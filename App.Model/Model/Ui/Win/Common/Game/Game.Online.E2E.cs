using System;
using App.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfinityChess;
using System.IO;
using InfinitySettings.Streams;
//using InfinityChess.Offline.Forms;
//using App.Win;

namespace App.Model
{
    public partial class Game
    {
        public void StartOlineE2E()
        {
            Stop();
            LoadOnlineE2E();
            DoStart();
        }

        public void LoadOnlineE2E()
        {
            FilePathOpeningBook = Ap.Options.CurrentBookFilePath;
            GameMode = GameMode.OnlineEngineVsEngine;
            GameType = (GameType)DbGame.GameTypeID;

            GameTime.Set(DbGame);

            GameResult = GameResultE.InProgress;

            Player1.PlayerTitle = DbGame.WhiteUser.UserName + " " + DbGame.WhiteUser.Engine.Name;
            Player2.PlayerTitle = DbGame.BlackUser.UserName + " " + DbGame.BlackUser.Engine.Name;
           
            if (DbGame.IsCurrentUserWhite)
            {
                if (PlayingMode.SelectedEngine != null)
                {
                    Player1EngineFileName = PlayingMode.SelectedEngine.EngineFile;
                    Player1.Engine.HashTableSize = PlayingMode.SelectedEngine.HashTableSize;
                }
                Player1.Book = PlayingMode.SelectedBook;
                Player1.PlayerType = PlayerType.Engine;

                Player2.PlayerType = PlayerType.Human;
                if (DbGame.EloBlackBefore != 0)
                    Player2.PlayerTitle += " " + DbGame.EloBlackBefore.ToString();
            }
            else
            {
                if (PlayingMode.SelectedEngine != null)
                {
                    Player2EngineFileName = PlayingMode.SelectedEngine.EngineFile;
                    Player2.Engine.HashTableSize = PlayingMode.SelectedEngine.HashTableSize;
                }
                Player2.Book = PlayingMode.SelectedBook;
                Player2.PlayerType = PlayerType.Engine;

                Player1.PlayerType = PlayerType.Human;
                if (DbGame.EloWhiteBefore != 0)
                    Player1.PlayerTitle += " " + DbGame.EloWhiteBefore.ToString();
            }

            //    Player1.Engine.HashTableSize = InfinitySettings.Settings.DefaultHashTableSize;

            if (DbGame.IsRated)
            {
                gameTypeTitle = GameType.ToString() + " " + DbGame.TimeMinute.ToString() + "m + " + DbGame.TimeSecond.ToString() + "s, " + "Rated";
            }
            else
            {
                gameTypeTitle = GameType.ToString() + " " + DbGame.TimeMinute.ToString() + "m + " + DbGame.TimeSecond.ToString() + "s, " + "Unrated";
            }
        }
    }
}
