namespace App.Win
{
    partial class GameSearch
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Position = new System.Windows.Forms.TabPage();
            this.GameData = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numMoves2 = new System.Windows.Forms.NumericUpDown();
            this.numMoves1 = new System.Windows.Forms.NumericUpDown();
            this.txtEco2 = new System.Windows.Forms.TextBox();
            this.txtEco1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numYear2 = new System.Windows.Forms.NumericUpDown();
            this.chkMoves = new System.Windows.Forms.CheckBox();
            this.chkEco = new System.Windows.Forms.CheckBox();
            this.groupBoxElo = new System.Windows.Forms.GroupBox();
            this.numElo2 = new System.Windows.Forms.NumericUpDown();
            this.rdbtnAverage = new System.Windows.Forms.RadioButton();
            this.numElo1 = new System.Windows.Forms.NumericUpDown();
            this.rdbtnBoth = new System.Windows.Forms.RadioButton();
            this.rdbtnOne = new System.Windows.Forms.RadioButton();
            this.rdbtnNone = new System.Windows.Forms.RadioButton();
            this.lblDash = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.numYear1 = new System.Windows.Forms.NumericUpDown();
            this.chkYear = new System.Windows.Forms.CheckBox();
            this.groupBoxResult = new System.Windows.Forms.GroupBox();
            this.chkLost = new System.Windows.Forms.CheckBox();
            this.chkDraw = new System.Windows.Forms.CheckBox();
            this.chkWin = new System.Windows.Forms.CheckBox();
            this.chkCheck = new System.Windows.Forms.CheckBox();
            this.chkStalem = new System.Windows.Forms.CheckBox();
            this.chkMate = new System.Windows.Forms.CheckBox();
            this.txtTournament = new System.Windows.Forms.TextBox();
            this.txtBlack2 = new System.Windows.Forms.TextBox();
            this.txtBlack1 = new System.Windows.Forms.TextBox();
            this.txtWhite2 = new System.Windows.Forms.TextBox();
            this.txtWhite1 = new System.Windows.Forms.TextBox();
            this.lblTournament = new System.Windows.Forms.Label();
            this.lblBlack2 = new System.Windows.Forms.Label();
            this.lblBlack1 = new System.Windows.Forms.Label();
            this.lblWhite2 = new System.Windows.Forms.Label();
            this.lblWhite1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkPosition = new System.Windows.Forms.CheckBox();
            this.chkGameData = new System.Windows.Forms.CheckBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.GameData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMoves2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoves1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear2)).BeginInit();
            this.groupBoxElo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numElo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numElo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear1)).BeginInit();
            this.groupBoxResult.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Position);
            this.tabControl1.Controls.Add(this.GameData);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(674, 583);
            this.tabControl1.TabIndex = 0;
            // 
            // Position
            // 
            this.Position.Location = new System.Drawing.Point(4, 22);
            this.Position.Name = "Position";
            this.Position.Padding = new System.Windows.Forms.Padding(3);
            this.Position.Size = new System.Drawing.Size(666, 557);
            this.Position.TabIndex = 1;
            this.Position.Text = "Position";
            this.Position.UseVisualStyleBackColor = true;
            // 
            // GameData
            // 
            this.GameData.Controls.Add(this.label3);
            this.GameData.Controls.Add(this.label2);
            this.GameData.Controls.Add(this.numMoves2);
            this.GameData.Controls.Add(this.numMoves1);
            this.GameData.Controls.Add(this.txtEco2);
            this.GameData.Controls.Add(this.txtEco1);
            this.GameData.Controls.Add(this.label1);
            this.GameData.Controls.Add(this.numYear2);
            this.GameData.Controls.Add(this.chkMoves);
            this.GameData.Controls.Add(this.chkEco);
            this.GameData.Controls.Add(this.groupBoxElo);
            this.GameData.Controls.Add(this.btnReset);
            this.GameData.Controls.Add(this.numYear1);
            this.GameData.Controls.Add(this.chkYear);
            this.GameData.Controls.Add(this.groupBoxResult);
            this.GameData.Controls.Add(this.txtTournament);
            this.GameData.Controls.Add(this.txtBlack2);
            this.GameData.Controls.Add(this.txtBlack1);
            this.GameData.Controls.Add(this.txtWhite2);
            this.GameData.Controls.Add(this.txtWhite1);
            this.GameData.Controls.Add(this.lblTournament);
            this.GameData.Controls.Add(this.lblBlack2);
            this.GameData.Controls.Add(this.lblBlack1);
            this.GameData.Controls.Add(this.lblWhite2);
            this.GameData.Controls.Add(this.lblWhite1);
            this.GameData.Location = new System.Drawing.Point(4, 22);
            this.GameData.Name = "GameData";
            this.GameData.Padding = new System.Windows.Forms.Padding(3);
            this.GameData.Size = new System.Drawing.Size(666, 557);
            this.GameData.TabIndex = 0;
            this.GameData.Text = "GameData";
            this.GameData.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "-";
            // 
            // numMoves2
            // 
            this.numMoves2.Location = new System.Drawing.Point(194, 201);
            this.numMoves2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numMoves2.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numMoves2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMoves2.Name = "numMoves2";
            this.numMoves2.Size = new System.Drawing.Size(51, 20);
            this.numMoves2.TabIndex = 57;
            this.numMoves2.Value = new decimal(new int[] {
            22,
            0,
            0,
            0});
            this.numMoves2.ValueChanged += new System.EventHandler(this.numMoves2_ValueChanged);
            // 
            // numMoves1
            // 
            this.numMoves1.Location = new System.Drawing.Point(119, 201);
            this.numMoves1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numMoves1.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numMoves1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMoves1.Name = "numMoves1";
            this.numMoves1.Size = new System.Drawing.Size(51, 20);
            this.numMoves1.TabIndex = 56;
            this.numMoves1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMoves1.ValueChanged += new System.EventHandler(this.numMoves1_ValueChanged);
            // 
            // txtEco2
            // 
            this.txtEco2.Location = new System.Drawing.Point(194, 174);
            this.txtEco2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEco2.MaxLength = 40;
            this.txtEco2.Name = "txtEco2";
            this.txtEco2.Size = new System.Drawing.Size(51, 20);
            this.txtEco2.TabIndex = 55;
            this.txtEco2.TextChanged += new System.EventHandler(this.txtEco2_TextChanged);
            // 
            // txtEco1
            // 
            this.txtEco1.Location = new System.Drawing.Point(119, 173);
            this.txtEco1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEco1.MaxLength = 40;
            this.txtEco1.Name = "txtEco1";
            this.txtEco1.Size = new System.Drawing.Size(51, 20);
            this.txtEco1.TabIndex = 54;
            this.txtEco1.TextChanged += new System.EventHandler(this.txtEco1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "-";
            // 
            // numYear2
            // 
            this.numYear2.Location = new System.Drawing.Point(194, 148);
            this.numYear2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numYear2.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numYear2.Minimum = new decimal(new int[] {
            1600,
            0,
            0,
            0});
            this.numYear2.Name = "numYear2";
            this.numYear2.Size = new System.Drawing.Size(51, 20);
            this.numYear2.TabIndex = 52;
            this.numYear2.Value = new decimal(new int[] {
            2010,
            0,
            0,
            0});
            this.numYear2.ValueChanged += new System.EventHandler(this.numYear2_ValueChanged);
            // 
            // chkMoves
            // 
            this.chkMoves.AutoSize = true;
            this.chkMoves.Location = new System.Drawing.Point(58, 201);
            this.chkMoves.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkMoves.Name = "chkMoves";
            this.chkMoves.Size = new System.Drawing.Size(58, 17);
            this.chkMoves.TabIndex = 51;
            this.chkMoves.Text = "Moves";
            this.chkMoves.UseVisualStyleBackColor = true;
            this.chkMoves.CheckedChanged += new System.EventHandler(this.chkMoves_CheckedChanged);
            // 
            // chkEco
            // 
            this.chkEco.AutoSize = true;
            this.chkEco.Location = new System.Drawing.Point(58, 176);
            this.chkEco.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkEco.Name = "chkEco";
            this.chkEco.Size = new System.Drawing.Size(48, 17);
            this.chkEco.TabIndex = 50;
            this.chkEco.Text = "ECO";
            this.chkEco.UseVisualStyleBackColor = true;
            this.chkEco.CheckedChanged += new System.EventHandler(this.chkEco_CheckedChanged);
            // 
            // groupBoxElo
            // 
            this.groupBoxElo.Controls.Add(this.numElo2);
            this.groupBoxElo.Controls.Add(this.rdbtnAverage);
            this.groupBoxElo.Controls.Add(this.numElo1);
            this.groupBoxElo.Controls.Add(this.rdbtnBoth);
            this.groupBoxElo.Controls.Add(this.rdbtnOne);
            this.groupBoxElo.Controls.Add(this.rdbtnNone);
            this.groupBoxElo.Controls.Add(this.lblDash);
            this.groupBoxElo.Location = new System.Drawing.Point(280, 76);
            this.groupBoxElo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxElo.Name = "groupBoxElo";
            this.groupBoxElo.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxElo.Size = new System.Drawing.Size(223, 112);
            this.groupBoxElo.TabIndex = 41;
            this.groupBoxElo.TabStop = false;
            this.groupBoxElo.Text = "Elo";
            // 
            // numElo2
            // 
            this.numElo2.Location = new System.Drawing.Point(110, 15);
            this.numElo2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numElo2.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numElo2.Minimum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numElo2.Name = "numElo2";
            this.numElo2.Size = new System.Drawing.Size(51, 20);
            this.numElo2.TabIndex = 61;
            this.numElo2.Value = new decimal(new int[] {
            2800,
            0,
            0,
            0});
            // 
            // rdbtnAverage
            // 
            this.rdbtnAverage.AutoSize = true;
            this.rdbtnAverage.Location = new System.Drawing.Point(110, 72);
            this.rdbtnAverage.Name = "rdbtnAverage";
            this.rdbtnAverage.Size = new System.Drawing.Size(65, 17);
            this.rdbtnAverage.TabIndex = 6;
            this.rdbtnAverage.TabStop = true;
            this.rdbtnAverage.Text = "Average";
            this.rdbtnAverage.UseVisualStyleBackColor = true;
            this.rdbtnAverage.CheckedChanged += new System.EventHandler(this.rdbtnAverage_CheckedChanged);
            // 
            // numElo1
            // 
            this.numElo1.Location = new System.Drawing.Point(34, 15);
            this.numElo1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numElo1.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numElo1.Minimum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numElo1.Name = "numElo1";
            this.numElo1.Size = new System.Drawing.Size(51, 20);
            this.numElo1.TabIndex = 60;
            this.numElo1.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // rdbtnBoth
            // 
            this.rdbtnBoth.AutoSize = true;
            this.rdbtnBoth.Location = new System.Drawing.Point(34, 72);
            this.rdbtnBoth.Name = "rdbtnBoth";
            this.rdbtnBoth.Size = new System.Drawing.Size(47, 17);
            this.rdbtnBoth.TabIndex = 5;
            this.rdbtnBoth.TabStop = true;
            this.rdbtnBoth.Text = "Both";
            this.rdbtnBoth.UseVisualStyleBackColor = true;
            this.rdbtnBoth.CheckedChanged += new System.EventHandler(this.rdbtnBoth_CheckedChanged);
            // 
            // rdbtnOne
            // 
            this.rdbtnOne.AutoSize = true;
            this.rdbtnOne.Location = new System.Drawing.Point(110, 46);
            this.rdbtnOne.Name = "rdbtnOne";
            this.rdbtnOne.Size = new System.Drawing.Size(45, 17);
            this.rdbtnOne.TabIndex = 4;
            this.rdbtnOne.TabStop = true;
            this.rdbtnOne.Text = "One";
            this.rdbtnOne.UseVisualStyleBackColor = true;
            this.rdbtnOne.CheckedChanged += new System.EventHandler(this.rdbtnOne_CheckedChanged);
            // 
            // rdbtnNone
            // 
            this.rdbtnNone.AutoSize = true;
            this.rdbtnNone.Location = new System.Drawing.Point(34, 46);
            this.rdbtnNone.Name = "rdbtnNone";
            this.rdbtnNone.Size = new System.Drawing.Size(51, 17);
            this.rdbtnNone.TabIndex = 3;
            this.rdbtnNone.TabStop = true;
            this.rdbtnNone.Text = "None";
            this.rdbtnNone.UseVisualStyleBackColor = true;
            // 
            // lblDash
            // 
            this.lblDash.AutoSize = true;
            this.lblDash.Location = new System.Drawing.Point(92, 19);
            this.lblDash.Name = "lblDash";
            this.lblDash.Size = new System.Drawing.Size(10, 13);
            this.lblDash.TabIndex = 2;
            this.lblDash.Text = "-";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(428, 285);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 22);
            this.btnReset.TabIndex = 47;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // numYear1
            // 
            this.numYear1.Location = new System.Drawing.Point(119, 148);
            this.numYear1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numYear1.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numYear1.Minimum = new decimal(new int[] {
            1600,
            0,
            0,
            0});
            this.numYear1.Name = "numYear1";
            this.numYear1.Size = new System.Drawing.Size(51, 20);
            this.numYear1.TabIndex = 42;
            this.numYear1.Value = new decimal(new int[] {
            2010,
            0,
            0,
            0});
            this.numYear1.ValueChanged += new System.EventHandler(this.numYear1_ValueChanged);
            // 
            // chkYear
            // 
            this.chkYear.AutoSize = true;
            this.chkYear.Location = new System.Drawing.Point(58, 151);
            this.chkYear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkYear.Name = "chkYear";
            this.chkYear.Size = new System.Drawing.Size(48, 17);
            this.chkYear.TabIndex = 41;
            this.chkYear.Text = "Year";
            this.chkYear.UseVisualStyleBackColor = true;
            this.chkYear.CheckedChanged += new System.EventHandler(this.chkYear_CheckedChanged);
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Controls.Add(this.chkLost);
            this.groupBoxResult.Controls.Add(this.chkDraw);
            this.groupBoxResult.Controls.Add(this.chkWin);
            this.groupBoxResult.Controls.Add(this.chkCheck);
            this.groupBoxResult.Controls.Add(this.chkStalem);
            this.groupBoxResult.Controls.Add(this.chkMate);
            this.groupBoxResult.Location = new System.Drawing.Point(280, 200);
            this.groupBoxResult.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxResult.Name = "groupBoxResult";
            this.groupBoxResult.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxResult.Size = new System.Drawing.Size(223, 77);
            this.groupBoxResult.TabIndex = 40;
            this.groupBoxResult.TabStop = false;
            this.groupBoxResult.Text = "Result";
            // 
            // chkLost
            // 
            this.chkLost.AutoSize = true;
            this.chkLost.Location = new System.Drawing.Point(162, 23);
            this.chkLost.Name = "chkLost";
            this.chkLost.Size = new System.Drawing.Size(41, 17);
            this.chkLost.TabIndex = 9;
            this.chkLost.Text = "0-1";
            this.chkLost.UseVisualStyleBackColor = true;
            this.chkLost.CheckedChanged += new System.EventHandler(this.chkLost_CheckedChanged);
            // 
            // chkDraw
            // 
            this.chkDraw.AutoSize = true;
            this.chkDraw.Location = new System.Drawing.Point(80, 23);
            this.chkDraw.Name = "chkDraw";
            this.chkDraw.Size = new System.Drawing.Size(63, 17);
            this.chkDraw.TabIndex = 8;
            this.chkDraw.Text = "1/2-1/2";
            this.chkDraw.UseVisualStyleBackColor = true;
            this.chkDraw.CheckedChanged += new System.EventHandler(this.chkDraw_CheckedChanged);
            // 
            // chkWin
            // 
            this.chkWin.AutoSize = true;
            this.chkWin.Location = new System.Drawing.Point(17, 23);
            this.chkWin.Name = "chkWin";
            this.chkWin.Size = new System.Drawing.Size(41, 17);
            this.chkWin.TabIndex = 7;
            this.chkWin.Text = "1-0";
            this.chkWin.UseVisualStyleBackColor = true;
            this.chkWin.CheckedChanged += new System.EventHandler(this.chkWin_CheckedChanged);
            // 
            // chkCheck
            // 
            this.chkCheck.AutoSize = true;
            this.chkCheck.Location = new System.Drawing.Point(162, 45);
            this.chkCheck.Name = "chkCheck";
            this.chkCheck.Size = new System.Drawing.Size(57, 17);
            this.chkCheck.TabIndex = 6;
            this.chkCheck.Text = "Check";
            this.chkCheck.UseVisualStyleBackColor = true;
            this.chkCheck.CheckedChanged += new System.EventHandler(this.chkCheck_CheckedChanged);
            // 
            // chkStalem
            // 
            this.chkStalem.AutoSize = true;
            this.chkStalem.Location = new System.Drawing.Point(80, 45);
            this.chkStalem.Name = "chkStalem";
            this.chkStalem.Size = new System.Drawing.Size(58, 17);
            this.chkStalem.TabIndex = 5;
            this.chkStalem.Text = "Stalem";
            this.chkStalem.UseVisualStyleBackColor = true;
            this.chkStalem.CheckedChanged += new System.EventHandler(this.chkStalem_CheckedChanged);
            // 
            // chkMate
            // 
            this.chkMate.AutoSize = true;
            this.chkMate.Location = new System.Drawing.Point(17, 45);
            this.chkMate.Name = "chkMate";
            this.chkMate.Size = new System.Drawing.Size(50, 17);
            this.chkMate.TabIndex = 4;
            this.chkMate.Text = "Mate";
            this.chkMate.UseVisualStyleBackColor = true;
            this.chkMate.CheckedChanged += new System.EventHandler(this.chkMate_CheckedChanged);
            // 
            // txtTournament
            // 
            this.txtTournament.Location = new System.Drawing.Point(121, 83);
            this.txtTournament.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTournament.MaxLength = 40;
            this.txtTournament.Name = "txtTournament";
            this.txtTournament.Size = new System.Drawing.Size(137, 20);
            this.txtTournament.TabIndex = 30;
            this.txtTournament.TextChanged += new System.EventHandler(this.txtTournament_TextChanged);
            // 
            // txtBlack2
            // 
            this.txtBlack2.Location = new System.Drawing.Point(280, 43);
            this.txtBlack2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBlack2.MaxLength = 20;
            this.txtBlack2.Name = "txtBlack2";
            this.txtBlack2.Size = new System.Drawing.Size(137, 20);
            this.txtBlack2.TabIndex = 28;
            this.txtBlack2.TextChanged += new System.EventHandler(this.txtBlack2_TextChanged);
            // 
            // txtBlack1
            // 
            this.txtBlack1.Location = new System.Drawing.Point(121, 43);
            this.txtBlack1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBlack1.MaxLength = 30;
            this.txtBlack1.Name = "txtBlack1";
            this.txtBlack1.Size = new System.Drawing.Size(137, 20);
            this.txtBlack1.TabIndex = 27;
            this.txtBlack1.TextChanged += new System.EventHandler(this.txtBlack1_TextChanged);
            // 
            // txtWhite2
            // 
            this.txtWhite2.Location = new System.Drawing.Point(280, 17);
            this.txtWhite2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWhite2.MaxLength = 20;
            this.txtWhite2.Name = "txtWhite2";
            this.txtWhite2.Size = new System.Drawing.Size(137, 20);
            this.txtWhite2.TabIndex = 26;
            this.txtWhite2.TextChanged += new System.EventHandler(this.txtWhite2_TextChanged);
            // 
            // txtWhite1
            // 
            this.txtWhite1.Location = new System.Drawing.Point(121, 17);
            this.txtWhite1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWhite1.MaxLength = 30;
            this.txtWhite1.Name = "txtWhite1";
            this.txtWhite1.Size = new System.Drawing.Size(137, 20);
            this.txtWhite1.TabIndex = 24;
            this.txtWhite1.TextChanged += new System.EventHandler(this.txtWhite1_TextChanged);
            // 
            // lblTournament
            // 
            this.lblTournament.AutoSize = true;
            this.lblTournament.Location = new System.Drawing.Point(55, 90);
            this.lblTournament.Name = "lblTournament";
            this.lblTournament.Size = new System.Drawing.Size(64, 13);
            this.lblTournament.TabIndex = 35;
            this.lblTournament.Text = "Tournament";
            // 
            // lblBlack2
            // 
            this.lblBlack2.AutoSize = true;
            this.lblBlack2.Location = new System.Drawing.Point(264, 50);
            this.lblBlack2.Name = "lblBlack2";
            this.lblBlack2.Size = new System.Drawing.Size(10, 13);
            this.lblBlack2.TabIndex = 34;
            this.lblBlack2.Text = ",";
            // 
            // lblBlack1
            // 
            this.lblBlack1.AutoSize = true;
            this.lblBlack1.Location = new System.Drawing.Point(55, 50);
            this.lblBlack1.Name = "lblBlack1";
            this.lblBlack1.Size = new System.Drawing.Size(34, 13);
            this.lblBlack1.TabIndex = 31;
            this.lblBlack1.Text = "Black";
            // 
            // lblWhite2
            // 
            this.lblWhite2.AutoSize = true;
            this.lblWhite2.Location = new System.Drawing.Point(264, 24);
            this.lblWhite2.Name = "lblWhite2";
            this.lblWhite2.Size = new System.Drawing.Size(10, 13);
            this.lblWhite2.TabIndex = 29;
            this.lblWhite2.Text = ",";
            // 
            // lblWhite1
            // 
            this.lblWhite1.AutoSize = true;
            this.lblWhite1.Location = new System.Drawing.Point(55, 24);
            this.lblWhite1.Name = "lblWhite1";
            this.lblWhite1.Size = new System.Drawing.Size(35, 13);
            this.lblWhite1.TabIndex = 25;
            this.lblWhite1.Text = "White";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkPosition);
            this.panel1.Controls.Add(this.chkGameData);
            this.panel1.Controls.Add(this.btnHelp);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 543);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 40);
            this.panel1.TabIndex = 1;
            // 
            // chkPosition
            // 
            this.chkPosition.AutoSize = true;
            this.chkPosition.Location = new System.Drawing.Point(33, 11);
            this.chkPosition.Name = "chkPosition";
            this.chkPosition.Size = new System.Drawing.Size(63, 17);
            this.chkPosition.TabIndex = 124;
            this.chkPosition.Text = "Position";
            this.chkPosition.UseVisualStyleBackColor = true;
            this.chkPosition.CheckedChanged += new System.EventHandler(this.chkPosition_CheckedChanged);
            // 
            // chkGameData
            // 
            this.chkGameData.AutoSize = true;
            this.chkGameData.Location = new System.Drawing.Point(104, 11);
            this.chkGameData.Name = "chkGameData";
            this.chkGameData.Size = new System.Drawing.Size(77, 17);
            this.chkGameData.TabIndex = 122;
            this.chkGameData.Text = "GameData";
            this.chkGameData.UseVisualStyleBackColor = true;
            this.chkGameData.CheckedChanged += new System.EventHandler(this.chkGameData_CheckedChanged);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(582, 8);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 22);
            this.btnHelp.TabIndex = 6;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(501, 8);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(420, 8);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 22);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // GameSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 583);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSearch";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Games";
            this.tabControl1.ResumeLayout(false);
            this.GameData.ResumeLayout(false);
            this.GameData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMoves2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMoves1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear2)).EndInit();
            this.groupBoxElo.ResumeLayout(false);
            this.groupBoxElo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numElo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numElo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear1)).EndInit();
            this.groupBoxResult.ResumeLayout(false);
            this.groupBoxResult.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage GameData;
        private System.Windows.Forms.TabPage Position;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.NumericUpDown numYear1;
        private System.Windows.Forms.CheckBox chkYear;
        private System.Windows.Forms.GroupBox groupBoxResult;
        private System.Windows.Forms.TextBox txtTournament;
        private System.Windows.Forms.TextBox txtBlack2;
        private System.Windows.Forms.TextBox txtBlack1;
        private System.Windows.Forms.TextBox txtWhite2;
        private System.Windows.Forms.TextBox txtWhite1;
        private System.Windows.Forms.Label lblTournament;
        private System.Windows.Forms.Label lblBlack2;
        private System.Windows.Forms.Label lblBlack1;
        private System.Windows.Forms.Label lblWhite2;
        private System.Windows.Forms.Label lblWhite1;
        private System.Windows.Forms.CheckBox chkPosition;
        private System.Windows.Forms.CheckBox chkGameData;
        private System.Windows.Forms.CheckBox chkMate;
        private System.Windows.Forms.CheckBox chkCheck;
        private System.Windows.Forms.CheckBox chkStalem;
        private System.Windows.Forms.CheckBox chkLost;
        private System.Windows.Forms.CheckBox chkDraw;
        private System.Windows.Forms.CheckBox chkWin;
        private System.Windows.Forms.GroupBox groupBoxElo;
        private System.Windows.Forms.RadioButton rdbtnAverage;
        private System.Windows.Forms.RadioButton rdbtnBoth;
        private System.Windows.Forms.RadioButton rdbtnOne;
        private System.Windows.Forms.RadioButton rdbtnNone;
        private System.Windows.Forms.Label lblDash;
        private System.Windows.Forms.CheckBox chkMoves;
        private System.Windows.Forms.CheckBox chkEco;
        private System.Windows.Forms.TextBox txtEco2;
        private System.Windows.Forms.TextBox txtEco1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numYear2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numMoves2;
        private System.Windows.Forms.NumericUpDown numMoves1;
        private System.Windows.Forms.NumericUpDown numElo2;
        private System.Windows.Forms.NumericUpDown numElo1;
    }
}