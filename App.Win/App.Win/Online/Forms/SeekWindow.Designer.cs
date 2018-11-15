namespace App.Win
{
    partial class SeekWindow
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
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageChallenge = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkWithClock = new System.Windows.Forms.CheckBox();
            this.chkRated = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSlow = new System.Windows.Forms.Button();
            this.btnRapid = new System.Windows.Forms.Button();
            this.btnBlitz = new System.Windows.Forms.Button();
            this.btnBullet = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownGainMoveSec = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTimeSec = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownGainMove = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTimeMin = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbAutometic = new System.Windows.Forms.RadioButton();
            this.rbWhite = new System.Windows.Forms.RadioButton();
            this.rbBlack = new System.Windows.Forms.RadioButton();
            this.tabFini = new System.Windows.Forms.TabPage();
            this.userFiniUc1 = new App.Win.UserFiniUc();
            this.tabControl1.SuspendLayout();
            this.tabPageChallenge.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGainMoveSec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeSec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGainMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeMin)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tabFini.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(291, 278);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(210, 278);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(129, 278);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageChallenge);
            this.tabControl1.Controls.Add(this.tabFini);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(370, 272);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageChallenge
            // 
            this.tabPageChallenge.Controls.Add(this.groupBox4);
            this.tabPageChallenge.Controls.Add(this.groupBox2);
            this.tabPageChallenge.Controls.Add(this.groupBox3);
            this.tabPageChallenge.Location = new System.Drawing.Point(4, 22);
            this.tabPageChallenge.Name = "tabPageChallenge";
            this.tabPageChallenge.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChallenge.Size = new System.Drawing.Size(362, 246);
            this.tabPageChallenge.TabIndex = 0;
            this.tabPageChallenge.Text = "Seek";
            this.tabPageChallenge.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkWithClock);
            this.groupBox4.Controls.Add(this.chkRated);
            this.groupBox4.Location = new System.Drawing.Point(11, 125);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(167, 91);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Condition";
            // 
            // chkWithClock
            // 
            this.chkWithClock.AutoSize = true;
            this.chkWithClock.Checked = true;
            this.chkWithClock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWithClock.Location = new System.Drawing.Point(31, 51);
            this.chkWithClock.Name = "chkWithClock";
            this.chkWithClock.Size = new System.Drawing.Size(78, 17);
            this.chkWithClock.TabIndex = 1;
            this.chkWithClock.Text = "With Clock";
            this.chkWithClock.UseVisualStyleBackColor = true;
            // 
            // chkRated
            // 
            this.chkRated.AutoSize = true;
            this.chkRated.Location = new System.Drawing.Point(31, 28);
            this.chkRated.Name = "chkRated";
            this.chkRated.Size = new System.Drawing.Size(55, 17);
            this.chkRated.TabIndex = 0;
            this.chkRated.Text = "Rated";
            this.chkRated.UseVisualStyleBackColor = true;
            this.chkRated.CheckedChanged += new System.EventHandler(this.chkRated_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSlow);
            this.groupBox2.Controls.Add(this.btnRapid);
            this.groupBox2.Controls.Add(this.btnBlitz);
            this.groupBox2.Controls.Add(this.btnBullet);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.numericUpDownGainMoveSec);
            this.groupBox2.Controls.Add(this.numericUpDownTimeSec);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.numericUpDownGainMove);
            this.groupBox2.Controls.Add(this.numericUpDownTimeMin);
            this.groupBox2.Location = new System.Drawing.Point(12, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(339, 109);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Clock";
            // 
            // btnSlow
            // 
            this.btnSlow.Location = new System.Drawing.Point(253, 71);
            this.btnSlow.Name = "btnSlow";
            this.btnSlow.Size = new System.Drawing.Size(75, 23);
            this.btnSlow.TabIndex = 7;
            this.btnSlow.Text = "Long";
            this.btnSlow.UseVisualStyleBackColor = true;
            this.btnSlow.Click += new System.EventHandler(this.btnSlow_Click);
            // 
            // btnRapid
            // 
            this.btnRapid.Location = new System.Drawing.Point(172, 71);
            this.btnRapid.Name = "btnRapid";
            this.btnRapid.Size = new System.Drawing.Size(75, 23);
            this.btnRapid.TabIndex = 6;
            this.btnRapid.Text = "Rapid";
            this.btnRapid.UseVisualStyleBackColor = true;
            this.btnRapid.Click += new System.EventHandler(this.btnRapid_Click);
            // 
            // btnBlitz
            // 
            this.btnBlitz.Location = new System.Drawing.Point(91, 71);
            this.btnBlitz.Name = "btnBlitz";
            this.btnBlitz.Size = new System.Drawing.Size(75, 23);
            this.btnBlitz.TabIndex = 5;
            this.btnBlitz.Text = "Blitz";
            this.btnBlitz.UseVisualStyleBackColor = true;
            this.btnBlitz.Click += new System.EventHandler(this.btnBlitz_Click);
            // 
            // btnBullet
            // 
            this.btnBullet.Location = new System.Drawing.Point(10, 71);
            this.btnBullet.Name = "btnBullet";
            this.btnBullet.Size = new System.Drawing.Size(75, 23);
            this.btnBullet.TabIndex = 4;
            this.btnBullet.Text = "Bullet";
            this.btnBullet.UseVisualStyleBackColor = true;
            this.btnBullet.Click += new System.EventHandler(this.btnBullet_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(256, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "---";
            this.label4.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "---";
            this.label1.Visible = false;
            // 
            // numericUpDownGainMoveSec
            // 
            this.numericUpDownGainMoveSec.Enabled = false;
            this.numericUpDownGainMoveSec.Location = new System.Drawing.Point(278, 45);
            this.numericUpDownGainMoveSec.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownGainMoveSec.Name = "numericUpDownGainMoveSec";
            this.numericUpDownGainMoveSec.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownGainMoveSec.TabIndex = 3;
            this.numericUpDownGainMoveSec.Visible = false;
            // 
            // numericUpDownTimeSec
            // 
            this.numericUpDownTimeSec.Location = new System.Drawing.Point(278, 19);
            this.numericUpDownTimeSec.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDownTimeSec.Name = "numericUpDownTimeSec";
            this.numericUpDownTimeSec.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownTimeSec.TabIndex = 1;
            this.numericUpDownTimeSec.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Gain per move";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Time";
            // 
            // numericUpDownGainMove
            // 
            this.numericUpDownGainMove.Location = new System.Drawing.Point(197, 45);
            this.numericUpDownGainMove.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownGainMove.Name = "numericUpDownGainMove";
            this.numericUpDownGainMove.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownGainMove.TabIndex = 2;
            // 
            // numericUpDownTimeMin
            // 
            this.numericUpDownTimeMin.Location = new System.Drawing.Point(197, 19);
            this.numericUpDownTimeMin.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownTimeMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTimeMin.Name = "numericUpDownTimeMin";
            this.numericUpDownTimeMin.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownTimeMin.TabIndex = 0;
            this.numericUpDownTimeMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbAutometic);
            this.groupBox3.Controls.Add(this.rbWhite);
            this.groupBox3.Controls.Add(this.rbBlack);
            this.groupBox3.Location = new System.Drawing.Point(184, 125);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(167, 91);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Color";
            // 
            // rbAutometic
            // 
            this.rbAutometic.AutoSize = true;
            this.rbAutometic.Checked = true;
            this.rbAutometic.Location = new System.Drawing.Point(27, 19);
            this.rbAutometic.Name = "rbAutometic";
            this.rbAutometic.Size = new System.Drawing.Size(72, 17);
            this.rbAutometic.TabIndex = 0;
            this.rbAutometic.TabStop = true;
            this.rbAutometic.Text = "Autometic";
            this.rbAutometic.UseVisualStyleBackColor = true;
            // 
            // rbWhite
            // 
            this.rbWhite.AutoSize = true;
            this.rbWhite.Location = new System.Drawing.Point(27, 42);
            this.rbWhite.Name = "rbWhite";
            this.rbWhite.Size = new System.Drawing.Size(53, 17);
            this.rbWhite.TabIndex = 1;
            this.rbWhite.TabStop = true;
            this.rbWhite.Text = "White";
            this.rbWhite.UseVisualStyleBackColor = true;
            // 
            // rbBlack
            // 
            this.rbBlack.AutoSize = true;
            this.rbBlack.Location = new System.Drawing.Point(27, 65);
            this.rbBlack.Name = "rbBlack";
            this.rbBlack.Size = new System.Drawing.Size(52, 17);
            this.rbBlack.TabIndex = 2;
            this.rbBlack.TabStop = true;
            this.rbBlack.Text = "Black";
            this.rbBlack.UseVisualStyleBackColor = true;
            // 
            // tabFini
            // 
            this.tabFini.Controls.Add(this.userFiniUc1);
            this.tabFini.Location = new System.Drawing.Point(4, 22);
            this.tabFini.Name = "tabFini";
            this.tabFini.Size = new System.Drawing.Size(362, 246);
            this.tabFini.TabIndex = 1;
            this.tabFini.Text = "Fini";
            this.tabFini.UseVisualStyleBackColor = true;
            // 
            // userFiniUc1
            // 
            this.userFiniUc1.Location = new System.Drawing.Point(0, 1);
            this.userFiniUc1.Name = "userFiniUc1";
            this.userFiniUc1.Size = new System.Drawing.Size(338, 245);
            this.userFiniUc1.TabIndex = 0;
            // 
            // SeekWindow
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(370, 304);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeekWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seek";
            this.Load += new System.EventHandler(this.ChallengeWindow_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageChallenge.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGainMoveSec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeSec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGainMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeMin)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabFini.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageChallenge;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkWithClock;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownGainMove;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkRated;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeMin;
        private System.Windows.Forms.RadioButton rbAutometic;
        private System.Windows.Forms.RadioButton rbWhite;
        private System.Windows.Forms.RadioButton rbBlack;
        private System.Windows.Forms.Button btnSlow;
        private System.Windows.Forms.Button btnRapid;
        private System.Windows.Forms.Button btnBlitz;
        private System.Windows.Forms.Button btnBullet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownGainMoveSec;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeSec;
        private System.Windows.Forms.TabPage tabFini;
        private UserFiniUc userFiniUc1;

    }
}