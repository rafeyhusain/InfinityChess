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
    public partial class RegisteredPlayerUc : UserControl
    {
        #region Data Members
        public FilterItems Filter = new FilterItems();
        public App.Model.Db.Tournament Tournament = null;
        DataTable filterTable = null;
        DataTable table = null;
        #endregion

        #region Ctor
        public RegisteredPlayerUc()
        {
            InitializeComponent();
        }

        #endregion
        
        #region Properties
        public int SelectedID
        {
            get
            {
                if (dgvRegisterPlayer.DataSource == null)
                {
                    return 0;
                }

                if (dgvRegisterPlayer.SelectedCells.Count < 1)
                {
                    return 0;
                }

                return BaseItem.ToInt32(((DataTable)dgvRegisterPlayer.DataSource).Rows[dgvRegisterPlayer.SelectedCells[0].RowIndex]["TournamentUserID"]);
            }
        }


        #region GridTable
        public DataTable GridTable
        {
            get { return (DataTable)dgvRegisterPlayer.DataSource; }
        }

        #endregion
        

        private int GetEloBeforeRating
        {
            get
            {
                if (this.Tournament.ChessTypeIDE == ChessTypeE.Engine)
                {
                    return 2200;
                }
                else if (this.Tournament.ChessTypeIDE == ChessTypeE.Human)
                {
                    return 1500;
                }
                return 2200;
            }

        }

        #endregion
        
        #region Load

        private void RegisterPlayerUc_Load(object sender, EventArgs e)
        {
            InitFilter();
        }
        
        #endregion

        #region Helpers
        public void IsRegisteredPlayers(bool isRegistered)
        {
            if (isRegistered)
            {
                //tsbAddPlayer.Visible = false;
                tsbNew.Visible = true;
                tsbDelete.Visible = true;
            }
            else
            {
                //tsbAddPlayer.Visible = true;
                tsbNew.Visible = false;
                tsbDelete.Visible = false;
            }
        }

        #region Save Tournament Registered Users
        void SaveTournamentRegisteredUsers(StatusE statusID, TournamentUserStatusE tournamentUserStatusID)
        {
            int i = 0;
            string userIDs = string.Empty;
            int teamID = 0;

            if (dgvRegisterPlayer.Rows.Count == 0)
            {
                MessageForm.Error(this.ParentForm, MsgE.ErrorNoSelection, "player");

                return;
            }

            try
            {
                foreach (DataGridViewRow row in dgvRegisterPlayer.Rows)
                {                    
                    if (dgvRegisterPlayer[0, row.Index].Value != null)
                    {
                        if ((bool)dgvRegisterPlayer[0, row.Index].Value)
                        {

                            if (this.Tournament.TournamentTypeE == TournamentTypeE.Scheveningen)
                            {
                                teamID = Convert.ToInt32(GridTable.Rows[i]["TeamID"]);
                            }

                            int userID = BaseItem.ToInt32(GridTable.Rows[i]["UserID"]);

                            userIDs += "," + userID.ToString();

                        }
                    }
                    i++;
                }
                
                if (userIDs.Length > 0)
                    userIDs = userIDs.Remove(0, 1);


                SocketClient.SaveTournamentRegisteredUsers(statusID, tournamentUserStatusID, this.Tournament.TournamentID, userIDs, teamID, GetEloBeforeRating);

            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }
        #endregion

        #region Filter
        private void InitFilter()
        {
            Filter.Add("UserName", "Player Name");
            Filter.Add("Country", "Country");
            Filter.Add("Rating", "Rating");
            Filter.Add("Team", "Team");
            Filter.Add("Rank", "Rank");

            tscombo.ComboBox.DataSource = Filter.DataTable;
            tscombo.ComboBox.DisplayMember = "Value";
            tscombo.ComboBox.ValueMember = "Key";
            //tscombo.ComboBox.SelectedIndex = 0;
        }

        private void RefreshGrid(DataTable table)
        {
            filterTable = Filter.SearchByValue(table, tscombo, tsTextbox);
            dgvRegisterPlayer.DataSource = filterTable;
        }

        private void RefreshGrid()
        {

            if (this.Tournament == null)
            {
                return;
            }

            ProgressForm frmProgress = ProgressForm.Show(this, "Loading players...");

            try
            {
                dgvRegisterPlayer.AutoGenerateColumns = false;

                DataSet ds = SocketClient.GetTournamentRegisteredUser(StatusE.Active, this.Tournament.TournamentID);

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        if (Tournament.TournamentTypeE == TournamentTypeE.RoundRobin)
                        {
                            dgvRegisterPlayer.Columns[2].Visible = true;
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

        #region SetCheck
        private void SetCheck(bool isCheck)
        {
            foreach (DataGridViewRow row in dgvRegisterPlayer.Rows)
            {
                row.Cells[0].Value = isCheck;
            }
        }
        #endregion

        #endregion

        #region Toolbar
        private void tsbDelete_Click(object sender, EventArgs e)
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


            if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemDelete, "player") == DialogResult.Yes)
            {
                SaveTournamentRegisteredUsers(StatusE.Deleted, TournamentUserStatusE.Declined);
                RefreshGrid();
            }
        }


        private void tsbNew_Click(object sender, EventArgs e)
        {
            RegisterPlayer();
        }

        private void RegisterPlayer()
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

            TournamentRegisterPlayer TournamentRegisterPlayer = new TournamentRegisterPlayer(this.Tournament, 0);
            DialogResult dr = TournamentRegisterPlayer.ShowDialog(this.ParentForm);
            if (dr == DialogResult.OK)
            {
                TournamentRegisterPlayer.Close();
                RefreshGrid();
            }
        }

        private void tsRefresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCheck(true);
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCheck(false);
        }

        private void tsTextbox_TextChanged(object sender, EventArgs e)
        {
            RefreshGrid(table);
        }

        private void tscombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrid(table);
        }
        #endregion

        #region Grid
        private void dgvRegisterPlayer_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (filterTable == null)
            {
                filterTable = table.Copy();
            }

            SetRating(e);

            switch (e.ColumnIndex)
            {
                case 2:
                    SetRank(e);
                    break;
                case 3:
                    SetUserName(e);
                    break;
                case 5:
                    SetFlag(e);
                    break;
            }
        }

        private void SetUserName(DataGridViewCellFormattingEventArgs e)
        {
            if (Convert.ToInt32(filterTable.Rows[e.RowIndex]["UserID2"]) > 0)
            {
                e.Value = filterTable.Rows[e.RowIndex]["UserName2"].ToString() + " (" + e.Value + ")";
            }
        }

        private void SetFlag(DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                if (dgvRegisterPlayer["Flag", e.RowIndex].Value != null && dgvRegisterPlayer["Flag", e.RowIndex].Value.ToString() != "" && dgvRegisterPlayer["Flag", e.RowIndex].Value.ToString() != "0")
                {
                    Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Flags\" + dgvRegisterPlayer["Flag", e.RowIndex].Value + ".PNG");
                    e.Value = item;
                    dgvRegisterPlayer["Country", e.RowIndex].ToolTipText = dgvRegisterPlayer["Country", e.RowIndex].Value.ToString();
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
            if (dgvRegisterPlayer["RoleID", e.RowIndex].Value != null && dgvRegisterPlayer["RoleID", e.RowIndex].Value.ToString() != "" && dgvRegisterPlayer["RoleID", e.RowIndex].Value.ToString() == "1")
            {
                e.Value = Ap.GetUserRankImage("Admin"); //For Admin Image
            }
            else if (dgvRegisterPlayer["Rank", e.RowIndex].Value != null && dgvRegisterPlayer["Rank", e.RowIndex].Value.ToString() != "" && dgvRegisterPlayer["Rank", e.RowIndex].Value.ToString() != "0")
            {
                e.Value = Ap.GetUserRankImage(dgvRegisterPlayer["Rank", e.RowIndex].Value.ToString()); //For User Rank Image
            }
        }

        private void SetRating(DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRegisterPlayer.Columns[e.ColumnIndex].HeaderText == "Rating")
            {
                if (dgvRegisterPlayer[e.ColumnIndex, e.RowIndex].Value.ToString() == "0")
                {
                    dgvRegisterPlayer[e.ColumnIndex, e.RowIndex].Value = "";
                }
            }
        }

        private void dgvRegisterPlayer_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvRegisterPlayer.CurrentCell is System.Windows.Forms.DataGridViewCheckBoxCell)
            {
                dgvRegisterPlayer.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        } 
        #endregion

        #region RefreshTab
        public void RefreshTab()
        {
            RefreshGrid();
        } 
        #endregion

        internal void AllowEdit(bool enable)
        {
            tsbNew.Visible = enable;
            tsbDelete.Visible = enable;
            tsbSelect.Visible = enable;

            dgvRegisterPlayer.Columns[0].Visible = enable;
        }

        private void tsReplacedPlayer_Click(object sender, EventArgs e)
        {
            if (this.Tournament == null)
            {
                return;
            }

            if (this.Tournament.TournamentID == 0)
            {
                return;
            }

            if (this.Tournament.TournamentStatusIDE != TournamentStatusE.InProgress)
            {
                return;
            }

            TournamentRegisterPlayer Tru = new TournamentRegisterPlayer(this.Tournament, 0);

            int userID = ValidateReplacePlayer();

            if (userID == -1 || userID == 0)
            {
                MessageForm.Error(this.ParentForm, MsgE.ErrorReplacePlayerSelection, "");
                return;
            }

            Tru.UserID = userID;

            DialogResult dr = Tru.ShowDialog(this.ParentForm);
            if (dr == DialogResult.OK)
            {
                Tru.Close();
                RefreshGrid();
            }
        }

        int ValidateReplacePlayer()
        {
            int userID = 0, counter = 0, i = 0 ;            
            foreach (DataGridViewRow row in dgvRegisterPlayer.Rows)
            {
                if (dgvRegisterPlayer[0, row.Index].Value != null)
                {
                    if ((bool)dgvRegisterPlayer[0, row.Index].Value)
                    {
                        if (counter > 1)
                        {
                            return -1;
                        }
                        userID = BaseItem.ToInt32(GridTable.Rows[i]["UserID"]);
                        counter++;
                    }                    
                }
                i++;
            }
            return userID;
        }

    }
}
