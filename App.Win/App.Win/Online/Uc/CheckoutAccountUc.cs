using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;
using System.Configuration;
using App.Model.Db;

namespace App.Win
{
    public partial class CheckoutAccountUc : UserControl
    {
        public CheckoutAccountUc()
        {
            InitializeComponent();
        }

        private void btnSubmitKey_Click(object sender, EventArgs e)
        {
            DataSet ds = SocketClient.CheckoutAccount(txtVoucherNo.Text);

            MsgE msgID = UserVoucher.GetMessage(ds);

            if (msgID != MsgE.VoucherInvalid)
            {
                lblcp.Text = ds.Tables[0].Rows[2][1].ToString();
                lblExpDate2.Text = ds.Tables[0].Rows[3][1].ToString();
                if (msgID == MsgE.CreditCardValid)
                {
                    MessageForm.Show(this.ParentForm, msgID);
                    this.ParentForm.Close();
                }
            }
            else
            {
                MessageForm.Show(this.ParentForm, msgID);
            }            
        }

        private void CheckoutAccountUc_Load(object sender, EventArgs e)
        {
            DataSet dsUser = SocketClient.GetUserById(Ap.CurrentUser.UserID);

            if (dsUser != null && dsUser.Tables.Count > 0)
            {
                if (dsUser.Tables[0].Rows.Count > 0)
                {
                    User user = new User(Ap.Cxt, dsUser.Tables[0].Rows[0]);

                    lblcp.Text = user.Fini.ToString();
                }
            }
        }
    }
}
