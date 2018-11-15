using System;
using App.Model;
using System.Collections.Generic;
using System.Text;
using InfinityChess;
using System.IO;
using System.Data;
using InfinitySettings.Streams;

namespace App.Model
{
    public partial class Game
    {
        #region GameData

        public string GetGameXml()
        {
            if (GameData == null)
            {
                return "";
            }

            if (string.IsNullOrEmpty(GameData.Guid))
            {
                GameData.Guid = System.Guid.NewGuid().ToString();
            }
            
            GameData.InitialBoardFen = InitialBoardFen;

            GameData.Moves = UData.ToString(Notations.Game.Moves.DataTable);

            switch (GameType)
            {
                case GameType.BulletGame:
                case GameType.BlitzGame:
                case GameType.RapidGame:
                case GameType.NoClock:
                    GameData.OptionsBlitzClock = Ap.OptionsBlitzClock.Kv.ToDataTableString;
                    break;
                case GameType.LongGame:
                    GameData.OptionsLongClock = Ap.OptionsLongClock.Kv.ToDataTableString;
                    break;
            }

            GameData.GameMode = GameMode;
            GameData.GameType = GameType; 


            return UData.ToString(GameData.Kv.DataTable);
        }

        public void SaveGame(string filename)
        {
            string gameXml = GetGameXml();
            if (gameXml != "")
            {
                App.Model.Database database = new Database(filename);
                database.AppendGame(gameXml);
                database.Save();
            }
        }

        public void SaveEmptyGame(string filename)
        {
            App.Model.Database database = new Database(filename);
        }

        #endregion
    }
}
