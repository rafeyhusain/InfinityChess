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
    partial class SocketClient
    {

        public static DataSet AddPrize(Kv kv)
        {
            kv.Set("MethodName", (int)MethodNameE.AddPrize);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);

            return SocketClient.Instance.Invoke(kv.DataTable);
        }

        public static DataSet GetPrizesByTournamentID(int tournamentID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetPrizesByTournamentID);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);

            kv.Set("TournamentID", tournamentID);

            return SocketClient.Instance.Invoke(kv.DataTable);
        }

        public static DataSet DeleteTournamentPrize(string tournamentPrizeIDs)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.DeleteTournamentPrize);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("TournamentPrizeIDs", tournamentPrizeIDs);

            return SocketClient.Instance.Invoke(kv.DataTable);
        }

        public static DataSet GetTournamentPrizeCategories()
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetTournamentPrizeCategories);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);

            return SocketClient.Instance.Invoke(kv.DataTable);
        }
    }
}
