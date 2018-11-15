namespace App.Win
{
    partial class frmSelectPiecePromotion
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
            this.btnKnight = new System.Windows.Forms.Button();
            this.btnBishop = new System.Windows.Forms.Button();
            this.btnRook = new System.Windows.Forms.Button();
            this.btnQueen = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnKnight
            // 
            this.btnKnight.Location = new System.Drawing.Point(314, 6);
            this.btnKnight.Name = "btnKnight";
            this.btnKnight.Size = new System.Drawing.Size(82, 73);
            this.btnKnight.TabIndex = 7;
            this.btnKnight.UseVisualStyleBackColor = true;
            this.btnKnight.Click += new System.EventHandler(this.btnKnight_Click);
            // 
            // btnBishop
            // 
            this.btnBishop.Location = new System.Drawing.Point(212, 6);
            this.btnBishop.Name = "btnBishop";
            this.btnBishop.Size = new System.Drawing.Size(82, 73);
            this.btnBishop.TabIndex = 6;
            this.btnBishop.UseVisualStyleBackColor = true;
            this.btnBishop.Click += new System.EventHandler(this.btnBishop_Click);
            // 
            // btnRook
            // 
            this.btnRook.Location = new System.Drawing.Point(111, 6);
            this.btnRook.Name = "btnRook";
            this.btnRook.Size = new System.Drawing.Size(82, 73);
            this.btnRook.TabIndex = 5;
            this.btnRook.UseVisualStyleBackColor = true;
            this.btnRook.Click += new System.EventHandler(this.btnRook_Click);
            // 
            // btnQueen
            // 
            this.btnQueen.Location = new System.Drawing.Point(12, 6);
            this.btnQueen.Name = "btnQueen";
            this.btnQueen.Size = new System.Drawing.Size(82, 73);
            this.btnQueen.TabIndex = 4;
            this.btnQueen.UseVisualStyleBackColor = true;
            this.btnQueen.Click += new System.EventHandler(this.btnQueen_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnQueen);
            this.panel1.Controls.Add(this.btnKnight);
            this.panel1.Controls.Add(this.btnRook);
            this.panel1.Controls.Add(this.btnBishop);
            this.panel1.Location = new System.Drawing.Point(12, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 90);
            this.panel1.TabIndex = 8;
            // 
            // frmSelectPiecePromotion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 126);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectPiecePromotion";
            this.ShowInTaskbar = false;
            this.Text = "Promotion";
            this.Load += new System.EventHandler(this.frmSelectPiecePromotion_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSelectPiecePromotion_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKnight;
        private System.Windows.Forms.Button btnBishop;
        private System.Windows.Forms.Button btnRook;
        private System.Windows.Forms.Button btnQueen;
        private System.Windows.Forms.Panel panel1;
    }
}