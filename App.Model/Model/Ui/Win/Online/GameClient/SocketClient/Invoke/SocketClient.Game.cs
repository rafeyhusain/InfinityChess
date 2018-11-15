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
        public static DataSet AddGameData(int challengeID, int chessTypeID)
        {
            return AddGameData(challengeID, Ap.CurrentUserID, chessTypeID);
        }

        public static DataSet AddGameData(int challengeID, int currentUserID, int chessTypeID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.AddGameData);
            kv.Set(StdKv.CurrentUserID, currentUserID);
            kv.Set("ChessTypeID", chessTypeID);
            kv.Set("ChallengeID", challengeID);
            kv.DataTable.TableName = "AddGameData";

            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable);

            return ds;
        }
        public static DataSet GetGameDataByChallengeID(int challengeID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetGameDataByChallengeID);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("ChallengeID", challengeID);

            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable);
            return ds;
        }

        public static DataSet GetGameDataByGameID(int gameId)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetGameDataByGameID);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("gameId", gameId);

            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable);
            return ds;
        }

        public static DataSet GetLastInprogressGame(int userId)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetLastInprogressGame);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
       
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable);
            return ds;
        }

        public static void UpdateGameDataByGameID(int gameID, string lastMoveGameXml, GameResultE gameResult, string gameFlags, int opponentUserID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.UpdateGameDataByGameID);
            kv.Set("GameID", gameID);
            kv.Set("GameXml", lastMoveGameXml);
            kv.Set("GameResult", (int) gameResult);
            kv.Set("GameFlags", gameFlags);
            kv.Set("OpponentUserID", opponentUserID);
            SocketClient.Instance.InvokeAsync(kv.DataTable);
        }

        public static void RestartGameWithSetup(ResetGameE methodID, int gameID, int moveID, int senderUserID, int receiverUserID, 
            int wMin, int wSec, int bMin, int bSec, bool isTournamentDirector)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.RestartGameWithSetup);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("ResetGame", (int) methodID);
            kv.Set("GameID", gameID);
            kv.Set("MoveID", moveID);
            kv.Set("SenderUserID", senderUserID);
            kv.Set("ReceiverUserID", receiverUserID);
            kv.Set("WhiteMin", wMin);
            kv.Set("WhiteSec", wSec);
            kv.Set("BlackMin", bMin);
            kv.Set("BlackSec", bSec);
            kv.Set("IsTournamentDirector", isTournamentDirector);
            
            SocketClient.Instance.InvokeAsync(kv.DataTable);
        }

        public static void SetGamePositionByFen(string fen, int gameID, string lastMoveGameXml, int whiteUserID, int blackUserID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.SetGamePositionByFen);
            kv.Set("GameID", gameID);
            kv.Set("Fen", fen);
            kv.Set("GameXml", lastMoveGameXml);
            if (whiteUserID == Ap.CurrentUserID)
            {
                kv.Set("OpponentUserID", blackUserID);
            }
            else
            {
                kv.Set("OpponentUserID", whiteUserID);
            }
            SocketClient.Instance.InvokeAsync(kv.DataTable);
        }

        public static DataSet GetGameDataByTournamentMatchID(int tournamentMatchID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetGameDataByTournamentMatchID);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("TournamentMatchID", tournamentMatchID);

            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable);
            return ds;
        }

    }
}
