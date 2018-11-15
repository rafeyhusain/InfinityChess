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

        public static DataSet UpdateTournamentMatchStatus(TournamentMatchStatusE tournamentMatchStatusID, int tournamentID, string matchIDs)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.UpdateTournamentMatchStatus);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("TournamentMatchStatusID", tournamentMatchStatusID.ToString("d"));
            kv.Set("TournamentID", tournamentID);
            kv.Set("MatchIDs", matchIDs);

            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable);
            return ds;
        }

        public static void RestartGame(int tournamentID, string matchIDs, int tournamentDirectorID, int senderUserID, int receiverUserID, ResetGameE resetGameID, bool isResetFromLastMove, string gameXml)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.RestartGame);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("TournamentDirectorID", tournamentDirectorID);
            kv.Set("TournamentID", tournamentID);
            kv.Set("MatchIDs", matchIDs);
            kv.Set("SenderUserID", senderUserID);
            kv.Set("ReceiverUserID", receiverUserID);
            kv.Set("ResetGame", (int)resetGameID);
            kv.Set("IsResetFromLastMove", isResetFromLastMove);
            kv.Set("GameXml", gameXml);
            SocketClient.Instance.InvokeAsync(kv.DataTable);
        }

        public static DataSet GetTournamentMatches(int tournamentId,TournamentTypeE tournamentType)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetTournamentMatchs);

            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("TournamentId", tournamentId);
            kv.Set("TournamentTypeId", (int)tournamentType);

            return SocketClient.Instance.Invoke(kv.DataTable);
        }

        public static DataSet CreateTournamentRounds(int tId, int round)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.CreateTournamentRounds);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("TId", tId);
            kv.Set("CurrentRound", round);

            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable);
            return ds;
        }

        public static DataSet IsKnockOutTournamentCompleted(int tId, int round)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.IsKnockOutTournamentCompleted);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("TId", tId);
            kv.Set("CurrentRound", round);

            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable);
            return ds;
        }

        public static DataSet StartTournamentRound(int tId)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.StartTournamentRound);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("TId", tId);

            return SocketClient.Instance.Invoke(kv.DataTable);
        }

        public static int GetGameIDByTournamentMatchID(int tournamentMatchID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetGameIDByTournamentMatchID);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("TournamentMatchID", tournamentMatchID);

            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable);

            if (ds == null)
            {
                return 0;
            }

            if (ds.Tables.Count == 0)
            {
                return 0;
            }

            if (ds.Tables[0].Rows.Count == 0)
            {
                return 0;
            }

            return BaseItem.GetColInt32(ds.Tables[0].Rows[0], "GameID", 0);
        }

        public static DataSet SaveTournamentMatch(Kv kv)
        {
            kv.Set("MethodName", (int)MethodNameE.SaveTournamentMatch);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);

            return SocketClient.Instance.Invoke(kv.DataTable);
        }

        public static DataSet GetTournamntMatchByParentID(int parentMatchID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetTournamntMatchByParentID);

            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("ParentMatchID", parentMatchID);

            return SocketClient.Instance.Invoke(kv.DataTable);
        }


    }
}
