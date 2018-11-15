namespace InfinityChess
{
    partial class EngineManagement
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
            this.lstActivateEngine = new System.Windows.Forms.ListBox();
            this.lstDeActivateEngine = new System.Windows.Forms.ListBox();
            this.btnDeActive = new System.Windows.Forms.Button();
            this.btnActive = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstActivateEngine
            // 
            this.lstActivateEngine.FormattingEnabled = true;
            this.lstActivateEngine.Location = new System.Drawing.Point(13, 38);
            this.lstActivateEngine.Name = "lstActivateEngine";
            this.lstActivateEngine.Size = new System.Drawing.Size(175, 225);
            this.lstActivateEngine.TabIndex = 3;
            this.lstActivateEngine.TabStop = false;
            // 
            // lstDeActivateEngine
            // 
            this.lstDeActivateEngine.FormattingEnabled = true;
            this.lstDeActivateEngine.Location = new System.Drawing.Point(226, 38);
            this.lstDeActivateEngine.Name = "lstDeActivateEngine";
            this.lstDeActivateEngine.Size = new System.Drawing.Size(175, 225);
            this.lstDeActivateEngine.TabIndex = 0;
            this.lstDeActivateEngine.TabStop = false;
            // 
            // btnDeActive
            // 
            this.btnDeActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeActive.Location = new System.Drawing.Point(194, 111);
            this.btnDeActive.Name = "btnDeActive";
            this.btnDeActive.Size = new System.Drawing.Size(25, 22);
            this.btnDeActive.TabIndex = 0;
            this.btnDeActive.Text = ">";
            this.btnDeActive.UseVisualStyleBackColor = true;
            this.btnDeActive.Click += new System.EventHandler(this.btnDeActive_Click);
            // 
            // btnActive
            // 
            this.btnActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActive.Location = new System.Drawing.Point(194, 146);
            this.btnActive.Name = "btnActive";
            this.btnActive.Size = new System.Drawing.Size(25, 22);
            this.btnActive.TabIndex = 1;
            this.btnActive.Text = "<<";
            this.btnActive.UseVisualStyleBackColor = true;
            this.btnActive.Click += new System.EventHandler(this.btnActive_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(245, 269);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 22);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(326, 269);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(175, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "Active Engines";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(226, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(175, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "Inactive Engines";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EngineManagement
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(414, 302);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnActive);
            this.Controls.Add(this.btnDeActive);
            this.Controls.Add(this.lstDeActivateEngine);
            this.Controls.Add(this.lstActivateEngine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EngineManagement";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Engine Management";
            this.Load += new System.EventHandler(this.EngineManagement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstActivateEngine;
        private System.Windows.Forms.ListBox lstDeActivateEngine;
        private System.Windows.Forms.Button btnDeActive;
        private System.Windows.Forms.Button btnActive;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}