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
using AppTournament = App.Model.Db.Tournament;

namespace App.Win
{
    public partial class RegisterPlayerUc : UserControl
    {
        
        #region Data Memebers
        public FilterItems Filter = new FilterItems();
        AppTournament TournamentItem = null;
        public int TournamentID = 0;
        public int TeamId = 0;
        public int UserID = 0;
        string userName = string.Empty;
        DataTable filterTable = null;
        DataTable table = null;
        #endregion

        #region Constructor
        public RegisterPlayerUc()
        {
            InitializeComponent();
        }

        public RegisterPlayerUc(AppTournament Tournament)
        {
            InitializeComponent();
            this.Tournament = Tournament;
        }


        #endregion
        
        #region Properties

        #region Tournament        
        
        public AppTournament Tournament { get { return TournamentItem; } set { TournamentItem = value; } }
        #endregion

        #region Get EloRating        
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

        #region SelectedID
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
        #endregion

        #region SelectedFlag
        public int SelectedFlag(int rowIndex)
        {            
                return BaseItem.ToInt32(((DataTable)dgvRegisterPlayer.DataSource).Rows[rowIndex]["TournamentUserID"]);         
        }
        #endregion

        #region GridTable
        public DataTable GridTable
        {
            get { return (DataTable)dgvRegisterPlayer.DataSource; }
        }

        #endregion

        public void IsRegisteredPlayers(bool isRegistered)
        {
            if (isRegistered)
            {
                tsbAddPlayer.Visible = false;                
            }
            else
            {
                tsbAddPlayer.Visible = true;                
            }
        }

        #endregion 
        
        #region Events
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            SaveTournamentRegisteredUsers(StatusE.Deleted, TournamentUserStatusE.Declined);
        }

        private void RegisterPlayerUc_Load(object sender, EventArgs e)
        {
            tsPlayers.SelectedIndex = 0;
            //RefreshGrid(UserStatusE.Blank);
            InitFilter();            
        }
        
        #endregion

        #region Methods

        #region Save Tournament Registered Users
        void SaveTournamentRegisteredUsers(StatusE statusID, TournamentUserStatusE tournamentUserStatusID)
        {            
            if (this.Tournament == null)
            {
                return;
            }

            if (this.Tournament.TournamentID == 0)
            {
                return;
            }

            if (dgvRegisterPlayer.Rows.Count == 0)
            {
                MessageForm.Error(this.ParentForm, MsgE.ErrorNoSelection, "player");

                return;
            }

            try
            {
                if (this.UserID == 0)
                {
                    RegisterPlayer(statusID, tournamentUserStatusID);
                }
                else
                {
                    UpdateReplacePlayer();
                }

            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }

        void UpdateReplacePlayer()
        {
            int userID2 = 0;

            userID2 = ValidateReplacePlayer();

            if (userID2 == -1 || userID2 == 0)
            {
                MessageForm.Error(this.ParentForm, MsgE.ErrorReplacePlayerSelection, "");
                return;
            }

            DataSet ds = SocketClient.UpdateReplacePlayer(this.Tournament.TournamentID, this.UserID, userID2);

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    Kv kv = new Kv(ds.Tables[0]);
                    if (kv.GetInt32("Result") > 0)
                    {
                        MessageForm.Error(this.ParentForm, (MsgE)kv.GetInt32("Result"));
                        return;
                    }
                }
            }

            TournamentRegisterPlayer TournamentRegisterPlayer = (TournamentRegisterPlayer)this.ParentForm;
            TournamentRegisterPlayer.DialogResult = DialogResult.OK;

        }

        int ValidateReplacePlayer()
        {
            this.userName = string.Empty;
            int userID = 0, counter = 0, i = 0;
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

        private void RegisterPlayer(StatusE statusID, TournamentUserStatusE tournamentUserStatusID)
        {
            string userIDs = string.Empty;
            int i = 0;
            foreach (DataGridViewRow row in dgvRegisterPlayer.Rows)
            {

                int chessTypeID = Convert.ToInt32(GridTable.Rows[i]["ChessTypeId"]);
                if (dgvRegisterPlayer[0, row.Index].Value != null)
                {
                    if ((bool)dgvRegisterPlayer[0, row.Index].Value)
                    {
                        int userID = BaseItem.ToInt32(GridTable.Rows[i]["UserID"]);
                        userIDs += "," + userID.ToString();
                    }
                }
                i++;
            }

            if (userIDs.Length > 0)
                userIDs = userIDs.Remove(0, 1);

            SocketClient.SaveTournamentRegisteredUsers(statusID, tournamentUserStatusID, this.Tournament.TournamentID, userIDs, TeamId, GetEloBeforeRating);

            TournamentRegisterPlayer TournamentRegisterPlayer = (TournamentRegisterPlayer)this.ParentForm;
            TournamentRegisterPlayer.DialogResult = DialogResult.OK;
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
            tscombo.ComboBox.SelectedIndex = 0;
        }

        private void RefreshGrid(DataTable table)
        {
            filterTable = Filter.SearchByValue(table, tscombo, toolStripTextBox1);
            dgvRegisterPlayer.DataSource = filterTable;
        }

        private void RefreshGrid(UserStatusE userStatusID)
        {
            ProgressForm frmProgress = ProgressForm.Show(this, "Loading players...");

            try
            {
                dgvRegisterPlayer.AutoGenerateColumns = false;

                DataSet ds = SocketClient.GetTournamentRegisterUser(userStatusID, this.Tournament.TournamentID);

                if (ds != null)
                {
                    table = ds.Tables[0];
                }

                RefreshGrid(table);
            }
            catch ( Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
            }

            frmProgress.Close();
        } 
        #endregion

        private void tsPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        #region Refresh
        private void RefreshGrid()
        {            
            if (tsPlayers.SelectedIndex == 0)
            {
                RefreshGrid(UserStatusE.Gone);
            }
            else
            {
                RefreshGrid(UserStatusE.Unknown);
            }            
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
        
        private void tsbAddPlayer_Click(object sender, EventArgs e)
        {

            if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, "register", "player(s)") == DialogResult.Yes)
            {
                Save();
            }
            
        }

        public void Save()
        {
            SaveTournamentRegisteredUsers(StatusE.Active, TournamentUserStatusE.Approved);
        }

        private void dgvRegisterPlayer_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvRegisterPlayer.CurrentCell is System.Windows.Forms.DataGridViewCheckBoxCell)
            {
                dgvRegisterPlayer.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void tsRefresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }
        
        #region Set Formatting

        private void dgvRegisterPlayer_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
                case 4:
                    SetFlag(e);
                    break;
            }
        }

        
        private void SetFlag(DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
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
            //if (e.ColumnIndex == 1)
            //{
            //    if (dgvRegisterPlayer["Rank", e.RowIndex].Value != null && dgvRegisterPlayer["Rank", e.RowIndex].Value.ToString() != "" && dgvRegisterPlayer["Rank", e.RowIndex].Value.ToString() != "0")
            //    {
            //        Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Ranks\" + dgvRegisterPlayer["Rank", e.RowIndex].Value + ".PNG");
            //        e.Value = item;
            //    }
            //}
        }

        #endregion

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCheck(true);
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCheck(false);
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            RefreshGrid(table);
        }

        private void tscombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrid(table);
        }
        
        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

    }
}
