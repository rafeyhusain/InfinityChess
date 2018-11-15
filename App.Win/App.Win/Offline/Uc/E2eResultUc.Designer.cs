namespace InfinityChess
{
    partial class E2EResultUc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(E2EResultUc));
            this.editor1 = new Design.Editor();
            this.SuspendLayout();
            // 
            // editor1
            // 
            this.editor1.BackColor = System.Drawing.Color.White;
            this.editor1.BodyHtml = null;
            this.editor1.BodyText = null;
            this.editor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor1.DocumentText = resources.GetString("editor1.DocumentText");
            this.editor1.EditorBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.editor1.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.editor1.FontName = null;
            this.editor1.FontSize = Design.FontSize.NA;
            this.editor1.Location = new System.Drawing.Point(0, 0);
            this.editor1.Name = "editor1";
            this.editor1.Size = new System.Drawing.Size(576, 179);
            this.editor1.TabIndex = 4;
            // 
            // E2EResultUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.editor1);
            this.Name = "E2EResultUc";
            this.Size = new System.Drawing.Size(576, 179);
            this.Load += new System.EventHandler(this.E2EResultUc_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Design.Editor editor1;


    }
}
