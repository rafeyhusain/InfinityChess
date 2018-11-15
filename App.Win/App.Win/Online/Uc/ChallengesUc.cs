using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using App.Model;
using App.Model.Db;
using WeifenLuo.WinFormsUI.Docking;

namespace App.Win
{
    public partial class ChallengesUc : DockContent
    {
        #region DataMember

        
        
        #endregion

        #region Properties

        public const string Guid = "ad140ff2-50b5-4747-8c0a-08c5c2ada813";

        public static ChallengesUc Instance
        {
            [System.Diagnostics.DebuggerStepThrough]
            get;
            [System.Diagnostics.DebuggerStepThrough]
            private set;
        }
        #endregion

        #region Constructor
        public ChallengesUc()
        {
            InitializeComponent();
            Instance = this;
        } 

        #endregion

        #region Helper
        public void LoadChallenges(DataTable table)
        {
            if (AutometicAcceptTournamentChallenges(table))
            {
                dataGridView1.DataSource = null;
                return;
            }

            if (Ap.CurrentUser.IsPause)
            {
                return;
            }

            int index = 0;
            DataGridViewColumn oldColumn = new DataGridViewColumn();
            SortOrder so = SortOrder.None;

            if (dataGridView1 != null && dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    index = dataGridView1.SelectedRows[0].Index;
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

            table = CheckUserFormula(table);

            if (table == null)
            {
                AutometicAcceptChallenges(table);
                return;
            }
            //DataRow[] dr = table.Select("ChallengerUserID <> " + Ap.CurrentUserID + " AND Type = " + (int)ChallengeTypeE.Decline);
            DataTable dt = new DataTable();
            dt = table.Clone();

            foreach (DataRow dr in table.Rows)
            {
                if (UData.ToInt32(dr["ChallengerUserID"].ToString()) != Ap.CurrentUserID && UData.ToInt32(dr["Type"].ToString()) == (int)ChallengeTypeE.Decline)
                {
                    //DO NOTHING
                }
                else
                {
                    dt.ImportRow(dr);
                }
            }

            dataGridView1.DataSource = dt;
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
            if (dataGridView1.Rows.Count > index)
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = index;
                dataGridView1.Rows[index].Selected = true;
            }

            AutometicAcceptChallenges(dt);
        }

        private void AutometicAcceptChallenges(DataTable dt)
        {
            if (Ap.IsGameInProgress)
            {
                return;
            }

            if ((Ap.SelectedRoomID == (int)RoomE.ComputerChess || Ap.SelectedRoomID == (int)RoomE.EngineHall || Ap.SelectedRoomID == (int)RoomE.FreestyleChess || Ap.SelectedRoomID == (int)RoomE.TestRoom) && Ap.PlayingMode.ChessTypeID == (int)ChessTypeE.Engine && Ap.CurrentUser.UserStatusIDE == UserStatusE.Engine)
            {
                if (PlayingModeData.Instance.AutometicAccepts && dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Select("ChessTypeID=2 AND ChallengeStatusID=1")[0];

                    foreach (DataGridViewRow item in dataGridView1.Rows)
                    {
                        if (item.Cells[0].Value == dr[0])
                        {
                            item.Selected = true;
                            toolStripButtonAccept.PerformClick();
                            return;
                        }
                    }
                }
                if (PlayingModeData.Instance.AutometicChallenges && Ap.CanAutoChallenge)
                {
                    Ap.CanAutoChallenge = false;
                    GameType gameTypeIDE = GameTime.GetGameType(PlayingModeData.Instance.Time, 0);
                    DataSet ds = SocketClient.AddChallengeData(Ap.CurrentUserID, 0, ChallengeTypeE.Seek, gameTypeIDE, ColorE.Autometic, Ap.SelectedRoomID, PlayingModeData.Instance.Time, PlayingModeData.Instance.GainPerMove, 2, true, true, false, string.Empty, 0, 0);
                    ChallengesUc.Instance.LoadChallenges(ds.Tables[0]);
                }
            }
        }

        private bool AutometicAcceptTournamentChallenges(DataTable dt)
        {
            if (dt == null)
            {
                return false;
            }

            if (Ap.IsGameInProgress)
            {
                return false;
            }

            foreach (DataRow row in dt.Rows)
            {
                Challenge c = new Challenge(Cxt.Instance, row);
                if (c.IsTournamentMatch && c.AmIOpponent)
                {
                    InfinityChess.WinForms.MainOnline.ShowMainOnline(c.ID, ChallengeStatusE.Seeking, 0);
                    Ap.CanAutoChallenge = true;
                    return true;
                }
                else if (c.IsTournamentMatch && c.AmIChallenger)
                {
                    return true;
                }
            }

            return false;
        }

        private DataTable CheckUserFormula(DataTable dt)
        {
            if (UserFormulas.Instance == null)
            {
                return dt;
            }

            UserFormula formula = UserFormulas.Instance.GetUserFormula();
            if (dt == null || dt.Rows.Count <= 0 || formula == null || !formula.IsActive)
            {
                return dt;
            }

            DataTable FilteredTable = new DataTable();
            try
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = "ChallengerUserID = " + Ap.CurrentUserID;
                FilteredTable = dv.ToTable();

                DataTable table = new DataTable();
                DataTable table1 = new DataTable();
                StringBuilder QueryFilter = new StringBuilder();

                int internetID = 5;
                if (formula.IsFastInternetOnly)
                {
                    internetID = 2;
                }

                if (formula.IsNoComputer)
                {
                    QueryFilter.Append("ChessTypeID <> 2 AND ");
                }

                if (formula.IsRated && !formula.IsUnrated)
                {
                    QueryFilter.Append("Condition = true AND ");
                }

                else if (!formula.IsRated && formula.IsUnrated)
                {
                    QueryFilter.Append("Condition = false AND ");
                }
                else if (!formula.IsRated && !formula.IsUnrated)
                {
                    QueryFilter.Append("(Condition = false AND Condition = true) AND ");
                }

                QueryFilter.Append("(GainPerMoveMin >= " + formula.MinGainPerMove + " AND " + " GainPerMoveMin<= " + formula.MaxGainPerMove + ") AND ");
                QueryFilter.Append("(GameTime >= " + formula.MinTime + " AND " + " GameTime<= " + formula.MaxTime + ")");


                string ChallengerRankID;
                if (formula.RankID == 7)
                {
                    ChallengerRankID = "ChallengerRankID <= " + formula.RankID;
                }
                else
                {
                    ChallengerRankID = "(ChallengerRankID <> 7 AND ChallengerRankID >= " + formula.RankID + ")";
                }

                dv = new DataView(dt);
                dv.RowFilter = "ChallengerUserID <> " + Ap.CurrentUserID + " AND InternetC <= " + internetID + " AND ChallengerElo >= " + formula.MinElo + " AND ChallengerElo <= " + formula.MaxElo + " AND " + ChallengerRankID + " AND Type = 1 AND " + QueryFilter;
                table = dv.ToTable();

                dv = new DataView(dt);
                dv.RowFilter = "ChallengerUserID <> " + Ap.CurrentUserID + " AND InternetC <= " + internetID + " AND (ChallengerElo >= " + formula.MinElo + " AND ChallengerElo <= " + formula.MaxElo + ") AND " + ChallengerRankID + " AND Type <> 1 AND " + QueryFilter;
                table1 = dv.ToTable();

                FilteredTable.Merge(table);
                FilteredTable.Merge(table1);

                foreach (DataRow item in FilteredTable.Rows)
                {
                    DataRow r = dt.Select("ChallengeID = " + item["ChallengeID"])[0];
                    dt.Rows.Remove(r);
                }


                dv = new DataView(dt);
                dv.RowFilter = "Type <> 1 AND TournamentMatchID = 0";
                dt = dv.ToTable();

                if (dt.Rows.Count > 0)
                {
                    SocketClient.DeclineChallenges(dt);
                }
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
            }
            return FilteredTable;
        }

        private void AcceptChallenge(int i)
        {
            if (Ap.IsGameInProgress)
            {
                //MessageForm.Show(this.ParentForm, MsgE.ErrorRoomChange);
                ChatClient.Write(ChatTypeE.OnlineClient, ChatMessageTypeE.Warning, ChatTypeE.OnlineClient, MsgE.ErrorRoomChange,0);
                return;
            }

            if (dataGridView1["ChallengerID", i].Value.ToString() != Ap.CurrentUserID.ToString())
            {
                if ((dataGridView1["Conditions", i].Value.ToString() == "true" || dataGridView1["Conditions", i].Value.ToString() == "Rated") && Ap.CurrentUser.IsGuest)
                {
                    MessageForm.Show(this.ParentForm, MsgE.ErrorGuestAcceptChallenge);
                    return;
                }
                
                if (dataGridView1["challengeStatusID", i].Value.ToString() == "1")
                {
                    int challengeID = UData.ToInt32(dataGridView1[0, i].Value);

                    InfinityChess.WinForms.MainOnline.LoadGameByChallengeID(challengeID);

                    Ap.CanAutoChallenge = true;
                }
            }
        }
        #endregion

        #region Events

        private void ChallengesUc_Load(object sender, EventArgs e)
        {

        }

        private void withDraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButtonDelete.PerformClick();
        }

        private void acceptToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripButtonAccept.PerformClick();
        }

        private void declineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButtonDelete.PerformClick();
        }

        private void modifyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripButtonModify.PerformClick();
        }

        private void toolStripButtonAccept_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                int i = dataGridView1.CurrentRow.Index;
                AcceptChallenge(i);
            }
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0 && Ap.SelectedRoomID != (int)RoomE.HumanTournaments && Ap.SelectedRoomParentID != (int)RoomE.HumanTournaments)
            {
                int i = dataGridView1.CurrentRow.Index;
                int ChallengeID = UData.ToInt32(dataGridView1["ChallengeID", i].Value);
                int ChallengerID = UData.ToInt32(dataGridView1["ChallengerID", i].Value);
                ChallengeTypeE challengeType = (ChallengeTypeE)UData.ToInt32(dataGridView1["Type", i].Value);
                DataSet ds = SocketClient.DeleteChallenge(ChallengeID, ChallengerID, challengeType);
                if (ds != null && ds.Tables.Count > 0)
                    LoadChallenges(ds.Tables[0]);
            }
        }

        private void toolStripButtonModify_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0 && Ap.SelectedRoomID != (int)RoomE.HumanTournaments && Ap.SelectedRoomParentID != (int)RoomE.HumanTournaments)
            {
                int i = dataGridView1.CurrentRow.Index;

                if (UData.ToInt32(dataGridView1["ChallengerID", i].Value) != Ap.CurrentUserID && UData.ToInt32(dataGridView1["Type", i].Value) != (int)ChallengeTypeE.Seek)
                {
                    ChallengeWindow frm = new ChallengeWindow();
                    frm.IsModify = true;
                    frm.ChallengeID = UData.ToInt32(dataGridView1["ChallengeID", i].Value);
                    frm.opponentUserID = UData.ToInt32(dataGridView1["ChallengerID", i].Value);
                    frm.opponentUserName = dataGridView1["OpponentName", i].Value.ToString();
                    frm.ShowDialog();
                }
            }
        }

        private void toolStripButtonSeek_Click(object sender, EventArgs e)
        {
            if (Ap.IsGameInProgress)
            {
                return;
            }
            if (Ap.SelectedRoomID != (int)RoomE.HumanTournaments && Ap.SelectedRoomParentID != (int)RoomE.HumanTournaments && Ap.SelectedRoomID != (int)RoomE.EngineTournaments && Ap.SelectedRoomParentID != (int)RoomE.EngineTournaments)
            {
                if (Ap.CurrentUser.HumanRankIDE == RankE.Guest && Ap.SelectedRoomID != (int)RoomE.Cafe && Ap.SelectedRoomID != (int)RoomE.Broadcasts && Ap.SelectedRoomID != (int)RoomE.EngineHall)
                {
                    return;
                }
                SeekWindow frm = new SeekWindow();
                frm.ShowDialog();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            AcceptChallenge(e.RowIndex);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 4 || e.ColumnIndex == 10 || e.ColumnIndex == 13 || e.ColumnIndex == 16)
            {
                if (dataGridView1["ChallengerID", e.RowIndex].Value.ToString() == Ap.CurrentUserID.ToString())
                {
                    switch (e.ColumnIndex)
                    {
                        case 1:
                            if (dataGridView1["Type", e.RowIndex].Value != null && dataGridView1["Type", e.RowIndex].Value.ToString() != "")
                            {
                                if (UData.ToInt32(dataGridView1["Type", e.RowIndex].Value) == (int)ChallengeTypeE.Seek)
                                {
                                    Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Challenges\outgoingSeek.png");
                                    e.Value = item;
                                }
                                else if (UData.ToInt32(dataGridView1["Type", e.RowIndex].Value) == (int)ChallengeTypeE.Challenge)
                                {
                                    Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Challenges\outgoing.png");
                                    e.Value = item;
                                }
                                else if (UData.ToInt32(dataGridView1["Type", e.RowIndex].Value) == (int)ChallengeTypeE.Modify)
                                {
                                    Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Challenges\modify.ico");
                                    e.Value = item;
                                }
                                else
                                {
                                    Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Challenges\decline.png");
                                    e.Value = item;
                                }
                            }
                            break;
                        case 4:
                            e.Value = dataGridView1["OpponentName", e.RowIndex].Value;
                            break;
                        case 10:
                            if (dataGridView1["OpponentElo", e.RowIndex].Value.ToString() == "0")
                                e.Value = "";
                            else
                                e.Value = dataGridView1["OpponentElo", e.RowIndex].Value;
                            break;
                        case 13:
                            if (dataGridView1["Type", e.RowIndex].Value != null && dataGridView1["Type", e.RowIndex].Value.ToString() != "")
                            {
                                if (UData.ToInt32(dataGridView1["Type", e.RowIndex].Value) == (int)ChallengeTypeE.Seek)
                                {
                                    e.Value = "Seek";
                                }
                                else if (UData.ToInt32(dataGridView1["Type", e.RowIndex].Value) == (int)ChallengeTypeE.Challenge)
                                {
                                    e.Value = "Outgoing";
                                }
                                else if (UData.ToInt32(dataGridView1["Type", e.RowIndex].Value) == (int)ChallengeTypeE.Modify)
                                {
                                    e.Value = "Modify";
                                }
                                else
                                {
                                    e.Value = "Decline";
                                }
                            }
                            break;
                        case 16:
                            if (dataGridView1["InternetO", e.RowIndex].Value != null && dataGridView1["InternetO", e.RowIndex].Value.ToString() != "" && dataGridView1["InternetO", e.RowIndex].Value.ToString() != "0")
                            {
                                Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Internet\" + dataGridView1["InternetO", e.RowIndex].Value + ".PNG");
                                e.Value = item;
                                dataGridView1["Internet", e.RowIndex].ToolTipText = dataGridView1["InternetTooltipO", e.RowIndex].Value.ToString();
                            }
                            else
                            {
                                Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Flags\244.PNG");
                                e.Value = item;
                            }
                            break;
                    }

                }
                else
                {
                    switch (e.ColumnIndex)
                    {
                        case 1:
                            if (dataGridView1["Type", e.RowIndex].Value != null && dataGridView1["Type", e.RowIndex].Value.ToString() != "")
                            {
                                if (UData.ToInt32(dataGridView1["Type", e.RowIndex].Value) == (int)ChallengeTypeE.Seek)
                                {
                                    Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Challenges\incomingSeek.png");
                                    e.Value = item;
                                }
                                else if (UData.ToInt32(dataGridView1["Type", e.RowIndex].Value) == (int)ChallengeTypeE.Modify)
                                {
                                    Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Challenges\modify.ico");
                                    e.Value = item;
                                }
                                else
                                {
                                    Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Challenges\incoming.png");
                                    e.Value = item;
                                }
                            }
                            break;
                        case 4:
                            e.Value = dataGridView1["ChallengerName", e.RowIndex].Value;
                            break;
                        case 10:
                            if (dataGridView1["OpponentElo", e.RowIndex].Value.ToString() == "0")
                                e.Value = "";
                            else
                                e.Value = dataGridView1["ChallengerElo", e.RowIndex].Value;
                            break;
                        case 13:
                            if (dataGridView1["Type", e.RowIndex].Value != null && dataGridView1["Type", e.RowIndex].Value.ToString() != "")
                            {
                                if (UData.ToInt32(dataGridView1["Type", e.RowIndex].Value) == (int)ChallengeTypeE.Seek)
                                {
                                    e.Value = "Seek";
                                }
                                else if (UData.ToInt32(dataGridView1["Type", e.RowIndex].Value) == (int)ChallengeTypeE.Modify)
                                {
                                    e.Value = "Modify";
                                }
                                else
                                {
                                    e.Value = "Incoming";
                                }
                            }
                            break;
                        case 16:
                            if (dataGridView1["InternetC", e.RowIndex].Value != null && dataGridView1["InternetC", e.RowIndex].Value.ToString() != "" && dataGridView1["InternetC", e.RowIndex].Value.ToString() != "0")
                            {
                                Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Internet\" + dataGridView1["InternetC", e.RowIndex].Value + ".PNG");
                                e.Value = item;
                                dataGridView1["Internet", e.RowIndex].ToolTipText = dataGridView1["InternetTooltipC", e.RowIndex].Value.ToString();
                            }
                            else
                            {
                                Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Flags\244.PNG");
                                e.Value = item;
                            }
                            break;
                    }
                }
            }
            if (e.ColumnIndex == 7)
            {
                if (dataGridView1[7, e.RowIndex].Value != null && Convert.ToBoolean(dataGridView1[7, e.RowIndex].Value.ToString()))
                {
                    e.Value = "Rated";
                }
                else
                {
                    if (Convert.ToBoolean(dataGridView1["IsChallengerSendsGame", e.RowIndex].Value))
                    {
                        e.Value = "Unrated, Send Opening";
                    }
                    else
                    {
                        e.Value = "Unrated";
                    }
                }
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hti = dataGridView1.HitTest(e.X, e.Y);
            if (hti.RowIndex == -1)
            {
                return;
            }
            if (e.Button == MouseButtons.Right && Ap.SelectedRoomID != (int)RoomE.HumanTournaments && Ap.SelectedRoomParentID != (int)RoomE.HumanTournaments)
            {
                if (dataGridView1.Rows[hti.RowIndex].Cells[2].Value.ToString() == Ap.CurrentUserID.ToString())
                {
                    contextMenuStrip1.Items[0].Visible = true;
                    contextMenuStrip1.Items[1].Visible = false;
                    contextMenuStrip1.Items[2].Visible = false;
                    contextMenuStrip1.Items[3].Visible = false;
                }
                else
                {
                    contextMenuStrip1.Items[0].Visible = false;
                    contextMenuStrip1.Items[1].Visible = true;
                    contextMenuStrip1.Items[2].Visible = true;
                    contextMenuStrip1.Items[3].Visible = true;
                }
                dataGridView1.CurrentCell = dataGridView1.Rows[hti.RowIndex].Cells[hti.ColumnIndex];
                contextMenuStrip1.Show(dataGridView1, e.Location);
            }
        }

        private void chkPause_CheckedChanged(object sender, EventArgs e)
        {
            SocketClient.PauseUser(chkPause.Checked);
            Ap.CurrentUser.IsPause = chkPause.Checked;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Formula frm = new Formula();
            frm.ShowDialog();
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
