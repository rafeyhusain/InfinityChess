namespace App.Win
{
    partial class RankInfoUc
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbRank = new System.Windows.Forms.Label();
            this.lblNextRank = new System.Windows.Forms.Label();
            this.lblBullet = new System.Windows.Forms.Label();
            this.lblLoginDays = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rank:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Next Rank:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Blitz:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Login days:";
            // 
            // lbRank
            // 
            this.lbRank.AutoSize = true;
            this.lbRank.Location = new System.Drawing.Point(88, 14);
            this.lbRank.Name = "lbRank";
            this.lbRank.Size = new System.Drawing.Size(35, 13);
            this.lbRank.TabIndex = 5;
            this.lbRank.Text = "label5";
            // 
            // lblNextRank
            // 
            this.lblNextRank.AutoSize = true;
            this.lblNextRank.Location = new System.Drawing.Point(88, 45);
            this.lblNextRank.Name = "lblNextRank";
            this.lblNextRank.Size = new System.Drawing.Size(35, 13);
            this.lblNextRank.TabIndex = 6;
            this.lblNextRank.Text = "label6";
            // 
            // lblBullet
            // 
            this.lblBullet.AutoSize = true;
            this.lblBullet.Location = new System.Drawing.Point(88, 76);
            this.lblBullet.Name = "lblBullet";
            this.lblBullet.Size = new System.Drawing.Size(35, 13);
            this.lblBullet.TabIndex = 8;
            this.lblBullet.Text = "label8";
            // 
            // lblLoginDays
            // 
            this.lblLoginDays.AutoSize = true;
            this.lblLoginDays.Location = new System.Drawing.Point(88, 107);
            this.lblLoginDays.Name = "lblLoginDays";
            this.lblLoginDays.Size = new System.Drawing.Size(35, 13);
            this.lblLoginDays.TabIndex = 9;
            this.lblLoginDays.Text = "label9";
            // 
            // RankInfoUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblLoginDays);
            this.Controls.Add(this.lblBullet);
            this.Controls.Add(this.lblNextRank);
            this.Controls.Add(this.lbRank);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RankInfoUc";
            this.Size = new System.Drawing.Size(138, 125);
            this.Load += new System.EventHandler(this.RankInfoUc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbRank;
        private System.Windows.Forms.Label lblNextRank;
        private System.Windows.Forms.Label lblBullet;
        private System.Windows.Forms.Label lblLoginDays;
    }
}
