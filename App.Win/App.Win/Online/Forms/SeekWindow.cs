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
    public partial class SeekWindow : BaseWinForm
    {
        #region Constructor
        public SeekWindow()
        {
            InitializeComponent();
        } 
        #endregion

        #region Events
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveChallenge();
            this.Close();
        }

        private void ChallengeWindow_Load(object sender, EventArgs e)
        {
            if (Ap.CurrentUser.HumanRankIDE == RankE.Guest)
            {
                chkRated.Enabled = false;
            }
        }

        private void chkRated_CheckedChanged(object sender, EventArgs e)
        {
            rbAutometic.Checked = true;
            chkWithClock.Checked = true;

            if (chkRated.Checked)
            {

                rbAutometic.Enabled = false;
                rbWhite.Enabled = false;
                rbBlack.Enabled = false;

                chkWithClock.Enabled = false;
            }
            else
            {
                rbAutometic.Enabled = true;
                rbWhite.Enabled = true;
                rbBlack.Enabled = true;

                chkWithClock.Enabled = true;
            }
        }

        private void btnBullet_Click(object sender, EventArgs e)
        {
            numericUpDownTimeMin.Value = 1;
            numericUpDownTimeSec.Value = 0;
            numericUpDownGainMove.Value = 0;
        }

        private void btnBlitz_Click(object sender, EventArgs e)
        {
            numericUpDownTimeMin.Value = 3;
            numericUpDownTimeSec.Value = 1;
            numericUpDownGainMove.Value = 0;
        }

        private void btnRapid_Click(object sender, EventArgs e)
        {
            numericUpDownTimeMin.Value = 11;
            numericUpDownTimeSec.Value = 1;
            numericUpDownGainMove.Value = 1;
        }

        private void btnSlow_Click(object sender, EventArgs e)
        {
            numericUpDownTimeMin.Value = 61;
            numericUpDownTimeSec.Value = 1;
            numericUpDownGainMove.Value = 1;
        }
        public override string HelpTopicId
        {
            get { return "210"; }
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            Ap.Help(this, HelpTopicIdE.Seek);
        }

        #endregion

        #region Helper

        private void LoadChallenge(DataTable dt)
        {
            numericUpDownTimeMin.Value = Convert.ToDecimal(dt.Rows[0]["TimeMin"].ToString());

            if (Convert.ToBoolean(dt.Rows[0]["IsRated"]))
            {
                chkRated.Checked = true;
            }
            if (Convert.ToBoolean(dt.Rows[0]["WithClock"]))
            {
                chkWithClock.Checked = true;
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
            int chessTypeID , roomID, timeMin, gainPerMove;
            bool isRated, withClock, challengerSendsGame;
            string description = "";
            ColorE colorIDE;
            GameType gameTypeIDE;
            chessTypeID = PlayingModeData.Instance.ChessTypeID;

            decimal stake = userFiniUc1.Stake;
            decimal flate = userFiniUc1.Flate;

            //if (RoomUc.selectedRoomId == 8 || RoomUc.selectedRoomId == 9 || RoomUc.selectedRoomId == 10 || RoomUc.selectedRoomId == 11 || RoomUc.selectedRoomId == 12)
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
                if (chessTypeID == 3)
                {
                    gameTypeIDE = GameType.Long;
                }
                else
                {
                    gameTypeIDE = GameTime.GetGameType((int)numericUpDownTimeMin.Value, 0);
                }
                
                timeMin = Convert.ToInt32(numericUpDownTimeMin.Value);
                gainPerMove = Convert.ToInt32(numericUpDownGainMove.Value);
            }
            else
            {
                gameTypeIDE = GameType.NoClock;
                timeMin = 0;
                gainPerMove = 0;
            }

            challengerSendsGame = false;
            description = "";

            try
            {
                DataSet ds = SocketClient.AddChallengeData(Ap.CurrentUserID, 0, ChallengeTypeE.Seek, gameTypeIDE, colorIDE, roomID, timeMin, gainPerMove, chessTypeID, isRated, withClock, challengerSendsGame, description, Convert.ToInt32(stake), Convert.ToInt32(flate));
                ChallengesUc.Instance.LoadChallenges(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
            }
        } 

        #endregion

        

    }
}

