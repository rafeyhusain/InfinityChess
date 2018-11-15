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
using App.Model.Db;
using System.Net.Sockets;
using System.Net;
using System.Collections;
using System.Threading;

namespace App.Model
{
    public partial class SocketClient
    {
        public static string AddAudienceAsync(string uData)
        { 
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.AddAudienceAsync);
            kv.Set("AudienceData", uData);
            string data = UData.ToString(kv.DataTable);
            return data;
        }
        public static string RemoveAudience(int userID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.RemoveAudience);
            kv.Set("UserID", userID);
            string data = UData.ToString(kv.DataTable);
            return data;
        }
        public static DataSet GetAudienceGameData(int gameID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetAudienceGameData);
            kv.Set(StdKv.CurrentUserID, App.Model.Ap.CurrentUserID);
            kv.Set("GameID", gameID);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable);
            return ds;
        }
        public static void AddAudience(int gameID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.AddAudience);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("UserID", Ap.CurrentUserID);
            kv.Set("GameID", gameID);
            SocketClient.Instance.Invoke(kv.DataTable.Copy());
        }
    }
}
