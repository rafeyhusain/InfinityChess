namespace InfinityChess.Online.Forms
{
    partial class ServerStatistic
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
            this.serverStatisticsUc1 = new InfinityChess.Online.Uc.ServerStatisticsUc();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serverStatisticsUc1
            // 
            this.serverStatisticsUc1.Location = new System.Drawing.Point(10, 8);
            this.serverStatisticsUc1.Name = "serverStatisticsUc1";
            this.serverStatisticsUc1.Size = new System.Drawing.Size(267, 239);
            this.serverStatisticsUc1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(101, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ServerStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 283);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.serverStatisticsUc1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServerStatistic";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Server Statistics";
            this.Load += new System.EventHandler(this.ServerStatistics_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private InfinityChess.Online.Uc.ServerStatisticsUc serverStatisticsUc1;
        private System.Windows.Forms.Button button1;
    }
}