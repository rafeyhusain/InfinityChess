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
    public partial class StandingsUc : UserControl
    {
        #region Data Members
        App.Model.Db.Tournament tournament = null;
        public FilterItems Filter = new FilterItems();
        DataTable table = null;
        #endregion

        #region Ctor
        public StandingsUc()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties 

        public App.Model.Db.Tournament Tournament
        {
            get { return tournament; }
            set
            {
                tournament = value;
                SetTournament(value);
            }
        }

        private void SetTournament(App.Model.Db.Tournament value)
        {
            if (value == null)
            {
                return;
            }

            switch (tournament.TournamentTypeE)
            {
                case TournamentTypeE.RoundRobin:
                    roundRobinResultsUc1.Tournament = value;
                    roundRobinResultsUc1.Visible = true;
                    roundRobinResultsUc1.Dock = DockStyle.Fill;
                    break;
                case TournamentTypeE.Swiss:
                    swissResultsUc1.Tournament = value;
                    swissResultsUc1.Visible = true;
                    swissResultsUc1.Dock = DockStyle.Fill; 
                    break;
                case TournamentTypeE.Knockout:
                    knockOutResultsUc1.Tournament = value;
                    knockOutResultsUc1.Visible = true;
                    knockOutResultsUc1.Dock = DockStyle.Fill;
                    break;
                case TournamentTypeE.Scheveningen:
                    scheveningenResultsUc1.Tournament = value;
                    scheveningenResultsUc1.Visible = true;
                    scheveningenResultsUc1.Dock = DockStyle.Fill;
                    break;
                default:
                    break;
            }
        } 

        #endregion

        #region Load
        private void StandingsUc_Load(object sender, EventArgs e)
        {
            
        }

        #endregion

        #region Helpers 
        private void RefreshStandings()
        {
            switch (Tournament.TournamentTypeE)
            {
                case TournamentTypeE.RoundRobin:
                    roundRobinResultsUc1.RefreshTab();
                    break;
                case TournamentTypeE.Swiss:
                    swissResultsUc1.RefreshTab();
                    break;
                case TournamentTypeE.Knockout:
                    knockOutResultsUc1.RefreshTab();
                    break;
                case TournamentTypeE.Scheveningen:
                    scheveningenResultsUc1.RefreshTab();
                    break;
                default:
                    break;
            }
        } 
        #endregion

        #region RefreshTab 
        public void RefreshTab()
        {
            RefreshStandings();
        }
        #endregion

        #region Internal 
        internal void AllowEdit(bool enable)
        {

        }

        internal void OnTournamentSave()
        {
            //InitFilter();
        }         
        #endregion
    }
}
