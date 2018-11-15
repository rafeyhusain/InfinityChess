using System;
using App.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfinityChess;
using System.IO;
using InfinitySettings.Streams;
//using InfinityChess.Forms;

namespace App.Model
{
    public partial class Game
    {
        //public void Start(InfinityChess.TournamentManager.Tournament tournament)
        //{
        //    Load(tournament);
        //    DoStart();
        //}

        //public void Load(InfinityChess.TournamentManager.Tournament t)
        //{
        //    FilePathOpeningBook = Ap.FolderSettings + @"Books\" + InfinitySettings.Settings.DefaultOpeningBook;

        //    GameType = t.GameType;

        //    this.GameTime.Set(t);

        //    GameMode = t.GameMode;

        //    Player1.Engine.HashTableSize = InfinitySettings.Settings.DefaultHashTableSize;
        //    Player2.Engine.HashTableSize = InfinitySettings.Settings.DefaultHashTableSize;

        //    Player1.Title = t.Participant1.Name;
        //    Player1.PlayerType = t.Participant1PlayerType;

        //    Player2.Title = t.Participant2.Name;
        //    Player2.PlayerType = t.Participant2PlayerType;

        //    switch (GameMode)
        //    {
        //        case GameMode.None:
        //            break;
        //        case GameMode.HumanVsHuman:
        //            break;
        //        case GameMode.HumanVsEngine:
        //            Player2EngineFileName = t.Participant2.Name + ".exe";
        //            break;
        //        case GameMode.EngineVsEngine:
        //            Player1EngineFileName = t.Participant1.Name + ".exe";
        //            Player2EngineFileName = t.Participant2.Name + ".exe";
        //            break;
        //        default:
        //            break;
        //    }

        //    //this.GameData.White1 = t.Participant1.Name;
        //    //this.GameData.Black1 = t.Participant2.Name;
        //    //this.GameData.Save();  
        //}
    }
}
