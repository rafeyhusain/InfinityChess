using System;
using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using App.Model.Db;
using InfinityChess.InfinityChesshelp;

namespace App.Win
{
    public partial class LoginForm : BaseWinForm
    {

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            linkLabel1.Visible = Config.IsDev;
            linkLabel2.Visible = Config.IsDev;
            SocketClient.Instance.Connect();

            Options.Instance.Load();
            txtLoginId.Text = Options.Instance.LoginID;
            txtPassword.Text = Options.Instance.Password;
            if (!String.IsNullOrEmpty(Options.Instance.Password))
            {
                chkRemindPassword.Checked = true;
            }
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            this.Close();

            UserData.Show(this, 0, null, false);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ProgressForm frm = ProgressForm.Show(this, "Verifying Username and Password ...");

            LoginUser();

            frm.Close();
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            LoginGuest();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        #region Helper
        private void LoginUser()
        {
            LoginUser(txtLoginId.Text, txtPassword.Text);
        }

        bool IsValidUser(Kv kv, int statusID)
        {
            bool isTrue = false;
            Kv kv1 = new Kv(kv.GetDataTable("Msg"));
            DataTable dt = kv1.DataTable;
            int msgID = Convert.ToInt32(dt.Rows[0][0]);
            string serverMaintainceDateTime = KeyValues.Instance.GetKeyValue(KeyValueE.ServerMaintainceDateTime).Value;
            if (statusID == 5)
            {
                MessageForm.Error(this, MsgE.ErrorBannedForever, Ap.CurrentUser.UserName);
                isTrue = true;
            }
            else if (statusID == 0)
            {
                DateTime dt1 = Convert.ToDateTime(dt.Rows[0][1]);
                DateTime dt2 = Convert.ToDateTime(dt.Rows[0][2]);
                MessageForm.Error(this, MsgE.InfoBaned, dt1.ToString(), dt2.ToString());
                isTrue = true;
            }
            else if (statusID == 7)
            {
                MessageForm.Error(this, MsgE.WrongIdPassowrd);
                isTrue = true;
            }
            else if (statusID == 8)
            {
                MessageForm.Error(this, MsgE.NoRoles);
            }
            else if (serverMaintainceDateTime != string.Empty)
            {
                isTrue = true;
                MessageForm.Error(this.ParentForm, MsgE.ErrorServerMaintainceMode, serverMaintainceDateTime);
            }
            else if (statusID == 6)
            {
                MessageForm.Error(this, MsgE.BlockIp);
                isTrue = true;
            }
            else
            {
                isTrue = false;
            }
            return isTrue;
        }

        private void LoginUser(string loginId, string password)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtLoginId.Text) && !String.IsNullOrEmpty(txtPassword.Text))
                {
                    DataSet ds = SocketClient.LoginUser(loginId, password, Options.Instance.ApplicationCode);

                    if (ds != null && ds.Tables.Count > 0)
                    {
                        Kv kv = new Kv(ds.Tables[0]);

                        int statusID = User.LoginMsg(kv, false);

                        Srv.SetCurrentUser(kv);

                        if (IsValidUser(kv, statusID))
                        {
                            return;
                        }

                        if (Ap.CurrentUser.UserStatusIDE != UserStatusE.Gone)
                        {
                            UserStatus frm = new UserStatus();
                            frm.ShowDialog();
                            return;
                        }

                        SocketClient.LoginUser(Ap.CurrentUserID, UserStatusE.Blank);

                        if (chkRemindPassword.Checked)
                        {
                            Options.Instance.LoginID = loginId;
                            Options.Instance.Password = password;
                        }
                        else
                        {
                            Options.Instance.LoginID = "";
                            Options.Instance.Password = "";
                        }
                        Options.Instance.Save();

                        LoadOnlineClient();
                    }
                    else
                    {
                        MessageForm.Error(this, MsgE.ErrorServerConnection);
                    }
                }
                else
                {
                    MessageForm.Error(this, MsgE.ErrorEmptyIdPassword);
                }
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }

        OnlineClient frmOnlineClient;
        private void LoadOnlineClient()
        {
            ApWin.StartupForm.Visible = false;

            this.Visible = false;

            frmOnlineClient = new OnlineClient();

            frmOnlineClient.Show();
        }

        private void LoginGuest()
        {
            try
            {
                DataSet ds = SocketClient.LoginGuest();

                if (ds != null && ds.Tables.Count > 0)
                {
                    Kv kv = new Kv(ds.Tables[0]);

                    int statusID = User.LoginMsg(kv, true);

                    Srv.SetCurrentUser(kv);

                    //if (IsValidUser(kv, statusID))
                    //{
                    //    return;
                    //}
                    //if (LoginMsg(kv1))
                    //{
                    //    return;
                    //}

                    //Srv.SetCurrentUser(kv);

                    SocketClient.LoginUser(Ap.CurrentUserID, UserStatusE.Blank);

                    Options.Instance.LoginID = "Guest";
                    Options.Instance.Password = "";
                    Options.Instance.Save();

                    ApWin.StartupForm.Visible = false;
                    this.Visible = false;
                    this.Close();
                    OnlineClient frm = new OnlineClient();
                    frm.Show();

                }
                else
                {
                    MessageForm.Error(this, MsgE.ErrorServerConnection);
                }
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }

        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtLoginId.Text = Config.User1Name;
            txtPassword.Text = Config.User1Password;
            LoginUser(Config.User1Name, Config.User1Password);
        }


        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtLoginId.Text = Config.User2Name;
            txtPassword.Text = Config.User2Password;
            LoginUser(Config.User2Name, Config.User2Password);
        }

        private void btnForgotPwd_Click(object sender, EventArgs e)
        {


        }

        private void txtLoginId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPasswordForm forgotPasswordForm = new ForgotPasswordForm();
            forgotPasswordForm.ControlBox = false;
            forgotPasswordForm.ShowDialog();
        }
        public override string HelpTopicId
        {
            get { return "240"; }
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            Ap.Help(this, HelpTopicIdE.LoginForm);
        }
    }
}