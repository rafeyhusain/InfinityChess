using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppTournament = App.Model.Db.Tournament;

namespace App.Win
{
    public partial class SchRegisterTeam : Form
    {
        #region DataMembers

        
        AppTournament TournamentItem = null;

        #endregion

        #region Properties

        public AppTournament Tournament { get { return TournamentItem; } set { TournamentItem = value; } }

        public string TeamIds
        {
            get { return SchRegisterTeamUc1.TeamIds; }
        }

        #endregion

        #region Ctor

        public SchRegisterTeam()
        {
            InitializeComponent();
        }

        public SchRegisterTeam(AppTournament Tournament)
        {
            InitializeComponent();
            this.Tournament = Tournament;
            SchRegisterTeamUc1.Tournament = this.Tournament;
        }
        
        #endregion

        #region Load 

        private void SchRegisterTeam_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Events 
                
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SchRegisterTeamUc1.RegisterTeams();
        }

        #endregion

    }
}
