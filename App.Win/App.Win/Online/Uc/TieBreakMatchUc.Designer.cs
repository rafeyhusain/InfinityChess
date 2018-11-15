namespace App.Win
{
    partial class TieBreakMatchUc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TieBreakMatchUc));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.txtColorA = new System.Windows.Forms.TextBox();
            this.cbColorA = new System.Windows.Forms.ComboBox();
            this.cbColorB = new System.Windows.Forms.ComboBox();
            this.txtColorB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSec = new System.Windows.Forms.ComboBox();
            this.cmbMin = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(387, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSave
            // 
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(51, 22);
            this.tsbSave.Text = "Save";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // txtColorA
            // 
            this.txtColorA.Enabled = false;
            this.txtColorA.Location = new System.Drawing.Point(199, 11);
            this.txtColorA.Name = "txtColorA";
            this.txtColorA.Size = new System.Drawing.Size(168, 20);
            this.txtColorA.TabIndex = 9;
            // 
            // cbColorA
            // 
            this.cbColorA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColorA.FormattingEnabled = true;
            this.cbColorA.Items.AddRange(new object[] {
            "White",
            "Black"});
            this.cbColorA.Location = new System.Drawing.Point(85, 11);
            this.cbColorA.Name = "cbColorA";
            this.cbColorA.Size = new System.Drawing.Size(108, 21);
            this.cbColorA.TabIndex = 13;
            this.cbColorA.SelectedIndexChanged += new System.EventHandler(this.cbColorA_SelectedIndexChanged);
            // 
            // cbColorB
            // 
            this.cbColorB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColorB.FormattingEnabled = true;
            this.cbColorB.Items.AddRange(new object[] {
            "White",
            "Black"});
            this.cbColorB.Location = new System.Drawing.Point(85, 36);
            this.cbColorB.Name = "cbColorB";
            this.cbColorB.Size = new System.Drawing.Size(108, 21);
            this.cbColorB.TabIndex = 14;
            this.cbColorB.SelectedIndexChanged += new System.EventHandler(this.cbColorB_SelectedIndexChanged);
            // 
            // txtColorB
            // 
            this.txtColorB.Enabled = false;
            this.txtColorB.Location = new System.Drawing.Point(199, 37);
            this.txtColorB.Name = "txtColorB";
            this.txtColorB.Size = new System.Drawing.Size(168, 20);
            this.txtColorB.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(243, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Sec";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(146, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Min";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Time Control";
            // 
            // cmbSec
            // 
            this.cmbSec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSec.FormattingEnabled = true;
            this.cmbSec.Location = new System.Drawing.Point(178, 63);
            this.cmbSec.Name = "cmbSec";
            this.cmbSec.Size = new System.Drawing.Size(62, 21);
            this.cmbSec.TabIndex = 21;
            // 
            // cmbMin
            // 
            this.cmbMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMin.FormattingEnabled = true;
            this.cmbMin.Location = new System.Drawing.Point(85, 63);
            this.cmbMin.Name = "cmbMin";
            this.cmbMin.Size = new System.Drawing.Size(55, 21);
            this.cmbMin.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtColorB);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtColorA);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbColorA);
            this.panel1.Controls.Add(this.cmbSec);
            this.panel1.Controls.Add(this.cbColorB);
            this.panel1.Controls.Add(this.cmbMin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 104);
            this.panel1.TabIndex = 25;
            // 
            // TieBreakMatchUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "TieBreakMatchUc";
            this.Size = new System.Drawing.Size(387, 129);
            this.Load += new System.EventHandler(this.TieBreakMatchUc_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TextBox txtColorA;
        private System.Windows.Forms.ComboBox cbColorA;
        private System.Windows.Forms.ComboBox cbColorB;
        private System.Windows.Forms.TextBox txtColorB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSec;
        private System.Windows.Forms.ComboBox cmbMin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton tsbSave;



    }
}
