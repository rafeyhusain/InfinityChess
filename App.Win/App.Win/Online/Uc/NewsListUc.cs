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
    public partial class NewsListUc : UserControl
    {
        public FilterItems Filter = new FilterItems();
        DataTable table = null;
        public NewsListUc()
        {
            InitializeComponent();
        }
        public int SelectedNewsID
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

                return BaseItem.ToInt32(((DataTable)dataGridView1.DataSource).Rows[dataGridView1.SelectedCells[0].RowIndex]["NewsID"]);
            }
        }
        public DataTable GridTable
        {
            get { return (DataTable)dataGridView1.DataSource; }
        }

        private void NewsListUc_Load(object sender, EventArgs e)
        {
            RefreshGrid();
            InitFilter();
        }
        private void InitFilter()
        {
            Filter.Add("Name", "News Name");
            Filter.Add("Status", "Status");

            toolStripComboBox1.ComboBox.DataSource = Filter.DataTable;
            toolStripComboBox1.ComboBox.DisplayMember = "Value";
            toolStripComboBox1.ComboBox.ValueMember = "Key";
            toolStripComboBox1.ComboBox.SelectedIndex = 0;
        }

        public void RefreshGrid()
        {
            ProgressForm frmProgress = ProgressForm.Show(this, "Loading News...");

            try
            {

                dataGridView1.AutoGenerateColumns = false;

                DataSet ds = SocketClient.GetAllNews();

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

        private void tsbView_Click(object sender, EventArgs e)
        {
            ViewDetail(SelectedNewsID);
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ViewDetail(SelectedNewsID);
        }

        public void ViewDetail(int selectedNewsID)
        {
            DialogResult result = NewsDetail.Show(this.ParentForm, selectedNewsID, null);
            if (result == DialogResult.OK)
            {
                RefreshGrid();
                MessageForm.Show(this.ParentForm, MsgE.InfoSaveNews);
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
        private void avtiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateNewsStatus(StatusE.Active);
        }
        private void inActiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateNewsStatus(StatusE.Inactive);
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateNewsStatus(StatusE.Deleted);
        }
        void UpdateNewsStatus(StatusE statusID)
        {

            try
            {
                int i = 0;

                string newsIDs = string.Empty;
                NewsItems news = new NewsItems();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if ((bool)row.Cells[0].Value)
                        {
                            Int32 newsId = BaseItem.ToInt32(GridTable.Rows[i]["NewsID"]);

                            newsIDs += "," + newsId.ToString();
                        }
                    }

                    i++;
                }
                if (newsIDs.Length > 0)
                {
                    newsIDs = newsIDs.Remove(0, 1);

                    if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, statusID.ToString().ToLower(), "news") == DialogResult.Yes)
                    {
                        ProgressForm frmProgress = ProgressForm.Show(this, "Updating News Status...");
                        SocketClient.UpdateNewsStatus(statusID, newsIDs);
                        frmProgress.Close();
                        RefreshGrid();
                        MessageForm.Show(this.ParentForm, MsgE.InfoNewsUpdate);
                    }
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

       
    }
}
