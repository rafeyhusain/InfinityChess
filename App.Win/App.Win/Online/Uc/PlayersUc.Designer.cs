namespace App.Win
{
    partial class PlayersUc
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayersUc));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.followToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.viewRatingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.challengeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmBan = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiKickUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.blockIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blockMachineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonChallenge = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFollow = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPicture = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRating = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.tsRefresh = new System.Windows.Forms.ToolStripButton();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RankImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BulletElo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BlitzElo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RapidElo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LongElo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FideTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IccfTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nation = new System.Windows.Forms.DataGridViewImageColumn();
            this.Engine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Internet = new System.Windows.Forms.DataGridViewImageColumn();
            this.GameID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Social = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InternetToolTip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserStatusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsPause = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsIdle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserID,
            this.RankImage,
            this.UserName,
            this.TeamName,
            this.Status,
            this.BulletElo,
            this.BlitzElo,
            this.RapidElo,
            this.LongElo,
            this.FideTitle,
            this.IccfTitle,
            this.CountryID,
            this.Nation,
            this.Engine,
            this.Rank,
            this.Internet,
            this.GameID,
            this.Social,
            this.InternetToolTip,
            this.CountryName,
            this.UserStatusID,
            this.IsPause,
            this.IsIdle,
            this.RoleID,
            this.Empty});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1028, 91);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.followToolStripMenuItem,
            this.toolStripSeparator4,
            this.viewRatingToolStripMenuItem,
            this.challengeToolStripMenuItem1,
            this.pictureToolStripMenuItem1,
            this.toolStripSeparator1,
            this.tsmBan,
            this.tsmiKickUser,
            this.toolStripSeparator2,
            this.blockIPToolStripMenuItem,
            this.blockMachineToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(141, 198);
            // 
            // followToolStripMenuItem
            // 
            this.followToolStripMenuItem.Name = "followToolStripMenuItem";
            this.followToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.followToolStripMenuItem.Text = "Follow";
            this.followToolStripMenuItem.Click += new System.EventHandler(this.followToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(137, 6);
            // 
            // viewRatingToolStripMenuItem
            // 
            this.viewRatingToolStripMenuItem.Name = "viewRatingToolStripMenuItem";
            this.viewRatingToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.viewRatingToolStripMenuItem.Text = "View Rating";
            this.viewRatingToolStripMenuItem.Click += new System.EventHandler(this.viewRatingToolStripMenuItem_Click);
            // 
            // challengeToolStripMenuItem1
            // 
            this.challengeToolStripMenuItem1.Name = "challengeToolStripMenuItem1";
            this.challengeToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.challengeToolStripMenuItem1.Text = "Challenge";
            this.challengeToolStripMenuItem1.Click += new System.EventHandler(this.challengeToolStripMenuItem1_Click);
            // 
            // pictureToolStripMenuItem1
            // 
            this.pictureToolStripMenuItem1.Name = "pictureToolStripMenuItem1";
            this.pictureToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.pictureToolStripMenuItem1.Text = "Picture";
            this.pictureToolStripMenuItem1.Click += new System.EventHandler(this.pictureToolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(137, 6);
            // 
            // tsmBan
            // 
            this.tsmBan.Name = "tsmBan";
            this.tsmBan.Size = new System.Drawing.Size(140, 22);
            this.tsmBan.Text = "Ban User";
            this.tsmBan.Click += new System.EventHandler(this.tsmBan_Click);
            // 
            // tsmiKickUser
            // 
            this.tsmiKickUser.Name = "tsmiKickUser";
            this.tsmiKickUser.Size = new System.Drawing.Size(140, 22);
            this.tsmiKickUser.Text = "Kick User";
            this.tsmiKickUser.Click += new System.EventHandler(this.tsmiKickUser_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(137, 6);
            // 
            // blockIPToolStripMenuItem
            // 
            this.blockIPToolStripMenuItem.Name = "blockIPToolStripMenuItem";
            this.blockIPToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.blockIPToolStripMenuItem.Text = "Block I.P";
            this.blockIPToolStripMenuItem.Click += new System.EventHandler(this.blockIPToolStripMenuItem_Click);
            // 
            // blockMachineToolStripMenuItem
            // 
            this.blockMachineToolStripMenuItem.Name = "blockMachineToolStripMenuItem";
            this.blockMachineToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.blockMachineToolStripMenuItem.Text = "Block Machine";
            this.blockMachineToolStripMenuItem.Visible = false;
            this.blockMachineToolStripMenuItem.Click += new System.EventHandler(this.blockMachineToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonChallenge,
            this.toolStripButtonFollow,
            this.toolStripButtonPicture,
            this.toolStripButtonRating,
            this.toolStripSeparator3,
            this.toolStripTextBox1,
            this.toolStripComboBox1,
            this.tsRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 91);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1028, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonChallenge
            // 
            this.toolStripButtonChallenge.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonChallenge.Image")));
            this.toolStripButtonChallenge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonChallenge.Name = "toolStripButtonChallenge";
            this.toolStripButtonChallenge.Size = new System.Drawing.Size(74, 22);
            this.toolStripButtonChallenge.Text = "Challenge";
            this.toolStripButtonChallenge.Click += new System.EventHandler(this.toolStripButtonChallenge_Click);
            // 
            // toolStripButtonFollow
            // 
            this.toolStripButtonFollow.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFollow.Image")));
            this.toolStripButtonFollow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFollow.Name = "toolStripButtonFollow";
            this.toolStripButtonFollow.Size = new System.Drawing.Size(57, 22);
            this.toolStripButtonFollow.Text = "Follow";
            this.toolStripButtonFollow.Click += new System.EventHandler(this.toolStripButtonFollow_Click);
            // 
            // toolStripButtonPicture
            // 
            this.toolStripButtonPicture.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPicture.Image")));
            this.toolStripButtonPicture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPicture.Name = "toolStripButtonPicture";
            this.toolStripButtonPicture.Size = new System.Drawing.Size(60, 22);
            this.toolStripButtonPicture.Text = "Picture";
            this.toolStripButtonPicture.Click += new System.EventHandler(this.toolStripButtonPicture_Click);
            // 
            // toolStripButtonRating
            // 
            this.toolStripButtonRating.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRating.Image")));
            this.toolStripButtonRating.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRating.Name = "toolStripButtonRating";
            this.toolStripButtonRating.Size = new System.Drawing.Size(58, 22);
            this.toolStripButtonRating.Text = "Rating";
            this.toolStripButtonRating.Click += new System.EventHandler(this.toolStripButtonRating_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "user name",
            "first name",
            "last name"});
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // tsRefresh
            // 
            this.tsRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsRefresh.Image")));
            this.tsRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRefresh.Name = "tsRefresh";
            this.tsRefresh.Size = new System.Drawing.Size(65, 22);
            this.tsRefresh.Text = "Refresh";
            this.tsRefresh.ToolTipText = "Refresh";
            this.tsRefresh.Click += new System.EventHandler(this.tsRefresh_Click);
            // 
            // UserID
            // 
            this.UserID.DataPropertyName = "UserID";
            this.UserID.HeaderText = "UserID";
            this.UserID.Name = "UserID";
            this.UserID.ReadOnly = true;
            this.UserID.Visible = false;
            this.UserID.Width = 46;
            // 
            // RankImage
            // 
            this.RankImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle5.NullValue")));
            this.RankImage.DefaultCellStyle = dataGridViewCellStyle5;
            this.RankImage.HeaderText = "";
            this.RankImage.Name = "RankImage";
            this.RankImage.ReadOnly = true;
            this.RankImage.Width = 5;
            // 
            // UserName
            // 
            this.UserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "Name";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // TeamName
            // 
            this.TeamName.DataPropertyName = "TeamName";
            this.TeamName.HeaderText = "Team";
            this.TeamName.Name = "TeamName";
            this.TeamName.ReadOnly = true;
            this.TeamName.Visible = false;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 60;
            // 
            // BulletElo
            // 
            this.BulletElo.DataPropertyName = "BulletElo";
            this.BulletElo.HeaderText = "Bullet";
            this.BulletElo.Name = "BulletElo";
            this.BulletElo.ReadOnly = true;
            this.BulletElo.Width = 40;
            // 
            // BlitzElo
            // 
            this.BlitzElo.DataPropertyName = "BlitzElo";
            this.BlitzElo.HeaderText = "Blitz";
            this.BlitzElo.Name = "BlitzElo";
            this.BlitzElo.ReadOnly = true;
            this.BlitzElo.Width = 40;
            // 
            // RapidElo
            // 
            this.RapidElo.DataPropertyName = "RapidElo";
            this.RapidElo.HeaderText = "Rapid";
            this.RapidElo.Name = "RapidElo";
            this.RapidElo.ReadOnly = true;
            this.RapidElo.Width = 40;
            // 
            // LongElo
            // 
            this.LongElo.DataPropertyName = "LongElo";
            this.LongElo.HeaderText = "Long";
            this.LongElo.Name = "LongElo";
            this.LongElo.ReadOnly = true;
            this.LongElo.Width = 40;
            // 
            // FideTitle
            // 
            this.FideTitle.DataPropertyName = "FideTitle";
            this.FideTitle.HeaderText = "FIDE";
            this.FideTitle.Name = "FideTitle";
            this.FideTitle.ReadOnly = true;
            this.FideTitle.Width = 40;
            // 
            // IccfTitle
            // 
            this.IccfTitle.DataPropertyName = "IccfTitle";
            this.IccfTitle.HeaderText = "ICCF";
            this.IccfTitle.Name = "IccfTitle";
            this.IccfTitle.ReadOnly = true;
            this.IccfTitle.Width = 40;
            // 
            // CountryID
            // 
            this.CountryID.DataPropertyName = "CountryID";
            this.CountryID.HeaderText = "CountryID";
            this.CountryID.Name = "CountryID";
            this.CountryID.ReadOnly = true;
            this.CountryID.Visible = false;
            this.CountryID.Width = 79;
            // 
            // Nation
            // 
            this.Nation.DataPropertyName = "CountryID";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle6.NullValue")));
            this.Nation.DefaultCellStyle = dataGridViewCellStyle6;
            this.Nation.HeaderText = "Nation";
            this.Nation.Name = "Nation";
            this.Nation.ReadOnly = true;
            this.Nation.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Nation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Nation.Width = 45;
            // 
            // Engine
            // 
            this.Engine.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Engine.DataPropertyName = "Engine";
            this.Engine.HeaderText = "Engine";
            this.Engine.Name = "Engine";
            this.Engine.ReadOnly = true;
            // 
            // Rank
            // 
            this.Rank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Rank.DataPropertyName = "Rank";
            this.Rank.HeaderText = "Rank";
            this.Rank.Name = "Rank";
            this.Rank.ReadOnly = true;
            this.Rank.Width = 60;
            // 
            // Internet
            // 
            this.Internet.DataPropertyName = "Internet";
            this.Internet.HeaderText = "Internet";
            this.Internet.Name = "Internet";
            this.Internet.ReadOnly = true;
            this.Internet.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Internet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Internet.Width = 45;
            // 
            // GameID
            // 
            this.GameID.DataPropertyName = "GameID";
            this.GameID.HeaderText = "GameID";
            this.GameID.Name = "GameID";
            this.GameID.ReadOnly = true;
            this.GameID.Visible = false;
            this.GameID.Width = 71;
            // 
            // Social
            // 
            this.Social.DataPropertyName = "Social";
            this.Social.HeaderText = "Social";
            this.Social.Name = "Social";
            this.Social.ReadOnly = true;
            this.Social.Visible = false;
            this.Social.Width = 40;
            // 
            // InternetToolTip
            // 
            this.InternetToolTip.DataPropertyName = "InternetToolTip";
            this.InternetToolTip.HeaderText = "InternetToolTip";
            this.InternetToolTip.Name = "InternetToolTip";
            this.InternetToolTip.ReadOnly = true;
            this.InternetToolTip.Visible = false;
            this.InternetToolTip.Width = 104;
            // 
            // CountryName
            // 
            this.CountryName.DataPropertyName = "CountryName";
            this.CountryName.HeaderText = "CountryName";
            this.CountryName.Name = "CountryName";
            this.CountryName.ReadOnly = true;
            this.CountryName.Visible = false;
            // 
            // UserStatusID
            // 
            this.UserStatusID.DataPropertyName = "UserStatusID";
            this.UserStatusID.HeaderText = "UserStatusID";
            this.UserStatusID.Name = "UserStatusID";
            this.UserStatusID.ReadOnly = true;
            this.UserStatusID.Visible = false;
            // 
            // IsPause
            // 
            this.IsPause.DataPropertyName = "IsPause";
            this.IsPause.HeaderText = "IsPause";
            this.IsPause.Name = "IsPause";
            this.IsPause.ReadOnly = true;
            this.IsPause.Visible = false;
            // 
            // IsIdle
            // 
            this.IsIdle.DataPropertyName = "IsIdle";
            this.IsIdle.HeaderText = "IsIdle";
            this.IsIdle.Name = "IsIdle";
            this.IsIdle.ReadOnly = true;
            this.IsIdle.Visible = false;
            // 
            // RoleID
            // 
            this.RoleID.DataPropertyName = "RoleID";
            this.RoleID.HeaderText = "RoleID";
            this.RoleID.Name = "RoleID";
            this.RoleID.ReadOnly = true;
            this.RoleID.Visible = false;
            // 
            // Empty
            // 
            this.Empty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Empty.HeaderText = "";
            this.Empty.Name = "Empty";
            this.Empty.ReadOnly = true;
            // 
            // PlayersUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 116);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PlayersUc";
            this.Load += new System.EventHandler(this.PlayersUc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewRatingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem challengeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pictureToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmBan;
        private System.Windows.Forms.ToolStripMenuItem tsmiKickUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem blockIPToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonChallenge;
        private System.Windows.Forms.ToolStripButton toolStripButtonFollow;
        private System.Windows.Forms.ToolStripButton toolStripButtonPicture;
        private System.Windows.Forms.ToolStripButton toolStripButtonRating;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem blockMachineToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripMenuItem followToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewImageColumn RankImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn BulletElo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BlitzElo;
        private System.Windows.Forms.DataGridViewTextBoxColumn RapidElo;
        private System.Windows.Forms.DataGridViewTextBoxColumn LongElo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FideTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn IccfTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountryID;
        private System.Windows.Forms.DataGridViewImageColumn Nation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Engine;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rank;
        private System.Windows.Forms.DataGridViewImageColumn Internet;
        private System.Windows.Forms.DataGridViewTextBoxColumn GameID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Social;
        private System.Windows.Forms.DataGridViewTextBoxColumn InternetToolTip;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserStatusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsPause;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsIdle;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empty;
    }
}
