namespace Design
{
    partial class Editor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.fontComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.fontSizeComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.boldButton = new System.Windows.Forms.ToolStripButton();
            this.italicButton = new System.Windows.Forms.ToolStripButton();
            this.underlineButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.colorButton = new System.Windows.Forms.ToolStripButton();
            this.backColorButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.justifyLeftButton = new System.Windows.Forms.ToolStripButton();
            this.justifyCenterButton = new System.Windows.Forms.ToolStripButton();
            this.justifyRightButton = new System.Windows.Forms.ToolStripButton();
            this.justifyFullButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.orderedListButton = new System.Windows.Forms.ToolStripButton();
            this.unorderedListButton = new System.Windows.Forms.ToolStripButton();
            this.outdentButton = new System.Windows.Forms.ToolStripButton();
            this.indentButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tsbHtml = new System.Windows.Forms.ToolStripButton();
            this.txtHtml = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontComboBox,
            this.fontSizeComboBox,
            this.toolStripSeparator1,
            this.boldButton,
            this.italicButton,
            this.underlineButton,
            this.toolStripSeparator4,
            this.colorButton,
            this.backColorButton,
            this.toolStripSeparator2,
            this.justifyLeftButton,
            this.justifyCenterButton,
            this.justifyRightButton,
            this.justifyFullButton,
            this.toolStripSeparator5,
            this.orderedListButton,
            this.unorderedListButton,
            this.outdentButton,
            this.indentButton,
            this.tsbHtml});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(627, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // fontComboBox
            // 
            this.fontComboBox.Name = "fontComboBox";
            this.fontComboBox.Size = new System.Drawing.Size(121, 25);
            this.fontComboBox.ToolTipText = "Font";
            // 
            // fontSizeComboBox
            // 
            this.fontSizeComboBox.Name = "fontSizeComboBox";
            this.fontSizeComboBox.Size = new System.Drawing.Size(75, 25);
            this.fontSizeComboBox.ToolTipText = "Font Size";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // boldButton
            // 
            this.boldButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.boldButton.Image = ((System.Drawing.Image)(resources.GetObject("boldButton.Image")));
            this.boldButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.boldButton.Name = "boldButton";
            this.boldButton.Size = new System.Drawing.Size(23, 22);
            this.boldButton.Text = "toolStripButton1";
            this.boldButton.ToolTipText = "Bold";
            this.boldButton.Click += new System.EventHandler(this.boldButton_Click);
            // 
            // italicButton
            // 
            this.italicButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.italicButton.Image = ((System.Drawing.Image)(resources.GetObject("italicButton.Image")));
            this.italicButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.italicButton.Name = "italicButton";
            this.italicButton.Size = new System.Drawing.Size(23, 22);
            this.italicButton.Text = "toolStripButton2";
            this.italicButton.ToolTipText = "Italic";
            this.italicButton.Click += new System.EventHandler(this.italicButton_Click);
            // 
            // underlineButton
            // 
            this.underlineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.underlineButton.Image = ((System.Drawing.Image)(resources.GetObject("underlineButton.Image")));
            this.underlineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.underlineButton.Name = "underlineButton";
            this.underlineButton.Size = new System.Drawing.Size(23, 22);
            this.underlineButton.Text = "toolStripButton3";
            this.underlineButton.ToolTipText = "Underline";
            this.underlineButton.Click += new System.EventHandler(this.underlineButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // colorButton
            // 
            this.colorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.colorButton.Image = ((System.Drawing.Image)(resources.GetObject("colorButton.Image")));
            this.colorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(23, 22);
            this.colorButton.Text = "toolStripButton3";
            this.colorButton.ToolTipText = "Font Color";
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // backColorButton
            // 
            this.backColorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.backColorButton.Image = ((System.Drawing.Image)(resources.GetObject("backColorButton.Image")));
            this.backColorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backColorButton.Name = "backColorButton";
            this.backColorButton.Size = new System.Drawing.Size(23, 22);
            this.backColorButton.Text = "toolStripButton3";
            this.backColorButton.ToolTipText = "Back Color";
            this.backColorButton.Click += new System.EventHandler(this.backColorButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // justifyLeftButton
            // 
            this.justifyLeftButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.justifyLeftButton.Image = ((System.Drawing.Image)(resources.GetObject("justifyLeftButton.Image")));
            this.justifyLeftButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.justifyLeftButton.Name = "justifyLeftButton";
            this.justifyLeftButton.Size = new System.Drawing.Size(23, 22);
            this.justifyLeftButton.Text = "Left";
            this.justifyLeftButton.ToolTipText = "Left";
            this.justifyLeftButton.Click += new System.EventHandler(this.justifyLeftButton_Click);
            // 
            // justifyCenterButton
            // 
            this.justifyCenterButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.justifyCenterButton.Image = ((System.Drawing.Image)(resources.GetObject("justifyCenterButton.Image")));
            this.justifyCenterButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.justifyCenterButton.Name = "justifyCenterButton";
            this.justifyCenterButton.Size = new System.Drawing.Size(23, 22);
            this.justifyCenterButton.Text = "Center";
            this.justifyCenterButton.ToolTipText = "Center";
            this.justifyCenterButton.Click += new System.EventHandler(this.justifyCenterButton_Click);
            // 
            // justifyRightButton
            // 
            this.justifyRightButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.justifyRightButton.Image = ((System.Drawing.Image)(resources.GetObject("justifyRightButton.Image")));
            this.justifyRightButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.justifyRightButton.Name = "justifyRightButton";
            this.justifyRightButton.Size = new System.Drawing.Size(23, 22);
            this.justifyRightButton.Text = "Right";
            this.justifyRightButton.ToolTipText = "Right";
            this.justifyRightButton.Click += new System.EventHandler(this.justifyRightButton_Click);
            // 
            // justifyFullButton
            // 
            this.justifyFullButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.justifyFullButton.Image = ((System.Drawing.Image)(resources.GetObject("justifyFullButton.Image")));
            this.justifyFullButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.justifyFullButton.Name = "justifyFullButton";
            this.justifyFullButton.Size = new System.Drawing.Size(23, 22);
            this.justifyFullButton.Text = "Justify";
            this.justifyFullButton.ToolTipText = "Justify";
            this.justifyFullButton.Click += new System.EventHandler(this.justifyFullButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // orderedListButton
            // 
            this.orderedListButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.orderedListButton.Image = ((System.Drawing.Image)(resources.GetObject("orderedListButton.Image")));
            this.orderedListButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.orderedListButton.Name = "orderedListButton";
            this.orderedListButton.Size = new System.Drawing.Size(23, 22);
            this.orderedListButton.Text = "Numbering";
            this.orderedListButton.ToolTipText = "Numbering";
            this.orderedListButton.Click += new System.EventHandler(this.orderedListButton_Click);
            // 
            // unorderedListButton
            // 
            this.unorderedListButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.unorderedListButton.Image = ((System.Drawing.Image)(resources.GetObject("unorderedListButton.Image")));
            this.unorderedListButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.unorderedListButton.Name = "unorderedListButton";
            this.unorderedListButton.Size = new System.Drawing.Size(23, 22);
            this.unorderedListButton.Text = "Bullets";
            this.unorderedListButton.ToolTipText = "Bullets";
            this.unorderedListButton.Click += new System.EventHandler(this.unorderedListButton_Click);
            // 
            // outdentButton
            // 
            this.outdentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.outdentButton.Image = ((System.Drawing.Image)(resources.GetObject("outdentButton.Image")));
            this.outdentButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.outdentButton.Name = "outdentButton";
            this.outdentButton.Size = new System.Drawing.Size(23, 22);
            this.outdentButton.Text = "Decrease Indent";
            this.outdentButton.ToolTipText = "Decrease Indent";
            this.outdentButton.Click += new System.EventHandler(this.outdentButton_Click);
            // 
            // indentButton
            // 
            this.indentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.indentButton.Image = ((System.Drawing.Image)(resources.GetObject("indentButton.Image")));
            this.indentButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.indentButton.Name = "indentButton";
            this.indentButton.Size = new System.Drawing.Size(23, 22);
            this.indentButton.Text = "Increase Indent";
            this.indentButton.ToolTipText = "Increase Indent";
            this.indentButton.Click += new System.EventHandler(this.indentButton_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 23);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 23);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 25);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(627, 125);
            this.webBrowser1.TabIndex = 2;
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
            // 
            // pasteToolStripMenuItem2
            // 
            this.pasteToolStripMenuItem2.Name = "pasteToolStripMenuItem2";
            this.pasteToolStripMenuItem2.Size = new System.Drawing.Size(32, 19);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // pasteToolStripMenuItem1
            // 
            this.pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            this.pasteToolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
            this.pasteToolStripMenuItem1.Text = "Paste";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem1,
            this.copyToolStripMenuItem2,
            this.pasteToolStripMenuItem3,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(106, 92);
            // 
            // cutToolStripMenuItem1
            // 
            this.cutToolStripMenuItem1.Name = "cutToolStripMenuItem1";
            this.cutToolStripMenuItem1.Size = new System.Drawing.Size(105, 22);
            this.cutToolStripMenuItem1.Text = "Cut";
            this.cutToolStripMenuItem1.Click += new System.EventHandler(this.cutToolStripMenuItem1_Click);
            // 
            // copyToolStripMenuItem2
            // 
            this.copyToolStripMenuItem2.Name = "copyToolStripMenuItem2";
            this.copyToolStripMenuItem2.Size = new System.Drawing.Size(105, 22);
            this.copyToolStripMenuItem2.Text = "Copy";
            this.copyToolStripMenuItem2.Click += new System.EventHandler(this.copyToolStripMenuItem2_Click);
            // 
            // pasteToolStripMenuItem3
            // 
            this.pasteToolStripMenuItem3.Name = "pasteToolStripMenuItem3";
            this.pasteToolStripMenuItem3.Size = new System.Drawing.Size(105, 22);
            this.pasteToolStripMenuItem3.Text = "Paste";
            this.pasteToolStripMenuItem3.Click += new System.EventHandler(this.pasteToolStripMenuItem3_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // tsbHtml
            // 
            this.tsbHtml.CheckOnClick = true;
            this.tsbHtml.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHtml.Name = "tsbHtml";
            this.tsbHtml.Size = new System.Drawing.Size(32, 22);
            this.tsbHtml.Text = "Html";
            this.tsbHtml.Click += new System.EventHandler(this.tsbHtml_Click);
            // 
            // txtHtml
            // 
            this.txtHtml.Location = new System.Drawing.Point(8, 33);
            this.txtHtml.Multiline = true;
            this.txtHtml.Name = "txtHtml";
            this.txtHtml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHtml.Size = new System.Drawing.Size(194, 78);
            this.txtHtml.TabIndex = 3;
            this.txtHtml.Visible = false;
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtHtml);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Editor";
            this.Size = new System.Drawing.Size(627, 150);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ToolStripButton boldButton;
        private System.Windows.Forms.ToolStripButton italicButton;
        private System.Windows.Forms.ToolStripComboBox fontComboBox;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripComboBox fontSizeComboBox;
        private System.Windows.Forms.ToolStripButton underlineButton;
        private System.Windows.Forms.ToolStripButton colorButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripButton outdentButton;
        private System.Windows.Forms.ToolStripButton indentButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton backColorButton;
        private System.Windows.Forms.ToolStripButton orderedListButton;
        private System.Windows.Forms.ToolStripButton unorderedListButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton justifyLeftButton;
        private System.Windows.Forms.ToolStripButton justifyCenterButton;
        private System.Windows.Forms.ToolStripButton justifyRightButton;
        private System.Windows.Forms.ToolStripButton justifyFullButton;
        public System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbHtml;
        private System.Windows.Forms.TextBox txtHtml;

    }
}

