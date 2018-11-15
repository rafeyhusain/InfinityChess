namespace App.Win
{
    partial class GamesUc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GamesUc));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonWatch = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.tsRefresh = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.GameID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GameTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GameTypeImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.WhiteUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WhiteUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WhiteElo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BlackUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BlackUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BlackElo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeControl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonWatch,
            this.toolStripTextBox1,
            this.toolStripComboBox1,
            this.tsRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 91);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(808, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonWatch
            // 
            this.toolStripButtonWatch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonWatch.Image")));
            this.toolStripButtonWatch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonWatch.Name = "toolStripButtonWatch";
            this.toolStripButtonWatch.Size = new System.Drawing.Size(58, 22);
            this.toolStripButtonWatch.Text = "Watch";
            this.toolStripButtonWatch.Click += new System.EventHandler(this.toolStripButtonWatch_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "user name",
            "first name",
            "last name"});
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // tsRefresh
            // 
            this.tsRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsRefresh.Image")));
            this.tsRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRefresh.Name = "tsRefresh";
            this.tsRefresh.Size = new System.Drawing.Size(65, 22);
            this.tsRefresh.Text = "Refresh";
            this.tsRefresh.ToolTipText = "Refresh";
            this.tsRefresh.Click += new System.EventHandler(this.tsRefresh_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GameID,
            this.GameTypeID,
            this.GameTypeImage,
            this.WhiteUserID,
            this.WhiteUserName,
            this.WhiteElo,
            this.BlackUserID,
            this.BlackUserName,
            this.BlackElo,
            this.Result,
            this.TimeControl,
            this.StartTime,
            this.Type,
            this.Empty});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(808, 91);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // GameID
            // 
            this.GameID.DataPropertyName = "GameID";
            this.GameID.HeaderText = "GameID";
            this.GameID.Name = "GameID";
            this.GameID.ReadOnly = true;
            this.GameID.Visible = false;
            // 
            // GameTypeID
            // 
            this.GameTypeID.DataPropertyName = "GameTypeID";
            this.GameTypeID.HeaderText = "GameType";
            this.GameTypeID.Name = "GameTypeID";
            this.GameTypeID.ReadOnly = true;
            this.GameTypeID.Visible = false;
            // 
            // GameTypeImage
            // 
            this.GameTypeImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.GameTypeImage.HeaderText = "";
            this.GameTypeImage.Name = "GameTypeImage";
            this.GameTypeImage.ReadOnly = true;
            this.GameTypeImage.Width = 5;
            // 
            // WhiteUserID
            // 
            this.WhiteUserID.DataPropertyName = "WhiteUserID";
            this.WhiteUserID.HeaderText = "WhiteUserID";
            this.WhiteUserID.Name = "WhiteUserID";
            this.WhiteUserID.ReadOnly = true;
            this.WhiteUserID.Visible = false;
            // 
            // WhiteUserName
            // 
            this.WhiteUserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.WhiteUserName.DataPropertyName = "WhiteUserName";
            this.WhiteUserName.HeaderText = "White";
            this.WhiteUserName.Name = "WhiteUserName";
            this.WhiteUserName.ReadOnly = true;
            this.WhiteUserName.Width = 60;
            // 
            // WhiteElo
            // 
            this.WhiteElo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.WhiteElo.DataPropertyName = "EloWhiteBefore";
            this.WhiteElo.HeaderText = "EloWhite";
            this.WhiteElo.Name = "WhiteElo";
            this.WhiteElo.ReadOnly = true;
            this.WhiteElo.Width = 75;
            // 
            // BlackUserID
            // 
            this.BlackUserID.DataPropertyName = "BlackUserID";
            this.BlackUserID.HeaderText = "BlackUserID";
            this.BlackUserID.Name = "BlackUserID";
            this.BlackUserID.ReadOnly = true;
            this.BlackUserID.Visible = false;
            // 
            // BlackUserName
            // 
            this.BlackUserName.DataPropertyName = "BlackUserName";
            this.BlackUserName.HeaderText = "Black";
            this.BlackUserName.Name = "BlackUserName";
            this.BlackUserName.ReadOnly = true;
            // 
            // BlackElo
            // 
            this.BlackElo.DataPropertyName = "EloBlackBefore";
            this.BlackElo.HeaderText = "EloBlack";
            this.BlackElo.Name = "BlackElo";
            this.BlackElo.ReadOnly = true;
            // 
            // Result
            // 
            this.Result.DataPropertyName = "Result";
            this.Result.HeaderText = "Result";
            this.Result.Name = "Result";
            this.Result.ReadOnly = true;
            // 
            // TimeControl
            // 
            this.TimeControl.DataPropertyName = "TimeControl";
            this.TimeControl.HeaderText = "Time Control";
            this.TimeControl.Name = "TimeControl";
            this.TimeControl.ReadOnly = true;
            // 
            // StartTime
            // 
            this.StartTime.DataPropertyName = "StartTime";
            this.StartTime.HeaderText = "Start Time";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Rated";
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Empty
            // 
            this.Empty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Empty.HeaderText = "";
            this.Empty.Name = "Empty";
            this.Empty.ReadOnly = true;
            // 
            // GamesUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 116);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "GamesUc";
            this.Load += new System.EventHandler(this.GamesUc_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonWatch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripButton tsRefresh;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn GameID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GameTypeID;
        private System.Windows.Forms.DataGridViewImageColumn GameTypeImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn WhiteUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn WhiteUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn WhiteElo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BlackUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BlackUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BlackElo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeControl;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empty;
    }
}
