using System; using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace App.Win
{
    public partial class ImportGameEditor : BaseWinForm
    {
        #region DataMembers 
        public Game Game = null;        
        Database database;
        string databaseFileName;
        int fromGameNo;
        int toGameNo;
        int length;
        bool includeVariations;

        #endregion

        #region Ctor 
                
        public ImportGameEditor(string databaseFileName,Game game)
        {
            this.Game = game;
            InitializeComponent();
            this.databaseFileName = databaseFileName;
        }

        #endregion
        
        #region Properties

        public Database Database
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return database; }
        }

        public int FromGameNo
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return fromGameNo; }
        }

        public int ToGameNo
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return toGameNo; }
        }

        public int Length
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return length; }
        }

        public bool IncludeVariations
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return includeVariations; }
        }

        #endregion

        #region Load 

        private void frmSource_Load(object sender, EventArgs e)
        {
            LoadImportGameData();
        }
        
        #endregion

        #region Helpers 

        private void LoadImportGameData()
        {
            if (!databaseFileName.EndsWith(Files.DatabaseExtension))
            {
                MessageForm.Error(this, MsgE.ErrorInvalidFileFormat);
                this.Close();
                return;
            }
            try
            {
                ProgressForm frmProgress = ProgressForm.Show(this, "Loading Database...");

                database = new Database(databaseFileName, this.Game);

                frmProgress.Close();

                if (database.GamesCount > 0)
                {
                    numFromGameNo.Value = 1;
                    numToGameNo.Value = database.GamesCount;

                    numFromGameNo.Maximum = database.GamesCount;
                    numToGameNo.Maximum = database.GamesCount;
                }
                else
                {
                    numFromGameNo.Maximum = 0;
                    numToGameNo.Maximum = 0;

                    numFromGameNo.Value = 0;
                    numToGameNo.Value = 0;
                }

                fromGameNo = (int)numFromGameNo.Value;
                toGameNo = (int)numToGameNo.Value;
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Error(this, MsgE.ErrorInvalidFileFormat,ex);
                this.Close();
            }
        }

        #endregion

        #region Events 

        private void btnOK_Click(object sender, EventArgs e)
        {
            fromGameNo = (int)numFromGameNo.Value;
            toGameNo = (int)numToGameNo.Value;
            length = (int)numLength.Value;
            includeVariations = chkIncludeVariations.Checked;

            // if second parameter is defined larger than first parameter, then swap their values
            if (fromGameNo > toGameNo)
            {
                int tempGameNo = toGameNo;
                toGameNo = fromGameNo;
                fromGameNo = tempGameNo;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Ap.Help(this, HelpTopicIdE.ImportGameEditor);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void numFromGameNo_ValueChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region Overrides 

        public override string HelpTopicId
        {
            get { return "100"; }
        }

        #endregion
                
    }
}