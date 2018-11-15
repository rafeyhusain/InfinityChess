using System; using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using InfinitySettings.UCIManager;


namespace App.Win
{
    public partial class SetupUCIEngine : BaseWinForm
    {
        #region DataMembers 

        public Game Game = null;                
        InfinitySettings.EngineManager.EngineManager _engineManager;
        OpenFileDialog ofdEngineFile;                
        InfinitySettings.UCIManager.EngineParameters engineParameters;

        string engineFileName;
        string sourceFilePath;

        #endregion

        #region Ctor 

        public SetupUCIEngine(Game game)
        {
            this.Game = game;
            InitializeComponent();
        }
        
        #endregion

        #region Properties 

        bool HasGame
        {
            get { return this.Game != null; }
        }

        #endregion

        #region Load

        private void SetupUCIEngine_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Helper Methods 

        private bool IsEngineAlreadyLoaded(string engineFileName)
        {
            if (!HasGame)
            {
                return false;
            }

            bool engineLoaded = false;
            engineFileName = engineFileName.Replace(".exe", "");
            if (this.Game.Player1 != null)
            {
                if (this.Game.Player1.Engine != null)
                {
                    if (this.Game.Player1.Engine.EngineName == engineFileName)
                    {
                        engineLoaded = true;
                    }
                }
            }
            if (this.Game.Player2 != null)
            {
                if (this.Game.Player2.Engine != null)
                {
                    if (this.Game.Player2.Engine.EngineName == engineFileName)
                    {
                        engineLoaded = true;
                    }
                }
            }
            return engineLoaded;
        }

        #endregion

        #region UciEngineValidator Events 

        void ev_NameReceived(object sender, UCIMessageEventArgs e)
        {
            if (txtName.InvokeRequired)
            {
                txtName.BeginInvoke(new MethodInvoker(delegate() { ev_NameReceived(sender, e); }));
            }
            else
            {
                txtName.Text = e.Message;
            }
        }

        void ev_AuthorReceived(object sender, UCIMessageEventArgs e)
        {
            if (txtAuthor.InvokeRequired)
            {
                txtAuthor.BeginInvoke(new MethodInvoker(delegate() { ev_AuthorReceived(sender, e); }));
            }
            else
            {
                txtAuthor.Text = e.Message;
            }
        }

        void ev_UciValidated(object sender, EventArgs e)
        {
            btnBrowse.Enabled = true;
            btnOK.Enabled = true;
            btnParameters.Enabled = true;
        }

        void ev_UciInvalidated(object sender, EventArgs e)
        {
            btnBrowse.Enabled = true;
            MessageForm.Error(this, MsgE.ErrorInvalidUciEngine);
        }

        #endregion

        #region Buttons Events 
        ProgressForm frmProgress;

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ofdEngineFile = new OpenFileDialog();
            ofdEngineFile.Filter = "UCI Engines exe(*.exe)|*.exe";
            ofdEngineFile.FileName = "*.exe";
            //ofdEngineFile.InitialDirectory = Ap.FolderEngines;

            if (ofdEngineFile.ShowDialog() == DialogResult.OK)
            {
                frmProgress = ProgressForm.Show(this, "Verifying UCI Engine...", 4000);
                frmProgress.FormClosed += new FormClosedEventHandler(frmProgress_FormClosed);

                btnBrowse.Enabled = false;
                btnOK.Enabled = false;
                btnParameters.Enabled = false;
                txtAuthor.Text = "";
                txtName.Text = "";
                txtEngine.Text = ofdEngineFile.SafeFileName;

                sourceFilePath = ofdEngineFile.FileName;
                engineFileName = sourceFilePath.Substring(sourceFilePath.LastIndexOf("\\") + 1);

                ValidateEngine();
            }
        }

        private void ValidateEngine()
        {
            try
            {
                if (!IsEngineAlreadyLoaded(engineFileName))
                {
                    UCIEngineValidator ev = new UCIEngineValidator(sourceFilePath, this.Game);
                    ev.NameReceived += new UCIEngine.NameReceivedHandler(ev_NameReceived);
                    ev.AuthorReceived += new UCIEngine.AuthorReceivedHandler(ev_AuthorReceived);
                    ev.UciValidated += new EventHandler(ev_UciValidated);
                    ev.UciInvalidated += new EventHandler(ev_UciInvalidated);

                    ev.Validate();
                }
                else
                {
                    frmProgress.Close();
                    btnBrowse.Enabled = true;
                    MessageForm.Error(this, MsgE.ErrorUciEngine);
                }
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                frmProgress.Close();
                btnBrowse.Enabled = true;
                MessageForm.Error(this, MsgE.ErrorInvalidUciEngine);
            }
        }

        void frmProgress_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmProgress = null;
        }

        private void btnParameters_Click(object sender, EventArgs e)
        {
            EngineParametersPopup frm = new EngineParametersPopup(sourceFilePath, this.Game);            
            frm.ShowDialog(this);
            engineParameters = frm.Parameters;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _engineManager = new InfinitySettings.EngineManager.EngineManager();
            _engineManager.EngineObject.EngineTitle = txtEngine.Text;
            _engineManager.EngineObject.Name = txtName.Text;
            _engineManager.EngineObject.Author = txtAuthor.Text;
            _engineManager.EngineObject.IsBelowNormal = false;
            _engineManager.EngineObject.IsActive = true;
            _engineManager.EngineObject.FilePath = sourceFilePath;

            if (_engineManager.AddEngineNode() == true)
            {
                string targetFilePath = Ap.FolderEngines + engineFileName;
                if (sourceFilePath != targetFilePath && !UFile.Exists(targetFilePath))
                {
                    UFile.Copy(sourceFilePath, targetFilePath);
                }

                MessageForm.Show(this,MsgE.InfoEngineLoaded);
                this.Close();
            }
            else
            {
                MessageForm.Show(this,MsgE.InfoEngineExsist);
            }            
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Ap.Help(this, HelpTopicIdE.SetupUCIEngine);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region  Overrides 

        public override string HelpTopicId
        {
            get { return "130"; }
        }
        
        #endregion

    }
}