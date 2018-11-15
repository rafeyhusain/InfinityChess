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
using System.IO;

namespace App.Win
{
    public partial class ResultsUc : UserControl
    {
        #region Data Members
        public App.Model.Db.Tournament Tournament = null;
        public FilterItems Filter = new FilterItems();
        DataTable table = null;
        #endregion

        #region Ctor
        public ResultsUc()
        {
            InitializeComponent();
        }
        #endregion

        #region Load
        private void ResultsUc_Load(object sender, EventArgs e)
        {
            InitFilter();
        }

        #endregion

        #region Helpers
        private void InitFilter()
        {
            if (this.Tournament == null)
            {
                return;
            }

            if (this.Tournament != null)
            {
                Filter.Clear();

                if (Tournament.TournamentTypeE == TournamentTypeE.Knockout)
                {
                    Filter.Add("Round", "Round");
                    Filter.Add("Lose", "Lose");
                    Filter.Add("Win", "Win");
                }
                else
                {
                    Filter.Add("Player", "Player");
                    Filter.Add("Rank", "Rank");
                    Filter.Add("Rating", "Rating");
                    Filter.Add("TotalPoints", "Total Points");
                }
            }

            toolStripcmbSearch.ComboBox.DataSource = Filter.DataTable;
            toolStripcmbSearch.ComboBox.DisplayMember = "Value";
            toolStripcmbSearch.ComboBox.ValueMember = "Key";
            toolStripcmbSearch.ComboBox.SelectedIndex = 0;
        }

        private void FormatGrid()
        {
            try
            {
                HideColumn("UserID");
                HideColumn("CountryID");
                HideColumn("CountryName");
                HideColumn("TeamID");

                if (this.Tournament.TournamentTypeIDE != TournamentTypeE.RoundRobin)
                {
                    HideColumn("Flag");
                }

                SetWidth("Flag", 40);
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }

        private void HideColumn(string columnName)
        {
            if (dgvResult.Columns.Contains(columnName))
            {
                dgvResult.Columns[columnName].Visible = false;
            }
        }

        private void SetWidth(string columnName, int width)
        {
            if (dgvResult.Columns.Contains(columnName))
            {
                dgvResult.Columns[columnName].Width = width;
            }
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

            this.panel1.Visible = false;
            dgvWinners.Visible = false;

            if (this.Tournament.TournamentTypeIDE == TournamentTypeE.Scheveningen)
            {
                dgvSchTeamResult.AutoGenerateColumns = false;
                dgvTeamPoint.AutoGenerateColumns = false;
                this.panel1.Visible = true;
            }

            ProgressForm frmProgress = ProgressForm.Show(this, "Loading Standings...");

            try
            {
                DataSet ds = SocketClient.GetTournamentResultById(this.Tournament.TournamentID);

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                        RefreshGrid(table);
                        FillWinners(table);
                        if (ds.Tables.Count > 1)
                        {
                            FillSchTeamResult(ds.Tables[1]);
                        }
                        if (ds.Tables.Count > 2)
                        {
                            FillTeamUserPoint(ds.Tables[3]);
                        }
                    }
                    else
                    {
                        dgvResult.DataSource = null;
                        dgvSchTeamResult.DataSource = null;
                        dgvTeamPoint.DataSource = null;
                    }
                }
                else
                {
                    dgvResult.DataSource = null;
                    dgvSchTeamResult.DataSource = null;
                    dgvTeamPoint.DataSource = null;
                }
                
                foreach (DataGridViewRow row in dgvResult.Rows)
                {
                    if (row.Cells["CountryId"].Value.ToString() == "0")
                    {
                        Image item = Image.FromFile(Ap.FolderFlags + "244.png");
                        row.Cells["Flag"].Value = item;
                    }
                    else
                    {
                        Image item = Image.FromFile(Ap.FolderFlags + row.Cells["CountryId"].Value + ".png");
                        row.Cells["Flag"].Value = item;
                    }
                }
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
            }

            FormatGrid();
            frmProgress.Close();
        }

        void FillTeamUserPoint(DataTable dt)
        {
            dgvTeamPoint.DataSource = dt;
        }

        void FillSchTeamResult(DataTable dt)
        {
            dgvSchTeamResult.DataSource = dt;
        }

        private void RefreshGrid(DataTable table)
        {
            dgvResult.DataSource = null;
            dgvResult.DataSource = Filter.SearchByValue(table, toolStripcmbSearch, toolStriptxtSearch);
            FormatGrid();
            if (Tournament.TournamentTypeE == TournamentTypeE.Knockout)
            {
                if (dgvResult.Columns.Contains("Result"))
                {
                    dgvResult.Columns["Result"].Visible = false;
                    dgvResult.Columns["WhiteUserId"].Visible = false;
                    dgvResult.Columns["BlackUserId"].Visible = false;
                }
            }
        }

        #endregion

        #region Toolbar
        private void toolStriptxtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshGrid(table);
        }

        private void toolStripcmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrid(table);
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }
        #endregion

        #region RefreshTab
        public void RefreshTab()
        {
            RefreshGrid();
        }
        #endregion

        #region Grid
        private void dgvResult_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            SetRating(e);
            ReplaceHalf(e);
            SetSB(e);
            SetCountryFlag(e);
            SetRound(e);
            SetWinner(e);
        }
        
        private void ReplaceHalf(DataGridViewCellFormattingEventArgs e)
        {
            if (dgvResult[e.ColumnIndex, e.RowIndex].Value != null)
            {
                if (dgvResult[e.ColumnIndex, e.RowIndex].Value.ToString().Contains('?'))
                {
                    dgvResult[e.ColumnIndex, e.RowIndex].Value = dgvResult[e.ColumnIndex, e.RowIndex].Value.ToString().Replace('?', '½');
                }
            }
        }

        private void SetRating(DataGridViewCellFormattingEventArgs e)
        {
            if (dgvResult.Columns[e.ColumnIndex].HeaderText == "Rating")
            {
                if (dgvResult[e.ColumnIndex, e.RowIndex].Value.ToString() == "0")
                {
                    dgvResult[e.ColumnIndex, e.RowIndex].Value = "";
                }
            }
        }

        private void SetSB(DataGridViewCellFormattingEventArgs e)
        {
            if (dgvResult.Columns[e.ColumnIndex].HeaderText == "SB")
            {
                if (dgvResult[e.ColumnIndex, e.RowIndex].Value.ToString() == "0.0" || dgvResult[e.ColumnIndex, e.RowIndex].Value.ToString() == "0")
                {
                    dgvResult[e.ColumnIndex, e.RowIndex].Value = "";
                }
            }
        }

        private void SetCountryFlag(DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (dgvResult.Columns.Contains("CountryID"))
                {
                    if (dgvResult["CountryID", e.RowIndex].Value != null && dgvResult["CountryID", e.RowIndex].Value.ToString() != "" && dgvResult["CountryID", e.RowIndex].Value.ToString() != "0")
                    {
                        if (File.Exists(App.Model.Ap.FolderImages + @"Flags\" + dgvResult["CountryID", e.RowIndex].Value + ".PNG"))
                        {
                            Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Flags\" + dgvResult["CountryID", e.RowIndex].Value + ".PNG");
                            e.Value = item;
                        }
                        if (dgvResult["CountryName", e.RowIndex].Value != null)
                        {
                            dgvResult[e.ColumnIndex, e.RowIndex].ToolTipText = dgvResult["CountryName", e.RowIndex].Value.ToString();
                        }
                    }
                    else
                    {
                        if (File.Exists(App.Model.Ap.FolderImages + @"Flags\244.PNG"))
                        {
                            Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Flags\244.PNG");
                            e.Value = item;
                        }
                    }
                }
            }
        }

        private void SetRound(DataGridViewCellFormattingEventArgs e)
        {
            if (dgvResult.Columns[e.ColumnIndex].HeaderText == "Round")
            {
                if (dgvResult.Rows[e.RowIndex].Cells["Round"].Value.ToString() == "0")
                {
                    e.Value = "Preliminary";
                    return;
                }                
            }
        }

        private void SetWinner(DataGridViewCellFormattingEventArgs e)
        {
            if (Tournament.TournamentTypeE != TournamentTypeE.Knockout)
            {
                return;
            }

            if (dgvResult.Columns[e.ColumnIndex].HeaderText == "Result")
            {
                DataGridViewCell resultCell = dgvResult.Rows[e.RowIndex].Cells["Result"];
                DataGridViewCell winnerCell = dgvResult.Rows[e.RowIndex].Cells["Result"];
                DataGridViewCell loserCell = dgvResult.Rows[e.RowIndex].Cells["Result"];

                if (resultCell.Value.ToString() == "1-0")
                {
                    winnerCell = dgvResult.Rows[e.RowIndex].Cells["White"];
                    loserCell = dgvResult.Rows[e.RowIndex].Cells["Black"];
                }
                else if (resultCell.Value.ToString() == "0-1")
                {
                    winnerCell = dgvResult.Rows[e.RowIndex].Cells["Black"];
                    loserCell = dgvResult.Rows[e.RowIndex].Cells["White"];
                }
                winnerCell.Style.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                loserCell.Style.Font = new Font(e.CellStyle.Font, FontStyle.Regular);
            }
        }

        #endregion

        #region Fill Winners 

        private void FillWinners(DataTable dtResults)
        {
            if (Tournament.TournamentTypeE != TournamentTypeE.Knockout)
            {
                return;
            }
            if (Tournament.MaxWinners == 0)
            {
                return;
            }

            int lastRound = Convert.ToInt32(dtResults.Compute("Max(Round)", ""));
            DataSet ds = SocketClient.IsKnockOutTournamentCompleted(Tournament.TournamentID, lastRound + 1);

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    Kv kv = new Kv(ds.Tables[0]);
                    if (kv.GetInt32("Result") > 0)
                    {   
                        // tournament not yet completed, so no winners could decided here...
                        return;
                    }
                }
            }

            dgvWinners.Visible = true;
            dgvWinners.DataSource = LoadWinners(dtResults, lastRound);
            if (dgvWinners.Columns.Contains("WinnerId"))
            {
                dgvWinners.Columns["WinnerId"].Visible = false;                
            }
        }

        private DataTable LoadWinners(DataTable dtResults, int lastRound)
        {
            DataTable dtWinners = new DataTable("Winners");
            dtWinners.Columns.Add("Rank", typeof(int));
            dtWinners.Columns.Add("WinnerId", typeof(int));
            dtWinners.Columns.Add("Winner", typeof(string));

            int rank = 1;
            
            
            foreach (DataRow drResult in dtResults.Select("","Round desc"))
            {
                if (rank > Tournament.MaxWinners)
                {
                    break;
                }

                if (drResult["Result"].ToString() == "1-0")
                {
                    if (IsUserWinInRound(dtResults, drResult["WhiteUserId"].ToString(), lastRound - 1))
                    {
                        dtWinners.Rows.Add(new object[] { rank, drResult["WhiteUserId"], drResult["White"] });
                        rank++;
                        dtWinners.Rows.Add(new object[] { rank, drResult["BlackUserId"], drResult["Black"] });
                        rank++;
                    }
                    else
                    {
                        dtWinners.Rows.Add(new object[] { rank, drResult["WhiteUserId"], drResult["White"] });
                        rank++;
                    }                    
                }
                else if (drResult["Result"].ToString() == "0-1")
                {
                    if (IsUserWinInRound(dtResults, drResult["BlackUserId"].ToString(), lastRound - 1))
                    {
                        dtWinners.Rows.Add(new object[] { rank, drResult["BlackUserId"], drResult["Black"] });
                        rank++;
                        dtWinners.Rows.Add(new object[] { rank, drResult["WhiteUserId"], drResult["White"] });
                        rank++;
                    }
                    else
                    {
                        dtWinners.Rows.Add(new object[] { rank, drResult["BlackUserId"], drResult["Black"] });
                        rank++;
                    }
                }
            }
            return dtWinners;
        }

        private bool IsUserWinInRound(DataTable dtResults, string userId, int round)
        {
            bool isWinner = false;

            DataRow[] rows = dtResults.Select("Round = " + round);
            foreach (DataRow dr in rows)
            {
                if (dr["Result"].ToString() == "1-0" && dr["WhiteUserId"].ToString() == userId)
                {
                    isWinner = true;
                }
                else if (dr["Result"].ToString() == "0-1" && dr["BlackUserId"].ToString() == userId)
                {
                    isWinner = true;                    
                }
            }

            return isWinner;
        }

        #endregion

        internal void AllowEdit(bool enable)
        {
           
        }

        internal void OnTournamentSave()
        {
            InitFilter();
        }        
    }
}
