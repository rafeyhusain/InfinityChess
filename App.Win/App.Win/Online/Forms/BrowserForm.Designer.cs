namespace InfinityChess.Online.Forms
{
    partial class BrowserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserForm));
            this.browserUC = new App.Win.BrowserUc();
            this.SuspendLayout();
            // 
            // browserUC
            // 
            this.browserUC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserUC.Location = new System.Drawing.Point(0, 0);
            this.browserUC.Name = "browserUC";
            this.browserUC.Size = new System.Drawing.Size(956, 631);
            this.browserUC.TabIndex = 0;
            // 
            // BrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 631);
            this.Controls.Add(this.browserUC);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BrowserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.BrowserForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private App.Win.BrowserUc browserUC;
    }
}