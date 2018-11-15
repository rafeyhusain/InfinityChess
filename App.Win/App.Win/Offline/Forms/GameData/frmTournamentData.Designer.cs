namespace InfinityChess.GameData
{
    partial class frmTournamentData
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtPlace = new System.Windows.Forms.TextBox();
            this.lblPlace = new System.Windows.Forms.Label();
            this.numDay = new System.Windows.Forms.NumericUpDown();
            this.numMonth = new System.Windows.Forms.NumericUpDown();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.chkDay = new System.Windows.Forms.CheckBox();
            this.chkMonth = new System.Windows.Forms.CheckBox();
            this.chkYear = new System.Windows.Forms.CheckBox();
            this.numCategory = new System.Windows.Forms.NumericUpDown();
            this.numRounds = new System.Windows.Forms.NumericUpDown();
            this.chkBoardPoints = new System.Windows.Forms.CheckBox();
            this.chkType = new System.Windows.Forms.CheckBox();
            this.chkCategory = new System.Windows.Forms.CheckBox();
            this.chkRounds = new System.Windows.Forms.CheckBox();
            this.chkNotation = new System.Windows.Forms.CheckBox();
            this.chkComplete = new System.Windows.Forms.CheckBox();
            this.cmbNotation = new System.Windows.Forms.ComboBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbCorrespChe = new System.Windows.Forms.RadioButton();
            this.rdbNormal = new System.Windows.Forms.RadioButton();
            this.rdbRapid = new System.Windows.Forms.RadioButton();
            this.rdbBlitz = new System.Windows.Forms.RadioButton();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRounds)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(24, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(73, 13);
            this.txtTitle.MaxLength = 40;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(319, 20);
            this.txtTitle.TabIndex = 0;
            // 
            // txtPlace
            // 
            this.txtPlace.Location = new System.Drawing.Point(73, 39);
            this.txtPlace.MaxLength = 30;
            this.txtPlace.Name = "txtPlace";
            this.txtPlace.Size = new System.Drawing.Size(319, 20);
            this.txtPlace.TabIndex = 1;
            // 
            // lblPlace
            // 
            this.lblPlace.AutoSize = true;
            this.lblPlace.Location = new System.Drawing.Point(24, 46);
            this.lblPlace.Name = "lblPlace";
            this.lblPlace.Size = new System.Drawing.Size(34, 13);
            this.lblPlace.TabIndex = 2;
            this.lblPlace.Text = "Place";
            // 
            // numDay
            // 
            this.numDay.Location = new System.Drawing.Point(88, 120);
            this.numDay.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.numDay.Name = "numDay";
            this.numDay.Size = new System.Drawing.Size(51, 20);
            this.numDay.TabIndex = 11;
            this.numDay.Value = new decimal(new int[] {
            31,
            0,
            0,
            0});
            // 
            // numMonth
            // 
            this.numMonth.Location = new System.Drawing.Point(88, 97);
            this.numMonth.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numMonth.Name = "numMonth";
            this.numMonth.Size = new System.Drawing.Size(51, 20);
            this.numMonth.TabIndex = 7;
            this.numMonth.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // numYear
            // 
            this.numYear.Location = new System.Drawing.Point(88, 74);
            this.numYear.Maximum = new decimal(new int[] {
            2400,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(51, 20);
            this.numYear.TabIndex = 3;
            this.numYear.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // chkDay
            // 
            this.chkDay.AutoSize = true;
            this.chkDay.Location = new System.Drawing.Point(27, 123);
            this.chkDay.Name = "chkDay";
            this.chkDay.Size = new System.Drawing.Size(45, 17);
            this.chkDay.TabIndex = 10;
            this.chkDay.Text = "Day";
            this.chkDay.UseVisualStyleBackColor = true;
            // 
            // chkMonth
            // 
            this.chkMonth.AutoSize = true;
            this.chkMonth.Location = new System.Drawing.Point(27, 100);
            this.chkMonth.Name = "chkMonth";
            this.chkMonth.Size = new System.Drawing.Size(56, 17);
            this.chkMonth.TabIndex = 6;
            this.chkMonth.Text = "Month";
            this.chkMonth.UseVisualStyleBackColor = true;
            // 
            // chkYear
            // 
            this.chkYear.AutoSize = true;
            this.chkYear.Location = new System.Drawing.Point(27, 77);
            this.chkYear.Name = "chkYear";
            this.chkYear.Size = new System.Drawing.Size(48, 17);
            this.chkYear.TabIndex = 2;
            this.chkYear.Text = "Year";
            this.chkYear.UseVisualStyleBackColor = true;
            // 
            // numCategory
            // 
            this.numCategory.Location = new System.Drawing.Point(321, 123);
            this.numCategory.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numCategory.Name = "numCategory";
            this.numCategory.Size = new System.Drawing.Size(71, 20);
            this.numCategory.TabIndex = 13;
            this.numCategory.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // numRounds
            // 
            this.numRounds.Location = new System.Drawing.Point(321, 97);
            this.numRounds.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numRounds.Name = "numRounds";
            this.numRounds.Size = new System.Drawing.Size(71, 20);
            this.numRounds.TabIndex = 9;
            this.numRounds.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // chkBoardPoints
            // 
            this.chkBoardPoints.AutoSize = true;
            this.chkBoardPoints.Location = new System.Drawing.Point(200, 174);
            this.chkBoardPoints.Name = "chkBoardPoints";
            this.chkBoardPoints.Size = new System.Drawing.Size(86, 17);
            this.chkBoardPoints.TabIndex = 17;
            this.chkBoardPoints.Text = "Board Points";
            this.chkBoardPoints.UseVisualStyleBackColor = true;
            // 
            // chkType
            // 
            this.chkType.AutoSize = true;
            this.chkType.Location = new System.Drawing.Point(200, 151);
            this.chkType.Name = "chkType";
            this.chkType.Size = new System.Drawing.Size(50, 17);
            this.chkType.TabIndex = 14;
            this.chkType.Text = "Type";
            this.chkType.UseVisualStyleBackColor = true;
            // 
            // chkCategory
            // 
            this.chkCategory.AutoSize = true;
            this.chkCategory.Location = new System.Drawing.Point(200, 124);
            this.chkCategory.Name = "chkCategory";
            this.chkCategory.Size = new System.Drawing.Size(68, 17);
            this.chkCategory.TabIndex = 12;
            this.chkCategory.Text = "Category";
            this.chkCategory.UseVisualStyleBackColor = true;
            // 
            // chkRounds
            // 
            this.chkRounds.AutoSize = true;
            this.chkRounds.Location = new System.Drawing.Point(200, 100);
            this.chkRounds.Name = "chkRounds";
            this.chkRounds.Size = new System.Drawing.Size(63, 17);
            this.chkRounds.TabIndex = 8;
            this.chkRounds.Text = "Rounds";
            this.chkRounds.UseVisualStyleBackColor = true;
            // 
            // chkNotation
            // 
            this.chkNotation.AutoSize = true;
            this.chkNotation.Location = new System.Drawing.Point(200, 74);
            this.chkNotation.Name = "chkNotation";
            this.chkNotation.Size = new System.Drawing.Size(66, 17);
            this.chkNotation.TabIndex = 4;
            this.chkNotation.Text = "Notation";
            this.chkNotation.UseVisualStyleBackColor = true;
            // 
            // chkComplete
            // 
            this.chkComplete.AutoSize = true;
            this.chkComplete.Location = new System.Drawing.Point(27, 174);
            this.chkComplete.Name = "chkComplete";
            this.chkComplete.Size = new System.Drawing.Size(70, 17);
            this.chkComplete.TabIndex = 16;
            this.chkComplete.Text = "Complete";
            this.chkComplete.UseVisualStyleBackColor = true;
            // 
            // cmbNotation
            // 
            this.cmbNotation.FormattingEnabled = true;
            this.cmbNotation.Location = new System.Drawing.Point(321, 70);
            this.cmbNotation.Name = "cmbNotation";
            this.cmbNotation.Size = new System.Drawing.Size(71, 21);
            this.cmbNotation.TabIndex = 5;
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(321, 149);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(71, 21);
            this.cmbType.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbCorrespChe);
            this.groupBox1.Controls.Add(this.rdbNormal);
            this.groupBox1.Controls.Add(this.rdbRapid);
            this.groupBox1.Controls.Add(this.rdbBlitz);
            this.groupBox1.Location = new System.Drawing.Point(27, 197);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 52);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Time";
            // 
            // rdbCorrespChe
            // 
            this.rdbCorrespChe.AutoSize = true;
            this.rdbCorrespChe.Location = new System.Drawing.Point(270, 19);
            this.rdbCorrespChe.Name = "rdbCorrespChe";
            this.rdbCorrespChe.Size = new System.Drawing.Size(89, 17);
            this.rdbCorrespChe.TabIndex = 48;
            this.rdbCorrespChe.TabStop = true;
            this.rdbCorrespChe.Text = "Corresp. Che:";
            this.rdbCorrespChe.UseVisualStyleBackColor = true;
            // 
            // rdbNormal
            // 
            this.rdbNormal.AutoSize = true;
            this.rdbNormal.Location = new System.Drawing.Point(183, 19);
            this.rdbNormal.Name = "rdbNormal";
            this.rdbNormal.Size = new System.Drawing.Size(58, 17);
            this.rdbNormal.TabIndex = 2;
            this.rdbNormal.TabStop = true;
            this.rdbNormal.Text = "Normal";
            this.rdbNormal.UseVisualStyleBackColor = true;
            // 
            // rdbRapid
            // 
            this.rdbRapid.AutoSize = true;
            this.rdbRapid.Location = new System.Drawing.Point(93, 21);
            this.rdbRapid.Name = "rdbRapid";
            this.rdbRapid.Size = new System.Drawing.Size(53, 17);
            this.rdbRapid.TabIndex = 1;
            this.rdbRapid.TabStop = true;
            this.rdbRapid.Text = "Rapid";
            this.rdbRapid.UseVisualStyleBackColor = true;
            // 
            // rdbBlitz
            // 
            this.rdbBlitz.AutoSize = true;
            this.rdbBlitz.Location = new System.Drawing.Point(12, 19);
            this.rdbBlitz.Name = "rdbBlitz";
            this.rdbBlitz.Size = new System.Drawing.Size(44, 17);
            this.rdbBlitz.TabIndex = 0;
            this.rdbBlitz.TabStop = true;
            this.rdbBlitz.Text = "Blitz";
            this.rdbBlitz.UseVisualStyleBackColor = true;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(236, 265);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 20;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(317, 265);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(155, 265);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 19;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmTournamentData
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(416, 303);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.cmbNotation);
            this.Controls.Add(this.chkComplete);
            this.Controls.Add(this.numCategory);
            this.Controls.Add(this.numRounds);
            this.Controls.Add(this.chkBoardPoints);
            this.Controls.Add(this.chkType);
            this.Controls.Add(this.chkCategory);
            this.Controls.Add(this.chkRounds);
            this.Controls.Add(this.chkNotation);
            this.Controls.Add(this.numDay);
            this.Controls.Add(this.numMonth);
            this.Controls.Add(this.numYear);
            this.Controls.Add(this.chkDay);
            this.Controls.Add(this.chkMonth);
            this.Controls.Add(this.chkYear);
            this.Controls.Add(this.txtPlace);
            this.Controls.Add(this.lblPlace);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTournamentData";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Tournament Data";
            this.Load += new System.EventHandler(this.frmTournamentData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRounds)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtPlace;
        private System.Windows.Forms.Label lblPlace;
        private System.Windows.Forms.NumericUpDown numDay;
        private System.Windows.Forms.NumericUpDown numMonth;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.CheckBox chkDay;
        private System.Windows.Forms.CheckBox chkMonth;
        private System.Windows.Forms.CheckBox chkYear;
        private System.Windows.Forms.NumericUpDown numCategory;
        private System.Windows.Forms.NumericUpDown numRounds;
        private System.Windows.Forms.CheckBox chkBoardPoints;
        private System.Windows.Forms.CheckBox chkType;
        private System.Windows.Forms.CheckBox chkCategory;
        private System.Windows.Forms.CheckBox chkRounds;
        private System.Windows.Forms.CheckBox chkNotation;
        private System.Windows.Forms.CheckBox chkComplete;
        private System.Windows.Forms.ComboBox cmbNotation;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbCorrespChe;
        private System.Windows.Forms.RadioButton rdbNormal;
        private System.Windows.Forms.RadioButton rdbRapid;
        private System.Windows.Forms.RadioButton rdbBlitz;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}