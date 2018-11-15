namespace App.Win
{
    partial class ImportGameEditor
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
            this.lblGamesFrom = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numLength = new System.Windows.Forms.NumericUpDown();
            this.rdbECORelativeLength = new System.Windows.Forms.RadioButton();
            this.rdbAbsoluteLength = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.numFromGameNo = new System.Windows.Forms.NumericUpDown();
            this.numToGameNo = new System.Windows.Forms.NumericUpDown();
            this.chkIncludeVariations = new System.Windows.Forms.CheckBox();
            this.lblGamesTo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFromGameNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToGameNo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGamesFrom
            // 
            this.lblGamesFrom.AutoSize = true;
            this.lblGamesFrom.Location = new System.Drawing.Point(16, 18);
            this.lblGamesFrom.Name = "lblGamesFrom";
            this.lblGamesFrom.Size = new System.Drawing.Size(40, 13);
            this.lblGamesFrom.TabIndex = 0;
            this.lblGamesFrom.Text = "Games";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numLength);
            this.groupBox1.Controls.Add(this.rdbECORelativeLength);
            this.groupBox1.Controls.Add(this.rdbAbsoluteLength);
            this.groupBox1.Enabled = false;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(16, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 74);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Length";
            // 
            // numLength
            // 
            this.numLength.Location = new System.Drawing.Point(137, 40);
            this.numLength.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.numLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLength.Name = "numLength";
            this.numLength.Size = new System.Drawing.Size(59, 20);
            this.numLength.TabIndex = 2;
            this.numLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rdbECORelativeLength
            // 
            this.rdbECORelativeLength.AutoSize = true;
            this.rdbECORelativeLength.Location = new System.Drawing.Point(17, 43);
            this.rdbECORelativeLength.Name = "rdbECORelativeLength";
            this.rdbECORelativeLength.Size = new System.Drawing.Size(116, 17);
            this.rdbECORelativeLength.TabIndex = 1;
            this.rdbECORelativeLength.TabStop = true;
            this.rdbECORelativeLength.Text = "ECO-relative length";
            this.rdbECORelativeLength.UseVisualStyleBackColor = true;
            // 
            // rdbAbsoluteLength
            // 
            this.rdbAbsoluteLength.AutoSize = true;
            this.rdbAbsoluteLength.Location = new System.Drawing.Point(17, 20);
            this.rdbAbsoluteLength.Name = "rdbAbsoluteLength";
            this.rdbAbsoluteLength.Size = new System.Drawing.Size(98, 17);
            this.rdbAbsoluteLength.TabIndex = 0;
            this.rdbAbsoluteLength.TabStop = true;
            this.rdbAbsoluteLength.Text = "Absolute length";
            this.rdbAbsoluteLength.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(23, 166);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 22);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(104, 166);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 22);
            this.btnHelp.TabIndex = 5;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(185, 166);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // numFromGameNo
            // 
            this.numFromGameNo.Location = new System.Drawing.Point(58, 14);
            this.numFromGameNo.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numFromGameNo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFromGameNo.Name = "numFromGameNo";
            this.numFromGameNo.Size = new System.Drawing.Size(58, 20);
            this.numFromGameNo.TabIndex = 0;
            this.numFromGameNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFromGameNo.ValueChanged += new System.EventHandler(this.numFromGameNo_ValueChanged);
            // 
            // numToGameNo
            // 
            this.numToGameNo.Location = new System.Drawing.Point(140, 14);
            this.numToGameNo.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.numToGameNo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numToGameNo.Name = "numToGameNo";
            this.numToGameNo.Size = new System.Drawing.Size(58, 20);
            this.numToGameNo.TabIndex = 1;
            this.numToGameNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkIncludeVariations
            // 
            this.chkIncludeVariations.AutoSize = true;
            this.chkIncludeVariations.Enabled = false;
            this.chkIncludeVariations.Location = new System.Drawing.Point(34, 135);
            this.chkIncludeVariations.Name = "chkIncludeVariations";
            this.chkIncludeVariations.Size = new System.Drawing.Size(109, 17);
            this.chkIncludeVariations.TabIndex = 3;
            this.chkIncludeVariations.Text = "Include variations";
            this.chkIncludeVariations.UseVisualStyleBackColor = true;
            // 
            // lblGamesTo
            // 
            this.lblGamesTo.AutoSize = true;
            this.lblGamesTo.Location = new System.Drawing.Point(123, 18);
            this.lblGamesTo.Name = "lblGamesTo";
            this.lblGamesTo.Size = new System.Drawing.Size(10, 13);
            this.lblGamesTo.TabIndex = 17;
            this.lblGamesTo.Text = "-";
            // 
            // ImportGameEditor
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(276, 200);
            this.Controls.Add(this.lblGamesTo);
            this.Controls.Add(this.chkIncludeVariations);
            this.Controls.Add(this.numToGameNo);
            this.Controls.Add(this.numFromGameNo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblGamesFrom);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportGameEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import games";
            this.Load += new System.EventHandler(this.frmSource_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFromGameNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToGameNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGamesFrom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbECORelativeLength;
        private System.Windows.Forms.RadioButton rdbAbsoluteLength;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown numFromGameNo;
        private System.Windows.Forms.NumericUpDown numToGameNo;
        private System.Windows.Forms.NumericUpDown numLength;
        private System.Windows.Forms.CheckBox chkIncludeVariations;
        private System.Windows.Forms.Label lblGamesTo;
    }
}