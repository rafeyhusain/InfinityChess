namespace App.Win
{
    partial class ChessBoard
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
            this.cmChessBoard = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.flipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boardDesignToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.cmChessBoard.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmChessBoard
            // 
            this.cmChessBoard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flipToolStripMenuItem,
            this.boardDesignToolStripMenuItem});
            this.cmChessBoard.Name = "cmChessBoard";
            this.cmChessBoard.Size = new System.Drawing.Size(138, 48);
            // 
            // flipToolStripMenuItem
            // 
            this.flipToolStripMenuItem.Name = "flipToolStripMenuItem";
            this.flipToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.flipToolStripMenuItem.Text = "Flip Board";
            this.flipToolStripMenuItem.Click += new System.EventHandler(this.flipToolStripMenuItem_Click);
            // 
            // boardDesignToolStripMenuItem
            // 
            this.boardDesignToolStripMenuItem.Name = "boardDesignToolStripMenuItem";
            this.boardDesignToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.boardDesignToolStripMenuItem.Text = "Board Design";
            this.boardDesignToolStripMenuItem.Click += new System.EventHandler(this.boardDesignToolStripMenuItem_Click);
            // 
            // pnlBackground
            // 
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(457, 449);
            this.pnlBackground.TabIndex = 1;
            // 
            // ChessBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.cmChessBoard;
            this.Controls.Add(this.pnlBackground);
            this.Name = "ChessBoard";
            this.Size = new System.Drawing.Size(457, 449);
            this.Load += new System.EventHandler(this.ChessBoard_Load);
            this.cmChessBoard.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmChessBoard;
        private System.Windows.Forms.ToolStripMenuItem flipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boardDesignToolStripMenuItem;
        private System.Windows.Forms.Panel pnlBackground;


    }
}
