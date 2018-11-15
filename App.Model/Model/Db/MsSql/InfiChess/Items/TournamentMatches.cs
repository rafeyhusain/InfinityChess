using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Linq;
using System.Diagnostics;

namespace App.Model.Db
{
    public partial class TournamentMatches : BaseItems<TournamentMatch, TournamentMatches>
    {
        #region Constructors
        public TournamentMatches()
        {
        }

        public TournamentMatches(Cxt cxt)
        {
            Cxt = cxt;
        }

        public TournamentMatches(Cxt cxt, BaseCollection items)
        {
            Cxt = cxt;

            DataTable = items.DataTable;
        }

        public TournamentMatches(Cxt cxt, DataTable table)
        {
            Cxt = cxt;

            DataTable = table;
        }

        #endregion

        #region Properties

        #region Core
        public override InfiChess TableName
        {
            [DebuggerStepThrough]
            get
            {
                return InfiChess.TournamentMatch;
            }
            [DebuggerStepThrough]
            set
            {
                base.TableName = value;
            }
        }

        #endregion

        #region Enum
        #endregion

        #region Generated

        DataTable dtTournamentUsers = null;

        public Tournament Tournament
        {
            get
            {
                return new Tournament(Cxt.Instance, 0);//tournamentID);
            }
        }

        public DataTable DtTournamentUsersMatch
        {
            [DebuggerStepThrough]
            get { return dtTournamentUsers; }
            [DebuggerStepThrough]
            set { dtTournamentUsers = value; }
        }

        #endregion

        #region Contained Classes

        private Event EventItem = null;
        public Event Event
        {
            [DebuggerStepThrough]
            get
            {
                if (EventItem == null)
                {
                    EventItem = Event.GetEventByTournamentID(base.Cxt, this.Tournament.TournamentID);
                }
                return EventItem;
            }
            [DebuggerStepThrough]
            set { EventItem = value; }
        }

        #endregion

        #region Calculated

        #endregion
        #endregion

        #region Methods

        #region Get Tournaments Matches By TournamentID
        public static DataTable GetTournamentsMatchByTournamentID(int tournamentID)
        {
            return BaseCollection.Execute("GetTournamentMatchByTournamentID", tournamentID);
        }

        #endregion

        #region Delete Tournament Match By TournamentID
        public static void DeleteTournamentMatchByTournamentID(SqlTransaction trans, int tournamentID)
        {
            BaseCollection.ExecuteSql(trans, InfiChess.TournamentMatch, "UPDATE TournamentMatch set StatusID = @p1 where tournamentID = @p2", (int)StatusE.Deleted, tournamentID);
        }
        #endregion

        #region GetTournamntMatch
        public static DataTable GetTournamntMatch()
        {
            return BaseCollection.Select(InfiChess.TournamentMatch, 0);
        }
        #endregion

        #region GetTournamntMatchByTournamentID
        public static DataTable GetTournamntMatchByTournamentID(int tournamentID)
        {
            return BaseCollection.Select(InfiChess.TournamentMatch, "TournamentID", tournamentID, "StatusID", (int)StatusE.Active);
        }

        public static DataTable GetTournamentMatchByRound(int tournamentID, int round)
        {
            return  BaseCollection.Select(InfiChess.TournamentMatch, "TournamentID",tournamentID, "Round", round, "StatusID", (int)StatusE.Active);
        }


        public static DataTable GetTournamntMatchByParentID(int parentMatchID)
        {
            return BaseCollection.Select(InfiChess.TournamentMatch, "ParentMatchID", parentMatchID.ToString(), "StatusID", (int)StatusE.Active);
        }

        public static DataTable GetWinnerTournamntMatch(int tournamentID, int round)
        {
            return BaseCollection.Select(InfiChess.TournamentMatch, "GameResultID  not in (1, 5, 6) and TournamentID = " + tournamentID + " and Round = " + round +" and statusID <> 4");
        }

        public static DataTable GetTournamntPlayers(int tournamentID)
        {
            return BaseCollection.Select(InfiChess.TournamentMatch, "GameResultID  not in (1, 5, 6) and TournamentID = " + tournamentID + " and statusID <> 4");
        }

        #endregion

        #region UpdateStatus
        public static void UpdateStatus(Cxt cxt, TournamentMatchStatusE tournamentMatchStatusID, string tournamentMatchIDs, GameResultE gameResultID)
        {
            SqlTransaction trans = null;

            try
            {
                trans = SqlHelper.BeginTransaction(Config.ConnectionString);

                UpdateStatus(trans, cxt, tournamentMatchStatusID, tournamentMatchIDs, gameResultID);

                SqlHelper.CommitTransaction(trans);
            }
            catch (Exception ex)
            {
                SqlHelper.RollbackTransaction(trans);
                Log.Write(cxt, ex);
            }
        }

        public static void UpdateStatus(SqlTransaction trans, Cxt cxt, TournamentMatchStatusE tournamentMatchStatusID, string tournamentMatchIDs, GameResultE gameResultID)
        {
            StringBuilder sb = new StringBuilder();

            BaseCollection.Execute(trans, "UpdateTournamentMatchStatus",
                                    tournamentMatchIDs,
                                    tournamentMatchStatusID.ToString("d"),
                                    gameResultID.ToString("d"),
                                    cxt.CurrentUserID
                                    );

            if (tournamentMatchStatusID != TournamentMatchStatusE.Scheduled &&
                                tournamentMatchStatusID != TournamentMatchStatusE.Absent)
            {
                BaseCollection.Execute(trans, "UpdateTournamentChallengeStatus",
                                        tournamentMatchIDs,
                                        StatusE.Deleted.ToString("d"),
                                        cxt.CurrentUserID);
            }
        }
        #endregion

        #region UpdateTournamentMatches
        public void UpdateTournamentMatches(TournamentMatches tournamentMatches)
        {
            SqlTransaction trans = null;
            try
            {
                trans = SqlHelper.BeginTransaction(Config.ConnectionString);
                Save(trans);
                SqlHelper.CommitTransaction(trans);
            }
            catch (Exception ex)
            {
                SqlHelper.RollbackTransaction(trans);
                Log.Write(base.Cxt, ex);
            }
        }
        #endregion

        #region Save Tournament Matches

        public override void Save()
        {
            SqlTransaction trans = null;
            this.DtTournamentUsersMatch = TournamentUsers.GetTournamentUsersByTournamentID(StatusE.Active, this.Tournament.TournamentID);

            try
            {
                for (int i = 0; i < this.Count; i++)
                {
                    trans = SqlHelper.BeginTransaction(Config.ConnectionString);

                    TournamentMatch tournamentMatch = this[i];
                    this.Save(trans);
                    Challenge Challenge = CreateChallenge(tournamentMatch);
                    Challenge.Save(trans);

                    Game Game = null;

                    //if (this.teamLooseStatusE != TeamLooseStatusE.None)
                    //{
                    // Game = CreateGame(this, Challenge);
                    Game.Save(trans);
                    //}

                    if (this.Tournament.TournamentStartDate == new DateTime())
                    {
                        this.Tournament.TournamentStartDate = DateTime.Now;
                        this.Tournament.TournamentStartTime = DateTime.Now;
                        this.Tournament.Save(trans);
                    }
                    SqlHelper.CommitTransaction(trans);
                    trans = SqlHelper.BeginTransaction(Config.ConnectionString);
                    //if (this.teamLooseStatusE != TeamLooseStatusE.None)
                    //{
                    Elo Elo = new Elo(Game);
                    if (Game.IsEloWhiteUpated && Game.IsEloBlackUpated)
                    {
                        Elo.Update(trans);
                    }
                    //}

                    SqlHelper.CommitTransaction(trans);
                }
            }
            catch (Exception ex)
            {
                SqlHelper.RollbackTransaction(trans);
                Log.Write(base.Cxt, ex);
            }
        }


        #region Get Round in Progress
        static int GetRoundInprogress(Cxt cxt, int tournamentID, TournamentMatches matches)
        {            
            int round = 0, counter = 0;
            bool isMatchStatus = false;
            // Test if round already running and user want to update status of that round
            // below check is for start matches and start single match

            // this check is for multiple matches selection with diff rounds

            DataTable dt = TournamentMatches.GetTournamentsMatchByTournamentID(tournamentID);

            for (int i = 0; i < matches.Count; i++)
            {
                TournamentMatch tm = matches[i];
                if (tm.Round != round)
                {
                    counter++;
                    round = tm.Round;
                    if (counter > 1)
                    {
                        round = 0;
                        return (int)MsgE.ErrorMatchStarts;
                    }
                }
            }

            if (!isMatchStatus)
            {
                foreach (DataRow item in dt.Rows)
                {
                    TournamentMatch TournamentMatch = new TournamentMatch(cxt, item);
                    if (TournamentMatch.TournamentMatchStatusE == TournamentMatchStatusE.InProgress)
                    {
                        for (int i = 0; i < matches.Count; i++)
                        {
                            TournamentMatch tm = matches[i];
                            if (tm.Round != TournamentMatch.Round)
                            {
                                return (int)MsgE.ErrorMatchStarts;
                            }
                            isMatchStatus = true;
                        }
                        break;
                    }
                }
            }

            if (!isMatchStatus)
            {
                foreach (DataRow item in dt.Rows)
                {
                    TournamentMatch TournamentMatch = new TournamentMatch(cxt, item);
                    if (TournamentMatch.TournamentMatchStatusE == TournamentMatchStatusE.Finsihed)
                    {

                        DataRow[] drArr = dt.Select("Round = " + TournamentMatch.Round +
                                        " and TournamentMatchStatusID = " + BaseItem.ToString((int)TournamentMatchStatusE.Scheduled));

                        foreach (DataRow dr in drArr)
                        {
                            TournamentMatch tm1 = new TournamentMatch(cxt, dr);

                            for (int i = 0; i < matches.Count; i++)
                            {
                                TournamentMatch tm = matches[i];
                                if (tm.Round != tm1.Round)
                                {
                                    return (int)MsgE.ErrorMatchStarts;
                                }
                            }
                            break;
                        }
                    }
                }
            }

            return 0;
        }

        #endregion

        public static Kv UpdateTournamentMatchStatus(Cxt cxt, int tournamentID, TournamentMatchStatusE tournamentMatchStatusID, TournamentMatches matches)
        {
            Kv kv = new Kv();
            int result = 0;

            if (tournamentMatchStatusID == TournamentMatchStatusE.InProgress)
            {
                result = GetRoundInprogress(cxt, tournamentID, matches);
                if (result > 0)
                {
                    kv.Set("Result", result);
                    return kv;
                }
            }
            DataTable dt = new DataTable("TournamentMatchResult");
            dt.Columns.Add("Round", typeof(Int32));
            dt.Columns.Add("TournamentMatchID", typeof(Int32));
            dt.Columns.Add("Player1", typeof(Int32));
            dt.Columns.Add("Player2", typeof(Int32));
            
            for (int i = 0; i < matches.Count; i++)
            {
                result = 0;

                TournamentMatch item = matches[i];
                
                
                if (tournamentMatchStatusID == TournamentMatchStatusE.InProgress)
                {
                    result = IsPlayerAvailable(cxt, item);
                }

                if (result == 0)
                {
                    UpdateTournamentMatchStatus(cxt, tournamentMatchStatusID, item);
                    dt.Rows.Add(item.Round, item.TournamentMatchID, item.WhiteUserID, item.BlackUserID);
                }
            }
            kv.Set("TournamentMatchResult", UData.ToString(dt));
            kv.Set("Result", result);

            return kv;
        }

        private static int IsPlayerAvailable(Cxt cxt, TournamentMatch tm)
        {
            int result = 0;
            
            User userW = new User(cxt, tm.WhiteUserID);
            User userB = new User(cxt, tm.BlackUserID);
            Tournament t = new Tournament(cxt, tm.TournamentID);

            if (userW.UserStatusIDE == UserStatusE.Gone || t.RoomID != userW.RoomID)
            {
                result = (int)MsgE.ErrorTournamentUserStatus;
            }

            if (userB.UserStatusIDE == UserStatusE.Gone || t.RoomID != userB.RoomID)
            {
                result = (int)MsgE.ErrorTournamentUserStatus;
            }
            return result;
        }



        //public static void UpdateTournamentMatchStatus(Cxt cxt, int tournamentID, int tournamentMatchStatusID, string matchIDs)
        //{           

        //    string[] matches = matchIDs.Split(',');

        //    foreach (string item in matches)
        //    {
        //        UpdateTournamentMatchStatus(cxt, tournamentMatchStatusID, Convert.ToInt32(item));
        //    }         
        //}

        #region Update Match Status
        
        public static void UpdateTournamentMatchStatus(Cxt cxt, TournamentMatchStatusE tournamentMatchStatusID, TournamentMatch m)
        {
            SqlTransaction t = null;
            Game g = null;
            Challenge c = null;

            DataTable dtMatches = TournamentMatches.GetTournamentsMatchByTournamentID(m.TournamentID);
            TournamentMatches matches = new TournamentMatches(cxt, dtMatches);
            DataTable dtGame = Games.GetAllGamesByTournamentID(cxt, m.TournamentID);

            DataTable dtTUser = TournamentUsers.GetTournamentUsersByTournamentID(StatusE.Active, m.TournamentID);

            try
            {
                if (!TournamentMatchRules.Instance.CanChangeStatus(m.TournamentMatchStatusE, tournamentMatchStatusID))
                {
                    return;
                }

                m.EloBlackBefore = (m.EloBlackBefore == 0) ? 1500 : m.EloBlackBefore;
                m.EloWhiteBefore = (m.EloWhiteBefore == 0) ? 1500 : m.EloWhiteBefore;
                m.TournamentMatchStatusE = tournamentMatchStatusID;

                if (GetGameResultID((TournamentMatchStatusE)tournamentMatchStatusID) != GameResultE.None)
                {
                    m.GameResultIDE = GetGameResultID((TournamentMatchStatusE)tournamentMatchStatusID);
                }

                if (m.TournamentMatchStatusE == TournamentMatchStatusE.InProgress || m.IsBye || m.IsForced)
                {
                    c = CreateChallenge(m);
                }

                t = SqlHelper.BeginTransaction(Config.ConnectionString);

                m.Save(t);

                if (c != null)
                {
                    if (c.IsNew)
                    {
                        c.Save(t);
                    }
                }

                if (m.IsBye || m.IsForced)
                {
                    if (c != null)
                    {
                        c.ChallengeStatusIDE = ChallengeStatusE.Decline;
                        c.StatusIDE = StatusE.Inactive;
                        c.Save(t);
                    }

                    TournamentUserResult(cxt, dtTUser, m, matches, dtGame).Save(t);

                    g = GetGame(cxt, m);

                    if (!g.IsNew)
                    {
                        g.GameResultIDE = m.GameResultIDE;
                        g.GameFlags = "";
                        g.Save(t);
                    }
                }

                SqlHelper.CommitTransaction(t);

                switch (m.TournamentMatchStatusE)
                {
                    case TournamentMatchStatusE.Draw:
                    case TournamentMatchStatusE.WhiteBye:
                    case TournamentMatchStatusE.BlackBye:
                    case TournamentMatchStatusE.ForcedWhiteWin:
                    case TournamentMatchStatusE.ForcedWhiteLose:
                    case TournamentMatchStatusE.ForcedDraw:
                        TournamentMatch.CreateChildMatchIfRequired(cxt, m, dtTUser);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                SqlHelper.RollbackTransaction(t);
                Log.Write(cxt, ex);
            }
        }

        private static Game GetGame(Cxt cxt, TournamentMatch m)
        {
            return new Game(m.Cxt, BaseCollection.SelectItem(InfiChess.Game, "TournamentMatchID", m.TournamentMatchID));
        }

        public static GameResultE GetGameResultID(TournamentMatchStatusE tournamentMatchStatusIDE)
        {
            switch (tournamentMatchStatusIDE)
            {
                case TournamentMatchStatusE.None:
                    return GameResultE.None;
                case TournamentMatchStatusE.Scheduled:
                    return GameResultE.None;
                case TournamentMatchStatusE.InProgress:
                    return GameResultE.InProgress;
                case TournamentMatchStatusE.Finsihed:
                    return GameResultE.None;
                case TournamentMatchStatusE.Postpond:
                    return GameResultE.NoResult;
                case TournamentMatchStatusE.Absent:
                    return GameResultE.Absent;
                case TournamentMatchStatusE.Draw:
                    return GameResultE.Draw;
                case TournamentMatchStatusE.WhiteBye:
                    return GameResultE.WhiteBye;
                case TournamentMatchStatusE.BlackBye:
                    return GameResultE.BlackBye;
                case TournamentMatchStatusE.ForcedWhiteWin:
                    return GameResultE.ForcedWhiteWin;
                case TournamentMatchStatusE.ForcedWhiteLose:
                    return GameResultE.ForcedWhiteLose;
                case TournamentMatchStatusE.ForcedDraw:
                    return GameResultE.ForcedDraw;
                default:
                    return GameResultE.None;
            }
        }

        #endregion

        #region Create Game

        private static Game CreateGame(Cxt cxt, TournamentMatch m, Challenge c)
        {
            Game g = new Game(cxt, 0);

            g.WhiteChessTypeIDE = m.Tournament.ChessTypeIDE;
            g.BlackChessTypeIDE = m.Tournament.ChessTypeIDE;
            g.GameTypeIDE = c.GameTypeIDE;
            g.WhiteUserID = c.ChallengerUserID;
            g.BlackUserID = c.OpponentUserID;
            g.RoomID = c.RoomID;
            g.TournamentMatchID = c.TournamentMatchID;
            g.ChallengeID = c.ChallengeID;
            g.TimeMin = c.TimeMin;
            g.GainPerMoveMin = c.GainPerMoveMin;
            g.StartDate = DateTime.Now;
            g.IsRated = m.Tournament.Rated;
            g.GameResultIDE = m.GameResultIDE;

            UserGameType userGameTypeWhite = UserGameType.GetUserGameRating(cxt, g.WhiteChessTypeID, g.GameTypeID, g.WhiteUserID);
            UserGameType userGameTypeBlack = UserGameType.GetUserGameRating(cxt, g.BlackChessTypeID, g.GameTypeID, g.BlackUserID);

            g.EloWhiteBefore = (userGameTypeWhite == null ? 0 : userGameTypeWhite.EloRating);
            g.EloBlackBefore = (userGameTypeBlack == null ? 0 : userGameTypeBlack.EloRating);

            return g;
        }

        #endregion

        #region CreateChallenge
        public static Challenge CreateChallenge(TournamentMatch m)
        {
            Challenge c = new Challenge(m.Cxt, BaseCollection.SelectItem(InfiChess.Challenge, "TournamentMatchID", m.TournamentMatchID));

            c.ChallengerUserID = m.WhiteUserID;
            c.OpponentUserID = m.BlackUserID;
            c.ChessTypeIDE = m.Tournament.ChessTypeIDE;
            c.ChallengeTypeIDE = ChallengeTypeE.Challenge;
            c.IsRated = m.Tournament.Rated;
            c.WithClock = true;
            c.IsChallengerSendsGame = false;
            c.GameTypeIDE = Game.GetGameType(m.TimeMin, m.TimeSec);
            c.ColorIDE = ColorE.White;
            c.TournamentMatchID = m.TournamentMatchID;

            if (m.TournamentMatchTypeE == TournamentMatchTypeE.SuddenDeath)
            {
                Tournament t = new Tournament(m.Cxt, m.TournamentID);
                c.TimeMin = t.SuddenDeathWhiteMin;
                c.GainPerMoveMin = t.SuddenDeathSec;
            }
            else
            {
                c.TimeMin = m.TimeMin;
                c.GainPerMoveMin = m.TimeSec;
            }
            
            if (m.Tournament.RoomID > 0)
            {
                c.RoomID = m.Tournament.RoomID;
            }

            if (m.IsNotBye)
            {
                c.ChallengeStatusIDE = ChallengeStatusE.Seeking;
                c.StatusIDE = StatusE.Active;
            }
            else
            {
                c.ChallengeStatusIDE = ChallengeStatusE.Accepted;
                c.StatusIDE = StatusE.Inactive;
            }

            return c;
        }
        #endregion

        #region Update tournament user table when white and black bye do
        static TournamentUsers TournamentUserResult(Cxt cxt, DataTable dtTUser, TournamentMatch tournamentMatch, TournamentMatches matches, DataTable dtGames)
        {
            #region Find UserID 2

            TournamentUsers tournamentUsers = new TournamentUsers();
            
            int wUserID = tournamentMatch.WhiteUserID;
            int bUserID = tournamentMatch.BlackUserID;

            DataRow[] drWhite = dtTUser.Select("UserID = " + wUserID);
            DataRow[] drBlack = dtTUser.Select("UserID = " + bUserID);

            if (drWhite.Length == 0)
            {
                drWhite = dtTUser.Select("UserID2 = " + wUserID);
            }

            if (drBlack.Length == 0)
            {
                drBlack = dtTUser.Select("UserID2 = " + bUserID);
            }

            TournamentUser tournamentWUser = new TournamentUser(cxt, drWhite[0]);
            TournamentUser tournamentBUser = new TournamentUser(cxt, drBlack[0]);


            TournamentMatch tm = matches.GetByID(tournamentMatch.TournamentMatchID);            

            #endregion

            if (tm.TournamentMatchStatusE == TournamentMatchStatusE.Scheduled ||
                tm.TournamentMatchStatusE == TournamentMatchStatusE.InProgress)
            {
                #region Points Calculation
                decimal wPoints = 0;
                decimal bPoints = 0;
                
                switch (tournamentMatch.TournamentMatchStatusE)
                {
                    case TournamentMatchStatusE.Draw:
                        wPoints = 0.5m;
                        bPoints = 0.5m;
                        break;
                    case TournamentMatchStatusE.WhiteBye:
                        wPoints = 0;
                        bPoints = 1;
                        break;
                    case TournamentMatchStatusE.BlackBye:
                        wPoints = 1;
                        bPoints = 0;
                        break;
                    case TournamentMatchStatusE.ForcedWhiteWin:
                        wPoints = 1;
                        bPoints = 0;
                        break;
                    case TournamentMatchStatusE.ForcedWhiteLose:
                        wPoints = 0;
                        bPoints = 1;
                        break;
                    case TournamentMatchStatusE.ForcedDraw:
                        wPoints = 0.5m;
                        bPoints = 0.5m;
                        break;
                    default:
                        break;
                }

                tournamentBUser.TournamentPoints = tournamentBUser.TournamentPoints + bPoints;
                tournamentWUser.TournamentPoints = tournamentWUser.TournamentPoints + wPoints;
                #endregion
            }
            else
            {
                #region Points Calculation
                switch (tm.GameResultIDE)
                {
                    case GameResultE.WhiteWin:
                        WhiteWin(tournamentMatch, tournamentWUser, tournamentBUser);
                        break;
                    case GameResultE.WhiteLose:
                        WhiteLose(tournamentMatch, tournamentWUser, tournamentBUser);
                        break;
                    case GameResultE.ForcedWhiteWin:
                        ForcedWhiteWin(tournamentMatch, tournamentWUser, tournamentBUser);
                        break;
                    case GameResultE.ForcedWhiteLose:
                        ForcedWhiteLose(tournamentMatch, tournamentWUser, tournamentBUser);
                        break;
                    case GameResultE.WhiteBye:
                        WhiteBye(tournamentMatch, tournamentWUser, tournamentBUser);
                        break;
                    case GameResultE.BlackBye:
                        BlackBye(tournamentMatch, tournamentWUser, tournamentBUser);
                        break;
                    case GameResultE.ForcedDraw:
                        ForcedDraw(tournamentMatch, tournamentWUser, tournamentBUser);
                        break;
                    case GameResultE.Absent:
                        Absent(tournamentMatch, tournamentWUser, tournamentBUser);
                        break;
                    case GameResultE.Draw:
                        ForcedDraw(tournamentMatch, tournamentWUser, tournamentBUser);
                        break;
                } 
                #endregion
            }
            tournamentUsers.Add(tournamentWUser);
            tournamentUsers.Add(tournamentBUser);
            return tournamentUsers;
            //tournamentUsers.Save(trans);
        }

        #region Absent
        private static void Absent(TournamentMatch tournamentMatch, TournamentUser tournamentWUser, TournamentUser tournamentBUser)
        {
            if (tournamentMatch.TournamentMatchStatusE == TournamentMatchStatusE.ForcedWhiteLose)
            {
                tournamentWUser.TournamentPoints = tournamentWUser.TournamentPoints - 0;
                tournamentBUser.TournamentPoints = tournamentBUser.TournamentPoints + 1;
            }
            else if (tournamentMatch.TournamentMatchStatusE == TournamentMatchStatusE.ForcedWhiteWin)
            {
                tournamentWUser.TournamentPoints = tournamentWUser.TournamentPoints + 1;
                tournamentBUser.TournamentPoints = tournamentBUser.TournamentPoints - 0;
            }
            else if (tournamentMatch.TournamentMatchStatusE == TournamentMatchStatusE.ForcedDraw)
            {
                tournamentWUser.TournamentPoints = tournamentWUser.TournamentPoints + 0.5m;
                tournamentBUser.TournamentPoints = tournamentBUser.TournamentPoints + 0.5m;
            }
            else if (tournamentMatch.TournamentMatchStatusE == TournamentMatchStatusE.BlackBye)
            {
                tournamentWUser.TournamentPoints = tournamentWUser.TournamentPoints + 1;
                tournamentBUser.TournamentPoints = tournamentBUser.TournamentPoints - 0;
            }
            else if (tournamentMatch.TournamentMatchStatusE == TournamentMatchStatusE.WhiteBye)
            {
                tournamentWUser.TournamentPoints = tournamentWUser.TournamentPoints - 0;
                tournamentBUser.TournamentPoints = tournamentBUser.TournamentPoints + 1;
            }

        } 
        #endregion

        #region ForcedDraw
        private static void ForcedDraw(TournamentMatch tournamentMatch, TournamentUser tournamentWUser, TournamentUser tournamentBUser)
        {
            if (tournamentMatch.TournamentMatchStatusE == TournamentMatchStatusE.ForcedWhiteLose)
            {
                tournamentWUser.TournamentPoints = tournamentWUser.TournamentPoints - 0.5m;
                tournamentBUser.TournamentPoints = tournamentBUser.TournamentPoints + 0.5m;
            }
            else if (tournamentMatch.TournamentMatchStatusE == TournamentMatchStatusE.ForcedWhiteWin)
            {
                tournamentWUser.TournamentPoints = tournamentWUser.TournamentPoints + 0.5m;
                tournamentBUser.TournamentPoints = tournamentBUser.TournamentPoints - 0.5m;
            }
        } 
        #endregion

        #region BlackBye
        private static void BlackBye(TournamentMatch tournamentMatch, TournamentUser tournamentWUser, TournamentUser tournamentBUser)
        {
            if (tournamentMatch.TournamentMatchStatusE == TournamentMatchStatusE.ForcedWhiteLose)
            {
                tournamentWUser.TournamentPoints = tournamentWUser.TournamentPoints - 1;
                tournamentBUser.TournamentPoints = tournamentBUser.TournamentPoints + 1;
            }
            else if (tournamentMatch.TournamentMatchStatusE == TournamentMatchStatusE.ForcedDraw)
            {
                tournamentWUser.TournamentPoints = tournamentWUser.TournamentPoints - 0.5m;
                tournamentBUser.TournamentPoints = tournamentBUser.TournamentPoints + 0.5m;
            }
        } 
        #endregion

        #region WhiteBye
        private static void WhiteBye(TournamentMatch tournamentMatch, TournamentUser tournamentWUser, TournamentUser tournamentBUser)
        {
            if (tournamentMatch.TournamentMatchStatusE == TournamentMatchStatusE.ForcedWhiteWin)
            {
                tournamentWUser.TournamentPoints = tournamentWUser.TournamentPoints + 1;
                tournamentBUser.TournamentPoints = tournamentBUser.TournamentPoints - 1;
            }
            else if (tournamentMatch.TournamentMatchStatusE == TournamentMatchStatusE.ForcedDraw)
            {
                tournamentWUser.TournamentPoints = tournamentWUser.TournamentPoints + 0.5m;
                tournamentBUser.TournamentPoints = tournamentBUser.TournamentPoints - 0.5m;
            }
        } 
        #endregion

        #region ForcedWhiteLose
        private static void ForcedWhiteLose(TournamentMatch tournamentMatch, TournamentUser tournamentWUser, TournamentUser tournamentBUser)
        {
            if (tournamentMatch.TournamentMatchStatusE == TournamentMatchStatusE.ForcedWhiteWin)
            {
                tournamentWUser.TournamentPoints = tournamentWUser.TournamentPoints + 1;
                tournamentBUser.TournamentPoints = tournamentBUser.TournamentPoints - 1;
            }
            else if (tournamentMatch.TournamentMatchStatusE == TournamentMatchStatusE.ForcedDraw)
            {
                tournamentWUser.TournamentPoints = tournamentWUser.TournamentPoints + 0.5m;
                tournamentBUser.TournamentPoints = tournamentBUser.TournamentPoints - 0.5m;
            }
        } 
        #endregion

        #region ForcedWhiteWin
        private static void ForcedWhiteWin(TournamentMatch tournamentMatch, TournamentUser tournamentWUser, TournamentUser tournamentBUser)
        {
            if (tournamentMatch.TournamentMatchStatusE == TournamentMatchStatusE.ForcedWhiteLose)
            {
                tournamentWUser.TournamentPoints = tournamentWUser.TournamentPoints - 1;
                tournamentBUser.TournamentPoints = tournamentBUser.TournamentPoints + 1;
            }
            else if (tournamentMatch.TournamentMatchStatusE == TournamentMatchStatusE.ForcedDraw)
            {
                tournamentWUser.TournamentPoints = tournamentWUser.TournamentPoints - 0.5m;
                tournamentBUser.TournamentPoints = tournamentBUser.TournamentPoints + 0.5m;
            }
        } 
        #endregion

        #region WhiteLose
        private static void WhiteLose(TournamentMatch tournamentMatch, TournamentUser tournamentWUser, TournamentUser tournamentBUser)
        {
            if (tournamentMatch.TournamentMatchStatusE == TournamentMatchStatusE.ForcedWhiteWin)
            {
                tournamentWUser.TournamentPoints = tournamentWUser.TournamentPoints + 1;
                tournamentBUser.TournamentPoints = tournamentBUser.TournamentPoints - 1;
            }
            else if (tournamentMatch.TournamentMatchStatusE == TournamentMatchStatusE.ForcedDraw)
            {
                tournamentWUser.TournamentPoints = tournamentWUser.TournamentPoints + 0.5m;
                tournamentBUser.TournamentPoints = tournamentBUser.TournamentPoints - 0.5m;
            }
        } 
        #endregion

        #region WhiteWin
        private static void WhiteWin(TournamentMatch tournamentMatch, TournamentUser tournamentWUser, TournamentUser tournamentBUser)
        {
            if (tournamentMatch.TournamentMatchStatusE == TournamentMatchStatusE.ForcedWhiteLose)
            {
                tournamentWUser.TournamentPoints = tournamentWUser.TournamentPoints - 1;
                tournamentBUser.TournamentPoints = tournamentBUser.TournamentPoints + 1;
            }
            else if (tournamentMatch.TournamentMatchStatusE == TournamentMatchStatusE.ForcedDraw)
            {
                tournamentWUser.TournamentPoints = tournamentWUser.TournamentPoints - 0.5m;
                tournamentBUser.TournamentPoints = tournamentBUser.TournamentPoints + 0.5m;
            }
        } 
        #endregion

        #endregion

        #endregion

        #region Start Round

        public static Kv StartRound(Cxt cxt, int tournamentID)
        {
            Kv kv = new Kv();

            int result = StartTournamentRound(cxt, tournamentID);

            kv.Set("Result", result);

            return kv;
        }

        public static int StartTournamentRound(Cxt cxt, int tournamentID)
        {
            int round = -1, count = 0, msg = 0;
            DataTable dt = GetTournamntMatchByTournamentID(tournamentID);
            TournamentMatches tm1 = new TournamentMatches(cxt, dt);

            for (int i = 0; i < tm1.Count; i++)
            {
                TournamentMatch TournamentMatch = tm1[i];

                if (TournamentMatch.TournamentMatchStatusE == TournamentMatchStatusE.InProgress)
                {
                    round = TournamentMatch.Round;
                    break;
                }
            }

            if (round > -1)
            {
                DataTable dt1 = tm1.DataTable;

                DataRow[] dr = dt1.Select("Round =" + round.ToString());

                //TournamentMatches tmFilter = tm1.Filter("Round =" + round.ToString());

                for (int i = 0; i < dr.Length; i++)
                {
                    TournamentMatch tm = new TournamentMatch(cxt, dr[i]);

                    if (tm.TournamentMatchStatusE == TournamentMatchStatusE.Scheduled)
                    {
                        msg = IsPlayerAvailable(cxt, tm);

                        if (msg == 0)
                        {
                            UpdateTournamentMatchStatus(cxt, TournamentMatchStatusE.InProgress, tm);
                        }
                        
                        count++;
                    }
                }

                if (count == 0)
                {
                    return (int)MsgE.ErrorTournamentNextRoundStarted;
                }

                return msg;
            }

            for (int i = 0; i < tm1.Count; i++)
            {
                TournamentMatch TournamentMatch = tm1[i];

                if (TournamentMatch.TournamentMatchStatusE == TournamentMatchStatusE.Scheduled)
                {
                    round = TournamentMatch.Round;
                    break; // Get Schedule round
                }
            }

            if (round > -1)
            {
                DataTable dt1 = tm1.DataTable;

                DataRow[] dr = dt1.Select("Round =" + round.ToString());

                for (int i = 0; i < dr.Length; i++)
                {
                    TournamentMatch tm = new TournamentMatch(cxt, dr[i]);

                    if (tm.TournamentMatchStatusE == TournamentMatchStatusE.Scheduled)
                    {
                        msg = IsPlayerAvailable(cxt, tm);

                        if (msg == 0)
                        {
                            UpdateTournamentMatchStatus(cxt, TournamentMatchStatusE.InProgress, tm);
                            count++;
                        }
                    }
                }
            }
            return msg;
        }
        #endregion

        #region GetGameIDByTournamentMatchID
        public static DataTable GetGameIDByTournamentMatchID(Cxt cxt, int tournamentMatchID)
        {
            return BaseCollection.ExecuteSql(InfiChess.TournamentMatch, "select GameID from Game where TournamentMatchID =" + tournamentMatchID);
        }
        #endregion
              

        #endregion



    }

}