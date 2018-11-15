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
    public partial class TournamentDetailUc : UserControl
    {
        #region Data Members
        public App.Model.Db.Tournament tournament = null;
        public bool IsAllowEdit = false;
        TabPage tpRegisterUser = null;
        TabPage tpTeam = null;
        #endregion

        #region Properties

        public App.Model.Db.Tournament Tournament
        {
            get { return tournament; }
            set
            {
                tournament = value;

                tournamentUc1.Tournament = value;
                tournamentViewUc1.Tournament = value;
                wantInPlayerUc1.Tournament = value;
                registeredPlayerUc1.Tournament = value;
                schTeamUc1.Tournament = value;
                prizeUc1.Tournament = value;
                matchesUc1.Tournament = value;                
                standingsUc1.Tournament = value;
            }
        } 
        #endregion

        #region Ctor

        public TournamentDetailUc()
        {
            InitializeComponent();
        }
        
        #endregion

        #region Load
        private void TournamentDetailUc_Load(object sender, EventArgs e)
        {
            this.tournamentUc1.OnVisibleTab += new EventHandler(tournamentUc1_VisibleTab);
            this.tournamentUc1.OnTournamentSave += new EventHandler(tournamentUc1_OnTournamentSave);
        }

        #region Tab Enable Events
        void tournamentUc1_OnTournamentSave(object sender, EventArgs e)
        {
            this.Tournament = tournamentUc1.Tournament;
            
            this.standingsUc1.OnTournamentSave();

            AllowEdit(IsAllowEdit);
        }

        void tournamentUc1_VisibleTab(object sender, EventArgs e)
        {
            EnableTab();
        }

        #endregion

        #endregion

        #region Visible Tab
        private void VisibleTab()
        {
            if (this.Tournament == null)
            {
                HideTabs();

                return;
            }

            if (this.Tournament.IsNew)
            {
                HideTabs();
            }
            else
            {
                EnableTab();

                if (this.Tournament.TournamentTypeIDE == TournamentTypeE.Scheveningen)
                {
                    if (tabCntrlTournamentDetail.TabPages.Contains(tabRegisterPlayer))
                    {
                        tabCntrlTournamentDetail.TabPages.Remove(tabRegisterPlayer);
                    }
                }
                else
                {
                    if (tabCntrlTournamentDetail.TabPages.Contains(tabTeam))
                    {
                        tabCntrlTournamentDetail.TabPages.Remove(tabTeam);
                    }
                }
            }
        }

        private void EnableTab()
        {
            for (int i = 0; i < tabCntrlTournamentDetail.TabPages.Count; i++)
            {
                Control ctrl = tabCntrlTournamentDetail.TabPages[i] as Control;
                ctrl.Enabled = true;
            }

            if (this.Tournament == null)
            {
                return;
            }
            if (this.Tournament.TournamentID == 0)
            {
                return;
            }

            if (this.Tournament.TournamentTypeIDE == TournamentTypeE.Scheveningen)
            {
                if (tabCntrlTournamentDetail.TabPages["tabRegisterPlayer"] != null)
                {
                    tpRegisterUser = tabCntrlTournamentDetail.TabPages["tabRegisterPlayer"];
                    tabCntrlTournamentDetail.TabPages.Remove(tpRegisterUser);
                    if (tabCntrlTournamentDetail.TabPages["tabTeam"] == null)
                    {
                        tabCntrlTournamentDetail.TabPages.Insert(2, tpTeam);
                    }
                }
                 
            }
            else if (tabCntrlTournamentDetail.TabPages["tabTeam"] != null)
            {
                tpTeam = tabCntrlTournamentDetail.TabPages["tabTeam"];
                tabCntrlTournamentDetail.TabPages.Remove(tpTeam);
                if (tabCntrlTournamentDetail.TabPages["tabRegisterPlayer"] == null)
                {
                    tabCntrlTournamentDetail.TabPages.Insert(2, tpRegisterUser);
                }
            }             

        }

        private void HideTabs()
        {
            for (int i = 1; i < tabCntrlTournamentDetail.TabPages.Count; i++)
            {
                Control ctrl = tabCntrlTournamentDetail.TabPages[i] as Control;
                ctrl.Enabled = false;
            }
        }
        #endregion

        #region AllowEdit
        public void AllowEdit(bool allowEdit)
        {
            this.IsAllowEdit = allowEdit;

            if (allowEdit)
            {
                tournamentUc1.Visible = true;
                tournamentViewUc1.Visible = false;
                tournamentUc1.Dock = DockStyle.Fill;
            }
            else
            {
                tournamentUc1.Visible = false;
                tournamentViewUc1.Visible = true;
                tournamentViewUc1.Dock = DockStyle.Fill;
            }

            wantInPlayerUc1.AllowEdit(allowEdit);
            registeredPlayerUc1.AllowEdit(allowEdit);
            schTeamUc1.AllowEdit(allowEdit);
            prizeUc1.AllowEdit(allowEdit);
            matchesUc1.AllowEdit(allowEdit);            
            standingsUc1.AllowEdit(allowEdit);

        } 
        #endregion

        public void Show(int tournamentID)
        {
            Show(tournamentID, false);
        }

        public void Show(int tournamentID, bool allowEdit)
        {
            this.IsAllowEdit = allowEdit;

            Tournament = SocketClient.GetTournamentByID(tournamentID);

            tabCntrlTournamentDetail.SelectedIndex = 0;

            SelectTab("tournament");

            AllowEdit(allowEdit);

            VisibleTab();
        }

        private void tabCntrlTournamentDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectTab(tabCntrlTournamentDetail.SelectedTab.Text.ToLower());
        }

        private void SelectTab(string tabText)
        {
            switch (tabText)
            {
                case "tournament":
                    if (IsAllowEdit)
                    {
                        tournamentUc1.RefreshTab();
                    }
                    else
                    {
                        tournamentViewUc1.RefreshTab();
                    }
                    break;
                case "wantin player":
                    wantInPlayerUc1.RefreshTab();
                    break;
                case "register player":
                    registeredPlayerUc1.RefreshTab();
                    break;
                case "team":
                    schTeamUc1.RefreshTab();
                    break;
                case "prize":
                    prizeUc1.RefreshTab();
                    break;
                case "matches":
                    matchesUc1.RefreshTab();
                    break;
                case "standings":                    
                    standingsUc1.RefreshTab();
                    break;
                default:
                    break;
            }
        }

        public void Save()
        {
            tournamentUc1.Save();
        }

        public void WantinPlayer()
        {
            tournamentViewUc1.WantinPlayer();
        }

        private void matchesUc1_Load(object sender, EventArgs e)
        {

        }

    }
}
