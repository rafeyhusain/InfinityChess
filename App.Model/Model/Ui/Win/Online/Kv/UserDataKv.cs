using System;
using App.Model;
using System.Collections.Generic;
using System.Text;
using System.Data;
using App.Model.Db;
using System.Drawing;
using System.IO;
using System.Diagnostics;
namespace App.Model
{
    public class UserDataKv : BaseDataKv
    {
        #region Data Member
        private static UserDataKv instance;
        #endregion

        #region Properties

        #region Core

        #endregion

        #region Enum
        public StatusE StatusIDE { [DebuggerStepThrough] get { return (StatusE)this.StatusID; } [DebuggerStepThrough]set { this.StatusID = (int)value; } }
        public string UserImageType { [DebuggerStepThrough] get { return Kv.Get("UserImageType"); } [DebuggerStepThrough]set { Kv.Set("UserImageType", value); } }
        public string UserImage { [DebuggerStepThrough]get { return Kv.Get("UserImage"); } [DebuggerStepThrough]set { Kv.Set("UserImage", value); } }
        public GenderE GenderIDE { [DebuggerStepThrough] get { return (GenderE)this.GenderID; } [DebuggerStepThrough] set { this.GenderID = (int)value; } }
        public FideTitleE FideTitleIDE { [DebuggerStepThrough] get { return (FideTitleE)this.FideTitleID; } [DebuggerStepThrough]set { this.FideTitleID = (int)value; } }
        public IccfTitleE IccfTitleIDE { [DebuggerStepThrough] get { return (IccfTitleE)this.IccfTitleID; } [DebuggerStepThrough] set { this.IccfTitleID = (int)value; } }
        
        #endregion

        #region Generated

        public int UserID
        {
            [DebuggerStepThrough]
            get { return Kv.GetInt32("UserID"); }
            [DebuggerStepThrough]
            set { Kv.Set("UserID", value); }
        }
        public int RoomID { [DebuggerStepThrough] get { return Kv.GetInt32("RoomID"); } [DebuggerStepThrough]set { Kv.Set("RoomID", value); } }
        public int UserStatusID { [DebuggerStepThrough] get { return Kv.GetInt32("UserStatusID"); } [DebuggerStepThrough]set { Kv.Set("UserStatusID", value); } }
        public int HumanRankID { [DebuggerStepThrough] get { return Kv.GetInt32("HumanRankID"); } [DebuggerStepThrough]set { Kv.Set("HumanRankID", value); } }
        public int EngineRankID { [DebuggerStepThrough] get { return Kv.GetInt32("EngineRankID"); } [DebuggerStepThrough]set { Kv.Set("EngineRankID", value); } }
        public int CentaurRankID { [DebuggerStepThrough] get { return Kv.GetInt32("CentaurRankID"); } [DebuggerStepThrough]set { Kv.Set("CentaurRankID", value); } }
        public int CorrespondenceRankID { [DebuggerStepThrough]get { return Kv.GetInt32("CorrespondenceRankID"); } [DebuggerStepThrough]set { Kv.Set("CorrespondenceRankID", value); } }
        public int CountryID { [DebuggerStepThrough]        get { return Kv.GetInt32("CountryID"); } [DebuggerStepThrough]set { Kv.Set("CountryID", value); } }
        public int NearestCityID { [DebuggerStepThrough]    get { return Kv.GetInt32("NearestCityID"); } [DebuggerStepThrough]set { Kv.Set("NearestCityID", value); } }
        public int GenderID { [DebuggerStepThrough]         get { return Kv.GetInt32("GenderID"); } [DebuggerStepThrough] set { Kv.Set("GenderID", value); } }
        public int FideTitleID { [DebuggerStepThrough]      get { return Kv.GetInt32("FideTitleID"); } [DebuggerStepThrough] set { Kv.Set("FideTitleID", value); } }
        public int IccfTitleID { [DebuggerStepThrough]      get { return Kv.GetInt32("IccfTitleID"); } [DebuggerStepThrough]set { Kv.Set("IccfTitleID", value); } }
        public int SocialID { [DebuggerStepThrough]         get { return Kv.GetInt32("SocialID"); } [DebuggerStepThrough] set { Kv.Set("SocialID", value); } }
        public int StatusID { [DebuggerStepThrough]         get { return Kv.GetInt32("StatusID"); } [DebuggerStepThrough]set { Kv.Set("StatusID", value); } }
        public string UserName { [DebuggerStepThrough]      get { return Kv.Get("UserName"); } [DebuggerStepThrough]set { Kv.Set("UserName", value); } }
        public string Password { [DebuggerStepThrough]      get { return Kv.Get("Password"); } [DebuggerStepThrough] set { Kv.Set("Password", value); } }
        public string Email { [DebuggerStepThrough]         get { return Kv.Get("Email"); } [DebuggerStepThrough] set { Kv.Set("Email", value); } }
        public string FirstName { [DebuggerStepThrough]     get { return Kv.Get("FirstName"); } [DebuggerStepThrough]set { Kv.Set("FirstName", value); } }
        public string LastName { [DebuggerStepThrough]      get { return Kv.Get("LastName"); } [DebuggerStepThrough] set { Kv.Set("LastName", value); } }
        public int EngineID { [DebuggerStepThrough]         get { return Kv.GetInt32("EngineID"); } [DebuggerStepThrough]set { Kv.Set("EngineID", value); } }
        public string PersonalNotes { [DebuggerStepThrough] get { return Kv.Get("PersonalNotes"); } [DebuggerStepThrough]set { Kv.Set("PersonalNotes", value); } }
        public string PasswordHint { [DebuggerStepThrough]  get { return Kv.Get("PasswordHint"); } [DebuggerStepThrough]set { Kv.Set("PasswordHint", value); } }
        public string Url { [DebuggerStepThrough]           get { return Kv.Get("Url"); } [DebuggerStepThrough]set { Kv.Set("Url", value); } }
        public string DateLastLogin { [DebuggerStepThrough] get { return Kv.Get("DateLastLogin"); } [DebuggerStepThrough]set { Kv.Set("DateLastLogin", value); } }
        public string DateOfBirth { [DebuggerStepThrough]   get { return Kv.Get("DateOfBirth"); } [DebuggerStepThrough]set { Kv.Set("DateOfBirth", value); } }
        public double Internet { [DebuggerStepThrough]      get { return Kv.GetDouble("Internet"); } [DebuggerStepThrough] set { Kv.Set("Internet", value); } }
        public string BanStartDate { [DebuggerStepThrough]  get { return Kv.Get("BanStartDate"); } [DebuggerStepThrough] set { Kv.Set("BanStartDate", value); } }
        public string BanStartTime { [DebuggerStepThrough]  get { return Kv.Get("BanStartTime"); } [DebuggerStepThrough]set { Kv.Set("BanStartTime", value); } }
        public string BanEndDate { [DebuggerStepThrough]    get { return Kv.Get("BanEndDate"); } [DebuggerStepThrough] set { Kv.Set("BanEndDate", value); } }
        public string BanEndTime { [DebuggerStepThrough]    get { return Kv.Get("BanEndTime"); } [DebuggerStepThrough]set { Kv.Set("BanEndTime", value); } }
        public string BanReason { [DebuggerStepThrough]    get { return Kv.Get("BanReason"); } [DebuggerStepThrough]set { Kv.Set("BanReason", value); } }
        public string BanMachineKey { [DebuggerStepThrough]    get { return Kv.Get("BanMachineKey"); } [DebuggerStepThrough]set { Kv.Set("BanMachineKey", value); } }
        
        public bool IsIdle { [DebuggerStepThrough]          get { return Kv.GetBool("IsIdle"); } [DebuggerStepThrough]set { Kv.Set("IsIdle", value); } }
        public bool IsPause { [DebuggerStepThrough]         get { return Kv.GetBool("IsPause"); } [DebuggerStepThrough]set { Kv.Set("IsPause", value); } }

        #endregion

        #region Contained Classes

        public static UserDataKv Instance
        {
            [DebuggerStepThrough]
            get
            {
                if (instance == null)
                    instance = new UserDataKv();
                return instance;
            }

            [DebuggerStepThrough]
            set { instance = value; }
        }
        #endregion

        #region Calculated

        #endregion
        #endregion

        #region Constructor
        public UserDataKv()
        {
            Kv = new Kv(KvType.Web);
        }

        public UserDataKv(Kv kv)
        {
            Kv = kv;
        }

        #endregion

        #region Methods

        #region Public Methods (Add/Update/Delete)

        public DataTable AddUser()
        {
            base.Kv.Cxt.CurrentUserID = 1; // New users are added by Admin = 1
            User item = new User();
            item.Cxt = base.Kv.Cxt;
            if (CountryID != 0)
                item.CountryID = CountryID;
            item.NearestCityID = NearestCityID;
            item.GenderID = GenderID;
            item.FideTitleID = FideTitleID;
            item.IccfTitleID = IccfTitleID;
            item.UserName = UserName;
            item.Email = Email;
            item.FirstName = FirstName;
            item.LastName = LastName;
            item.EngineID = 1;
            item.PasswordHint = PasswordHint;
            item.PersonalNotes = PersonalNotes;
            item.Url = Url;
            if (DateLastLogin != string.Empty)
                item.DateLastLogin = Convert.ToDateTime(DateLastLogin);
            if (DateOfBirth != string.Empty)
                item.DateOfBirth = Convert.ToDateTime(DateOfBirth);
            item.Password = Password;
            item.HumanRankIDE = RankE.Pawn;
            item.EngineRankIDE = RankE.Pawn;
            item.CentaurRankIDE = RankE.Pawn;
            item.CorrespondenceRankIDE = RankE.Pawn;
            item.StatusIDE = StatusE.Active;
            item.RoomID = 3;
            item.SocialID = 1;
            item.UserStatusIDE = UserStatusE.Blank;
            item.IsIdle = false;
            item.IsPause = false;
            item.Cxt.CurrentUserID = base.Kv.Cxt.CurrentUserID;

            item.Save();

            if (!string.IsNullOrEmpty(UserImage))
            {
                SaveUserImage(Ap.WebFolderUserImages + item.UserID);
            }

            DataTable roles = User.GetRolesTable(item.UserID);

            Kv kv1 = new Kv();
            kv1.Set("MsgId", -1);
            kv1.Set("UserData", UData.ToString(item.DataRow.Table));
            kv1.Set("RolesData", UData.ToString(roles.Copy()));

            return kv1.DataTable;
        }

        public void SaveIp(Cxt cxt, string IPAddress, int BlockedBy)
        {
            if (IPAddress == "")
                return;

            try
            {
                BaseCollection.ExecuteSql("Insert into BlockedIP (IPAddress,CreatedBy,DateCreated) values ('" + IPAddress + "'," + BlockedBy + ",'" + DateTime.Now.ToString() + "')");
            }
            catch (Exception ex)
            {
                Log.Write(cxt, ex);
            }
            
        }

        public Kv BanUser()
        {
            User item = null;
            item = new User(base.Kv.Cxt, UserID);

            item.StatusID = StatusID;
            if (BanStartDate != string.Empty)
                item.BanStartDate = Convert.ToDateTime(BanStartDate);

            if (BanEndDate != string.Empty)
                item.BanEndDate = Convert.ToDateTime(BanEndDate);
            else
                item.SetColumnNull("BanEndDate");

            if (BanStartTime != string.Empty)
                item.BanStartTime = Convert.ToDateTime(BanStartTime);

            if (BanEndTime != string.Empty)
                item.BanEndTime = Convert.ToDateTime(BanEndTime);
            if (BanReason != string.Empty)
                item.BanReason = BanReason;
            else
                item.SetColumnNull("BanEndTime");

            item.BanMachineKey = BanMachineKey;
            item.Cxt.CurrentUserID = base.Kv.Cxt.CurrentUserID;
            item.Save();

            Kv kv = new Kv();
            kv.Set("BanStartDate", item.BanStartDate.ToShortDateString() + " " + item.BanStartTime.ToShortTimeString());
            kv.Set("BanEndDate", item.BanEndDate.ToShortDateString() + " " + item.BanEndTime.ToShortTimeString());

            return kv;
        }

        public DataTable UpdateUser()
        {
            User item = new User(base.Kv.Cxt, base.Kv.Cxt.CurrentUserID);

            item.CountryID = CountryID;
            item.NearestCityID = NearestCityID;
            item.GenderID = GenderID;
            item.FideTitleID = FideTitleID;
            item.IccfTitleID = IccfTitleID;
            item.Email = Email;
            item.FirstName = FirstName;
            item.LastName = LastName;
            item.PersonalNotes = PersonalNotes;
            item.Url = Url;
            if (DateOfBirth != string.Empty)
                item.DateOfBirth = Convert.ToDateTime(DateOfBirth);//DateOfBirth;

            item.Cxt.CurrentUserID = base.Kv.Cxt.CurrentUserID;

            item.Save();

            if (!string.IsNullOrEmpty(UserImage))
            {
                SaveUserImage(Ap.WebFolderUserImages + item.UserID);
            }

            DataTable roles = User.GetRolesTable(item.UserID);

            Kv kv1 = new Kv();
            kv1.Set("MsgId", -1);
            kv1.Set("UserData", UData.ToString(item.DataRow.Table));
            kv1.Set("RolesData", UData.ToString(roles.Copy()));

            return kv1.DataTable;
        }

        public bool DeleteUser()
        {
            return false;
        }

        public DataTable GetUserInfoByUserID()
        {
            int userID = Kv.GetInt32("UserID");
            DataTable dt = User.GetUserInfoByUserID(Kv.Cxt, userID);
            Kv Kv1 = new Kv();
            Kv1.DataTable = dt;
            
            if (Kv1.DataTable.Rows.Count > 0)
            {
                DataColumn dc = new DataColumn("UserImage");
                Kv1.DataTable.Columns.Add(dc);
                Kv1.DataTable.Rows[0]["UserImage"] = GetUserImage(Ap.WebFolderUserImages + userID);
            }
            return Kv1.DataTable;
        }

        public DataTable GetRankInfo()
        {
            int userID = Kv.GetInt32("UserID");
            DataTable dt = User.GetRankInfo(Kv.Cxt, userID);
            Kv Kv1 = new Kv();
            Kv1.DataTable = dt;
            return Kv1.DataTable;
        }
       
        public DataTable GetUserByName()
        {
            Kv kv1 = new Kv();
            kv1.DataTable = User.GetUserByName(base.Kv.Cxt, Kv.Get("UserName"));
            if (kv1.DataTable.Rows.Count > 0)
            {
                DataColumn dc = new DataColumn("UserImage");
                kv1.DataTable.Columns.Add(dc);
                kv1.DataTable.Rows[0]["UserImage"] = GetUserImage(Ap.WebFolderUserImages + kv1.DataTable.Rows[0]["UserID"]);//kv1.GetInt32("UserID"));
            }
            return kv1.DataTable;
        }

        public DataSet SetUserEngine()
        {
            int userID = base.Kv.GetInt32("UserID");
            string engineName = base.Kv.Get("EngineName");
            string userStatus = base.Kv.Get("UserStatus");

            DataSet ds = new DataSet();
            if (userID != 0)
            {
                Engine eng;
                DataTable dt = Engine.GetEngineByName(base.Kv.Cxt, engineName);
                if (dt.Rows.Count > 0)
                {
                    eng = new Engine(base.Kv.Cxt, dt.Rows[0]);
                }
                else
                {
                    eng = new Engine();
                    eng.Name = engineName.Trim();
                    eng.Description = engineName;
                    eng.Save();
                }
                User user = new User(base.Kv.Cxt, userID);
                user.EngineID = eng.EngineID;
                user.UserStatusID = UData.ToInt32(userStatus);
                user.Save();
            }

            return ds;
        }

        public void GetUserPicture(int userID)
        {
            Kv = new Kv();
            DataColumn dc = new DataColumn("UserImage");
            Kv.DataTable.Columns.Add(dc);
            Kv.DataTable.Rows[0]["UserImage"] = GetUserImage(Ap.WebFolderUserImages + userID);
        }

        #endregion

        #region Private Methods (SaveImage)

        private void SaveUserImage(string filePath)
        {
            DataTable userImageTable = new DataTable("UserImageTable");
            DataColumn nameColumn;
            nameColumn = new DataColumn();
            nameColumn.DataType = System.Type.GetType("System.String");
            nameColumn.ColumnName = "ImageName";
            userImageTable.Columns.Add(nameColumn);
            DataColumn imageColumn;
            imageColumn = new DataColumn();
            imageColumn.DataType = System.Type.GetType("System.Byte[]");
            imageColumn.ColumnName = "ImageBytes";
            userImageTable.Columns.Add(imageColumn);

            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            MemoryStream ms = new MemoryStream(encoding.GetBytes(UserImage));
            userImageTable.ReadXml(ms);
            ms.Close();

            //Image img = Image.FromStream(ms);
            if (userImageTable != null && userImageTable.Rows.Count > 0)
            {
                MemoryStream memoryStream = new MemoryStream((byte[])userImageTable.Rows[0]["ImageBytes"]);
                Bitmap img = new Bitmap(memoryStream);

                UFile.Delete(filePath + ".bmp");
                UFile.Delete(filePath + ".jpeg");
                UFile.Delete(filePath + ".jpg");
                UFile.Delete(filePath + ".gif");
                UFile.RemoveReadOnly(filePath + UserImageType);

                img.Save(filePath + UserImageType);
                memoryStream.Close();
            }
        }

        private string GetUserImage(string filePath)
        {
            string imagetype = "";
            if (UFile.Exists(filePath + ".bmp"))
            {
                imagetype = ".bmp";
            }
            else if (UFile.Exists(filePath + ".jpeg"))
            {
                imagetype = ".jpeg";
            }
            else if (UFile.Exists(filePath + ".jpg"))
            {
                imagetype = ".jpg";
            }
            else if (UFile.Exists(filePath + ".gif"))
            {
                imagetype = ".gif";
            }
            else
            {
                return string.Empty;
            }
            byte[] UserImageBytes = UImage.GetImageBytes(filePath + imagetype);
            //UserImageType = System.IO.Path.GetExtension(filePath);
            DataTable userImageTable = new DataTable("UserImageTable");
            DataColumn nameColumn;
            nameColumn = new DataColumn();
            nameColumn.DataType = System.Type.GetType("System.String");
            nameColumn.ColumnName = "ImageName";
            userImageTable.Columns.Add(nameColumn);
            DataColumn imageColumn;
            imageColumn = new DataColumn();
            imageColumn.DataType = System.Type.GetType("System.Byte[]");
            imageColumn.ColumnName = "ImageBytes";
            userImageTable.Columns.Add(imageColumn);
            DataColumn typeColumn;
            typeColumn = new DataColumn();
            typeColumn.DataType = System.Type.GetType("System.String");
            typeColumn.ColumnName = "ImageType";
            userImageTable.Columns.Add(typeColumn);
            DataRow dr = userImageTable.NewRow();
            dr["ImageName"] = "UserImage";
            dr["ImageBytes"] = UserImageBytes;
            dr["ImageType"] = imagetype;
            userImageTable.Rows.Add(dr);

            return UData.ToString(userImageTable);
        }

        public void SaveMachineCode(string machineKey, int BlockedBy)
        {
            if (String.IsNullOrEmpty(machineKey))
                return;
            BaseCollection.ExecuteSql("Insert into BlockedMachines(MachineKey,CreatedBy,DateCreated) Values('" + machineKey + "'," + BlockedBy + ",'" + DateTime.Now.ToString() + "')");
        }

        #endregion

        #region Checkout Account
        public Kv CheckoutAccount()
        {
            Kv kv = new Kv();
            string VoucherNo = Kv.Get("VoucherNo");
            UserVoucher UserVoucher = UserVoucher.CheckoutAccount(base.Kv.Cxt, VoucherNo);
            if (UserVoucher != null)
            {
                User User = User.GetUserByID(base.Kv.Cxt, UserVoucher.UserID);
                kv.Set("Payment", User.Fini);
                kv.Set("ExpiryDate", UserVoucher.ExpiryDate);
                if (UserVoucher.IsUsed == false)
                {
                    kv.Set("Message", "0");
                }
                else
                {
                    kv.Set("Message", "1");
                }
            }
            else
            {
                kv.Set("Message", "2");
            }
            return kv;
        }
        #endregion

        #endregion
    }
}
