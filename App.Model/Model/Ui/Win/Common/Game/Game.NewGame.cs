using System;
using App.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfinityChess;
using System.IO;
using InfinitySettings.Streams;
using InfinitySettings.UCIManager;
using System.Data;
using System.Diagnostics;
using ChessLibrary;
using AppEngine;
using ChessBoardCtrl.New;
using App.Model.Fen;
using System.Windows.Forms;

namespace App.Model
{
    public partial class Game
    {
        #region NewGame
        public void NewGame(GameMode gameMode, GameType gameType)
        {
            NewGame(ChessLibrary.FenParser.InitialBoardFen, gameMode, gameType);  
        }

        public void NewGame(string fen, GameMode gameMode, GameType gameType)
        {
            NewGame(fen, gameMode, gameType, null, null);
        }

        public void NewGame(string fen, GameMode gameMode, GameType gameType, OptionsBlitzClock blitzClock, OptionsLongClock longClock)
        {
            Stop();

            InitialBoardFen = fen;
            GameMode = gameMode;
            GameType = gameType;

            if (BeforeNewGame != null)
            {
                BeforeNewGame(this, EventArgs.Empty);
            }
                     
            #region Init
            GameValidator = new GameW(this.InitialBoardFen);

            SpaceBarCounter = 0;

            CloseEngines();

            if (GameType == GameType.LongGame)
            {
                GameTime.Init(longClock, true);
            }
            else
            {
                GameTime.Init(blitzClock, true);
            }

            GameResult = GameResultE.InProgress;
            CurrentMove = null;

            Flags.Reset(); 
            #endregion

            #region Switch gameMode
            switch (GameMode)
            {
                case GameMode.None:
                    break;
                case GameMode.HumanVsHuman:
                    Player1.PlayerType = PlayerType.Human;
                    Player2.PlayerType = PlayerType.Human;

                    Player1.Engine = null;
                    Player2.Engine = null;

                    Player1.PlayerTitle = GameData.WhiteTitle;
                    Player2.PlayerTitle = GameData.BlackTitle;
                    break;
                case GameMode.HumanVsEngine:
                    Player1.PlayerType = PlayerType.Human;
                    Player2.PlayerType = PlayerType.Engine;
                    Player2EngineFileName = InfinitySettings.Settings.DefaultEngineXml.FilePath;
                    Player1.Engine = null;
                    if (DefaultEngine == null)
                    {
                        Player2.Engine = UCIEngine.Load(Player2EngineFileName, Options.DefaultHashTableSize);
                        Player2.Engine.UseTablebases = EngineParameters.UseTablebases;

                        DefaultEngine = Player2.Engine;
                    }
                    else
                    {
                        Player2.Engine = DefaultEngine;
                    }

                    Player2.Book = Book;
                    DefaultBook = Player2.Book;

                    Player1.PlayerTitle = Ap.UserProfile.LastName;
                    Player2.PlayerTitle = Player2.Engine.EngineName;

                    break;
                case GameMode.EngineVsEngine:
                    Player1.PlayerType = PlayerType.Engine;
                    Player2.PlayerType = PlayerType.Engine;

                    Player1.Engine = UCIEngine.Load(Player1EngineFileName, Player1EngineHashTableSize);
                    Player1.Engine.UseTablebases = EngineParameters.UseTablebases;

                    Player2.Engine = UCIEngine.Load(Player2EngineFileName, Player2EngineHashTableSize);
                    Player2.Engine.UseTablebases = EngineParameters.UseTablebases;

                    Player1.PlayerTitle = Player1.Engine.EngineName;
                    Player2.PlayerTitle = Player2.Engine.EngineName;
 
                    break;
                case GameMode.OnlineHumanVsHuman:
                    #region OnlineHumanVsHuman
                    StartOnlineH2HGame();
                    #endregion
                    break;
                case GameMode.OnlineHumanVsEngine:
                    break;
                case GameMode.OnlineEngineVsEngine:

                    if (PlayingMode.SelectedEngine == null)
                    {
                        StartOnlineH2HGame();
                    }
                    else
                    {
                        StartOnlineE2EGame();
                    }

                    break;
                case GameMode.Kibitzer:
                    #region Kibitzer
                    GameTime.Set(DbGame);
                    GameResult = DbGame.GameResultIDE; //GameResultE.InProgress;

                    Player1.PlayerType = PlayerType.Human;
                    Player1.PlayerTitle = DbGame.WhiteUser.UserName;
                    Player2.PlayerType = PlayerType.Human;
                    Player2.PlayerTitle = DbGame.BlackUser.UserName;

                    if (DbGame.IsRated)
                    {
                        gameTypeTitle = GameType.ToString() + " " + DbGame.TimeMin.ToString() + "m + " + DbGame.GainPerMoveMin.ToString() + "s, " + "Rated";

                        if (DbGame.EloBlackBefore != 0 && !DbGame.BlackUser.IsGuest)
                            Player2.PlayerTitle += " " + DbGame.EloBlackBefore.ToString();

                        if (DbGame.EloWhiteBefore != 0 && !DbGame.WhiteUser.IsGuest)
                            Player1.PlayerTitle += " " + DbGame.EloWhiteBefore.ToString();

                    }
                    else
                    {
                        gameTypeTitle = GameType.ToString() + " " + DbGame.TimeMin.ToString() + "m + " + DbGame.GainPerMoveMin.ToString() + "s, " + "Unrated";
                    }
                    #endregion
                    break;
                default:
                    break;
            } 
            #endregion

            if (DefaultEngine != null)
            {
                if (DefaultEngine.IsClosed)
                {
                    DefaultEngine.Load();
                }
            }

            Flags.IsEngineBlack = true;

            #region Start
        
            gameTypeTitle = Ap.GetGameTypeTitle(GameType);

            Player1.Active = true;
            Player2.Active = false;
                    
            Notations.SetupNewGame();
            CapturedPieces.SetupNewGame();
            Clock.SetupNewGame();
            Book.SetupNewGame();

            Clipboard.Reset();

            CurrentPlayer = Player1;

            GameData.SetupNewGame();


            if (Flags.IsChangeNamesAllowed)
            {
                GameData.White1 = Player1.PlayerTitle;
                GameData.White2 = Ap.UserProfile.FirstName;
                GameData.Black1 = Player2.PlayerTitle;
            }
            GameData.Tournament = GameTypeTitle;

            InitTablebases();

            Ap.Options.GameType = gameType;
            Ap.Options.Save();

          
            #endregion

            if (CreateDocking != null)
            {
                CreateDocking(this, EventArgs.Empty);
            }

            Flags.IsInfiniteAnalysisOn = false;
            SetFen(fen);

            if (Flags.IsOnline)
            {
               // Flags.IsChallengerSendsGame = Flags.IsPositionSetupAllowed;
            }

            if (AfterNewGame != null)
            {
                AfterNewGame(this, EventArgs.Empty);
            }
        }

        private void StartOnlineH2HGame()
        {
            GameTime.Set(DbGame);

            GameMode = GameMode.OnlineHumanVsHuman;

            Player1.PlayerType = PlayerType.Human;
            Player2.PlayerType = PlayerType.Human;

            Player1.PlayerTitle = DbGame.WhiteUser.UserName + " " + DbGame.WhiteUser.Engine.Name;
            Player2.PlayerTitle = DbGame.BlackUser.UserName + " " + DbGame.BlackUser.Engine.Name;

            if (DbGame.IsTournamentMatch)
            {
                gameTypeTitle = DbGame.TournamentMatch.Tournament.Name;
            }

            if (DbGame.IsRated)
            {
                gameTypeTitle = gameTypeTitle + " " + GameType.ToString() + " " + DbGame.TimeMin.ToString() + "m + " + DbGame.GainPerMoveMin.ToString() + "s, " + "Rated";

                if (DbGame.EloBlackBefore != 0 && !DbGame.BlackUser.IsGuest)
                    Player2.PlayerTitle += " " + DbGame.EloBlackBefore.ToString();

                if (DbGame.EloWhiteBefore != 0 && !DbGame.WhiteUser.IsGuest)
                    Player1.PlayerTitle += " " + DbGame.EloWhiteBefore.ToString();
            }
            else
            {
                gameTypeTitle = gameTypeTitle + " " + GameType.ToString() + " " + DbGame.TimeMin.ToString() + "m + " + DbGame.GainPerMoveMin.ToString() + "s, " + "Unrated";
            }
        }

        private void StartOnlineE2EGame()
        {
            FilePathOpeningBook = Ap.Options.CurrentBookFilePath;
            GameTime.Set(DbGame);
      
            Player1.PlayerTitle = DbGame.WhiteUser.UserName + " " + DbGame.WhiteUser.Engine.Name;
            Player2.PlayerTitle = DbGame.BlackUser.UserName + " " + DbGame.BlackUser.Engine.Name;

            if (DbGame.IsCurrentUserWhite)
            {
                Player1.Engine = UCIEngine.Load(PlayingMode.SelectedEngine.EngineFile, PlayingMode.SelectedEngine.HashTableSize);
                Player1.Engine.UseTablebases = EngineParameters.UseTablebases;

                DefaultEngine = Player1.Engine; 
                
                Player1.Book = PlayingMode.SelectedBook;
                Player1.PlayerType = PlayerType.Engine;


                Player2.PlayerType = PlayerType.Human;
                if (DbGame.EloBlackBefore != 0)
                {
                    Player2.PlayerTitle += " " + DbGame.EloBlackBefore.ToString();
                }
            }
            else
            {
                Player2.Engine = UCIEngine.Load(PlayingMode.SelectedEngine.EngineFile, PlayingMode.SelectedEngine.HashTableSize);
                Player2.Engine.UseTablebases = EngineParameters.UseTablebases;

                DefaultEngine = Player2.Engine;

                Player2.Book = PlayingMode.SelectedBook;
                Player2.PlayerType = PlayerType.Engine;

                Player1.PlayerType = PlayerType.Human;
                if (DbGame.EloWhiteBefore != 0)
                {
                    Player1.PlayerTitle += " " + DbGame.EloWhiteBefore.ToString();
                }
            }

            if (DbGame.IsRated)
            {
                gameTypeTitle = GameType.ToString() + " " + DbGame.TimeMin.ToString() + "m + " + DbGame.GainPerMoveMin.ToString() + "s, " + "Rated";
            }
            else
            {
                gameTypeTitle = GameType.ToString() + " " + DbGame.TimeMin.ToString() + "m + " + DbGame.GainPerMoveMin.ToString() + "s, " + "Unrated";
            }
        }

        #endregion

        #region Load game
        public void LoadGame(string guid)
        {
            Databases databaseFilePaths = new Databases();

            if (!string.IsNullOrEmpty(Ap.Options.CurrentGameDatabaseFilePath))
            {
                if (databaseFilePaths.Exists(Ap.Options.CurrentGameDatabaseFilePath))
                {
                   Ap.Database = new Database(Ap.Options.CurrentGameDatabaseFilePath);
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }

            GameItem gameItem = Ap.Database.GameItems.GetGameByGuid(guid);

            if (gameItem == null)
            {
                return;
            }

            Ap.Options.CurrentGameGuid = guid;
            Ap.Options.CurrentAutoSaveGameGuid = string.Empty;
            Ap.Options.CurrentGameDatabaseFilePath = Ap.Options.CurrentDatabaseFilePath;
            Ap.Options.Save();

            GameData = gameItem.GameData;

            NewGame(GameData.InitialBoardFen, GameData.GameMode, GameData.GameType, new OptionsBlitzClock(GameData.OptionsBlitzClock), new OptionsLongClock(GameData.OptionsLongClock));

            Paste(gameItem.Moves);
        } 
        #endregion

        #region InitTablebases
        private void InitTablebases()
        {
            if (tablebases == null)
            {
                tablebases = new TablebasesManager(this);
                tablebases.Init();
            }
        } 
        #endregion
    }
}
