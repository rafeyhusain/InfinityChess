namespace App.Win
{
    partial class TournamentUc
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentUc));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tbsbStartTournament = new System.Windows.Forms.ToolStripButton();
            this.tsbFinishTournament = new System.Windows.Forms.ToolStripButton();
            this.tsbRescheduleTask = new System.Windows.Forms.ToolStripSplitButton();
            this.reScheduleTournamentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbDblRound = new System.Windows.Forms.ComboBox();
            this.lblDblRound = new System.Windows.Forms.Label();
            this.cmbRound = new System.Windows.Forms.ComboBox();
            this.pnlCommonItems = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtInvitation = new System.Windows.Forms.TextBox();
            this.lblTournamentDirector = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTDName = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpTournamentStartTime = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpTournamentStartDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpRegStartDate = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpRegEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpRegEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpRegStartTime = new System.Windows.Forms.DateTimePicker();
            this.pnlKoItems = new System.Windows.Forms.Panel();
            this.numMaxWinners = new System.Windows.Forms.NumericUpDown();
            this.lblMaxWinners = new System.Windows.Forms.Label();
            this.chkAllowMultipleWinners = new System.Windows.Forms.CheckBox();
            this.cmbTbMin = new System.Windows.Forms.ComboBox();
            this.cmbTbSec = new System.Windows.Forms.ComboBox();
            this.lblTbTime = new System.Windows.Forms.Label();
            this.lblTbMin = new System.Windows.Forms.Label();
            this.numGames = new System.Windows.Forms.NumericUpDown();
            this.lblSuddenDeath = new System.Windows.Forms.Label();
            this.lblNoOfGamesPerRound = new System.Windows.Forms.Label();
            this.lblNoOfTieBreaks = new System.Windows.Forms.Label();
            this.numTieBreaks = new System.Windows.Forms.NumericUpDown();
            this.lblBlackTime = new System.Windows.Forms.Label();
            this.cmbWhiteMin = new System.Windows.Forms.ComboBox();
            this.cmbSdSec = new System.Windows.Forms.ComboBox();
            this.cmbBlackMin = new System.Windows.Forms.ComboBox();
            this.lblWhiteTime = new System.Windows.Forms.Label();
            this.lblWhiteMin = new System.Windows.Forms.Label();
            this.lblBlackMin = new System.Windows.Forms.Label();
            this.lblTbSec = new System.Windows.Forms.Label();
            this.lblSdSec = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.cmbSec = new System.Windows.Forms.ComboBox();
            this.cmbMin = new System.Windows.Forms.ComboBox();
            this.chkAllowTieBreak = new System.Windows.Forms.CheckBox();
            this.chkDoubleRound = new System.Windows.Forms.CheckBox();
            this.chkRated = new System.Windows.Forms.CheckBox();
            this.cmbChessType = new System.Windows.Forms.ComboBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlCommonItems.SuspendLayout();
            this.pnlKoItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxWinners)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTieBreaks)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.tbsbStartTournament,
            this.tsbFinishTournament,
            this.tsbRescheduleTask});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(472, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSave
            // 
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(51, 22);
            this.tsbSave.Text = "Save";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tbsbStartTournament
            // 
            this.tbsbStartTournament.Image = ((System.Drawing.Image)(resources.GetObject("tbsbStartTournament.Image")));
            this.tbsbStartTournament.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbsbStartTournament.Name = "tbsbStartTournament";
            this.tbsbStartTournament.Size = new System.Drawing.Size(112, 22);
            this.tbsbStartTournament.Text = "Start Tournament";
            this.tbsbStartTournament.Click += new System.EventHandler(this.tbsbStartTournament_Click);
            // 
            // tsbFinishTournament
            // 
            this.tsbFinishTournament.Image = ((System.Drawing.Image)(resources.GetObject("tsbFinishTournament.Image")));
            this.tsbFinishTournament.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFinishTournament.Name = "tsbFinishTournament";
            this.tsbFinishTournament.Size = new System.Drawing.Size(115, 22);
            this.tsbFinishTournament.Text = "Finish Tournament";
            this.tsbFinishTournament.Click += new System.EventHandler(this.tsbFinishTournament_Click);
            // 
            // tsbRescheduleTask
            // 
            this.tsbRescheduleTask.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRescheduleTask.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reScheduleTournamentToolStripMenuItem});
            this.tsbRescheduleTask.Image = ((System.Drawing.Image)(resources.GetObject("tsbRescheduleTask.Image")));
            this.tsbRescheduleTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRescheduleTask.Name = "tsbRescheduleTask";
            this.tsbRescheduleTask.Size = new System.Drawing.Size(45, 22);
            this.tsbRescheduleTask.Text = "Task";
            this.tsbRescheduleTask.Visible = false;
            // 
            // reScheduleTournamentToolStripMenuItem
            // 
            this.reScheduleTournamentToolStripMenuItem.Name = "reScheduleTournamentToolStripMenuItem";
            this.reScheduleTournamentToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.reScheduleTournamentToolStripMenuItem.Text = "Re-Schedule Tournament";
            this.reScheduleTournamentToolStripMenuItem.Click += new System.EventHandler(this.reScheduleTournamentToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.cmbDblRound);
            this.panel3.Controls.Add(this.lblDblRound);
            this.panel3.Controls.Add(this.cmbRound);
            this.panel3.Controls.Add(this.pnlCommonItems);
            this.panel3.Controls.Add(this.pnlKoItems);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtTitle);
            this.panel3.Controls.Add(this.cmbSec);
            this.panel3.Controls.Add(this.cmbMin);
            this.panel3.Controls.Add(this.chkAllowTieBreak);
            this.panel3.Controls.Add(this.chkDoubleRound);
            this.panel3.Controls.Add(this.chkRated);
            this.panel3.Controls.Add(this.cmbChessType);
            this.panel3.Controls.Add(this.cmbType);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(472, 478);
            this.panel3.TabIndex = 6;
            // 
            // cmbDblRound
            // 
            this.cmbDblRound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDblRound.FormattingEnabled = true;
            this.cmbDblRound.Location = new System.Drawing.Point(264, 83);
            this.cmbDblRound.Name = "cmbDblRound";
            this.cmbDblRound.Size = new System.Drawing.Size(43, 21);
            this.cmbDblRound.TabIndex = 54;
            // 
            // lblDblRound
            // 
            this.lblDblRound.AutoSize = true;
            this.lblDblRound.Location = new System.Drawing.Point(183, 88);
            this.lblDblRound.Name = "lblDblRound";
            this.lblDblRound.Size = new System.Drawing.Size(76, 13);
            this.lblDblRound.TabIndex = 53;
            this.lblDblRound.Text = "Double Round";
            // 
            // cmbRound
            // 
            this.cmbRound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRound.FormattingEnabled = true;
            this.cmbRound.Location = new System.Drawing.Point(398, 58);
            this.cmbRound.Name = "cmbRound";
            this.cmbRound.Size = new System.Drawing.Size(55, 21);
            this.cmbRound.TabIndex = 4;
            // 
            // pnlCommonItems
            // 
            this.pnlCommonItems.Controls.Add(this.label7);
            this.pnlCommonItems.Controls.Add(this.txtInvitation);
            this.pnlCommonItems.Controls.Add(this.lblTournamentDirector);
            this.pnlCommonItems.Controls.Add(this.label8);
            this.pnlCommonItems.Controls.Add(this.lblTDName);
            this.pnlCommonItems.Controls.Add(this.label9);
            this.pnlCommonItems.Controls.Add(this.dtpTournamentStartTime);
            this.pnlCommonItems.Controls.Add(this.label10);
            this.pnlCommonItems.Controls.Add(this.dtpTournamentStartDate);
            this.pnlCommonItems.Controls.Add(this.label12);
            this.pnlCommonItems.Controls.Add(this.label13);
            this.pnlCommonItems.Controls.Add(this.dtpRegStartDate);
            this.pnlCommonItems.Controls.Add(this.label14);
            this.pnlCommonItems.Controls.Add(this.dtpRegEndDate);
            this.pnlCommonItems.Controls.Add(this.dtpRegEndTime);
            this.pnlCommonItems.Controls.Add(this.dtpRegStartTime);
            this.pnlCommonItems.Location = new System.Drawing.Point(7, 270);
            this.pnlCommonItems.Name = "pnlCommonItems";
            this.pnlCommonItems.Size = new System.Drawing.Size(460, 204);
            this.pnlCommonItems.TabIndex = 52;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Registration Start Date";
            // 
            // txtInvitation
            // 
            this.txtInvitation.Location = new System.Drawing.Point(120, 90);
            this.txtInvitation.Multiline = true;
            this.txtInvitation.Name = "txtInvitation";
            this.txtInvitation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInvitation.Size = new System.Drawing.Size(327, 80);
            this.txtInvitation.TabIndex = 15;
            // 
            // lblTournamentDirector
            // 
            this.lblTournamentDirector.AutoSize = true;
            this.lblTournamentDirector.Location = new System.Drawing.Point(5, 177);
            this.lblTournamentDirector.Name = "lblTournamentDirector";
            this.lblTournamentDirector.Size = new System.Drawing.Size(104, 13);
            this.lblTournamentDirector.TabIndex = 35;
            this.lblTournamentDirector.Text = "Tournament Director";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(339, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Time";
            // 
            // lblTDName
            // 
            this.lblTDName.Location = new System.Drawing.Point(120, 177);
            this.lblTDName.Name = "lblTDName";
            this.lblTDName.Size = new System.Drawing.Size(262, 21);
            this.lblTDName.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Registration End Date";
            // 
            // dtpTournamentStartTime
            // 
            this.dtpTournamentStartTime.CustomFormat = "hh:mm tt";
            this.dtpTournamentStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTournamentStartTime.Location = new System.Drawing.Point(370, 62);
            this.dtpTournamentStartTime.Name = "dtpTournamentStartTime";
            this.dtpTournamentStartTime.ShowUpDown = true;
            this.dtpTournamentStartTime.Size = new System.Drawing.Size(79, 20);
            this.dtpTournamentStartTime.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(339, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Time";
            // 
            // dtpTournamentStartDate
            // 
            this.dtpTournamentStartDate.Location = new System.Drawing.Point(120, 62);
            this.dtpTournamentStartDate.Name = "dtpTournamentStartDate";
            this.dtpTournamentStartDate.Size = new System.Drawing.Size(200, 20);
            this.dtpTournamentStartDate.TabIndex = 13;
            this.dtpTournamentStartDate.Value = new System.DateTime(2010, 8, 24, 0, 0, 0, 0);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(65, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Invitation";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(339, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "Time";
            // 
            // dtpRegStartDate
            // 
            this.dtpRegStartDate.Location = new System.Drawing.Point(120, 4);
            this.dtpRegStartDate.Name = "dtpRegStartDate";
            this.dtpRegStartDate.Size = new System.Drawing.Size(200, 20);
            this.dtpRegStartDate.TabIndex = 9;
            this.dtpRegStartDate.Value = new System.DateTime(2010, 8, 24, 0, 0, 0, 0);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(115, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "Tournament Start Date";
            // 
            // dtpRegEndDate
            // 
            this.dtpRegEndDate.Location = new System.Drawing.Point(120, 33);
            this.dtpRegEndDate.Name = "dtpRegEndDate";
            this.dtpRegEndDate.Size = new System.Drawing.Size(200, 20);
            this.dtpRegEndDate.TabIndex = 11;
            this.dtpRegEndDate.Value = new System.DateTime(2010, 8, 24, 0, 0, 0, 0);
            // 
            // dtpRegEndTime
            // 
            this.dtpRegEndTime.CustomFormat = "hh:mm tt";
            this.dtpRegEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRegEndTime.Location = new System.Drawing.Point(370, 33);
            this.dtpRegEndTime.Name = "dtpRegEndTime";
            this.dtpRegEndTime.ShowUpDown = true;
            this.dtpRegEndTime.Size = new System.Drawing.Size(79, 20);
            this.dtpRegEndTime.TabIndex = 12;
            // 
            // dtpRegStartTime
            // 
            this.dtpRegStartTime.CustomFormat = "hh:mm tt";
            this.dtpRegStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRegStartTime.Location = new System.Drawing.Point(370, 4);
            this.dtpRegStartTime.Name = "dtpRegStartTime";
            this.dtpRegStartTime.ShowUpDown = true;
            this.dtpRegStartTime.Size = new System.Drawing.Size(79, 20);
            this.dtpRegStartTime.TabIndex = 10;
            // 
            // pnlKoItems
            // 
            this.pnlKoItems.Controls.Add(this.numMaxWinners);
            this.pnlKoItems.Controls.Add(this.lblMaxWinners);
            this.pnlKoItems.Controls.Add(this.chkAllowMultipleWinners);
            this.pnlKoItems.Controls.Add(this.cmbTbMin);
            this.pnlKoItems.Controls.Add(this.cmbTbSec);
            this.pnlKoItems.Controls.Add(this.lblTbTime);
            this.pnlKoItems.Controls.Add(this.lblTbMin);
            this.pnlKoItems.Controls.Add(this.numGames);
            this.pnlKoItems.Controls.Add(this.lblSuddenDeath);
            this.pnlKoItems.Controls.Add(this.lblNoOfGamesPerRound);
            this.pnlKoItems.Controls.Add(this.lblNoOfTieBreaks);
            this.pnlKoItems.Controls.Add(this.numTieBreaks);
            this.pnlKoItems.Controls.Add(this.lblBlackTime);
            this.pnlKoItems.Controls.Add(this.cmbWhiteMin);
            this.pnlKoItems.Controls.Add(this.cmbSdSec);
            this.pnlKoItems.Controls.Add(this.cmbBlackMin);
            this.pnlKoItems.Controls.Add(this.lblWhiteTime);
            this.pnlKoItems.Controls.Add(this.lblWhiteMin);
            this.pnlKoItems.Controls.Add(this.lblBlackMin);
            this.pnlKoItems.Controls.Add(this.lblTbSec);
            this.pnlKoItems.Controls.Add(this.lblSdSec);
            this.pnlKoItems.Location = new System.Drawing.Point(6, 111);
            this.pnlKoItems.Name = "pnlKoItems";
            this.pnlKoItems.Size = new System.Drawing.Size(460, 157);
            this.pnlKoItems.TabIndex = 51;
            // 
            // numMaxWinners
            // 
            this.numMaxWinners.Location = new System.Drawing.Point(120, 133);
            this.numMaxWinners.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numMaxWinners.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numMaxWinners.Name = "numMaxWinners";
            this.numMaxWinners.Size = new System.Drawing.Size(54, 20);
            this.numMaxWinners.TabIndex = 58;
            this.numMaxWinners.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lblMaxWinners
            // 
            this.lblMaxWinners.AutoSize = true;
            this.lblMaxWinners.Location = new System.Drawing.Point(14, 140);
            this.lblMaxWinners.Name = "lblMaxWinners";
            this.lblMaxWinners.Size = new System.Drawing.Size(75, 13);
            this.lblMaxWinners.TabIndex = 57;
            this.lblMaxWinners.Text = "Max. Winners ";
            // 
            // chkAllowMultipleWinners
            // 
            this.chkAllowMultipleWinners.AutoSize = true;
            this.chkAllowMultipleWinners.Location = new System.Drawing.Point(120, 113);
            this.chkAllowMultipleWinners.Name = "chkAllowMultipleWinners";
            this.chkAllowMultipleWinners.Size = new System.Drawing.Size(128, 17);
            this.chkAllowMultipleWinners.TabIndex = 56;
            this.chkAllowMultipleWinners.Text = "Allow multiple winners";
            this.chkAllowMultipleWinners.UseVisualStyleBackColor = true;
            this.chkAllowMultipleWinners.CheckedChanged += new System.EventHandler(this.chkAllowMultipleWinners_CheckedChanged);
            // 
            // cmbTbMin
            // 
            this.cmbTbMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTbMin.FormattingEnabled = true;
            this.cmbTbMin.Location = new System.Drawing.Point(214, 30);
            this.cmbTbMin.Name = "cmbTbMin";
            this.cmbTbMin.Size = new System.Drawing.Size(55, 21);
            this.cmbTbMin.TabIndex = 51;
            // 
            // cmbTbSec
            // 
            this.cmbTbSec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTbSec.FormattingEnabled = true;
            this.cmbTbSec.Location = new System.Drawing.Point(307, 30);
            this.cmbTbSec.Name = "cmbTbSec";
            this.cmbTbSec.Size = new System.Drawing.Size(62, 21);
            this.cmbTbSec.TabIndex = 52;
            // 
            // lblTbTime
            // 
            this.lblTbTime.AutoSize = true;
            this.lblTbTime.Location = new System.Drawing.Point(181, 34);
            this.lblTbTime.Name = "lblTbTime";
            this.lblTbTime.Size = new System.Drawing.Size(30, 13);
            this.lblTbTime.TabIndex = 53;
            this.lblTbTime.Text = "Time";
            // 
            // lblTbMin
            // 
            this.lblTbMin.AutoSize = true;
            this.lblTbMin.Location = new System.Drawing.Point(269, 34);
            this.lblTbMin.Name = "lblTbMin";
            this.lblTbMin.Size = new System.Drawing.Size(24, 13);
            this.lblTbMin.TabIndex = 54;
            this.lblTbMin.Text = "Min";
            // 
            // numGames
            // 
            this.numGames.Location = new System.Drawing.Point(120, 4);
            this.numGames.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGames.Name = "numGames";
            this.numGames.Size = new System.Drawing.Size(55, 20);
            this.numGames.TabIndex = 37;
            this.numGames.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblSuddenDeath
            // 
            this.lblSuddenDeath.AutoSize = true;
            this.lblSuddenDeath.Location = new System.Drawing.Point(13, 73);
            this.lblSuddenDeath.Name = "lblSuddenDeath";
            this.lblSuddenDeath.Size = new System.Drawing.Size(76, 13);
            this.lblSuddenDeath.TabIndex = 50;
            this.lblSuddenDeath.Text = "Sudden Death";
            // 
            // lblNoOfGamesPerRound
            // 
            this.lblNoOfGamesPerRound.AutoSize = true;
            this.lblNoOfGamesPerRound.Location = new System.Drawing.Point(18, 6);
            this.lblNoOfGamesPerRound.Name = "lblNoOfGamesPerRound";
            this.lblNoOfGamesPerRound.Size = new System.Drawing.Size(71, 13);
            this.lblNoOfGamesPerRound.TabIndex = 36;
            this.lblNoOfGamesPerRound.Text = "No Of Games";
            // 
            // lblNoOfTieBreaks
            // 
            this.lblNoOfTieBreaks.AutoSize = true;
            this.lblNoOfTieBreaks.Location = new System.Drawing.Point(4, 34);
            this.lblNoOfTieBreaks.Name = "lblNoOfTieBreaks";
            this.lblNoOfTieBreaks.Size = new System.Drawing.Size(89, 13);
            this.lblNoOfTieBreaks.TabIndex = 38;
            this.lblNoOfTieBreaks.Text = "No Of Tie Breaks";
            // 
            // numTieBreaks
            // 
            this.numTieBreaks.Location = new System.Drawing.Point(120, 30);
            this.numTieBreaks.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numTieBreaks.Name = "numTieBreaks";
            this.numTieBreaks.Size = new System.Drawing.Size(54, 20);
            this.numTieBreaks.TabIndex = 39;
            this.numTieBreaks.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTieBreaks.ValueChanged += new System.EventHandler(this.numTieBreaks_ValueChanged);
            // 
            // lblBlackTime
            // 
            this.lblBlackTime.AutoSize = true;
            this.lblBlackTime.Location = new System.Drawing.Point(151, 90);
            this.lblBlackTime.Name = "lblBlackTime";
            this.lblBlackTime.Size = new System.Drawing.Size(60, 13);
            this.lblBlackTime.TabIndex = 47;
            this.lblBlackTime.Text = "Black Time";
            // 
            // cmbWhiteMin
            // 
            this.cmbWhiteMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWhiteMin.FormattingEnabled = true;
            this.cmbWhiteMin.Location = new System.Drawing.Point(214, 58);
            this.cmbWhiteMin.Name = "cmbWhiteMin";
            this.cmbWhiteMin.Size = new System.Drawing.Size(55, 21);
            this.cmbWhiteMin.TabIndex = 40;
            // 
            // cmbSdSec
            // 
            this.cmbSdSec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSdSec.FormattingEnabled = true;
            this.cmbSdSec.Location = new System.Drawing.Point(305, 70);
            this.cmbSdSec.Name = "cmbSdSec";
            this.cmbSdSec.Size = new System.Drawing.Size(62, 21);
            this.cmbSdSec.TabIndex = 41;
            // 
            // cmbBlackMin
            // 
            this.cmbBlackMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBlackMin.FormattingEnabled = true;
            this.cmbBlackMin.Location = new System.Drawing.Point(214, 86);
            this.cmbBlackMin.Name = "cmbBlackMin";
            this.cmbBlackMin.Size = new System.Drawing.Size(55, 21);
            this.cmbBlackMin.TabIndex = 45;
            // 
            // lblWhiteTime
            // 
            this.lblWhiteTime.AutoSize = true;
            this.lblWhiteTime.Location = new System.Drawing.Point(150, 62);
            this.lblWhiteTime.Name = "lblWhiteTime";
            this.lblWhiteTime.Size = new System.Drawing.Size(61, 13);
            this.lblWhiteTime.TabIndex = 42;
            this.lblWhiteTime.Text = "White Time";
            // 
            // lblWhiteMin
            // 
            this.lblWhiteMin.AutoSize = true;
            this.lblWhiteMin.Location = new System.Drawing.Point(269, 62);
            this.lblWhiteMin.Name = "lblWhiteMin";
            this.lblWhiteMin.Size = new System.Drawing.Size(24, 13);
            this.lblWhiteMin.TabIndex = 43;
            this.lblWhiteMin.Text = "Min";
            // 
            // lblBlackMin
            // 
            this.lblBlackMin.AutoSize = true;
            this.lblBlackMin.Location = new System.Drawing.Point(269, 90);
            this.lblBlackMin.Name = "lblBlackMin";
            this.lblBlackMin.Size = new System.Drawing.Size(24, 13);
            this.lblBlackMin.TabIndex = 48;
            this.lblBlackMin.Text = "Min";
            // 
            // lblTbSec
            // 
            this.lblTbSec.AutoSize = true;
            this.lblTbSec.Location = new System.Drawing.Point(369, 34);
            this.lblTbSec.Name = "lblTbSec";
            this.lblTbSec.Size = new System.Drawing.Size(26, 13);
            this.lblTbSec.TabIndex = 55;
            this.lblTbSec.Text = "Sec";
            this.lblTbSec.Click += new System.EventHandler(this.lblTbWhiteSec_Click);
            // 
            // lblSdSec
            // 
            this.lblSdSec.AutoSize = true;
            this.lblSdSec.Location = new System.Drawing.Point(367, 78);
            this.lblSdSec.Name = "lblSdSec";
            this.lblSdSec.Size = new System.Drawing.Size(26, 13);
            this.lblSdSec.TabIndex = 44;
            this.lblSdSec.Text = "Sec";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(47, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Title";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(185, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Min";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Time Control";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Round";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(310, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Chess Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Type";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(126, 4);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(327, 20);
            this.txtTitle.TabIndex = 0;
            // 
            // cmbSec
            // 
            this.cmbSec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSec.FormattingEnabled = true;
            this.cmbSec.Location = new System.Drawing.Point(216, 58);
            this.cmbSec.Name = "cmbSec";
            this.cmbSec.Size = new System.Drawing.Size(62, 21);
            this.cmbSec.TabIndex = 8;
            // 
            // cmbMin
            // 
            this.cmbMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMin.FormattingEnabled = true;
            this.cmbMin.Location = new System.Drawing.Point(126, 57);
            this.cmbMin.Name = "cmbMin";
            this.cmbMin.Size = new System.Drawing.Size(55, 21);
            this.cmbMin.TabIndex = 7;
            this.cmbMin.SelectedIndexChanged += new System.EventHandler(this.cmbMin_SelectedIndexChanged);
            // 
            // chkAllowTieBreak
            // 
            this.chkAllowTieBreak.AutoSize = true;
            this.chkAllowTieBreak.Location = new System.Drawing.Point(353, 85);
            this.chkAllowTieBreak.Name = "chkAllowTieBreak";
            this.chkAllowTieBreak.Size = new System.Drawing.Size(100, 17);
            this.chkAllowTieBreak.TabIndex = 6;
            this.chkAllowTieBreak.Text = "Allow Tie Break";
            this.chkAllowTieBreak.UseVisualStyleBackColor = true;
            this.chkAllowTieBreak.CheckedChanged += new System.EventHandler(this.chkAllowTieBreak_CheckedChanged);
            // 
            // chkDoubleRound
            // 
            this.chkDoubleRound.AutoSize = true;
            this.chkDoubleRound.Location = new System.Drawing.Point(212, 88);
            this.chkDoubleRound.Name = "chkDoubleRound";
            this.chkDoubleRound.Size = new System.Drawing.Size(95, 17);
            this.chkDoubleRound.TabIndex = 5;
            this.chkDoubleRound.Text = "Double Round";
            this.chkDoubleRound.UseVisualStyleBackColor = true;
            // 
            // chkRated
            // 
            this.chkRated.AutoSize = true;
            this.chkRated.Location = new System.Drawing.Point(126, 87);
            this.chkRated.Name = "chkRated";
            this.chkRated.Size = new System.Drawing.Size(55, 17);
            this.chkRated.TabIndex = 3;
            this.chkRated.Text = "Rated";
            this.chkRated.UseVisualStyleBackColor = true;
            // 
            // cmbChessType
            // 
            this.cmbChessType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChessType.FormattingEnabled = true;
            this.cmbChessType.Location = new System.Drawing.Point(373, 31);
            this.cmbChessType.Name = "cmbChessType";
            this.cmbChessType.Size = new System.Drawing.Size(80, 21);
            this.cmbChessType.TabIndex = 2;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(126, 30);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(181, 21);
            this.cmbType.TabIndex = 1;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(281, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Sec";
            // 
            // TournamentUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.toolStrip1);
            this.Name = "TournamentUc";
            this.Size = new System.Drawing.Size(472, 503);
            this.Load += new System.EventHandler(this.TournamentUc_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlCommonItems.ResumeLayout(false);
            this.pnlCommonItems.PerformLayout();
            this.pnlKoItems.ResumeLayout(false);
            this.pnlKoItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxWinners)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTieBreaks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbFinishTournament;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInvitation;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.ComboBox cmbSec;
        private System.Windows.Forms.ComboBox cmbMin;
        private System.Windows.Forms.CheckBox chkAllowTieBreak;
        private System.Windows.Forms.CheckBox chkDoubleRound;
        private System.Windows.Forms.CheckBox chkRated;
        private System.Windows.Forms.ComboBox cmbRound;
        private System.Windows.Forms.ComboBox cmbChessType;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.DateTimePicker dtpRegEndDate;
        private System.Windows.Forms.DateTimePicker dtpRegStartDate;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tbsbStartTournament;
        private System.Windows.Forms.DateTimePicker dtpRegEndTime;
        private System.Windows.Forms.DateTimePicker dtpRegStartTime;
        private System.Windows.Forms.DateTimePicker dtpTournamentStartTime;
        private System.Windows.Forms.DateTimePicker dtpTournamentStartDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTournamentDirector;
        private System.Windows.Forms.Label lblTDName;
        private System.Windows.Forms.NumericUpDown numGames;
        private System.Windows.Forms.Label lblNoOfGamesPerRound;
        private System.Windows.Forms.NumericUpDown numTieBreaks;
        private System.Windows.Forms.Label lblNoOfTieBreaks;
        private System.Windows.Forms.Label lblSdSec;
        private System.Windows.Forms.Label lblWhiteMin;
        private System.Windows.Forms.Label lblWhiteTime;
        private System.Windows.Forms.ComboBox cmbSdSec;
        private System.Windows.Forms.ComboBox cmbWhiteMin;
        private System.Windows.Forms.Label lblSuddenDeath;
        private System.Windows.Forms.Label lblBlackMin;
        private System.Windows.Forms.Label lblBlackTime;
        private System.Windows.Forms.ComboBox cmbBlackMin;
        private System.Windows.Forms.Panel pnlKoItems;
        private System.Windows.Forms.Panel pnlCommonItems;
        private System.Windows.Forms.ToolStripSplitButton tsbRescheduleTask;
        private System.Windows.Forms.ToolStripMenuItem reScheduleTournamentToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbTbMin;
        private System.Windows.Forms.ComboBox cmbTbSec;
        private System.Windows.Forms.Label lblTbTime;
        private System.Windows.Forms.Label lblTbSec;
        private System.Windows.Forms.Label lblTbMin;
        private System.Windows.Forms.Label lblDblRound;
        private System.Windows.Forms.ComboBox cmbDblRound;
        private System.Windows.Forms.CheckBox chkAllowMultipleWinners;
        private System.Windows.Forms.NumericUpDown numMaxWinners;
        private System.Windows.Forms.Label lblMaxWinners;

    }
}
