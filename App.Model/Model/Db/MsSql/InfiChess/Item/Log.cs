// (c) Copyright RafeySoft, Karachi Pakistan. http://rafeysoft.com
// This source is subject to following License:
// http://rafeysoft.com/Web/Page/ItemEdit.aspx?sid=29&lid=4&cid=23&iid=2143
// Please write to info@rafeysoft.com for more information
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;
namespace App.Model.Db
{
    public class Log : BaseItem
    {
        #region DataMembers

        public static string Error = "Error";
        public static string Warning = "Warning";
        public static string Info = "Info";
        public static string System = "System";

        #endregion

        #region Constructor
        public Log()
            : base(0)
        {
        }

        public Log(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public Log(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        #endregion

        #region Properties

        #region Core

        public override InfiChess TableName
        {
            [DebuggerStepThrough]
            get { return InfiChess.Log; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion

        #region Table Columns

        public string Type { [DebuggerStepThrough]get { return GetCol("Type"); } [DebuggerStepThrough]set { SetColumn("Type", value); } }
        public string Category { [DebuggerStepThrough]get { return GetCol("Category"); } [DebuggerStepThrough]set { SetColumn("Category", value); } }
        public string Message { [DebuggerStepThrough]get { return GetCol("Message"); } [DebuggerStepThrough] set { SetColumn("Message", value); } }
        #endregion

        #endregion

        #region Methods

        #region WriteMessages

        public static void WriteError(Cxt cxt, string message)
        {
            Write(cxt, Log.Error, Log.System, message);
        }

        public static void Write(Cxt cxt, Exception ex)
        {
            Write(cxt, ex, "");
        }

        public static void Write(Cxt cxt, Exception ex, string message)
        {
            if (ex == null)
            {
                ex = new Exception("Exception object was null. Using this dummy as replacement.");
            }

            Write(cxt, Log.Error, Log.System, AppException.GetError(ex, message));
        }

        public static void Write(Cxt cxt, string message)
        {
            Write(cxt, Log.Info, Log.System, message);
        }

        public static void Write(Cxt cxt, string type, string category, string message)
        {
            Log log = new Log(cxt, 0);

            if (cxt != null)
            {
                if (cxt.CurrentUserID != 0)
                {
                    message = "UserName:" + UStr.Bracket(cxt.CurrentUser.UserName) + " - " + message;
                }
            }

            log.Type = type;
            log.Category = category;
            log.Message = message;

            log.Save();
        }

        #endregion

        #region Writedata

        public static void WriteOutgoing(Cxt cxt, string data)
        {
            if (Config.GameServerEnableOutgoingLog)
            {
                Log.Write(cxt, "Info", "Outgoing", data);
            }
        }
        public static void WriteIncomming(Cxt cxt, string data)
        {
            if (Config.GameServerEnableIncomingLog)
            {
                Log.Write(cxt, "Info", "Incomming", data);
            }
        }

        #endregion

        #region WriteError

        public static void WriteStackTrace(Cxt cxt)
        {
            try
            {
                throw new Exception("WriteStackTrace");
            }
            catch (Exception ex)
            {
                Log.Write(cxt, ex);
            }
        }

        #endregion

        #region SelectSqlLogTable

        public static DataTable SelectAll()
        {
            return BaseCollection.ExecuteSql("select * from [Log] order by DateCreated desc");
        }
        public static DataTable SelectByCategory(string category)
        {
            return BaseCollection.ExecuteSql("select * from [Log] where Type = 'Info' and Category = '" + category + "' order by DateCreated desc");
        }

        #endregion

        #region DeleteLogTable

        public static void Clear()
        {
            BaseCollection.ExecuteSql("delete from [Log]");
        }

        #endregion

        #endregion
    }
}
