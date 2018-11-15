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
    public partial class LogListUc : UserControl
    {
        public FilterItems Filter = new FilterItems();
        DataTable table = null;
        public LogListUc()
        {
            InitializeComponent();
        }
        public int SelectedLogID
        {
            get
            {
                if (gvLog.DataSource == null)
                {
                    return 0;
                }

                if (gvLog.SelectedCells.Count < 1)
                {
                    return 0;
                }

                return BaseItem.ToInt32(((DataTable)gvLog.DataSource).Rows[gvLog.SelectedCells[0].RowIndex]["LogID"]);
            }
        }

        public string SelectedLogMessage
        {
            get
            {
                if (gvLog.DataSource == null)
                {
                    return "";
                }

                if (gvLog.SelectedCells.Count < 1)
                {
                    return "";
                }

                return BaseItem.ToString(((DataTable)gvLog.DataSource).Rows[gvLog.SelectedCells[0].RowIndex]["Message"]);
            }
        }

        private void LogListUc_Load(object sender, EventArgs e)
        {
            RefreshGrid();
            InitFilter();
        }
        private void InitFilter()
        {
            Filter.Add("Message", "Message");
            Filter.Add("Type", "Type");
            Filter.Add("Category", "Category");
           
            toolStripComboBox1.ComboBox.DataSource = Filter.DataTable;
            toolStripComboBox1.ComboBox.DisplayMember = "Value";
            toolStripComboBox1.ComboBox.ValueMember = "Key";
            toolStripComboBox1.ComboBox.SelectedIndex = 0;
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
            foreach (DataGridViewRow row in gvLog.Rows)
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
        private void RefreshGrid()
        {
            ProgressForm frmProgress = ProgressForm.Show(this, "Loading Logs...");

            try
            {

                gvLog.AutoGenerateColumns = false;

                DataSet ds = SocketClient.GetAllLog();

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

        private void RefreshGrid(DataTable table)
        {
            gvLog.DataSource = Filter.SearchByValue(table, toolStripComboBox1, toolStripTextBox1);
        }
        private void tsbClear_Click(object sender, EventArgs e)
        { 
            try
            {
                if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, "clear", "logs") == DialogResult.Yes)
                {
                    ProgressForm frmProgress = ProgressForm.Show(this, "Removing Logs...");
                    SocketClient.ClearLog();
                    frmProgress.Close();
                    RefreshGrid();
                    MessageForm.Show(this.ParentForm, MsgE.InfoClearLogs);
                }
            }
            catch(Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
            
        }

        private void gvLog_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ViewLogDescription(e);
        }

        private void ViewLogDescription(DataGridViewCellEventArgs e)
        {
            txtLogDetail.Text = SelectedLogMessage;
        }

        private void gvLog_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (table == null)
            {
                return;
            }

            if (table.Rows.Count == 0)
            {
                return;
            }

            switch (e.ColumnIndex)
            {
                case 3:
                    SetDateCreated(e);
                    break;                
            }
        }

        private void SetDateCreated(DataGridViewCellFormattingEventArgs e)
        {
            if (table.Rows[e.RowIndex]["DateCreated"] != null)
            {
                e.Value = Convert.ToDateTime(table.Rows[e.RowIndex]["DateCreated"]);
            }
        }

    }
}
