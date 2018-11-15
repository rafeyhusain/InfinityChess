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
    public partial class PrizeUc : UserControl
    {
        #region Data Member
        TournamentPrize TournamentPrize = null;
        DataTable table = null;

        public App.Model.Db.Tournament Tournament;

        #endregion

        #region Ctor
        public PrizeUc()
        {
            InitializeComponent();
        } 
        #endregion

        #region Properties

        public int SelectedID
        {
            get
            {
                if (dgvPrize.DataSource == null)
                {
                    return 0;
                }

                if (dgvPrize.SelectedCells.Count < 1)
                {
                    return 0;
                }

                return BaseItem.ToInt32(((DataTable)dgvPrize.DataSource).Rows[dgvPrize.SelectedCells[0].RowIndex]["TournamentPrizeID"]);
            }
        }

        #endregion

        #region Load
        private void PrizeUc_Load(object sender, EventArgs e)
        {
            InitUi();
        }
        #endregion

        #region Toolbar
        private void tsbRefresh_Click(object sender, EventArgs e)
        {  
            RefreshGrid();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCheck(true);
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCheck(false);
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
             DialogResult dr = MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemDelete, "prize(s)");
             if (dr == DialogResult.Yes)
             {
                 DeletePrizes();
             }
        }
        #endregion

        #region Grid

        private void dgvPrize_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (table == null)
            {
                return;
            }
            if (table.Rows.Count == 0)
            {
                return;
            }

            if (e.ColumnIndex==3 && e.Value != null)
            {
                double amount =0;
                if(Double.TryParse(e.Value.ToString(),out amount))
                {
                    e.Value = amount.ToString("0.00");
                }
            }

            if (e.ColumnIndex == 1)
            {
                e.Value = GetPosition(Convert.ToInt32(table.Rows[e.RowIndex]["PrizePosition"]));
            }
            
        }

        private void dgvPrize_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvPrize.CurrentCell is System.Windows.Forms.DataGridViewCheckBoxCell)
            {
                dgvPrize.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        #endregion
        
        #region Add Button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            double amount = 0;
            if (!Double.TryParse(txtAmount.Text.Trim(),out amount))
            {
                MessageForm.Error("Please enter correct amount.");
                return;
            }
           
            Kv kv = new Kv();

            kv.Set("TournamentID", this.Tournament.TournamentID);
            kv.Set("PrizePosition", GetPrizeIndex(cmbPrize.Text));
            kv.Set("TournamentPrizeCategoryID", Convert.ToInt32(cmbCategory.SelectedValue));
            kv.Set("PrizeAmount", amount);
            
            DataSet ds = SocketClient.AddPrize(kv);
            
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                TournamentPrize = new TournamentPrize(Ap.Cxt, ds.Tables[0].Rows[0]);
            }
            txtAmount.Text = "";
            RefreshGrid();
        }
        
        #endregion

        #region Helpers

        int GetPrizeIndex(string prize)
        {
            switch (prize)
            {
                case "1st":
                    return 1;
                case "2nd":
                    return 2;
                case "3rd":
                    return 3;
                case "4th":
                    return 4;
                case "5th":
                    return 5;
                case "6th":
                    return 6;
                case "7th":
                    return 7;
                case "8th":
                    return 8;
                case "9th":
                    return 9;
                case "10th":
                    return 10;

                default:
                    break;
            }
            return 0;
        }

        string GetPosition(int i)
        {
            switch (i)
            {
                case 1:
                    return "1st";
                case 2:
                    return "2nd";
                case 3:
                    return "3rd";
                case 4:
                    return "4th";
                case 5:
                    return "5th";
                case 6:
                    return "6th";
                case 7:
                    return "7th";
                case 8:
                    return "8th";
                case 9:
                    return "9th";
                case 10:
                    return "10th";
            }
            return "";
        }

        private void InitUi()
        {
            for (int i = 1; i <= 10; i++)
            {
                cmbPrize.Items.Add(GetPosition(i));
            }
            cmbPrize.SelectedIndex = 0;

            DataSet ds = SocketClient.GetTournamentPrizeCategories();

            if (ds != null && ds.Tables.Count > 0)
            {
                cmbCategory.DataSource = ds.Tables[0];
                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "TournamentPrizeCategoryID";
            }
        }
        
        private void RefreshGrid()
        {
            try
            {
                if (this.Tournament == null)
                {
                    return;
                }

                ProgressForm frmProgress = ProgressForm.Show(this, "Loading Prizes...");

                dgvPrize.AutoGenerateColumns = false;

                DataSet ds = SocketClient.GetPrizesByTournamentID(this.Tournament.TournamentID);

                if (ds != null && ds.Tables.Count > 0)
                {
                    table = ds.Tables[0];
                }
                else
                {
                    if (table != null)
                    {
                        table.Rows.Clear();
                    }
                }

                dgvPrize.DataSource = table;

                frmProgress.Close();
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }

        private void SetCheck(bool isCheck)
        {
            foreach (DataGridViewRow row in dgvPrize.Rows)
            {
                row.Cells[0].Value = isCheck;
            }
        }

        private void DeletePrizes()
        {
            if (dgvPrize.Rows.Count == 0)
            {
                MessageForm.Error(this.ParentForm, MsgE.ErrorNoSelection, "prize");

                return;
            }

            try
            {
                int i = 0;

                string tournamentPrizeIds = string.Empty;

                foreach (DataGridViewRow row in dgvPrize.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if ((bool)row.Cells[0].Value)
                        {
                            int tournamentPrizeID = BaseItem.ToInt32(table.Rows[i]["TournamentPrizeID"]);

                            tournamentPrizeIds += "," + tournamentPrizeID.ToString();
                        }
                    }
                    i++;
                }

                if (tournamentPrizeIds.Length > 0)
                {
                    tournamentPrizeIds = tournamentPrizeIds.Remove(0, 1);

                    ProgressForm frmProgress = ProgressForm.Show(this, "Removing Prizes...");

                    SocketClient.DeleteTournamentPrize(tournamentPrizeIds);

                    frmProgress.Close();

                    RefreshGrid();
                }
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }

        #endregion

        #region RefreshTab
        internal void RefreshTab()
        {
            RefreshGrid();
        } 
        #endregion

        internal void AllowEdit(bool enable)
        {
            tsbDelete.Visible = enable;
            toolStripSplitButton1.Visible = enable;

            panel2.Visible = enable;
        }        
    }
}
