using System;
using App.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfinityChess;
using System.IO;
using InfinitySettings.Streams;
//using InfinityChess.Offline.Forms;
using System.Data;

namespace App.Model
{
    public partial class Game
    {
        #region Data Members
        public DataTable Audience = null;
        #endregion

        public void StartOlineKibitzing()
        {
            Stop();
            LoadOnlineKibitzing();
            DoStart();
        }

        public void LoadOnlineKibitzing()
        {
            // FilePathOpeningBook = Ap.FolderSettings + @"Books\" + InfinitySettings.Settings.DefaultOpeningBook;
            GameMode = GameMode.Kibitzer;
            GameType = (GameType)DbGame.GameTypeID;
            GameTime.Set(DbGame);
            GameResult = DbGame.GameResultIDE; //GameResultE.InProgress;

            Player1.PlayerType = PlayerType.Human;
            Player1.PlayerTitle = DbGame.WhiteUser.UserName;
            Player2.PlayerType = PlayerType.Human;
            Player2.PlayerTitle = DbGame.BlackUser.UserName;

            if (DbGame.IsRated)
            {
                gameTypeTitle = GameType.ToString() + " " + DbGame.TimeMinute.ToString() + "m + " + DbGame.TimeSecond.ToString() + "s, " + "Rated";

                if (DbGame.EloBlackBefore != 0 && !DbGame.BlackUser.IsGuest)
                    Player2.PlayerTitle += " " + DbGame.EloBlackBefore.ToString();

                if (DbGame.EloWhiteBefore != 0 && !DbGame.WhiteUser.IsGuest)
                    Player1.PlayerTitle += " " + DbGame.EloWhiteBefore.ToString();

            }
            else
            {
                gameTypeTitle = GameType.ToString() + " " + DbGame.TimeMinute.ToString() + "m + " + DbGame.TimeSecond.ToString() + "s, " + "Unrated";
            }
        }

    }
}
