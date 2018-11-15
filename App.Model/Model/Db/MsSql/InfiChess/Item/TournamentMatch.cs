using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
namespace App.Model.Db
{

    public class TournamentMatch : BaseItem
    {
        #region Constructor
        public TournamentMatch()
            : base(0)
        {
            
        }

        public TournamentMatch(Cxt cxt, int id)
            : base(cxt, id)
        {
            
        }

        public TournamentMatch(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
            
        }

        public TournamentMatch(Cxt cxt, DataRow row)
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
            get { return InfiChess.TournamentMatch; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion

        #region Enum

        public TournamentMatchStatusE TournamentMatchStatusE { [DebuggerStepThrough] get { return (TournamentMatchStatusE)this.TournamentMatchStatusID; } [DebuggerStepThrough] set { this.TournamentMatchStatusID = (int)value; } }
        public TournamentMatchTypeE TournamentMatchTypeE { [DebuggerStepThrough] get { return (TournamentMatchTypeE)this.TournamentMatchTypeID; } [DebuggerStepThrough] set { this.TournamentMatchTypeID = (int)value; } }
        public GameResultE GameResultIDE { [DebuggerStepThrough] get { return (GameResultE)this.GameResultID; } [DebuggerStepThrough] set { this.GameResultID = (int)value; } }
        public StatusE StatusIDE { [DebuggerStepThrough] get { return (StatusE)this.StatusID; } [DebuggerStepThrough] set { this.StatusID = (int)value; } }
        #endregion

        #region Generated
        public int GameResultID { [DebuggerStepThrough] get { return GetColInt32("GameResultID"); } [DebuggerStepThrough]set { SetColumn("GameResultID", value); } }
        public int TournamentMatchID { [DebuggerStepThrough] get { return GetColInt32("TournamentMatchID"); } [DebuggerStepThrough]set { SetColumn("TournamentMatchID", value); } }
        public int TournamentID { [DebuggerStepThrough] get { return GetColInt32("TournamentID"); } [DebuggerStepThrough] set { SetColumn("TournamentID", value); } }
        public int WhiteUserID { [DebuggerStepThrough] get { return GetColInt32("WhiteUserID"); } [DebuggerStepThrough] set { SetColumn("WhiteUserID", value); } }
        public int BlackUserID { [DebuggerStepThrough] get { return GetColInt32("BlackUserID"); } [DebuggerStepThrough] set { SetColumn("BlackUserID", value); } }
        public int Round { [DebuggerStepThrough] get { return GetColInt32("Round"); } [DebuggerStepThrough] set { SetColumn("Round", value); } }
        public int TournamentMatchStatusID { [DebuggerStepThrough] get { return GetColInt32("TournamentMatchStatusID"); } [DebuggerStepThrough] set { SetColumn("TournamentMatchStatusID", value); } }
        public DateTime MatchStartDate { [DebuggerStepThrough] get { return GetColDateTime("MatchStartDate"); } [DebuggerStepThrough] set { SetColumn("MatchStartDate", value); } }
        public DateTime MatchStartTime { [DebuggerStepThrough] get { return GetColDateTime("MatchStartTime"); } [DebuggerStepThrough] set { SetColumn("MatchStartTime", value); } }
        public int EloWhiteBefore { [DebuggerStepThrough] get { return GetColInt32("EloWhiteBefore"); } [DebuggerStepThrough] set { SetColumn("EloWhiteBefore", value); } }
        public int EloBlackBefore { [DebuggerStepThrough] get { return GetColInt32("EloBlackBefore"); } [DebuggerStepThrough] set { SetColumn("EloBlackBefore", value); } }
        public int EloWhiteAfter { [DebuggerStepThrough] get { return GetColInt32("EloWhiteAfter"); } [DebuggerStepThrough] set { SetColumn("EloWhiteAfter", value); } }
        public int EloBlackAfter { [DebuggerStepThrough] get { return GetColInt32("EloBlackAfter"); } [DebuggerStepThrough] set { SetColumn("EloBlackAfter", value); } }
        public int ParentMatchID { [DebuggerStepThrough] get { return GetColInt32("ParentMatchID"); } [DebuggerStepThrough] set { SetColumn("ParentMatchID", value); } }
        public int TimeMin { [DebuggerStepThrough] get { return GetColInt32("TimeMin"); } [DebuggerStepThrough] set { SetColumn("TimeMin", value); } }
        public int TimeSec { [DebuggerStepThrough] get { return GetColInt32("TimeSec"); } [DebuggerStepThrough] set { SetColumn("TimeSec", value); } }
        public int TournamentMatchTypeID { [DebuggerStepThrough] get { return GetColInt32("TournamentMatchTypeID"); } [DebuggerStepThrough] set { SetColumn("TournamentMatchTypeID", value); } }
        public int StatusID { [DebuggerStepThrough]get { return GetColInt32("StatusID"); } [DebuggerStepThrough]set { SetColumn("StatusID", value); } }
        #endregion

        #region Contained Classes

        private Tournament tournament = null;
        public Tournament Tournament
        {
            [DebuggerStepThrough]
            get
            {
                if (tournament == null)
                {
                    tournament = new Tournament(Cxt, this.TournamentID);
                }

                return tournament;
            }
            [DebuggerStepThrough]
            set { tournament = value; }
        }

        #endregion

        #region Calculated
        public bool IsBye { [DebuggerStepThrough] get { return TournamentMatchStatusE == TournamentMatchStatusE.WhiteBye || TournamentMatchStatusE == TournamentMatchStatusE.BlackBye; } }
        public bool IsNotBye { [DebuggerStepThrough] get { return !IsBye; } }
        public bool IsForced { [DebuggerStepThrough] get { return TournamentMatchStatusE == TournamentMatchStatusE.ForcedWhiteWin || TournamentMatchStatusE == TournamentMatchStatusE.ForcedWhiteLose || TournamentMatchStatusE == TournamentMatchStatusE.ForcedDraw; } }
        public bool IsNotForced { [DebuggerStepThrough] get { return !IsForced; } }

        #endregion
        #endregion

        #region Methods
        [DebuggerStepThrough]
        public int OpponentUserID(int userID)
        {
            if (userID == WhiteUserID)
            {
                return BlackUserID;
            }
            else
            {
                return WhiteUserID;
            }
        }

        #region GetTournamentMatchId

        public static TournamentMatch GetTournamentMatchByID(Cxt cxt, int tournamentMatchID)
        {
            return new TournamentMatch(cxt, BaseCollection.SelectItem(InfiChess.TournamentMatch, tournamentMatchID));
        }
        public static TournamentMatch GetTournamntMatchByTournamentAndPlayerID(Cxt cxt, int tournamentMatchID)
        {
            return new TournamentMatch(cxt, BaseCollection.SelectItem(InfiChess.TournamentMatch, tournamentMatchID));
        }

        public static DataTable GetTournamntMatchesByParentID(int tournamentMatchParentID)
        {
            return BaseCollection.Select(InfiChess.TournamentMatch, "ParentMatchID = " + tournamentMatchParentID);
        }

        #endregion

        public static bool GetTournamentMatchByTournamentUserID(Cxt cxt, int tournamentID, int userID)
        {
            bool result = false;

            DataTable dt = BaseCollection.Execute("GetTournamentMatchByTournamentUserID", tournamentID, userID);

            if (dt.Rows.Count > 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        //public void Save()
        //{

        //    //SqlTransaction trans = null;

        //    try
        //    {
        //        //trans = SqlHelper.BeginTransaction(Config.ConnectionString);

        //        this.Save(trans);                    

        //        //Challenge Challenge = Challenge.CreateChallenge(this);
        //        //Challenge.Save(trans);

        //        //SqlHelper.CommitTransaction(trans);
        //    }

        //    catch (Exception ex)
        //    {
        //        //SqlHelper.RollbackTransaction(trans);
        //        Log.Write(base.Cxt, ex);
        //    }
        //}        

        public void UpdateUserPoints(SqlTransaction t)
        {
            double wPoints = 0;
            double bPoints = 0;

            switch (this.GameResultIDE)
            {
                case GameResultE.WhiteWin:
                    wPoints = 1;
                    bPoints = 0;
                    break;
                case GameResultE.WhiteLose:
                    wPoints = 0;
                    bPoints = 1;
                    break;
                case GameResultE.Draw:
                    wPoints = 0.5;
                    bPoints = 0.5;
                    break;
            }        

            BaseCollection.ExecuteSql2(t, "Update TournamentUser set TournamentPoints = ISNULL(TournamentPoints,0) + " + wPoints + " where IsNull(UserID2, UserID) = " + this.WhiteUserID + " and TournamentID = " + this.TournamentID);
            BaseCollection.ExecuteSql2(t, "Update TournamentUser set TournamentPoints = ISNULL(TournamentPoints,0) + " + bPoints + " where IsNull(UserID2, UserID) = " + this.BlackUserID + " and TournamentID = " + this.TournamentID);
        }

        /*
	                        S	P	F	PP	A	D	WB	BB	FW	FL	FD
            Scheduled		X		X	X		X	X	X	X	X
            In Progress							X	X	X	X	X
            Finsihed									X	X	X
            Postpond	    X										
            Absent	        X						X	X	X	X	X
            Draw									X	X	X
            WhiteBye	    X							X	X	X	X
            BlackBye	    X						X		X	X	X
            Forced White Win									X	X
            Forced White Lose								X		X
            Forced Draw 									X	X	
         */
        public static bool CanChangeStatus(TournamentMatchStatusE currentStatusID, TournamentMatchStatusE requiredStatusID)
        {
            switch (currentStatusID)
            {
                case TournamentMatchStatusE.None:
                    return false;

                case TournamentMatchStatusE.Scheduled:
                    #region Check Required
                    switch (requiredStatusID)
                    {
                        case TournamentMatchStatusE.None:
                        case TournamentMatchStatusE.Draw:
                        case TournamentMatchStatusE.Finsihed:
                        case TournamentMatchStatusE.Scheduled:
                            return false;

                        case TournamentMatchStatusE.InProgress:
                        case TournamentMatchStatusE.Postpond:
                        case TournamentMatchStatusE.Absent:
                        case TournamentMatchStatusE.WhiteBye:
                        case TournamentMatchStatusE.BlackBye:
                        case TournamentMatchStatusE.ForcedWhiteWin:
                        case TournamentMatchStatusE.ForcedWhiteLose:
                        case TournamentMatchStatusE.ForcedDraw:
                            return true;
                    }
                    #endregion
                    break;

                case TournamentMatchStatusE.InProgress:
                    #region Check Required
                    switch (requiredStatusID)
                    {
                        case TournamentMatchStatusE.None:
                        case TournamentMatchStatusE.Scheduled:
                        case TournamentMatchStatusE.InProgress:
                        case TournamentMatchStatusE.Finsihed:
                        case TournamentMatchStatusE.Postpond:
                        case TournamentMatchStatusE.Absent:
                        case TournamentMatchStatusE.Draw:
                        case TournamentMatchStatusE.WhiteBye:
                        case TournamentMatchStatusE.BlackBye:
                            return false;

                        case TournamentMatchStatusE.ForcedWhiteWin:
                        case TournamentMatchStatusE.ForcedWhiteLose:
                        case TournamentMatchStatusE.ForcedDraw:
                            return true;
                    }
                    #endregion
                    break;

                case TournamentMatchStatusE.Finsihed:
                    #region Check Required
                    switch (requiredStatusID)
                    {
                        case TournamentMatchStatusE.None:
                        case TournamentMatchStatusE.Scheduled:
                        case TournamentMatchStatusE.InProgress:
                        case TournamentMatchStatusE.Finsihed:
                        case TournamentMatchStatusE.Postpond:
                        case TournamentMatchStatusE.Absent:
                        case TournamentMatchStatusE.Draw:
                        case TournamentMatchStatusE.WhiteBye:
                        case TournamentMatchStatusE.BlackBye:
                            return false;

                        case TournamentMatchStatusE.ForcedWhiteWin:
                        case TournamentMatchStatusE.ForcedWhiteLose:
                        case TournamentMatchStatusE.ForcedDraw:
                            return true;
                    }
                    #endregion
                    break;

                case TournamentMatchStatusE.Postpond:
                    #region Check Required
                    switch (requiredStatusID)
                    {
                        case TournamentMatchStatusE.None:
                        case TournamentMatchStatusE.Draw:
                        case TournamentMatchStatusE.Finsihed:
                        case TournamentMatchStatusE.Postpond:
                            return false;

                        case TournamentMatchStatusE.Scheduled:
                        case TournamentMatchStatusE.InProgress:
                        case TournamentMatchStatusE.Absent:
                        case TournamentMatchStatusE.WhiteBye:
                        case TournamentMatchStatusE.BlackBye:
                        case TournamentMatchStatusE.ForcedWhiteWin:
                        case TournamentMatchStatusE.ForcedWhiteLose:
                        case TournamentMatchStatusE.ForcedDraw:
                            return true;
                    }
                    #endregion
                    break;

                case TournamentMatchStatusE.Absent:
                    #region Check Required
                    switch (requiredStatusID)
                    {
                        case TournamentMatchStatusE.None:
                        case TournamentMatchStatusE.InProgress:
                        case TournamentMatchStatusE.Finsihed:
                        case TournamentMatchStatusE.Draw:
                        case TournamentMatchStatusE.Scheduled:
                        case TournamentMatchStatusE.Postpond:
                        case TournamentMatchStatusE.Absent:
                            return false;

                        case TournamentMatchStatusE.WhiteBye:
                        case TournamentMatchStatusE.BlackBye:
                        case TournamentMatchStatusE.ForcedWhiteWin:
                        case TournamentMatchStatusE.ForcedWhiteLose:
                        case TournamentMatchStatusE.ForcedDraw:
                            return true;
                    }
                    #endregion
                    break;

                case TournamentMatchStatusE.Draw:
                    #region Check Required
                    switch (requiredStatusID)
                    {
                        case TournamentMatchStatusE.None:
                        case TournamentMatchStatusE.Scheduled:
                        case TournamentMatchStatusE.InProgress:
                        case TournamentMatchStatusE.Finsihed:
                        case TournamentMatchStatusE.Postpond:
                        case TournamentMatchStatusE.Absent:
                        case TournamentMatchStatusE.Draw:
                        case TournamentMatchStatusE.WhiteBye:
                        case TournamentMatchStatusE.BlackBye:
                        case TournamentMatchStatusE.ForcedDraw:
                            return false;

                        case TournamentMatchStatusE.ForcedWhiteWin:
                        case TournamentMatchStatusE.ForcedWhiteLose:
                            return true;
                    }
                    #endregion
                    break;

                case TournamentMatchStatusE.WhiteBye:
                    #region Check Required
                    switch (requiredStatusID)
                    {
                        case TournamentMatchStatusE.None:
                        case TournamentMatchStatusE.InProgress:
                        case TournamentMatchStatusE.Finsihed:
                        case TournamentMatchStatusE.Draw:
                        case TournamentMatchStatusE.WhiteBye:
                            return false;

                        case TournamentMatchStatusE.Scheduled:
                        case TournamentMatchStatusE.Postpond:
                        case TournamentMatchStatusE.Absent:
                        case TournamentMatchStatusE.BlackBye:
                        case TournamentMatchStatusE.ForcedWhiteWin:
                        case TournamentMatchStatusE.ForcedWhiteLose:
                        case TournamentMatchStatusE.ForcedDraw:
                            return true;
                    }
                    #endregion
                    break;

                case TournamentMatchStatusE.BlackBye:
                    #region Check Required
                    switch (requiredStatusID)
                    {
                        case TournamentMatchStatusE.None:
                        case TournamentMatchStatusE.InProgress:
                        case TournamentMatchStatusE.Finsihed:
                        case TournamentMatchStatusE.Draw:
                        case TournamentMatchStatusE.BlackBye:
                            return false;

                        case TournamentMatchStatusE.Scheduled:
                        case TournamentMatchStatusE.Postpond:
                        case TournamentMatchStatusE.Absent:
                        case TournamentMatchStatusE.WhiteBye:
                        case TournamentMatchStatusE.ForcedWhiteWin:
                        case TournamentMatchStatusE.ForcedWhiteLose:
                        case TournamentMatchStatusE.ForcedDraw:
                            return true;
                    }
                    #endregion
                    break;

                case TournamentMatchStatusE.ForcedWhiteWin:
                    #region Check Required
                    switch (requiredStatusID)
                    {
                        case TournamentMatchStatusE.None:
                        case TournamentMatchStatusE.InProgress:
                        case TournamentMatchStatusE.Finsihed:
                        case TournamentMatchStatusE.Draw:
                        case TournamentMatchStatusE.ForcedWhiteWin:
                            return false;

                        case TournamentMatchStatusE.Scheduled:
                        case TournamentMatchStatusE.Postpond:
                        case TournamentMatchStatusE.Absent:
                        case TournamentMatchStatusE.BlackBye:
                        case TournamentMatchStatusE.WhiteBye:
                        case TournamentMatchStatusE.ForcedWhiteLose:
                        case TournamentMatchStatusE.ForcedDraw:
                            return true;
                    }
                    #endregion
                    break;

                case TournamentMatchStatusE.ForcedWhiteLose:
                    #region Check Required
                    switch (requiredStatusID)
                    {
                        case TournamentMatchStatusE.None:
                        case TournamentMatchStatusE.InProgress:
                        case TournamentMatchStatusE.Finsihed:
                        case TournamentMatchStatusE.Draw:
                        case TournamentMatchStatusE.ForcedWhiteLose:
                            return false;

                        case TournamentMatchStatusE.Absent:
                        case TournamentMatchStatusE.BlackBye:
                        case TournamentMatchStatusE.ForcedWhiteWin:
                        case TournamentMatchStatusE.WhiteBye:
                        case TournamentMatchStatusE.ForcedDraw:
                            return true;
                    }
                    #endregion
                    break;

                case TournamentMatchStatusE.ForcedDraw:
                    #region Check Required
                    switch (requiredStatusID)
                    {
                        case TournamentMatchStatusE.None:
                        case TournamentMatchStatusE.InProgress:
                        case TournamentMatchStatusE.Finsihed:
                        case TournamentMatchStatusE.Draw:
                        case TournamentMatchStatusE.ForcedDraw:
                        case TournamentMatchStatusE.Scheduled:
                        case TournamentMatchStatusE.Postpond:
                            return false;

                        case TournamentMatchStatusE.Absent:
                        case TournamentMatchStatusE.BlackBye:
                        case TournamentMatchStatusE.ForcedWhiteWin:
                        case TournamentMatchStatusE.ForcedWhiteLose:
                        case TournamentMatchStatusE.WhiteBye:
                            return true;
                    }
                    #endregion
                    break;

            }

            return false;
        }

        #endregion

        #region SaveTournamentMatch 
        
        public static void SaveTournamentMatch(Kv kv)
        {
            TournamentMatch TournamentMatch;
            int tournamentMatchID = kv.GetInt32("TournamentMatchID");
            
            if (tournamentMatchID > 0) // update existing match
            {
                TournamentMatch = new TournamentMatch(kv.Cxt, tournamentMatchID);
            }
            else // add new match
            {
                TournamentMatch = new TournamentMatch(kv.Cxt, 0);
            }

            TournamentMatch.TournamentID = kv.GetInt32("TournamentID");
            TournamentMatch.WhiteUserID = kv.GetInt32("WhiteUserID");
            TournamentMatch.BlackUserID = kv.GetInt32("BlackUserID");
            TournamentMatch.Round = kv.GetInt32("Round");
            TournamentMatch.TimeMin = kv.GetInt32("TimeMin");
            TournamentMatch.TimeSec = kv.GetInt32("TimeSec");
            TournamentMatch.MatchStartDate = kv.GetDateTime("MatchStartDate");
            TournamentMatch.MatchStartTime = kv.GetDateTime("MatchStartTime");
            TournamentMatch.ParentMatchID = kv.GetInt32("ParentMatchID");
            TournamentMatch.TournamentMatchStatusID = kv.GetInt32("TournamentMatchStatusID");
            TournamentMatch.TournamentMatchTypeID = kv.GetInt32("TournamentMatchTypeID");
            TournamentMatch.StatusID = kv.GetInt32("StatusID");
            TournamentMatch.Save();
        }

        #endregion
        
        #region Child Match - Knock-out 

        public static void CreateChildMatchIfRequired(Cxt cxt, TournamentMatch m, DataTable dtTournamentUsers)
        {            
            #region Entry Conditions 
            if (m == null)
            {
                return;
            }
            Tournament t = new Tournament(cxt, m.TournamentID);

            if (t.TournamentTypeE != TournamentTypeE.Knockout)
            {
                return;
            }

            if (dtTournamentUsers == null)
            {
                dtTournamentUsers = TournamentUsers.GetTournamentUsersByTournamentID(StatusE.Active, t.TournamentID);
            }

            //if (m.Round == 0 && IsPreliminaryRound(m.Round, dtTournamentUsers)) // if it is prelimiry round
            //{
            //    return;
            //}

            #endregion            

            #region DataMembers 
            DataTable dtMatches = App.Model.Db.TournamentMatches.GetTournamentMatchByRound(t.ID, m.Round);
            DataRow[] drMatches = null;
            int whiteUserId = m.WhiteUserID;
            int blackUserId = m.BlackUserID;            
            decimal whitePoints = -1;
            decimal blackPoints = -1;
            string filter = "";

            filter += "(WhiteUserId = " + whiteUserId + " or BlackUserId = " + whiteUserId;
            filter += " or WhiteUserId = " + blackUserId + " or BlackUserId = " + blackUserId + ")"; 
            #endregion
            
            switch (m.TournamentMatchTypeE)
            {
                case TournamentMatchTypeE.Normal:
                    #region Normal Round Matches
                    drMatches = dtMatches.Select(filter + " and TournamentMatchTypeID = " + (int)TournamentMatchTypeE.Normal);

                    whitePoints = CalculatePlayerPoints(cxt, whiteUserId, drMatches);
                    blackPoints = CalculatePlayerPoints(cxt, blackUserId, drMatches);

                    if (drMatches.Length >= t.NoOfGamesPerRound) // NoOfGamesPerRound completed.
                    {
                        #region If NoOfGamesPerRound completed
                        if (whitePoints > blackPoints)
                        {
                            // white win
                            SaveTournamentRound(cxt, dtMatches, t.ID, m.Round, whiteUserId, blackUserId, whitePoints, blackPoints, true);
                        }
                        else if (whitePoints < blackPoints)
                        {
                            // white lose
                            SaveTournamentRound(cxt, dtMatches, t.ID, m.Round, whiteUserId, blackUserId, whitePoints, blackPoints, false);
                        }
                        else
                        {
                            // draw/tie, now start tie-break matches if required.
                            if (t.IsTieBreak && t.NoOfTieBreaks > 0)
                            {
                                CreateChildMatch(t, m, TournamentMatchTypeE.TieBreak);
                            }
                        }
                        #endregion
                    }
                    else // NoOfGamesPerRound not completed, so continue with round's matches if no player win yet.
                    {
                        #region if NoOfGamesPerRound not completed
                        decimal winningPoints = (decimal)(t.NoOfGamesPerRound / 2 + 0.5);
                        if (whitePoints >= winningPoints)
                        {
                            // white win                            
                            SaveTournamentRound(cxt, dtMatches, t.ID, m.Round, whiteUserId, blackUserId, whitePoints, blackPoints, true);
                        }
                        else if (blackPoints >= winningPoints)
                        {
                            // white lose
                            SaveTournamentRound(cxt, dtMatches, t.ID, m.Round, whiteUserId, blackUserId, whitePoints, blackPoints, false);
                        }
                        else
                        {
                            CreateChildMatch(t, m, TournamentMatchTypeE.Normal);
                        }
                        #endregion
                    }
                    #endregion
                    break;
                case TournamentMatchTypeE.TieBreak:
                    #region Tie-Break Matches
                    drMatches = dtMatches.Select(filter + " and TournamentMatchTypeID = " + (int)TournamentMatchTypeE.TieBreak);

                    whitePoints = CalculatePlayerPoints(cxt, whiteUserId, drMatches);
                    blackPoints = CalculatePlayerPoints(cxt, blackUserId, drMatches);

                    if (drMatches.Length >= t.NoOfTieBreaks) // NoOfTieBreaks completed.
                    {
                        #region if NoOfTieBreaks completed
                        
                        if (whitePoints > blackPoints)
                        {
                            // white win
                            SaveTournamentRound(cxt, dtMatches, t.ID, m.Round, whiteUserId, blackUserId, whitePoints, blackPoints, true);
                        }
                        else if (whitePoints < blackPoints)
                        {
                            // white lose
                            SaveTournamentRound(cxt, dtMatches, t.ID, m.Round, whiteUserId, blackUserId, whitePoints, blackPoints, false);
                        }
                        else 
                        {
                            // draw/tie, now required SuddenDeath match
                            CreateChildMatch(t, m, TournamentMatchTypeE.SuddenDeath);
                        }
                        #endregion
                    }
                    else // NoOfTieBreaks not completed, so continue with tie-break's matches
                    {
                        decimal winningPoints = (decimal)( t.NoOfTieBreaks / 2 + 0.5);
                        if (whitePoints >= winningPoints)
                        {
                            // white win
                            SaveTournamentRound(cxt, dtMatches, t.ID, m.Round, whiteUserId, blackUserId, whitePoints, blackPoints, true);
                        }
                        else if (blackPoints >= winningPoints)
                        {
                            // white lose
                            SaveTournamentRound(cxt, dtMatches, t.ID, m.Round, whiteUserId, blackUserId, whitePoints, blackPoints, false);                            
                        }
                        else
                        {
                            CreateChildMatch(t, m, TournamentMatchTypeE.TieBreak);
                        }
                    }
                    #endregion
                    break;
                case TournamentMatchTypeE.SuddenDeath:
                    #region SuddenDeath Match 
                    bool isWhiteWin = false;

                    #region Check Result 
                    switch (m.GameResultIDE)
                    {
                        case GameResultE.None:
                            #region Check TournamentMatchStatusE
                            switch (m.TournamentMatchStatusE)
                            {
                                case TournamentMatchStatusE.ForcedWhiteWin:
                                case TournamentMatchStatusE.BlackBye:
                                    isWhiteWin = true;
                                    break;
                                default:
                                    break;
                            }
                            #endregion
                            break;
                        case GameResultE.WhiteWin:
                        case GameResultE.BlackBye:
                        case GameResultE.ForcedWhiteWin:
                            isWhiteWin = true;
                            break;
                        default:
                            break;
                    }
                    #endregion

                    if (isWhiteWin)
                    {
                        // white win
                        whitePoints = 1;
                        blackPoints = 0;
                        SaveTournamentRound(cxt, dtMatches, t.ID, m.Round, whiteUserId, blackUserId, whitePoints, blackPoints, true);                        
                    }
                    else
                    {
                        // white lose
                        whitePoints = 0;
                        blackPoints = 1;
                        SaveTournamentRound(cxt, dtMatches, t.ID, m.Round, whiteUserId, blackUserId, whitePoints, blackPoints, false);                        
                    }
                    #endregion
                    break;
                default:
                    break;
            }
        }

        public static bool IsPreliminaryRound(int round, DataTable dtUsers)
        {
            if (round > 0)
            {
                return false;
            }

            bool isPreliminary = true;            
            int x = 1;
            int y = -1;

            do
            {
                y = (int)Math.Pow(2, x++);
                if (y == dtUsers.Rows.Count)
                {
                    isPreliminary = false;
                    break;
                }
            } while (y < dtUsers.Rows.Count);
            
            return isPreliminary;
        }

        public static int CountPreliminaryRoundUsers(DataTable dtUsers)
        {
            return CountPreliminaryRoundUsers(dtUsers.Rows.Count);
        }

        public static int CountPreliminaryRoundUsers(int totalUsersCount)
        {
            int users = 0;
            bool isPreliminary = true;
            int x = 1;
            int y = -1;

            do
            {
                y = (int)Math.Pow(2, x++);
                if (y == totalUsersCount)
                {
                    isPreliminary = false;
                    break;
                }
            } while (y < totalUsersCount);

            if (isPreliminary)
            {
                x -= 2;
                int minimum = (int)Math.Pow(2, x);
                users = totalUsersCount - minimum;
            }

            return users;
        }

        public static void SaveTournamentRound(Cxt cxt, DataTable dtMatches, int tournamentId, int round, 
            int whiteUserId, int blackUserId,decimal whitePoints,decimal blackPoints,bool isWhiteWin)
        {
            #region Find Round's White/Black Users 

            int roundWhiteUserId = -1;
            int roundBlackUserId = -1;
            string filter = "";

            filter += "(WhiteUserId = " + whiteUserId + " or BlackUserId = " + whiteUserId;
            filter += " or WhiteUserId = " + blackUserId + " or BlackUserId = " + blackUserId + ")"; 

            DataRow[] drRoundMatches = dtMatches.Select(filter, "TournamentMatchID asc");
            if (drRoundMatches.Length > 0)
            {
                DataRow drFirstMatch = drRoundMatches[0];

                roundWhiteUserId = Convert.ToInt32(drFirstMatch["WhiteUserID"]);
                roundBlackUserId = Convert.ToInt32(drFirstMatch["BlackUserID"]);
            }

            if (roundWhiteUserId == -1 || roundBlackUserId == -1)
            {
                return;
            }

            #endregion

            #region Load TournamentRound, if already exists 

            DataTable dtRound = TournamentRound.GetTournamentRoundByPlayers(tournamentId, round, roundWhiteUserId, roundBlackUserId);
            TournamentRound tr;
            if (dtRound != null && dtRound.Rows.Count > 0)
            {
                tr = new TournamentRound(cxt, dtRound.Rows[0]);
            }
            else
            {
                tr = new TournamentRound();
            }

            #endregion

            #region Accumulate Points

            // "whitePoints" and "blackPoints" are points only for "Normal","Tie-Break" or "SuddenDeath" matches separately.
            // now update these points to accumulate all points of this round, irrespective of "Normal","Tie-Break" or "SuddenDeath" matches.
            // so recalcaulate points totally for this round.

            whitePoints = CalculatePlayerPoints(cxt, whiteUserId, drRoundMatches);
            blackPoints = CalculatePlayerPoints(cxt, blackUserId, drRoundMatches);

            #endregion

            tr.TournamentID = tournamentId;
            tr.Round = round;
            tr.WhiteUserID = roundWhiteUserId;
            tr.BlackUserID = roundBlackUserId;

            if (whiteUserId == roundWhiteUserId)
            {
                tr.WhitePoints = whitePoints;
                tr.BlackPoints = blackPoints;
                tr.GameResultIDE = isWhiteWin ? GameResultE.WhiteWin : GameResultE.WhiteLose;
            }
            else if (whiteUserId == roundBlackUserId)
            {
                isWhiteWin = !isWhiteWin;
                tr.WhitePoints = blackPoints;
                tr.BlackPoints = whitePoints;
                tr.GameResultIDE = isWhiteWin ? GameResultE.WhiteWin : GameResultE.WhiteLose;                
            }
            
            tr.StatusID = (int)StatusE.Active;
            tr.Save();
        }

        public static decimal CalculatePlayerPoints(Cxt cxt, int playerId, DataRow[] drMatches)
        {
            double points = 0;
            TournamentMatch tm = null;

            foreach (DataRow drNormal in drMatches)
            {
                tm = new TournamentMatch(cxt, drNormal);

                if (tm.WhiteUserID == playerId)
                {
                    #region Check for White Player 

                    switch (tm.GameResultIDE)
                    {
                        case GameResultE.None:
                            #region Check TournamentMatchStatusE 
                            switch (tm.TournamentMatchStatusE)
                            {
                                case TournamentMatchStatusE.Draw:
                                case TournamentMatchStatusE.ForcedDraw:
                                    points += 0.5;
                                    break;                                    
                                case TournamentMatchStatusE.ForcedWhiteWin:
                                case TournamentMatchStatusE.BlackBye:
                                    points += 1;
                                    break;
                                case TournamentMatchStatusE.ForcedWhiteLose:
                                case TournamentMatchStatusE.WhiteBye:
                                    points += 0;
                                    break;
                                default:
                                    break;
                            }
                            #endregion
                            break;                        
                        case GameResultE.WhiteWin:
                        case GameResultE.BlackBye:
                        case GameResultE.ForcedWhiteWin:
                            points += 1;
                            break;
                            points += 0;
                            break;
                        case GameResultE.Draw:
                        case GameResultE.ForcedDraw:
                            points += 0.5;
                            break;
                        case GameResultE.WhiteLose:
                        case GameResultE.WhiteBye:
                        case GameResultE.ForcedWhiteLose:
                            points += 0;
                            break;                            
                        default:
                            break;
                    }

                    #endregion
                }
                else if (tm.BlackUserID == playerId)
                {
                    #region Check for Black Player 

                    switch (tm.GameResultIDE)
                    {
                        case GameResultE.None:
                            #region Check TournamentMatchStatusE
                            switch (tm.TournamentMatchStatusE)
                            {
                                case TournamentMatchStatusE.Draw:
                                case TournamentMatchStatusE.ForcedDraw:
                                    points += 0.5;
                                    break;
                                case TournamentMatchStatusE.ForcedWhiteWin:
                                case TournamentMatchStatusE.BlackBye:
                                    points += 0;
                                    break;
                                case TournamentMatchStatusE.ForcedWhiteLose:
                                case TournamentMatchStatusE.WhiteBye:
                                    points += 1;
                                    break;
                                default:
                                    break;
                            }
                            #endregion
                            break;                       
                        case GameResultE.WhiteWin:
                        case GameResultE.BlackBye:
                        case GameResultE.ForcedWhiteWin:
                            points += 0;
                            break;
                        case GameResultE.WhiteLose:
                        case GameResultE.WhiteBye:
                        case GameResultE.ForcedWhiteLose:
                            points += 1;
                            break;
                        case GameResultE.Draw:
                        case GameResultE.ForcedDraw:
                            points += 0.5;
                            break;                            
                        default:
                            break;
                    }

                    #endregion
                }
            }

            return (decimal)points;
        }

        public static void CreateChildMatch(Tournament t, TournamentMatch m, TournamentMatchTypeE matchType)
        {
            Kv kv = null;

            if (m != null)
            {
                kv = new Kv();

                kv.Set("TournamentID", m.TournamentID);

                kv.Set("WhiteUserID", m.BlackUserID);
                kv.Set("BlackUserID", m.WhiteUserID);

                kv.Set("Round", m.Round);

                switch (matchType)
                {
                    case TournamentMatchTypeE.Normal:
                        kv.Set("TimeMin", m.TimeMin);
                        kv.Set("TimeSec", m.TimeSec);
                        break;
                    case TournamentMatchTypeE.TieBreak:
                        kv.Set("TimeMin", t.TieBreakMin);
                        kv.Set("TimeSec", t.TieBreakSec);
                        break;
                    case TournamentMatchTypeE.SuddenDeath:
                        kv.Set("TimeMin", t.SuddenDeathWhiteMin);
                        kv.Set("TimeSec", t.SuddenDeathSec);
                        break;
                    default:
                        break;
                }                

                kv.Set("MatchStartDate", DateTime.Now);
                kv.Set("MatchStartTime", DateTime.Now);

                kv.Set("ParentMatchID", m.ParentMatchID > 0 ? m.ParentMatchID : m.TournamentMatchID);
                kv.Set("TournamentMatchStatusID", (int)TournamentMatchStatusE.Scheduled);
                kv.Set("TournamentMatchTypeID", (int)matchType);
                kv.Set("StatusID", (int)StatusE.Active);
            }

            App.Model.Db.TournamentMatch.SaveTournamentMatch(kv);            
        }

        #endregion

    }
}
