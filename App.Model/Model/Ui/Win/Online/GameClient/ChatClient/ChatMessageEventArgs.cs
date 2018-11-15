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

namespace App.Model
{
    #region enum
    public enum ChatMessageTypeE
    {
        Text, // any simple message for 1 or more users, like Hey all! come in Computer Chess Tournament Room
        Info,
        Warning, // Oppnent has already left
        Error, // Unable to connect server at this time
        Success,
        Failed,
        Inprogress,
        Private,
        EnteredRoom,
        LeftRoom,
        TournametInvitation,
        AdminMessage,
        TournamentResult,
        TournamentMatchResult
    }

    public enum ChatAudienceTypeE
    {
        Individual,
        Room,
        All,
        Kibitzer,
        KibitzerPlayer
    }

    public enum ChatTypeE
    {
        OnlineClient,
        GameWindow,
        AllWindows
    }
    #endregion

    public partial class ChatMessageEventArgs
    {
        #region Data Members
        public Cxt Cxt;
        public ChatMessageTypeE Type = ChatMessageTypeE.Text;
        public ChatTypeE ChatType = ChatTypeE.OnlineClient;
        public string Message = "";
        public int GameID = 0;
        #endregion

        #region Ctor
        public ChatMessageEventArgs()
        {
          
        }
        
        #endregion

    }
}
