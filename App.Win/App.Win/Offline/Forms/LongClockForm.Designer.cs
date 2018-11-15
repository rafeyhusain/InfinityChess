namespace App.Win
{
    partial class LongClockForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LongClockForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numMovesFirst = new System.Windows.Forms.NumericUpDown();
            this.lblMovesFirst = new System.Windows.Forms.Label();
            this.lblGainTimeFirst = new System.Windows.Forms.Label();
            this.lblMinFirst = new System.Windows.Forms.Label();
            this.lblHourFirst = new System.Windows.Forms.Label();
            this.numHourFirst = new System.Windows.Forms.NumericUpDown();
            this.numMinuteFirst = new System.Windows.Forms.NumericUpDown();
            this.numGainFirst = new System.Windows.Forms.NumericUpDown();
            this.lblGainFirst = new System.Windows.Forms.Label();
            this.lblTimeFirst = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rb90minAllMoves = new System.Windows.Forms.RadioButton();
            this.rb45min = new System.Windows.Forms.RadioButton();
            this.rb90min = new System.Windows.Forms.RadioButton();
            this.rb2HourAllMoves = new System.Windows.Forms.RadioButton();
            this.rb60min = new System.Windows.Forms.RadioButton();
            this.rb2hour = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numMovesSecond = new System.Windows.Forms.NumericUpDown();
            this.lblGainTimeSecond = new System.Windows.Forms.Label();
            this.lblMovesSecond = new System.Windows.Forms.Label();
            this.lblMinuteSecond = new System.Windows.Forms.Label();
            this.lblHourSecond = new System.Windows.Forms.Label();
            this.numHourSecond = new System.Windows.Forms.NumericUpDown();
            this.numMinuteSecond = new System.Windows.Forms.NumericUpDown();
            this.numGainSecond = new System.Windows.Forms.NumericUpDown();
            this.lblGainSecond = new System.Windows.Forms.Label();
            this.lblTimeSecond = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblGainTimeThird = new System.Windows.Forms.Label();
            this.lblMinuteThird = new System.Windows.Forms.Label();
            this.lblHourThird = new System.Windows.Forms.Label();
            this.numHourThird = new System.Windows.Forms.NumericUpDown();
            this.numMinuteThird = new System.Windows.Forms.NumericUpDown();
            this.numGainThird = new System.Windows.Forms.NumericUpDown();
            this.lblGainThird = new System.Windows.Forms.Label();
            this.lblTimeThird = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMovesFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHourFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinuteFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGainFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMovesSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHourSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinuteSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGainSecond)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHourThird)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinuteThird)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGainThird)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numMovesFirst);
            this.groupBox1.Controls.Add(this.lblMovesFirst);
            this.groupBox1.Controls.Add(this.lblGainTimeFirst);
            this.groupBox1.Controls.Add(this.lblMinFirst);
            this.groupBox1.Controls.Add(this.lblHourFirst);
            this.groupBox1.Controls.Add(this.numHourFirst);
            this.groupBox1.Controls.Add(this.numMinuteFirst);
            this.groupBox1.Controls.Add(this.numGainFirst);
            this.groupBox1.Controls.Add(this.lblGainFirst);
            this.groupBox1.Controls.Add(this.lblTimeFirst);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(269, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "First time control";
            // 
            // numMovesFirst
            // 
            this.numMovesFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMovesFirst.Location = new System.Drawing.Point(102, 47);
            this.numMovesFirst.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMovesFirst.Name = "numMovesFirst";
            this.numMovesFirst.Size = new System.Drawing.Size(50, 20);
            this.numMovesFirst.TabIndex = 14;
            this.numMovesFirst.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblMovesFirst
            // 
            this.lblMovesFirst.AutoSize = true;
            this.lblMovesFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovesFirst.Location = new System.Drawing.Point(10, 49);
            this.lblMovesFirst.Name = "lblMovesFirst";
            this.lblMovesFirst.Size = new System.Drawing.Size(45, 13);
            this.lblMovesFirst.TabIndex = 15;
            this.lblMovesFirst.Text = "Moves :";
            // 
            // lblGainTimeFirst
            // 
            this.lblGainTimeFirst.AutoSize = true;
            this.lblGainTimeFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGainTimeFirst.Location = new System.Drawing.Point(251, 78);
            this.lblGainTimeFirst.Name = "lblGainTimeFirst";
            this.lblGainTimeFirst.Size = new System.Drawing.Size(24, 13);
            this.lblGainTimeFirst.TabIndex = 13;
            this.lblGainTimeFirst.Text = "sec";
            // 
            // lblMinFirst
            // 
            this.lblMinFirst.AutoSize = true;
            this.lblMinFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinFirst.Location = new System.Drawing.Point(253, 20);
            this.lblMinFirst.Name = "lblMinFirst";
            this.lblMinFirst.Size = new System.Drawing.Size(23, 13);
            this.lblMinFirst.TabIndex = 12;
            this.lblMinFirst.Text = "min";
            // 
            // lblHourFirst
            // 
            this.lblHourFirst.AutoSize = true;
            this.lblHourFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHourFirst.Location = new System.Drawing.Point(158, 20);
            this.lblHourFirst.Name = "lblHourFirst";
            this.lblHourFirst.Size = new System.Drawing.Size(13, 13);
            this.lblHourFirst.TabIndex = 11;
            this.lblHourFirst.Text = "h";
            // 
            // numHourFirst
            // 
            this.numHourFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numHourFirst.Location = new System.Drawing.Point(102, 18);
            this.numHourFirst.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numHourFirst.Name = "numHourFirst";
            this.numHourFirst.Size = new System.Drawing.Size(50, 20);
            this.numHourFirst.TabIndex = 0;
            // 
            // numMinuteFirst
            // 
            this.numMinuteFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMinuteFirst.Location = new System.Drawing.Point(195, 18);
            this.numMinuteFirst.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numMinuteFirst.Name = "numMinuteFirst";
            this.numMinuteFirst.Size = new System.Drawing.Size(50, 20);
            this.numMinuteFirst.TabIndex = 1;
            // 
            // numGainFirst
            // 
            this.numGainFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGainFirst.Location = new System.Drawing.Point(195, 75);
            this.numGainFirst.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numGainFirst.Name = "numGainFirst";
            this.numGainFirst.Size = new System.Drawing.Size(50, 20);
            this.numGainFirst.TabIndex = 3;
            // 
            // lblGainFirst
            // 
            this.lblGainFirst.AutoSize = true;
            this.lblGainFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGainFirst.Location = new System.Drawing.Point(10, 78);
            this.lblGainFirst.Name = "lblGainFirst";
            this.lblGainFirst.Size = new System.Drawing.Size(82, 13);
            this.lblGainFirst.TabIndex = 4;
            this.lblGainFirst.Text = "Gain per move :";
            // 
            // lblTimeFirst
            // 
            this.lblTimeFirst.AutoSize = true;
            this.lblTimeFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeFirst.Location = new System.Drawing.Point(10, 20);
            this.lblTimeFirst.Name = "lblTimeFirst";
            this.lblTimeFirst.Size = new System.Drawing.Size(36, 13);
            this.lblTimeFirst.TabIndex = 3;
            this.lblTimeFirst.Text = "Time :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(21, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(236, 173);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.rb90minAllMoves);
            this.groupBox4.Controls.Add(this.rb45min);
            this.groupBox4.Controls.Add(this.rb90min);
            this.groupBox4.Controls.Add(this.rb2HourAllMoves);
            this.groupBox4.Controls.Add(this.rb60min);
            this.groupBox4.Controls.Add(this.rb2hour);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox4.Location = new System.Drawing.Point(12, 184);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(245, 137);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Defaults";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(22, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "All moves :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(22, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "For 40 moves use :";
            // 
            // rb90minAllMoves
            // 
            this.rb90minAllMoves.AutoSize = true;
            this.rb90minAllMoves.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb90minAllMoves.Location = new System.Drawing.Point(131, 97);
            this.rb90minAllMoves.Name = "rb90minAllMoves";
            this.rb90minAllMoves.Size = new System.Drawing.Size(76, 17);
            this.rb90minAllMoves.TabIndex = 5;
            this.rb90minAllMoves.TabStop = true;
            this.rb90minAllMoves.Text = "90 minutes";
            this.rb90minAllMoves.UseVisualStyleBackColor = true;
            this.rb90minAllMoves.CheckedChanged += new System.EventHandler(this.rb90minAllMoves_CheckedChanged);
            // 
            // rb45min
            // 
            this.rb45min.AutoSize = true;
            this.rb45min.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb45min.Location = new System.Drawing.Point(131, 64);
            this.rb45min.Name = "rb45min";
            this.rb45min.Size = new System.Drawing.Size(76, 17);
            this.rb45min.TabIndex = 3;
            this.rb45min.TabStop = true;
            this.rb45min.Text = "45 minutes";
            this.rb45min.UseVisualStyleBackColor = true;
            this.rb45min.CheckedChanged += new System.EventHandler(this.rb45min_CheckedChanged);
            // 
            // rb90min
            // 
            this.rb90min.AutoSize = true;
            this.rb90min.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb90min.Location = new System.Drawing.Point(131, 42);
            this.rb90min.Name = "rb90min";
            this.rb90min.Size = new System.Drawing.Size(76, 17);
            this.rb90min.TabIndex = 1;
            this.rb90min.TabStop = true;
            this.rb90min.Text = "90 minutes";
            this.rb90min.UseVisualStyleBackColor = true;
            this.rb90min.CheckedChanged += new System.EventHandler(this.rb90min_CheckedChanged);
            // 
            // rb2HourAllMoves
            // 
            this.rb2HourAllMoves.AutoSize = true;
            this.rb2HourAllMoves.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb2HourAllMoves.Location = new System.Drawing.Point(25, 97);
            this.rb2HourAllMoves.Name = "rb2HourAllMoves";
            this.rb2HourAllMoves.Size = new System.Drawing.Size(60, 17);
            this.rb2HourAllMoves.TabIndex = 4;
            this.rb2HourAllMoves.TabStop = true;
            this.rb2HourAllMoves.Text = "2 hours";
            this.rb2HourAllMoves.UseVisualStyleBackColor = true;
            this.rb2HourAllMoves.CheckedChanged += new System.EventHandler(this.rb2HourAllMoves_CheckedChanged);
            // 
            // rb60min
            // 
            this.rb60min.AutoSize = true;
            this.rb60min.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb60min.Location = new System.Drawing.Point(25, 62);
            this.rb60min.Name = "rb60min";
            this.rb60min.Size = new System.Drawing.Size(76, 17);
            this.rb60min.TabIndex = 2;
            this.rb60min.TabStop = true;
            this.rb60min.Text = "60 minutes";
            this.rb60min.UseVisualStyleBackColor = true;
            this.rb60min.CheckedChanged += new System.EventHandler(this.rb60min_CheckedChanged);
            // 
            // rb2hour
            // 
            this.rb2hour.AutoSize = true;
            this.rb2hour.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb2hour.Location = new System.Drawing.Point(25, 42);
            this.rb2hour.Name = "rb2hour";
            this.rb2hour.Size = new System.Drawing.Size(60, 17);
            this.rb2hour.TabIndex = 0;
            this.rb2hour.TabStop = true;
            this.rb2hour.Text = "2 hours";
            this.rb2hour.UseVisualStyleBackColor = true;
            this.rb2hour.CheckedChanged += new System.EventHandler(this.rb2hour_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(394, 348);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnHelp.Location = new System.Drawing.Point(475, 348);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 22);
            this.btnHelp.TabIndex = 6;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnOK.Location = new System.Drawing.Point(313, 348);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 22);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numMovesSecond);
            this.groupBox2.Controls.Add(this.lblGainTimeSecond);
            this.groupBox2.Controls.Add(this.lblMovesSecond);
            this.groupBox2.Controls.Add(this.lblMinuteSecond);
            this.groupBox2.Controls.Add(this.lblHourSecond);
            this.groupBox2.Controls.Add(this.numHourSecond);
            this.groupBox2.Controls.Add(this.numMinuteSecond);
            this.groupBox2.Controls.Add(this.numGainSecond);
            this.groupBox2.Controls.Add(this.lblGainSecond);
            this.groupBox2.Controls.Add(this.lblTimeSecond);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(269, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(283, 114);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Second time control";
            // 
            // numMovesSecond
            // 
            this.numMovesSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMovesSecond.Location = new System.Drawing.Point(102, 50);
            this.numMovesSecond.Name = "numMovesSecond";
            this.numMovesSecond.Size = new System.Drawing.Size(50, 20);
            this.numMovesSecond.TabIndex = 16;
            // 
            // lblGainTimeSecond
            // 
            this.lblGainTimeSecond.AutoSize = true;
            this.lblGainTimeSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGainTimeSecond.Location = new System.Drawing.Point(251, 81);
            this.lblGainTimeSecond.Name = "lblGainTimeSecond";
            this.lblGainTimeSecond.Size = new System.Drawing.Size(24, 13);
            this.lblGainTimeSecond.TabIndex = 13;
            this.lblGainTimeSecond.Text = "sec";
            // 
            // lblMovesSecond
            // 
            this.lblMovesSecond.AutoSize = true;
            this.lblMovesSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovesSecond.Location = new System.Drawing.Point(10, 52);
            this.lblMovesSecond.Name = "lblMovesSecond";
            this.lblMovesSecond.Size = new System.Drawing.Size(45, 13);
            this.lblMovesSecond.TabIndex = 17;
            this.lblMovesSecond.Text = "Moves :";
            // 
            // lblMinuteSecond
            // 
            this.lblMinuteSecond.AutoSize = true;
            this.lblMinuteSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinuteSecond.Location = new System.Drawing.Point(253, 20);
            this.lblMinuteSecond.Name = "lblMinuteSecond";
            this.lblMinuteSecond.Size = new System.Drawing.Size(23, 13);
            this.lblMinuteSecond.TabIndex = 12;
            this.lblMinuteSecond.Text = "min";
            // 
            // lblHourSecond
            // 
            this.lblHourSecond.AutoSize = true;
            this.lblHourSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHourSecond.Location = new System.Drawing.Point(158, 20);
            this.lblHourSecond.Name = "lblHourSecond";
            this.lblHourSecond.Size = new System.Drawing.Size(13, 13);
            this.lblHourSecond.TabIndex = 11;
            this.lblHourSecond.Text = "h";
            // 
            // numHourSecond
            // 
            this.numHourSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numHourSecond.Location = new System.Drawing.Point(102, 18);
            this.numHourSecond.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numHourSecond.Name = "numHourSecond";
            this.numHourSecond.Size = new System.Drawing.Size(50, 20);
            this.numHourSecond.TabIndex = 0;
            // 
            // numMinuteSecond
            // 
            this.numMinuteSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMinuteSecond.Location = new System.Drawing.Point(195, 18);
            this.numMinuteSecond.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numMinuteSecond.Name = "numMinuteSecond";
            this.numMinuteSecond.Size = new System.Drawing.Size(50, 20);
            this.numMinuteSecond.TabIndex = 1;
            // 
            // numGainSecond
            // 
            this.numGainSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGainSecond.Location = new System.Drawing.Point(195, 78);
            this.numGainSecond.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numGainSecond.Name = "numGainSecond";
            this.numGainSecond.Size = new System.Drawing.Size(50, 20);
            this.numGainSecond.TabIndex = 3;
            // 
            // lblGainSecond
            // 
            this.lblGainSecond.AutoSize = true;
            this.lblGainSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGainSecond.Location = new System.Drawing.Point(10, 81);
            this.lblGainSecond.Name = "lblGainSecond";
            this.lblGainSecond.Size = new System.Drawing.Size(82, 13);
            this.lblGainSecond.TabIndex = 4;
            this.lblGainSecond.Text = "Gain per move :";
            // 
            // lblTimeSecond
            // 
            this.lblTimeSecond.AutoSize = true;
            this.lblTimeSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeSecond.Location = new System.Drawing.Point(10, 20);
            this.lblTimeSecond.Name = "lblTimeSecond";
            this.lblTimeSecond.Size = new System.Drawing.Size(36, 13);
            this.lblTimeSecond.TabIndex = 3;
            this.lblTimeSecond.Text = "Time :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblGainTimeThird);
            this.groupBox3.Controls.Add(this.lblMinuteThird);
            this.groupBox3.Controls.Add(this.lblHourThird);
            this.groupBox3.Controls.Add(this.numHourThird);
            this.groupBox3.Controls.Add(this.numMinuteThird);
            this.groupBox3.Controls.Add(this.numGainThird);
            this.groupBox3.Controls.Add(this.lblGainThird);
            this.groupBox3.Controls.Add(this.lblTimeThird);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox3.Location = new System.Drawing.Point(269, 244);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(283, 77);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Third  time control";
            // 
            // lblGainTimeThird
            // 
            this.lblGainTimeThird.AutoSize = true;
            this.lblGainTimeThird.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGainTimeThird.Location = new System.Drawing.Point(251, 54);
            this.lblGainTimeThird.Name = "lblGainTimeThird";
            this.lblGainTimeThird.Size = new System.Drawing.Size(24, 13);
            this.lblGainTimeThird.TabIndex = 13;
            this.lblGainTimeThird.Text = "sec";
            // 
            // lblMinuteThird
            // 
            this.lblMinuteThird.AutoSize = true;
            this.lblMinuteThird.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinuteThird.Location = new System.Drawing.Point(253, 20);
            this.lblMinuteThird.Name = "lblMinuteThird";
            this.lblMinuteThird.Size = new System.Drawing.Size(23, 13);
            this.lblMinuteThird.TabIndex = 12;
            this.lblMinuteThird.Text = "min";
            // 
            // lblHourThird
            // 
            this.lblHourThird.AutoSize = true;
            this.lblHourThird.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHourThird.Location = new System.Drawing.Point(158, 20);
            this.lblHourThird.Name = "lblHourThird";
            this.lblHourThird.Size = new System.Drawing.Size(13, 13);
            this.lblHourThird.TabIndex = 11;
            this.lblHourThird.Text = "h";
            // 
            // numHourThird
            // 
            this.numHourThird.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numHourThird.Location = new System.Drawing.Point(102, 18);
            this.numHourThird.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numHourThird.Name = "numHourThird";
            this.numHourThird.Size = new System.Drawing.Size(50, 20);
            this.numHourThird.TabIndex = 0;
            // 
            // numMinuteThird
            // 
            this.numMinuteThird.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMinuteThird.Location = new System.Drawing.Point(195, 18);
            this.numMinuteThird.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numMinuteThird.Name = "numMinuteThird";
            this.numMinuteThird.Size = new System.Drawing.Size(50, 20);
            this.numMinuteThird.TabIndex = 1;
            // 
            // numGainThird
            // 
            this.numGainThird.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGainThird.Location = new System.Drawing.Point(195, 51);
            this.numGainThird.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numGainThird.Name = "numGainThird";
            this.numGainThird.Size = new System.Drawing.Size(50, 20);
            this.numGainThird.TabIndex = 3;
            // 
            // lblGainThird
            // 
            this.lblGainThird.AutoSize = true;
            this.lblGainThird.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGainThird.Location = new System.Drawing.Point(10, 54);
            this.lblGainThird.Name = "lblGainThird";
            this.lblGainThird.Size = new System.Drawing.Size(82, 13);
            this.lblGainThird.TabIndex = 4;
            this.lblGainThird.Text = "Gain per move :";
            // 
            // lblTimeThird
            // 
            this.lblTimeThird.AutoSize = true;
            this.lblTimeThird.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeThird.Location = new System.Drawing.Point(10, 20);
            this.lblTimeThird.Name = "lblTimeThird";
            this.lblTimeThird.Size = new System.Drawing.Size(36, 13);
            this.lblTimeThird.TabIndex = 3;
            this.lblTimeThird.Text = "Time :";
            // 
            // LongClockForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(562, 386);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LongClockForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Long Game";
            this.Load += new System.EventHandler(this.LongClockForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMovesFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHourFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinuteFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGainFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMovesSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHourSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinuteSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGainSecond)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHourThird)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinuteThird)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGainThird)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numMinuteFirst;
        private System.Windows.Forms.NumericUpDown numGainFirst;
        private System.Windows.Forms.Label lblGainFirst;
        private System.Windows.Forms.Label lblTimeFirst;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rb90minAllMoves;
        private System.Windows.Forms.RadioButton rb45min;
        private System.Windows.Forms.RadioButton rb90min;
        private System.Windows.Forms.RadioButton rb2HourAllMoves;
        private System.Windows.Forms.RadioButton rb60min;
        private System.Windows.Forms.RadioButton rb2hour;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblMinFirst;
        private System.Windows.Forms.Label lblHourFirst;
        private System.Windows.Forms.NumericUpDown numHourFirst;
        private System.Windows.Forms.Label lblGainTimeFirst;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblGainTimeSecond;
        private System.Windows.Forms.Label lblMinuteSecond;
        private System.Windows.Forms.Label lblHourSecond;
        private System.Windows.Forms.NumericUpDown numHourSecond;
        private System.Windows.Forms.NumericUpDown numMinuteSecond;
        private System.Windows.Forms.NumericUpDown numGainSecond;
        private System.Windows.Forms.Label lblGainSecond;
        private System.Windows.Forms.Label lblTimeSecond;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblGainTimeThird;
        private System.Windows.Forms.Label lblMinuteThird;
        private System.Windows.Forms.Label lblHourThird;
        private System.Windows.Forms.NumericUpDown numHourThird;
        private System.Windows.Forms.NumericUpDown numMinuteThird;
        private System.Windows.Forms.NumericUpDown numGainThird;
        private System.Windows.Forms.Label lblGainThird;
        private System.Windows.Forms.Label lblTimeThird;
        private System.Windows.Forms.NumericUpDown numMovesFirst;
        private System.Windows.Forms.Label lblMovesFirst;
        private System.Windows.Forms.NumericUpDown numMovesSecond;
        private System.Windows.Forms.Label lblMovesSecond;
    }
}

