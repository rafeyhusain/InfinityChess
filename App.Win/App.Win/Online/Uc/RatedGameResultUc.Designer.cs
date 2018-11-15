namespace App.Win
{
    partial class RatedGameResultUc
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRanking = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNOpponents = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblOpponentElo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblLosses = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDraws = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblWhite = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblWins = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblStoredGame = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTotalGames = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ChallengeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WhiteUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BlackUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WhiteUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BlackUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Opponent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EloWhite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EloBlack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Elo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChallengeStatusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Side = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WhiteUserCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BlackUserCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChallengeImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.GameResultID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblRanking);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblRating);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblNOpponents);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblResult);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblOpponentElo);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lblLosses);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblDraws);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lblWhite);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.lblWins);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.lblStoredGame);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.lblTotalGames);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 300);
            this.panel1.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Games";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(127, 272);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(10, 13);
            this.lblDate.TabIndex = 23;
            this.lblDate.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Stored Results";
            // 
            // lblRanking
            // 
            this.lblRanking.AutoSize = true;
            this.lblRanking.Location = new System.Drawing.Point(127, 246);
            this.lblRanking.Name = "lblRanking";
            this.lblRanking.Size = new System.Drawing.Size(10, 13);
            this.lblRanking.TabIndex = 22;
            this.lblRanking.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "White";
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRating.Location = new System.Drawing.Point(127, 219);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(17, 17);
            this.lblRating.TabIndex = 21;
            this.lblRating.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Wins";
            // 
            // lblNOpponents
            // 
            this.lblNOpponents.AutoSize = true;
            this.lblNOpponents.Location = new System.Drawing.Point(127, 197);
            this.lblNOpponents.Name = "lblNOpponents";
            this.lblNOpponents.Size = new System.Drawing.Size(13, 13);
            this.lblNOpponents.TabIndex = 20;
            this.lblNOpponents.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Draws";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(127, 153);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(10, 13);
            this.lblResult.TabIndex = 19;
            this.lblResult.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Losses";
            // 
            // lblOpponentElo
            // 
            this.lblOpponentElo.AutoSize = true;
            this.lblOpponentElo.Location = new System.Drawing.Point(127, 175);
            this.lblOpponentElo.Name = "lblOpponentElo";
            this.lblOpponentElo.Size = new System.Drawing.Size(10, 13);
            this.lblOpponentElo.TabIndex = 18;
            this.lblOpponentElo.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Result";
            // 
            // lblLosses
            // 
            this.lblLosses.AutoSize = true;
            this.lblLosses.Location = new System.Drawing.Point(127, 131);
            this.lblLosses.Name = "lblLosses";
            this.lblLosses.Size = new System.Drawing.Size(13, 13);
            this.lblLosses.TabIndex = 17;
            this.lblLosses.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Opponent Elo";
            // 
            // lblDraws
            // 
            this.lblDraws.AutoSize = true;
            this.lblDraws.Location = new System.Drawing.Point(127, 109);
            this.lblDraws.Name = "lblDraws";
            this.lblDraws.Size = new System.Drawing.Size(13, 13);
            this.lblDraws.TabIndex = 16;
            this.lblDraws.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 197);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "N Opponents";
            // 
            // lblWhite
            // 
            this.lblWhite.AutoSize = true;
            this.lblWhite.Location = new System.Drawing.Point(127, 64);
            this.lblWhite.Name = "lblWhite";
            this.lblWhite.Size = new System.Drawing.Size(13, 13);
            this.lblWhite.TabIndex = 15;
            this.lblWhite.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 219);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 17);
            this.label10.TabIndex = 9;
            this.label10.Text = "Rating";
            // 
            // lblWins
            // 
            this.lblWins.AutoSize = true;
            this.lblWins.Location = new System.Drawing.Point(127, 86);
            this.lblWins.Name = "lblWins";
            this.lblWins.Size = new System.Drawing.Size(13, 13);
            this.lblWins.TabIndex = 14;
            this.lblWins.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 246);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Ranking";
            // 
            // lblStoredGame
            // 
            this.lblStoredGame.AutoSize = true;
            this.lblStoredGame.Location = new System.Drawing.Point(127, 40);
            this.lblStoredGame.Name = "lblStoredGame";
            this.lblStoredGame.Size = new System.Drawing.Size(13, 13);
            this.lblStoredGame.TabIndex = 13;
            this.lblStoredGame.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 272);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Date";
            // 
            // lblTotalGames
            // 
            this.lblTotalGames.AutoSize = true;
            this.lblTotalGames.Location = new System.Drawing.Point(127, 9);
            this.lblTotalGames.Name = "lblTotalGames";
            this.lblTotalGames.Size = new System.Drawing.Size(13, 13);
            this.lblTotalGames.TabIndex = 12;
            this.lblTotalGames.Text = "0";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 300);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(700, 50);
            this.panel2.TabIndex = 28;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChallengeID,
            this.WhiteUserID,
            this.BlackUserID,
            this.WhiteUserName,
            this.BlackUserName,
            this.Opponent,
            this.EloWhite,
            this.EloBlack,
            this.Elo,
            this.ChallengeStatusID,
            this.Side,
            this.WhiteUserCountry,
            this.BlackUserCountry,
            this.ChallengeImage,
            this.GameResultID,
            this.Empty});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(212, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(488, 300);
            this.dataGridView1.TabIndex = 30;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // ChallengeID
            // 
            this.ChallengeID.DataPropertyName = "GameID";
            this.ChallengeID.HeaderText = "GameID";
            this.ChallengeID.Name = "ChallengeID";
            this.ChallengeID.ReadOnly = true;
            this.ChallengeID.Visible = false;
            // 
            // WhiteUserID
            // 
            this.WhiteUserID.DataPropertyName = "WhiteUserID";
            this.WhiteUserID.HeaderText = "WhiteUserID";
            this.WhiteUserID.Name = "WhiteUserID";
            this.WhiteUserID.ReadOnly = true;
            this.WhiteUserID.Visible = false;
            // 
            // BlackUserID
            // 
            this.BlackUserID.DataPropertyName = "BlackUserID";
            this.BlackUserID.HeaderText = "BlackUserID";
            this.BlackUserID.Name = "BlackUserID";
            this.BlackUserID.ReadOnly = true;
            this.BlackUserID.Visible = false;
            // 
            // WhiteUserName
            // 
            this.WhiteUserName.DataPropertyName = "WhiteUserName";
            this.WhiteUserName.HeaderText = "WhiteUserName";
            this.WhiteUserName.Name = "WhiteUserName";
            this.WhiteUserName.ReadOnly = true;
            this.WhiteUserName.Visible = false;
            // 
            // BlackUserName
            // 
            this.BlackUserName.DataPropertyName = "BlackUserName";
            this.BlackUserName.HeaderText = "BlackUserName";
            this.BlackUserName.Name = "BlackUserName";
            this.BlackUserName.ReadOnly = true;
            this.BlackUserName.Visible = false;
            // 
            // Opponent
            // 
            this.Opponent.HeaderText = "Opponent";
            this.Opponent.Name = "Opponent";
            this.Opponent.ReadOnly = true;
            // 
            // EloWhite
            // 
            this.EloWhite.DataPropertyName = "EloWhiteBefore";
            this.EloWhite.HeaderText = "EloWhite";
            this.EloWhite.Name = "EloWhite";
            this.EloWhite.ReadOnly = true;
            this.EloWhite.Visible = false;
            // 
            // EloBlack
            // 
            this.EloBlack.DataPropertyName = "EloBlackBefore";
            this.EloBlack.HeaderText = "EloBlack";
            this.EloBlack.Name = "EloBlack";
            this.EloBlack.ReadOnly = true;
            this.EloBlack.Visible = false;
            // 
            // Elo
            // 
            this.Elo.HeaderText = "Elo";
            this.Elo.Name = "Elo";
            this.Elo.ReadOnly = true;
            // 
            // ChallengeStatusID
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ChallengeStatusID.DefaultCellStyle = dataGridViewCellStyle1;
            this.ChallengeStatusID.HeaderText = "Result";
            this.ChallengeStatusID.Name = "ChallengeStatusID";
            this.ChallengeStatusID.ReadOnly = true;
            // 
            // Side
            // 
            this.Side.HeaderText = "Opp. Side";
            this.Side.Name = "Side";
            this.Side.ReadOnly = true;
            this.Side.Width = 95;
            // 
            // WhiteUserCountry
            // 
            this.WhiteUserCountry.DataPropertyName = "WhiteUserCountry";
            this.WhiteUserCountry.HeaderText = "WhiteUserCountry";
            this.WhiteUserCountry.Name = "WhiteUserCountry";
            this.WhiteUserCountry.ReadOnly = true;
            this.WhiteUserCountry.Visible = false;
            // 
            // BlackUserCountry
            // 
            this.BlackUserCountry.DataPropertyName = "BlackUserCountry";
            this.BlackUserCountry.HeaderText = "BlackUserCountry";
            this.BlackUserCountry.Name = "BlackUserCountry";
            this.BlackUserCountry.ReadOnly = true;
            this.BlackUserCountry.Visible = false;
            // 
            // ChallengeImage
            // 
            this.ChallengeImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ChallengeImage.HeaderText = "Nation";
            this.ChallengeImage.Name = "ChallengeImage";
            this.ChallengeImage.ReadOnly = true;
            this.ChallengeImage.Width = 44;
            // 
            // GameResultID
            // 
            this.GameResultID.DataPropertyName = "GameResultID";
            this.GameResultID.HeaderText = "GameResultID";
            this.GameResultID.Name = "GameResultID";
            this.GameResultID.ReadOnly = true;
            this.GameResultID.Visible = false;
            // 
            // Empty
            // 
            this.Empty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Empty.HeaderText = "";
            this.Empty.Name = "Empty";
            this.Empty.ReadOnly = true;
            // 
            // RatedGameResultUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "RatedGameResultUc";
            this.Size = new System.Drawing.Size(700, 350);
            this.Load += new System.EventHandler(this.RatedGameResultUc_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRanking;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNOpponents;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblOpponentElo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblLosses;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDraws;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblWhite;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblWins;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblStoredGame;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTotalGames;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChallengeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn WhiteUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BlackUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn WhiteUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BlackUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Opponent;
        private System.Windows.Forms.DataGridViewTextBoxColumn EloWhite;
        private System.Windows.Forms.DataGridViewTextBoxColumn EloBlack;
        private System.Windows.Forms.DataGridViewTextBoxColumn Elo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChallengeStatusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Side;
        private System.Windows.Forms.DataGridViewTextBoxColumn WhiteUserCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn BlackUserCountry;
        private System.Windows.Forms.DataGridViewImageColumn ChallengeImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn GameResultID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empty;
    }
}
