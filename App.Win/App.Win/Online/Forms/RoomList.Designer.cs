namespace App.Win
{
    partial class RoomList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomList));
            this.roomListUc1 = new App.Win.RoomListUc();
            this.SuspendLayout();
            // 
            // roomListUc1
            // 
            this.roomListUc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roomListUc1.Location = new System.Drawing.Point(0, 0);
            this.roomListUc1.Name = "roomListUc1";
            this.roomListUc1.Size = new System.Drawing.Size(598, 399);
            this.roomListUc1.TabIndex = 0;
            // 
            // RoomList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 399);
            this.Controls.Add(this.roomListUc1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RoomList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Room List";
            this.ResumeLayout(false);

		}

		#endregion

        private RoomListUc roomListUc1;


    }
}