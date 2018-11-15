namespace App.Win
{
    partial class ChallengeWindow
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
            this.chkChallengesSendsGame = new System.Windows.Forms.CheckBox();
            this.chkWithClock = new System.Windows.Forms.CheckBox();
            this.chkRated = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblOpponentName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownGainMove = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTime = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbAutometic = new System.Windows.Forms.RadioButton();
            this.rbWhite = new System.Windows.Forms.RadioButton();
            this.rbBlack = new System.Windows.Forms.RadioButton();
            this.tabPageFini = new System.Windows.Forms.TabPage();
            this.userFiniUc1 = new App.Win.UserFiniUc();
            this.tabControl1.SuspendLayout();
            this.tabPageChallenge.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGainMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTime)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tabPageFini.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(267, 288);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 22);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(186, 288);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(105, 287);
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
            this.tabControl1.Controls.Add(this.tabPageFini);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(346, 282);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageChallenge
            // 
            this.tabPageChallenge.Controls.Add(this.groupBox4);
            this.tabPageChallenge.Controls.Add(this.groupBox1);
            this.tabPageChallenge.Controls.Add(this.groupBox2);
            this.tabPageChallenge.Controls.Add(this.groupBox3);
            this.tabPageChallenge.Location = new System.Drawing.Point(4, 22);
            this.tabPageChallenge.Name = "tabPageChallenge";
            this.tabPageChallenge.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChallenge.Size = new System.Drawing.Size(338, 256);
            this.tabPageChallenge.TabIndex = 0;
            this.tabPageChallenge.Text = "Challenge";
            this.tabPageChallenge.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkChallengesSendsGame);
            this.groupBox4.Controls.Add(this.chkWithClock);
            this.groupBox4.Controls.Add(this.chkRated);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox4.Location = new System.Drawing.Point(11, 172);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(321, 60);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Condition";
            // 
            // chkChallengesSendsGame
            // 
            this.chkChallengesSendsGame.AutoSize = true;
            this.chkChallengesSendsGame.Location = new System.Drawing.Point(163, 37);
            this.chkChallengesSendsGame.Name = "chkChallengesSendsGame";
            this.chkChallengesSendsGame.Size = new System.Drawing.Size(140, 17);
            this.chkChallengesSendsGame.TabIndex = 2;
            this.chkChallengesSendsGame.Text = "Challenger Sends Game";
            this.chkChallengesSendsGame.UseVisualStyleBackColor = true;
            // 
            // chkWithClock
            // 
            this.chkWithClock.AutoSize = true;
            this.chkWithClock.Checked = true;
            this.chkWithClock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWithClock.Location = new System.Drawing.Point(163, 14);
            this.chkWithClock.Name = "chkWithClock";
            this.chkWithClock.Size = new System.Drawing.Size(78, 17);
            this.chkWithClock.TabIndex = 1;
            this.chkWithClock.Text = "With Clock";
            this.chkWithClock.UseVisualStyleBackColor = true;
            // 
            // chkRated
            // 
            this.chkRated.AutoSize = true;
            this.chkRated.Location = new System.Drawing.Point(17, 24);
            this.chkRated.Name = "chkRated";
            this.chkRated.Size = new System.Drawing.Size(55, 17);
            this.chkRated.TabIndex = 0;
            this.chkRated.Text = "Rated";
            this.chkRated.UseVisualStyleBackColor = true;
            this.chkRated.CheckedChanged += new System.EventHandler(this.chkRated_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblOpponentName);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(11, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opponent";
            // 
            // lblOpponentName
            // 
            this.lblOpponentName.AutoSize = true;
            this.lblOpponentName.Location = new System.Drawing.Point(14, 21);
            this.lblOpponentName.Name = "lblOpponentName";
            this.lblOpponentName.Size = new System.Drawing.Size(85, 13);
            this.lblOpponentName.TabIndex = 0;
            this.lblOpponentName.Text = "Opponent Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.numericUpDownGainMove);
            this.groupBox2.Controls.Add(this.numericUpDownTime);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(11, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(158, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Clock";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Gain per move";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Time";
            // 
            // numericUpDownGainMove
            // 
            this.numericUpDownGainMove.Location = new System.Drawing.Point(96, 53);
            this.numericUpDownGainMove.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownGainMove.Name = "numericUpDownGainMove";
            this.numericUpDownGainMove.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownGainMove.TabIndex = 1;
            // 
            // numericUpDownTime
            // 
            this.numericUpDownTime.Location = new System.Drawing.Point(96, 27);
            this.numericUpDownTime.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTime.Name = "numericUpDownTime";
            this.numericUpDownTime.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownTime.TabIndex = 0;
            this.numericUpDownTime.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbAutometic);
            this.groupBox3.Controls.Add(this.rbWhite);
            this.groupBox3.Controls.Add(this.rbBlack);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox3.Location = new System.Drawing.Point(174, 66);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(158, 100);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Color";
            // 
            // rbAutometic
            // 
            this.rbAutometic.AutoSize = true;
            this.rbAutometic.Checked = true;
            this.rbAutometic.Location = new System.Drawing.Point(21, 19);
            this.rbAutometic.Name = "rbAutometic";
            this.rbAutometic.Size = new System.Drawing.Size(72, 17);
            this.rbAutometic.TabIndex = 0;
            this.rbAutometic.TabStop = true;
            this.rbAutometic.Text = "Automatic";
            this.rbAutometic.UseVisualStyleBackColor = true;
            // 
            // rbWhite
            // 
            this.rbWhite.AutoSize = true;
            this.rbWhite.Location = new System.Drawing.Point(21, 42);
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
            this.rbBlack.Location = new System.Drawing.Point(21, 65);
            this.rbBlack.Name = "rbBlack";
            this.rbBlack.Size = new System.Drawing.Size(52, 17);
            this.rbBlack.TabIndex = 2;
            this.rbBlack.TabStop = true;
            this.rbBlack.Text = "Black";
            this.rbBlack.UseVisualStyleBackColor = true;
            // 
            // tabPageFini
            // 
            this.tabPageFini.Controls.Add(this.userFiniUc1);
            this.tabPageFini.Location = new System.Drawing.Point(4, 22);
            this.tabPageFini.Name = "tabPageFini";
            this.tabPageFini.Size = new System.Drawing.Size(338, 256);
            this.tabPageFini.TabIndex = 1;
            this.tabPageFini.Text = "Fini";
            this.tabPageFini.UseVisualStyleBackColor = true;
            // 
            // userFiniUc1
            // 
            this.userFiniUc1.Location = new System.Drawing.Point(0, 0);
            this.userFiniUc1.Name = "userFiniUc1";
            this.userFiniUc1.Size = new System.Drawing.Size(338, 245);
            this.userFiniUc1.TabIndex = 0;
            // 
            // ChallengeWindow
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(346, 314);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChallengeWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Challenge";
            this.Load += new System.EventHandler(this.ChallengeWindow_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageChallenge.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGainMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTime)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPageFini.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageChallenge;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkChallengesSendsGame;
        private System.Windows.Forms.CheckBox chkWithClock;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblOpponentName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownGainMove;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkRated;
        private System.Windows.Forms.NumericUpDown numericUpDownTime;
        private System.Windows.Forms.RadioButton rbAutometic;
        private System.Windows.Forms.RadioButton rbWhite;
        private System.Windows.Forms.RadioButton rbBlack;
        private System.Windows.Forms.TabPage tabPageFini;
        private UserFiniUc userFiniUc1;

    }
}