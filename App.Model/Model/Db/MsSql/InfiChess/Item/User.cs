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
using System.Security.Principal;
using System.Web.Security;
using System.Data.SqlClient;
using System.Diagnostics;
namespace App.Model.Db
{
    public enum SignInMsgE
    { 
        UserIpBlocked = -6,
        UserNotFound = -7,
        UserHasNoRole = -8
    }

    public class User : BaseItem
    {
        #region Data Members
        
        #endregion

        #region Constructor
        public User()
            : base(0)
        {
        }

        public User(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public User(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public User(Cxt cxt, DataRow row)
        {
            Cxt = cxt;

            DataRow = row;
        }

        public User(Cxt cxt, string userName)
        {
            Cxt = cxt;

            Load(userName);
        }
        #endregion

        #region Properties

        #region Core
        public override InfiChess TableName
        {
            [DebuggerStepThrough]
            get { return InfiChess.User; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion

        #region Table Columns

        #region Enum
        public StatusE StatusIDE { [DebuggerStepThrough] get { return (StatusE)this.StatusID; } [DebuggerStepThrough]set { this.StatusID = (int)value; } }
        public UserStatusE UserStatusIDE { [DebuggerStepThrough] get { return (UserStatusE)this.UserStatusID; } [DebuggerStepThrough] set { this.UserStatusID = (int)value; } }
        public RankE HumanRankIDE { [DebuggerStepThrough] get { return (RankE)this.HumanRankID; } [DebuggerStepThrough] set { this.HumanRankID = (int)value; } }
        public RankE EngineRankIDE { [DebuggerStepThrough] get { return (RankE)this.EngineRankID; } [DebuggerStepThrough] set { this.EngineRankID = (int)value; } }
        public RankE CentaurRankIDE { [DebuggerStepThrough] get { return (RankE)this.CentaurRankID; } [DebuggerStepThrough] set { this.CentaurRankID = (int)value; } }
        public RankE CorrespondenceRankIDE { [DebuggerStepThrough] get { return (RankE)this.CorrespondenceRankID; } [DebuggerStepThrough] set { this.CorrespondenceRankID = (int)value; } }

        #endregion

        #region Properties
        public int UserID { [DebuggerStepThrough] get { return GetColInt32("UserID"); } [DebuggerStepThrough] set { SetColumn("UserID", value); } }
        public int RoomID { [DebuggerStepThrough]get { return GetColInt32("RoomID"); } [DebuggerStepThrough]set { SetColumn("RoomID", value); } }
        public int UserStatusID { [DebuggerStepThrough] get { return GetColInt32("UserStatusID"); } [DebuggerStepThrough] set { SetColumn("UserStatusID", value); } }
        public int HumanRankID { [DebuggerStepThrough]get { return GetColInt32("HumanRankID"); } [DebuggerStepThrough] set { SetColumn("HumanRankID", value); } }
        public int EngineRankID { [DebuggerStepThrough] get { return GetColInt32("EngineRankID"); } [DebuggerStepThrough] set { SetColumn("EngineRankID", value); } }
        public int CentaurRankID { [DebuggerStepThrough] get { return GetColInt32("CentaurRankID"); } [DebuggerStepThrough] set { SetColumn("CentaurRankID", value); } }
        public int CorrespondenceRankID { [DebuggerStepThrough] get { return GetColInt32("CorrespondenceRankID"); } [DebuggerStepThrough]set { SetColumn("CorrespondenceRankID", value); } }
        public int CountryID { [DebuggerStepThrough]get { return GetColInt32("CountryID"); } [DebuggerStepThrough]set { SetColumn("CountryID", value); } }
        public int NearestCityID { [DebuggerStepThrough] get { return GetColInt32("NearestCityID"); } [DebuggerStepThrough] set { SetColumn("NearestCityID", value); } }
        public int GenderID { [DebuggerStepThrough]get { return GetColInt32("GenderID"); } [DebuggerStepThrough] set { SetColumn("GenderID", value); } }
        public int FideTitleID { [DebuggerStepThrough]get { return GetColInt32("FideTitleID"); } [DebuggerStepThrough]set { SetColumn("FideTitleID", value); } }
        public int IccfTitleID { [DebuggerStepThrough] get { return GetColInt32("IccfTitleID"); } [DebuggerStepThrough]set { SetColumn("IccfTitleID", value); } }
        public int SocialID { [DebuggerStepThrough] get { return GetColInt32("SocialID"); } [DebuggerStepThrough]set { SetColumn("SocialID", value); } }
        public int StatusID { [DebuggerStepThrough] get { return GetColInt32("StatusID"); } [DebuggerStepThrough] set { SetColumn("StatusID", value); } }
        public string UserName { [DebuggerStepThrough] get { return GetCol("UserName"); } [DebuggerStepThrough] set { SetColumn("UserName", value); } }
        public string Password { [DebuggerStepThrough] get { return GetCol("Password"); } [DebuggerStepThrough]set { SetColumn("Password", value); } }
        public string Email { [DebuggerStepThrough]get { return GetCol("Email"); } [DebuggerStepThrough]set { SetColumn("Email", value); } }
        public string FirstName { [DebuggerStepThrough] get { return GetCol("FirstName"); } [DebuggerStepThrough]set { SetColumn("FirstName", value); } }
        public string LastName { [DebuggerStepThrough]get { return GetCol("LastName"); } [DebuggerStepThrough] set { SetColumn("LastName", value); } }
        public string BanReason { [DebuggerStepThrough]get { return GetCol("BanReason"); } [DebuggerStepThrough] set { SetColumn("BanReason", value); } }
        public string BanMachineKey { [DebuggerStepThrough]get { return GetCol("BanMachineKey"); } [DebuggerStepThrough] set { SetColumn("BanMachineKey", value); } }
        
        public int EngineID { [DebuggerStepThrough]get { return GetColInt32("EngineID"); } [DebuggerStepThrough]set { SetColumn("EngineID", value); } }
        public string PersonalNotes { [DebuggerStepThrough] get { return GetCol("PersonalNotes"); } [DebuggerStepThrough] set { SetColumn("PersonalNotes", value); } }
        public string PasswordHint { [DebuggerStepThrough] get { return GetCol("PasswordHint"); } [DebuggerStepThrough]set { SetColumn("PasswordHint", value); } }
        public string Url { [DebuggerStepThrough] get { return GetCol("Url"); } [DebuggerStepThrough] set { SetColumn("Url", value); } }
        public DateTime DateLastLogin { [DebuggerStepThrough] get { return GetColDateTime("DateLastLogin"); } [DebuggerStepThrough] set { SetColumn("DateLastLogin", value); } }
        public DateTime DateOfBirth { [DebuggerStepThrough]get { return GetColDateTime("DateOfBirth"); } [DebuggerStepThrough]set { SetColumn("DateOfBirth", value); } }
        public double Internet { [DebuggerStepThrough] get { return GetColDouble("Internet"); } [DebuggerStepThrough] set { SetColumn("Internet", value); } }
        public DateTime BanStartDate { [DebuggerStepThrough] get { return GetColDateTime("BanStartDate"); } [DebuggerStepThrough] set { SetColumn("BanStartDate", value); } }
        public DateTime BanStartTime { [DebuggerStepThrough] get { return GetColDateTime("BanStartTime"); } [DebuggerStepThrough] set { SetColumn("BanStartTime", value); } }
        public DateTime BanEndDate { [DebuggerStepThrough] get { return GetColDateTime("BanEndDate"); } [DebuggerStepThrough]set { SetColumn("BanEndDate", value); } }
        public DateTime BanEndTime { [DebuggerStepThrough]get { return GetColDateTime("BanEndTime"); } [DebuggerStepThrough]set { SetColumn("BanEndTime", value); } }
        public bool IsIdle { [DebuggerStepThrough] get { return GetColBool("IsIdle"); } [DebuggerStepThrough]set { SetColumn("IsIdle", value); } }
        public bool IsPause { [DebuggerStepThrough] get { return GetColBool("IsPause"); } [DebuggerStepThrough]set { SetColumn("IsPause", value); } }
        public int Fini { [DebuggerStepThrough] get { return GetColInt32("Fini"); } [DebuggerStepThrough]set { SetColumn("Fini", value); } }
        #endregion

        #endregion

        #region Calculated
        public string PasswordEncrypted
        {
            [DebuggerStepThrough]
            get { return GetCol("Password"); }
            [DebuggerStepThrough]
            set { SetColumn("Password", value); }
        }

        string[] roles = null;

        public string[] Roles
        {
            [DebuggerStepThrough]
            get
            {
                if (roles == null)
                {
                    roles = GetRoles(ID);
                }

                return roles;
            }
            [DebuggerStepThrough]
            set { roles = value; }
        }

        public bool IsGuest
        {
            [DebuggerStepThrough]
            get
            {
                return this.HumanRankIDE == RankE.Guest;
            }
        }

        public bool IsAdmin
        {
            [DebuggerStepThrough]
            get
            {
                return User.IsInRole(RoleE.Admin);
            }
        }

        public bool IsTournamentDirector
        {
            [DebuggerStepThrough]
            get
            {
                return (int)HumanRankIDE >= Ap.SysOptions[KeyValueE.MinTournamentRank].ValueInt32 || User.IsInRole(RoleE.Admin);
            }
        }

        public string FullName
        {
            [DebuggerStepThrough]
            get
            {
                return FirstName + ", " + LastName;
            }
        }

        public TimeSpan LoginDays
        {
            [DebuggerStepThrough]
            get
            {
                return DateTime.Now.Subtract(this.DateCreated);
            }
        }

        public bool IsBannedForever
        {
            [DebuggerStepThrough]
            get
            {
                return this.BanEndDate == UDate.DefaultDate;
            }
        }

        #endregion

        #region Contained Classes
        private Rank humanRank = null;
        public Rank HumanRank
        {
            [DebuggerStepThrough]
            get
            {
                if (humanRank == null)
                {
                    humanRank = new Rank(this.Cxt, this.HumanRankID);
                }

                return humanRank;
            }
            [DebuggerStepThrough]
            set { humanRank = value; }
        }

        private Engine engine = null;
        public Engine Engine
        {
            [DebuggerStepThrough]
            get
            {
                if (engine == null)
                {
                    engine = new Engine(this.Cxt, this.EngineID);
                }

                return engine;
            }
            [DebuggerStepThrough]
            set { engine = value; }
        }

        #endregion

        #endregion

        #region Method

        #region Login
        public static IPrincipal GetPrincipal(FormsAuthenticationTicket ticket)
        {
            return GetPrincipal(ticket.Name);
        }

        public static IPrincipal GetPrincipal(string userName)
        {
            return GetPrincipal(userName, User.GetRoles(userName));
        }

        public static IPrincipal GetPrincipal(string userName, DataTable roles)
        {
            return GetPrincipal(userName, (string[])UData.ToArray(roles, "RoleID"));
        }

        public static IPrincipal GetPrincipal(string userName, string[] roles)
        {
            GenericIdentity identity = new GenericIdentity(userName);

            GenericPrincipal principal = new GenericPrincipal(identity, roles);

            return principal;
        }

        private static DataSet Login(Cxt cxt, string userName, string password, string code, string Ip, string machineCode, DateTime serverDate)
        {
            DataSet ds = BaseCollection.ExecuteDataset("LoginUser", userName, password, code, Ip, machineCode, serverDate);

            return ds;
        }

        private static void SaveLoginUser(User user)
        {
            user.DateLastLogin = DateTime.Now;
            user.UserStatusIDE = UserStatusE.Blank;
            user.Save();
        }

        private static bool CheckBanDate(User user)
        {
            bool isValid = false;

            DateTime banStartDate = Convert.ToDateTime(user.BanStartDate.ToShortDateString() + " " + user.BanStartTime.ToShortTimeString());
            DateTime banEndDate = Convert.ToDateTime(user.BanEndDate.ToShortDateString() + " " + user.BanEndTime.ToShortTimeString());
            if (user.BanEndDate == new DateTime()) // Ban forever user
            {
                isValid = true;
            }
            else if (banEndDate <= DateTime.Now)
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }
            return isValid;
        }

        private static int LoginByUserID(Cxt cxt, int userID)
        {
            User user = GetUserByID(cxt, userID);

            if (user.IsNew)
            {
                return 0;
            }
            else
            {
                System.Web.HttpContext.Current.User = User.GetPrincipal(user.UserName);
                FormsAuthentication.SetAuthCookie(user.UserName, true);
                return userID;
            }
        }

        public static User GetUserByEmail(Cxt cxt, string email)
        {
            DataTable table = BaseCollection.ExecuteSql(InfiChess.User, "select * from [User] where email=@p1", email);

            User user = null;

            if (table.Rows.Count > 0)
            {
                user = new User(cxt, table.Rows[0]);
            }
            else
            {
                user = new User();
            }

            return user;
        }

        private static Kv GetGuest(Cxt cxt, string applicationCode)
        {
            User item = new User();
            item.UserName = "Guest" + applicationCode;
            item.Password = "Guest";
            item.FirstName = "Guest";
            item.HumanRankIDE = RankE.Guest;
            item.EngineID = 1;
            item.UserStatusIDE = UserStatusE.Blank;
            item.RoomID = 3;
            item.DateLastLogin = DateTime.Now;
            item.StatusIDE = StatusE.Active;
            item.Save();

            item.UserName = "Guest" + item.ID;
            item.Save();

            DataTable roles = User.GetRolesTable(item.UserID);

            Kv kv1 = new Kv();
            kv1.Set("Msg", -1);
            kv1.Set("UserData", UData.ToString(item.DataRow.Table));
            kv1.Set("RolesData", UData.ToString(roles.Copy()));

            return kv1;

        }

        public static int Login(Cxt cxt, string userName, string password)
        {
            DataSet ds = Login(cxt, userName, password, "", "", "", DateTime.Now);

            if (ds.Tables.Count > 1)
            {
                return UData.ToInt32(ds.Tables[1].Rows[0]["UserId"]);
            }
            else
            {
                return 0;
            }
        }

        public static int LoginByID(Cxt cxt, int userID)
        {
            return LoginByUserID(cxt, userID);
        }

        public static DataTable LoginKv(Kv kv)
        {
            DataSet ds = Login(kv.Cxt, kv.Get("LoginID"), kv.Get("Password"), kv.Get("AccessCode"), kv.Get("Ip"), kv.Get("MachineCode"), Convert.ToDateTime(kv.Get("ServerDate")));
            int msgId = UData.ToInt32(ds.Tables[0].Rows[0]["MsgId"]);

            kv = new Kv();
            kv.Set("Msg", UData.ToString(ds.Tables[0]));

            if (ds.Tables.Count > 1)
            {
                kv.Set("UserData", UData.ToString(ds.Tables[1]));
                kv.Set("RolesData", UData.ToString(ds.Tables[2]));
            }

            return kv.DataTable;
        }

        public static DataTable LoginGuest(Kv kv)
        {
            DataSet ds = Login(kv.Cxt, kv.Get("LoginID"), kv.Get("Password"), kv.Get("AccessCode"), kv.Get("Ip"), 
                            kv.Get("MachineCode"), DateTime.Now);
            int msgId = UData.ToInt32(ds.Tables[0].Rows[0]["MsgId"]);

            Kv kvOut = new Kv();
            kvOut.Cxt = kv.Cxt;
            kvOut.Set("MsgId", msgId);
            kvOut.Set("ServerDateTime", DateTime.Now.ToString());

            if ((SignInMsgE)msgId == SignInMsgE.UserNotFound)
            {
                kvOut = GetGuest(kvOut.Cxt, kv.Get("AccessCode"));
            }
            else
            {
                if (ds.Tables.Count > 1)
                {
                    kvOut.Set("UserData", UData.ToString(ds.Tables[1]));
                    kvOut.Set("RolesData", UData.ToString(ds.Tables[2]));
                }
            }

            System.Diagnostics.Debug.WriteLine("**************** S T A R T **************");

            string s = UData.ToString(ds);

            if (String.IsNullOrEmpty(s))
            {
                System.Diagnostics.Debug.WriteLine("<EMPTY DATASET>");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("ROWS=" + kvOut.DataTable.Rows.Count);
            }

            return kvOut.DataTable;
        }

        /// <summary>
        /// Below function is use in web site login
        /// </summary>
        /// <param name="kv"></param>
        /// <returns></returns>
        public static bool LoginUser(Kv kv)
        {
            DataTable dt = null;
            bool isLogin = false;

            Kv kv1 = new Kv(User.LoginKv(kv));

            dt = kv1.GetDataTable("Msg");

            if (dt.Rows.Count > 0)
            {
                int statusID = Convert.ToInt32(dt.Rows[0]["MsgId"]) * -1;

                if (statusID == (int)(MsgE.Active))
                {
                    return true;
                }
            }
            return isLogin;
        }

        private bool CheckBanDate(DataTable dt)
        {
            bool isBan = false;

            if (dt.Rows.Count > 0)
            {
                User user = new User(base.Cxt, dt.Rows[0]);
                if (user.UserID == 1)
                {
                    return false;

                }
                if (user.BanEndDate == new DateTime())
                {
                    isBan = true;
                }
                else
                {
                    string date = user.BanEndDate.Date.ToShortDateString() + " " + user.BanEndTime.ToShortTimeString();

                    DateTime dt1 = DateTime.Parse(date);

                    if (DateTime.Now <= dt1)
                    {
                        isBan = true;
                    }
                    else
                    {
                        if (user.StatusIDE == StatusE.Ban)
                        {
                            User user1 = User.GetUser(base.Cxt, user.UserName, user.Password);
                            user1.StatusIDE = StatusE.Active;
                            user1.Save();
                        }
                    }
                }
            }

            return isBan;
        }


        public static int LoginMsg(Kv kv, bool isGuest)
        {
            DataTable dt = null;
            int msgID = 0;
            if (isGuest)
            {
                msgID = kv.GetInt32("Msg");
            }
            else
            {
                Kv kv1 = new Kv(kv.GetDataTable("Msg"));
                dt = kv1.DataTable;
                msgID = Convert.ToInt32(dt.Rows[0][0]);
            }

            if (msgID < 0)
            {
                msgID = msgID * -1;
                MsgE msge = (MsgE)msgID;

                switch (msge)
                {
                    case MsgE.Active:
                        return (int)MsgE.Active;
                    case MsgE.Disabled:
                    case MsgE.Inactive:
                    case MsgE.Deleted:
                    case MsgE.BlockIp:
                        return (int)MsgE.BlockIp;
                    case MsgE.InfoBlockMachine:
                    case MsgE.WrongIdPassowrd:
                        return (int)MsgE.WrongIdPassowrd;
                    case MsgE.NoRoles:
                        return (int)MsgE.NoRoles;
                    case MsgE.Ban:
                        //MessageForm.Error(this, MsgE.ErrorBannedForever, Ap.CurrentUser.UserName);
                        return (int)MsgE.Ban;

                }
            }
            else if (msgID == 0)
            {
                //MessageForm.Error(this, MsgE.InfoBaned, kv.GetDateTime("BanEndDateTime"), kv.GetDateTime("BanEndDateTime1"));
                return 0;
            }
            return msgID;
        }



        #region Change Password
        //public static bool ChangePassword(Cxt cxt, int userID, string password)
        //{

        //    User item = new User(Cxt.Instance, userID);
        //    item.Password = password;
        //    //item.PasswordHint = passwordHint;
        //    item.Save();

        //    MailVerifyResult mvr = EmailTemplate.Send(EmailTemplateE.ChangePassword, item);
        //    if (mvr == MailVerifyResult.Ok)
        //    {
        //        return true;
        //        //Msg.Text = "Your password has been changed successfully.";
        //    }
        //    return false;
        //}

        public static DataTable ChangePassword(Cxt cxt, Kv kv)
        {
            return User.ChangePassword(cxt, kv.GetInt32("UserID"), kv.Get("Password"), kv.Get("PasswordHint")).Copy();
        }

        public static DataTable ChangePassword(Cxt cxt, int userID, string password, string passwordHint)
        {
            User item = new User(cxt, userID);
            item.Password = password;
            item.PasswordHint = passwordHint;
            item.Save();

            MailVerifyResult mvr = EmailTemplate.Send(cxt, EmailTemplateE.ChangePassword, item);
            Kv Kv = new Kv();
            if (mvr == MailVerifyResult.Ok)
            {
                Kv.Set("Updated", true);
            }
            else
            {
                Kv.Set("Updated", false);
            }
            return Kv.DataTable;
        }
        #endregion

        #region Forgot Password

        public static bool ForgotPassword(Cxt cxt, User user)
        {
            //User user = User.GetUser(cxt, userName);
            MailVerifyResult mvr = EmailTemplate.Send(cxt, EmailTemplateE.ForgotPassword, user);
            if (mvr == MailVerifyResult.Ok)
            {
                return true;
                //Msg.Text = "Your password has been changed successfully.";
            }
            return false;
        }

        public static DataTable ForgotPassword(Cxt cxt, string userName)
        {
            Kv Kv = new Kv();
            User user = User.GetUser(cxt, userName);
            if (user.IsNew)
            {
                Kv.Set("Updated", false);
            }
            else
            {
                Kv.Set("Updated", ForgotPassword(cxt, user));
            }


            return Kv.DataTable;

        }

        #endregion

        public static bool UpdatedUserRoom(Cxt cxt, SqlTransaction t, int roomID, int userStatus, int engineID, int userID)
        {
            User item = new User(cxt, userID);
            item.UserStatusID = userStatus;

            if (engineID >= 0)
            {
                if (engineID == 0)
                {
                    engineID = 1;
                }
                item.EngineID = engineID;
            }

            item.RoomID = roomID;
            item.Save(t);

            return true;
        }

        public static DataTable LogoffUser(Cxt cxt, int userID)
        {
            Kv Kv = new Kv();
            SqlTransaction t = null;
            try
            {
                t = SqlHelper.BeginTransaction(Config.ConnectionString);
                Challenges.UpdateChallengesStatus(t, userID);
                User item = new User(cxt, userID);
                item.UserStatusIDE = UserStatusE.Gone;
                //item.StatusIDE = item.IsGuest ? StatusE.Inactive : item.StatusIDE;
                item.EngineID = 1;
                item.IsIdle = false;
                item.IsPause = false;
                item.Save(t); //Transaction also commited in this method
                Kv.Set("LogedOff", true);
            }
            catch (Exception ex)
            {
                SqlHelper.RollbackTransaction(t);
                throw ex;
            }

            return Kv.DataTable;
        }

        public static void ChangeUserStatus(Cxt cxt, int userID, UserStatusE status)
        {
            User item = new User(cxt, userID);

            item.UserStatusIDE = status;

            item.Save();
        }

        #endregion

        #region GetUser

        public void Load(string userName)
        {
            DataTable table = BaseCollection.ExecuteSql(InfiChess.User, "select * from [User] where LOWER(UserName)=LOWER(@p1)", userName);

            SetRow(table);
        }

        public static User GetUser(Cxt cxt, string userName, string password)
        {
            DataTable table = BaseCollection.ExecuteSql(InfiChess.User, "select * from [User] where LOWER(UserName)=LOWER(@p1) AND Password=@p2", userName, password);

            User user = null;

            if (table.Rows.Count > 0)
            {
                user = new User(cxt, table.Rows[0]);
            }
            else
            {
                user = new User();
            }

            return user;
        }

        public static User GetUser(Cxt cxt, string userName)
        {
            DataTable table = BaseCollection.ExecuteSql(InfiChess.User, "select * from [User] where LOWER(UserName)=LOWER(@p1)", userName);

            User user = null;

            if (table.Rows.Count > 0)
            {
                user = new User(cxt, table.Rows[0]);
            }
            else
            {
                user = new User();
            }

            return user;
        }

        public static User GetUserByID(Cxt cxt, int userID)
        {
            DataTable table = BaseCollection.ExecuteSql(InfiChess.User, "select * from [User] where UserID=@p1", userID.ToString());

            User user = null;

            if (table.Rows.Count > 0)
            {
                user = new User(cxt, table.Rows[0]);
            }
            else
            {
                user = new User();
            }

            return user;
        }

        public static string[] GetRoles(string userName)
        {
            DataTable table = BaseCollection.ExecuteSql(InfiChess.Role, "SELECT Role.RoleID FROM UserRole INNER JOIN Role ON UserRole.RoleID = Role.RoleID INNER JOIN[User] ON UserRole.UserID = [User].UserID WHERE (LOWER([User].UserName) = LOWER(@p1))", userName);

            return (string[])UData.ToArray(table, "RoleID");
        }

        public static string[] GetRoles(int userID)
        {
            return (string[])UData.ToArray(GetRolesTable(userID), "RoleID");
        }

        public static DataTable GetRolesTable(int userID)
        {
            DataTable table = BaseCollection.ExecuteSql(InfiChess.Role, "SELECT RoleID FROM UserRole WHERE UserID = @p1", userID);

            return table;
        }

        public static bool Exists(Cxt cxt, string userName)
        {
            User user = User.GetUser(cxt, userName);
            return !user.IsNew;
        }

        public static User GetFirstInActiveGuest(Cxt cxt)
        {
            DataTable table = BaseCollection.ExecuteSql(InfiChess.User, "SELECT TOP 1 * FROM [User] WHERE HumanRankID = 7 AND StatusID = 3", "");

            User user = null;

            if (table.Rows.Count > 0)
            {
                user = new User(cxt, table.Rows[0]);
            }
            else
            {
                user = new User();
            }

            return user;
        }

        public static DataTable GetUserInfoByUserID(Cxt cxt, int userID)
        {
            return BaseCollection.Execute("GetUserInfoByUserID", userID, "");
        }
        public static DataTable GetRankInfo(Cxt cxt, int userID)
        {
            return BaseCollection.Execute("GetRankInfo", userID);
        }

        public static DataTable GetUserByName(Cxt cxt, string userName)
        {
            return BaseCollection.Execute("GetUserInfoByUserID", 0, userName);
        }

        #endregion

        #region IsAuthorize
        public bool IsAuthorize(TaskE task)
        {
            //if (User.IsInRole(RoleE.SiteAdmin))
            //{
            //    return true;
            //}

            //bool allowed = Task.HasTask(0, task);

            //if (User.IsInRole(RoleE.SiteUser))
            //{
            //    switch (task)
            //    {
            //        case TaskE.NewItem:
            //        case TaskE.EditItem:
            //        case TaskE.DeleteItem:
            //            allowed = false;
            //            break;
            //    }
            //}

            //if (User.IsInRole(RoleE.ServiceAdmin))
            //{
            //    switch (task)
            //    {
            //        case TaskE.NewItem:
            //        case TaskE.EditItem:
            //        case TaskE.DeleteItem:
            //            allowed = allowed && IsServiceAdmin;
            //            break;
            //    }
            //}

            //return allowed;

            return false;
        }
        #endregion

        #region IsInRole

        public bool HasInAllRole(params RoleE[] roles)
        {
            return User.IsInRole(true, roles);
        }

        public bool HasInAnyRole(params RoleE[] roles)
        {
            return User.IsInRole(false, roles);
        }

        public static bool IsInAllRole(params RoleE[] roles)
        {
            return User.IsInRole(true, roles);
        }

        public static bool IsInAnyRole(params RoleE[] roles)
        {
            return User.IsInRole(false, roles);
        }

        public static bool IsInRole(bool checkAll, params RoleE[] roles)
        {
            foreach (RoleE role in roles)
            {
                if (checkAll)
                {
                    if (!User.IsInRole(role))
                    {
                        return false; // is not in one role
                    }
                }
                else
                {
                    if (User.IsInRole(role))
                    {
                        return true; // is in any role
                    }
                }
            }

            if (checkAll)
            {
                return true; // found in all mentioned roles
            }
            else
            {
                return false; // not found in any role
            }
        }

        public static bool IsInRole(RoleE role)
        {
            return UWeb.Principal.IsInRole(((int)role).ToString());
        }

        #endregion

        #region Save

        protected override void Save(string connectionString, SqlTransaction t)
        {
            bool isNew = false;

            if (IsNew)
            {
                if (Exists(Cxt, UserName))
                {
                    AppException.Throw("Msg.UserNameExists(UserName)");
                }

                this.StatusIDE = StatusE.Active;

                isNew = true;
            }

            try
            {
                //CalculateRanks();

                if (t == null)
                {
                    t = SqlHelper.BeginTransaction(connectionString);
                }

                base.Save(connectionString, t);

                if (isNew)
                {
                    #region Save User Role
                    UserRole ur = new UserRole();

                    ur.Cxt = Cxt;

                    ur.UserID = ID;
                    ur.RoleIDE = this.IsGuest ? RoleE.Guest : RoleE.Player;

                    ur.Save(t);
                    #endregion

                    if (!this.IsGuest)
                    {
                        #region Email send
                        MailVerifyResult mvr = EmailTemplate.Send(base.Cxt, EmailTemplateE.NewAccount, this);
                        if (mvr != MailVerifyResult.Ok)
                        {

                        }
                        #endregion
                    }
                    //UMail.Send(this, MailTemplateE.ActivateAccount);
                }

                SqlHelper.CommitTransaction(t);
            }
            catch (Exception ex)
            {
                SqlHelper.RollbackTransaction(t);

                throw ex;
            }
        }

        #endregion

        #region Activate User

        public static void HandleRequestType(Cxt cxt, AccountRequestTypeE RequestType, string userName)
        {
            switch (RequestType)
            {
                case AccountRequestTypeE.ActivateEmail:
                    SendActivationEmail(cxt, userName);
                    break;
                case AccountRequestTypeE.ActivateAccount:
                    ActivateUser(cxt, userName);
                    break;
                default:
                    break;
            }
        }

        public static void SendActivationEmail(Cxt cxt, string userName)
        {
            User user = User.GetUser(cxt, userName);

            if (user.IsNew)
            {
                AppException.Throw("Msg.UserNameNotExists(userName)");
            }

            MailVerifyResult result = EmailTemplate.Send(cxt, EmailTemplateE.NewAccount, user);

            if (result == MailVerifyResult.Ok)
            {
                AppException.Throw("Msg.ActivationEmailOk(userName)");
            }
        }

        public static void ActivateUser(Cxt Cxt, string userName)
        {
            User user = User.GetUser(Cxt, userName);

            if (user.IsNew)
            {
                AppException.Throw("Msg.UserNameNotExists(userName)");
            }

            switch (user.StatusIDE)
            {
                case StatusE.Active:
                    AppException.Throw("Account is already active. <a href='http://RafeySoft.com/Web/Page/Account/SignIn.aspx'>Sign In</a> now!");
                    break;
                case StatusE.Disabled:
                    AppException.Throw("Account is disabled.");
                    break;
                case StatusE.Inactive:
                case StatusE.Deleted:
                    user.StatusIDE = StatusE.Active;
                    user.Save();
                    AppException.Throw("Account activated successfully. <a href='http://RafeySoft.com/Web/Page/Account/SignIn.aspx'>Sign In</a> now!");
                    break;
            }
        }

        public static void SendActivationEmail(Cxt cxt)
        {
            BaseCollection items = BaseCollection.SelectItems(InfiChess.User, "StatusID", 3);

            for (int i = 0; i < items.Count; i++)
            {
                if (EmailTemplate.Send(cxt, EmailTemplateE.NewAccount, new User(cxt, items[i])) != MailVerifyResult.Ok)
                {
                    System.Threading.Thread.Sleep(5000);
                }
            }
        }
        #endregion

        #region Internal Method
        internal void CalculateRanks()
        {
            if (HumanRankIDE == RankE.Guest)
            {
                HumanRankIDE = RankE.Guest;
                EngineRankIDE = RankE.Guest;
                CentaurRankIDE = RankE.Guest;
                CorrespondenceRankIDE = RankE.Guest;
            }
            else
            {
                if (IsNew)
                {
                    EngineRankIDE = RankE.Pawn;
                    CentaurRankIDE = RankE.Pawn;
                }

                HumanRankIDE = RankE.Pawn; // TODO: According to doc and tables
                CorrespondenceRankIDE = RankE.Pawn; // TODO: According to doc and tables
            }
        }
        #endregion

        #region Logoff User
        public void Logoff()
        {
            SocketClient.LogoffUser();

        }
        #endregion

        public static void UpdateInternet(double t, int id)
        {
            double maxLimit = 9999999.99;
            double temp = t;
            if (temp > maxLimit) // to eliminate 'Arithmetic overflow' error
            {
                temp = maxLimit;
            }
            if (temp < -maxLimit) // to eliminate 'Arithmetic overflow' error
            {
                temp = -maxLimit;
            }
            
            BaseCollection.ExecuteSql("update [User] set Internet = " + temp.ToString("0.##") + " WHERE userID = " + id.ToString());
        }

        public static DataTable UpdateFini(SqlTransaction t, int fini, int userID)
        {
            string str = "update [User] set Fini = " + fini.ToString() + " WHERE userID = " + userID.ToString();

            return BaseCollection.ExecuteSql2(t, str);
        }

        #endregion

        #region Contained Methods

        public static User CreateUser(DataTable dt)
        {

            if (dt.Rows.Count > 0)
            {
                User u = new User(Cxt.Instance, dt.Rows[0]);
                return u;
            }

            return null;
        }
        #endregion
    }
}
