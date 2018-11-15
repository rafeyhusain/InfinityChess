namespace App.Win
{
    partial class TournamentUc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentUc));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInvitation = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtRegEndTime = new System.Windows.Forms.TextBox();
            this.txtRegStartTime = new System.Windows.Forms.TextBox();
            this.cmbSec = new System.Windows.Forms.ComboBox();
            this.cmbMin = new System.Windows.Forms.ComboBox();
            this.chkAllowTieBreak = new System.Windows.Forms.CheckBox();
            this.chkDoubleRound = new System.Windows.Forms.CheckBox();
            this.chkRated = new System.Windows.Forms.CheckBox();
            this.cmbRound = new System.Windows.Forms.ComboBox();
            this.cmbChessType = new System.Windows.Forms.ComboBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.dptRegistrationStartDate = new System.Windows.Forms.DateTimePicker();
            this.dptRegistrationEndDate = new System.Windows.Forms.DateTimePicker();
            this.toolStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(683, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSave
            // 
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(51, 22);
            this.tsbSave.Text = "Save";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.dptRegistrationEndDate);
            this.panel3.Controls.Add(this.dptRegistrationStartDate);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtInvitation);
            this.panel3.Controls.Add(this.txtTitle);
            this.panel3.Controls.Add(this.txtRegEndTime);
            this.panel3.Controls.Add(this.txtRegStartTime);
            this.panel3.Controls.Add(this.cmbSec);
            this.panel3.Controls.Add(this.cmbMin);
            this.panel3.Controls.Add(this.chkAllowTieBreak);
            this.panel3.Controls.Add(this.chkDoubleRound);
            this.panel3.Controls.Add(this.chkRated);
            this.panel3.Controls.Add(this.cmbRound);
            this.panel3.Controls.Add(this.cmbChessType);
            this.panel3.Controls.Add(this.cmbType);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(683, 446);
            this.panel3.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(101, 354);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Invitation";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(124, 330);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Title";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(40, 302);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Registration End Time";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 275);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Registration End Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 246);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Registration Start Time";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Registration Start Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(367, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Sec";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Min";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Time Control";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Round";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Chess Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Type";
            // 
            // txtInvitation
            // 
            this.txtInvitation.Location = new System.Drawing.Point(160, 352);
            this.txtInvitation.Multiline = true;
            this.txtInvitation.Name = "txtInvitation";
            this.txtInvitation.Size = new System.Drawing.Size(262, 80);
            this.txtInvitation.TabIndex = 13;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(160, 323);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(122, 20);
            this.txtTitle.TabIndex = 12;
            // 
            // txtRegEndTime
            // 
            this.txtRegEndTime.Location = new System.Drawing.Point(160, 295);
            this.txtRegEndTime.Name = "txtRegEndTime";
            this.txtRegEndTime.Size = new System.Drawing.Size(122, 20);
            this.txtRegEndTime.TabIndex = 11;
            // 
            // txtRegStartTime
            // 
            this.txtRegStartTime.Location = new System.Drawing.Point(160, 243);
            this.txtRegStartTime.Name = "txtRegStartTime";
            this.txtRegStartTime.Size = new System.Drawing.Size(122, 20);
            this.txtRegStartTime.TabIndex = 9;
            // 
            // cmbSec
            // 
            this.cmbSec.FormattingEnabled = true;
            this.cmbSec.Location = new System.Drawing.Point(277, 184);
            this.cmbSec.Name = "cmbSec";
            this.cmbSec.Size = new System.Drawing.Size(80, 21);
            this.cmbSec.TabIndex = 7;
            // 
            // cmbMin
            // 
            this.cmbMin.FormattingEnabled = true;
            this.cmbMin.Location = new System.Drawing.Point(161, 184);
            this.cmbMin.Name = "cmbMin";
            this.cmbMin.Size = new System.Drawing.Size(80, 21);
            this.cmbMin.TabIndex = 6;
            // 
            // chkAllowTieBreak
            // 
            this.chkAllowTieBreak.AutoSize = true;
            this.chkAllowTieBreak.Location = new System.Drawing.Point(161, 161);
            this.chkAllowTieBreak.Name = "chkAllowTieBreak";
            this.chkAllowTieBreak.Size = new System.Drawing.Size(100, 17);
            this.chkAllowTieBreak.TabIndex = 5;
            this.chkAllowTieBreak.Text = "Allow Tie Break";
            this.chkAllowTieBreak.UseVisualStyleBackColor = true;
            // 
            // chkDoubleRound
            // 
            this.chkDoubleRound.AutoSize = true;
            this.chkDoubleRound.Location = new System.Drawing.Point(161, 138);
            this.chkDoubleRound.Name = "chkDoubleRound";
            this.chkDoubleRound.Size = new System.Drawing.Size(95, 17);
            this.chkDoubleRound.TabIndex = 4;
            this.chkDoubleRound.Text = "Double Round";
            this.chkDoubleRound.UseVisualStyleBackColor = true;
            // 
            // chkRated
            // 
            this.chkRated.AutoSize = true;
            this.chkRated.Location = new System.Drawing.Point(161, 81);
            this.chkRated.Name = "chkRated";
            this.chkRated.Size = new System.Drawing.Size(55, 17);
            this.chkRated.TabIndex = 3;
            this.chkRated.Text = "Rated";
            this.chkRated.UseVisualStyleBackColor = true;
            // 
            // cmbRound
            // 
            this.cmbRound.FormattingEnabled = true;
            this.cmbRound.Location = new System.Drawing.Point(161, 102);
            this.cmbRound.Name = "cmbRound";
            this.cmbRound.Size = new System.Drawing.Size(121, 21);
            this.cmbRound.TabIndex = 2;
            // 
            // cmbChessType
            // 
            this.cmbChessType.FormattingEnabled = true;
            this.cmbChessType.Location = new System.Drawing.Point(161, 49);
            this.cmbChessType.Name = "cmbChessType";
            this.cmbChessType.Size = new System.Drawing.Size(121, 21);
            this.cmbChessType.TabIndex = 1;
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(161, 18);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 21);
            this.cmbType.TabIndex = 0;
            // 
            // dptRegistrationStartDate
            // 
            this.dptRegistrationStartDate.Location = new System.Drawing.Point(161, 216);
            this.dptRegistrationStartDate.Name = "dptRegistrationStartDate";
            this.dptRegistrationStartDate.Size = new System.Drawing.Size(200, 20);
            this.dptRegistrationStartDate.TabIndex = 26;
            // 
            // dptRegistrationEndDate
            // 
            this.dptRegistrationEndDate.Location = new System.Drawing.Point(161, 268);
            this.dptRegistrationEndDate.Name = "dptRegistrationEndDate";
            this.dptRegistrationEndDate.Size = new System.Drawing.Size(200, 20);
            this.dptRegistrationEndDate.TabIndex = 27;
            this.dptRegistrationEndDate.Value = new System.DateTime(2010, 8, 12, 0, 0, 0, 0);
            // 
            // TournamentUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.toolStrip1);
            this.Name = "TournamentUc";
            this.Size = new System.Drawing.Size(683, 471);
            this.Load += new System.EventHandler(this.TournamentUc_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInvitation;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtRegEndTime;
        private System.Windows.Forms.TextBox txtRegStartTime;
        private System.Windows.Forms.ComboBox cmbSec;
        private System.Windows.Forms.ComboBox cmbMin;
        private System.Windows.Forms.CheckBox chkAllowTieBreak;
        private System.Windows.Forms.CheckBox chkDoubleRound;
        private System.Windows.Forms.CheckBox chkRated;
        private System.Windows.Forms.ComboBox cmbRound;
        private System.Windows.Forms.ComboBox cmbChessType;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.DateTimePicker dptRegistrationEndDate;
        private System.Windows.Forms.DateTimePicker dptRegistrationStartDate;

    }
}
