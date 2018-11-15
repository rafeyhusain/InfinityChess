namespace App.Win
{
    partial class RoomDetailUc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomDetailUc));
            this.txtName = new System.Windows.Forms.TextBox();
            this.chkIsGuestAllow = new System.Windows.Forms.CheckBox();
            this.chkCanMoveBack = new System.Windows.Forms.CheckBox();
            this.chkIsUrlBit = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbParentRoom = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.editor1 = new Design.Editor();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(102, 23);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(236, 20);
            this.txtName.TabIndex = 0;
            // 
            // chkIsGuestAllow
            // 
            this.chkIsGuestAllow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIsGuestAllow.AutoSize = true;
            this.chkIsGuestAllow.Location = new System.Drawing.Point(102, 320);
            this.chkIsGuestAllow.Name = "chkIsGuestAllow";
            this.chkIsGuestAllow.Size = new System.Drawing.Size(172, 17);
            this.chkIsGuestAllow.TabIndex = 3;
            this.chkIsGuestAllow.Text = "Guests are allowed in this room";
            this.chkIsGuestAllow.UseVisualStyleBackColor = true;
            // 
            // chkCanMoveBack
            // 
            this.chkCanMoveBack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCanMoveBack.AutoSize = true;
            this.chkCanMoveBack.Location = new System.Drawing.Point(102, 345);
            this.chkCanMoveBack.Name = "chkCanMoveBack";
            this.chkCanMoveBack.Size = new System.Drawing.Size(209, 17);
            this.chkCanMoveBack.TabIndex = 4;
            this.chkCanMoveBack.Text = "Move take back is allowed in this room";
            this.chkCanMoveBack.UseVisualStyleBackColor = true;
            // 
            // chkIsUrlBit
            // 
            this.chkIsUrlBit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIsUrlBit.AutoSize = true;
            this.chkIsUrlBit.Location = new System.Drawing.Point(102, 370);
            this.chkIsUrlBit.Name = "chkIsUrlBit";
            this.chkIsUrlBit.Size = new System.Drawing.Size(200, 17);
            this.chkIsUrlBit.TabIndex = 5;
            this.chkIsUrlBit.Text = "Above text box is a websites address";
            this.chkIsUrlBit.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Description:";
            // 
            // cmbParentRoom
            // 
            this.cmbParentRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParentRoom.FormattingEnabled = true;
            this.cmbParentRoom.Location = new System.Drawing.Point(102, 56);
            this.cmbParentRoom.Name = "cmbParentRoom";
            this.cmbParentRoom.Size = new System.Drawing.Size(430, 21);
            this.cmbParentRoom.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Parent Room:";
            // 
            // editor1
            // 
            this.editor1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.editor1.BodyHtml = null;
            this.editor1.BodyText = null;
            this.editor1.DocumentText = resources.GetString("editor1.DocumentText");
            this.editor1.EditorBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.editor1.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.editor1.FontName = null;
            this.editor1.FontSize = Design.FontSize.NA;
            this.editor1.HtmlText = null;
            this.editor1.Location = new System.Drawing.Point(102, 90);
            this.editor1.Name = "editor1";
            this.editor1.Size = new System.Drawing.Size(744, 209);
            this.editor1.TabIndex = 8;
            // 
            // RoomDetailUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbParentRoom);
            this.Controls.Add(this.editor1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkIsUrlBit);
            this.Controls.Add(this.chkCanMoveBack);
            this.Controls.Add(this.chkIsGuestAllow);
            this.Controls.Add(this.txtName);
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Name = "RoomDetailUc";
            this.Size = new System.Drawing.Size(863, 403);
            this.Load += new System.EventHandler(this.RoomDetailUc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox chkIsGuestAllow;
        private System.Windows.Forms.CheckBox chkCanMoveBack;
        private System.Windows.Forms.CheckBox chkIsUrlBit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Design.Editor editor1;
        private System.Windows.Forms.ComboBox cmbParentRoom;
        private System.Windows.Forms.Label label3;

    }
}
