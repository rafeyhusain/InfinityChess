namespace App.Win
{
    partial class UserList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserList));
            this.userListUc1 = new App.Win.UserListUc();
            this.SuspendLayout();
            // 
            // userListUc1
            // 
            this.userListUc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userListUc1.Location = new System.Drawing.Point(0, 0);
            this.userListUc1.Name = "userListUc1";
            this.userListUc1.Size = new System.Drawing.Size(621, 399);
            this.userListUc1.TabIndex = 0;
            // 
            // UserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 399);
            this.Controls.Add(this.userListUc1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User List";
            this.Load += new System.EventHandler(this.UserList_Load);
            this.ResumeLayout(false);

		}

		#endregion

        private App.Win.UserListUc userListUc1;
	}
}