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
    public partial class IPListUc : UserControl
    {
        public FilterItems Filter = new FilterItems();
        DataTable table = null;
        public IPListUc()
        {
            InitializeComponent();
        }
        public int SelectedBlockedIPID
        {
            get
            {
                if (dataGridView1.DataSource == null)
                {
                    return 0;
                }

                if (dataGridView1.SelectedCells.Count < 1)
                {
                    return 0;
                }

                return BaseItem.ToInt32(((DataTable)dataGridView1.DataSource).Rows[dataGridView1.SelectedCells[0].RowIndex]["BlockedIPID"]);
            }
        }
        public DataTable GridTable
        {
            get { return (DataTable)dataGridView1.DataSource; }
        }

        private void IPListUc_Load(object sender, EventArgs e)
        {
            RefreshGrid();
            InitFilter();
        }
        private void InitFilter()
        {
            Filter.Add("IPAddress", "IP Address");
            
            toolStripComboBox1.ComboBox.DataSource = Filter.DataTable;
            toolStripComboBox1.ComboBox.DisplayMember = "Value";
            toolStripComboBox1.ComboBox.ValueMember = "Key";
        }

        public void RefreshGrid()
        {
            ProgressForm frmProgress = ProgressForm.Show(this, "Loading IPs...");

            try
            {

                dataGridView1.AutoGenerateColumns = false;

                DataSet ds = SocketClient.GetAllBlockedIPs();

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                    }
                    else
                    {
                        table = null;
                    }
                }

                RefreshGrid(table);
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }

            frmProgress.Close();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCheck(true);
        }
        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCheck(false);
        }
        private void SetCheck(bool isCheck)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = isCheck;
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrid(table);
        }
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            RefreshGrid(table);
        }
        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }
        private void RefreshGrid(DataTable table)
        {
            dataGridView1.DataSource = Filter.SearchByValue(table, toolStripComboBox1, toolStripTextBox1);
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            ViewDetail(0);
        }

       
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ViewDetail(SelectedBlockedIPID);
        }
        private void tsbView_Click(object sender, EventArgs e)
        {
            ViewDetail(SelectedBlockedIPID);
        }

        public void ViewDetail(int selectedBlockedIPID)
        {
            DialogResult result =  BlockedIPDetail.Show(this.ParentForm, selectedBlockedIPID, null);
            if (result == DialogResult.OK)
            {
                RefreshGrid();
                MessageForm.Show(this.ParentForm, MsgE.InfoSaveBlockedIP);
            }
        }
        private void tsbUnBlockedIP_Click(object sender, EventArgs e)
        {
            if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, "unblocked", "ips") == DialogResult.Yes)
            {
                UnBlockedIP();
            }
        }
        void UnBlockedIP()
        {

            try
            {
                int i = 0;

                string blockedIPIDs = string.Empty;
                BlockedIpItem ips = new BlockedIpItem();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if ((bool)row.Cells[0].Value)
                        {
                            Int32 blockedIps = BaseItem.ToInt32(GridTable.Rows[i]["BlockedIPID"]);

                            blockedIPIDs += "," + blockedIps.ToString();
                        }
                    }

                    i++;
                }
                if (blockedIPIDs.Length > 0)
                {
                    blockedIPIDs = blockedIPIDs.Remove(0, 1);
                    ProgressForm frmProgress = ProgressForm.Show(this, "UnBlocking IPs...");
                    SocketClient.UnBlockIPs(blockedIPIDs);
                    frmProgress.Close();
                    RefreshGrid();
                    MessageForm.Show(this.ParentForm, MsgE.InfoUnBlockedIPs);
                }
                else
                {
                    MessageForm.Show(this.ParentForm, MsgE.ErrorSelectCheckBox);
                }

            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }
        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell is System.Windows.Forms.DataGridViewCheckBoxCell)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

       
    }
}
