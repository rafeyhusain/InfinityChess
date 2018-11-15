namespace App.Win
{
    partial class BanUserUc
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
            this.components = new System.ComponentModel.Container();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDuration = new System.Windows.Forms.RadioButton();
            this.lblHours = new System.Windows.Forms.Label();
            this.cbHours = new System.Windows.Forms.ComboBox();
            this.cbDays = new System.Windows.Forms.ComboBox();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.rbForever = new System.Windows.Forms.RadioButton();
            this.rbDate = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblServerTime = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBanReason = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(346, 358);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 20;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(438, 358);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDuration);
            this.groupBox1.Controls.Add(this.lblHours);
            this.groupBox1.Controls.Add(this.cbHours);
            this.groupBox1.Controls.Add(this.cbDays);
            this.groupBox1.Controls.Add(this.dtpEndTime);
            this.groupBox1.Controls.Add(this.dtpStartTime);
            this.groupBox1.Controls.Add(this.rbForever);
            this.groupBox1.Controls.Add(this.rbDate);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dtpEndDate);
            this.groupBox1.Controls.Add(this.dtpStartDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(511, 130);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ban Duration";
            // 
            // rbDuration
            // 
            this.rbDuration.AutoSize = true;
            this.rbDuration.Location = new System.Drawing.Point(15, 104);
            this.rbDuration.Name = "rbDuration";
            this.rbDuration.Size = new System.Drawing.Size(49, 17);
            this.rbDuration.TabIndex = 28;
            this.rbDuration.TabStop = true;
            this.rbDuration.Text = "Days";
            this.rbDuration.UseVisualStyleBackColor = true;
            this.rbDuration.CheckedChanged += new System.EventHandler(this.rbDuration_CheckedChanged);
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Location = new System.Drawing.Point(185, 107);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(35, 13);
            this.lblHours.TabIndex = 27;
            this.lblHours.Text = "Hours";
            // 
            // cbHours
            // 
            this.cbHours.FormattingEnabled = true;
            this.cbHours.Location = new System.Drawing.Point(226, 104);
            this.cbHours.Name = "cbHours";
            this.cbHours.Size = new System.Drawing.Size(64, 21);
            this.cbHours.TabIndex = 26;
            // 
            // cbDays
            // 
            this.cbDays.FormattingEnabled = true;
            this.cbDays.Location = new System.Drawing.Point(102, 103);
            this.cbDays.Name = "cbDays";
            this.cbDays.Size = new System.Drawing.Size(64, 21);
            this.cbDays.TabIndex = 25;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndTime.Location = new System.Drawing.Point(371, 75);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(92, 20);
            this.dtpEndTime.TabIndex = 23;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartTime.Location = new System.Drawing.Point(371, 45);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(92, 20);
            this.dtpStartTime.TabIndex = 22;
            // 
            // rbForever
            // 
            this.rbForever.AutoSize = true;
            this.rbForever.Location = new System.Drawing.Point(15, 19);
            this.rbForever.Name = "rbForever";
            this.rbForever.Size = new System.Drawing.Size(64, 17);
            this.rbForever.TabIndex = 21;
            this.rbForever.TabStop = true;
            this.rbForever.Text = " Forever";
            this.rbForever.UseVisualStyleBackColor = true;
            this.rbForever.CheckedChanged += new System.EventHandler(this.rbForever_CheckedChanged);
            // 
            // rbDate
            // 
            this.rbDate.AutoSize = true;
            this.rbDate.Location = new System.Drawing.Point(15, 49);
            this.rbDate.Name = "rbDate";
            this.rbDate.Size = new System.Drawing.Size(76, 17);
            this.rbDate.TabIndex = 20;
            this.rbDate.TabStop = true;
            this.rbDate.Text = " Start Date";
            this.rbDate.UseVisualStyleBackColor = true;
            this.rbDate.CheckedChanged += new System.EventHandler(this.rbDate_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(296, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "End Time";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(102, 75);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(188, 20);
            this.dtpEndDate.TabIndex = 10;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "";
            this.dtpStartDate.Location = new System.Drawing.Point(102, 45);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(188, 20);
            this.dtpStartDate.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(296, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Start Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "End Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Server Time";
            // 
            // lblServerTime
            // 
            this.lblServerTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerTime.Location = new System.Drawing.Point(111, 10);
            this.lblServerTime.Name = "lblServerTime";
            this.lblServerTime.Size = new System.Drawing.Size(412, 20);
            this.lblServerTime.TabIndex = 25;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBanReason);
            this.groupBox2.Location = new System.Drawing.Point(15, 171);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(508, 181);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ban Reason";
            // 
            // txtBanReason
            // 
            this.txtBanReason.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBanReason.Location = new System.Drawing.Point(3, 16);
            this.txtBanReason.Multiline = true;
            this.txtBanReason.Name = "txtBanReason";
            this.txtBanReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBanReason.Size = new System.Drawing.Size(502, 162);
            this.txtBanReason.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // BanUserUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblServerTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Name = "BanUserUc";
            this.Size = new System.Drawing.Size(536, 392);
            this.Load += new System.EventHandler(this.BanUserUc_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rbForever;
        private System.Windows.Forms.RadioButton rbDate;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblServerTime;
        private System.Windows.Forms.ComboBox cbHours;
        private System.Windows.Forms.ComboBox cbDays;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.RadioButton rbDuration;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtBanReason;
        private System.Windows.Forms.ImageList imageList1;
    }
}
