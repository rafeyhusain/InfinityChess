using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;
namespace App.Win
{
    public partial class SetupMatch : Form
    {
        public int TournamentMatchID = 0;

        public SetupMatch()
        {
            InitializeComponent();
        }
        
        private void SetupMatch_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {            
            if (this.setupMatchUc2.MoveID == 0)
            {                
                if (!this.setupMatchUc2.RestartGame())
                {
                    return;
                }                
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Ap.Game != null)
            {
                Ap.Game.Resume();
            }
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Ap.Help(this, HelpTopicIdE.TeamDetail);
        }

        public static DialogResult Show(Form owner, int moveID, int tournamentMatchID, int challengerUserID, int opponentUserID,
            int wMin, int wSec, int bMin, int bSec, bool isTournamentDirector)
        {
            SetupMatch frm = new SetupMatch();
            frm.setupMatchUc2.TournamentMatchID = tournamentMatchID;
            frm.setupMatchUc2.ChallengerUserID = challengerUserID;
            frm.setupMatchUc2.OpponentUserID = opponentUserID;
            frm.setupMatchUc2.MoveID = moveID;
            frm.setupMatchUc2.WMin = wMin;
            frm.setupMatchUc2.WSec = wSec;
            frm.setupMatchUc2.BMin = bMin;
            frm.setupMatchUc2.BSec = bSec;
            frm.setupMatchUc2.IsTournamentDirector = isTournamentDirector;
            return frm.ShowDialog(owner);
        }
    }
}
