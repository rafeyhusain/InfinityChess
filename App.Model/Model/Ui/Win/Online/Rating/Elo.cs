using System;
using System.Collections.Generic;
using System.Text;
using App.Model.Db;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace App.Model
{
    #region enum
    public enum EloKFactorTypeE
    {
        None,
        Fide
    }

    #endregion

    public class Elo
    {
        #region Data Members
        public int GameID = 0;
        #endregion

        #region Constructor

        public Elo()
        {

        }

        public Elo(App.Model.Db.Game game)
        {
            Game = game;
        }

        public Elo(int gameID)
        {
            GameID = gameID;
        }

        #endregion

        #region Contained Classes

        private App.Model.Db.Game game = null;

        public App.Model.Db.Game Game
        {
            [DebuggerStepThrough]
            get
            {
                if (game == null)
                {
                  //  game = new Game(Cxt.Instance, this.GameID);
                }

                return game;
            }
            [DebuggerStepThrough]
            set { game = value; }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Update(SqlTransaction t)
        {
            if (!game.IsRated)
            {
                return;
            }

            //Get both players datat
            UserGameType whiteUserData;
            UserGameType blackUserData;
            if (game.WhiteChessTypeID == 3)
            {
                whiteUserData = UserGameType.GetUserCentaurGameRating(game.Cxt, game.WhiteChessTypeID, game.GameTypeID, game.WhiteUserID);
            }
            else
            {
                whiteUserData = UserGameType.GetUserGameRating(game.Cxt, game.WhiteChessTypeID, game.GameTypeID, game.WhiteUserID);
            }
            if (game.BlackChessTypeID == 3)
            {
                blackUserData = UserGameType.GetUserCentaurGameRating(game.Cxt, game.BlackChessTypeID, game.GameTypeID, game.BlackUserID);
            }
            else
            {
                blackUserData = UserGameType.GetUserGameRating(game.Cxt, game.BlackChessTypeID, game.GameTypeID, game.BlackUserID);
            }

            //Calculate Wining Probablity of both players
            double eResultWhite = 0;
            double eResultBlack = 0;

            RatingWinProbablity winProbablity = RatingWinProbablities.Instance.GetRatingWinProbablity(game.EloWhiteBefore, game.EloBlackBefore);
            if (game.EloWhiteBefore >= game.EloBlackBefore)
            {
                eResultWhite = winProbablity.StrongerPlayer;
                eResultBlack = winProbablity.WeakerPlayer;
            }
            else
            {
                eResultBlack = winProbablity.StrongerPlayer;
                eResultWhite = winProbablity.WeakerPlayer;
            }

            //Calculate K-Factor -> Calculate Rating -> Save Rating -> Calculate Ranking -> Save Ranking
            switch (game.GameResultIDE)
            {
                case GameResultE.WhiteWin:
                    whiteUserData = CalculateRating(whiteUserData, 1, eResultWhite, game.WhiteUserID, t);
                    blackUserData = CalculateRating(blackUserData, 0, eResultBlack, game.BlackUserID, t);
                    break;
                case GameResultE.WhiteLose:
                    whiteUserData = CalculateRating(whiteUserData, 0, eResultWhite, game.WhiteUserID, t);
                    blackUserData = CalculateRating(blackUserData, 1, eResultBlack, game.BlackUserID, t);
                    break;
                case GameResultE.Draw:
                    whiteUserData = CalculateRating(whiteUserData, 0.5, eResultWhite, game.WhiteUserID, t);
                    blackUserData = CalculateRating(blackUserData, 0.5, eResultBlack, game.BlackUserID, t);
                    break;
            }

            //***********************************************************************
          
            if (Game.IsTournamentMatch)
            {
                TournamentUser.UpdateUsersEloAfter(t, Game.TournamentMatch.WhiteUserID, Game.TournamentMatch.BlackUserID, whiteUserData.EloRating, blackUserData.EloRating, Game.TournamentMatch.TournamentID);
            }

        }
        #endregion

        #region Private Methods
        private UserGameType CalculateRating(UserGameType item, double result, double eResult, int userID, SqlTransaction t)
        {

            //Calculate K-Factor of both player
            RatingKFactor kFactor;

            //UserGameType item;
            //Calculate Rating
                kFactor = RatingKFactors.Instance.GetRatingKFactor(item.EloRating, item.NoOfGames);
                item.NoOfGames = item.NoOfGames + 1;
                item.EloRating = item.EloRating + UData.ToInt32(System.Math.Round(kFactor.KFactor * (result - eResult)));
                item.StoredMatches = item.StoredMatches + 1;
            
            //SqlTransaction t = null;
            try
            {
                //t = SqlHelper.BeginTransaction(Config.ConnectionString);

                //Save Rating
                item.Save(t);

                //Calculate Ranking -> Save Ranking

                CalculateRanking(item, t);

                //SqlHelper.CommitTransaction(t);
            }
            catch (Exception ex)
            {
                //SqlHelper.RollbackTransaction(t);
                throw ex;
            }
            return item;
        }

        private void CalculateRanking(UserGameType userGame, SqlTransaction t)
        {
            User item = new User(game.Cxt, userGame.UserID);
            //Calculate Ranking
            if (item == null || item.UserID <= 16)
            {
                return;
            }
         
            RankRule rankRule = RankRules.Instance.GetRankRule(userGame.EloRating, userGame.NoOfGames, item.LoginDays.Days, userGame.ChessTypeID);

            switch (userGame.ChessTypeIDE)
            {
                case ChessTypeE.None:
                    break;
                case ChessTypeE.Human:
                    #region GameType
                    switch (game.GameTypeIDE)
                    {
                        case GameType.None:
                            break;
                        case GameType.Bullet:
                            break;
                        case GameType.Blitz:
                            item.HumanRankIDE = rankRule.RankIDE;
                            break;
                        case GameType.Rapid:
                            break;
                        case GameType.Long:
                            break;
                        default:
                            break;
                    } 
                    #endregion
                    break;
                case ChessTypeE.Engine:
                    #region GameType
                    switch (game.GameTypeIDE)
                    {
                        case GameType.None:
                            break;
                        case GameType.Bullet:
                            break;
                        case GameType.Blitz:
                            break;
                        case GameType.Rapid:
                            item.EngineRankIDE = rankRule.RankIDE;
                            break;
                        case GameType.Long:
                            break;
                        default:
                            break;
                    } 
                    #endregion
                    break;
                case ChessTypeE.Centaur:
                    item.CentaurRankIDE = rankRule.RankIDE;
                    break;
                case ChessTypeE.Correspondence:
                    item.CorrespondenceRankIDE = rankRule.RankIDE;
                    break;
            }

            //Save Ranking
            item.Save();
        }
        #endregion

        #endregion
    }
}
