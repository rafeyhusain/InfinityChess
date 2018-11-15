namespace App.Win
{
    partial class AudienceUc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AudienceUc));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RankImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nation = new System.Windows.Forms.DataGridViewImageColumn();
            this.CountryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FideTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IccfTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BulletElo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BlitzElo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RapidElo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LongElo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Engine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Social = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserID,
            this.RankImage,
            this.UserName,
            this.CountryID,
            this.Nation,
            this.CountryName,
            this.FideTitle,
            this.IccfTitle,
            this.BulletElo,
            this.BlitzElo,
            this.RapidElo,
            this.LongElo,
            this.Status,
            this.Engine,
            this.Rank,
            this.Social,
            this.Empty});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1218, 200);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // UserID
            // 
            this.UserID.DataPropertyName = "UserID";
            this.UserID.HeaderText = "UserID";
            this.UserID.Name = "UserID";
            this.UserID.ReadOnly = true;
            this.UserID.Visible = false;
            this.UserID.Width = 46;
            // 
            // RankImage
            // 
            this.RankImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle2.NullValue")));
            this.RankImage.DefaultCellStyle = dataGridViewCellStyle2;
            this.RankImage.HeaderText = "";
            this.RankImage.Name = "RankImage";
            this.RankImage.ReadOnly = true;
            this.RankImage.Width = 5;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "Name";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // CountryID
            // 
            this.CountryID.DataPropertyName = "CountryID";
            this.CountryID.HeaderText = "CountryID";
            this.CountryID.Name = "CountryID";
            this.CountryID.ReadOnly = true;
            this.CountryID.Visible = false;
            // 
            // Nation
            // 
            dataGridViewCellStyle3.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle3.NullValue")));
            this.Nation.DefaultCellStyle = dataGridViewCellStyle3;
            this.Nation.HeaderText = "Nation";
            this.Nation.Name = "Nation";
            this.Nation.ReadOnly = true;
            this.Nation.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Nation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Nation.Width = 45;
            // 
            // CountryName
            // 
            this.CountryName.DataPropertyName = "CountryName";
            this.CountryName.HeaderText = "CountryName";
            this.CountryName.Name = "CountryName";
            this.CountryName.ReadOnly = true;
            this.CountryName.Visible = false;
            // 
            // FideTitle
            // 
            this.FideTitle.DataPropertyName = "FideTitle";
            this.FideTitle.HeaderText = "FIDE";
            this.FideTitle.Name = "FideTitle";
            this.FideTitle.ReadOnly = true;
            this.FideTitle.Width = 40;
            // 
            // IccfTitle
            // 
            this.IccfTitle.DataPropertyName = "IccfTitle";
            this.IccfTitle.HeaderText = "ICCF";
            this.IccfTitle.Name = "IccfTitle";
            this.IccfTitle.ReadOnly = true;
            this.IccfTitle.Width = 40;
            // 
            // BulletElo
            // 
            this.BulletElo.DataPropertyName = "BulletElo";
            this.BulletElo.HeaderText = "Bullet";
            this.BulletElo.Name = "BulletElo";
            this.BulletElo.ReadOnly = true;
            this.BulletElo.Width = 40;
            // 
            // BlitzElo
            // 
            this.BlitzElo.DataPropertyName = "BlitzElo";
            this.BlitzElo.HeaderText = "Blitz";
            this.BlitzElo.Name = "BlitzElo";
            this.BlitzElo.ReadOnly = true;
            this.BlitzElo.Width = 40;
            // 
            // RapidElo
            // 
            this.RapidElo.DataPropertyName = "RapidElo";
            this.RapidElo.HeaderText = "Rapid";
            this.RapidElo.Name = "RapidElo";
            this.RapidElo.ReadOnly = true;
            this.RapidElo.Width = 40;
            // 
            // LongElo
            // 
            this.LongElo.DataPropertyName = "LongElo";
            this.LongElo.HeaderText = "Long";
            this.LongElo.Name = "LongElo";
            this.LongElo.ReadOnly = true;
            this.LongElo.Width = 40;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 60;
            // 
            // Engine
            // 
            this.Engine.DataPropertyName = "Engine";
            this.Engine.HeaderText = "Engine";
            this.Engine.Name = "Engine";
            this.Engine.ReadOnly = true;
            this.Engine.Width = 75;
            // 
            // Rank
            // 
            this.Rank.DataPropertyName = "Rank";
            this.Rank.HeaderText = "Rank";
            this.Rank.Name = "Rank";
            this.Rank.ReadOnly = true;
            this.Rank.Visible = false;
            // 
            // Social
            // 
            this.Social.DataPropertyName = "Social";
            this.Social.HeaderText = "Social";
            this.Social.Name = "Social";
            this.Social.ReadOnly = true;
            this.Social.Visible = false;
            // 
            // Empty
            // 
            this.Empty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Empty.HeaderText = "";
            this.Empty.Name = "Empty";
            this.Empty.ReadOnly = true;
            // 
            // AudienceUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Name = "AudienceUc";
            this.Size = new System.Drawing.Size(1218, 200);
            this.Load += new System.EventHandler(this.AudienceUc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewImageColumn RankImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountryID;
        private System.Windows.Forms.DataGridViewImageColumn Nation;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FideTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn IccfTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn BulletElo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BlitzElo;
        private System.Windows.Forms.DataGridViewTextBoxColumn RapidElo;
        private System.Windows.Forms.DataGridViewTextBoxColumn LongElo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Engine;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rank;
        private System.Windows.Forms.DataGridViewTextBoxColumn Social;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empty;
    }
}
