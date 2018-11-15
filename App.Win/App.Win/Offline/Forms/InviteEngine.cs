using System; using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using InfinitySettings.EngineManager;
using InfinitySettings.UCIManager;
using System.IO;

namespace App.Win
{
    public partial class InviteEngine : BaseWinForm
    {
        #region DataMembers 
                
        public Game Game = null;
        public InfinityChess.TournamentManager.Tournament TournamentInfo;

        UCIEngine selectedEngine;

        Book selectedBook;

        bool isWhite = false;
        InfinitySettings.UCIManager.EngineParameters engineParameters;

        #endregion

        #region Ctor
                
        public InviteEngine(bool isWhite,Game game)
        {
            InitializeComponent();
            this.Game = game;
            this.isWhite = isWhite;
            TournamentInfo = new InfinityChess.TournamentManager.Tournament(this.Game);
        }       

        public InviteEngine(UCIEngine uciEngine, Book book, bool isWhite,Game game)
        {
            InitializeComponent();

            this.Game = game;
            this.selectedEngine = uciEngine;
            this.selectedBook = book;
            this.isWhite = isWhite;
            TournamentInfo = new InfinityChess.TournamentManager.Tournament(this.Game);
        }

        #endregion        

        #region Properties 

        public UCIEngine SelectedEngine
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return selectedEngine; }
        }

        public Book SelectedBook
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return selectedBook; }
        }

        bool IsBookSelected
        {
            get
            {
                bool isSelected = false;

                if(isWhite)
                {
                    isSelected = !string.IsNullOrEmpty(Ap.EngineOptions.WhiteBook) && File.Exists(Ap.EngineOptions.WhiteBook);
                }
                else
                {
                    isSelected = !string.IsNullOrEmpty(Ap.EngineOptions.BlackBook) && File.Exists(Ap.EngineOptions.BlackBook);
                }

                return isSelected;
            }
        }

        bool IsWhiteEngineSelected
        {
            get
            {
                return !string.IsNullOrEmpty(Ap.EngineOptions.WhiteEngine) && File.Exists(Ap.EngineOptions.WhiteEngine);
            }
        }

        bool IsBlackEngineSelected
        {
            get
            {
                return !string.IsNullOrEmpty(Ap.EngineOptions.BlackEngine) && File.Exists(Ap.EngineOptions.BlackEngine);
            }
        }

        #endregion

        #region FormEvents

        private void InviteEngine_Load(object sender, EventArgs e)
        {
            LoadEnginesList();
            LoadEngineValues();
        }

        #endregion

        #region Helper Methods 
                
        private void LoadEnginesList()
        {
            EngineManager objEngineManager = new EngineManager();
            InfinitySettings.EngineManager.Engine _defaultEngine = objEngineManager.LoadDefaultEngine();
            List<InfinitySettings.EngineManager.Engine> engines = objEngineManager.LoadEngines();
            engines = engines.Where(x => x.IsActive == true).ToList();

            for (int i = 0; i < TournamentInfo.ParticipitantList.Count; i++)
            {
                for (int j = 0; j < engines.Count; j++)
                {
                    if (engines[j].Name == TournamentInfo.ParticipitantList[i].ToString())
                    {
                        engines.Remove(engines[j]);
                    }
                }
            }

            if (isWhite) // remove engine from list, if it is already selected for black engine
            {
                if (App.Win.EngineVsEngine.UCIEngineBlack != null)
                {
                    for (int i = 0; i < engines.Count; i++)
                    {
                        if (engines[i].TitleOnly == App.Win.EngineVsEngine.UCIEngineBlack.EngineName)
                            engines.Remove(engines[i]);
                    }
                }
            }
            else // remove engine from list, if it is already selected for white engine
            {
                if (App.Win.EngineVsEngine.UCIEngineWhite != null)
                {
                    for (int i = 0; i < engines.Count; i++)
                    {
                        if (engines[i].TitleOnly == App.Win.EngineVsEngine.UCIEngineWhite.EngineName)
                            engines.Remove(engines[i]);
                    }
                }
            }

            if (engines.Count > 0)
            {
                lstEngines.DisplayMember = "Name";
                lstEngines.ValueMember = "FilePath";
                lstEngines.DataSource = engines;
                if (!String.IsNullOrEmpty(_defaultEngine.FilePath))
                {
                    lstEngines.SelectedValue = _defaultEngine.FilePath;
                }

                SetSelectedEngine();
            }
        }

        private void SetSelectedEngine()
        {
            if (lstEngines.SelectedValue == null)
            {
                if (IsWhiteEngineSelected)
                {
                    lstEngines.SelectedValue = Ap.EngineOptions.WhiteEngine;
                }
                else if (IsBlackEngineSelected)
                {
                    lstEngines.SelectedValue = Ap.EngineOptions.BlackEngine;
                }
            }
        }

        private void LoadEngineValues()
        {
            if (selectedBook != null)
            {
                lblBook.Text = selectedBook.FileName;
            }

            if (selectedEngine != null)
            {
                lstEngines.SelectedValue = selectedEngine.EngineFile;
            }

            if (isWhite)
            {
                numHashTableSize.Value = Ap.EngineOptions.WhiteHashTableSize;
            }
            else
            {
                numHashTableSize.Value = Ap.EngineOptions.BlackHashTableSize;
            }
        }

        private void LoadBook()
        {
            if (selectedBook != null)
            {
                return;
            }

            if (isWhite)
            {
                selectedBook = new Book(this.Game, Ap.EngineOptions.WhiteBook);
                selectedBook.BookOptions.OptionsType = BookOptionsType.WhiteEngine;
            }
            else
            {
                selectedBook = new Book(this.Game, Ap.EngineOptions.BlackBook);
                selectedBook.BookOptions.OptionsType = BookOptionsType.BlackEngine;
            }            
        }

        #endregion

        #region Controls Events 

        private void btnBookChoice_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdLoadBook = new OpenFileDialog();
            ofdLoadBook.Filter = "Trees icb(*" + Files.OpeningBookExtension + ")|*" + Files.OpeningBookExtension;
            ofdLoadBook.FileName = "*" + Files.OpeningBookExtension;
            ofdLoadBook.InitialDirectory = Ap.FolderBooks;

            if (ofdLoadBook.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofdLoadBook.FileName;
                if (isWhite)
                {
                    Ap.EngineOptions.WhiteBook = fileName;
                }
                else
                {
                    Ap.EngineOptions.BlackBook = fileName;
                }
                Ap.EngineOptions.Save();
                selectedBook = null;
                LoadBook();
                lblBook.Text = selectedBook.FileName;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lstEngines.Items.Count > 0 && lstEngines.SelectedValue != null)
            {
                string engineFilePath = lstEngines.SelectedValue.ToString();
                int hashTableSize = (int)numHashTableSize.Value;

                if (selectedEngine != null)
                    selectedEngine.Close();

                selectedEngine = new UCIEngine(engineFilePath, hashTableSize, this.Game);
                if (engineParameters != null)
                {
                    engineParameters.SetEngineParameters(selectedEngine);
                }

                selectedEngine.UseTablebases = chkUseTablebases.Checked;
                selectedEngine.Load();
                selectedEngine.Close();

                if (selectedBook != null && selectedBook.BookOptions != null && selectedBook.BookOptions.UseBook)
                {
                    selectedBook.SetOptions(selectedBook.BookOptions);
                }
                else
                {
                    selectedBook = null;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnBookOption_Click(object sender, EventArgs e)
        {
            if (!IsBookSelected)
            {
                return;
            }
            LoadBook();

            App.Win.BookOptionsPopup frm = new App.Win.BookOptionsPopup(selectedBook.BookOptions, this.Game);
            frm.ShowDialog(this);
        }

        private void btnEnginParameter_Click(object sender, EventArgs e)
        {
            string engineFilePath = lstEngines.SelectedValue.ToString();
            EngineParametersPopup frm = new EngineParametersPopup(engineFilePath, this.Game);            
            frm.ShowDialog(this);
            engineParameters = frm.Parameters;
        }

        private void btnCreateEngine_Click(object sender, EventArgs e)
        {
            SetupUCIEngine frm = new SetupUCIEngine(this.Game);            
            frm.ShowDialog(this);

            LoadEnginesList();
        }

        #endregion
                
    }
}