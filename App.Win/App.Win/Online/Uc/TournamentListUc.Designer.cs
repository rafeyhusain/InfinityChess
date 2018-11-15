namespace App.Win
{
    partial class TournamentListUc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentListUc));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbView = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStriptxtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripcmbSearch = new System.Windows.Forms.ToolStripComboBox();
            this.tsbRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvTournamentList = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TournamentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TournamentStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTournamentList)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.tsbView,
            this.tsbDelete,
            this.toolStriptxtSearch,
            this.toolStripcmbSearch,
            this.tsbRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(766, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbNew
            // 
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(48, 22);
            this.tsbNew.Text = "New";
            this.tsbNew.ToolTipText = "Save";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // tsbView
            // 
            this.tsbView.Image = ((System.Drawing.Image)(resources.GetObject("tsbView.Image")));
            this.tsbView.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbView.Name = "tsbView";
            this.tsbView.Size = new System.Drawing.Size(49, 22);
            this.tsbView.Text = "View";
            this.tsbView.Click += new System.EventHandler(this.tsbView_Click);
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
            // toolStriptxtSearch
            // 
            this.toolStriptxtSearch.Name = "toolStriptxtSearch";
            this.toolStriptxtSearch.Size = new System.Drawing.Size(100, 25);
            this.toolStriptxtSearch.TextChanged += new System.EventHandler(this.toolStriptxtSearch_TextChanged);
            // 
            // toolStripcmbSearch
            // 
            this.toolStripcmbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripcmbSearch.Name = "toolStripcmbSearch";
            this.toolStripcmbSearch.Size = new System.Drawing.Size(121, 25);
            this.toolStripcmbSearch.SelectedIndexChanged += new System.EventHandler(this.toolStripcmbSearch_SelectedIndexChanged);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(73, 25);
            this.tsbRefresh.Text = "Refresh";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // dgvTournamentList
            // 
            this.dgvTournamentList.AllowUserToAddRows = false;
            this.dgvTournamentList.AllowUserToDeleteRows = false;
            this.dgvTournamentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTournamentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.TournamentName,
            this.TD,
            this.Status,
            this.TournamentStartDate});
            this.dgvTournamentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTournamentList.Location = new System.Drawing.Point(0, 25);
            this.dgvTournamentList.Name = "dgvTournamentList";
            this.dgvTournamentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTournamentList.Size = new System.Drawing.Size(766, 406);
            this.dgvTournamentList.TabIndex = 7;
            this.dgvTournamentList.DoubleClick += new System.EventHandler(this.dgvTournamentList_DoubleClick);
            this.dgvTournamentList.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvTournamentList_CurrentCellDirtyStateChanged);
            // 
            // Select
            // 
            this.Select.FillWeight = 59.67383F;
            this.Select.HeaderText = "";
            this.Select.Name = "Select";
            this.Select.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Select.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Select.Width = 40;
            // 
            // TournamentName
            // 
            this.TournamentName.DataPropertyName = "Name";
            this.TournamentName.FillWeight = 178.6169F;
            this.TournamentName.HeaderText = "Tournament Name";
            this.TournamentName.Name = "TournamentName";
            this.TournamentName.ReadOnly = true;
            this.TournamentName.Width = 350;
            // 
            // TD
            // 
            this.TD.DataPropertyName = "TD";
            this.TD.HeaderText = "Tournament Director";
            this.TD.Name = "TD";
            this.TD.Width = 110;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "TournamentStatus";
            this.Status.FillWeight = 55.60288F;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // TournamentStartDate
            // 
            this.TournamentStartDate.DataPropertyName = "TournamentStartDate";
            this.TournamentStartDate.HeaderText = "Start Date";
            this.TournamentStartDate.Name = "TournamentStartDate";
            this.TournamentStartDate.ReadOnly = true;
            this.TournamentStartDate.Width = 150;
            // 
            // TournamentListUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvTournamentList);
            this.Controls.Add(this.toolStrip1);
            this.Name = "TournamentListUc";
            this.Size = new System.Drawing.Size(766, 431);
            this.Load += new System.EventHandler(this.TournamentListUc_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTournamentList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbView;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.DataGridView dgvTournamentList;
        private System.Windows.Forms.ToolStripTextBox toolStriptxtSearch;
        private System.Windows.Forms.ToolStripComboBox toolStripcmbSearch;
        private System.Windows.Forms.ToolStripMenuItem tsbRefresh;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn TournamentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn TournamentStartDate;
    }
}
