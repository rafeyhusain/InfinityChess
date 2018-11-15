// (c) Copyright RafeySoft, Karachi Pakistan. http://rafeysoft.com
// This source is subject to following License:
// http://rafeysoft.com/Web/Page/ItemEdit.aspx?sid=29&lid=4&cid=23&iid=2143
// Please write to info@rafeysoft.com for more information
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using System.Diagnostics;
namespace App.Model.Db
{
    public class Game : BaseItem
    {
        #region Constructor
        public Game()
            : base(0)
        {
        }

        public Game(Cxt cxt)
            : base(0)
        {
            base.Cxt = cxt;
        }

        public Game(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public Game(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public Game(Cxt cxt, DataRow row)
        {
            Cxt = cxt;

            DataRow = row;
        }


        #endregion

        #region Properties

        #region Core
        public override InfiChess TableName
        {
            [DebuggerStepThrough]
            get { return InfiChess.Game; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion

        #region Enum
        public GameResultE GameResultIDE { [DebuggerStepThrough] get { return (GameResultE)this.GameResultID; } [DebuggerStepThrough] set { this.GameResultID = (int)value; } }
        public GameType GameTypeIDE { [DebuggerStepThrough] get { return (GameType)this.GameTypeID; } [DebuggerStepThrough] set { this.GameTypeID = (int)value; } }
        public ChessTypeE WhiteChessTypeIDE { [DebuggerStepThrough]get { return (ChessTypeE)this.WhiteChessTypeID; } [DebuggerStepThrough] set { this.WhiteChessTypeID = (int)value; } }
        public ChessTypeE BlackChessTypeIDE { [DebuggerStepThrough]get { return (ChessTypeE)this.BlackChessTypeID; } [DebuggerStepThrough] set { this.BlackChessTypeID = (int)value; } }

        #endregion

        #region Generated

        public int GameID { [DebuggerStepThrough]get { return GetColInt32("GameID"); } [DebuggerStepThrough] set { SetColumn("GameID", value); } }
        public int WhiteChessTypeID { [DebuggerStepThrough] get { return GetColInt32("WhiteChessTypeID"); } [DebuggerStepThrough]set { SetColumn("WhiteChessTypeID", value); } }
        public int BlackChessTypeID { [DebuggerStepThrough] get { return GetColInt32("BlackChessTypeID"); } [DebuggerStepThrough] set { SetColumn("BlackChessTypeID", value); } }
        public int GameTypeID { [DebuggerStepThrough]get { return GetColInt32("GameTypeID"); } [DebuggerStepThrough] set { SetColumn("GameTypeID", value); } }
        public int WhiteUserID { [DebuggerStepThrough] get { return GetColInt32("WhiteUserID"); } [DebuggerStepThrough] set { SetColumn("WhiteUserID", value); } }
        public int BlackUserID { [DebuggerStepThrough] get { return GetColInt32("BlackUserID"); } [DebuggerStepThrough]set { SetColumn("BlackUserID", value); } }
        public int GameResultID { [DebuggerStepThrough] get { return GetColInt32("GameResultID"); } [DebuggerStepThrough] set { SetColumn("GameResultID", value); } }
        public int EloWhiteBefore { [DebuggerStepThrough] get { return GetColInt32("EloWhiteBefore"); } [DebuggerStepThrough]set { SetColumn("EloWhiteBefore", value); } }
        public int EloBlackBefore { [DebuggerStepThrough]get { return GetColInt32("EloBlackBefore"); } [DebuggerStepThrough]set { SetColumn("EloBlackBefore", value); } }
        public int EloWhiteAfter { [DebuggerStepThrough]get { return GetColInt32("EloWhiteAfter"); } [DebuggerStepThrough]set { SetColumn("EloWhiteAfter", value); } }
        public int EloBlackAfter { [DebuggerStepThrough] get { return GetColInt32("EloBlackAfter"); } [DebuggerStepThrough]set { SetColumn("EloBlackAfter", value); } }
        public int RoomID { [DebuggerStepThrough] get { return GetColInt32("RoomID"); } [DebuggerStepThrough] set { SetColumn("RoomID", value); } }
        public int ChallengeID { [DebuggerStepThrough] get { return GetColInt32("ChallengeID"); } [DebuggerStepThrough] set { SetColumn("ChallengeID", value); } }

        public int TimeMin { [DebuggerStepThrough]get { return GetColInt32("TimeMin"); } [DebuggerStepThrough]set { SetColumn("TimeMin", value); } }
        public int GainPerMoveMin { [DebuggerStepThrough]get { return GetColInt32("GainPerMoveMin"); } [DebuggerStepThrough]set { SetColumn("GainPerMoveMin", value); } }
        public int TimeMax { [DebuggerStepThrough]get { return GetColInt32("TimeMax"); } [DebuggerStepThrough]set { SetColumn("TimeMax", value); } }
        public int GainPerMoveMax { [DebuggerStepThrough]get { return GetColInt32("GainPerMoveMax"); } [DebuggerStepThrough]set { SetColumn("GainPerMoveMax", value); } }

        public string GameXml { [DebuggerStepThrough]get { return GetCol("GameXml"); } [DebuggerStepThrough] set { SetColumn("GameXml", value); } }
        public DateTime StartDate { [DebuggerStepThrough]get { return GetColDateTime("StartDate"); } [DebuggerStepThrough]set { SetColumn("StartDate", value); } }
        public bool IsRated { [DebuggerStepThrough]get { return GetColBool("IsRated"); } [DebuggerStepThrough] set { SetColumn("IsRated", value); } }
        public int TournamentMatchID { [DebuggerStepThrough]get { return GetColInt32("TournamentMatchID"); } [DebuggerStepThrough] set { SetColumn("TournamentMatchID", value); } }
        public int WhiteEngineID { [DebuggerStepThrough] get { return GetColInt32("WhiteEngineID"); } [DebuggerStepThrough]set { SetColumn("WhiteEngineID", value); } }
        public int BlackEngineID { [DebuggerStepThrough]get { return GetColInt32("BlackEngineID"); } [DebuggerStepThrough]set { SetColumn("BlackEngineID", value); } }
        public bool IsChallengerSendsGame { [DebuggerStepThrough] get { return GetColBool("IsChallengerSendsGame"); } [DebuggerStepThrough]set { SetColumn("IsChallengerSendsGame", value); } }
        public string GameFlags { [DebuggerStepThrough] get { return GetCol("GameFlags"); } [DebuggerStepThrough] set { SetColumn("GameFlags", value); } }

        #endregion

        #region Contained Classes
        private User whiteUser = null;
        public User WhiteUser
        {
            [DebuggerStepThrough]
            get
            {
                if (whiteUser == null)
                {
                    whiteUser = new User(Cxt, this.WhiteUserID);
                }

                return whiteUser;
            }
            [DebuggerStepThrough]
            set { whiteUser = value; }
        }

        private User blackUser = null;
        public User BlackUser
        {
            [DebuggerStepThrough]
            get
            {
                if (blackUser == null)
                {
                    blackUser = new User(Cxt, this.BlackUserID);
                }

                return blackUser;
            }
            [DebuggerStepThrough]
            set { blackUser = value; }
        }

        private TournamentMatch tournamentMatch = null;
        public TournamentMatch TournamentMatch
        {
            [DebuggerStepThrough]
            get
            {
                if (tournamentMatch == null)
                {
                    tournamentMatch = new TournamentMatch(Cxt, this.TournamentMatchID);
                }

                return tournamentMatch;
            }
            [DebuggerStepThrough]
            set { tournamentMatch = value; }
        }

        private Challenge challenge = null;
        public Challenge Challenge
        {
            [DebuggerStepThrough]
            get
            {
                if (challenge == null)
                {
                    challenge = new Challenge(Cxt, this.ChallengeID);
                }

                return challenge;
            }
            [DebuggerStepThrough]
            set { challenge = value; }
        }
        #endregion

        #region Calculated
        public bool IsTournamentMatch { [DebuggerStepThrough] get { return this.TournamentMatchID == 0 ? false : true; } }
        public bool IsKibitzer { [DebuggerStepThrough]get { return (this.GameResultIDE != GameResultE.InProgress || (this.WhiteUserID != Cxt.CurrentUserID && this.BlackUserID != Cxt.CurrentUserID)); } }
        public bool IsCurrentUserWhite { [DebuggerStepThrough] get { return this.WhiteUserID == Cxt.CurrentUserID; } }
        public bool IsCurrentUserBlack { [DebuggerStepThrough] get { return this.BlackUserID == Cxt.CurrentUserID; } }
        public bool IsCurrentUserAudiance { [DebuggerStepThrough] get { return !IsCurrentUserWhite && !IsCurrentUserBlack; } }
        public bool IsFinished { [DebuggerStepThrough] get { return GameResultIDE != GameResultE.None && GameResultIDE != GameResultE.InProgress; } }
        public bool IsEloWhiteUpated { [DebuggerStepThrough] get { return (EloWhiteAfter != 0) ? false : true; } }
        public bool IsEloBlackUpated { [DebuggerStepThrough] get { return (EloBlackAfter != 0) ? false : true; } }
        public int OpponentUserID
        {
            get
            {
                if (IsCurrentUserWhite)
                    return BlackUserID;
                else if (IsCurrentUserBlack)
                    return WhiteUserID;
                else return 0;
            }
        }
        #endregion
        #endregion

        #region Methods

        #region GetGameData

        public static DataSet GetGameDataByGameID(Cxt cxt, int gameId)
        {
            DataSet ds = new DataSet();
            ds = BaseCollection.ExecuteDataset("GetGameByGameID", gameId);
            ds.Tables[0].TableName = "Challenge";
            ds.Tables[1].TableName = "Game";
            ds.Tables[2].TableName = "Users";
            ds.Tables[3].TableName = "Engines";
            ds.Tables[4].TableName = "TournamentMatch";
            ds.Tables[5].TableName = "Tournament";

            return ds;
        }

        public static DataSet GetGameDataByChallengeID(DataTable dt)
        {
            Kv kv = new Kv(dt);
            DataSet ds = new DataSet();
            ds = BaseCollection.ExecuteDataset("GetGameByChallengeID", kv.GetInt32("ChallengeID"), kv.GetInt32(StdKv.CurrentUserID));
            ds.Tables[0].TableName = "Challenge";
            ds.Tables[1].TableName = "Game";
            ds.Tables[2].TableName = "Users";
            ds.Tables[3].TableName = "Engines";
            ds.Tables[4].TableName = "TournamentMatch";
            ds.Tables[5].TableName = "Tournament";

            return ds;
        }

        public static DataSet GetGameData(int challengeID, int opponentUserID, int opponentChessTypeID, bool isOfferedReMatch)
        {
            return BaseCollection.ExecuteDataset("GetGameData", challengeID, opponentUserID, opponentChessTypeID, isOfferedReMatch);
        }

        public static DataSet GetLastInprogressGame(int userId)
        {
            DataSet ds = BaseCollection.ExecuteDataset("GetLastInprogressGame", userId);
            ds.Tables[0].TableName = "Challenge";
            ds.Tables[1].TableName = "Game";
            ds.Tables[2].TableName = "Users";
            ds.Tables[3].TableName = "Engines";
            ds.Tables[4].TableName = "TournamentMatch";
            ds.Tables[5].TableName = "Tournament";
            return ds;
        }

        public static Game GetGameByID(Cxt cxt, int tournamentMatchID)
        {
            return new Game(cxt, BaseCollection.SelectItem(InfiChess.Game, "TournamentMatchID", tournamentMatchID));
        }

        public static DataTable GetHighestRankingPlayerGame(Cxt cxt)
        {
            return BaseCollection.Execute("GetHighestRankingPlayerGame", cxt.CurrentUserID);
        }

        #endregion

        #region Contained Methods
        public static Game CreateGame(Cxt cxt, DataSet gds)
        {
            Game g = null;

            if (gds == null)
            {
                return null;
            }

            if (gds.Tables["Game"] == null)
            {
                return null;
            }

            if (gds.Tables["Game"].Rows.Count == 0)
            {
                return null;
            }

            g = new App.Model.Db.Game(cxt, gds.Tables["Game"].Rows[0]);

            if (gds.Tables["Challenge"] != null)
            {
                if (gds.Tables["Challenge"].Rows.Count > 0)
                {
                    g.Challenge = new Challenge(cxt, gds.Tables["Challenge"].Rows[0]);
                }
            }

            User uc = new User(cxt, gds.Tables["Users"].Rows[0]);
            User uo = new User(cxt, gds.Tables["Users"].Rows[1]);

            Engine ec = new Engine(cxt, gds.Tables["Engines"].Rows[0]);
            Engine eo = new Engine(cxt, gds.Tables["Engines"].Rows[1]);

            if (uc.EngineID == ec.EngineID)
            {
                uc.Engine = ec;
                uo.Engine = eo;
            }
            else
            {
                uc.Engine = eo;
                uo.Engine = ec;
            }

            if (g.WhiteUserID == uc.ID)
            {
                g.WhiteUser = uc;
                g.BlackUser = uo;
            }
            else
            {
                g.WhiteUser = uo;
                g.BlackUser = uc;
            }

            if (gds.Tables.Count > 4 && (gds.Tables.Contains("TournamentMatch") || gds.Tables.Contains("Tournament")))
            {

                TournamentMatch tm = new TournamentMatch(cxt, gds.Tables["TournamentMatch"].Rows[0]);
                Tournament t = new Tournament(cxt, gds.Tables["Tournament"].Rows[0]);

                tm.Tournament = t;
                g.TournamentMatch = tm;
            }

            return g;
        }

        public static GameType GetGameType(int min, int sec)
        {
            float gameTime = min + ((float)sec / 60);

            if (gameTime <= 2)
            {
                //Bullet Game
                return GameType.Bullet;
            }
            else if (gameTime <= 10)
            {
                //Blitz Game
                return GameType.Blitz;
            }
            else if (gameTime <= 60)
            {
                //Rapid Game
                return GameType.Rapid;
            }
            else
            {
                //Long Game
                return GameType.Long;
            }
        }

        #endregion

        #region Override Methods
        public override void Save()
        {            
            System.Data.SqlClient.SqlTransaction t = SqlHelper.BeginTransaction(Config.ConnectionString);

            try
            {
                if (GameResultIDE != GameResultE.InProgress && GameResultIDE != GameResultE.None && GameResultIDE != GameResultE.NoResult)
                {
                    if (GameResultIDE != GameResultE.WhiteBye || GameResultIDE != GameResultE.BlackBye)
                    {
                        Elo e = new Elo(this);
                        e.Update(t);
                    }

                    if (this.Challenge.Stake > 0 && this.Challenge.Flate != 0)
                        UserFini.UpdateFiniTransfer(t, base.Cxt, this, this.Challenge.Stake, this.Challenge.Flate);

                    if (this.IsTournamentMatch)
                    {
                        if (this.GameResultIDE == GameResultE.Draw)
                        {
                            this.TournamentMatch.TournamentMatchStatusE = TournamentMatchStatusE.Draw;
                            this.TournamentMatch.GameResultID = this.GameResultID;
                            this.TournamentMatch.Save(t);                                                        
                        }
                        else
                        {
                            string matchID = this.TournamentMatch.TournamentMatchID.ToString();
                            this.TournamentMatch.GameResultID = this.GameResultID;
                            TournamentMatches.UpdateStatus(t, base.Cxt, TournamentMatchStatusE.Finsihed, matchID, this.GameResultIDE);
                        }

                        this.TournamentMatch.UpdateUserPoints(t);
                    }
                }
                
                base.Save(t);

                SqlHelper.CommitTransaction(t);
                if (IsFinished)
                {
                    TournamentMatch.CreateChildMatchIfRequired(Cxt, this.TournamentMatch, null);
                }
            }
            catch (Exception ex)
            {
                SqlHelper.RollbackTransaction(t);
                Log.Write(Cxt, ex);
            }
        }

        #endregion

        #endregion

        public static string GetGameXML(string xml)
        {
            xml = xml.Replace("<DocumentElement>", "<NewDataSet>");
            xml = xml.Replace("</DocumentElement>", "</NewDataSet>");
            return xml;
        }

        public static Game RestartGameByMoveID(Cxt cxt, int gameID, int moveID, int wMin, int wSec, int bMin, int bSec)
        {
            Game g = new Game(cxt, gameID);
            
            Moves moves = new Moves(g.GameXml);

            moves.TruncateAfter(moveID);

            Move ml = moves.Last;

            ml.MoveTimeWhite = wMin + wSec;
            ml.MoveTimeBlack = bMin + bSec;

            g.GameXml = GetGameXML(UData.ToString(moves.DataTable));
            
            g.Save();

            return g;
        }
    }
}


