using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ChessLibrary;
using InfinitySettings.UCIManager;
using InfinitySettings.EngineManager;
using System.Threading;
using FullScreenMode;
using InfinityChess.Offline.Forms;
using App.Win;
using App.Model;
using System.Diagnostics;
using WeifenLuo.WinFormsUI.Docking;

namespace InfinityChess.WinForms
{
    #region enum
    public enum WindowPane
    {
        Clock,
        Analysis,
        Analysis1,
        Analysis2,
        Notation,
        CapturedPieces,
        Kibitzer
    }

    #endregion

    public partial class MainForm : DockContent       
    {
        #region Data Members
        public Game Game = null;
        public KibitzerManager KibitzerManager = null;
        public GameUcList GameUcList = new GameUcList();

        public DatabaseForm DatabaseForm = null;
        protected FullScreen fullScreen;
        ProgressForm frmProgress;
        protected DockPanel dp;

        public readonly int DockPanelWidth = 200;
        public readonly int BoardPanelWidth = 825;
        public readonly int BoardSerialNo = 30;

        #endregion

        #region Delegates/Events

        #endregion

        #region Ctor
        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(Game game)
        {
            Game = game;

            InitializeComponent();
        }

        #endregion

        #region Property

        #region Uc

        InfinityChess.BookUc bookUc;
        public InfinityChess.BookUc BookUc
        {
            [DebuggerStepThrough]
            get { return bookUc; }
            [DebuggerStepThrough]
            set { bookUc = value; }
        }

        InfinityChess.GameInfoUc gameInfoUc;
        public InfinityChess.GameInfoUc GameInfoUc
        {
            [DebuggerStepThrough]
            get { return gameInfoUc; }
            [DebuggerStepThrough]
            set { gameInfoUc = value; }
        }

        NotationUc notationUc;
        public NotationUc NotationUc
        {
            [DebuggerStepThrough]
            get { return notationUc; }
            [DebuggerStepThrough]
            set { notationUc = value; }
        }

        ScoringUc scoringUc;
        public ScoringUc ScoringUc
        {
            [DebuggerStepThrough]
            get { return scoringUc; }
            [DebuggerStepThrough]
            set { scoringUc = value; }
        }

        AnalysisUc analysisUc;
        public AnalysisUc AnalysisUc
        {
            [DebuggerStepThrough]
            get { return analysisUc; }
            [DebuggerStepThrough]
            set { analysisUc = value; }
        }

        AnalysisUc analysisUc1;
        public AnalysisUc AnalysisUc1
        {
            [DebuggerStepThrough]
            get { return analysisUc1; }
            [DebuggerStepThrough]
            set { analysisUc1 = value; }
        }

        AnalysisUc analysisUc2;
        public AnalysisUc AnalysisUc2
        {
            [DebuggerStepThrough]
            get { return analysisUc2; }
            [DebuggerStepThrough]
            set { analysisUc2 = value; }
        }

        ClockUc clockUc;
        public ClockUc ClockUc
        {
            get { return clockUc; }
            set { clockUc = value; }
        }

        CapturePieceUc capturePieceUc;
        public CapturePieceUc CapturePieceUc
        {
            get { return capturePieceUc; }
            set { capturePieceUc = value; }
        }

        App.Win.AudienceUc audienceUc;
        public App.Win.AudienceUc AudienceUc
        {
            get { return audienceUc; }
            set { audienceUc = value; }
        }

        App.Win.ChatUc chatUc;
        public App.Win.ChatUc ChatUc
        {
            get { return chatUc; }
            set { chatUc = value; }
        }

        ChessBoard chessBoard1 = null;
        public ChessBoard ChessBoard
        {
            [DebuggerStepThrough]
            get { return chessBoard1; }
            [DebuggerStepThrough]
            set { chessBoard1 = value; }
        }

        public DevUc DevUc;

        public virtual TableLayoutPanel OuterControl
        {
            [DebuggerStepThrough]
            get { return null; }
        }

        #endregion

        protected bool IsCreateDockingRequied
        {
            get { return this.Game.Flags.IsNewGameMode || dp == null; }
        }

        protected bool IsNonFlippedBoard
        {
            get { return ChessBoardUc.Flipped || this.Game.E2EGamesCount == 0 || !Ap.EngineOptions.FlipBoard; }
        }

        #endregion

        #region MainForm Events

        private void MainForm_Load(object sender, EventArgs e)
        {
            DevUc = new DevUc();
            DevUc.Game = this.Game;

            if (this.Game != null)
            {
                this.Game.AfterPaste += new EventHandler(Game_AfterPaste);
                this.Game.BeforeNewGame += new EventHandler<NewGameEventArgs>(Game_BeforeNewGame);
                this.Game.AfterNewGame += new EventHandler(Game_AfterNewGame);
                this.Game.SaveDocking += new EventHandler(Game_SaveDocking);
                this.Game.CreateDocking += new EventHandler(Game_CreateDocking);
                this.Game.BeforeFinish += new EventHandler(Game_BeforeFinish);
                this.Game.AfterFinish += new EventHandler(Game_AfterFinish);
                this.Game.Book.BookLoaded += new EventHandler(Book_BookLoaded);
                this.Game.Book.BookClosed += new EventHandler(Book_BookClosed);
                this.Game.BeforeSetFen += new EventHandler(Game_BeforeSetFen);
                this.Game.AfterSetFen += new EventHandler(Game_AfterSetFen);
                this.Game.AfterSwapPlayers += new EventHandler(Game_AfterSwapPlayers);
                this.Game.AfterAddMove += new EventHandler(Game_AfterAddMove);
                this.Game.BeforeMoveTo += new EventHandler<MoveToEventArgs>(Game_BeforeMoveTo);
                this.Game.AfterMoveTo += new EventHandler<MoveToEventArgs>(Game_AfterMoveTo);
                this.Game.AfterSendMovesToEngine += new Game.AfterSendMovesToEngineEventHandler(Game_AfterSendMovesToEngine);                
                this.Game.BeforeLoadGame += new EventHandler(Game_BeforeLoadGame);
                this.Game.AfterLoadGame += new EventHandler(Game_AfterLoadGame);
            }

            Ap.Eco.EcoReceived += new EventHandler<EcoMoveEventArgs>(Eco_EcoReceived);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Game.GameMode == GameMode.EngineVsEngine)
            {
                return;
            }

            frmProgress = null;

            this.Game.BeforeNewGame -= new EventHandler<NewGameEventArgs>(Game_BeforeNewGame);
            this.Game.AfterNewGame -= new EventHandler(Game_AfterNewGame);
            this.Game.SaveDocking -= new EventHandler(Game_SaveDocking);
            this.Game.CreateDocking -= new EventHandler(Game_CreateDocking);
            this.Game.BeforeFinish -= new EventHandler(Game_BeforeFinish);
            this.Game.AfterFinish -= new EventHandler(Game_AfterFinish);
            this.Game.Book.BookLoaded -= new EventHandler(Book_BookLoaded);
            this.Game.Book.BookClosed -= new EventHandler(Book_BookClosed);
            this.Game.BeforeSetFen -= new EventHandler(Game_BeforeSetFen);
            this.Game.AfterSetFen -= new EventHandler(Game_AfterSetFen);
            this.Game.AfterSwapPlayers -= new EventHandler(Game_AfterSwapPlayers);
            this.Game.AfterAddMove -= new EventHandler(Game_AfterAddMove);
            this.Game.BeforeMoveTo -= new EventHandler<MoveToEventArgs>(Game_BeforeMoveTo);
            this.Game.AfterMoveTo -= new EventHandler<MoveToEventArgs>(Game_AfterMoveTo);
            this.Game.AfterSendMovesToEngine -= new Game.AfterSendMovesToEngineEventHandler(Game_AfterSendMovesToEngine);            
            Ap.Eco.EcoReceived -= new EventHandler<EcoMoveEventArgs>(Eco_EcoReceived);
        }

        void MainForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            ChessBoardUc.StartGame();
        }

        #region Main Form Key Events

        public System.Windows.Forms.Timer tmrSpaceBar;

        protected void InitSpaceBarTimer()
        {
            this.Game.SpaceBarCounter = 0;
            tmrSpaceBar = new System.Windows.Forms.Timer();
            tmrSpaceBar.Interval = 300;
            tmrSpaceBar.Tick += new EventHandler(tmrSpaceBar_Tick);
            tmrSpaceBar.Start();
        }

        void tmrSpaceBar_Tick(object sender, EventArgs e)
        {
            tmrSpaceBar.Stop();
            if (this.Game.Flags.IsForceEngineMoveAllowed)
            {
                if (this.Game.SpaceBarCounter > 1)
                {
                    this.Game.SpaceBarCounter = 1;
                }
                this.Game.SpaceBarCounter--;
                this.Game.Flags.IsMoveInProgress = true;
                ForceEngineToPlay();
            }

            tmrSpaceBar.Start();
        }

        protected override bool ProcessKeyPreview(ref System.Windows.Forms.Message m)
        {
            if (this.Game.GameMode != GameMode.HumanVsEngine && this.Game.GameMode != GameMode.HumanVsHuman)
            {
                return false;
            }

            switch ((Keys)m.WParam.ToInt32())
            {
                case Keys.Space:
                    if (m.Msg == 256)
                    {
                        this.Game.SpaceBarCounter++;
                    }
                    else if (m.Msg == 257)
                    {
                        if (this.Game.SpaceBarCounter > 1)
                        {
                            this.Game.SpaceBarCounter = 1;
                        }
                    }
                    break;
                case Keys.Left:
                    if (m.Msg == 256)
                    {
                        this.Game.MoveTo(MoveToE.Previous, false);
                    }
                    break;
                case Keys.Right:
                    if (m.Msg == 256)
                    {
                        if (BookUc.Visible)
                        {
                            this.Game.MoveTo(MoveToE.Next, true);
                        }
                        else
                        {
                            this.Game.MoveTo(MoveToE.Next, false);
                        }
                    }
                    break;
                case Keys.T:
                    if (m.Msg == 256)
                    {
                        TestForm frm = new TestForm(this.Game);
                        frm.Show();
                    }      
                    break;
            }

            return false;
        }

        #endregion
        #endregion

        #region Game Events

        void Game_SaveDocking(object sender, EventArgs e)
        {
            RemoveAllKibitzers();
            SaveDocking();
        }

        void Game_CreateDocking(object sender, EventArgs e)
        {
            GameCreateDocking();
        }

        void Game_AfterNewGame(object sender, EventArgs e)
        {
            GameAfterNewGame();
        }

        protected virtual void GameAfterNewGame()
        {

        }

        void Game_AfterPaste(object sender, EventArgs e)
        {
            GameAfterPaste();
        }

        protected virtual void GameAfterPaste()
        {

        }

        void Game_BeforeNewGame(object sender, NewGameEventArgs e)
        {
            GameBeforeNewGame(e);
        }

        protected virtual void GameBeforeNewGame(NewGameEventArgs e)
        {

        }

        void Game_BeforeMoveTo(object sender, MoveToEventArgs e)
        {
            
        }

        void Game_AfterMoveTo(object sender, MoveToEventArgs e)
        {
            KibitzerManager.SendMoveToKibitzer(e.Move);
        }

        void Game_AfterSendMovesToEngine(string moves, long whiteTurnSeconds, long blackTurnSeconds)
        {
            KibitzerManager.SendMoveToKibitzer(moves, whiteTurnSeconds, blackTurnSeconds);
        }

        void Game_AfterAddMove(object sender, EventArgs e)
        {
            GameAfterMoveAdd();
        }

        protected virtual void GameAfterMoveAdd()
        {
            SetClockMenuItem(true);

            if (this.Game.GameMode != GameMode.EngineVsEngine && string.IsNullOrEmpty(this.Game.GameData.Result))
            {
                EnableDrawResignButtons(true);
            }
        }

        void Game_AfterSwapPlayers(object sender, EventArgs e)
        {
            RefreshGameInfo();
        }

        void Game_AfterSetFen(object sender, EventArgs e)
        {
            GameAfterSetFen();
        }

        protected virtual void GameAfterSetFen()
        {
            ChessBoardUc.SetFen(this.Game.BoardFen);
        }

        void Game_BeforeSetFen(object sender, EventArgs e)
        {

        }

        void Game_BeforeFinish(object sender, EventArgs e)
        {
            GameBeforeFinish();
        }

        void Game_AfterFinish(object sender, EventArgs e)
        {
            GameAfterFinish();
        }

        protected virtual void GameBeforeFinish()
        {

        }

        protected virtual void GameAfterFinish()
        {

        }

        protected virtual void Book_BookLoaded(object sender, EventArgs e)
        {
            BookBookLoaded();
        }

        protected virtual void BookBookLoaded()
        {

        }

        protected virtual void Book_BookClosed(object sender, EventArgs e)
        {
            BookBookClosed();
        }

        protected virtual void BookBookClosed()
        {

        }

        void Game_BeforeLoadGame(object sender, EventArgs e)
        {
            if (this.IsDisposed)
            {
                return;
            }

            frmProgress = ProgressForm.Show(this, "Loading Game...");
        }

        void Game_AfterLoadGame(object sender, EventArgs e)
        {
            RefreshGameInfo();

            if (frmProgress == null)
            {
                return;
            }

            if (frmProgress.IsDisposed)
            {
                return;
            }

            frmProgress.Close();
        }

        void Eco_EcoReceived(object sender, EcoMoveEventArgs e)
        {
            GameInfoUc.RefreshEco(e.EcoCode);
        }
        
        #endregion

        #region FlipBoard

        public virtual void FlipBoard()
        {
            ChessBoardUc.Flipped = !ChessBoardUc.Flipped;
        }

        #endregion

        #region Layout

        public void ChangeMainEngine(UCIEngine engine)
        {
            this.Game.DefaultEngine.Pause();
            this.Game.SwapPlayersIfNeeded();
            if (this.Game.IsDefaultEngine(engine))
            {
                this.Game.DefaultEngine.Resume();
                return;
            }

            this.Game.Clock.Stop();
            this.Game.PreviousPonderMove = "";
            this.Game.DefaultEngine.Close();
            this.Game.DefaultEngine = engine;
            AnalysisUc.ChangeEngine(engine);
            AnalysisUc.TabText = engine.EngineTitle;

            if (this.Game.GameMode == App.Model.GameMode.HumanVsEngine)
            {

                if (this.Game.CurrentPlayer.IsWhite)
                {
                    this.Game.Player2.Engine = this.Game.DefaultEngine;
                }
                else
                {
                    this.Game.Player1.Engine = this.Game.DefaultEngine;
                }

                ChessBoardUc.SetEvents();
                this.Game.GameData.Black1 = this.Game.DefaultEngine.EngineName;
                this.RefreshGameInfo();
            }
        }

        public virtual void EnableDrawResignButtons(bool enabled)
        {

        }

        #endregion

        #region Game

        #region Swap Players

        private void SwapPlayers()
        {
            this.Game.SwapPlayers();

            RefreshGameInfo();
        }

        #endregion


        public virtual void GameIsStarted()
        {

        }

        public virtual void GameIsFinished()
        {

        }

        public void ForceEngineToPlay()
        {
            SwapPlayers();
            ChessBoardUc.ForceEngineToPlay();
        }

        #endregion

        #region Virtual Methods

        public virtual void SetClockMenuItem(bool doClockContinue)
        {

        }

        public virtual void ImportGame()
        {}

        public virtual void ImportPgnGame()
        {}

        public virtual void NewOpeningBook()
        {}

        public virtual void GameSelectedMode()
        {
            
        }

        #endregion

        #region SaveAsBitmap
        public void SaveAsBitmap(string fileName)
        {
            ChessBoard.SaveAsBitmap(fileName);
        }
        #endregion

        #region RefreshTitle
        protected void RefreshTitle()
        {
            this.Game.Player1.PlayerTitle = this.Game.GameData.WhiteTitle;
            this.Game.Player2.PlayerTitle = this.Game.GameData.BlackTitle;

            this.Text = this.Game.GameWindowTitle;
        }
        #endregion

    }
}