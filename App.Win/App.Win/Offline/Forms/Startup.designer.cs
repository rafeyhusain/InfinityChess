namespace InfinityChess.Winforms
{
    partial class Startup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Startup));
            this.pbPlayInfinityChess = new System.Windows.Forms.PictureBox();
            this.pbInfinityChess = new System.Windows.Forms.PictureBox();
            this.pbQuit = new System.Windows.Forms.PictureBox();
            this.pbHelp = new System.Windows.Forms.PictureBox();
            this.lblVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayInfinityChess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfinityChess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPlayInfinityChess
            // 
            this.pbPlayInfinityChess.BackColor = System.Drawing.Color.Transparent;
            this.pbPlayInfinityChess.Image = global::InfinityChess.Properties.Resources.Play;
            this.pbPlayInfinityChess.Location = new System.Drawing.Point(35, 452);
            this.pbPlayInfinityChess.Name = "pbPlayInfinityChess";
            this.pbPlayInfinityChess.Size = new System.Drawing.Size(133, 39);
            this.pbPlayInfinityChess.TabIndex = 4;
            this.pbPlayInfinityChess.TabStop = false;
            this.pbPlayInfinityChess.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pbInfinityChess
            // 
            this.pbInfinityChess.BackColor = System.Drawing.Color.Transparent;
            this.pbInfinityChess.Image = global::InfinityChess.Properties.Resources.Play_Online;
            this.pbInfinityChess.Location = new System.Drawing.Point(430, 452);
            this.pbInfinityChess.Name = "pbInfinityChess";
            this.pbInfinityChess.Size = new System.Drawing.Size(133, 39);
            this.pbInfinityChess.TabIndex = 6;
            this.pbInfinityChess.TabStop = false;
            this.pbInfinityChess.Click += new System.EventHandler(this.pbInfinityChess_Click);
            // 
            // pbQuit
            // 
            this.pbQuit.BackColor = System.Drawing.Color.Transparent;
            this.pbQuit.Image = ((System.Drawing.Image)(resources.GetObject("pbQuit.Image")));
            this.pbQuit.Location = new System.Drawing.Point(430, 511);
            this.pbQuit.Name = "pbQuit";
            this.pbQuit.Size = new System.Drawing.Size(133, 39);
            this.pbQuit.TabIndex = 7;
            this.pbQuit.TabStop = false;
            this.pbQuit.Click += new System.EventHandler(this.pbQuit_Click);
            // 
            // pbHelp
            // 
            this.pbHelp.BackColor = System.Drawing.Color.Transparent;
            this.pbHelp.Image = ((System.Drawing.Image)(resources.GetObject("pbHelp.Image")));
            this.pbHelp.Location = new System.Drawing.Point(38, 511);
            this.pbHelp.Name = "pbHelp";
            this.pbHelp.Size = new System.Drawing.Size(133, 39);
            this.pbHelp.TabIndex = 8;
            this.pbHelp.TabStop = false;
            this.pbHelp.Click += new System.EventHandler(this.pbHelp_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.Silver;
            this.lblVersion.Location = new System.Drawing.Point(359, 144);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(57, 19);
            this.lblVersion.TabIndex = 9;
            this.lblVersion.Text = "2.0.0.0";
            // 
            // Startup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(598, 598);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.pbHelp);
            this.Controls.Add(this.pbQuit);
            this.Controls.Add(this.pbInfinityChess);
            this.Controls.Add(this.pbPlayInfinityChess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Startup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Infinity Chess";
            this.Load += new System.EventHandler(this.Startup_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Startup_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayInfinityChess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfinityChess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPlayInfinityChess;
        private System.Windows.Forms.PictureBox pbInfinityChess;
        private System.Windows.Forms.PictureBox pbQuit;
        private System.Windows.Forms.PictureBox pbHelp;
        private System.Windows.Forms.Label lblVersion;
    }
}

