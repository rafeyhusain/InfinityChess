using System; using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using InfinitySettings.EngineManager;
using InfinitySettings.UCIManager;
using InfinityChess.Winforms;
using System.Linq;
using App.Win;
using InfinityChess.WinForms;

namespace App.Win
{
    public partial class LoadEngine : BaseWinForm
    {
        #region Data Members 

        public Game Game = null;
        public MainForm MainForm;
        UCIEngine selectedEngine;
        InfinitySettings.UCIManager.EngineParameters engineParameters;

        private bool _isAddKibitzer;       
        
        #endregion
        
        #region Ctor & Load 
                
        public LoadEngine(Game game, MainForm mainForm)
        {
            this.Game = game;
            this.MainForm = mainForm;
            this.selectedEngine = this.Game.DefaultEngine;
            InitializeComponent();
        }     

        private void LoadEngine_Load(object sender, EventArgs e)
        {
            LoadHashTableCombo();
            LoadEnginesList();
            LoadEngineOptions();
        }
        
        #endregion

        #region Properties 

        public bool IsAddKibitzer
        {
            get { return _isAddKibitzer; }
            set { _isAddKibitzer = value; }
        }

        public UCIEngine SelectedEngine
        {
            get { return selectedEngine; }
        }

        public bool IsNewEngineSelected
        {
            get
            {
                if (lstEngines.SelectedValue == null)
                {
                    return false;
                }

                return selectedEngine != null && selectedEngine.EngineFile != lstEngines.SelectedValue.ToString();
            }
        }

        #endregion

        #region Helper Methods

        private void LoadHashTableCombo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("HashDisplay", typeof(string));
            dt.Columns.Add("HashValue", typeof(string));
            dt.Rows.Add(new object[] { "1 MB", 1 });
            dt.Rows.Add(new object[] { "4 MB", 4 });
            dt.Rows.Add(new object[] { "10 MB", 10 });
            dt.Rows.Add(new object[] { "12 MB", 12 });
            dt.Rows.Add(new object[] { "16 MB", 16 });
            dt.Rows.Add(new object[] { "24 MB", 24 });
            dt.Rows.Add(new object[] { "32 MB", 32 });
            dt.Rows.Add(new object[] { "48 MB", 48 });
            dt.Rows.Add(new object[] { "64 MB", 64 });
            dt.Rows.Add(new object[] { "96 MB", 96 });
            dt.Rows.Add(new object[] { "128 MB", 128 });
            dt.Rows.Add(new object[] { "192 MB", 192 });
            dt.Rows.Add(new object[] { "256 MB", 256 });
            dt.Rows.Add(new object[] { "288 MB", 288 });
            dt.Rows.Add(new object[] { "311 MB", 311 });
            dt.Rows.Add(new object[] { "384 MB", 384 });
            dt.Rows.Add(new object[] { "432 MB", 432 });
            dt.Rows.Add(new object[] { "512 MB", 512 });
            dt.Rows.Add(new object[] { "768 MB", 768 });
            dt.Rows.Add(new object[] { "832 MB", 832 });
            dt.Rows.Add(new object[] { "1024 MB", 1024 });
            dt.Rows.Add(new object[] { "1536 MB", 1536 });
            dt.Rows.Add(new object[] { "1595 MB", 1595 });
            dt.Rows.Add(new object[] { "2 GB", 2048 });
            dt.Rows.Add(new object[] { "3 GB", 3072 });
            dt.Rows.Add(new object[] { "4 GB", 4096 });

            cmbHashTableSize.DataSource = dt;
            cmbHashTableSize.DisplayMember = "HashDisplay";
            cmbHashTableSize.ValueMember = "HashValue";
            cmbHashTableSize.SelectedValue = cmbHashTableSize.Items[0];
        }

        private void LoadEnginesList()
        {
            EngineManager objEngineManager = new EngineManager();
            List<InfinitySettings.EngineManager.Engine> lstEngine = objEngineManager.LoadEngines();
            lstEngine = lstEngine.Where(x => x.IsActive == true).ToList();
            if (IsAddKibitzer == true)
            {
                List<InfinitySettings.EngineManager.Engine> lstKibitzer = new List<InfinitySettings.EngineManager.Engine>();
                if (lstEngine.Count > 0)
                {
                    foreach (var item in lstEngine)
                    {
                        foreach (var itemKibitzer in this.MainForm.KibitzerManager.KibitzersList)
                        {
                            if (item.TitleOnly.ToLower() == itemKibitzer.UCIEngine.EngineName.ToLower())
                            {
                                lstKibitzer.Add(item);
                            }
                        }
                    }
                    foreach (var item in lstKibitzer)
                    {
                        lstEngine.Remove(item);
                    }
                    if (lstEngine.Count > 0)
                    {
                        lstEngines.DisplayMember = "Name";
                        lstEngines.ValueMember = "FilePath";
                        lstEngines.DataSource = lstEngine;
                    }
                }
            }
            else
            {
                if (lstEngine.Count > 0)
                {
                    lstEngines.DisplayMember = "Name";
                    lstEngines.ValueMember = "FilePath";
                    lstEngines.DataSource = lstEngine;

                    InfinitySettings.EngineManager.Engine _defaultEngine = objEngineManager.LoadDefaultEngine();
                    if (!String.IsNullOrEmpty(_defaultEngine.FilePath))
                        lstEngines.SelectedValue = _defaultEngine.FilePath;
                }
            }
        }

        private void LoadEngineOptions()
        {
            chkUseTablebases.Checked = Ap.EngineOptions.UseTablebases;
            cmbHashTableSize.SelectedValue = Ap.EngineOptions.HashTableSize.ToString();
        }

        private void SaveEngineOptions()
        {
            Ap.EngineOptions.UseTablebases = chkUseTablebases.Checked;
            Ap.EngineOptions.HashTableSize = Convert.ToInt32(cmbHashTableSize.SelectedValue);

            Ap.EngineOptions.Save();
        }

        private void AddKibitzer()
        {
            string engineName = lstEngines.SelectedValue.ToString();
            int hashTableSize = Convert.ToInt32(cmbHashTableSize.SelectedValue);
            UCIEngine uciEngine = new UCIEngine(engineName, hashTableSize, this.Game);
            uciEngine.IsKibitzer = true;
            uciEngine.NameReceived += new UCIEngine.NameReceivedHandler(uciEngine_NameReceived);
            uciEngine.Load();
        }

        void uciEngine_NameReceived(object sender, UCIMessageEventArgs e)
        {
            UCIEngine uciEngine = sender as UCIEngine;
            if (uciEngine != null)
            {
                InfinityChess.AnalysisUc analysisUc = new InfinityChess.AnalysisUc(true, this.Game,this.MainForm);
                analysisUc.Init();
                analysisUc.SetEngine(uciEngine);
                analysisUc.NewGame();
                analysisUc.KibitzerGuid = Guid.NewGuid().ToString();
                this.MainForm.KibitzerManager.KibitzersList.Add(analysisUc);
                this.MainForm.AddKibitzerPanel(analysisUc);
                this.MainForm.KibitzerManager.SendMoveToKibitzer(this.Game.CurrentMove);
            }
        }

        private void LoadNewEngine()
        {
            if (!IsNewEngineSelected)
            {
                return;
            }

            EngineManager objEngineManager = new EngineManager();
            objEngineManager.SaveDefaultEngine(lstEngines.SelectedValue.ToString());

            int hashTableSize = Convert.ToInt32(cmbHashTableSize.SelectedValue);
            InfinitySettings.Settings.DefaultEngineXml = objEngineManager.LoadDefaultEngine();
            string engineFile = InfinitySettings.Settings.DefaultEngineXml.FilePath;

            selectedEngine = new UCIEngine(engineFile, hashTableSize, this.Game);
            if (engineParameters != null)
            {
                engineParameters.SetEngineParameters(selectedEngine);
            }

            UCIEngine oldEngine = this.Game.DefaultEngine;
            if (oldEngine != null)
            {
                oldEngine.Close();
            }
            selectedEngine.UseTablebases = chkUseTablebases.Checked;
            selectedEngine.Load();
        }

        #endregion

        #region Events

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveEngineOptions();

            if (IsAddKibitzer == true)
            {
                if (lstEngines.Items.Count > 0)
                {
                    AddKibitzer();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {   
                LoadNewEngine();
                this.MainForm.RefreshGameInfo();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                cmbHashTableSize.SelectedValue = numericUpDown1.Value.ToString();
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
            }
        }

        private void cbHashtableSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbHashTableSize.SelectedValue != null)
                {
                    string s = cmbHashTableSize.SelectedValue.ToString();
                    int t;
                    if (Int32.TryParse(s, out t))
                    {
                        numericUpDown1.Value = t;
                    }
                }
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
            }
        }
        public override string HelpTopicId
        {
            get { return "110"; }
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            Ap.Help(this, HelpTopicIdE.LoadEngine);
        }

        private void btnEngineParameter_Click(object sender, EventArgs e)
        {
            EngineParametersPopup frm = null;

            if (IsNewEngineSelected)
            {
                LoadNewEngine();
            }

            frm = new EngineParametersPopup(selectedEngine, this.Game);

            frm.ShowDialog(this);
            engineParameters = frm.Parameters;
        }

        private void lstEngines_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEngines.SelectedValue != null)
            {
                engineParameters = null;
            }
        }

        #endregion
       
    }
}