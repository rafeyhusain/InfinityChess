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
using System.Threading;


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
        NoResult = 6,
        WhiteBye = 7,
        BlackBye = 8,
        ForcedWhiteWin = 9,
        ForcedWhiteLose = 10,
        ForcedDraw = 11
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
        Aborted = 7,
        FiftyMoves = 8,
        InsufficientMaterial = 9        
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

    public enum MoveByE
    {
        None = 0,
        Human = 1,
        Engine = 2,
        Book = 3
    }

    #endregion

    public partial class Game
    {
        #region Data Members
        public DataTable Audience = null;
        private static Game game = null; // singleton game instance

        // Moved variables from Notation
        public int WhiteMoveNumber = 0;
        public int GainPerMove = 0;
        public int MoveIdWhenFenIsSet = 0;

        public string move = null;

        public DateTime GameStartTimeLocal;
        private Move currentMove = null;

        public Move RootMove = null;
        public Moves Moves = null;
        //public PlayingMode PlayingMode = null;
        public Clipboard Clipboard = null;
        public Notations Notations = null;
        public Book Book;
        public GameTime GameTime = null;
        public GameData GameData = null;
        public GameFlags Flags = null;
        public Player Player1 = null;
        public Player Player2 = null;
        public MoveValidator MoveValidator = null;
        public FenParser FenParser = null;
        public Clock Clock = null;
        public CapturedPieces CapturedPieces = null;
        public GameW GameValidator;
        public Moves CurrentLine;
        public E2eResult E2eResult;
        public App.Model.Db.Game DbGame = null;

        private UCIEngine defaultEngine;
        private Book defaultBook;

        public GameMode GameMode = GameMode.None;
        public GameMode PreviousGameMode = GameMode.None;
        public GameResultE GameResult = GameResultE.None;

        public string FilePath = string.Empty;
        public string GameId = string.Empty;
        public string Player1EngineFileName = "";
        public string Player2EngineFileName = "";
        public int Player1EngineHashTableSize = Options.DefaultHashTableSize;
        public int Player2EngineHashTableSize = Options.DefaultHashTableSize;
        public string FilePathOpeningBook = "";
        public string BestMove = "";
        public string PonderMove = "";
        public string PreviousPonderMove = "";

        string gameTypeTitle;

        string gameBook_UserTitle;

        public int FullMovesCounter = 1;
        public int HalfMovesCounter = 0;
        public int SpaceBarCounter = 0;

        public int E2EGamesCount = 0;
        public bool IsFlipped = true;
        public bool E2EMatchesStopped = false;

        public VariationTypeE VariationType = VariationTypeE.None;
        public SquareE EnPassant = SquareE.NoSquare;

        public GameResultE GameResultID;
        #endregion

        #region Events

        public event EventHandler<NewGameEventArgs> BeforeNewGame;
        public event EventHandler AfterNewGame;

        public event EventHandler BeforeStop;
        public event EventHandler AfterStop;

        public event EventHandler BeforeFinish;
        public event EventHandler AfterFinish;

        public event EventHandler BeforeSetFen;
        public event EventHandler AfterSetFen;


        public event EventHandler AfterSwapPlayers;

        public event EventHandler<EngineMoveEventArgs> BeforeAddMove;
        public event EventHandler AfterAddMove;

        public event EventHandler BeforePaste;
        public event EventHandler AfterPaste;

        public event EventHandler StartAnalysis;
        public event EventHandler StopAnalysis;

        public event EventHandler SaveDocking;
        public event EventHandler CreateDocking;

        public event EventHandler BeforeLoadGame;
        public event EventHandler AfterLoadGame;

        public event EventHandler<MoveToEventArgs> BeforeMoveTo;
        public event EventHandler<MoveToEventArgs> AfterMoveTo;

        public delegate void SelectCurrentMoveChildrenEventHandler(object sender, SelectCurrentMoveChildrenEventArgs e);
        public event SelectCurrentMoveChildrenEventHandler SelectCurrentMoveChildren;

        public delegate void AfterSendMovesToEngineEventHandler(string moves, long whiteTurnSeconds, long blackTurnSeconds);
        public event AfterSendMovesToEngineEventHandler AfterSendMovesToEngine;

        public delegate void DisplayMoveFlagsHandler(object sender, string flags);

        public delegate void FormClosingEventHandler(object sender, FormClosingEventArgs e);
        public event FormClosingEventHandler AddNewVariation;

        #endregion

        #region Ctor

        public Game()
        {
            RootMove = GetRootMove();
            CurrentMove = RootMove.Clone();

            Flags = new GameFlags(this);
            //PlayingMode = new PlayingMode(this);
            Clipboard = new Clipboard(this);
            Notations = new Notations(this);
            GameTime = new GameTime(this);
            GameData = new GameData(this);
            Book = new Book(this);
            Clock = new Clock(this);
            CapturedPieces = new CapturedPieces(this);
            Moves = new Moves(this);
            GameValidator = new GameW(this.InitialBoardFen);

            Player1 = new Player(this, PlayerColorE.White);
            Player2 = new Player(this, PlayerColorE.Black);
        }

        public Game(Game g)
        {
            this.Flags = new GameFlags(this);
            this.Flags.Flags = g.Flags.Flags;
            this.Moves = new Moves(this);
            this.Moves.DataTable = g.Moves.DataTable.Copy();
            this.GameResult = g.GameResult;
        }

        #endregion

        #region Properties

        public DateTime GameStartTimeServer
        {
            get
            {
                if (DbGame == null)
                {
                    return new DateTime(1900, 1, 1);
                }

                return DbGame.DateCreated;
            }
        }

        public Player CurrentPlayer
        {
            [DebuggerStepThrough]
            get
            {
                if (Flags.IsFirtMove)
                {
                    if (InitialIsWhite)
                    {
                        return Player1;
                    }
                    else
                    {
                        return Player2;
                    }
                }

                if (CurrentMove.IsWhite)
                {
                    return Player2;
                }
                else
                {
                    return Player1;
                }
            }
        }

        #region Initial
        public int InitialMoveNo
        {
            [DebuggerStepThrough]
            get
            {
                return RootMove.MoveNo;
            }
        }

        public bool InitialIsWhite
        {
            [DebuggerStepThrough]
            get
            {
                return RootMove.IsWhite;
            }
        }

        public string InitialBoardFen
        {
            [DebuggerStepThrough]
            get
            {
                return RootMove.Fen;
            }
            [DebuggerStepThrough]
            set
            {
                RootMove.SetFen(value);
            }
        }
        #endregion

        #region NextMove
        public bool NextMoveIsWhite
        {
            [DebuggerStepThrough]
            get
            {
                if (Flags.IsFirtMove || Flags.IsRootMove)
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
                if (Flags.IsFirtMove || Flags.IsRootMove)
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
                    return Moves.Last.Id + 1;
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
                if (Flags.IsFirtMove || Flags.IsRootMove)
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
                if (Flags.IsDatabaseGame)
                {
                    return Player1.PlayerTitle + " vs. " + Player2.PlayerTitle;
                }
                else
                {
                    switch (GameMode)
                    {
                        case GameMode.HumanVsHuman:
                            return Player1.PlayerTitle + " vs. " + Player2.PlayerTitle;

                        case GameMode.HumanVsEngine:
                            UCIEngine engine = Player2.Engine == null ? Player1.Engine : Player2.Engine;
                            return engine == null ? GameTypeTitle : engine.EngineName + ", " + GameTypeTitle;

                        case GameMode.EngineVsEngine:
                            if (Player1.Engine != null && Player2.Engine != null)
                            {
                                return Player1.Engine.EngineName + " vs. " + Player2.Engine.EngineName;
                            }
                            return string.Empty;
                    }
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
                {
                    gameBook_UserTitle += Ap.EngineOptions.HashTableSize + "MB, ";
                }

                if (!string.IsNullOrEmpty(Book.FileName) && GameMode != GameMode.EngineVsEngine)
                {
                    gameBook_UserTitle += Book.FileName + ", ";
                }

                if (GameMode != GameMode.HumanVsHuman)
                {
                    gameBook_UserTitle += Ap.UserProfile.Computer;
                }

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
                else if (Flags.IsInsufficientMaterial)
                {
                    return GameResultReasonE.InsufficientMaterial;
                }
                else if (Flags.IsStaleMated)
                {
                    return GameResultReasonE.StaleMated;
                }
                else if (Flags.IsFiftyMoves)
                {
                    return GameResultReasonE.FiftyMoves;
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

                //if (GameResult == GameResultE.WhiteWin)
                //{
                //    return Player2.PlayerTitle + " Lost";
                //}
                //else if (GameResult == GameResultE.WhiteLose)
                //{
                //    return Player1.PlayerTitle + " Lost";
                //}
                //else
                //{
                //    return "";
                //}
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
                        return "Time ";

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
                                msg = "Resigned";
                            }
                        }
                        break;
                    case GameResultReasonE.Mated:
                        if (Flags.IsOnline && Flags.IsMyTurn)
                        {
                            msg = "Mated ";
                        }
                        else
                        {
                            msg = "Mated";
                        }
                        if (Flags.IsOffline)
                        {
                            msg = "Mated ";
                        }
                        break;
                    case GameResultReasonE.ThreeFoldRepetition:
                        msg = "Threefold repetition";
                        break;
                    case GameResultReasonE.InsufficientMaterial:
                        msg = "Insufficient material";
                        break;
                    case GameResultReasonE.StaleMated:
                        msg = "Stale mated";
                        break;
                    case GameResultReasonE.FiftyMoves:
                        msg = "Fifty moves";
                        break;
                    case GameResultReasonE.Draw:
                        msg = "Game draw by mutual agreement ";
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
                        path = Ap.AutoSaveFilePath;
                        break;
                    case GameMode.EngineVsEngine:
                        path = Ap.EngineOptions.DatabaseFile;
                        break;
                    case GameMode.OnlineHumanVsHuman:
                        if (Flags.IsTournamentMatch)
                            path = Ap.MyOnlineHumanTournamentFilePath; 
                        else
                            path = Ap.MyOnlineGameFilePath;
                        break;
                    case GameMode.OnlineEngineVsEngine:
                        if (Flags.IsTournamentMatch)
                            path = Ap.MyOnlineEngineTournamentFilePath;
                        else
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

            if (Player2.HasEngine)
            {
                Player2.Engine.Close();
                Player2.Engine = null;
            }

            if (CurrentPlayer.HasEngine)
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
            PlayerColorE p1Color = Player1.Color;
            PlayerColorE p2Color = Player2.Color;

            Player p = Player1;

            Player1 = Player2;
            Player1.Color = p1Color;

            Player2 = p;
            Player2.Color = p2Color;

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
                SwapGameDataPlayers();

                GameData.Save();
                GameData.IsPlayersSwapped = true;
            }
        }

        private void SwapGameDataPlayers()
        {
            string w1 = GameData.White1;
            string w2 = GameData.White2;
            string b1 = GameData.Black1;
            string b2 = GameData.Black2;

            GameData.White1 = b1;
            GameData.White2 = b2;
            GameData.Black1 = w1;
            GameData.Black2 = w2;
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

        public void Reset()
        {
            Flags.Reset();

            EnPassant = SquareE.NoSquare;
            HalfMovesCounter = 0;
            FullMovesCounter = 1;
        }

        public void ResetCurrentGame()
        {
            Ap.Options.CurrentGameGuid = string.Empty;
            Ap.Options.CurrentGameDatabaseFilePath = string.Empty;
            Ap.Options.Save();
        }

        public void ChangeGameMode(GameMode gameMode)
        {
            switch (gameMode)
            {
                case GameMode.None:
                    break;
                case GameMode.HumanVsHuman:
                    break;
                case GameMode.HumanVsEngine:
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

        public bool IsDefaultEngine(UCIEngine engine)
        {
            if (DefaultEngine == null || engine == null)
            {
                return false;
            }

            if (DefaultEngine.EngineFile == engine.EngineFile)
            {
                return true;
            }

            return false;
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
                Player1.CloseEngine();
            }

            if (Player2 != null && Player2.Engine != null)
            {
                Player1.CloseEngine();
            }

            if (AfterStop != null)
            {
                AfterStop(this, EventArgs.Empty);
            }
            
        }

        public void Draw()
        {
            if (Flags.IsSuddenDeathMatch)
            {
                Flags.IsSuddenDeathResult = true;
                this.Finish(GameResultE.WhiteLose);
            }
            else
            {
                this.Finish(GameResultE.Draw);
            }
        }

        public void Resign(GameResultE result)
        {
            int gameID = 0;
            int opponentUserID = 0;

            if (DbGame != null)
            {
                gameID = DbGame.GameID; // DbGame is null once AfterFinish is called in Finish()
                opponentUserID = DbGame.OpponentUserID;
            }

            bool whiteWin = false;

            switch (result)
            {
                case GameResultE.InProgress:
                    if (Flags.IsOffline)
                    {
                        whiteWin = ResignOffline();// Flags.AmIBlack;
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
                SocketClient.Resign(gameID, GameResult, opponentUserID, Flags.Flags);
            }
        }

        public bool ResignOffline()
        {
            bool isWhiteWin = false;

            switch (GameMode)
            {
                case GameMode.HumanVsHuman:
                    isWhiteWin = Flags.AmIBlack;
                    break;
                case GameMode.HumanVsEngine:
                    if (Player1.IsHuman)
                    {
                        if (Player1.IsWhite)
                        {
                            isWhiteWin = false;
                        }
                        else
                        {
                            isWhiteWin = true;
                        }
                    }
                    else if (Player2.IsHuman)
                    {
                        if (Player2.IsWhite)
                        {
                            isWhiteWin = false;
                        }
                        else
                        {
                            isWhiteWin = true;
                        }
                    }                    
                    break;                
            }
            return isWhiteWin;
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

        public void TimeExpired(GameResultE result, bool isSendResult)
        {
            int gameID = 0;
            int opponentUserID = 0;

            if (DbGame != null)
            {
                gameID = DbGame.GameID; // DbGame is null once AfterFinish is called in Finish()
                opponentUserID = DbGame.OpponentUserID;
            }

            Flags.IsTimeExpired = true;

            if (result == GameResultE.InProgress)
            {
                if (Flags.AmIBlack) // black clock expired
                {
                    Finish(GameResultE.WhiteWin);
                }
                else
                {
                    Finish(GameResultE.WhiteLose);
                }
            }
            else
            {
                Finish(result);
            }

            if (Flags.IsOnline && isSendResult)
            {
                SocketClient.TimeExpired(gameID, GameResult, opponentUserID, Flags.Flags);
            }
        }

        public void ThreefoldRepetition()
        {
            ThreefoldRepetition(true);
        }

        public void ThreefoldRepetition(bool sendResignMessage)
        {
            Draw();
        }

        public void InsufficientMaterial()
        {
            Draw();
        }

        public void StaleMated()
        {
            StaleMated(true);
        }

        public void FifityMoves()
        {
            Flags.IsFiftyMoves = true;
            Draw();
        }

        public void StaleMated(bool sendResignMessage)
        {
            Draw();
        }

        public void Abort()
        {
            Abort(true);
        }

        public void Abort(bool isSendResult)
        {
            int gameID = 0;
            int opponentUserID = 0;

            if (DbGame != null)
            {
                gameID = DbGame.GameID; // DbGame is null once AfterFinish is called in Finish()
                opponentUserID = DbGame.OpponentUserID;
            }

            Flags.IsAborted = true;

            this.Finish(GameResultE.NoResult);

            if (Flags.IsOnline && isSendResult)
            {
                SocketClient.Abort(gameID, "", GameResultE.NoResult, opponentUserID, Flags.Flags);
            }
        }

        public void GameForcefullyFinished(GameResultE gameResult)
        {
            Finish(gameResult);
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
                case GameResultE.ForcedWhiteLose:
                    GameData.Result = "0-1 (Forced black win)";
                    break;
                case GameResultE.ForcedWhiteWin:
                    GameData.Result = "1-0 (Forced white win)";
                    break;
                case GameResultE.ForcedDraw:
                    GameData.Result = "1/2-1/2 (Forced draw)";
                    break;                
                default:
                    break;
            }

            Notations.GameFinished();

            if (!Flags.IsDatabaseGame)
            {
                GameData.Save();
                AutoSaveGame();
            }

            //if (Flags.IsOnline && Flags.IsTimeExpired && (Flags.IsMyTurn || Flags.IsTournamentMatchTimeExpired))
            //{
            //    SocketClient.TimeExpired(DbGame.GameID, GameResult, DbGame.OpponentUserID, Flags.Flags);
            //}

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
                string resultReason = ResultMessage;// ResultReason.ToString();

                switch (GameResult)
                {
                    case GameResultE.WhiteWin:
                        return resultReason + " 1-0";
                    case GameResultE.WhiteLose:
                        if (Flags.IsSuddenDeathResult)
                        {
                            return "Sudden Death 0-1 (" + resultReason + " 1/2-1/2)";
                        }
                        else
                        {
                            return resultReason + " 0-1";
                        }
                    case GameResultE.Draw:
                        return resultReason + " 1/2-1/2";
                    case GameResultE.Absent:
                        return resultReason + " Absent";
                    case GameResultE.NoResult:
                        return resultReason + " NoResult";
                    case GameResultE.ForcedWhiteLose:
                        return resultReason + "0-1 (Forced black win)";                        
                    case GameResultE.ForcedWhiteWin:
                        return resultReason + "1-0 (Forced white win)";                        
                    case GameResultE.ForcedDraw:
                        return resultReason + "1/2-1/2 (Forced draw)";
                        break;
                }

                return "";
            }
        }

        public GameResultE GameResultE
        {
            get
            {
                switch (GameData.Result)
                {
                    case "1-0":
                        return GameResultE.WhiteWin;
                    case "0-1":
                        return GameResultE.WhiteLose;
                    case "1/2-1/2":
                        return GameResultE.Draw;
                    case "Line":
                        return GameResultE.NoResult;
                    case "0-1 (Forced black win)":
                        return GameResultE.ForcedWhiteLose;
                    case "1-0 (Forced white win)":
                        return GameResultE.ForcedWhiteWin;
                    case "1/2-1/2 (Forced draw)":
                        return GameResultE.ForcedDraw;
                    default:
                        return GameResultE.None;                        
                }
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
                //if (game == null)
                //{
                //    game = new Game();
                //}

                return game;
            }
            set
            {
                game = value;
            }
        }
        #endregion

        #region AutoSaveGame

        private void AutoSaveGame()
        {
            Thread th = new Thread(DoAutoSaveGame);
            th.Start();
        }

        private void DoAutoSaveGame()
        {
            try
            {
                string storeCurrentGameGuid = string.Empty;
                string path = "";

                path = AutoSaveFilePath;

                Ap.LoadDatabase(path);

                storeCurrentGameGuid = GameData.Guid;

                if (Ap.Options.CurrentGameGuid != string.Empty && GameMode != GameMode.Kibitzer)
                {
                    GameItem gameItem = Ap.Database.GameItems.GetGameByGuid(Ap.Options.CurrentGameGuid);
                    int currentGameIndex = Ap.Database.GameItems.GetCurrentGameIndex();
                    GameData.Guid = Ap.Options.CurrentGameGuid;
                    string updatedGameXml = GetGameXml();
                    Ap.Database.UpdateGame(updatedGameXml, currentGameIndex);
                    Ap.Database.Save();
                }
                else
                {
                    GameData.Guid = string.Empty;
                    string gameXml = GetGameXml();
                    Ap.Database.AppendGame(gameXml);
                    Ap.Options.CurrentGameGuid = GameData.Guid;
                    Ap.Options.CurrentGameDatabaseFilePath = path;
                    Ap.Options.Save();
                }
                GameData.Guid = storeCurrentGameGuid;
            }
            catch
            {
            }
        }

        #endregion

        #region Fen

        public void SetFen(string fen)
        {
            if (string.IsNullOrEmpty(fen))
            {
                return;
            }

            if (BeforeSetFen != null)
            {
                BeforeSetFen(this, EventArgs.Empty);
            }

            //GameValidator = new GameW(fen);
            GameValidator.SetFen(fen);

            if (Flags.IsOffline)
            {
                if (Flags.IsFirtMove)
                {
                    MoveIdWhenFenIsSet = 0;

                }
                else
                {
                    MoveIdWhenFenIsSet = CurrentMove.Id;
                }

                SwapPlayersIfNeeded();
            }

            EnPassant = ChessLibrary.FenParser.GetEnpasantSqaure(fen);
            HalfMovesCounter = ChessLibrary.FenParser.GetHalfMovesCounter(fen);
            FullMovesCounter = ChessLibrary.FenParser.GetFullMovesCounter(fen);
            Flags.IsBlackShortCastling = ChessLibrary.FenParser.GetIsBlackShortCastling(fen);
            Flags.IsBlackLongCastling = ChessLibrary.FenParser.GetIsBlackLongCastling(fen);            
            Flags.IsWhiteShortCastling = ChessLibrary.FenParser.GetIsWhiteShortCastling(fen);
            Flags.IsWhiteLongCastling = ChessLibrary.FenParser.GetIsWhiteLongCastling(fen);

            //PlayFenSound();
            if (AfterSetFen != null)
            {
                AfterSetFen(this, EventArgs.Empty);
            }
        }
        public void PlayFenSound()
        {
            if (Flags.IsFirtMove)
            {
                MediaPlayer.PlaySound(SoundFileNameE.Move);
            }

            //if (Flags.IsFirtMove || Ap.Options.CurrentGameGuid == string.Empty)
            //{
            //    App.Model.MediaPlayer.PlaySound(SoundFileNameE.SetPieces);
            //}
            //else
            //{
            //    App.Model.MediaPlayer.PlaySound(SoundFileNameE.Move);
            //}
        }
        public void SwapPlayersIfNeeded()
        {
            if (Flags.IsSwapPlayersRequired)
            {
                SwapPlayers();
            }
        }

        #endregion

        #region SendMovesToEngine
        public void OnSendMovesToEngine(string gameMoves, long turnCounterWhite, long turnCounterBlack)
        {
            if (AfterSendMovesToEngine != null)
            {
                AfterSendMovesToEngine(gameMoves, turnCounterWhite, turnCounterBlack);
            }
        }
        #endregion

        #region Delete Comentary
        public void DeleteCurrentMoveComentary()
        {
            DeleteComentary(CurrentMove.Id);
            Notations.SetNotation(CurrentMove, "", false,false);
        }

        public void DeleteComentary(int moveId)
        {
            for (int i = 0; i < Moves.Count; i++)
            {
                Move m = Moves[i];
                if (m.Id == moveId)
                {
                    m.Game = this;
                    m.DeleteComments();
                    Notations.SetNotationView(m);
                    break;
                }
            }

            CurrentMove.DeleteComments();
        }

        public void DeleteAllComentary()
        {
            for (int i = 0; i < Moves.Count; i++)
            {
                Move m = Moves[i];
                m.Game = this;
                m.DeleteComments();
                Notations.SetNotationView(m);
            }

            CurrentMove.DeleteComments();

            Notations.SetNotation(CurrentMove, "", false,true);
        }
        #endregion

        #region InfiniteAnalysis

        public void StartInfiniteAnalysis()
        {
            Flags.IsInfiniteAnalysisOn = true;
            //Clock.Reset(0, 0);
            Clock.Reset();

            if (StartAnalysis != null)
            {
                StartAnalysis(this, EventArgs.Empty);
            }
        }

        public void StopInfiniteAnalysis()
        {
            Flags.IsInfiniteAnalysisOn = false;
            Clock.Reset();

            if (StopAnalysis != null)
            {
                StopAnalysis(this, EventArgs.Empty);
            }
        }

        #endregion

        #region RootMove
        public Move GetRootMove()
        {
            Move m = Move.NewMove();
            m.Game = this;

            m.Id = -1;

            m.SetFen(ChessLibrary.FenParser.InitialBoardFen);

            return m;
        }
        #endregion

        #region Helper Class
        public class SelectCurrentMoveChildrenEventArgs : System.ComponentModel.CancelEventArgs
        {
            public Move Move = null;
            public SelectCurrentMoveChildrenEventArgs()
            {
            }
        }
        #endregion

        #region GameWindowClosed

        public void GameWindowClosed()
        {
            ChessTypeE chessType = (ChessTypeE)Ap.PlayingMode.ChessTypeID;// PlayingModeData.Instance.ChessTypeID;
            UserStatusE userStatus = UserStatusE.Blank;

            // by default user status set to "Playing"
            userStatus = UserStatusE.Playing;

            // if closing playing game window and atleast one kibitzer window is opened, then user status will be "Kibitzer"
            if (Ap.KibitzersCount > 0 && (!Ap.IsGameInProgress || (Ap.IsGameInProgress && Ap.Game.DbGame.ID == this.DbGame.ID)))
            {
                userStatus = UserStatusE.Kibitzer;
            }
            // if close playing game window and there is no kibitzer, then user status will be one of the following options (based on chess type)"
            else if (Ap.KibitzersCount == 0 && Ap.IsGameInProgress && Ap.Game.DbGame.ID == this.DbGame.ID)
            {
                switch (chessType)
                {
                    case ChessTypeE.None:
                    case ChessTypeE.Human:
                    case ChessTypeE.Correspondence:
                        userStatus = UserStatusE.Blank;
                        break;
                    case ChessTypeE.Engine:
                        userStatus = UserStatusE.Engine;
                        break;
                    case ChessTypeE.Centaur:
                        userStatus = UserStatusE.Centaur;
                        break;
                    default:
                        break;
                }
            }
            // if closing kibitzer window and there is no other kibitzer or playing game window, then user status will be one of the following options (based on chess type)"
            else if (Ap.KibitzersCount == 0 && !Ap.IsGameInProgress)
            {
                switch (chessType)
                {
                    case ChessTypeE.None:
                    case ChessTypeE.Human:
                    case ChessTypeE.Correspondence:
                        userStatus = UserStatusE.Blank;
                        break;
                    case ChessTypeE.Engine:
                        userStatus = UserStatusE.Engine;
                        break;
                    case ChessTypeE.Centaur:
                        userStatus = UserStatusE.Centaur;
                        break;
                    default:
                        break;
                }
            }

            UserLeaveGame(userStatus);

            Ap.MsgQueue.Clear(this.DbGame.GameID);

            DbGame = null;
        }
        #endregion

        #region Copy 

        public Game Copy()
        {
            Game g = new Game(this);
            return g;
        }

        #endregion
    }
}
