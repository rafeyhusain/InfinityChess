using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InfinitySettings.UCIManager;
using InfinitySettings.EngineManager;
using System.IO;
using App.Model;
using App.Win;

namespace App.Win
{
    public partial class EngineParametersPopup : BaseWinForm
    {
        #region Delegates/Events 

        delegate void delSetDataSource(DataTable dt);

        #endregion

        #region DataMembers
        
        public Game Game = null;
        public UCIEngine UciEngine = null;
        InfinitySettings.UCIManager.EngineParameters parameters;
        Dictionary<string, string> updatedParameters = new Dictionary<string, string>();

        string engineFilePath;
        string currentCellValue = null;

        int currentRow = -1;
        int currentCol = -1;

        #endregion

        #region Ctor 

        public EngineParametersPopup(string engineFile,Game game)
        {
            InitializeComponent();
            this.Game = game;
            this.engineFilePath = engineFile;
        }

        public EngineParametersPopup(UCIEngine engine, Game game)
        {
            InitializeComponent();
            this.Game = game;
            this.UciEngine = engine;
            if (UciEngine != null)
            {
                this.engineFilePath = UciEngine.EngineFile;
            }
        }

        #endregion

        #region Properties 

        bool HasGame
        {
            get { return this.Game != null; }
        }

        public InfinitySettings.UCIManager.EngineParameters Parameters
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            { return parameters; }
        }

        private bool IsEngineLoaded
        {
            get
            {
                return UciEngine != null;
            }
        }

        #endregion

        #region Events

        private void EngineParametersPopup_Load(object sender, EventArgs e)
        {
            LoadParams();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateParameters();
            SaveParameters();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadParameters();
        }

        private void btnDefaults_Click(object sender, EventArgs e)
        {
            parameters.LoadDefault();            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            UpdateParameters();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void uciEngine_UciOkReceived(object sender, EventArgs e)
        {
            LoadParams();
        }

        private void dgvParameters_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            currentRow = e.RowIndex;
            currentCol = e.ColumnIndex;

            UpdateCurrentItem();          
            ResetCurrentItem();
        }

        private void UpdateCurrentItem()
        {
            if (currentRow == -1 || currentCol == -1)
            {
                return;
            }

            DataGridViewRow dgvRow = dgvParameters.Rows[currentRow];
            if (dgvRow.Cells[0].Value == null)
            {
                return;
            }

            string parameterName;
            string parameterValue;
            parameterName = dgvRow.Cells[0].Value.ToString();
            parameterValue = dgvRow.Cells[currentCol].EditedFormattedValue.ToString();
            bool isUpdated = UpdateValue(parameterName, parameterValue);
            if (!isUpdated)
            {
                //string value = parameters.GetValue(parameterName);
                dgvRow.Cells[currentCol].Value = currentCellValue;
            }
            return;
        }

        private void ResetCurrentItem()
        {
            currentRow = -1;
            currentCol = -1;
            currentCellValue = null;
        }

        private void dgvParameters_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            currentRow = e.RowIndex;
            currentCol = e.ColumnIndex;

            DataGridViewRow dgvRow = dgvParameters.Rows[currentRow];
            if (dgvRow.Cells[0].Value == null)
            {
                return;
            }
            currentCellValue = dgvRow.Cells[currentCol].Value.ToString();
        }

        void parameters_ParameterError(object sender, string error)
        {
            MessageForm.Show(error);
        }

        void parameters_ParametersLoaded(object sender, EventArgs e)
        {
            try
            {
                //frmProgressForm.Close();
                CloseForm(frmProgressForm);
                SetDataSource(parameters.EngineParameterData);
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                string s = ex.Message;
            }

        }

        #endregion

        #region Helper Methods 
        
        ProgressForm frmProgressForm;      

        private void LoadParams()
        {
            parameters = new InfinitySettings.UCIManager.EngineParameters(this.Game);
            parameters.ParametersLoaded += new EventHandler(parameters_ParametersLoaded);
            parameters.ParameterError += new InfinitySettings.UCIManager.EngineParameters.ParameterErrorHandler(parameters_ParameterError);
            string engineName = Path.GetFileNameWithoutExtension(engineFilePath);

            dgvParameters.Visible = false;
            frmProgressForm = ProgressForm.Show(this, "Loading...", 1);
            if (UciEngine == null)
            {
                parameters.Init(engineFilePath);
            }
            else
            {
                parameters.Init(UciEngine);
            }
        }      

        private void SetDataSource(DataTable dt)
        {
            if (dgvParameters.InvokeRequired)
            {
                delSetDataSource del = new delSetDataSource(SetDataSource);
                this.Invoke(del, new object[] { dt });
            }
            else
            {
                dgvParameters.DataSource = dt;
                dgvParameters.Refresh();
                dgvParameters.Visible = true;
            }
        }

        private bool UpdateValue(string parameterName, string parameterValue)
        {
            bool isValidValue = parameters.IsValidValue(parameterName, parameterValue);
            if (isValidValue)
            {
                if (updatedParameters.ContainsKey(parameterName))
                {
                    updatedParameters[parameterName] = parameterValue;
                }
                else
                {
                    updatedParameters.Add(parameterName, parameterValue);
                }
            }
            return isValidValue;
        }

        private void SaveParameters()
        {
            sfdSaveParameters.Filter = "Parameters param(*" + Files.ParametersExtension + ")|*" + Files.ParametersExtension;
            sfdSaveParameters.FileName = "*" + Files.ParametersExtension;
            sfdSaveParameters.InitialDirectory = Ap.FolderEngineParameter;

            if (sfdSaveParameters.ShowDialog() == DialogResult.OK)
            {
                string filePath = sfdSaveParameters.FileName;
                parameters.Save(filePath);
            }
        }

        private void LoadParameters()
        {
            ofdLoadParameters.Filter = "Parameters param(*" + Files.ParametersExtension + ")|*" + Files.ParametersExtension;
            ofdLoadParameters.FileName = "*" + Files.ParametersExtension;
            ofdLoadParameters.InitialDirectory = Ap.FolderEngineParameter;

            if (ofdLoadParameters.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofdLoadParameters.FileName;
                parameters.Load(filePath);
            }
        }

        private void UpdateParameters()
        {
            UpdateCurrentItem();

            foreach (KeyValuePair<string,string> param in updatedParameters)
            {
                parameters.SetValue(param.Key, param.Value);
            }
            SetEngineParametersIfLoaded();
        }

        private void SetEngineParametersIfLoaded()
        {
            if (IsEngineLoaded)
            {   
                UciEngine.LoadParameters(parameters);
            }
        }

        #region Thread-safe Methods

        private void CloseForm(Form frm)
        {
            if (frm.InvokeRequired)
            {
                frm.BeginInvoke(new MethodInvoker(delegate() { CloseForm(frm); }));
            }
            else
            {
                frm.Close();
            }
        }

        #endregion

        #endregion         
    }
}
