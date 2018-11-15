using System;
using App.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfinityChess;
using System.IO;
using InfinitySettings.Streams;
//using InfinityChess.Offline.Forms;

namespace App.Model
{
    public partial class Game
    {
        public void UserLeaveGame(UserStatusE userStatus)
        {
            SocketClient.UserLeaveGame(userStatus, DbGame.GameID);
        }
    }
}
