using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;
using System.Diagnostics;
namespace App.Model.Db
{
    public enum ServerEventE
    {
        ServerStarted = 1,
        PeakUserCount = 2
    }

    public class ServerEventLog : BaseItem
    {
        #region Constructor
        public ServerEventLog()
            : base(0)
        {
        }

        public ServerEventLog(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public ServerEventLog(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public ServerEventLog(Cxt cxt, DataRow row)
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
            get { return InfiChess.ServerEventLog; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }
        #endregion

        #region Enum

        public ServerEventE ServerEventIDE
        {
            set { this.ServerEventID = (int)value; }
            get { return (ServerEventE)this.ServerEventID; }
        }
        #endregion

        #region Generated
        public int ServerEventLogID { get { return GetColInt32("ServerEventLogID"); } set { SetColumn("ServerEventLogID", value); } }
        public int ServerEventID { get { return GetColInt32("ServerEventID"); } set { SetColumn("ServerEventID", value); } }
        public string ServerIp { get { return GetCol("ServerIp"); } set { SetColumn("ServerIp", value); } }
        public string ServerPort { get { return GetCol("ServerPort"); } set { SetColumn("ServerPort", value); } }
        #endregion

        #endregion

        #region Methods

        public static ServerEventLog GetServerEventLogById(Cxt cxt, int ServerEventLogById)
        {
            return new ServerEventLog(cxt, BaseCollection.SelectItem(InfiChess.ServerEventLog, ServerEventLogById));
        }
        public static ServerEventLog GetTopServerEventLog(Cxt cxt)
        {
            ServerEventLogs ServerEventLogs = new ServerEventLogs(cxt, 
                            BaseCollection.ExecuteSql(InfiChess.ServerEventLog, 
                            "select top 1 * from servereventlog order by servereventlogid desc"));
            
            return ServerEventLogs[0];
        }
        public static void UpdatePeakUser(Cxt cxt, int serverPeakUserCount)
        {            
            ServerEventLog ServerEventLog = GetTopServerEventLog(cxt);
            try
            {
                if (ServerEventLog.ServerEventIDE == ServerEventE.PeakUserCount)
                {
                    int peakUser = 0;
                    peakUser = Convert.ToInt32(ServerEventLog.Description);
                    if (serverPeakUserCount > peakUser)
                    {
                        ServerEventLog.Description = serverPeakUserCount.ToString();
                        ServerEventLog.Save();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Write(cxt, ex);
            }
        }

        #endregion
    }
}
