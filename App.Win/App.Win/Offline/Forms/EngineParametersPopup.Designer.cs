namespace App.Win
{
    partial class EngineParametersPopup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnDefaults = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlParameters = new System.Windows.Forms.Panel();
            this.dgvParameters = new System.Windows.Forms.DataGridView();
            this.ParameterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParameterValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParameterType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParameterDefaultValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParameterValidValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlCommon = new System.Windows.Forms.Panel();
            this.sfdSaveParameters = new System.Windows.Forms.SaveFileDialog();
            this.ofdLoadParameters = new System.Windows.Forms.OpenFileDialog();
            this.pnlParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).BeginInit();
            this.pnlCommon.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(298, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 22);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(379, 8);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 22);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnDefaults
            // 
            this.btnDefaults.Location = new System.Drawing.Point(460, 9);
            this.btnDefaults.Name = "btnDefaults";
            this.btnDefaults.Size = new System.Drawing.Size(75, 22);
            this.btnDefaults.TabIndex = 2;
            this.btnDefaults.Text = "Defaults";
            this.btnDefaults.UseVisualStyleBackColor = true;
            this.btnDefaults.Click += new System.EventHandler(this.btnDefaults_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(136, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 22);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(217, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlParameters
            // 
            this.pnlParameters.Controls.Add(this.dgvParameters);
            this.pnlParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlParameters.Location = new System.Drawing.Point(0, 0);
            this.pnlParameters.Name = "pnlParameters";
            this.pnlParameters.Size = new System.Drawing.Size(547, 382);
            this.pnlParameters.TabIndex = 5;
            // 
            // dgvParameters
            // 
            this.dgvParameters.AllowDrop = true;
            this.dgvParameters.AllowUserToAddRows = false;
            this.dgvParameters.AllowUserToDeleteRows = false;
            this.dgvParameters.AllowUserToResizeRows = false;
            this.dgvParameters.CausesValidation = false;
            this.dgvParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvParameters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParameterName,
            this.ParameterValue,
            this.ParameterType,
            this.ParameterDefaultValue,
            this.ParameterValidValue});
            this.dgvParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvParameters.EnableHeadersVisualStyles = false;
            this.dgvParameters.Location = new System.Drawing.Point(0, 0);
            this.dgvParameters.MultiSelect = false;
            this.dgvParameters.Name = "dgvParameters";
            this.dgvParameters.RowHeadersVisible = false;
            this.dgvParameters.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvParameters.Size = new System.Drawing.Size(547, 382);
            this.dgvParameters.TabIndex = 0;
            this.dgvParameters.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvParameters_CellBeginEdit);
            this.dgvParameters.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParameters_CellEndEdit);
            // 
            // ParameterName
            // 
            this.ParameterName.DataPropertyName = "Name";
            this.ParameterName.HeaderText = "Name";
            this.ParameterName.Name = "ParameterName";
            this.ParameterName.ReadOnly = true;
            // 
            // ParameterValue
            // 
            this.ParameterValue.DataPropertyName = "Value";
            this.ParameterValue.HeaderText = "Value";
            this.ParameterValue.Name = "ParameterValue";
            // 
            // ParameterType
            // 
            this.ParameterType.DataPropertyName = "Type";
            this.ParameterType.HeaderText = "Type";
            this.ParameterType.Name = "ParameterType";
            this.ParameterType.ReadOnly = true;
            // 
            // ParameterDefaultValue
            // 
            this.ParameterDefaultValue.DataPropertyName = "Default";
            this.ParameterDefaultValue.HeaderText = "Default";
            this.ParameterDefaultValue.Name = "ParameterDefaultValue";
            this.ParameterDefaultValue.ReadOnly = true;
            // 
            // ParameterValidValue
            // 
            this.ParameterValidValue.DataPropertyName = "ValidValue";
            this.ParameterValidValue.HeaderText = "Valid Value";
            this.ParameterValidValue.Name = "ParameterValidValue";
            this.ParameterValidValue.ReadOnly = true;
            // 
            // pnlCommon
            // 
            this.pnlCommon.Controls.Add(this.btnDefaults);
            this.pnlCommon.Controls.Add(this.btnSave);
            this.pnlCommon.Controls.Add(this.btnCancel);
            this.pnlCommon.Controls.Add(this.btnLoad);
            this.pnlCommon.Controls.Add(this.btnOK);
            this.pnlCommon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCommon.Location = new System.Drawing.Point(0, 333);
            this.pnlCommon.Name = "pnlCommon";
            this.pnlCommon.Size = new System.Drawing.Size(547, 49);
            this.pnlCommon.TabIndex = 0;
            // 
            // ofdLoadParameters
            // 
            this.ofdLoadParameters.FileName = "openFileDialog1";
            // 
            // EngineParametersPopup
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(547, 382);
            this.Controls.Add(this.pnlCommon);
            this.Controls.Add(this.pnlParameters);
            this.MinimizeBox = false;
            this.Name = "EngineParametersPopup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Engine Parameters";
            this.Load += new System.EventHandler(this.EngineParametersPopup_Load);
            this.pnlParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).EndInit();
            this.pnlCommon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnDefaults;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlParameters;
        private System.Windows.Forms.Panel pnlCommon;
        private System.Windows.Forms.DataGridView dgvParameters;
        private System.Windows.Forms.SaveFileDialog sfdSaveParameters;
        private System.Windows.Forms.OpenFileDialog ofdLoadParameters;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterDefaultValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterValidValue;
    }
}