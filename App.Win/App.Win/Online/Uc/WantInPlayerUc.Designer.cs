namespace App.Win
{
    partial class WantInPlayerUc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WantInPlayerUc));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbApprove = new System.Windows.Forms.ToolStripButton();
            this.tsbDecline = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTextbox = new System.Windows.Forms.ToolStripTextBox();
            this.tsCombo = new System.Windows.Forms.ToolStripComboBox();
            this.tsbRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvWantin = new System.Windows.Forms.DataGridView();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Rank = new System.Windows.Forms.DataGridViewImageColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flag = new System.Windows.Forms.DataGridViewImageColumn();
            this.Rating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TournamentUserStatusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWantin)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbApprove,
            this.tsbDecline,
            this.toolStripSplitButton1,
            this.tsTextbox,
            this.tsCombo,
            this.tsbRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(647, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // tsbApprove
            // 
            this.tsbApprove.Image = ((System.Drawing.Image)(resources.GetObject("tsbApprove.Image")));
            this.tsbApprove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbApprove.Name = "tsbApprove";
            this.tsbApprove.Size = new System.Drawing.Size(68, 22);
            this.tsbApprove.Text = "Approve";
            this.tsbApprove.Click += new System.EventHandler(this.tsbApprove_Click);
            // 
            // tsbDecline
            // 
            this.tsbDecline.Image = ((System.Drawing.Image)(resources.GetObject("tsbDecline.Image")));
            this.tsbDecline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDecline.Name = "tsbDecline";
            this.tsbDecline.Size = new System.Drawing.Size(61, 22);
            this.tsbDecline.Text = "Decline";
            this.tsbDecline.Click += new System.EventHandler(this.tsbDecline_Click);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.clearAllToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.MediumAquamarine;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(52, 22);
            this.toolStripSplitButton1.Text = "Select";
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
            // tsTextbox
            // 
            this.tsTextbox.Name = "tsTextbox";
            this.tsTextbox.Size = new System.Drawing.Size(100, 25);
            this.tsTextbox.TextChanged += new System.EventHandler(this.tsTextbox_TextChanged);
            // 
            // tsCombo
            // 
            this.tsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsCombo.Name = "tsCombo";
            this.tsCombo.Size = new System.Drawing.Size(121, 25);
            this.tsCombo.SelectedIndexChanged += new System.EventHandler(this.tsCombo_SelectedIndexChanged);
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
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 457);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvWantin);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(647, 457);
            this.panel2.TabIndex = 0;
            // 
            // dgvWantin
            // 
            this.dgvWantin.AllowUserToAddRows = false;
            this.dgvWantin.AllowUserToDeleteRows = false;
            this.dgvWantin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWantin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check,
            this.Rank,
            this.UserName,
            this.Country,
            this.TeamName,
            this.Flag,
            this.Rating,
            this.TournamentUserStatusName,
            this.RoleID});
            this.dgvWantin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWantin.Location = new System.Drawing.Point(0, 0);
            this.dgvWantin.MultiSelect = false;
            this.dgvWantin.Name = "dgvWantin";
            this.dgvWantin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWantin.Size = new System.Drawing.Size(647, 457);
            this.dgvWantin.TabIndex = 9;
            this.dgvWantin.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvWantin_CellFormatting);
            this.dgvWantin.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvWantin_CurrentCellDirtyStateChanged);
            // 
            // Check
            // 
            this.Check.HeaderText = "";
            this.Check.Name = "Check";
            this.Check.Width = 40;
            // 
            // Rank
            // 
            this.Rank.DataPropertyName = "Rank";
            this.Rank.HeaderText = "Rank";
            this.Rank.Name = "Rank";
            this.Rank.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Rank.ToolTipText = "Rank";
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
            // 
            // Country
            // 
            this.Country.DataPropertyName = "Country";
            this.Country.HeaderText = "Country";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            // 
            // TeamName
            // 
            this.TeamName.DataPropertyName = "TeamName";
            this.TeamName.HeaderText = "Team Name";
            this.TeamName.Name = "TeamName";
            // 
            // Flag
            // 
            this.Flag.DataPropertyName = "Flag";
            this.Flag.HeaderText = "Flag";
            this.Flag.Name = "Flag";
            this.Flag.Width = 40;
            // 
            // Rating
            // 
            this.Rating.DataPropertyName = "Rating";
            this.Rating.HeaderText = "Rating";
            this.Rating.Name = "Rating";
            this.Rating.ReadOnly = true;
            this.Rating.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TournamentUserStatusName
            // 
            this.TournamentUserStatusName.DataPropertyName = "TournamentUserStatusName";
            this.TournamentUserStatusName.HeaderText = "Status";
            this.TournamentUserStatusName.Name = "TournamentUserStatusName";
            this.TournamentUserStatusName.ReadOnly = true;
            this.TournamentUserStatusName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RoleID
            // 
            this.RoleID.DataPropertyName = "RoleID";
            this.RoleID.HeaderText = "RoleID";
            this.RoleID.Name = "RoleID";
            this.RoleID.Visible = false;
            // 
            // WantInPlayerUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "WantInPlayerUc";
            this.Size = new System.Drawing.Size(647, 482);
            this.Load += new System.EventHandler(this.WantInPlayerUc_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWantin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripButton tsbApprove;
        private System.Windows.Forms.ToolStripButton tsbDecline;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox tsTextbox;
        private System.Windows.Forms.ToolStripComboBox tsCombo;
        private System.Windows.Forms.ToolStripMenuItem tsbRefresh;
        private System.Windows.Forms.DataGridView dgvWantin;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.DataGridViewImageColumn Rank;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamName;
        private System.Windows.Forms.DataGridViewImageColumn Flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rating;
        private System.Windows.Forms.DataGridViewTextBoxColumn TournamentUserStatusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoleID;


    }
}
