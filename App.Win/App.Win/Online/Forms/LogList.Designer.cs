namespace App.Win
{
    partial class LogList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogList));
            this.logListUc2 = new App.Win.LogListUc();
            this.SuspendLayout();
            // 
            // logListUc2
            // 
            this.logListUc2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logListUc2.Location = new System.Drawing.Point(0, 0);
            this.logListUc2.Name = "logListUc2";
            this.logListUc2.Size = new System.Drawing.Size(731, 399);
            this.logListUc2.TabIndex = 0;
            this.logListUc2.Load += new System.EventHandler(this.logListUc2_Load);
            // 
            // LogList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 399);
            this.Controls.Add(this.logListUc2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log List";
            this.ResumeLayout(false);

		}

		#endregion

        private LogListUc logListUc2;


    }
}