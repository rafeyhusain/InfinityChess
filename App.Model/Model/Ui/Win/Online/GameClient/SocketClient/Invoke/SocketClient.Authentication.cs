// (c) Copyright RafeySoft, Karachi Pakistan. http://rafeysoft.com
// This source is subject to following License:
// http://rafeysoft.com/Web/Page/ItemEdit.aspx?sid=29&lid=4&cid=23&iid=2143
// Please write to info@rafeysoft.com for more information
// All other rights reserved.
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using System.Net.Sockets;
using System.Net;
using System.Collections;
using System.Threading;
using App.Model.Db;

namespace App.Model
{
    public partial class SocketClient
    {
        public static DataSet LoginUser(string loginId, string password, string accessCode)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.LoginUser);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("LoginId", loginId);
            kv.Set("Password", UCrypto.Encrypt(password));
            kv.Set("AccessCode", Options.Instance.ApplicationCode);
            kv.Set("MachineCode", WmiHelper.GetMachineKey());
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable);          
            return ds;
        }

        public static void LoginUser(int userID, UserStatusE userStatus)
        {
            TimeSpan ts = SocketClient.Ping();

            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.UpdateUserStatus);
            kv.Set(StdKv.CurrentUserID, userID);
            kv.Set("UserStatusID", (int)userStatus);
            kv.Set("Internet", ts.TotalSeconds);
            kv.Set("AccessCode", Options.Instance.ApplicationCode);

            SocketClient.Instance.InvokeAsync(kv.DataTable);
            Ap.CurrentUser.UserStatusIDE = userStatus;
            Ap.CurrentUser.StatusIDE = StatusE.Active;  

            SocketClient.AddSession();
        }
        public static DataSet LoginGuest()
        {
            return LoginGuest(Options.Instance.ApplicationCode); 
        }
        public static DataSet LoginGuest(string accessCode)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.LoginGuest);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("LoginId", "Guest");
            kv.Set("Password", "Guest");
            kv.Set("AccessCode", accessCode);

            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable.Copy());
            return ds;
        }

        public static void ForceLogoff(int userId)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.ForceLogoff);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("UserId", userId);

            SocketClient.Instance.InvokeAsync(kv.DataTable.Copy());
        }

        public static void LogoffUser()
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.LogoffUser);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("UserId", Ap.CurrentUserID);

            SocketClient.Instance.Invoke(kv.DataTable.Copy());
        }
    }
}
