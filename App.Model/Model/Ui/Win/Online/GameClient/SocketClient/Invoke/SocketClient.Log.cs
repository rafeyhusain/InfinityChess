using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace App.Model
{
    public partial class SocketClient
    {
        public static DataSet GetAllLog()
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetAllLog);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable.Copy());
            return ds;
        }
        public static void ClearLog()
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.ClearLog);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            SocketClient.Instance.InvokeAsync(kv.DataTable.Copy());
        }
    }
}
