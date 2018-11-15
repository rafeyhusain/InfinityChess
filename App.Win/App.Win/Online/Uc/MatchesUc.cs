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
    public partial class MatchesUc : UserControl
    {
        public FilterItems Filter = new FilterItems();
        
        #region Private
        App.Model.Db.Tournament tournament = null;
        public int TournamentID = 0;

        DataTable table = null;
        
        #endregion

        public MatchesUc()
        {
            InitializeComponent();
        }

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

        #region Properties
        public App.Model.Db.Tournament Tournament
        {
            get
            {
                TournamentDetail TournamentDetail = (TournamentDetail)Parent.FindForm();
                return TournamentDetail.Tournament;
            }
        }

        #region Get EloRating
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

        #endregion 

        private void MatchesUc_Load(object sender, EventArgs e)
        {
            RefreshGrid();
            InitFilter();
        }

        #region Methods
        private void InitFilter()
        {
            Filter.Add("UserName", "Player Name");
            Filter.Add("Country", "Country");
            Filter.Add("Rating", "Rating");
            Filter.Add("Team", "Team");
            Filter.Add("Rank", "Rank");

            tsCombo.ComboBox.DataSource = Filter.DataTable;
            tsCombo.ComboBox.DisplayMember = "Value";
            tsCombo.ComboBox.ValueMember = "Key";
            tsCombo.ComboBox.SelectedIndex = 0;
        }

        private void RefreshTeamGrid(DataTable table)
        {
            dgvMatches.DataSource = Filter.SearchByValue(table, tsCombo, tsTextbox);
        }

        private void RefreshGrid()
        {
            ProgressForm frmProgress = ProgressForm.Show(this, "Loading players...");

            try
            {
                dgvMatches.AutoGenerateColumns = false;

                DataSet ds = SocketClient.GetTournamentMatchs(this.TournamentID);

                if (ds != null)
                {
                    table = ds.Tables[0];
                }

                RefreshTeamGrid(table);
            }
            catch
            {

            }

            frmProgress.Close();
        }
        #endregion

        private void startMatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgressForm frmProgress = ProgressForm.Show(this, "Loading players...");
            CreateChallange(TournamentMatchStatusE.InProgress);
            frmProgress.Close();
            
        }
        
        #region Validation

        bool IsCorrectStatus(int gvTournamentStatusID, TournamentMatchStatusE tournamentMatchStatusID)
        {
            bool IsTrue = true;
            TournamentMatchStatusE gvTournamentStatusIDE = (TournamentMatchStatusE)Enum.ToObject(typeof(TournamentMatchStatusE), gvTournamentStatusID);
            switch (tournamentMatchStatusID)
            {
                case TournamentMatchStatusE.Absent:
                    IsTrue = (gvTournamentStatusIDE == TournamentMatchStatusE.Scheduled) || (gvTournamentStatusIDE == TournamentMatchStatusE.Postpond) ? false : true;
                    break;
                case TournamentMatchStatusE.Scheduled:
                    break;
                case TournamentMatchStatusE.Postpond:
                    IsTrue = gvTournamentStatusIDE == TournamentMatchStatusE.Finsihed || gvTournamentStatusIDE == TournamentMatchStatusE.InProgress ? true : false;
                    break;
                case TournamentMatchStatusE.InProgress:
                    IsTrue = gvTournamentStatusIDE == TournamentMatchStatusE.Scheduled ? false : true;
                    break;
                case TournamentMatchStatusE.Finsihed:
                    break;

                default:
                    break;
            }
            return IsTrue;
        }

        void TournamentRoundStarted()
        {
            int i = 0, j = 0;
            foreach (DataGridViewRow row in dgvMatches.Rows)
            {
                int gvTournamentMatchStatusID = Convert.ToInt32(table.Rows[i]["TournamentMatchStatusID"]);
                int matchID = Convert.ToInt32(table.Rows[i]["TournamentMatchID"]);

                TournamentMatchStatusE TournamentMatchStatusIDE = (TournamentMatchStatusE)Enum.ToObject(typeof(TournamentMatchStatusE),
                                                                    gvTournamentMatchStatusID);

                if (TournamentMatchStatusIDE == TournamentMatchStatusE.InProgress)
                {
                    //RsPanel.ShowMessage(Msg.GetMsg(MsgE.ErrorRoundStarts), true);
                    return;
                }
                i++;
            }

            foreach (DataGridViewRow row in dgvMatches.Rows)
            {
                bool isTrue = false;
                int gvTournamentMatchStatusID = Convert.ToInt32(table.Rows[i]["TournamentMatchStatusID"]);

                int round = Convert.ToInt32(table.Rows[j]["Round"]);

                TournamentMatchStatusE TournamentMatchStatusIDE = (TournamentMatchStatusE)Enum.ToObject(typeof(TournamentMatchStatusE),
                                                                    gvTournamentMatchStatusID);

                if (TournamentMatchStatusIDE == TournamentMatchStatusE.Scheduled)
                {
                    DataView dv = table.DefaultView;

                    dv.RowFilter = "Round = " + round.ToString();

                    foreach (DataRow item in dv.ToTable().Rows)
                    {
                        int wRating = 0, bRating = 0, matchStatus = 0;
                        matchStatus = (item["TournamentMatchStatusID"] != DBNull.Value) ? Convert.ToInt32(item["TournamentMatchStatusID"]) : 0;
                        int matchID = (item["TournamentMatchID"] != DBNull.Value) ? Convert.ToInt32(item["TournamentMatchID"]) : 0;
                        TournamentMatchStatusE TournamentMatchStatusID = (TournamentMatchStatusE)Enum.ToObject(typeof(TournamentMatchStatusE), matchStatus);

                        if (TournamentMatchStatusID == TournamentMatchStatusE.Scheduled)
                        {
                            wRating = (item["WRating"] != DBNull.Value) ? Convert.ToInt32(item["WRating"]) : 0;
                            bRating = (item["BRating"] != DBNull.Value) ? Convert.ToInt32(item["BRating"]) : 0;
                            //GetTournamentMatch(TournamentMatchStatusE.InProgress, wRating, bRating, false, RsToolbarButton.StartRound);
                            isTrue = true;
                        }
                    }
                    if (isTrue)
                    {
                        //StartMatches(false, RsToolbarButton.StartRound);
                        return;
                    }
                    else
                    {
                        //RsPanel.ShowMessage(Msg.GetMsg(MsgE.ErrorMatchStarts), true);
                    }
                }
                j++;
            }
        }

        bool IsRoundStarted()
        {
            int round = 0;
            short count = 0;
            //lblMessage.Text = "";


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


                //RsPanel.ShowMessage(Msg.GetMsg(MsgE.ErrorTournamentMultipleRounds), true);
                return false;
            }
            else
            {
                return true;

            }


        }
        
        #endregion

        public void CreateChallange(TournamentMatchStatusE tournamentMatchStatusIDE)
        {
            bool isTrue = false;

            int i = 0;
            string matchIDs = string.Empty;

            foreach (DataGridViewRow row in dgvMatches.Rows)
            {
                int chessTypeID = Convert.ToInt32(table.Rows[i]["ChessTypeId"]);

                if (dgvMatches[0, row.Index].State == DataGridViewElementStates.Selected)
                {

                    int matchID = Convert.ToInt32(table.Rows[i]["TournamentMatchID"]);
                    int gvTournamentMatchStatusID = Convert.ToInt32(table.Rows[i]["TournamentMatchStatusID"]);
                    int wRating = Convert.ToInt32(table.Rows[i]["WRating"]);
                    int bRating = Convert.ToInt32(table.Rows[i]["BRating"]);
                    
                    isTrue = !IsCorrectStatus(gvTournamentMatchStatusID, tournamentMatchStatusIDE);
                    if (!isTrue)
                        continue;

                    matchIDs += "," + matchID.ToString();
                }
                i++;
            }

            if (matchIDs.Length > 0)
            {
                SocketClient.StartTournamentMaches(TournamentID, matchIDs, tournamentMatchStatusIDE, TeamLooseStatusE.None, GameResultE.None);
                
            }
            
            RefreshGrid();
        }

        private void tsbWhiteBye_Click(object sender, EventArgs e)
        {
            ProgressForm frmProgress = ProgressForm.Show(this, "Loading players...");


            frmProgress.Close();
        }

        private void tsbBlackBye_Click(object sender, EventArgs e)
        {
            ProgressForm frmProgress = ProgressForm.Show(this, "Loading players...");


            frmProgress.Close();
        }
    }
}
