namespace InfinityChess.WinForms
{
    partial class DevForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DevForm));
            this.devUc1 = new App.Model.DevUc();
            this.SuspendLayout();
            // 
            // devUc1
            // 
            this.devUc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.devUc1.Location = new System.Drawing.Point(0, 0);
            this.devUc1.Name = "devUc1";
            this.devUc1.Size = new System.Drawing.Size(678, 405);
            this.devUc1.TabIndex = 0;
            // 
            // DevForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 405);
            this.Controls.Add(this.devUc1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DevForm";
            this.Text = "DevForm";
            this.Load += new System.EventHandler(this.DevForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private App.Model.DevUc devUc1;


    }
}