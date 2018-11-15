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
    #region Enum
    public enum AvChatStateE
    {
        Idle,
        Handshaking,
        Talking,
    }

    public enum AvChatTypeE
    {
        Audio,
        Video
    }

    public enum AvChatE
    {
        None = 0,
        Asked = 1,
        Accepted = 2,
        Declined = 3,
        Busy = 4,
        NoService = 5
    }
   
	#endregion

    public partial class SocketClient
    {
        public static void SendAvRequest(int toUserID, string toUserName, AvChatTypeE type, ChatTypeE clientWindow)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.AvChat);
            kv.Set("AvChat",(int) AvChatE.Asked);
            kv.Set("AvChatType", (int) type);
            kv.Set("FromUserID", Ap.CurrentUserID);
            kv.Set("FromUserName", Ap.CurrentUser.UserName);
            kv.Set("ToUserID", toUserID);
            kv.Set("ToUserName", toUserName);
            kv.Set("ClientWindow", (int)clientWindow);  
            SocketClient.Instance.InvokeAsync(kv.DataTable);
        }

        public static void AcceptAvRequest(int fromUserID, string fromUserName, AvChatTypeE type, ChatTypeE clientWindow)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.AvChat);
            kv.Set("AvChat", (int)AvChatE.Accepted);
            kv.Set("AvChatType", (int)type);
            kv.Set("FromUserID", fromUserID );
            kv.Set("FromUserName", fromUserName);
            kv.Set("ToUserID", Ap.CurrentUserID);
            kv.Set("ToUserName", Ap.CurrentUser.UserName);
            kv.Set("ClientWindow", (int)clientWindow);
            SocketClient.Instance.InvokeAsync(kv.DataTable);
        }

        public static void SendAvResponse(Kv kv)
        {
            SocketClient.Instance.InvokeAsync(kv.DataTable);   
        }
    }
}
