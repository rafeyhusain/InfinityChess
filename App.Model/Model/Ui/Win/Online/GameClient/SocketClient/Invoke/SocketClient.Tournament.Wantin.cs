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

        public static void SaveWantinUsers(StatusE statusID,                                                    
                                                    TournamentUserStatusE TournamentUserStatusID,
                                                    int tournamentID,
                                                    string userIDs, 
                                                    string tournamentWantinUserIDs,
                                                    int teamID,
                                                    int eloBefore
                                                    )
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.SaveWantinUsers);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("StatusID", statusID.ToString("d"));
            kv.Set("TournamentUserStatusID", TournamentUserStatusID.ToString("d"));
            kv.Set("TournamentID", tournamentID);
            kv.Set("UserIDs", userIDs);
            kv.Set("TournamentWantinUserIDs", tournamentWantinUserIDs);
            kv.Set("TeamID", teamID);
            kv.Set("EloBefore", eloBefore);
            
            SocketClient.Instance.InvokeAsync(kv.DataTable.Copy());    
        
        }

        public static void UpdateWantinUsers(StatusE statusID,
                                                    TournamentUserStatusE TournamentUserStatusID,
                                                    int tournamentID,
                                                    string userIDs,
                                                    string tournamentWantinUserIDs)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.UpdateWantinUsers);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("StatusID", statusID.ToString("d"));
            kv.Set("TournamentUserStatusID", TournamentUserStatusID.ToString("d"));
            kv.Set("TournamentID", tournamentID);
            kv.Set("UserIDs", userIDs);
            kv.Set("TournamentWantinUserIDs", tournamentWantinUserIDs);

            SocketClient.Instance.InvokeAsync(kv.DataTable.Copy());

        }

        public static DataSet GetTournamentWantinUsers(int tournamentID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetTournamentWantinUser);

            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("TournamentID", tournamentID);

            return SocketClient.Instance.Invoke(kv.DataTable);
        }

        public static DataSet CreateTournamentWantinUser(int userID, int tournamentID, int teamID, TournamentUserStatusE tournamentUserStatusID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.CreateTournamentWantinUser);

            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("TournamentID", tournamentID);
            kv.Set("TeamID", teamID);
            kv.Set("UserID", userID);
            kv.Set("TournamentUserStatusID", tournamentUserStatusID.ToString("d"));

            return SocketClient.Instance.Invoke(kv.DataTable);
        }

        

    }
}
