using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using App.Model.Db;

namespace App.Model
{
    public partial class SocketClient
    {
        public static ServerStatistic GetServerStatistic()
        {
            ServerStatistic ServerStatistic = null;
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetServerStatistics);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable.Copy());

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ServerStatistic = new ServerStatistic(kv.Cxt, ds.Tables[0].Rows[0]);
            }
            return ServerStatistic;
        }

        public static DataSet GetKeyValue(string key)
        {
            DataSet ds = null;

            try
            {
                Kv kv = new Kv();
                kv.Set("MethodName", (int)MethodNameE.GetKeyValue);
                kv.Set("Key", key);
                kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
                ds = SocketClient.Instance.Invoke(kv.DataTable.Copy());
            }
            catch
            {
                ds = new DataSet();
            }

            return ds;
        }
    }
}
