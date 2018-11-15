using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using App.Model;
using App.Model.Db;

namespace App.Win
{
    public class Srv
    {
        private static Srv srv = null;

        public static Srv Instance
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                if (srv == null)
                {
                    srv = new Srv();
                }

                return srv;
            }
        }

        public DataSet Invoke(DataTable dt)
        {
            return SocketClient.Instance.Invoke(dt);
        }

        public void InvokeAsync(DataTable dt)
        {
            SocketClient.Instance.InvokeAsync(dt);
        }

        public static void SetCurrentUser(Kv kv1)
        {
            DataTable dtUser = kv1.GetDataTable("UserData");
            DataTable dtRoles = kv1.GetDataTable("RolesData");

            if (dtUser.Rows.Count > 0)
            {
                Ap.CurrentUser = new User(Cxt.Instance, dtUser.Rows[0]);
                UWeb.Principal = User.GetPrincipal(Ap.CurrentUser.UserName, dtRoles);
            }
        }

    }
}
