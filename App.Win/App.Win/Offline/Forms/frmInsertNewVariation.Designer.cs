namespace InfinityChess
{
    partial class frmInsertNewVariation
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNewVariant = new System.Windows.Forms.Button();
            this.btnNewMainLine = new System.Windows.Forms.Button();
            this.btnOverwrite = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.lbloldmoves = new System.Windows.Forms.Label();
            this.lstLines = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(0, 206);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNewVariant
            // 
            this.btnNewVariant.Location = new System.Drawing.Point(0, 37);
            this.btnNewVariant.Name = "btnNewVariant";
            this.btnNewVariant.Size = new System.Drawing.Size(75, 22);
            this.btnNewVariant.TabIndex = 0;
            this.btnNewVariant.Text = "New Variation";
            this.btnNewVariant.UseVisualStyleBackColor = true;
            this.btnNewVariant.Click += new System.EventHandler(this.btnNewVariant_Click);
            // 
            // btnNewMainLine
            // 
            this.btnNewMainLine.Location = new System.Drawing.Point(0, 74);
            this.btnNewMainLine.Name = "btnNewMainLine";
            this.btnNewMainLine.Size = new System.Drawing.Size(75, 22);
            this.btnNewMainLine.TabIndex = 1;
            this.btnNewMainLine.Text = "New Main Line";
            this.btnNewMainLine.UseVisualStyleBackColor = true;
            this.btnNewMainLine.Click += new System.EventHandler(this.btnNewMainLine_Click);
            // 
            // btnOverwrite
            // 
            this.btnOverwrite.Location = new System.Drawing.Point(0, 111);
            this.btnOverwrite.Name = "btnOverwrite";
            this.btnOverwrite.Size = new System.Drawing.Size(75, 22);
            this.btnOverwrite.TabIndex = 2;
            this.btnOverwrite.Text = "Overwrite";
            this.btnOverwrite.UseVisualStyleBackColor = true;
            this.btnOverwrite.Click += new System.EventHandler(this.btnOverwrite_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(0, 148);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 22);
            this.btnInsert.TabIndex = 3;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // lbloldmoves
            // 
            this.lbloldmoves.AutoSize = true;
            this.lbloldmoves.Location = new System.Drawing.Point(9, 9);
            this.lbloldmoves.Name = "lbloldmoves";
            this.lbloldmoves.Size = new System.Drawing.Size(57, 13);
            this.lbloldmoves.TabIndex = 7;
            this.lbloldmoves.Text = "Old moves";
            // 
            // lstLines
            // 
            this.lstLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLines.FormattingEnabled = true;
            this.lstLines.Location = new System.Drawing.Point(12, 39);
            this.lstLines.Name = "lstLines";
            this.lstLines.Size = new System.Drawing.Size(187, 134);
            this.lstLines.TabIndex = 8;
            this.lstLines.DoubleClick += new System.EventHandler(this.lstLines_DoubleClick);
            this.lstLines.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstLines_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnNewVariant);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnNewMainLine);
            this.panel1.Controls.Add(this.btnInsert);
            this.panel1.Controls.Add(this.btnOverwrite);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(213, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(81, 236);
            this.panel1.TabIndex = 9;
            // 
            // frmInsertNewVariation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 236);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lstLines);
            this.Controls.Add(this.lbloldmoves);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "frmInsertNewVariation";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Input new move";
            this.Load += new System.EventHandler(this.frmInsertNewVariation_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNewVariant;
        private System.Windows.Forms.Button btnNewMainLine;
        private System.Windows.Forms.Button btnOverwrite;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Label lbloldmoves;
        private System.Windows.Forms.ListBox lstLines;
        private System.Windows.Forms.Panel panel1;
    }
}