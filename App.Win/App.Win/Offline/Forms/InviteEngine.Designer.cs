namespace App.Win
{
    partial class InviteEngine
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
            this.lstEngines = new System.Windows.Forms.ListBox();
            this.btnBookChoice = new System.Windows.Forms.Button();
            this.btnBookOption = new System.Windows.Forms.Button();
            this.btnEnginParameter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkUseTablebases = new System.Windows.Forms.CheckBox();
            this.lblBook = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.numHashTableSize = new System.Windows.Forms.NumericUpDown();
            this.btnCreateEngine = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numHashTableSize)).BeginInit();
            this.SuspendLayout();
            // 
            // lstEngines
            // 
            this.lstEngines.FormattingEnabled = true;
            this.lstEngines.Location = new System.Drawing.Point(4, 6);
            this.lstEngines.Name = "lstEngines";
            this.lstEngines.Size = new System.Drawing.Size(246, 121);
            this.lstEngines.TabIndex = 0;
            this.lstEngines.TabStop = false;
            // 
            // btnBookChoice
            // 
            this.btnBookChoice.Location = new System.Drawing.Point(15, 135);
            this.btnBookChoice.Name = "btnBookChoice";
            this.btnBookChoice.Size = new System.Drawing.Size(101, 22);
            this.btnBookChoice.TabIndex = 0;
            this.btnBookChoice.Text = "Book Choice";
            this.btnBookChoice.UseVisualStyleBackColor = true;
            this.btnBookChoice.Click += new System.EventHandler(this.btnBookChoice_Click);
            // 
            // btnBookOption
            // 
            this.btnBookOption.Location = new System.Drawing.Point(15, 161);
            this.btnBookOption.Name = "btnBookOption";
            this.btnBookOption.Size = new System.Drawing.Size(101, 22);
            this.btnBookOption.TabIndex = 1;
            this.btnBookOption.Text = "Book Option";
            this.btnBookOption.UseVisualStyleBackColor = true;
            this.btnBookOption.Click += new System.EventHandler(this.btnBookOption_Click);
            // 
            // btnEnginParameter
            // 
            this.btnEnginParameter.Location = new System.Drawing.Point(15, 187);
            this.btnEnginParameter.Name = "btnEnginParameter";
            this.btnEnginParameter.Size = new System.Drawing.Size(101, 22);
            this.btnEnginParameter.TabIndex = 3;
            this.btnEnginParameter.Text = "Engine Parameter";
            this.btnEnginParameter.UseVisualStyleBackColor = true;
            this.btnEnginParameter.Click += new System.EventHandler(this.btnEnginParameter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hashtable size[MB]";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(92, 282);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(76, 22);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(174, 282);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 22);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkUseTablebases
            // 
            this.chkUseTablebases.AutoSize = true;
            this.chkUseTablebases.Location = new System.Drawing.Point(124, 164);
            this.chkUseTablebases.Name = "chkUseTablebases";
            this.chkUseTablebases.Size = new System.Drawing.Size(103, 17);
            this.chkUseTablebases.TabIndex = 2;
            this.chkUseTablebases.Text = "Use Tablebases";
            this.chkUseTablebases.UseVisualStyleBackColor = true;
            this.chkUseTablebases.Visible = false;
            // 
            // lblBook
            // 
            this.lblBook.AutoSize = true;
            this.lblBook.Location = new System.Drawing.Point(124, 140);
            this.lblBook.Name = "lblBook";
            this.lblBook.Size = new System.Drawing.Size(48, 13);
            this.lblBook.TabIndex = 0;
            this.lblBook.Text = "No book";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // numHashTableSize
            // 
            this.numHashTableSize.Location = new System.Drawing.Point(124, 245);
            this.numHashTableSize.Margin = new System.Windows.Forms.Padding(2);
            this.numHashTableSize.Maximum = new decimal(new int[] {
            1596,
            0,
            0,
            0});
            this.numHashTableSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHashTableSize.Name = "numHashTableSize";
            this.numHashTableSize.Size = new System.Drawing.Size(44, 20);
            this.numHashTableSize.TabIndex = 5;
            this.numHashTableSize.Value = new decimal(new int[] {
            311,
            0,
            0,
            0});
            // 
            // btnCreateEngine
            // 
            this.btnCreateEngine.Location = new System.Drawing.Point(15, 215);
            this.btnCreateEngine.Name = "btnCreateEngine";
            this.btnCreateEngine.Size = new System.Drawing.Size(101, 22);
            this.btnCreateEngine.TabIndex = 9;
            this.btnCreateEngine.Text = "Create Engine...";
            this.btnCreateEngine.UseVisualStyleBackColor = true;
            this.btnCreateEngine.Click += new System.EventHandler(this.btnCreateEngine_Click);
            // 
            // InviteEngine
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(255, 315);
            this.Controls.Add(this.btnCreateEngine);
            this.Controls.Add(this.numHashTableSize);
            this.Controls.Add(this.lblBook);
            this.Controls.Add(this.chkUseTablebases);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEnginParameter);
            this.Controls.Add(this.btnBookOption);
            this.Controls.Add(this.btnBookChoice);
            this.Controls.Add(this.lstEngines);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InviteEngine";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InfinityChess: Invite Engine";
            this.Load += new System.EventHandler(this.InviteEngine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numHashTableSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstEngines;
        private System.Windows.Forms.Button btnBookChoice;
        private System.Windows.Forms.Button btnBookOption;
        private System.Windows.Forms.Button btnEnginParameter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkUseTablebases;
        private System.Windows.Forms.Label lblBook;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.NumericUpDown numHashTableSize;
        private System.Windows.Forms.Button btnCreateEngine;
    }
}