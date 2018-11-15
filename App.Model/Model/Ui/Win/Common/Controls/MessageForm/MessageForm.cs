using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace App.Model
{
    public partial class MessageForm : Form
    {
        #region Ctor
        public MessageForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public string Message
        {
            [DebuggerStepThrough]
            get { return txtMessage.Text; }
            [DebuggerStepThrough]
            set { txtMessage.Text = value; }
        }
        #endregion

        #region Helpers
        #region Show
        public static DialogResult Show(Form owner, string text, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            if (UStr.LineCount(text) <= 15)
            {
                return MessageBox.Show(owner, text, Config.ProductName, buttons, icon);
            }
            else
            {
                return MessageForm.Open(owner, text);
            }
        }

        public static DialogResult Open(Form owner, string message)
        {
            MessageForm frm = new MessageForm();

            frm.Message = message;

            return frm.ShowDialog(owner);
        }

        public static DialogResult Show(string text, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return Show(null, text, buttons, icon);
        }

        public static DialogResult Show(string text)
        {
            return Show(text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Error
        public static DialogResult Error(string text)
        {
            return Show(text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult Show(Exception ex)
        {
            return Show(ex, "");
        }

        public static DialogResult Show(Exception ex, string message)
        {
            return Error(AppException.GetError(ex, message));
        }

        #endregion

        #region Confirm
        public static DialogResult Confirm(string text)
        {
            return MessageForm.Confirm(null, text);
        }

        public static DialogResult Confirm(Form owner, string text)
        {
            return MessageBox.Show(owner, text, Config.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        #endregion

        #region MsgE
        #region Confirm

        public static DialogResult Confirm(Form owner, MsgE msgId, params object[] vals)
        {
            return Confirm(owner, Msg.GetMsg(msgId, vals));
        }

        #endregion

        #region Show
        public static DialogResult Show2(Form owner, MsgE msgId, MessageBoxButtons buttons, MessageBoxIcon icon, params object[] vals)
        {
            try
            {
                return MessageBox.Show(owner, Msg.GetMsg(msgId, vals), Config.ProductName, buttons, icon);     // due to cross thread use try..DA
            }
            catch
            {
            }
            return DialogResult.None;
        }

        public static DialogResult Show(Form owner, MsgE msgId, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return Show2(owner, msgId, buttons, icon);
        }

        public static DialogResult Show(Form owner, MsgE msgId, params object[] vals)
        {
            return Show2(owner, msgId, MessageBoxButtons.OK, MessageBoxIcon.Information, vals);
        }

        public static DialogResult Show(Form owner, MsgE msgId)
        {
            return Show(owner, msgId, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Error
        public static DialogResult Error(Form owner, MsgE msgId, params object[] vals)
        {
            return Show2(owner, msgId, MessageBoxButtons.OK, MessageBoxIcon.Error, vals);
        }

        #endregion


        #endregion
        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
            this.Text = Config.ProductName;
        }
    }
}
