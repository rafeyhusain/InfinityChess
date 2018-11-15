namespace App.Win
{
    partial class BlitzClockForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlitzClockForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericTime = new System.Windows.Forms.NumericUpDown();
            this.numericGainPerMove = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rb10min1sec = new System.Windows.Forms.RadioButton();
            this.rb3min1sec = new System.Windows.Forms.RadioButton();
            this.rb10min2 = new System.Windows.Forms.RadioButton();
            this.rb3min = new System.Windows.Forms.RadioButton();
            this.rb5min = new System.Windows.Forms.RadioButton();
            this.rb90min = new System.Windows.Forms.RadioButton();
            this.rb15min = new System.Windows.Forms.RadioButton();
            this.rb2min = new System.Windows.Forms.RadioButton();
            this.rb4min = new System.Windows.Forms.RadioButton();
            this.rb60min = new System.Windows.Forms.RadioButton();
            this.rb25min = new System.Windows.Forms.RadioButton();
            this.rb10min = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGainPerMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericTime);
            this.groupBox1.Controls.Add(this.numericGainPerMove);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox1.Location = new System.Drawing.Point(117, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(314, 68);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // numericTime
            // 
            this.numericTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericTime.Location = new System.Drawing.Point(183, 13);
            this.numericTime.Margin = new System.Windows.Forms.Padding(2);
            this.numericTime.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericTime.Name = "numericTime";
            this.numericTime.Size = new System.Drawing.Size(38, 20);
            this.numericTime.TabIndex = 0;
            this.numericTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericGainPerMove
            // 
            this.numericGainPerMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericGainPerMove.Location = new System.Drawing.Point(182, 39);
            this.numericGainPerMove.Margin = new System.Windows.Forms.Padding(2);
            this.numericGainPerMove.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericGainPerMove.Name = "numericGainPerMove";
            this.numericGainPerMove.Size = new System.Drawing.Size(38, 20);
            this.numericGainPerMove.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Gain per move (sec):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Time (min):";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rb10min1sec);
            this.groupBox4.Controls.Add(this.rb3min1sec);
            this.groupBox4.Controls.Add(this.rb10min2);
            this.groupBox4.Controls.Add(this.rb3min);
            this.groupBox4.Controls.Add(this.rb5min);
            this.groupBox4.Controls.Add(this.rb90min);
            this.groupBox4.Controls.Add(this.rb15min);
            this.groupBox4.Controls.Add(this.rb2min);
            this.groupBox4.Controls.Add(this.rb4min);
            this.groupBox4.Controls.Add(this.rb60min);
            this.groupBox4.Controls.Add(this.rb25min);
            this.groupBox4.Controls.Add(this.rb10min);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox4.Location = new System.Drawing.Point(17, 95);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(414, 86);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Defaults";
            // 
            // rb10min1sec
            // 
            this.rb10min1sec.AutoSize = true;
            this.rb10min1sec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb10min1sec.Location = new System.Drawing.Point(302, 63);
            this.rb10min1sec.Margin = new System.Windows.Forms.Padding(2);
            this.rb10min1sec.Name = "rb10min1sec";
            this.rb10min1sec.Size = new System.Drawing.Size(94, 17);
            this.rb10min1sec.TabIndex = 11;
            this.rb10min1sec.TabStop = true;
            this.rb10min1sec.Text = "10 min + 1 sec";
            this.rb10min1sec.UseVisualStyleBackColor = true;
            this.rb10min1sec.CheckedChanged += new System.EventHandler(this.rb10min1sec_Click);
            // 
            // rb3min1sec
            // 
            this.rb3min1sec.AutoSize = true;
            this.rb3min1sec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb3min1sec.Location = new System.Drawing.Point(87, 63);
            this.rb3min1sec.Margin = new System.Windows.Forms.Padding(2);
            this.rb3min1sec.Name = "rb3min1sec";
            this.rb3min1sec.Size = new System.Drawing.Size(88, 17);
            this.rb3min1sec.TabIndex = 9;
            this.rb3min1sec.TabStop = true;
            this.rb3min1sec.Text = "3 min + 1 sec";
            this.rb3min1sec.UseVisualStyleBackColor = true;
            this.rb3min1sec.CheckedChanged += new System.EventHandler(this.rb3min1sec_Click);
            // 
            // rb10min2
            // 
            this.rb10min2.AutoSize = true;
            this.rb10min2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb10min2.Location = new System.Drawing.Point(192, 63);
            this.rb10min2.Margin = new System.Windows.Forms.Padding(2);
            this.rb10min2.Name = "rb10min2";
            this.rb10min2.Size = new System.Drawing.Size(56, 17);
            this.rb10min2.TabIndex = 10;
            this.rb10min2.TabStop = true;
            this.rb10min2.Text = "10 min";
            this.rb10min2.UseVisualStyleBackColor = true;
            this.rb10min2.CheckedChanged += new System.EventHandler(this.rb10min2_Click);
            // 
            // rb3min
            // 
            this.rb3min.AutoSize = true;
            this.rb3min.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb3min.Location = new System.Drawing.Point(19, 63);
            this.rb3min.Margin = new System.Windows.Forms.Padding(2);
            this.rb3min.Name = "rb3min";
            this.rb3min.Size = new System.Drawing.Size(50, 17);
            this.rb3min.TabIndex = 8;
            this.rb3min.TabStop = true;
            this.rb3min.Text = "3 min";
            this.rb3min.UseVisualStyleBackColor = true;
            this.rb3min.CheckedChanged += new System.EventHandler(this.rb3min_Click);
            // 
            // rb5min
            // 
            this.rb5min.AutoSize = true;
            this.rb5min.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb5min.Location = new System.Drawing.Point(19, 21);
            this.rb5min.Margin = new System.Windows.Forms.Padding(2);
            this.rb5min.Name = "rb5min";
            this.rb5min.Size = new System.Drawing.Size(50, 17);
            this.rb5min.TabIndex = 0;
            this.rb5min.TabStop = true;
            this.rb5min.Text = "5 min";
            this.rb5min.UseVisualStyleBackColor = true;
            this.rb5min.CheckedChanged += new System.EventHandler(this.rb5min_CheckedChanged);
            // 
            // rb90min
            // 
            this.rb90min.AutoSize = true;
            this.rb90min.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb90min.Location = new System.Drawing.Point(302, 42);
            this.rb90min.Margin = new System.Windows.Forms.Padding(2);
            this.rb90min.Name = "rb90min";
            this.rb90min.Size = new System.Drawing.Size(100, 17);
            this.rb90min.TabIndex = 7;
            this.rb90min.TabStop = true;
            this.rb90min.Text = "45 min + 15 sec";
            this.rb90min.UseVisualStyleBackColor = true;
            this.rb90min.CheckedChanged += new System.EventHandler(this.rb90min_CheckedChanged);
            // 
            // rb15min
            // 
            this.rb15min.AutoSize = true;
            this.rb15min.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb15min.Location = new System.Drawing.Point(302, 21);
            this.rb15min.Margin = new System.Windows.Forms.Padding(2);
            this.rb15min.Name = "rb15min";
            this.rb15min.Size = new System.Drawing.Size(94, 17);
            this.rb15min.TabIndex = 3;
            this.rb15min.TabStop = true;
            this.rb15min.Text = "15 min + 3 sec";
            this.rb15min.UseVisualStyleBackColor = true;
            this.rb15min.CheckedChanged += new System.EventHandler(this.rb15min_CheckedChanged);
            // 
            // rb2min
            // 
            this.rb2min.AutoSize = true;
            this.rb2min.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb2min.Location = new System.Drawing.Point(192, 42);
            this.rb2min.Margin = new System.Windows.Forms.Padding(2);
            this.rb2min.Name = "rb2min";
            this.rb2min.Size = new System.Drawing.Size(100, 17);
            this.rb2min.TabIndex = 6;
            this.rb2min.TabStop = true;
            this.rb2min.Text = "30 min + 10 sec";
            this.rb2min.UseVisualStyleBackColor = true;
            this.rb2min.CheckedChanged += new System.EventHandler(this.rb2min_CheckedChanged);
            // 
            // rb4min
            // 
            this.rb4min.AutoSize = true;
            this.rb4min.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb4min.Location = new System.Drawing.Point(192, 21);
            this.rb4min.Margin = new System.Windows.Forms.Padding(2);
            this.rb4min.Name = "rb4min";
            this.rb4min.Size = new System.Drawing.Size(88, 17);
            this.rb4min.TabIndex = 2;
            this.rb4min.TabStop = true;
            this.rb4min.Text = "4 min + 2 sec";
            this.rb4min.UseVisualStyleBackColor = true;
            this.rb4min.CheckedChanged += new System.EventHandler(this.rb4min_CheckedChanged);
            // 
            // rb60min
            // 
            this.rb60min.AutoSize = true;
            this.rb60min.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb60min.Location = new System.Drawing.Point(87, 42);
            this.rb60min.Margin = new System.Windows.Forms.Padding(2);
            this.rb60min.Name = "rb60min";
            this.rb60min.Size = new System.Drawing.Size(56, 17);
            this.rb60min.TabIndex = 5;
            this.rb60min.TabStop = true;
            this.rb60min.Text = "60 min";
            this.rb60min.UseVisualStyleBackColor = true;
            this.rb60min.CheckedChanged += new System.EventHandler(this.rb60min_CheckedChanged);
            // 
            // rb25min
            // 
            this.rb25min.AutoSize = true;
            this.rb25min.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb25min.Location = new System.Drawing.Point(87, 21);
            this.rb25min.Margin = new System.Windows.Forms.Padding(2);
            this.rb25min.Name = "rb25min";
            this.rb25min.Size = new System.Drawing.Size(56, 17);
            this.rb25min.TabIndex = 1;
            this.rb25min.TabStop = true;
            this.rb25min.Text = "30 min";
            this.rb25min.UseVisualStyleBackColor = true;
            this.rb25min.CheckedChanged += new System.EventHandler(this.rb25min_CheckedChanged);
            // 
            // rb10min
            // 
            this.rb10min.AutoSize = true;
            this.rb10min.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb10min.Location = new System.Drawing.Point(19, 42);
            this.rb10min.Margin = new System.Windows.Forms.Padding(2);
            this.rb10min.Name = "rb10min";
            this.rb10min.Size = new System.Drawing.Size(56, 17);
            this.rb10min.TabIndex = 4;
            this.rb10min.TabStop = true;
            this.rb10min.Text = "15 min";
            this.rb10min.UseVisualStyleBackColor = true;
            this.rb10min.CheckedChanged += new System.EventHandler(this.rb10min_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(277, 196);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(356, 196);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(2);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 22);
            this.btnHelp.TabIndex = 5;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(198, 196);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 22);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // BlitzClockForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(442, 227);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BlitzClockForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blitz and Rapid game";
            this.Load += new System.EventHandler(this.BlitzClockForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGainPerMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericTime;
        private System.Windows.Forms.NumericUpDown numericGainPerMove;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rb90min;
        private System.Windows.Forms.RadioButton rb15min;
        private System.Windows.Forms.RadioButton rb2min;
        private System.Windows.Forms.RadioButton rb4min;
        private System.Windows.Forms.RadioButton rb60min;
        private System.Windows.Forms.RadioButton rb25min;
        private System.Windows.Forms.RadioButton rb10min;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RadioButton rb5min;
        private System.Windows.Forms.RadioButton rb10min1sec;
        private System.Windows.Forms.RadioButton rb3min1sec;
        private System.Windows.Forms.RadioButton rb10min2;
        private System.Windows.Forms.RadioButton rb3min;
    }
}

