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
        public static EventHandler Reconnected = null;

        public static TimeSpan Ping()
        {
            DateTime start = DateTime.Now;

            DataSet ds = DoPing();
            DateTime end = DateTime.Now;
            TimeSpan ts = end.Subtract(start);

            if (ds.Tables.Count > 0)
            {
                ChatClient.Write(ChatTypeE.OnlineClient, ChatMessageTypeE.Success, ChatTypeE.OnlineClient, "Reply from server in Time=" + Math.Round(ts.TotalSeconds, 2).ToString() + "s",0);
            }

            return ts;
        }

        /// <summary>
        /// Returns false if there is no need for reconnection or
        /// unable to reconnect
        /// </summary>
        /// <param name="chatType"></param>
        /// <returns></returns>
        public static bool ReconnectIfRequired(ChatTypeE chatType)
        {
            if (SocketClient.Instance.IsNotConnected)
            {
                return SocketClient.Reconnect(ChatTypeE.OnlineClient);
            }

            return false;
        }

        public static void ReconnectASync(ChatTypeE chatType)
        {
            Thread t = new Thread(new ParameterizedThreadStart(DoReconnectASync));

            t.Start(chatType);
        }

        private static void DoReconnectASync(object chatType)
        {
            ChatTypeE type = (ChatTypeE)chatType;

            Reconnect(type);
        }

        public static bool Reconnect(ChatTypeE chatType)
        {
            if (SocketClient.Instance.IsConnected)
            {
                ChatClient.Write(chatType, ChatMessageTypeE.Success, chatType, "Already connected",0);

                return false; // Not reconnected
            }
            else
            {
                ChatClient.Write(chatType, ChatMessageTypeE.Inprogress, chatType, "Reconnecting...", 0);
                ChatClient.Write(ChatTypeE.GameWindow, ChatMessageTypeE.Inprogress, ChatTypeE.GameWindow, "Reconnecting...", 0);

                if (SocketClient.Instance.Connect())
                {
                    SocketClient.LoginUser(Ap.CurrentUserID, Ap.CurrentUser.UserStatusIDE);
                    ChatClient.Write(chatType, ChatMessageTypeE.Success, chatType, "Connected", 0);
                    ChatClient.Write(ChatTypeE.GameWindow, ChatMessageTypeE.Success, ChatTypeE.GameWindow, "Connected", 0);
                    ChatClient.Send(ChatAudienceTypeE.Room, ChatMessageTypeE.Success, ChatTypeE.AllWindows, Ap.CurrentUser.RoomID, "'" + Ap.CurrentUser.UserName + "' is connected", 0);
                }
                else
                {
                    string msg = DateTime.Now.ToString("[h:mmtt]:") + "Unable to connect to server";

                    ChatClient.Write(chatType, ChatMessageTypeE.Failed, chatType, msg, 0);
                    ChatClient.Write(ChatTypeE.GameWindow, ChatMessageTypeE.Failed, ChatTypeE.GameWindow, msg, 0);
                    return false; // Not reconnected
                }
            }

            if (Reconnected != null)
            {
                Reconnected(SocketClient.Instance, EventArgs.Empty);
            }

            return true; // Reconnected!
        }

        public static DataSet DoPing()
        {
            DataSet ds = null;
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.Ping);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            ds = SocketClient.Instance.Invoke(kv.DataTable.Copy());

            return ds;
        }

        public static void HeartbeatPing()
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.HeartbeatPing);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            SocketClient.Instance.InvokeAsync(kv.DataTable);
        }

        public static void PingReply()
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.PingClient);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);

            SocketClient.Instance.InvokeAsync(kv.DataTable.Copy());
        }

        public static void AddSession()
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.AddSession);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            SocketClient.Instance.Invoke(kv.DataTable);
            UpdateSession();
        }

        public static void UpdateSession()
        {
            
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.UpdateSession);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            SocketClient.Instance.InvokeAsync(kv.DataTable);

        }
    }
}
