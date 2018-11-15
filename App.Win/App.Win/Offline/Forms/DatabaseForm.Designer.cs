namespace InfinityChess.WinForms
{
    partial class DatabaseForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseForm));
            this.GameGridView = new System.Windows.Forms.DataGridView();
            this.Guid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Players = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tournament = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ECO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Variation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Moves = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripFilePaths = new System.Windows.Forms.ToolStrip();
            this.cmboDatabaseFilePaths = new System.Windows.Forms.ToolStripComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbCreateNewDatabase = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tsbAppendGame = new System.Windows.Forms.ToolStripButton();
            this.tsbReplaceGame = new System.Windows.Forms.ToolStripButton();
            this.tsbActivateGameWindow = new System.Windows.Forms.ToolStripButton();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDatabaseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.gotoInfiChessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editGameDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gotoLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator37 = new System.Windows.Forms.ToolStripSeparator();
            this.hintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suggestionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator38 = new System.Windows.Forms.ToolStripSeparator();
            this.explaneAllMovesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator39 = new System.Windows.Forms.ToolStripSeparator();
            this.coachIsWatchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dynamicHintsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openingHintsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.threatenedSquaresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator40 = new System.Windows.Forms.ToolStripSeparator();
            this.toInfinityChesscomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutFritToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ofdOpenDatabase = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.GameGridView)).BeginInit();
            this.toolStripFilePaths.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameGridView
            // 
            this.GameGridView.AllowUserToAddRows = false;
            this.GameGridView.AllowUserToResizeColumns = false;
            this.GameGridView.AllowUserToResizeRows = false;
            this.GameGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GameGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.GameGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GameGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GameGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GameGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GameGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Guid,
            this.SerialNumber,
            this.Players,
            this.Tournament,
            this.ECO,
            this.Year,
            this.Result,
            this.Variation,
            this.Moves});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GameGridView.DefaultCellStyle = dataGridViewCellStyle5;
            this.GameGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameGridView.Location = new System.Drawing.Point(3, 3);
            this.GameGridView.MultiSelect = false;
            this.GameGridView.Name = "GameGridView";
            this.GameGridView.ReadOnly = true;
            this.GameGridView.RowHeadersVisible = false;
            this.GameGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.GameGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GameGridView.Size = new System.Drawing.Size(720, 332);
            this.GameGridView.TabIndex = 0;
            this.GameGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GameGridView_CellDoubleClick);
            // 
            // Guid
            // 
            this.Guid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Guid.DataPropertyName = "Guid";
            this.Guid.FillWeight = 5F;
            this.Guid.HeaderText = "Guid";
            this.Guid.Name = "Guid";
            this.Guid.ReadOnly = true;
            this.Guid.Visible = false;
            this.Guid.Width = 5;
            // 
            // SerialNumber
            // 
            this.SerialNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SerialNumber.DataPropertyName = "SNo";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SerialNumber.DefaultCellStyle = dataGridViewCellStyle2;
            this.SerialNumber.HeaderText = "";
            this.SerialNumber.MinimumWidth = 35;
            this.SerialNumber.Name = "SerialNumber";
            this.SerialNumber.ReadOnly = true;
            this.SerialNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SerialNumber.Width = 35;
            // 
            // Players
            // 
            this.Players.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Players.DataPropertyName = "Players";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Players.DefaultCellStyle = dataGridViewCellStyle3;
            this.Players.FillWeight = 71.57458F;
            this.Players.HeaderText = "Players";
            this.Players.Name = "Players";
            this.Players.ReadOnly = true;
            this.Players.Width = 400;
            // 
            // Tournament
            // 
            this.Tournament.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Tournament.DataPropertyName = "Tournament";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tournament.DefaultCellStyle = dataGridViewCellStyle4;
            this.Tournament.FillWeight = 228.4295F;
            this.Tournament.HeaderText = "Tournament";
            this.Tournament.Name = "Tournament";
            this.Tournament.ReadOnly = true;
            this.Tournament.Width = 350;
            // 
            // ECO
            // 
            this.ECO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ECO.DataPropertyName = "ECO";
            this.ECO.HeaderText = "ECO";
            this.ECO.Name = "ECO";
            this.ECO.ReadOnly = true;
            this.ECO.Width = 50;
            // 
            // Year
            // 
            this.Year.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Year.DataPropertyName = "Year";
            this.Year.HeaderText = "Year";
            this.Year.Name = "Year";
            this.Year.ReadOnly = true;
            this.Year.Width = 50;
            // 
            // Result
            // 
            this.Result.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Result.DataPropertyName = "Result";
            this.Result.HeaderText = "Result";
            this.Result.Name = "Result";
            this.Result.ReadOnly = true;
            this.Result.Width = 60;
            // 
            // Variation
            // 
            this.Variation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Variation.DataPropertyName = "Variation";
            this.Variation.HeaderText = "Variation";
            this.Variation.Name = "Variation";
            this.Variation.ReadOnly = true;
            this.Variation.Width = 90;
            // 
            // Moves
            // 
            this.Moves.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Moves.DataPropertyName = "Moves";
            this.Moves.HeaderText = "Moves";
            this.Moves.Name = "Moves";
            this.Moves.ReadOnly = true;
            // 
            // toolStripFilePaths
            // 
            this.toolStripFilePaths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripFilePaths.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmboDatabaseFilePaths});
            this.toolStripFilePaths.Location = new System.Drawing.Point(484, 0);
            this.toolStripFilePaths.Name = "toolStripFilePaths";
            this.toolStripFilePaths.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripFilePaths.Size = new System.Drawing.Size(250, 30);
            this.toolStripFilePaths.TabIndex = 2;
            this.toolStripFilePaths.Text = "toolStrip2";
            // 
            // cmboDatabaseFilePaths
            // 
            this.cmboDatabaseFilePaths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboDatabaseFilePaths.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cmboDatabaseFilePaths.Name = "cmboDatabaseFilePaths";
            this.cmboDatabaseFilePaths.Size = new System.Drawing.Size(200, 30);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(734, 394);
            this.panel2.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(734, 364);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.GameGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(726, 338);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Games";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.menuStrip, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.toolStripFilePaths, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(734, 30);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCreateNewDatabase,
            this.toolStripButton2,
            this.tsbAppendGame,
            this.tsbReplaceGame,
            this.tsbActivateGameWindow});
            this.toolStrip1.Location = new System.Drawing.Point(220, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(264, 30);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbCreateNewDatabase
            // 
            this.tsbCreateNewDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCreateNewDatabase.Image = ((System.Drawing.Image)(resources.GetObject("tsbCreateNewDatabase.Image")));
            this.tsbCreateNewDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCreateNewDatabase.Name = "tsbCreateNewDatabase";
            this.tsbCreateNewDatabase.Size = new System.Drawing.Size(23, 27);
            this.tsbCreateNewDatabase.Text = "Create a new database";
            this.tsbCreateNewDatabase.Click += new System.EventHandler(this.newDatabaseToolStripMenuItem1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 27);
            this.toolStripButton2.Text = "Open a database in this list window";
            this.toolStripButton2.Click += new System.EventHandler(this.openDatabaseToolStripMenuItem_Click);
            // 
            // tsbAppendGame
            // 
            this.tsbAppendGame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAppendGame.Image = ((System.Drawing.Image)(resources.GetObject("tsbAppendGame.Image")));
            this.tsbAppendGame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAppendGame.Name = "tsbAppendGame";
            this.tsbAppendGame.Size = new System.Drawing.Size(23, 27);
            this.tsbAppendGame.Text = "Append the game from the board window to this database";
            this.tsbAppendGame.Click += new System.EventHandler(this.tsbAppendGame_Click);
            // 
            // tsbReplaceGame
            // 
            this.tsbReplaceGame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbReplaceGame.Image = ((System.Drawing.Image)(resources.GetObject("tsbReplaceGame.Image")));
            this.tsbReplaceGame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReplaceGame.Name = "tsbReplaceGame";
            this.tsbReplaceGame.Size = new System.Drawing.Size(23, 27);
            this.tsbReplaceGame.Text = "Replace selected game in database";
            this.tsbReplaceGame.Click += new System.EventHandler(this.tsbReplaceGame_Click);
            // 
            // tsbActivateGameWindow
            // 
            this.tsbActivateGameWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbActivateGameWindow.Image = ((System.Drawing.Image)(resources.GetObject("tsbActivateGameWindow.Image")));
            this.tsbActivateGameWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbActivateGameWindow.Name = "tsbActivateGameWindow";
            this.tsbActivateGameWindow.Size = new System.Drawing.Size(23, 27);
            this.tsbActivateGameWindow.Text = "Activate game window";
            this.tsbActivateGameWindow.Click += new System.EventHandler(this.tsbActivateGameWindow_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(220, 30);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.gotoInfiChessToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(35, 26);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDatabaseToolStripMenuItem1});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // newDatabaseToolStripMenuItem1
            // 
            this.newDatabaseToolStripMenuItem1.Name = "newDatabaseToolStripMenuItem1";
            this.newDatabaseToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.newDatabaseToolStripMenuItem1.Text = "Database";
            this.newDatabaseToolStripMenuItem1.Click += new System.EventHandler(this.newDatabaseToolStripMenuItem1_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDatabaseToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // openDatabaseToolStripMenuItem
            // 
            this.openDatabaseToolStripMenuItem.Name = "openDatabaseToolStripMenuItem";
            this.openDatabaseToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.openDatabaseToolStripMenuItem.Text = "Database";
            this.openDatabaseToolStripMenuItem.Click += new System.EventHandler(this.openDatabaseToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(203, 6);
            // 
            // gotoInfiChessToolStripMenuItem
            // 
            this.gotoInfiChessToolStripMenuItem.Name = "gotoInfiChessToolStripMenuItem";
            this.gotoInfiChessToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.gotoInfiChessToolStripMenuItem.Text = "Goto InfinityChess WebSite";
            this.gotoInfiChessToolStripMenuItem.Click += new System.EventHandler(this.gotoInfiChessToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click_1);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editGameDataToolStripMenuItem,
            this.gotoLineToolStripMenuItem,
            this.filterToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 26);
            this.fileToolStripMenuItem.Text = "Edit";
            // 
            // editGameDataToolStripMenuItem
            // 
            this.editGameDataToolStripMenuItem.Name = "editGameDataToolStripMenuItem";
            this.editGameDataToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editGameDataToolStripMenuItem.Text = "Edit Game Data";
            this.editGameDataToolStripMenuItem.Click += new System.EventHandler(this.editGameDataToolStripMenuItem_Click);
            // 
            // gotoLineToolStripMenuItem
            // 
            this.gotoLineToolStripMenuItem.Name = "gotoLineToolStripMenuItem";
            this.gotoLineToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.gotoLineToolStripMenuItem.Text = "Goto line";
            this.gotoLineToolStripMenuItem.Click += new System.EventHandler(this.gotoLineToolStripMenuItem_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.filterToolStripMenuItem.Text = "Filter Games";
            this.filterToolStripMenuItem.Click += new System.EventHandler(this.filterToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.toolStripSeparator37,
            this.hintToolStripMenuItem,
            this.suggestionToolStripMenuItem,
            this.tToolStripMenuItem1,
            this.toolStripSeparator38,
            this.explaneAllMovesToolStripMenuItem,
            this.toolStripSeparator39,
            this.coachIsWatchingToolStripMenuItem,
            this.dynamicHintsToolStripMenuItem,
            this.openingHintsToolStripMenuItem,
            this.threatenedSquaresToolStripMenuItem,
            this.spyToolStripMenuItem,
            this.toolStripSeparator40,
            this.toInfinityChesscomToolStripMenuItem,
            this.registerToolStripMenuItem,
            this.aboutFritToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(43, 26);
            this.helpToolStripMenuItem.Text = " &Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(205, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // toolStripSeparator37
            // 
            this.toolStripSeparator37.Name = "toolStripSeparator37";
            this.toolStripSeparator37.Size = new System.Drawing.Size(202, 6);
            // 
            // hintToolStripMenuItem
            // 
            this.hintToolStripMenuItem.Name = "hintToolStripMenuItem";
            this.hintToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.hintToolStripMenuItem.Text = "Hint";
            this.hintToolStripMenuItem.Visible = false;
            // 
            // suggestionToolStripMenuItem
            // 
            this.suggestionToolStripMenuItem.Enabled = false;
            this.suggestionToolStripMenuItem.Name = "suggestionToolStripMenuItem";
            this.suggestionToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.suggestionToolStripMenuItem.Text = "Suggestion";
            this.suggestionToolStripMenuItem.Visible = false;
            // 
            // tToolStripMenuItem1
            // 
            this.tToolStripMenuItem1.Enabled = false;
            this.tToolStripMenuItem1.Name = "tToolStripMenuItem1";
            this.tToolStripMenuItem1.Size = new System.Drawing.Size(205, 22);
            this.tToolStripMenuItem1.Text = "Threat";
            this.tToolStripMenuItem1.Visible = false;
            // 
            // toolStripSeparator38
            // 
            this.toolStripSeparator38.Name = "toolStripSeparator38";
            this.toolStripSeparator38.Size = new System.Drawing.Size(202, 6);
            this.toolStripSeparator38.Visible = false;
            // 
            // explaneAllMovesToolStripMenuItem
            // 
            this.explaneAllMovesToolStripMenuItem.Enabled = false;
            this.explaneAllMovesToolStripMenuItem.Name = "explaneAllMovesToolStripMenuItem";
            this.explaneAllMovesToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.explaneAllMovesToolStripMenuItem.Text = "Explane All Moves";
            this.explaneAllMovesToolStripMenuItem.Visible = false;
            // 
            // toolStripSeparator39
            // 
            this.toolStripSeparator39.Name = "toolStripSeparator39";
            this.toolStripSeparator39.Size = new System.Drawing.Size(202, 6);
            this.toolStripSeparator39.Visible = false;
            // 
            // coachIsWatchingToolStripMenuItem
            // 
            this.coachIsWatchingToolStripMenuItem.Enabled = false;
            this.coachIsWatchingToolStripMenuItem.Name = "coachIsWatchingToolStripMenuItem";
            this.coachIsWatchingToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.coachIsWatchingToolStripMenuItem.Text = "Coach is Watching";
            this.coachIsWatchingToolStripMenuItem.Visible = false;
            // 
            // dynamicHintsToolStripMenuItem
            // 
            this.dynamicHintsToolStripMenuItem.Enabled = false;
            this.dynamicHintsToolStripMenuItem.Name = "dynamicHintsToolStripMenuItem";
            this.dynamicHintsToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.dynamicHintsToolStripMenuItem.Text = "Dynamic Hints..";
            this.dynamicHintsToolStripMenuItem.Visible = false;
            // 
            // openingHintsToolStripMenuItem
            // 
            this.openingHintsToolStripMenuItem.Enabled = false;
            this.openingHintsToolStripMenuItem.Name = "openingHintsToolStripMenuItem";
            this.openingHintsToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.openingHintsToolStripMenuItem.Text = "Opening Hints..";
            this.openingHintsToolStripMenuItem.Visible = false;
            // 
            // threatenedSquaresToolStripMenuItem
            // 
            this.threatenedSquaresToolStripMenuItem.Enabled = false;
            this.threatenedSquaresToolStripMenuItem.Name = "threatenedSquaresToolStripMenuItem";
            this.threatenedSquaresToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.threatenedSquaresToolStripMenuItem.Text = "Threatened Squares";
            this.threatenedSquaresToolStripMenuItem.Visible = false;
            // 
            // spyToolStripMenuItem
            // 
            this.spyToolStripMenuItem.Enabled = false;
            this.spyToolStripMenuItem.Name = "spyToolStripMenuItem";
            this.spyToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.spyToolStripMenuItem.Text = "Spy...";
            this.spyToolStripMenuItem.Visible = false;
            // 
            // toolStripSeparator40
            // 
            this.toolStripSeparator40.Name = "toolStripSeparator40";
            this.toolStripSeparator40.Size = new System.Drawing.Size(202, 6);
            this.toolStripSeparator40.Visible = false;
            // 
            // toInfinityChesscomToolStripMenuItem
            // 
            this.toInfinityChesscomToolStripMenuItem.Name = "toInfinityChesscomToolStripMenuItem";
            this.toInfinityChesscomToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.toInfinityChesscomToolStripMenuItem.Text = "Goto InfinityChess Website";
            this.toInfinityChesscomToolStripMenuItem.Click += new System.EventHandler(this.gotoInfiChessToolStripMenuItem_Click);
            // 
            // registerToolStripMenuItem
            // 
            this.registerToolStripMenuItem.Enabled = false;
            this.registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            this.registerToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.registerToolStripMenuItem.Text = "Register...";
            this.registerToolStripMenuItem.Visible = false;
            // 
            // aboutFritToolStripMenuItem
            // 
            this.aboutFritToolStripMenuItem.Name = "aboutFritToolStripMenuItem";
            this.aboutFritToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.aboutFritToolStripMenuItem.Text = "About InfinityChess...";
            this.aboutFritToolStripMenuItem.Click += new System.EventHandler(this.aboutInfinityChessToolStripMenuItem_Click);
            // 
            // ofdOpenDatabase
            // 
            this.ofdOpenDatabase.FileName = "*.icg";
            // 
            // DatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 394);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DatabaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DatabaseForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DatabaseForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.GameGridView)).EndInit();
            this.toolStripFilePaths.ResumeLayout(false);
            this.toolStripFilePaths.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripFilePaths;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.DataGridView GameGridView;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDatabaseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editGameDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gotoLineToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripComboBox cmboDatabaseFilePaths;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbCreateNewDatabase;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton tsbAppendGame;
        private System.Windows.Forms.ToolStripButton tsbReplaceGame;
        private System.Windows.Forms.ToolStripButton tsbActivateGameWindow;
        private System.Windows.Forms.OpenFileDialog ofdOpenDatabase;
        private System.Windows.Forms.ToolStripMenuItem gotoInfiChessToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator37;
        private System.Windows.Forms.ToolStripMenuItem hintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suggestionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator38;
        private System.Windows.Forms.ToolStripMenuItem explaneAllMovesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator39;
        private System.Windows.Forms.ToolStripMenuItem coachIsWatchingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dynamicHintsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openingHintsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem threatenedSquaresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator40;
        private System.Windows.Forms.ToolStripMenuItem toInfinityChesscomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutFritToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Guid;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Players;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tournament;
        private System.Windows.Forms.DataGridViewTextBoxColumn ECO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn Variation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Moves;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
    }
}