namespace App.Win
{
    partial class ChallengesUc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChallengesUc));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.withDraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acceptToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.declineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chkPause = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAccept = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonModify = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSeek = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ChallengeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChallengeImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.ChallengerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpponentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Opponent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChallengerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpponentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Conditions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChallengerElo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpponentElo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Elo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clocks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GameTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChallengeStatusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Internet = new System.Windows.Forms.DataGridViewImageColumn();
            this.InternetC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InternetTooltipC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InternetO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InternetTooltipO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsChallengerSendsGame = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChallengerStatusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.withDraToolStripMenuItem,
            this.acceptToolStripMenuItem1,
            this.declineToolStripMenuItem,
            this.modifyToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(121, 92);
            // 
            // withDraToolStripMenuItem
            // 
            this.withDraToolStripMenuItem.Name = "withDraToolStripMenuItem";
            this.withDraToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.withDraToolStripMenuItem.Text = "Withdraw";
            this.withDraToolStripMenuItem.Click += new System.EventHandler(this.withDraToolStripMenuItem_Click);
            // 
            // acceptToolStripMenuItem1
            // 
            this.acceptToolStripMenuItem1.Name = "acceptToolStripMenuItem1";
            this.acceptToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.acceptToolStripMenuItem1.Text = "Accept";
            this.acceptToolStripMenuItem1.Click += new System.EventHandler(this.acceptToolStripMenuItem1_Click);
            // 
            // declineToolStripMenuItem
            // 
            this.declineToolStripMenuItem.Name = "declineToolStripMenuItem";
            this.declineToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.declineToolStripMenuItem.Text = "Decline";
            this.declineToolStripMenuItem.Click += new System.EventHandler(this.declineToolStripMenuItem_Click);
            // 
            // modifyToolStripMenuItem1
            // 
            this.modifyToolStripMenuItem1.Name = "modifyToolStripMenuItem1";
            this.modifyToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.modifyToolStripMenuItem1.Text = "Modify";
            this.modifyToolStripMenuItem1.Click += new System.EventHandler(this.modifyToolStripMenuItem1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.chkPause, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 201);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(681, 24);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // chkPause
            // 
            this.chkPause.AutoSize = true;
            this.chkPause.BackColor = System.Drawing.SystemColors.Control;
            this.chkPause.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkPause.Location = new System.Drawing.Point(622, 3);
            this.chkPause.Name = "chkPause";
            this.chkPause.Size = new System.Drawing.Size(56, 19);
            this.chkPause.TabIndex = 9;
            this.chkPause.Text = "Pause";
            this.chkPause.UseVisualStyleBackColor = false;
            this.chkPause.CheckedChanged += new System.EventHandler(this.chkPause_CheckedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAccept,
            this.toolStripButtonDelete,
            this.toolStripButtonModify,
            this.toolStripButtonSeek,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(619, 25);
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAccept
            // 
            this.toolStripButtonAccept.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAccept.Image")));
            this.toolStripButtonAccept.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAccept.Name = "toolStripButtonAccept";
            this.toolStripButtonAccept.Size = new System.Drawing.Size(60, 22);
            this.toolStripButtonAccept.Text = "Accept";
            this.toolStripButtonAccept.Click += new System.EventHandler(this.toolStripButtonAccept_Click);
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDelete.Image")));
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(58, 22);
            this.toolStripButtonDelete.Text = "Delete";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click);
            // 
            // toolStripButtonModify
            // 
            this.toolStripButtonModify.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonModify.Image")));
            this.toolStripButtonModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonModify.Name = "toolStripButtonModify";
            this.toolStripButtonModify.Size = new System.Drawing.Size(59, 22);
            this.toolStripButtonModify.Text = "Modify";
            this.toolStripButtonModify.Click += new System.EventHandler(this.toolStripButtonModify_Click);
            // 
            // toolStripButtonSeek
            // 
            this.toolStripButtonSeek.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSeek.Image")));
            this.toolStripButtonSeek.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSeek.Name = "toolStripButtonSeek";
            this.toolStripButtonSeek.Size = new System.Drawing.Size(50, 22);
            this.toolStripButtonSeek.Text = "Seek";
            this.toolStripButtonSeek.Click += new System.EventHandler(this.toolStripButtonSeek_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(65, 22);
            this.toolStripButton1.Text = "Formula";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChallengeID,
            this.ChallengeImage,
            this.ChallengerID,
            this.OpponentID,
            this.Opponent,
            this.ChallengerName,
            this.OpponentName,
            this.Conditions,
            this.ChallengerElo,
            this.OpponentElo,
            this.Elo,
            this.Clocks,
            this.Color,
            this.Type,
            this.GameTypeID,
            this.ChallengeStatusID,
            this.Internet,
            this.InternetC,
            this.InternetTooltipC,
            this.InternetO,
            this.InternetTooltipO,
            this.IsChallengerSendsGame,
            this.ChallengerStatusID,
            this.empty});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(681, 201);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // ChallengeID
            // 
            this.ChallengeID.DataPropertyName = "ChallengeID";
            this.ChallengeID.HeaderText = "ChallengeID";
            this.ChallengeID.Name = "ChallengeID";
            this.ChallengeID.ReadOnly = true;
            this.ChallengeID.Visible = false;
            // 
            // ChallengeImage
            // 
            this.ChallengeImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ChallengeImage.HeaderText = "";
            this.ChallengeImage.Name = "ChallengeImage";
            this.ChallengeImage.ReadOnly = true;
            this.ChallengeImage.Width = 5;
            // 
            // ChallengerID
            // 
            this.ChallengerID.DataPropertyName = "ChallengerUserID";
            this.ChallengerID.HeaderText = "ChallengerID";
            this.ChallengerID.Name = "ChallengerID";
            this.ChallengerID.ReadOnly = true;
            this.ChallengerID.Visible = false;
            // 
            // OpponentID
            // 
            this.OpponentID.DataPropertyName = "OpponentUserID";
            this.OpponentID.HeaderText = "OpponentID";
            this.OpponentID.Name = "OpponentID";
            this.OpponentID.ReadOnly = true;
            this.OpponentID.Visible = false;
            // 
            // Opponent
            // 
            this.Opponent.HeaderText = "Opponent";
            this.Opponent.Name = "Opponent";
            this.Opponent.ReadOnly = true;
            // 
            // ChallengerName
            // 
            this.ChallengerName.DataPropertyName = "ChallengerName";
            this.ChallengerName.HeaderText = "ChallengerName";
            this.ChallengerName.Name = "ChallengerName";
            this.ChallengerName.ReadOnly = true;
            this.ChallengerName.Visible = false;
            // 
            // OpponentName
            // 
            this.OpponentName.DataPropertyName = "OpponentName";
            this.OpponentName.HeaderText = "OpponentName";
            this.OpponentName.Name = "OpponentName";
            this.OpponentName.ReadOnly = true;
            this.OpponentName.Visible = false;
            // 
            // Conditions
            // 
            this.Conditions.DataPropertyName = "Condition";
            this.Conditions.HeaderText = "Conditions";
            this.Conditions.Name = "Conditions";
            this.Conditions.ReadOnly = true;
            // 
            // ChallengerElo
            // 
            this.ChallengerElo.DataPropertyName = "ChallengerElo";
            this.ChallengerElo.HeaderText = "ChallengerElo";
            this.ChallengerElo.Name = "ChallengerElo";
            this.ChallengerElo.ReadOnly = true;
            this.ChallengerElo.Visible = false;
            // 
            // OpponentElo
            // 
            this.OpponentElo.DataPropertyName = "OpponentElo";
            this.OpponentElo.HeaderText = "OpponentElo";
            this.OpponentElo.Name = "OpponentElo";
            this.OpponentElo.ReadOnly = true;
            this.OpponentElo.Visible = false;
            // 
            // Elo
            // 
            this.Elo.HeaderText = "Elo";
            this.Elo.Name = "Elo";
            this.Elo.ReadOnly = true;
            // 
            // Clocks
            // 
            this.Clocks.DataPropertyName = "Clock";
            this.Clocks.HeaderText = "Clocks";
            this.Clocks.Name = "Clocks";
            this.Clocks.ReadOnly = true;
            // 
            // Color
            // 
            this.Color.DataPropertyName = "Color";
            this.Color.HeaderText = "Color";
            this.Color.Name = "Color";
            this.Color.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // GameTypeID
            // 
            this.GameTypeID.DataPropertyName = "GameTypeID";
            this.GameTypeID.HeaderText = "GameTypeID";
            this.GameTypeID.Name = "GameTypeID";
            this.GameTypeID.ReadOnly = true;
            this.GameTypeID.Visible = false;
            // 
            // ChallengeStatusID
            // 
            this.ChallengeStatusID.DataPropertyName = "ChallengeStatusID";
            this.ChallengeStatusID.HeaderText = "ChallengeStatusID";
            this.ChallengeStatusID.Name = "ChallengeStatusID";
            this.ChallengeStatusID.ReadOnly = true;
            this.ChallengeStatusID.Visible = false;
            // 
            // Internet
            // 
            this.Internet.HeaderText = "Internet";
            this.Internet.Name = "Internet";
            this.Internet.ReadOnly = true;
            // 
            // InternetC
            // 
            this.InternetC.DataPropertyName = "InternetC";
            this.InternetC.HeaderText = "InternetC";
            this.InternetC.Name = "InternetC";
            this.InternetC.ReadOnly = true;
            this.InternetC.Visible = false;
            // 
            // InternetTooltipC
            // 
            this.InternetTooltipC.DataPropertyName = "InternetTooltipC";
            this.InternetTooltipC.HeaderText = "InternetTooltipC";
            this.InternetTooltipC.Name = "InternetTooltipC";
            this.InternetTooltipC.ReadOnly = true;
            this.InternetTooltipC.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.InternetTooltipC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.InternetTooltipC.Visible = false;
            // 
            // InternetO
            // 
            this.InternetO.DataPropertyName = "InternetO";
            this.InternetO.HeaderText = "InternetO";
            this.InternetO.Name = "InternetO";
            this.InternetO.ReadOnly = true;
            this.InternetO.Visible = false;
            // 
            // InternetTooltipO
            // 
            this.InternetTooltipO.DataPropertyName = "InternetTooltipO";
            this.InternetTooltipO.HeaderText = "InternetTooltipO";
            this.InternetTooltipO.Name = "InternetTooltipO";
            this.InternetTooltipO.ReadOnly = true;
            this.InternetTooltipO.Visible = false;
            // 
            // IsChallengerSendsGame
            // 
            this.IsChallengerSendsGame.DataPropertyName = "IsChallengerSendsGame";
            this.IsChallengerSendsGame.HeaderText = "IsChallengerSendsGame";
            this.IsChallengerSendsGame.Name = "IsChallengerSendsGame";
            this.IsChallengerSendsGame.ReadOnly = true;
            this.IsChallengerSendsGame.Visible = false;
            // 
            // ChallengerStatusID
            // 
            this.ChallengerStatusID.HeaderText = "ChallengerStatusID";
            this.ChallengerStatusID.Name = "ChallengerStatusID";
            this.ChallengerStatusID.ReadOnly = true;
            this.ChallengerStatusID.Visible = false;
            // 
            // empty
            // 
            this.empty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.empty.HeaderText = "";
            this.empty.Name = "empty";
            this.empty.ReadOnly = true;
            // 
            // ChallengesUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 225);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ChallengesUc";
            this.Load += new System.EventHandler(this.ChallengesUc_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem withDraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acceptToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem declineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox chkPause;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAccept;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.ToolStripButton toolStripButtonModify;
        private System.Windows.Forms.ToolStripButton toolStripButtonSeek;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChallengeID;
        private System.Windows.Forms.DataGridViewImageColumn ChallengeImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChallengerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpponentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Opponent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChallengerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpponentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conditions;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChallengerElo;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpponentElo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Elo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clocks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn GameTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChallengeStatusID;
        private System.Windows.Forms.DataGridViewImageColumn Internet;
        private System.Windows.Forms.DataGridViewTextBoxColumn InternetC;
        private System.Windows.Forms.DataGridViewTextBoxColumn InternetTooltipC;
        private System.Windows.Forms.DataGridViewTextBoxColumn InternetO;
        private System.Windows.Forms.DataGridViewTextBoxColumn InternetTooltipO;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsChallengerSendsGame;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChallengerStatusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn empty;
    }
}
