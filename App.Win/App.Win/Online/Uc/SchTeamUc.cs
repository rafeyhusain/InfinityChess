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
using System.IO;

namespace App.Win
{
    public partial class SchTeamUc : UserControl
    {
        #region Data Members
        public App.Model.Db.Tournament Tournament = null;
        DataTable filterPlayerTable = null;
        DataTable filterTeamTable = null;
        #endregion

        #region Ctor
        public SchTeamUc()
        {
            InitializeComponent();
        }
        #endregion

        #region Common

        private void TeamUc_Load(object sender, EventArgs e)
        {
            InitTeamFilter();
            InitPlayerFilter();
        }

        private void SetCheck(DataGridView g, bool isCheck)
        {
            foreach (DataGridViewRow row in g.Rows)
            {
                row.Cells[0].Value = isCheck;
            }
        }

        #endregion

        #region Team

        #region Data Members
        public FilterItems FilterTeam = new FilterItems();
        DataTable tableTeam = null;
        #endregion

        #region Properties
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

        #region GridTable
        public DataTable PlayerGridTable
        {
            get { return (DataTable)dgvPlayer.DataSource; }
        }

        public DataTable TeamGridTable
        {
            get { return (DataTable)dgvTeam.DataSource; }
        }

        #endregion

        private bool IsInvaildSelection
        {
            get
            {
                return dgvTeam.SelectedRows == null || dgvTeam.SelectedRows.Count == 0 || tableTeam == null || tableTeam.Rows.Count == 0;
            }
        }

        #endregion

        #region Toolbar

        private void tsbNew_Click(object sender, EventArgs e)
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


            SchRegisterTeam frm = new SchRegisterTeam(this.Tournament);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                RefreshTeamGrid();
            }
        }

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


            DialogResult dr = MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemDelete, "team(s)");
            if (dr == DialogResult.Yes)
            {
                DeleteTeams();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SetCheck(dgvTeam, true);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SetCheck(dgvTeam, false);
        }

        private void tsTextbox_TextChanged(object sender, EventArgs e)
        {
            RefreshTeamGrid(tableTeam);
        }

        private void tscombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTeamGrid(tableTeam);
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            RefreshTeamGrid();
        }

        #endregion

        #region Grid

        private void dgvTeam_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvTeam.CurrentCell is System.Windows.Forms.DataGridViewCheckBoxCell)
            {
                dgvTeam.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvTeam_SelectionChanged(object sender, EventArgs e)
        {
            if (IsInvaildSelection)
            {
                return;
            }

            RefreshPlayerGrid();
        }

        #endregion

        #region Helpers

        private void InitTeamFilter()
        {
            FilterTeam.Add("TeamName", "Name");
            FilterTeam.Add("Description", "Description");

            tscombo.ComboBox.DataSource = FilterTeam.DataTable;
            tscombo.ComboBox.DisplayMember = "Value";
            tscombo.ComboBox.ValueMember = "Key";            
        }

        private void RefreshTeamGrid()
        {
            if (this.Tournament == null)
            {
                return;
            }

            ProgressForm frmProgress = ProgressForm.Show(this, "Loading Teams...");

            try
            {
                dgvTeam.AutoGenerateColumns = false;

                DataSet ds = SocketClient.GetTeamsByTournamentID(this.Tournament.TournamentID);

                if (ds != null && ds.Tables.Count > 0)
                {
                    tableTeam = ds.Tables[0];
                }
                else
                {
                    if (tableTeam != null)
                    {
                        tableTeam.Rows.Clear();
                    }
                }

                RefreshTeamGrid(tableTeam);
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }

            frmProgress.Close();
        }

        private void RefreshTeamGrid(DataTable tableTeam)
        {
            filterTeamTable = FilterTeam.SearchByValue(tableTeam, tscombo, tsTextbox);
            dgvTeam.DataSource = filterTeamTable;
        }

        private void DeleteTeams()
        {
            if (dgvTeam.Rows.Count == 0)
            {
                MessageForm.Error(this.ParentForm, MsgE.ErrorNoSelection, "team");

                return;
            }

            try
            {
                int i = 0;

                string tournamentTeamIds = string.Empty;

                foreach (DataGridViewRow row in dgvTeam.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if ((bool)row.Cells[0].Value)
                        {
                            int teamId = BaseItem.ToInt32(TeamGridTable.Rows[i]["TeamID"]);

                            tournamentTeamIds += "," + teamId.ToString();
                        }
                    }
                    i++;
                }

                if (tournamentTeamIds.Length > 0)
                {
                    tournamentTeamIds = tournamentTeamIds.Remove(0, 1);

                    ProgressForm frmProgress = ProgressForm.Show(this, "Removing Teams...");

                    SocketClient.DeleteTournamentTeam(tournamentTeamIds, this.Tournament.TournamentID);

                    frmProgress.Close();

                    RefreshTeamGrid();
                    RefreshPlayerGrid();
                }
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }

        #endregion

        #endregion

        #region Players

        #region Data Members
        public FilterItems FilterPlayer = new FilterItems();
        DataTable tablePlayer = null;
        #endregion

        #region Properties

        public int SelectedPlayerID
        {
            get
            {
                if (dgvPlayer.DataSource == null)
                {
                    return 0;
                }

                if (dgvPlayer.SelectedCells.Count < 1)
                {
                    return 0;
                }

                return BaseItem.ToInt32(((DataTable)dgvPlayer.DataSource).Rows[dgvPlayer.SelectedCells[0].RowIndex]["UserID"]);
            }
        }

        public int UserStatusID
        {
            get
            {
                return BaseItem.ToInt32(((DataTable)dgvPlayer.DataSource).Rows[dgvPlayer.SelectedCells[0].RowIndex]["StatusID"]);
            }
        }

        #endregion

        #region Toolbar

        private void tsbNewTeamPlayers_Click(object sender, EventArgs e)
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


            TournamentRegisterPlayer frm = new TournamentRegisterPlayer(this.Tournament, SelectedTeamID);
            DialogResult dr = frm.ShowDialog(this.ParentForm);
            if (dr == DialogResult.OK)
            {
                frm.Close();
                RefreshPlayerGrid();
            }
        }

        private void tsbDeleteTeamPlayer_Click(object sender, EventArgs e)
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


            DialogResult dr = MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemDelete, "player(s)");
            if (dr == DialogResult.Yes)
            {
                DeletePlayers();
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCheck(dgvPlayer, true);
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCheck(dgvPlayer, false);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RefreshPlayerGrid();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            RefreshPlayerGrid(tablePlayer);
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshPlayerGrid(tablePlayer);
        }

        #endregion

        #region Grid

        private void dgvPlayer_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (filterPlayerTable == null)
            {
                filterPlayerTable = tablePlayer.Copy();
            }

            //if (filterPlayerTable.Rows.Count == 0)
            //{
            //    return;
            //}

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
            if (Convert.ToInt32(filterPlayerTable.Rows[e.RowIndex]["UserID2"]) > 0)
            {
                e.Value = filterPlayerTable.Rows[e.RowIndex]["UserName2"].ToString() + " (" + e.Value + ")";
            }
        }

        private void SetFlag(DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPlayer["Flag", e.RowIndex].Value != null && dgvPlayer["Flag", e.RowIndex].Value.ToString() != "" && dgvPlayer["Flag", e.RowIndex].Value.ToString() != "0")
            {
                Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Flags\" + dgvPlayer["Flag", e.RowIndex].Value + ".PNG");
                e.Value = item;
                dgvPlayer["Country", e.RowIndex].ToolTipText = dgvPlayer["Country", e.RowIndex].Value.ToString();
            }
            else
            {
                Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Flags\244.PNG");
                e.Value = item;
            }
        }

        private void SetRank(DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPlayer["Rank", e.RowIndex].Value != null && dgvPlayer["Rank", e.RowIndex].Value.ToString() != "" && dgvPlayer["Rank", e.RowIndex].Value.ToString() != "0")
            {
                Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Ranks\" + dgvPlayer["Rank", e.RowIndex].Value + ".PNG");
                e.Value = item;
            }
        }

        private void SetRating(DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPlayer.Columns[e.ColumnIndex].HeaderText == "Rating")
            {
                if (dgvPlayer[e.ColumnIndex, e.RowIndex].Value.ToString() == "0")
                {
                    dgvPlayer[e.ColumnIndex, e.RowIndex].Value = "";
                }
            }
        }


        private void dgvPlayer_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvPlayer.CurrentCell is System.Windows.Forms.DataGridViewCheckBoxCell)
            {
                dgvPlayer.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        #endregion

        #region Helpers

        private void InitPlayerFilter()
        {
            FilterPlayer.Add("UserName", "Player Name");
            FilterPlayer.Add("Country", "Country");
            FilterPlayer.Add("Rating", "Rating");
            FilterPlayer.Add("Rank", "Rank");

            toolStripComboBox1.ComboBox.DataSource = FilterPlayer.DataTable;
            toolStripComboBox1.ComboBox.DisplayMember = "Value";
            toolStripComboBox1.ComboBox.ValueMember = "Key";
            //toolStripComboBox1.ComboBox.SelectedIndex = 0;
        }

        private void RefreshPlayerGrid()
        {
            if (this.Tournament == null)
            {
                return;
            }

            ProgressForm frmProgress = ProgressForm.Show(this, "Loading Players...");

            try
            {

                dgvPlayer.AutoGenerateColumns = false;

                int teamID = SelectedTeamID;
                if (SelectedTeamID == 0)
                {
                    teamID = -1;
                }
                DataSet ds = SocketClient.GetTournamentTeamRegisteredUser(this.Tournament.TournamentID, teamID, UserStatusE.Unknown);

                if (ds != null && ds.Tables.Count > 0)
                {
                    tablePlayer = ds.Tables[0];
                }
                else
                {
                    if (tablePlayer != null)
                    {
                        tablePlayer.Rows.Clear();
                    }
                }

                RefreshPlayerGrid(tablePlayer);
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }

            frmProgress.Close();
        }

        private void RefreshPlayerGrid(DataTable tablePlayer)
        {
            filterPlayerTable = FilterPlayer.SearchByValue(tablePlayer, toolStripComboBox1, toolStripTextBox1);
            dgvPlayer.DataSource = filterPlayerTable;
        }

        private void DeletePlayers()
        {
            
            if (dgvPlayer.Rows.Count == 0)
            {
                MessageForm.Error(this.ParentForm, MsgE.ErrorNoSelection, "player");

                return;
            }

            try
            {
                int i = 0;
                string userIDs = string.Empty;

                foreach (DataGridViewRow row in dgvPlayer.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if ((bool)row.Cells[0].Value)
                        {
                            int userID = BaseItem.ToInt32(PlayerGridTable.Rows[i]["UserID"]);
                            userIDs += "," + userID.ToString();
                        }
                    }
                    i++;
                }

                if (userIDs.Length > 0)
                {
                    userIDs = userIDs.Remove(0, 1);

                    ProgressForm frmProgress = ProgressForm.Show(this, "Removing Players...");

                    SocketClient.SaveTournamentRegisteredUsers(StatusE.Deleted, TournamentUserStatusE.Declined, this.Tournament.TournamentID, userIDs, SelectedTeamID, 0);

                    frmProgress.Close();

                    RefreshPlayerGrid();
                }
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }

        #endregion

        #endregion

        #region RefreshTab
        internal void RefreshTab()
        {
            RefreshTeamGrid();
            RefreshPlayerGrid();
        } 
        #endregion

        internal void AllowEdit(bool enable)
        {
            tsbNew.Visible = enable;
            tsbDelete.Visible = enable;
            tsbSelectTeam.Visible = enable;

            dgvTeam.Columns[0].Visible = enable;

            tsbNewTeamPlayers.Visible = enable;
            tsbDeleteTeamPlayer.Visible = enable;
            tsbSelectTeamPlayer.Visible = enable;

            dgvPlayer.Columns[0].Visible = enable;
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
                RefreshPlayerGrid();
            }
        }
        int ValidateReplacePlayer()
        {
            int userID = 0, counter = 0, i = 0;
            foreach (DataGridViewRow row in dgvPlayer.Rows)
            {
                if (dgvPlayer[0, row.Index].Value != null)
                {
                    if ((bool)dgvPlayer[0, row.Index].Value)
                    {
                        if (counter > 1)
                        {
                            return -1;
                        }
                        userID = BaseItem.ToInt32(PlayerGridTable.Rows[i]["UserID"]);
                        counter++;
                    }
                }
                i++;
            }
            return userID;
        }
    }
}
