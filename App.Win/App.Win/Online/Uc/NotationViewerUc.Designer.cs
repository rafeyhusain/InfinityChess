namespace InfinityChess
{
    partial class NotationViewerUc
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
            this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
            this.notationTextView1 = new App.Model.Model.Ui.Win.Common.Controls.Notation.NotationTextView();
            this.SuspendLayout();
            // 
            // elementHost2
            // 
            this.elementHost2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost2.Location = new System.Drawing.Point(0, 0);
            this.elementHost2.Name = "elementHost2";
            this.elementHost2.Size = new System.Drawing.Size(515, 344);
            this.elementHost2.TabIndex = 4;
            this.elementHost2.Text = "elementHost2";
            this.elementHost2.Child = this.notationTextView1;
            // 
            // NotationViewerUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.elementHost2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "NotationViewerUc";
            this.Size = new System.Drawing.Size(515, 344);
            this.Load += new System.EventHandler(this.NotationUc_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private App.Model.Model.Ui.Win.Common.Controls.Notation.NotationTextView notationTextView1;

    }
}
