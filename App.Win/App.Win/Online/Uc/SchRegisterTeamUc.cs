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
    public partial class SchRegisterTeamUc : UserControl
    {
        public FilterItems Filter = new FilterItems();

        #region Private
        public App.Model.Db.Tournament Tournament = null;
        public int TournamentID = 0;
        DataTable table = null;
        DataTable filterTable = null;
        string teamIds = "";
        #endregion

        #region Constructor

        public SchRegisterTeamUc()
        {
            InitializeComponent();
        }

        #endregion
        
        #region Properties

        public string TeamIds
        {
            get { return teamIds; }
        }

        #region GridTable
        public DataTable GridTable
        {
            get { return (DataTable)dgvRegisterTeam.DataSource; }
        }
        #endregion
        #endregion

        #region Events

        private void SchRegisterTeamUc_Load(object sender, EventArgs e)
        {
            RefreshGrid();
            InitFilter();
        }
        
        private void tsbRegister_Click(object sender, EventArgs e)
        {
            RegisterTeams();
        }

        #endregion

        #region Methods

        #region Filter
        private void InitFilter()
        {
            Filter.Add("TeamName", "Team Name");            

            tscombo.ComboBox.DataSource = Filter.DataTable;
            tscombo.ComboBox.DisplayMember = "Value";
            tscombo.ComboBox.ValueMember = "Key";
            tscombo.ComboBox.SelectedIndex = 0;
        }

        private void RefreshGrid(DataTable table)
        {
            filterTable = Filter.SearchByValue(table, tscombo, tsTextbox);
            dgvRegisterTeam.DataSource = filterTable;
        }

        private void RefreshGrid()
        {
            ProgressForm frmProgress = ProgressForm.Show(this, "Loading teams...");

            try
            {
                dgvRegisterTeam.AutoGenerateColumns = false;

                DataSet ds = SocketClient.GetRecentTournamentTeam(this.Tournament.TournamentID);

                if (ds != null)
                {
                    table = ds.Tables[0];
                }

                RefreshGrid(table);
            }
            catch(Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                string s = ex.Message;
            }

            frmProgress.Close();
        } 
        #endregion

        public void RegisterTeams()
        {
            try
            {
                int i = 0;
                
                foreach (DataGridViewRow row in dgvRegisterTeam.Rows)
                {
                    if (dgvRegisterTeam[0, row.Index].Value != null && Convert.ToBoolean(dgvRegisterTeam[0, row.Index].Value) == true )
                    {
                        int teamID = BaseItem.ToInt32(GridTable.Rows[i]["TeamID"]);
                        teamIds += "," + teamID.ToString();
                    }
                    i++;
                }

                if (teamIds.Length > 0)
                {
                    teamIds = teamIds.Remove(0, 1);
                    SocketClient.SaveTournamentTeam(teamIds, this.Tournament.TournamentID);

                    this.ParentForm.DialogResult = DialogResult.OK;
                    this.ParentForm.Close();
                }
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }

        #endregion

        private void dgvRegisterTeam_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvRegisterTeam.CurrentCell is System.Windows.Forms.DataGridViewCheckBoxCell)
            {
                dgvRegisterTeam.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

    }
}
