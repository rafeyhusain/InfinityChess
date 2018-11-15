namespace App.Win
{
    partial class WorldUc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(App.Win.WorldUc));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoonOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showFriendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInToolStripMenuItem,
            this.zoonOutToolStripMenuItem,
            this.centerToolStripMenuItem,
            this.showToolStripMenuItem,
            this.showFriendToolStripMenuItem,
            this.toggleToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 126);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(597, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("zoomInToolStripMenuItem.Image")));
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.zoomInToolStripMenuItem.Text = "Zoom in";
            // 
            // zoonOutToolStripMenuItem
            // 
            this.zoonOutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("zoonOutToolStripMenuItem.Image")));
            this.zoonOutToolStripMenuItem.Name = "zoonOutToolStripMenuItem";
            this.zoonOutToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.zoonOutToolStripMenuItem.Text = "Zoon out";
            // 
            // centerToolStripMenuItem
            // 
            this.centerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("centerToolStripMenuItem.Image")));
            this.centerToolStripMenuItem.Name = "centerToolStripMenuItem";
            this.centerToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.centerToolStripMenuItem.Text = "Center";
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showToolStripMenuItem.Image")));
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.showToolStripMenuItem.Text = "Show Day/Night";
            // 
            // showFriendToolStripMenuItem
            // 
            this.showFriendToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showFriendToolStripMenuItem.Image")));
            this.showFriendToolStripMenuItem.Name = "showFriendToolStripMenuItem";
            this.showFriendToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.showFriendToolStripMenuItem.Text = "Show Friends";
            // 
            // toggleToolStripMenuItem
            // 
            this.toggleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("toggleToolStripMenuItem.Image")));
            this.toggleToolStripMenuItem.Name = "toggleToolStripMenuItem";
            this.toggleToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.toggleToolStripMenuItem.Text = "Toggle Projection";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(597, 126);
            this.webBrowser1.TabIndex = 4;
            // 
            // WorldUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "WorldUc";
            this.Size = new System.Drawing.Size(597, 150);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoonOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showFriendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleToolStripMenuItem;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}
