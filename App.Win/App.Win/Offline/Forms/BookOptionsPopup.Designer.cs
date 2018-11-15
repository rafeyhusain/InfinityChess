namespace App.Win
{
    partial class BookOptionsPopup
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkTournamentBook = new System.Windows.Forms.CheckBox();
            this.chkUseBook = new System.Windows.Forms.CheckBox();
            this.numericMinimumGame = new System.Windows.Forms.NumericUpDown();
            this.numericUpToMove = new System.Windows.Forms.NumericUpDown();
            this.lblMinimumGame = new System.Windows.Forms.Label();
            this.lblUpToMove = new System.Windows.Forms.Label();
            this.btnOptimize = new System.Windows.Forms.Button();
            this.btnNormal = new System.Windows.Forms.Button();
            this.btnHandicap = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinimumGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpToMove)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkTournamentBook);
            this.groupBox1.Controls.Add(this.chkUseBook);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(137, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // chkTournamentBook
            // 
            this.chkTournamentBook.AutoSize = true;
            this.chkTournamentBook.Location = new System.Drawing.Point(15, 42);
            this.chkTournamentBook.Name = "chkTournamentBook";
            this.chkTournamentBook.Size = new System.Drawing.Size(110, 17);
            this.chkTournamentBook.TabIndex = 1;
            this.chkTournamentBook.Text = "Tournament book";
            this.chkTournamentBook.UseVisualStyleBackColor = true;
            // 
            // chkUseBook
            // 
            this.chkUseBook.AutoSize = true;
            this.chkUseBook.Location = new System.Drawing.Point(15, 19);
            this.chkUseBook.Name = "chkUseBook";
            this.chkUseBook.Size = new System.Drawing.Size(72, 17);
            this.chkUseBook.TabIndex = 0;
            this.chkUseBook.Text = "Use book";
            this.chkUseBook.UseVisualStyleBackColor = true;
            // 
            // numericMinimumGame
            // 
            this.numericMinimumGame.Location = new System.Drawing.Point(268, 22);
            this.numericMinimumGame.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericMinimumGame.Name = "numericMinimumGame";
            this.numericMinimumGame.Size = new System.Drawing.Size(50, 20);
            this.numericMinimumGame.TabIndex = 1;
            // 
            // numericUpToMove
            // 
            this.numericUpToMove.Location = new System.Drawing.Point(268, 44);
            this.numericUpToMove.Name = "numericUpToMove";
            this.numericUpToMove.Size = new System.Drawing.Size(50, 20);
            this.numericUpToMove.TabIndex = 2;
            // 
            // lblMinimumGame
            // 
            this.lblMinimumGame.AutoSize = true;
            this.lblMinimumGame.Location = new System.Drawing.Point(170, 22);
            this.lblMinimumGame.Name = "lblMinimumGame";
            this.lblMinimumGame.Size = new System.Drawing.Size(82, 13);
            this.lblMinimumGame.TabIndex = 7;
            this.lblMinimumGame.Text = "Minimum games";
            // 
            // lblUpToMove
            // 
            this.lblUpToMove.AutoSize = true;
            this.lblUpToMove.Location = new System.Drawing.Point(170, 46);
            this.lblUpToMove.Name = "lblUpToMove";
            this.lblUpToMove.Size = new System.Drawing.Size(62, 13);
            this.lblUpToMove.TabIndex = 8;
            this.lblUpToMove.Text = "Up to move";
            // 
            // btnOptimize
            // 
            this.btnOptimize.Location = new System.Drawing.Point(12, 90);
            this.btnOptimize.Name = "btnOptimize";
            this.btnOptimize.Size = new System.Drawing.Size(75, 22);
            this.btnOptimize.TabIndex = 3;
            this.btnOptimize.Text = "Optimize";
            this.btnOptimize.UseVisualStyleBackColor = true;
            this.btnOptimize.Click += new System.EventHandler(this.btnOptimize_Click);
            // 
            // btnNormal
            // 
            this.btnNormal.Location = new System.Drawing.Point(12, 119);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(75, 22);
            this.btnNormal.TabIndex = 4;
            this.btnNormal.Text = "Normal";
            this.btnNormal.UseVisualStyleBackColor = true;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // btnHandicap
            // 
            this.btnHandicap.Location = new System.Drawing.Point(12, 147);
            this.btnHandicap.Name = "btnHandicap";
            this.btnHandicap.Size = new System.Drawing.Size(75, 22);
            this.btnHandicap.TabIndex = 5;
            this.btnHandicap.Text = "Handicap";
            this.btnHandicap.UseVisualStyleBackColor = true;
            this.btnHandicap.Click += new System.EventHandler(this.btnHandicap_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(76, 185);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 22);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(159, 185);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 22);
            this.btnHelp.TabIndex = 7;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(242, 185);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // BookOptionsPopup
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(325, 219);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnHandicap);
            this.Controls.Add(this.btnNormal);
            this.Controls.Add(this.btnOptimize);
            this.Controls.Add(this.lblUpToMove);
            this.Controls.Add(this.lblMinimumGame);
            this.Controls.Add(this.numericUpToMove);
            this.Controls.Add(this.numericMinimumGame);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BookOptionsPopup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Book Options";
            this.Load += new System.EventHandler(this.BookOptionsPopup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinimumGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpToMove)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkTournamentBook;
        private System.Windows.Forms.CheckBox chkUseBook;
        private System.Windows.Forms.NumericUpDown numericMinimumGame;
        private System.Windows.Forms.NumericUpDown numericUpToMove;
        private System.Windows.Forms.Label lblMinimumGame;
        private System.Windows.Forms.Label lblUpToMove;
        private System.Windows.Forms.Button btnOptimize;
        private System.Windows.Forms.Button btnNormal;
        private System.Windows.Forms.Button btnHandicap;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnCancel;
    }
}