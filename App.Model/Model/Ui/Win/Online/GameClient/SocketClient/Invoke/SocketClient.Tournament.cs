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

        public static DataSet SaveTournament(Kv  kv)
        {
            kv.Set("MethodName", (int)MethodNameE.SaveTournament);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);

            return SocketClient.Instance.Invoke(kv.DataTable);
        }

        public static DataSet GetAllTournaments(bool isAdmin)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetAllTournaments);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("IsAdmin", isAdmin);
            kv.Set("TournamentStatusId", (int)TournamentStatusE.Unknown);
            return SocketClient.Instance.Invoke(kv.DataTable);
        }

        public static DataSet GetAllTournamentsByStatus(TournamentStatusE ts)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetAllTournaments);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("TournamentStatusId", (int)ts);
            return SocketClient.Instance.Invoke(kv.DataTable);
        }

        public static DataSet GetAllForthcommingTournaments(TournamentStatusE ts)
        {
            return GetAllTournamentsByStatus(ts);
        }
        
        public static DataSet GetAllInprogressTournaments(TournamentStatusE ts)
        {
          return  GetAllTournamentsByStatus(ts);
        }

        public static DataSet GetAllFinishedTournaments(TournamentStatusE ts)
        {
            return GetAllTournamentsByStatus(ts);
        }

        public static DataSet DeleteTournament(string ids)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.DeleteTournament);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("Ids", ids);

            return SocketClient.Instance.Invoke(kv.DataTable);
        }

        public static DataSet GetNonDeletedTournament(int tournamentID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetNonDeletedTournament);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("TournamentID", tournamentID);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable);
            return ds;
        }

        public static DataSet GetTournamentCmbData()
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetTournamentCmbData);

            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);

            return SocketClient.Instance.Invoke(kv.DataTable);
        }

        public static Tournament GetTournamentByID(int tournamentID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetTournamentByID);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("TournamentID", tournamentID);

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

            Tournament t = new Tournament(Ap.Cxt, ds.Tables[0].Rows[0]);

            if (tournamentID > 0)
            {
                ds.Tables[0].Rows[0].AcceptChanges();
                ds.Tables[1].Rows[0].AcceptChanges();

                User u = new User(Ap.Cxt, ds.Tables[1].Rows[0]);

                t.CreatedUser = u;
            }

            return t;
        }
      
        public static DataSet TournamentStart(int tournamentID, TournamentStatusE tournamentStatusID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.TournamentStart);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);

            kv.Set("TournamentID", tournamentID);
            kv.Set("TournamentStatusID", tournamentStatusID.ToString("d"));


            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable);
            return ds;
            
        }

        public static void RescheduleTournament(int tournamentID, TournamentStatusE tournamentStatusID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.RescheduleTournament);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);

            kv.Set("TournamentID", tournamentID);
            kv.Set("TournamentStatusID", tournamentStatusID.ToString("d"));

            SocketClient.Instance.Invoke(kv.DataTable);
        }

        public static void TournamentFinish(int tournamentID, TournamentStatusE tournamentStatusID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.TournamentFinish);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);

            kv.Set("TournamentId", tournamentID);
            kv.Set("TournamentStatusID", tournamentStatusID.ToString("d"));

            SocketClient.Instance.Invoke(kv.DataTable);
        }

        public static DataSet GetTournamentResultById(int tournamentId)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetTournamentResultById);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("TournamentId", tournamentId);

            return SocketClient.Instance.Invoke(kv.DataTable);
        }
    }
}
