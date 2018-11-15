using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FullScreenMode;
using App.Model;
using InfinityChess.Offline.Forms;
using InfinitySettings.EngineManager;
using App.Win;
using App.Model.Db;
using Game = App.Model.Game;

namespace InfinityChess.WinForms
{
    public partial class MainOnline : MainForm
    {
        #region Helpers

        private void GetSetGame(int challengeId)
        {
            DataSet ds = SocketClient.GetGameDataByChallengeID(challengeId);

            base.Game.DbGame = App.Model.Db.Game.CreateGame(Ap.Cxt, ds);
        }

        private void GetSetGameByGameId(int gameId)
        {
            DataSet ds = SocketClient.GetGameDataByGameID(gameId);

            base.Game.DbGame = App.Model.Db.Game.CreateGame(Ap.Cxt, ds);

            if (ds.Tables["Audience"] != null)
            {
                base.Game.Audience = ds.Tables["Audience"];
            }
        }

        private void GetAudienceGame(int gameId)
        {
            DataSet ds = SocketClient.GetAudienceGameData(gameId);

            base.Game.DbGame = App.Model.Db.Game.CreateGame(Ap.Cxt, ds);

            if (ds.Tables["Audience"] != null)
            {
                base.Game.Audience = ds.Tables["Audience"];
            }
        }

        private void AddGame(int challengeId)
        {
            DataSet ds = SocketClient.AddGameData(challengeId, PlayingModeData.Instance.ChessTypeID);

            base.Game.DbGame = App.Model.Db.Game.CreateGame(Ap.Cxt, ds);
        }

        private void SetGamePrameters(Kv kv)
        {
            SetGamePrameters(kv.Get("GameXml"), false);
        }
        
        private void SetGamePrameters(string gameXml, bool isPaste)
        {
            if (!base.Game.SetOnlineGameXml(gameXml, isPaste))
            {
                return;
            }

            isGameStarted = true;

            if (base.Game.GameMode == GameMode.Kibitzer && !base.Game.Flags.IsGameFinished)
            {
                base.Game.Clock.Start();
            }
        }

        private void NewGame()
        {
            ChessTypeE chessType = ChessTypeE.None;

            if (base.Game.DbGame.IsCurrentUserWhite)
            {
                chessType = base.Game.DbGame.WhiteChessTypeIDE;
            }
            else if (base.Game.DbGame.IsCurrentUserBlack)
            {
                chessType = base.Game.DbGame.BlackChessTypeIDE;
            }

            if (base.Game.DbGame.IsKibitzer)
            {
                EnableKibitzerMode(true);
                base.Game.NewGame(GameMode.Kibitzer, (GameType)base.Game.DbGame.GameTypeID);
            }
            else
            {
                switch (chessType)
                {
                    case ChessTypeE.None:
                        break;
                    case ChessTypeE.Human:
                        EnableKibitzerMode(false);
                        base.Game.NewGame(GameMode.OnlineHumanVsHuman, (GameType)base.Game.DbGame.GameTypeID);
                        break;
                    case ChessTypeE.Engine:
                        base.Game.NewGame(GameMode.OnlineEngineVsEngine, (GameType)base.Game.DbGame.GameTypeID);
                        DisableOfferDraw();
                        break;
                    case ChessTypeE.Centaur:
                        EnableCentaurMode(true);
                        base.Game.NewGame(GameMode.OnlineHumanVsHuman, (GameType)base.Game.DbGame.GameTypeID);
                        break;
                    case ChessTypeE.Correspondence:
                        break;
                    default:
                        break;
                }
            }

            if (base.Game.DbGame.IsCurrentUserBlack)
            {
                if (!ChessBoardUc.Flipped)
                {
                    base.FlipBoard();
                }
            }
            else
            {
                if (ChessBoardUc.Flipped)
                {
                    base.FlipBoard();
                }
            }
            
            SetStatusbarMessage("Ready - New Game");

            this.Text = "[" + Ap.CurrentUser.UserName + "] - " + base.Game.DbGame.WhiteUser.UserName + " - " + base.Game.DbGame.BlackUser.UserName + " , " + ((GameType)base.Game.DbGame.GameTypeID).ToString() + " , " + base.Game.DbGame.TimeMin.ToString() + "' + " + base.Game.DbGame.GainPerMoveMin.ToString() + "'' - " + DateTime.Today.Year.ToString();
            
            if (base.Game.DbGame.IsRated)
            {
                this.Text += " Rated";
            }
            else
            {
                this.Text += " Unrated";
            }
        }

        private void DisableOfferDraw()
        {
            if (PlayingModeData.Instance.AutometicAccepts || PlayingModeData.Instance.AutometicChallenges || this.Game.Flags.IsTournamentMatch)
            {
                OfferDrawOnline.Enabled = false;
            }
        }

        private void EnableBarButtons(bool b)
        {
            OnlineResign.Enabled = b;
            OfferDrawOnline.Enabled = b;
        }

        private void EnableKibitzerMode(bool b)
        {
            ExaminetoolStripMenuItem5.Enabled = b;
            ExaminetoolStripButton2.Enabled = b;
            addKibitzerToolStripMenuItem1.Enabled = b;
            removeKibitzerToolStripMenuItem.Enabled = b;
            removeAllKibitzersToolStripMenuItem.Enabled = b;
            engineManagementToolStripMenuItem.Enabled = b;
            OnlineResign.Enabled = !b;
            OfferDrawOnline.Enabled = !b;
        }

        private void EnableCentaurMode(bool b)
        {
            addKibitzerToolStripMenuItem1.Enabled = b;
            removeKibitzerToolStripMenuItem.Enabled = b;
            removeAllKibitzersToolStripMenuItem.Enabled = b;
        }

        private void NewGame(Kv kv)
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(kv.GetDataTable("Challenge").Copy());
            ds.Tables.Add(kv.GetDataTable("Game").Copy());
            ds.Tables.Add(kv.GetDataTable("Users").Copy());
            ds.Tables.Add(kv.GetDataTable("Engines").Copy());

            base.Game.DbGame = App.Model.Db.Game.CreateGame(Ap.Cxt, ds);

            OfferReMatch.Enabled = false;
            EnableBarButtons(true);
            NewGame();
        }

        public void VisibleColsingWindowTimerButton(bool b)
        {
            tsbStopClose.Visible = b;
        }

        public void CloseWindowTimer()
        {
            VisibleColsingWindowTimerButton(true);
            closeTimer = new Timer();
            closeTimer.Tick += new EventHandler(closeTimer_Tick);
            closeTimer.Interval = 500;
            closeTimer.Start();
        }

        void closeTimer_Tick(object sender, EventArgs e)
        {
            if (IsChangeColor)
            {
                tsbStopClose.BackColor = Color.LightYellow;
            }
            else
            {
                tsbStopClose.BackColor = Color.LightGreen;
                CloseWindowCounter--;
                tsbStopClose.Text = " " + CloseWindowCounter.ToString() + " sec : Stop Closing";
                if (CloseWindowCounter == 0)
                {
                    this.Close();
                }
            }
            IsChangeColor = !IsChangeColor;
        }

        #endregion

        #region Override Methods

        protected override void GameBeforeFinish()
        {

        }

        protected override void GameAfterFinish()
        {
            string msg = base.Game.ResultMessage;

            base.Game.CloseEngines();
            base.Game.Clock.Stop();
            SaveDocking();

            EnableBarButtons(false);
            if (!base.Game.DbGame.IsTournamentMatch && !base.Game.DbGame.IsKibitzer)
            {
                OfferReMatch.Enabled = true;
            }

            if (base.Game.Flags.AmIHuman && base.Game.ResultReason != GameResultReasonE.TimeExpired && base.Game.GameMode != GameMode.Kibitzer)
            {
                if (!string.IsNullOrEmpty(msg))
                {
                    MessageForm.Show(this, msg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            SetStatusbarMessage(msg);

            if (base.Game.Flags.IsGameWindowAutoCloseRequired && base.Game.Flags.IsGameWindowAutoCloseOnResult)
            {
                CloseWindowTimer();
                //this.Close();
            }
        }

        // whenever white or black piece is moved this function is called
        protected override void GameAfterMoveAdd()
        {
            base.GameAfterMoveAdd();

            if (base.Game.Flags.IsGameWindowAutoCloseRequired && base.Game.Flags.IsGameFinished)
            {
                CloseWindowTimer();
                //this.Close();
            }
        }

        protected override void GameAfterSetFen()
        {
            base.GameAfterSetFen();
        }


        protected override void GameBeforeNewGame(NewGameEventArgs e)
        {
            switch (base.Game.GameMode)
            {
                case GameMode.OnlineHumanVsHuman:
                    break;
                case GameMode.OnlineHumanVsEngine:
                    break;
                case GameMode.OnlineEngineVsEngine:
                    break;
                case GameMode.Kibitzer:
                    break;
                default:
                    break;
            }
        }

        protected override void GameAfterNewGame()
        {
            switch (base.Game.GameMode)
            {
                case GameMode.OnlineHumanVsHuman:
                    if (base.Game.Flags.IsPositionSetupEnabled)
                    {
                        EnablePositionSetup(true);
                    }
                    break;
                case GameMode.OnlineHumanVsEngine:
                    break;
                case GameMode.OnlineEngineVsEngine:
                    break;
                case GameMode.Kibitzer:
                    break;
                default:
                    break;
            }

            this.RefreshGameInfo();

            SetStatusbarMessage("Ready - New Game");
        }

        private void EnablePositionSetup(bool b)
        {
            positionGameToolStripMenuItem.Enabled = b;
            startGameToolStripMenuItem.Enabled = b;
        }

        #endregion

        #region ConsumeMessage

        #region ConsumeMessage
        void SynchronizeConsumeMessage(Kv kv)
        {
            DoConsumeMessage(kv);
        }

        void DoConsumeMessage(Kv kv)
        {
            MethodNameE MethodName = (MethodNameE)kv.GetInt32("MethodName");

            switch (MethodName)
            {
                case MethodNameE.UpdateGameDataByGameID:
                    SetGamePrameters(kv);
                    break;
                case MethodNameE.Resign:
                    UserResign(kv);
                    break;
                case MethodNameE.Abort:
                    UserAbort();
                    break;
                case MethodNameE.Draw:
                    UserDraw(kv);
                    break;
                case MethodNameE.NewGame:
                    UserNewGame(kv);
                    break;
                case MethodNameE.TimeExpired:
                    TimeIsExpired(kv);
                    break;
                case MethodNameE.KingStaleMated:
                    UserKingStaleMated();
                    break;
                case MethodNameE.ThreefoldRepetition:
                    UserThreefoldRepetition(kv);
                    break;
                case MethodNameE.AddAudienceAsync:
                    this.AddAudience(kv);
                    break;
                case MethodNameE.RemoveAudience:
                    this.RemoveAudience(kv);
                    break;
                case MethodNameE.BanUser:
                    BanUser(kv);
                    break;
                case MethodNameE.KickUser:
                    KickUser();
                    break;
                case MethodNameE.BlockIP:
                    BlockIP();
                    break;
                case MethodNameE.WriteChatMessage:
                    WriteChatMessage(kv);
                    break;
                case MethodNameE.ForceLogoff:
                    CloseAllWindows();
                    break;
                case MethodNameE.SetGamePositionByFen:
                    SetGamePositionByFen(kv);
                    break;
                case MethodNameE.CloseInProgressGameWindow:
                    CloseInProgressGameWindow(kv);
                    break;
                case MethodNameE.RestartGame:
                    RestartGame(kv);
                    break;
                case MethodNameE.RestartGameWithSetup:
                    RestartGameWithSetup(kv);
                    break;
                case MethodNameE.RescheduleTournament:
                    SetRescheduleTournament();
                    break;
                case MethodNameE.ForcedGameWin:
                    ForcedGameWin(kv);
                    break;
            }
        }

        #endregion

        #region ThreefoldRepetition

        private void UserThreefoldRepetition(Kv kv)
        {
            string gameXml = kv.Get("GameXml");
            //SetGamePrameters(gameXml, false);

            //base.Game.ThreefoldRepetition(false);
        }

        #endregion

        #region KingStaleMated

        private void UserKingStaleMated()
        {
            base.Game.StaleMated();
        }

        #endregion

        #region TimeExpired

        private void TimeIsExpired(Kv kv)
        {
            GameResultE result = (GameResultE)kv.GetInt32("GameResult");
            base.Game.TimeExpired(result, false);
            ClockUc.TimeExpired(result);
        }

        #endregion

        #region Resign

        private void UserResign(Kv kv)
        {
            GameResultE result = (GameResultE)kv.GetInt32("GameResult");
            base.Game.Resign(result);
        }

        private void Resign()
        {
            base.Game.Resign(GameResultE.InProgress);
        }
        #endregion

        #region AbortGame

        private void UserAbort()
        {
            base.Game.Abort(false);
        }

        private void Abort()
        {
            base.Game.Abort();
        }
        #endregion

        #region Draw
        private void UserDraw(Kv kv)
        {
            int gameID = kv.GetInt32("GameID");
            DrawE draw = (DrawE)kv.GetInt32("Draw");

            switch (draw)
            {
                case DrawE.Asked:
                    if (PlayingModeData.Instance.AutometicAccepts || PlayingModeData.Instance.AutometicChallenges)
                    {
                        RejectDrawOffer();
                        return;
                    }
                    EnableBarButtons(false);
                    if (MessageForm.Confirm(this, MsgE.DrawAsked) == DialogResult.Yes)
                    {
                        base.Game.Draw();
                        AcceptDrawOffer();
                        EnableBarButtons(false);
                    }
                    else
                    {
                        RejectDrawOffer();
                        EnableBarButtons(true);
                    }
                    break;
                case DrawE.Accepted:
                    base.Game.Draw();
                    break;
                case DrawE.Decline:
                    ChatClient.Write(ChatTypeE.GameWindow, ChatMessageTypeE.Info, ChatTypeE.GameWindow, MsgE.DrawDecline, gameID);
                    EnableBarButtons(true);
                    break;
                default:
                    break;
            }
        }

        private void OfferDraw()
        {
            SocketClient.Draw((int)DrawE.Asked, base.Game.DbGame.GameID, base.Game.GameResult, base.Game.DbGame.OpponentUserID, base.Game.Flags.Flags);
            EnableBarButtons(false);
        }

        private void RejectDrawOffer()
        {
            SocketClient.Draw((int)DrawE.Decline, base.Game.DbGame.GameID, base.Game.GameResult, base.Game.DbGame.OpponentUserID, base.Game.Flags.Flags);
        }

        private void AcceptDrawOffer()
        {
            SocketClient.Draw((int)DrawE.Accepted, base.Game.DbGame.GameID, base.Game.GameResult, base.Game.DbGame.OpponentUserID, base.Game.Flags.Flags);
        }
        #endregion

        #region New Game
        private void UserNewGame(Kv kv)
        {
            int gameID = kv.GetInt32("GameID");
            NewGameE newGame = (NewGameE)kv.GetInt32("NewGame");

            switch (newGame)
            {
                case NewGameE.Asked:
                    if (MessageForm.Confirm(this, MsgE.ConfirmPlay) == DialogResult.Yes)
                    {
                        AcceptNewGameOffer();
                    }
                    else
                    {
                        RejectNewGameOffer();
                    }
                    break;
                case NewGameE.Accepted:
                    NewGame(kv);
                    break;
                case NewGameE.Decline:
                    ChatClient.Write(ChatTypeE.GameWindow, ChatMessageTypeE.Info, ChatTypeE.GameWindow, MsgE.InfoNewGameOffer, gameID);
                    break;
                default:
                    break;
            }
        }

        private void OfferNewGame()
        {
            SocketClient.NewGame((int)NewGameE.Asked, base.Game.DbGame.OpponentUserID, Ap.CurrentUserID, base.Game.DbGame.ChallengeID);
        }
        private void RejectNewGameOffer()
        {
            SocketClient.NewGame((int)NewGameE.Decline, base.Game.DbGame.OpponentUserID, Ap.CurrentUserID, base.Game.DbGame.ChallengeID);
        }
        private void AcceptNewGameOffer()
        {
            SocketClient.NewGame((int)NewGameE.Accepted, base.Game.DbGame.OpponentUserID, Ap.CurrentUserID, base.Game.DbGame.ChallengeID);
        }
        #endregion

        #region AddAudience
        private void AddAudience(Kv kv)
        {
            DataTable dt = kv.GetDataTable("AudienceData");
            if (dt.Rows.Count > 0)
                AudienceUc.AddAudience(dt.Rows[0]);
        }

        #endregion

        #region RemoveAudience
        private void RemoveAudience(Kv kv)
        {
            int userID = kv.GetInt32("UserID");
            AudienceUc.RemoveAudience(userID);
        }

        #endregion

        #region Examine mode
        private void SwitchExamineMode()
        {
            base.Game.Flags.IsExamineMode = !base.Game.Flags.IsExamineMode;

            if (base.Game.Flags.IsExamineMode)
            {
                textBeforeMoveToolStripMenuItem.Enabled = true;
                textAfterMoveToolStripMenuItem.Enabled = true;
                deleteAllComentaryToolStripMenuItem.Enabled = true;
                ExaminetoolStripMenuItem5.Text = "Resume reciving moves";
                ExaminetoolStripButton2.ToolTipText = "Resume reciving moves";
                ChatClient.Write(ChatTypeE.GameWindow, ChatMessageTypeE.Info, ChatTypeE.GameWindow, "You have unplugged the transmission", base.Game.DbGame.ID);
            }
            else
            {
                textBeforeMoveToolStripMenuItem.Enabled = false;
                textAfterMoveToolStripMenuItem.Enabled = false;
                deleteAllComentaryToolStripMenuItem.Enabled = false;
                ExaminetoolStripMenuItem5.Text = "Stop reciving moves to examine";
                ExaminetoolStripButton2.ToolTipText = "Stop reciving moves to examine";
                GetAudienceGame(base.Game.DbGame.GameID);
                SetGamePrameters(base.Game.DbGame.GameXml, true);
                ChatClient.Write(ChatTypeE.GameWindow, ChatMessageTypeE.Info, ChatTypeE.GameWindow, "The transmission is plugged in", base.Game.DbGame.ID);
            }
        }
        #endregion

        #region Reconnect
        private void Reconnect()
        {
            if (SocketClient.ReconnectIfRequired(ChatTypeE.GameWindow))
            {
                DataSet ds = SocketClient.GetGameDataByGameID(base.Game.DbGame.GameID);
                base.Game.DbGame = App.Model.Db.Game.CreateGame(Ap.Cxt, ds);
                base.Game.SetOnlineGameXml(base.Game.DbGame.GameXml, true);
            }
        }
        #endregion

        #region Ban, kich, block IP of User
        private void KickUser()
        {
            if (base.Game != null)
            {
                base.Game.Abort();
            }
            //MessageForm.Show(this, MsgE.InfoKickUser, Ap.CurrentUser.UserName);
            this.Close();
        }

        private void BanUser(Kv kv)
        {
            if (base.Game != null)
            {
                CloseAllWindows();
            }
            
            //kv.Get("BanStartDate");
            //kv.Get("BanEndDate");
            //MessageForm.Show(this, MsgE.InfoBaned, kv.Get("BanStartDate"), kv.Get("BanStartDate"));
        }

        private void BlockIP()
        {
            if (base.Game != null)
            {
                MessageForm.Show(this, MsgE.InfoBlockedUser, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void CloseAllWindows()
        {
            base.Game.Abort();
            this.Close();
        }

        #endregion

        #region Forced Game Win
        private void ForcedGameWin(Kv kv)
        {
            GameResultE result = (GameResultE)kv.GetInt32("GameResultID");
            base.Game.GameForcefullyFinished(result);
        }

        #endregion
        
        #region RestartGame
        #region Core
        private void RestartGame(Kv kv)
        {
            ResetGameE resetGame = (ResetGameE)kv.GetInt32("ResetGame");

            switch (resetGame)
            {
                case ResetGameE.Asked:
                    ResetGameAsked(kv);
                    break;
                case ResetGameE.Accepted:
                    ResetGameAccepted(kv);
                    break;
                case ResetGameE.Decline:
                    ResetGameDecline();
                    break;
                case ResetGameE.ResetAsked:
                    RestartGameResetAsked(kv);
                    break;
            }
        }
        #endregion

        #region ResetGameAsked
        private void ResetGameAsked(Kv kv)
        {
            Ap.Game.Pause();
            ResetGameE reset = ResetGameE.Decline;
            
            if (MessageForm.Confirm(this, MsgE.ConfirmRestartTournamentMatch) == DialogResult.Yes)
            {
                reset = ResetGameE.Accepted;
            }
            else
            {
                Ap.Game.Resume();
            }

            SocketClient.RestartGame(kv.GetInt32("TournamentID"), kv.Get("MatchIDs"), kv.GetInt32("TournamentDirectorID"), kv.GetInt32("SenderUserID"), kv.GetInt32("ReceiverUserID"), reset, kv.GetBool("IsResetFromLastMove"), kv.Get("GameXml"));
        }
        #endregion

        #region ResetGameAccepted
        private void ResetGameAccepted(Kv kv)
        {
            NewGame();

            Ap.Game.Flags.IsReady = true;

            if (kv.GetBool("IsResetFromLastMove") && !string.IsNullOrEmpty(kv.Get("GameXml")))
            {
                SetGamePrameters(kv.Get("GameXml"), true);
            }
            
            if (kv.GetInt32("TournamentDirectorID") > 0)
            {
                ChatClient.Write(ChatTypeE.GameWindow, ChatMessageTypeE.Info, ChatTypeE.GameWindow, MsgE.InfoRestartTournamentMatch, base.Game.DbGame.GameID);
            }
            else
            {
                ChatClient.Write(ChatTypeE.GameWindow, ChatMessageTypeE.Info, ChatTypeE.GameWindow, MsgE.InfoTournamentMatchStarted, base.Game.DbGame.GameID);
            }

        }
        #endregion

        #region ResetGameDecline
        private void ResetGameDecline()
        {
            ChatClient.Write(ChatTypeE.GameWindow, ChatMessageTypeE.Info, ChatTypeE.GameWindow, MsgE.InfoTournamentMatchRequestDecline, base.Game.DbGame.GameID);
            Ap.Game.Resume();
        }
        #endregion

        #region RestartGameResetAsked
        private void RestartGameResetAsked(Kv kv)
        {
            Ap.Game.Pause();
            Ap.MsgQueue.Clear(this.Game.DbGame.GameID);
            Ap.Game.Flags.IsReady = false;
            //send back with Done
            SocketClient.RestartGame(kv.GetInt32("TournamentID"), kv.Get("GameID"), 0, kv.GetInt32("SenderUserID"), kv.GetInt32("ReceiverUserID"), ResetGameE.ResetDone, kv.GetBool("IsResetFromLastMove"), kv.Get("GameXml"));
        }
        #endregion
        #endregion

        #region RestartGameWithSetup

        #region Core
        private void RestartGameWithSetup(Kv kv)
        {
            ResetGameE reset = (ResetGameE)kv.GetInt32("ResetGame");

            switch (reset)
            {
                case ResetGameE.Asked:
                    RestartGameWithSetupAsked(kv);
                    break;
                case ResetGameE.Accepted:
                    RestartGameWithSetupAccepted(kv);
                    break;
                case ResetGameE.Decline:
                    RestartGameWithSetupDecline(kv);
                    break;
                case ResetGameE.ResetAsked:
                    RestartGameWithSetupResetAsked(kv);
                    break;
            }
        }
        #endregion

        #region RestartGameWithSetupAsked
        private void RestartGameWithSetupAsked(Kv kv)
        {
            Ap.Game.Pause();

            int moveID = kv.GetInt32("MoveID");
            int wMin = kv.GetInt32("WhiteMin");
            int wSec = kv.GetInt32("WhiteSec");
            int bMin = kv.GetInt32("BlackMin");
            int bSec = kv.GetInt32("BlackSec");

            DialogResult dr = SetupMatch.Show(this.ParentForm, moveID, base.Game.DbGame.TournamentMatchID, kv.GetInt32("SenderUserID"), kv.GetInt32("ReceiverUserID"), wMin, wSec, bMin, bSec, false);

            ResetGameE reset = ResetGameE.Decline;
            if (dr == DialogResult.OK)
            {
                reset = ResetGameE.Accepted;
            }

            SocketClient.RestartGameWithSetup(reset, base.Game.DbGame.GameID, moveID, kv.GetInt32("SenderUserID"), base.Game.DbGame.OpponentUserID, wMin, wSec, bMin, bSec, false);

            if (reset == ResetGameE.Decline)
            {
                Ap.Game.Resume();
            }
        }
        #endregion

        #region RestartGameWithSetupAccepted
        private void RestartGameWithSetupAccepted(Kv kv)
        {
            ChatClient.Write(ChatTypeE.OnlineClient, ChatMessageTypeE.Info, ChatTypeE.OnlineClient, MsgE.InfoResetTournamentGame, 0);
            NewGame();
            SetGamePrameters(kv.Get("GameXml"), true);
        }

        #endregion

        #region RestartGameWithSetupDecline
        private void RestartGameWithSetupDecline(Kv kv)
        {
            ChatClient.Write(ChatTypeE.GameWindow, ChatMessageTypeE.Info, ChatTypeE.GameWindow, MsgE.InfoTournamentMatchRequestDecline, base.Game.DbGame.GameID);
            Ap.Game.Resume();
        }
        #endregion

        #region RestartGameWithSetupResetAsked
        private void RestartGameWithSetupResetAsked(Kv kv)
        {
            int moveID = kv.GetInt32("MoveID");
            int wMin = kv.GetInt32("WhiteMin");
            int wSec = kv.GetInt32("WhiteSec");
            int bMin = kv.GetInt32("BlackMin");
            int bSec = kv.GetInt32("BlackSec");

            Ap.Game.Pause();
            Ap.MsgQueue.Clear(this.Game.DbGame.GameID);

            //send back with Done
            SocketClient.RestartGameWithSetup(ResetGameE.ResetDone, base.Game.DbGame.GameID, moveID, kv.GetInt32("SenderUserID"), base.Game.DbGame.OpponentUserID, wMin, wSec, bMin, bSec, false);
        }
        #endregion

        #endregion

        #region Set Reschedule Tournament
        private void SetRescheduleTournament()
        {
            if (this.Game.GameMode != GameMode.OnlineEngineVsEngine && this.Game.GameMode != GameMode.Kibitzer)
            {
                MessageForm.Show(this, MsgE.InfoRescheduleTournament);
            }
            base.Game.GameResult = GameResultE.NoResult;
            base.Close();
        }
        #endregion

        #region Close Window on force win from tournament match
        private void CloseInProgressGameWindow(Kv kv)
        {
            DataTable dt = kv.DataTable;

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (base.Game.DbGame.ID == Convert.ToInt32(kv.Get("GameID")))
                    {
                        base.Game.GameResultID = GameResultE.ForcedWhiteLose;
                        base.Close();
                    }
                }
            }
        }

        #endregion

        #region Set GamePosition By Fen
        private void SetGamePositionByFen(Kv kv)
        {
            string fen = kv.Get("Fen");
            base.Game.Flags.IsChallengerSendsGame = false;
            ChessBoardUc.SetFen(fen);
        }

        #endregion

        #region WriteChatMessage

        private void WriteChatMessage(Kv kv)
        {
            int gameID = kv.GetInt32("GameID");

            ChatClient.Write(ChatTypeE.GameWindow, (ChatMessageTypeE)kv.GetInt32("MessageType"), (ChatTypeE)kv.GetInt32("ChatType"), kv.Get("Message"), gameID);
        } 
        #endregion

        #endregion
    }
}

