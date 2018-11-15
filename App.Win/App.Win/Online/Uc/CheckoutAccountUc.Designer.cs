namespace App.Win
{
    partial class CheckoutAccountUc
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCreditPayment = new System.Windows.Forms.Label();
            this.lblcp = new System.Windows.Forms.Label();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.lblExpDate = new System.Windows.Forms.Label();
            this.lblExpDate2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSubmitKey = new System.Windows.Forms.Button();
            this.txtVoucherNo = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCreditPayment
            // 
            this.lblCreditPayment.Location = new System.Drawing.Point(8, 42);
            this.lblCreditPayment.Name = "lblCreditPayment";
            this.lblCreditPayment.Size = new System.Drawing.Size(100, 16);
            this.lblCreditPayment.TabIndex = 0;
            this.lblCreditPayment.Text = "Credit for payment";
            // 
            // lblcp
            // 
            this.lblcp.Location = new System.Drawing.Point(107, 42);
            this.lblcp.Name = "lblcp";
            this.lblcp.Size = new System.Drawing.Size(100, 16);
            this.lblcp.TabIndex = 1;
            // 
            // lblCurrency
            // 
            this.lblCurrency.Location = new System.Drawing.Point(237, 42);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(33, 16);
            this.lblCurrency.TabIndex = 2;
            this.lblCurrency.Text = "Fini";
            // 
            // lblExpDate
            // 
            this.lblExpDate.Location = new System.Drawing.Point(8, 72);
            this.lblExpDate.Name = "lblExpDate";
            this.lblExpDate.Size = new System.Drawing.Size(100, 16);
            this.lblExpDate.TabIndex = 3;
            this.lblExpDate.Text = "Expiry Date";
            // 
            // lblExpDate2
            // 
            this.lblExpDate2.Location = new System.Drawing.Point(107, 72);
            this.lblExpDate2.Name = "lblExpDate2";
            this.lblExpDate2.Size = new System.Drawing.Size(145, 16);
            this.lblExpDate2.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSubmitKey);
            this.groupBox1.Controls.Add(this.txtVoucherNo);
            this.groupBox1.Location = new System.Drawing.Point(2, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 84);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter your fini voucher";
            // 
            // btnSubmitKey
            // 
            this.btnSubmitKey.Location = new System.Drawing.Point(117, 52);
            this.btnSubmitKey.Name = "btnSubmitKey";
            this.btnSubmitKey.Size = new System.Drawing.Size(141, 23);
            this.btnSubmitKey.TabIndex = 1;
            this.btnSubmitKey.Text = "Submit Voucher Number";
            this.btnSubmitKey.UseVisualStyleBackColor = true;
            this.btnSubmitKey.Click += new System.EventHandler(this.btnSubmitKey_Click);
            // 
            // txtVoucherNo
            // 
            this.txtVoucherNo.Location = new System.Drawing.Point(7, 24);
            this.txtVoucherNo.Name = "txtVoucherNo";
            this.txtVoucherNo.Size = new System.Drawing.Size(367, 20);
            this.txtVoucherNo.TabIndex = 0;
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(14, 6);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(366, 25);
            this.lblMessage.TabIndex = 7;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CheckoutAccountUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblExpDate2);
            this.Controls.Add(this.lblExpDate);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.lblcp);
            this.Controls.Add(this.lblCreditPayment);
            this.Name = "CheckoutAccountUc";
            this.Size = new System.Drawing.Size(390, 185);
            this.Load += new System.EventHandler(this.CheckoutAccountUc_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCreditPayment;
        private System.Windows.Forms.Label lblcp;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.Label lblExpDate;
        private System.Windows.Forms.Label lblExpDate2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtVoucherNo;
        private System.Windows.Forms.Button btnSubmitKey;
        private System.Windows.Forms.Label lblMessage;



    }
}
