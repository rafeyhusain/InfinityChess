namespace App.Win
{
    partial class BanUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BanUserForm));
            this.banUserUc1 = new App.Win.BanUserUc();
            this.SuspendLayout();
            // 
            // banUserUc1
            // 
            this.banUserUc1.Location = new System.Drawing.Point(-1, 0);
            this.banUserUc1.Name = "banUserUc1";
            this.banUserUc1.Size = new System.Drawing.Size(553, 391);
            this.banUserUc1.TabIndex = 0;
            this.banUserUc1.UserID = 0;
            this.banUserUc1.UserName = "";
            this.banUserUc1.Load += new System.EventHandler(this.banUserUc1_Load);
            // 
            // BanUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 390);
            this.Controls.Add(this.banUserUc1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BanUserForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.BanUserForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private BanUserUc banUserUc1;



    }
}