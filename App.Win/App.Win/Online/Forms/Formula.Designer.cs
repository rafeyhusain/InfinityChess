namespace App.Win
{
    partial class Formula
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkUnrated = new System.Windows.Forms.CheckBox();
            this.chkRated = new System.Windows.Forms.CheckBox();
            this.chkDucats = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkFastInternet = new System.Windows.Forms.CheckBox();
            this.chkNoComputer = new System.Windows.Forms.CheckBox();
            this.chkNoCentaur = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericMinElo = new System.Windows.Forms.NumericUpDown();
            this.numericMaxElo = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericMaxTime = new System.Windows.Forms.NumericUpDown();
            this.numericMinTime = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericMaxGain = new System.Windows.Forms.NumericUpDown();
            this.numericMinGain = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxMinRank = new System.Windows.Forms.ComboBox();
            this.numericMinDucats = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.chkActivate = new System.Windows.Forms.CheckBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinElo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxElo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinDucats)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(18, 269);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(99, 269);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // chkUnrated
            // 
            this.chkUnrated.AutoSize = true;
            this.chkUnrated.Checked = true;
            this.chkUnrated.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUnrated.Location = new System.Drawing.Point(6, 14);
            this.chkUnrated.Name = "chkUnrated";
            this.chkUnrated.Size = new System.Drawing.Size(64, 17);
            this.chkUnrated.TabIndex = 0;
            this.chkUnrated.Text = "Unrated";
            this.chkUnrated.UseVisualStyleBackColor = true;
            // 
            // chkRated
            // 
            this.chkRated.AutoSize = true;
            this.chkRated.Checked = true;
            this.chkRated.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRated.Location = new System.Drawing.Point(6, 37);
            this.chkRated.Name = "chkRated";
            this.chkRated.Size = new System.Drawing.Size(55, 17);
            this.chkRated.TabIndex = 1;
            this.chkRated.Text = "Rated";
            this.chkRated.UseVisualStyleBackColor = true;
            // 
            // chkDucats
            // 
            this.chkDucats.AutoSize = true;
            this.chkDucats.Enabled = false;
            this.chkDucats.Location = new System.Drawing.Point(6, 60);
            this.chkDucats.Name = "chkDucats";
            this.chkDucats.Size = new System.Drawing.Size(42, 17);
            this.chkDucats.TabIndex = 2;
            this.chkDucats.Text = "Fini";
            this.chkDucats.UseVisualStyleBackColor = true;
            this.chkDucats.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkDucats);
            this.groupBox1.Controls.Add(this.chkUnrated);
            this.groupBox1.Controls.Add(this.chkRated);
            this.groupBox1.Location = new System.Drawing.Point(12, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(89, 83);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // chkFastInternet
            // 
            this.chkFastInternet.AutoSize = true;
            this.chkFastInternet.Location = new System.Drawing.Point(6, 60);
            this.chkFastInternet.Name = "chkFastInternet";
            this.chkFastInternet.Size = new System.Drawing.Size(109, 17);
            this.chkFastInternet.TabIndex = 5;
            this.chkFastInternet.Text = "Fast Internet Only";
            this.chkFastInternet.UseVisualStyleBackColor = true;
            // 
            // chkNoComputer
            // 
            this.chkNoComputer.AutoSize = true;
            this.chkNoComputer.Location = new System.Drawing.Point(6, 14);
            this.chkNoComputer.Name = "chkNoComputer";
            this.chkNoComputer.Size = new System.Drawing.Size(88, 17);
            this.chkNoComputer.TabIndex = 3;
            this.chkNoComputer.Text = "No Computer";
            this.chkNoComputer.UseVisualStyleBackColor = true;
            // 
            // chkNoCentaur
            // 
            this.chkNoCentaur.AutoSize = true;
            this.chkNoCentaur.Enabled = false;
            this.chkNoCentaur.Location = new System.Drawing.Point(6, 37);
            this.chkNoCentaur.Name = "chkNoCentaur";
            this.chkNoCentaur.Size = new System.Drawing.Size(85, 17);
            this.chkNoCentaur.TabIndex = 4;
            this.chkNoCentaur.Text = "No Centaurs";
            this.chkNoCentaur.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkNoComputer);
            this.groupBox2.Controls.Add(this.chkFastInternet);
            this.groupBox2.Controls.Add(this.chkNoCentaur);
            this.groupBox2.Location = new System.Drawing.Point(112, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(150, 83);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Elo";
            // 
            // numericMinElo
            // 
            this.numericMinElo.Location = new System.Drawing.Point(99, 91);
            this.numericMinElo.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericMinElo.Name = "numericMinElo";
            this.numericMinElo.Size = new System.Drawing.Size(70, 20);
            this.numericMinElo.TabIndex = 6;
            // 
            // numericMaxElo
            // 
            this.numericMaxElo.Location = new System.Drawing.Point(192, 91);
            this.numericMaxElo.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numericMaxElo.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericMaxElo.Name = "numericMaxElo";
            this.numericMaxElo.Size = new System.Drawing.Size(70, 20);
            this.numericMaxElo.TabIndex = 7;
            this.numericMaxElo.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "-";
            // 
            // numericMaxTime
            // 
            this.numericMaxTime.Location = new System.Drawing.Point(192, 117);
            this.numericMaxTime.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericMaxTime.Name = "numericMaxTime";
            this.numericMaxTime.Size = new System.Drawing.Size(70, 20);
            this.numericMaxTime.TabIndex = 9;
            this.numericMaxTime.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // numericMinTime
            // 
            this.numericMinTime.Location = new System.Drawing.Point(99, 117);
            this.numericMinTime.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericMinTime.Name = "numericMinTime";
            this.numericMinTime.Size = new System.Drawing.Size(70, 20);
            this.numericMinTime.TabIndex = 8;
            this.numericMinTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Time";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "-";
            // 
            // numericMaxGain
            // 
            this.numericMaxGain.Location = new System.Drawing.Point(192, 143);
            this.numericMaxGain.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericMaxGain.Name = "numericMaxGain";
            this.numericMaxGain.Size = new System.Drawing.Size(70, 20);
            this.numericMaxGain.TabIndex = 11;
            this.numericMaxGain.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericMinGain
            // 
            this.numericMinGain.Location = new System.Drawing.Point(99, 143);
            this.numericMinGain.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericMinGain.Name = "numericMinGain";
            this.numericMinGain.Size = new System.Drawing.Size(70, 20);
            this.numericMinGain.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Gain per move";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Minimum Rank";
            // 
            // comboBoxMinRank
            // 
            this.comboBoxMinRank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMinRank.FormattingEnabled = true;
            this.comboBoxMinRank.Items.AddRange(new object[] {
            "Guest",
            "Pawn",
            "Knight",
            "Bishop",
            "Rook",
            "Queen",
            "King"});
            this.comboBoxMinRank.Location = new System.Drawing.Point(99, 169);
            this.comboBoxMinRank.Name = "comboBoxMinRank";
            this.comboBoxMinRank.Size = new System.Drawing.Size(163, 21);
            this.comboBoxMinRank.TabIndex = 12;
            // 
            // numericMinDucats
            // 
            this.numericMinDucats.Enabled = false;
            this.numericMinDucats.Location = new System.Drawing.Point(99, 196);
            this.numericMinDucats.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericMinDucats.Name = "numericMinDucats";
            this.numericMinDucats.Size = new System.Drawing.Size(25, 20);
            this.numericMinDucats.TabIndex = 13;
            this.numericMinDucats.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericMinDucats.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Minimum Fini";
            this.label8.Visible = false;
            // 
            // chkActivate
            // 
            this.chkActivate.AutoSize = true;
            this.chkActivate.Location = new System.Drawing.Point(6, 17);
            this.chkActivate.Name = "chkActivate";
            this.chkActivate.Size = new System.Drawing.Size(65, 17);
            this.chkActivate.TabIndex = 14;
            this.chkActivate.Text = "Activate";
            this.chkActivate.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(165, 15);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 15;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(180, 269);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 18;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkActivate);
            this.groupBox3.Controls.Add(this.btnReset);
            this.groupBox3.Location = new System.Drawing.Point(12, 216);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(250, 46);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            // 
            // Formula
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(273, 299);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.numericMinDucats);
            this.Controls.Add(this.comboBoxMinRank);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericMaxGain);
            this.Controls.Add(this.numericMinGain);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericMaxTime);
            this.Controls.Add(this.numericMinTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericMaxElo);
            this.Controls.Add(this.numericMinElo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Formula";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formula";
            this.Load += new System.EventHandler(this.Formula_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinElo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxElo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinDucats)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkUnrated;
        private System.Windows.Forms.CheckBox chkRated;
        private System.Windows.Forms.CheckBox chkDucats;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkFastInternet;
        private System.Windows.Forms.CheckBox chkNoComputer;
        private System.Windows.Forms.CheckBox chkNoCentaur;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericMinElo;
        private System.Windows.Forms.NumericUpDown numericMaxElo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericMaxTime;
        private System.Windows.Forms.NumericUpDown numericMinTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericMaxGain;
        private System.Windows.Forms.NumericUpDown numericMinGain;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxMinRank;
        private System.Windows.Forms.NumericUpDown numericMinDucats;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkActivate;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}