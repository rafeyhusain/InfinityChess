namespace App.Win
{
    partial class UpdateClient
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCurrentVersionNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pbDownloadItem = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.pbItems = new System.Windows.Forms.ProgressBar();
            this.lblTotalItems = new System.Windows.Forms.Label();
            this.lblCurrentItem = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Upgrading to:";
            // 
            // txtCurrentVersionNo
            // 
            this.txtCurrentVersionNo.Enabled = false;
            this.txtCurrentVersionNo.Location = new System.Drawing.Point(85, 14);
            this.txtCurrentVersionNo.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtCurrentVersionNo.Name = "txtCurrentVersionNo";
            this.txtCurrentVersionNo.Size = new System.Drawing.Size(219, 20);
            this.txtCurrentVersionNo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Download Item :";
            // 
            // pbDownloadItem
            // 
            this.pbDownloadItem.Location = new System.Drawing.Point(11, 60);
            this.pbDownloadItem.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.pbDownloadItem.Name = "pbDownloadItem";
            this.pbDownloadItem.Size = new System.Drawing.Size(293, 23);
            this.pbDownloadItem.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(229, 140);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(25, 3, 3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 133);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Downloading ";
            // 
            // pbItems
            // 
            this.pbItems.Location = new System.Drawing.Point(12, 100);
            this.pbItems.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.pbItems.Name = "pbItems";
            this.pbItems.Size = new System.Drawing.Size(292, 23);
            this.pbItems.TabIndex = 6;
            // 
            // lblTotalItems
            // 
            this.lblTotalItems.AutoSize = true;
            this.lblTotalItems.Location = new System.Drawing.Point(120, 133);
            this.lblTotalItems.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.lblTotalItems.Name = "lblTotalItems";
            this.lblTotalItems.Size = new System.Drawing.Size(45, 13);
            this.lblTotalItems.TabIndex = 7;
            this.lblTotalItems.Text = "[of total]";
            // 
            // lblCurrentItem
            // 
            this.lblCurrentItem.AutoSize = true;
            this.lblCurrentItem.Location = new System.Drawing.Point(105, 133);
            this.lblCurrentItem.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.lblCurrentItem.Name = "lblCurrentItem";
            this.lblCurrentItem.Size = new System.Drawing.Size(19, 13);
            this.lblCurrentItem.TabIndex = 8;
            this.lblCurrentItem.Text = "[1]";
            // 
            // UpdateClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 175);
            this.Controls.Add(this.lblCurrentItem);
            this.Controls.Add(this.lblTotalItems);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbItems);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pbDownloadItem);
            this.Controls.Add(this.txtCurrentVersionNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "UpdateClient";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Manager";
            this.Load += new System.EventHandler(this.Form_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCurrentVersionNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar pbDownloadItem;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar pbItems;
        private System.Windows.Forms.Label lblTotalItems;
        private System.Windows.Forms.Label lblCurrentItem;
    }
}