namespace App.Win
{
    partial class LoadEngine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadEngine));
            this.lstEngines = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEngineParameter = new System.Windows.Forms.Button();
            this.chkUseTablebases = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbHashTableSize = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstEngines
            // 
            this.lstEngines.FormattingEnabled = true;
            this.lstEngines.Location = new System.Drawing.Point(182, 11);
            this.lstEngines.Name = "lstEngines";
            this.lstEngines.Size = new System.Drawing.Size(192, 212);
            this.lstEngines.TabIndex = 0;
            this.lstEngines.TabStop = false;
            this.lstEngines.SelectedIndexChanged += new System.EventHandler(this.lstEngines_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(164, 208);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnEngineParameter
            // 
            this.btnEngineParameter.Location = new System.Drawing.Point(270, 228);
            this.btnEngineParameter.Name = "btnEngineParameter";
            this.btnEngineParameter.Size = new System.Drawing.Size(105, 22);
            this.btnEngineParameter.TabIndex = 1;
            this.btnEngineParameter.Text = "Engine Parameters";
            this.btnEngineParameter.UseVisualStyleBackColor = true;
            this.btnEngineParameter.Click += new System.EventHandler(this.btnEngineParameter_Click);
            // 
            // chkUseTablebases
            // 
            this.chkUseTablebases.AutoSize = true;
            this.chkUseTablebases.Location = new System.Drawing.Point(12, 257);
            this.chkUseTablebases.Name = "chkUseTablebases";
            this.chkUseTablebases.Size = new System.Drawing.Size(103, 17);
            this.chkUseTablebases.TabIndex = 2;
            this.chkUseTablebases.Text = "Use Tablebases";
            this.chkUseTablebases.UseVisualStyleBackColor = true;
            this.chkUseTablebases.Visible = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Location = new System.Drawing.Point(14, 25);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1582,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(18, 20);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "MB    Maximum 1595MB";
            // 
            // cmbHashTableSize
            // 
            this.cmbHashTableSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHashTableSize.FormattingEnabled = true;
            this.cmbHashTableSize.Location = new System.Drawing.Point(32, 25);
            this.cmbHashTableSize.Name = "cmbHashTableSize";
            this.cmbHashTableSize.Size = new System.Drawing.Size(65, 21);
            this.cmbHashTableSize.TabIndex = 0;
            this.cmbHashTableSize.Tag = "";
            this.cmbHashTableSize.SelectedIndexChanged += new System.EventHandler(this.cbHashtableSize_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(139, 358);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 22);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(220, 358);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 22);
            this.btnHelp.TabIndex = 5;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(301, 358);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.cmbHashTableSize);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 284);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 58);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hashtable Size";
            // 
            // LoadEngine
            // 
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(388, 393);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkUseTablebases);
            this.Controls.Add(this.btnEngineParameter);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lstEngines);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoadEngine";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Load Engine";
            this.Load += new System.EventHandler(this.LoadEngine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstEngines;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnEngineParameter;
        private System.Windows.Forms.CheckBox chkUseTablebases;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbHashTableSize;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}