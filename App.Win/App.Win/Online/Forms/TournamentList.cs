using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;
using App.Model.Db;

namespace App.Win
{
    public partial class TournamentList : Form
    {
        public TournamentList(TournamentStatusE ts)
        {
            InitializeComponent();

            tournamentListUc1.TournamentStatus = ts; 
        }

        private void tournamentListUc1_Load(object sender, EventArgs e)
        {

        }

        internal static void Show(Form owner, TournamentStatusE tournamentStatusIDE)
        {
            TournamentList frm = new TournamentList(tournamentStatusIDE);

            frm.Show(owner);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TournamentList_Load(object sender, EventArgs e)
        {
            switch (tournamentListUc1.TournamentStatus)
            {
                case TournamentStatusE.Unknown:
                    this.Text = "My Tournament List";
                    break;
                case TournamentStatusE.Scheduled:
                    this.Text = "Forthcoming Tournaments";
                    break;
                case TournamentStatusE.InProgress:
                    this.Text = "InProgress Tournaments";
                    break;
                case TournamentStatusE.Finsihed:
                    this.Text = "Finsihed Tournaments";
                    break;
                default:
                    this.Text = "Tournament List";
                    break;
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Ap.Help(this, HelpTopicIdE.Tournament);
        }
    }
}
