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
        public static DataSet CheckoutAccount(string voucherNo)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.CheckoutAccount);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("VoucherNo", voucherNo);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable);

            return ds;
        }
    }
}
