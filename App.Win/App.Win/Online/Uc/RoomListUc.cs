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
    public partial class RoomListUc : UserControl
    {
        public FilterItems Filter = new FilterItems();
        DataTable table = null;
        public RoomListUc()
        {
            InitializeComponent();
        }
        public int SelectedRoomID
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

                return BaseItem.ToInt32(((DataTable)dataGridView1.DataSource).Rows[dataGridView1.SelectedCells[0].RowIndex]["RoomID"]);
            }
        }
        public DataTable GridTable
        {
            get { return (DataTable)dataGridView1.DataSource; }
        }
        private void RoomListUc_Load(object sender, EventArgs e)
        {
            RefreshGrid();
            InitFilter();
        }
        private void InitFilter()
        {
            Filter.Add("ParentAndChild", "Room Name");
            Filter.Add("Status", "Status");

            toolStripComboBox1.ComboBox.DataSource = Filter.DataTable;
            toolStripComboBox1.ComboBox.DisplayMember = "Value";
            toolStripComboBox1.ComboBox.ValueMember = "Key";
            toolStripComboBox1.ComboBox.SelectedIndex = 0;
        }

        private void RefreshGrid()
        {
            ProgressForm frmProgress = ProgressForm.Show(this, "Loading Rooms...");

            try
            {

                dataGridView1.AutoGenerateColumns = false;

                DataSet ds = SocketClient.GetAllRoomsWithRelationShip();

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
            catch(Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
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
            ViewDetail(SelectedRoomID);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ViewDetail(SelectedRoomID);
        }

        public void ViewDetail(int selectedRoomID)
        {
            DialogResult result = RoomDetail.Show(this.ParentForm, selectedRoomID, null);
            if (result == DialogResult.OK)
            {
                RefreshGrid();
                MessageForm.Show(this.ParentForm, MsgE.InfoSaveRoom);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void avtiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateRoomStatus(StatusE.Active);
        }
        private void inActiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateRoomStatus(StatusE.Inactive);
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateRoomStatus(StatusE.Deleted);
        }
        void UpdateRoomStatus(StatusE statusID)
        {

            try
            {
                int i = 0;

                string roomIDs = string.Empty;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if ((bool)row.Cells[0].Value)
                        {

                            Int32 roomId = BaseItem.ToInt32(GridTable.Rows[i]["RoomID"]);

                            roomIDs += "," + roomId.ToString();
                        }
                    }

                    i++;
                }
                if (roomIDs.Length > 0)
                {
                    roomIDs = roomIDs.Remove(0, 1);

                    if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, statusID.ToString().ToLower(), "room") == DialogResult.Yes)
                    {
                        ProgressForm frmProgress = ProgressForm.Show(this, "Updating Room Status...");

                        SocketClient.UpdateRoomStatus(statusID, roomIDs);

                        frmProgress.Close();

                        RefreshGrid();

                        MessageForm.Show(this.ParentForm, MsgE.InfoUpdateRoom);
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
