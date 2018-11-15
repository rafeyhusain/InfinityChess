namespace InfinityChess
{
    partial class ClockUc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClockUc));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbBlackAnalog = new System.Windows.Forms.PictureBox();
            this.pnlWhite = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlBlack = new System.Windows.Forms.Panel();
            this.analogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlDigitalClock = new System.Windows.Forms.Panel();
            this.tlpDigital = new System.Windows.Forms.TableLayoutPanel();
            this.lblBlackCount = new System.Windows.Forms.Label();
            this.lblWhiteTime = new System.Windows.Forms.Label();
            this.lblWhiteCount = new System.Windows.Forms.Label();
            this.lblBlackTime = new System.Windows.Forms.Label();
            this.pbWhiteDigital = new System.Windows.Forms.PictureBox();
            this.pbBlackDigital = new System.Windows.Forms.PictureBox();
            this.pbWhiteAnalog = new System.Windows.Forms.PictureBox();
            this.digitalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlAnalogClock = new System.Windows.Forms.Panel();
            this.tlpAnalog = new System.Windows.Forms.TableLayoutPanel();
            this.cmsClockType = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.doubleDigitalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlClocks = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBlackAnalog)).BeginInit();
            this.pnlDigitalClock.SuspendLayout();
            this.tlpDigital.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWhiteDigital)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBlackDigital)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWhiteAnalog)).BeginInit();
            this.pnlAnalogClock.SuspendLayout();
            this.tlpAnalog.SuspendLayout();
            this.cmsClockType.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.pnlClocks.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::InfinityChess.Properties.Resources.Infinity_Chess_Logo;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(226, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pbBlackAnalog
            // 
            this.pbBlackAnalog.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbBlackAnalog.Image = ((System.Drawing.Image)(resources.GetObject("pbBlackAnalog.Image")));
            this.pbBlackAnalog.Location = new System.Drawing.Point(182, 0);
            this.pbBlackAnalog.Name = "pbBlackAnalog";
            this.pbBlackAnalog.Size = new System.Drawing.Size(15, 74);
            this.pbBlackAnalog.TabIndex = 8;
            this.pbBlackAnalog.TabStop = false;
            // 
            // pnlWhite
            // 
            this.pnlWhite.BackColor = System.Drawing.Color.Black;
            this.pnlWhite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlWhite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWhite.Location = new System.Drawing.Point(4, 4);
            this.pnlWhite.Name = "pnlWhite";
            this.pnlWhite.Size = new System.Drawing.Size(76, 66);
            this.pnlWhite.TabIndex = 2;
            this.pnlWhite.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlWhite_Paint);
            this.pnlWhite.Resize += new System.EventHandler(this.pnlWhite_Resize);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            // 
            // pnlBlack
            // 
            this.pnlBlack.BackColor = System.Drawing.Color.Black;
            this.pnlBlack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBlack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBlack.Location = new System.Drawing.Point(86, 4);
            this.pnlBlack.Name = "pnlBlack";
            this.pnlBlack.Size = new System.Drawing.Size(77, 66);
            this.pnlBlack.TabIndex = 2;
            this.pnlBlack.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBlack_Paint);
            this.pnlBlack.Resize += new System.EventHandler(this.pnlBlack_Resize);
            // 
            // analogToolStripMenuItem
            // 
            this.analogToolStripMenuItem.Name = "analogToolStripMenuItem";
            this.analogToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.analogToolStripMenuItem.Text = "Analog";
            this.analogToolStripMenuItem.Click += new System.EventHandler(this.analogToolStripMenuItem_Click);
            // 
            // pnlDigitalClock
            // 
            this.pnlDigitalClock.Controls.Add(this.tlpDigital);
            this.pnlDigitalClock.Controls.Add(this.pbWhiteDigital);
            this.pnlDigitalClock.Controls.Add(this.pbBlackDigital);
            this.pnlDigitalClock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDigitalClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlDigitalClock.Location = new System.Drawing.Point(197, 0);
            this.pnlDigitalClock.Name = "pnlDigitalClock";
            this.pnlDigitalClock.Size = new System.Drawing.Size(145, 74);
            this.pnlDigitalClock.TabIndex = 11;
            // 
            // tlpDigital
            // 
            this.tlpDigital.ColumnCount = 2;
            this.tlpDigital.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDigital.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDigital.Controls.Add(this.lblBlackCount, 1, 1);
            this.tlpDigital.Controls.Add(this.lblWhiteTime, 0, 0);
            this.tlpDigital.Controls.Add(this.lblWhiteCount, 0, 1);
            this.tlpDigital.Controls.Add(this.lblBlackTime, 1, 0);
            this.tlpDigital.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDigital.Location = new System.Drawing.Point(15, 0);
            this.tlpDigital.Name = "tlpDigital";
            this.tlpDigital.Padding = new System.Windows.Forms.Padding(2);
            this.tlpDigital.RowCount = 2;
            this.tlpDigital.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDigital.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDigital.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDigital.Size = new System.Drawing.Size(115, 74);
            this.tlpDigital.TabIndex = 14;
            // 
            // lblBlackCount
            // 
            this.lblBlackCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBlackCount.AutoSize = true;
            this.lblBlackCount.BackColor = System.Drawing.Color.Black;
            this.lblBlackCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBlackCount.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblBlackCount.ForeColor = System.Drawing.Color.White;
            this.lblBlackCount.Location = new System.Drawing.Point(57, 37);
            this.lblBlackCount.Margin = new System.Windows.Forms.Padding(0);
            this.lblBlackCount.MaximumSize = new System.Drawing.Size(0, 40);
            this.lblBlackCount.Name = "lblBlackCount";
            this.lblBlackCount.Padding = new System.Windows.Forms.Padding(3);
            this.lblBlackCount.Size = new System.Drawing.Size(56, 35);
            this.lblBlackCount.TabIndex = 17;
            this.lblBlackCount.Text = "[lblBlackCount]";
            this.lblBlackCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWhiteTime
            // 
            this.lblWhiteTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWhiteTime.AutoSize = true;
            this.lblWhiteTime.BackColor = System.Drawing.Color.Black;
            this.lblWhiteTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWhiteTime.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblWhiteTime.ForeColor = System.Drawing.Color.White;
            this.lblWhiteTime.Location = new System.Drawing.Point(2, 2);
            this.lblWhiteTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblWhiteTime.MaximumSize = new System.Drawing.Size(0, 40);
            this.lblWhiteTime.Name = "lblWhiteTime";
            this.lblWhiteTime.Padding = new System.Windows.Forms.Padding(3);
            this.lblWhiteTime.Size = new System.Drawing.Size(55, 35);
            this.lblWhiteTime.TabIndex = 14;
            this.lblWhiteTime.Text = "[lblWhiteTime]";
            this.lblWhiteTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWhiteTime.Resize += new System.EventHandler(this.lblWhiteTime_Resize);
            // 
            // lblWhiteCount
            // 
            this.lblWhiteCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWhiteCount.AutoSize = true;
            this.lblWhiteCount.BackColor = System.Drawing.Color.Black;
            this.lblWhiteCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWhiteCount.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblWhiteCount.ForeColor = System.Drawing.Color.White;
            this.lblWhiteCount.Location = new System.Drawing.Point(2, 37);
            this.lblWhiteCount.Margin = new System.Windows.Forms.Padding(0);
            this.lblWhiteCount.MaximumSize = new System.Drawing.Size(0, 40);
            this.lblWhiteCount.Name = "lblWhiteCount";
            this.lblWhiteCount.Padding = new System.Windows.Forms.Padding(3);
            this.lblWhiteCount.Size = new System.Drawing.Size(55, 35);
            this.lblWhiteCount.TabIndex = 16;
            this.lblWhiteCount.Text = "[lblWhiteCount]";
            this.lblWhiteCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBlackTime
            // 
            this.lblBlackTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBlackTime.AutoSize = true;
            this.lblBlackTime.BackColor = System.Drawing.Color.Black;
            this.lblBlackTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBlackTime.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblBlackTime.ForeColor = System.Drawing.Color.White;
            this.lblBlackTime.Location = new System.Drawing.Point(57, 2);
            this.lblBlackTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblBlackTime.MaximumSize = new System.Drawing.Size(0, 40);
            this.lblBlackTime.Name = "lblBlackTime";
            this.lblBlackTime.Padding = new System.Windows.Forms.Padding(3);
            this.lblBlackTime.Size = new System.Drawing.Size(56, 35);
            this.lblBlackTime.TabIndex = 15;
            this.lblBlackTime.Text = "[lblBlackTime]";
            this.lblBlackTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBlackTime.Resize += new System.EventHandler(this.lblBlackTime_Resize);
            // 
            // pbWhiteDigital
            // 
            this.pbWhiteDigital.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbWhiteDigital.Image = ((System.Drawing.Image)(resources.GetObject("pbWhiteDigital.Image")));
            this.pbWhiteDigital.Location = new System.Drawing.Point(0, 0);
            this.pbWhiteDigital.Name = "pbWhiteDigital";
            this.pbWhiteDigital.Padding = new System.Windows.Forms.Padding(0, 20, 10, 10);
            this.pbWhiteDigital.Size = new System.Drawing.Size(15, 74);
            this.pbWhiteDigital.TabIndex = 6;
            this.pbWhiteDigital.TabStop = false;
            // 
            // pbBlackDigital
            // 
            this.pbBlackDigital.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbBlackDigital.Image = ((System.Drawing.Image)(resources.GetObject("pbBlackDigital.Image")));
            this.pbBlackDigital.Location = new System.Drawing.Point(130, 0);
            this.pbBlackDigital.Name = "pbBlackDigital";
            this.pbBlackDigital.Padding = new System.Windows.Forms.Padding(3, 20, 3, 10);
            this.pbBlackDigital.Size = new System.Drawing.Size(15, 74);
            this.pbBlackDigital.TabIndex = 5;
            this.pbBlackDigital.TabStop = false;
            // 
            // pbWhiteAnalog
            // 
            this.pbWhiteAnalog.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbWhiteAnalog.Image = ((System.Drawing.Image)(resources.GetObject("pbWhiteAnalog.Image")));
            this.pbWhiteAnalog.Location = new System.Drawing.Point(0, 0);
            this.pbWhiteAnalog.Name = "pbWhiteAnalog";
            this.pbWhiteAnalog.Size = new System.Drawing.Size(15, 74);
            this.pbWhiteAnalog.TabIndex = 7;
            this.pbWhiteAnalog.TabStop = false;
            // 
            // digitalToolStripMenuItem
            // 
            this.digitalToolStripMenuItem.Name = "digitalToolStripMenuItem";
            this.digitalToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.digitalToolStripMenuItem.Text = "Digital";
            this.digitalToolStripMenuItem.Click += new System.EventHandler(this.digitalToolStripMenuItem_Click);
            // 
            // pnlAnalogClock
            // 
            this.pnlAnalogClock.Controls.Add(this.tlpAnalog);
            this.pnlAnalogClock.Controls.Add(this.pbWhiteAnalog);
            this.pnlAnalogClock.Controls.Add(this.pbBlackAnalog);
            this.pnlAnalogClock.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAnalogClock.Location = new System.Drawing.Point(0, 0);
            this.pnlAnalogClock.Name = "pnlAnalogClock";
            this.pnlAnalogClock.Size = new System.Drawing.Size(197, 74);
            this.pnlAnalogClock.TabIndex = 12;
            // 
            // tlpAnalog
            // 
            this.tlpAnalog.ColumnCount = 2;
            this.tlpAnalog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAnalog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAnalog.Controls.Add(this.pnlBlack, 1, 0);
            this.tlpAnalog.Controls.Add(this.pnlWhite, 0, 0);
            this.tlpAnalog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAnalog.Location = new System.Drawing.Point(15, 0);
            this.tlpAnalog.Name = "tlpAnalog";
            this.tlpAnalog.Padding = new System.Windows.Forms.Padding(1);
            this.tlpAnalog.RowCount = 1;
            this.tlpAnalog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAnalog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAnalog.Size = new System.Drawing.Size(167, 74);
            this.tlpAnalog.TabIndex = 3;
            // 
            // cmsClockType
            // 
            this.cmsClockType.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.digitalToolStripMenuItem,
            this.analogToolStripMenuItem,
            this.doubleDigitalToolStripMenuItem});
            this.cmsClockType.Name = "cmsClockType";
            this.cmsClockType.Size = new System.Drawing.Size(151, 70);
            // 
            // doubleDigitalToolStripMenuItem
            // 
            this.doubleDigitalToolStripMenuItem.Name = "doubleDigitalToolStripMenuItem";
            this.doubleDigitalToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.doubleDigitalToolStripMenuItem.Text = "Double Digital";
            this.doubleDigitalToolStripMenuItem.Click += new System.EventHandler(this.doubleDigitalToolStripMenuItem_Click);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpMain.Controls.Add(this.pnlClocks, 1, 0);
            this.tlpMain.Controls.Add(this.pictureBox1, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.MaximumSize = new System.Drawing.Size(580, 90);
            this.tlpMain.MinimumSize = new System.Drawing.Size(440, 80);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(580, 80);
            this.tlpMain.TabIndex = 13;
            this.tlpMain.Resize += new System.EventHandler(this.tlpMain_Resize);
            // 
            // pnlClocks
            // 
            this.pnlClocks.Controls.Add(this.pnlDigitalClock);
            this.pnlClocks.Controls.Add(this.pnlAnalogClock);
            this.pnlClocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClocks.Location = new System.Drawing.Point(235, 3);
            this.pnlClocks.Name = "pnlClocks";
            this.pnlClocks.Size = new System.Drawing.Size(342, 74);
            this.pnlClocks.TabIndex = 0;
            // 
            // ClockUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.cmsClockType;
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ClockUc";
            this.Size = new System.Drawing.Size(738, 75);
            this.Load += new System.EventHandler(this.ClockUc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBlackAnalog)).EndInit();
            this.pnlDigitalClock.ResumeLayout(false);
            this.tlpDigital.ResumeLayout(false);
            this.tlpDigital.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWhiteDigital)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBlackDigital)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWhiteAnalog)).EndInit();
            this.pnlAnalogClock.ResumeLayout(false);
            this.tlpAnalog.ResumeLayout(false);
            this.cmsClockType.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.pnlClocks.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbBlackAnalog;
        private System.Windows.Forms.Panel pnlWhite;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlBlack;
        private System.Windows.Forms.ToolStripMenuItem analogToolStripMenuItem;
        private System.Windows.Forms.Panel pnlDigitalClock;
        private System.Windows.Forms.PictureBox pbWhiteDigital;
        private System.Windows.Forms.PictureBox pbBlackDigital;
        private System.Windows.Forms.PictureBox pbWhiteAnalog;
        private System.Windows.Forms.ToolStripMenuItem digitalToolStripMenuItem;
        private System.Windows.Forms.Panel pnlAnalogClock;
        private System.Windows.Forms.ContextMenuStrip cmsClockType;
        private System.Windows.Forms.ToolStripMenuItem doubleDigitalToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pnlClocks;
        private System.Windows.Forms.TableLayoutPanel tlpDigital;
        private System.Windows.Forms.TableLayoutPanel tlpAnalog;
        private System.Windows.Forms.Label lblWhiteTime;
        private System.Windows.Forms.Label lblWhiteCount;
        private System.Windows.Forms.Label lblBlackTime;
        private System.Windows.Forms.Label lblBlackCount;

    }
}
