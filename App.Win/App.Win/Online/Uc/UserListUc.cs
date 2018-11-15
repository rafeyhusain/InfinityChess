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
    public partial class UserListUc : UserControl
    {
        #region DataMembers

        public FilterItems Filter = new FilterItems();
        DataTable table = null;
        
        #endregion

        #region Properties
        public int SelectedID
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

                return BaseItem.ToInt32(((DataTable)dataGridView1.DataSource).Rows[dataGridView1.SelectedCells[0].RowIndex]["UserID"]);
            }
        }

        public int UserStatusID
        {
            get
            {
                return BaseItem.ToInt32(((DataTable)dataGridView1.DataSource).Rows[dataGridView1.SelectedCells[0].RowIndex]["StatusID"]);
            }
        }

        public DataTable GridTable
        {
            get { return (DataTable)dataGridView1.DataSource; }
        }
        #endregion

        #region Ctor

        public UserListUc()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void UserListUc_Load(object sender, EventArgs e)
        {
            RefreshGrid();
            InitFilter();
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult result = UserData.Show(this.ParentForm, this.SelectedID);
            if (result == DialogResult.OK)
            {
                RefreshGrid();
            }
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            DialogResult result = UserData.Show(this.ParentForm, 0);
            if (result == DialogResult.OK)
            {
                RefreshGrid();
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCheck(true);
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCheck(false);
        }

        private void tsbView_Click(object sender, EventArgs e)
        {
            DialogResult result = UserData.Show(this.ParentForm, this.SelectedID);
            if (result == DialogResult.OK)
            {
                RefreshGrid();
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            RefreshGrid(table);
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrid(table);
        }

        private void banToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BanUser(StatusE.Ban);
        }

        private void removeBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateBanStatus(StatusE.Active);
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell is System.Windows.Forms.DataGridViewCheckBoxCell)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                SetRank(e);
            }
            if (e.ColumnIndex == 5)
            {
                SetCountry(e);
            }
        }

        private void SetCountry(DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1["CountryID", e.RowIndex].Value != null && dataGridView1["CountryID", e.RowIndex].Value.ToString() != "" && dataGridView1["CountryID", e.RowIndex].Value.ToString() != "0")
            {
                Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Flags\" + dataGridView1["CountryID", e.RowIndex].Value + ".PNG");
                e.Value = item;
                dataGridView1["Country", e.RowIndex].ToolTipText = dataGridView1["Country", e.RowIndex].Value.ToString();
            }
            else
            {
                Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Flags\244.PNG");
                e.Value = item;
            }
        }

        public void SetRank(DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1["RoleID", e.RowIndex].Value != null && dataGridView1["RoleID", e.RowIndex].Value.ToString() != "" && dataGridView1["RoleID", e.RowIndex].Value.ToString() == "1")
            {
                e.Value = Ap.GetUserRankImage("Admin"); //For Admin Image
            }
            else if (dataGridView1["Rank", e.RowIndex].Value != null && dataGridView1["Rank", e.RowIndex].Value.ToString() != "" && dataGridView1["Rank", e.RowIndex].Value.ToString() != "0")
            {
                e.Value = Ap.GetUserRankImage(dataGridView1["Rank", e.RowIndex].Value.ToString()); //For User Rank Image
            }
        }

        private void makeAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;

                string userIDs = string.Empty;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if ((bool)row.Cells[0].Value)
                        {
                            int userID = BaseItem.ToInt32(GridTable.Rows[i]["UserID"]);

                            userIDs += "," + userID.ToString();
                        }
                    }
                    i++;
                }

                if (userIDs.Length > 0)
                {
                    userIDs = userIDs.Remove(0, 1);

                    if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, "make", "admin") == DialogResult.Yes)
                    {
                        ProgressForm frmProgress = ProgressForm.Show(this, "Making Admin...");

                        SocketClient.MakeAdmin(userIDs, RankE.King, RoleE.Admin);

                        frmProgress.Close();

                        RefreshGrid();

                        MessageForm.Show(this.ParentForm, MsgE.InfoMakeAdmin);
                    }
                }
                else
                {
                    MessageForm.Show(this.ParentForm, MsgE.ErrorSelectCheckBox);
                }
            }
            catch (Exception ex)
            {
                MessageForm.Show(ex);
            }
        }

        private void adminListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetAllAdmin();
        }

        private void revokeAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RevokeAdmin();
        }

        private void banUserListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BanUserList();
        }
       
        private void showAllUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }
       
        #endregion
        
        #region Method
       
        private void InitFilter()
        {
            Filter.Add("UserName", "User Name");
            Filter.Add("FirstName", "First Name");
            Filter.Add("LastName", "Last Name");
            Filter.Add("Country", "Country");

            toolStripComboBox1.ComboBox.DataSource = Filter.DataTable;
            toolStripComboBox1.ComboBox.DisplayMember = "Value";
            toolStripComboBox1.ComboBox.ValueMember = "Key";
        }

        private void RefreshGrid()
        {
            ProgressForm frmProgress = ProgressForm.Show(this, "Loading Users...");

            try
            {
                dataGridView1.AutoGenerateColumns = false;

                DataSet ds = SocketClient.GetAllUserByID(); 

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
                MessageForm.Show(ex);
            }

            frmProgress.Close();
        }

        private void RefreshGrid(DataTable table)
        {
            dataGridView1.DataSource = Filter.SearchByValue(table, toolStripComboBox1, toolStripTextBox1);
        }

        private void SetCheck(bool isCheck) 
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = isCheck;
            }
        }

        void BanUser(StatusE statusID)
        {
            try
            {
                int i = 0;

                string userIDs = string.Empty;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if ((bool)row.Cells[0].Value)
                        {
                            int userID = BaseItem.ToInt32(GridTable.Rows[i]["UserID"]);

                            userIDs += "," + userID.ToString();
                        }
                    }
                    i++;
                }

                if (userIDs.Length > 0)
                {
                    userIDs = userIDs.Remove(0, 1);

                    if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, "ban", "user") == DialogResult.Yes)
                    {
                        ProgressForm frmProgress = ProgressForm.Show(this, "User Ban...");

                        SocketClient.UpdateBanStatus(statusID, userIDs);

                        frmProgress.Close();

                        RefreshGrid();

                        MessageForm.Show(this.ParentForm, MsgE.InfoBanUser);
                    }
                }
                else
                {
                    MessageForm.Show(this.ParentForm, MsgE.ErrorSelectCheckBox);
                }
            }
            catch (Exception ex)
            {
                MessageForm.Show(ex);
            }
        }

        void UpdateBanStatus(StatusE statusID)
        {
            try
            {
                int i = 0;

                string userIDs = string.Empty;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if ((bool)row.Cells[0].Value)
                        {
                            int statusIDx = BaseItem.ToInt32(GridTable.Rows[i]["StatusID"]);

                            if (statusIDx == (int)StatusE.Ban)
                            {
                                int userID = BaseItem.ToInt32(GridTable.Rows[i]["UserID"]);

                                userIDs += "," + userID.ToString();
                            }
                        }
                    }
                    i++;
                }

                if (userIDs.Length > 0)
                {
                    userIDs = userIDs.Remove(0, 1);

                    if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, "remove ban", "user") == DialogResult.Yes)
                    {
                        ProgressForm frmProgress = ProgressForm.Show(this, "Removing Ban...");

                        SocketClient.UpdateBanStatus(statusID, userIDs);

                        frmProgress.Close();

                        RefreshGrid();

                        MessageForm.Show(this.ParentForm, MsgE.InfoBanRemove);
                    }
                }
                else
                {
                    MessageForm.Show(this.ParentForm, MsgE.ErrorSelectCheckBox);
                }
            }
            catch (Exception ex)
            {
                MessageForm.Show(ex);
            }
        }

        public void GetAllAdmin()
        {
            ProgressForm frmProgress = ProgressForm.Show(this, "Loading Admin Users...");

            try
            {
                DataSet ds = SocketClient.GetAllAdmin();
                dataGridView1.AutoGenerateColumns = false;
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
                MessageForm.Show(ex);
            }

            frmProgress.Close();
        }

        public void RevokeAdmin()
        {
            try
            {
                string userIDs = GetAllSelectedUserIDs();
                if (userIDs.Length > 0)
                {
                    if (userIDs == "1")
                    {
                        MessageForm.Show("'Admin' can not be revoke");
                        return;
                    }

                    userIDs = userIDs.Remove(0, 1);

                    if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, "Revoke ", "admin") == DialogResult.Yes)
                    {
                        ProgressForm frmProgress = ProgressForm.Show(this, "Revoking Admin...");

                        SocketClient.RevokeAdmin(userIDs, RankE.Pawn, RoleE.Player);

                        frmProgress.Close();

                        RefreshGrid();

                        MessageForm.Show(this.ParentForm, MsgE.InfoAdminRevoked);
                    }
                }
                else
                {
                    MessageForm.Show(this.ParentForm, MsgE.ErrorSelectCheckBox);
                }
            }
            catch (Exception ex)
            {
                MessageForm.Show(ex);
            }
        }

        public string GetAllSelectedUserIDs()
        {
            string userIDs = string.Empty;

            try
            {
                int i = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if ((bool)row.Cells[0].Value)
                        {
                            int roleID = BaseItem.ToInt32(GridTable.Rows[i]["RoleID"]);

                            if (roleID == (int)RoleE.Admin)
                            {
                                int userID = BaseItem.ToInt32(GridTable.Rows[i]["UserID"]);
                                if (userID == 1)
                                {
                                    userIDs = userID.ToString();
                                    break;
                                }
                                userIDs += "," + userID.ToString();
                            }
                        }
                    }
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageForm.Show(ex);
            }
            return userIDs;
        }

        public void BanUserList()
        {
            ProgressForm frmProgress = ProgressForm.Show(this, "Loading Ban Users...");

            try
            {
                DataSet ds = SocketClient.GetAllBanUser();
                dataGridView1.AutoGenerateColumns = false;
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
                MessageForm.Show(ex);
            }

            frmProgress.Close();
        }

        public void BanUserMachineList()
        {
            ProgressForm frmProgress = ProgressForm.Show(this, "Loading Ban Uers Machines...");

            try
            {
                DataSet ds = SocketClient.GetAllBanUserMachine();
                dataGridView1.AutoGenerateColumns = false;
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
                MessageForm.Show(ex);
            }

            frmProgress.Close();
        }
        
        #endregion
    }
}
