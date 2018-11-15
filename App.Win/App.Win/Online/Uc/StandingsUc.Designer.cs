namespace App.Win
{
    partial class StandingsUc
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
            this.knockOutResultsUc1 = new App.Win.KnockOutResultsUc();
            this.roundRobinResultsUc1 = new App.Win.RoundRobinResultsUc();
            this.scheveningenResultsUc1 = new App.Win.ScheveningenResultsUc();
            this.swissResultsUc1 = new App.Win.SwissResultsUc();
            this.SuspendLayout();
            // 
            // knockOutResultsUc1
            // 
            this.knockOutResultsUc1.Location = new System.Drawing.Point(2, 3);
            this.knockOutResultsUc1.Name = "knockOutResultsUc1";
            this.knockOutResultsUc1.Size = new System.Drawing.Size(650, 100);
            this.knockOutResultsUc1.TabIndex = 0;
            this.knockOutResultsUc1.Visible = false;
            // 
            // roundRobinResultsUc1
            // 
            this.roundRobinResultsUc1.Location = new System.Drawing.Point(3, 109);
            this.roundRobinResultsUc1.Name = "roundRobinResultsUc1";
            this.roundRobinResultsUc1.Size = new System.Drawing.Size(650, 100);
            this.roundRobinResultsUc1.TabIndex = 1;
            this.roundRobinResultsUc1.Visible = false;
            // 
            // scheveningenResultsUc1
            // 
            this.scheveningenResultsUc1.Location = new System.Drawing.Point(3, 215);
            this.scheveningenResultsUc1.Name = "scheveningenResultsUc1";
            this.scheveningenResultsUc1.Size = new System.Drawing.Size(650, 100);
            this.scheveningenResultsUc1.TabIndex = 2;
            this.scheveningenResultsUc1.Visible = false;
            // 
            // swissResultsUc1
            // 
            this.swissResultsUc1.Location = new System.Drawing.Point(2, 321);
            this.swissResultsUc1.Name = "swissResultsUc1";
            this.swissResultsUc1.Size = new System.Drawing.Size(650, 100);
            this.swissResultsUc1.TabIndex = 3;
            this.swissResultsUc1.Visible = false;
            // 
            // StandingsUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.swissResultsUc1);
            this.Controls.Add(this.scheveningenResultsUc1);
            this.Controls.Add(this.roundRobinResultsUc1);
            this.Controls.Add(this.knockOutResultsUc1);
            this.Name = "StandingsUc";
            this.Size = new System.Drawing.Size(653, 564);
            this.Load += new System.EventHandler(this.StandingsUc_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private KnockOutResultsUc knockOutResultsUc1;
        private RoundRobinResultsUc roundRobinResultsUc1;
        private ScheveningenResultsUc scheveningenResultsUc1;
        private SwissResultsUc swissResultsUc1;


    }
}
