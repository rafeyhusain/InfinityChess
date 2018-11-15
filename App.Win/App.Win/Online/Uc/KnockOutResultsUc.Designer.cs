namespace App.Win
{
    partial class KnockOutResultsUc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KnockOutResultsUc));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStriptxtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripcmbSearch = new System.Windows.Forms.ToolStripComboBox();
            this.tsbRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.whiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.dgvWinners = new System.Windows.Forms.DataGridView();
            this.lblWinnersMessage = new System.Windows.Forms.Label();
            this.pnlWinners = new System.Windows.Forms.Panel();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.Flag = new System.Windows.Forms.DataGridViewImageColumn();
            this.CountryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWinners)).BeginInit();
            this.pnlWinners.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStriptxtSearch,
            this.toolStripcmbSearch,
            this.tsbRefresh,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(786, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
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
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.whiteToolStripMenuItem,
            this.toolStripMenuItem2});
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(55, 22);
            this.toolStripDropDownButton1.Text = "Legend";
            // 
            // whiteToolStripMenuItem
            // 
            this.whiteToolStripMenuItem.Name = "whiteToolStripMenuItem";
            this.whiteToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.whiteToolStripMenuItem.Text = "+ Win (Due to Bye)";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(187, 22);
            this.toolStripMenuItem2.Text = "-  Loose (Due to Bye)";
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 25);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(786, 3);
            this.splitter2.TabIndex = 7;
            this.splitter2.TabStop = false;
            // 
            // dgvWinners
            // 
            this.dgvWinners.AllowUserToAddRows = false;
            this.dgvWinners.AllowUserToDeleteRows = false;
            this.dgvWinners.AllowUserToResizeRows = false;
            this.dgvWinners.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvWinners.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWinners.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWinners.Location = new System.Drawing.Point(0, 0);
            this.dgvWinners.Name = "dgvWinners";
            this.dgvWinners.ReadOnly = true;
            this.dgvWinners.Size = new System.Drawing.Size(284, 512);
            this.dgvWinners.TabIndex = 9;
            this.dgvWinners.Visible = false;
            // 
            // lblWinnersMessage
            // 
            this.lblWinnersMessage.AutoSize = true;
            this.lblWinnersMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinnersMessage.Location = new System.Drawing.Point(12, 16);
            this.lblWinnersMessage.Name = "lblWinnersMessage";
            this.lblWinnersMessage.Size = new System.Drawing.Size(146, 17);
            this.lblWinnersMessage.TabIndex = 10;
            this.lblWinnersMessage.Text = "[Winners Message]";
            // 
            // pnlWinners
            // 
            this.pnlWinners.Controls.Add(this.lblWinnersMessage);
            this.pnlWinners.Controls.Add(this.dgvWinners);
            this.pnlWinners.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlWinners.Location = new System.Drawing.Point(502, 28);
            this.pnlWinners.Name = "pnlWinners";
            this.pnlWinners.Size = new System.Drawing.Size(284, 512);
            this.pnlWinners.TabIndex = 11;
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.AllowUserToResizeRows = false;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Flag,
            this.CountryName});
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.Location = new System.Drawing.Point(0, 28);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.Size = new System.Drawing.Size(502, 512);
            this.dgvResult.TabIndex = 12;
            this.dgvResult.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvResult_CellFormatting);
            // 
            // Flag
            // 
            this.Flag.HeaderText = "Flag";
            this.Flag.Name = "Flag";
            this.Flag.ReadOnly = true;
            this.Flag.Width = 743;
            // 
            // CountryName
            // 
            this.CountryName.DataPropertyName = "CountryName";
            this.CountryName.HeaderText = "CountryName";
            this.CountryName.Name = "CountryName";
            this.CountryName.ReadOnly = true;
            this.CountryName.Visible = false;
            this.CountryName.Width = 96;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(499, 28);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 512);
            this.splitter1.TabIndex = 13;
            this.splitter1.TabStop = false;
            // 
            // KnockOutResultsUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.pnlWinners);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "KnockOutResultsUc";
            this.Size = new System.Drawing.Size(786, 540);
            this.Load += new System.EventHandler(this.KnockOutResultsUc_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWinners)).EndInit();
            this.pnlWinners.ResumeLayout(false);
            this.pnlWinners.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox toolStriptxtSearch;
        private System.Windows.Forms.ToolStripComboBox toolStripcmbSearch;
        private System.Windows.Forms.ToolStripMenuItem tsbRefresh;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem whiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.DataGridView dgvWinners;
        private System.Windows.Forms.Label lblWinnersMessage;
        private System.Windows.Forms.Panel pnlWinners;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.DataGridViewImageColumn Flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountryName;
        private System.Windows.Forms.Splitter splitter1;

    }
}
