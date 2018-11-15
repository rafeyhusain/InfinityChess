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
                case GameType.Bullet:
                case GameType.Blitz:
                case GameType.Rapid:
                case GameType.NoClock:
                    GameData.OptionsBlitzClock = Ap.OptionsBlitzClock.Kv.ToDataTableString;
                    break;
                case GameType.Long:
                    GameData.OptionsLongClock = Ap.OptionsLongClock.Kv.ToDataTableString;
                    break;
            }
            if (GameMode == GameMode.Kibitzer)
            {
                GameData.GameMode = GameMode.HumanVsHuman;
            }
            else
            {
                GameData.GameMode = GameMode;
            }

            GameData.GameType = GameType;
            
            /////////////////
            GameData.Flags = this.Flags.Flags;
            GameData.GameResult = this.GameResult;
            /////////////////

            return UData.ToString(GameData.Kv.DataTable);
        }

        public string GetGameXml(GameData gameData)
        {
            if (gameData == null)
            {
                return "";
            }
            return UData.ToString(gameData.Kv.DataTable);
        }

        
        public void SaveGame(string filename)
        {
            GameData.Guid = string.Empty;
            string gameXml = GetGameXml();
            if (gameXml != "")
            {
                Ap.LoadDatabase(filename);
                Ap.Database.AppendGame(gameXml);
                Ap.Database.Save();
            }
        }

        public void SaveEmptyGame(string filename)
        {
            Ap.LoadDatabase(filename);
        }

        #endregion
    }
}
