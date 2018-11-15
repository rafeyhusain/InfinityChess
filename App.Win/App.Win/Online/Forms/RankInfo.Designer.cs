namespace App.Win
{
    partial class RankInfo
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
            this.btnOK = new System.Windows.Forms.Button();
            this.rankInfoUc1 = new App.Win.RankInfoUc();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(74, 142);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // rankInfoUc1
            // 
            this.rankInfoUc1.Location = new System.Drawing.Point(16, 8);
            this.rankInfoUc1.Name = "rankInfoUc1";
            this.rankInfoUc1.Size = new System.Drawing.Size(195, 128);
            this.rankInfoUc1.TabIndex = 0;
            this.rankInfoUc1.UserID = 0;
            this.rankInfoUc1.UserName = null;
            // 
            // RankInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 173);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.rankInfoUc1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RankInfo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Rank Information";
            this.Load += new System.EventHandler(this.RankInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private App.Win.RankInfoUc rankInfoUc1;
        private System.Windows.Forms.Button btnOK;
    }
}