namespace App.Win
{
    partial class SentUc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SentUc));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.UserMessageID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InboxImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserIDFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserIDTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.From = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusIDFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusIDTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.editor1 = new Design.Editor();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
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
            this.UserMessageID,
            this.InboxImage,
            this.Subject,
            this.UserIDFrom,
            this.UserIDTo,
            this.From,
            this.To,
            this.Time,
            this.EmailSize,
            this.StatusIDFrom,
            this.StatusIDTo,
            this.Text,
            this.empty});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(592, 121);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // UserMessageID
            // 
            this.UserMessageID.DataPropertyName = "UserMessageID";
            this.UserMessageID.HeaderText = "UserMessageID";
            this.UserMessageID.Name = "UserMessageID";
            this.UserMessageID.ReadOnly = true;
            this.UserMessageID.Visible = false;
            this.UserMessageID.Width = 89;
            // 
            // InboxImage
            // 
            this.InboxImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.InboxImage.HeaderText = "";
            this.InboxImage.Name = "InboxImage";
            this.InboxImage.ReadOnly = true;
            this.InboxImage.Width = 5;
            // 
            // Subject
            // 
            this.Subject.DataPropertyName = "Subject";
            this.Subject.HeaderText = "Subject";
            this.Subject.Name = "Subject";
            this.Subject.ReadOnly = true;
            // 
            // UserIDFrom
            // 
            this.UserIDFrom.DataPropertyName = "UserIDFrom";
            this.UserIDFrom.HeaderText = "UserIDFrom";
            this.UserIDFrom.Name = "UserIDFrom";
            this.UserIDFrom.ReadOnly = true;
            this.UserIDFrom.Visible = false;
            // 
            // UserIDTo
            // 
            this.UserIDTo.DataPropertyName = "UserIDTo";
            this.UserIDTo.HeaderText = "UserIDTo";
            this.UserIDTo.Name = "UserIDTo";
            this.UserIDTo.ReadOnly = true;
            this.UserIDTo.Visible = false;
            // 
            // From
            // 
            this.From.DataPropertyName = "From";
            this.From.HeaderText = "From";
            this.From.Name = "From";
            this.From.ReadOnly = true;
            // 
            // To
            // 
            this.To.DataPropertyName = "To";
            this.To.HeaderText = "To";
            this.To.Name = "To";
            this.To.ReadOnly = true;
            // 
            // Time
            // 
            this.Time.DataPropertyName = "Time";
            this.Time.HeaderText = "Time (Server)";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Width = 95;
            // 
            // EmailSize
            // 
            this.EmailSize.DataPropertyName = "Size";
            this.EmailSize.HeaderText = "Size (Bytes)";
            this.EmailSize.Name = "EmailSize";
            this.EmailSize.ReadOnly = true;
            // 
            // StatusIDFrom
            // 
            this.StatusIDFrom.DataPropertyName = "StatusIDFrom";
            this.StatusIDFrom.HeaderText = "StatusIDFrom";
            this.StatusIDFrom.Name = "StatusIDFrom";
            this.StatusIDFrom.ReadOnly = true;
            this.StatusIDFrom.Visible = false;
            // 
            // StatusIDTo
            // 
            this.StatusIDTo.DataPropertyName = "StatusIDTo";
            this.StatusIDTo.HeaderText = "StatusIDTo";
            this.StatusIDTo.Name = "StatusIDTo";
            this.StatusIDTo.ReadOnly = true;
            this.StatusIDTo.Visible = false;
            // 
            // Text
            // 
            this.Text.DataPropertyName = "Text";
            this.Text.HeaderText = "Text";
            this.Text.Name = "Text";
            this.Text.ReadOnly = true;
            this.Text.Visible = false;
            // 
            // empty
            // 
            this.empty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.empty.HeaderText = "";
            this.empty.Name = "empty";
            this.empty.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNew,
            this.toolStripButtonDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 241);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(592, 25);
            this.toolStrip1.TabIndex = 22;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonNew
            // 
            this.toolStripButtonNew.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNew.Image")));
            this.toolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNew.Name = "toolStripButtonNew";
            this.toolStripButtonNew.Size = new System.Drawing.Size(48, 22);
            this.toolStripButtonNew.Text = "New";
            this.toolStripButtonNew.Click += new System.EventHandler(this.toolStripButtonNew_Click);
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.editor1);
            this.splitContainer1.Size = new System.Drawing.Size(592, 241);
            this.splitContainer1.SplitterDistance = 121;
            this.splitContainer1.TabIndex = 23;
            // 
            // editor1
            // 
            this.editor1.BodyHtml = null;
            this.editor1.BodyText = null;
            this.editor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor1.DocumentText = resources.GetString("editor1.DocumentText");
            this.editor1.EditorBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.editor1.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.editor1.FontName = null;
            this.editor1.FontSize = Design.FontSize.NA;
            this.editor1.Location = new System.Drawing.Point(0, 0);
            this.editor1.Name = "editor1";
            this.editor1.Size = new System.Drawing.Size(592, 116);
            this.editor1.TabIndex = 1;
            // 
            // SentUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 266);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SentUc";
            this.Load += new System.EventHandler(this.SentUc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteDisable;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonNew;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private Design.Editor editor1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserMessageID;
        private System.Windows.Forms.DataGridViewImageColumn InboxImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserIDFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserIDTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn From;
        private System.Windows.Forms.DataGridViewTextBoxColumn To;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusIDFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusIDTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Text;
        private System.Windows.Forms.DataGridViewTextBoxColumn empty;
    }
}
