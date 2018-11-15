using System; using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using App.Model.Db;

namespace App.Win
{
    public partial class ForgotPasswordForm : BaseWinForm
    {

        public ForgotPasswordForm()
        {
            InitializeComponent();
        }

        private void ForgotPasswordForm_Load(object sender, EventArgs e)
        {          

            
        }

              
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }    
        
        private void btnForgotPwd_Click(object sender, EventArgs e)
        {

        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            
            DataSet ds = SocketClient.ForgotPassword(txtUserName.Text);
            bool update = false;
            if (ds != null && ds.Tables.Count > 0)
                {
                   Kv kv = new Kv(ds.Tables[0]);
                    update = kv.GetBool("Updated");
                }

                if (update)
                {
                    MessageForm.Show(this,MsgE.InfoCheckEmail);                    
                }
                else
                {
                    //MessageForm.Show("");
                }
                this.Close();
        }
        public override string HelpTopicId
        {
            get { return "180"; }
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            Ap.Help(this, HelpTopicIdE.ForgetPasswordForm);
        }
            
    }
}