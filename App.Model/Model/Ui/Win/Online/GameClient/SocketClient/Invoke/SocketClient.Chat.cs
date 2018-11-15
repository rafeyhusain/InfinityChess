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
        public static void ChatMessage(ChatAudienceTypeE audienceType, ChatMessageTypeE messageType, ChatTypeE chatType, int id, string message, int gameID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.ChatMessage);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("AudienceType", (int)audienceType);
            kv.Set("MessageType", (int)messageType);
            kv.Set("ChatType", (int)chatType);
            kv.Set("Id", id);
            kv.Set("Message", message);
            kv.Set("GameID", gameID);
            SocketClient.Instance.InvokeAsync(kv.DataTable);
        }
    }
}
