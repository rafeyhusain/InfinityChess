using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InfinityChess;
using InfinitySettings.UCIManager;
using App.Model;
using System.Drawing.Imaging;
using InfinityChess.InfinityChesshelp;
using App.Model.Db;

namespace App.Win
{
    public partial class PlayingMode : BaseWinForm
    {
        #region Data Members

        public App.Model.Game Game = null;
        static UCIEngine selectedEngine;
        static Book selectedBook;
        #endregion

        #region ctor
        public PlayingMode(App.Model.Game game)
        {
            this.Game = game;
            InitializeComponent();
        }
        #endregion

        #region Load
        private void PlayingMode_Load(object sender, EventArgs e)
        {
            if (Ap.SelectedRoomID == (int)RoomE.ComputerChess || Ap.SelectedRoomParentID == (int)RoomE.ComputerChess || Ap.SelectedRoomParentID == (int)RoomE.EngineTournaments)
            {
                rbComputer.Enabled = true;
                rbCentaur.Enabled = true;
                btnDefineEngine.Enabled = true;
            }
            
            if (PlayingModeData.Instance.ChessType == ChessTypeE.Engine)
            {
                rbComputer.Checked = true;
                rbComputer.Enabled = true;
                chkAutomaticChallenges.Checked = PlayingModeData.Instance.AutometicChallenges;
                chkAutometicAccepts.Checked = PlayingModeData.Instance.AutometicAccepts;
                chkSendEvaluations.Checked = PlayingModeData.Instance.SendEvaluations;
                chkSendExpectedMove.Checked = PlayingModeData.Instance.SendExpectedMoves;
                numericUpDown1.Value = PlayingModeData.Instance.Time;
            }
            else if (PlayingModeData.Instance.ChessType == ChessTypeE.Centaur)
            {
                rbCentaur.Checked = true;
            }
            else 
            {
                rbHuman.Checked = true;
            }
            selectedEngine = Ap.PlayingMode.SelectedEngine;
            selectedBook = Ap.PlayingMode.SelectedBook;

            if (Ap.IsGameInProgress)
            {
                rbHuman.Enabled = false;
                rbComputer.Enabled = false;
                rbCentaur.Enabled = false;
                btnDefineEngine.Enabled = false;
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                chkSendEvaluations.Enabled = false;
                chkSendExpectedMove.Enabled = false;
            }
        }

        #endregion

        #region Events
        private void btnDefineEngine_Click(object sender, EventArgs e)
        {
            InviteEngine frm = new InviteEngine(selectedEngine, selectedBook, true, this.Game);

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                selectedEngine = frm.SelectedEngine;
                selectedBook = frm.SelectedBook;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Ap.IsGameInProgress)
            {
                PlayingModeData.Instance.AutometicChallenges = chkAutomaticChallenges.Checked;
                PlayingModeData.Instance.AutometicAccepts = chkAutometicAccepts.Checked;
                this.Close();
            }
            else
            {
                string engineName = string.Empty;
                UserStatusE userStatus;
                if (rbHuman.Checked)
                {
                    if (selectedEngine != null)
                    {
                        selectedEngine.Close();
                        selectedEngine = null;
                    }
                    
                    Ap.PlayingMode.ChessTypeID = 1;
                    PlayingModeData.Instance.AutometicChallenges = false;
                    PlayingModeData.Instance.AutometicAccepts = false;
                    PlayingModeData.Instance.SendEvaluations = false;
                    PlayingModeData.Instance.SendExpectedMoves = false;
                    userStatus = UserStatusE.Blank;
                }
                else if (rbComputer.Checked)
                {
                    if (selectedEngine == null)
                    {
                        MessageForm.Show(this, MsgE.InfoUploadEngine);
                        return;
                    }
                    engineName = selectedEngine.EngineName;
                    Ap.PlayingMode.ChessTypeID = 2;
                    PlayingModeData.Instance.AutometicChallenges = chkAutomaticChallenges.Checked;
                    PlayingModeData.Instance.AutometicAccepts = chkAutometicAccepts.Checked;
                    PlayingModeData.Instance.SendEvaluations = chkSendEvaluations.Checked;
                    PlayingModeData.Instance.SendExpectedMoves = chkSendExpectedMove.Checked;
                    PlayingModeData.Instance.Time = UData.ToInt32(numericUpDown1.Value);
                    PlayingModeData.Instance.GainPerMove = UData.ToInt32(numericUpDown2.Value);
                    Ap.CurrentUser.UserStatusIDE = userStatus = UserStatusE.Engine;
                    ChatClient.Write(ChatTypeE.OnlineClient, ChatMessageTypeE.Info, ChatTypeE.OnlineClient, "'" + engineName + "' loaded successfully", 0);
                }
                else
                {
                    Ap.PlayingMode.ChessTypeID = 3;
                    PlayingModeData.Instance.AutometicChallenges = false;
                    PlayingModeData.Instance.AutometicAccepts = false;
                    PlayingModeData.Instance.SendEvaluations = false;
                    PlayingModeData.Instance.SendExpectedMoves = false;
                    Ap.CurrentUser.UserStatusIDE = userStatus = UserStatusE.Centaur;
                }

                SocketClient.SetUserEngine(engineName, userStatus);
                PlayingModeData.Instance.Pause = Ap.CurrentUser.IsPause;
                PlayingModeData.Instance.ChessTypeID = Ap.PlayingMode.ChessTypeID;
                PlayingModeData.Instance.Save();
                Ap.PlayingMode.SelectedEngine = selectedEngine;
                Ap.PlayingMode.SelectedBook = selectedBook;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            selectedEngine = null;
            selectedBook = null;
            this.Close();
        }

        private void rbComputer_CheckedChanged(object sender, EventArgs e)
        {
            btnDefineEngine.Enabled = true;
            if (Ap.SelectedRoomParentID != (int)RoomE.EngineTournaments && Ap.SelectedRoomID != (int)RoomE.EngineTournaments)
            {
                chkAutomaticChallenges.Enabled = true;
                chkAutometicAccepts.Enabled = true;
                chkSendEvaluations.Enabled = true;
                chkSendExpectedMove.Enabled = true;
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
            }
        }

        private void rbHuman_CheckedChanged(object sender, EventArgs e)
        {
            btnDefineEngine.Enabled = false;
            chkAutomaticChallenges.Enabled = false;
            chkAutometicAccepts.Enabled = false;
            chkSendEvaluations.Enabled = false;
            chkSendExpectedMove.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
        }

        private void rbCentaur_CheckedChanged(object sender, EventArgs e)
        {
            btnDefineEngine.Enabled = false;
            chkAutomaticChallenges.Enabled = false;
            chkAutometicAccepts.Enabled = false;
            chkSendEvaluations.Enabled = false;
            chkSendExpectedMove.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
        }
        public override string HelpTopicId
        {
            get { return "190"; }
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            Ap.Help(this, HelpTopicIdE.PlayingMode);
        }
        #endregion
    }
}
