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
        public static DataSet GetAllBlockedIPs()
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetAllBlockedIPs);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            return SocketClient.Instance.Invoke(kv.DataTable);
        }
        public static void UnBlockIPs(string blockedIPIds)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.UnBlockIPs);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("BlockedIPID", blockedIPIds);
            SocketClient.Instance.InvokeAsync(kv.DataTable.Copy());
        }
        public static BlockedIP GetBlockedIPByID(int blockedIPID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetBlockedIPByID);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("BlockedIPID", blockedIPID);

            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable);

            if (ds == null)
            {
                return null;
            }

            if (ds.Tables.Count == 0)
            {
                return null;
            }

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }

            BlockedIP i = new BlockedIP(Ap.Cxt, ds.Tables[0].Rows[0]);

            if (blockedIPID > 0)
            {
                ds.Tables[0].Rows[0].AcceptChanges();
                ds.Tables[1].Rows[0].AcceptChanges();

                User u = new User(Ap.Cxt, ds.Tables[1].Rows[0]);

                i.CreatedUser = u;
            }

            return i;
        }
        public static void SaveBlockedIP(string ipAddress,int blockedIPID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.SaveBlockedIP);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("IPAddress", ipAddress);
            kv.Set("BlockedIPID", blockedIPID);
            SocketClient.Instance.Invoke(kv.DataTable);
        }
    }
}
