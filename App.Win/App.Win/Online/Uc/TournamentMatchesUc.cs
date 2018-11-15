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
    public partial class TournamentMatchesUc : UserControl
    {
        #region Data Members
        DataTable table = null;
        DataTable filterTable = null;
        public FilterItems Filter = new FilterItems();
        public App.Model.Db.Tournament Tournament = null;
        public bool IsTournamentDirector = false;

        #endregion

        #region Ctor

        public TournamentMatchesUc()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public int SelectedID
        {
            get
            {
                if (dgvMatches.DataSource == null)
                {
                    return 0;
                }

                if (dgvMatches.SelectedCells.Count < 1)
                {
                    return 0;
                }

                return BaseItem.ToInt32(((DataTable)dgvMatches.DataSource).Rows[dgvMatches.SelectedCells[0].RowIndex]["TournamentMatchID"]);
            }
        }

        #endregion
        
        #region GridTable
        public DataTable GridTable
        {
            get { return (DataTable)dgvMatches.DataSource; }
        }
        #endregion

        #region Load
        private void MatchesUc_Load(object sender, EventArgs e)
        {
            HideTeam();
            RefreshGrid();
            InitFilter();
        }
        #endregion

        #region Grid

        int childCounter = 0;
        bool isTrue = false;

        #region Formatting
        private void dgvMatches_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int parentMatchID = 0;
            //childCounter = 0;
            if (filterTable == null)
            {
                filterTable = table.Copy();
            }

            if (filterTable.Rows.Count == 0)
            {
                return;
            }

            if (e.RowIndex > filterTable.Rows.Count)
            {
                return;
            }

            if (filterTable.Rows[e.RowIndex] == null)
            {
                return;
            }
            TournamentMatch m = new TournamentMatch(Ap.Cxt, filterTable.Rows[e.RowIndex]);

            if (m.ParentMatchID != 0)
            {
                parentMatchID = Convert.ToInt32(filterTable.Rows[e.RowIndex]["ParentMatchID"]);
            }


            switch (e.ColumnIndex)
            {
                case 0:
                    SetCheckboxReadOnly(e);
                    break;
                case 1:
                    SetChildRoundNo(e, parentMatchID);
                    break;
                case 2:
                    SetRankImage(e, "WRank", "WRoleID");
                    break;
                case 4:
                    SetPlayerName(e, "WhiteUserName2");
                    break;
                case 6:
                    SetUserStatusColor(e, "internetW");
                    break;
                case 11:
                    SetUserStatusColor(e, "internetB");
                    break;
                case 5:
                    SetRating(e);
                    break;
                case 7:
                    SetRankImage(e, "BRank", "BRoleID");
                    break;
                case 9:
                    SetPlayerName(e, "BlackUserName2");
                    break;
                case 10:
                    SetRating(e);
                    break;
                case 12:
                    SetTimeControl(e);
                    break;
                case 13:
                    SetDate(e);
                    break;
                case 14:
                    SetTime(e);
                    break;
                case 15:
                    SetMatchStatus(e);
                    break;
            }
        }

        private void SetPlayerName(DataGridViewCellFormattingEventArgs e, string playerName)
        {
            if (filterTable.Rows[e.RowIndex][playerName].ToString() != string.Empty)
            {
                e.Value = filterTable.Rows[e.RowIndex][playerName].ToString() + " ( " + e.Value + " )";
            }
        }

        private void SetTimeControl(DataGridViewCellFormattingEventArgs e)
        {
            if (filterTable.Rows[e.RowIndex]["TimeControlMin"] != DBNull.Value && filterTable.Rows[e.RowIndex]["TimeControlSec"] != DBNull.Value)
            {
                e.Value = filterTable.Rows[e.RowIndex]["TimeControlMin"] + "' + " + filterTable.Rows[e.RowIndex]["TimeControlSec"] + "''";
            }

        }

        private static void SetDate(DataGridViewCellFormattingEventArgs e)
        {
            e.Value = DateTime.Parse(e.Value.ToString()).ToShortDateString();
        }

        private static void SetTime(DataGridViewCellFormattingEventArgs e)
        {
            e.Value = DateTime.Parse(e.Value.ToString()).ToShortTimeString();
        }

        private void SetMatchStatus(DataGridViewCellFormattingEventArgs e)
        {
            if (filterTable.Rows[e.RowIndex]["GameResult"] == DBNull.Value)
            {
                e.Value = filterTable.Rows[e.RowIndex]["TournamentMatchStatus"];
            }
            else if (BaseItem.ToString(filterTable.Rows[e.RowIndex]["GameResult"]) == "6" || filterTable.Rows[e.RowIndex]["GameResult"].ToString() == "")
            {
                e.Value = filterTable.Rows[e.RowIndex]["TournamentMatchStatus"];
            }
            else
            {
                e.Value = filterTable.Rows[e.RowIndex]["GameResult"];
            }
        }

        private static void SetRating(DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value.ToString() == "0")
            {
                e.Value = "";
            }
        }

        private void SetChildRoundNo(DataGridViewCellFormattingEventArgs e, int parentMatchID)
        {

            if (dgvMatches.Rows[e.RowIndex].Cells["Round"].Value.ToString() == "0")
            {
                e.Value = "Preliminary";
                return;
            }
            
            //if (parentMatchID != 0)
            //{
            //    childCounter += 1;
            //    e.Value = string.Format(filterTable.Rows[e.RowIndex]["Round"].ToString() + ".{0}", childCounter.ToString());
            //}
            //else
            //{
            //    childCounter = 0;
            //}
        }

        private void SetCheckboxReadOnly(DataGridViewCellFormattingEventArgs e)
        {
            int player1 = Convert.ToInt32(filterTable.Rows[e.RowIndex]["WhiteUserID"]);
            int player2 = Convert.ToInt32(filterTable.Rows[e.RowIndex]["BlackUserID"]);

            if (player1 == 2 || player2 == 2)
            {
                DataGridViewCheckBoxCell chk = dgvMatches.Rows[e.RowIndex].Cells["Select"] as DataGridViewCheckBoxCell;
                chk.ReadOnly = true;
            }
        }

        private void SetUserStatusColor(DataGridViewCellFormattingEventArgs e, string columnName)
        {
            Image item = null;

            if (filterTable.Rows[e.RowIndex][columnName].ToString() == "-1")
            {
                item = Image.FromFile(App.Model.Ap.FolderFlags + "229.PNG");
                e.Value = item;

                dgvMatches[columnName, e.RowIndex].Style.BackColor = Color.LightGray;

                if (columnName.ToLower() == "internetw")
                {
                    dgvMatches["InternetW", e.RowIndex].ToolTipText = "Player Offline";
                }
                else
                {
                    dgvMatches["InternetB", e.RowIndex].ToolTipText = "Player Offline";
                }

                return;
            }

            item = Image.FromFile(App.Model.Ap.FolderImages + @"Internet\" + filterTable.Rows[e.RowIndex][columnName].ToString() + ".PNG");
            e.Value = item;

            if (columnName.ToLower() == "internetw")
            {
                dgvMatches["InternetW", e.RowIndex].ToolTipText = table.Rows[e.RowIndex]["InternetTooltipW"].ToString();

                //dgvMatches["InternetTooltipW", e.RowIndex].ToolTipText = dgvMatches["InternetTooltipW", e.RowIndex].Value.ToString();
            }
            else
            {
                dgvMatches["InternetB", e.RowIndex].ToolTipText = table.Rows[e.RowIndex]["InternetTooltipB"].ToString();
                //dgvMatches["InternetTooltipB", e.RowIndex].ToolTipText = dgvMatches["InternetTooltipB", e.RowIndex].Value.ToString();
            }
        }

        private void dgvMatches_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //dgvMatches.Refresh();

        }

        private void dgvMatches_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //dgvMatches.Refresh();


        }

        private void dgvMatches_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvMatches.Refresh();
        }

        private void dgvMatches_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataTable dt = (DataTable)dgvMatches.DataSource;
            if (isTrue)
            {

                dt.DefaultView.Sort = dgvMatches.Columns[e.ColumnIndex].Name + " ASC";
                RefreshGrid(dt);
                //dgvMatches.Sort(dgvMatches.Columns[e.ColumnIndex], ListSortDirection.Ascending);
                isTrue = false;
            }
            else
            {
                dt.DefaultView.Sort = dgvMatches.Columns[e.ColumnIndex].Name + " DESC";
                RefreshGrid(dt);
                isTrue = true;
            }

        }

        #endregion

        #region Dirty State change
        private void dgvMatches_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvMatches.CurrentCell is System.Windows.Forms.DataGridViewCheckBoxCell)
            {
                dgvMatches.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        #endregion


        #endregion

        #region Validation



        bool IsRoundStarted()
        {

            if (table == null)
            {
                return false;
            }
            short count = 0;
            int round = 0;
            foreach (DataRow item in table.Rows)
            {
                TournamentMatch tournamentMatch = new TournamentMatch(Cxt.Instance, item);

                if (tournamentMatch.TournamentMatchStatusE == TournamentMatchStatusE.InProgress)
                {
                    if (tournamentMatch.Round != round)
                    {
                        if (count > 1)
                            break;
                        round = tournamentMatch.Round;
                        count++;
                    }
                }
            }

            if (count > 1)
            {
                MessageForm.Error(Msg.GetMsg(MsgE.ErrorTournamentNextRoundStarted, ""));
                //RsPanel.ShowMessage(Msg.GetMsg(MsgE.ErrorTournamentMultipleRounds), true);
                return false;
            }
            else
            {
                return true;

            }

        }

        bool IsRoundAlreadyStarted()
        {
            short count = 0;
            int round = 0;
            foreach (DataRow item in table.Rows)
            {
                TournamentMatch tournamentMatch = new TournamentMatch(Cxt.Instance, item);

                if (tournamentMatch.TournamentMatchStatusE == TournamentMatchStatusE.InProgress)
                {
                    if (tournamentMatch.Round != round)
                    {
                        if (count > 1)
                            break;
                        round = tournamentMatch.Round;
                        count++;
                    }
                }
            }

            if (count > 1)
            {
                MessageForm.Error(Msg.GetMsg(MsgE.ErrorTournamentNextRoundStarted, ""));
                //RsPanel.ShowMessage(Msg.GetMsg(MsgE.ErrorTournamentMultipleRounds), true);
                return false;
            }
            else
            {
                return true;

            }

        }

        #endregion

        #region Toolbar

        #region Events

        private void tsbStartRound_Click(object sender, EventArgs e)
        {
            if (this.Tournament == null)
            {
                return;
            }
            if (this.Tournament.TournamentID == 0)
            {
                return;
            }

            if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, "start", "round") == DialogResult.Yes)
            {
                if (IsRoundStarted())
                {
                    DataSet ds = SocketClient.StartTournamentRound(this.Tournament.TournamentID);
                    if (ds != null)
                    {
                        if (ds.Tables.Count > 1)
                        {
                            Kv kv = new Kv(ds.Tables[1]);
                            if (kv.GetInt32("Result") > 0)
                            {
                                MessageForm.Error(this.ParentForm, (MsgE)kv.GetInt32("Result"));
                                RefreshGrid();
                                return;
                            }
                            else
                            {
                                RefreshGrid();
                            }
                        }

                    }
                }
            }
        }

        private void tsbStartMatch_Click(object sender, EventArgs e)
        {
            //if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, "update", "matches status" + TournamentMatchStatusE.InProgress.ToString()) == DialogResult.Yes)
            //{
            //    
            UpdateTournamentMatchStatus(TournamentMatchStatusE.InProgress);
            //}
        }

        private void tsbCreateRound_Click(object sender, EventArgs e)
        {
            CreateTournamentRounds();
        }

        private void tsbEditMatch_Click(object sender, EventArgs e)
        {
            int rowIndex = -1;

            int counter = 0;
            foreach (DataGridViewRow row in dgvMatches.Rows)
            {
                if (row.Cells["Select"].Value != null)
                {
                    if ((bool)row.Cells["Select"].Value)
                    {
                        counter++;
                        if (counter > 1)
                        {
                            MessageForm.Error(this.ParentForm, MsgE.ErrorMultipleItemsNotAllowed);
                            return;
                        }
                        rowIndex = row.Index; //Convert.ToInt32(GridTable.Rows[row.Index]["TournamentMatchID"]);                        
                    }
                }
            }

            if (counter == 0)
            {
                MessageForm.Error(this.ParentForm, MsgE.ErrorNoSelection, "match");
                return;
            }

            TournamentMatchStatusE tms = (TournamentMatchStatusE)Convert.ToInt32(GridTable.Rows[rowIndex]["TournamentMatchStatusID"]);
            if (tms != TournamentMatchStatusE.Scheduled)
            {
                MessageForm.Error(this.ParentForm, MsgE.ErrorTournamentMatchNotInStatus, "Scheduled");
                return;
            }

            EditMatch(rowIndex);
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonWatch_Click(object sender, EventArgs e)
        {
            if (dgvMatches.RowCount <= 0 || dgvMatches.SelectedRows == null || dgvMatches.SelectedRows.Count == 0)
            {
                return;
            }

            foreach (DataGridViewRow dgvRow in dgvMatches.SelectedRows)
            {
                ViewGame(dgvRow);
                break;
            }
        }

        private void toolStripButtonStartMatch_Click(object sender, EventArgs e)
        {
            UpdateTournamentMatchStatus(TournamentMatchStatusE.InProgress);
        }

        private void toolStripButtonStartRound_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonCreateRound_Click(object sender, EventArgs e)
        {
            CreateTournamentRounds();
        }

        private void tsbWhiteBye_Click(object sender, EventArgs e)
        {
            UpdateTournamentMatchStatus(TournamentMatchStatusE.WhiteBye);
        }

        private void tsbBlackBye_Click(object sender, EventArgs e)
        {
            UpdateTournamentMatchStatus(TournamentMatchStatusE.BlackBye);
        }

        private void tsbAbsent_Click(object sender, EventArgs e)
        {
            UpdateTournamentMatchStatus(TournamentMatchStatusE.Absent);
        }

        private void tsbPostpone_Click(object sender, EventArgs e)
        {
            UpdateTournamentMatchStatus(TournamentMatchStatusE.Postpond);
        }

        private void forcedWhiteWinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateTournamentMatchStatus(TournamentMatchStatusE.ForcedWhiteWin);
        }

        private void forcedWhiteLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateTournamentMatchStatus(TournamentMatchStatusE.ForcedWhiteLose);
        }

        private void forcedDrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateTournamentMatchStatus(TournamentMatchStatusE.ForcedDraw);
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

        private void tsCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrid(table);
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void tsbSchedule_Click(object sender, EventArgs e)
        {
            UpdateTournamentMatchStatus(TournamentMatchStatusE.Scheduled);
        }

        private void tsbRestartMatch_Click(object sender, EventArgs e)
        {
            RestartTournamentMatch(false, false);
        }

        private void tsbRestartRound_Click(object sender, EventArgs e)
        {
            RestartTournamentMatch(true, false);
        }

        private void tsbRestartMatchLastMove_Click(object sender, EventArgs e)
        {
            RestartTournamentMatch(false, true);
        }

        private void tsbRestartRoundLastMove_Click(object sender, EventArgs e)
        {
            RestartTournamentMatch(true, true);
        }

        #endregion

        #endregion

        #region Helpers

        private void UpdateTournamentMatchStatus(TournamentMatchStatusE tournamentMatchStatusID)
        {
            string matchStatus = string.Empty;

            switch (tournamentMatchStatusID)
            {
                case TournamentMatchStatusE.Scheduled:
                    matchStatus = "Scheduled";
                    break;
                case TournamentMatchStatusE.InProgress:
                    matchStatus = "In Progress";
                    break;
                case TournamentMatchStatusE.Finsihed:
                    break;
                case TournamentMatchStatusE.Postpond:
                    matchStatus = "postponed";
                    break;
                case TournamentMatchStatusE.Absent:
                    matchStatus = "Absent";
                    break;
                case TournamentMatchStatusE.Draw:
                    break;
                case TournamentMatchStatusE.WhiteBye:
                    matchStatus = "White Bye";
                    break;
                case TournamentMatchStatusE.BlackBye:
                    matchStatus = "Black Bye";
                    break;
                case TournamentMatchStatusE.ForcedWhiteWin:
                    matchStatus = "Forced White Win";
                    break;
                case TournamentMatchStatusE.ForcedWhiteLose:
                    matchStatus = "Forced White Lose";
                    break;
                case TournamentMatchStatusE.ForcedDraw:
                    matchStatus = "Forced Draw";
                    break;
                default:
                    break;
            }

            //if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, "update match status to ", matchStatus) == DialogResult.Yes)
            //{
            //    UpdateMatchStatus(tournamentMatchStatusID);
            //}
            UpdateMatchStatus(tournamentMatchStatusID, matchStatus);
        }

        #region UpdateMatchStatus

        private void UpdateMatchStatus(TournamentMatchStatusE tournamentMatchStatusID, string matchStatus)
        {
            if (this.Tournament == null)
            {
                return;
            }
            if (this.Tournament.TournamentID == 0)
            {
                return;
            }

            string matchIDs = string.Empty;

            foreach (DataGridViewRow row in dgvMatches.Rows)
            {
                if (row.Cells["Select"].Value != null)
                {
                    if ((bool)row.Cells["Select"].Value)
                    {
                        if (GridTable.Rows[row.Index]["WhiteUserID"].ToString() != "2" && GridTable.Rows[row.Index]["BlackUserID"].ToString() != "2")
                        {
                            matchIDs += "," + GridTable.Rows[row.Index]["TournamentMatchID"].ToString();
                        }
                    }
                }
            }

            if (matchIDs.Length > 0)
            {
                matchIDs = matchIDs.Remove(0, 1);

                if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, "update match status to ", matchStatus) != DialogResult.Yes)
                {
                    return;
                }

                ProgressForm frmProgress = ProgressForm.Show(this, "Updating match status...");
                DataSet ds = SocketClient.UpdateTournamentMatchStatus(tournamentMatchStatusID, this.Tournament.TournamentID, matchIDs);
                frmProgress.Close();

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
                RefreshGrid();
            }
            else
            {
                MessageForm.Error(this.ParentForm, MsgE.ErrorTournamentMatchStartRequest);
            }
        }

        #endregion

        private void SetRankImage(DataGridViewCellFormattingEventArgs e, string rankColumn, string roleIdColumn)
        {
            if (dgvMatches[roleIdColumn, e.RowIndex].Value != null && dgvMatches[roleIdColumn, e.RowIndex].Value.ToString() != "" && dgvMatches[roleIdColumn, e.RowIndex].Value.ToString() == "1")
            {
                e.Value = Ap.GetUserRankImage("Admin"); //For Admin Image
            }
            else if (dgvMatches[rankColumn, e.RowIndex].Value != null && dgvMatches[rankColumn, e.RowIndex].Value.ToString() != "" && dgvMatches[rankColumn, e.RowIndex].Value.ToString() != "0")
            {
                e.Value = Ap.GetUserRankImage(dgvMatches[rankColumn, e.RowIndex].Value.ToString()); //For User Rank Image
            }
        }

        #region Create Tournament Round
        private void CreateTournamentRounds()
        {

            if (this.Tournament == null)
            {
                return;
            }

            if (this.Tournament.TournamentID == 0)
            {
                return;
            }

            string msgID = string.Empty;
            bool isTrue = false;
            int round = 0;
            
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow item in table.Rows)
                    {
                        TournamentMatchStatusE ts = (TournamentMatchStatusE)Convert.ToInt32(item["TournamentMatchStatusID"]);


                        if (ts != TournamentMatchStatusE.Finsihed && ts != TournamentMatchStatusE.Absent &&
                            Tournament.TournamentTypeIDE != TournamentTypeE.Knockout && Tournament.TournamentTypeIDE != TournamentTypeE.Swiss)
                        {
                            isTrue = true;
                        }
                        
                        round = GetRoundNo(item["Round"].ToString());
                    }

                    if (isTrue)
                    {
                        MessageForm.Show(ParentForm, MsgE.ErrorTournamentNextRoundStarted);
                    }
                    else
                    {
                        DataSet ds = SocketClient.CreateTournamentRounds(Tournament.TournamentID, round + 1);

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

                        if (this.Tournament.TournamentTypeE != TournamentTypeE.Swiss)
                        {
                            //Tournament.TournamentCurrentRound = round + 1;
                        }
                    }
                }
            }
            RefreshGrid();
        }

        #endregion

        #region View Game

        private void ViewGame(DataGridViewRow row)
        {
            //if (Ap.IsGameInProgress)
            //{
            //    return;
            //}

            if (filterTable.Rows.Count == 0)
            {
                return;
            }
            TournamentMatch tm = null;
            DataRow dr = filterTable.Rows[row.Index];

            tm = new TournamentMatch(Ap.Cxt, dr);


            if (tm.WhiteUserID == Ap.CurrentUserID || tm.BlackUserID == Ap.CurrentUserID)
            {
                if (tm.TournamentMatchStatusE == TournamentMatchStatusE.InProgress)
                {
                    return;
                }
            }

            int gameID = SocketClient.GetGameIDByTournamentMatchID(this.SelectedID);

            if (gameID <= 0)
            {
                MessageForm.Show(this.ParentForm, MsgE.InfoGameNotFoundForTournamentMatch);
            }
            else
            {
                if (Ap.CurrentUser.UserStatusIDE == UserStatusE.Blank ||
                            Ap.CurrentUser.UserStatusIDE == UserStatusE.Engine ||
                            Ap.CurrentUser.UserStatusIDE == UserStatusE.Centaur)
                {
                    SocketClient.AddAudience(gameID);
                    InfinityChess.WinForms.MainOnline.ShowMainOnline(gameID);
                }
            }
        }

        #endregion

        private void SetCheck(bool isCheck)
        {
            foreach (DataGridViewRow row in dgvMatches.Rows)
            {
                row.Cells[0].Value = isCheck;
            }
        }

        private void InitFilter()
        {
            Filter.Add("Player1", "White");
            Filter.Add("Player2", "Black");
            Filter.Add("WRating", "White Rating");
            Filter.Add("WRank", "White Rank");
            Filter.Add("BRating", "Black Rating");
            Filter.Add("BRank", "Black Rank");
            Filter.Add("Round", "Round");
            Filter.Add("GameResult", "Match Status");

            if (this.Tournament == null)
            {
                return;
            }

            if (this.Tournament.TournamentID == 0)
            {
                return;
            }

            if (this.Tournament.TournamentTypeIDE == TournamentTypeE.Scheveningen)
            {
                Filter.Add("TeamW", "White Team");
                Filter.Add("TeamB", "Black Team");
            }

            tsCombo.ComboBox.DataSource = Filter.DataTable;
            tsCombo.ComboBox.DisplayMember = "Value";
            tsCombo.ComboBox.ValueMember = "Key";
            //tsCombo.ComboBox.SelectedIndex = 0;
        }

        #region InitFields
        private void InitFields()
        {

            tsbCreateRound.Visible = false;
            tsCreateRoundSeparator.Visible = false;
            if (this.Tournament == null)
            {
                return;
            }

            if (this.Tournament.TournamentID == 0)
            {
                return;
            }

            if (this.Tournament.TournamentTypeIDE == TournamentTypeE.Knockout || this.Tournament.TournamentTypeIDE == TournamentTypeE.Swiss)
            {
                if (this.Tournament.IsTieBreak)
                {
                    //tsbTieBreakMatch.Visible = true;
                }
                tsCreateRoundSeparator.Visible = true;
                tsbCreateRound.Visible = true;
            }

        }
        #endregion

        #endregion

        #region RefreshTab

        #region RefreshTab
        public void RefreshTab()
        {
            RefreshGrid();
        }

        #endregion

        #region Refresh
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

            ProgressForm frmProgress = ProgressForm.Show(this, "Loading Matches...");

            try
            {
                dgvMatches.AutoGenerateColumns = false;

                DataSet ds = SocketClient.GetTournamentMatches(Tournament.TournamentID,Tournament.TournamentTypeE);

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        RefreshGrid(table);
                    }
                    else
                    {
                        dgvMatches.DataSource = null;
                    }
                }
                else
                {
                    dgvMatches.DataSource = null;
                }
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
            filterTable = Filter.SearchByValue(table, tsCombo, tsTextbox);
            dgvMatches.DataSource = filterTable;

            HideTeam();
        }

        #region Hide Column
        void HideTeam()
        {
            if (this.Tournament == null)
            {
                return;
            }

            if (this.Tournament.TournamentID == 0)
            {
                return;
            }

            if (this.Tournament.TournamentTypeIDE != TournamentTypeE.Scheveningen)
            {
                HideColumn("TeamW");
                HideColumn("TeamB");
            }
        }

        private void HideColumn(string columnName)
        {
            if (dgvMatches.Columns.Contains(columnName))
            {
                dgvMatches.Columns[columnName].Visible = false;
            }
        }

        #endregion

        #endregion

        #endregion

        #region AllowEdit
        public void AllowEdit(bool enable)
        {
            tsbStartMatch.Visible = enable;
            tsbCreateRound.Visible = enable;
            tsbMatchStatus.Visible = enable;
            tsbSelect.Visible = enable;
            tsbStartRound.Visible = enable;
            tsCreateRoundSeparator.Visible = enable;
            tsStartRoundSeparator.Visible = enable;
            dgvMatches.Columns[0].Visible = enable;
            tsbRestartRound.Visible = enable;
            tsbEditMatch.Visible = enable;
            tsReStartSetupSeparator.Visible = enable;
            tsbRestartRoundLastMove.Visible = enable;
            IsTournamentDirector = enable;
            if (enable)
            {
                InitFields();
            }
        }
        #endregion

        #region Restart match
        private void RestartTournamentMatch(bool isRound, bool isFromLastMove)
        {
            if (this.Tournament == null)
            {
                return;
            }
            if (this.Tournament.TournamentID == 0)
            {
                return;
            }

            int senderUserID = 0;
            int receiverUserID = 0;
            int tournamentDirectorID = 0;
            string matchIDs = string.Empty;
            string msg = string.Empty;
            ProgressForm frmProgress = null;

            if (IsTournamentDirector)
            {
                #region TournamentDirector
                if (isRound)
                {
                    msg = "Restarting Round Matches...";
                    tournamentDirectorID = Ap.CurrentUserID;
                    senderUserID = tournamentDirectorID;
                }
                else
                {
                    tournamentDirectorID = Ap.CurrentUserID;
                    matchIDs = GetSelectedMatchIDs();

                    if (!String.IsNullOrEmpty(matchIDs))
                    {
                        msg = "Restarting Selected Matches...";
                    }
                    else
                    {
                        MessageForm.Error(this.ParentForm, MsgE.ErrorTournamentMatchRestart, "");
                        return;
                    }
                }

                if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmRestartTournamentMatch) != DialogResult.Yes)
                {
                    return;
                }

                #endregion
            }
            else
            {
                #region Player
                msg = "Restarting Match...";
                TournamentMatch tm = GetCurrentPlayerInProgressMatch();

                if (tm == null)
                {
                    MessageForm.Error(this.ParentForm, MsgE.ErrorTournamentMatchNotInprogress, "");
                    return;
                }

                matchIDs = tm.TournamentMatchID.ToString();
                senderUserID = Ap.CurrentUserID;
                receiverUserID = tm.OpponentUserID(Ap.CurrentUserID);

                if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmRestartTournamentMatch) != DialogResult.Yes)
                {
                    return;
                }

                if (Ap.Game != null)
                {
                    Ap.Game.Pause();
                }
                #endregion
            }

            frmProgress = ProgressForm.Show(this, msg);

            SocketClient.RestartGame(this.Tournament.TournamentID, matchIDs, tournamentDirectorID, senderUserID, receiverUserID, ResetGameE.Asked, isFromLastMove, string.Empty);
            if (Ap.Game != null && Ap.Game.GameId.Length > 0)
            {
                ChatClient.Write(ChatTypeE.GameWindow, ChatMessageTypeE.Info, ChatTypeE.GameWindow, MsgE.InfoTournamentMatchRestartRequest, Convert.ToInt32(Ap.Game.GameId));
            }

            frmProgress.Close();

            RefreshGrid();
        }

        private string GetSelectedMatchIDs()
        {
            string matchIDs = "";

            foreach (DataGridViewRow row in dgvMatches.Rows)
            {
                if (row.Cells["Select"].Value != null)
                {
                    if ((bool)row.Cells["Select"].Value)
                    {
                        matchIDs += "," + GridTable.Rows[row.Index]["TournamentMatchID"].ToString();
                    }
                }
            }

            if (matchIDs.Length > 0)
            {
                matchIDs = matchIDs.Remove(0, 1);
            }

            return matchIDs;
        }

        private TournamentMatch GetCurrentPlayerInProgressMatch()
        {
            DataTable dt = (DataTable)dgvMatches.DataSource;

            if (dt == null)
            {
                return null;
            }

            DataRow[] rows = dt.Select(String.Format("TournamentMatchStatusID=2 AND (WhiteUserID={0} OR BlackUserID={1})", Ap.CurrentUserID, Ap.CurrentUserID));

            if (rows.Length == 0)
            {
                return null;
            }

            TournamentMatch tm = new TournamentMatch(Ap.Cxt, rows[0]);

            return tm;
        }

        #endregion

        #region Restart Match with Setup

        private void tsRestartMatchSetup_Click(object sender, EventArgs e)
        {
            if (dgvMatches.RowCount <= 0)
            {
                return;
            }

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

            int senderUserID = 0;
            int receiverUserID = 0;

            bool IsRestartTournamentDirector = false;
            TournamentMatch tm = GetOpponentAndChallenger(ref IsRestartTournamentDirector);

            if (tm != null)
            {
                senderUserID = Ap.CurrentUserID;
                receiverUserID = tm.OpponentUserID(Ap.CurrentUserID);

                if (Ap.Game != null)
                {
                    Ap.Game.Pause();
                }

                if (receiverUserID > 0 && tm.TournamentMatchID > 0)
                {
                    DialogResult dr = SetupMatch.Show(this.ParentForm, 0, tm.TournamentMatchID, senderUserID, receiverUserID, 0, 0, 0, 0, IsRestartTournamentDirector);
                }
            }
        }

        private TournamentMatch GetOpponentAndChallenger(ref bool IsRestartTournamentDirector)
        {
            DataTable dt = (DataTable)dgvMatches.DataSource;

            if (dt == null)
            {
                return null;
            }

            DataRow[] rows = dt.Select(String.Format("TournamentMatchStatusID=2 AND (WhiteUserID={0} OR BlackUserID={1})", Ap.CurrentUserID, Ap.CurrentUserID));
            IsRestartTournamentDirector = false;

            if (rows.Length == 0)
            {
                string matchId = GetTournamentMatchID().ToString();
                if (matchId == "0")
                {
                    return null;
                }
                rows = dt.Select(String.Format("TournamentMatchStatusID=2 AND (TournamentMatchID={0})", matchId));
                IsRestartTournamentDirector = true;
            }
            else if (IsTournamentDirector)
            {
                IsRestartTournamentDirector = true;
            }

            if (rows.Count() > 0)
            {
                TournamentMatch tm = new TournamentMatch(Ap.Cxt, rows[0]);
                return tm;
            }
            else
            {
                MessageForm.Error(this.ParentForm, MsgE.ErrorTournamentMatchNotInprogress);
                return null;
            }
        }

        private int GetTournamentMatchID()
        {
            int counter = 0, tournamentMatchID = 0;
            foreach (DataGridViewRow row in dgvMatches.Rows)
            {
                if (row.Cells["Select"].Value != null)
                {
                    if ((bool)row.Cells["Select"].Value)
                    {
                        counter++;
                        if (counter > 1)
                        {
                            MessageForm.Error(this.ParentForm, MsgE.ErrorTournamentMultipleMatchSelection);
                            return 0;
                        }
                        tournamentMatchID = Convert.ToInt32(GridTable.Rows[row.Index]["TournamentMatchID"]);
                    }
                }
            }

            if (counter == 0)
            {
                if (IsTournamentDirector)
                {
                    MessageForm.Error(this.ParentForm, MsgE.ErrorTournamentMultipleMatchSelection);
                }
                else
                {
                    MessageForm.Error(this.ParentForm, MsgE.ErrorTournamentMatchNotInprogress);
                }
            }

            return tournamentMatchID;
        }

        #endregion

        #region EditMatch
        void EditMatch(int rowIndex)
        {
            DataTable dt = GridTable;
            string white = dt.Rows[rowIndex]["Player1"].ToString();
            string black = dt.Rows[rowIndex]["Player2"].ToString();

            int player1 = Convert.ToInt32(dt.Rows[rowIndex]["WhiteUserID"]);
            int player2 = Convert.ToInt32(dt.Rows[rowIndex]["BlackUserID"]);

            int round = GetRoundNo(dt.Rows[rowIndex]["Round"].ToString());

            int tournamentMatchID = Convert.ToInt32(dt.Rows[rowIndex]["TournamentMatchID"]);

            int parentMatchID = Convert.ToInt32(dt.Rows[rowIndex]["parentMatchID"]);
            int matchStatusID = Convert.ToInt32(dt.Rows[rowIndex]["TournamentMatchStatusID"]);
            int matchTypeID = Convert.ToInt32(dt.Rows[rowIndex]["TournamentMatchTypeID"]);
            int statusId = Convert.ToInt32(dt.Rows[rowIndex]["StatusID"]);

            MatchEditor frm = new MatchEditor();
            DialogResult dr = frm.Show(this.ParentForm, this.Tournament, tournamentMatchID, white, black, player1, player2, round, parentMatchID,
                                        matchStatusID, matchTypeID, statusId);

            if (dr == DialogResult.OK)
            {
                frm.Close();
                RefreshGrid();
            }
            return;
        }

        private int GetRoundNo(string sRound)
        {
            int round = 0;
            
            if (sRound.Contains("."))
            {
                sRound = sRound.Substring(0, sRound.IndexOf("."));
            }

            round = Convert.ToInt32(sRound);

            return round;
        }

        #endregion

    }
}
