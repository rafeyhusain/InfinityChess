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
    public partial class SwissResultsUc : UserControl
    {
        #region Data Members
        public App.Model.Db.Tournament Tournament = null;
        public FilterItems Filter = new FilterItems();
        DataTable table = null;
        #endregion

        #region Ctor
        public SwissResultsUc()
        {
            InitializeComponent();
        }
        #endregion

        #region Load
        private void SwissResultsUc_Load(object sender, EventArgs e)
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

                Filter.Add("Player", "Player");
                Filter.Add("Rank", "Rank");
                Filter.Add("Rating", "Rating");
                Filter.Add("TotalPoints", "Total Points");
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
                HideColumn("Flag");
                
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
                    }
                    else
                    {
                        dgvResult.DataSource = null;                        
                    }
                }
                else
                {
                    dgvResult.DataSource = null;                    
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
            catch(Exception ex)
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
            SetRating(e);
            ReplaceHalf(e);
            SetSB(e);
            SetCountryFlag(e);            
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
