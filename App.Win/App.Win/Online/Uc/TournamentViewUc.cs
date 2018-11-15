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
using AppTournament = App.Model.Db.Tournament;
using System.Globalization;

namespace App.Win
{
    public partial class TournamentViewUc : UserControl
    {
        #region Data Members
        public App.Model.Db.Tournament Tournament = null;
        #endregion

        #region Ctor
        public TournamentViewUc()
        {
            InitializeComponent();
        }
        
        #endregion

        #region Properties

        #endregion

        #region Load
        private void TournamentViewUc_Load(object sender, EventArgs e)
        {
            
        }

        #endregion

        #region Fill Team
        void FillTeam(int tournamentID)
        {
            //if (cbTeam.Items.Count > 0)
            //{
            //    return;
            //}

            DataSet ds = SocketClient.GetTeamsByTournamentID(tournamentID);

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    cbTeam.DataSource = ds.Tables[0];
                    cbTeam.DisplayMember = "TeamName";
                    cbTeam.ValueMember = "TeamID";
                }
                else
                {
                    cbTeam.DataSource = null;
                }
            }
            else
            {
                cbTeam.DataSource = null;
            }

        } 
        #endregion

        #region Get Tournament Type
        string GetTournamentType
        {
            get
            {
                switch (this.Tournament.TournamentTypeIDE)
                {
                    case TournamentTypeE.RoundRobin:
                        return "Round Robin";
                    case TournamentTypeE.Swiss:
                        return TournamentTypeE.Swiss.ToString();
                    case TournamentTypeE.Knockout:
                        return TournamentTypeE.Knockout.ToString();
                    case TournamentTypeE.Scheveningen:
                        return TournamentTypeE.Scheveningen.ToString();
                    default:
                        break;
                }
                return this.Tournament.TournamentTypeIDE.ToString();
            }
        } 
        #endregion
                
        #region Helpers
        #region Fill Tournament Fields
        public void RefreshTab()
        {
            lblTDName.Text = Ap.CurrentUser.UserName;

            toolStrip1.Visible = false;
            
            cbTeam.Visible = false;
            lblTeamText.Visible = false;

            if (Tournament != null && Tournament.TournamentID != 0)
            {
                FillTeam(Tournament.TournamentID);

                cbTeam.Visible = false;
                lblTeamText.Visible = false;
                pnlKoItems.Visible = false;
                pnlCommonItems.Location = new Point(pnlCommonItems.Location.X, pnlKoItems.Location.Y);

                lblDblRound.Text = (this.Tournament.DoubleRound) ? "Yes" : "No";

                switch (this.Tournament.TournamentTypeIDE)
                {
                    case TournamentTypeE.Unknown:
                        break;
                    case TournamentTypeE.RoundRobin:
                        break;
                    case TournamentTypeE.Swiss:
                        break;
                    case TournamentTypeE.Knockout:
                        pnlKoItems.Visible = true;
                        pnlCommonItems.Location = new Point(pnlCommonItems.Location.X, 340);
                        break;
                    case TournamentTypeE.Scheveningen:
                        cbTeam.Visible = true;
                        lblTeamText.Visible = true;
                        lblDblRound.Text = this.Tournament.DoubleRoundNo.ToString();
                        break;                    
                }

                if (this.Tournament.TournamentStatusIDE == TournamentStatusE.Scheduled)
                {                    
                    toolStrip1.Visible = true;
                }

                lblChessType.Text = this.Tournament.ChessTypeIDE.ToString();
                lblTournamentType.Text = GetTournamentType;
                lblTimeControl.Text = this.Tournament.TimeControlMin + "' + " + this.Tournament.TimeControlSec.ToString() + "''";

                lblRound.Text = this.Tournament.Round.ToString();
                lblRated.Text = (this.Tournament.Rated ? "Yes" : "No");
                
                lblTieBreak.Text = (this.Tournament.IsTieBreak) ? "Yes" : "No";
                lblRegStartDate.Text = this.Tournament.RegistrationStartDate.ToShortDateString();
                lblRegStartTime.Text = this.Tournament.RegistrationStartTime.ToShortTimeString() ;

                lblRegEndDate.Text = this.Tournament.RegistrationEndDate.ToShortDateString();
                lblRegEndTime.Text = this.Tournament.RegistrationEndTime.ToShortTimeString();

                lblTournamentStartDate.Text = this.Tournament.TournamentStartDate.ToShortDateString();
                lblTournamentStartTime.Text = this.Tournament.TournamentStartTime.ToShortTimeString();

                lblTitle.Text = this.Tournament.Name;
                lblInvitation.Text = this.Tournament.Description;
                
                lblTDName.Text = this.Tournament.CreatedUser.UserName;

                lblNoOfGamesPerRound.Text = this.Tournament.NoOfGamesPerRound.ToString();
                lblNoOfTieBreaks.Text = this.Tournament.NoOfTieBreaks.ToString();
                lblTbTime.Text = this.Tournament.TieBreakMin + "' + " + this.Tournament.TieBreakSec.ToString() + "''";
                lblWhiteTime.Text = this.Tournament.SuddenDeathWhiteMin + "' + " + this.Tournament.SuddenDeathSec.ToString() + "''";
                lblBlackTime.Text = this.Tournament.SuddenDeathBlackMin + "' + " + this.Tournament.SuddenDeathSec.ToString() + "''";
                lblMaxWinners.Text = this.Tournament.MaxWinners.ToString();

                if (Ap.CurrentUser.HumanRankIDE == RankE.Guest)
                {
                    toolStrip1.Visible = false;
                }

            } 
        }
        #endregion


        private void CreateWantinUser(int teamID)
        {
            string tournamentIDs = string.Empty;

            SocketClient.CreateTournamentWantinUser(Ap.CurrentUserID, this.Tournament.TournamentID, teamID, TournamentUserStatusE.Wantin);
        }

        private void tsbWantIn_Click(object sender, EventArgs e)
        {
            WantinPlayer();
        }

        public void WantinPlayer()
        {
            if (this.Tournament == null)
            {
                return;
            }
            if (this.Tournament.TournamentID == 0)
            {
                return;
            }

            int teamID = ValidateTeam(this.Tournament);

            if (teamID == -1) // Scheveningen
            {
                return;
            }

            if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, "wantin", "for " + this.Tournament.Name) == DialogResult.Yes)
            {
                CreateWantinUser(teamID);
                MessageForm.Show(this.ParentForm, MsgE.ConfirmTournamentWantinRequest, this.Tournament.Name);
            }
        }

        private int ValidateTeam(App.Model.Db.Tournament t)
        {
            int teamID = 0;
            if (t.TournamentTypeIDE == TournamentTypeE.Scheveningen)
            {
                if (cbTeam.Items.Count == 0)
                {
                    MessageForm.Error(this.ParentForm, MsgE.ErrorNoSelection, "team");                    
                    return -1;
                }
                return Convert.ToInt32(cbTeam.SelectedValue);
            }
            return teamID;
        }
        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblTournamentType_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblChessType_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

               
    }
}
