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
using Crom.Controls.Docking;

namespace InfinityChess.WinForms
{
    public partial class MainOnline : MainForm
    {
        #region DataMember
        Point menuStripOriginalLocation;
        Point toolStripOriginalLocation;
        
        #endregion

        #region Menu Click Events

        #region File Menu



        #region File > New  Events // *****************************************
        private void blitzGameToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //new game
        }

        private void PositionGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmGameResult.AdjudicateGame(base.Game))
            {
                return;
            }

            PositionSetup frm = new PositionSetup(base.Game, this);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                base.Game.NewGame(frm.Fen, base.Game.GameMode, base.Game.GameType);
            }
        }

        #endregion

        #region File > open

        private void openingBookToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void dataBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Save and Exit

        private void toolStripSaveGame_Click(object sender, EventArgs e)
        {
            //save game
            SaveGame(false);
        }


        private void ToolStripSaveAsGame_Click(object sender, EventArgs e)
        {
            //save as game
            SaveGame(true);
        }

        private void savePositionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        #endregion

        #region File > Print

        private void printSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void publishGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void publishGameToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        #endregion


        #endregion

        #region Edit menu




        private void UndotoolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void CanceltoolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }


        private void copyGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.Game.Clipboard.CopyGame();
        }
        private void copyPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fen = base.ChessBoardUc.GetFen();
            App.Win.Clipboard.CopyPosition(fen);

            //whiteMoveNumber = base.Game.Notations.MoveNo;
            //tempDataTable = base.Game.Notations.MovesData;
        }

        private void pastGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void pastPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pasteEngineVaritionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pasteEngineMoveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void editGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void findPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region View Menu

        private void flipBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlipBoard();
        }

        private void toolbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolbarToolStripMenuItem.Checked)
            {
                toolStrip1.Visible = false;
                toolbarToolStripMenuItem.Checked = false;
            }
            else
            {
                toolStrip1.Visible = true;
                toolbarToolStripMenuItem.Checked = true;
            }
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statusBarToolStripMenuItem.Checked)
            {
                statusStrip1.Visible = false;
                statusBarToolStripMenuItem.Checked = false;
            }
            else
            {
                statusStrip1.Visible = true;
                statusBarToolStripMenuItem.Checked = true;
            }
        }

        private void menubarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menubarToolStripMenuItem.Checked)
            {
                DialogResult result = MessageBox.Show("Press Ctrl + Alt + M to access menubar", "", MessageBoxButtons.OKCancel);
                if (result.ToString() == "OK")
                {
                    menuStrip1.Visible = false;
                    menubarToolStripMenuItem.Checked = false;

                    //// set toolstrip location to menustrip location.
                    menuStripOriginalLocation = new Point(menuStrip1.Location.X, menuStrip1.Location.Y);
                    toolStripOriginalLocation = new Point(toolStrip1.Location.X, toolStrip1.Location.Y);
                    toolStrip1.Location = new Point(menuStripOriginalLocation.X, menuStripOriginalLocation.Y);

                    if (toolStrip1.Visible)
                    {
                        tableLayoutPanel1.ColumnStyles[0].Width = 0;
                    }
                    else
                    {
                        tableLayoutPanel1.ColumnStyles[0].Width = 0;
                        tableLayoutPanel1.Visible = false;
                    }
                }
            }
            else
            {
                menuStrip1.Visible = true;
                menubarToolStripMenuItem.Checked = true;

                //// set toolstrip location to menustrip location.                                
                toolStrip1.Location = new Point(toolStripOriginalLocation.X, toolStripOriginalLocation.Y);

                tableLayoutPanel1.ColumnStyles[0].Width = 100;
                tableLayoutPanel1.Visible = true;
            }
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FullScreen();
        }

        private void shortCutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShortCutForm frm = new ShortCutForm();
            frm.Show();
        }

        #endregion

        #region Insert menu

        private void textBeforeMoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnterMoveText.Open(true, base.Game);
        }

        private void textAfterMoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnterMoveText.Open(false, base.Game);
        }

        private void deleteAllComentaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.Game.DeleteAllComentary();
        }

        private void tsShowComments_Click(object sender, EventArgs e)
        {
            Ap.Options.ShowComments = !tsShowComments.Checked;
            tsShowComments.Checked = !tsShowComments.Checked;
            this.NotationUc.SetContextMenu(tsShowComments.Checked, true);
            Ap.Options.Save();
            this.NotationUc.Refresh(tsShowComments.Checked, tsShowMoveLogs.Checked);
        }

        private void tsShowMoveLogs_Click(object sender, EventArgs e)
        {
            Ap.Options.ShowDisconnectionLog = !tsShowMoveLogs.Checked;
            tsShowMoveLogs.Checked = !tsShowMoveLogs.Checked;
            this.NotationUc.SetContextMenu(tsShowMoveLogs.Checked, false);
            Ap.Options.Save();
            this.NotationUc.Refresh(tsShowComments.Checked, tsShowMoveLogs.Checked);
        }


        #endregion

        #region Game Menu

        private void startGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SocketClient.SetGamePositionByFen(ChessBoardUc.GetFen(), base.Game.DbGame.GameID, base.Game.GetLastMoveXml(), base.Game.DbGame.WhiteUserID, base.Game.DbGame.BlackUserID);
            EnablePositionSetup(false);
            base.Game.Flags.IsChallengerSendsGame = false;
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (base.Game.Flags.IsGameFinished)
                OfferNewGame();
        }

        private void ExaminetoolStripMenuItem5_Click(object sender, EventArgs e)
        {
            SwitchExamineMode();
        }

        #endregion

        #region Engine menu

        private void addKibitzerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoadEngine objloadengine = new LoadEngine(base.Game, this);            
            objloadengine.IsAddKibitzer = true;
            objloadengine.ShowDialog();
        }

        private void removeKibitzerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KibitzerManager.KibitzersList.Count > 0)
            {
                RemoveKibitzer();
            }
        }

        private void removeAllKibitzersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<AnalysisUc> tempKibitzer = new List<AnalysisUc>();
            foreach (var item in KibitzerManager.KibitzersList)
            {
                tempKibitzer.Add(item);
            }
            foreach (var item in tempKibitzer)
            {
                RemoveKibitzer();
            }
        }

        private void engineManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EngineManagement objEnginemanagement = new EngineManagement(base.Game);            
            objEnginemanagement.ShowDialog(this);
        }

        #endregion

        #region Tools
        
        private void pictureWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonalInformation frm = new PersonalInformation();
            frm.UserID = base.Game.DbGame.WhiteUserID;
            frm.UserName = base.Game.DbGame.WhiteUser.UserName;
            frm.ShowDialog();
        }

        private void pictureBlackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonalInformation frm = new PersonalInformation();
            frm.UserID = base.Game.DbGame.BlackUserID;
            frm.UserName = base.Game.DbGame.BlackUser.UserName;
            frm.ShowDialog();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsPopup frm = new OptionsPopup(base.Game, this);
            frm.ShowDialog(this);
        }

        #endregion

        #region Window

        private void clockWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TogglePanel(ClockUc, clockWindowToolStripMenuItem.Checked);
        }

        private void notationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TogglePanel(NotationUc, notationToolStripMenuItem.Checked);
        }

        private void analysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (base.Game.GameMode)
            {
                case GameMode.OnlineHumanVsEngine:
                case GameMode.OnlineEngineVsEngine:
                    TogglePanel(AnalysisUc, analysisToolStripMenuItem.Checked);
                    break;
                default:
                    break;
            }
        }

        private void capturePieceWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotationUc.CapturePieceUc.Visible = capturePieceWindowToolStripMenuItem.Checked;            
        }

        private void chatWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TogglePanel(ChatUc, chatWindowToolStripMenuItem.Checked);
        }

        private void audienceWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TogglePanel(AudienceUc, audienceWindowToolStripMenuItem.Checked);
        }

        private void loadDefaultPanesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadDefaultPanels();
        }

        #endregion
        
        #region Toolbar Events
        private void AddKibitztoolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void Board2d3dtoolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void ApplauseWhitetoolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void ApplauseBlacktoolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void InfoWhitetoolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void InfoBlacktoolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void ExaminetoolStripButton2_Click(object sender, EventArgs e)
        {
            SwitchExamineMode();
        }

        private void ServerReconnect_Click(object sender, EventArgs e)
        {
            Reconnect();
        }
      
        private void OnlineResign_Click(object sender, EventArgs e)
        {
            if (!base.Game.Flags.IsGameFinished)
                if (MessageForm.Confirm(this,MsgE.ConfirmResignGame) == DialogResult.Yes)
                {
                    Resign();
                }
        }

        private void OfferDrawOnline_Click(object sender, EventArgs e)
        {
            if (!base.Game.Flags.IsGameFinished)
            {
                OfferDraw();
                OfferDrawOnline.Enabled = false;
            }
        }

        private void OfferReMatch_Click(object sender, EventArgs e)
        {
            if (base.Game.Flags.IsGameFinished)
                OfferNewGame();
        }

        private void tsbStopClose_Click(object sender, EventArgs e)
        {
            closeTimer.Stop();
            CloseWindowCounter = -1;
            VisibleColsingWindowTimerButton(false);
        }
        #endregion

        #region Help

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InfinityChesshelp.InfinityChessHelp.OpenHelpFile();
        }

        private void toInfinityChesscomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ap.OpenHomeUrl();
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ap.OpenRegistrationUrl();
        }

        private void aboutFritToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutInfinityChess frm = new AboutInfinityChess();
            frm.ShowDialog();
        }

        #endregion

        #endregion

        #region Helper
        
        public override void FlipBoard()
        {
            base.FlipBoard();
        }

        private void FullScreen()
        {
            if (fullScreen == null)
            {
                fullScreen = new FullScreen(this);
            }
            if (fullScreenToolStripMenuItem.Checked == false)
            {
                // show FullScreen
                DialogResult dr = MessageBox.Show("To store normal view, press Ctrl + Alt + F", "Confirm", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    fullScreen.ShowFullScreen();
                    tableLayoutPanel1.Visible = false;
                    menuStrip1.Visible = false;
                    toolStrip1.Visible = false;
                    statusStrip1.Visible = false;
                    fullScreenToolStripMenuItem.Checked = true;
                }
            }
            else
            {
                // Hide FullScreen
                fullScreen.ShowFullScreen();
                tableLayoutPanel1.Visible = true;
                menuStrip1.Visible = true;
                toolStrip1.Visible = true;
                statusStrip1.Visible = true;
                fullScreenToolStripMenuItem.Checked = false;
            }

        }
        #endregion
    }
}
