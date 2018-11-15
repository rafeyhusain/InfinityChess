using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace App.Model.Db
{
    #region enumTournamentTypeE

    public enum TournamentTypeE
    {
        Unknown = 0,
        RoundRobin = 1,
        Swiss = 2,
        Knockout = 3,
        Scheveningen = 4
        //ManualPairing = 4,
    }

    public enum TournamentStatusE
    {
        Unknown = 0,
        Scheduled = 1,
        InProgress = 2,
        Finsihed = 3
    }

    public enum TabTypeE
    {
        Tournament,
        Wantin,
        TournamentUser,
        TeamPlayer,
        TournamentPrize,
        TournamentMatch,
        Standings,
        Result,
        Unknown
    }

    #endregion

    public class Tournament : BaseItem
    {
        #region Constructor
        public Tournament()
            : base(0)
        {
        }

        public Tournament(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public Tournament(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public Tournament(Cxt cxt, DataRow row)
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
            get { return InfiChess.Tournament; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion

        #region Enum

        public TournamentTypeE TournamentTypeIDE { [DebuggerStepThrough]get { return (TournamentTypeE)this.TournamentTypeID; } [DebuggerStepThrough]set { this.TournamentTypeID = (int)value; } }
        public StatusE StatusIDE { [DebuggerStepThrough] get { return (StatusE)this.StatusID; } [DebuggerStepThrough] set { this.StatusID = (int)value; } }
        public TournamentTypeE TournamentTypeE { [DebuggerStepThrough]get { return (TournamentTypeE)TournamentTypeID; } [DebuggerStepThrough] set { this.TournamentTypeID = (int)value; } }
        public GameType GameTypeIDE { [DebuggerStepThrough] get { return (GameType)GameTypeID; } [DebuggerStepThrough] set { this.GameTypeID = (int)value; } }
        public ChessTypeE ChessTypeIDE { [DebuggerStepThrough]get { return (ChessTypeE)ChessTypeID; } [DebuggerStepThrough] set { this.ChessTypeID = (int)value; } }
        public TournamentStatusE TournamentStatusIDE { [DebuggerStepThrough]get { return (TournamentStatusE)TournamentStatusID; } [DebuggerStepThrough] set { this.TournamentStatusID = (int)value; } }
        #endregion

        #region Generated
        public int TournamentID { [DebuggerStepThrough]get { return GetColInt32("TournamentID"); } [DebuggerStepThrough]set { SetColumn("TournamentID", value); } }
        public int TournamentTypeID { [DebuggerStepThrough]get { return GetColInt32("TournamentTypeID"); } [DebuggerStepThrough]set { SetColumn("TournamentTypeID", value); } }
        public int Round { [DebuggerStepThrough]get { return GetColInt32("Round"); } [DebuggerStepThrough]set { SetColumn("Round", value); } }
        public int WinsNeedRound { [DebuggerStepThrough]get { return GetColInt32("WinsNeedRound"); } [DebuggerStepThrough]set { SetColumn("WinsNeedRound", value); } }
        public int SecondRound { [DebuggerStepThrough]get { return GetColInt32("SecondRound"); } [DebuggerStepThrough]set { SetColumn("SecondRound", value); } }
        public int TimeControlMin { [DebuggerStepThrough]get { return GetColInt32("TimeControlMin"); } [DebuggerStepThrough]set { SetColumn("TimeControlMin", value); } }
        public int TimeControlSec { [DebuggerStepThrough]get { return GetColInt32("TimeControlSec"); } [DebuggerStepThrough] set { SetColumn("TimeControlSec", value); } }
        public int TimePenaltyMin { [DebuggerStepThrough]get { return GetColInt32("TimePenaltyMin"); } [DebuggerStepThrough]set { SetColumn("TimePenaltyMin", value); } }
        public int TimePenaltyDraws { [DebuggerStepThrough]get { return GetColInt32("TimePenaltyDraws"); } [DebuggerStepThrough]set { SetColumn("TimePenaltyDraws", value); } }
        public int PlayOffBonus { [DebuggerStepThrough]get { return GetColInt32("PlayOffBonus"); } [DebuggerStepThrough]set { SetColumn("PlayOffBonus", value); } }
        public int Pause { [DebuggerStepThrough]get { return GetColInt32("Pause"); } [DebuggerStepThrough]set { SetColumn("Pause", value); } }
        public string Name { [DebuggerStepThrough]get { return GetCol("Name"); } [DebuggerStepThrough]set { SetColumn("Name", value); } }
        public string Description { [DebuggerStepThrough]get { return GetCol("Description"); } [DebuggerStepThrough]set { SetColumn("Description", value); } }
        public bool DoubleRound { [DebuggerStepThrough]get { return GetColBool("DoubleRound"); } [DebuggerStepThrough]set { SetColumn("DoubleRound", value); } }
        public bool Match { [DebuggerStepThrough]get { return GetColBool("Match"); } [DebuggerStepThrough]set { SetColumn("Match", value); } }
        public bool WinsNeeded { [DebuggerStepThrough]get { return GetColBool("WinsNeeded"); } [DebuggerStepThrough]set { SetColumn("WinsNeeded", value); } }
        public bool WinsNeeded2 { [DebuggerStepThrough]get { return GetColBool("WinsNeeded2"); } [DebuggerStepThrough]set { SetColumn("WinsNeeded2", value); } }
        public bool BestOf { [DebuggerStepThrough] get { return GetColBool("BestOf"); } [DebuggerStepThrough]set { SetColumn("BestOf", value); } }
        public bool Rated { [DebuggerStepThrough]get { return GetColBool("Rated"); } [DebuggerStepThrough]set { SetColumn("Rated", value); } }
        public bool TimePenalty { [DebuggerStepThrough]get { return GetColBool("TimePenalty"); } [DebuggerStepThrough]set { SetColumn("TimePenalty", value); } }
        public int StatusID { [DebuggerStepThrough]get { return GetColInt32("StatusID"); } [DebuggerStepThrough]set { SetColumn("StatusID", value); } }
        public int RoomID { [DebuggerStepThrough]get { return GetColInt32("RoomID"); } [DebuggerStepThrough]set { SetColumn("RoomID", value); } }
        public int GameTypeID { [DebuggerStepThrough]get { return GetColInt32("GameTypeID"); } [DebuggerStepThrough]set { SetColumn("GameTypeID", value); } }
        public int ChessTypeID { [DebuggerStepThrough]get { return GetColInt32("ChessTypeID"); } [DebuggerStepThrough]set { SetColumn("ChessTypeID", value); } }
        public DateTime TournamentStartDate { [DebuggerStepThrough]get { return GetColDateTime("TournamentStartDate"); } [DebuggerStepThrough]set { SetColumn("TournamentStartDate", value); } }
        public DateTime TournamentStartTime { [DebuggerStepThrough]get { return GetColDateTime("TournamentStartTime"); } [DebuggerStepThrough] set { SetColumn("TournamentStartTime", value); } }
        public DateTime TournamentEndDate { [DebuggerStepThrough]get { return GetColDateTime("TournamentEndDate"); } [DebuggerStepThrough]set { SetColumn("TournamentEndDate", value); } }
        public DateTime TournamentEndTime { [DebuggerStepThrough]get { return GetColDateTime("TournamentEndTime"); } [DebuggerStepThrough]set { SetColumn("TournamentEndTime", value); } }
        public int TournamentStatusID { [DebuggerStepThrough]get { return GetColInt32("TournamentStatusID"); } [DebuggerStepThrough]set { SetColumn("TournamentStatusID", value); } }
        public bool IsTieBreak { [DebuggerStepThrough]get { return GetColBool("IsTieBreak"); } [DebuggerStepThrough]set { SetColumn("IsTieBreak", value); } }
        public DateTime RegistrationStartDate { [DebuggerStepThrough]get { return GetColDateTime("RegistrationStartDate"); } [DebuggerStepThrough]set { SetColumn("RegistrationStartDate", value); } }
        public DateTime RegistrationStartTime { [DebuggerStepThrough]get { return GetColDateTime("RegistrationStartTime"); } [DebuggerStepThrough] set { SetColumn("RegistrationStartTime", value); } }
        public DateTime RegistrationEndDate { [DebuggerStepThrough]get { return GetColDateTime("RegistrationEndDate"); } [DebuggerStepThrough]set { SetColumn("RegistrationEndDate", value); } }
        public DateTime RegistrationEndTime { [DebuggerStepThrough]get { return GetColDateTime("RegistrationEndTime"); } [DebuggerStepThrough]set { SetColumn("RegistrationEndTime", value); } }
        #endregion

        #region Contained Classes

        private Room RoomItem = null;
        public Room Room
        {
            //[DebuggerStepThrough]
            get
            {
                if (RoomItem == null)
                {
                    RoomItem = Room.GetRoomById(base.Cxt, this.RoomID);
                }
                return RoomItem;
            }
            //[DebuggerStepThrough]
            set { RoomItem = value; }
        }

        private Event eventItem = null;
        public Event Event
        {
            [DebuggerStepThrough]
            get
            {
                if (eventItem == null)
                {
                    eventItem = Event.GetEventByTournamentID(base.Cxt, this.TournamentID);
                }
                return eventItem;
            }
            [DebuggerStepThrough]
            set { eventItem = value; }
        }

        public string GetChessTypeID
        {
            get
            {
                switch (this.ChessTypeIDE)
                {
                    case ChessTypeE.Centaur:
                        break;
                    case ChessTypeE.Correspondence:
                        break;
                    case ChessTypeE.Engine:
                        return "2200";
                    case ChessTypeE.Human:
                        return "1500";
                        break;
                    case ChessTypeE.None:
                        break;
                    default:
                        break;
                }
                return "";
            }

        }

        public int TournamentCurrentRound = 0;
        int teams = 0;
        public int Teams { get { return teams; } set { teams = value; } }
        #endregion

        #region Calculated
       
        TournamentMatches tournamentMatches = null;
        public TournamentMatches TournamentMatches
        {
            //[DebuggerStepThrough]
            get
            {
                return tournamentMatches;
            }
            //[DebuggerStepThrough]
            set
            {
                tournamentMatches = value;
            }
        }

        public bool IsTournamentFinished(ref Tournament Tournament)
        {
            Room Room = null;
            Tournament TournamentRoom = null;
            bool isTrue = true;

            if (Tournament.ChessTypeIDE == ChessTypeE.Human)
            {
                Room = Room.GetRoomById(base.Cxt, 7);
            }
            else if (Tournament.ChessTypeIDE == ChessTypeE.Engine)
            {
                Room = Room.GetRoomById(base.Cxt, 12);
            }

            TournamentRoom = GetTournamentById(base.Cxt, Room.TournamentID);



            if (TournamentRoom.TournamentID == 0)
            {
                isTrue = false;
            }
            else if (TournamentRoom.TournamentStatusIDE == TournamentStatusE.InProgress)
            {
                Tournament.Room = Room;
                Tournament = TournamentRoom;
            }
            else
            {
                isTrue = false;
            }
            return isTrue;
        }

        public bool IsTournamentInprogress
        {
            get
            {
                if (this.TournamentStatusIDE == TournamentStatusE.InProgress)
                {
                    return true;
                }
                return false;
            }
        }

        public static string GetTabTypeString(TabTypeE TabTypeIDE)
        {
            return Convert.ToString((int)TabTypeIDE);
        }


        #endregion

        #endregion

        #region Methods

        public static void Delete(int id)
        {
            BaseCollection.ExecuteSql("Update Tournament set StatusID = 4 where TournamentId = " + id);
        }
        
        #region GetTournamant_Id/Result

        public static Tournament GetTournamentById(Cxt cxt, int tournamentId)
        {
            return new Tournament(cxt, BaseCollection.SelectItem(InfiChess.Tournament, tournamentId));
        }

        public static Tournament GetTournament(Cxt cxt, int tournamentId)
        {
            return new Tournament(cxt, BaseCollection.SelectItem(InfiChess.Tournament, " TournamentID ", tournamentId, "StatusID <> " + StatusE.Deleted.ToString("d")));
        }

        /// <summary>
        /// user for online client
        /// </summary>
        /// <param name="cxt"></param>
        /// <param name="tournamentId"></param>
        /// <returns></returns>
        public static Tournament GetNonDeletedTournament(Cxt cxt, int tournamentId)
        {
            return new Tournament(cxt, BaseCollection.SelectItem(InfiChess.Tournament, " TournamentID ", tournamentId, "StatusID <> " + StatusE.Deleted.ToString("d")));
        }

        public static DataSet GetTournamentResult(Cxt cxt, Tournament t)
        {
            DataSet ds = BaseCollection.ExecuteDataset("GetTournamentResultByTournamentID", t.TournamentID);
            if (ds.Tables.Count < 2)
            {
                return new DataSet();
            }
            switch (t.TournamentTypeIDE)
            {
                case TournamentTypeE.RoundRobin:
                    if (t.DoubleRound)
                    {
                        return CreateDoubleRoundRobinCrossTable(ds);
                    }
                    else
                    {
                        return CreateRoundRobinCrossTable(ds);
                    }
                    break;
                case TournamentTypeE.Swiss:
                    return CreateSwissCrossTable(ds);
                    break;
                case TournamentTypeE.Knockout:
                    return GetKnockoutResult(cxt, t);
                    break;
                case TournamentTypeE.Scheveningen:
                    return CreateSchevinginCrossTable(ds);
                    break;
                default:
                    break;
            }

            return ds;
        }

        public static DataSet GetKnockoutResult(Cxt cxt, Tournament t)
        {
            return BaseCollection.ExecuteDataset("GetKnockoutResultByTournamentID", t.TournamentID);
        }

        public static DataSet GetTournamentCmbData(Cxt cxt)
        {
            return BaseCollection.ExecuteDataset("GetTournamentCmbData");
        }

        public static DataSet GetTournamentMatchByTournamentID(Cxt cxt,int id)
        {
            return BaseCollection.ExecuteDataset("GetTournamentMatchByTournamentID",id);
        }

        #endregion

        #region Save Tournament Matches

        Room GetChessTypeRoom(int roomID)
        {
            Room Room = new Room(base.Cxt, roomID);

            if (Room.RoomID == 0)
            {
                if (this.ChessTypeIDE == ChessTypeE.Human)
                {
                    Room = new Room(base.Cxt, 7);
                }
                else if (this.ChessTypeIDE == ChessTypeE.Engine)
                {
                    Room = new Room(base.Cxt, 12);
                }
            }
            return Room;
        }
        #region Save Tournament Status
        public void SetTournamentStatus()
        {
            SqlTransaction trans = null;

            try
            {
                trans = SqlHelper.BeginTransaction(Config.ConnectionString);

                if (this.TournamentStatusIDE == TournamentStatusE.Finsihed)
                {
                    this.TournamentStatusIDE = TournamentStatusE.Finsihed;
                    this.Room.TournamentID = 0;
                    this.Room.StatusIDE = StatusE.Inactive;
                    this.Room.Save();                    
                }
               
                this.Save(trans);
                SqlHelper.CommitTransaction(trans);
            }
            catch (Exception ex)
            {
                SqlHelper.RollbackTransaction(trans);
                Log.Write(this.Cxt, ex);
            }
        }
        #endregion

        #region Save Tournament
        public void TournamentStart()
        {
            SqlTransaction trans = null;

            this.TournamentMatches = new TournamentMatches(this.Cxt, BaseCollection.Select(InfiChess.TournamentMatch, 0));

            try
            {
                trans = SqlHelper.BeginTransaction(Config.ConnectionString);

                //tournament.Save(trans);
                this.Save(trans);
                //this.TournamentID = this.TournamentID;

                Room Room = Room.GetTournamentRoom(this.Cxt, this);

                Room.Save(trans);
                this.RoomID = Room.RoomID;

                //roomID = tournament.RoomID;
                if (this.TournamentStatusIDE == TournamentStatusE.InProgress)
                {
                    this.RoomID = Room.RoomID;
                    this.Save(trans);
                }

                //if (this.TournamentTypeE == TournamentTypeE.RoundRobin)
                //{
                //    TournamentMatches.DeleteTournamentMatchByTournamentID(trans, this.TournamentID);
                //}

                switch (this.TournamentTypeIDE)
                {
                    case TournamentTypeE.RoundRobin:
                        TournamentMatches.CreateTournamentMatch(this.Cxt, trans, this);
                        break;
                    case TournamentTypeE.Swiss:
                        DataTable dtTournamentUsers = TournamentUsers.GetTournamentUsersByTournamentID(StatusE.Active, this.TournamentID);
                        TournamentUsers tournamentUsers = new TournamentUsers(this.Cxt, dtTournamentUsers);
                        TournamentMatches tournamentMatchRounds = new TournamentMatches(this.Cxt, TournamentMatches.GetTournamntMatchByTournamentID(this.TournamentID));
                        if (tournamentUsers.DataTable.Rows.Count > 0 && tournamentMatchRounds.DataTable.Rows.Count == 0)
                        {
                            TournamentMatches.CreateRound(this.Cxt, trans, tournamentUsers, 1, this);
                        }
                        break;
                    case TournamentTypeE.Knockout:
                        TournamentMatches.DeleteTournamentMatchByTournamentID(trans, this.ID);
                        TournamentMatches.CreateKnockoutTournament(this.Cxt, trans, this);
                        break;
                    case TournamentTypeE.Scheveningen:
                        TournamentMatches.CreateSchavengenSystem(this.Cxt, trans, this);
                        break;
                    default:
                        break;
                }
                CreateEvent(trans, this);
                SqlHelper.CommitTransaction(trans);
            }
            catch (Exception ex)
            {
                SqlHelper.RollbackTransaction(trans);
                Log.Write(base.Cxt, ex);
            }
        }
        #endregion

        #endregion

        #endregion

        #region CreateEvent

        void CreateEvent(SqlTransaction trans, Tournament tournament)
        {
            Event.EventObjectID = tournament.TournamentID;
            Event.Name = tournament.Name + " " + DateTime.Now;
            Event.EventDate = DateTime.Now;
            Event.EventTypeIDE = EventTypeE.Tournament;
            //Event.RoomID = Room.RoomID;
            Event.CreatedBy = this.Cxt.CurrentUserID;
            Event.Cxt = this.Cxt;
            Event.StatusIDE = (Event.EventID == 0) ? StatusE.Active : Event.StatusIDE;
            Event.Save(trans);
        }

        #endregion

        #region Contained Methods

        #region Schevingin tournament result
        private static DataSet CreateSchevinginCrossTable(DataSet ds)
        {
            DataSet dsSch = new DataSet();

            int i, j, diff, total = ds.Tables[0].Rows.Count;
            int cols = 9;
            double sbp = 0, tp = 0;
            string str;

            DataTable tbl = UData.ToTable2("TournamentResult", "TeamID", "TeamName", "CountryName", "CountryID", "UserID", "Rank", "User Name", "Rating", "Difference");

            for (i = 1; i <= total; i++)
            {
                tbl.Columns.Add((i).ToString());
            }

            tbl.Columns.Add("TotalPoints");

            for (i = 0; i < total; i++)
            {
                diff = UData.ToInt32(ds.Tables[0].Rows[i]["EloAfter"]) - UData.ToInt32(ds.Tables[0].Rows[i]["EloBefore"]);

                if (UData.ToInt32(ds.Tables[0].Rows[i]["EloAfter"]) == 0)
                    diff = 0;

                if (diff > 0)
                    str = "+" + diff.ToString();
                else if (diff == 0)
                    str = "";
                else
                    str = diff.ToString();

                tbl.Rows.Add(
                            ds.Tables[0].Rows[i]["TeamID"], ds.Tables[0].Rows[i]["TeamName"],
                            ds.Tables[0].Rows[i]["CountryName"], ds.Tables[0].Rows[i]["CountryID"],
                            ds.Tables[0].Rows[i]["UserID"], (i + 1).ToString(), ds.Tables[0].Rows[i]["UserName"],
                            ds.Tables[0].Rows[i]["EloBefore"], str);

                str = "";
                for (j = 0; j < total; j++)
                {
                    int u1 = UData.ToInt32(ds.Tables[0].Rows[i]["UserID"]);
                    int u2 = UData.ToInt32(ds.Tables[0].Rows[j]["UserID"]);

                    if (u1 == u2)
                    {
                        tbl.Rows[tbl.Rows.Count - 1][j + cols] = "*";
                    }
                    else
                    {
                        str = GetFinalStandings(u1, u2, ds.Tables[1]);
                        tbl.Rows[tbl.Rows.Count - 1][j + cols] = str;
                    }
                }

                tbl.Rows[tbl.Rows.Count - 1]["TotalPoints"] = ds.Tables[0].Rows[i]["TournamentPoints"];
            }

            //**** order by
            tbl.DefaultView.Sort = "TotalPoints desc";
            tbl = tbl.DefaultView.ToTable();

            for (i = 0; i < total; i++)
            {
                int totalGamePlayed = TotalGamePlayedByUser(ds.Tables[1], tbl.Rows[i]["UserID"].ToString());
                j = UData.ToInt32(tbl.Rows[i]["Rank"]);
                tbl.Columns[j.ToString()].SetOrdinal(i + cols);
                tbl.Rows[i]["Rank"] = i + 1;
                tbl.Rows[i]["TotalPoints"] = tbl.Rows[i]["TotalPoints"] + " / " + (totalGamePlayed);
            }
            tbl.DefaultView.Sort = "TeamID Asc";
            dsSch.Tables.Add(tbl);
            dsSch.Tables.Add(ds.Tables[2].Copy());
            dsSch.Tables.Add(ds.Tables[0].Copy());
            return dsSch;
        }

        //static int TotalGamePlayedByUser(DataTable tbl, string userID)
        //{
        //    DataView dv = tbl.DefaultView;
        //    dv.RowFilter = "WhiteUserID = " + userID;
        //    int dvTotal = dv.Count;
        //    dv.RowFilter = "BlackUserID = " + userID;
        //    dvTotal += dv.Count;
        //    return dvTotal;
        //}

        #endregion

        #region Knock out tournament result
        private static DataSet CreateCrossTableResult(DataSet ds)
        {
            int i, j, diff, total = ds.Tables[0].Rows.Count;
            int cols = 7;
            double sbp = 0, tp = 0;
            string str;
            DataSet dsKo = new DataSet();

            DataTable tbl = UData.ToTable2("TournamentResult", "CountryName", "CountryID", "UserID", "Rank", "User Name", "Rating", "Difference");

            for (i = 1; i <= total; i++)
            {
                tbl.Columns.Add((i).ToString());
            }

            tbl.Columns.Add("TotalPoints");

            for (i = 0; i < total; i++)
            {
                diff = UData.ToInt32(ds.Tables[0].Rows[i]["EloAfter"]) - UData.ToInt32(ds.Tables[0].Rows[i]["EloBefore"]);

                if (UData.ToInt32(ds.Tables[0].Rows[i]["EloAfter"]) == 0)
                    diff = 0;

                if (diff > 0)
                    str = "+" + diff.ToString();
                else if (diff == 0)
                    str = "";
                else
                    str = diff.ToString();

                tbl.Rows.Add(ds.Tables[0].Rows[i]["CountryName"], ds.Tables[0].Rows[i]["CountryID"], ds.Tables[0].Rows[i]["UserID"], (i + 1).ToString(), ds.Tables[0].Rows[i]["UserName"], ds.Tables[0].Rows[i]["EloBefore"], str);

                str = "";
                for (j = 0; j < total; j++)
                {
                    int u1 = UData.ToInt32(ds.Tables[0].Rows[i]["UserID"]);
                    int u2 = UData.ToInt32(ds.Tables[0].Rows[j]["UserID"]);

                    if (u1 == u2)
                    {
                        tbl.Rows[tbl.Rows.Count - 1][j + cols] = "*";
                    }
                    else
                    {
                        str = GetFinalStandings(u1, u2, ds.Tables[1]);
                        tbl.Rows[tbl.Rows.Count - 1][j + cols] = str;
                    }
                }

                tbl.Rows[tbl.Rows.Count - 1]["TotalPoints"] = ds.Tables[0].Rows[i]["TournamentPoints"];

            }

            //**** order by
            tbl.DefaultView.Sort = "TotalPoints desc";
            tbl = tbl.DefaultView.ToTable();


            for (i = 0; i < total; i++)
            {
                int totalGamePlayed = TotalGamePlayedByUser(ds.Tables[1], tbl.Rows[i]["UserID"].ToString());
                j = UData.ToInt32(tbl.Rows[i]["Rank"]);
                tbl.Columns[j.ToString()].SetOrdinal(i + cols);
                tbl.Rows[i]["Rank"] = i + 1;
                tbl.Rows[i]["TotalPoints"] = tbl.Rows[i]["TotalPoints"];
            }
            dsKo.Tables.Add(tbl);

            return dsKo;
        }

        static int TotalGamePlayedByUser(DataTable tbl, string userID)
        {
            DataView dv = tbl.DefaultView;
            dv.RowFilter = "WhiteUserID = " + userID;
            int dvTotal = dv.Count;
            dv.RowFilter = "BlackUserID = " + userID;
            dvTotal += dv.Count;
            return dvTotal;
        }

        #endregion

        #region Create Round Robin Cross Table
        private static DataSet CreateRoundRobinCrossTable(DataSet ds)
        {
            int i, j, diff, total = ds.Tables[0].Rows.Count;
            int cols = 7;
            double sbp = 0, tp = 0;
            string str;
            DataSet dsRR = new DataSet();

            DataTable tbl = UData.ToTable2("TournamentResult", "CountryName", "CountryID", "UserID", "Rank", "Player", "Rating", "Difference");

            for (i = 1; i <= total; i++)
            {
                tbl.Columns.Add((i).ToString());
            }

            tbl.Columns.Add("TotalPoints");
            tbl.Columns.Add("SB");

            for (i = 0; i < total; i++)
            {
                diff = UData.ToInt32(ds.Tables[0].Rows[i]["EloAfter"]) - UData.ToInt32(ds.Tables[0].Rows[i]["EloBefore"]);

                if (UData.ToInt32(ds.Tables[0].Rows[i]["EloAfter"]) == 0)
                    diff = 0;

                if (diff > 0)
                    str = "+" + diff.ToString();
                else if (diff == 0)
                    str = "";
                else
                    str = diff.ToString();

                tbl.Rows.Add(ds.Tables[0].Rows[i]["CountryName"], ds.Tables[0].Rows[i]["CountryID"], ds.Tables[0].Rows[i]["UserID"], (i + 1).ToString(), ds.Tables[0].Rows[i]["UserName"], ds.Tables[0].Rows[i]["EloBefore"], str);

                str = "";
                for (j = 0; j < total; j++)
                {
                    int u1 = UData.ToInt32(ds.Tables[0].Rows[i]["UserID"]);
                    int u2 = UData.ToInt32(ds.Tables[0].Rows[j]["UserID"]);

                    if (u1 == u2)
                    {
                        tbl.Rows[tbl.Rows.Count - 1][j + cols] = "*";
                    }
                    else
                    {
                        str = GetFinalStandings(u1, u2, ds.Tables[1]);
                        tbl.Rows[tbl.Rows.Count - 1][j + cols] = str;
                    }
                }

                tbl.Rows[tbl.Rows.Count - 1]["TotalPoints"] = ds.Tables[0].Rows[i]["TournamentPoints"];//.ToString() + "/" + total.ToString();
                //tbl.Rows[tbl.Rows.Count - 1]["CountryName"] = ds.Tables[0].Rows[i]["CountryName"];
                // tp = 0;
            }

            //***** S.B Points
            for (i = 0; i < total; i++)
            {
                for (j = 0; j < total; j++)
                {
                    if (j != i)
                    {
                        if (tbl.Rows[j]["TotalPoints"] != DBNull.Value)
                        {
                            tp = Convert.ToDouble(tbl.Rows[j]["TotalPoints"]);

                            switch (tbl.Rows[i][j + cols].ToString())
                            {
                                case "1":
                                    sbp = sbp + tp;
                                    break;
                                case "½":
                                    sbp = sbp + (tp / 2);
                                    break;

                            }
                        }
                    }
                }


                if (i > 0)
                {
                    if (i != total - 1)
                    {
                        if (tbl.Rows[i]["TotalPoints"].ToString() == tbl.Rows[i + 1]["TotalPoints"].ToString() || tbl.Rows[i]["TotalPoints"].ToString() == tbl.Rows[i - 1]["TotalPoints"].ToString())
                            tbl.Rows[i]["SB"] = sbp;

                    }
                    else
                        if (tbl.Rows[i]["TotalPoints"].ToString() == tbl.Rows[i - 1]["TotalPoints"].ToString())
                            tbl.Rows[i]["SB"] = sbp;
                }
                else
                {
                    if (tbl.Rows[i]["TotalPoints"].ToString() == tbl.Rows[i + 1]["TotalPoints"].ToString())
                        tbl.Rows[i]["SB"] = sbp;
                }
                sbp = 0;

                //tbl.Rows[i]["SB"] = sbp.ToString();
                //sbp = 0;
            }

            //**** order by
            tbl.DefaultView.Sort = "TotalPoints desc, SB desc";
            tbl = tbl.DefaultView.ToTable();

            for (i = 0; i < total; i++)
            {
                j = UData.ToInt32(tbl.Rows[i]["Rank"]);
                tbl.Columns[j.ToString()].SetOrdinal(i + cols);
                tbl.Rows[i]["Rank"] = i + 1;
                tbl.Rows[i]["TotalPoints"] = tbl.Rows[i]["TotalPoints"] + " / " + (total - 1);
            }
            dsRR.Tables.Add(tbl);
            return dsRR;
        }

        #endregion

        #region Create Double Round Robin Cross Table

        private static DataSet CreateDoubleRoundRobinCrossTable(DataSet ds)
        {
            int i, j, diff, total = ds.Tables[0].Rows.Count;
            int cols = 7;
            double sbp = 0, tp = 0;
            string str;
            DataSet dsDRR = new DataSet();

            DataTable tbl = UData.ToTable2("TournamentResult", "CountryName", "CountryID", "UserID", "Rank", "Player", "Rating", "Difference");

            for (i = 1; i <= total; i++)
            {
                tbl.Columns.Add((i).ToString());
            }

            tbl.Columns.Add("TotalPoints");
            tbl.Columns.Add("SB");

            for (i = 0; i < total; i++)
            {
                diff = UData.ToInt32(ds.Tables[0].Rows[i]["EloAfter"]) - UData.ToInt32(ds.Tables[0].Rows[i]["EloBefore"]);

                if (UData.ToInt32(ds.Tables[0].Rows[i]["EloAfter"]) == 0)
                    diff = 0;

                if (diff > 0)
                    str = "+" + diff.ToString();
                else if (diff == 0)
                    str = "";
                else
                    str = diff.ToString();

                tbl.Rows.Add(ds.Tables[0].Rows[i]["CountryName"], ds.Tables[0].Rows[i]["CountryID"], ds.Tables[0].Rows[i]["UserID"], (i + 1).ToString(), ds.Tables[0].Rows[i]["UserName"], ds.Tables[0].Rows[i]["EloBefore"], str);

                str = "";
                for (j = 0; j < total; j++)
                {
                    int u1 = UData.ToInt32(ds.Tables[0].Rows[i]["UserID"]);
                    int u2 = UData.ToInt32(ds.Tables[0].Rows[j]["UserID"]);

                    if (u1 == u2)
                    {
                        tbl.Rows[tbl.Rows.Count - 1][j + cols] = "* *";
                    }
                    else
                    {
                        str = GetDoubleFinalStandings(u1, u2, ds.Tables[1]);
                        tbl.Rows[tbl.Rows.Count - 1][j + cols] = str;
                        //if (str == "½")
                        //    tp = tp + 0.5;
                        //else if (str == "")
                        //    tp = tp + 0;
                        //else
                        //    tp = tp + Convert.ToDouble(str); ;
                    }
                }

                tbl.Rows[tbl.Rows.Count - 1]["TotalPoints"] = ds.Tables[0].Rows[i]["TournamentPoints"];//.ToString() + "/" + total.ToString();
                tbl.Rows[tbl.Rows.Count - 1]["CountryName"] = ds.Tables[0].Rows[i]["CountryName"];

                //tp = 0;
            }

            //***** S.B Points
            for (i = 0; i < total; i++)
            {
                for (j = 0; j < total; j++)
                {
                    if (j != i)
                    {
                        if (tbl.Rows[j]["TotalPoints"] != DBNull.Value)
                        {
                            tp = Convert.ToDouble(tbl.Rows[j]["TotalPoints"]);

                            switch (tbl.Rows[i][j + cols].ToString())
                            {
                                case "1 0":
                                case "0 1":
                                    sbp = sbp + tp;
                                    break;
                                case "1 1":
                                    sbp = sbp + (tp * 2);
                                    break;
                                case "1 ½":
                                case "½ 1":
                                    sbp = sbp + (tp + (tp / 2));
                                    break;
                                case "½ 0":
                                case "0 ½":
                                    sbp = sbp + (tp / 2);
                                    break;

                            }
                        }
                    }
                }


                if (i > 0)
                {
                    if (i != total - 1)
                    {
                        if (tbl.Rows[i]["TotalPoints"].ToString() == tbl.Rows[i + 1]["TotalPoints"].ToString() || tbl.Rows[i]["TotalPoints"].ToString() == tbl.Rows[i - 1]["TotalPoints"].ToString())
                            tbl.Rows[i]["SB"] = sbp;

                    }
                    else
                        if (tbl.Rows[i]["TotalPoints"].ToString() == tbl.Rows[i - 1]["TotalPoints"].ToString())
                            tbl.Rows[i]["SB"] = sbp;
                }
                else
                {
                    if (tbl.Rows[i]["TotalPoints"].ToString() == tbl.Rows[i + 1]["TotalPoints"].ToString())
                        tbl.Rows[i]["SB"] = sbp;
                }
                sbp = 0;

                //tbl.Rows[i]["SB"] = sbp.ToString();
                //sbp = 0;
            }

            //**** order by
            tbl.DefaultView.Sort = "TotalPoints desc, SB desc";
            tbl = tbl.DefaultView.ToTable();

            for (i = 0; i < total; i++)
            {
                j = UData.ToInt32(tbl.Rows[i]["Rank"]);
                tbl.Columns[j.ToString()].SetOrdinal(i + cols);
                tbl.Rows[i]["Rank"] = i + 1;
                tbl.Rows[i]["TotalPoints"] = tbl.Rows[i]["TotalPoints"] + " / " + ((total - 1) * 2);
            }
            dsDRR.Tables.Add(tbl);
            return dsDRR;
        }

        #endregion

        #region Create Swiss Cross Table
        private static DataSet CreateSwissCrossTable(DataSet ds)
        {
            int i, j, NoR, total = ds.Tables[0].Rows.Count;
            int cols = 5;
            double r, sbp = 0, tp = 0;
            string str;
            DataSet dsSS = new DataSet();

            DataTable tbl = UData.ToTable2("TournamentResult", "Rank", "UserID", "Player", "Rating");
            NoR = 0;
            if (ds.Tables[1].Rows.Count > 0)
                NoR = UData.ToInt32(ds.Tables[1].Rows[0]["NoR"]);

            for (i = 1; i <= NoR; i++)
            {
                tbl.Columns.Add((i).ToString());
            }


            tbl.Columns.Add("TotalPoints");
            tbl.Columns.Add("SB");

            ds.Tables[0].Constraints.Add("pk", ds.Tables[0].Columns["UserID"], true);

            for (i = 0; i < total; i++)
            {

                int u1 = UData.ToInt32(ds.Tables[0].Rows[i]["UserID"]);
                DataRow[] dr = ds.Tables[1].Select("WhiteUserID = " + u1 + " or BlackUserID = " + u1);

                tbl.Rows.Add(ds.Tables[0].Rows[i]["Rank"], ds.Tables[0].Rows[i]["UserID"], ds.Tables[0].Rows[i]["UserName"], ds.Tables[0].Rows[i]["EloAfter"]);

                for (j = 0; j < dr.Length; j++)
                {
                    if (dr[j]["WhiteUserID"].ToString() == u1.ToString())
                    {
                        r = GetResult(UData.ToInt32(dr[j]["GameResultID"]));
                        if (r == 99)
                        {
                            str = "";
                            r = 0;
                        }
                        else if (r == 0.5)
                            str = "+ " + "½" + " / " + ds.Tables[0].Rows.Find(dr[j]["BlackUserID"])["Rank"].ToString();
                        else
                            str = "+ " + r.ToString() + " / " + ds.Tables[0].Rows.Find(dr[j]["BlackUserID"])["Rank"].ToString();
                    }
                    else
                    {
                        r = GetResultInv(UData.ToInt32(dr[j]["GameResultID"]));
                        if (r == 99)
                        {
                            str = "";
                            r = 0;
                        }
                        else if (r == 0.5)
                            str = "- " + "½" + " / " + ds.Tables[0].Rows.Find(dr[j]["WhiteUserID"])["Rank"].ToString();
                        else
                            str = "- " + r.ToString() + " / " + ds.Tables[0].Rows.Find(dr[j]["WhiteUserID"])["Rank"].ToString();

                    }
                    tp = tp + r;
                    tbl.Rows[tbl.Rows.Count - 1][dr[j]["Round"].ToString()] = str;
                }

                tbl.Rows[tbl.Rows.Count - 1]["TotalPoints"] = tp.ToString(); //+ "/" + total.ToString();
                tp = 0;
            }



            tbl.Constraints.Add("pk", tbl.Columns["Rank"], true);

            //S.B Points
            for (i = 0; i < total; i++)
            {
                for (j = cols; j < tbl.Columns.Count - 2; j++)
                {

                    if (tbl.Rows[i][j].ToString() != "")
                    {
                        str = tbl.Rows[i][j].ToString().Substring(2, 1);
                        if (str != "0" && str != "")
                        {
                            str = tbl.Rows[i][j].ToString().Substring(6, tbl.Rows[i][j].ToString().Length - 6);
                            sbp = sbp + Convert.ToDouble(tbl.Rows.Find(str)["TotalPoints"]);
                        }
                    }
                }

                if (i > 0)
                {
                    if (i != total - 1)
                    {
                        if (tbl.Rows[i]["TotalPoints"].ToString() == tbl.Rows[i + 1]["TotalPoints"].ToString() || tbl.Rows[i]["TotalPoints"].ToString() == tbl.Rows[i - 1]["TotalPoints"].ToString())
                            tbl.Rows[i]["SB"] = sbp;

                    }
                    else
                        if (tbl.Rows[i]["TotalPoints"].ToString() == tbl.Rows[i - 1]["TotalPoints"].ToString())
                            tbl.Rows[i]["SB"] = sbp;
                }
                else
                {
                    if (tbl.Rows[i]["TotalPoints"].ToString() == tbl.Rows[i + 1]["TotalPoints"].ToString())
                        tbl.Rows[i]["SB"] = sbp;
                }
                sbp = 0;
            }

            //////**** order by
            //tbl.DefaultView.Sort = "TotalPoints desc, SB desc";
            //tbl = tbl.DefaultView.ToTable();

            tbl.Columns.Remove("UserID");

            ////for (i = 0; i < total; i++)
            ////{
            ////    tbl.Rows[i]["RNo"] = i + 1;
            ////    tbl.Rows[i]["TotalPoints"] = tbl.Rows[i]["TotalPoints"] + " / " + NoR;
            ////}
            dsSS.Tables.Add(tbl.Copy());
            return dsSS;
        }

        #endregion

        #region Get Final Result
        private static string GetFinalStandings(int u1, int u2, DataTable dt)
        {
            DataRow[] dr = dt.Select("WhiteUserID = " + u1 + " and BlackUserID = " + u2);
            double r = 0;

            if (dr.Length > 0)
            {
                r = GetResult(UData.ToInt32(dr[0]["GameResultID"]));
                if (r == 0.5)
                {
                    //return "½";
                    return "1/2";
                }
                else if (r == 0.1)
                {
                    return "0";
                }
                else if (r == 0.2)
                {
                    return "-";
                }
                else if (r == 0.3)
                {
                    return "+";
                }
                else if (r == 99)
                {
                    return "";
                }
                else
                {
                    return r.ToString();
                }
            }
            else
            {
                dr = dt.Select("WhiteUserID=" + u2 + " and BlackUserID=" + u1);
                if (dr.Length > 0)
                {
                    r = GetResultInv(UData.ToInt32(dr[0]["GameResultID"]));
                    if (r == 0.5)
                    {
                        //return "½";// @"<font color=black>½</font>";
                        return "1/2";
                    }
                    else if (r == 0.1)
                    {
                        return "0";//@"<font color=black>0</font>";
                    }
                    else if (r == 0.2)
                    {
                        return "-";//@"<font color=black>-</font>";
                    }
                    else if (r == 0.3)
                    {
                        return "+";//@"<font color=black>+</font>";
                    }
                    else if (r == 99)
                    {
                        return "";
                    }
                    else
                    {
                        return r.ToString();//@"<font color=black>" + r.ToString() + @"</font>";
                    }
                }
                return "";
            }
        }

        #endregion

        #region Get Double Final Standings
        private static string GetDoubleFinalStandings(int u1, int u2, DataTable dt)
        {

            double r = 0;
            string str = "";
            DataRow[] dr = null;

            if (u1 < u2)
            {
                dr = dt.Select("WhiteUserID = " + u1 + " and BlackUserID = " + u2);
                if (dr.Length > 0)
                {
                    r = GetResult(UData.ToInt32(dr[0]["GameResultID"]));
                    if (r == 0.5)
                    {
                        str += "½";
                    }
                    else if (r == 0.1)
                    {
                        str += "0";
                    }
                    else if (r == 0.2)
                    {
                        str += "-";
                    }
                    else if (r == 0.3)
                    {
                        str += "+";
                    }
                    else if (r == 99)
                    {
                        str += " ";
                    }
                    else
                    {
                        str += r.ToString();
                    }
                }

                dr = dt.Select("WhiteUserID=" + u2 + " and BlackUserID=" + u1);
                if (dr.Length > 0)
                {
                    r = GetResultInv(UData.ToInt32(dr[0]["GameResultID"]));
                    if (r == 0.5)
                    {
                        str += " ½";
                    }
                    else if (r == 0.1)
                    {
                        str += @"<font color=black>0</font>";
                    }
                    else if (r == 0.2)
                    {
                        str += @"<font color=black>-</font>";
                    }
                    else if (r == 0.3)
                    {
                        str += @"<font color=black>+</font>";
                    }
                    else if (r == 99)
                    {
                        str += " ";
                    }
                    else
                    {
                        str += " " + @"<font color=black>" + r.ToString() + @"</font>";
                    }
                }
                return str;
            }
            else
            {

                dr = dt.Select("WhiteUserID=" + u2 + " and BlackUserID=" + u1);
                if (dr.Length > 0)
                {
                    r = GetResultInv(UData.ToInt32(dr[0]["GameResultID"]));
                    if (r == 0.5)
                    {
                        str += "½";
                    }
                    else if (r == 0.1)
                    {
                        str += @"<font color=black>0</font>";
                    }
                    else if (r == 0.2)
                    {
                        str += @"<font color=black>-</font>";
                    }
                    else if (r == 0.3)
                    {
                        str += @"<font color=black>+</font>";
                    }
                    else if (r == 99)
                    {
                        str += " ";
                    }
                    else
                    {
                        str += @"<font color=black>" + r.ToString() + @"</font>";
                    }
                }

                dr = dt.Select("WhiteUserID = " + u1 + " and BlackUserID = " + u2);

                if (dr.Length > 0)
                {
                    r = GetResult(UData.ToInt32(dr[0]["GameResultID"]));
                    if (r == 0.5)
                    {
                        str += " ½";
                    }
                    else if (r == 0.1)
                    {
                        str += "0";
                    }
                    else if (r == 0.2)
                    {
                        str += "-";
                    }
                    else if (r == 0.3)
                    {
                        str += "+";
                    }
                    else if (r == 99)
                    {
                        str += " ";
                    }
                    else
                    {
                        str += " " + r.ToString();
                    }
                }
                return str;
            }
        }

        #endregion

        #region Get Result
        private static double GetResult(int GameResultID)
        {
            GameResultE gr = (GameResultE)GameResultID;
            switch (gr)
            {
                case GameResultE.None:
                    break;
                case GameResultE.InProgress:
                    break;
                case GameResultE.ForcedWhiteWin:
                case GameResultE.WhiteWin:
                    return 1;
                case GameResultE.ForcedWhiteLose:
                case GameResultE.WhiteLose:
                    return 0;
                case GameResultE.ForcedDraw:
                case GameResultE.Draw:
                    return 0.5;
                case GameResultE.NoResult:
                case GameResultE.Absent:
                    return 0.1;
                case GameResultE.WhiteBye:
                    return 0.2;
                case GameResultE.BlackBye:
                    return 0.3;
                default:
                    break;
            }
            return 99;
        }

        #endregion

        #region Get Result Inv
        private static double GetResultInv(int GameResultID)
        {
            GameResultE gr = (GameResultE)GameResultID;
            switch (gr)
            {
                case GameResultE.None:
                    break;
                case GameResultE.InProgress:
                    break;
                case GameResultE.ForcedWhiteWin:
                case GameResultE.WhiteWin:
                    return 0;
                case GameResultE.ForcedWhiteLose:
                case GameResultE.WhiteLose:
                    return 1;
                case GameResultE.ForcedDraw:
                case GameResultE.Draw:
                    return 0.5;
                case GameResultE.NoResult:
                case GameResultE.Absent:
                    return 0.1;
                case GameResultE.WhiteBye:
                    return 0.3;
                case GameResultE.BlackBye:
                    return 0.2;
                default:
                    break;
            }

            return 99;
        }

        #endregion

        #endregion
    }
}
