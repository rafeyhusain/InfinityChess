namespace InfinityChess.GameData
{
    partial class frmTeamSettings
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblTeamNumber = new System.Windows.Forms.Label();
            this.numTeamNumber = new System.Windows.Forms.NumericUpDown();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.lblYear = new System.Windows.Forms.Label();
            this.chkSeason = new System.Windows.Forms.CheckBox();
            this.chkNotation = new System.Windows.Forms.CheckBox();
            this.cmbNotation = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numTeamNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(17, 24);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(105, 17);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(160, 20);
            this.txtName.TabIndex = 0;
            // 
            // lblTeamNumber
            // 
            this.lblTeamNumber.AutoSize = true;
            this.lblTeamNumber.Location = new System.Drawing.Point(17, 50);
            this.lblTeamNumber.Name = "lblTeamNumber";
            this.lblTeamNumber.Size = new System.Drawing.Size(74, 13);
            this.lblTeamNumber.TabIndex = 2;
            this.lblTeamNumber.Text = "Team Number";
            // 
            // numTeamNumber
            // 
            this.numTeamNumber.Location = new System.Drawing.Point(105, 43);
            this.numTeamNumber.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numTeamNumber.Name = "numTeamNumber";
            this.numTeamNumber.Size = new System.Drawing.Size(79, 20);
            this.numTeamNumber.TabIndex = 1;
            // 
            // numYear
            // 
            this.numYear.Location = new System.Drawing.Point(105, 70);
            this.numYear.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(79, 20);
            this.numYear.TabIndex = 2;
            this.numYear.Value = new decimal(new int[] {
            1700,
            0,
            0,
            0});
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(17, 77);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(29, 13);
            this.lblYear.TabIndex = 4;
            this.lblYear.Text = "Year";
            // 
            // chkSeason
            // 
            this.chkSeason.AutoSize = true;
            this.chkSeason.Location = new System.Drawing.Point(203, 73);
            this.chkSeason.Name = "chkSeason";
            this.chkSeason.Size = new System.Drawing.Size(62, 17);
            this.chkSeason.TabIndex = 3;
            this.chkSeason.Text = "Season";
            this.chkSeason.UseVisualStyleBackColor = true;
            // 
            // chkNotation
            // 
            this.chkNotation.AutoSize = true;
            this.chkNotation.Location = new System.Drawing.Point(20, 100);
            this.chkNotation.Name = "chkNotation";
            this.chkNotation.Size = new System.Drawing.Size(66, 17);
            this.chkNotation.TabIndex = 7;
            this.chkNotation.Text = "Notation";
            this.chkNotation.UseVisualStyleBackColor = true;
            // 
            // cmbNotation
            // 
            this.cmbNotation.FormattingEnabled = true;
            this.cmbNotation.Location = new System.Drawing.Point(105, 96);
            this.cmbNotation.Name = "cmbNotation";
            this.cmbNotation.Size = new System.Drawing.Size(79, 21);
            this.cmbNotation.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(122, 147);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(203, 147);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmTeamSettings
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(291, 181);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbNotation);
            this.Controls.Add(this.chkNotation);
            this.Controls.Add(this.chkSeason);
            this.Controls.Add(this.numYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.numTeamNumber);
            this.Controls.Add(this.lblTeamNumber);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTeamSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Team Settings";
            this.Load += new System.EventHandler(this.frmTeamSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numTeamNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblTeamNumber;
        private System.Windows.Forms.NumericUpDown numTeamNumber;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.CheckBox chkSeason;
        private System.Windows.Forms.CheckBox chkNotation;
        private System.Windows.Forms.ComboBox cmbNotation;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}