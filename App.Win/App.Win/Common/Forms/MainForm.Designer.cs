namespace InfinityChess.WinForms
{
    partial class MainForm
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.e2EResultUc1 = new E2EResultUc();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // e2EResultUc1
            // 
            this.e2EResultUc1.Dock = System.Windows.Forms.DockStyle.Top;
            this.e2EResultUc1.Location = new System.Drawing.Point(0, 0);
            this.e2EResultUc1.Name = "e2EResultUc1";
            this.e2EResultUc1.Size = new System.Drawing.Size(195, 166);
            this.e2EResultUc1.TabIndex = 2;
            this.e2EResultUc1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(195, 166);
            this.panel1.TabIndex = 1;            
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(195, 166);
            this.Controls.Add(this.e2EResultUc1);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(600, 150);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.ResumeLayout(false);

        }        

        #endregion

        protected System.Windows.Forms.Timer timer1;
        public InfinityChess.E2EResultUc e2EResultUc1;
        public System.Windows.Forms.Panel panel1;
    }
}