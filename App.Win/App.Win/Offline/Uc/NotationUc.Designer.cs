namespace InfinityChess
{
    partial class NotationUc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.capturePieceUc1 = new InfinityChess.CapturePieceUc();
            this.gameInfoUc1 = new InfinityChess.GameInfoUc();
            this.dgvNotation = new System.Windows.Forms.DataGridView();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.notationText1 = new App.Win.NotationText();
            this.cmsNotation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMoveComments = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMoveLog = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotation)).BeginInit();
            this.cmsNotation.SuspendLayout();
            this.SuspendLayout();
            // 
            // capturePieceUc1
            // 
            this.capturePieceUc1.BackColor = System.Drawing.Color.Wheat;
            this.capturePieceUc1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.capturePieceUc1.Location = new System.Drawing.Point(0, 213);
            this.capturePieceUc1.Name = "capturePieceUc1";
            this.capturePieceUc1.Size = new System.Drawing.Size(360, 27);
            this.capturePieceUc1.TabIndex = 1;
            // 
            // gameInfoUc1
            // 
            this.gameInfoUc1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gameInfoUc1.EcoDiscription = "eco";
            this.gameInfoUc1.Location = new System.Drawing.Point(0, 0);
            this.gameInfoUc1.Name = "gameInfoUc1";
            this.gameInfoUc1.Size = new System.Drawing.Size(360, 53);
            this.gameInfoUc1.TabIndex = 2;
            // 
            // dgvNotation
            // 
            this.dgvNotation.AllowUserToAddRows = false;
            this.dgvNotation.AllowUserToDeleteRows = false;
            this.dgvNotation.AllowUserToResizeColumns = false;
            this.dgvNotation.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            this.dgvNotation.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvNotation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvNotation.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvNotation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvNotation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotation.ColumnHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNotation.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvNotation.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgvNotation.Location = new System.Drawing.Point(0, 59);
            this.dgvNotation.MultiSelect = false;
            this.dgvNotation.Name = "dgvNotation";
            this.dgvNotation.ReadOnly = true;
            this.dgvNotation.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgvNotation.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvNotation.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgvNotation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvNotation.Size = new System.Drawing.Size(186, 47);
            this.dgvNotation.TabIndex = 0;
            this.dgvNotation.Visible = false;
            this.dgvNotation.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvNotation_CellFormatting);
            this.dgvNotation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvNotation_KeyDown);
            this.dgvNotation.SelectionChanged += new System.EventHandler(this.dgvNotation_SelectionChanged);
            // 
            // elementHost1
            // 
            this.elementHost1.BackColor = System.Drawing.Color.White;
            this.elementHost1.ContextMenuStrip = this.cmsNotation;
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(0, 53);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(360, 160);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.notationText1;
            // 
            // cmsNotation
            // 
            this.cmsNotation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMoveComments,
            this.tsMoveLog});
            this.cmsNotation.Name = "cmsOpeningBook";
            this.cmsNotation.Size = new System.Drawing.Size(190, 70);
            // 
            // tsMoveComments
            // 
            this.tsMoveComments.Name = "tsMoveComments";
            this.tsMoveComments.Size = new System.Drawing.Size(189, 22);
            this.tsMoveComments.Text = "Show Comments";
            this.tsMoveComments.Click += new System.EventHandler(this.tsMoveComments_Click);
            // 
            // tsMoveLog
            // 
            this.tsMoveLog.Name = "tsMoveLog";
            this.tsMoveLog.Size = new System.Drawing.Size(189, 22);
            this.tsMoveLog.Text = "Show Disconnection Log";
            this.tsMoveLog.Click += new System.EventHandler(this.tsMoveLog_Click);
            // 
            // NotationUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 240);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.dgvNotation);
            this.Controls.Add(this.gameInfoUc1);
            this.Controls.Add(this.capturePieceUc1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "NotationUc";
            this.Load += new System.EventHandler(this.NotationUc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotation)).EndInit();
            this.cmsNotation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CapturePieceUc capturePieceUc1;
        private GameInfoUc gameInfoUc1;
        private System.Windows.Forms.DataGridView dgvNotation;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private App.Win.NotationText notationText1;
        private System.Windows.Forms.ContextMenuStrip cmsNotation;
        private System.Windows.Forms.ToolStripMenuItem tsMoveComments;
        private System.Windows.Forms.ToolStripMenuItem tsMoveLog;

    }
}
