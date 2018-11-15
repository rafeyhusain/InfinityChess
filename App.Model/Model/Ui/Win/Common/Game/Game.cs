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
    #region enum

    public enum GameResultE
    {
        None = 0,
        InProgress = 1,
        WhiteWin = 2,
        WhiteLose = 3,
        Draw = 4,
        Absent = 5,
        NoResult = 6
    }

    public enum GameResultReasonE
    {
        None = 0,
        TimeExpired = 1,
        Resigned = 2,
        Draw = 3,
        Mated = 4,
        ThreeFoldRepetition = 5,
        StaleMated = 6,
        Aborted = 7
    }

    public enum GameMode
    {
        None = 0,
        HumanVsHuman = 1,
        HumanVsEngine = 2,
        EngineVsEngine = 3,
        OnlineHumanVsHuman = 4,
        OnlineHumanVsEngine = 5,
        OnlineEngineVsEngine = 6,
        Kibitzer = 7
    }

    public enum MoveToE
    {
        First = 0,
        Last = 1,
        Next = 2,
        Previous = 3,
        Up = 4,
        Down = 5
    }
    
    public enum VariationTypeE
    {
        None = 0,
        Variation = 1,
        MainLine = 2,
        Insert = 3,
        Overwrite = 4
    }
   
    #endregion

    public partial class Game
    {
        #region Data Members
        public DataTable Audience = null;
        private static Game game = null; // singleton game instance
        private static TablebasesManager tablebases; // singleton Tablebases instance

        // Moved variables from Notation
        public int WhiteMoveNumber = 0;
        public int GainPerMove = 0;

        public string move = null;

        private Move currentMove = null;

        public Moves Moves = null;      
        public PlayingMode PlayingMode = null;
        public Clipboard Clipboard = null;
        public Notations Notations = null;
        public Book Book;
        public GameTime GameTime = null;
        public GameData GameData = null;
        public EngineParameters EngineParameters = null;
        public GameFlags Flags = null;
        public Player Player1 = null;
        public Player Player2 = null;
        public Player CurrentPlayer = null;
        public MoveValidator MoveValidator = null;
        public FenParser FenParser = null;
        public Clock Clock = null;

        private UCIEngine defaultEngine;
        private Book defaultBook;

        public GameMode GameMode = GameMode.None;
        public GameResultE GameResult = GameResultE.None;

        public string FilePath = string.Empty;
        public string GameId = string.Empty;
        public string Player1EngineFileName = "";
        public string Player2EngineFileName = "";
        public int Player1EngineHashTableSize = Options.DefaultHashTableSize;
        public int Player2EngineHashTableSize = Options.DefaultHashTableSize;
        public string FilePathOpeningBook = "";
        private string initialBoardFen = "";

        string gameTypeTitle;
        string gameTitle;

        string gameBook_UserTitle;

        public int FullMovesCounter = 1;
        public int BlackMovesCounter = 0;
        public int HalfMovesCounter = 0;
        public int SpaceBarCounter = 0;
        public VariationTypeE VariationType = VariationTypeE.None;
        
        #endregion

        #region Events

        public event EventHandler BeforeNewGame;
        public event EventHandler AfterNewGame;

        public event EventHandler BeforeStop;
        public event EventHandler AfterStop;

        public event EventHandler BeforeFinish;
        public event EventHandler AfterFinish;

        public event EventHandler BeforeLoadOpeningBook;
        public event EventHandler AfterLoadOpeningBook;

        public event EventHandler BeforeSetFen;
        public event EventHandler AfterSetFen;

        public event EventHandler BeforeSwapPlayers;
        public event EventHandler AfterSwapPlayers;

        public event EventHandler BeforeAddMove;
        public event EventHandler AfterAddMove;

        public event EventHandler BeforePaste;
        public event EventHandler AfterPaste;

        public event EventHandler CreateDocking;

        public delegate void AfterSendMovesToEngineEventHandler(string moves, long whiteTurnSeconds, long blackTurnSeconds);
        public event AfterSendMovesToEngineEventHandler AfterSendMovesToEngine;

        public delegate void DisplayMoveFlagsHandler(object sender, string flags);
        public event DisplayMoveFlagsHandler DisplayMoveFlags;

        public event EventHandler MoveFlagsError;

        public delegate void FormClosingEventHandler(object sender, FormClosingEventArgs e);
        public event FormClosingEventHandler AddNewVariation;
        #endregion

        #region Ctor

        public Game()
        {
            Flags = new GameFlags(this);
            PlayingMode = new PlayingMode(this);
            Clipboard = new Clipboard(this);
            Notations = new Notations(this);
            GameTime = new GameTime(this);
            GameData = new GameData(this);
            EngineParameters = new EngineParameters(this);
            Book = new Book(this);
            Clock = new Clock(this);

            Player1 = new Player(PlayerColorE.White);
            Player2 = new Player(PlayerColorE.Black);
        }

        #endregion

        #region Properties

        #region Initial
        public int InitialMoveNo
        {
            [DebuggerStepThrough]
            get
            {
                return ChessLibrary.FenParser.GetMoveNo(initialBoardFen);
            }
        }

        public bool InitialIsWhite
        {
            [DebuggerStepThrough]
            get
            {
                return initialBoardFen.Contains(" w ");
            }
        }


        public string InitialBoardFen
        {
            get
            {
                if (string.IsNullOrEmpty(initialBoardFen))
                {
                    initialBoardFen = ChessLibrary.FenParser.InitialBoardFen;
                }

                return initialBoardFen;
            }

            set
            {
                initialBoardFen = value;
            }
        } 
        #endregion

        #region NextMove
        public bool NextMoveIsWhite
        {
            [DebuggerStepThrough]
            get
            {
                if (Flags.IsFirtMove)
                {
                    return InitialIsWhite;
                }
                else
                {

                    return !CurrentMove.IsWhite;
                }
            }
        }

        public int NextMoveNo
        {
            [DebuggerStepThrough]
            get
            {
                if (Flags.IsFirtMove)
                {
                    return InitialMoveNo;
                }
                else
                {
                    if (NextMoveIsWhite)
                    {
                        return CurrentMove.MoveNo + 1;
                    }

                    return CurrentMove.MoveNo;
                }
            }
        }

        public int NextMoveId
        {
            [DebuggerStepThrough]
            get
            {
                if (Flags.IsFirtMove)
                {
                    return 1;
                }
                else
                {
                    return CurrentMove.Id + 1;
                }
            }
        }

        public int NextMovePid
        {
            [DebuggerStepThrough]
            get
            {
                if (Flags.IsFirtMove)
                {
                    return -1;
                }
                else
                {
                    return CurrentMove.Id;
                }
            }
        }

        #endregion

        public string BoardFen
        {
            [DebuggerStepThrough]
            get
            {
                if (Flags.IsFirtMove)
                {
                    return InitialBoardFen;
                }

                return CurrentMove.Fen;
            }
        }

        public Move CurrentMove
        {
            [DebuggerStepThrough]
            get
            {
                if (currentMove == null && !Flags.IsFirtMove)
                {
                    currentMove = Move.NewMove();
                }

                return currentMove;
            }
           [DebuggerStepThrough]
            set
            {
                currentMove = value;
            }
        }

        public string GameTypeTitle
        {
            [DebuggerStepThrough]
            get { return gameTypeTitle; }
        }

        public string GameTitle
        {
            [DebuggerStepThrough]
            get
            {
                switch (GameMode)
                {
                    case GameMode.HumanVsHuman:
                        return Player1.PlayerTitle + " vs. " + Player2.PlayerTitle;

                    case GameMode.HumanVsEngine:
                        UCIEngine engine = Player2.Engine == null ? Player1.Engine : Player2.Engine;
                        return engine == null ? GameTypeTitle : engine.EngineName + ", " + GameTypeTitle;

                    case GameMode.EngineVsEngine:
                        return Player1.Engine.EngineName + " vs. " + Player2.Engine.EngineName;
                }

                return Config.ProductName;
            }
        }

        public string GameWindowTitle
        {
            [DebuggerStepThrough]
            get
            {
                return GameTitle + " - " + Config.ProductName;
            }
        }

        public string NewGameTitle
        {
            [DebuggerStepThrough]
            get
            {
                return GameData.WhiteTitle + " - " + GameData.BlackTitle;
            }
        }

        public string GameBookUserTitle
        {
            [DebuggerStepThrough]
            get
            {
                gameBook_UserTitle = string.Empty;

                if (DefaultEngine != null)
                    gameBook_UserTitle += EngineParameters.HashTableSize + "MB, ";

                if (!string.IsNullOrEmpty(Book.FileName) && GameMode != GameMode.EngineVsEngine)
                    gameBook_UserTitle += Book.FileName + ", ";

                gameBook_UserTitle += Ap.UserProfile.Computer;

                return gameBook_UserTitle;
            }
        }

        public UCIEngine DefaultEngine
        {
            [DebuggerStepThrough]
            get { return defaultEngine; }
            [DebuggerStepThrough]
            set { defaultEngine = value; }
        }

        public Book DefaultBook
        {
            [DebuggerStepThrough]
            get { return defaultBook; }
            [DebuggerStepThrough]
            set { defaultBook = value; }
        }

        public TablebasesManager Tablebases
        {
            [DebuggerStepThrough]
            get
            {
                return tablebases;
            }
        }

        public GameType GameType
        {
            [DebuggerStepThrough]
            get { return GameTime.GameType; }
            [DebuggerStepThrough]
            set { GameTime.GameType = value; }
        }

        public UCIEngine MainEngine
        {
            [DebuggerStepThrough]
            get
            {
                if (IsPlayer1Engine)
                {
                    return Player1.Engine;
                }
                else
                {
                    return Player2.Engine;
                }
            }
        }

        public GameResultReasonE ResultReason
        {
            get
            {
                if (Flags.IsTimeExpired)
                {
                    return GameResultReasonE.TimeExpired;
                }
                else if (Flags.IsResigned)
                {
                    return GameResultReasonE.Resigned;
                }
                else if (Flags.IsMated)
                {
                    return GameResultReasonE.Mated;
                }
                else if (Flags.IsThreeFoldRepetition)
                {
                    return GameResultReasonE.ThreeFoldRepetition;
                }
                else if (Flags.IsStaleMated)
                {
                    return GameResultReasonE.StaleMated;
                }
                else if (Flags.IsDraw)
                {
                    return GameResultReasonE.Draw;
                }
                else if (Flags.IsAborted)
                {
                    return GameResultReasonE.Aborted;
                }

                return GameResultReasonE.None;
            }
        }

        public string PlayerLost
        {
            get
            {
                return "";

                if (GameResult == GameResultE.WhiteWin)
                {
                    return Player2.PlayerTitle + " Lost";
                }
                else if (GameResult == GameResultE.WhiteLose)
                {
                    return Player1.PlayerTitle + " Lost";
                }
                else
                {
                    return "";
                }
            }
        }

        public string ResultMessage
        {
            get
            {
                string msg = "";

                switch (ResultReason)
                {
                    case GameResultReasonE.TimeExpired:
                        return "Time expired " + PlayerLost;

                    case GameResultReasonE.Resigned:
                        if (Flags.IsOffline)
                        {
                            if (Flags.IsWhiteResigned)
                            {
                                msg = Player1.PlayerTitle + " resigned";
                            }
                            else
                            {
                                msg = Player2.PlayerTitle + " resigned";
                            }
                        }
                        else
                        {
                            if (Flags.IsWhiteResigned && DbGame.IsCurrentUserBlack)
                            {
                                msg = Player1.PlayerTitle + " resigned";
                            }
                            else if (Flags.IsBlackResigned && DbGame.IsCurrentUserWhite)
                            {
                                msg = Player2.PlayerTitle + " resigned";
                            }
                            else
                            {
                                msg = "";
                            }
                        }
                        break;
                    case GameResultReasonE.Mated:
                        if (Flags.IsOnline && Flags.IsMyTurn)
                        {
                            msg = "Mated " + PlayerLost;
                        }
                        else
                        {
                            msg = "";
                        }
                        if (Flags.IsOffline)
                        {
                            msg = "Mated " + PlayerLost;
                        }
                        break;
                    case GameResultReasonE.ThreeFoldRepetition:
                        msg = "Game draw - Threefold repetition";
                        break;
                    case GameResultReasonE.StaleMated:
                        msg = "Game draw - Stale mated";
                        break;
                    case GameResultReasonE.Draw:
                        msg = "Game draw";
                        break;
                    case GameResultReasonE.Aborted:
                        msg = "Aborted";
                        break;
                }

                return msg;
            }
        }

        public string AutoSaveFilePath
        {
            get
            {
                string path = "";

                switch (GameMode)
                {
                    case GameMode.None:
                    case GameMode.HumanVsHuman:
                    case GameMode.HumanVsEngine:
                    case GameMode.EngineVsEngine:
                        path = Ap.AutoSaveFilePath;
                        break;
                    case GameMode.OnlineHumanVsHuman:
                        path = Ap.MyOnlineGameFilePath;
                        break;
                    case GameMode.OnlineEngineVsEngine:
                        path = Ap.MyOnlineEngineGameFilePath;
                        break;
                    case GameMode.Kibitzer:
                        path = Ap.OnlineKibitzedGameFilePath;
                        break;
                    default:
                        path = Ap.AutoSaveFilePath;
                        break;
                }
                return path;
            }
        }
      
        public bool IsPlayer1Engine { get { return Player1 != null && Player1.Engine != null; } }

        public bool IsPlayer2Engine { get { return Player2 != null && Player2.Engine != null; } }

        #endregion

        #region Helper

        private string GetUserTitle()
        {
            string userTitle = string.Empty;
            userTitle += Ap.UserProfile.LastName;
            userTitle += ",";
            userTitle += Ap.UserProfile.FirstName;
            return userTitle;
        }

        public void CloseEngines()
        {
            if (Player1 != null && Player1.Engine != null)
            {
                Player1.Engine.Close();
                Player1.Engine = null;
            }

            if (Player2 != null && Player2.Engine != null)
            {
                Player2.Engine.Close();
                Player2.Engine = null;
            }

            if (CurrentPlayer != null && CurrentPlayer.Engine != null)
            {
                CurrentPlayer.Engine.Close();
                CurrentPlayer.Engine = null;
            }

            if (DefaultEngine != null)
            {
                DefaultEngine.Close();
                DefaultEngine = null;
            }
        }

        public void Save()
        {
            SaveGame(Ap.DefaultDatabaseFilePath);
        }

        public void SwapPlayers()
        {
            Player player1Clone = Player1.Clone();
            Player player2Clone = Player2.Clone();

            string player1Title = Player1.Title;
            string player2Title = Player2.Title;

            Player1 = player2Clone;
            Player1.ResetTitle(player1Title);
            Player2 = player1Clone;
            Player2.ResetTitle(player2Title);

            SetCurrentPlayerHuman();
            UpdateGameDataPlayers();

            Flags.IsEngineBlack = !Flags.IsEngineBlack;

            if (AfterSwapPlayers != null)
            {
                AfterSwapPlayers(this, EventArgs.Empty);
            }
        }

        private void UpdateGameDataPlayers()
        {
            if (Ap.Options.LockGameData && GameMode == GameMode.HumanVsHuman)
                return;

            if (NextMoveNo <= 1 && !GameData.IsPlayersSwapped)
            {
                GameData.White1 = Player1.PlayerTitle;
                GameData.Black1 = Player2.PlayerTitle;
                GameData.Save();
                GameData.IsPlayersSwapped = true;
            }
        }

        public void IncFifityMove(bool isCapture, Pieces piece)
        {
            if (isCapture || piece == Pieces.WPAWN || piece == Pieces.BPAWN)
            {
                HalfMovesCounter = 0;
            }
            else
            {
                HalfMovesCounter++;
            }
        }

        public void ResetCounters()
        {
            this.HalfMovesCounter = 0;
            this.BlackMovesCounter = 0;
            this.FullMovesCounter = 1;
        }

        public void ChangeGameMode(GameMode gameMode)
        {
            switch (gameMode)
            {
                case GameMode.None:
                    break;
                case GameMode.HumanVsHuman:
                    if (Player1.PlayerType == PlayerType.Engine)
                        Player1.PlayerType = PlayerType.Human;
                    if (Player2.PlayerType == PlayerType.Engine)
                        Player2.PlayerType = PlayerType.Human;
                    if (CurrentPlayer.PlayerType == PlayerType.Engine)
                        CurrentPlayer.PlayerType = PlayerType.Human;
                    break;
                case GameMode.HumanVsEngine:
                    if (Player1.Engine != null)
                        Player1.PlayerType = PlayerType.Engine;
                    if (Player2.Engine != null)
                        Player2.PlayerType = PlayerType.Engine;
                    if (CurrentPlayer.Engine != null)
                        CurrentPlayer.PlayerType = PlayerType.Engine;
                    SetCurrentPlayerHuman();
                    break;
                case GameMode.EngineVsEngine:
                    break;
                case GameMode.OnlineHumanVsHuman:
                    break;
                default:
                    break;
            }

            GameMode = gameMode;
        }

        #endregion

        #region Finish


        public void Stop()
        {
            if (BeforeStop != null)
            {
                BeforeStop(this, EventArgs.Empty);
            }

            if (Player1 != null && Player1.Engine != null)
            {
                Player1.Engine.Close();
                Player1.Engine = null;
            }

            if (Player2 != null && Player2.Engine != null)
            {
                Player2.Engine.Close();
                Player2.Engine = null;
            }

            if (AfterStop != null)
            {
                AfterStop(this, EventArgs.Empty);
            }
        }

        public void Draw()
        {
            this.Finish(GameResultE.Draw);
        }

        public void Resign(GameResultE result)
        {
            bool whiteWin = false;

            switch (result)
            {
                case GameResultE.InProgress:
                    if (Flags.IsOffline)
                    {
                        whiteWin = Flags.AmIBlack;
                    }
                    else
                    {
                        if (DbGame.IsCurrentUserBlack)
                        {
                            whiteWin = true;
                        }
                    }
                    break;
                case GameResultE.WhiteWin:
                    whiteWin = true;
                    break;
                case GameResultE.WhiteLose:
                    whiteWin = false;
                    break;
            }

            Flags.IsResigned = true;

            if (whiteWin)
            {
                this.Finish(GameResultE.WhiteWin);
            }
            else
            {
                this.Finish(GameResultE.WhiteLose);
            }

            if (Flags.IsOnline && result == GameResultE.InProgress)
            {
                MessageFactory.Resign(DbGame.GameID, GameResult);
            }
        }

        public void Mated()
        {
            SpaceBarCounter = 0;

            if (CurrentMove.IsWhite) // has white mated the black?
            {
                Finish(GameResultE.WhiteWin);
            }
            else
            {
                Finish(GameResultE.WhiteLose);
            }
        }

        public void TimeExpired()
        {
            Flags.IsTimeExpired = true;

            if (CurrentMove.IsWhite) // black clock expired
            {
                Finish(GameResultE.WhiteWin);
            }
            else
            {
                Finish(GameResultE.WhiteLose);
            }

            if (Flags.IsOnline && Flags.IsMyTurn)
            {
                MessageFactory.TimeExpired(DbGame.GameID, GetOnlineGameXml(), GameResult);
            }
        }

        public void ThreefoldRepetition()
        {
            ThreefoldRepetition(true);
        }

        public void ThreefoldRepetition(bool sendResignMessage)
        {
            Draw();

            //if (Flags.IsOnline && sendResignMessage)
            //{
            //    MessageFactory.ThreefoldRepetition(
            //         DbGame.GameID
            //        , GetOnlineGameXml()
            //        , GameResult
            //        );
            //}
        }

        public void StaleMated()
        {
            StaleMated(true);
        }

        public void FifityMoves()
        {
            Draw();
        }

        public void StaleMated(bool sendResignMessage)
        {
            Draw();

            //MessageFactory.KingStaleMated(
            //     DbGame.GameID
            //    , GetOnlineGameXml()
            //    , GameResult
            //    );
        }

        public void Abort()
        {
            Abort(true);
        }

        public void Abort(bool sendResignMessage)
        {
            Flags.IsAborted = true;
            this.Finish(GameResultE.NoResult);

            if (Flags.IsOnline && sendResignMessage)
            {
                MessageFactory.Abort(
                  DbGame.GameID
                 , ""
                 , GameResultE.NoResult
                 );
            }
        }

        public void Finish(GameResultE gameResult)
        {
            if (Flags.IsGameFinished)
            {
                return; // we can not finish a game more than once
            }

            if (BeforeFinish != null)
            {
                BeforeFinish(this, EventArgs.Empty);
            }

            GameResult = gameResult;

            switch (gameResult)
            {
                case GameResultE.None:
                    break;
                case GameResultE.InProgress:
                    break;
                case GameResultE.WhiteWin:
                    GameData.Result = "1-0";
                    break;
                case GameResultE.WhiteLose:
                    GameData.Result = "0-1";
                    break;
                case GameResultE.Draw:
                    GameData.Result = "1/2-1/2";
                    break;
                case GameResultE.Absent:
                    GameData.Result = "Line";
                    break;
                case GameResultE.NoResult:
                    GameData.Result = "Line";
                    break;
                default:
                    break;
            }

            Notations.GameFinished();

            GameData.Save();

            AutoSaveGame();

            if (AfterFinish != null)
            {
                AfterFinish(this, EventArgs.Empty);
            }
        }

        #region GameResult
        public string GameResultString
        {
            get
            {
                string resultReason = ResultReason.ToString();

                switch (GameResult)
                {
                    case GameResultE.WhiteWin:
                        return resultReason + " 1-0";
                    case GameResultE.WhiteLose:
                        return resultReason + " 0-1";
                    case GameResultE.Draw:
                        return resultReason + " 1/2-1/2";
                    case GameResultE.Absent:
                        return resultReason + " Absent";
                    case GameResultE.NoResult:
                        return resultReason + " NoResult";
                }

                return "";
            }
        }

        #endregion

        #endregion

        #region Instance
        public static Game Instance
        {
            [DebuggerStepThrough]
            get
            {
                if (game == null)
                {
                    game = new Game();
                }

                return game;
            }
        }
        #endregion

        #region AutoSaveGame
        void AutoSaveGame()
        {
            string storeCurrentGameGuid = string.Empty;
            string path = "";
            Database database = null;

            path = AutoSaveFilePath;

            database = new Database(path);
            Databases.AddDatabaseFilePath(path);

            storeCurrentGameGuid = GameData.Guid;

            if (Ap.Options.CurrentAutoSaveGameGuid != string.Empty)
            {
                GameItem gameItem = database.GameItems.GetGameByGuid(Ap.Options.CurrentAutoSaveGameGuid);
                int currentGameIndex = database.GameItems.GetCurrentGameIndexInAutoSaveMode();
                GameData.Guid = Ap.Options.CurrentAutoSaveGameGuid;
                string updatedGameXml = GetGameXml();
                database.UpdateGame(updatedGameXml, currentGameIndex);
                database.Save();
            }
            else
            {
                GameData.Guid = string.Empty;
                string gameXml = GetGameXml();
                database.AppendGame(gameXml);
                database.Save();
                Ap.Options.CurrentAutoSaveGameGuid = GameData.Guid;
                Ap.Options.Save();
            }
            GameData.Guid = storeCurrentGameGuid;
        }

        #endregion

        #region Fen

        public void SetFen(string fen)
        {
            if (string.IsNullOrEmpty(fen) || !GameValidator.IsValidFen(fen))
            {
                return;
            }

            if (BeforeSetFen != null)
            {
                BeforeSetFen(this, EventArgs.Empty);
            }

            GameValidator = new GameW(fen);

            if (Flags.IsOffline)
            {
                if (Flags.IsClickedByUser)
                {
                    if (IsSwapPlayersRequired)
                    {
                        SwapPlayers();
                    }
                }
                else
                {
                    Clock.Reset();
                    Clock.Stop();
                    GameResult = GameResultE.InProgress;
                }

                Flags.EnPassant = SquareE.NoSquare;
                ResetCounters();
            }

            if (AfterSetFen != null)
            {
                AfterSetFen(this, EventArgs.Empty);
            }
        }

        public bool IsSwapPlayersRequired
        {
            get
            {
                if ((CurrentMove.IsWhite && Flags.IsEngineBlack) // if engine is black and variation is white(clicked on white's move's cell)
                 || (!CurrentMove.IsWhite && !Flags.IsEngineBlack) // if engine is white and variation is black(clicked on black's move's cell)
                   )
                {
                    if (GameMode != GameMode.OnlineHumanVsHuman
                     && GameMode != GameMode.OnlineEngineVsEngine
                       )
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public void SwapPlayersIfNeeded()
        {
            if (Flags.IsFirtMove)
                return;

            if (
                (CurrentMove.IsWhite && !Flags.IsEngineBlack) // if engine is black and variation is white(clicked on white's move's cell)
                ||
                (!CurrentMove.IsWhite && Flags.IsEngineBlack) // if engine is white and variation is black(clicked on black's move's cell)
                )
            {
                SwapPlayers();
            }
        }
        #endregion

        #region SendMovesToEngine
        public void SendMovesToEngine(string gameMoves, long turnCounterWhite, long turnCounterBlack)
        {
            if (AfterSendMovesToEngine != null)
            {
                AfterSendMovesToEngine(gameMoves, turnCounterWhite, turnCounterBlack);
            }
        }
        #endregion

        #region Delete Comentary
        public void DeleteAllComentary()
        {
            Notations.DeleteAllComentary();
        }
        #endregion
    }
}
