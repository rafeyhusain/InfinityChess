namespace App.Win
{
    partial class GameSearchProgress
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
            this.components = new System.ComponentModel.Container();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblGameNo = new System.Windows.Forms.Label();
            this.lblTimeConsumed = new System.Windows.Forms.Label();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.Red;
            this.progressBar1.Location = new System.Drawing.Point(23, 13);
            this.progressBar1.Maximum = 100000000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(436, 35);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 6;
            this.progressBar1.Value = 1;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // lblGameNo
            // 
            this.lblGameNo.AutoSize = true;
            this.lblGameNo.Location = new System.Drawing.Point(30, 52);
            this.lblGameNo.Name = "lblGameNo";
            this.lblGameNo.Size = new System.Drawing.Size(0, 13);
            this.lblGameNo.TabIndex = 7;
            // 
            // lblTimeConsumed
            // 
            this.lblTimeConsumed.AutoSize = true;
            this.lblTimeConsumed.Location = new System.Drawing.Point(235, 52);
            this.lblTimeConsumed.Name = "lblTimeConsumed";
            this.lblTimeConsumed.Size = new System.Drawing.Size(0, 13);
            this.lblTimeConsumed.TabIndex = 8;
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.Location = new System.Drawing.Point(391, 52);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(0, 13);
            this.lblPercentage.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(384, 74);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // GameSearchProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 110);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblPercentage);
            this.Controls.Add(this.lblTimeConsumed);
            this.Controls.Add(this.lblGameNo);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSearchProgress";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Searching Games...";
            this.Load += new System.EventHandler(this.GameSearchProgress_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameSearchProgress_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblGameNo;
        private System.Windows.Forms.Label lblTimeConsumed;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Timer timer1;
    }
}