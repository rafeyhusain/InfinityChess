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
    public partial class BlockedIPDetail : Form
    {
        public int BlockedIPsID = 0;
        private BlockedIP blockedIPs = null;
        public BlockedIPDetail()
        {
            InitializeComponent();
        }
       
        private void BlockedIPDetail_Load(object sender, EventArgs e)
        {
           LoadBlockedIPs();
        }
        public BlockedIP BlockedIPs
        {
            //[System.Diagnostics.DebuggerStepThrough]
            get
            {
                if (blockedIPs == null)
                {
                    try
                    {
                        ProgressForm frm = ProgressForm.Show(this, "Loading BlockedIPs...");

                        blockedIPs = SocketClient.GetBlockedIPByID(BlockedIPsID);

                        frm.Close();
                    }
                    catch (Exception ex)
                    {
                        TestDebugger.Instance.WriteError(ex);
                        MessageForm.Show(ex);
                    }
                    //if (table.Rows.Count > 0)
                    //{
                    //    BlockedIPs = new BlockedIPs(Ap.Cxt, table.Rows[0]);
                    //}
                }

                return blockedIPs;
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                blockedIPs = value;
            }
        }
        public void LoadBlockedIPs()
        {
            if (BlockedIPs == null)
            {
                return;
            }
            mtxtBlockedIP.Text = this.BlockedIPs.IPAddress;
            
            if (this.BlockedIPs.BlockedIPID == 0)
            {
                this.Text = "New BlockedIP";
            }
        }
        
        public void SaveBlockedIPs()
        {
            try
            {
                //int BlockedIPsCategoryID = Convert.ToInt32(cmbBlockedIPsType.SelectedValue);
                //SocketClient.SaveBlockedIPs(txtBlockedIPsName.Text, editor1.HtmlText, BlockedIPsCategoryID, BlockedIPsID);
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }

        
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (mtxtBlockedIP.Text == string.Empty)
            {
                MessageForm.Show(this, MsgE.ErrorEmptyNewsTitle);
            }
            else
            {
                if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, "block", "ip") == DialogResult.Yes)
                {
                    SaveBlockedIP();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
        public void SaveBlockedIP()
        {
            try
            {
                SocketClient.SaveBlockedIP(mtxtBlockedIP.Text, BlockedIPsID);
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Ap.Help(this, HelpTopicIdE.BlockedIPDetail);
        }
        public static DialogResult Show(Form owner, int blockedIPID)
        {
            return Show(owner, blockedIPID, null);
        }

        public static DialogResult Show(Form owner, int blockedIPID, BlockedIP blockedIPs)
        {
            BlockedIPDetail frm = new BlockedIPDetail();
            frm.BlockedIPsID = blockedIPID;
            frm.BlockedIPs = blockedIPs;
            DialogResult result = frm.ShowDialog(owner);

            return result;
        }

        private void pnlBottom_Paint(object sender, PaintEventArgs e)
        {

        }

       
       
       
    }
}
