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
using WeifenLuo.WinFormsUI.Docking;

namespace InfinityChess.WinForms
{
    public partial class MainOnline : MainForm
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
        }

        protected override void SetPanels()
        {
            ChessBoard.TabText = "Board";
            ChessBoard.HideOnClose = true;

            if (Config.IsDev)
            {
                DevUc.TabText = "DevUc";
                DevUc.HideOnClose = true;
            }

            ClockUc.TabText = "Clock";
            ClockUc.HideOnClose = true;

            NotationUc.TabText = "Notations";
            NotationUc.HideOnClose = true;

            switch (base.Game.GameMode)
            {
                case GameMode.None:
                    break;
                case GameMode.Kibitzer:
                    ScoringUc.TabText = "Scoring";
                    ScoringUc.HideOnClose = true;

                    BookUc.TabText = "Book";
                    BookUc.HideOnClose = true;
                    break;
                case GameMode.OnlineHumanVsEngine:
                case GameMode.OnlineEngineVsEngine:
                    base.AnalysisUc1.SetEngine(base.Game.DefaultEngine);
                    AnalysisUc1.TabText = base.Game.DefaultEngine.EngineTitle;
                    AnalysisUc1.HideOnClose = true;
                    break;                
            }

            ChatUc.TabText = "Chat";
            ChatUc.HideOnClose = true;
            this.ChatUc.ChatType = ChatTypeE.GameWindow;

            AudienceUc.TabText = "Audience";
            AudienceUc.HideOnClose = true;            
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
            LoadFromFile(defaultFileName);

            #endregion

            #region Load Manually
            
            ChessBoard.Show(dp, DockState.Document);

            if (Config.IsDev)
            {
                DevUc.Show(ChessBoard.Pane, null);
            }
            ClockUc.Show(dp, DockState.DockRight);
            
            NotationUc.Show(ClockUc.Pane, DockAlignment.Bottom, 0.85);

            GameInfoUc.Visible = Ap.Options.ShowGameInfo;
            CapturePieceUc.Visible = Ap.Options.ShowCapturedPieces;

            ChessBoard.TabText = "Board";
            ChessBoard.HideOnClose = true;

            if (Config.IsDev)
            {
                DevUc.TabText = "DevUc";
                DevUc.HideOnClose = true;
            }

            DockContent chatParent = NotationUc;

            switch (base.Game.GameMode)
            {
                case GameMode.None:
                    break;
                case GameMode.Kibitzer:
                    NotationUc.Show(ClockUc.Pane, DockAlignment.Bottom, 0.85);
                    ScoringUc.Show(NotationUc.Pane, null);
                    BookUc.Show(NotationUc.Pane, null);

                    chatParent = NotationUc;
                    break;
                case GameMode.OnlineHumanVsHuman:
                    NotationUc.Show(ClockUc.Pane, DockAlignment.Bottom, 0.85);
                    chatParent = NotationUc;
                    break;
                case GameMode.OnlineHumanVsEngine:
                case GameMode.OnlineEngineVsEngine:
                    NotationUc.Show(ClockUc.Pane, DockAlignment.Bottom, 0.85);
                    AnalysisUc1.Show(NotationUc.Pane, DockAlignment.Bottom, 0.60);

                    chatParent = AnalysisUc1;
                    break;
            }

            ChatUc.Show(chatParent.Pane, DockAlignment.Bottom, 0.50);
            AudienceUc.Show(ChatUc.Pane, null);

            #endregion
        }

        protected override bool LoadFromFile(string fileName)
        {
            try
            {
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
                    return AnalysisUc1;                    
                case AnalysisUc.Guid2:
                    return AnalysisUc2;
                case ChatUc.Guid:
                    return ChatUc;
                case AudienceUc.Guid:
                    return AudienceUc;
                default:
                    return null;
            }              
        }

        protected override void SaveDocking()
        {
            base.SaveDocking();
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
            capturePieceWindowToolStripMenuItem.Checked = true;
            audienceWindowToolStripMenuItem.Checked = true;
        }
        
        #endregion

        #region Controls Events

        private void InitDockingEvents()
        {
            ClockUc.VisibleChanged += new EventHandler(ClockUc_VisibleChanged);
            NotationUc.VisibleChanged += new EventHandler(NotationUc_VisibleChanged);            
            AnalysisUc1.VisibleChanged += new EventHandler(AnalysisUc1_VisibleChanged);
            ChatUc.VisibleChanged += new EventHandler(ChatUc_VisibleChanged);
            AudienceUc.VisibleChanged += new EventHandler(AudienceUc_VisibleChanged);
        }

        private void UnInitDockingEvents()
        {
            ClockUc.VisibleChanged -= new EventHandler(ClockUc_VisibleChanged);
            NotationUc.VisibleChanged -= new EventHandler(NotationUc_VisibleChanged);            
            AnalysisUc1.VisibleChanged -= new EventHandler(AnalysisUc1_VisibleChanged);
            ChatUc.VisibleChanged -= new EventHandler(ChatUc_VisibleChanged);
            AudienceUc.VisibleChanged -= new EventHandler(AudienceUc_VisibleChanged);
        }

        void ClockUc_VisibleChanged(object sender, EventArgs e)
        {
            clockWindowToolStripMenuItem.Checked = !ClockUc.IsHidden;
        }

        void NotationUc_VisibleChanged(object sender, EventArgs e)
        {
            notationToolStripMenuItem.Checked = !NotationUc.IsHidden;
        }

        void AnalysisUc1_VisibleChanged(object sender, EventArgs e)
        {
            analysisToolStripMenuItem.Checked = !AnalysisUc1.IsHidden;
        }

        void ChatUc_VisibleChanged(object sender, EventArgs e)
        {
            chatWindowToolStripMenuItem.Checked = !ChatUc.IsHidden;
        }

        void AudienceUc_VisibleChanged(object sender, EventArgs e)
        {
            audienceWindowToolStripMenuItem.Checked = !AudienceUc.IsHidden;
        }

        #endregion
    }
}
