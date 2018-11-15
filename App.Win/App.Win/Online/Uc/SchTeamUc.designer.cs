namespace App.Win
{
    partial class SchTeamUc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchTeamUc));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbSelectTeam = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTextbox = new System.Windows.Forms.ToolStripTextBox();
            this.tscombo = new System.Windows.Forms.ToolStripComboBox();
            this.tsbRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvTeam = new System.Windows.Forms.DataGridView();
            this.chkTeam = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbNewTeamPlayers = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteTeamPlayer = new System.Windows.Forms.ToolStripButton();
            this.tsbSelectTeamPlayer = new System.Windows.Forms.ToolStripSplitButton();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsReplacedPlayer = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvPlayer = new System.Windows.Forms.DataGridView();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.StartNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rank = new System.Windows.Forms.DataGridViewImageColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flag = new System.Windows.Forms.DataGridViewImageColumn();
            this.Rating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeam)).BeginInit();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.tsbDelete,
            this.tsbSelectTeam,
            this.tsTextbox,
            this.tscombo,
            this.tsbRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(785, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbNew
            // 
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(75, 22);
            this.tsbNew.Text = "Add Team";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(58, 22);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbSelectTeam
            // 
            this.tsbSelectTeam.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSelectTeam.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.tsbSelectTeam.Image = ((System.Drawing.Image)(resources.GetObject("tsbSelectTeam.Image")));
            this.tsbSelectTeam.ImageTransparentColor = System.Drawing.Color.MediumAquamarine;
            this.tsbSelectTeam.Name = "tsbSelectTeam";
            this.tsbSelectTeam.Size = new System.Drawing.Size(52, 22);
            this.tsbSelectTeam.Text = "Select";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(117, 22);
            this.toolStripMenuItem2.Text = "Select All";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(117, 22);
            this.toolStripMenuItem3.Text = "Clear All";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // tsTextbox
            // 
            this.tsTextbox.Name = "tsTextbox";
            this.tsTextbox.Size = new System.Drawing.Size(100, 25);
            this.tsTextbox.TextChanged += new System.EventHandler(this.tsTextbox_TextChanged);
            // 
            // tscombo
            // 
            this.tscombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscombo.Name = "tscombo";
            this.tscombo.Size = new System.Drawing.Size(121, 25);
            this.tscombo.SelectedIndexChanged += new System.EventHandler(this.tscombo_SelectedIndexChanged);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(73, 25);
            this.tsbRefresh.Text = "Refresh";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // dgvTeam
            // 
            this.dgvTeam.AllowUserToAddRows = false;
            this.dgvTeam.AllowUserToDeleteRows = false;
            this.dgvTeam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkTeam,
            this.TeamName,
            this.TeamDescription});
            this.dgvTeam.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvTeam.Location = new System.Drawing.Point(0, 25);
            this.dgvTeam.Name = "dgvTeam";
            this.dgvTeam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTeam.Size = new System.Drawing.Size(785, 163);
            this.dgvTeam.TabIndex = 0;
            this.dgvTeam.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvTeam_CurrentCellDirtyStateChanged);
            this.dgvTeam.SelectionChanged += new System.EventHandler(this.dgvTeam_SelectionChanged);
            // 
            // chkTeam
            // 
            this.chkTeam.HeaderText = "";
            this.chkTeam.Name = "chkTeam";
            this.chkTeam.Width = 40;
            // 
            // TeamName
            // 
            this.TeamName.DataPropertyName = "TeamName";
            this.TeamName.HeaderText = "Name";
            this.TeamName.Name = "TeamName";
            this.TeamName.ReadOnly = true;
            this.TeamName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TeamName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TeamName.Width = 200;
            // 
            // TeamDescription
            // 
            this.TeamDescription.DataPropertyName = "Description";
            this.TeamDescription.HeaderText = "Description";
            this.TeamDescription.Name = "TeamDescription";
            this.TeamDescription.ReadOnly = true;
            this.TeamDescription.Width = 250;
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(117, 22);
            this.toolStripMenuItem4.Text = "Select All";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(117, 22);
            this.toolStripMenuItem5.Text = "Clear All";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(117, 22);
            this.toolStripMenuItem6.Text = "Select All";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(117, 22);
            this.toolStripMenuItem7.Text = "Clear All";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(117, 22);
            this.toolStripMenuItem8.Text = "Select All";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(117, 22);
            this.toolStripMenuItem9.Text = "Clear All";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 188);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(785, 5);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewTeamPlayers,
            this.tsbDeleteTeamPlayer,
            this.tsbSelectTeamPlayer,
            this.toolStripTextBox1,
            this.toolStripComboBox1,
            this.toolStripMenuItem1,
            this.tsReplacedPlayer});
            this.toolStrip2.Location = new System.Drawing.Point(0, 193);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(785, 25);
            this.toolStrip2.TabIndex = 9;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbNewTeamPlayers
            // 
            this.tsbNewTeamPlayers.Image = ((System.Drawing.Image)(resources.GetObject("tsbNewTeamPlayers.Image")));
            this.tsbNewTeamPlayers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewTeamPlayers.Name = "tsbNewTeamPlayers";
            this.tsbNewTeamPlayers.Size = new System.Drawing.Size(79, 22);
            this.tsbNewTeamPlayers.Text = "Add Player";
            this.tsbNewTeamPlayers.Click += new System.EventHandler(this.tsbNewTeamPlayers_Click);
            // 
            // tsbDeleteTeamPlayer
            // 
            this.tsbDeleteTeamPlayer.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeleteTeamPlayer.Image")));
            this.tsbDeleteTeamPlayer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDeleteTeamPlayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteTeamPlayer.Name = "tsbDeleteTeamPlayer";
            this.tsbDeleteTeamPlayer.Size = new System.Drawing.Size(58, 22);
            this.tsbDeleteTeamPlayer.Text = "Delete";
            this.tsbDeleteTeamPlayer.Click += new System.EventHandler(this.tsbDeleteTeamPlayer_Click);
            // 
            // tsbSelectTeamPlayer
            // 
            this.tsbSelectTeamPlayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSelectTeamPlayer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.clearAllToolStripMenuItem});
            this.tsbSelectTeamPlayer.Image = ((System.Drawing.Image)(resources.GetObject("tsbSelectTeamPlayer.Image")));
            this.tsbSelectTeamPlayer.ImageTransparentColor = System.Drawing.Color.MediumAquamarine;
            this.tsbSelectTeamPlayer.Name = "tsbSelectTeamPlayer";
            this.tsbSelectTeamPlayer.Size = new System.Drawing.Size(52, 22);
            this.tsbSelectTeamPlayer.Text = "Select";
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.clearAllToolStripMenuItem.Text = "Clear All";
            this.clearAllToolStripMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(73, 25);
            this.toolStripMenuItem1.Text = "Refresh";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // tsReplacedPlayer
            // 
            this.tsReplacedPlayer.Name = "tsReplacedPlayer";
            this.tsReplacedPlayer.Size = new System.Drawing.Size(90, 25);
            this.tsReplacedPlayer.Text = "Replace Player";
            this.tsReplacedPlayer.Click += new System.EventHandler(this.tsReplacedPlayer_Click);
            // 
            // dgvPlayer
            // 
            this.dgvPlayer.AllowUserToAddRows = false;
            this.dgvPlayer.AllowUserToDeleteRows = false;
            this.dgvPlayer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check,
            this.StartNo,
            this.Rank,
            this.UserName,
            this.Country,
            this.Flag,
            this.Rating});
            this.dgvPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlayer.Location = new System.Drawing.Point(0, 218);
            this.dgvPlayer.Name = "dgvPlayer";
            this.dgvPlayer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlayer.Size = new System.Drawing.Size(785, 252);
            this.dgvPlayer.TabIndex = 10;
            this.dgvPlayer.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPlayer_CellFormatting);
            this.dgvPlayer.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvPlayer_CurrentCellDirtyStateChanged);
            // 
            // Check
            // 
            this.Check.HeaderText = "";
            this.Check.Name = "Check";
            this.Check.Width = 40;
            // 
            // StartNo
            // 
            this.StartNo.DataPropertyName = "No";
            this.StartNo.HeaderText = "Start No.";
            this.StartNo.Name = "StartNo";
            // 
            // Rank
            // 
            this.Rank.DataPropertyName = "Rank";
            this.Rank.HeaderText = "Rank";
            this.Rank.Name = "Rank";
            this.Rank.Width = 40;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "Player";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.UserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UserName.Width = 230;
            // 
            // Country
            // 
            this.Country.DataPropertyName = "Country";
            this.Country.HeaderText = "Country";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            this.Country.Width = 150;
            // 
            // Flag
            // 
            this.Flag.DataPropertyName = "Flag";
            this.Flag.HeaderText = "Flag";
            this.Flag.Name = "Flag";
            this.Flag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Flag.Width = 40;
            // 
            // Rating
            // 
            this.Rating.DataPropertyName = "Rating";
            this.Rating.HeaderText = "Rating";
            this.Rating.Name = "Rating";
            this.Rating.ReadOnly = true;
            // 
            // SchTeamUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvPlayer);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.dgvTeam);
            this.Controls.Add(this.toolStrip1);
            this.Name = "SchTeamUc";
            this.Size = new System.Drawing.Size(785, 470);
            this.Load += new System.EventHandler(this.TeamUc_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeam)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView dgvTeam;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripMenuItem tsbRefresh;
        private System.Windows.Forms.ToolStripSplitButton tsbSelectTeam;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripComboBox tscombo;
        private System.Windows.Forms.ToolStripTextBox tsTextbox;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbNewTeamPlayers;
        private System.Windows.Forms.ToolStripButton tsbDeleteTeamPlayer;
        private System.Windows.Forms.ToolStripSplitButton tsbSelectTeamPlayer;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.DataGridView dgvPlayer;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamDescription;
        private System.Windows.Forms.ToolStripMenuItem tsReplacedPlayer;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartNo;
        private System.Windows.Forms.DataGridViewImageColumn Rank;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewImageColumn Flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rating;



    }
}
