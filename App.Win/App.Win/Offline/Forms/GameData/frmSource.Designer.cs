namespace InfinityChess.GameData
{
    partial class frmSource
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtPublisher = new System.Windows.Forms.TextBox();
            this.lblPublisher = new System.Windows.Forms.Label();
            this.lblPublication = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.numVersion = new System.Windows.Forms.NumericUpDown();
            this.dtpPublication = new System.Windows.Forms.DateTimePicker();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbLow = new System.Windows.Forms.RadioButton();
            this.rdbNormal = new System.Windows.Forms.RadioButton();
            this.rdbHigh = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numVersion)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(77, 17);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(169, 20);
            this.txtTitle.TabIndex = 0;
            // 
            // txtPublisher
            // 
            this.txtPublisher.Location = new System.Drawing.Point(77, 43);
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.Size = new System.Drawing.Size(169, 20);
            this.txtPublisher.TabIndex = 1;
            // 
            // lblPublisher
            // 
            this.lblPublisher.AutoSize = true;
            this.lblPublisher.Location = new System.Drawing.Point(12, 43);
            this.lblPublisher.Name = "lblPublisher";
            this.lblPublisher.Size = new System.Drawing.Size(50, 13);
            this.lblPublisher.TabIndex = 2;
            this.lblPublisher.Text = "Publisher";
            // 
            // lblPublication
            // 
            this.lblPublication.AutoSize = true;
            this.lblPublication.Location = new System.Drawing.Point(12, 76);
            this.lblPublication.Name = "lblPublication";
            this.lblPublication.Size = new System.Drawing.Size(59, 13);
            this.lblPublication.TabIndex = 4;
            this.lblPublication.Text = "Publication";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(12, 103);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Date";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(204, 73);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(42, 13);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "Version";
            // 
            // numVersion
            // 
            this.numVersion.Location = new System.Drawing.Point(207, 96);
            this.numVersion.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numVersion.Name = "numVersion";
            this.numVersion.Size = new System.Drawing.Size(39, 20);
            this.numVersion.TabIndex = 5;
            this.numVersion.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dtpPublication
            // 
            this.dtpPublication.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPublication.Location = new System.Drawing.Point(77, 69);
            this.dtpPublication.Name = "dtpPublication";
            this.dtpPublication.Size = new System.Drawing.Size(124, 20);
            this.dtpPublication.TabIndex = 2;
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(77, 96);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(124, 20);
            this.dtpDate.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbLow);
            this.groupBox1.Controls.Add(this.rdbNormal);
            this.groupBox1.Controls.Add(this.rdbHigh);
            this.groupBox1.Location = new System.Drawing.Point(16, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quality";
            // 
            // rdbLow
            // 
            this.rdbLow.AutoSize = true;
            this.rdbLow.Location = new System.Drawing.Point(185, 19);
            this.rdbLow.Name = "rdbLow";
            this.rdbLow.Size = new System.Drawing.Size(45, 17);
            this.rdbLow.TabIndex = 2;
            this.rdbLow.TabStop = true;
            this.rdbLow.Text = "Low";
            this.rdbLow.UseVisualStyleBackColor = true;
            // 
            // rdbNormal
            // 
            this.rdbNormal.AutoSize = true;
            this.rdbNormal.Location = new System.Drawing.Point(92, 19);
            this.rdbNormal.Name = "rdbNormal";
            this.rdbNormal.Size = new System.Drawing.Size(58, 17);
            this.rdbNormal.TabIndex = 1;
            this.rdbNormal.TabStop = true;
            this.rdbNormal.Text = "Normal";
            this.rdbNormal.UseVisualStyleBackColor = true;
            // 
            // rdbHigh
            // 
            this.rdbHigh.AutoSize = true;
            this.rdbHigh.Location = new System.Drawing.Point(18, 19);
            this.rdbHigh.Name = "rdbHigh";
            this.rdbHigh.Size = new System.Drawing.Size(47, 17);
            this.rdbHigh.TabIndex = 1;
            this.rdbHigh.TabStop = true;
            this.rdbHigh.Text = "High";
            this.rdbHigh.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(16, 183);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(108, 183);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(196, 183);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmSource
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(284, 218);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.dtpPublication);
            this.Controls.Add(this.numVersion);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblPublication);
            this.Controls.Add(this.txtPublisher);
            this.Controls.Add(this.lblPublisher);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSource";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Source";
            this.Load += new System.EventHandler(this.frmSource_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numVersion)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtPublisher;
        private System.Windows.Forms.Label lblPublisher;
        private System.Windows.Forms.Label lblPublication;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.NumericUpDown numVersion;
        private System.Windows.Forms.DateTimePicker dtpPublication;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbLow;
        private System.Windows.Forms.RadioButton rdbNormal;
        private System.Windows.Forms.RadioButton rdbHigh;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnCancel;
    }
}