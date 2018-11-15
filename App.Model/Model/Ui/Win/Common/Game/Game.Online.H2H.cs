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
        public void StartOlineH2H()
        {
            Stop();
            LoadOnlineH2H();
            DoStart();
        }

        public void LoadOnlineH2H()
        {
            // FilePathOpeningBook = Ap.FolderSettings + @"Books\" + InfinitySettings.Settings.DefaultOpeningBook;
            GameMode = GameMode.OnlineHumanVsHuman;
            GameType = (GameType)DbGame.GameTypeID;
            GameTime.Set(DbGame);
            GameResult = GameResultE.InProgress;

            Player1.PlayerType = PlayerType.Human;
            Player2.PlayerType = PlayerType.Human;

            Player1.PlayerTitle = DbGame.WhiteUser.UserName + " " + DbGame.WhiteUser.Engine.Name;
            Player2.PlayerTitle = DbGame.BlackUser.UserName + " " + DbGame.BlackUser.Engine.Name;

            if (DbGame.IsTournamentMatch)
                gameTypeTitle = DbGame.TournamentMatch.Tournament.Name;

            if (DbGame.IsRated)
            {
                gameTypeTitle = gameTypeTitle + " " + GameType.ToString() + " " + DbGame.TimeMinute.ToString() + "m + " + DbGame.TimeSecond.ToString() + "s, " + "Rated";

                if (DbGame.EloBlackBefore != 0 && !DbGame.BlackUser.IsGuest)
                    Player2.PlayerTitle += " " + DbGame.EloBlackBefore.ToString();

                if (DbGame.EloWhiteBefore != 0 && !DbGame.WhiteUser.IsGuest)
                    Player1.PlayerTitle += " " + DbGame.EloWhiteBefore.ToString();
            }
            else
            {
                gameTypeTitle = gameTypeTitle + " " + GameType.ToString() + " " + DbGame.TimeMinute.ToString() + "m + " + DbGame.TimeSecond.ToString() + "s, " + "Unrated";
            }
        }

    }
}
