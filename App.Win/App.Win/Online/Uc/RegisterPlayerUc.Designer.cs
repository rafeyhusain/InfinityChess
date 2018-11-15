namespace App.Win
{
    partial class RegisterPlayerUc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterPlayerUc));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAddPlayer = new System.Windows.Forms.ToolStripButton();
            this.tssbSelect = new System.Windows.Forms.ToolStripSplitButton();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.tscombo = new System.Windows.Forms.ToolStripComboBox();
            this.tsPlayers = new System.Windows.Forms.ToolStripComboBox();
            this.tsbRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvRegisterPlayer = new System.Windows.Forms.DataGridView();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Rank = new System.Windows.Forms.DataGridViewImageColumn();
            this.Player = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flag = new System.Windows.Forms.DataGridViewImageColumn();
            this.Rating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegisterPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddPlayer,
            this.tssbSelect,
            this.toolStripTextBox1,
            this.tscombo,
            this.tsPlayers,
            this.tsbRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(642, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAddPlayer
            // 
            this.tsbAddPlayer.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddPlayer.Image")));
            this.tsbAddPlayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddPlayer.Name = "tsbAddPlayer";
            this.tsbAddPlayer.Size = new System.Drawing.Size(100, 22);
            this.tsbAddPlayer.Text = "Register Player";
            this.tsbAddPlayer.Click += new System.EventHandler(this.tsbAddPlayer_Click);
            // 
            // tssbSelect
            // 
            this.tssbSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssbSelect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.clearAllToolStripMenuItem});
            this.tssbSelect.Image = ((System.Drawing.Image)(resources.GetObject("tssbSelect.Image")));
            this.tssbSelect.ImageTransparentColor = System.Drawing.Color.MediumAquamarine;
            this.tssbSelect.Name = "tssbSelect";
            this.tssbSelect.Size = new System.Drawing.Size(52, 22);
            this.tssbSelect.Text = "Select";
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
            // tscombo
            // 
            this.tscombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscombo.Name = "tscombo";
            this.tscombo.Size = new System.Drawing.Size(121, 25);
            this.tscombo.SelectedIndexChanged += new System.EventHandler(this.tscombo_SelectedIndexChanged);
            // 
            // tsPlayers
            // 
            this.tsPlayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsPlayers.Items.AddRange(new object[] {
            "Online Players",
            "All Players"});
            this.tsPlayers.Name = "tsPlayers";
            this.tsPlayers.Size = new System.Drawing.Size(121, 25);
            this.tsPlayers.SelectedIndexChanged += new System.EventHandler(this.tsPlayers_SelectedIndexChanged);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(73, 25);
            this.tsbRefresh.Text = "Refresh";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvRegisterPlayer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(642, 383);
            this.panel1.TabIndex = 4;
            // 
            // dgvRegisterPlayer
            // 
            this.dgvRegisterPlayer.AllowUserToAddRows = false;
            this.dgvRegisterPlayer.AllowUserToDeleteRows = false;
            this.dgvRegisterPlayer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegisterPlayer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk,
            this.Rank,
            this.Player,
            this.Country,
            this.Flag,
            this.Rating,
            this.RoleID});
            this.dgvRegisterPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRegisterPlayer.Location = new System.Drawing.Point(0, 0);
            this.dgvRegisterPlayer.MultiSelect = false;
            this.dgvRegisterPlayer.Name = "dgvRegisterPlayer";
            this.dgvRegisterPlayer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegisterPlayer.Size = new System.Drawing.Size(642, 383);
            this.dgvRegisterPlayer.TabIndex = 0;
            this.dgvRegisterPlayer.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRegisterPlayer_CellFormatting);
            this.dgvRegisterPlayer.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvRegisterPlayer_CurrentCellDirtyStateChanged);
            // 
            // chk
            // 
            this.chk.HeaderText = "";
            this.chk.Name = "chk";
            this.chk.Width = 40;
            // 
            // Rank
            // 
            this.Rank.DataPropertyName = "Rank";
            this.Rank.HeaderText = "Rank";
            this.Rank.Name = "Rank";
            this.Rank.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Rank.Width = 40;
            // 
            // Player
            // 
            this.Player.DataPropertyName = "UserName";
            this.Player.HeaderText = "Player";
            this.Player.Name = "Player";
            this.Player.Width = 229;
            // 
            // Country
            // 
            this.Country.DataPropertyName = "Country";
            this.Country.HeaderText = "Country";
            this.Country.Name = "Country";
            this.Country.Width = 150;
            // 
            // Flag
            // 
            this.Flag.DataPropertyName = "Flag";
            this.Flag.HeaderText = "Flag";
            this.Flag.Name = "Flag";
            this.Flag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Flag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Flag.Width = 40;
            // 
            // Rating
            // 
            this.Rating.DataPropertyName = "Rating";
            this.Rating.HeaderText = "Rating";
            this.Rating.Name = "Rating";
            // 
            // RoleID
            // 
            this.RoleID.DataPropertyName = "RoleID";
            this.RoleID.HeaderText = "RoleID";
            this.RoleID.Name = "RoleID";
            this.RoleID.Visible = false;
            // 
            // RegisterPlayerUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "RegisterPlayerUc";
            this.Size = new System.Drawing.Size(642, 408);
            this.Load += new System.EventHandler(this.RegisterPlayerUc_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegisterPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvRegisterPlayer;
        private System.Windows.Forms.ToolStripSplitButton tssbSelect;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripComboBox tscombo;
        private System.Windows.Forms.ToolStripButton tsbAddPlayer;
        private System.Windows.Forms.ToolStripComboBox tsPlayers;
        private System.Windows.Forms.ToolStripMenuItem tsbRefresh;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        private System.Windows.Forms.DataGridViewImageColumn Rank;
        private System.Windows.Forms.DataGridViewTextBoxColumn Player;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewImageColumn Flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rating;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoleID;

    }
}
