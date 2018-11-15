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
            lock (this)
            {
                DoNewGame(fen, gameMode, gameType, blitzClock, longClock);
            }
        }

        private void DoNewGame(string fen, GameMode gameMode, GameType gameType, OptionsBlitzClock blitzClock, OptionsLongClock longClock)
        {
            NewGameEventArgs args = new NewGameEventArgs();
            if (BeforeNewGame != null)
            {
                BeforeNewGame(this, args);
            }

            if (args.Cancel)
            {
                return;
            }

            if (SaveDocking != null)
            {
                SaveDocking(this, EventArgs.Empty);
            }

            GameStartTimeLocal = DateTime.Now;

            Ap.Options.CurrentGameGuid = string.Empty;
            Stop();

            InitialBoardFen = fen;

            PreviousGameMode = GameMode;
            PreviousPonderMove = string.Empty;
            GameMode = gameMode;
            GameType = gameType;                       

            #region Init
            //GameValidator = new GameW(this.InitialBoardFen);
            GameValidator.SetFen(this.InitialBoardFen);

            SpaceBarCounter = 0;

            CloseEngines();

            if (GameType == GameType.Long)
            {
                GameTime.Init(longClock, true);
            }
            else
            {
                GameTime.Init(blitzClock, true);
            }

            if (Flags.IsBookLoadRequired)
            {
                Book.Load(null);
            }

            GameResult = GameResultE.InProgress;
            Reset();

            if (DbGame != null && DbGame.IsFinished)
            {
                this.GameResult = DbGame.GameResultIDE;
                this.Flags.SetFlags(DbGame.GameFlags);                
            }     

            CurrentMove = RootMove.Clone();
            Moves.Clear();
            CurrentLine = null;
            #endregion

            #region Switch GameMode
            switch (GameMode)
            {
                case GameMode.None:
                    break;
                case GameMode.HumanVsHuman:
                    #region HumanVsHuman
                    GameTime.TimeMin = 0;
                    GameTime.GainPerMove = 0;

                    Player1.Engine = null;
                    Player2.Engine = null;

                    Player2.Book = Book;

                    Player1.PlayerTitle = Ap.UserProfile.LastName;
                    Player2.PlayerTitle = "InfinityChess";

                    GameData.SetPlayers(Player1.PlayerTitle, Ap.UserProfile.FirstName, Player2.PlayerTitle, "");
                    gameTypeTitle = Ap.GetGameTypeTitle(GameType); 
                    #endregion
                    break;
                case GameMode.HumanVsEngine:
                    #region HumanVsEngine
                    Player2EngineFileName = InfinitySettings.Settings.DefaultEngineXml.FilePath;
                    Player1.Engine = null;
                    if (DefaultEngine == null)
                    {
                        Player2.Engine = UCIEngine.Load(Player2EngineFileName, Options.DefaultHashTableSize, this);
                        Player2.Engine.UseTablebases = Ap.EngineOptions.UseTablebases;

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

                    GameData.SetPlayers(Player1.PlayerTitle, Ap.UserProfile.FirstName, Player2.PlayerTitle, "");
                    gameTypeTitle = Ap.GetGameTypeTitle(GameType); 
                    #endregion
                    break;
                case GameMode.EngineVsEngine:
                    #region EngineVsEngine
                    Player1.Engine = UCIEngine.Load(Player1EngineFileName, Player1EngineHashTableSize, this);
                    Player1.Engine.UseTablebases = Ap.EngineOptions.UseTablebases;

                    Player2.Engine = UCIEngine.Load(Player2EngineFileName, Player2EngineHashTableSize, this);
                    Player2.Engine.UseTablebases = Ap.EngineOptions.UseTablebases;

                    Player1.PlayerTitle = Player1.Engine.EngineName;
                    Player2.PlayerTitle = Player2.Engine.EngineName;

                    if (Player1.Book != null)
                    {
                        Player1.Book.NewGame();
                    }
                    if (Player2.Book != null)
                    {
                        Player2.Book.NewGame();
                    }

                    GameData.SetPlayers(Player1.PlayerTitle, "", Player2.PlayerTitle, "");
                    gameTypeTitle = Ap.GetGameTypeTitle(GameType);

                    InitE2eResult(); 
                    #endregion
                    break;
                case GameMode.OnlineHumanVsHuman:
                    #region OnlineHumanVsHuman
                    StartOnlineH2HGame();
                    #endregion
                    break;
                case GameMode.OnlineHumanVsEngine:
                    #region OnlineHumanVsEngine
                    gameTypeTitle = Ap.GetGameTypeTitle(GameType); 
                    #endregion
                    break;
                case GameMode.OnlineEngineVsEngine:
                    #region OnlineEngineVsEngine
                    if (Ap.PlayingMode.SelectedEngine == null)
                    {
                        StartOnlineH2HGame();
                    }
                    else
                    {
                        StartOnlineE2EGame();
                    } 
                    #endregion
                    break;
                case GameMode.Kibitzer:
                    #region Kibitzer
                    GameTime.Set(DbGame);
                    GameResult = DbGame.GameResultIDE;

                    Player1.PlayerTitle = DbGame.WhiteUser.UserName + " " + DbGame.WhiteUser.Engine.Name;
                    Player2.PlayerTitle = DbGame.BlackUser.UserName + " " + DbGame.BlackUser.Engine.Name;

                    if (DbGame.IsRated)
                    {
                        gameTypeTitle = GameType.ToString() + " " + DbGame.TimeMin.ToString() + "' + " + DbGame.GainPerMoveMin.ToString() + "'', " + "Rated";

                        if (DbGame.EloBlackBefore != 0 && !DbGame.BlackUser.IsGuest)
                        {
                            Player2.PlayerTitle += " " + DbGame.EloBlackBefore.ToString();
                        }

                        if (DbGame.EloWhiteBefore != 0 && !DbGame.WhiteUser.IsGuest)
                        {
                            Player1.PlayerTitle += " " + DbGame.EloWhiteBefore.ToString();
                        }
                    }
                    else
                    {
                        gameTypeTitle = GameType.ToString() + " " + DbGame.TimeMin.ToString() + "' + " + DbGame.GainPerMoveMin.ToString() + "'', " + "Unrated";
                    }

                    GameData.SetPlayers(Player1.PlayerTitle, "", Player2.PlayerTitle, "");

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

            Clock.NewGame();
            Notations.NewGame();

            if (Flags.IsBookLoadRequired)
            {
                Book.NewGame();
            }

            CapturedPieces.NewGame();
            GameData.NewGame();

            Clipboard.Reset();

            GameData.Tournament = GameTypeTitle;

            Ap.Options.GameType = gameType;
            Ap.Options.Save();

            #endregion

            if (CreateDocking != null)
            {
                CreateDocking(this, EventArgs.Empty);
            }

            Flags.IsInfiniteAnalysisOn = false;
            MediaPlayer.PlaySound(SoundFileNameE.SetPieces);
            SetFen(fen);

            Flags.IsBoardSetByFen = fen != ChessLibrary.FenParser.InitialBoardFen;

            if (Flags.IsOnline && DbGame != null)
            {
                Flags.IsChallengerSendsGame = DbGame.IsChallengerSendsGame;
            }

            SetSuddenDeathMatchTime();

            if (AfterNewGame != null)
            {
                AfterNewGame(this, EventArgs.Empty);
            }            
        }

        private void SetSuddenDeathMatchTime()
        {
            if (Flags.IsSuddenDeathMatch)
            {
                long wt = DbGame.TournamentMatch.Tournament.SuddenDeathWhiteMin * 60;
                long bt = DbGame.TournamentMatch.Tournament.SuddenDeathBlackMin * 60;
                long gain = DbGame.TournamentMatch.Tournament.SuddenDeathSec;

                Clock.Reset(wt + gain, bt + gain);
                GameTime.GainPerMove = gain;
            }
        }

        private void StartOnlineH2HGame()
        {
            GameTime.Set(DbGame);

            GameMode = GameMode.OnlineHumanVsHuman;

            Player1.PlayerTitle = DbGame.WhiteUser.UserName + " " + DbGame.WhiteUser.Engine.Name;
            Player2.PlayerTitle = DbGame.BlackUser.UserName + " " + DbGame.BlackUser.Engine.Name;

            Player1.Color = PlayerColorE.White;
            Player2.Color = PlayerColorE.Black;

            if (DbGame.IsTournamentMatch)
            {
                gameTypeTitle = DbGame.TournamentMatch.Tournament.Name;
            }

            if (DbGame.IsRated)
            {
                gameTypeTitle = GameType.ToString() + " " + DbGame.TimeMin.ToString() + "' + " + DbGame.GainPerMoveMin.ToString() + "'', " + "Rated";

                if (DbGame.EloBlackBefore != 0 && !DbGame.BlackUser.IsGuest)
                    Player2.PlayerTitle += " " + DbGame.EloBlackBefore.ToString();

                if (DbGame.EloWhiteBefore != 0 && !DbGame.WhiteUser.IsGuest)
                    Player1.PlayerTitle += " " + DbGame.EloWhiteBefore.ToString();
            }
            else
            {
                gameTypeTitle = GameType.ToString() + " " + DbGame.TimeMin.ToString() + "' + " + DbGame.GainPerMoveMin.ToString() + "'', " + "Unrated";
            }

            GameData.SetPlayers(Player1.PlayerTitle, "", Player2.PlayerTitle, "");
        }

        private void StartOnlineE2EGame()
        {
            FilePathOpeningBook = Ap.Options.CurrentBookFilePath;
            GameTime.Set(DbGame);

            Player1.PlayerTitle = DbGame.WhiteUser.UserName + " " + DbGame.WhiteUser.Engine.Name;
            Player2.PlayerTitle = DbGame.BlackUser.UserName + " " + DbGame.BlackUser.Engine.Name;

            Player1.Color = PlayerColorE.White;
            Player2.Color = PlayerColorE.Black;

            if (DbGame.IsCurrentUserWhite)
            {
                Player1.Engine = UCIEngine.Load(Ap.PlayingMode.SelectedEngine.EngineFile, Ap.PlayingMode.SelectedEngine.HashTableSize, this);
                Player1.Engine.UseTablebases = Ap.EngineOptions.UseTablebases;

                DefaultEngine = Player1.Engine;
                Player1.Book = Ap.PlayingMode.SelectedBook;
                if (Player1.Book != null)
                {
                    Player1.Book.Game = this;
                    Player1.Book.NewGame();
                }

                if (DbGame.EloBlackBefore != 0)
                {
                    Player2.PlayerTitle += " " + DbGame.EloBlackBefore.ToString();
                }
            }
            else
            {
                Player2.Engine = UCIEngine.Load(Ap.PlayingMode.SelectedEngine.EngineFile, Ap.PlayingMode.SelectedEngine.HashTableSize, this);
                Player2.Engine.UseTablebases = Ap.EngineOptions.UseTablebases;

                DefaultEngine = Player2.Engine;

                Player2.Book = Ap.PlayingMode.SelectedBook;
                if (Player2.Book != null)
                {
                    Player2.Book.Game = this;
                    Player2.Book.NewGame();
                }

                if (DbGame.EloWhiteBefore != 0)
                {
                    Player1.PlayerTitle += " " + DbGame.EloWhiteBefore.ToString();
                }
            }

            if (DbGame.IsRated)
            {
                gameTypeTitle = GameType.ToString() + " " + DbGame.TimeMin.ToString() + "' + " + DbGame.GainPerMoveMin.ToString() + "'', " + "Rated";
            }
            else
            {
                gameTypeTitle = GameType.ToString() + " " + DbGame.TimeMin.ToString() + "' + " + DbGame.GainPerMoveMin.ToString() + "'', " + "Unrated";
            }

            GameData.SetPlayers(Player1.PlayerTitle, "", Player2.PlayerTitle, "");
        }

        public void NewGameE2E()
        {
            if (Ap.EngineOptions.AlternateColor) // swap engines : white <---> black
            {
                string e1 = Player1EngineFileName;
                string e2 = Player2EngineFileName;

                int hts1 = Player1EngineHashTableSize;
                int hts2 = Player2EngineHashTableSize;

                Book b1 = Player1.Book;
                Book b2 = Player2.Book;

                Player1EngineFileName = e2;
                Player1EngineHashTableSize = hts2;
                Player1.Book = b2;

                Player2EngineFileName = e1;
                Player2EngineHashTableSize = hts1;
                Player2.Book = b1;

                SwapGameDataPlayers();
            }

            IsFlipped = !IsFlipped;
            NewGame(GameMode.EngineVsEngine, GameType);
        }

        private void InitE2eResult()
        {
            if (Flags.IsE2eResultInitRequired)
            {
                E2eResult = new E2eResult(this);
                E2eResult.Engine1Name = Player1.Engine.EngineName;
                E2eResult.Engine2Name = Player2.Engine.EngineName;
            }
        }

        public void UpdateE2eResult()
        {
            if (E2eResult == null)
            {
                return;
            }

            switch (GameResultE)
            {
                case GameResultE.WhiteWin:
                    if (Flags.IsEngine1White)
                    {
                        E2eResult.Engine1WhiteWin++;
                        E2eResult.AddMatch("1", "0", true);
                    }
                    else
                    {
                        E2eResult.Engine2WhiteWin++;
                        E2eResult.AddMatch("0", "1", false);
                    }
                    break;
                case GameResultE.WhiteLose:
                    if (Flags.IsEngine1White)
                    {
                        E2eResult.Engine2BlackWin++;
                        E2eResult.AddMatch("0", "1", true);
                    }
                    else
                    {
                        E2eResult.Engine1BlackWin++;
                        E2eResult.AddMatch("1", "0", false);
                    }
                    break;
                case GameResultE.Draw:
                    E2eResult.Draw++;
                    if (Flags.IsEngine1White)
                    {
                        E2eResult.AddMatch("1/2", "1/2", true);
                    }
                    else
                    {
                        E2eResult.AddMatch("1/2", "1/2", false);
                    }
                    break;
                case GameResultE.NoResult:
                    E2eResult.NoResult++;
                    if (Flags.IsEngine1White)
                    {
                        E2eResult.AddMatch("0", "0", true);
                    }
                    else
                    {
                        E2eResult.AddMatch("0", "0", false);
                    }
                    break;
                default:
                    break;
            }
            TestDebugger.Instance.WriteLog("TotalMatches : " + E2eResult.TotalMatches + " - " + DateTime.Now.ToLongDateString() + " - " + DateTime.Now.ToLongTimeString());
        }

        #endregion

        #region Load game
        public bool LoadGame(string guid)
        {
            if (!Ap.LoadDatabase(Ap.Options.CurrentGameDatabaseFilePath))
            {
                return false;
            }

            GameItem gameItem = Ap.Database.GameItems.GetGameByGuid(guid);

            if (gameItem == null)
            {
                return false;
            }

            if (BeforeLoadGame != null)
            {
                BeforeLoadGame(this, EventArgs.Empty);
            }
            
            NewGame(GameData.InitialBoardFen, MapGameMode(GameData.GameMode), GameData.GameType, new OptionsBlitzClock(GameData.OptionsBlitzClock), new OptionsLongClock(GameData.OptionsLongClock));
            GameData = gameItem.GameData;
            Ap.Options.CurrentGameGuid = guid;
            Ap.Options.CurrentGameDatabaseFilePath = Ap.Options.CurrentDatabaseFilePath;
            Ap.Options.Save();
            Flags.Flags = gameItem.GameData.Flags;
            Flags.IsDatabaseGame = true;
            Paste(gameItem.Moves);
            if (GameData.Result != string.Empty)
            {
                Finish(gameItem.GameData.GameResult);
            }

            if (AfterLoadGame != null)
            {
                AfterLoadGame(this, EventArgs.Empty);
            }

            Flags.IsDatabaseGame = false;

            return true;
        }

        private GameMode MapGameMode(GameMode m)
        {
            switch (m)
            {
                case GameMode.OnlineHumanVsHuman:
                case GameMode.Kibitzer:
                    return GameMode.HumanVsHuman;
                   
                case GameMode.EngineVsEngine:
                case GameMode.OnlineHumanVsEngine:
                case GameMode.OnlineEngineVsEngine:
                    return GameMode.HumanVsEngine;
                    
                default:
                    return m;
                    
            }
        }

        #endregion
    }
}
