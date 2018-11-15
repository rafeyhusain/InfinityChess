using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace App.Model
{
    public partial class SocketClient
    {
        public static void ServerMessage()
        {
            ChatClient.Write(ChatTypeE.OnlineClient, ChatMessageTypeE.Failed, ChatTypeE.OnlineClient, DateTime.Now.ToString("[h:mmtt]:") + "Unable to connect to server", 0);
        }
    }
}
