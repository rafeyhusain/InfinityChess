namespace App.Win
{
    partial class ChatUc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatUc));
            this.btnSendMsg = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbHappy = new System.Windows.Forms.ToolStripButton();
            this.tsbWink = new System.Windows.Forms.ToolStripButton();
            this.tsbSad = new System.Windows.Forms.ToolStripButton();
            this.tsbAngry = new System.Windows.Forms.ToolStripButton();
            this.tsbSurprised = new System.Windows.Forms.ToolStripButton();
            this.tsbKiss = new System.Windows.Forms.ToolStripButton();
            this.tsbQuestion = new System.Windows.Forms.ToolStripButton();
            this.tsbLaughing = new System.Windows.Forms.ToolStripButton();
            this.tsbSleep = new System.Windows.Forms.ToolStripButton();
            this.tsbUnfair = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnEmotion = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.avClientUc1 = new App.Win.AvClientUc();
            this.cbAudienceType = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.CausesValidation = false;
            this.btnSendMsg.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSendMsg.Location = new System.Drawing.Point(451, 0);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(44, 23);
            this.btnSendMsg.TabIndex = 2;
            this.btnSendMsg.Text = "Send";
            this.btnSendMsg.UseVisualStyleBackColor = true;
            this.btnSendMsg.Click += new System.EventHandler(this.btnSendMsg_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbHappy,
            this.tsbWink,
            this.tsbSad,
            this.tsbAngry,
            this.tsbSurprised,
            this.tsbKiss,
            this.tsbQuestion,
            this.tsbLaughing,
            this.tsbSleep,
            this.tsbUnfair});
            this.toolStrip1.Location = new System.Drawing.Point(0, 287);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(503, 25);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Visible = false;
            // 
            // tsbHappy
            // 
            this.tsbHappy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbHappy.Image = ((System.Drawing.Image)(resources.GetObject("tsbHappy.Image")));
            this.tsbHappy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHappy.Name = "tsbHappy";
            this.tsbHappy.Size = new System.Drawing.Size(23, 22);
            this.tsbHappy.Text = "Happy :)";
            this.tsbHappy.ToolTipText = "Happy :)";
            this.tsbHappy.Click += new System.EventHandler(this.tsbHappy_Click);
            // 
            // tsbWink
            // 
            this.tsbWink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbWink.Image = ((System.Drawing.Image)(resources.GetObject("tsbWink.Image")));
            this.tsbWink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbWink.Name = "tsbWink";
            this.tsbWink.Size = new System.Drawing.Size(23, 22);
            this.tsbWink.Text = "Wink ;)";
            this.tsbWink.ToolTipText = "Wink ;)";
            this.tsbWink.Click += new System.EventHandler(this.tsbWink_Click);
            // 
            // tsbSad
            // 
            this.tsbSad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSad.Image = ((System.Drawing.Image)(resources.GetObject("tsbSad.Image")));
            this.tsbSad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSad.Name = "tsbSad";
            this.tsbSad.Size = new System.Drawing.Size(23, 22);
            this.tsbSad.Text = "Sad :(";
            this.tsbSad.Click += new System.EventHandler(this.tsbSad_Click);
            // 
            // tsbAngry
            // 
            this.tsbAngry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAngry.Image = ((System.Drawing.Image)(resources.GetObject("tsbAngry.Image")));
            this.tsbAngry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAngry.Name = "tsbAngry";
            this.tsbAngry.Size = new System.Drawing.Size(23, 22);
            this.tsbAngry.Text = "Angry :@";
            this.tsbAngry.Click += new System.EventHandler(this.tsbAngry_Click);
            // 
            // tsbSurprised
            // 
            this.tsbSurprised.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSurprised.Image = ((System.Drawing.Image)(resources.GetObject("tsbSurprised.Image")));
            this.tsbSurprised.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSurprised.Name = "tsbSurprised";
            this.tsbSurprised.Size = new System.Drawing.Size(23, 22);
            this.tsbSurprised.Text = "Surprised :-O";
            this.tsbSurprised.Click += new System.EventHandler(this.tsbSurprised_Click);
            // 
            // tsbKiss
            // 
            this.tsbKiss.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbKiss.Image = ((System.Drawing.Image)(resources.GetObject("tsbKiss.Image")));
            this.tsbKiss.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbKiss.Name = "tsbKiss";
            this.tsbKiss.Size = new System.Drawing.Size(23, 22);
            this.tsbKiss.Text = "Kiss (K)";
            this.tsbKiss.Click += new System.EventHandler(this.tsbKiss_Click);
            // 
            // tsbQuestion
            // 
            this.tsbQuestion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbQuestion.Image = ((System.Drawing.Image)(resources.GetObject("tsbQuestion.Image")));
            this.tsbQuestion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQuestion.Name = "tsbQuestion";
            this.tsbQuestion.Size = new System.Drawing.Size(23, 22);
            this.tsbQuestion.Text = "Question :?";
            this.tsbQuestion.Click += new System.EventHandler(this.tsbQuestion_Click);
            // 
            // tsbLaughing
            // 
            this.tsbLaughing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLaughing.Image = ((System.Drawing.Image)(resources.GetObject("tsbLaughing.Image")));
            this.tsbLaughing.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLaughing.Name = "tsbLaughing";
            this.tsbLaughing.Size = new System.Drawing.Size(23, 22);
            this.tsbLaughing.Text = "Laughing :D";
            this.tsbLaughing.Click += new System.EventHandler(this.tsbLaughing_Click);
            // 
            // tsbSleep
            // 
            this.tsbSleep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSleep.Image = ((System.Drawing.Image)(resources.GetObject("tsbSleep.Image")));
            this.tsbSleep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSleep.Name = "tsbSleep";
            this.tsbSleep.Size = new System.Drawing.Size(23, 22);
            this.tsbSleep.Text = "Sleep :-)";
            this.tsbSleep.Click += new System.EventHandler(this.tsbSleep_Click);
            // 
            // tsbUnfair
            // 
            this.tsbUnfair.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUnfair.Image = ((System.Drawing.Image)(resources.GetObject("tsbUnfair.Image")));
            this.tsbUnfair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUnfair.Name = "tsbUnfair";
            this.tsbUnfair.Size = new System.Drawing.Size(23, 22);
            this.tsbUnfair.Text = "Unfair :|";
            this.tsbUnfair.Click += new System.EventHandler(this.tsbUnfair_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtMessage);
            this.panel1.Controls.Add(this.btnEmotion);
            this.panel1.Controls.Add(this.btnSendMsg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 255);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 23);
            this.panel1.TabIndex = 12;
            // 
            // txtMessage
            // 
            this.txtMessage.CausesValidation = false;
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessage.Location = new System.Drawing.Point(0, 0);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(428, 20);
            this.txtMessage.TabIndex = 5;
            this.txtMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessage_KeyPress);
            // 
            // btnEmotion
            // 
            this.btnEmotion.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEmotion.Image = ((System.Drawing.Image)(resources.GetObject("btnEmotion.Image")));
            this.btnEmotion.Location = new System.Drawing.Point(428, 0);
            this.btnEmotion.Name = "btnEmotion";
            this.btnEmotion.Size = new System.Drawing.Size(23, 23);
            this.btnEmotion.TabIndex = 4;
            this.btnEmotion.UseVisualStyleBackColor = true;
            this.btnEmotion.Click += new System.EventHandler(this.btnEmotion_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 229);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(495, 26);
            this.panel2.TabIndex = 13;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Controls.Add(this.avClientUc1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbAudienceType, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(495, 26);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // avClientUc1
            // 
            this.avClientUc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.avClientUc1.Location = new System.Drawing.Point(348, 0);
            this.avClientUc1.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.avClientUc1.Name = "avClientUc1";
            this.avClientUc1.Size = new System.Drawing.Size(147, 26);
            this.avClientUc1.TabIndex = 11;
            // 
            // cbAudienceType
            // 
            this.cbAudienceType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbAudienceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudienceType.FormattingEnabled = true;
            this.cbAudienceType.Items.AddRange(new object[] {
            ""});
            this.cbAudienceType.Location = new System.Drawing.Point(0, 1);
            this.cbAudienceType.Margin = new System.Windows.Forms.Padding(0, 1, 3, 3);
            this.cbAudienceType.Name = "cbAudienceType";
            this.cbAudienceType.Size = new System.Drawing.Size(342, 21);
            this.cbAudienceType.TabIndex = 10;
            this.cbAudienceType.SelectedIndexChanged += new System.EventHandler(this.cbAudienceType_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(495, 229);
            this.panel3.TabIndex = 14;
            // 
            // ChatUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(495, 278);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ChatUc";
            this.Load += new System.EventHandler(this.ChatUc_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendMsg;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripButton tsbHappy;
        private System.Windows.Forms.ToolStripButton tsbWink;
        private System.Windows.Forms.ToolStripButton tsbSad;
        private System.Windows.Forms.ToolStripButton tsbAngry;
        private System.Windows.Forms.ToolStripButton tsbSurprised;
        private System.Windows.Forms.ToolStripButton tsbKiss;
        private System.Windows.Forms.ToolStripButton tsbQuestion;
        private System.Windows.Forms.ToolStripButton tsbLaughing;
        private System.Windows.Forms.ToolStripButton tsbSleep;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnEmotion;
        private System.Windows.Forms.ToolStripButton tsbUnfair;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private AvClientUc avClientUc1;
        private System.Windows.Forms.ComboBox cbAudienceType;
    }
}
