namespace InfinityChess
{
    partial class BookUc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookUc));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmsOpeningBook = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMoveTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMoveTypeNone = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMoveTypeFreeze = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMainMove = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDontPlayTournamentMove = new System.Windows.Forms.ToolStripMenuItem();
            this.tsChangeWeight = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsLoadBook = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCloseBook = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAllowMoveAdding = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.newOpeningBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importPGNGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdLoadOpeningBook = new System.Windows.Forms.OpenFileDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnLoadOpeningBook = new System.Windows.Forms.Button();
            this.dgvOpeningBook = new System.Windows.Forms.DataGridView();
            this.To = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WinCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValuePercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueAvg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Perf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueFactProbPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsWhite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoveNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrawCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LostCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoveType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.From = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Piece = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoveFlags = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CapturedPiece = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoveKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsOpeningBook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpeningBook)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsOpeningBook
            // 
            this.cmsOpeningBook.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMoveTypes,
            this.tsMainMove,
            this.tsDontPlayTournamentMove,
            this.tsChangeWeight,
            this.toolStripSeparator1,
            this.tsLoadBook,
            this.tsSave,
            this.tsCloseBook,
            this.tsAllowMoveAdding,
            this.toolStripSeparator2,
            this.newOpeningBookToolStripMenuItem,
            this.importGameToolStripMenuItem,
            this.importPGNGameToolStripMenuItem,
            this.bookOptionsToolStripMenuItem});
            this.cmsOpeningBook.Name = "cmsOpeningBook";
            this.cmsOpeningBook.Size = new System.Drawing.Size(172, 280);
            // 
            // tsMoveTypes
            // 
            this.tsMoveTypes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMoveTypeNone,
            this.tsMoveTypeFreeze});
            this.tsMoveTypes.Name = "tsMoveTypes";
            this.tsMoveTypes.Size = new System.Drawing.Size(171, 22);
            this.tsMoveTypes.Text = "?...";
            // 
            // tsMoveTypeNone
            // 
            this.tsMoveTypeNone.Name = "tsMoveTypeNone";
            this.tsMoveTypeNone.Size = new System.Drawing.Size(99, 22);
            this.tsMoveTypeNone.Text = "None";
            this.tsMoveTypeNone.Click += new System.EventHandler(this.tsMoveTypeNone_Click);
            // 
            // tsMoveTypeFreeze
            // 
            this.tsMoveTypeFreeze.Name = "tsMoveTypeFreeze";
            this.tsMoveTypeFreeze.Size = new System.Drawing.Size(99, 22);
            this.tsMoveTypeFreeze.Text = "?";
            this.tsMoveTypeFreeze.Click += new System.EventHandler(this.tsMoveTypeFreeze_Click);
            // 
            // tsMainMove
            // 
            this.tsMainMove.Name = "tsMainMove";
            this.tsMainMove.Size = new System.Drawing.Size(171, 22);
            this.tsMainMove.Text = "Mark green";
            this.tsMainMove.Click += new System.EventHandler(this.tsMainMove_Click);
            // 
            // tsDontPlayTournamentMove
            // 
            this.tsDontPlayTournamentMove.Name = "tsDontPlayTournamentMove";
            this.tsDontPlayTournamentMove.Size = new System.Drawing.Size(171, 22);
            this.tsDontPlayTournamentMove.Text = "Mark red";
            this.tsDontPlayTournamentMove.Click += new System.EventHandler(this.tsDontPlayTournamentMove_Click);
            // 
            // tsChangeWeight
            // 
            this.tsChangeWeight.Name = "tsChangeWeight";
            this.tsChangeWeight.Size = new System.Drawing.Size(171, 22);
            this.tsChangeWeight.Text = "Change weight";
            this.tsChangeWeight.Click += new System.EventHandler(this.tsChangeWeight_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
            // 
            // tsLoadBook
            // 
            this.tsLoadBook.Name = "tsLoadBook";
            this.tsLoadBook.Size = new System.Drawing.Size(171, 22);
            this.tsLoadBook.Text = "Load Book";
            this.tsLoadBook.Click += new System.EventHandler(this.tsLoadBook_Click);
            // 
            // tsSave
            // 
            this.tsSave.Name = "tsSave";
            this.tsSave.Size = new System.Drawing.Size(171, 22);
            this.tsSave.Text = "Save Book";
            this.tsSave.Click += new System.EventHandler(this.tsSave_Click);
            // 
            // tsCloseBook
            // 
            this.tsCloseBook.Name = "tsCloseBook";
            this.tsCloseBook.Size = new System.Drawing.Size(171, 22);
            this.tsCloseBook.Text = "Close Book";
            this.tsCloseBook.Click += new System.EventHandler(this.tsCloseBook_Click);
            // 
            // tsAllowMoveAdding
            // 
            this.tsAllowMoveAdding.Name = "tsAllowMoveAdding";
            this.tsAllowMoveAdding.Size = new System.Drawing.Size(171, 22);
            this.tsAllowMoveAdding.Text = "Allow Move Adding";
            this.tsAllowMoveAdding.Click += new System.EventHandler(this.tsAllowMoveAdding_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(168, 6);
            // 
            // newOpeningBookToolStripMenuItem
            // 
            this.newOpeningBookToolStripMenuItem.Name = "newOpeningBookToolStripMenuItem";
            this.newOpeningBookToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.newOpeningBookToolStripMenuItem.Text = "New Opening Book";
            this.newOpeningBookToolStripMenuItem.Click += new System.EventHandler(this.newOpeningBookToolStripMenuItem_Click);
            // 
            // importGameToolStripMenuItem
            // 
            this.importGameToolStripMenuItem.Name = "importGameToolStripMenuItem";
            this.importGameToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.importGameToolStripMenuItem.Text = "Import Game...";
            this.importGameToolStripMenuItem.Click += new System.EventHandler(this.importGameToolStripMenuItem_Click);
            // 
            // importPGNGameToolStripMenuItem
            // 
            this.importPGNGameToolStripMenuItem.Name = "importPGNGameToolStripMenuItem";
            this.importPGNGameToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.importPGNGameToolStripMenuItem.Text = "Import PGN Game...";
            this.importPGNGameToolStripMenuItem.Click += new System.EventHandler(this.importPGNGameToolStripMenuItem_Click);
            // 
            // bookOptionsToolStripMenuItem
            // 
            this.bookOptionsToolStripMenuItem.Name = "bookOptionsToolStripMenuItem";
            this.bookOptionsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.bookOptionsToolStripMenuItem.Text = "Book Options...";
            this.bookOptionsToolStripMenuItem.Click += new System.EventHandler(this.bookOptionsToolStripMenuItem_Click);
            // 
            // ofdLoadOpeningBook
            // 
            this.ofdLoadOpeningBook.FileName = "*.icb";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "tree.png");
            // 
            // btnLoadOpeningBook
            // 
            this.btnLoadOpeningBook.BackColor = System.Drawing.Color.Transparent;
            this.btnLoadOpeningBook.ForeColor = System.Drawing.Color.Black;
            this.btnLoadOpeningBook.Location = new System.Drawing.Point(2, 1);
            this.btnLoadOpeningBook.Name = "btnLoadOpeningBook";
            this.btnLoadOpeningBook.Size = new System.Drawing.Size(122, 23);
            this.btnLoadOpeningBook.TabIndex = 18;
            this.btnLoadOpeningBook.Text = "Load Opening Book";
            this.btnLoadOpeningBook.UseVisualStyleBackColor = false;
            this.btnLoadOpeningBook.Visible = false;
            this.btnLoadOpeningBook.Click += new System.EventHandler(this.btnLoadOpeningBook_Click);
            // 
            // dgvOpeningBook
            // 
            this.dgvOpeningBook.AllowUserToAddRows = false;
            this.dgvOpeningBook.AllowUserToDeleteRows = false;
            this.dgvOpeningBook.AllowUserToResizeColumns = false;
            this.dgvOpeningBook.AllowUserToResizeRows = false;
            this.dgvOpeningBook.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvOpeningBook.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(184)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOpeningBook.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOpeningBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOpeningBook.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.To,
            this.WinCount,
            this.ValuePercent,
            this.ValueAvg,
            this.Perf,
            this.Fact,
            this.Prob,
            this.ValueFactProbPercent,
            this.Id,
            this.IsWhite,
            this.MoveNumber,
            this.Fen,
            this.DrawCount,
            this.LostCount,
            this.MoveType,
            this.ParentId,
            this.From,
            this.Piece,
            this.MoveFlags,
            this.CapturedPiece,
            this.MoveKey});
            this.dgvOpeningBook.ContextMenuStrip = this.cmsOpeningBook;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(234)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(59)))), ((int)(((byte)(27)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOpeningBook.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvOpeningBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOpeningBook.GridColor = System.Drawing.SystemColors.Control;
            this.dgvOpeningBook.Location = new System.Drawing.Point(0, 0);
            this.dgvOpeningBook.MultiSelect = false;
            this.dgvOpeningBook.Name = "dgvOpeningBook";
            this.dgvOpeningBook.ReadOnly = true;
            this.dgvOpeningBook.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            this.dgvOpeningBook.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvOpeningBook.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvOpeningBook.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOpeningBook.Size = new System.Drawing.Size(536, 278);
            this.dgvOpeningBook.TabIndex = 17;
            this.dgvOpeningBook.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dgvOpeningBook_CellContextMenuStripNeeded);
            this.dgvOpeningBook.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvOpeningBook_CellFormatting);
            this.dgvOpeningBook.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOpeningBook_CellClick);
            this.dgvOpeningBook.SelectionChanged += new System.EventHandler(this.dgvOpeningBook_SelectionChanged);
            // 
            // To
            // 
            this.To.DataPropertyName = "T";
            this.To.Frozen = true;
            this.To.HeaderText = "To";
            this.To.Name = "To";
            this.To.ReadOnly = true;
            // 
            // WinCount
            // 
            this.WinCount.DataPropertyName = "W";
            this.WinCount.HeaderText = "Win";
            this.WinCount.Name = "WinCount";
            this.WinCount.ReadOnly = true;
            this.WinCount.Width = 60;
            // 
            // ValuePercent
            // 
            this.ValuePercent.DataPropertyName = "A";
            this.ValuePercent.HeaderText = "%";
            this.ValuePercent.Name = "ValuePercent";
            this.ValuePercent.ReadOnly = true;
            this.ValuePercent.Width = 60;
            // 
            // ValueAvg
            // 
            this.ValueAvg.DataPropertyName = "V";
            this.ValueAvg.HeaderText = "Avg Elo";
            this.ValueAvg.Name = "ValueAvg";
            this.ValueAvg.ReadOnly = true;
            this.ValueAvg.Width = 60;
            // 
            // Perf
            // 
            this.Perf.DataPropertyName = "R";
            this.Perf.HeaderText = "Perf";
            this.Perf.Name = "Perf";
            this.Perf.ReadOnly = true;
            this.Perf.Width = 60;
            // 
            // Fact
            // 
            this.Fact.DataPropertyName = "C";
            this.Fact.HeaderText = "Fact";
            this.Fact.Name = "Fact";
            this.Fact.ReadOnly = true;
            // 
            // Prob
            // 
            this.Prob.DataPropertyName = "B";
            this.Prob.HeaderText = "Prob";
            this.Prob.Name = "Prob";
            this.Prob.ReadOnly = true;
            // 
            // ValueFactProbPercent
            // 
            this.ValueFactProbPercent.DataPropertyName = "G";
            this.ValueFactProbPercent.HeaderText = "(%)";
            this.ValueFactProbPercent.Name = "ValueFactProbPercent";
            this.ValueFactProbPercent.ReadOnly = true;
            this.ValueFactProbPercent.Visible = false;
            this.ValueFactProbPercent.Width = 60;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "I";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // IsWhite
            // 
            this.IsWhite.DataPropertyName = "H";
            this.IsWhite.HeaderText = "IsWhite";
            this.IsWhite.Name = "IsWhite";
            this.IsWhite.ReadOnly = true;
            this.IsWhite.Visible = false;
            // 
            // MoveNumber
            // 
            this.MoveNumber.DataPropertyName = "M";
            this.MoveNumber.HeaderText = "MoveNumber";
            this.MoveNumber.Name = "MoveNumber";
            this.MoveNumber.ReadOnly = true;
            this.MoveNumber.Visible = false;
            // 
            // Fen
            // 
            this.Fen.DataPropertyName = "E";
            this.Fen.HeaderText = "Fen";
            this.Fen.Name = "Fen";
            this.Fen.ReadOnly = true;
            this.Fen.Visible = false;
            // 
            // DrawCount
            // 
            this.DrawCount.DataPropertyName = "D";
            this.DrawCount.HeaderText = "DrawCount";
            this.DrawCount.Name = "DrawCount";
            this.DrawCount.ReadOnly = true;
            this.DrawCount.Visible = false;
            // 
            // LostCount
            // 
            this.LostCount.DataPropertyName = "L";
            this.LostCount.HeaderText = "LostCount";
            this.LostCount.Name = "LostCount";
            this.LostCount.ReadOnly = true;
            this.LostCount.Visible = false;
            // 
            // MoveType
            // 
            this.MoveType.DataPropertyName = "Y";
            this.MoveType.HeaderText = "MoveType";
            this.MoveType.Name = "MoveType";
            this.MoveType.ReadOnly = true;
            this.MoveType.Visible = false;
            // 
            // ParentId
            // 
            this.ParentId.DataPropertyName = "P";
            this.ParentId.HeaderText = "ParentId";
            this.ParentId.Name = "ParentId";
            this.ParentId.ReadOnly = true;
            this.ParentId.Visible = false;
            // 
            // From
            // 
            this.From.DataPropertyName = "F";
            this.From.HeaderText = "From";
            this.From.Name = "From";
            this.From.ReadOnly = true;
            this.From.Visible = false;
            // 
            // Piece
            // 
            this.Piece.DataPropertyName = "O";
            this.Piece.HeaderText = "Piece";
            this.Piece.Name = "Piece";
            this.Piece.ReadOnly = true;
            this.Piece.Visible = false;
            // 
            // MoveFlags
            // 
            this.MoveFlags.DataPropertyName = "S";
            this.MoveFlags.HeaderText = "MoveFlags";
            this.MoveFlags.Name = "MoveFlags";
            this.MoveFlags.ReadOnly = true;
            this.MoveFlags.Visible = false;
            // 
            // CapturedPiece
            // 
            this.CapturedPiece.DataPropertyName = "X";
            this.CapturedPiece.HeaderText = "CapturedPiece";
            this.CapturedPiece.Name = "CapturedPiece";
            this.CapturedPiece.ReadOnly = true;
            this.CapturedPiece.Visible = false;
            // 
            // MoveKey
            // 
            this.MoveKey.DataPropertyName = "K";
            this.MoveKey.HeaderText = "Key";
            this.MoveKey.Name = "MoveKey";
            this.MoveKey.ReadOnly = true;
            this.MoveKey.Visible = false;
            // 
            // BookUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 278);
            this.Controls.Add(this.btnLoadOpeningBook);
            this.Controls.Add(this.dgvOpeningBook);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "BookUc";
            this.Load += new System.EventHandler(this.BookUc_Load);
            this.cmsOpeningBook.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpeningBook)).EndInit();
            this.ResumeLayout(false);

        }             
        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsOpeningBook;
        private System.Windows.Forms.ToolStripMenuItem tsMainMove;
        private System.Windows.Forms.ToolStripMenuItem tsDontPlayTournamentMove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsLoadBook;
        private System.Windows.Forms.ToolStripMenuItem tsSave;
        private System.Windows.Forms.ToolStripMenuItem tsCloseBook;
        private System.Windows.Forms.OpenFileDialog ofdLoadOpeningBook;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnLoadOpeningBook;
        private System.Windows.Forms.DataGridView dgvOpeningBook;
        private System.Windows.Forms.ToolStripMenuItem tsAllowMoveAdding;
        private System.Windows.Forms.ToolStripMenuItem tsMoveTypes;
        private System.Windows.Forms.ToolStripMenuItem tsMoveTypeNone;
        private System.Windows.Forms.ToolStripMenuItem tsMoveTypeFreeze;
        private System.Windows.Forms.ToolStripMenuItem tsChangeWeight;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem newOpeningBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importPGNGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookOptionsToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn To;
        private System.Windows.Forms.DataGridViewTextBoxColumn WinCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValuePercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueAvg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Perf;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fact;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prob;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueFactProbPercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsWhite;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoveNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrawCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn LostCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoveType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn From;
        private System.Windows.Forms.DataGridViewTextBoxColumn Piece;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoveFlags;
        private System.Windows.Forms.DataGridViewTextBoxColumn CapturedPiece;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoveKey;

    }
}
