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
    public partial class TournamentDetail : Form
    {
        #region Ctor
        public TournamentDetail()
        {
            InitializeComponent();
        }
        
        #endregion

        #region Properties
        private static bool IsAllowEdit = false;
        public App.Model.Db.Tournament Tournament
        {
            get { return tournamentDetailUc1.Tournament; }
            set { tournamentDetailUc1.Tournament = value; }
        } 
        #endregion

        #region Load
        private void TournamentDetail_Load(object sender, EventArgs e)
        {            
        }
        
        #endregion

        #region Helpers

        #endregion

        #region Buttons
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (IsAllowEdit)
            {
                this.tournamentDetailUc1.Save();
            }
            else
            {
                this.tournamentDetailUc1.WantinPlayer();
            }
        }        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        } 
        #endregion

        #region Show

        public static void Show(Form owner, int tournamentID)
        {
            TournamentDetail frm = new TournamentDetail();
            IsAllowEdit = true;
            frm.Show(tournamentID, IsAllowEdit);

            frm.Show(owner);
        }

        public static DialogResult ShowDialog(Form owner, int tournamentID)
        {
            return Show(owner, tournamentID, true);
        }

        public static DialogResult Show(Form owner, int tournamentID, bool allowEdit)
        {
            TournamentDetail frm = new TournamentDetail();
            IsAllowEdit = allowEdit;
            frm.Show(tournamentID, allowEdit);

            return frm.ShowDialog(owner);
            //frm.Show(owner);
        }

        private void Show(int tournamentID, bool allowEdit)
        {
            tournamentDetailUc1.Show(tournamentID, allowEdit);

            if (tournamentID <= 0)
            {
                this.Text = "New Tournament";
            }
            else 
            {
                if (tournamentDetailUc1.Tournament == null)
                {
                    return;
                }
                this.Text = tournamentDetailUc1.Tournament.Name;
            }
        } 
        #endregion

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Ap.Help(this, HelpTopicIdE.Tournament);
        }
    }
}
