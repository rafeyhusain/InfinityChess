namespace App.Win
{
    partial class frmGameResult
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbElse = new System.Windows.Forms.RadioButton();
            this.cmbResult = new System.Windows.Forms.ComboBox();
            this.rdb0_1 = new System.Windows.Forms.RadioButton();
            this.rdb12_12 = new System.Windows.Forms.RadioButton();
            this.rdb1_0 = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbElse);
            this.groupBox1.Controls.Add(this.cmbResult);
            this.groupBox1.Controls.Add(this.rdb0_1);
            this.groupBox1.Controls.Add(this.rdb12_12);
            this.groupBox1.Controls.Add(this.rdb1_0);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 125);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Result";
            // 
            // rdbElse
            // 
            this.rdbElse.AutoSize = true;
            this.rdbElse.Location = new System.Drawing.Point(17, 87);
            this.rdbElse.Name = "rdbElse";
            this.rdbElse.Size = new System.Drawing.Size(48, 17);
            this.rdbElse.TabIndex = 3;
            this.rdbElse.TabStop = true;
            this.rdbElse.Text = "Else:";
            this.rdbElse.UseVisualStyleBackColor = true;
            this.rdbElse.Click += new System.EventHandler(this.rdbElse_Click);
            // 
            // cmbResult
            // 
            this.cmbResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResult.Enabled = false;
            this.cmbResult.FormattingEnabled = true;
            this.cmbResult.Location = new System.Drawing.Point(71, 87);
            this.cmbResult.Name = "cmbResult";
            this.cmbResult.Size = new System.Drawing.Size(89, 21);
            this.cmbResult.TabIndex = 4;
            // 
            // rdb0_1
            // 
            this.rdb0_1.AutoSize = true;
            this.rdb0_1.Location = new System.Drawing.Point(18, 63);
            this.rdb0_1.Name = "rdb0_1";
            this.rdb0_1.Size = new System.Drawing.Size(40, 17);
            this.rdb0_1.TabIndex = 2;
            this.rdb0_1.TabStop = true;
            this.rdb0_1.Text = "0-1";
            this.rdb0_1.UseVisualStyleBackColor = true;
            this.rdb0_1.Click += new System.EventHandler(this.rdb0_1_Click);
            // 
            // rdb12_12
            // 
            this.rdb12_12.AutoSize = true;
            this.rdb12_12.Location = new System.Drawing.Point(17, 39);
            this.rdb12_12.Name = "rdb12_12";
            this.rdb12_12.Size = new System.Drawing.Size(62, 17);
            this.rdb12_12.TabIndex = 1;
            this.rdb12_12.TabStop = true;
            this.rdb12_12.Text = "1/2-1/2";
            this.rdb12_12.UseVisualStyleBackColor = true;
            this.rdb12_12.Click += new System.EventHandler(this.rdb12_12_Click);
            // 
            // rdb1_0
            // 
            this.rdb1_0.AutoSize = true;
            this.rdb1_0.Location = new System.Drawing.Point(17, 15);
            this.rdb1_0.Name = "rdb1_0";
            this.rdb1_0.Size = new System.Drawing.Size(40, 17);
            this.rdb1_0.TabIndex = 0;
            this.rdb1_0.TabStop = true;
            this.rdb1_0.Text = "1-0";
            this.rdb1_0.UseVisualStyleBackColor = true;
            this.rdb1_0.Click += new System.EventHandler(this.rdb1_0_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(28, 140);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(109, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmGameResult
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(197, 170);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGameResult";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adjudicate game";
            this.Load += new System.EventHandler(this.frmGameResult_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbElse;
        private System.Windows.Forms.ComboBox cmbResult;
        private System.Windows.Forms.RadioButton rdb0_1;
        private System.Windows.Forms.RadioButton rdb12_12;
        private System.Windows.Forms.RadioButton rdb1_0;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;

    }
}