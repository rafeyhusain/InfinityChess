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
using InfinityChess.InfinityChesshelp;

namespace App.Win
{
    public partial class ChallengeWindow : BaseWinForm
    {
        #region Data Member
        public bool IsModify = false;
        public int ChallengeID = 0;
        public int opponentUserID = 0;
        public string opponentUserName = "";
        public string opponentRank = ""; 
        #endregion

        #region Constructor

        public ChallengeWindow()
        {
            InitializeComponent();
        } 

        #endregion

        #region Events

        private void ChallengeWindow_Load(object sender, EventArgs e)
        {
            lblOpponentName.Text = opponentUserName;
            if (IsModify)
            {
                DataSet ds = SocketClient.GetChallengeByID(ChallengeID);
                if (ds != null && ds.Tables.Count > 0)
                    LoadChallenge(ds.Tables[0]);

            }
            else
            {
                if (Ap.CurrentUser.HumanRankIDE == RankE.Guest || opponentRank == "Guest")
                {
                    chkRated.Enabled = false;
                }
                //rbAutometic.Checked = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (IsModify)
            {
                ModifyChallenge();
            }
            else
            {
                SaveChallenge();
            }
            this.Close();
        }

        private void chkRated_CheckedChanged(object sender, EventArgs e)
        {
            rbAutometic.Checked = true;
            chkWithClock.Checked = true;
            chkChallengesSendsGame.Checked = false;

            if (chkRated.Checked)
            {

                rbAutometic.Enabled = false;
                rbWhite.Enabled = false;
                rbBlack.Enabled = false;

                chkWithClock.Enabled = false;
                chkChallengesSendsGame.Enabled = false;
            }
            else
            {
                rbAutometic.Enabled = true;
                rbWhite.Enabled = true;
                rbBlack.Enabled = true;

                chkWithClock.Enabled = true;
                chkChallengesSendsGame.Enabled = true;
            }
        }
        public override string HelpTopicId
        {
            get { return "160"; }
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            Ap.Help(this, HelpTopicIdE.ChallangeWindow);
        }

        #endregion

        #region Helper

        private void LoadChallenge(DataTable dt)
        {
            numericUpDownTime.Value = Convert.ToDecimal(dt.Rows[0]["TimeMin"].ToString());

            if (Convert.ToBoolean(dt.Rows[0]["IsRated"]))
            {
                chkRated.Checked = true;
            }
            if (Convert.ToBoolean(dt.Rows[0]["WithClock"]))
            {
                chkWithClock.Checked = true;
            }
            if (Convert.ToBoolean(dt.Rows[0]["IsChallengerSendsGame"]))
            {
                chkChallengesSendsGame.Checked = true;
            }

            if (Convert.ToInt32(dt.Rows[0]["ColorID"]) == (int)ColorE.White)
            {
                rbWhite.Checked = true;
            }
            else if (Convert.ToInt32(dt.Rows[0]["ColorID"]) == (int)ColorE.Black)
            {
                rbBlack.Checked = true;
            }
            else
            {
                rbAutometic.Checked = true;
            }

        }        

        private void SaveChallenge()
        {
            int chessTypeID, roomID, timeMin, gainPerMove;
            bool isRated, withClock, challengerSendsGame;
            string description = "";
            ColorE colorIDE;
            GameType gameTypeIDE;

            decimal stake = 0, flate = 0;
            if (userFiniUc1.IsFiniApplicable(opponentUserID))
            {
                return;
            }

            stake = userFiniUc1.Stake;
            flate = userFiniUc1.Flate;

            chessTypeID = PlayingModeData.Instance.ChessTypeID; 
            if (rbAutometic.Checked)
            {
                colorIDE = ColorE.Autometic;
            }
            else if (rbWhite.Checked)
            {
                colorIDE = ColorE.White;
            }
            else
            {
                colorIDE = ColorE.Black;
            }
            if (Ap.SelectedRoomID != 0)
                roomID = Ap.SelectedRoomID;
            else
                roomID = Ap.CurrentUser.RoomID;

            isRated = chkRated.Checked;
            withClock = chkWithClock.Checked;

            if (withClock)
            {
                if (chessTypeID == 3)
                {
                    gameTypeIDE = GameType.Long;
                }
                else
                {
                    gameTypeIDE = GameTime.GetGameType((int)numericUpDownTime.Value, 0);
                }
                timeMin = Convert.ToInt32(numericUpDownTime.Value);
                gainPerMove = Convert.ToInt32(numericUpDownGainMove.Value);
            }
            else 
            {
                gameTypeIDE = GameType.NoClock;
                timeMin = 0;
                gainPerMove = 0;
            }
            
            challengerSendsGame = chkChallengesSendsGame.Checked;
            description = "";

            try
            {
                DataSet ds = SocketClient.AddChallengeData(Ap.CurrentUserID, opponentUserID, ChallengeTypeE.Challenge, gameTypeIDE, colorIDE, roomID, timeMin, gainPerMove, chessTypeID, isRated, withClock, challengerSendsGame, description, Convert.ToInt32(stake), Convert.ToInt32(flate));
                ChallengesUc.Instance.LoadChallenges(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
            }
        }

        private void ModifyChallenge()
        {
            int chessTypeID, timeMin, gainPerMove, roomID;
            bool isRated, withClock, challengerSendsGame;
            ColorE colorIDE;
            GameType gameTypeIDE;
            chessTypeID = PlayingModeData.Instance.ChessTypeID; 
            //if (RoomUc.selectedRoomParentId == 8)
            //{
            //    chessTypeID = 2;
            //}
            //else
            //{
            //    chessTypeID = 1;
            //}

            if (rbAutometic.Checked)
            {
                colorIDE = ColorE.Autometic;
            }
            else if (rbWhite.Checked)
            {
                colorIDE = ColorE.White;
            }
            else
            {
                colorIDE = ColorE.Black;
            }
            if (Ap.SelectedRoomID != 0)
                roomID = Ap.SelectedRoomID;
            else
                roomID = Ap.CurrentUser.RoomID;

            isRated = chkRated.Checked;
            withClock = chkWithClock.Checked;

            if (withClock)
            {
                gameTypeIDE = GameTime.GetGameType((int)numericUpDownTime.Value, 0);
                timeMin = Convert.ToInt32(numericUpDownTime.Value);
                gainPerMove = Convert.ToInt32(numericUpDownGainMove.Value);
            }
            else
            {
                gameTypeIDE = GameType.NoClock;
                timeMin = 0;
                gainPerMove = 0;
            }

            challengerSendsGame = chkChallengesSendsGame.Checked;
            
            DataSet ds = SocketClient.ModifyChallenge(colorIDE, gameTypeIDE, ChallengeID, roomID, chessTypeID, isRated, withClock, challengerSendsGame, opponentUserID, timeMin, gainPerMove);
            ChallengesUc.Instance.LoadChallenges(ds.Tables[0]);
        } 

        #endregion
      

    }
}
