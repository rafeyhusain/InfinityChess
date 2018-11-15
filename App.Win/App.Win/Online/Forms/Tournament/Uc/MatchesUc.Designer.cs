namespace App.Win
{
    partial class MatchesUc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchesUc));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.ddlMatchStatus = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbWhiteBye = new System.Windows.Forms.ToolStripButton();
            this.tsbBlackBye = new System.Windows.Forms.ToolStripButton();
            this.tsbAbsent = new System.Windows.Forms.ToolStripButton();
            this.tsbPostpone = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvMatches = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatches)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.ddlMatchStatus,
            this.tsbRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(806, 25);
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
            // 
            // ddlMatchStatus
            // 
            this.ddlMatchStatus.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbWhiteBye,
            this.tsbBlackBye,
            this.tsbAbsent,
            this.tsbPostpone});
            this.ddlMatchStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddlMatchStatus.Name = "ddlMatchStatus";
            this.ddlMatchStatus.Size = new System.Drawing.Size(83, 22);
            this.ddlMatchStatus.Text = "Match Status";
            // 
            // tsbWhiteBye
            // 
            this.tsbWhiteBye.Image = ((System.Drawing.Image)(resources.GetObject("tsbWhiteBye.Image")));
            this.tsbWhiteBye.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbWhiteBye.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbWhiteBye.Name = "tsbWhiteBye";
            this.tsbWhiteBye.Size = new System.Drawing.Size(76, 20);
            this.tsbWhiteBye.Text = "White Bye";
            // 
            // tsbBlackBye
            // 
            this.tsbBlackBye.Image = ((System.Drawing.Image)(resources.GetObject("tsbBlackBye.Image")));
            this.tsbBlackBye.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbBlackBye.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBlackBye.Name = "tsbBlackBye";
            this.tsbBlackBye.Size = new System.Drawing.Size(72, 20);
            this.tsbBlackBye.Text = "Black Bye";
            // 
            // tsbAbsent
            // 
            this.tsbAbsent.Image = ((System.Drawing.Image)(resources.GetObject("tsbAbsent.Image")));
            this.tsbAbsent.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAbsent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbsent.Name = "tsbAbsent";
            this.tsbAbsent.Size = new System.Drawing.Size(61, 20);
            this.tsbAbsent.Text = "Absent";
            // 
            // tsbPostpone
            // 
            this.tsbPostpone.Image = ((System.Drawing.Image)(resources.GetObject("tsbPostpone.Image")));
            this.tsbPostpone.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbPostpone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPostpone.Name = "tsbPostpone";
            this.tsbPostpone.Size = new System.Drawing.Size(72, 20);
            this.tsbPostpone.Text = "Postpone";
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(73, 25);
            this.tsbRefresh.Text = "Refresh";
            // 
            // dgvMatches
            // 
            this.dgvMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMatches.Location = new System.Drawing.Point(0, 25);
            this.dgvMatches.Name = "dgvMatches";
            this.dgvMatches.Size = new System.Drawing.Size(806, 442);
            this.dgvMatches.TabIndex = 6;
            // 
            // MatchesUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvMatches);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MatchesUc";
            this.Size = new System.Drawing.Size(806, 467);
            this.Load += new System.EventHandler(this.MatchesUc_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatches)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton ddlMatchStatus;
        private System.Windows.Forms.ToolStripButton tsbWhiteBye;
        private System.Windows.Forms.ToolStripButton tsbBlackBye;
        private System.Windows.Forms.ToolStripButton tsbPostpone;
        private System.Windows.Forms.DataGridView dgvMatches;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbAbsent;
        private System.Windows.Forms.ToolStripMenuItem tsbRefresh;

    }
}
