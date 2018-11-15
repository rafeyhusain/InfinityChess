namespace App.Win
{
    partial class ChangeWeightPopup
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
            this.lblChangeWeight = new System.Windows.Forms.Label();
            this.numMoveWeight = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // lblChangeWeight
            // 
            this.lblChangeWeight.AutoSize = true;
            this.lblChangeWeight.Location = new System.Drawing.Point(19, 18);
            this.lblChangeWeight.Name = "lblChangeWeight";
            this.lblChangeWeight.Size = new System.Drawing.Size(78, 13);
            this.lblChangeWeight.TabIndex = 0;
            this.lblChangeWeight.Text = "Change weight";
            // 
            // numMoveWeight
            // 
            this.numMoveWeight.Location = new System.Drawing.Point(117, 16);
            this.numMoveWeight.Maximum = new decimal(new int[] {
            125,
            0,
            0,
            0});
            this.numMoveWeight.Minimum = new decimal(new int[] {
            125,
            0,
            0,
            -2147483648});
            this.numMoveWeight.Name = "numMoveWeight";
            this.numMoveWeight.Size = new System.Drawing.Size(92, 20);
            this.numMoveWeight.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(53, 64);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 22);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(134, 64);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ChangeWeightPopup
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(228, 103);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.numMoveWeight);
            this.Controls.Add(this.lblChangeWeight);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeWeightPopup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter Number";
            this.Load += new System.EventHandler(this.ChangeWeightPopup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numMoveWeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChangeWeight;
        private System.Windows.Forms.NumericUpDown numMoveWeight;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}