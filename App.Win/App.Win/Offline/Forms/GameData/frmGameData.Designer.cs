namespace InfinityChess.GameData
{
    partial class frmGameData
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.tbPlayers_Result = new System.Windows.Forms.TabPage();
            this.btnReset = new System.Windows.Forms.Button();
            this.numDay = new System.Windows.Forms.NumericUpDown();
            this.numMonth = new System.Windows.Forms.NumericUpDown();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.chkDay = new System.Windows.Forms.CheckBox();
            this.chkMonth = new System.Windows.Forms.CheckBox();
            this.chkYear = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbResult = new System.Windows.Forms.ComboBox();
            this.rdb0_1 = new System.Windows.Forms.RadioButton();
            this.rdb12_12 = new System.Windows.Forms.RadioButton();
            this.rdb1_0 = new System.Windows.Forms.RadioButton();
            this.numEloBlack = new System.Windows.Forms.NumericUpDown();
            this.numEloWhite = new System.Windows.Forms.NumericUpDown();
            this.txtECOCode = new System.Windows.Forms.TextBox();
            this.txtTournament = new System.Windows.Forms.TextBox();
            this.txtBlack2 = new System.Windows.Forms.TextBox();
            this.txtBlack1 = new System.Windows.Forms.TextBox();
            this.txtWhite2 = new System.Windows.Forms.TextBox();
            this.txtWhite1 = new System.Windows.Forms.TextBox();
            this.chkEloBlack = new System.Windows.Forms.CheckBox();
            this.chkEloWhite = new System.Windows.Forms.CheckBox();
            this.chkECOCode = new System.Windows.Forms.CheckBox();
            this.lblTournament = new System.Windows.Forms.Label();
            this.lblBlack2 = new System.Windows.Forms.Label();
            this.lblBlack1 = new System.Windows.Forms.Label();
            this.lblWhite2 = new System.Windows.Forms.Label();
            this.lblWhite1 = new System.Windows.Forms.Label();
            this.tbGameData = new System.Windows.Forms.TabControl();
            this.tbPlayers_Result.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEloBlack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEloWhite)).BeginInit();
            this.tbGameData.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(218, 274);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.btnCancel.Location = new System.Drawing.Point(299, 274);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(380, 274);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 22);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // tbPlayers_Result
            // 
            this.tbPlayers_Result.Controls.Add(this.btnReset);
            this.tbPlayers_Result.Controls.Add(this.numDay);
            this.tbPlayers_Result.Controls.Add(this.numMonth);
            this.tbPlayers_Result.Controls.Add(this.numYear);
            this.tbPlayers_Result.Controls.Add(this.chkDay);
            this.tbPlayers_Result.Controls.Add(this.chkMonth);
            this.tbPlayers_Result.Controls.Add(this.chkYear);
            this.tbPlayers_Result.Controls.Add(this.groupBox1);
            this.tbPlayers_Result.Controls.Add(this.numEloBlack);
            this.tbPlayers_Result.Controls.Add(this.numEloWhite);
            this.tbPlayers_Result.Controls.Add(this.txtECOCode);
            this.tbPlayers_Result.Controls.Add(this.txtTournament);
            this.tbPlayers_Result.Controls.Add(this.txtBlack2);
            this.tbPlayers_Result.Controls.Add(this.txtBlack1);
            this.tbPlayers_Result.Controls.Add(this.txtWhite2);
            this.tbPlayers_Result.Controls.Add(this.txtWhite1);
            this.tbPlayers_Result.Controls.Add(this.chkEloBlack);
            this.tbPlayers_Result.Controls.Add(this.chkEloWhite);
            this.tbPlayers_Result.Controls.Add(this.chkECOCode);
            this.tbPlayers_Result.Controls.Add(this.lblTournament);
            this.tbPlayers_Result.Controls.Add(this.lblBlack2);
            this.tbPlayers_Result.Controls.Add(this.lblBlack1);
            this.tbPlayers_Result.Controls.Add(this.lblWhite2);
            this.tbPlayers_Result.Controls.Add(this.lblWhite1);
            this.tbPlayers_Result.Location = new System.Drawing.Point(4, 22);
            this.tbPlayers_Result.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPlayers_Result.Name = "tbPlayers_Result";
            this.tbPlayers_Result.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPlayers_Result.Size = new System.Drawing.Size(439, 230);
            this.tbPlayers_Result.TabIndex = 0;
            this.tbPlayers_Result.Text = "Players & Result";
            this.tbPlayers_Result.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(340, 193);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 22);
            this.btnReset.TabIndex = 23;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // numDay
            // 
            this.numDay.Location = new System.Drawing.Point(364, 167);
            this.numDay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numDay.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.numDay.Name = "numDay";
            this.numDay.Size = new System.Drawing.Size(51, 20);
            this.numDay.TabIndex = 22;
            this.numDay.Value = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.numDay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numDay_KeyDown);
            // 
            // numMonth
            // 
            this.numMonth.Location = new System.Drawing.Point(364, 144);
            this.numMonth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numMonth.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numMonth.Name = "numMonth";
            this.numMonth.Size = new System.Drawing.Size(51, 20);
            this.numMonth.TabIndex = 20;
            this.numMonth.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numMonth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numMonth_KeyDown);
            // 
            // numYear
            // 
            this.numYear.Location = new System.Drawing.Point(364, 121);
            this.numYear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numYear.Maximum = new decimal(new int[] {
            2400,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(51, 20);
            this.numYear.TabIndex = 18;
            this.numYear.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numYear_KeyPress);
            this.numYear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numYear_KeyDown);
            // 
            // chkDay
            // 
            this.chkDay.AutoSize = true;
            this.chkDay.Location = new System.Drawing.Point(303, 170);
            this.chkDay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDay.Name = "chkDay";
            this.chkDay.Size = new System.Drawing.Size(45, 17);
            this.chkDay.TabIndex = 21;
            this.chkDay.Text = "Day";
            this.chkDay.UseVisualStyleBackColor = true;
            // 
            // chkMonth
            // 
            this.chkMonth.AutoSize = true;
            this.chkMonth.Location = new System.Drawing.Point(303, 147);
            this.chkMonth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkMonth.Name = "chkMonth";
            this.chkMonth.Size = new System.Drawing.Size(56, 17);
            this.chkMonth.TabIndex = 19;
            this.chkMonth.Text = "Month";
            this.chkMonth.UseVisualStyleBackColor = true;
            // 
            // chkYear
            // 
            this.chkYear.AutoSize = true;
            this.chkYear.Location = new System.Drawing.Point(303, 124);
            this.chkYear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkYear.Name = "chkYear";
            this.chkYear.Size = new System.Drawing.Size(48, 17);
            this.chkYear.TabIndex = 17;
            this.chkYear.Text = "Year";
            this.chkYear.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbResult);
            this.groupBox1.Controls.Add(this.rdb0_1);
            this.groupBox1.Controls.Add(this.rdb12_12);
            this.groupBox1.Controls.Add(this.rdb1_0);
            this.groupBox1.Location = new System.Drawing.Point(192, 109);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(100, 112);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Result";
            // 
            // cmbResult
            // 
            this.cmbResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResult.FormattingEnabled = true;
            this.cmbResult.Location = new System.Drawing.Point(17, 82);
            this.cmbResult.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbResult.Name = "cmbResult";
            this.cmbResult.Size = new System.Drawing.Size(62, 21);
            this.cmbResult.TabIndex = 3;
            this.cmbResult.SelectedIndexChanged += new System.EventHandler(this.cmbResult_SelectedIndexChanged);
            // 
            // rdb0_1
            // 
            this.rdb0_1.AutoSize = true;
            this.rdb0_1.Location = new System.Drawing.Point(18, 61);
            this.rdb0_1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdb0_1.Name = "rdb0_1";
            this.rdb0_1.Size = new System.Drawing.Size(40, 17);
            this.rdb0_1.TabIndex = 2;
            this.rdb0_1.TabStop = true;
            this.rdb0_1.Text = "0-1";
            this.rdb0_1.UseVisualStyleBackColor = true;
            this.rdb0_1.Click += new System.EventHandler(this.rdb0_1_Click);
            // 
            // rdb12_12
            // 
            this.rdb12_12.AutoSize = true;
            this.rdb12_12.Location = new System.Drawing.Point(17, 38);
            this.rdb12_12.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdb12_12.Name = "rdb12_12";
            this.rdb12_12.Size = new System.Drawing.Size(62, 17);
            this.rdb12_12.TabIndex = 1;
            this.rdb12_12.TabStop = true;
            this.rdb12_12.Text = "1/2-1/2";
            this.rdb12_12.UseVisualStyleBackColor = true;
            this.rdb12_12.Click += new System.EventHandler(this.rdb12_12_Click);
            // 
            // rdb1_0
            // 
            this.rdb1_0.AutoSize = true;
            this.rdb1_0.Location = new System.Drawing.Point(17, 15);
            this.rdb1_0.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdb1_0.Name = "rdb1_0";
            this.rdb1_0.Size = new System.Drawing.Size(40, 17);
            this.rdb1_0.TabIndex = 0;
            this.rdb1_0.TabStop = true;
            this.rdb1_0.Text = "1-0";
            this.rdb1_0.UseVisualStyleBackColor = true;
            this.rdb1_0.Click += new System.EventHandler(this.rdb1_0_Click);
            // 
            // numEloBlack
            // 
            this.numEloBlack.Location = new System.Drawing.Point(105, 155);
            this.numEloBlack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numEloBlack.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numEloBlack.Name = "numEloBlack";
            this.numEloBlack.Size = new System.Drawing.Size(71, 20);
            this.numEloBlack.TabIndex = 11;
            this.numEloBlack.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numEloBlack.ValueChanged += new System.EventHandler(this.numEloBlack_ValueChanged);
            // 
            // numEloWhite
            // 
            this.numEloWhite.Location = new System.Drawing.Point(105, 132);
            this.numEloWhite.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numEloWhite.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numEloWhite.Name = "numEloWhite";
            this.numEloWhite.Size = new System.Drawing.Size(71, 20);
            this.numEloWhite.TabIndex = 9;
            this.numEloWhite.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numEloWhite.ValueChanged += new System.EventHandler(this.numEloWhite_ValueChanged);
            // 
            // txtECOCode
            // 
            this.txtECOCode.Location = new System.Drawing.Point(105, 109);
            this.txtECOCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtECOCode.MaxLength = 6;
            this.txtECOCode.Name = "txtECOCode";
            this.txtECOCode.Size = new System.Drawing.Size(71, 20);
            this.txtECOCode.TabIndex = 7;
            this.txtECOCode.TextChanged += new System.EventHandler(this.txtECOCode_TextChanged);
            // 
            // txtTournament
            // 
            this.txtTournament.Location = new System.Drawing.Point(86, 65);
            this.txtTournament.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTournament.MaxLength = 40;
            this.txtTournament.Name = "txtTournament";
            this.txtTournament.Size = new System.Drawing.Size(137, 20);
            this.txtTournament.TabIndex = 4;
            // 
            // txtBlack2
            // 
            this.txtBlack2.Location = new System.Drawing.Point(245, 39);
            this.txtBlack2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBlack2.MaxLength = 20;
            this.txtBlack2.Name = "txtBlack2";
            this.txtBlack2.Size = new System.Drawing.Size(137, 20);
            this.txtBlack2.TabIndex = 3;
            // 
            // txtBlack1
            // 
            this.txtBlack1.Location = new System.Drawing.Point(86, 39);
            this.txtBlack1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBlack1.MaxLength = 30;
            this.txtBlack1.Name = "txtBlack1";
            this.txtBlack1.Size = new System.Drawing.Size(137, 20);
            this.txtBlack1.TabIndex = 2;
            // 
            // txtWhite2
            // 
            this.txtWhite2.Location = new System.Drawing.Point(245, 13);
            this.txtWhite2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWhite2.MaxLength = 20;
            this.txtWhite2.Name = "txtWhite2";
            this.txtWhite2.Size = new System.Drawing.Size(137, 20);
            this.txtWhite2.TabIndex = 1;
            // 
            // txtWhite1
            // 
            this.txtWhite1.Location = new System.Drawing.Point(86, 13);
            this.txtWhite1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWhite1.MaxLength = 30;
            this.txtWhite1.Name = "txtWhite1";
            this.txtWhite1.Size = new System.Drawing.Size(137, 20);
            this.txtWhite1.TabIndex = 0;
            // 
            // chkEloBlack
            // 
            this.chkEloBlack.AutoSize = true;
            this.chkEloBlack.Location = new System.Drawing.Point(23, 158);
            this.chkEloBlack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkEloBlack.Name = "chkEloBlack";
            this.chkEloBlack.Size = new System.Drawing.Size(71, 17);
            this.chkEloBlack.TabIndex = 10;
            this.chkEloBlack.Text = "Elo Black";
            this.chkEloBlack.UseVisualStyleBackColor = true;
            // 
            // chkEloWhite
            // 
            this.chkEloWhite.AutoSize = true;
            this.chkEloWhite.Location = new System.Drawing.Point(23, 135);
            this.chkEloWhite.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkEloWhite.Name = "chkEloWhite";
            this.chkEloWhite.Size = new System.Drawing.Size(72, 17);
            this.chkEloWhite.TabIndex = 8;
            this.chkEloWhite.Text = "Elo White";
            this.chkEloWhite.UseVisualStyleBackColor = true;
            // 
            // chkECOCode
            // 
            this.chkECOCode.AutoSize = true;
            this.chkECOCode.Location = new System.Drawing.Point(23, 112);
            this.chkECOCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkECOCode.Name = "chkECOCode";
            this.chkECOCode.Size = new System.Drawing.Size(76, 17);
            this.chkECOCode.TabIndex = 6;
            this.chkECOCode.Text = "ECO Code";
            this.chkECOCode.UseVisualStyleBackColor = true;
            // 
            // lblTournament
            // 
            this.lblTournament.AutoSize = true;
            this.lblTournament.Location = new System.Drawing.Point(20, 72);
            this.lblTournament.Name = "lblTournament";
            this.lblTournament.Size = new System.Drawing.Size(64, 13);
            this.lblTournament.TabIndex = 8;
            this.lblTournament.Text = "Tournament";
            // 
            // lblBlack2
            // 
            this.lblBlack2.AutoSize = true;
            this.lblBlack2.Location = new System.Drawing.Point(229, 46);
            this.lblBlack2.Name = "lblBlack2";
            this.lblBlack2.Size = new System.Drawing.Size(10, 13);
            this.lblBlack2.TabIndex = 7;
            this.lblBlack2.Text = ",";
            // 
            // lblBlack1
            // 
            this.lblBlack1.AutoSize = true;
            this.lblBlack1.Location = new System.Drawing.Point(20, 46);
            this.lblBlack1.Name = "lblBlack1";
            this.lblBlack1.Size = new System.Drawing.Size(34, 13);
            this.lblBlack1.TabIndex = 4;
            this.lblBlack1.Text = "Black";
            // 
            // lblWhite2
            // 
            this.lblWhite2.AutoSize = true;
            this.lblWhite2.Location = new System.Drawing.Point(229, 20);
            this.lblWhite2.Name = "lblWhite2";
            this.lblWhite2.Size = new System.Drawing.Size(10, 13);
            this.lblWhite2.TabIndex = 3;
            this.lblWhite2.Text = ",";
            // 
            // lblWhite1
            // 
            this.lblWhite1.AutoSize = true;
            this.lblWhite1.Location = new System.Drawing.Point(20, 20);
            this.lblWhite1.Name = "lblWhite1";
            this.lblWhite1.Size = new System.Drawing.Size(35, 13);
            this.lblWhite1.TabIndex = 0;
            this.lblWhite1.Text = "White";
            // 
            // tbGameData
            // 
            this.tbGameData.Controls.Add(this.tbPlayers_Result);
            this.tbGameData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tbGameData.Location = new System.Drawing.Point(12, 13);
            this.tbGameData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbGameData.Name = "tbGameData";
            this.tbGameData.SelectedIndex = 0;
            this.tbGameData.Size = new System.Drawing.Size(447, 256);
            this.tbGameData.TabIndex = 0;
            // 
            // frmGameData
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(471, 308);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbGameData);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGameData";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game data";
            this.Load += new System.EventHandler(this.frmGameData_Load);
            this.tbPlayers_Result.ResumeLayout(false);
            this.tbPlayers_Result.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEloBlack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEloWhite)).EndInit();
            this.tbGameData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.TabPage tbPlayers_Result;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.NumericUpDown numDay;
        private System.Windows.Forms.NumericUpDown numMonth;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.CheckBox chkDay;
        private System.Windows.Forms.CheckBox chkMonth;
        private System.Windows.Forms.CheckBox chkYear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbResult;
        private System.Windows.Forms.RadioButton rdb0_1;
        private System.Windows.Forms.RadioButton rdb12_12;
        private System.Windows.Forms.RadioButton rdb1_0;
        private System.Windows.Forms.NumericUpDown numEloBlack;
        private System.Windows.Forms.NumericUpDown numEloWhite;
        private System.Windows.Forms.TextBox txtECOCode;
        private System.Windows.Forms.TextBox txtTournament;
        private System.Windows.Forms.TextBox txtBlack2;
        private System.Windows.Forms.TextBox txtBlack1;
        private System.Windows.Forms.TextBox txtWhite2;
        private System.Windows.Forms.TextBox txtWhite1;
        private System.Windows.Forms.CheckBox chkEloBlack;
        private System.Windows.Forms.CheckBox chkEloWhite;
        private System.Windows.Forms.CheckBox chkECOCode;
        private System.Windows.Forms.Label lblTournament;
        private System.Windows.Forms.Label lblBlack2;
        private System.Windows.Forms.Label lblBlack1;
        private System.Windows.Forms.Label lblWhite2;
        private System.Windows.Forms.Label lblWhite1;
        private System.Windows.Forms.TabControl tbGameData;
    }
}