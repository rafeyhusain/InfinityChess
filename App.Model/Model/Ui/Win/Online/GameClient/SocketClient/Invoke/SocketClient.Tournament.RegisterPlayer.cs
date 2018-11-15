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

        public static DataSet SaveTournamentRegisteredUsers(StatusE statusID,                                                    
                                                    TournamentUserStatusE TournamentUserStatusID,
                                                    int tournamentID,
                                                    string userIDs,                                                     
                                                    int teamID,
                                                    int eloBefore
                                                    )
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.SaveTournamentRegisteredUsers);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("StatusID", statusID.ToString("d"));
            kv.Set("TournamentUserStatusID", TournamentUserStatusID.ToString("d"));
            kv.Set("TournamentID", tournamentID);
            kv.Set("UserIDs", userIDs);            
            kv.Set("TeamID", teamID);
            kv.Set("EloBefore", eloBefore);

            return SocketClient.Instance.Invoke(kv.DataTable);
        
        }

        public static DataSet GetTournamentRegisteredUser(StatusE statusID, int tournamentID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetTournamentRegisteredUser);

            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("TournamentID", tournamentID);
            kv.Set("StatusID", statusID.ToString("d"));
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable);
            return ds;
        }

        public static DataSet GetTournamentRegisterUser(UserStatusE userStatusID, int tournamentID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetTournamentRegisterUser);

            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("TournamentID", tournamentID);
            kv.Set("UserStatusID", userStatusID.ToString("d"));
            return SocketClient.Instance.Invoke(kv.DataTable);
        }

        public static DataSet GetTournamentTeamRegisteredUser(int TournamentID, int TeamID, UserStatusE UserStatusID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetTournamentTeamRegisteredUser);

            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("TournamentID", TournamentID);
            kv.Set("TeamID", TeamID);
            kv.Set("UserStatusID", UserStatusID.ToString("d"));            
            return SocketClient.Instance.Invoke(kv.DataTable);
        }

        public static DataSet UpdateReplacePlayer(int TournamentID, int userID, int userID2)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.UpdateReplacePlayer);

            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("TournamentID", TournamentID);
            kv.Set("UserID", userID);
            kv.Set("UserID2", userID2);
            return SocketClient.Instance.Invoke(kv.DataTable);
        }

    }
}
