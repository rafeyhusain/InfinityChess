using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;
using System.Text.RegularExpressions;

namespace App.Win
{
    public partial class ChangePassword : Form
    {
        #region Data Members
        private UserDataKv userkv = null;
        #endregion

        #region Properties
        public bool IsNew
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return (Ap.CurrentUserID == 0 || Ap.CurrentUserID == -1); }
        }
        public UserDataKv UserKv
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                if (userkv == null)
                {
                    if (IsNew)
                    {
                        userkv = UserDataKv.Instance;
                    }
                }

                return userkv;
            }
        }
        #endregion

        public ChangePassword()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPassword.Text) && String.IsNullOrEmpty(txtRetypePassword.Text))
            {
                MessageForm.Error(this,MsgE.ErrorEnterPassword);
                return;
            }
            else if (txtPassword.Text.Length < 5)
            {
                MessageForm.Error(this,MsgE.ErrorPasswordLimit);
                return;
            }
            else if (txtPassword.Text != txtRetypePassword.Text)
            {
                MessageForm.Error(this,MsgE.ErrorPasswordMismatch);
                return;
            }
            else if (txtPassword.Text.Contains(" "))
            {
                MessageForm.Error(this,MsgE.ErrorSpacing);
                return;
            }

            //Regex reg = new Regex(@"^[a-zA-Z0-9]+$");
            //Match mt = reg.Match(txtPassword.Text);
            //if (!mt.Success)
            //{
            //    MessageForm.Show("Invalid Password Entered");
            //    return;
            //}

            if (IsNew)
            {
                Save();
            }
            else
            {
                Update();
            }
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            LoadUi();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Helper
        private void LoadUi()
        {
            if (IsNew)
            {
                label1.Visible = false;
                txtOldPassword.Visible = false;
                txtPassword.Focus();
            }
            else
                txtOldPassword.Focus();
        }

        private new void Update()
        {
            if (String.IsNullOrEmpty(txtOldPassword.Text))
            {
                MessageForm.Error(this,MsgE.ErrorEmptyOldPassword);
                return;
            }
            else if (UCrypto.Encrypt(txtOldPassword.Text) != Ap.CurrentUser.Password)
            {
                MessageForm.Error(this,MsgE.ErrorWrongOldPassword);
                return;
            }

            DataSet ds = SocketClient.ChangePassword(txtPassword.Text, txtPasswordHint.Text);
            bool update = false;

            if (ds != null && ds.Tables.Count > 0)
            {
                Kv kv = new Kv(ds.Tables[0]);
                update = kv.GetBool("Updated");
            }
            
            if (update)
            {
                MessageForm.Show(this,MsgE.InfoUpdatePassword);

                Ap.CurrentUser.Password = UCrypto.Encrypt(txtPassword.Text);
                Ap.CurrentUser.PasswordHint = txtPasswordHint.Text;
            }
            else
            {
                MessageForm.Error(this,MsgE.ErrorUpdatePassword);
            }
            this.Close();
        }

        private void Save()
        {
            UserKv.Password = UCrypto.Encrypt(txtPassword.Text);
            UserKv.PasswordHint = txtPasswordHint.Text;
            
            DataSet ds = SocketClient.AddUser(UserKv); 
            if (ds != null && ds.Tables.Count > 0)
            {
                Kv kv = new Kv(ds.Tables[0]);
                Srv.SetCurrentUser(kv);
                SocketClient.LoginUser(Ap.CurrentUserID, UserStatusE.Blank); 
                this.Visible = false;                
                ApWin.StartupForm.Visible = false;
                OnlineClient frm = new OnlineClient();
                frm.Show();
            }
            this.Close();
        } 

        #endregion

        
    }
}
