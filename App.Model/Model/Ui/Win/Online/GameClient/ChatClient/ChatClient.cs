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
using System.Diagnostics;
namespace App.Model
{
    public partial class ChatClient
    {
        #region Data Members
        private static ChatClient cc = null;
        #endregion

        #region Events
        public delegate void ChateMessageReceivedEventHandler(object sender, ChatMessageEventArgs e);
        public event ChateMessageReceivedEventHandler ChatMessageReceived;
        #endregion

        #region Ctor
        public ChatClient()
        {
          
        }
        
        #endregion

        #region Instance
        public static ChatClient Instance
        {
            [DebuggerStepThrough]
            get
            {
                if (cc == null)
                {
                    cc = new ChatClient();
                }

                return cc;
            }
            set { cc = value; }
        }
        #endregion

        #region Write
        // write on your chat window
        private void WriteLine(ChatTypeE receiverType, ChatMessageTypeE type, ChatTypeE chatType, MsgE message, int gameId)
        {
            Write(receiverType, type, chatType, Msg.GetMsg(message), gameId);
        }

        private void WriteLine(ChatTypeE receiverType, ChatMessageTypeE type, ChatTypeE chatType, string message, int gameId)
        {
            if (receiverType != chatType)
            {
                return;
            }

            if (ChatMessageReceived != null)
            {
                ChatMessageEventArgs e = new ChatMessageEventArgs();

                e.Type = type;
                e.Message = message;
                e.ChatType = chatType;
                e.GameID = gameId;

                ChatMessageReceived(this, e);
            }
        }

        public static void Write(ChatTypeE receiverType, ChatMessageTypeE type, ChatTypeE chatType, string message, int gameId)
        {
            ChatClient.Instance.WriteLine(receiverType, type, chatType, message, gameId);
        }

        public static void Write(ChatTypeE receiverType, ChatMessageTypeE type, ChatTypeE chatType, MsgE message, int gameId)
        {
            ChatClient.Instance.WriteLine(receiverType, type, chatType, message, gameId);
        }
        #endregion

        #region Send
        public static void Send(ChatAudienceTypeE audienceType, ChatMessageTypeE messageType, ChatTypeE chatType, int id, string message, int gameID)
        {
            SocketClient.ChatMessage(audienceType, messageType, chatType, id, message, gameID);
        } 
        #endregion
    }
}
