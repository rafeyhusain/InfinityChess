// (c) Copyright RafeySoft, Karachi Pakistan. http://rafeysoft.com
// This source is subject to following License:
// http://rafeysoft.com/Web/Page/ItemEdit.aspx?sid=29&lid=4&cid=23&iid=2143
// Please write to info@rafeysoft.com for more information
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Diagnostics;
using App.Model.Db;

namespace App.Model
{
    #region Code Generator SQL
    /*        
        
    declare @TableName varchar(300)
declare @Kv varchar(300)
declare @Get varchar(300)
declare @Set varchar(300)
set @TableName = 'ScheduledJob'
-- for Kv
--set @Kv = 'Kv.'  
--set @Get = ''
--set @Set = 'Kv.Set'
-- for DB
set @Kv = '' 
set @Get = 'Col'
set @Set = 'SetColumn' 
     
select '#region Properties'
UNION ALL select ''
UNION ALL 
select '#region Core'
UNION ALL
select 'public override InfiChess TableName { [DebuggerStepThrough] get { return InfiChess.' + @TableName + '; } [DebuggerStepThrough] set { base.TableName = value; } }'
UNION ALL
select '#endregion'
UNION ALL select ''
UNION ALL 
select '#region Enum'
UNION ALL
     * select '#endregion'
UNION ALL select ''
UNION ALL
select '#region Generated'
UNION ALL
select 
    'public int ' + name + ' { [DebuggerStepThrough] get { return ' + @Kv + 'Get' + @Get + 'Int32("' + name + '"); } [DebuggerStepThrough] set { ' + @Set + '("' + name + '", value); } } '
    from sys.columns where object_id in (select object_id from sys.tables where name = @TableName)
and system_type_id in (56) and name not in ('CreatedBy', 'ModifiedBy')
UNION ALL
select 
    'public string ' + name + ' { [DebuggerStepThrough] get { return ' + @Kv + 'Get' + @Get + '("' + name + '"); } [DebuggerStepThrough] set { ' + @Set + '("' + name + '", value); } } '
    from sys.columns where object_id in (select object_id from sys.tables where name = @TableName)
and system_type_id not in (56, 61, 104)
UNION ALL
select 
    'public DateTime ' + name + ' { [DebuggerStepThrough] get { return ' + @Kv + 'Get' + @Get + 'DateTime("' + name + '"); } [DebuggerStepThrough] set { ' + @Set + '("' + name + '", value); } } '
    from sys.columns where object_id in (select object_id from sys.tables where name = @TableName)
and system_type_id in (61) and name not in ('DateCreated', 'DateModified')
UNION ALL
select 
    'public bool ' + name + ' { [DebuggerStepThrough] get { return ' + @Kv + 'Get' + @Get + 'Bool("' + name + '"); } [DebuggerStepThrough] set { ' + @Set + '("' + name + '", value); } } '
    from sys.columns where object_id in (select object_id from sys.tables where name = @TableName)
and system_type_id in (104)
UNION ALL
select '#endregion'
UNION ALL select ''
UNION ALL
select '#region Contained Classes'
UNION ALL
select '#endregion'
UNION ALL select ''
UNION ALL
select '#region Calculated'
UNION ALL
select '#endregion'
UNION ALL select ''
UNION ALL
select '#endregion'


    */
    #endregion

    #region enums

    #region InfiChess
    //SELECT name + ',' FROM sys.objects where type='U' and name not in ('sysdiagrams', 'dtproperties') order by name
    public enum InfiChess
    {
        Unknown,
        AccessCode,
        BlockedIP,
        Challenge,
        ChallengeStatus,
        ChallengeType,
        ChessType,
        Color,
        Contact,
        Country,
        EmailTemplate,
        Engine,
        Event,
        EventType,
        FideTitle,
        Game,
        GameResult,
        GameType,
        Gender,
        IccfTitle,
        Internet,
        KeyValue,
        Log,
        NearestCity,
        News,
        Order,
        OrderDetail,
        OrderStatus,
        Performance,
        Product,
        Rank,
        RankRule,
        RatingKFactor,
        RatingSystem,
        RatingWinProbablity,
        RegisteredUser,
        Role,
        RoleTask,
        Room,
        RoomChessType,
        RoomRank,
        ScheduledJob,
        ServerEvent,
        ServerEventLog,
        ServerStatistics,
        Social,
        Status,
        Strength,
        Task,
        Team,
        Tournament,
        TournamentMatch,
        TournamentMatchStatus,
        TournamentTeam,
        TournamentType,
        TournamentUser,
        TournamentUserStatus,
        TournamentWantinUser,
        User,
        UserAccessCode,
        UserFormula,
        UserGameType,
        UserMessage,
        UserRole,
        UserStatus,
        UserVoucher,
        VoucherStatus,
        TournamentPrize,
        NewsCategory,
        UserFini,
        TournamentMatchRule,
        TournamentRound
    }

    #endregion

    #region EntityTypeE

    public enum TournamentEntityTypeE
    {
        RegisterUser,
        RegisteredUser
    }

    #endregion

    #region UserStatusE
    //SELECT Name + ' = ' + CONVERT(VARCHAR(20), UserStatusID) + ',' FROM UserStatus
    public enum UserStatusE
    {
        Unknown = 0,
        Blank = 1,
        Playing = 2,
        Centaur = 3,
        Gone = 4,
        Kibitzer = 5,
        Engine = 6
    }
    #endregion

    #region FideTitle
    //SELECT Name + ' = ' + CONVERT(VARCHAR(20), FideTitleID) + ',' FROM FideTitle
    public enum FideTitleE
    {
        None = 1,
        FM = 2,
        IM = 3,
        GM = 4
    }
    #endregion

    #region IccfTitle
    //SELECT Name + ' = ' + CONVERT(VARCHAR(20), IccfTitleID) + ',' FROM IccfTitle
    public enum IccfTitleE
    {
        None = 1,
        IM = 2,
        SIM = 3,
        GM = 4
    }
    #endregion

    #region Gender
    //SELECT Name + ' = ' + CONVERT(VARCHAR(20), GenderID) + ',' FROM Gender
    public enum GenderE
    {
        Mr = 1,
        Mrs = 2,
        Comp = 3
    }
    #endregion

    #region RankRuleE
    //SELECT RT.Name + R.Name + '=' + CONVERT(VARCHAR(20), R.RankRuleID) + ',' FROM [RankRule] R INNER JOIN RankType RT ON R.RankTypeID = RT.RankTypeID
    public enum RankRuleE
    {
        Unknown = 0,
        HumanPawn = 1,
        HumanKnight = 2,
        HumanBishop = 3,
        HumanRook = 4,
        HumanQueen = 5,
        HumanKing = 6,
        EnginePawn = 7,
        EngineKnight = 8,
        EngineBishop = 9,
        EngineRook = 10,
        EngineQueen = 11,
        EngineKing = 12,
        CentaurPawn = 13,
        CentaurKnight = 14,
        CentaurBishop = 15,
        CentaurRook = 16,
        CentaurQueen = 17,
        CentaurKing = 18,
        CorrespondencePawn = 19,
        CorrespondenceKnight = 20,
        CorrespondenceBishop = 21,
        CorrespondenceRook = 22,
        CorrespondenceQueen = 23,
        CorrespondenceKing = 24,
        Guest = 25
    }
    #endregion

    #region MethodNameE
    public enum MethodNameE
    {
        Unknown = 0,

        AddSession = 1,
        UpdateSession = 2,

        AddUser = 3,
        UpdateUser = 4,
        DeleteUser = 5,
        CheckUserId = 6,
        GetUserById = 7,
        GetUserInfoByUserID = 8,
        GetUserPicture = 9,
        ChangeUserStatus = 10,
        ForgotPassword = 11,
        ChangePassword = 12,
        SetUserEngine = 13,

        LoginGuest = 14,
        LoginUser = 16,
        LogoffUser = 17,

        GetAllUsers = 18,
        GetAllRooms = 19,
        GetAllGames = 20,
        GetAllCountries = 21,
        GetAllCities = 22,
        GetDataByRoomID = 23,
        GetNews = 24,
        GetKeyValues = 25,
        GetRoomUsersCount = 26,
        GetGamesByUserID = 27,

        AddGameData = 28,
        GetGameDataByGameID = 29,
        GetGameDataByChallengeID = 30,
        UpdateGameDataByGameID = 31,
        UpdateGameResultByGameID = 32,

        AddChallengeData = 33,
        UpdateAcceptedChallenge = 34,
        DeleteChallenge = 35,
        DeclineChallenge = 36,
        GetChallengeByID = 37,
        ModifyChallenge = 38,

        NewGame = 39,
        Resign = 40,
        Draw = 41,
        TimeExpired = 42,
        KingStaleMated = 43,
        ThreefoldRepetition = 44,

        AddAudience = 45,
        RemoveAudience = 46,
        GetAudiance = 47,
        GetAudienceGameData = 48,
        UserLeaveGame = 49,
        Ping = 50,

        BanUser = 51,
        KickUser = 52,
        Abort = 53,

        GetServerTime = 54,
        ChatMessage = 55,

        BlockIP = 56,

        GetUsersByGameType = 57,
        HighestRankingPlayerGame = 58,

        UserByName = 59,
        GamesByUserName = 60,
        SystemInformation = 61,
        UpdateUserStatus = 62,

        PauseUser = 63,
        IdleUser = 64,

        GetLastInprogressGame = 65,

        AddAudienceAsync = 66,

        UpdateFormula = 67,
        SendEmail = 68,
        DeleteEmail = 69,

        GetRankInfo = 70,
        GetUserFormula = 71,

        AvChat = 72,

        DeclineChallenges = 73,

        CheckoutAccount = 74,

        GetServerStatistics = 75,

        QueryUpgrade = 76,
        SetGamePositionByFen = 77,
        BlockMachine = 78,
        WriteChatMessage = 79,
        ForceLogoff = 80,

        StartTournamentMatch = 81,

        GetKeyValue = 82,

        PingClient = 83,
        HeartbeatPing = 84,

        SaveTournament = 85,
        GetAllUserByID = 86,
        UpdateBanStatus = 87,
        GetTournamentCmbData = 88,
        GetTournamentMatchs = 89,
        SaveTeam = 90,
        GetAllTeam = 91,
        AddPrize = 92,

        SaveWantinUsers = 93,
        GetTournamentWantinUser = 94,
        UpdateWantinUsers = 95,
        GetNonDeletedTournament = 96,
        SaveTournamentRegisterUsers = 97,
        GetTournamentRegisteredUser = 98,
        UpdateTournamentMatchStatus = 99,
        TournamentStart = 100,
        TournamentFinish = 101,

        GetAllTournaments = 102,
        GetPrize = 103,

        SaveTournamentTeam = 104,
        GetTournamentResultById = 105,
        GetTeamsByTournamentID = 106,
        SaveTournamentRegisteredUsers = 107,
        GetTournamentMatches = 108,
        GetPrizesByTournamentID = 109,
        GetAllNews = 110,
        DeleteTournament = 111,
        UpdateNewsStatus = 112,
        GetTournamentRegisterUser = 113,
        GetRecentTournamentTeam = 114,
        CreateTournamentRounds = 115,
        GetGameIDByTournamentMatchID = 116,
        DeleteTournamentTeam = 117,
        UpdateTeamStatus = 118,
        GetTournamentTeamRegisteredUser = 119,
        GetTournamentMatchRules = 120,
        DeleteTournamentPrize = 121,
        GetTournamentByID = 122,
        GetTournamentPrizeCategories = 123,
        StartTournamentRound = 124,
        GetTeamByID = 125,
        CreateTournamentWantinUser = 126,
        GetNewsByID = 127,
        GetAllNewsCategory = 128,
        SaveNews = 129,
        UpdateRoomStatus = 130,
        GetAllRoomsWithRelationShip = 131,
        SaveTournamentMatch = 132,
        GetTournamntMatchByParentID = 133,
        GetRoomByID = 134,
        SaveRoom = 135,
        GetAllLog = 136,
        ClearLog = 137,
        GetAllRoomsWithNullTournament = 138,
        GetSetIntruptedGameUserEngine = 139,
        CloseInProgressGameWindow = 140,
        GetAllBlockedIPs = 141,
        UnBlockIPs = 142,
        RestartGame = 143,
        GetBlockedIPByID = 144,
        UpdateReplacePlayer = 145,
        RescheduleTournament = 146,
        SaveBlockedIP = 147,
        GetGameDataByTournamentMatchID = 148,
        MakeAdmin = 149,
        GetAllAdmin = 150,
        RestartGameWithSetup = 151,
        RevokeAdmin = 152,
        GetAllBanUser = 153,
        GetAllBanUserMachine = 154,
        ForcedGameWin = 155,
        GetAvailablePatches = 156,
        BannedUser = 157,
        KickedUser = 158,
        IsKnockOutTournamentCompleted = 159
    }
    #endregion

    #region ColorE
    public enum ColorE
    {
        None = 0,
        Autometic = 1,
        White = 2,
        Black = 3
    }
    #endregion

    #region ChessTypeE
    public enum ChessTypeE
    {
        None = 0,
        Human = 1,
        Engine = 2,
        Centaur = 3,
        Correspondence = 4
    }
    #endregion

    #region TournamentUserStatusE
    public enum TournamentUserStatusE
    {
        None = 0,
        Wantin = 1,
        Approved = 2,
        Declined = 3
    }
    #endregion

    #region TournamentMatchStatusE
    public enum TournamentMatchStatusE
    {
        None = 0,
        Scheduled = 1,
        InProgress = 2,
        Finsihed = 3,
        Postpond = 4,
        Absent = 5,
        Draw = 6,
        WhiteBye = 7,
        BlackBye = 8,
        ForcedWhiteWin = 9,
        ForcedWhiteLose = 10,
        ForcedDraw = 11
    }
    #endregion

    #region TournamentMatchTypeE
    public enum TournamentMatchTypeE
    {
        None = 0,
        Normal = 1,
        TieBreak = 2,
        SuddenDeath = 3
    }
    #endregion


    #region DrawE
    public enum DrawE
    {
        None = 0,
        Asked = 1,
        Accepted = 2,
        Decline = 3
    }
    #endregion

    #region ResetGameE
    public enum ResetGameE
    {
        None = 0,
        Asked = 1,
        Accepted = 2,
        Decline = 3,
        ResetAsked = 4,
        ResetDone = 5
    }
    #endregion

    #region NewGameE
    public enum NewGameE
    {
        None = 0,
        Asked = 1,
        Accepted = 2,
        Decline = 3
    }
    #endregion

    #region InternetE
    public enum InternetE
    {
        None = 0,
        Execellent = 1,
        Good = 2,
        Average = 3,
        Fair = 4,
        Poor = 5
    }
    #endregion


    #endregion

    public class BaseItem
    {
        #region Data Members
        public DataRow DataRow = null;
        public Cxt Cxt = null;
        private InfiChess tableName = InfiChess.Unknown;
        #endregion

        #region Constructor
        public BaseItem()
        {
        }

        public BaseItem(int id)
            : this(null, id)
        {
        }

        public BaseItem(Cxt cxt, int id)
        {
            Cxt = cxt;

            Load(id);
        }

        public BaseItem(Cxt cxt, BaseItem item)
        {
            Cxt = cxt;

            DataRow = item.DataRow;
        }

        public BaseItem(Cxt cxt, DataRow row)
        {
            Cxt = cxt;

            DataRow = row;
        }
        #endregion

        #region Properties
        public virtual InfiChess TableName
        {
            [DebuggerStepThrough]
            get { return tableName; }
            [DebuggerStepThrough]
            set { tableName = value; }
        }

        public virtual string PrimaryKey
        {
            [DebuggerStepThrough]
            get { return TableName.ToString() + "ID"; }
        }

        public virtual int ID
        {
            [DebuggerStepThrough]
            get { return GetColInt32(PrimaryKey); }
        }

        public virtual bool IsNew
        {
            [DebuggerStepThrough]
            get
            {
                if (DataRow == null)
                {
                    return true;
                }

                if (DataRow.RowState == DataRowState.Added)
                {
                    return true;
                }

                return false;
            }
            [DebuggerStepThrough]
            set
            {
                if (DataRow == null)
                {
                    return;
                }

                if (!CanGetRow(DataRow))
                {
                    return;
                }

                DataRow.AcceptChanges();

                if (value)
                {
                    DataRow.SetAdded();
                }
                else
                {
                    DataRow.SetModified();
                }
            }
        }

        public virtual bool IsUnchanged
        {
            [DebuggerStepThrough]
            get
            {
                if (DataRow == null)
                {
                    return true;
                }

                if (DataRow.RowState == DataRowState.Unchanged)
                {
                    return true;
                }

                return false;
            }
        }

        public int ModifiedBy
        {
            [DebuggerStepThrough]
            get { return GetColInt32("ModifiedBy"); }
            [DebuggerStepThrough]
            set { SetColumn("ModifiedBy", value); }
        }

        public DateTime DateModified
        {
            [DebuggerStepThrough]
            get { return GetColDateTime("DateModified"); }
            [DebuggerStepThrough]
            set { SetColumn("DateModified", value); }
        }

        public int CreatedBy
        {
            [DebuggerStepThrough]
            get { return GetColInt32("CreatedBy"); }
            [DebuggerStepThrough]
            set { SetColumn("CreatedBy", value); }
        }

        public DateTime DateCreated
        {
            [DebuggerStepThrough]
            get { return GetColDateTime("DateCreated"); }
            [DebuggerStepThrough]
            set { SetColumn("DateCreated", value); }
        }

        public string Description
        {
            [DebuggerStepThrough]
            get { return GetCol("Description"); }
            [DebuggerStepThrough]
            set { SetColumn("Description", value); }
        }

        public string Name
        {
            [DebuggerStepThrough]
            get { return GetCol("Name"); }
            [DebuggerStepThrough]
            set { SetColumn("Name", value); }
        }

        #region Foreign Keys

        private User createdUser = null;
        public User CreatedUser
        {
            [DebuggerStepThrough]
            get
            {
                if (createdUser == null)
                {
                    createdUser = new User(Cxt, CreatedBy);
                }

                return createdUser;
            }
            [DebuggerStepThrough]
            set
            {
                createdUser = value;
            }
        }

        private User modifiedUser = null;
        public User ModifiedUser
        {
            [DebuggerStepThrough]
            get
            {
                if (modifiedUser == null)
                {
                    modifiedUser = new User(Cxt, ModifiedBy);
                }

                return modifiedUser;
            }
            [DebuggerStepThrough]
            set
            {
                modifiedUser = value;
            }
        }
        #endregion

        #region Calculated
        public string CreatedDuration
        {
            [DebuggerStepThrough]
            get
            {
                return UStr.Duration(DateCreated);
            }
        }

        public string ModifiedDuration
        {
            [DebuggerStepThrough]
            get
            {
                return UStr.Duration(DateModified);
            }
        }
        #endregion
        #endregion

        #region Common
        public void Load(int id)
        {
            if (TableName == InfiChess.Unknown)
            {
                return;
            }

            DataTable table = BaseCollection.Select(TableName, PrimaryKey, id);

            SetRow(table);
        }

        protected void SetRow(DataTable table)
        {
            if (table.Rows.Count > 0)
            {
                DataRow = table.Rows[0];
            }
            else
            {
                NewRow(table);
            }
        }

        public virtual void Save()
        {
            Save(Config.ConnectionString);
        }

        public virtual void Save(string connectionString)
        {
            Save(connectionString, null);
        }

        public virtual void Save(SqlTransaction t)
        {
            Save(t.Connection.ConnectionString, t);
        }

        protected virtual void Save(string connectionString, SqlTransaction t)
        {
            if (IsUnchanged)
            {
                return;
            }

            UpdateAuditLog();

            SqlHelper.Save(connectionString, t, DataRow);
        }

        private void UpdateAuditLog()
        {
            int userID = 1;

            // 1st try
            if (Cxt != null)
            {
                if (Cxt.CurrentUserID > 0)
                {
                    userID = Cxt.CurrentUserID;
                }
            }

            if (Ap.CurrentUser != null)
            {
                // 2nd try
                if (Ap.CurrentUserID > 0)
                {
                    userID = Ap.CurrentUserID;
                }
            }
            // now audit
            if (IsNew)
            {
                CreatedBy = userID;
                DateCreated = DateTime.Now;
            }
            else
            {
                ModifiedBy = userID;
                DateModified = DateTime.Now;
            }
        }

        public virtual void NewRow(DataTable table)
        {
            DataRow = table.NewRow();

            table.Rows.Add(DataRow);

            SetColumn("CreatedBy", 1);
            SetColumn("DateCreated", DateTime.Now);
        }

        public virtual void SetTableName(string tableName)
        {
            //SELECT 'case "'+name+'": TableName = InfiChess.'+name+'; break;' FROM sys.objects where type='U' and name not in ('sysdiagrams', 'dtproperties') order by name
            switch (tableName)
            {
                case "Log": TableName = InfiChess.Log; break;
                case "Role": TableName = InfiChess.Role; break;
                case "RoleTask": TableName = InfiChess.RoleTask; break;
                case "Status": TableName = InfiChess.Status; break;
                case "Task": TableName = InfiChess.Task; break;
                case "User": TableName = InfiChess.User; break;
                case "UserRole": TableName = InfiChess.UserRole; break;
                default: TableName = InfiChess.Unknown; break;
            }
        }

        #endregion

        #region Get Set Column

        #region GetColumn

        #region GetColDateTime

        public DateTime GetColDateTime(string columnName)
        {
            return Convert.ToDateTime(BaseItem.GetColumn(DataRow, columnName, UDate.DefaultDate));
        }

        public DateTime GetColDateTime(object row, string columnName, DateTime deafultValue)
        {
            return Convert.ToDateTime(BaseItem.GetColumn(row, columnName, deafultValue));
        }

        public DateTime GetColDateTime(string columnName, DateTime deafultValue)
        {
            return Convert.ToDateTime(BaseItem.GetColumn(DataRow, columnName, deafultValue));
        }

        public static DateTime GetColDateTime(object row, string columnName)
        {
            return Convert.ToDateTime(BaseItem.GetColumn(row, columnName, UDate.DefaultDate));
        }

        public static DateTime GetColDateTime(DataRowView row, string columnName)
        {
            return Convert.ToDateTime(BaseItem.GetColumn(row, columnName, UDate.DefaultDate));
        }

        public static DateTime GetColDateTime(DataRow row, string columnName)
        {
            return Convert.ToDateTime(BaseItem.GetColumn(row, columnName, UDate.DefaultDate));
        }

        public static DateTime GetColDateTime(DataRowView row, string columnName, DateTime deafultValue)
        {
            return Convert.ToDateTime(BaseItem.GetColumn(row, columnName, deafultValue));
        }

        public static DateTime GetColDateTime(DataRow row, string columnName, DateTime deafultValue)
        {
            return Convert.ToDateTime(BaseItem.GetColumn(row, columnName, deafultValue));
        }

        #endregion

        #region GetColDecimal

        public Decimal GetColDecimal(string columnName)
        {
            return BaseItem.ToDecimal(BaseItem.GetColumn(DataRow, columnName, 0));
        }

        public Decimal GetColDecimal(object row, string columnName, Decimal deafultValue)
        {
            return BaseItem.ToDecimal(BaseItem.GetColumn(row, columnName, deafultValue), deafultValue);
        }

        public Decimal GetColDecimal(string columnName, Decimal deafultValue)
        {
            return BaseItem.ToDecimal(BaseItem.GetColumn(DataRow, columnName, deafultValue), deafultValue);
        }

        public static Decimal GetColDecimal(object row, string columnName)
        {
            return BaseItem.ToDecimal(BaseItem.GetColumn(row, columnName, 0));
        }

        public static Decimal GetColDecimal(DataRowView row, string columnName)
        {
            return BaseItem.ToDecimal(BaseItem.GetColumn(row, columnName, 0));
        }

        public static Decimal GetColDecimal(DataRow row, string columnName)
        {
            return BaseItem.ToDecimal(BaseItem.GetColumn(row, columnName, 0));
        }

        public static Decimal GetColDecimal(DataRowView row, string columnName, Decimal deafultValue)
        {
            return BaseItem.ToDecimal(BaseItem.GetColumn(row, columnName, deafultValue), deafultValue);
        }

        public static Decimal GetColDecimal(DataRow row, string columnName, Decimal deafultValue)
        {
            return BaseItem.ToDecimal(BaseItem.GetColumn(row, columnName, deafultValue), deafultValue);
        }

        #endregion

        #region GetColDouble

        public Double GetColDouble(string columnName)
        {
            return BaseItem.ToDouble(BaseItem.GetColumn(DataRow, columnName, 0));
        }

        public Double GetColDouble(object row, string columnName, Double deafultValue)
        {
            return BaseItem.ToDouble(BaseItem.GetColumn(row, columnName, deafultValue), deafultValue);
        }

        public Double GetColDouble(string columnName, Double deafultValue)
        {
            return BaseItem.ToDouble(BaseItem.GetColumn(DataRow, columnName, deafultValue), deafultValue);
        }

        public static Double GetColDouble(object row, string columnName)
        {
            return BaseItem.ToDouble(BaseItem.GetColumn(row, columnName, 0));
        }

        public static Double GetColDouble(DataRowView row, string columnName)
        {
            return BaseItem.ToDouble(BaseItem.GetColumn(row, columnName, 0));
        }

        public static Double GetColDouble(DataRow row, string columnName)
        {
            return BaseItem.ToDouble(BaseItem.GetColumn(row, columnName, 0));
        }

        public static Double GetColDouble(DataRowView row, string columnName, Double deafultValue)
        {
            return BaseItem.ToDouble(BaseItem.GetColumn(row, columnName, deafultValue), deafultValue);
        }

        public static Double GetColDouble(DataRow row, string columnName, Double deafultValue)
        {
            return BaseItem.ToDouble(BaseItem.GetColumn(row, columnName, deafultValue), deafultValue);
        }

        #endregion

        #region GetColBool

        public bool GetColBool(string columnName)
        {
            return BaseItem.ToBool(BaseItem.GetColumn(DataRow, columnName, false));
        }

        public bool GetColBool(object row, string columnName, bool deafultValue)
        {
            return BaseItem.ToBool(BaseItem.GetColumn(row, columnName, deafultValue), deafultValue);
        }

        public bool GetColBool(string columnName, bool deafultValue)
        {
            return BaseItem.ToBool(BaseItem.GetColumn(DataRow, columnName, deafultValue), deafultValue);
        }

        public static bool GetColBool(object row, string columnName)
        {
            return BaseItem.ToBool(BaseItem.GetColumn(row, columnName, false));
        }

        public static bool GetColBool(DataRowView row, string columnName)
        {
            return BaseItem.ToBool(BaseItem.GetColumn(row, columnName, false));
        }

        public static bool GetColBool(DataRow row, string columnName)
        {
            return BaseItem.ToBool(BaseItem.GetColumn(row, columnName, false));
        }

        public static bool GetColBool(DataRowView row, string columnName, bool deafultValue)
        {
            return BaseItem.ToBool(BaseItem.GetColumn(row, columnName, deafultValue), deafultValue);
        }

        public static bool GetColBool(DataRow row, string columnName, bool deafultValue)
        {
            return BaseItem.ToBool(BaseItem.GetColumn(row, columnName, deafultValue), deafultValue);
        }

        #endregion

        #region GetColInt32

        public int GetColInt32(string columnName)
        {
            return BaseItem.ToInt32(BaseItem.GetColumn(DataRow, columnName, 0));
        }

        public int GetColInt32(object row, string columnName, int deafultValue)
        {
            return BaseItem.ToInt32(BaseItem.GetColumn(row, columnName, deafultValue), deafultValue);
        }

        public int GetColInt32(string columnName, int deafultValue)
        {
            return BaseItem.ToInt32(BaseItem.GetColumn(DataRow, columnName, deafultValue), deafultValue);
        }

        public static int GetColInt32(object row, string columnName)
        {
            return BaseItem.ToInt32(BaseItem.GetColumn(row, columnName, 0));
        }

        public static int GetColInt32(DataRowView row, string columnName)
        {
            return BaseItem.ToInt32(BaseItem.GetColumn(row, columnName, 0));
        }

        public static int GetColInt32(DataRow row, string columnName)
        {
            return BaseItem.ToInt32(BaseItem.GetColumn(row, columnName, 0));
        }

        public static int GetColInt32(DataRowView row, string columnName, int deafultValue)
        {
            return BaseItem.ToInt32(BaseItem.GetColumn(row, columnName, deafultValue), deafultValue);
        }

        public static int GetColInt32(DataRow row, string columnName, int deafultValue)
        {
            return BaseItem.ToInt32(BaseItem.GetColumn(row, columnName, deafultValue), deafultValue);
        }

        #endregion

        #region GetCol

        public string GetCol(string columnName)
        {
            return BaseItem.GetColumn(DataRow, columnName, "").ToString();
        }

        public string GetCol(object row, string columnName, string deafultValue)
        {
            return BaseItem.GetColumn(row, columnName, deafultValue).ToString();
        }

        public string GetCol(string columnName, string deafultValue)
        {
            return BaseItem.GetColumn(DataRow, columnName, deafultValue).ToString();
        }

        public static string GetCol(object row, string columnName)
        {
            return BaseItem.GetColumn(row, columnName, "").ToString();
        }

        public static string GetCol(DataRowView row, string columnName)
        {
            return BaseItem.GetColumn(row, columnName, "").ToString();
        }

        public static string GetCol(DataRow row, string columnName)
        {
            return BaseItem.GetColumn(row, columnName, "").ToString();
        }

        public static string GetCol(DataRowView row, string columnName, string deafultValue)
        {
            return BaseItem.GetColumn(row, columnName, deafultValue).ToString();
        }

        public static string GetCol(DataRow row, string columnName, string deafultValue)
        {
            return BaseItem.GetColumn(row, columnName, deafultValue).ToString();
        }

        #endregion

        #region GetColumn
        public object GetColumn(string columnName)
        {
            return GetColumn(columnName, "");
        }

        public object GetColumn(string columnName, object deafultValue)
        {
            return BaseItem.GetColumn(DataRow, columnName, deafultValue);
        }

        public static object GetColumn(object row, string columnName, object deafultValue)
        {
            if (row is DataRow)
            {
                return BaseItem.GetColumn((DataRow)row, columnName, deafultValue);
            }
            if (row is DataRowView)
            {
                return BaseItem.GetColumn((DataRowView)row, columnName, deafultValue);
            }
            else
            {
                return deafultValue;
            }
        }

        public static object GetColumn(DataRowView row, string columnName, object deafultValue)
        {
            return BaseItem.GetColumn(row.Row, columnName, deafultValue);
        }

        public static object GetColumn(DataRow row, string columnName, object deafultValue)
        {
            try
            {
                if (!CanGetColumn(row, columnName))
                {
                    return deafultValue;
                }

                object val = row[columnName].ToString();

                if (row.Table.Columns[columnName].DataType != Type.GetType("System.String"))
                {
                    if (val == null || String.IsNullOrEmpty(val.ToString()))
                    {
                        return deafultValue;
                    }
                }

                return val;
            }
            catch
            {
                return deafultValue;
            }
        }

        public static bool CanGetColumn(DataRow row, string columnName)
        {
            try
            {
                if (row == null || row.RowState == DataRowState.Deleted || String.IsNullOrEmpty(columnName) ||
                    !row.Table.Columns.Contains(columnName))
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static bool CanGetRow(DataRow row)
        {
            return !(row == null || row.RowState == DataRowState.Deleted);
        }
        #endregion
        #endregion

        #region SetColumn
        public bool SetColumn(string columnName, object val)
        {
            if (!CanGetColumn(DataRow, columnName))
            {
                return false;
            }

            DataRow[columnName] = val;

            return true;
        }

        public bool SetColumn(int columnIndex, object val)
        {
            if (!CanGetColumn(DataRow, DataRow.Table.Columns[columnIndex].ColumnName))
            {
                return false;
            }

            DataRow[columnIndex] = val;

            return true;
        }

        public bool SetColumn(int columnIndex, object val, Type type)
        {
            if (!CanGetColumn(DataRow, DataRow.Table.Columns[columnIndex].ColumnName))
            {
                return false;
            }

            DataRow[columnIndex] = ToType(type, val, System.DBNull.Value);

            return true;
        }

        public bool SetColumnNull(string columnName)
        {
            return SetColumn(columnName, System.DBNull.Value);
        }
        #endregion

        #endregion

        #region ToString
        public override string ToString()
        {
            return ID + "|" + Name;
        }
        #endregion

        #region To
        #region ToLong

        public static long ToLong(object o)
        {
            return BaseItem.ToLong(o, 0);
        }

        public static long ToLong(GridViewRowEventArgs e, string columnName)
        {
            return BaseItem.ToLong(((System.Data.DataRowView)(e.Row.DataItem)).Row[columnName]);
        }

        public static long ToLong(DataListItemEventArgs e, string columnName)
        {
            return BaseItem.ToLong(((System.Data.DataRowView)(e.Item.DataItem)).Row[columnName]);
        }

        public static long ToLong(object o, long defaultValue)
        {
            try
            {
                if (o != null)
                {
                    return Convert.ToInt64(o.ToString());
                }
            }
            catch
            {
            }

            return defaultValue;
        }
        #endregion

        #region ToDouble

        public static double ToDouble(object o)
        {
            return BaseItem.ToDouble(o, 0);
        }

        public static double ToDouble(GridViewRowEventArgs e, string columnName)
        {
            return BaseItem.ToDouble(((System.Data.DataRowView)(e.Row.DataItem)).Row[columnName]);
        }

        public static double ToDouble(DataListItemEventArgs e, string columnName)
        {
            return BaseItem.ToDouble(((System.Data.DataRowView)(e.Item.DataItem)).Row[columnName]);
        }

        public static double ToDouble(object o, double defaultValue)
        {
            try
            {
                if (o != null)
                {
                    return Convert.ToDouble(o.ToString());
                }
            }
            catch
            {
            }

            return defaultValue;
        }
        #endregion

        #region ToInt32

        public static int ToInt32(object o)
        {
            return BaseItem.ToInt32(o, 0);
        }

        public static int ToInt32(GridViewRowEventArgs e, string columnName)
        {
            return BaseItem.ToInt32(((System.Data.DataRowView)(e.Row.DataItem)).Row[columnName]);
        }

        public static int ToInt32(DataListItemEventArgs e, string columnName)
        {
            return BaseItem.ToInt32(((System.Data.DataRowView)(e.Item.DataItem)).Row[columnName]);
        }

        public static int ToInt32(object o, int defaultValue)
        {
            try
            {
                if (o != null)
                {
                    return Convert.ToInt32(o.ToString());
                }
            }
            catch
            {
            }

            return defaultValue;
        }
        #endregion

        #region ToBool

        public static bool ToBool(object o)
        {
            return BaseItem.ToBool(o, false);
        }

        public static bool ToBool(object o, bool defaultValue)
        {
            try
            {
                if (o != null)
                {
                    return Convert.ToBoolean(o.ToString());
                }
            }
            catch
            {
            }

            return defaultValue;
        }
        #endregion

        #region ToString

        public static string ToString(object o)
        {
            return BaseItem.ToString(o, "");
        }

        public static string ToString(GridViewRowEventArgs e, string columnName)
        {
            return BaseItem.ToString(((System.Data.DataRowView)(e.Row.DataItem)).Row[columnName]);
        }

        public static string ToString(DataListItemEventArgs e, string columnName)
        {
            return BaseItem.ToString(((System.Data.DataRowView)(e.Item.DataItem)).Row[columnName]);
        }

        public static string ToString(object o, string defaultValue)
        {
            try
            {
                if (o != null)
                {
                    return o.ToString();
                }
            }
            catch
            {
            }

            return defaultValue;
        }
        #endregion

        #region ToDecimal

        public static Decimal ToDecimal(object o)
        {
            return BaseItem.ToDecimal(o, 0);
        }

        public static Decimal ToDecimal(object o, Decimal defaultValue)
        {
            try
            {
                if (o != null)
                {
                    return Convert.ToDecimal(o.ToString());
                }
            }
            catch
            {
            }

            return defaultValue;
        }
        #endregion

        #region ToType
        public static object ToType(Type type, object o)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Boolean:
                    return ToBool(o);

                case TypeCode.Double:
                case TypeCode.Decimal:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return ToDouble(o);

                case TypeCode.Byte:
                case TypeCode.Char:
                case TypeCode.DBNull:
                case TypeCode.DateTime:
                case TypeCode.Empty:
                case TypeCode.Object:
                case TypeCode.SByte:
                case TypeCode.String:
                default:
                    return ToString(o);
            }
        }

        public static object ToType(Type type, object o, object defaultValue)
        {
            try
            {
                switch (Type.GetTypeCode(type))
                {
                    case TypeCode.Boolean:
                        return Convert.ToBoolean(o);

                    case TypeCode.Double:
                    case TypeCode.Decimal:
                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                    case TypeCode.Single:
                    case TypeCode.UInt16:
                    case TypeCode.UInt32:
                    case TypeCode.UInt64:
                        return Convert.ToDouble(o);

                    case TypeCode.Byte:
                    case TypeCode.Char:
                    case TypeCode.DBNull:
                    case TypeCode.DateTime:
                    case TypeCode.Empty:
                    case TypeCode.Object:
                    case TypeCode.SByte:
                    case TypeCode.String:
                    default:
                        return Convert.ToString(o);
                }
            }
            catch
            {
            }

            return defaultValue;
        }
        #endregion

        #endregion

        #region Filter
        public static string FilterOr(string filter, string append)
        {
            return ApppendFilter(filter, append, "OR");
        }

        public static string FilterAnd(string filter, string append)
        {
            return ApppendFilter(filter, append, "AND");
        }

        public static string ApppendFilter(string filter, string append, string logicalOperator)
        {
            if (append != "")
            {
                filter += append + " " + logicalOperator + " ";
            }

            return filter;
        }

        public static string TrimOr(string filter)
        {
            filter = UStr.TrimEnd(filter, " OR ");

            return filter;
        }

        public static string TrimAnd(string filter)
        {
            filter = UStr.TrimEnd(filter, " AND ");

            return filter;
        }
        #endregion

        public DataRow Replace(DataRow row)
        {
            foreach (DataColumn col in row.Table.Columns)
            {
                this.DataRow[col.ColumnName] = row[col.ColumnName];
            }

            return this.DataRow;
        }
    }
}
