namespace App.Win
{
    partial class NewsDetailUc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewsDetailUc));
            this.txtNewsName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNewsType = new System.Windows.Forms.ComboBox();
            this.editor1 = new Design.Editor();
            this.SuspendLayout();
            // 
            // txtNewsName
            // 
            this.txtNewsName.Location = new System.Drawing.Point(85, 19);
            this.txtNewsName.Name = "txtNewsName";
            this.txtNewsName.Size = new System.Drawing.Size(398, 20);
            this.txtNewsName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "News Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "News Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Description:";
            // 
            // cmbNewsType
            // 
            this.cmbNewsType.FormattingEnabled = true;
            this.cmbNewsType.Location = new System.Drawing.Point(85, 46);
            this.cmbNewsType.Name = "cmbNewsType";
            this.cmbNewsType.Size = new System.Drawing.Size(160, 21);
            this.cmbNewsType.TabIndex = 6;
            // 
            // editor1
            // 
            this.editor1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.editor1.BodyHtml = null;
            this.editor1.BodyText = null;
            this.editor1.DocumentText = resources.GetString("editor1.DocumentText");
            this.editor1.EditorBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.editor1.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.editor1.FontName = null;
            this.editor1.FontSize = Design.FontSize.NA;
            this.editor1.HtmlText = null;
            this.editor1.Location = new System.Drawing.Point(85, 74);
            this.editor1.Name = "editor1";
            this.editor1.Size = new System.Drawing.Size(636, 297);
            this.editor1.TabIndex = 7;
            // 
            // NewsDetailUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.editor1);
            this.Controls.Add(this.cmbNewsType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNewsName);
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Name = "NewsDetailUc";
            this.Size = new System.Drawing.Size(729, 384);
            this.Load += new System.EventHandler(this.NewsDetailUc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNewsName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbNewsType;
        private Design.Editor editor1;
    }
}
