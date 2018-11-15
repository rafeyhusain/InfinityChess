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
            this.startMatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startRoundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createRoundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbView = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCombo = new System.Windows.Forms.ToolStripComboBox();
            this.tsTextbox = new System.Windows.Forms.ToolStripTextBox();
            this.tsbRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvMatches = new System.Windows.Forms.DataGridView();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Round = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Player1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WRank = new System.Windows.Forms.DataGridViewImageColumn();
            this.WRating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Player2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BRank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BRating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeControlMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatchStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatchStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TournamentMatchStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.tsbView,
            this.toolStripSplitButton1,
            this.tsTextbox,
            this.tsCombo,
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
            this.tsbPostpone,
            this.startMatchToolStripMenuItem,
            this.startRoundToolStripMenuItem,
            this.createRoundToolStripMenuItem});
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
            this.tsbWhiteBye.Click += new System.EventHandler(this.tsbWhiteBye_Click);
            // 
            // tsbBlackBye
            // 
            this.tsbBlackBye.Image = ((System.Drawing.Image)(resources.GetObject("tsbBlackBye.Image")));
            this.tsbBlackBye.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbBlackBye.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBlackBye.Name = "tsbBlackBye";
            this.tsbBlackBye.Size = new System.Drawing.Size(72, 20);
            this.tsbBlackBye.Text = "Black Bye";
            this.tsbBlackBye.Click += new System.EventHandler(this.tsbBlackBye_Click);
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
            // startMatchToolStripMenuItem
            // 
            this.startMatchToolStripMenuItem.Name = "startMatchToolStripMenuItem";
            this.startMatchToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.startMatchToolStripMenuItem.Text = "Start Match";
            this.startMatchToolStripMenuItem.Click += new System.EventHandler(this.startMatchToolStripMenuItem_Click);
            // 
            // startRoundToolStripMenuItem
            // 
            this.startRoundToolStripMenuItem.Name = "startRoundToolStripMenuItem";
            this.startRoundToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.startRoundToolStripMenuItem.Text = "Start Round";
            // 
            // createRoundToolStripMenuItem
            // 
            this.createRoundToolStripMenuItem.Name = "createRoundToolStripMenuItem";
            this.createRoundToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.createRoundToolStripMenuItem.Text = "Create Round";
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
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.clearAllToolStripMenuItem.Text = "Clear All";
            // 
            // tsCombo
            // 
            this.tsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsCombo.Name = "tsCombo";
            this.tsCombo.Size = new System.Drawing.Size(121, 25);
            // 
            // tsTextbox
            // 
            this.tsTextbox.Name = "tsTextbox";
            this.tsTextbox.Size = new System.Drawing.Size(100, 25);
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
            this.dgvMatches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk,
            this.Round,
            this.Player1,
            this.WRank,
            this.WRating,
            this.Player2,
            this.BRank,
            this.BRating,
            this.TimeControlMin,
            this.MatchStartDate,
            this.MatchStartTime,
            this.TournamentMatchStatus});
            this.dgvMatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMatches.Location = new System.Drawing.Point(0, 25);
            this.dgvMatches.Name = "dgvMatches";
            this.dgvMatches.Size = new System.Drawing.Size(806, 442);
            this.dgvMatches.TabIndex = 6;
            // 
            // chk
            // 
            this.chk.HeaderText = "";
            this.chk.Name = "chk";
            // 
            // Round
            // 
            this.Round.DataPropertyName = "Round";
            this.Round.HeaderText = "Round";
            this.Round.Name = "Round";
            // 
            // Player1
            // 
            this.Player1.DataPropertyName = "Player1";
            this.Player1.HeaderText = "White";
            this.Player1.Name = "Player1";
            // 
            // WRank
            // 
            this.WRank.DataPropertyName = "WRank";
            this.WRank.HeaderText = "Rank";
            this.WRank.Name = "WRank";
            // 
            // WRating
            // 
            this.WRating.DataPropertyName = "WRating";
            this.WRating.HeaderText = "Rating";
            this.WRating.Name = "WRating";
            // 
            // Player2
            // 
            this.Player2.DataPropertyName = "Player2";
            this.Player2.HeaderText = "Black";
            this.Player2.Name = "Player2";
            // 
            // BRank
            // 
            this.BRank.DataPropertyName = "BRank";
            this.BRank.HeaderText = "Rank";
            this.BRank.Name = "BRank";
            // 
            // BRating
            // 
            this.BRating.DataPropertyName = "BRating";
            this.BRating.HeaderText = "Rating";
            this.BRating.Name = "BRating";
            // 
            // TimeControlMin
            // 
            this.TimeControlMin.DataPropertyName = "TimeControlMin";
            this.TimeControlMin.HeaderText = "Time Control";
            this.TimeControlMin.Name = "TimeControlMin";
            // 
            // MatchStartDate
            // 
            this.MatchStartDate.DataPropertyName = "MatchStartDate";
            this.MatchStartDate.HeaderText = "StartDate";
            this.MatchStartDate.Name = "MatchStartDate";
            // 
            // MatchStartTime
            // 
            this.MatchStartTime.DataPropertyName = "MatchStartTime";
            this.MatchStartTime.HeaderText = "Start Time";
            this.MatchStartTime.Name = "MatchStartTime";
            // 
            // TournamentMatchStatus
            // 
            this.TournamentMatchStatus.DataPropertyName = "TournamentMatchStatus";
            this.TournamentMatchStatus.HeaderText = "Match Status";
            this.TournamentMatchStatus.Name = "TournamentMatchStatus";
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
        private System.Windows.Forms.ToolStripComboBox tsCombo;
        private System.Windows.Forms.ToolStripTextBox tsTextbox;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Round;
        private System.Windows.Forms.DataGridViewTextBoxColumn Player1;
        private System.Windows.Forms.DataGridViewImageColumn WRank;
        private System.Windows.Forms.DataGridViewTextBoxColumn WRating;
        private System.Windows.Forms.DataGridViewTextBoxColumn Player2;
        private System.Windows.Forms.DataGridViewTextBoxColumn BRank;
        private System.Windows.Forms.DataGridViewTextBoxColumn BRating;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeControlMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatchStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatchStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TournamentMatchStatus;
        private System.Windows.Forms.ToolStripMenuItem startMatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startRoundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createRoundToolStripMenuItem;

    }
}
