namespace InfinityChess.Online
{
    partial class ServerTimeUc
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
            this.gbServerTime = new System.Windows.Forms.GroupBox();
            this.dtpServerTimeB = new System.Windows.Forms.DateTimePicker();
            this.dtpServerTimeA = new System.Windows.Forms.DateTimePicker();
            this.gbLocalTime = new System.Windows.Forms.GroupBox();
            this.dtpLocalTimeB = new System.Windows.Forms.DateTimePicker();
            this.dtpLocalTimeA = new System.Windows.Forms.DateTimePicker();
            this.gbServerTime.SuspendLayout();
            this.gbLocalTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbServerTime
            // 
            this.gbServerTime.Controls.Add(this.dtpServerTimeB);
            this.gbServerTime.Controls.Add(this.dtpServerTimeA);
            this.gbServerTime.Location = new System.Drawing.Point(6, 5);
            this.gbServerTime.Name = "gbServerTime";
            this.gbServerTime.Size = new System.Drawing.Size(137, 123);
            this.gbServerTime.TabIndex = 0;
            this.gbServerTime.TabStop = false;
            this.gbServerTime.Text = "Server Time";
            // 
            // dtpServerTimeB
            // 
            this.dtpServerTimeB.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpServerTimeB.Location = new System.Drawing.Point(20, 66);
            this.dtpServerTimeB.Name = "dtpServerTimeB";
            this.dtpServerTimeB.ShowUpDown = true;
            this.dtpServerTimeB.Size = new System.Drawing.Size(110, 20);
            this.dtpServerTimeB.TabIndex = 1;
            this.dtpServerTimeB.ValueChanged += new System.EventHandler(this.dtpServerTimeB_ValueChanged);
            this.dtpServerTimeB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpServerTimeB_KeyDown);
            // 
            // dtpServerTimeA
            // 
            this.dtpServerTimeA.Enabled = false;
            this.dtpServerTimeA.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpServerTimeA.Location = new System.Drawing.Point(20, 32);
            this.dtpServerTimeA.Name = "dtpServerTimeA";
            this.dtpServerTimeA.ShowUpDown = true;
            this.dtpServerTimeA.Size = new System.Drawing.Size(110, 20);
            this.dtpServerTimeA.TabIndex = 0;
            // 
            // gbLocalTime
            // 
            this.gbLocalTime.Controls.Add(this.dtpLocalTimeB);
            this.gbLocalTime.Controls.Add(this.dtpLocalTimeA);
            this.gbLocalTime.Location = new System.Drawing.Point(148, 5);
            this.gbLocalTime.Name = "gbLocalTime";
            this.gbLocalTime.Size = new System.Drawing.Size(137, 123);
            this.gbLocalTime.TabIndex = 2;
            this.gbLocalTime.TabStop = false;
            this.gbLocalTime.Text = "Local Time";
            // 
            // dtpLocalTimeB
            // 
            this.dtpLocalTimeB.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpLocalTimeB.Location = new System.Drawing.Point(20, 66);
            this.dtpLocalTimeB.Name = "dtpLocalTimeB";
            this.dtpLocalTimeB.ShowUpDown = true;
            this.dtpLocalTimeB.Size = new System.Drawing.Size(110, 20);
            this.dtpLocalTimeB.TabIndex = 1;
            this.dtpLocalTimeB.ValueChanged += new System.EventHandler(this.dtpLocalTimeB_ValueChanged);
            this.dtpLocalTimeB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpLocalTimeB_KeyDown);
            // 
            // dtpLocalTimeA
            // 
            this.dtpLocalTimeA.Enabled = false;
            this.dtpLocalTimeA.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpLocalTimeA.Location = new System.Drawing.Point(20, 32);
            this.dtpLocalTimeA.Name = "dtpLocalTimeA";
            this.dtpLocalTimeA.ShowUpDown = true;
            this.dtpLocalTimeA.Size = new System.Drawing.Size(110, 20);
            this.dtpLocalTimeA.TabIndex = 0;
            // 
            // ServerTimeUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbLocalTime);
            this.Controls.Add(this.gbServerTime);
            this.Name = "ServerTimeUc";
            this.Size = new System.Drawing.Size(290, 132);
            this.Load += new System.EventHandler(this.ServerTimeUc_Load);
            this.gbServerTime.ResumeLayout(false);
            this.gbLocalTime.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbServerTime;
        private System.Windows.Forms.DateTimePicker dtpServerTimeA;
        private System.Windows.Forms.DateTimePicker dtpServerTimeB;
        private System.Windows.Forms.GroupBox gbLocalTime;
        private System.Windows.Forms.DateTimePicker dtpLocalTimeB;
        private System.Windows.Forms.DateTimePicker dtpLocalTimeA;
    }
}
