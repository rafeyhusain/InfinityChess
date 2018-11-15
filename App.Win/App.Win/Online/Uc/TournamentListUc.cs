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

namespace App.Win
{
    public partial class TournamentListUc : UserControl
    {
        #region Data Member
        public FilterItems Filter = new FilterItems();
        public TournamentStatusE TournamentStatus = TournamentStatusE.Unknown;
        DataTable table = null; 
        #endregion
        
        #region Ctor
        public TournamentListUc()
        {
            InitializeComponent();

        } 
        #endregion

        #region Properties

        public int SelectedID
        {
            get
            {
                if (dgvTournamentList.DataSource == null)
                {
                    return 0;
                }

                if (dgvTournamentList.SelectedCells.Count < 1)
                {
                    return 0;
                }

                return BaseItem.ToInt32(((DataTable)dgvTournamentList.DataSource).Rows[dgvTournamentList.SelectedCells[0].RowIndex]["TournamentID"]);
            }
        }

        public App.Model.Db.Tournament SelectedTournament
        {
            get
            {
                if (dgvTournamentList.DataSource == null)
                {
                    return null;
                }

                if (dgvTournamentList.SelectedCells.Count < 1)
                {
                    return null;
                }
                DataRow dr = ((DataTable)dgvTournamentList.DataSource).Rows[dgvTournamentList.SelectedCells[0].RowIndex];

                return new App.Model.Db.Tournament(Ap.Cxt, dr);
            }
        } 
        #endregion

        #region Load
        private void TournamentListUc_Load(object sender, EventArgs e)
        {
            InitUi();
            RefreshGrid();
            InitFilter();
        }

        #endregion

        #region Helper
        private void ShowSelectedTournament()
        {
            if (this.SelectedID > 0)
            {
                DialogResult dr = TournamentDetail.Show(this.ParentForm, this.SelectedID, TournamentStatus == TournamentStatusE.Unknown);
                if (dr == DialogResult.OK)
                {
                    RefreshGrid();
                }
            }
        }

        private void InitUi()
        {
            switch (TournamentStatus)
            {
                case TournamentStatusE.Scheduled:
                case TournamentStatusE.InProgress:
                case TournamentStatusE.Finsihed:
                    tsbNew.Visible = false;
                    tsbDelete.Visible = false;
                    break;
            }
        }

        private void SetCheck(bool isCheck)
        {
            foreach (DataGridViewRow row in dgvTournamentList.Rows)
            {
                row.Cells[0].Value = isCheck;
            }
        }

        private void RefreshGrid(DataTable table)
        {
            dgvTournamentList.DataSource = Filter.SearchByValue(table, toolStripcmbSearch, toolStriptxtSearch);
        }

        private void InitFilter()
        {
            Filter.Add("Name", "Tournament Name");
            Filter.Add("TD", "Tournament Director");
            Filter.Add("TournamentStatus", "Tournament Status");

            toolStripcmbSearch.ComboBox.DataSource = Filter.DataTable;
            toolStripcmbSearch.ComboBox.DisplayMember = "Value";
            toolStripcmbSearch.ComboBox.ValueMember = "Key";
            toolStripcmbSearch.ComboBox.SelectedIndex = 0;
        }

        private void RefreshGrid()
        {
            ProgressForm frmProgress = ProgressForm.Show(this, "Loading Tournaments...");

            try
            {
                dgvTournamentList.AutoGenerateColumns = false;

                DataSet ds = null;

                switch (TournamentStatus)
                {
                    case TournamentStatusE.Unknown:
                        ds= SocketClient.GetAllTournaments(Ap.CurrentUser.IsAdmin);
                        break;
                    case TournamentStatusE.Scheduled:
                        ds = SocketClient.GetAllForthcommingTournaments(TournamentStatus);
                        break;
                    case TournamentStatusE.InProgress:
                        ds = SocketClient.GetAllInprogressTournaments(TournamentStatus);
                        break;
                    case TournamentStatusE.Finsihed:
                        ds = SocketClient.GetAllFinishedTournaments(TournamentStatus);
                        break;
                    default:
                        break;

                }

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        table = ds.Tables[0];
                    }
                    else
                    {
                        table = null;
                    }
                }
                else
                {
                    table = null;
                }

                RefreshGrid(table);
            }
            catch(Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
            }

            frmProgress.Close();
        } 
        #endregion

        #region Grid
        private void dgvTournamentList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvTournamentList.CurrentCell is System.Windows.Forms.DataGridViewCheckBoxCell)
            {
                dgvTournamentList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvTournamentList_DoubleClick(object sender, EventArgs e)
        {
            ShowSelectedTournament();
        } 
        #endregion

        #region Toolbar

        private void tsbNew_Click(object sender, EventArgs e)
        {
            DialogResult dr = TournamentDetail.ShowDialog(this.ParentForm, 0);
            if (dr == DialogResult.OK)
            {
                RefreshGrid();
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCheck(true);
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCheck(false);
        }

        private void tsbView_Click(object sender, EventArgs e)
        {
            ShowSelectedTournament();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            RefreshGrid(table);
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrid(table);
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            string ids = string.Empty;

            if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemDelete, "tournament") != DialogResult.Yes)
            {
                return;
            }

            if (dgvTournamentList.Rows.Count == 0)
            {
                MessageForm.Error(this.ParentForm, MsgE.ErrorNoSelection, "tournament");

                return;
            }

            foreach (DataGridViewRow row in dgvTournamentList.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if ((bool)row.Cells[0].Value)
                    {
                        int tid = Convert.ToInt32(table.Rows[row.Index]["TournamentId"]);

                        if (string.IsNullOrEmpty(ids))
                        {
                            ids = tid.ToString();
                        }
                        else
                        {
                            ids += "," + tid.ToString();
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(ids))
            {
                SocketClient.DeleteTournament(ids);
                RefreshGrid();
            }
        }

        private void toolStriptxtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshGrid(table);
        }

        private void toolStripcmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrid(table);
        }

        private void tsbWantIn_Click(object sender, EventArgs e)
        {
            //CreateWantinUser();

        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        #endregion
    }
}
