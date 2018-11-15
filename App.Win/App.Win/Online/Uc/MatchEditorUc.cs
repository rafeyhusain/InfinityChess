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
    public partial class MatchEditorUc : UserControl
    {
        #region Constructor
        public MatchEditorUc()
        {
            InitializeComponent();
        }
        
        #endregion

        #region DataMembers 
        public App.Model.Db.Tournament Tournament = null;        
        public int TournamentMatchID;
        public int Player1;
        public int Player2;
        public int Round ;
        public string WhitePlayer;
        public string BlackPlayer;
        public int ParentMatchID;
        public int MatchStatusID;
        public int MatchTypeID;
        public int StatusID;        
        #endregion        

        #region FillNumbers
        void FillNumbers(ComboBox cb, int counter, int start)
        {
            for (int i = start; i < counter; i++)
            {
                cb.Items.Add(i.ToString());
            }
            cb.SelectedIndex = 0;
        } 
        #endregion

        #region Validation

        public bool IsWhiteBlackPlayer
        {
            get
            {
                if (!((cbColorA.SelectedIndex == 0 && cbColorB.SelectedIndex == 1) ||
                     (cbColorA.SelectedIndex == 1 && cbColorB.SelectedIndex == 0)))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        bool IsChildRound
        {
            get
            {
                int parentID = 0;

                parentID = this.ParentMatchID;
                if (this.ParentMatchID == 0)
                {
                    parentID = this.TournamentMatchID;
                }
                DataSet ds = SocketClient.GetTournamntMatchByParentID(parentID);
                bool isTrue = false;
                if (ds != null)
                {
                    TournamentMatch TournamentMatch = null;
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            if (this.ParentMatchID == 0)
                            {
                                isTrue = true;
                            }

                            TournamentMatch = new TournamentMatch(Ap.Cxt, ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]);

                            if (TournamentMatch.TournamentMatchID != this.TournamentMatchID)
                            {
                                isTrue = true;
                            }
                        }
                        else
                        {
                            this.ParentMatchID = this.TournamentMatchID;
                            isTrue = false;
                        }
                    }
                    else
                    {
                        this.ParentMatchID = this.TournamentMatchID;
                        isTrue = false;
                    }
                }
                return isTrue;
            }

        }

        
        #endregion
                
        #region InitFields
        private void InitFields()
        {
            FillNumbers(cmbMin, 181, 1);
            FillNumbers(cmbSec, 60, 0);
            txtColorA.Text = WhitePlayer;
            txtColorB.Text = BlackPlayer;
            cbColorA.SelectedIndex = 0;
            cbColorB.SelectedIndex = 1;
        } 
        #endregion
        
        #region Save
        private bool Save()
        {
            int player1 = 0, player2 = 0;

            if (!IsWhiteBlackPlayer)
            {
                MessageForm.Error(this.ParentForm, MsgE.ErrorWhiteAndBlackBye);
                return false;
            }

            if (IsChildRound)
            {
                MessageForm.Error(this.ParentForm, MsgE.ErrorTieBreakMatchStart);
                return false;
            }

            player1 = Player1;
            player2 = Player2;

            if (cbColorA.SelectedIndex == 1)
            {
                player1 = Player2;
                player2 = Player1;
            }


            Kv kv = new Kv();

            if (this.Tournament != null)
            {
                kv.Set("TournamentID", this.Tournament.TournamentID);
            }

            kv.Set("WhiteUserID", player1);
            kv.Set("BlackUserID", player2);

            kv.Set("Round", Round);
                        
            if (cmbMin.SelectedItem != null)
            {
                kv.Set("TimeMin", cmbMin.SelectedItem.ToString());
            }
            else
            {
                kv.Set("TimeMin", 1);
            }

            if (cmbSec.SelectedItem != null)
            {
                kv.Set("TimeSec", cmbSec.SelectedItem.ToString());
            }
            else
            {
                kv.Set("TimeSec", 0);
            }

            kv.Set("MatchStartDate", DateTime.Now);
            kv.Set("MatchStartTime", DateTime.Now);

            kv.Set("TournamentMatchID", this.TournamentMatchID);
            kv.Set("ParentMatchID", this.ParentMatchID);
            kv.Set("TournamentMatchStatusID", MatchStatusID);
            kv.Set("TournamentMatchTypeID", MatchTypeID);
            kv.Set("StatusID", StatusID);

            ProgressForm frmProgress = ProgressForm.Show(this, "Saving Match...");

            DataSet ds = SocketClient.SaveTournamentMatch(kv);

            frmProgress.Close();
            return true;

        } 
        #endregion

        #region Events
        private void TieBreakMatchUc_Load(object sender, EventArgs e)
        {
            InitFields();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveMatch();
        }

        public void SaveMatch()
        {
            if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, "update", "match") == DialogResult.Yes)
            {
                if (Save())
                {
                    this.ParentForm.DialogResult = DialogResult.OK;
                }
            }
        } 
        #endregion

        private void cbColorA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbColorA.SelectedIndex == 0)
            {
                cbColorB.SelectedIndex = 1;
            }
            else
            {
                cbColorB.SelectedIndex = 0;
            }
        }

        private void cbColorB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbColorB.SelectedIndex == 0)
            {
                cbColorA.SelectedIndex = 1;
            }
            else
            {
                cbColorA.SelectedIndex = 0;
            }
        }
    }
}
