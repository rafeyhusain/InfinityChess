namespace App.Win
{
    partial class PlayingMode
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
            this.rbHuman = new System.Windows.Forms.RadioButton();
            this.rbComputer = new System.Windows.Forms.RadioButton();
            this.rbCentaur = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkSendExpectedMove = new System.Windows.Forms.CheckBox();
            this.chkSendEvaluations = new System.Windows.Forms.CheckBox();
            this.chkAutometicAccepts = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDefineEngine = new System.Windows.Forms.Button();
            this.chkAutomaticChallenges = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbHuman
            // 
            this.rbHuman.AutoSize = true;
            this.rbHuman.Location = new System.Drawing.Point(12, 11);
            this.rbHuman.Name = "rbHuman";
            this.rbHuman.Size = new System.Drawing.Size(59, 17);
            this.rbHuman.TabIndex = 1;
            this.rbHuman.TabStop = true;
            this.rbHuman.Text = "Human";
            this.rbHuman.UseVisualStyleBackColor = true;
            this.rbHuman.CheckedChanged += new System.EventHandler(this.rbHuman_CheckedChanged);
            // 
            // rbComputer
            // 
            this.rbComputer.AutoSize = true;
            this.rbComputer.Enabled = false;
            this.rbComputer.Location = new System.Drawing.Point(111, 11);
            this.rbComputer.Name = "rbComputer";
            this.rbComputer.Size = new System.Drawing.Size(70, 17);
            this.rbComputer.TabIndex = 2;
            this.rbComputer.TabStop = true;
            this.rbComputer.Text = "Computer";
            this.rbComputer.UseVisualStyleBackColor = true;
            this.rbComputer.CheckedChanged += new System.EventHandler(this.rbComputer_CheckedChanged);
            // 
            // rbCentaur
            // 
            this.rbCentaur.AutoSize = true;
            this.rbCentaur.Enabled = false;
            this.rbCentaur.Location = new System.Drawing.Point(218, 11);
            this.rbCentaur.Name = "rbCentaur";
            this.rbCentaur.Size = new System.Drawing.Size(62, 17);
            this.rbCentaur.TabIndex = 3;
            this.rbCentaur.TabStop = true;
            this.rbCentaur.Text = "Centaur";
            this.rbCentaur.UseVisualStyleBackColor = true;
            this.rbCentaur.CheckedChanged += new System.EventHandler(this.rbCentaur_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkSendExpectedMove);
            this.groupBox2.Controls.Add(this.chkSendEvaluations);
            this.groupBox2.Controls.Add(this.chkAutometicAccepts);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.btnDefineEngine);
            this.groupBox2.Controls.Add(this.chkAutomaticChallenges);
            this.groupBox2.Location = new System.Drawing.Point(12, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 215);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Computer";
            // 
            // chkSendExpectedMove
            // 
            this.chkSendExpectedMove.AutoSize = true;
            this.chkSendExpectedMove.Enabled = false;
            this.chkSendExpectedMove.Location = new System.Drawing.Point(31, 187);
            this.chkSendExpectedMove.Name = "chkSendExpectedMove";
            this.chkSendExpectedMove.Size = new System.Drawing.Size(132, 17);
            this.chkSendExpectedMove.TabIndex = 5;
            this.chkSendExpectedMove.Text = "Send expected moves";
            this.chkSendExpectedMove.UseVisualStyleBackColor = true;
            // 
            // chkSendEvaluations
            // 
            this.chkSendEvaluations.AutoSize = true;
            this.chkSendEvaluations.Enabled = false;
            this.chkSendEvaluations.Location = new System.Drawing.Point(31, 164);
            this.chkSendEvaluations.Name = "chkSendEvaluations";
            this.chkSendEvaluations.Size = new System.Drawing.Size(109, 17);
            this.chkSendEvaluations.TabIndex = 4;
            this.chkSendEvaluations.Text = "Send Evaluations";
            this.chkSendEvaluations.UseVisualStyleBackColor = true;
            // 
            // chkAutometicAccepts
            // 
            this.chkAutometicAccepts.AutoSize = true;
            this.chkAutometicAccepts.Enabled = false;
            this.chkAutometicAccepts.Location = new System.Drawing.Point(31, 141);
            this.chkAutometicAccepts.Name = "chkAutometicAccepts";
            this.chkAutometicAccepts.Size = new System.Drawing.Size(115, 17);
            this.chkAutometicAccepts.TabIndex = 3;
            this.chkAutometicAccepts.Text = "Autometic Accepts";
            this.chkAutometicAccepts.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDown2);
            this.groupBox3.Controls.Add(this.numericUpDown1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(31, 47);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(206, 65);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Clock";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(155, 35);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(45, 20);
            this.numericUpDown2.TabIndex = 1;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Location = new System.Drawing.Point(155, 13);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(45, 20);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Gain per move";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Time";
            // 
            // btnDefineEngine
            // 
            this.btnDefineEngine.Enabled = false;
            this.btnDefineEngine.Location = new System.Drawing.Point(84, 18);
            this.btnDefineEngine.Name = "btnDefineEngine";
            this.btnDefineEngine.Size = new System.Drawing.Size(100, 23);
            this.btnDefineEngine.TabIndex = 0;
            this.btnDefineEngine.Text = "Define Engine";
            this.btnDefineEngine.UseVisualStyleBackColor = true;
            this.btnDefineEngine.Click += new System.EventHandler(this.btnDefineEngine_Click);
            // 
            // chkAutomaticChallenges
            // 
            this.chkAutomaticChallenges.AutoSize = true;
            this.chkAutomaticChallenges.Enabled = false;
            this.chkAutomaticChallenges.Location = new System.Drawing.Point(31, 118);
            this.chkAutomaticChallenges.Name = "chkAutomaticChallenges";
            this.chkAutomaticChallenges.Size = new System.Drawing.Size(128, 17);
            this.chkAutomaticChallenges.TabIndex = 2;
            this.chkAutomaticChallenges.Text = "Automatic Challenges";
            this.chkAutomaticChallenges.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(46, 254);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 22);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(208, 254);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 22);
            this.btnHelp.TabIndex = 7;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(127, 254);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PlayingMode
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(292, 288);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.rbCentaur);
            this.Controls.Add(this.rbComputer);
            this.Controls.Add(this.rbHuman);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlayingMode";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Playing Mode";
            this.Load += new System.EventHandler(this.PlayingMode_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbHuman;
        private System.Windows.Forms.RadioButton rbComputer;
        private System.Windows.Forms.RadioButton rbCentaur;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDefineEngine;
        private System.Windows.Forms.CheckBox chkAutomaticChallenges;
        private System.Windows.Forms.CheckBox chkSendExpectedMove;
        private System.Windows.Forms.CheckBox chkSendEvaluations;
        private System.Windows.Forms.CheckBox chkAutometicAccepts;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnCancel;
    }
}