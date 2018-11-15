namespace App.Win
{
    partial class NewsList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewsList));
            this.newsListUc1 = new App.Win.NewsListUc();
            this.SuspendLayout();
            // 
            // newsListUc1
            // 
            this.newsListUc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newsListUc1.Location = new System.Drawing.Point(0, 0);
            this.newsListUc1.Name = "newsListUc1";
            this.newsListUc1.Size = new System.Drawing.Size(598, 399);
            this.newsListUc1.TabIndex = 0;
            // 
            // NewsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 399);
            this.Controls.Add(this.newsListUc1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewsList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "News List";
            this.Load += new System.EventHandler(this.UserList_Load);
            this.ResumeLayout(false);

		}

		#endregion

        private NewsListUc newsListUc1;

    }
}