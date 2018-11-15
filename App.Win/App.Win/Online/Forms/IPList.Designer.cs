namespace App.Win
{
    partial class IPList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IPList));
            this.ipListUc1 = new App.Win.IPListUc();
            this.SuspendLayout();
            // 
            // ipListUc1
            // 
            this.ipListUc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ipListUc1.Location = new System.Drawing.Point(0, 0);
            this.ipListUc1.Name = "ipListUc1";
            this.ipListUc1.Size = new System.Drawing.Size(598, 399);
            this.ipListUc1.TabIndex = 0;
            // 
            // IPList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 399);
            this.Controls.Add(this.ipListUc1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IPList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blocked IP List";
            this.Load += new System.EventHandler(this.IPList_Load);
            this.ResumeLayout(false);

		}

		#endregion

        private IPListUc ipListUc1;


    }
}