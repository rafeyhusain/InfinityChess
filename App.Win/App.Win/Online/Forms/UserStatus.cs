using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;

namespace App.Win
{
    public partial class UserStatus : Form
    {
        #region ctor
        public UserStatus()
        {
            InitializeComponent();
        } 
        #endregion

        #region Load
        private void UserStatus_Load(object sender, EventArgs e)
        {
            Text = "[" + Ap.CurrentUser.UserName + "] - Status";

            if (Ap.CurrentUser.UserStatusIDE == UserStatusE.Blank)
            {
                lblStatus.Text = "Idle";
            }
            else
            {
                lblStatus.Text = Ap.CurrentUser.UserStatusIDE.ToString();
            }

            lblLoginTime.Text = Ap.CurrentUser.LoginDays.ToString();
        } 
        #endregion

        #region Events Click
        private void btnLogoffUser_Click(object sender, EventArgs e)
        {
            if (MessageForm.Confirm(this, MsgE.ConfirmClosedAllWindow, "") == DialogResult.Yes)
            {
                SocketClient.ForceLogoff(Ap.CurrentUserID);
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion
    }
}
