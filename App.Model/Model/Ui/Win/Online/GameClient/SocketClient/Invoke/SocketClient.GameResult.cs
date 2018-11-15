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
        public static void ThreefoldRepetition(int gameId, string gameXml, GameResultE gameResult, int opponentUserID, string flags)
        {
            Kv kv = new Kv();
            
            kv.Set("MethodName", (int)MethodNameE.ThreefoldRepetition);
            kv.Set("OpponentUserID", opponentUserID);
            kv.Set("GameID", gameId);
            kv.Set("GameXml", gameXml);
            kv.Set("GameResult", (int)gameResult);
            kv.Set("GameFlags", flags);

            SocketClient.Instance.InvokeAsync(kv.DataTable);
        }

        public static void NewGame(int methodID, int opponentUserID, int userID, int challengeID)
        {
            Kv kv = new Kv();

            kv.Set("MethodName", (int)MethodNameE.NewGame);
            kv.Set("OpponentUserID", opponentUserID);
            kv.Set("NewGame", methodID);
            if (methodID == (int)NewGameE.Accepted)
            {
                kv.Set(StdKv.CurrentUserID, userID);
                kv.Set("ChallengeID", challengeID);
            }

            SocketClient.Instance.InvokeAsync(kv.DataTable);
        }

        public static void Resign(int gameId, GameResultE gameResult, int opponentUserID, string flags) 
        {
            Kv kv = new Kv();

            kv.Set("MethodName", (int)MethodNameE.Resign);
            kv.Set("OpponentUserID", opponentUserID);
            kv.Set("GameID", gameId);
            kv.Set("GameXml", "");
            kv.Set("GameResult", (int)gameResult);
            kv.Set("GameFlags", flags);

            SocketClient.Instance.InvokeAsync(kv.DataTable);
        }

        public static void Draw(int methodID, int gameID, GameResultE gameResult, int opponentUserID, string flags)
        {
            Kv kv = new Kv();

            kv.Set("MethodName", (int)MethodNameE.Draw);
            kv.Set("OpponentUserID", opponentUserID);
            kv.Set("Draw", methodID);
            if (methodID == (int)DrawE.Accepted)
            {
                kv.Set("GameID", gameID);
                kv.Set("GameXml", "");
                kv.Set("GameResult", (int)gameResult);
                kv.Set("GameFlags", flags);
            }

            SocketClient.Instance.InvokeAsync(kv.DataTable);
        }

        public static void TimeExpired(int gameId, GameResultE gameResult, int opponentUserID, string flags)
        {
            Kv kv = new Kv();

            kv.Set("MethodName", (int)MethodNameE.TimeExpired);
            kv.Set("OpponentUserID", opponentUserID);
            kv.Set("GameID", gameId);
            kv.Set("GameXml", "");
            kv.Set("GameResult", (int)gameResult);
            kv.Set("GameFlags", flags);

            SocketClient.Instance.InvokeAsync(kv.DataTable);
        }

        public static void KingStaleMated(int gameId, string gameXml, GameResultE gameResult, int opponentUserID, string flags)
        {
            Kv kv = new Kv();

            kv.Set("MethodName", (int)MethodNameE.KingStaleMated);
            kv.Set("OpponentUserID", opponentUserID);
            kv.Set("GameID", gameId);
            kv.Set("GameXml", gameXml);
            kv.Set("GameResult", (int)gameResult);
            kv.Set("GameFlags", flags);

            SocketClient.Instance.InvokeAsync(kv.DataTable);
        }

        public static void Abort(int gameId, string gameXml, GameResultE gameResult, int opponentUserID, string flags)
        {
            Kv kv = new Kv();

            kv.Set("MethodName", (int)MethodNameE.Abort);
            kv.Set("OpponentUserID", opponentUserID);
            kv.Set("GameID", gameId);
            kv.Set("GameXml", gameXml);
            kv.Set("GameResult", (int)gameResult);
            kv.Set("GameFlags", flags);

            SocketClient.Instance.InvokeAsync(kv.DataTable);

        }
    }
}
