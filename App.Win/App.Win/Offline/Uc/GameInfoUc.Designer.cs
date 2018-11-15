namespace InfinityChess
{
    partial class GameInfoUc
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
            this.components = new System.ComponentModel.Container();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblGameTitle2 = new System.Windows.Forms.Label();
            this.lblTournament = new System.Windows.Forms.Label();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblECO = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblGameTitle2);
            this.panel2.Controls.Add(this.lblTournament);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(340, 20);
            this.panel2.TabIndex = 0;
            // 
            // lblGameTitle2
            // 
            this.lblGameTitle2.AutoSize = true;
            this.lblGameTitle2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGameTitle2.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblGameTitle2.Location = new System.Drawing.Point(29, 0);
            this.lblGameTitle2.Margin = new System.Windows.Forms.Padding(3);
            this.lblGameTitle2.Name = "lblGameTitle2";
            this.lblGameTitle2.Size = new System.Drawing.Size(23, 13);
            this.lblGameTitle2.TabIndex = 105;
            this.lblGameTitle2.Text = "title";
            // 
            // lblTournament
            // 
            this.lblTournament.AutoSize = true;
            this.lblTournament.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTournament.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTournament.Location = new System.Drawing.Point(0, 0);
            this.lblTournament.Margin = new System.Windows.Forms.Padding(3);
            this.lblTournament.Name = "lblTournament";
            this.lblTournament.Size = new System.Drawing.Size(29, 13);
            this.lblTournament.TabIndex = 2;
            this.lblTournament.Text = "tour";
            // 
            // lblPlayer
            // 
            this.lblPlayer.BackColor = System.Drawing.Color.LightGray;
            this.lblPlayer.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer.ForeColor = System.Drawing.Color.Black;
            this.lblPlayer.Location = new System.Drawing.Point(0, 0);
            this.lblPlayer.Margin = new System.Windows.Forms.Padding(0);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(692, 32);
            this.lblPlayer.TabIndex = 15;
            this.lblPlayer.Text = "White - Black";
            this.lblPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPlayer.Click += new System.EventHandler(this.lblWhite_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 32);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.53846F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(692, 23);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblECO);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblDateTime);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(349, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 17);
            this.panel1.TabIndex = 18;
            // 
            // lblECO
            // 
            this.lblECO.AutoSize = true;
            this.lblECO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblECO.Location = new System.Drawing.Point(103, 0);
            this.lblECO.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblECO.Name = "lblECO";
            this.lblECO.Size = new System.Drawing.Size(25, 13);
            this.lblECO.TabIndex = 26;
            this.lblECO.Text = "eco";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(81, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "     ";
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDateTime.Location = new System.Drawing.Point(34, 0);
            this.lblDateTime.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(47, 13);
            this.lblDateTime.TabIndex = 24;
            this.lblDateTime.Text = "datetime";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Date";
            // 
            // GameInfoUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblPlayer);
            this.Name = "GameInfoUc";
            this.Size = new System.Drawing.Size(692, 55);
            this.Load += new System.EventHandler(this.GameInfoUc_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTournament;
        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.Label lblGameTitle2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblECO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Label label5;


    }
}
