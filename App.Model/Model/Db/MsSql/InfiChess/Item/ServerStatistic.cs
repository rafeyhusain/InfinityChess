using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;
namespace App.Model.Db
{
    public class ServerStatistic : BaseItem
    {
        #region Constructor
        public ServerStatistic()
            : base(0)
        {
        }

        public ServerStatistic(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public ServerStatistic(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public ServerStatistic(Cxt cxt, DataRow row)
        {
            Cxt = cxt;

            DataRow = row;
        }

       
        #endregion

        #region Properties
        #region Enum
        #endregion

        #region Generated
        public int ServerStatisticsID { get { return GetColInt32("ServerStatisticsID"); } set { SetColumn("ServerStatisticsID", value); } }
        public int ServerUpTime { get { return GetColInt32("ServerUpTime"); } set { SetColumn("ServerUpTime", value); } }
        public int Visitors { get { return GetColInt32("Visitors"); } set { SetColumn("Visitors", value); } }
        public int GamePlayed { get { return GetColInt32("GamePlayed"); } set { SetColumn("GamePlayed", value); } }
        public int PeakUsers { get { return GetColInt32("PeakUsers"); } set { SetColumn("PeakUsers", value); } }
        public int Tournaments { get { return GetColInt32("Tournaments"); } set { SetColumn("Tournaments", value); } }
        public int RegisterUsers { get { return GetColInt32("RegisterUsers"); } set { SetColumn("RegisterUsers", value); } }
        public int TotalGames { get { return GetColInt32("TotalGames"); } set { SetColumn("TotalGames", value); } }
        public string ServerIp { get { return GetCol("ServerIp"); } set { SetColumn("ServerIp", value); } }
        public string ServerPort { get { return GetCol("ServerPort"); } set { SetColumn("ServerPort", value); } }
        public string ServerVersion { get { return GetCol("ServerVersion"); } set { SetColumn("ServerVersion", value); } }
        public DateTime PriviousDay { get { return GetColDateTime("PriviousDay"); } set { SetColumn("PriviousDay", value); } }
        #endregion
        #endregion

        #region Methods
        public static ServerStatistic GetServerStatisticById(Cxt cxt)
        {
            ServerStatistics ServerStatistics = new ServerStatistics(cxt,
                   BaseCollection.ExecuteSql("select top 1 * from ServerStatistics order by ServerStatisticsID desc"));

            return ServerStatistics[0];
        }
        public static void CreateServerStatistics(Cxt cxt)
        {
            try
            {
                BaseCollection.Execute("CreateServerStatistics");
            }
            catch (Exception ex)
            {

                Log.Write(cxt, ex);
            }
            
        }

        

        #endregion
    }
}
