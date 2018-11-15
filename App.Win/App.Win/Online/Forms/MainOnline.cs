using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FullScreenMode;
using App.Model;
using InfinityChess.Offline.Forms;
using InfinitySettings.EngineManager;
using App.Win;
using App.Model.Db;
using Game = App.Model.Game;

namespace InfinityChess.WinForms
{
    public partial class MainOnline : MainForm, IMsgQueueConsumer
    {
        #region Data Members
        delegate void SetTextCallback(DataTable dt);
        private bool isGameStarted = false;
        private Timer closeTimer = null;
        private int CloseWindowCounter = 10;
        private bool IsChangeColor = true;
        #endregion

        #region Ctor
        public MainOnline()
        {
            base.Game = Ap.Game;

            InitializeComponent();
        }

        public MainOnline(Game game)
            : base(game)
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        protected virtual bool IsOffline
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return false; }
        }
        public override TableLayoutPanel OuterControl
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return this.tableLayoutPanel1;
            }
        }
        #endregion

        #region Load

        private void MainOnline_Load(object sender, EventArgs e)
        {
            this.Visible = false;

            #region Create Controls

            if (base.Game != null)
            {
                #region Create Objects
                base.ClockUc = new ClockUc(base.Game);
                base.NotationUc = new NotationUc(base.Game, this);
                base.GameInfoUc = base.NotationUc.GameInfoUc;
                base.ScoringUc = new ScoringUc(base.Game);
                base.BookUc = new BookUc(base.Game, this);
                base.CapturePieceUc = base.NotationUc.CapturePieceUc;
                base.ChatUc = new ChatUc(base.Game);
                base.ChessBoard = new ChessBoard(base.Game);
                base.AnalysisUc = new AnalysisUc(true, base.Game, this);
                base.AnalysisUc1 = new AnalysisUc(true, base.Game, this);
                base.AnalysisUc2 = new AnalysisUc(false, base.Game, this);
                base.AudienceUc = new AudienceUc();
                #endregion

                #region Register Controls
                base.GameUcList.Add("ClockUc", base.ClockUc);
                base.GameUcList.Add("GameInfoUc", base.GameInfoUc);
                base.GameUcList.Add("NotationUc", base.NotationUc);
                base.GameUcList.Add("ScoringUc", base.ScoringUc);
                base.GameUcList.Add("BookUc", base.BookUc);
                base.GameUcList.Add("CapturePieceUc", base.CapturePieceUc);
                base.GameUcList.Add("ChatUc", base.ChatUc);
                base.GameUcList.Add("AnalysisUc", base.AnalysisUc);
                base.GameUcList.Add("ChessBoard", base.ChessBoard);
                base.GameUcList.Add("AnalysisUc", base.AnalysisUc);
                base.GameUcList.Add("AnalysisUc1", base.AnalysisUc1);
                base.GameUcList.Add("AnalysisUc2", base.AnalysisUc2);
                base.GameUcList.Add("AudienceUc", base.AudienceUc);

                base.GameUcList.Init();

                #endregion

                KibitzerManager = new KibitzerManager(base.Game);
            }
            #endregion

            InitDockingEvents();

            #region Events
            ApWin.OnlineClientForm.OnDisconnect += new EventHandler(OnlineClientForm_OnDisconnect);
            ApWin.OnlineClientForm.OnConnect += new EventHandler(OnlineClientForm_OnConnect);
            NotationUc.OnRefresh += new EventHandler(NotationUc_OnRefresh);
            #endregion
        }

        void NotationUc_OnRefresh(object sender, EventArgs e)
        {
            tsShowComments.Checked = Ap.Options.ShowComments;
            tsShowMoveLogs.Checked = Ap.Options.ShowDisconnectionLog;
        }

        void OnlineClientForm_OnConnect(object sender, EventArgs e)
        {
            this.Game.Connected();
        }

        void OnlineClientForm_OnDisconnect(object sender, EventArgs e)
        {
            this.Game.Disconnected();
        }

        private void MainOnline_FormClosing(object sender, FormClosingEventArgs e)
        {
            #region Finish Game
            if (!base.Game.Flags.IsTournamentMatchForcedWin)
            {
                if (!base.Game.Flags.IsGameFinished && base.Game.GameMode != GameMode.Kibitzer)
                {
                    if (!isGameStarted && !base.Game.Flags.IsTournamentMatch)
                    {
                        if (MessageForm.Confirm(this, MsgE.ConfirmAbortGame) == DialogResult.No)
                        {
                            e.Cancel = true;
                            return;
                        }
                        else
                        {
                            Abort();
                        }
                    }
                    else if (MessageForm.Confirm(this, MsgE.ConfirmResignGame) == DialogResult.No)
                    {
                        e.Cancel = true;
                        return;
                    }
                    else
                    {
                        Resign();
                    }
                }
                else
                {
                    base.Game.Finish(GameResultE.NoResult);
                }
            }
            #endregion

            #region UnInit MainOnline
            if (!e.Cancel)
            {
                Ap.MsgQueue.UnRegister(this);

                base.GameUcList.UnInit();
                base.GameUcList.Clear();

                UnInitDockingEvents();

                RemoveAllKibitzers();
                SaveDocking();

                if (closeTimer != null)
                {
                    closeTimer.Tick -= new EventHandler(closeTimer_Tick);
                }

                if (base.Game.GameMode == GameMode.Kibitzer)
                {
                    Ap.KibitzersCount--;
                }

                base.Game.CloseEngines();
                base.Game.GameWindowClosed();

                if (Ap.IsGameInProgress)
                {
                    Ap.FinishGame();
                }
            }
            #endregion
        }

        private void MainOnline_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.chat.UnInit();
        }

        private void LoadGame(int challengeID, ChallengeStatusE challengeStatus, int gameID)
        {
            switch (challengeStatus)
            {
                case ChallengeStatusE.None:
                    GetAudienceGame(gameID);
                    if (base.Game.DbGame != null)
                    {
                        NewGame();
                        SetGamePrameters(base.Game.DbGame.GameXml, false);
                    }
                    AudienceUc.FillAudienceGrid(base.Game.Audience);
                    break;
                case ChallengeStatusE.Seeking:
                    AddGame(challengeID);
                    if (base.Game.DbGame != null)
                    {
                        NewGame();
                    }
                    break;
                case ChallengeStatusE.Accepted:
                    GetSetGame(challengeID);
                    if (base.Game.DbGame != null)
                    {
                        NewGame();
                    }
                    break;
                case ChallengeStatusE.Withdraw:
                    break;
                case ChallengeStatusE.Decline:
                    break;
                default:
                    break;
            }
        }

        private void LoadGame(int gameID)
        {
            GetSetGameByGameId(gameID);
            if (base.Game.DbGame != null)
            {
                NewGame();
                SetGamePrameters(base.Game.DbGame.GameXml, true);
            }
            AudienceUc.FillAudienceGrid(base.Game.Audience);
        }

        private void LoadGame()
        {
            if (base.Game.DbGame != null)
            {
                NewGame();
                SetGamePrameters(base.Game.DbGame.GameXml, true);
            }
        }

        #endregion

        #region Statusbar
        private void SetStatusbarMessage(string message)
        {
            tsStatusMessage.Text = message;
        }
        #endregion

        #region MainOnline Events

        void Instance_ServerDownError(string error)
        {
            try
            {
                //tsStatusMessage.Text = error;
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
            }
        }

        #endregion

        #region Static ShowMainOnline

        static ProgressForm frmProgress;
        public static void ShowMainOnline(int challengeID, ChallengeStatusE status, int gameID)
        {
            Ap.NewGame();
            MainOnline mainOnlineForm = new InfinityChess.WinForms.MainOnline();

            frmProgress = ProgressForm.Show(mainOnlineForm, "Loading...");

            mainOnlineForm.Game = Ap.Game;
            mainOnlineForm.Show();
            mainOnlineForm.LoadGame(challengeID, status, gameID);

            frmProgress.Close();

            ActivateMainForm(mainOnlineForm);
        }

        public static bool LoadGameByChallengeID(int challengeID)
        {
            DataSet ds = SocketClient.AddGameData(challengeID, PlayingModeData.Instance.ChessTypeID);

            if (ds == null || ds.Tables.Count == 0)
            {
                return false;
            }

            Ap.NewGame();
            MainOnline mainOnlineForm = new InfinityChess.WinForms.MainOnline();

            frmProgress = ProgressForm.Show(mainOnlineForm, "Loading...");

            mainOnlineForm.Game = Ap.Game;
            mainOnlineForm.Show();
            mainOnlineForm.Game.DbGame = App.Model.Db.Game.CreateGame(Ap.Cxt, ds);

            if (mainOnlineForm.Game.DbGame != null)
            {
                mainOnlineForm.NewGame();
            }

            frmProgress.Close();

            ActivateMainForm(mainOnlineForm);
            return true;
        }

        public static void ShowMainOnline(int gameID)
        {
            if (LoadKibitzerGame(gameID))
            {
                return;
            }

            MainOnline mainOnlineForm = new InfinityChess.WinForms.MainOnline();

            frmProgress = ProgressForm.Show(mainOnlineForm, "Loading...");

            mainOnlineForm.Game = new Game();
            mainOnlineForm.Show();
            mainOnlineForm.LoadGame(gameID);

            frmProgress.Close();

            ActivateMainForm(mainOnlineForm);
            Ap.KibitzersCount++;
        }

        public static bool ShowMainOnline(DataSet ds, bool isLoadLastGame)
        {
            App.Model.Db.Game dbGame = App.Model.Db.Game.CreateGame(Ap.Cxt, ds);
            if (dbGame == null)
            {
                return false;
            }

            Ap.NewGame();
            MainOnline mainOnlineForm = new InfinityChess.WinForms.MainOnline();

            frmProgress = ProgressForm.Show(mainOnlineForm, "Loading...");

            mainOnlineForm.Game = Ap.Game;
            mainOnlineForm.Game.DbGame = dbGame;

            if (isLoadLastGame)
            {
                SetUserEngine(mainOnlineForm.Game);
            }

            mainOnlineForm.Show();
            mainOnlineForm.LoadGame();

            frmProgress.Close();

            ActivateMainForm(mainOnlineForm);

            return true;
        }

        static void ActivateMainForm(MainOnline mainOnlineForm)
        {
            mainOnlineForm.ShowAll();
            frmProgress = null;

            mainOnlineForm.GetOpponentSystemInfo();

            HideToolStrip(mainOnlineForm);
        }

        static void HideToolStrip(MainOnline mainOnlineForm)
        {
            if (mainOnlineForm.Game.Flags.IsGameFinished)
            {
                mainOnlineForm.toolStrip1.Enabled = false;
            }
        }

        private static void SetUserEngine(Game game)
        {
            if (game.DbGame.IsCurrentUserWhite && game.DbGame.WhiteChessTypeIDE == ChessTypeE.Engine)
            {
                LoadUserEngine(game, game.DbGame.WhiteEngineID, game.DbGame.WhiteChessTypeID, Ap.EngineOptions.WhiteBook);
            }
            else if (game.DbGame.IsCurrentUserBlack && game.DbGame.BlackChessTypeIDE == ChessTypeE.Engine)
            {
                LoadUserEngine(game, game.DbGame.BlackEngineID, game.DbGame.BlackChessTypeID, Ap.EngineOptions.WhiteBook);
            }
            else
            {
                SocketClient.GetSetIntruptedGameUserEngine(1, UserStatusE.Playing);
                Ap.CurrentUser.EngineID = 1;
                Ap.PlayingMode.SelectedEngine = null;
                Ap.PlayingMode.ChessTypeID = 1;
            }
        }

        private static void LoadUserEngine(Game game, int engineID, int chessTypeID, string bookFile)
        {
            DataSet dataset = SocketClient.GetSetIntruptedGameUserEngine(engineID, UserStatusE.Playing);

            if (dataset != null && dataset.Tables.Count > 0)
            {
                if (dataset.Tables[0] != null && dataset.Tables[0].Rows.Count > 0)
                {
                    App.Model.Db.Engine engine = new App.Model.Db.Engine(Ap.Cxt, dataset.Tables[0].Rows[0]);

                    InfinitySettings.EngineManager.EngineManager objEngineManager = new InfinitySettings.EngineManager.EngineManager();
                    List<InfinitySettings.EngineManager.Engine> lstEngine = objEngineManager.LoadEngines();
                    InfinitySettings.EngineManager.Engine eng = lstEngine.Where(x => x.IsActive == true && x.EngineTitle.Replace(".exe", "") == engine.Name).FirstOrDefault();

                    if (eng != null)
                    {
                        UCIEngine selectedEngine = new UCIEngine(eng.FilePath, Ap.EngineOptions.HashTableSize, game);

                        selectedEngine.Load();
                        selectedEngine.Close();

                        Ap.PlayingMode.SelectedEngine = selectedEngine;
                        Ap.PlayingMode.ChessTypeID = chessTypeID;
                        Ap.PlayingMode.SelectedBook = new Book(game, bookFile);
                    }
                }
            }
        }

        private static bool LoadKibitzerGame(int gameId)
        {
            MainOnline mainOnline = null;
            bool gameLoaded = false;

            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(MainOnline))
                {
                    mainOnline = frm as MainOnline;
                    if (mainOnline.Game.DbGame.ID == gameId)
                    {
                        mainOnline.Activate();
                        gameLoaded = true;
                        break;
                    }
                }
            }

            return gameLoaded;
        }

        #endregion

        #region GetOpponentSystemInfo
        private void GetOpponentSystemInfo()
        {
            SocketClient.Instance.ServerDownError += new SocketClient.OnServerDownErrorEventHandler(Instance_ServerDownError);
            Ap.MsgQueue.Register(this);

            if (base.Game.GameMode == GameMode.OnlineEngineVsEngine)
            {
                SocketClient.SystemInformation(base.Game.DbGame.OpponentUserID, ChatTypeE.GameWindow);
            }
        }

        #endregion

        #region Show/Hide Methods

        public void ShowAll()
        {
            this.WindowState = FormWindowState.Maximized;
            this.ShowInTaskbar = true;
        }

        public void HideAll()
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        #endregion

        #region Menus Event Handlers
        private void gotoInfinityChessMenuItem_Click(object sender, EventArgs e)
        {
            Ap.OpenHomeUrl();
        }

        private void tsOpenDataFolder_Click(object sender, EventArgs e)
        {
            Ap.OpenFolderData();
        }

        #endregion

        #region Save Game In Default Game Database i.e 'database.icd' Or In New Database
        public void SaveGame(bool isSaveAs)
        {
            SaveFileDialog sfdSaveGame = new SaveFileDialog();
            sfdSaveGame.Filter = "Databases icd(*" + Files.DatabaseExtension + ")|*" + Files.DatabaseExtension;
            sfdSaveGame.FileName = "*" + Files.DatabaseExtension;
            sfdSaveGame.InitialDirectory = Ap.FolderDatabase;
            if (isSaveAs)
            {
                if (sfdSaveGame.ShowDialog() == DialogResult.OK)
                {
                    InfinityChess.GameData.frmGameData frmGameData = new InfinityChess.GameData.frmGameData(this);
                    frmGameData.Game = base.Game;
                    if (frmGameData.ShowDialog(this) == DialogResult.OK)
                    {
                        string fileName = sfdSaveGame.FileName;
                        if (!fileName.EndsWith(Files.DatabaseExtension))
                        {
                            fileName = fileName + Files.DatabaseExtension;
                        }
                        base.Game.GameData.Guid = string.Empty;
                        base.Game.SaveGame(fileName);
                        Ap.Databases.Add(fileName);
                        Ap.Options.CurrentGameGuid = base.Game.GameData.Guid;
                        Ap.Options.CurrentGameDatabaseFilePath = fileName;
                        Ap.Options.Save();
                        //GameSelectedMode();
                        if (this.DatabaseForm != null)
                        {
                            this.DatabaseForm.FocusOpenedDatabaseForm();
                        }
                    }
                }
            }
            else
            {
                InfinityChess.GameData.frmGameData frmGameData = new InfinityChess.GameData.frmGameData(this);
                frmGameData.Game = base.Game;
                if (frmGameData.ShowDialog(this) == DialogResult.OK)
                {
                    base.Game.GameData.Guid = string.Empty;
                    base.Game.SaveGame(Ap.DefaultDatabaseFilePath);
                    Ap.Databases.Add(Ap.DefaultDatabaseFilePath);
                    Ap.Options.CurrentGameGuid = base.Game.GameData.Guid;
                    Ap.Options.CurrentGameDatabaseFilePath = Ap.DefaultDatabaseFilePath;
                    Ap.Options.Save();
                }
            }
        }
        #endregion

        #region IMsgQueueConsumer Members

        void IMsgQueueConsumer.ConsumeMessage(Kv kv)
        {
            ISynchronizeInvoke synchronizer = this;

            MsgQueue.SyncConsumeMessage s = new MsgQueue.SyncConsumeMessage(SynchronizeConsumeMessage);

            synchronizer.Invoke(s, new object[] { kv });
        }

        int IMsgQueueConsumer.GameID
        {
            get
            {
                if (base.Game == null || base.Game.DbGame == null)
                {
                    return -1;
                }

                return base.Game.DbGame.ID;
            }
        }

        Game IMsgQueueConsumer.Game
        {
            get
            {
                if (base.Game == null || base.Game.DbGame == null)
                {
                    return null;
                }

                return base.Game;
            }
        }

        #endregion
    }
}

