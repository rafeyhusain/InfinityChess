namespace App.Win
{
    partial class EngineVsEngine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EngineVsEngine));
            this.txtMatchTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblBookWhite = new System.Windows.Forms.Label();
            this.lblWhiteEngine = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnDefineWhite = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblSelectedGameType = new System.Windows.Forms.Label();
            this.rdbLongGame = new System.Windows.Forms.RadioButton();
            this.rdbBlitzGame = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblBookBlack = new System.Windows.Forms.Label();
            this.lblBlackEngine = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.btnDefineBlack = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkNoMoveLimit = new System.Windows.Forms.CheckBox();
            this.lblDatabasePath = new System.Windows.Forms.Label();
            this.txtDatabasePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.chkNoGameLimit = new System.Windows.Forms.CheckBox();
            this.numNumberOfGames = new System.Windows.Forms.NumericUpDown();
            this.numMoveLimit = new System.Windows.Forms.NumericUpDown();
            this.chkFlipBoard = new System.Windows.Forms.CheckBox();
            this.chkAlternateColor = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnStartMatch = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfGames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveLimit)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMatchTitle
            // 
            this.txtMatchTitle.Location = new System.Drawing.Point(227, 9);
            this.txtMatchTitle.Multiline = true;
            this.txtMatchTitle.Name = "txtMatchTitle";
            this.txtMatchTitle.Size = new System.Drawing.Size(235, 17);
            this.txtMatchTitle.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(154, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Match Title:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblBookWhite);
            this.groupBox1.Controls.Add(this.lblWhiteEngine);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.btnDefineWhite);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(152, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 119);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "White";
            // 
            // lblBookWhite
            // 
            this.lblBookWhite.AutoSize = true;
            this.lblBookWhite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookWhite.Location = new System.Drawing.Point(13, 51);
            this.lblBookWhite.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBookWhite.Name = "lblBookWhite";
            this.lblBookWhite.Size = new System.Drawing.Size(70, 13);
            this.lblBookWhite.TabIndex = 999;
            this.lblBookWhite.Text = "lblBookWhite";
            // 
            // lblWhiteEngine
            // 
            this.lblWhiteEngine.AutoSize = true;
            this.lblWhiteEngine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhiteEngine.Location = new System.Drawing.Point(13, 25);
            this.lblWhiteEngine.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWhiteEngine.Name = "lblWhiteEngine";
            this.lblWhiteEngine.Size = new System.Drawing.Size(78, 13);
            this.lblWhiteEngine.TabIndex = 1;
            this.lblWhiteEngine.Text = "lblWhiteEngine";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(8, 22);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(145, 13);
            this.textBox2.TabIndex = 9;
            // 
            // btnDefineWhite
            // 
            this.btnDefineWhite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDefineWhite.Location = new System.Drawing.Point(8, 81);
            this.btnDefineWhite.Name = "btnDefineWhite";
            this.btnDefineWhite.Size = new System.Drawing.Size(75, 22);
            this.btnDefineWhite.TabIndex = 0;
            this.btnDefineWhite.Text = "Define";
            this.btnDefineWhite.UseVisualStyleBackColor = true;
            this.btnDefineWhite.Click += new System.EventHandler(this.btnDefineWhite_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblSelectedGameType);
            this.groupBox3.Controls.Add(this.rdbLongGame);
            this.groupBox3.Controls.Add(this.rdbBlitzGame);
            this.groupBox3.Location = new System.Drawing.Point(9, 160);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(136, 120);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // lblSelectedGameType
            // 
            this.lblSelectedGameType.AutoSize = true;
            this.lblSelectedGameType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedGameType.Location = new System.Drawing.Point(14, 93);
            this.lblSelectedGameType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelectedGameType.Name = "lblSelectedGameType";
            this.lblSelectedGameType.Size = new System.Drawing.Size(111, 13);
            this.lblSelectedGameType.TabIndex = 3;
            this.lblSelectedGameType.Text = "lblSelectedGameType";
            // 
            // rdbLongGame
            // 
            this.rdbLongGame.AutoSize = true;
            this.rdbLongGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbLongGame.Location = new System.Drawing.Point(17, 41);
            this.rdbLongGame.Name = "rdbLongGame";
            this.rdbLongGame.Size = new System.Drawing.Size(80, 17);
            this.rdbLongGame.TabIndex = 1;
            this.rdbLongGame.Text = "Long Game";
            this.rdbLongGame.UseVisualStyleBackColor = true;
            this.rdbLongGame.Click += new System.EventHandler(this.rdbLongGame_Click);
            // 
            // rdbBlitzGame
            // 
            this.rdbBlitzGame.AutoSize = true;
            this.rdbBlitzGame.Checked = true;
            this.rdbBlitzGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbBlitzGame.Location = new System.Drawing.Point(17, 24);
            this.rdbBlitzGame.Name = "rdbBlitzGame";
            this.rdbBlitzGame.Size = new System.Drawing.Size(75, 17);
            this.rdbBlitzGame.TabIndex = 0;
            this.rdbBlitzGame.TabStop = true;
            this.rdbBlitzGame.Text = "Blitz Game";
            this.rdbBlitzGame.UseVisualStyleBackColor = true;
            this.rdbBlitzGame.Click += new System.EventHandler(this.rdbBlitzGame_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblBookBlack);
            this.groupBox2.Controls.Add(this.lblBlackEngine);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.btnDefineBlack);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(361, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 119);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Black";
            // 
            // lblBookBlack
            // 
            this.lblBookBlack.AutoSize = true;
            this.lblBookBlack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookBlack.Location = new System.Drawing.Point(10, 51);
            this.lblBookBlack.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBookBlack.Name = "lblBookBlack";
            this.lblBookBlack.Size = new System.Drawing.Size(69, 13);
            this.lblBookBlack.TabIndex = 999;
            this.lblBookBlack.Text = "lblBookBlack";
            // 
            // lblBlackEngine
            // 
            this.lblBlackEngine.AutoSize = true;
            this.lblBlackEngine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlackEngine.Location = new System.Drawing.Point(10, 25);
            this.lblBlackEngine.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBlackEngine.Name = "lblBlackEngine";
            this.lblBlackEngine.Size = new System.Drawing.Size(77, 13);
            this.lblBlackEngine.TabIndex = 999;
            this.lblBlackEngine.Text = "lblBlackEngine";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Control;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Location = new System.Drawing.Point(9, 22);
            this.textBox5.Margin = new System.Windows.Forms.Padding(2);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(145, 13);
            this.textBox5.TabIndex = 9;
            // 
            // btnDefineBlack
            // 
            this.btnDefineBlack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDefineBlack.Location = new System.Drawing.Point(9, 81);
            this.btnDefineBlack.Name = "btnDefineBlack";
            this.btnDefineBlack.Size = new System.Drawing.Size(75, 22);
            this.btnDefineBlack.TabIndex = 0;
            this.btnDefineBlack.Text = "Define";
            this.btnDefineBlack.UseVisualStyleBackColor = true;
            this.btnDefineBlack.Click += new System.EventHandler(this.btnDefineBlack_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkNoMoveLimit);
            this.groupBox4.Controls.Add(this.lblDatabasePath);
            this.groupBox4.Controls.Add(this.txtDatabasePath);
            this.groupBox4.Controls.Add(this.btnBrowse);
            this.groupBox4.Controls.Add(this.chkNoGameLimit);
            this.groupBox4.Controls.Add(this.numNumberOfGames);
            this.groupBox4.Controls.Add(this.numMoveLimit);
            this.groupBox4.Controls.Add(this.chkFlipBoard);
            this.groupBox4.Controls.Add(this.chkAlternateColor);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(150, 160);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(411, 119);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            // 
            // chkNoMoveLimit
            // 
            this.chkNoMoveLimit.AutoSize = true;
            this.chkNoMoveLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNoMoveLimit.Location = new System.Drawing.Point(182, 38);
            this.chkNoMoveLimit.Name = "chkNoMoveLimit";
            this.chkNoMoveLimit.Size = new System.Drawing.Size(94, 17);
            this.chkNoMoveLimit.TabIndex = 15;
            this.chkNoMoveLimit.Text = "No Move Limit";
            this.chkNoMoveLimit.UseVisualStyleBackColor = true;
            this.chkNoMoveLimit.CheckedChanged += new System.EventHandler(this.chkNoMoveLimit_CheckedChanged);
            // 
            // lblDatabasePath
            // 
            this.lblDatabasePath.AutoSize = true;
            this.lblDatabasePath.Location = new System.Drawing.Point(7, 88);
            this.lblDatabasePath.Name = "lblDatabasePath";
            this.lblDatabasePath.Size = new System.Drawing.Size(59, 13);
            this.lblDatabasePath.TabIndex = 14;
            this.lblDatabasePath.Text = "Database :";
            // 
            // txtDatabasePath
            // 
            this.txtDatabasePath.Location = new System.Drawing.Point(72, 81);
            this.txtDatabasePath.Name = "txtDatabasePath";
            this.txtDatabasePath.Size = new System.Drawing.Size(185, 20);
            this.txtDatabasePath.TabIndex = 13;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(263, 78);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 10;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // chkNoGameLimit
            // 
            this.chkNoGameLimit.AutoSize = true;
            this.chkNoGameLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNoGameLimit.Location = new System.Drawing.Point(182, 13);
            this.chkNoGameLimit.Name = "chkNoGameLimit";
            this.chkNoGameLimit.Size = new System.Drawing.Size(95, 17);
            this.chkNoGameLimit.TabIndex = 9;
            this.chkNoGameLimit.Text = "No Game Limit";
            this.chkNoGameLimit.UseVisualStyleBackColor = true;
            this.chkNoGameLimit.CheckedChanged += new System.EventHandler(this.chkNoGameLimit_CheckedChanged);
            // 
            // numNumberOfGames
            // 
            this.numNumberOfGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numNumberOfGames.Location = new System.Drawing.Point(122, 10);
            this.numNumberOfGames.Margin = new System.Windows.Forms.Padding(2);
            this.numNumberOfGames.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numNumberOfGames.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numNumberOfGames.Name = "numNumberOfGames";
            this.numNumberOfGames.Size = new System.Drawing.Size(42, 20);
            this.numNumberOfGames.TabIndex = 0;
            this.numNumberOfGames.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numMoveLimit
            // 
            this.numMoveLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMoveLimit.Location = new System.Drawing.Point(122, 35);
            this.numMoveLimit.Margin = new System.Windows.Forms.Padding(2);
            this.numMoveLimit.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numMoveLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMoveLimit.Name = "numMoveLimit";
            this.numMoveLimit.Size = new System.Drawing.Size(42, 20);
            this.numMoveLimit.TabIndex = 1;
            this.numMoveLimit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkFlipBoard
            // 
            this.chkFlipBoard.AutoSize = true;
            this.chkFlipBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFlipBoard.Location = new System.Drawing.Point(122, 62);
            this.chkFlipBoard.Name = "chkFlipBoard";
            this.chkFlipBoard.Size = new System.Drawing.Size(72, 17);
            this.chkFlipBoard.TabIndex = 6;
            this.chkFlipBoard.Text = "Flip board";
            this.chkFlipBoard.UseVisualStyleBackColor = true;
            // 
            // chkAlternateColor
            // 
            this.chkAlternateColor.AutoSize = true;
            this.chkAlternateColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAlternateColor.Location = new System.Drawing.Point(14, 62);
            this.chkAlternateColor.Name = "chkAlternateColor";
            this.chkAlternateColor.Size = new System.Drawing.Size(95, 17);
            this.chkAlternateColor.TabIndex = 5;
            this.chkAlternateColor.Text = "Alternate Color";
            this.chkAlternateColor.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Move Limit:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Number of Games:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(405, 284);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(486, 284);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 22);
            this.btnHelp.TabIndex = 7;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnStartMatch
            // 
            this.btnStartMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartMatch.Location = new System.Drawing.Point(324, 284);
            this.btnStartMatch.Name = "btnStartMatch";
            this.btnStartMatch.Size = new System.Drawing.Size(75, 22);
            this.btnStartMatch.TabIndex = 5;
            this.btnStartMatch.Text = "Start Match";
            this.btnStartMatch.UseVisualStyleBackColor = true;
            this.btnStartMatch.Click += new System.EventHandler(this.btnStartMatch_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.pictureBox1);
            this.groupBox5.Location = new System.Drawing.Point(9, 3);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(137, 152);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 135);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // EngineVsEngine
            // 
            this.AcceptButton = this.btnDefineWhite;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(572, 317);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnStartMatch);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMatchTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EngineVsEngine";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Engine vs Engine Match";
            this.Load += new System.EventHandler(this.EngineVsEngine_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfGames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveLimit)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMatchTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDefineWhite;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbLongGame;
        private System.Windows.Forms.RadioButton rdbBlitzGame;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button btnDefineBlack;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkFlipBoard;
        private System.Windows.Forms.CheckBox chkAlternateColor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnStartMatch;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblWhiteEngine;
        private System.Windows.Forms.Label lblBlackEngine;
        private System.Windows.Forms.NumericUpDown numNumberOfGames;
        private System.Windows.Forms.NumericUpDown numMoveLimit;
        private System.Windows.Forms.Label lblSelectedGameType;
        private System.Windows.Forms.Label lblBookWhite;
        private System.Windows.Forms.Label lblBookBlack;
        private System.Windows.Forms.CheckBox chkNoGameLimit;
        private System.Windows.Forms.Label lblDatabasePath;
        private System.Windows.Forms.TextBox txtDatabasePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox chkNoMoveLimit;
    }
}