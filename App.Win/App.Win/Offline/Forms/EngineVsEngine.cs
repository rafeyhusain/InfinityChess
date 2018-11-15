using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using App.Model;
using InfinitySettings.UCIManager;
using System.IO;

namespace App.Win
{
    public partial class EngineVsEngine : BaseWinForm
    {
        #region DataMembers 

        public Game Game = null;

        #endregion

        #region Properties

        static UCIEngine uciEngineWhite;
        static public UCIEngine UCIEngineWhite
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return uciEngineWhite; }
        }

        static UCIEngine uciEngineBlack;
        static public UCIEngine UCIEngineBlack
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return uciEngineBlack; }
        }

        static Book bookWhite;
        static public Book BookWhite
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return bookWhite; }
        }

        static Book bookBlack;
        static public Book BookBlack
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return bookBlack; }
        }

        #endregion

        #region Ctor
                
        public EngineVsEngine(Game game)
        {
            InitializeComponent();
            this.Game = game;
            Ap.EngineOptions.GameType = GameType.Blitz;
        }

        #endregion

        #region Form Events 

        private void EngineVsEngine_Load(object sender, EventArgs e)
        {
            LoadControls();
            SetPlayersLabels();
            SetGameTypeTitle();
        }

        #endregion

        #region Controls Events 

        private void btnDefineWhite_Click(object sender, EventArgs e)
        {
            InviteEngine frmInviteEngine;
            if (uciEngineWhite != null && bookWhite != null)
                frmInviteEngine = new InviteEngine(uciEngineWhite, bookWhite, true, this.Game);
            else
                frmInviteEngine = new InviteEngine(true, this.Game);

            if (frmInviteEngine.ShowDialog() == DialogResult.OK)
            {
                uciEngineWhite = frmInviteEngine.SelectedEngine;
                bookWhite = frmInviteEngine.SelectedBook;

                Ap.EngineOptions.WhiteEngine = uciEngineWhite.EngineFile;
                Ap.EngineOptions.WhiteUseTablebases = uciEngineWhite.UseTablebases;
                Ap.EngineOptions.WhiteHashTableSize = uciEngineWhite.HashTableSize;
                Ap.EngineOptions.WhiteBook = "";

                if (bookWhite != null)
                {
                    Ap.EngineOptions.WhiteBook = bookWhite.FilePath;
                }

                SetPlayersLabels();
            }
        }

        private void btnDefineBlack_Click(object sender, EventArgs e)
        {
            InviteEngine frmInviteEngine;
            if (uciEngineBlack != null && bookBlack != null)
                frmInviteEngine = new InviteEngine(uciEngineBlack, bookBlack, false, this.Game);
            else
                frmInviteEngine = new InviteEngine(false, this.Game);

            if (frmInviteEngine.ShowDialog() == DialogResult.OK)
            {
                uciEngineBlack = frmInviteEngine.SelectedEngine;
                bookBlack = frmInviteEngine.SelectedBook;

                Ap.EngineOptions.BlackEngine = uciEngineBlack.EngineFile;
                Ap.EngineOptions.BlackUseTablebases = uciEngineBlack.UseTablebases;
                Ap.EngineOptions.BlackHashTableSize = uciEngineBlack.HashTableSize;
                Ap.EngineOptions.BlackBook = "";

                if (bookBlack != null)
                {
                    Ap.EngineOptions.BlackBook = bookBlack.FilePath;
                }

                SetPlayersLabels();
            }
        }

        private void btnStartMatch_Click(object sender, EventArgs e)
        {
            InitEngines();

            if (!ValidateMatchSettings())
            {
                return;
            }

            Ap.EngineOptions.NoOfGames = (int)numNumberOfGames.Value;
            Ap.EngineOptions.MoveLimit = (int)numMoveLimit.Value;

            Ap.EngineOptions.NoGameLimit = chkNoGameLimit.Checked;
            Ap.EngineOptions.NoMoveLimit = chkNoMoveLimit.Checked;
            Ap.EngineOptions.AlternateColor = chkAlternateColor.Checked;
            Ap.EngineOptions.FlipBoard = chkFlipBoard.Checked;

            this.Game.GameType = Ap.EngineOptions.GameType;

            Ap.EngineOptions.Save();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Ap.Help(this, HelpTopicIdE.EngineVsEngine);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void rdbBlitzGame_Click(object sender, EventArgs e)
        {
            if (rdbBlitzGame.Checked)
            {
                App.Win.BlitzClockForm frm = new App.Win.BlitzClockForm(this.Game);
                
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Ap.EngineOptions.GameType = GameType.Blitz;
                    SetGameTypeTitle();
                }
            }
        }

        private void rdbLongGame_Click(object sender, EventArgs e)
        {
            if (rdbLongGame.Checked)
            {
                LongClockForm frm = new LongClockForm(this.Game);
                
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Ap.EngineOptions.GameType = GameType.Long;
                    SetGameTypeTitle();
                }
            }
        }

        private void chkNoGameLimit_CheckedChanged(object sender, EventArgs e)
        {
            numNumberOfGames.Enabled = !chkNoGameLimit.Checked;
        }

        private void chkNoMoveLimit_CheckedChanged(object sender, EventArgs e)
        {
            numMoveLimit.Enabled = !chkNoMoveLimit.Checked;
        }

        #endregion

        #region Helper Methods 

        private void LoadControls()
        {
            numNumberOfGames.Value = Ap.EngineOptions.NoOfGames;
            numMoveLimit.Value = Ap.EngineOptions.MoveLimit;

            chkNoGameLimit.Checked = Ap.EngineOptions.NoGameLimit;
            chkNoMoveLimit.Checked = Ap.EngineOptions.NoMoveLimit;
            chkAlternateColor.Checked = Ap.EngineOptions.AlternateColor;
            chkFlipBoard.Checked = Ap.EngineOptions.FlipBoard;

            if (string.IsNullOrEmpty(Ap.EngineOptions.DatabaseFile))
            {
                txtDatabasePath.Text = Ap.FileDatabaseE2E;
                Ap.EngineOptions.DatabaseFile = Ap.FileDatabaseE2E;
                Ap.EngineOptions.Save();
                Database.CreateE2eIfNotExists();
            }
            else
            {
                txtDatabasePath.Text = Ap.EngineOptions.DatabaseFile;
            }

            switch (Ap.EngineOptions.GameType)
            {
                case GameType.Blitz:
                    rdbBlitzGame.Checked = true;
                    break;
                case GameType.Long:
                    rdbLongGame.Checked = true;
                    break;
            }
        }

        private void SetPlayersLabels()
        {
            string fileName="";

            fileName = GetFileName(Ap.EngineOptions.WhiteEngine);
            lblWhiteEngine.Text = fileName + " (" + Ap.EngineOptions.WhiteHashTableSize + " MB)";

            fileName = GetFileName(Ap.EngineOptions.BlackEngine);
            lblBlackEngine.Text = fileName + " (" + Ap.EngineOptions.BlackHashTableSize + " MB)";

            if (string.IsNullOrEmpty(Ap.EngineOptions.WhiteBook))
            {
                lblBookWhite.Text = "No book";
            }
            else
            {
                lblBookWhite.Text = GetFileName(Ap.EngineOptions.WhiteBook);
            }
            
            if (string.IsNullOrEmpty(Ap.EngineOptions.BlackBook))
            {
                lblBookBlack.Text = "No book";
            }
            else
            {
                lblBookBlack.Text = GetFileName(Ap.EngineOptions.BlackBook);
            }
        }

        private void SetGameTypeTitle()
        {
            string gameTypeTitle = Ap.GetGameTypeTitle(Ap.EngineOptions.GameType);

            lblSelectedGameType.Text = gameTypeTitle;
            txtMatchTitle.Text = Environment.MachineName + ", " + gameTypeTitle;
        }

        private string GetFileName(string filePath)
        {
            int length = 25;
            string fileName = "";
            
            if (System.IO.File.Exists(filePath))
            {
                fileName = System.IO.Path.GetFileNameWithoutExtension(filePath);

                if (fileName.Length > length)
                    fileName = fileName.Substring(0, length) + "... ";
            }

            return fileName;
        }

        private void InitEngines()
        {
            if (uciEngineWhite == null && File.Exists(Ap.EngineOptions.WhiteEngine))
            {
                uciEngineWhite = new UCIEngine(Ap.EngineOptions.WhiteEngine, Ap.EngineOptions.HashTableSize, this.Game);
                uciEngineWhite.UseTablebases = Ap.EngineOptions.UseTablebases;
                uciEngineWhite.Load();
                uciEngineWhite.Close();
            }
            if (uciEngineBlack == null && File.Exists(Ap.EngineOptions.BlackEngine))
            {
                uciEngineBlack = new UCIEngine(Ap.EngineOptions.BlackEngine, Ap.EngineOptions.HashTableSize, this.Game);
                uciEngineBlack.UseTablebases = Ap.EngineOptions.UseTablebases;
                uciEngineBlack.Load();
                uciEngineBlack.Close();
            }

            if (bookWhite == null && File.Exists(Ap.EngineOptions.WhiteBook))
            {
                bookWhite = new Book(this.Game, Ap.EngineOptions.WhiteBook);
                bookWhite.BookOptions.OptionsType = BookOptionsType.WhiteEngine;
                bookWhite.SetOptions();
            }

            if (bookBlack == null && File.Exists(Ap.EngineOptions.BlackBook))
            {
                bookBlack = new Book(this.Game, Ap.EngineOptions.BlackBook);
                bookBlack.BookOptions.OptionsType = BookOptionsType.BlackEngine;
                bookBlack.SetOptions();
            }
        }

        private bool ValidateMatchSettings()
        {
            if (uciEngineWhite == null)
            {
                MessageForm.Show(this, MsgE.InfoSelectEngineForWhite);
                return false;
            }
            if (uciEngineBlack == null)
            {
                MessageForm.Show(this, MsgE.InfoSelectEngineForBlack);
                return false;
            }

            string dbFilePath = txtDatabasePath.Text.Trim();
            if (string.IsNullOrEmpty(dbFilePath) || !UFile.Exists(dbFilePath))
            {
                MessageForm.Show(this, MsgE.InfoSelectDatabaseFileForE2E);
                return false;
            }

            return true;
        }

        #endregion

        #region Overrides 

        public override string HelpTopicId
        {
            get { return "90"; }
        }

        #endregion

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Databases icd(*" + Files.DatabaseExtension + ")|*" + Files.DatabaseExtension;
            saveFileDialog1.FileName = "*" + Files.DatabaseExtension;
            saveFileDialog1.InitialDirectory = Ap.FolderDatabase;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;
                txtDatabasePath.Text = fileName;

                Ap.LoadDatabase(fileName);
                Ap.Database.Save();

                Ap.EngineOptions.DatabaseFile = fileName;
                Ap.EngineOptions.Save();
            }
        }
    }
}