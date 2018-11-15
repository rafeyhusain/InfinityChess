using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using App.Model.Db;
using System.Drawing;
using System.IO;
using System.Data.SqlClient;
using System.Diagnostics;
namespace App.Model
{
    public class GameDataKv : BaseDataKv
    {
        #region Ctor
        public GameDataKv()
        {
            Kv = new Kv(KvType.Web);
        }

        public GameDataKv(Kv kv)
        {
            base.Kv = kv;
        }

        #endregion

        #region Properties
        #region Auto Generated

        public int GameID { [DebuggerStepThrough]get { return Kv.GetInt32("GameID"); } [DebuggerStepThrough]set { Kv.Set("GameID", value); } }
        public int WhiteChessTypeID { [DebuggerStepThrough] get { return Kv.GetInt32("WhiteChessTypeID"); } [DebuggerStepThrough] set { Kv.Set("WhiteChessTypeID", value); } }
        public int BlackChessTypeID { [DebuggerStepThrough] get { return Kv.GetInt32("BlackChessTypeID"); } [DebuggerStepThrough]set { Kv.Set("BlackChessTypeID", value); } }
        public int GameTypeID { [DebuggerStepThrough]get { return Kv.GetInt32("GameTypeID"); } [DebuggerStepThrough] set { Kv.Set("GameTypeID", value); } }
        public int WhiteUserID { [DebuggerStepThrough] get { return Kv.GetInt32("WhiteUserID"); } [DebuggerStepThrough] set { Kv.Set("WhiteUserID", value); } }
        public int BlackUserID { [DebuggerStepThrough] get { return Kv.GetInt32("BlackUserID"); } [DebuggerStepThrough] set { Kv.Set("BlackUserID", value); } }
        public int GameResultID { [DebuggerStepThrough] get { return Kv.GetInt32("GameResultID"); } [DebuggerStepThrough] set { Kv.Set("GameResultID", value); } }
        public int TournamentMatchID { [DebuggerStepThrough] get { return Kv.GetInt32("TournamentMatchID"); } [DebuggerStepThrough] set { Kv.Set("TournamentMatchID", value); } }
        public int EloWhite { [DebuggerStepThrough] get { return Kv.GetInt32("EloWhite"); } [DebuggerStepThrough] set { Kv.Set("EloWhite", value); } }
        public int EloBlack { [DebuggerStepThrough]get { return Kv.GetInt32("EloBlack"); } [DebuggerStepThrough] set { Kv.Set("EloBlack", value); } }
        public int EloWhiteAfter { [DebuggerStepThrough]get { return Kv.GetInt32("EloWhiteAfter"); } [DebuggerStepThrough]set { Kv.Set("EloWhiteAfter", value); } }
        public int EloBlackAfter { [DebuggerStepThrough] get { return Kv.GetInt32("EloBlackAfter"); } [DebuggerStepThrough] set { Kv.Set("EloBlackAfter", value); } }
        public int RoomID { [DebuggerStepThrough] get { return Kv.GetInt32("RoomID"); } [DebuggerStepThrough] set { Kv.Set("RoomID", value); } }
        public int ChallengeID { [DebuggerStepThrough] get { return Kv.GetInt32("ChallengeID"); } [DebuggerStepThrough]set { Kv.Set("ChallengeID", value); } }
        public int TimeMin { [DebuggerStepThrough]get { return Kv.GetInt32("TimeMin"); } [DebuggerStepThrough]set { Kv.Set("TimeMin", value); } }
        public int GainPerMoveMin { [DebuggerStepThrough]get { return Kv.GetInt32("GainPerMoveMin"); } [DebuggerStepThrough]set { Kv.Set("GainPerMoveMin", value); } }
        public int TimeMax { [DebuggerStepThrough]get { return Kv.GetInt32("TimeMax"); } [DebuggerStepThrough]set { Kv.Set("TimeMax", value); } }
        public int GainPerMoveMax { [DebuggerStepThrough]get { return Kv.GetInt32("GainPerMoveMax"); } [DebuggerStepThrough]set { Kv.Set("GainPerMoveMax", value); } }
        public string Description { [DebuggerStepThrough] get { return Kv.Get("Description"); } [DebuggerStepThrough]set { Kv.Set("Description", value); } }
        public string GameXml { [DebuggerStepThrough]get { return Kv.Get("GameXml"); } [DebuggerStepThrough]set { Kv.Set("GameXml", value); } }
        public DateTime StartDate { [DebuggerStepThrough]get { return Kv.GetDateTime("StartDate"); } [DebuggerStepThrough]set { Kv.Set("StartDate", value); } }
        public bool IsRated { [DebuggerStepThrough]get { return Kv.GetBool("IsRated"); } [DebuggerStepThrough]set { Kv.Set("IsRated", value); } }
        public int WhiteEngineID { [DebuggerStepThrough] get { return Kv.GetInt32("WhiteEngineID"); } [DebuggerStepThrough]set { Kv.Set("WhiteEngineID", value); } }
        public int BlackEngineID { [DebuggerStepThrough] get { return Kv.GetInt32("BlackEngineID"); } [DebuggerStepThrough]set { Kv.Set("BlackEngineID", value); } }
        public bool IsChallengerSendsGame { [DebuggerStepThrough]get { return Kv.GetBool("IsChallengerSendsGame"); } [DebuggerStepThrough]set { Kv.Set("IsChallengerSendsGame", value); } }
        
        #endregion
        #endregion

        #region Methods

        public DataSet AddGame(bool isOfferedReMatch)
        {
            try
            {
                #region Get Game Data

                int challengeID = Kv.GetInt32("ChallengeID");
                int currentUserID = Kv.GetInt32(StdKv.CurrentUserID);  //opponent user id //using StdKv.CurrentUserID because of some reason -----base.Kv.Cxt.CurrentUserID
                int opponentChessTypeID = Kv.GetInt32("ChessTypeID");

                DataSet gds = App.Model.Db.Game.GetGameData(challengeID, currentUserID, opponentChessTypeID, isOfferedReMatch);
                if (gds.Tables.Count < 2)
                {
                    return null;
                }

                gds.Tables[0].TableName = "Challenge";
                gds.Tables[1].TableName = "Users";
                gds.Tables[2].TableName = "UserGameTypes";
                gds.Tables[3].TableName = "Engines";

                if (gds.Tables.Count > 4)
                {
                    gds.Tables[4].TableName = "TournamentMatch";
                    gds.Tables[5].TableName = "Tournament";
                }

                Challenge c = new Challenge(base.Kv.Cxt, gds.Tables["Challenge"].Rows[0]);
                Users us = new Users(base.Kv.Cxt, gds.Tables["Users"]);

                User uc = us[0];
                User uo = us[1];

                //if (currentUserID == uc.UserID)
                //{
                //    if (uo.UserStatusIDE == UserStatusE.Playing || uo.UserStatusIDE == UserStatusE.Gone || uo.UserStatusIDE == UserStatusE.Kibitzer)
                //    {
                //        return null;
                //    }
                //}
                //else
                //{
                //    if (uc.UserStatusIDE == UserStatusE.Playing || uc.UserStatusIDE == UserStatusE.Gone || uc.UserStatusIDE == UserStatusE.Kibitzer)
                //    {
                //        return null;
                //    }
                //}

                UserGameTypes ugts = new UserGameTypes(base.Kv.Cxt, gds.Tables["UserGameTypes"]);
                UserGameType ugtc = new UserGameType();
                UserGameType ugto = new UserGameType();

                switch (ugts.Count)
                {
                    case 1:
                        ugtc = ugts[0];
                        break;
                    case 2:
                        ugtc = ugts[0];
                        ugto = ugts[1];
                        break;
                }

                if (c.ChallengerUserID != ugtc.UserID)
                {
                    UserGameType ugtt = ugtc;
                    ugtc = ugto;
                    ugto = ugtt;
                }

                if (c.ChallengerUserID != uc.UserID)
                {
                    User ut = uc;
                    uc = uo;
                    uo = ut;
                }

                #endregion

                #region Save Game
                SqlTransaction t = null;
                App.Model.Db.Game item = new App.Model.Db.Game();

                if (c.ChessTypeIDE == ChessTypeE.Engine || c.ChessTypeIDE == ChessTypeE.Centaur)
                {
                    if (ugtc.EloRating == 0)
                        ugtc.EloRating = 2200;
                }
                else
                {
                    if (ugtc.EloRating == 0)
                        ugtc.EloRating = 1500;

                }

                if ((ChessTypeE)opponentChessTypeID == ChessTypeE.Engine || (ChessTypeE)opponentChessTypeID == ChessTypeE.Centaur)
                {
                    if (ugto.EloRating == 0)
                        ugto.EloRating = 2200;
                }
                else
                {
                    if (ugto.EloRating == 0)
                        ugto.EloRating = 1500;
                }


                try
                {

                    switch (c.ColorIDE)
                    {
                        //case ColorE.Autometic:
                        case ColorE.White:
                            item.WhiteUserID = ugtc.UserID == 0 ? c.ChallengerUserID : ugtc.UserID;
                            item.BlackUserID = ugto.UserID == 0 ? currentUserID : ugto.UserID;
                            item.EloWhiteBefore = ugtc.EloRating;
                            item.EloBlackBefore = ugto.EloRating;
                            item.WhiteEngineID = uc.EngineID;
                            item.BlackEngineID = uo.EngineID;
                            item.WhiteChessTypeID = c.ChessTypeID;
                            item.BlackChessTypeID = opponentChessTypeID;
                            break;
                        case ColorE.Black:
                            item.BlackUserID = ugtc.UserID == 0 ? c.ChallengerUserID : ugtc.UserID;
                            item.WhiteUserID = ugto.UserID == 0 ? currentUserID : ugto.UserID;
                            item.EloBlackBefore = ugtc.EloRating;
                            item.EloWhiteBefore = ugto.EloRating;
                            item.BlackEngineID = uc.EngineID;
                            item.WhiteEngineID = uo.EngineID;
                            item.WhiteChessTypeID = opponentChessTypeID;
                            item.BlackChessTypeID = c.ChessTypeID;
                            break;
                    }

                    item.IsRated = c.IsRated;
                    item.IsChallengerSendsGame = c.IsChallengerSendsGame;
                    item.ChallengeID = c.ChallengeID;
                    item.GameResultIDE = GameResultE.InProgress;
                    item.GameTypeID = c.GameTypeID;
                    item.StartDate = DateTime.Now;
                    item.TimeMin = c.TimeMin;
                    item.GainPerMoveMin = c.GainPerMoveMin;
                    item.RoomID = c.RoomID;
                    item.GameXml = "";
                    if (c.TournamentMatchID != 0)
                        item.TournamentMatchID = c.TournamentMatchID;

                    t = SqlHelper.BeginTransaction(Config.ConnectionString);

                    Challenges.UpdateAllChallenges(t, c.ID, currentUserID, c.ChallengerUserID);

                    item.Save(t);

                    SqlHelper.CommitTransaction(t);
                }
                catch (Exception ex)
                {
                    SqlHelper.RollbackTransaction(t);
                    //throw ex;
                    Log.Write(base.Kv.Cxt, ex);
                }
                #endregion

                #region Return Game DataSet
                item.DataRow.Table.TableName = "Game";
                gds.Tables.Add(item.DataRow.Table.Copy());

                gds.Tables.Remove("UserGameTypes");

                return gds;
                #endregion
            }
            catch (Exception ex)
            {
                Log.Write(Kv.Cxt, ex);
                return null;
            }
        }

        public void UpdateGame()
        {
            App.Model.Db.Game item = new App.Model.Db.Game(base.Kv.Cxt, Kv.GetInt32("GameID"));

            if (!string.IsNullOrEmpty(Kv.Get("GameXml")))
            {
                item.GameXml = Kv.Get("GameXml");
            }

            item.GameResultID = Kv.GetInt32("GameResult");
            item.GameFlags = Kv.Get("GameFlags");
            item.Save();
        }

        public bool DeleteGame()
        {
            return false;
        }

        
        #endregion
    }
}
