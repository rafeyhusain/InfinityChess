namespace App.Win
{
    partial class WebCam
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pctRemoteWebCam = new System.Windows.Forms.PictureBox();
            this.pctLocalWebCam = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctRemoteWebCam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLocalWebCam)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pctRemoteWebCam);
            this.flowLayoutPanel1.Controls.Add(this.pctLocalWebCam);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(353, 144);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // pctRemoteWebCam
            // 
            this.pctRemoteWebCam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctRemoteWebCam.Image = global::InfinityChess.Properties.Resources.NoSignal;
            this.pctRemoteWebCam.Location = new System.Drawing.Point(0, 0);
            this.pctRemoteWebCam.Margin = new System.Windows.Forms.Padding(0);
            this.pctRemoteWebCam.Name = "pctRemoteWebCam";
            this.pctRemoteWebCam.Size = new System.Drawing.Size(176, 144);
            this.pctRemoteWebCam.TabIndex = 0;
            this.pctRemoteWebCam.TabStop = false;
            // 
            // pctLocalWebCam
            // 
            this.pctLocalWebCam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctLocalWebCam.Image = global::InfinityChess.Properties.Resources.NoSignal;
            this.pctLocalWebCam.Location = new System.Drawing.Point(176, 0);
            this.pctLocalWebCam.Margin = new System.Windows.Forms.Padding(0);
            this.pctLocalWebCam.Name = "pctLocalWebCam";
            this.pctLocalWebCam.Size = new System.Drawing.Size(176, 144);
            this.pctLocalWebCam.TabIndex = 1;
            this.pctLocalWebCam.TabStop = false;
            // 
            // WebCam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 144);
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WebCam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "WebCam View";
            //this.OnClosed += new System.EventHandler(this.WebCam_OnClose); 
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctRemoteWebCam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLocalWebCam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        internal System.Windows.Forms.PictureBox pctRemoteWebCam;
        internal System.Windows.Forms.PictureBox pctLocalWebCam;
    }
}