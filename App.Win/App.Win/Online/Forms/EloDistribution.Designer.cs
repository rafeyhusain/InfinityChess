namespace App.Win
{
    partial class EloDistribution
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
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageBullet = new System.Windows.Forms.TabPage();
            this.eloDistributionUc1 = new App.Win.EloDistributionUc();
            this.tabPageBlitz = new System.Windows.Forms.TabPage();
            this.tabPageSlow = new System.Windows.Forms.TabPage();
            this.tabPageComputer = new System.Windows.Forms.TabPage();
            this.tabPageCentaur = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPageBullet.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(514, 3);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 22);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(433, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(352, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 22);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageBullet);
            this.tabControl1.Controls.Add(this.tabPageBlitz);
            this.tabControl1.Controls.Add(this.tabPageSlow);
            this.tabControl1.Controls.Add(this.tabPageComputer);
            this.tabControl1.Controls.Add(this.tabPageCentaur);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(592, 353);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageBullet
            // 
            this.tabPageBullet.Controls.Add(this.eloDistributionUc1);
            this.tabPageBullet.Location = new System.Drawing.Point(4, 22);
            this.tabPageBullet.Name = "tabPageBullet";
            this.tabPageBullet.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBullet.Size = new System.Drawing.Size(584, 327);
            this.tabPageBullet.TabIndex = 0;
            this.tabPageBullet.Text = "Bullet";
            this.tabPageBullet.UseVisualStyleBackColor = true;
            // 
            // eloDistributionUc1
            // 
            this.eloDistributionUc1.Dock = System.Windows.Forms.DockStyle.Top;
            this.eloDistributionUc1.Location = new System.Drawing.Point(3, 3);
            this.eloDistributionUc1.Name = "eloDistributionUc1";
            this.eloDistributionUc1.Size = new System.Drawing.Size(578, 325);
            this.eloDistributionUc1.TabIndex = 0;
            // 
            // tabPageBlitz
            // 
            this.tabPageBlitz.Location = new System.Drawing.Point(4, 22);
            this.tabPageBlitz.Name = "tabPageBlitz";
            this.tabPageBlitz.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBlitz.Size = new System.Drawing.Size(584, 327);
            this.tabPageBlitz.TabIndex = 1;
            this.tabPageBlitz.Text = "Blitz";
            this.tabPageBlitz.UseVisualStyleBackColor = true;
            // 
            // tabPageSlow
            // 
            this.tabPageSlow.Location = new System.Drawing.Point(4, 22);
            this.tabPageSlow.Name = "tabPageSlow";
            this.tabPageSlow.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSlow.Size = new System.Drawing.Size(584, 327);
            this.tabPageSlow.TabIndex = 2;
            this.tabPageSlow.Text = "Slow";
            this.tabPageSlow.UseVisualStyleBackColor = true;
            // 
            // tabPageComputer
            // 
            this.tabPageComputer.Location = new System.Drawing.Point(4, 22);
            this.tabPageComputer.Name = "tabPageComputer";
            this.tabPageComputer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageComputer.Size = new System.Drawing.Size(584, 327);
            this.tabPageComputer.TabIndex = 3;
            this.tabPageComputer.Text = "Computer";
            this.tabPageComputer.UseVisualStyleBackColor = true;
            // 
            // tabPageCentaur
            // 
            this.tabPageCentaur.Location = new System.Drawing.Point(4, 22);
            this.tabPageCentaur.Name = "tabPageCentaur";
            this.tabPageCentaur.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCentaur.Size = new System.Drawing.Size(584, 327);
            this.tabPageCentaur.TabIndex = 4;
            this.tabPageCentaur.Text = "Centaur";
            this.tabPageCentaur.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 353);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 30);
            this.panel1.TabIndex = 0;
            // 
            // EloDistribution
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(592, 383);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EloDistribution";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elo Distribution";
            this.Load += new System.EventHandler(this.EloDistribution_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageBullet.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageBullet;
        private System.Windows.Forms.TabPage tabPageBlitz;
        private System.Windows.Forms.TabPage tabPageSlow;
        private System.Windows.Forms.TabPage tabPageComputer;
        private System.Windows.Forms.TabPage tabPageCentaur;
        private EloDistributionUc eloDistributionUc1;
        private System.Windows.Forms.Panel panel1;
    }
}