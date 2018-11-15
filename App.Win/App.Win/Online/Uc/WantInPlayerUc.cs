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
    public partial class WantInPlayerUc : UserControl
    {
        #region Data Members
        public App.Model.Db.Tournament Tournament = null;
        public FilterItems Filter = new FilterItems();
        DataTable table = null;
        DataTable filterTable = null;

        #endregion

        #region Ctor
        public WantInPlayerUc()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        #region GridTable
        public DataTable GridTable
        {
            get { return (DataTable)dgvWantin.DataSource; }
        }

        #endregion

        public int SelectedID
        {
            get
            {
                if (dgvWantin.DataSource == null)
                {
                    return 0;
                }

                if (dgvWantin.SelectedCells.Count < 1)
                {
                    return 0;
                }

                return BaseItem.ToInt32(((DataTable)dgvWantin.DataSource).Rows[dgvWantin.SelectedCells[0].RowIndex]["TournamentWantinUserID"]);
            }
        }
        #endregion

        #region Load
        private void WantInPlayerUc_Load(object sender, EventArgs e)
        {
            InitFilter();
        } 
        #endregion

        #region Toolbar

        private void tsbStartTournament_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tsbApprove_Click(object sender, EventArgs e)
        {
            if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, "approve", "player(s)") == DialogResult.Yes)
            {
                SaveWantinUsers(StatusE.Active, TournamentUserStatusE.Approved);
            }
            RefreshGrid();
        }

        private void tsbDecline_Click(object sender, EventArgs e)
        {            
            if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, "decline", "player(s)") == DialogResult.Yes)
            {
                SaveWantinUsers(StatusE.Deleted, TournamentUserStatusE.Declined);
            }
            RefreshGrid();
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        } 
        #endregion

        #region Grid
        private void dgvWantin_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvWantin.CurrentCell is System.Windows.Forms.DataGridViewCheckBoxCell)
            {
                dgvWantin.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        #region Formatting
        private void dgvWantin_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (filterTable == null)
            {
                filterTable = table.Copy();
            }

            switch (e.ColumnIndex)
            {
                case 1:
                    SetRank(e);
                    break;
                case 5:
                    SetFlag(e);
                    break;
            }



        }

        private void SetFlag(DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                if (dgvWantin["Flag", e.RowIndex].Value != null && dgvWantin["Flag", e.RowIndex].Value.ToString() != "" && dgvWantin["Flag", e.RowIndex].Value.ToString() != "0")
                {
                    Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Flags\" + dgvWantin["Flag", e.RowIndex].Value + ".PNG");
                    e.Value = item;
                    
                    dgvWantin["Country", e.RowIndex].ToolTipText = dgvWantin["Country", e.RowIndex].Value.ToString();
                }
                else
                {
                    Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Flags\244.PNG");
                    e.Value = item;
                    
                }
            }
        }

        private void SetRank(DataGridViewCellFormattingEventArgs e)
        {
            if (dgvWantin["RoleID", e.RowIndex].Value != null && dgvWantin["RoleID", e.RowIndex].Value.ToString() != "" && dgvWantin["RoleID", e.RowIndex].Value.ToString() == "1")
            {
                e.Value = Ap.GetUserRankImage("Admin"); //For Admin Image
            }
            else if (dgvWantin["Rank", e.RowIndex].Value != null && dgvWantin["Rank", e.RowIndex].Value.ToString() != "" && dgvWantin["Rank", e.RowIndex].Value.ToString() != "0")
            {
                e.Value = Ap.GetUserRankImage(dgvWantin["Rank", e.RowIndex].Value.ToString()); //For User Rank Image
            }

            //if (dgvWantin["Rank", e.RowIndex].Value != null && dgvWantin["Rank", e.RowIndex].Value.ToString() != "" && dgvWantin["Rank", e.RowIndex].Value.ToString() != "0")
            //{
            //    Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Ranks\" + dgvWantin["Rank", e.RowIndex].Value + ".PNG");
            //    e.Value = item;
            //}
        }
        
        #endregion
        #endregion

        #region Helpers

        #region Methods
        private void InitFilter()
        {
            Filter.Add("UserName", "Player Name");
            Filter.Add("Country", "Country");
            Filter.Add("Rating", "Rating");
            Filter.Add("TeamName", "Team");
            Filter.Add("Rank", "Rank");

            tsCombo.ComboBox.DataSource = Filter.DataTable;
            tsCombo.ComboBox.DisplayMember = "Value";
            tsCombo.ComboBox.ValueMember = "Key";
            tsCombo.ComboBox.SelectedIndex = 0;
        }

        private void RefreshGrid(DataTable table)
        {
            filterTable = Filter.SearchByValue(table, tsCombo, tsTextbox);
            dgvWantin.DataSource = filterTable;
        }

        private void RefreshGrid()
        {

            if (this.Tournament == null)
            {
                return;
            }
            if (this.Tournament.TournamentID == 0)
            {
                return;
            }

            ProgressForm frmProgress = ProgressForm.Show(this, "Loading players...");

            try
            {
                dgvWantin.AutoGenerateColumns = false;
                DataSet ds = SocketClient.GetTournamentWantinUsers(this.Tournament.TournamentID);

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        dgvWantin.DataSource = table;
                    }
                    else
                    {
                        if (table != null)
                        {
                            table.Rows.Clear();
                            table.AcceptChanges();
                        }
                    }
                }
                else
                {
                    if (table != null)
                    {
                        table.Rows.Clear();
                        table.AcceptChanges();
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
        #endregion

        #region Update Wantin Users

        private void SaveWantinUsers(StatusE statusID, TournamentUserStatusE tournamentUserStatusID)
        {

            Save(statusID, tournamentUserStatusID);
        }

        private void Save(StatusE statusID, TournamentUserStatusE tournamentUserStatusID)
        {
            if (this.Tournament == null)
            {
                return;
            }

            if (this.Tournament.TournamentID == 0)
            {
                return;
            }

            if (this.Tournament.TournamentStatusIDE != TournamentStatusE.Scheduled)
            {
                return;
            }


            int i = 0;
            string userIDs = string.Empty;
            string tournamentWantinUserIDs = string.Empty;
            int teamID = 0, eloBefore = 0;

            try
            {

                foreach (DataGridViewRow row in dgvWantin.Rows)
                {

                    int chessTypeID = Convert.ToInt32(GridTable.Rows[i]["ChessTypeId"]);

                    if (dgvWantin[0, row.Index].Value != null)
                    {
                        if ((bool)dgvWantin[0, row.Index].Value)
                        {

                            if (this.Tournament.TournamentTypeE == TournamentTypeE.Scheveningen)
                            {
                                teamID = Convert.ToInt32(GridTable.Rows[i]["TeamID"]);
                            }

                            if (DBNull.Value != GridTable.Rows[i]["Rating"])
                            {
                                eloBefore = GetEloBeforeRating(Convert.ToInt32(GridTable.Rows[i]["Rating"]), chessTypeID);
                            }
                            else
                            {
                                eloBefore = GetEloBeforeRating(0, chessTypeID);
                            }

                            int userID = BaseItem.ToInt32(GridTable.Rows[i]["UserID"]);
                            int tournamentWantinUserID = BaseItem.ToInt32(GridTable.Rows[i]["TournamentWantinUserID"]);

                            tournamentWantinUserIDs += "," + tournamentWantinUserID.ToString();
                            userIDs += "," + userID.ToString();

                        }
                    }
                    i++;
                }

                if (tournamentWantinUserIDs.Length > 0)
                    tournamentWantinUserIDs = tournamentWantinUserIDs.Remove(0, 1);

                if (userIDs.Length > 0)
                    userIDs = userIDs.Remove(0, 1);

                SocketClient.SaveWantinUsers(statusID, tournamentUserStatusID, this.Tournament.TournamentID, userIDs, tournamentWantinUserIDs, 0, eloBefore);
                RefreshGrid();
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }

        #endregion

        int GetEloBeforeRating(int rating, int chessType)
        {
            if (rating == 0)
            {
                ChessTypeE ChessTypeIDE = (ChessTypeE)Enum.ToObject(typeof(ChessTypeE), chessType);

                if (ChessTypeIDE == ChessTypeE.Engine)
                {
                    rating = 2200;
                }
                else if (ChessTypeIDE == ChessTypeE.Human)
                {
                    rating = 1500;
                }
            }
            return rating;
        }
        #endregion

        #region RefreshTab

        internal void RefreshTab()
        {
            RefreshGrid();
        } 
        #endregion

        #region AllowEdit
        public void AllowEdit(bool enable)
        {
            tsbApprove.Visible = enable;
            tsbDecline.Visible = enable;
            toolStripSplitButton1.Visible = enable;

            dgvWantin.Columns[0].Visible = enable;
        } 
        #endregion

        #region SetCheck
        private void SetCheck(bool isCheck)
        {
            foreach (DataGridViewRow row in dgvWantin.Rows)
            {
                row.Cells[0].Value = isCheck;
            }
        }
        #endregion
        private void tsTextbox_TextChanged(object sender, EventArgs e)
        {
            RefreshGrid(table);
        }

        private void tsCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrid(table);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCheck(true);
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCheck(false);
        }
    }
}
