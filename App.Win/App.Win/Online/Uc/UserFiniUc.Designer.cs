namespace App.Win
{
    partial class UserFiniUc
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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblLossText = new System.Windows.Forms.Label();
            this.lblDrawText = new System.Windows.Forms.Label();
            this.lblWinText = new System.Windows.Forms.Label();
            this.lblLoose = new System.Windows.Forms.Label();
            this.lblDraw = new System.Windows.Forms.Label();
            this.lblWin = new System.Windows.Forms.Label();
            this.gbFini = new System.Windows.Forms.GroupBox();
            this.nudFlate = new System.Windows.Forms.NumericUpDown();
            this.nudStake = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.lblStakeText = new System.Windows.Forms.Label();
            this.lblFlate = new System.Windows.Forms.Label();
            this.lblStake = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            this.gbFini.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFlate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStake)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblLossText);
            this.groupBox5.Controls.Add(this.lblDrawText);
            this.groupBox5.Controls.Add(this.lblWinText);
            this.groupBox5.Controls.Add(this.lblLoose);
            this.groupBox5.Controls.Add(this.lblDraw);
            this.groupBox5.Controls.Add(this.lblWin);
            this.groupBox5.Location = new System.Drawing.Point(7, 123);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(325, 116);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Get (positive) and Loss (negative) of Game";
            // 
            // lblLossText
            // 
            this.lblLossText.AutoSize = true;
            this.lblLossText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLossText.Location = new System.Drawing.Point(109, 82);
            this.lblLossText.Name = "lblLossText";
            this.lblLossText.Size = new System.Drawing.Size(14, 13);
            this.lblLossText.TabIndex = 9;
            this.lblLossText.Text = "0";
            this.lblLossText.TextChanged += new System.EventHandler(this.lblLossText_TextChanged);
            // 
            // lblDrawText
            // 
            this.lblDrawText.AutoSize = true;
            this.lblDrawText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrawText.Location = new System.Drawing.Point(109, 52);
            this.lblDrawText.Name = "lblDrawText";
            this.lblDrawText.Size = new System.Drawing.Size(14, 13);
            this.lblDrawText.TabIndex = 8;
            this.lblDrawText.Text = "0";
            // 
            // lblWinText
            // 
            this.lblWinText.AutoSize = true;
            this.lblWinText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinText.Location = new System.Drawing.Point(109, 26);
            this.lblWinText.Name = "lblWinText";
            this.lblWinText.Size = new System.Drawing.Size(14, 13);
            this.lblWinText.TabIndex = 7;
            this.lblWinText.Text = "0";
            // 
            // lblLoose
            // 
            this.lblLoose.AutoSize = true;
            this.lblLoose.Location = new System.Drawing.Point(19, 82);
            this.lblLoose.Name = "lblLoose";
            this.lblLoose.Size = new System.Drawing.Size(29, 13);
            this.lblLoose.TabIndex = 6;
            this.lblLoose.Text = "Loss";
            // 
            // lblDraw
            // 
            this.lblDraw.AutoSize = true;
            this.lblDraw.Location = new System.Drawing.Point(19, 52);
            this.lblDraw.Name = "lblDraw";
            this.lblDraw.Size = new System.Drawing.Size(32, 13);
            this.lblDraw.TabIndex = 1;
            this.lblDraw.Text = "Draw";
            // 
            // lblWin
            // 
            this.lblWin.AutoSize = true;
            this.lblWin.Location = new System.Drawing.Point(19, 26);
            this.lblWin.Name = "lblWin";
            this.lblWin.Size = new System.Drawing.Size(26, 13);
            this.lblWin.TabIndex = 0;
            this.lblWin.Text = "Win";
            // 
            // gbFini
            // 
            this.gbFini.Controls.Add(this.nudFlate);
            this.gbFini.Controls.Add(this.nudStake);
            this.gbFini.Controls.Add(this.label5);
            this.gbFini.Controls.Add(this.lblStakeText);
            this.gbFini.Controls.Add(this.lblFlate);
            this.gbFini.Controls.Add(this.lblStake);
            this.gbFini.Location = new System.Drawing.Point(7, 3);
            this.gbFini.Name = "gbFini";
            this.gbFini.Size = new System.Drawing.Size(325, 116);
            this.gbFini.TabIndex = 7;
            this.gbFini.TabStop = false;
            this.gbFini.Text = "Fini";
            // 
            // nudFlate
            // 
            this.nudFlate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudFlate.Location = new System.Drawing.Point(105, 50);
            this.nudFlate.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudFlate.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.nudFlate.Name = "nudFlate";
            this.nudFlate.Size = new System.Drawing.Size(64, 20);
            this.nudFlate.TabIndex = 7;
            this.nudFlate.ValueChanged += new System.EventHandler(this.nudFlate_ValueChanged);
            // 
            // nudStake
            // 
            this.nudStake.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudStake.Location = new System.Drawing.Point(105, 24);
            this.nudStake.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudStake.Name = "nudStake";
            this.nudStake.Size = new System.Drawing.Size(64, 20);
            this.nudStake.TabIndex = 6;
            this.nudStake.ValueChanged += new System.EventHandler(this.nudStake_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Fini";
            // 
            // lblStakeText
            // 
            this.lblStakeText.AutoSize = true;
            this.lblStakeText.Location = new System.Drawing.Point(189, 26);
            this.lblStakeText.Name = "lblStakeText";
            this.lblStakeText.Size = new System.Drawing.Size(23, 13);
            this.lblStakeText.TabIndex = 4;
            this.lblStakeText.Text = "Fini";
            // 
            // lblFlate
            // 
            this.lblFlate.AutoSize = true;
            this.lblFlate.Location = new System.Drawing.Point(19, 53);
            this.lblFlate.Name = "lblFlate";
            this.lblFlate.Size = new System.Drawing.Size(30, 13);
            this.lblFlate.TabIndex = 1;
            this.lblFlate.Text = "Flate";
            // 
            // lblStake
            // 
            this.lblStake.AutoSize = true;
            this.lblStake.Location = new System.Drawing.Point(19, 26);
            this.lblStake.Name = "lblStake";
            this.lblStake.Size = new System.Drawing.Size(35, 13);
            this.lblStake.TabIndex = 0;
            this.lblStake.Text = "Stake";
            // 
            // UserFiniUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.gbFini);
            this.Name = "UserFiniUc";
            this.Size = new System.Drawing.Size(338, 245);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.gbFini.ResumeLayout(false);
            this.gbFini.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFlate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStake)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblLossText;
        private System.Windows.Forms.Label lblDrawText;
        private System.Windows.Forms.Label lblWinText;
        private System.Windows.Forms.Label lblLoose;
        private System.Windows.Forms.Label lblDraw;
        private System.Windows.Forms.Label lblWin;
        private System.Windows.Forms.GroupBox gbFini;
        private System.Windows.Forms.NumericUpDown nudFlate;
        private System.Windows.Forms.NumericUpDown nudStake;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblStakeText;
        private System.Windows.Forms.Label lblFlate;
        private System.Windows.Forms.Label lblStake;
    }
}
