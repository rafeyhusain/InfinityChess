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
    public partial class KnockOutResultsUc : UserControl
    {
        #region Data Members
        public App.Model.Db.Tournament Tournament = null;
        public FilterItems Filter = new FilterItems();
        DataTable table = null;
        #endregion

        #region Ctor
        public KnockOutResultsUc()
        {
            InitializeComponent();
        }
        #endregion

        #region GridTable
        public DataTable GridTable
        {
            get { return (DataTable)dgvResult.DataSource; }
        }
        #endregion

        #region Load
        private void KnockOutResultsUc_Load(object sender, EventArgs e)
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

                Filter.Add("Round", "Round");
                Filter.Add("White", "White");
                Filter.Add("Black", "Black");
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
                HideColumn("Result");
                HideColumn("WhiteUserId");
                HideColumn("BlackUserId");
                HideColumn("Flag");

                SetWidth("Flag", 40);

                FormatGridCells();
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
                    }
                    else
                    {
                        dgvResult.DataSource = null;
                        LoadWinners(null);
                    }
                }
                else
                {
                    dgvResult.DataSource = null;
                    LoadWinners(null);                    
                }                
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
            }

            FormatGrid();
            frmProgress.Close();
        }

        private void RefreshGrid(DataTable table)
        {
            dgvResult.DataSource = null;
            dgvResult.DataSource = Filter.SearchByValue(table, toolStripcmbSearch, toolStriptxtSearch);
            FormatGrid();
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
            SetRound(e);
            SetWinner(e);
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
            //if (dgvResult.Columns[e.ColumnIndex].HeaderText == "Result")
            //{
            //    DataGridViewCell resultCell = dgvResult.Rows[e.RowIndex].Cells["Result"];
            //    DataGridViewCell winnerCell = dgvResult.Rows[e.RowIndex].Cells["Result"];
            //    DataGridViewCell loserCell = dgvResult.Rows[e.RowIndex].Cells["Result"];

            //    if (resultCell.Value.ToString() == "1-0")
            //    {
            //        winnerCell = dgvResult.Rows[e.RowIndex].Cells["White"];
            //        loserCell = dgvResult.Rows[e.RowIndex].Cells["Black"];
            //    }
            //    else if (resultCell.Value.ToString() == "0-1")
            //    {
            //        winnerCell = dgvResult.Rows[e.RowIndex].Cells["Black"];
            //        loserCell = dgvResult.Rows[e.RowIndex].Cells["White"];
            //    }
            //    winnerCell.Style.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
            //    loserCell.Style.Font = new Font(e.CellStyle.Font, FontStyle.Regular);
            //}            
        }

        #endregion

        #region Fill Winners 

        private void FillWinners(DataTable dtResults)
        {
            if (Tournament.MaxWinners == 0)
            {
                LoadWinners(null);
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
                        LoadWinners(null);
                        return;
                    }
                }
            }

            DataTable dtWinners = LoadWinners(dtResults, lastRound);
            LoadWinners(dtWinners);
        }

        private DataTable LoadWinners(DataTable dtResults, int lastRound)
        {
            DataTable dtWinners = new DataTable("Winners");
            dtWinners.Columns.Add("Rank", typeof(int));
            dtWinners.Columns.Add("WinnerId", typeof(int));
            dtWinners.Columns.Add("Winners", typeof(string));

            int rank = 1;

            foreach (DataRow drResult in dtResults.Select("Round = " + lastRound, "Round desc"))
            {
                if (rank > Tournament.MaxWinners)
                {
                    break;
                }

                if (drResult["Result"].ToString() == "1-0")
                {
                    if (IsUserWinInRound(dtResults, drResult["WhiteUserId"].ToString(), lastRound - 1))
                    {
                        dtWinners.Rows.Add(NewWinnersRow(dtWinners, 1, drResult["WhiteUserId"], drResult["White"]));
                        rank++;
                        dtWinners.Rows.Add(NewWinnersRow(dtWinners, 2, drResult["BlackUserId"], drResult["Black"]));
                        rank++;
                    }
                    else
                    {
                        dtWinners.Rows.Add(NewWinnersRow(dtWinners, 3, drResult["WhiteUserId"], drResult["White"]));
                        rank++;
                    }
                }
                else if (drResult["Result"].ToString() == "0-1")
                {
                    if (IsUserWinInRound(dtResults, drResult["BlackUserId"].ToString(), lastRound - 1))
                    {
                        dtWinners.Rows.Add(NewWinnersRow(dtWinners, 1, drResult["BlackUserId"], drResult["Black"]));
                        rank++;
                        dtWinners.Rows.Add(NewWinnersRow(dtWinners, 2, drResult["WhiteUserId"], drResult["White"]));
                        rank++;
                    }
                    else
                    {
                        dtWinners.Rows.Add(NewWinnersRow(dtWinners, 3, drResult["BlackUserId"], drResult["Black"]));
                        rank++;
                    }
                }
            }

            DataView dv = dtWinners.DefaultView;
            dv.Sort = "Rank asc";
            dtWinners = dv.ToTable();
            return dtWinners;
        }

        private DataRow NewWinnersRow(DataTable dtWinners, object rank, object winnerId, object name)
        {
            DataRow dr = dtWinners.NewRow();
            dr["Rank"] = rank;
            dr["WinnerId"] = winnerId;
            dr["Winners"] = name;
            return dr;
        }

        private void LoadWinners(DataTable dtWinners)
        {
            pnlWinners.Visible = Tournament.MaxWinners > 0;

            if (dtWinners == null || dtWinners.Rows.Count == 0)
            {
                lblWinnersMessage.Text = "Winners will be listed after final.";
                lblWinnersMessage.Visible = true;
                dgvWinners.Visible = false;
                return;
            }

            lblWinnersMessage.Visible = false;
            dgvWinners.Visible = true;

            dgvWinners.DataSource = dtWinners;
            if (dgvWinners.Columns.Contains("WinnerId"))
            {
                dgvWinners.Columns["WinnerId"].Visible = false;
            }
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

        private void FormatGridCells()
        {
            string result = "";
            DataTable dt = GridTable;

            foreach (DataGridViewRow gRow in dgvResult.Rows)
            {
                 result =  dt.Rows[gRow.Index]["Result"].ToString();
                DataGridViewCell winnerCell = gRow.Cells["White"];
                DataGridViewCell loserCell = gRow.Cells["Black"];

                if (result == "1-0")
                {
                    winnerCell = gRow.Cells["White"];
                    loserCell = gRow.Cells["Black"];
                }
                else if (result == "0-1")
                {
                    winnerCell = gRow.Cells["Black"];
                    loserCell = gRow.Cells["White"];
                }
                winnerCell.Style.Font = new Font(this.Font, FontStyle.Bold);
                loserCell.Style.Font = new Font(this.Font, FontStyle.Regular);
            }
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
