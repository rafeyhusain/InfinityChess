namespace App.Win
{
    partial class UserData
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
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblEmailAddress = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.rbMr = new System.Windows.Forms.RadioButton();
            this.rbMrs = new System.Windows.Forms.RadioButton();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblLoginId = new System.Windows.Forms.Label();
            this.txtLoginId = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbFlag = new System.Windows.Forms.PictureBox();
            this.cbNearestCity = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pbUser = new System.Windows.Forms.PictureBox();
            this.btnChangePicture = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.chkICCF = new System.Windows.Forms.CheckBox();
            this.rbIccfIM = new System.Windows.Forms.RadioButton();
            this.rbIccfGM = new System.Windows.Forms.RadioButton();
            this.rbIccfSIM = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.chkFIDE = new System.Windows.Forms.CheckBox();
            this.rbGM = new System.Windows.Forms.RadioButton();
            this.rbFM = new System.Windows.Forms.RadioButton();
            this.rbIM = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.rbComp = new System.Windows.Forms.RadioButton();
            this.btnHelp = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlag)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUser)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(6, 76);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(63, 13);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name :";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(6, 103);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(64, 13);
            this.lblLastName.TabIndex = 1;
            this.lblLastName.Text = "Last Name :";
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.AutoSize = true;
            this.lblEmailAddress.Location = new System.Drawing.Point(6, 49);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new System.Drawing.Size(79, 13);
            this.lblEmailAddress.TabIndex = 3;
            this.lblEmailAddress.Text = "Email Address :";
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(6, 158);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(49, 13);
            this.lblCountry.TabIndex = 4;
            this.lblCountry.Text = "Country :";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(107, 73);
            this.txtFirstName.MaxLength = 50;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(186, 20);
            this.txtFirstName.TabIndex = 2;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(107, 100);
            this.txtLastName.MaxLength = 50;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(186, 20);
            this.txtLastName.TabIndex = 3;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(107, 46);
            this.txtEmail.MaxLength = 256;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(186, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // rbMr
            // 
            this.rbMr.AutoSize = true;
            this.rbMr.Checked = true;
            this.rbMr.Location = new System.Drawing.Point(98, 14);
            this.rbMr.Name = "rbMr";
            this.rbMr.Size = new System.Drawing.Size(43, 17);
            this.rbMr.TabIndex = 0;
            this.rbMr.TabStop = true;
            this.rbMr.Text = " Mr.";
            this.rbMr.UseVisualStyleBackColor = true;
            // 
            // rbMrs
            // 
            this.rbMrs.AutoSize = true;
            this.rbMrs.Location = new System.Drawing.Point(153, 14);
            this.rbMrs.Name = "rbMrs";
            this.rbMrs.Size = new System.Drawing.Size(45, 17);
            this.rbMrs.TabIndex = 1;
            this.rbMrs.Text = "Mrs.";
            this.rbMrs.UseVisualStyleBackColor = true;
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.CustomFormat = "dd-MMM-yyyy";
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(6, 150);
            this.dtpDateOfBirth.MaxDate = new System.DateTime(2010, 1, 14, 0, 0, 0, 0);
            this.dtpDateOfBirth.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(150, 20);
            this.dtpDateOfBirth.TabIndex = 0;
            this.dtpDateOfBirth.Value = new System.DateTime(2010, 1, 14, 0, 0, 0, 0);
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(3, 134);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(74, 13);
            this.lblDateOfBirth.TabIndex = 0;
            this.lblDateOfBirth.Text = "Date Of Birth :";
            // 
            // cbCountry
            // 
            this.cbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(107, 155);
            this.cbCountry.MaxDropDownItems = 10;
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(150, 21);
            this.cbCountry.TabIndex = 5;
            this.cbCountry.SelectedIndexChanged += new System.EventHandler(this.cbCountry_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(343, 408);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(262, 408);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblLoginId
            // 
            this.lblLoginId.AutoSize = true;
            this.lblLoginId.Location = new System.Drawing.Point(6, 22);
            this.lblLoginId.Name = "lblLoginId";
            this.lblLoginId.Size = new System.Drawing.Size(48, 13);
            this.lblLoginId.TabIndex = 10;
            this.lblLoginId.Text = "LoginId :";
            // 
            // txtLoginId
            // 
            this.txtLoginId.Location = new System.Drawing.Point(107, 19);
            this.txtLoginId.MaxLength = 50;
            this.txtLoginId.Name = "txtLoginId";
            this.txtLoginId.Size = new System.Drawing.Size(186, 20);
            this.txtLoginId.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbFlag);
            this.groupBox1.Controls.Add(this.lblCountry);
            this.groupBox1.Controls.Add(this.txtLoginId);
            this.groupBox1.Controls.Add(this.lblLoginId);
            this.groupBox1.Controls.Add(this.cbNearestCity);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.lblEmailAddress);
            this.groupBox1.Controls.Add(this.txtFirstName);
            this.groupBox1.Controls.Add(this.cbCountry);
            this.groupBox1.Controls.Add(this.lblFirstName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtLastName);
            this.groupBox1.Controls.Add(this.lblLastName);
            this.groupBox1.Location = new System.Drawing.Point(19, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 208);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Identity";
            // 
            // pbFlag
            // 
            this.pbFlag.Location = new System.Drawing.Point(271, 158);
            this.pbFlag.Name = "pbFlag";
            this.pbFlag.Size = new System.Drawing.Size(22, 15);
            this.pbFlag.TabIndex = 18;
            this.pbFlag.TabStop = false;
            // 
            // cbNearestCity
            // 
            this.cbNearestCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNearestCity.FormattingEnabled = true;
            this.cbNearestCity.Location = new System.Drawing.Point(107, 127);
            this.cbNearestCity.MaxDropDownItems = 10;
            this.cbNearestCity.Name = "cbNearestCity";
            this.cbNearestCity.Size = new System.Drawing.Size(186, 21);
            this.cbNearestCity.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Nearest City :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pbUser);
            this.groupBox2.Controls.Add(this.btnChangePicture);
            this.groupBox2.Location = new System.Drawing.Point(335, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(164, 208);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Your Picture";
            // 
            // pbUser
            // 
            this.pbUser.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbUser.Location = new System.Drawing.Point(6, 19);
            this.pbUser.Name = "pbUser";
            this.pbUser.Size = new System.Drawing.Size(150, 150);
            this.pbUser.TabIndex = 21;
            this.pbUser.TabStop = false;
            // 
            // btnChangePicture
            // 
            this.btnChangePicture.Location = new System.Drawing.Point(6, 179);
            this.btnChangePicture.Name = "btnChangePicture";
            this.btnChangePicture.Size = new System.Drawing.Size(150, 23);
            this.btnChangePicture.TabIndex = 0;
            this.btnChangePicture.Text = "Change Picture";
            this.btnChangePicture.UseVisualStyleBackColor = true;
            this.btnChangePicture.Click += new System.EventHandler(this.btnChangePicture_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox8);
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Location = new System.Drawing.Point(19, 225);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(310, 131);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rating and Title Data";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.chkICCF);
            this.groupBox8.Controls.Add(this.rbIccfIM);
            this.groupBox8.Controls.Add(this.rbIccfGM);
            this.groupBox8.Controls.Add(this.rbIccfSIM);
            this.groupBox8.Location = new System.Drawing.Point(9, 88);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(295, 37);
            this.groupBox8.TabIndex = 2;
            this.groupBox8.TabStop = false;
            // 
            // chkICCF
            // 
            this.chkICCF.AutoSize = true;
            this.chkICCF.Location = new System.Drawing.Point(6, 13);
            this.chkICCF.Name = "chkICCF";
            this.chkICCF.Size = new System.Drawing.Size(78, 17);
            this.chkICCF.TabIndex = 0;
            this.chkICCF.Text = "ICCF Title :";
            this.chkICCF.UseVisualStyleBackColor = true;
            this.chkICCF.CheckedChanged += new System.EventHandler(this.chkICCF_CheckedChanged);
            // 
            // rbIccfIM
            // 
            this.rbIccfIM.AutoSize = true;
            this.rbIccfIM.Location = new System.Drawing.Point(98, 13);
            this.rbIccfIM.Name = "rbIccfIM";
            this.rbIccfIM.Size = new System.Drawing.Size(37, 17);
            this.rbIccfIM.TabIndex = 1;
            this.rbIccfIM.TabStop = true;
            this.rbIccfIM.Text = "IM";
            this.rbIccfIM.UseVisualStyleBackColor = true;
            // 
            // rbIccfGM
            // 
            this.rbIccfGM.AutoSize = true;
            this.rbIccfGM.Location = new System.Drawing.Point(214, 12);
            this.rbIccfGM.Name = "rbIccfGM";
            this.rbIccfGM.Size = new System.Drawing.Size(42, 17);
            this.rbIccfGM.TabIndex = 3;
            this.rbIccfGM.TabStop = true;
            this.rbIccfGM.Text = "GM";
            this.rbIccfGM.UseVisualStyleBackColor = true;
            // 
            // rbIccfSIM
            // 
            this.rbIccfSIM.AutoSize = true;
            this.rbIccfSIM.Location = new System.Drawing.Point(153, 13);
            this.rbIccfSIM.Name = "rbIccfSIM";
            this.rbIccfSIM.Size = new System.Drawing.Size(44, 17);
            this.rbIccfSIM.TabIndex = 2;
            this.rbIccfSIM.TabStop = true;
            this.rbIccfSIM.Text = "SIM";
            this.rbIccfSIM.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.chkFIDE);
            this.groupBox7.Controls.Add(this.rbGM);
            this.groupBox7.Controls.Add(this.rbFM);
            this.groupBox7.Controls.Add(this.rbIM);
            this.groupBox7.Location = new System.Drawing.Point(9, 50);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(295, 37);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            // 
            // chkFIDE
            // 
            this.chkFIDE.AutoSize = true;
            this.chkFIDE.Location = new System.Drawing.Point(6, 14);
            this.chkFIDE.Name = "chkFIDE";
            this.chkFIDE.Size = new System.Drawing.Size(79, 17);
            this.chkFIDE.TabIndex = 0;
            this.chkFIDE.Text = "FIDE Title :";
            this.chkFIDE.UseVisualStyleBackColor = true;
            this.chkFIDE.CheckedChanged += new System.EventHandler(this.chkFIDE_CheckedChanged);
            // 
            // rbGM
            // 
            this.rbGM.AutoSize = true;
            this.rbGM.Location = new System.Drawing.Point(214, 13);
            this.rbGM.Name = "rbGM";
            this.rbGM.Size = new System.Drawing.Size(42, 17);
            this.rbGM.TabIndex = 3;
            this.rbGM.TabStop = true;
            this.rbGM.Text = "GM";
            this.rbGM.UseVisualStyleBackColor = true;
            // 
            // rbFM
            // 
            this.rbFM.AutoSize = true;
            this.rbFM.Location = new System.Drawing.Point(98, 13);
            this.rbFM.Name = "rbFM";
            this.rbFM.Size = new System.Drawing.Size(40, 17);
            this.rbFM.TabIndex = 1;
            this.rbFM.TabStop = true;
            this.rbFM.Text = "FM";
            this.rbFM.UseVisualStyleBackColor = true;
            // 
            // rbIM
            // 
            this.rbIM.AutoSize = true;
            this.rbIM.Location = new System.Drawing.Point(153, 13);
            this.rbIM.Name = "rbIM";
            this.rbIM.Size = new System.Drawing.Size(37, 17);
            this.rbIM.TabIndex = 2;
            this.rbIM.TabStop = true;
            this.rbIM.Text = "IM";
            this.rbIM.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblGender);
            this.groupBox6.Controls.Add(this.rbMr);
            this.groupBox6.Controls.Add(this.rbMrs);
            this.groupBox6.Controls.Add(this.rbComp);
            this.groupBox6.Location = new System.Drawing.Point(9, 13);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(295, 37);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(3, 16);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(48, 13);
            this.lblGender.TabIndex = 19;
            this.lblGender.Text = "Gender :";
            // 
            // rbComp
            // 
            this.rbComp.AutoSize = true;
            this.rbComp.Location = new System.Drawing.Point(214, 14);
            this.rbComp.Name = "rbComp";
            this.rbComp.Size = new System.Drawing.Size(55, 17);
            this.rbComp.TabIndex = 2;
            this.rbComp.Text = "Comp.";
            this.rbComp.UseVisualStyleBackColor = true;
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.Location = new System.Drawing.Point(424, 408);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 5;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtNotes);
            this.groupBox4.Controls.Add(this.dtpDateOfBirth);
            this.groupBox4.Controls.Add(this.lblDateOfBirth);
            this.groupBox4.Location = new System.Drawing.Point(335, 225);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(164, 177);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Personal Information";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(6, 19);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(150, 106);
            this.txtNotes.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtURL);
            this.groupBox5.Location = new System.Drawing.Point(19, 356);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(310, 46);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "URL";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(9, 19);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(284, 20);
            this.txtURL.TabIndex = 0;
            // 
            // UserData
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(519, 443);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserData";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Data";
            this.Load += new System.EventHandler(this.RegistrationForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlag)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbUser)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblEmailAddress;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.RadioButton rbMr;
        private System.Windows.Forms.RadioButton rbMrs;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblLoginId;
        private System.Windows.Forms.TextBox txtLoginId;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnChangePicture;
        private System.Windows.Forms.PictureBox pbUser;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbComp;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.RadioButton rbGM;
        private System.Windows.Forms.RadioButton rbIM;
        private System.Windows.Forms.RadioButton rbFM;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.ComboBox cbNearestCity;
        private System.Windows.Forms.RadioButton rbIccfGM;
        private System.Windows.Forms.RadioButton rbIccfSIM;
        private System.Windows.Forms.RadioButton rbIccfIM;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.PictureBox pbFlag;
        private System.Windows.Forms.CheckBox chkFIDE;
        private System.Windows.Forms.CheckBox chkICCF;
        private System.Windows.Forms.Label lblGender;
    }
}