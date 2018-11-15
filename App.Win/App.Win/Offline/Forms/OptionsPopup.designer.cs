namespace App.Win
{
    partial class OptionsPopup
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabClocks_Notation = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.rdbClocks_N_1d4 = new System.Windows.Forms.RadioButton();
            this.rdbClocks_N_1d2_d4 = new System.Windows.Forms.RadioButton();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.rdbClocks_C_DoubleDigital = new System.Windows.Forms.RadioButton();
            this.rdbClocks_C_Analog = new System.Windows.Forms.RadioButton();
            this.rdbClocks_C_Digital = new System.Windows.Forms.RadioButton();
            this.tabDesign = new System.Windows.Forms.TabPage();
            this.chkShowVerticalGrid = new System.Windows.Forms.CheckBox();
            this.chkShowHorizontalGrid = new System.Windows.Forms.CheckBox();
            this.btnDesign_BoardDesign = new System.Windows.Forms.Button();
            this.tabMultimedia = new System.Windows.Forms.TabPage();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.chkMM_Audio_BoardSounds = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.sfdVersion_PGNPath = new System.Windows.Forms.SaveFileDialog();
            this.ofdTraining = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabClocks_Notation.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tabDesign.SuspendLayout();
            this.tabMultimedia.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabClocks_Notation);
            this.tabControl1.Controls.Add(this.tabDesign);
            this.tabControl1.Controls.Add(this.tabMultimedia);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(383, 368);
            this.tabControl1.TabIndex = 0;
            // 
            // tabClocks_Notation
            // 
            this.tabClocks_Notation.Controls.Add(this.groupBox10);
            this.tabClocks_Notation.Controls.Add(this.groupBox9);
            this.tabClocks_Notation.Location = new System.Drawing.Point(4, 22);
            this.tabClocks_Notation.Name = "tabClocks_Notation";
            this.tabClocks_Notation.Size = new System.Drawing.Size(375, 342);
            this.tabClocks_Notation.TabIndex = 5;
            this.tabClocks_Notation.Text = "Clocks+Notation";
            this.tabClocks_Notation.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.rdbClocks_N_1d4);
            this.groupBox10.Controls.Add(this.rdbClocks_N_1d2_d4);
            this.groupBox10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox10.Location = new System.Drawing.Point(148, 28);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(204, 98);
            this.groupBox10.TabIndex = 6;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Notation";
            // 
            // rdbClocks_N_1d4
            // 
            this.rdbClocks_N_1d4.AutoSize = true;
            this.rdbClocks_N_1d4.Location = new System.Drawing.Point(16, 19);
            this.rdbClocks_N_1d4.Name = "rdbClocks_N_1d4";
            this.rdbClocks_N_1d4.Size = new System.Drawing.Size(46, 17);
            this.rdbClocks_N_1d4.TabIndex = 7;
            this.rdbClocks_N_1d4.TabStop = true;
            this.rdbClocks_N_1d4.Text = "1.d4";
            this.rdbClocks_N_1d4.UseVisualStyleBackColor = true;
            // 
            // rdbClocks_N_1d2_d4
            // 
            this.rdbClocks_N_1d2_d4.AutoSize = true;
            this.rdbClocks_N_1d2_d4.Location = new System.Drawing.Point(16, 41);
            this.rdbClocks_N_1d2_d4.Name = "rdbClocks_N_1d2_d4";
            this.rdbClocks_N_1d2_d4.Size = new System.Drawing.Size(61, 17);
            this.rdbClocks_N_1d2_d4.TabIndex = 9;
            this.rdbClocks_N_1d2_d4.TabStop = true;
            this.rdbClocks_N_1d2_d4.Text = "1.d2-d4";
            this.rdbClocks_N_1d2_d4.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.rdbClocks_C_DoubleDigital);
            this.groupBox9.Controls.Add(this.rdbClocks_C_Analog);
            this.groupBox9.Controls.Add(this.rdbClocks_C_Digital);
            this.groupBox9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox9.Location = new System.Drawing.Point(18, 28);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(124, 98);
            this.groupBox9.TabIndex = 5;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Clocks";
            // 
            // rdbClocks_C_DoubleDigital
            // 
            this.rdbClocks_C_DoubleDigital.AutoSize = true;
            this.rdbClocks_C_DoubleDigital.Location = new System.Drawing.Point(17, 70);
            this.rdbClocks_C_DoubleDigital.Name = "rdbClocks_C_DoubleDigital";
            this.rdbClocks_C_DoubleDigital.Size = new System.Drawing.Size(89, 17);
            this.rdbClocks_C_DoubleDigital.TabIndex = 8;
            this.rdbClocks_C_DoubleDigital.TabStop = true;
            this.rdbClocks_C_DoubleDigital.Text = "Double digital";
            this.rdbClocks_C_DoubleDigital.UseVisualStyleBackColor = true;
            // 
            // rdbClocks_C_Analog
            // 
            this.rdbClocks_C_Analog.AutoSize = true;
            this.rdbClocks_C_Analog.Location = new System.Drawing.Point(17, 47);
            this.rdbClocks_C_Analog.Name = "rdbClocks_C_Analog";
            this.rdbClocks_C_Analog.Size = new System.Drawing.Size(58, 17);
            this.rdbClocks_C_Analog.TabIndex = 7;
            this.rdbClocks_C_Analog.TabStop = true;
            this.rdbClocks_C_Analog.Text = "Analog";
            this.rdbClocks_C_Analog.UseVisualStyleBackColor = true;
            // 
            // rdbClocks_C_Digital
            // 
            this.rdbClocks_C_Digital.AutoSize = true;
            this.rdbClocks_C_Digital.Location = new System.Drawing.Point(17, 24);
            this.rdbClocks_C_Digital.Name = "rdbClocks_C_Digital";
            this.rdbClocks_C_Digital.Size = new System.Drawing.Size(54, 17);
            this.rdbClocks_C_Digital.TabIndex = 6;
            this.rdbClocks_C_Digital.TabStop = true;
            this.rdbClocks_C_Digital.Text = "Digital";
            this.rdbClocks_C_Digital.UseVisualStyleBackColor = true;
            // 
            // tabDesign
            // 
            this.tabDesign.Controls.Add(this.chkShowVerticalGrid);
            this.tabDesign.Controls.Add(this.chkShowHorizontalGrid);
            this.tabDesign.Controls.Add(this.btnDesign_BoardDesign);
            this.tabDesign.Location = new System.Drawing.Point(4, 22);
            this.tabDesign.Name = "tabDesign";
            this.tabDesign.Padding = new System.Windows.Forms.Padding(3);
            this.tabDesign.Size = new System.Drawing.Size(375, 342);
            this.tabDesign.TabIndex = 0;
            this.tabDesign.Text = "Design";
            this.tabDesign.UseVisualStyleBackColor = true;
            // 
            // chkShowVerticalGrid
            // 
            this.chkShowVerticalGrid.AutoSize = true;
            this.chkShowVerticalGrid.Location = new System.Drawing.Point(25, 94);
            this.chkShowVerticalGrid.Name = "chkShowVerticalGrid";
            this.chkShowVerticalGrid.Size = new System.Drawing.Size(113, 17);
            this.chkShowVerticalGrid.TabIndex = 6;
            this.chkShowVerticalGrid.Text = "Show Vertical Grid";
            this.chkShowVerticalGrid.UseVisualStyleBackColor = true;
            // 
            // chkShowHorizontalGrid
            // 
            this.chkShowHorizontalGrid.AutoSize = true;
            this.chkShowHorizontalGrid.Location = new System.Drawing.Point(25, 73);
            this.chkShowHorizontalGrid.Name = "chkShowHorizontalGrid";
            this.chkShowHorizontalGrid.Size = new System.Drawing.Size(125, 17);
            this.chkShowHorizontalGrid.TabIndex = 5;
            this.chkShowHorizontalGrid.Text = "Show Horizontal Grid";
            this.chkShowHorizontalGrid.UseVisualStyleBackColor = true;
            // 
            // btnDesign_BoardDesign
            // 
            this.btnDesign_BoardDesign.Location = new System.Drawing.Point(25, 28);
            this.btnDesign_BoardDesign.Name = "btnDesign_BoardDesign";
            this.btnDesign_BoardDesign.Size = new System.Drawing.Size(75, 22);
            this.btnDesign_BoardDesign.TabIndex = 2;
            this.btnDesign_BoardDesign.Text = "Board Design";
            this.btnDesign_BoardDesign.UseVisualStyleBackColor = true;
            this.btnDesign_BoardDesign.Click += new System.EventHandler(this.btnDesign_BoardDesign_Click);
            // 
            // tabMultimedia
            // 
            this.tabMultimedia.Controls.Add(this.groupBox17);
            this.tabMultimedia.Location = new System.Drawing.Point(4, 22);
            this.tabMultimedia.Name = "tabMultimedia";
            this.tabMultimedia.Size = new System.Drawing.Size(375, 342);
            this.tabMultimedia.TabIndex = 7;
            this.tabMultimedia.Text = "Multimedia";
            this.tabMultimedia.UseVisualStyleBackColor = true;
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.chkMM_Audio_BoardSounds);
            this.groupBox17.Location = new System.Drawing.Point(14, 14);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(337, 76);
            this.groupBox17.TabIndex = 0;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Audio";
            // 
            // chkMM_Audio_BoardSounds
            // 
            this.chkMM_Audio_BoardSounds.AutoSize = true;
            this.chkMM_Audio_BoardSounds.Location = new System.Drawing.Point(23, 31);
            this.chkMM_Audio_BoardSounds.Name = "chkMM_Audio_BoardSounds";
            this.chkMM_Audio_BoardSounds.Size = new System.Drawing.Size(91, 17);
            this.chkMM_Audio_BoardSounds.TabIndex = 3;
            this.chkMM_Audio_BoardSounds.Text = "Board sounds";
            this.chkMM_Audio_BoardSounds.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(73, 391);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 22);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(154, 391);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(235, 391);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 22);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(316, 391);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 22);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // sfdVersion_PGNPath
            // 
            this.sfdVersion_PGNPath.DefaultExt = "pgn";
            this.sfdVersion_PGNPath.FileName = "Publish";
            this.sfdVersion_PGNPath.InitialDirectory = "C:\\Documents and Settings\\User\\My Documents\\InfinityChess\\NoGames\\Textfile";
            // 
            // ofdTraining
            // 
            this.ofdTraining.FileName = "*.cbh;*.cbv;*.cbz;*.pgn";
            this.ofdTraining.InitialDirectory = "C:\\Documents and Settings\\User\\My Documents\\InfinityChess\\Bases";
            // 
            // OptionsPopup
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(407, 425);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsPopup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsPopup_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabClocks_Notation.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.tabDesign.ResumeLayout(false);
            this.tabDesign.PerformLayout();
            this.tabMultimedia.ResumeLayout(false);
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDesign;
        private System.Windows.Forms.TabPage tabClocks_Notation;
        private System.Windows.Forms.TabPage tabMultimedia;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnDesign_BoardDesign;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.RadioButton rdbClocks_C_Digital;
        private System.Windows.Forms.RadioButton rdbClocks_C_DoubleDigital;
        private System.Windows.Forms.RadioButton rdbClocks_C_Analog;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.RadioButton rdbClocks_N_1d2_d4;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.CheckBox chkMM_Audio_BoardSounds;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.SaveFileDialog sfdVersion_PGNPath;
        private System.Windows.Forms.OpenFileDialog ofdTraining;
        public System.Windows.Forms.RadioButton rdbClocks_N_1d4;
        private System.Windows.Forms.CheckBox chkShowVerticalGrid;
        private System.Windows.Forms.CheckBox chkShowHorizontalGrid;
    }
}