namespace InfinityChess.WinForms
{
    partial class frmGotoLineNumber
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblGotoLine = new System.Windows.Forms.Label();
            this.domainUpDown = new System.Windows.Forms.DomainUpDown();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(115, 51);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(18, 51);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblGotoLine
            // 
            this.lblGotoLine.AutoSize = true;
            this.lblGotoLine.Location = new System.Drawing.Point(15, 18);
            this.lblGotoLine.Name = "lblGotoLine";
            this.lblGotoLine.Size = new System.Drawing.Size(49, 13);
            this.lblGotoLine.TabIndex = 6;
            this.lblGotoLine.Text = "Goto line";
            // 
            // domainUpDown
            // 
            this.domainUpDown.Location = new System.Drawing.Point(82, 14);
            this.domainUpDown.Name = "domainUpDown";
            this.domainUpDown.Size = new System.Drawing.Size(120, 20);
            this.domainUpDown.TabIndex = 10;
            this.domainUpDown.Text = "Enter Line Number";
            // 
            // frmGotoLineNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 88);
            this.Controls.Add(this.domainUpDown);
            this.Controls.Add(this.lblGotoLine);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGotoLineNumber";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enter Number";
            this.Load += new System.EventHandler(this.frmGotoLine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblGotoLine;
        private System.Windows.Forms.DomainUpDown domainUpDown;
    }
}