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
    public partial class MatchEditor : Form
    {
        int round = 0;

        int player1 = 0, player2 = 0;
        string whitePlayer = string.Empty;
        string blackPlayer = string.Empty;

        int parentMatchID = 0;

        #region Properties
        public int ParentMatchID { get { return parentMatchID; } set { parentMatchID = value; } }

        int tournamentMatchID = 0;
        public int TournamentMatchID { get { return tournamentMatchID; } set { tournamentMatchID = value; } }

        public int Player1 { get { return player1; } set { player1 = value; } }

        public int Player2 { get { return player2; } set { player2 = value; } }

        public int Round { get { return round; } set { round = value; } }

        public string WhitePlayer { get { return whitePlayer; } set { whitePlayer = value; } }

        public string BlackPlayer { get { return blackPlayer; } set { blackPlayer = value; } }

        public App.Model.Db.Tournament Tournament = null;
        
        #endregion

        public MatchEditor()
        {
            InitializeComponent();
            //TieBreakMatchUc1.Tournament = Tournament;
            //TieBreakMatchUc1.Player1 = player1;
            //TieBreakMatchUc1.Player2 = player2;
            //TieBreakMatchUc1.Round = round;
            //TieBreakMatchUc1.ParentMatchID = parentMatchID;
            //TieBreakMatchUc1.TournamentMatchID = tournamentMatchID;
            //TieBreakMatchUc1.WhitePlayer = whiteName;
            //TieBreakMatchUc1.BlackPlayer = blackName;
        }

        public DialogResult Show(Form owner, App.Model.Db.Tournament Tournament , int tournamentMatchID, string whiteName, string blackName,
                                        int player1, int player2, int round, int parentMatchID, int matchStatusId, int matchTypeId,int statusId)
        {
            MatchEditor frm = new MatchEditor();
            frm.MatchEditorUc1.Tournament = Tournament;
            frm.MatchEditorUc1.TournamentMatchID = tournamentMatchID;
            frm.MatchEditorUc1.Player1 = player1;
            frm.MatchEditorUc1.Player2 = player2;
            frm.MatchEditorUc1.Round = round;
            frm.MatchEditorUc1.WhitePlayer = whiteName;
            frm.MatchEditorUc1.BlackPlayer = blackName;
            frm.MatchEditorUc1.ParentMatchID = parentMatchID;
            frm.MatchEditorUc1.MatchStatusID = matchStatusId;
            frm.MatchEditorUc1.MatchTypeID = matchTypeId;
            frm.MatchEditorUc1.StatusID = statusId;

            DialogResult dr = frm.ShowDialog(owner);            
            return dr;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {            
            //this.Close();
        }

        private void MatchEditor_Load(object sender, EventArgs e)
        {           

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Ap.Help(this, HelpTopicIdE.Tournament);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            MatchEditorUc1.SaveMatch();
            this.DialogResult = DialogResult.OK;
            //this.Close();
        }
    }
}
