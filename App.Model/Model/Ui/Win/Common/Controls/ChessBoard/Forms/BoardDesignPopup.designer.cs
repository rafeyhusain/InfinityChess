namespace App.Win
{
    partial class BoardDesignPopup
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
            this.lblColorSchemes = new System.Windows.Forms.Label();
            this.cmbColorSchemes = new System.Windows.Forms.ComboBox();
            this.cmbPieces = new System.Windows.Forms.ComboBox();
            this.lblPieces = new System.Windows.Forms.Label();
            this.cmbBackground = new System.Windows.Forms.ComboBox();
            this.lblBackgroung = new System.Windows.Forms.Label();
            this.chkCoordinates = new System.Windows.Forms.CheckBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.lblWhite = new System.Windows.Forms.Label();
            this.lblBlack = new System.Windows.Forms.Label();
            this.lblLightSquares = new System.Windows.Forms.Label();
            this.lblDarkSquares = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblDarkSquaresColor = new System.Windows.Forms.Label();
            this.lblLightSquaresColor = new System.Windows.Forms.Label();
            this.lblBlackColor = new System.Windows.Forms.Label();
            this.lblWhiteColor = new System.Windows.Forms.Label();
            this.lblBackgroundColor = new System.Windows.Forms.Label();
            this.pbLightSquares = new System.Windows.Forms.PictureBox();
            this.pbDarkSquares = new System.Windows.Forms.PictureBox();
            this.pbBackground = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLightSquares)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDarkSquares)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // lblColorSchemes
            // 
            this.lblColorSchemes.AutoSize = true;
            this.lblColorSchemes.Location = new System.Drawing.Point(13, 113);
            this.lblColorSchemes.Name = "lblColorSchemes";
            this.lblColorSchemes.Size = new System.Drawing.Size(79, 13);
            this.lblColorSchemes.TabIndex = 0;
            this.lblColorSchemes.Text = "Color schemes:";
            // 
            // cmbColorSchemes
            // 
            this.cmbColorSchemes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColorSchemes.FormattingEnabled = true;
            this.cmbColorSchemes.Location = new System.Drawing.Point(97, 113);
            this.cmbColorSchemes.Name = "cmbColorSchemes";
            this.cmbColorSchemes.Size = new System.Drawing.Size(135, 21);
            this.cmbColorSchemes.TabIndex = 1;
            // 
            // cmbPieces
            // 
            this.cmbPieces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPieces.FormattingEnabled = true;
            this.cmbPieces.Location = new System.Drawing.Point(97, 12);
            this.cmbPieces.Name = "cmbPieces";
            this.cmbPieces.Size = new System.Drawing.Size(135, 21);
            this.cmbPieces.TabIndex = 8;
            // 
            // lblPieces
            // 
            this.lblPieces.AutoSize = true;
            this.lblPieces.Location = new System.Drawing.Point(13, 15);
            this.lblPieces.Name = "lblPieces";
            this.lblPieces.Size = new System.Drawing.Size(42, 13);
            this.lblPieces.TabIndex = 7;
            this.lblPieces.Text = "Pieces:";
            // 
            // cmbBackground
            // 
            this.cmbBackground.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBackground.FormattingEnabled = true;
            this.cmbBackground.Location = new System.Drawing.Point(89, 259);
            this.cmbBackground.Name = "cmbBackground";
            this.cmbBackground.Size = new System.Drawing.Size(135, 21);
            this.cmbBackground.TabIndex = 18;
            this.cmbBackground.Visible = false;
            this.cmbBackground.SelectedIndexChanged += new System.EventHandler(this.cmbBackground_SelectedIndexChanged);
            // 
            // lblBackgroung
            // 
            this.lblBackgroung.AutoSize = true;
            this.lblBackgroung.Location = new System.Drawing.Point(13, 210);
            this.lblBackgroung.Name = "lblBackgroung";
            this.lblBackgroung.Size = new System.Drawing.Size(68, 13);
            this.lblBackgroung.TabIndex = 17;
            this.lblBackgroung.Text = "Background:";
            // 
            // chkCoordinates
            // 
            this.chkCoordinates.AutoSize = true;
            this.chkCoordinates.Location = new System.Drawing.Point(97, 236);
            this.chkCoordinates.Name = "chkCoordinates";
            this.chkCoordinates.Size = new System.Drawing.Size(82, 17);
            this.chkCoordinates.TabIndex = 19;
            this.chkCoordinates.Text = "Coordinates";
            this.chkCoordinates.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(139, 306);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(60, 27);
            this.btnApply.TabIndex = 20;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(7, 306);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(60, 27);
            this.btnOK.TabIndex = 22;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(73, 306);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(60, 27);
            this.btnHelp.TabIndex = 23;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(213, 306);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 27);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblWhite
            // 
            this.lblWhite.AutoSize = true;
            this.lblWhite.Location = new System.Drawing.Point(19, 44);
            this.lblWhite.Name = "lblWhite";
            this.lblWhite.Size = new System.Drawing.Size(35, 13);
            this.lblWhite.TabIndex = 29;
            this.lblWhite.Text = "White";
            // 
            // lblBlack
            // 
            this.lblBlack.AutoSize = true;
            this.lblBlack.Location = new System.Drawing.Point(20, 73);
            this.lblBlack.Name = "lblBlack";
            this.lblBlack.Size = new System.Drawing.Size(34, 13);
            this.lblBlack.TabIndex = 30;
            this.lblBlack.Text = "Black";
            // 
            // lblLightSquares
            // 
            this.lblLightSquares.AutoSize = true;
            this.lblLightSquares.Location = new System.Drawing.Point(19, 146);
            this.lblLightSquares.Name = "lblLightSquares";
            this.lblLightSquares.Size = new System.Drawing.Size(72, 13);
            this.lblLightSquares.TabIndex = 31;
            this.lblLightSquares.Text = "Light Squares";
            // 
            // lblDarkSquares
            // 
            this.lblDarkSquares.AutoSize = true;
            this.lblDarkSquares.Location = new System.Drawing.Point(19, 174);
            this.lblDarkSquares.Name = "lblDarkSquares";
            this.lblDarkSquares.Size = new System.Drawing.Size(72, 13);
            this.lblDarkSquares.TabIndex = 32;
            this.lblDarkSquares.Text = "Dark Squares";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Enabled = false;
            this.btnBrowse.Location = new System.Drawing.Point(230, 259);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(37, 21);
            this.btnBrowse.TabIndex = 33;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Visible = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblDarkSquaresColor
            // 
            this.lblDarkSquaresColor.AutoSize = true;
            this.lblDarkSquaresColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDarkSquaresColor.Location = new System.Drawing.Point(94, 174);
            this.lblDarkSquaresColor.Name = "lblDarkSquaresColor";
            this.lblDarkSquaresColor.Size = new System.Drawing.Size(140, 17);
            this.lblDarkSquaresColor.TabIndex = 37;
            this.lblDarkSquaresColor.Text = "[Dark Squares Color]";
            this.lblDarkSquaresColor.Click += new System.EventHandler(this.lblDarkSquaresColor_Click);
            // 
            // lblLightSquaresColor
            // 
            this.lblLightSquaresColor.AutoSize = true;
            this.lblLightSquaresColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLightSquaresColor.Location = new System.Drawing.Point(94, 146);
            this.lblLightSquaresColor.Name = "lblLightSquaresColor";
            this.lblLightSquaresColor.Size = new System.Drawing.Size(141, 17);
            this.lblLightSquaresColor.TabIndex = 36;
            this.lblLightSquaresColor.Text = "[Light Squares Color]";
            this.lblLightSquaresColor.Click += new System.EventHandler(this.lblLightSquaresColor_Click);
            // 
            // lblBlackColor
            // 
            this.lblBlackColor.AutoSize = true;
            this.lblBlackColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlackColor.Location = new System.Drawing.Point(94, 73);
            this.lblBlackColor.Name = "lblBlackColor";
            this.lblBlackColor.Size = new System.Drawing.Size(87, 17);
            this.lblBlackColor.TabIndex = 35;
            this.lblBlackColor.Text = "[Black Color]";
            this.lblBlackColor.Click += new System.EventHandler(this.lblBlackColor_Click);
            // 
            // lblWhiteColor
            // 
            this.lblWhiteColor.AutoSize = true;
            this.lblWhiteColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhiteColor.Location = new System.Drawing.Point(94, 44);
            this.lblWhiteColor.Name = "lblWhiteColor";
            this.lblWhiteColor.Size = new System.Drawing.Size(89, 17);
            this.lblWhiteColor.TabIndex = 34;
            this.lblWhiteColor.Text = "[White Color]";
            this.lblWhiteColor.Click += new System.EventHandler(this.lblWhiteColor_Click);
            // 
            // lblBackgroundColor
            // 
            this.lblBackgroundColor.AutoSize = true;
            this.lblBackgroundColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackgroundColor.Location = new System.Drawing.Point(95, 206);
            this.lblBackgroundColor.Name = "lblBackgroundColor";
            this.lblBackgroundColor.Size = new System.Drawing.Size(129, 17);
            this.lblBackgroundColor.TabIndex = 38;
            this.lblBackgroundColor.Text = "[Background Color]";
            this.lblBackgroundColor.Click += new System.EventHandler(this.lblBackgroundColor_Click);
            // 
            // pbLightSquares
            // 
            this.pbLightSquares.Location = new System.Drawing.Point(241, 138);
            this.pbLightSquares.Name = "pbLightSquares";
            this.pbLightSquares.Size = new System.Drawing.Size(46, 25);
            this.pbLightSquares.TabIndex = 39;
            this.pbLightSquares.TabStop = false;
            this.pbLightSquares.Click += new System.EventHandler(this.pbLightSquares_Click);
            // 
            // pbDarkSquares
            // 
            this.pbDarkSquares.Location = new System.Drawing.Point(241, 167);
            this.pbDarkSquares.Name = "pbDarkSquares";
            this.pbDarkSquares.Size = new System.Drawing.Size(46, 25);
            this.pbDarkSquares.TabIndex = 40;
            this.pbDarkSquares.TabStop = false;
            this.pbDarkSquares.Click += new System.EventHandler(this.pbDarkSquares_Click);
            // 
            // pbBackground
            // 
            this.pbBackground.Location = new System.Drawing.Point(241, 198);
            this.pbBackground.Name = "pbBackground";
            this.pbBackground.Size = new System.Drawing.Size(46, 25);
            this.pbBackground.TabIndex = 41;
            this.pbBackground.TabStop = false;
            this.pbBackground.Click += new System.EventHandler(this.pbBackground_Click);
            // 
            // BoardDesignPopup
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(295, 341);
            this.Controls.Add(this.pbBackground);
            this.Controls.Add(this.pbDarkSquares);
            this.Controls.Add(this.pbLightSquares);
            this.Controls.Add(this.lblBackgroundColor);
            this.Controls.Add(this.lblDarkSquaresColor);
            this.Controls.Add(this.lblLightSquaresColor);
            this.Controls.Add(this.lblBlackColor);
            this.Controls.Add(this.lblWhiteColor);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblDarkSquares);
            this.Controls.Add(this.lblLightSquares);
            this.Controls.Add(this.lblBlack);
            this.Controls.Add(this.lblWhite);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.chkCoordinates);
            this.Controls.Add(this.cmbBackground);
            this.Controls.Add(this.lblBackgroung);
            this.Controls.Add(this.cmbPieces);
            this.Controls.Add(this.lblPieces);
            this.Controls.Add(this.cmbColorSchemes);
            this.Controls.Add(this.lblColorSchemes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BoardDesignPopup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Board Design";
            this.Load += new System.EventHandler(this.BoardDesign_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLightSquares)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDarkSquares)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblColorSchemes;
        private System.Windows.Forms.ComboBox cmbColorSchemes;
        private System.Windows.Forms.ComboBox cmbPieces;
        private System.Windows.Forms.Label lblPieces;
        private System.Windows.Forms.ComboBox cmbBackground;
        private System.Windows.Forms.Label lblBackgroung;
        private System.Windows.Forms.CheckBox chkCoordinates;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lblWhite;
        private System.Windows.Forms.Label lblBlack;
        private System.Windows.Forms.Label lblLightSquares;
        private System.Windows.Forms.Label lblDarkSquares;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblDarkSquaresColor;
        private System.Windows.Forms.Label lblLightSquaresColor;
        private System.Windows.Forms.Label lblBlackColor;
        private System.Windows.Forms.Label lblWhiteColor;
        private System.Windows.Forms.Label lblBackgroundColor;
        private System.Windows.Forms.PictureBox pbLightSquares;
        private System.Windows.Forms.PictureBox pbDarkSquares;
        private System.Windows.Forms.PictureBox pbBackground;
    }
}