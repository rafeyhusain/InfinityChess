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
    public partial class SetupMatchUc : UserControl
    {
        int gameID = 0;
        public int OpponentUserID = 0;
        public int ChallengerUserID = 0;
        public int TournamentMatchID = 0;
        public int MoveID = 0;
        public int WMin = 0, WSec = 0, BMin = 0, BSec = 0;
        public bool IsTournamentDirector;
        
        public App.Model.Db.Game DbGame
        {
            get { return notationViewerUc1.DbGame; }
            set { notationViewerUc1.DbGame = value; }
        }        

        public SetupMatchUc()
        {
            InitializeComponent();
        }

        private void SetupMatchUc_Load(object sender, EventArgs e)
        {
            FillNumbers(cmbBlackMin, 181, 1);
            FillNumbers(cmbWhiteMin, 181, 1);
            FillNumbers(cmbBlackSec, 60, 0);
            FillNumbers(cmbWhiteSec, 60, 0);

            if (WMin > 0)
            {
                cmbWhiteMin.Text = Convert.ToString(WMin/60);
            }
            if (WSec > 0)
            {
                cmbWhiteSec.Text = WSec.ToString();
            }

            if (BMin > 0)
            {
                cmbBlackMin.Text = Convert.ToString(BMin/60);
            }
            if (BSec > 0)
            {
                cmbBlackSec.Text = BSec.ToString();
            }

            EnableFields(true);
            if (this.MoveID > 0)
            {
                notationViewerUc1.MoveID = this.MoveID;
                EnableFields(false);                
            }

            SetMoves();
        }

        public void EnableFields(bool enable)
        {
            cmbBlackMin.Enabled = enable;
            cmbBlackSec.Enabled = enable;
            cmbWhiteMin.Enabled = enable;
            cmbWhiteSec.Enabled = enable;
            if (enable)
            {
                lblMsg.Text = Msg.GetMsg(MsgE.InfoRestartTournamentGame);
            }
            else
            {
                lblMsg.Text = Msg.GetMsg(MsgE.ConfirmRestartTournamentGame);
            }
        }

        private void SetMoves()
        {
            ProgressForm frm = ProgressForm.Show(this, "Loading Game Information...");

            DataSet dsGame = SocketClient.GetGameDataByTournamentMatchID(TournamentMatchID);

            frm.Close();

            if (dsGame == null)
            {
                return;
            }

            if (dsGame.Tables.Count > 0)
            {
                if (dsGame.Tables[0].Rows.Count > 0)
                {
                    notationViewerUc1.DbGame = new App.Model.Db.Game(Ap.Cxt, dsGame.Tables[0].Rows[0]);
                    notationViewerUc1.Init();
                }
            }
        }

        void FillNumbers(ComboBox cb, int counter, int start)
        {
            for (int i = start; i < counter; i++)
            {
                cb.Items.Add(i.ToString());
            }
            cb.SelectedIndex = 0;
        }


        public bool RestartGame()
        {
            if (DbGame == null)
            {
                return false;
            }            

            GameType wGameType = GameTime.GetGameType(Convert.ToInt32(cmbWhiteMin.Text), Convert.ToInt32(cmbWhiteSec.Text));
            GameType bGameType = GameTime.GetGameType(Convert.ToInt32(cmbBlackMin.Text), Convert.ToInt32(cmbBlackSec.Text));

            if (this.DbGame.GameTypeIDE != wGameType || this.DbGame.GameTypeIDE != bGameType)
            {
                MessageForm.Error(this.ParentForm, MsgE.ErrorRestartGameTime, "");
                return false;
            }

            int wMin = Convert.ToInt32(cmbWhiteMin.Text) * 60;
            int wSec = Convert.ToInt32(cmbWhiteSec.Text);

            int bMin = Convert.ToInt32(cmbBlackMin.Text) * 60;
            int bSec = Convert.ToInt32(cmbBlackSec.Text);
            
            ProgressForm frm = ProgressForm.Show(this, "Restarting Game...");

            SocketClient.RestartGameWithSetup(ResetGameE.Asked, this.DbGame.GameID, notationViewerUc1.SelectedMoveID, ChallengerUserID, OpponentUserID, wMin, wSec, bMin, bSec, IsTournamentDirector);

            frm.Close();
            return true;
        }

    }
}
