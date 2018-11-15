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

        public static DataSet SaveTournamentTeam(string teamIDs, int tournamentID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.SaveTournamentTeam);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);

            kv.Set("TeamIDs", teamIDs);
            kv.Set("TournamentID", tournamentID);

            return SocketClient.Instance.Invoke(kv.DataTable);
        }

        public static DataSet DeleteTournamentTeam(string tournamentTeamIDs, int tournamentID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.DeleteTournamentTeam);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("TournamentTeamIDs", tournamentTeamIDs);
            kv.Set("TournamentID", tournamentID);
            
            return SocketClient.Instance.Invoke(kv.DataTable);
        }
        public static DataSet GetTeamsByTournamentID(int tournamentID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetTeamsByTournamentID);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("TournamentID", tournamentID);
            return SocketClient.Instance.Invoke(kv.DataTable);
        } 
        public static DataSet GetRecentTournamentTeam(int tournamentID)
        {

            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetRecentTournamentTeam);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("TournamentID", tournamentID);
            return SocketClient.Instance.Invoke(kv.DataTable);
        }        

    }
}
