namespace App.Win
{
    partial class SchRegisterTeamUc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchRegisterTeamUc));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbRegister = new System.Windows.Forms.ToolStripButton();
            this.tssbSelect = new System.Windows.Forms.ToolStripSplitButton();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTextbox = new System.Windows.Forms.ToolStripTextBox();
            this.tscombo = new System.Windows.Forms.ToolStripComboBox();
            this.tsRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvRegisterTeam = new System.Windows.Forms.DataGridView();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegisterTeam)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRegister,
            this.tssbSelect,
            this.tsTextbox,
            this.tscombo,
            this.tsRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(763, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbRegister
            // 
            this.tsbRegister.Image = ((System.Drawing.Image)(resources.GetObject("tsbRegister.Image")));
            this.tsbRegister.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRegister.Name = "tsbRegister";
            this.tsbRegister.Size = new System.Drawing.Size(67, 22);
            this.tsbRegister.Text = "Register";
            this.tsbRegister.Click += new System.EventHandler(this.tsbRegister_Click);
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
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.clearAllToolStripMenuItem.Text = "Clear All";
            // 
            // tsTextbox
            // 
            this.tsTextbox.Name = "tsTextbox";
            this.tsTextbox.Size = new System.Drawing.Size(100, 25);
            // 
            // tscombo
            // 
            this.tscombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscombo.Name = "tscombo";
            this.tscombo.Size = new System.Drawing.Size(121, 25);
            // 
            // tsRefresh
            // 
            this.tsRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsRefresh.Image")));
            this.tsRefresh.Name = "tsRefresh";
            this.tsRefresh.Size = new System.Drawing.Size(73, 25);
            this.tsRefresh.Text = "Refresh";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvRegisterTeam);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 441);
            this.panel1.TabIndex = 4;
            // 
            // dgvRegisterTeam
            // 
            this.dgvRegisterTeam.AllowUserToAddRows = false;
            this.dgvRegisterTeam.AllowUserToDeleteRows = false;
            this.dgvRegisterTeam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegisterTeam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk,
            this.TeamName});
            this.dgvRegisterTeam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRegisterTeam.Location = new System.Drawing.Point(0, 0);
            this.dgvRegisterTeam.Name = "dgvRegisterTeam";
            this.dgvRegisterTeam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegisterTeam.Size = new System.Drawing.Size(763, 441);
            this.dgvRegisterTeam.TabIndex = 0;
            this.dgvRegisterTeam.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvRegisterTeam_CurrentCellDirtyStateChanged);
            // 
            // chk
            // 
            this.chk.HeaderText = "";
            this.chk.Name = "chk";
            this.chk.Width = 40;
            // 
            // TeamName
            // 
            this.TeamName.DataPropertyName = "TeamName";
            this.TeamName.HeaderText = "Team";
            this.TeamName.Name = "TeamName";
            this.TeamName.ReadOnly = true;
            this.TeamName.Width = 250;
            // 
            // SchRegisterTeamUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "SchRegisterTeamUc";
            this.Size = new System.Drawing.Size(763, 466);
            this.Load += new System.EventHandler(this.SchRegisterTeamUc_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegisterTeam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbRegister;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvRegisterTeam;
        private System.Windows.Forms.ToolStripSplitButton tssbSelect;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox tsTextbox;
        private System.Windows.Forms.ToolStripComboBox tscombo;
        private System.Windows.Forms.ToolStripMenuItem tsRefresh;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamName;

    }
}
