using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;
using App.Model.Db;

namespace App.Win
{
    public partial class SendMessage : Form
    {
        #region DataMember
        public string To = String.Empty;
        public string Subject = String.Empty;
        public string BodyText = String.Empty;
        public bool IsReply = false;
        #endregion

        public SendMessage()
        {
            InitializeComponent();
        }

        private void SendMessage_Load(object sender, EventArgs e)
        {
            if (IsReply)
            {
                txtTo.Text = To;
                txtSubject.Text = "RE : " + Subject;
                editor1.BodyHtml = BodyText;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTo.Text))
            {
                return;
            }

            DataSet ds = SocketClient.CheckUserId(txtTo.Text);
            if (ds != null && ds.Tables.Count > 0)
            {
                Kv kv1 = new Kv();
                kv1 = new Kv(ds.Tables[0]);
                bool isExist = kv1.GetBool("IsExist");
                if (!isExist)
                {
                    MessageForm.Error(this, MsgE.ErrorUserNotExist, txtTo.Text);
                    return;
                }
            }
            else
            {
                MessageForm.Error(this, MsgE.ErrorServerConnection);
                return;
            }

            UserMessageDataKv messageKv = new UserMessageDataKv();

            messageKv.UserIDFrom = Ap.CurrentUserID;
            messageKv.UserIDTo = 0;
            messageKv.UserNameTo = txtTo.Text;
            messageKv.Subject = txtSubject.Text;
            messageKv.Text = editor1.BodyHtml;
            messageKv.EmailTime = DateTime.Now;
            messageKv.Size = UStr.ToBytes(editor1.BodyHtml).Length;
            messageKv.StatusIDFromE = StatusE.Active;
            messageKv.StatusIDToE = StatusE.Active;
            SocketClient.SendEmail(messageKv);

            MessageForm.Show(this, MsgE.InfoEmailSend);

            this.Close();
        }
    }
}
