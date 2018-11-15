using System.Windows.Forms;

namespace App.Win
{
    partial class AvClientUc
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cboChatType = new System.Windows.Forms.ComboBox();
            this.btnDial = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Controls.Add(this.cboChatType, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDial, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(175, 24);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cboChatType
            // 
            this.cboChatType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboChatType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboChatType.DropDownHeight = 100;
            this.cboChatType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChatType.DropDownWidth = 100;
            this.cboChatType.FormattingEnabled = true;
            this.cboChatType.IntegralHeight = false;
            this.cboChatType.ItemHeight = 16;
            this.cboChatType.Items.AddRange(new object[] {
            "Voice Chat",
            "Video Chat"});
            this.cboChatType.Location = new System.Drawing.Point(3, 1);
            this.cboChatType.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.cboChatType.Name = "cboChatType";
            this.cboChatType.Size = new System.Drawing.Size(137, 22);
            this.cboChatType.TabIndex = 0;
            this.cboChatType.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.DrawItem);
            // 
            // btnDial
            // 
            this.btnDial.Image = global::InfinityChess.Properties.Resources.PickupCall;
            this.btnDial.Location = new System.Drawing.Point(143, 0);
            this.btnDial.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnDial.Name = "btnDial";
            this.btnDial.Size = new System.Drawing.Size(29, 24);
            this.btnDial.TabIndex = 1;
            this.btnDial.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDial.UseVisualStyleBackColor = true;
            this.btnDial.Click += new System.EventHandler(this.btnDial_Click);
            // 
            // AVClientCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AvClientUc";
            this.Size = new System.Drawing.Size(175, 24);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ComboBox cboChatType;
        private Button btnDial;

    }
}
