using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model.Db;
using App.Model;

namespace App.Win
{
    public partial class TeamListUc : UserControl
    {

        public FilterItems Filter = new FilterItems();
        DataTable table = null;
        public TeamListUc()
        {
            InitializeComponent();
        }
        public int SelectedTeamID
        {
            get
            {
                if (dgvTeam.DataSource == null)
                {
                    return 0;
                }

                if (dgvTeam.SelectedCells.Count < 1)
                {
                    return 0;
                }

                return BaseItem.ToInt32(((DataTable)dgvTeam.DataSource).Rows[dgvTeam.SelectedCells[0].RowIndex]["TeamID"]);
            }
        }

        public DataTable GridTable
        {
            get { return (DataTable)dgvTeam.DataSource; }
        }

        private void TeamUc_Load(object sender, EventArgs e)
        {
            RefreshGrid();
            InitFilter();
        }

        #region Filter
        private void InitFilter()
        {
            Filter.Add("TeamName", "Team Name");
            Filter.Add("Status", "Status");

            toolStripComboBox1.ComboBox.DataSource = Filter.DataTable;
            toolStripComboBox1.ComboBox.DisplayMember = "Value";
            toolStripComboBox1.ComboBox.ValueMember = "Key";
        }
        #endregion

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }
        private void RefreshGrid()
        {
            ProgressForm frmProgress = ProgressForm.Show(this, "Loading Teams...");

            try
            {
                dgvTeam.AutoGenerateColumns = false;

                DataSet ds = SocketClient.GetAllTeam();

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
            }

            frmProgress.Close();
        }
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            RefreshGrid(table);
        }
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrid(table);
        }
        private void RefreshGrid(DataTable table)
        {
            dgvTeam.DataSource = Filter.SearchByValue(table, toolStripComboBox1, toolStripTextBox1);
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SetCheck(true);
        }
        private void SetCheck(bool isCheck)
        {
            foreach (DataGridViewRow row in dgvTeam.Rows)
            {
                row.Cells[0].Value = isCheck;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SetCheck(false);
        }

        private void dgvTeam_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }
        private void activeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateTeamStatus(StatusE.Active);
        }
        private void inActiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateTeamStatus(StatusE.Inactive);
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateTeamStatus(StatusE.Deleted);
        }
        void UpdateTeamStatus(StatusE statusID)
        {
            try
            {
                int i = 0;

                string teamIDs = string.Empty;

                foreach (DataGridViewRow row in dgvTeam.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if ((bool)row.Cells[0].Value)
                        {
                            int TeamId = Convert.ToInt32(GridTable.Rows[i]["TeamID"]);
                            teamIDs += "," + TeamId.ToString();
                        }
                    }
                    i++;
                }

                if (teamIDs.Length > 0)
                {
                    teamIDs = teamIDs.Remove(0, 1);

                    if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, statusID.ToString().ToLower(), "team") == DialogResult.Yes)
                    {
                        ProgressForm frmProgress = ProgressForm.Show(this, "Updating Status...");

                        SocketClient.UpdateTeamStatus(statusID, teamIDs);

                        frmProgress.Close();

                        RefreshGrid();

                        MessageForm.Show(this.ParentForm, MsgE.InfoUpdateTeamStatus);
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

        private void dgvTeam_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvTeam.CurrentCell is System.Windows.Forms.DataGridViewCheckBoxCell)
            {
                dgvTeam.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            ViewDetail(0);
        }

        private void tsbView_Click(object sender, EventArgs e)
        {
            ViewDetail(SelectedTeamID);
        }
        private void dgvTeam_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ViewDetail(SelectedTeamID);
        }
        public void ViewDetail(int selectTeamID)
        {
            DialogResult result = TeamDetail.Show(this.ParentForm, selectTeamID);
            if (result == DialogResult.OK)
            {
                RefreshGrid();
                MessageForm.Show(this.ParentForm, MsgE.InfoSaveTeam);
            }
        }

    }
}
