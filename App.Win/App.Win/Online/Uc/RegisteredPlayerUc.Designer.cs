namespace App.Win
{
    partial class RegisteredPlayerUc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisteredPlayerUc));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsReplacedPlayer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbSelect = new System.Windows.Forms.ToolStripSplitButton();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTextbox = new System.Windows.Forms.ToolStripTextBox();
            this.tscombo = new System.Windows.Forms.ToolStripComboBox();
            this.tsRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvRegisterPlayer = new System.Windows.Forms.DataGridView();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rank = new System.Windows.Forms.DataGridViewImageColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flag = new System.Windows.Forms.DataGridViewImageColumn();
            this.Rating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.tsbNew,
            this.tsbDelete,
            this.tsReplacedPlayer,
            this.tsbSelect,
            this.tsTextbox,
            this.tscombo,
            this.tsRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(642, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbNew
            // 
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(79, 22);
            this.tsbNew.Text = "Add Player";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(58, 22);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsReplacedPlayer
            // 
            this.tsReplacedPlayer.Name = "tsReplacedPlayer";
            this.tsReplacedPlayer.Size = new System.Drawing.Size(90, 25);
            this.tsReplacedPlayer.Text = "Replace Player";
            this.tsReplacedPlayer.Click += new System.EventHandler(this.tsReplacedPlayer_Click);
            // 
            // tsbSelect
            // 
            this.tsbSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSelect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.clearAllToolStripMenuItem});
            this.tsbSelect.Image = ((System.Drawing.Image)(resources.GetObject("tsbSelect.Image")));
            this.tsbSelect.ImageTransparentColor = System.Drawing.Color.MediumAquamarine;
            this.tsbSelect.Name = "tsbSelect";
            this.tsbSelect.Size = new System.Drawing.Size(52, 22);
            this.tsbSelect.Text = "Select";
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
            // tscombo
            // 
            this.tscombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscombo.Name = "tscombo";
            this.tscombo.Size = new System.Drawing.Size(121, 25);
            this.tscombo.SelectedIndexChanged += new System.EventHandler(this.tscombo_SelectedIndexChanged);
            // 
            // tsRefresh
            // 
            this.tsRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsRefresh.Image")));
            this.tsRefresh.Name = "tsRefresh";
            this.tsRefresh.Size = new System.Drawing.Size(73, 25);
            this.tsRefresh.Text = "Refresh";
            this.tsRefresh.Click += new System.EventHandler(this.tsRefresh_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvRegisterPlayer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(642, 408);
            this.panel1.TabIndex = 4;
            // 
            // dgvRegisterPlayer
            // 
            this.dgvRegisterPlayer.AllowUserToAddRows = false;
            this.dgvRegisterPlayer.AllowUserToDeleteRows = false;
            this.dgvRegisterPlayer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegisterPlayer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk,
            this.No,
            this.Rank,
            this.UserName,
            this.Country,
            this.Flag,
            this.Rating,
            this.Status,
            this.RoleID});
            this.dgvRegisterPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRegisterPlayer.Location = new System.Drawing.Point(0, 0);
            this.dgvRegisterPlayer.Name = "dgvRegisterPlayer";
            this.dgvRegisterPlayer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegisterPlayer.Size = new System.Drawing.Size(642, 408);
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
            // No
            // 
            this.No.DataPropertyName = "No";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.No.DefaultCellStyle = dataGridViewCellStyle1;
            this.No.HeaderText = "Start No.";
            this.No.Name = "No";
            this.No.Width = 75;
            // 
            // Rank
            // 
            this.Rank.DataPropertyName = "Rank";
            this.Rank.HeaderText = "Rank";
            this.Rank.Name = "Rank";
            this.Rank.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Rank.Width = 40;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "Player";
            this.UserName.Name = "UserName";
            this.UserName.Width = 229;
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
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.Visible = false;
            // 
            // RoleID
            // 
            this.RoleID.DataPropertyName = "RoleID";
            this.RoleID.HeaderText = "RoleID";
            this.RoleID.Name = "RoleID";
            this.RoleID.Visible = false;
            // 
            // RegisteredPlayerUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "RegisteredPlayerUc";
            this.Size = new System.Drawing.Size(642, 433);
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
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvRegisterPlayer;
        private System.Windows.Forms.ToolStripSplitButton tsbSelect;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox tsTextbox;
        private System.Windows.Forms.ToolStripComboBox tscombo;
        private System.Windows.Forms.ToolStripMenuItem tsRefresh;
        private System.Windows.Forms.ToolStripMenuItem tsReplacedPlayer;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewImageColumn Rank;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewImageColumn Flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rating;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoleID;

    }
}
