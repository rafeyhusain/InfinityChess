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
       
        public static User GetUserRating(int userID)
        {
            return new User();
        }

        public static User GetUserRating(string userName)
        {
            return new User();
        }

        public static DataSet CheckUserId(string txtLoginId)
        {
            Kv kv1 = new Kv();
            kv1.Set("MethodName", (int)MethodNameE.CheckUserId);
            kv1.Set("LoginId", txtLoginId);
            DataSet ds = SocketClient.Instance.Invoke(kv1.DataTable.Copy());
            return ds;

        }

        public static DataSet GetUserById(int userID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetUserById);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("UserID", userID);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable);

            return ds;
        }

        public static DataSet GetUserInfoByUserID(int userID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetUserInfoByUserID);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("UserID", userID);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable.Copy());
            return ds;
        }

        public static DataSet GetUserPicture()
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetUserPicture);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("UserID", Ap.CurrentUserID);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable.Copy());
            return ds;
        }

        public static DataSet ForgotPassword(string txtUserName)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.ForgotPassword);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("UserName", txtUserName);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable.Copy());
            return ds;
        }

        public static DataSet ChangePassword(string txtPassword, string txtPasswordHint)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.ChangePassword);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("UserId", Ap.CurrentUserID);
            kv.Set("Password", UCrypto.Encrypt(txtPassword));
            kv.Set("PasswordHint", txtPasswordHint);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable.Copy());
            return ds;
        }

        public static void SetUserEngine(string engineName, UserStatusE userStatus)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.SetUserEngine);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("UserID", Ap.CurrentUserID);
            kv.Set("EngineName", engineName);
            kv.Set("UserStatus", (int)userStatus);
            SocketClient.Instance.InvokeAsync(kv.DataTable.Copy());
        }

        public static DataSet GetSetIntruptedGameUserEngine(int engineId, UserStatusE userStatus)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetSetIntruptedGameUserEngine);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("UserID", Ap.CurrentUserID);
            kv.Set("EngineID", engineId);
            kv.Set("UserStatusID", (int)userStatus);
            return SocketClient.Instance.Invoke(kv.DataTable.Copy());
        }

        public static void UserLeaveGame(UserStatusE userStatus, int gameID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.UserLeaveGame);
            kv.Set("GameID", gameID);
            kv.Set("UserStatus", (int)userStatus);
            kv.Set(StdKv.CurrentUserID, App.Model.Ap.CurrentUserID);
            SocketClient.Instance.InvokeAsync(kv.DataTable);
        }

        public static void KickUser(int SelectedUserId)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.KickUser);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("UserID", SelectedUserId);
            SocketClient.Instance.InvokeAsync(kv.DataTable);
        }

        public static DataSet GetServerTime()
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetServerTime);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable);
            return ds;
        }

        public static void BlockIP(int SelectedUserId)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.BlockIP);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("UserID", SelectedUserId);
            SocketClient.Instance.InvokeAsync(kv.DataTable);
        }

        public static DataSet UserByName(string userName)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.UserByName);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("UserName", userName);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable);
            return ds;
        }

        public static void SystemInformation(int opponentUserID, ChatTypeE chatType)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.SystemInformation);
            kv.Set("ChatType", (int)chatType);
            kv.Set("FromUserID", Ap.CurrentUserID);
            kv.Set("ToUserID", opponentUserID);
            SocketClient.Instance.InvokeAsync(kv.DataTable);

        }

        public static void PauseUser(bool chkPause)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.PauseUser);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("UserID", Ap.CurrentUserID);
            kv.Set("IsPause", chkPause);
            SocketClient.Instance.InvokeAsync(kv.DataTable.Copy());
        }

        public static DataSet AddUser(UserDataKv UserKv)
        {
            UserKv.Kv.Set("MethodName", (int)MethodNameE.AddUser);
            DataSet ds = SocketClient.Instance.Invoke(UserKv.Kv.DataTable.Copy());
            return ds;
        }

        public static DataSet BanUser(UserDataKv KvUserData)
        {
            KvUserData.Kv.Set("MethodName", (int)MethodNameE.BanUser);
            KvUserData.Kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            KvUserData.StatusIDE = StatusE.Ban;
            
            DataSet ds = SocketClient.Instance.Invoke(KvUserData.Kv.DataTable);
            return ds;
        }

        public static DataSet UpdateUser(UserDataKv Kv)
        {
            Kv.Kv.Set("MethodName", (int)MethodNameE.UpdateUser);
            Kv.Kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            DataSet ds = SocketClient.Instance.Invoke(Kv.Kv.DataTable);
            return ds;
        }

        public static DataSet GetRankInfo(int userID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetRankInfo);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("UserID", userID);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable.Copy());
            return ds;
        }

        public static void IdleUser(bool chkIdle)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.IdleUser);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("UserID", Ap.CurrentUserID);
            kv.Set("IsIdle", chkIdle);
            SocketClient.Instance.InvokeAsync(kv.DataTable.Copy());
        }

        public static void BlockMachine(int SelectedUserId)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.BlockMachine);
            kv.Set("BlockMachineE", (int) BlockMachineE.Initialized);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("UserID", SelectedUserId);
            kv.Set("MachineKey", String.Empty);
            SocketClient.Instance.InvokeAsync(kv.DataTable);
        }
        public static DataSet GetAllUserByID()
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetAllUserByID);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable.Copy());
            return ds;
        }
        public static DataSet GetAllBanUser()
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetAllBanUser);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable.Copy());
            return ds;
        }
        public static DataSet GetAllBanUserMachine()
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetAllBanUserMachine);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable.Copy());
            return ds;
        }
        public static DataSet GetAllAdmin()
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetAllAdmin);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable.Copy());
            return ds;
        }
        public static void UpdateBanStatus(StatusE statusID, string userIds)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.UpdateBanStatus);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("UserIDs", userIds);
            kv.Set("StatusID", statusID.ToString("d"));
            //kv.Set("BanMachineKey", WmiHelper.GetMachineKey());
            SocketClient.Instance.InvokeAsync(kv.DataTable.Copy());
        }
        public static void MakeAdmin(string userIDs, RankE humanRankID, RoleE roleID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.MakeAdmin);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("UserIDs", userIDs);
            kv.Set("HumanRankID", humanRankID.ToString("d"));
            kv.Set("RoleID", roleID.ToString("d"));
            SocketClient.Instance.InvokeAsync(kv.DataTable.Copy());
        }
        public static void RevokeAdmin(string userIDs, RankE humanRankID, RoleE roleID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.RevokeAdmin);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("UserIDs", userIDs);
            kv.Set("HumanRankID", humanRankID.ToString("d"));
            kv.Set("RoleID", roleID.ToString("d"));
            SocketClient.Instance.InvokeAsync(kv.DataTable.Copy());
        }
        
    }
}
