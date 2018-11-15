using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;
using System.Configuration;
using App.Model.Db;
using WeifenLuo.WinFormsUI.Docking;

namespace App.Win
{
    public partial class PlayersUc : DockContent
    {
        public const string Guid = "3d527894-1bc3-4c60-b764-44983bf35e4d";
        public const string GridBorderColor = "#f4f4f4";
        public delegate void SelectedPlayerHandler(int userID, string userName, string userRank);
        public event SelectedPlayerHandler SelectPlayer;
        public event EventHandler RefreshData;
        public FilterItems Filter = new FilterItems();
        bool isTrue = false;

        #region Ctor
        public PlayersUc()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties
        public int SelectedUserId
        {
            //[System.Diagnostics.DebuggerStepThrough]
            get
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {

                    return Convert.ToInt32(dataGridView1["UserID", dataGridView1.SelectedRows[0].Index].Value);
                }
                else
                {
                    return 0;
                }
            }
        }

        public string SelectedUserName
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {

                    return dataGridView1["UserName", dataGridView1.SelectedRows[0].Index].Value.ToString();
                }
                else
                {
                    return "";
                }
            }
        }

        public string SelectedUserRank
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {

                    return dataGridView1["Rank", dataGridView1.SelectedRows[0].Index].Value.ToString();
                }
                else
                {
                    return "";
                }
            }
        }
   
        #endregion

        #region Helper

        private void InitFilter()
        {
            if (toolStripComboBox1.Items.Count > 0)
            {
                return;
            }

            Filter.Add("UserName", "Name");
            Filter.Add("Status", "Status");
            Filter.Add("Engine", "Engine");
            Filter.Add("BulletElo", "Bullet");
            Filter.Add("BlitzElo", "Blitz");
            Filter.Add("FideTitle", "FIDE");
            Filter.Add("IccfTitle", "ICCF");
            Filter.Add("Internet", "Internet");
            Filter.Add("TeamName", "Team");

            toolStripComboBox1.ComboBox.DataSource = Filter.DataTable;
            toolStripComboBox1.ComboBox.DisplayMember = "Value";
            toolStripComboBox1.ComboBox.ValueMember = "Key";
            toolStripComboBox1.ComboBox.SelectedIndex = 0;
        }

        private void ChallengeGame(DataGridViewRow row)
        {
            if (Ap.IsGameInProgress)
            {
                return;
            }

            if (Ap.SelectedRoomID == (int)RoomE.HumanTournaments || Ap.SelectedRoomParentID == (int)RoomE.HumanTournaments || Ap.SelectedRoomID == (int)RoomE.EngineTournaments || Ap.SelectedRoomParentID == (int)RoomE.EngineTournaments)
            {
                return;
            }
            if (Convert.ToInt32(row.Cells[0].Value) == Ap.CurrentUserID)
            {
                MessageForm.Error(this.ParentForm,MsgE.ErrorChallangeYourself);
                return;
            }

            if (UData.ToInt32(row.Cells[20].Value.ToString()) == (int)UserStatusE.Blank
                || UData.ToInt32(row.Cells[20].Value.ToString()) == (int)UserStatusE.Engine
                || UData.ToInt32(row.Cells[20].Value.ToString()) == (int)UserStatusE.Centaur
                || UData.ToInt32(row.Cells[20].Value.ToString()) == (int)UserStatusE.Kibitzer)
            {
                if (!String.IsNullOrEmpty(row.Cells[21].Value.ToString()) && Convert.ToBoolean(row.Cells[21].Value.ToString()))
                {
                    MessageForm.Show(this.ParentForm, MsgE.ChallengePauseUser, row.Cells[2].Value.ToString());
                    return;
                }
                //MessageForm.Show(dataGridView1[2, e.RowIndex].Value + " : " + UserStatusE.Idle.ToString());
                ChallengeWindow frm = new ChallengeWindow();
                frm.IsModify = false;
                frm.opponentUserID = SelectedUserId;
                frm.opponentUserName = SelectedUserName;
                frm.opponentRank = SelectedUserRank;
                frm.ShowDialog();
            }
        }

        private void ViewGame(DataGridViewRow row)
        {
            if (Ap.IsGameInProgress)
            {
                return;
            }

            if (Convert.ToInt32(row.Cells[0].Value) == Ap.CurrentUserID)
            {
                return;
            }
            //if (row.Cells[3].Value.ToString() == UserStatusE.Playing.ToString() && Ap.CurrentUser.UserStatusIDE == UserStatusE.Blank)
            if (UData.ToInt32(row.Cells[20].Value.ToString()) == (int)UserStatusE.Playing && (Ap.CurrentUser.UserStatusIDE == UserStatusE.Blank 
                || Ap.CurrentUser.UserStatusIDE == UserStatusE.Engine 
                || Ap.CurrentUser.UserStatusIDE == UserStatusE.Centaur))
            {
                if (row.Cells[16].Value != null && !String.IsNullOrEmpty(row.Cells[16].Value.ToString()))    
                {
                    int GameID = UData.ToInt32(row.Cells[16].Value);
                    SocketClient.AddAudience(GameID);
                    InfinityChess.WinForms.MainOnline.ShowMainOnline(GameID);
                }
            }
        }

        public void LoadPlayers()
        {
            if (User.IsInRole(RoleE.Admin))
            {
                tsmBan.Visible = true;
                tsmiKickUser.Visible = true;
                blockIPToolStripMenuItem.Visible = true;
                toolStripSeparator1.Visible = true;
                //blockMachineToolStripMenuItem.Visible = true;
            }
            else
            {
                tsmBan.Visible = false;
                tsmiKickUser.Visible = false;
                blockIPToolStripMenuItem.Visible = false;
                toolStripSeparator1.Visible = false;
                //blockMachineToolStripMenuItem.Visible = false;
            }
            dataGridView1.AllowUserToResizeColumns = true;
            this.Cursor = System.Windows.Forms.Cursors.Default;

            if (!Ap.Options.ShowHorizontalGrid && !Ap.Options.ShowVerticalGrid)
            {
                dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            }
            else if (Ap.Options.ShowHorizontalGrid && !Ap.Options.ShowVerticalGrid)
            {
                dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            }
            else if (Ap.Options.ShowVerticalGrid && !Ap.Options.ShowHorizontalGrid)
            {
                dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            }
            else
            {
                dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            }
            dataGridView1.GridColor = ColorTranslator.FromHtml(GridBorderColor);
        }

        public void LoadPlayers(DataTable table)
        {
            int Index = 0;
            int ScrollIndex = 0;
            DataGridViewColumn oldColumn = new DataGridViewColumn();
            SortOrder so = SortOrder.None;
            if (dataGridView1 != null && dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    Index = dataGridView1.SelectedRows[0].Index;
                    ScrollIndex = dataGridView1.FirstDisplayedScrollingRowIndex;
                }

                oldColumn = dataGridView1.SortedColumn;
                so = dataGridView1.SortOrder;
            }

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = null;

            if (Ap.CurrentUser.HumanRankIDE == RankE.Guest && Ap.SelectedRoomID != (int)RoomE.Cafe && Ap.SelectedRoomID != (int)RoomE.Broadcasts && Ap.SelectedRoomID != (int)RoomE.EngineHall)
            {
                return;
            }

            RefreshGrid(table);  

            if (oldColumn != null)
            {
                switch (so)
                {
                    case SortOrder.Ascending:
                        this.dataGridView1.Sort(oldColumn, ListSortDirection.Ascending);
                        break;
                    case SortOrder.Descending:
                        this.dataGridView1.Sort(oldColumn, ListSortDirection.Descending);
                        break;
                    case SortOrder.None:
                        break;
                    default:
                        break;
                }
            }
            //dataGridView1.Refresh();
            if (dataGridView1.Rows.Count > Index)
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = ScrollIndex;
                dataGridView1.Rows[Index].Selected = true;
            }
            InitFilter();
        }

        private void RefreshGrid()
        {
            RefreshGrid((DataTable)dataGridView1.DataSource);
        }

        private void RefreshGrid(DataTable table)
        {
            dataGridView1.DataSource = Filter.SearchByValue(table, toolStripComboBox1, toolStripTextBox1);
            HideColumn(table, "TeamName");
        }

        private void HideColumn(DataTable table, string columnName)
        {
            if (table != null)
            {

                if (table.Rows.Count > 0)
                {
                    if (table.Rows[0]["TournamentTypeID"].ToString() == "4")
                    {
                        if (dataGridView1.Columns.Contains("TeamName"))
                        {
                            dataGridView1.Columns["TeamName"].Visible = true;
                            isTrue = true;
                        }
                    }
                    else
                    {
                        if (dataGridView1.Columns.Contains("TeamName"))
                        {
                            dataGridView1.Columns["TeamName"].Visible = false;
                            isTrue = false;
                        }
                    }
                }
            }
        }

        #endregion

        #region Events

        private void PlayersUc_Load(object sender, EventArgs e)
        {
            LoadPlayers();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 1:
                    SetRank(e);
                    break;
                case 21:
                    SetPause(e);
                    break;
                case 12:
                    SetFlag(e);
                    break;
                case 15:
                    SetInternet(e);
                    break;
            }
        }

        private void SetInternet(DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1["Internet", e.RowIndex].Value != null && dataGridView1["Internet", e.RowIndex].Value.ToString() != "" && dataGridView1["Internet", e.RowIndex].Value.ToString() != "0")
            {
                Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Internet\" + dataGridView1["Internet", e.RowIndex].Value + ".PNG");
                e.Value = item;
                dataGridView1["Internet", e.RowIndex].ToolTipText = dataGridView1["InternetToolTip", e.RowIndex].Value.ToString();
            }
            else
            {
                Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Flags\244.PNG");
                e.Value = item;
            }
        }

        private void SetFlag(DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1["CountryID", e.RowIndex].Value != null && dataGridView1["CountryID", e.RowIndex].Value.ToString() != "" && dataGridView1["CountryID", e.RowIndex].Value.ToString() != "0")
            {
                Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Flags\" + dataGridView1["CountryID", e.RowIndex].Value + ".PNG");
                e.Value = item;
                dataGridView1["Nation", e.RowIndex].ToolTipText = dataGridView1["CountryName", e.RowIndex].Value.ToString();
            }
            else
            {
                Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Flags\244.PNG");
                e.Value = item;
            }
        }

        private void SetPause(DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1["IsPause", e.RowIndex].Value != null && dataGridView1["IsPause", e.RowIndex].Value.ToString() == "true")
            {
                if (string.IsNullOrEmpty(e.Value.ToString()))
                    e.Value = "Pause";
                else
                    e.Value = e.Value + "/Pause";
            }
            if (dataGridView1["IsIdle", e.RowIndex].Value != null && dataGridView1["IsIdle", e.RowIndex].Value.ToString() == "true")
            {
                if (string.IsNullOrEmpty(e.Value.ToString()))
                    e.Value = "Idle";
                else
                    e.Value = e.Value + "/Idle";
            }
        }

        private void SetRank(DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1["RoleID", e.RowIndex].Value != null && dataGridView1["RoleID", e.RowIndex].Value.ToString() != "" && dataGridView1["RoleID", e.RowIndex].Value.ToString() == "1")
            {
                //Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Ranks\A.PNG");
                e.Value = Ap.GetUserRankImage("Admin");
            }
            else if (dataGridView1["Rank", e.RowIndex].Value != null && dataGridView1["Rank", e.RowIndex].Value.ToString() != "" && dataGridView1["Rank", e.RowIndex].Value.ToString() != "0")
            {
                //Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Ranks\" + dataGridView1["Rank", e.RowIndex].Value + ".PNG");
                e.Value = Ap.GetUserRankImage(dataGridView1["Rank", e.RowIndex].Value.ToString());
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() == UserStatusE.Playing.ToString())
            {
                ViewGame(dataGridView1.Rows[e.RowIndex]);
            }
            else
            {
                ChallengeGame(dataGridView1.Rows[e.RowIndex]);
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hti = dataGridView1.HitTest(e.X, e.Y);
            if (hti.RowIndex == -1)
            {
                return;
            }
            if (e.Button == MouseButtons.Right)
            {

                dataGridView1.CurrentCell = dataGridView1.Rows[hti.RowIndex].Cells[hti.ColumnIndex];

                if (Convert.ToInt32(dataGridView1["UserID", hti.RowIndex].Value) == 1)
                {
                    tsmBan.Visible = false;
                    tsmiKickUser.Visible = false;
                    blockIPToolStripMenuItem.Visible = false;
                    toolStripSeparator1.Visible = false;
                }
                else if (User.IsInRole(RoleE.Admin))
                {
                    tsmBan.Visible = true;
                    tsmiKickUser.Visible = true;
                    blockIPToolStripMenuItem.Visible = true;
                    toolStripSeparator1.Visible = true;
                }
                contextMenuStrip1.Show(dataGridView1, e.Location);
            }
        }

        private void viewRatingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButtonRating.PerformClick();
        }
        
        private void challengeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripButtonChallenge.PerformClick();
        }
        
        private void pictureToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripButtonPicture.PerformClick();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (SelectPlayer != null)
                {
                    int userID = UData.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    string userName = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    string userRank = dataGridView1.SelectedRows[0].Cells[14].Value.ToString();
                    SelectPlayer(userID, userName, userRank);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int userid = SelectedUserId;
            //MessageBox.Show(userid.ToString());
        }

        private void toolStripButtonChallenge_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows == null || dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            foreach (DataGridViewRow dgvRow in dataGridView1.SelectedRows)
            {
                try
                {
                    ChallengeGame(dgvRow);
                    //DataRowView drv = (DataRowView)dgvRow.DataBoundItem;
                    break;
                }
                catch (Exception ex)
                {
                    TestDebugger.Instance.WriteError(ex);
                    MessageForm.Error(this.ParentForm, MsgE.ErrorMessage, ex.Message);
                }
            }
        }

        private void toolStripButtonFollow_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount <= 0 || dataGridView1.SelectedRows == null || dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            foreach (DataGridViewRow dgvRow in dataGridView1.SelectedRows)
            {
                ViewGame(dgvRow);
                break;
            }
        }

        private void toolStripButtonPicture_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount <= 0 || dataGridView1.SelectedRows == null || dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (!Ap.CurrentUser.IsGuest)
                {
                    int i = dataGridView1.CurrentRow.Index;
                    if (dataGridView1["Rank", i].Value.ToString() != "Guest")
                    {
                        PersonalInformation frm = new PersonalInformation();
                        
                        frm.UserID = SelectedUserId;
                        frm.UserName = SelectedUserName;
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageForm.Show(this.ParentForm, MsgE.ErrorViewGuestPicture);
                    }
                }
                else
                {
                    MessageForm.Show(this.ParentForm, MsgE.ErrorViewUserPicture);
                }
            }
        }

        private void toolStripButtonRating_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount <= 0 || dataGridView1.SelectedRows == null || dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (!Ap.CurrentUser.IsGuest)
                {
                    int i = dataGridView1.CurrentRow.Index;

                    if (dataGridView1["Rank", i].Value.ToString() != "Guest")
                    {
                        RatedGameResult frm = new RatedGameResult();
                        frm.UserID = SelectedUserId;
                        frm.UserName = SelectedUserName;
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageForm.Show(this.ParentForm, MsgE.ErrorViewGuestRating);
                    }
                }
                else
                {
                    MessageForm.Show(this.ParentForm, MsgE.ErrorViewUserRating);
                }
            }
        }

        private void tsRefresh_Click(object sender, EventArgs e)
        {
            if (RefreshData != null)
            {
                RefreshData(this, EventArgs.Empty); 
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void followToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButtonFollow.PerformClick();
        }

        #endregion

        #region Ban Kick and Blockip Events
        private void tsmBan_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dgvRow in dataGridView1.SelectedRows)
            {
                try
                {
                    BanUserForm BanUserForm = new BanUserForm(SelectedUserId, SelectedUserName);
                    BanUserForm.ShowInTaskbar = false;
                    BanUserForm.ShowDialog();
                    break;
                }
                catch (Exception ex)
                {
                    TestDebugger.Instance.WriteError(ex);
                    MessageForm.Show(ex);
                }
            }
        }

        private void tsmiKickUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectedUserId == 0)
                    return;

                DialogResult dr = MessageForm.Confirm(this.ParentForm, MsgE.ConfirmKickUser, SelectedUserName);
                if (dr == DialogResult.Yes)
                {
                    SocketClient.KickUser(SelectedUserId);
                }
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }

        private void blockIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedUserId == 0)
                return;

            DialogResult dr = MessageForm.Confirm(this.ParentForm, MsgE.ConfirmBlockIp, SelectedUserName);
            if (dr == DialogResult.Yes)
            {
                SocketClient.BlockIP(SelectedUserId);
            }
        }

        private void blockMachineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedUserId == 0)
                return;

            DialogResult dr = MessageForm.Confirm(this.ParentForm, MsgE.ConfirmBlockMachine, SelectedUserName);
            if (dr == DialogResult.Yes)
                SocketClient.BlockMachine(SelectedUserId);
        }

        #endregion        

        #region Overrrides

        protected override string GetPersistString()
        {
            return Guid;
        }

        #endregion

        
        
        

    }
}
