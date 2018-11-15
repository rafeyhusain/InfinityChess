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
        public static DataSet GetAllRooms()
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetAllRooms);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable.Copy());
            return ds;
        }
        public static DataSet GetNews()
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetNews);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable.Copy());
            return ds;
        }
        public static DataSet GetKeyValues()
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetKeyValues);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable.Copy());
            return ds;
        }
        public static DataSet GetRoomUsersCount()
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetRoomUsersCount);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable.Copy());
            return ds;
        }
        public static DataSet GetGamesByUserID(int uID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetGamesByUserID);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("UserID", uID);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable.Copy());
            return ds;
        }
        public static DataSet GetUsersByGameType(ChessTypeE chessType, GameType gameType)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetUsersByGameType);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("ChessTypeID", (int)chessType);
            kv.Set("GameTypeID", (int)gameType);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable.Copy());
            return ds;
        }
        public static DataSet GamesByUserName(string uName)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GamesByUserName);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("UserName", uName);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable.Copy());
            return ds;
        }
        public static DataSet HighestRankingPlayerGame()
        {
            Kv kvPlayer = new Kv();
            kvPlayer.Set("MethodName", (int)MethodNameE.HighestRankingPlayerGame);
            kvPlayer.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            DataSet dsPlayer = SocketClient.Instance.Invoke(kvPlayer.DataTable.Copy());
            return dsPlayer;
        }
        public static void GetDataByRoomID(bool isFromTimer, int selectedRoomId, int userID)
        {
            if (SocketClient.Instance.Retries > 2)
            {
                Reconnect(ChatTypeE.OnlineClient);
            }

            if (SocketClient.Instance.IsConnected)
            {
                Kv kv = new Kv();
                kv.Set("MethodName", (int)MethodNameE.GetDataByRoomID);
                kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
                kv.Set("IsFromTimer", isFromTimer);
                kv.Set("RoomId", selectedRoomId);
                kv.Set("UserId", userID);
                kv.Set("UserStatus", Ap.CurrentUser.UserStatusID);
                kv.Set("EngineID", Ap.CurrentUser.EngineID);
                SocketClient.Instance.InvokeAsync(kv.DataTable.Copy());
            }
            else
            {
                SocketClient.Instance.Retries += 1; 
            }
        }

        public static DataSet UpdateFormula(UserFormulaDataKv formulaKv)
        {
            formulaKv.Kv.Set("MethodName", (int)MethodNameE.UpdateFormula);
            formulaKv.Kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            formulaKv.Kv.Set("RoomID", Ap.CurrentUser.RoomID);
            DataSet ds = SocketClient.Instance.Invoke(formulaKv.Kv.DataTable.Copy());
            return ds;
        }

        public static DataSet GetUserFormula(int userID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetUserFormula);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("UserId", userID);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable.Copy());
            return ds;
        }

        public static DataSet GetAvailablePatches(string version)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetAvailablePatches);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("Version", version);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable.Copy());
            return ds;
        }
    }
}
