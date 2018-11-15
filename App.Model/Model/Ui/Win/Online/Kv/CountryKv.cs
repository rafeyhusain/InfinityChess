using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using App.Model.Db;
using System.Diagnostics;
namespace App.Model
{
    public class CountryKv : BaseDataKv
    {
        #region Constructor
        public CountryKv()
        {
            Kv = new Kv(KvType.Web);
        }

        public CountryKv(Kv kv)
        {
            base.Kv = kv;
        }

        #endregion

        #region Properties
        public int UserID { [DebuggerStepThrough] get { return Kv.GetInt32("UserID"); } [DebuggerStepThrough] set { Kv.Set("UserID", value); } }
        public int RoomID { [DebuggerStepThrough] get { return Kv.GetInt32("RoomID"); } [DebuggerStepThrough] set { Kv.Set("RoomID", value); } }
        public int UserStatusID { [DebuggerStepThrough]get { return Kv.GetInt32("UserStatusID"); } [DebuggerStepThrough] set { Kv.Set("UserStatusID", value); } }
        public int RankID { [DebuggerStepThrough] get { return Kv.GetInt32("RankID"); } [DebuggerStepThrough] set { Kv.Set("RankID", value); } }
        public int CountryID { [DebuggerStepThrough]get { return Kv.GetInt32("CountryID"); } [DebuggerStepThrough] set { Kv.Set("CountryID", value); } }
        public int NearestCityID { [DebuggerStepThrough] get { return Kv.GetInt32("NearestCityID"); } [DebuggerStepThrough] set { Kv.Set("NearestCityID", value); } }
        public int GenderID { [DebuggerStepThrough] get { return Kv.GetInt32("GenderID"); } [DebuggerStepThrough]set { Kv.Set("GenderID", value); } }
        public int FideTitleID { [DebuggerStepThrough]get { return Kv.GetInt32("FideTitleID"); } [DebuggerStepThrough] set { Kv.Set("FideTitleID", value); } }
        public int IccfTitleID { [DebuggerStepThrough]get { return Kv.GetInt32("IccfTitleID"); } [DebuggerStepThrough] set { Kv.Set("IccfTitleID", value); } }
        public int FideStrength { [DebuggerStepThrough]get { return Kv.GetInt32("FideStrength"); } [DebuggerStepThrough] set { Kv.Set("FideStrength", value); } }
        public int IccfStrength { [DebuggerStepThrough]get { return Kv.GetInt32("IccfStrength"); } [DebuggerStepThrough]set { Kv.Set("IccfStrength", value); } }
        public int ScocialID { [DebuggerStepThrough] get { return Kv.GetInt32("ScocialID"); } [DebuggerStepThrough]set { Kv.Set("ScocialID", value); } }
        public int StatusID { [DebuggerStepThrough]get { return Kv.GetInt32("StatusID"); } [DebuggerStepThrough]set { Kv.Set("StatusID", value); } }
        public string UserName { [DebuggerStepThrough]get { return Kv.Get("UserName"); } [DebuggerStepThrough] set { Kv.Set("UserName", value); } }
        public string Password { [DebuggerStepThrough] get { return Kv.Get("Password"); } [DebuggerStepThrough] set { Kv.Set("Password", value); } }
        public string Email { [DebuggerStepThrough] get { return Kv.Get("Email"); } [DebuggerStepThrough]set { Kv.Set("Email", value); } }
        public string FirstName { [DebuggerStepThrough] get { return Kv.Get("FirstName"); } [DebuggerStepThrough] set { Kv.Set("FirstName", value); } }
        public string LastName { [DebuggerStepThrough] get { return Kv.Get("LastName"); } [DebuggerStepThrough] set { Kv.Set("LastName", value); } }
        public string Engine { [DebuggerStepThrough] get { return Kv.Get("Engine"); } [DebuggerStepThrough] set { Kv.Set("Engine", value); } }
        public string PasswordHint { [DebuggerStepThrough]get { return Kv.Get("PasswordHint"); } [DebuggerStepThrough] set { Kv.Set("PasswordHint", value); } }
        public string PersonalNotes { [DebuggerStepThrough]get { return Kv.Get("PersonalNotes"); } [DebuggerStepThrough] set { Kv.Set("PersonalNotes", value); } }
        public string Url { [DebuggerStepThrough] get { return Kv.Get("Url"); } [DebuggerStepThrough] set { Kv.Set("Url", value); } }
        public DateTime DateLastLogin { [DebuggerStepThrough] get { return Kv.GetDateTime("DateLastLogin"); } [DebuggerStepThrough] set { Kv.Set("DateLastLogin", value); } }
        public DateTime DateOfBirth { [DebuggerStepThrough] get { return Kv.GetDateTime("DateOfBirth"); } [DebuggerStepThrough] set { Kv.Set("DateOfBirth", value); } }
        #endregion

        #region Methods
        public bool AddUser()
        {
            User item = new User();

            item.SetColumn("RoomID", Kv.Get("RoomID"));
            item.SetColumn("UserStatusID", Kv.Get("UserStatusID"));
            item.SetColumn("RankID", Kv.Get("RankID"));
            item.SetColumn("CountryID", Kv.Get("CountryID"));
            item.SetColumn("NearestCityID", Kv.Get("NearestCityID"));
            item.SetColumn("GenderID", Kv.Get("GenderID"));
            item.SetColumn("FideTitleID", Kv.Get("FideTitleID"));
            item.SetColumn("IccfTitleID", Kv.Get("IccfTitleID"));
            item.SetColumn("FideStrength", Kv.Get("FideStrength"));
            item.SetColumn("IccfStrength", Kv.Get("IccfStrength"));
            item.SetColumn("ScocialID", Kv.Get("ScocialID"));
            item.SetColumn("UserName", Kv.Get("UserName"));
            item.SetColumn("Email", Kv.Get("Email"));
            item.SetColumn("FirstName", Kv.Get("FirstName"));
            item.SetColumn("LastName", Kv.Get("LastName"));
            item.SetColumn("Engine", Kv.Get("Engine"));
            item.SetColumn("PasswordHint", Kv.Get("PasswordHint"));
            item.SetColumn("PersonalNotes", Kv.Get("PersonalNotes"));
            item.SetColumn("Url", Kv.Get("Url"));
            item.SetColumn("DateLastLogin", Kv.Get("DateLastLogin"));
            item.SetColumn("DateOfBirth", Kv.Get("DateOfBirth"));
            item.SetColumn("Password", UCrypto.Encrypt(Kv.Get("Password")));
            item.Save();


            return false;
        }

        public bool UpdateUser()
        {
            return false;
        }

        public bool DeleteUser()
        {
            return false;
        }

        public bool Exists(String userName)
        {
            return User.Exists(base.Kv.Cxt, userName);
        }
        #endregion
    }
}
