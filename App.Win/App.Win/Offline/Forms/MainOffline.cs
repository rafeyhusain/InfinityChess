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
using System.Diagnostics;
using Crom.Controls.Docking;
using System.IO;
using App.Win;


namespace InfinityChess.WinForms
{
    public partial class MainOffline : MainForm
    {
        #region Data Members
        
        DataTable tempDataTable = null;
        Timer AutoSaveGameTimer = new Timer();

        public int totalGamesCount = 0;
        private bool isTotalGameCountSet = false;
        GameSearchProgress progressForm;
        PgnManager pgn;
        IcdManager Icd;
        #endregion

        #region Properties
        public override TableLayoutPanel OuterControl
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return this.tableLayoutPanel1;
            }
        }
        public DatabaseForm databaseForm
        {
            get
            {
                if (this.DatabaseForm != null)
                {
                    return this.DatabaseForm;
                }
                else
                {
                    this.DatabaseForm = new DatabaseForm(this, base.Game);
                    return this.DatabaseForm;
                }
            }

        }

        public GameType NewGameType
        {
            get
            {
                GameType gameType = Ap.Options.GameType;
                if (gameType == GameType.None)
                {
                    gameType = GameType.Blitz;
                }
                return gameType;
            }
        }

        #endregion

        #region Ctor
        
        public MainOffline()
            : this(Ap.Game)
        {
            
        }

        public MainOffline(Game game)
            : base(game)
        {
            InitializeComponent();
        }
        
        #endregion

        #region Form Events
        private void MainOffline_Load(object sender, EventArgs e)
        {
            this.Visible = false;

            #region Create Controls

            #region Create Objects
            base.ClockUc = new ClockUc(base.Game);
            base.NotationUc = new NotationUc(base.Game, this);
            base.GameInfoUc = base.NotationUc.GameInfoUc;
            base.ScoringUc = new ScoringUc(base.Game);
            base.BookUc = new BookUc(base.Game, this);
            base.CapturePieceUc = base.NotationUc.CapturePieceUc;
            base.ChessBoard = new ChessBoard(base.Game);
            base.AnalysisUc = new AnalysisUc(true, base.Game, this);
            base.AnalysisUc1 = new AnalysisUc(true, base.Game, this);
            base.AnalysisUc2 = new AnalysisUc(false, base.Game, this);
            e2EResultUc1.Game = base.Game;
            #endregion

            #region Register Controls

            base.GameUcList.Add("ClockUc", base.ClockUc);
            base.GameUcList.Add("GameInfoUc", base.GameInfoUc);
            base.GameUcList.Add("NotationUc", base.NotationUc);
            base.GameUcList.Add("ScoringUc", base.ScoringUc);
            base.GameUcList.Add("BookUc", base.BookUc);
            base.GameUcList.Add("CapturePieceUc", base.CapturePieceUc);
            base.GameUcList.Add("ChessBoard", base.ChessBoard);
            base.GameUcList.Add("AnalysisUc", base.AnalysisUc);
            base.GameUcList.Add("AnalysisUc1", base.AnalysisUc1);
            base.GameUcList.Add("AnalysisUc2", base.AnalysisUc2);

            base.GameUcList.Init();

            #endregion

            #endregion

            KibitzerManager = new KibitzerManager(base.Game);

            InitDockingEvents();
            Ap.Init(ApModuleE.Offline);

            EnableBookButtons(!base.Game.Book.IsClosed);

            base.Game.StartAnalysis += new EventHandler(Game_StartAnalysis);
            base.Game.StopAnalysis += new EventHandler(Game_StopAnalysis);
            AnalysisUc.StartAnalysis += new EventHandler(AnalysisUc_StartAnalysis);
            AnalysisUc.StopAnalysis += new EventHandler(AnalysisUc_StopAnalysis);
            NotationUc.OnRefresh += new EventHandler(NotationUc_OnRefresh);
            LoadLastGame();
            tsShowComments.Checked  = Ap.Options.ShowComments;
            tsShowDisconnectionLogs.Checked  = Ap.Options.ShowDisconnectionLog;
        }

         private void LoadLastGame()
        {
            if (!Ap.LoadLastGame(base.Game, NewGameType))
            {
                MessageForm.Error(this, MsgE.ErrorDatabaseLoadLastGameFailed);
            }
        }

        private void MainOffline_FormClosing(object sender, FormClosingEventArgs e)
        {
            RemoveAllKibitzers();
            if (base.Game.GameMode == GameMode.EngineVsEngine)
            {
                if (!base.Game.Flags.IsGameFinished)
                {
                    MessageBox.Show("Engine Match: Stopped.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                e.Cancel = true;
                StopGame();
            }
            else
            {
                if (frmGameResult.AdjudicateGame(base.Game))
                {
                    SaveDocking();
                    dp = null;
                    ApWin.StartupForm.SetVisible();
                }
                else
                {
                    e.Cancel = true;
                }
            }

            if (!e.Cancel)
            {
                base.GameUcList.UnInit();
                base.GameUcList.Clear();
                UnInitDockingEvents();

                this.AnalysisUc.StartAnalysis -= new EventHandler(AnalysisUc_StartAnalysis);
                this.AnalysisUc.StopAnalysis -= new EventHandler(AnalysisUc_StopAnalysis);

                base.Game.CloseEngines();
                Ap.FinishGame();
                Ap.UnInit(ApModuleE.Offline);
            }

            if (this.DatabaseForm != null)
            {
                this.DatabaseForm.Close();
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
            //this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        #endregion

        #region OfflineClient Code

        private void ToggleMenuShortcuts(ToolStripMenuItem oItem, bool enable)
        {
            for (int i = 0; i < oItem.DropDownItems.Count; i++)
            {
                try
                {
                    //recursive call of this method to find all menuitems
                    if (DisabledDefaultMenus(oItem.DropDownItems[i].Name))
                        this.ToggleMenuShortcuts((ToolStripMenuItem)oItem.DropDownItems[i], enable);
                }
                catch (Exception ex)
                {
                    TestDebugger.Instance.WriteError(ex);
                }

            }
            //Remove Shortcut and disable menuitem
            oItem.Enabled = enable;
        }

        private bool DisabledDefaultMenus(string menuName)
        {
            switch (menuName)
            {
                case "ratedToolStripMenuItem":
                    return false;
                case "friendToolStripMenuItem":
                    return false;
                case "twoComputerMatchToolStripMenuItem":
                    return false;
                case "dataBaseToolStripMenuItem":
                    return false;
                case "loadNextGamToolStripMenuItem":
                    return false;
                case "loadPreviousGamToolStripMenuItem":
                    return false;
                case "pastGameToolStripMenuItem":
                    return false;
                case "findPositionToolStripMenuItem":
                    return false;
                case "friendModeToolStripMenuItem":
                    return false;
                case "databaseToolStripMenuItem1":
                    return false;
                default:
                    return true;
            }
        }

        private void OpenOpeningBook()
        {
            ofdImportGame.Filter = "InfinityChess Opening Book icb(*" + Files.OpeningBookExtension + ")|*" + Files.OpeningBookExtension;
            ofdImportGame.FileName = "*" + Files.OpeningBookExtension;
            ofdImportGame.InitialDirectory = Ap.FolderBooks;

            if (ofdImportGame.ShowDialog() == DialogResult.OK)
            {
                Options.Instance.CurrentBookFilePath = ofdImportGame.FileName;
                LoadBook();
            }
        }

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
                        GameSelectedMode();

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
                    GameSelectedMode();

                    if (this.DatabaseForm != null)
                    {
                        this.DatabaseForm.FocusOpenedDatabaseForm();
                    }
                }
            }
        }
        #endregion

        #region Save Game In The Current Game Database Or In New Database
        public void SaveGameInCurrentGameDatabase()
        {
            SaveFileDialog sfdSaveGame = new SaveFileDialog();
            sfdSaveGame.Filter = "Databases icd(*" + Files.DatabaseExtension + ")|*" + Files.DatabaseExtension;
            sfdSaveGame.FileName = "*" + Files.DatabaseExtension;
            sfdSaveGame.InitialDirectory = Ap.FolderDatabase;
            if (string.IsNullOrEmpty(Ap.Options.CurrentGameGuid))
            {
                if (sfdSaveGame.ShowDialog() == DialogResult.OK)
                {
                    InfinityChess.GameData.frmGameData frmGameData = new InfinityChess.GameData.frmGameData(this);
                    frmGameData.Game = base.Game;
                    frmGameData.ShowDialog(this);
                    string fileName = sfdSaveGame.FileName;
                    if (!fileName.EndsWith(Files.DatabaseExtension))
                    {
                        fileName = fileName + Files.DatabaseExtension;
                    }
                    base.Game.GameData.Guid = string.Empty;
                    base.Game.SaveGame(fileName);
                    Ap.Databases.Add(fileName);
                    Ap.Options.CurrentGameDatabaseFilePath = fileName;
                    Ap.Options.Save();
                    this.databaseForm.Show();
                    this.databaseForm.FocusOpenedDatabaseForm();
                }
            }
            else
            {
                InfinityChess.GameData.frmGameData frmGameData = new InfinityChess.GameData.frmGameData(this);
                frmGameData.Game = base.Game;
                if (frmGameData.ShowDialog(this) == DialogResult.OK)
                {
                    string fileName = Ap.Options.CurrentGameDatabaseFilePath;
                    base.Game.GameData.Guid = string.Empty;
                    base.Game.SaveGame(fileName);
                    this.databaseForm.Show();
                    this.databaseForm.FocusOpenedDatabaseForm();
                }
            }
        }
        #endregion

        private void UpdateCurrentGame()
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
                Ap.LoadDatabase(Ap.Options.CurrentGameDatabaseFilePath);
                GameItem gameItem = Ap.Database.GameItems.GetGameByGuid(Ap.Options.CurrentGameGuid);
                int currentGameIndex = Ap.Database.GameItems.GetCurrentGameIndex();
                base.Game.GameData.Guid = Ap.Options.CurrentGameGuid;
                string updatedGameXml = base.Game.GetGameXml();
                Ap.Database.UpdateGame(updatedGameXml, currentGameIndex);
                Ap.Database.Save();
                this.databaseForm.Show();
                this.databaseForm.FocusOpenedDatabaseForm();
            }
        }

        private void SavePosition()
        {
            sfdSaveGame.Filter = "Jpeg (*.jpg)|*.jpg";
            sfdSaveGame.FileName = "Position.jpg";
            sfdSaveGame.InitialDirectory = Ap.DesktopData;
            if (sfdSaveGame.ShowDialog() == DialogResult.OK)
            {
                SaveAsBitmap(sfdSaveGame.FileName);
            }
        }

        public void NewGameMode()
        {
            toolStrip1.Items["tsbLoadNextGameDatabase"].Enabled = false;
            toolStrip1.Items["tsbLoadPreviousGameDatabase"].Enabled = false;
            toolStrip1.Items["tsbReplaceCurrentVersionGameDatabase"].Enabled = false;
            ToolStripMenuItem LoadNextGame = ((ToolStripMenuItem)((ToolStripMenuItem)menuStrip1.Items["fileToolStripMenuItem"]).DropDownItems["openToolStripMenuItem"]).DropDownItems["loadNextGamToolStripMenuItem"] as ToolStripMenuItem;
            LoadNextGame.Enabled = false;
            ToolStripMenuItem LoadPreviousGame = ((ToolStripMenuItem)((ToolStripMenuItem)menuStrip1.Items["fileToolStripMenuItem"]).DropDownItems["openToolStripMenuItem"]).DropDownItems["loadPreviousGamToolStripMenuItem"] as ToolStripMenuItem;
            LoadPreviousGame.Enabled = false;
            base.Game.Flags.IsNewGame = true;
        }

        public void ImportGameForOpeningBook(string fileName)
        {
            App.Win.ImportGameEditor frmImportGameEditor = new App.Win.ImportGameEditor(fileName, base.Game);
            if (frmImportGameEditor.ShowDialog(this) == DialogResult.OK)
            {
                ProgressForm frm = ProgressForm.Show(this, "Importing game(s)...");
                base.Game.Book.ImportGameFromDatabase(frmImportGameEditor.Database, frmImportGameEditor.FromGameNo, frmImportGameEditor.ToGameNo, frmImportGameEditor.IncludeVariations);
                frm.Close();
                MessageForm.Show(this, MsgE.InfoNewPosition, base.Game.Book.NewPositionsImported);
            }
        }

        private void OfferDraw()
        {
            if (base.Game.GameMode == GameMode.HumanVsHuman)
            {
                base.Game.Draw();
            }
            else
            {
                MessageForm.Show(this, MsgE.InfoPlay);
            }
        }

        private void ResignIfAllowed()
        {
            if (base.Game.Flags.IsResignAllowed)
            {
                EnableDrawResignButtons(false);

                base.Game.Resign(GameResultE.InProgress);

                base.Game.Clock.Stop();
            }
        }

        private void FullScreen()
        {
            if (fullScreen == null)
            {
                fullScreen = new FullScreen(this);
            }
            if (fullScreenToolStripMenuItem.Checked == false)
            {
                // show FullScreen
                DialogResult dr = MessageBox.Show("To store normal view, press Ctrl + Alt + F", "Confirm", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    fullScreen.ShowFullScreen();
                    tableLayoutPanel1.Visible = false;
                    menuStrip1.Visible = false;
                    toolStrip1.Visible = false;
                    statusStrip1.Visible = false;
                    fullScreenToolStripMenuItem.Checked = true;
                }
            }
            else
            {
                // Hide FullScreen
                fullScreen.ShowFullScreen();
                tableLayoutPanel1.Visible = true;
                menuStrip1.Visible = true;
                toolStrip1.Visible = true;
                statusStrip1.Visible = true;
                fullScreenToolStripMenuItem.Checked = false;
            }

        }

        private void SetStatusbarMessage(string message)
        {
            tsStatusMessage.Text = message;
        }

        public void NewBlitzGame()
        {
            BlitzClockForm frm = new BlitzClockForm(base.Game);            
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                base.Game.NewGame(GameMode.HumanVsEngine, GameType.Blitz);
            }
        }

        public void NewLongGame()
        {
            LongClockForm frm = new LongClockForm(base.Game);            
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                base.Game.NewGame(GameMode.HumanVsEngine, GameType.Long);
            }
        }

        public override void EnableDrawResignButtons(bool enabled)
        {
            offDrawToolStripMenuItem.Enabled = enabled;
            resignToolStripMenuItem.Enabled = enabled;
            tsbResignThisGame.Enabled = enabled;
            tsbOfferDrawToPlay.Enabled = enabled;
        }

        public override void SetClockMenuItem(bool doClockContinue)
        {
            if (doClockContinue)
            {
                continueClockToolStripMenuItem.Text = "Pause Clock";
                continueClockToolStripMenuItem.Checked = false;
            }
            else
            {
                continueClockToolStripMenuItem.Text = "Continue Clock";
                continueClockToolStripMenuItem.Checked = true;
            }
        }

        private void StartE2EGame()
        {
            EngineVsEngine frm = new EngineVsEngine(base.Game);            
            if (frm.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < menuStrip1.Items.Count; i++)
                {
                    this.ToggleMenuShortcuts((ToolStripMenuItem)menuStrip1.Items[i], false);
                }

                tableLayoutPanel1.Visible = false;
                menuStrip1.Visible = false;
                toolStrip1.Visible = false;
                toolStrip2.Visible = true;

                base.Game.Player1EngineFileName = EngineVsEngine.UCIEngineWhite.EngineFile;
                base.Game.Player2EngineFileName = EngineVsEngine.UCIEngineBlack.EngineFile;

                base.Game.Player1EngineHashTableSize = EngineVsEngine.UCIEngineWhite.HashTableSize;
                base.Game.Player2EngineHashTableSize = EngineVsEngine.UCIEngineBlack.HashTableSize;

                base.Game.Player1.Book = EngineVsEngine.BookWhite;
                base.Game.Player2.Book = EngineVsEngine.BookBlack;

                base.Game.E2EGamesCount = 0;
                base.Game.E2EMatchesStopped = false;
                base.Game.IsFlipped = true;
                base.Game.NewGame(GameMode.EngineVsEngine, Ap.Options.GameType);
            }
        }

        private void EnableNevigateButtons(bool b)
        {
            PrevMove.Enabled = b;
            tsbRetractLastMoveOverwrite.Enabled = b;
            NextMove.Enabled = b;
            MoveToLast.Enabled = b;
            MoveToFirst.Enabled = b;
        }

        #endregion

        #region Menu Events

        #region File > New  Events // *****************************************

        private void blitzGameToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            NewBlitzGame();
        }

        private void longGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewLongGame();
        }

        private void ratedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Marked_Game frm = new Marked_Game();
            //frm.ShowDialog();
        }

        private void friendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //BuddyMode frm = new BuddyMode();
            //frm.ShowDialog();
        }

        private void openingBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewOpeningBook();
        }

        private void tournamentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "InfinityChess Tournaments (*.ictourn)| *.ictourn";
            dlg.ShowDialog(this);

            if (dlg.FileName != "")
            {
                Tournament frm = new Tournament(base.Game);

                frm.TournamentInfo.FilePath = dlg.FileName;

                if (frm.ShowDialog(this) == DialogResult.OK)
                {

                }
            }
        }

        private void engineMatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartE2EGame();
        }

        private void manualGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.Game.NewGame(GameMode.HumanVsHuman, GameType.NoClock);
        }

        #endregion

        #region File > Open Events *******************************************
        private void openingBookToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenOpeningBook();
        }

        private void dataBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatabaseForm.OpenDatabaseForm(this, base.Game);
        }

        private void tournamentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "InfinityChess Tournaments (*.ictourn)| *.ictourn";
            dlg.ShowDialog();

            if (dlg.FileName != "")
            {
                Tournament frm = new Tournament(base.Game);
                frm.TournamentInfo.FilePath = dlg.FileName;
                frm.Show();
            }
        }

        private void formPGNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofdPGNGame.ShowDialog() == DialogResult.OK)
            {
                PGNManager.PGNReader reader = new InfinityChess.PGNManager.PGNReader(base.Game);
                string fileName = ofdPGNGame.FileName;
                reader.LoadGames(fileName);
                // LoadPGNGames frm = new LoadPGNGames(reader.Games);
                //frm.Show();
            }
        }

        #endregion

        #region File Save and Exit Events************************************

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.SaveGame(false);
        }

        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SaveGame(true);
        }


        private void savePositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavePosition();
        }

        // Exit Code*****************************************

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApWin.StartupForm.Show();
            this.Close();
        }

        #endregion

        #region File > // Print Events  *************************************

        private void printGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintGame();
        }

        private void PrintGame()
        {
            GameReport frm = new GameReport(false, base.Game, this);            
            this.Visible = false;
            frm.Show();
        }

        private void printScoreSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void printDiagramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsBitmap(Ap.FilePrintDiagram);

            GameReport frm = new GameReport(true, base.Game, this);            
            this.Visible = false;
            frm.Show();
        }

        private void evaluationProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void printSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void publishGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void publishGameToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Edit > Copy and Past Events// **********************************

        private void copyGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.Game.Clipboard.CopyGame();
        }

        private void copyPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fen = base.ChessBoardUc.GetFen();
            App.Win.Clipboard.CopyPosition(fen);

            //tempDataTable = base.Game.Moves.DataTable;
        }

        private void pastGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.Game.Clipboard.PasteGame();
        }

        private void pastPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.Win.Clipboard.PastePosition(base.Game);

            if (this.AnalysisUc != null)
            {
                this.AnalysisUc.ClearAnalysisItems();
            }

            SetCapturedPiecesParameters();
        }

        private void findPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatabaseForm.OpenDatabaseForm(this, base.Game);
            if (Ap.Database != null)
            {
                string fenNotation = ChessLibrary.FenParser.GetOnlyFen(ChessBoardUc.GetFen());
                App.Model.GameSearch gameSearchData = new App.Model.GameSearch();
                gameSearchData.BoardFen = fenNotation;
                gameSearchData.IsPositonIncluded = true;
                gameSearchData.IsGameDataIncluded = false;
                DatabaseForm.SearchGames(gameSearchData);
            }
        }

        private void SetCapturedPiecesParameters()
        {
            if (tempDataTable == null)
                return;

            DataRow dr = GetLastRowTempDataTable(tempDataTable);
            if (dr != null)
            {
                //base.Game.CapturedPieces.IsWhiteMove = dr[Moves.White].ToString() == "1";
                //base.Game.CapturedPieces.MoveNo = Convert.ToInt32(dr[Moves.No]);
                ////base.Game.CapturedPieces.SelectedRowIndex = Convert.ToInt32(dr[Moves.R]);
                ////base.Game.CapturedPieces.SelectedColumnIndex = Convert.ToInt32(dr[Moves.C]);
                //base.Game.CapturedPieces.NotationsDataTable = tempDataTable.Copy();
            }
        }
        private DataRow GetLastRowTempDataTable(DataTable dt)
        {
            DataRow dr = null;
            int index = tempDataTable.Rows.Count - 1;
            if (index >= 0)
            {
                dr = tempDataTable.Rows[index];
            }
            return dr;
        }
        #endregion

        #region Edit > Edit Game and Import Export / ********************************************

        private void editGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfinityChess.GameData.frmGameData frm = new InfinityChess.GameData.frmGameData(this);
            frm.Game = base.Game;
            frm.ShowDialog();
        }
       
        private void importGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportGame();
        }

        private void importPgnGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportPgnGame();
        }

        private void bookOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookOptionsPopup frm = new BookOptionsPopup(base.Game);
            frm.ShowDialog();
        }

        public void EnableBookButtons(bool enable)
        {
            importGameToolStripMenuItem.Enabled = enable;
            importPgnGameToolStripMenuItem.Enabled = enable;
            bookOptionsToolStripMenuItem.Enabled = enable;
        }

        #endregion

        #region View Menu ***********************************************

        private void flipBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlipBoard();
        }

        public override void FlipBoard()
        {
            base.FlipBoard();
        }

        private void board2DToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolbarToolStripMenuItem.Checked)
            {
                toolStrip1.Visible = false;
                toolbarToolStripMenuItem.Checked = false;
            }
            else
            {
                toolStrip1.Visible = true;
                toolbarToolStripMenuItem.Checked = true;
            }
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statusBarToolStripMenuItem.Checked)
            {
                statusStrip1.Visible = false;
                statusBarToolStripMenuItem.Checked = false;
            }
            else
            {
                statusStrip1.Visible = true;
                statusBarToolStripMenuItem.Checked = true;
            }
        }

        Point menuStripOriginalLocation;
        Point toolStripOriginalLocation;
        private void menubarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menubarToolStripMenuItem.Checked)
            {
                DialogResult result = MessageBox.Show("Press Ctrl + Alt + M to access menubar", "", MessageBoxButtons.OKCancel);
                if (result.ToString() == "OK")
                {
                    menuStrip1.Visible = false;
                    menubarToolStripMenuItem.Checked = false;

                    //// set toolstrip location to menustrip location.
                    menuStripOriginalLocation = new Point(menuStrip1.Location.X, menuStrip1.Location.Y);
                    toolStripOriginalLocation = new Point(toolStrip1.Location.X, toolStrip1.Location.Y);
                    toolStrip1.Location = new Point(menuStripOriginalLocation.X, menuStripOriginalLocation.Y);

                    if (toolStrip1.Visible)
                    {
                        tableLayoutPanel1.ColumnStyles[0].Width = 0;
                    }
                    else
                    {
                        tableLayoutPanel1.ColumnStyles[0].Width = 0;
                        tableLayoutPanel1.Visible = false;
                    }
                }
            }
            else
            {
                menuStrip1.Visible = true;
                menubarToolStripMenuItem.Checked = true;

                //// set toolstrip location to menustrip location.                                
                toolStrip1.Location = new Point(toolStripOriginalLocation.X, toolStripOriginalLocation.Y);

                tableLayoutPanel1.ColumnStyles[0].Width = 100;
                tableLayoutPanel1.Visible = true;
            }
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FullScreen();
        }

        private void shortCutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShortCutForm frm = new ShortCutForm();
            frm.Show();
        }

        #endregion

        #region Game Menu ***************************************

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.Game.NewGame(GameMode.HumanVsEngine, NewGameType);
            Ap.Options.CurrentGameDatabaseFilePath = string.Empty;
            Ap.Options.Save();
            NewGameMode();
            if (this.DatabaseForm != null)
            {
                this.DatabaseForm.CurrentGameHighlighted();
            }
        }

        private void tsMoveNow_Click(object sender, EventArgs e)
        {
            base.ForceEngineToPlay();
        }

        private void infinityAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleInfiniteAnalysis(infiniteAnalysisToolStripMenuItem.Text.Contains("Infinite Analysis:"));
        }

        //Levels **************************
        private void blitzGameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BlitzClockForm frm = new BlitzClockForm(base.Game);            
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                base.Game.NewGame(GameMode.HumanVsEngine, GameType.Blitz);
            }

        }

        private void longGameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LongClockForm frm = new LongClockForm(base.Game);            

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                base.Game.NewGame(GameMode.HumanVsEngine, GameType.Long);
            }
        }

        private void friendModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //BuddyMode frm = new BuddyMode();
            //frm.ShowDialog();

        }
        // end levels ****************
        private void continueClockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (continueClockToolStripMenuItem.Checked)
            {
                base.Game.Clock.Start();
                SetClockMenuItem(true);
            }
            else
            {
                base.Game.Clock.Stop();
                SetClockMenuItem(false);
            }
        }


        private void offDraawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OfferDraw();
        }

        private void resignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResignIfAllowed();
        }

        #endregion

        #region Engine Menu ***************************************
        private void changToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadEngine frm = new LoadEngine(base.Game, this);            
            frm.IsAddKibitzer = false;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                base.ChangeMainEngine(frm.SelectedEngine);

                if (base.Game.Flags.IsInfiniteAnalysisOn)
                {
                    infiniteAnalysisToolStripMenuItem.Text = "Stop: " + InfinitySettings.Settings.DefaultEngineXml.EngineTitle;
                    StartInfiniteAnalysis();
                }
                else
                {
                    infiniteAnalysisToolStripMenuItem.Text = "Infinite Analysis: " + InfinitySettings.Settings.DefaultEngineXml.EngineTitle;
                }
            }
        }

        private void switchOffEngineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (switchOffEngineToolStripMenuItem.Checked)
            {
                switchOffEngineToolStripMenuItem.Checked = false;
                switchOffEngineToolStripMenuItem.Text = "Switch off engine";
                ToggleInfiniteAnalysis(false);
            }
            else
            {
                switchOffEngineToolStripMenuItem.Checked = true;
                switchOffEngineToolStripMenuItem.Text = "Switch on engine";
                ToggleInfiniteAnalysis(true);
            }
        }

        private void StopEngine()
        {
            base.AnalysisUc.SwitchOffEngine();
            switchOffEngineToolStripMenuItem.Text = "Switch On Engine";
            switchOffEngineToolStripMenuItem.Checked = true;
            base.Game.Flags.IsEngineOn = false;
        }

        private void StartEngine()
        {
            base.AnalysisUc.SwitchOnEngine();
            switchOffEngineToolStripMenuItem.Text = "Switch Off Engine";
            switchOffEngineToolStripMenuItem.Checked = false;
            base.Game.Flags.IsEngineOn = true;
        }

        void AnalysisUc_StopAnalysis(object sender, EventArgs args)
        {
            base.Game.DefaultEngine.SendStop();
        }

        void AnalysisUc_StartAnalysis(object sender, EventArgs args)
        {
            base.Game.DefaultEngine.SendPositionGoInfinite(string.Empty, base.Game.Moves.GetParentsStr(base.Game.CurrentMove));
        }

        void Game_StartAnalysis(object sender, EventArgs e)
        { }

        void Game_StopAnalysis(object sender, EventArgs e)
        { }

        private void infiniteAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!base.Game.Flags.IsAnalysisAllowed)
            {
                return;
            }

            if (infiniteAnalysisToolStripMenuItem.Text.Contains("Infinite Analysis:"))
            {
                ToggleInfiniteAnalysis(true);
            }
            else
            {
                ToggleInfiniteAnalysis(false);
                switchOffEngineToolStripMenuItem.Checked = false;
                switchOffEngineToolStripMenuItem.Text = "Switch off engine";
            }
        }

        public void ToggleInfiniteAnalysis(bool doStartAnalysis)
        {
            if (base.Game.DefaultEngine == null)
            {
                return;
            }

            if (doStartAnalysis)
            {
                base.Game.Flags.IsInfiniteAnalysisStarted = true;
                base.Game.Flags.IsInfiniteAnalysisGoButtonPressed = true;
                base.Game.DefaultEngine.SendStop();
                StartInfiniteAnalysis();
                base.Game.StartInfiniteAnalysis();

                if (this.Game.Flags.IsBoardSetByFen)
                {
                    base.Game.DefaultEngine.SendPositionGoInfinite(base.Game.InitialBoardFen, base.Game.Moves.GetParentsStr(base.Game.CurrentMove));
                }
                else
                {
                    base.Game.DefaultEngine.SendPositionGoInfinite(string.Empty, base.Game.Moves.GetParentsStr(base.Game.CurrentMove));                    
                }                
            }
            else
            {
                base.Game.Flags.IsInfiniteAnalysisStopped = true;
                StopInfiniteAnalysis();
                base.Game.StopInfiniteAnalysis();
                AnalysisUc.ClearAnalysisItems();
                if (Game.Flags.IsInfiniteAnalysisGoButtonPressed)
                {
                    base.Game.DefaultEngine.SendStop();
                }
            }
        }

        private void StartInfiniteAnalysis()
        {
            infiniteAnalysisToolStripMenuItem.Text = "Stop: " + InfinitySettings.Settings.DefaultEngineXml.EngineTitle;
        }

        private void StopInfiniteAnalysis()
        {
            infiniteAnalysisToolStripMenuItem.Text = "Infinite Analysis: " + InfinitySettings.Settings.DefaultEngineXml.EngineTitle;
            base.Game.SwapPlayersIfNeeded();
        }

        private void addKibitzerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadEngine objloadengine = new LoadEngine(base.Game, this);            
            objloadengine.IsAddKibitzer = true;
            objloadengine.ShowDialog();
        }

        private void removeKibitzerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KibitzerManager.KibitzersList.Count > 0)
            {
                RemoveKibitzer();
            }
        }

        private void removeKibitzerAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<AnalysisUc> tempKibitzer = new List<AnalysisUc>();
            foreach (var item in KibitzerManager.KibitzersList)
            {
                tempKibitzer.Add(item);
            }
            foreach (var item in tempKibitzer)
            {
                RemoveKibitzer();
            }
        }

        private void engineManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EngineManagement objEnginemanagement = new EngineManagement(base.Game);            
            objEnginemanagement.ShowDialog(this);
        }

        private void engineUCIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetupUCIEngine objuciengine = new SetupUCIEngine(base.Game);            
            objuciengine.ShowDialog(this);
        }

        private void chessBenchmarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Benchmark objbenchmark = new Benchmark();
            //objbenchmark.Show();
        }
        #endregion

        #region Tools Menu ****************************************************

        #region Tools > Analysis Events ***************************************
        private void fullAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }


        private void blunderCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }


        private void deepPositionAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }

        private void shootoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }

        private void compareAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }

        private void processTestSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }


        private void mateSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }

        private void classifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }


        #endregion


        #region Tools > Traning Events ***************************************
        private void themeBlitzToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void openingTranningToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void endGameTToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void attackTranningToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void checkTranningToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void defenceTrainningToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        #endregion

        private void dGTBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }

        private void connectHardwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }

        private void bookOptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookOptionsPopup frm = new BookOptionsPopup(base.Game);
            frm.ShowDialog(this);
        }

        private void userInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserInfo frm = new UserInfo();
            frm.ShowDialog(this);
        }

        private void factorySettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageForm.Confirm(this, MsgE.ConfirmResetSetting);
            if (dialogResult == DialogResult.Yes)
            {
                ApWin.ShowUserProfile = true;
                Ap.ResetFactorySettings();
                LoadDefaultPanels();
                this.Close();
            }
        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsPopup frm = new OptionsPopup(base.Game, this);
            frm.ShowDialog(this);
        }

        private void importPgnToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ConvertFilesPopup frm = new ConvertFilesPopup(base.Game);
            frm.Show();
        }

        #endregion

        #region Windows Menu ****************************************************

        #region Windows > Panes ****************************************************

        private void clockWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TogglePanel(ClockUc, clockWindowToolStripMenuItem.Checked);
        }

        private void gameInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotationUc.GameInfoUc.Visible = gameInfoToolStripMenuItem.Checked;
        }

        private void notationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TogglePanel(NotationUc, notationToolStripMenuItem.Checked);
        }

        private void scoringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TogglePanel(ScoringUc, scoringToolStripMenuItem.Checked);
        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TogglePanel(BookUc, bookToolStripMenuItem.Checked);
        }

        private void analysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (base.Game.GameMode)
            {
                case GameMode.None:
                    break;
                case GameMode.HumanVsHuman:
                case GameMode.HumanVsEngine:
                    TogglePanel(AnalysisUc, analysisToolStripMenuItem.Checked);
                    break;
                case GameMode.EngineVsEngine:
                    TogglePanel(AnalysisUc1, analysisToolStripMenuItem.Checked);
                    TogglePanel(AnalysisUc2, analysisToolStripMenuItem.Checked);
                    break;
                case GameMode.OnlineHumanVsHuman:
                    break;
                case GameMode.OnlineEngineVsEngine:
                    break;
                default:
                    break;
            }
        }

        private void capturePieceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotationUc.CapturePieceUc.Visible = capturePieceToolStripMenuItem.Checked;
        }

        private void evaluationProfileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //empty
        }

        private void extraBookWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }

        private void analysisBoarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }

        private void control2dBoarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }

        private void chatterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }

        private void engineOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }

        private void explanAllMovesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }

        private void chessMediaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }

        private void loadDefaultPanesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageForm.Confirm(this, MsgE.ConfirmLoadDefaultPanes) == DialogResult.Yes)
            {
                LoadDefaultPanels();
            }
        }


        #endregion

        #region Windows > Standard Layouts ****************************************************
        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }
        private void bigBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }

        private void bigNotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }
        private void bigEngineToolStripMenuItem_Click(object sender, EventArgs e)
        {//empty

        }

        private void bigProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }

        private void boardOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }



        private void boardAndClockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }

        private void browseBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }
        private void allWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }

        private void miniWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }


        #endregion

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }

        #region Windows > Arrange ****************************************************
        private void tToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }
        private void top2HorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }
        private void top2DiagonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }
        private void maximizeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //empty
        }

        #endregion

        #endregion

        #region Help Menu ****************************************************


        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InfinityChesshelp.InfinityChessHelp.OpenHelpFile();
        }

        private void toInfinityChesscomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ap.OpenHomeUrl();
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ap.OpenRegistrationUrl();
        }
        private void aboutInfinityChessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutInfinityChess frm = new AboutInfinityChess();
            frm.ShowDialog();
        }

        #endregion

        #region Insert Menu
        private void enterTextBeforeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnterMoveText.Open(true, base.Game);
        }

        private void textAfterMoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnterMoveText.Open(false, base.Game);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, "delete", "all commentary") == DialogResult.Yes)
            {
                base.Game.DeleteAllComentary();
            }
        }

        private void deleteSelectedMoveCommentaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, "delete", "all commentary") == DialogResult.Yes)
            {
                base.Game.DeleteCurrentMoveComentary();
            }
        }

        void NotationUc_OnRefresh(object sender, EventArgs e)
        {
            tsShowComments.Checked = Ap.Options.ShowComments;
            tsShowDisconnectionLogs.Checked = Ap.Options.ShowDisconnectionLog;
       
        }
        
        #endregion

        #endregion

        #region Overrides

        protected override void BookBookLoaded()
        {
            EnableBookButtons(true);
            GameInfoUc.RefreshGameInfo();
        }

        protected override void BookBookClosed()
        {
            EnableBookButtons(false);
            GameInfoUc.RefreshGameInfo();
        }

        protected override void GameBeforeFinish()
        {

        }

        protected override void GameAfterFinish()
        {
            if (base.Game.GameMode == GameMode.EngineVsEngine)
            {
                base.Game.UpdateE2eResult();
            }

            if (base.Game.GameMode != GameMode.HumanVsEngine)
            {
                base.Game.CloseEngines();
            }
            base.Game.Clock.Stop();

            EnableDrawResignButtons(false);

            string msg = base.Game.ResultMessage;

            if (base.Game.Flags.IsResultPopupAllowed)
            {
                MessageForm.Show(this, msg, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            SetStatusbarMessage(msg);

            if (base.Game.GameMode == GameMode.EngineVsEngine)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);

                base.Game.E2EGamesCount++;

                if (base.Game.Flags.NewEngineMatchRequired)
                {
                    base.Game.NewGameE2E();
                }
                else
                {
                    if (DatabaseForm == null)
                    {
                        DatabaseForm = new DatabaseForm(this, base.Game);
                        DatabaseForm.Game = base.Game;
                    }
                    DatabaseForm.Show();
                    DatabaseForm.InitDatabaseFilesPathCombo(base.Game.AutoSaveFilePath);
                    DatabaseForm.Activate();
                }
            }
        }

        protected override void GameAfterSetFen()
        {
            base.GameAfterSetFen();
        }

        protected override void GameAfterMoveAdd()
        {
            base.GameAfterMoveAdd();

            EnableNevigateButtons(true);

            if (base.Game.Flags.IsOffline)
            {
                Application.DoEvents();
            }
        }

        protected override void GameAfterPaste()
        {
            base.GameAfterPaste();

            EnableNevigateButtons(true);
        }

        protected override void GameBeforeNewGame(NewGameEventArgs e)
        {
            #region Game Result
            if (base.Game.Flags.IsAdjudicateRequired)
            {
                frmGameResult frmGameResult = new frmGameResult(base.Game);

                if (frmGameResult.ShowDialog() == DialogResult.OK)
                {
                    tsbOfferDrawToPlay.Enabled = true;
                    tsbResignThisGame.Enabled = true;
                }
                else
                {
                    e.Cancel = true;
                    return;
                }
            }
            #endregion

            #region Init Ui
            offDrawToolStripMenuItem.Enabled = true;
            resignToolStripMenuItem.Enabled = true;
            tsbResignThisGame.Enabled = true;
            tsbOfferDrawToPlay.Enabled = true;
            infiniteAnalysisToolStripMenuItem.Text = "Infinite Analysis: " + InfinitySettings.Settings.DefaultEngineXml.EngineTitle;
            switchOffEngineToolStripMenuItem.Text = "Switch Off Engine";
            switchOffEngineToolStripMenuItem.Checked = false;
            EnableNevigateButtons(false);
            #endregion

            switch (base.Game.GameMode)
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
                case GameMode.OnlineHumanVsEngine:
                    break;
                case GameMode.OnlineEngineVsEngine:
                    break;
                case GameMode.Kibitzer:
                    break;
                default:
                    break;
            }
        }

        protected override void GameAfterNewGame()
        {
            switch (base.Game.GameMode)
            {
                case GameMode.None:
                    break;
                case GameMode.HumanVsHuman:
                    break;
                case GameMode.HumanVsEngine:
                    InitSpaceBarTimer();
                    break;
                case GameMode.EngineVsEngine:
                    break;
                case GameMode.OnlineHumanVsHuman:
                    break;
                case GameMode.OnlineHumanVsEngine:
                    break;
                case GameMode.OnlineEngineVsEngine:
                    break;
                case GameMode.Kibitzer:
                    break;
                default:
                    break;
            }

            if (ChessBoardUc.Flipped)
            {
                FlipBoard();
            }

            if (base.Game.Flags.IsFlipBoardRequried)
            {
                System.Threading.Thread.Sleep(1000);
                ChessBoardUc.Flipped = true;
            }

            this.RefreshGameInfo();
            base.RefreshTitle();

            SetStatusbarMessage("Ready - New Game");
            EnableDrawResignButtons(false);
            SetEngineMenuItems();
        }
        
        public override void ImportGame()
        {
            try
            {
                ofdImportGame.Filter = "Databases icd(*" + Files.DatabaseExtension + ")|*" + Files.DatabaseExtension;
                ofdImportGame.FileName = "*" + Files.DatabaseExtension;
                ofdImportGame.InitialDirectory = Ap.FolderDatabase;

                if (ofdImportGame.ShowDialog() == DialogResult.OK)
                {
                    string fileName = ofdImportGame.FileName;
                    Icd = new IcdManager(base.Game);
                    Icd.OnProgressBarInitialized += new IcdManager.ProgressBarInitHandler(Icd_OnProgressBarInitialized);
                    Icd.OnProgressChanged += new IcdManager.ProgressChangedEventHandler(Icd_OnProgressChanged);
                    Icd.OnProgressWorkCompleted += new IcdManager.ProgressWorkCompletedHandler(Icd_OnProgressWorkCompleted);
                    Icd.isImportInCurrentGameBook = true;
                    Icd.ConvertIcdToPgn(fileName);
                }
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }

        public override void ImportPgnGame()
        {
            try
            {
                ofdImportGame.Filter = "Databases pgn(*" + Files.PortableGameNotationExtension + ")|*" + Files.PortableGameNotationExtension;
                ofdImportGame.FileName = "*" + Files.PortableGameNotationExtension;
                ofdImportGame.InitialDirectory = Ap.FolderDatabase;

                if (ofdImportGame.ShowDialog() == DialogResult.OK)
                {
                    string fileName = ofdImportGame.FileName;
                    pgn = new PgnManager(base.Game);
                    pgn.OnProgressBarInitialized += new PgnManager.ProgressBarInitHandler(pgn_OnProgressBarInitialized);
                    pgn.OnProgressChanged += new PgnManager.ProgressChangedEventHandler(pgn_OnProgressChanged);
                    pgn.OnProgressWorkCompleted += new PgnManager.ProgressWorkCompletedHandler(pgn_OnProgressWorkCompleted);
                    pgn.isImportInCurrentGameBook = true;
                    pgn.isPgnToIcbConversion = true;
                    BookUc.DeAttachBook();
                    tmrSpaceBar.Stop();
                    pgn.ConvertPgnToIcd(fileName);
                }
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }

        public override void NewOpeningBook()
        {
            sfdOpeningBook.Filter = "InfinityChess Opening Book icb(*" + Files.OpeningBookExtension + ")|*" + Files.OpeningBookExtension;
            sfdOpeningBook.FileName = "*" + Files.OpeningBookExtension;
            sfdOpeningBook.InitialDirectory = Ap.FolderBooks;

            if (sfdOpeningBook.ShowDialog() == DialogResult.OK)
            {
                string fileName = sfdOpeningBook.FileName;
                if (!fileName.EndsWith(Files.OpeningBookExtension))
                {
                    fileName = fileName + Files.OpeningBookExtension;
                }
                Options.Instance.CurrentBookFilePath = fileName;

                LoadBook();

                base.Game.Book.Save();
                BookUc.LoadBookGridHeaders();
                if (base.Game.Book != null && !base.Game.Book.IsClosed)
                {
                    EnableBookButtons(true);
                }
            }
        }

        public override void GameSelectedMode()
        {
            toolStrip1.Items["tsbLoadNextGameDatabase"].Enabled = true;
            toolStrip1.Items["tsbLoadPreviousGameDatabase"].Enabled = true;
            toolStrip1.Items["tsbReplaceCurrentVersionGameDatabase"].Enabled = true;
            ToolStripMenuItem LoadNextGame = ((ToolStripMenuItem)((ToolStripMenuItem)menuStrip1.Items["fileToolStripMenuItem"]).DropDownItems["openToolStripMenuItem"]).DropDownItems["loadNextGamToolStripMenuItem"] as ToolStripMenuItem;
            LoadNextGame.Enabled = true;
            ToolStripMenuItem LoadPreviousGame = ((ToolStripMenuItem)((ToolStripMenuItem)menuStrip1.Items["fileToolStripMenuItem"]).DropDownItems["openToolStripMenuItem"]).DropDownItems["loadPreviousGamToolStripMenuItem"] as ToolStripMenuItem;
            LoadPreviousGame.Enabled = true;
            base.Game.Flags.IsNewGame = false;
        }

        #endregion

        #region ToolBar Events


        private void tsbNewGame_Click(object sender, EventArgs e)
        {
            base.Game.ResetCurrentGame();
            base.Game.NewGame(GameMode.HumanVsEngine, NewGameType);
            NewGameMode();
        }
        private void tsbFlipBoard_Click(object sender, EventArgs e)
        {
            flipBoardToolStripMenuItem.PerformClick();
        }
        private void tsbForceEngineToMove_Click(object sender, EventArgs e)
        {
            tsMoveNow.PerformClick();
        }
        private void tsbOfferDrawToPlay_Click(object sender, EventArgs e)
        {
            OfferDraw();
        }
        private void tsbResignThisGame_Click(object sender, EventArgs e)
        {
            ResignIfAllowed();
        }
        private void tsbChangeMainPlaying_Click(object sender, EventArgs e)
        {
            changToolStripMenuItem.PerformClick();
        }
        private void tsbChangeBoardDesign_Click(object sender, EventArgs e)
        {
            //BoardDesignPopup frm = new BoardDesignPopup();
            //frm.ShowDialog();
            ChessBoard.ShowBoardDesignPopup(this);
        }
        private void tsbToggleFullScreenMode_Click(object sender, EventArgs e)
        {
            FullScreen();
        }
        private void tsbInputUserNameInfo_Click(object sender, EventArgs e)
        {
            UserInfo frm = new UserInfo();
            frm.ShowDialog(this);
        }

        private void tsbSetMainProgramOption_Click(object sender, EventArgs e)
        {
            OptionsPopup frm = new OptionsPopup(base.Game, this);
            frm.ShowDialog(this);
        }

        private void tsbOpenGameDatabase_Click(object sender, EventArgs e)
        {
            DatabaseForm.OpenDatabaseForm(this, base.Game);
        }

        private void tsbFindCurrentPositionDatabase_Click(object sender, EventArgs e)
        {
            if (base.Game.Notations != null)
            {
                Ap.LoadDatabase(Ap.Options.CurrentDatabaseFilePath);
                int selectedColumnIndex = NotationUc.Grid.SelectedCells[0].ColumnIndex;
                int selectedRowIndex = NotationUc.Grid.SelectedCells[0].RowIndex;
                DatabaseForm.OpenDatabaseForm(this, base.Game);
                this.DatabaseForm.GamesGrid.AutoGenerateColumns = false;
                this.DatabaseForm.GamesGrid.DataSource = Ap.Database.GameItems.GetGamesByNotation(base.Game.Notations, selectedRowIndex, selectedColumnIndex - 1);
            }
        }

        private void tsbSetPlayersNamesTournamentResults_Click(object sender, EventArgs e)
        {
            InfinityChess.GameData.frmGameData frm = new InfinityChess.GameData.frmGameData(this);
            frm.Game = base.Game;
            frm.ShowDialog();
        }
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            this.SaveGame(false);
        }
        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            base.Game.Clipboard.CopyGame();
        }
        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            base.Game.Clipboard.PasteGame();
        }

        void printToolStripButton_Click(object sender, System.EventArgs e)
        {
            PrintGame();
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            InfinityChesshelp.InfinityChessHelp.OpenHelpFile();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            StopGame();
        }

        private void StopGame()
        {
            e2EResultUc1.Visible = false;
            base.Game.E2EMatchesStopped = true;
            base.Game.CapturedPieces.Clear();
            base.Game.Abort(false);
            base.Game.NewGame(GameMode.HumanVsEngine, Ap.Options.GameType);

            for (int i = 0; i < menuStrip1.Items.Count; i++)
            {
                this.ToggleMenuShortcuts((ToolStripMenuItem)menuStrip1.Items[i], true);
            }

            tableLayoutPanel1.Visible = true;
            menuStrip1.Visible = true;
            toolStrip1.Visible = true;
            toolStrip2.Visible = false;
        }
        private void databaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DatabaseForm.OpenDatabaseForm(this, base.Game);
        }

        private void goToChessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ap.OpenHomeUrl();
        }

        private void tsOpenDataFolder_Click(object sender, EventArgs e)
        {
            Ap.OpenFolderData();
        }

        private void tsUndo_Click(object sender, EventArgs e)
        {
            if (MessageForm.Confirm(this, MsgE.ConfirmLoadDefaultPanes) == DialogResult.Yes)
            {
                LoadDefaultPanels();
            }
        }

        private void designToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChessBoard.ShowBoardDesignPopup(this);
        }

        #region Database Related Events Handler
        private void tsbSaveNewVersionGameDatabase_Click(object sender, EventArgs e)
        {
            SaveGameInCurrentGameDatabase();
        }
        private void tsbReplaceCurrentVersionGameDatabase_Click(object sender, EventArgs e)
        {
            UpdateCurrentGame();
        }
        private void tsbLoadNextGameDatabase_Click(object sender, EventArgs e)
        {
            LoadGameFromDatabase(true);
        }

        private void tsbLoadPreviousGameDatabase_Click(object sender, EventArgs e)
        {
            LoadGameFromDatabase(false);
        }

        private void LoadGameFromDatabase(bool next)
        {
            Ap.LoadDatabase(Ap.Options.CurrentDatabaseFilePath);

            if (!string.IsNullOrEmpty(Ap.Options.CurrentGameGuid))
            {
                GameItem gameItem = null;

                if (Ap.Options.CurrentDatabaseFilePath != Ap.Options.CurrentGameDatabaseFilePath)
                {
                    if (next)
                    {
                        gameItem = Ap.Database.GameItems.FirstGame();
                    }
                    else
                    {
                        gameItem = Ap.Database.GameItems.LastGame();
                    }

                    Ap.Options.CurrentGameDatabaseFilePath = Ap.Options.CurrentDatabaseFilePath;
                    Ap.Options.Save();
                }
                else
                {
                    if (next)
                    {
                        gameItem = Ap.Database.GameItems.GetNextGameByGuid(Ap.Options.CurrentGameGuid);
                    }
                    else
                    {
                        gameItem = Ap.Database.GameItems.GetPreviousGameByGuid(Ap.Options.CurrentGameGuid);
                    }
                }

                base.Game.LoadGame(gameItem.GameData.Guid);
                this.Focus();
                this.GameSelectedMode();
            
                if (this.DatabaseForm == null)
                {
                    this.DatabaseForm = new DatabaseForm(this, base.Game);
                    this.DatabaseForm.Game = base.Game;
                    this.DatabaseForm.Show();
                    this.DatabaseForm.UpdateGamesGrid();
                }
                else
                {
                    this.DatabaseForm.UpdateGamesGrid();
                }

                this.DatabaseForm.CurrentGameHighlighted();
            }
        }

        #endregion

        private void statusStrip1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void ArrowInitialBoardPosition_Click(object sender, EventArgs e)
        {

        }

        private void tsbViewResultSummary_Click(object sender, EventArgs e)
        {
            e2EResultUc1.Init();
            if (e2EResultUc1.Visible)
            {
                e2EResultUc1.Visible = false;
                tsbViewResultSummary.Text = "Show Result Summary";
                tsbViewResultSummary.ToolTipText = "Show Result Summary";
            }
            else
            {
                e2EResultUc1.Visible = true;
                tsbViewResultSummary.Text = "Hide Result Summary";
                tsbViewResultSummary.ToolTipText = "Hide Result Summary";
            }
        }

        private void tsbAdjudicateGame_Click(object sender, EventArgs e)
        {
            frmGameResult obj = new frmGameResult(base.Game);
            obj.ShowDialog(this);
        }

        void toolStripButton2_Click(object sender, System.EventArgs e)
        {

        }

        #endregion

        #region Helpers 

        private void SetEngineMenuItems()
        {
            bool visible = base.Game.GameMode != GameMode.HumanVsHuman;

            changToolStripMenuItem.Visible = visible;
            switchOffEngineToolStripMenuItem.Visible = visible;
            toolStripSeparator27.Visible = visible;
            infiniteAnalysisToolStripMenuItem.Visible = visible;
            engineManagementToolStripMenuItem.Visible = visible;
        }

        #endregion

        #region PGNManagerProgressBar
        void pgn_OnProgressWorkCompleted(object sender, ProgressWorkCompletedEventArgs e)
        {

            if (progressForm != null)
            {
                progressForm.Timer.Stop();
                this.Game.Book.IsImportInProgress = true;
                this.Game.Book.Save();
                BookUc.AttachBook();
                if (e.arguments.Cancelled)
                {
                    MessageForm.Show(this, MsgE.ImportCancelled);
                }
                if (!e.arguments.Cancelled)
                {
                    MessageForm.Show(this, MsgE.InfoNewPosition, base.Game.Book.NewPositionsImported);
                    progressForm.OnWorkCancelled -= new GameSearchProgress.WorkCancelledHandler(pgnProgressForm_OnWorkCancelled);
                }
                tmrSpaceBar.Start();
                progressForm.Close();
                progressForm = null;
            }

        }
        void pgn_OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            if (progressForm != null)
            {
                if (!isTotalGameCountSet)
                {
                    progressForm.ProgressBar.Maximum = totalGamesCount;
                    isTotalGameCountSet = true;
                }
                progressForm.ProgressBar.Show();
                progressForm.ProgressBar.Refresh();
                progressForm.ProgressBar.Value = e.ProgressPercentage;
                progressForm.GameNo.Text = "Game " + e.ProgressPercentage.ToString() + " of " + totalGamesCount.ToString();
                string percentage =Math.Round((((double)e.ProgressPercentage / totalGamesCount) * 100)).ToString();
                progressForm.Percentage.Text = percentage + "%";

            }
            else
            {
                progressForm = new GameSearchProgress();
                progressForm.Text = "Import Game";
                progressForm.OnWorkCancelled += new GameSearchProgress.WorkCancelledHandler(pgnProgressForm_OnWorkCancelled);
                progressForm.TimeConsumed.Text = "Estimating Game Count....";
                progressForm.ShowDialog(this);
            }
        }
        void pgn_OnProgressBarInitialized(object sender, ProgressBarEventArgs e)
        {
            totalGamesCount = e.TotalGames;
        }
        void pgnProgressForm_OnWorkCancelled(object sender, EventArgs args)
        {
            if (pgn != null)
            {
                DialogResult dr = MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask,"cancel","import game");
                if (dr == DialogResult.Yes)
                {

                    progressForm.OnWorkCancelled -= new GameSearchProgress.WorkCancelledHandler(pgnProgressForm_OnWorkCancelled);
                    pgn.CancelPgnToIcdConversion();
                }
                else
                {
                    return;
                }
            }
        }
        #endregion

        #region IcdManagerProgressBar
        void Icd_OnProgressBarInitialized(object sender, ProgressBarEventArgs e)
        {
            totalGamesCount = e.TotalGames;
        }
        void Icd_OnProgressWorkCompleted(object sender, ProgressWorkCompletedEventArgs e)
        {
            if (progressForm != null)
            {
                progressForm.Timer.Stop();
                if (e.arguments.Cancelled)
                {
                    MessageForm.Show(this,MsgE.ImportCancelled);
                }
                if (!e.arguments.Cancelled)
                {
                    MessageForm.Show(this, MsgE.InfoNewPosition, base.Game.Book.NewPositionsImported);                 }
                progressForm.OnWorkCancelled -= new GameSearchProgress.WorkCancelledHandler(IcdProgressForm_OnWorkCancelled);
            }
            progressForm.Close();
            progressForm = null;
        }

        void Icd_OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (progressForm != null)
            {
                progressForm.ProgressBar.Show();
                progressForm.ProgressBar.Refresh();
                progressForm.ProgressBar.Value = e.ProgressPercentage;
                progressForm.GameNo.Text = "Game " + e.ProgressPercentage.ToString() + " of " + totalGamesCount.ToString();
                string percentage =Math.Round((((double)e.ProgressPercentage / totalGamesCount) * 100)).ToString();
                progressForm.Percentage.Text = percentage + "%";
            }
            else
            {
                progressForm = new GameSearchProgress();
                progressForm.Text = "Import Game";
                progressForm.OnWorkCancelled += new GameSearchProgress.WorkCancelledHandler(IcdProgressForm_OnWorkCancelled);
                progressForm.ProgressBar.Maximum = totalGamesCount;
                progressForm.ShowDialog(this);

            }
        }
        void IcdProgressForm_OnWorkCancelled(object sender, EventArgs args)
        {
            if (Icd != null)
            {
                DialogResult dr = MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask,"cancel","import game");
                if (dr == DialogResult.Yes)
                {
                    progressForm.OnWorkCancelled -= new GameSearchProgress.WorkCancelledHandler(IcdProgressForm_OnWorkCancelled);
                    Icd.CancelIcdToPgnConversion();
                }
                else
                {
                    return;
                }
            }
        }
        #endregion

        private void tsShowComments_Click(object sender, EventArgs e)
        {
            Ap.Options.ShowComments=!tsShowComments.Checked;
            tsShowComments.Checked = !tsShowComments.Checked;
            this.NotationUc.SetContextMenu(tsShowComments.Checked, true);
            Ap.Options.Save();
            this.NotationUc.Refresh(tsShowComments.Checked,tsShowDisconnectionLogs.Checked);
        }

        private void tsShowDisconnectionLogs_Click(object sender, EventArgs e)
        {
            Ap.Options.ShowDisconnectionLog = !tsShowDisconnectionLogs.Checked;
            tsShowDisconnectionLogs.Checked = !tsShowDisconnectionLogs.Checked;
            this.NotationUc.SetContextMenu(tsShowDisconnectionLogs.Checked, false);
            Ap.Options.Save();
            this.NotationUc.Refresh(tsShowComments.Checked, tsShowDisconnectionLogs.Checked);
        }

    }
}
