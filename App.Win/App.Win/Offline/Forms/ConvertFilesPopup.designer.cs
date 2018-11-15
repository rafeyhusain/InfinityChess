namespace App.Win
{
    partial class ConvertFilesPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConvertFilesPopup));
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.lblInputFile = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.convertPGNToInfinityChessDatabaseicdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertPGNToInfinityChessBookicbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertInfinityChessDatabaseicdToPGNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(368, 43);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(71, 44);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(288, 20);
            this.txtFile.TabIndex = 1;
            // 
            // lblInputFile
            // 
            this.lblInputFile.AutoSize = true;
            this.lblInputFile.Location = new System.Drawing.Point(11, 48);
            this.lblInputFile.Name = "lblInputFile";
            this.lblInputFile.Size = new System.Drawing.Size(59, 13);
            this.lblInputFile.TabIndex = 2;
            this.lblInputFile.Text = "Input File : ";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(374, 86);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(299, 86);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(69, 23);
            this.btnHelp.TabIndex = 9;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(455, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertPGNToInfinityChessDatabaseicdToolStripMenuItem,
            this.convertPGNToInfinityChessBookicbToolStripMenuItem,
            this.convertInfinityChessDatabaseicdToPGNToolStripMenuItem});
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(59, 22);
            this.toolStripButton1.Text = "Convert";
            // 
            // convertPGNToInfinityChessDatabaseicdToolStripMenuItem
            // 
            this.convertPGNToInfinityChessDatabaseicdToolStripMenuItem.Name = "convertPGNToInfinityChessDatabaseicdToolStripMenuItem";
            this.convertPGNToInfinityChessDatabaseicdToolStripMenuItem.Size = new System.Drawing.Size(292, 22);
            this.convertPGNToInfinityChessDatabaseicdToolStripMenuItem.Text = "Convert PGN to InfinityChess Database (.icd)";
            this.convertPGNToInfinityChessDatabaseicdToolStripMenuItem.Click += new System.EventHandler(this.convertPGNToInfinityChessDatabaseicdToolStripMenuItem_Click);
            // 
            // convertPGNToInfinityChessBookicbToolStripMenuItem
            // 
            this.convertPGNToInfinityChessBookicbToolStripMenuItem.Name = "convertPGNToInfinityChessBookicbToolStripMenuItem";
            this.convertPGNToInfinityChessBookicbToolStripMenuItem.Size = new System.Drawing.Size(292, 22);
            this.convertPGNToInfinityChessBookicbToolStripMenuItem.Text = "Convert PGN to InfinityChess Book (.icb)";
            this.convertPGNToInfinityChessBookicbToolStripMenuItem.Click += new System.EventHandler(this.convertPGNToInfinityChessBookicbToolStripMenuItem_Click);
            // 
            // convertInfinityChessDatabaseicdToPGNToolStripMenuItem
            // 
            this.convertInfinityChessDatabaseicdToPGNToolStripMenuItem.Name = "convertInfinityChessDatabaseicdToPGNToolStripMenuItem";
            this.convertInfinityChessDatabaseicdToPGNToolStripMenuItem.Size = new System.Drawing.Size(292, 22);
            this.convertInfinityChessDatabaseicdToPGNToolStripMenuItem.Text = "Convert InfinityChess Database (.icd) to PGN";
            this.convertInfinityChessDatabaseicdToPGNToolStripMenuItem.Click += new System.EventHandler(this.convertInfinityChessDatabaseicdToPGNToolStripMenuItem_Click);
            // 
            // ConvertFilesPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(455, 142);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblInputFile);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnBrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConvertFilesPopup";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Convert";
            this.Load += new System.EventHandler(this.ConvertFilesPopup_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label lblInputFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem convertPGNToInfinityChessDatabaseicdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertPGNToInfinityChessBookicbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertInfinityChessDatabaseicdToPGNToolStripMenuItem;


    }
}