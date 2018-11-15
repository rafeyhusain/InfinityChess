using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using ChessLibrary;
using InfinitySettings.UCIManager;
using InfinitySettings.EngineManager;
using App.Model;
//using Crom.Controls.Docking;
using InfinityChess.Offline.Forms;
using ChessBoardCtrl;
using App.Win;
using WeifenLuo.WinFormsUI.Docking;

namespace InfinityChess.WinForms
{
    public partial class MainOffline : MainForm
    {
        #region Docking Window

        protected override void GameCreateDocking()
        {
            SetPanels();

            if (IsCreateDockingRequied)
            {
                base.BeforeGameCreateDocking();
                LoadPanels();
            }

            base.AfterGameCreateDocking();
            
            ChessBoard.Activate();
            ChessBoard.Focus();

            this.Visible = true;
        }
        
        protected override void SetPanels()
        {
            ChessBoard.TabText = "Board";
            ChessBoard.HideOnClose = true;
            ChessBoard.CloseButtonVisible = false;

            if (Config.IsDev)
            {
                DevUc.TabText = "DevUc";
                DevUc.HideOnClose = true;
            }

            ClockUc.TabText = "Clock";
            ClockUc.HideOnClose = true;
            
            NotationUc.TabText = "Notations";
            NotationUc.HideOnClose = true;
            
            if (base.Game.GameMode != GameMode.EngineVsEngine)
            {
                ScoringUc.TabText = "Scoring";            
                ScoringUc.HideOnClose = true;
                
                BookUc.TabText = "Book";
                BookUc.HideOnClose = true;                
            }

            switch (base.Game.GameMode)
            {
                case GameMode.None:
                    break;
                case GameMode.HumanVsHuman:
                    break;
                case GameMode.HumanVsEngine:
                    base.AnalysisUc.SetEngine(base.Game.DefaultEngine);
                    AnalysisUc.TabText = base.Game.DefaultEngine.EngineTitle;
                    AnalysisUc.HideOnClose = true;
                    break;
                case GameMode.EngineVsEngine:
                    if (IsNonFlippedBoard)
                    {
                        base.AnalysisUc1.SetEngine(base.Game.Player2.Engine);
                        AnalysisUc1.TabText = base.Game.Player2.Engine.EngineTitle;
                        AnalysisUc1.HideOnClose = true;

                        base.AnalysisUc2.SetEngine(base.Game.Player1.Engine);
                        AnalysisUc2.TabText = base.Game.Player1.Engine.EngineTitle;
                        AnalysisUc2.HideOnClose = true;
                    }
                    else
                    {
                        base.AnalysisUc1.SetEngine(base.Game.Player1.Engine);
                        AnalysisUc1.TabText = base.Game.Player1.Engine.EngineTitle;
                        AnalysisUc1.HideOnClose = true;

                        base.AnalysisUc2.SetEngine(base.Game.Player2.Engine);
                        AnalysisUc2.TabText = base.Game.Player2.Engine.EngineTitle;
                        AnalysisUc2.HideOnClose = true;
                    }
                    break;
            }
        }

        protected override void LoadPanels()
        {
            #region Load from xml 
                        
            string fileName = Ap.FileDock(base.Game.GameMode);
            if (LoadFromFile(fileName))
            {
                return;
            }

            string defaultFileName = Ap.FileDockDefault(base.Game.GameMode);
            if (LoadFromFile(defaultFileName) && base.Game.GameMode == GameMode.EngineVsEngine)
            {
                return;
            }
            #endregion

            #region Load Manually 

            ChessBoard.Show(dp, DockState.Document);

            if (Config.IsDev)
            {
                DevUc.Show(ChessBoard.Pane, null);
            }

            ClockUc.Show(dp, DockState.DockRight);            

            GameInfoUc.Visible = Ap.Options.ShowGameInfo;
            CapturePieceUc.Visible = Ap.Options.ShowCapturedPieces;
            gameInfoToolStripMenuItem.Checked = Ap.Options.ShowGameInfo;
            capturePieceToolStripMenuItem.Checked = Ap.Options.ShowCapturedPieces;

            if (base.Game.GameMode == GameMode.EngineVsEngine)
            {
                //NotationUc.Show(ChessBoard.Pane, DockAlignment.Bottom, 0.70);
                NotationUc.Show(dp, DockState.DockBottom);
            }
            else
            {
                NotationUc.Show(ClockUc.Pane, DockAlignment.Bottom, 0.85);
                ScoringUc.Show(NotationUc.Pane, null);
                BookUc.Show(NotationUc.Pane, null);
            }

            switch (base.Game.GameMode)
            {
                case GameMode.None:
                    break;
                case GameMode.HumanVsHuman:
                    break;
                case GameMode.HumanVsEngine:
                    AnalysisUc.Show(NotationUc.Pane, DockAlignment.Bottom, 0.40);
                    break;
                case GameMode.EngineVsEngine:
                    base.AnalysisUc1.SetEngine(base.Game.Player1.Engine);
                    AnalysisUc1.Show(ClockUc.Pane, DockAlignment.Bottom, 0.40);

                    base.AnalysisUc2.SetEngine(base.Game.Player2.Engine);
                    AnalysisUc2.Show(AnalysisUc1.Pane, DockAlignment.Bottom, 0.45);
                    break;
            }

            #endregion     
        }

        protected override bool LoadFromFile(string fileName)
        {
            try
            {
//                if (System.IO.File.Exists(fileName) && !Config.IsDev) // if IsDev = true, then load panels without persistance

                if (System.IO.File.Exists(fileName) && !Config.IsDev) // if IsDev = true, then load panels without persistance
                {
                    base.BeforeGameCreateDocking();
                    DeserializeDockContent ddc = new DeserializeDockContent(GetContentFromPersistString);
                    dp.LoadFromXml(fileName, ddc);

                    return true;
                }
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                base.BeforeGameCreateDocking();
            }

            return false;
        }

        protected IDockContent GetContentFromPersistString(string persistString)
        {
            switch (persistString)
            {

                case ChessBoard.Guid:
                    return ChessBoard;
                case DevUc.Guid:
                    return DevUc;
                case ClockUc.Guid:
                    return ClockUc;
                case NotationUc.Guid:
                    return NotationUc;
                case ScoringUc.Guid:
                    return ScoringUc;
                case BookUc.Guid:
                    return BookUc;                
                case AnalysisUc.Guid1:                    
                    switch (base.Game.GameMode)
                    {
                        case GameMode.HumanVsEngine:
                            return AnalysisUc;
                        case GameMode.EngineVsEngine:
                            return AnalysisUc1;
                        default:
                            return AnalysisUc;
                            
                    }
                case AnalysisUc.Guid2:
                    return AnalysisUc2;
                default:
                    return null;
            }
        }

        protected void LoadDefaultDocking()
        {
            base.BeforeGameCreateDocking();

            dp.Visible = false;
            dp.SuspendLayout();

            LoadPanels();
            base.SetSelectedPanels();
            
            ChessBoard.Activate();

            dp.ResumeLayout(true);
            dp.Visible = true;
        }

        protected override void LoadDefaultPanels()
        {
            RemoveAllKibitzers();            
            System.IO.File.Delete(Ap.FileDock(base.Game.GameMode));
            LoadDefaultDocking();

            clockWindowToolStripMenuItem.Checked = true;
            notationToolStripMenuItem.Checked = true;
            analysisToolStripMenuItem.Checked = true;
            capturePieceToolStripMenuItem.Checked = true;
        }

        protected override void SaveDocking()
        {
            base.SaveDocking();
        }

        #endregion

        #region Controls Events

        private void InitDockingEvents()
        {
            ClockUc.VisibleChanged += new EventHandler(ClockUc_VisibleChanged);
            NotationUc.VisibleChanged += new EventHandler(NotationUc_VisibleChanged);
            ScoringUc.VisibleChanged += new EventHandler(ScoringUc_VisibleChanged);
            BookUc.VisibleChanged += new EventHandler(BookUc_VisibleChanged);
            AnalysisUc.VisibleChanged += new EventHandler(AnalysisUc_VisibleChanged);
        }

        private void UnInitDockingEvents()
        {
            ClockUc.VisibleChanged -= new EventHandler(ClockUc_VisibleChanged);
            NotationUc.VisibleChanged -= new EventHandler(NotationUc_VisibleChanged);
            ScoringUc.VisibleChanged -= new EventHandler(ScoringUc_VisibleChanged);
            BookUc.VisibleChanged -= new EventHandler(BookUc_VisibleChanged);
            AnalysisUc.VisibleChanged -= new EventHandler(AnalysisUc_VisibleChanged);
        }

        void ClockUc_VisibleChanged(object sender, EventArgs e)
        {
            clockWindowToolStripMenuItem.Checked = !ClockUc.IsHidden;
        }

        void NotationUc_VisibleChanged(object sender, EventArgs e)
        {
            notationToolStripMenuItem.Checked = !NotationUc.IsHidden;
            gameInfoToolStripMenuItem.Visible = notationToolStripMenuItem.Checked;
            capturePieceToolStripMenuItem.Visible = notationToolStripMenuItem.Checked;
        }

        void ScoringUc_VisibleChanged(object sender, EventArgs e)
        {
            scoringToolStripMenuItem.Checked = !ScoringUc.IsHidden;
        }

        void BookUc_VisibleChanged(object sender, EventArgs e)
        {
            bookToolStripMenuItem.Checked = !BookUc.IsHidden;
        }

        void AnalysisUc_VisibleChanged(object sender, EventArgs e)
        {
            analysisToolStripMenuItem.Checked = !AnalysisUc.IsHidden;
        }

        #endregion
    }
}
