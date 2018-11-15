namespace App.Win
{
    partial class LogListUc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogListUc));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.tsbRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.gvLog = new System.Windows.Forms.DataGridView();
            this.sc = new System.Windows.Forms.SplitContainer();
            this.txtLogDetail = new System.Windows.Forms.TextBox();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLog)).BeginInit();
            this.sc.Panel1.SuspendLayout();
            this.sc.Panel2.SuspendLayout();
            this.sc.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.toolStripComboBox1,
            this.tsbRefresh,
            this.tsbClear});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(659, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(73, 25);
            this.tsbRefresh.Text = "Refresh";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tsbClear
            // 
            this.tsbClear.Image = global::InfinityChess.Properties.Resources.delete1;
            this.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClear.Name = "tsbClear";
            this.tsbClear.Size = new System.Drawing.Size(52, 22);
            this.tsbClear.Text = "Clear";
            this.tsbClear.Click += new System.EventHandler(this.tsbClear_Click);
            // 
            // gvLog
            // 
            this.gvLog.AllowUserToAddRows = false;
            this.gvLog.AllowUserToDeleteRows = false;
            this.gvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Message,
            this.Type,
            this.Category,
            this.CreatedDate});
            this.gvLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvLog.Location = new System.Drawing.Point(0, 0);
            this.gvLog.Name = "gvLog";
            this.gvLog.ReadOnly = true;
            this.gvLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvLog.Size = new System.Drawing.Size(659, 177);
            this.gvLog.TabIndex = 9;
            this.gvLog.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvLog_CellFormatting);
            this.gvLog.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvLog_CellClick);
            // 
            // sc
            // 
            this.sc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc.Location = new System.Drawing.Point(0, 25);
            this.sc.Name = "sc";
            this.sc.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sc.Panel1
            // 
            this.sc.Panel1.Controls.Add(this.gvLog);
            this.sc.Panel1MinSize = 40;
            // 
            // sc.Panel2
            // 
            this.sc.Panel2.Controls.Add(this.txtLogDetail);
            this.sc.Panel2MinSize = 5;
            this.sc.Size = new System.Drawing.Size(659, 392);
            this.sc.SplitterDistance = 177;
            this.sc.TabIndex = 11;
            // 
            // txtLogDetail
            // 
            this.txtLogDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLogDetail.Location = new System.Drawing.Point(0, 0);
            this.txtLogDetail.Multiline = true;
            this.txtLogDetail.Name = "txtLogDetail";
            this.txtLogDetail.ReadOnly = true;
            this.txtLogDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogDetail.Size = new System.Drawing.Size(659, 211);
            this.txtLogDetail.TabIndex = 0;
            // 
            // Message
            // 
            this.Message.DataPropertyName = "Message";
            this.Message.HeaderText = "Message";
            this.Message.Name = "Message";
            this.Message.ReadOnly = true;
            this.Message.Width = 400;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Category
            // 
            this.Category.DataPropertyName = "Category";
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // CreatedDate
            // 
            this.CreatedDate.DataPropertyName = "DateCreated";
            this.CreatedDate.HeaderText = "Created Date";
            this.CreatedDate.Name = "CreatedDate";
            this.CreatedDate.ReadOnly = true;
            // 
            // LogListUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sc);
            this.Controls.Add(this.toolStrip1);
            this.Name = "LogListUc";
            this.Size = new System.Drawing.Size(659, 417);
            this.Load += new System.EventHandler(this.LogListUc_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLog)).EndInit();
            this.sc.Panel1.ResumeLayout(false);
            this.sc.Panel2.ResumeLayout(false);
            this.sc.Panel2.PerformLayout();
            this.sc.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripMenuItem tsbRefresh;
        private System.Windows.Forms.DataGridView gvLog;
        private System.Windows.Forms.ToolStripButton tsbClear;
        private System.Windows.Forms.SplitContainer sc;
        private System.Windows.Forms.TextBox txtLogDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
    }
}
