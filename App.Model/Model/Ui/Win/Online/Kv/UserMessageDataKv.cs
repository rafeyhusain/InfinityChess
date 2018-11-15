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
    public class UserMessageDataKv : BaseDataKv
    {
        #region Constructor
        public UserMessageDataKv()
        {
            Kv = new Kv(KvType.Web);
        }

        public UserMessageDataKv(Kv kv)
        {
            base.Kv = kv;
        }
        #endregion

        #region Properties

        #region Core

        #endregion

        #region Enum
        public StatusE StatusIDFromE { [DebuggerStepThrough]get { return (StatusE)this.StatusIDFrom; } [DebuggerStepThrough]set { this.StatusIDFrom = (int)value; } }
        public StatusE StatusIDToE { [DebuggerStepThrough]get { return (StatusE)this.StatusIDTo; } [DebuggerStepThrough]set { this.StatusIDTo = (int)value; } }
        #endregion

        #region Generated
        public int UserMessageID { [DebuggerStepThrough]get { return base.Kv.GetInt32("UserMessageID"); } [DebuggerStepThrough]set { base.Kv.Set("UserMessageID", value); } }
        public int UserIDFrom { [DebuggerStepThrough]get { return base.Kv.GetInt32("UserIDFrom"); } [DebuggerStepThrough]set { base.Kv.Set("UserIDFrom", value); } }
        public int UserIDTo { [DebuggerStepThrough]get { return base.Kv.GetInt32("UserIDTo"); } [DebuggerStepThrough]set { base.Kv.Set("UserIDTo", value); } }
        public string UserNameTo { [DebuggerStepThrough]get { return base.Kv.Get("UserNameTo"); } [DebuggerStepThrough]set { base.Kv.Set("UserNameTo", value); } }
        public int Size { [DebuggerStepThrough]get { return base.Kv.GetInt32("Size"); } [DebuggerStepThrough]set { base.Kv.Set("Size", value); } }
        public int StatusIDFrom { [DebuggerStepThrough]get { return base.Kv.GetInt32("StatusIDFrom"); } [DebuggerStepThrough]set { base.Kv.Set("StatusIDFrom", value); } }
        public int StatusIDTo { [DebuggerStepThrough]get { return base.Kv.GetInt32("StatusIDTo"); } [DebuggerStepThrough]set { base.Kv.Set("StatusIDTo", value); } }
        public string Subject { [DebuggerStepThrough]get { return base.Kv.Get("Subject"); } [DebuggerStepThrough]set { base.Kv.Set("Subject", value); } }
        public string Text { [DebuggerStepThrough]get { return base.Kv.Get("Text"); } [DebuggerStepThrough]set { base.Kv.Set("Text", value); } }
        public DateTime EmailTime { [DebuggerStepThrough]get { return base.Kv.GetDateTime("EmailTime"); } [DebuggerStepThrough] set { base.Kv.Set("EmailTime", value); } }
        #endregion

        #region Contained Classes

        #endregion

        #region Calculated

        #endregion
        #endregion

        #region Methods
        public void SendMessage()
        {
            UserMessage item = new UserMessage();
            try
            {
                string selectQuery;
                DataTable table;
                selectQuery = "SELECT UserID FROM [User] WHERE UserName = '" + UserNameTo + "'";
                table = BaseCollection.ExecuteSql(selectQuery);

                if (table != null && table.Rows.Count > 0)
                {
                    UserIDTo = UData.ToInt32(table.Rows[0][0]);
                }
                else
                {
                    UserIDTo = 0;
                }

                item.Cxt = base.Kv.Cxt;
                item.UserIDFrom = UserIDFrom;
                item.UserIDTo = UserIDTo;
                item.EmailTime = DateTime.Now;
                item.Text = Text;
                item.Subject = Subject;
                item.StatusIDFrom = StatusIDFrom;
                item.StatusIDTo = StatusIDTo;
                item.Size = Size;
                item.Cxt.CurrentUserID = base.Kv.Cxt.CurrentUserID;

                item.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable DeleteMessage()
        {
            UserMessage item = new UserMessage(base.Kv.Cxt, UserMessageID);
            try
            {
                item.StatusIDFrom = StatusIDFrom;
                item.StatusIDTo = StatusIDTo;
                item.Save();

                return UserMessages.GetuserMessages(base.Kv.Cxt, base.Kv.GetInt32(StdKv.CurrentUserID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
