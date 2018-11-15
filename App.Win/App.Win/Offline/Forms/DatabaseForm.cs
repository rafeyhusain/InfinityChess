using System;
using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Xml;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using App.Win;

namespace InfinityChess.WinForms
{
    public partial class DatabaseForm : Form
    {
        #region Data Member
        public Game Game = null;
        public MainForm MainForm = null;
        BindingManagerBase bindingManager;
        GameSearchProgress progressForm;
        int TotalGames = 0;
        #endregion

        #region Ctor
        public DatabaseForm(MainOffline mainForm, Game game)
        {
            MainForm = mainForm;
            this.Game = game;
            InitializeComponent();
        }
        #endregion

        #region Properties
        public DataTable GameDataTable { get { return (DataTable)this.GameGridView.DataSource; } }
        public NotationUc NotationUc
        {
            get
            {
                return MainForm.NotationUc;
            }
        }
        public DataGridView GamesGrid
        {
            get
            {
                return this.GameGridView;
            }
        }
        #endregion

        #region DatabaseForm Events
        private void DatabaseForm_Load(object sender, EventArgs e)
        {
            InitDatabaseFilesPathCombo();
            InitGamesGrid();
            this.CurrentGameHighlighted();
        }

        #endregion

        #region GamesGrid
        public void InitGamesGrid()
        {
            if (cmboDatabaseFilePaths.Items != null)
            {
                if (cmboDatabaseFilePaths.Items.Count > 0)
                {
                    ToolStripComboBox toolStripcmbo = toolStripFilePaths.Items["cmboDatabaseFilePaths"] as ToolStripComboBox;
                    ComboBox cmboDBFilePaths = toolStripcmbo.ComboBox as ComboBox;
                    string databaseFileName = cmboDBFilePaths.SelectedValue.ToString();
                    this.Text = "Database  ( " + Path.GetFileName(databaseFileName) + " )";
                    if (databaseFileName != string.Empty)
                    {

                        if (!databaseFileName.EndsWith(Files.DatabaseExtension))
                        {
                            ShowInvalidFileFormatMessage();
                            return;
                        }
                        try
                        {
                            Ap.LoadDatabase(databaseFileName);
                        }
                        catch ( Exception ex)
                        {
                            TestDebugger.Instance.WriteError(ex);
                            ShowInvalidFileFormatMessage();
                            return;
                        }

                        Ap.Options.CurrentDatabaseFilePath = databaseFileName;
                        Ap.Options.Save();

                        GameGridView.AutoGenerateColumns = false;

                        ProgressForm frm = ProgressForm.Show(this, "Loading Database....");
                        DataTable gameItems = Ap.Database.GameItems.GetGamesData();
                        DataBind(gameItems);
                        frm.Close();
                        GameGridView.Focus();
                    }
                }
            }
        }

        public void DataBind(DataTable games)
        {
            if (games.Rows.Count > 0)
            {
                GameGridView.DataSource = games;
                bindingManager = GameGridView.BindingContext[GameGridView.DataSource, GameGridView.DataMember];
                ToolStripMenuItem editMenuItem = menuStrip.Items["fileToolStripMenuItem"] as ToolStripMenuItem;
                editMenuItem.DropDownItems["editGameDataToolStripMenuItem"].Enabled = true;
            }
            else
            {
                DataTable emptyGameTable = Database.GetDatabaseViewDataTable();
                DataRow emptyGameRow = emptyGameTable.NewRow();
                emptyGameRow[Database.Players] = "No Game Found";
                emptyGameTable.Rows.Add(emptyGameRow);
                GameGridView.DataSource = emptyGameTable;
                ToolStripMenuItem editMenuItem = menuStrip.Items["fileToolStripMenuItem"] as ToolStripMenuItem;
                editMenuItem.DropDownItems["editGameDataToolStripMenuItem"].Enabled = false;
            }
        }
        #endregion

        #region Invalid File Format Message
        private void ShowInvalidFileFormatMessage()
        {
            MessageForm.Show(this, MsgE.ErrorInvalidFileFormat);
        }
        #endregion

        #region Populating ComboBox With DatbaseFilePaths
        private void InitDatabaseFilesPathCombo()
        {
            InitDatabaseFilesPathCombo(null);
        }

        public void InitDatabaseFilesPathCombo(string filePath)
        {
            for (int filePathCounter = 0; filePathCounter <= Ap.Databases.Count - 1; filePathCounter++)
            {
                DataRow row = Ap.Databases.DatabaseFilesData.Rows[filePathCounter];

                if (!File.Exists(row[Databases.Path].ToString()))
                {
                    Ap.Databases.Remove(row[Databases.Path].ToString());
                }
            }

            Ap.Databases.Save();

            ToolStripComboBox toolStripcmbo = toolStripFilePaths.Items["cmboDatabaseFilePaths"] as ToolStripComboBox;
            ComboBox cmboDBFilePaths = toolStripcmbo.ComboBox as ComboBox;
            cmboDBFilePaths.DisplayMember = Databases.ShortPath;
            cmboDBFilePaths.ValueMember = Databases.Path;
            cmboDBFilePaths.DataSource = Ap.Databases.DatabaseFilesData as IListSource;
            cmboDBFilePaths.Select();
            cmboDBFilePaths.SelectedIndexChanged += new EventHandler(cmboDBFilePaths_SelectedIndexChanged);

            if (!String.IsNullOrEmpty(filePath))
            {
                cmboDBFilePaths.SelectedValue = filePath;
            }
        }

        #endregion

        #region DatabaseFilePathComboBoxEventHandler
        void cmboDBFilePaths_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitGamesGrid();
        }
        #endregion

        #region ToolStrip Event Handler

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tsbActivateGameWindow_Click(object sender, EventArgs e)
        {
            if (MainForm != null)
            {
                MainForm.Activate();
            }

        }
        private void tsbAppendGame_Click(object sender, EventArgs e)
        {
            this.SaveGameInCurrentGameDatabase();
        }
        private void tsbReplaceGame_Click(object sender, EventArgs e)
        {
            this.ReplaceGameInCurrentGameDatabase();
        }
        private void databaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Databases icd(*" + Files.DatabaseExtension + ")|*" + Files.DatabaseExtension;
            saveFileDialog1.FileName = "*" + Files.DatabaseExtension;
            saveFileDialog1.InitialDirectory = Ap.FolderDatabase;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;

                Ap.Databases.Add(fileName);
            }
        }

        #endregion

        #region File Menu ********************************************
        private void openDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofdOpenDatabase.Filter = "Databases icd(*" + Files.DatabaseExtension + ")|*" + Files.DatabaseExtension;
            ofdOpenDatabase.FileName = "*" + Files.DatabaseExtension;
            ofdOpenDatabase.InitialDirectory = Ap.FolderDatabase;

            if (ofdOpenDatabase.ShowDialog() == DialogResult.OK)
            {
                if (!Ap.Databases.Exists(ofdOpenDatabase.FileName))
                {
                    if (ofdOpenDatabase.FileName.EndsWith(Files.DatabaseExtension))
                    {
                        Ap.Databases.Add(ofdOpenDatabase.FileName);
                    }
                    else
                    {
                        ShowInvalidFileFormatMessage();
                        return;
                    }
                }
                InitDatabaseFilesPathCombo();
                InitGamesGrid();
                this.CurrentGameHighlighted();
                ToolStripComboBox toolStripcmbo = toolStripFilePaths.Items["cmboDatabaseFilePaths"] as ToolStripComboBox;
                ComboBox cmboDBFilePaths = toolStripcmbo.ComboBox as ComboBox;
                cmboDBFilePaths.SelectedValue = ofdOpenDatabase.FileName;
            }
        }
        private void newDatabaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Databases icd(*" + Files.DatabaseExtension + ")|*" + Files.DatabaseExtension;
            saveFileDialog1.FileName = "*" + Files.DatabaseExtension;
            saveFileDialog1.InitialDirectory = Ap.FolderDatabase;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;
                if (!fileName.EndsWith(Files.DatabaseExtension))
                {
                    fileName = fileName + Files.DatabaseExtension;
                }
                this.Game.SaveEmptyGame(fileName);

                Ap.Databases.Add(fileName);

                InitDatabaseFilesPathCombo();
                ToolStripComboBox toolStripcmbo = toolStripFilePaths.Items["cmboDatabaseFilePaths"] as ToolStripComboBox;
                ComboBox cmboDBFilePaths = toolStripcmbo.ComboBox as ComboBox;
                cmboDBFilePaths.SelectedIndex = cmboDBFilePaths.Items.Count - 1;
            }

        }
        private void gotoInfiChessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ap.OpenHomeUrl();
        }
        private void closeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        public void SearchGames(App.Model.GameSearch gameSearchData)
        {
            RegisterEventHandlers();
            Ap.Database.SearchGames(gameSearchData);
        }        

        #region Edit Menu ****************************************************

        private void editGameDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = GameGridView.SelectedRows[0];
            int editGameIndex = selectedRow.Index;
            if (selectedRow != null)
            {
                //string selectedGameGuid = selectedRow.Cells[Database.Guid].Value.ToString();
                string selectedGameGuid = GameDataTable.Rows[selectedRow.Index][Database.Guid].ToString();

                GameItem selectedGameItem = Ap.Database.GameItems.GetGameByGuid(selectedGameGuid);
                if (selectedGameGuid != string.Empty && selectedGameItem != null)
                {
                    InfinityChess.GameData.frmGameData frmGameData = new InfinityChess.GameData.frmGameData(selectedGameItem.GameData, this.MainForm);
                    frmGameData.Game = this.Game;

                    if (frmGameData.ShowDialog(this) == DialogResult.OK)
                    {

                        int selectedGameIndex = Ap.Database.GameItems.GetGameIndexByGuid(selectedGameGuid);
                        string updatedGameXml = this.Game.GetGameXml(selectedGameItem.GameData);
                        Ap.Database.UpdateGame(updatedGameXml, selectedGameIndex);
                        Ap.Database.Save();
                        this.FocusOpenedDatabaseForm();
                        GameGridView.Rows[editGameIndex].Selected = true;
                    }
                }
            }
        }

        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.Win.GameSearch gameSearch = new App.Win.GameSearch(this.Game, this.MainForm);
            if (gameSearch.ShowDialog(this) == DialogResult.OK)
            {
                SearchGames(gameSearch.GameSearchData);
            }
        }



        private void gotoLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfinityChess.WinForms.frmGotoLineNumber lineNumber = new frmGotoLineNumber(this);
            lineNumber.ShowDialog();
        }
        #endregion

        #region Help Menu ****************************************************

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InfinityChesshelp.InfinityChessHelp.OpenHelpFile();
        }
        private void aboutInfinityChessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutInfinityChess frm = new AboutInfinityChess();
            frm.ShowDialog();
        }

        #endregion

        #region Grid View Event Handlers
        private void GameGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            if (bindingManager != null)
            {
              DataRow findRow =((DataRowView)bindingManager.Current).Row;
              ShowGame(findRow[Database.Guid].ToString()); 
            }
           // ShowGame(GameDataTable.Rows[e.RowIndex][Database.Guid].ToString());
        }
        #endregion

        #region DisplayGameByGuid
        public void ShowGame(string guid)
        {
            if (string.IsNullOrEmpty(guid))
            {
                return;
            }

            Ap.Options.CurrentGameDatabaseFilePath = Ap.Options.CurrentDatabaseFilePath;
            Ap.Options.Save();
            this.Game.LoadGame(guid);

            if (MainForm == null)
            {
                InfinityChess.WinForms.MainOffline frm = new InfinityChess.WinForms.MainOffline();
                frm.Show();
                frm.Visible = true;
                frm.GameSelectedMode();                
            }
            else if (!MainForm.IsDisposed)
            {
                MainForm.Visible = true;
                MainForm.Focus();
                MainForm.GameSelectedMode();                
            }
        }
        #endregion

        #region DatabaseFormEventHandler
        private void DatabaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Ap.Database != null)
            {
                UnregisterEventHandlers();
            }
            MainForm.DatabaseForm = null;

            this.MainForm.Focus();
        }
        #endregion

        #region Helper
        #region Open The Database Form
        public static void OpenDatabaseForm(MainOffline mainOffline, Game game)
        {
            if (mainOffline.DatabaseForm == null)
            {
                mainOffline.DatabaseForm = new DatabaseForm(mainOffline, game);
                mainOffline.DatabaseForm.Show();
            }
            else
            {
                mainOffline.DatabaseForm.Visible = true;
                mainOffline.DatabaseForm.Focus();
            }

        }
        #endregion

        #region Focus Opened Database Form
        public void FocusOpenedDatabaseForm()
        {
            this.InitGamesGrid();
        }
        #endregion

        #region Update Games Grid Database Form
        public void UpdateGamesGrid()
        {
            this.InitGamesGrid();
            if (MainForm != null)
            {
                MainForm.Focus();
            }
        }
        #endregion

        #region Highlight The Current Game In The Games Grid
        public void CurrentGameHighlighted()
        {
            if (Ap.Database != null)
            {
                int currentGameIndex = Ap.Database.GameItems.GetCurrentGameIndex();
                if (currentGameIndex != -1)
                {
                    this.GameGridView.Rows[currentGameIndex].Selected = true;
                }
                else if (this.GameGridView.RowCount > 0)
                {
                    this.GameGridView.Rows[0].Selected = true;
                }
            }
        }
        #endregion

        #region Save Game In The Current Database
        public void SaveGameInCurrentGameDatabase()
        {
            InfinityChess.GameData.frmGameData frmGameData = new InfinityChess.GameData.frmGameData(this.MainForm);
            frmGameData.Game = this.Game;

            if (frmGameData.ShowDialog(this) == DialogResult.OK)
            {
                string fileName = Ap.Options.CurrentDatabaseFilePath;
                if (!fileName.EndsWith(Files.DatabaseExtension))
                {
                    fileName = fileName + Files.DatabaseExtension;
                }
                this.Game.GameData.Guid = string.Empty;
                this.Game.SaveGame(fileName);
                Ap.Databases.Add(fileName);
                Ap.Options.CurrentGameDatabaseFilePath = fileName;
                Ap.Options.CurrentGameGuid = this.Game.GameData.Guid;
                Ap.Options.Save();
                MainForm.GameSelectedMode();
                this.FocusOpenedDatabaseForm();
            }

        }
        #endregion

        #region Replace Game In The Current Database
        public void ReplaceGameInCurrentGameDatabase()
        {
            InfinityChess.GameData.frmGameData frmGameData = new InfinityChess.GameData.frmGameData(this.MainForm);
            frmGameData.Game = this.Game;

            if (frmGameData.ShowDialog(this) == DialogResult.OK)
            {
                string fileName = string.Empty;

                if (Ap.Options.CurrentGameGuid == string.Empty)
                {
                    fileName = Ap.Options.DefaultGameDatabaseFilePath;
                    this.Game.GameData.Guid = string.Empty;
                    this.Game.SaveGame(fileName);
                    Ap.Databases.Add(fileName);
                    Ap.Options.CurrentGameDatabaseFilePath = fileName;
                    Ap.Options.CurrentGameGuid = this.Game.GameData.Guid;
                    Ap.Options.Save();
                    MainForm.GameSelectedMode();
                    this.FocusOpenedDatabaseForm();
                }
                else
                {
                    fileName = Ap.Options.CurrentGameDatabaseFilePath;
                    Ap.LoadDatabase(fileName);
                    GameItem gameItem = Ap.Database.GameItems.GetGameByGuid(Ap.Options.CurrentGameGuid);
                    int currentGameIndex = Ap.Database.GameItems.GetCurrentGameIndex();
                    this.Game.GameData.Guid = Ap.Options.CurrentGameGuid;
                    string updatedGameXml = this.Game.GetGameXml();
                    Ap.Database.UpdateGame(updatedGameXml, currentGameIndex);
                    Ap.Database.Save();
                    MainForm.GameSelectedMode();
                    this.FocusOpenedDatabaseForm();
                }
            }
        }
        #endregion

        #region Unregister Events
        private void UnregisterEventHandlers()
        {
            Ap.Database.OnProgressBarInitialized -= new Database.ProgressBarInitHandler(Database_OnProgressBarInitialized);
            Ap.Database.OnProgressChanged -= new Database.ProgressChangedEventHandler(Database_OnProgressChanged);
            Ap.Database.OnProgressWorkCompleted -= new Database.ProgressWorkCompletedHandler(Database_OnProgressWorkCompleted);

        }
        #endregion

        #region Register Events
        private void RegisterEventHandlers()
        {
            Ap.Database.OnProgressBarInitialized += new Database.ProgressBarInitHandler(Database_OnProgressBarInitialized);
            Ap.Database.OnProgressChanged += new Database.ProgressChangedEventHandler(Database_OnProgressChanged);
            Ap.Database.OnProgressWorkCompleted += new Database.ProgressWorkCompletedHandler(Database_OnProgressWorkCompleted);
        }
        #endregion

        #region ProgressBar
        ProgressForm waitingForm;
        void Database_OnProgressBarInitialized(object sender, ProgressBarEventArgs e)
        {
            TotalGames = e.TotalGames;
        }
        void Database_OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == -1 && waitingForm == null)
            {
                waitingForm = new ProgressForm();
                waitingForm.ProgressText = "Please Wait......";
                waitingForm.ControlBox = false;
                waitingForm.Text = "  ";
                waitingForm.StartPosition = FormStartPosition.CenterScreen;
                waitingForm.Show(this);
            }
            else
            {
                if (e.ProgressPercentage != -1 && waitingForm != null)
                {
                    waitingForm.Close();
                }

                if (progressForm != null)
                {
                    progressForm.ProgressBar.Show();
                    progressForm.ProgressBar.Refresh();
                    progressForm.ProgressBar.Value = e.ProgressPercentage;
                    progressForm.GameNo.Text = "Game " + e.ProgressPercentage.ToString();
                    string percentage = Math.Round((((double)e.ProgressPercentage / TotalGames) * 100)).ToString();
                    progressForm.Percentage.Text = percentage + "%";
                }
                else
                {
                    progressForm = new GameSearchProgress();
                    progressForm.Text = "Searching Games....";
                    progressForm.OnWorkCancelled += new GameSearchProgress.WorkCancelledHandler(progressForm_OnWorkCancelled);
                    progressForm.ProgressBar.Maximum = TotalGames;
                    progressForm.ShowDialog(this);
                }
            }
        }
        void progressForm_OnWorkCancelled(object sender, EventArgs args)
        {
            if (Ap.Database != null)
            {
                DialogResult dr = MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, "cancel", "searching");
                if (dr == DialogResult.Yes)
                {
                    progressForm.OnWorkCancelled -= new GameSearchProgress.WorkCancelledHandler(progressForm_OnWorkCancelled);
                    Ap.Database.CancelSearching();
                }
                else
                {
                    return;
                }
            }
        }
        void Database_OnProgressWorkCompleted(object sender, ProgressWorkCompletedEventArgs e)
        {
            if (progressForm != null)
            {
                progressForm.Timer.Stop();
                if (e.arguments.Cancelled)
                {
                    MessageForm.Show(this, MsgE.SearchingCancelled);
                }
                if (!e.arguments.Cancelled)
                {
                    MessageForm.Show(this, MsgE.SearchingCompleted);
                    progressForm.OnWorkCancelled -= new GameSearchProgress.WorkCancelledHandler(progressForm_OnWorkCancelled);
                    
                }
                progressForm.Close();
                progressForm = null;
                UnregisterEventHandlers();
                DataBind(e.SearchedGames);

            }
        }
        #endregion

        #endregion
    }
}
