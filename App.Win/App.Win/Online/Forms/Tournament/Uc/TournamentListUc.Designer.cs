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
            this.tsbWantIn = new System.Windows.Forms.ToolStripButton();
            this.tsbView = new System.Windows.Forms.ToolStripButton();
            this.tsbMatches = new System.Windows.Forms.ToolStripButton();
            this.tsbStandings = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbActive = new System.Windows.Forms.ToolStripButton();
            this.tsbInActive = new System.Windows.Forms.ToolStripButton();
            this.dgvTournamentList = new System.Windows.Forms.DataGridView();
            this.TournamentType = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTournamentList)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.tsbWantIn,
            this.tsbView,
            this.tsbMatches,
            this.tsbStandings,
            this.tsbDelete,
            this.tsbActive,
            this.tsbInActive});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(630, 25);
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
            // 
            // tsbWantIn
            // 
            this.tsbWantIn.Image = ((System.Drawing.Image)(resources.GetObject("tsbWantIn.Image")));
            this.tsbWantIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbWantIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbWantIn.Name = "tsbWantIn";
            this.tsbWantIn.Size = new System.Drawing.Size(66, 22);
            this.tsbWantIn.Text = "Want In";
            // 
            // tsbView
            // 
            this.tsbView.Image = ((System.Drawing.Image)(resources.GetObject("tsbView.Image")));
            this.tsbView.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbView.Name = "tsbView";
            this.tsbView.Size = new System.Drawing.Size(49, 22);
            this.tsbView.Text = "View";
            // 
            // tsbMatches
            // 
            this.tsbMatches.Image = ((System.Drawing.Image)(resources.GetObject("tsbMatches.Image")));
            this.tsbMatches.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbMatches.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMatches.Name = "tsbMatches";
            this.tsbMatches.Size = new System.Drawing.Size(67, 22);
            this.tsbMatches.Text = "Matches";
            // 
            // tsbStandings
            // 
            this.tsbStandings.Image = ((System.Drawing.Image)(resources.GetObject("tsbStandings.Image")));
            this.tsbStandings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbStandings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStandings.Name = "tsbStandings";
            this.tsbStandings.Size = new System.Drawing.Size(74, 22);
            this.tsbStandings.Text = "Standings";
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(58, 22);
            this.tsbDelete.Text = "Delete";
            // 
            // tsbActive
            // 
            this.tsbActive.Image = ((System.Drawing.Image)(resources.GetObject("tsbActive.Image")));
            this.tsbActive.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbActive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbActive.Name = "tsbActive";
            this.tsbActive.Size = new System.Drawing.Size(57, 22);
            this.tsbActive.Text = "Active";
            // 
            // tsbInActive
            // 
            this.tsbInActive.Image = ((System.Drawing.Image)(resources.GetObject("tsbInActive.Image")));
            this.tsbInActive.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbInActive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInActive.Name = "tsbInActive";
            this.tsbInActive.Size = new System.Drawing.Size(67, 22);
            this.tsbInActive.Text = "InActive";
            // 
            // dgvTournamentList
            // 
            this.dgvTournamentList.AllowUserToResizeColumns = false;
            this.dgvTournamentList.AllowUserToResizeRows = false;
            this.dgvTournamentList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTournamentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTournamentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TournamentType,
            this.Status});
            this.dgvTournamentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTournamentList.Location = new System.Drawing.Point(0, 25);
            this.dgvTournamentList.Name = "dgvTournamentList";
            this.dgvTournamentList.Size = new System.Drawing.Size(630, 406);
            this.dgvTournamentList.TabIndex = 7;
            // 
            // TournamentType
            // 
            this.TournamentType.HeaderText = "TournamentType";
            this.TournamentType.Name = "TournamentType";
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // TournamentListUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvTournamentList);
            this.Controls.Add(this.toolStrip1);
            this.Name = "TournamentListUc";
            this.Size = new System.Drawing.Size(630, 431);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTournamentList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbWantIn;
        private System.Windows.Forms.ToolStripButton tsbView;
        private System.Windows.Forms.ToolStripButton tsbMatches;
        private System.Windows.Forms.ToolStripButton tsbStandings;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.DataGridView dgvTournamentList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TournamentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.ToolStripButton tsbActive;
        private System.Windows.Forms.ToolStripButton tsbInActive;
    }
}
