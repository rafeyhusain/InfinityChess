namespace App.Win
{
    partial class TeamList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamList));
            this.teamListUc2 = new App.Win.TeamListUc();
            this.SuspendLayout();
            // 
            // teamListUc2
            // 
            this.teamListUc2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teamListUc2.Location = new System.Drawing.Point(0, 0);
            this.teamListUc2.Name = "teamListUc2";
            this.teamListUc2.Size = new System.Drawing.Size(598, 399);
            this.teamListUc2.TabIndex = 0;
            // 
            // TeamList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 399);
            this.Controls.Add(this.teamListUc2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TeamList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Team List";
            this.Load += new System.EventHandler(this.TeamList_Load);
            this.ResumeLayout(false);

		}

		#endregion

        private TeamListUc teamListUc2;


    }
}