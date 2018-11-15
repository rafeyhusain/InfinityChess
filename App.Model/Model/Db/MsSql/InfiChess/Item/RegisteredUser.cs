using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Diagnostics;
/// <summary>
/// Summary description for RegisteredUser
/// </summary>
namespace App.Model.Db
{
    public class RegisteredUser : BaseItem
    {
        #region Constructor

        public RegisteredUser()
            : base(0)
        {
        }

        public RegisteredUser(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public RegisteredUser(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public RegisteredUser(Cxt cxt, DataRow row)
        {
            Cxt = cxt;

            DataRow = row;
        }

        public RegisteredUser(Cxt cxt, string serialNumber)
        {
            Cxt = cxt;

            Load(serialNumber);
        }

        #endregion

        #region Properties

        #region Core

        public override InfiChess TableName
        {
            [DebuggerStepThrough]
            get { return InfiChess.RegisteredUser; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion

        #region Enum

        #endregion

        #region Generated

        public int RegisteredUserID { get { return GetColInt32("RegisteredUserID"); } set { SetColumn("RegisteredUserID", value); } }
        public int StatusID { get { return GetColInt32("StatusID"); } set { SetColumn("StatusID", value); } }
        public string SerialNumber { get { return GetCol("SerialNumber"); } set { SetColumn("SerialNumber", value); } }
        public string FirstName { get { return GetCol("FirstName"); } set { SetColumn("FirstName", value); } }
        public string LastName { get { return GetCol("LastName"); } set { SetColumn("LastName", value); } }
        public string StreetAddress { get { return GetCol("StreetAddress"); } set { SetColumn("StreetAddress", value); } }
        public string PostCode { get { return GetCol("PostCode"); } set { SetColumn("PostCode", value); } }
        public string City { get { return GetCol("City"); } set { SetColumn("City", value); } }
        public string Country { get { return GetCol("Country"); } set { SetColumn("Country", value); } }
        public string Email { get { return GetCol("Email"); } set { SetColumn("Email", value); } }
        public bool NotifyByEmail { get { return GetColBool("NotifyByEmail"); } set { SetColumn("NotifyByEmail", value); } }

        #endregion

        #endregion

        #region Methods
        public void Load(string serialNumber)
        {
            DataTable table = BaseCollection.ExecuteSql(InfiChess.RegisteredUser, "SELECT * FROM [RegisteredUser] WHERE SerialNumber=@p1", serialNumber);

            SetRow(table);
        }
        #endregion
    }
}