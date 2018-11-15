// (c) Copyright RafeySoft, Karachi Pakistan. http://rafeysoft.com
// This source is subject to following License:
// http://rafeysoft.com/Web/Page/ItemEdit.aspx?sid=29&lid=4&cid=23&iid=2143
// Please write to info@rafeysoft.com for more information
// All other rights reserved.

using System;
using App.Model;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace App.Model
{
    public class MessageForm
    {
        #region Show
        public static DialogResult Show(Form owner, string text, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(owner, text, Config.ProductName, buttons, icon);
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

        public static DialogResult Show(Exception ex, string text)
        {
            return Error(text + "\n\n" + ex.Message + "\n\n" + ex.StackTrace);
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
            return Confirm(owner, Msg.GetMsg(msgId,vals));
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
    }
}
