using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppTournament = App.Model.Db.Tournament;
using App.Model;

namespace App.Win
{
    public partial class TournamentRegisterPlayer : Form
    {
        #region Data Members

        AppTournament TournamentItem = null;
        int teamId = 0;
        int userID = 0;
        #endregion
        
        #region Ctor 

        public TournamentRegisterPlayer()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties 

        public AppTournament Tournament { get { return TournamentItem; } set { TournamentItem = value; } }

        public int TeamId { get { return teamId; } set { teamId = value; } }

        public int UserID { get { return userID; } set { userID = value; } }

        #endregion

        public TournamentRegisterPlayer(AppTournament Tournament, int teamId)
        {
            InitializeComponent();
            this.Tournament = Tournament;
            this.TeamId = teamId;
            registerPlayerUc1.Tournament = this.Tournament;
            registerPlayerUc1.TeamId = this.TeamId;
            
        }
        
        private void TournamentDetail_Load(object sender, EventArgs e)
        {
            registerPlayerUc1.UserID = this.UserID;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Ap.Help(this, HelpTopicIdE.Tournament);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            registerPlayerUc1.Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
