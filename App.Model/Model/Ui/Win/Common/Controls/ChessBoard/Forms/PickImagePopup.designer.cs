namespace App.Win
{
    partial class PickImagePopup
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
            this.cmbBackground = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbPickImage = new System.Windows.Forms.RadioButton();
            this.rdbChooseImage = new System.Windows.Forms.RadioButton();
            this.rdbPickColor = new System.Windows.Forms.RadioButton();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbBackground
            // 
            this.cmbBackground.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBackground.FormattingEnabled = true;
            this.cmbBackground.Location = new System.Drawing.Point(114, 19);
            this.cmbBackground.Name = "cmbBackground";
            this.cmbBackground.Size = new System.Drawing.Size(135, 21);
            this.cmbBackground.TabIndex = 18;
            this.cmbBackground.SelectedIndexChanged += new System.EventHandler(this.cmbBackground_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 127);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(83, 27);
            this.btnOK.TabIndex = 22;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(193, 127);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 27);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbPickImage);
            this.groupBox3.Controls.Add(this.rdbChooseImage);
            this.groupBox3.Controls.Add(this.rdbPickColor);
            this.groupBox3.Controls.Add(this.cmbBackground);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(264, 100);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            // 
            // rdbPickImage
            // 
            this.rdbPickImage.AutoSize = true;
            this.rdbPickImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPickImage.Location = new System.Drawing.Point(17, 70);
            this.rdbPickImage.Name = "rdbPickImage";
            this.rdbPickImage.Size = new System.Drawing.Size(78, 17);
            this.rdbPickImage.TabIndex = 2;
            this.rdbPickImage.Text = "Pick Image";
            this.rdbPickImage.UseVisualStyleBackColor = true;
            this.rdbPickImage.Click += new System.EventHandler(this.rdbPickImage_Click);
            // 
            // rdbChooseImage
            // 
            this.rdbChooseImage.AutoSize = true;
            this.rdbChooseImage.Checked = true;
            this.rdbChooseImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbChooseImage.Location = new System.Drawing.Point(17, 24);
            this.rdbChooseImage.Name = "rdbChooseImage";
            this.rdbChooseImage.Size = new System.Drawing.Size(93, 17);
            this.rdbChooseImage.TabIndex = 1;
            this.rdbChooseImage.TabStop = true;
            this.rdbChooseImage.Text = "Choose Image";
            this.rdbChooseImage.UseVisualStyleBackColor = true;
            this.rdbChooseImage.Click += new System.EventHandler(this.rdbChooseImage_Click);
            // 
            // rdbPickColor
            // 
            this.rdbPickColor.AutoSize = true;
            this.rdbPickColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPickColor.Location = new System.Drawing.Point(17, 47);
            this.rdbPickColor.Name = "rdbPickColor";
            this.rdbPickColor.Size = new System.Drawing.Size(73, 17);
            this.rdbPickColor.TabIndex = 0;
            this.rdbPickColor.Text = "Pick Color";
            this.rdbPickColor.UseVisualStyleBackColor = true;
            this.rdbPickColor.Click += new System.EventHandler(this.rdbPickColor_Click);
            // 
            // PickImagePopup
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(288, 163);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PickImagePopup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pick Image";
            this.Load += new System.EventHandler(this.PickImagePopup_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbBackground;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbPickImage;
        private System.Windows.Forms.RadioButton rdbChooseImage;
        private System.Windows.Forms.RadioButton rdbPickColor;
    }
}