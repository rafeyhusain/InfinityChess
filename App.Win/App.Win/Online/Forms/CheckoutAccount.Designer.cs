namespace App.Win
{
    partial class CheckoutAccount
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
            this.checkoutAccountUc1 = new App.Win.CheckoutAccountUc();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkoutAccountUc1
            // 
            this.checkoutAccountUc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkoutAccountUc1.Location = new System.Drawing.Point(0, 0);
            this.checkoutAccountUc1.Name = "checkoutAccountUc1";
            this.checkoutAccountUc1.Size = new System.Drawing.Size(391, 185);
            this.checkoutAccountUc1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(264, 150);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // CheckoutAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(391, 185);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.checkoutAccountUc1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckoutAccount";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check out payment";
            this.ResumeLayout(false);

        }

        #endregion

        private CheckoutAccountUc checkoutAccountUc1;
        private System.Windows.Forms.Button btnCancel;






    }
}