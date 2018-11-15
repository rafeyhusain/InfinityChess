using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;
using App.Model.Db;
namespace App.Win
{
    public partial class BlockedIPDetailUc : UserControl
    {
        public int BlockedIPsID = 0;
        private BlockedIP blockedIPs = null;
        public BlockedIPDetailUc()
        {
            InitializeComponent();
        }
       
        public BlockedIP BlockedIPs
        {
            //[System.Diagnostics.DebuggerStepThrough]
            get
            {
                if (BlockedIPs == null)
                {
                    try
                    {
                        ProgressForm frm = ProgressForm.Show(this, "Loading BlockedIPs...");

                        //BlockedIPs = SocketClient.GetBlockedIPsByID(BlockedIPsID);

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

                return BlockedIPs;
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                BlockedIPs = value;
            }
        }

        private void BlockedIPDetailUc_Load(object sender, EventArgs e)
        {
            FillBlockedIPsCategoryCombo();

            LoadBlockedIPs();
        }

        public void LoadBlockedIPs()
        {
            if (BlockedIPs == null)
            {
                return;
            }

            //txtBlockedIPsName.Text = this.BlockedIPs.Name;
            //editor1.HtmlText = this.BlockedIPs.Description;

            if (this.BlockedIPs.BlockedIPID == 0)
            {
                this.ParentForm.Text = "New BlockedIPs";
            }
        }

        public void FillBlockedIPsCategoryCombo()
        {
            try
            {
                //DataSet ds = SocketClient.GetAllBlockedIPsCategory();
                //if (ds != null)
                //{
                //    cmbBlockedIPsType.DataSource = ds.Tables[0];
                //    cmbBlockedIPsType.DisplayMember = "Name";
                //    cmbBlockedIPsType.ValueMember = "BlockedIPsCategoryID";
                //    if (this.BlockedIPs.BlockedIPsCategoryID > 0)
                //    {
                //        cmbBlockedIPsType.SelectedValue = this.BlockedIPs.BlockedIPsCategoryID;
                //    }
                //}
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }
       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        
    }
}
