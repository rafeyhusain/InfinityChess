namespace InfinityChess.Online.Uc
{
    partial class UserTopRatingUc
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
            this.gvUserRating = new System.Windows.Forms.DataGridView();
            this.RowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EloRating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbTopRating = new System.Windows.Forms.GroupBox();
            this.lbGameType = new System.Windows.Forms.ListBox();
            this.btnPicture = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvUserRating)).BeginInit();
            this.gbTopRating.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvUserRating
            // 
            this.gvUserRating.AllowUserToAddRows = false;
            this.gvUserRating.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvUserRating.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvUserRating.ColumnHeadersVisible = false;
            this.gvUserRating.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowNumber,
            this.UserID,
            this.UserName,
            this.EloRating});
            this.gvUserRating.Location = new System.Drawing.Point(183, 24);
            this.gvUserRating.MultiSelect = false;
            this.gvUserRating.Name = "gvUserRating";
            this.gvUserRating.ReadOnly = true;
            this.gvUserRating.RowHeadersVisible = false;
            this.gvUserRating.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvUserRating.Size = new System.Drawing.Size(467, 334);
            this.gvUserRating.TabIndex = 0;
            this.gvUserRating.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvUserRating_CellDoubleClick);
            this.gvUserRating.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvUserRating_CellClick);
            // 
            // RowNumber
            // 
            this.RowNumber.DataPropertyName = "RowNumber";
            this.RowNumber.FillWeight = 129.9492F;
            this.RowNumber.HeaderText = "";
            this.RowNumber.Name = "RowNumber";
            this.RowNumber.ReadOnly = true;
            // 
            // UserID
            // 
            this.UserID.DataPropertyName = "UserID";
            this.UserID.FillWeight = 10.15228F;
            this.UserID.HeaderText = "";
            this.UserID.Name = "UserID";
            this.UserID.ReadOnly = true;
            this.UserID.Visible = false;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.FillWeight = 129.9492F;
            this.UserName.HeaderText = "";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // EloRating
            // 
            this.EloRating.DataPropertyName = "EloRating";
            this.EloRating.FillWeight = 129.9492F;
            this.EloRating.HeaderText = "";
            this.EloRating.Name = "EloRating";
            this.EloRating.ReadOnly = true;
            // 
            // gbTopRating
            // 
            this.gbTopRating.Controls.Add(this.lbGameType);
            this.gbTopRating.Controls.Add(this.btnPicture);
            this.gbTopRating.Controls.Add(this.gvUserRating);
            this.gbTopRating.Location = new System.Drawing.Point(3, 6);
            this.gbTopRating.Name = "gbTopRating";
            this.gbTopRating.Size = new System.Drawing.Size(664, 395);
            this.gbTopRating.TabIndex = 1;
            this.gbTopRating.TabStop = false;
            this.gbTopRating.Text = "Top 100";
            // 
            // lbGameType
            // 
            this.lbGameType.FormattingEnabled = true;
            this.lbGameType.Items.AddRange(new object[] {
            "Top List Bullet",
            "Top List Biltz",
            "Top List Rapid",
            "Top List Long"});
            this.lbGameType.Location = new System.Drawing.Point(11, 24);
            this.lbGameType.Name = "lbGameType";
            this.lbGameType.Size = new System.Drawing.Size(166, 329);
            this.lbGameType.TabIndex = 4;
            this.lbGameType.Click += new System.EventHandler(this.lbGameType_Click);
            // 
            // btnPicture
            // 
            this.btnPicture.Location = new System.Drawing.Point(547, 364);
            this.btnPicture.Name = "btnPicture";
            this.btnPicture.Size = new System.Drawing.Size(103, 23);
            this.btnPicture.TabIndex = 2;
            this.btnPicture.Text = "Picture";
            this.btnPicture.UseVisualStyleBackColor = true;
            this.btnPicture.Click += new System.EventHandler(this.btnPicture_Click);
            // 
            // UserTopRatingUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbTopRating);
            this.Name = "UserTopRatingUc";
            this.Size = new System.Drawing.Size(678, 419);
            this.Load += new System.EventHandler(this.UserTopRatingUc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvUserRating)).EndInit();
            this.gbTopRating.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTopRating;
        private System.Windows.Forms.Button btnPicture;
        private System.Windows.Forms.ListBox lbGameType;
        private System.Windows.Forms.DataGridView gvUserRating;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EloRating;
    }
}
