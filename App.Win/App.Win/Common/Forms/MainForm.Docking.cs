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
//using Crom.Controls.Docking;
using InfinityChess.Offline.Forms;
using System.Diagnostics;
using App.Model;
using App.Win;
using System.Runtime.InteropServices;
using WeifenLuo.WinFormsUI.Docking;

namespace InfinityChess.WinForms
{
    public partial class MainForm
    {
        #region SetupNewGame

        private void SetTimer()
        {
            this.Focus();
            if (this.Game.GameMode != GameMode.OnlineEngineVsEngine)
            {
                timer1.Interval = 1;
            }

            timer1.Enabled = true;
        }

        protected virtual void GameCreateDocking()
        {
        }

        protected virtual void CreatePanels()
        {

        }

        protected virtual void SetPanels()
        {

        }

        protected virtual bool LoadFromFile(string fileName)
        {
            return false;
        }

        protected virtual void LoadPanels()
        {

        }

        protected void BeforeGameCreateDocking()
        {
            dp = new DockPanel();
            dp.ActiveAutoHideContent = null;
            dp.Dock = DockStyle.Fill;
            dp.DocumentStyle = DocumentStyle.DockingSdi;
            Controls.Add(dp);
            dp.BringToFront();
        }

        protected void AfterGameCreateDocking()
        {
            GameUcList.NewGame();
            SetSelectedPanels();
            SetTimer();
        }

        #region SetSelectedPanels

        protected void SetSelectedPanels()
        {
            ChessBoard.Activate();
            NotationUc.Activate();

            switch (this.Game.GameMode)
            {
                case GameMode.OnlineHumanVsHuman:
                case GameMode.OnlineHumanVsEngine:
                case GameMode.OnlineEngineVsEngine:
                    if (ChatUc != null)
                    {
                        ChatUc.Activate();
                    }
                    break;
                case GameMode.Kibitzer:
                    break;
                default:
                    break;
            }
        }

        #endregion

        protected virtual void SaveDocking()
        {
            if (dp != null)
            {
                string fileName = Ap.FileDock(this.Game.GameMode);
                dp.SaveAsXml(fileName);
            }
        }

        #endregion

        #region Helper Methods

        protected virtual void LoadDefaultPanels()
        {
            //if (dc != null)
            //{
            //    dc.Visible = false;
            //    RemoveAllPanels();

            //    BeforeGameCreateDocking();
            //    CreatePanels();
            //    dc.LoadDefaultPanels();
            //    dc.Visible = true;

            //    SetSelectedPanels();
            //}
        }

        private void RemoveAllPanels()
        {
            //while (dc.DockedItems.Values.Count > 0)
            //{
            //    DockedItem item = dc.DockedItems.Values.FirstOrDefault();
            //    RemoveForm(item.Guid);
            //}
        }

        //protected string GetFirstChildGuid(int currentNo)
        //{
        //    string guid = string.Empty;
        //    if (dc.DockedItems.Count > 0)
        //    {
        //        IEnumerable<int> ids = (from d in dc.DockedItems.Values
        //                                where d.No > currentNo && d.No != BoardSerialNo
        //                                select d.No);
        //        if (ids.Count() > 0)
        //        {
        //            int minimumId = 0;
        //            minimumId = ids.Min();
        //            IEnumerable<string> guids = (from di in dc.DockedItems.Values
        //                                         where di.No == minimumId
        //                                         select di.Guid);
        //            if (guids.Count() > 0)
        //            {
        //                guid = guids.FirstOrDefault();
        //            }
        //        }
        //    }
        //    return guid;
        //}

        //protected string GetLastParentGuid(int currentNo)
        //{
        //    string guid = string.Empty;
        //    if (dc.DockedItems.Count > 0)
        //    {
        //        IEnumerable<int> ids = (from d in dc.DockedItems.Values
        //                                where d.No < currentNo && d.No != BoardSerialNo
        //                                select d.No);
        //        if (ids.Count() > 0)
        //        {
        //            int maximumId = 0;
        //            maximumId = ids.Max();

        //            IEnumerable<string> guids = (from di in dc.DockedItems.Values
        //                                         where di.No == maximumId
        //                                         select di.Guid);
        //            if (guids.Count() > 0)
        //            {
        //                guid = guids.FirstOrDefault();
        //            }
        //        }
        //    }
        //    return guid;
        //}

        #endregion

        #region Add/Remove Panels

        protected void TogglePanel(DockContent dContent, bool show)
        {
            if (show)
            {
                dContent.Show();
            }
            else
            {
                dContent.Hide();
            }
        }

        public void AddKibitzerPanel(AnalysisUc analysisUc)
        {
            if (dp.InvokeRequired)
            {
                dp.BeginInvoke(new MethodInvoker(delegate() { AddKibitzerPanel(analysisUc); }));
            }
            else
            {
                analysisUc.TabText = analysisUc.UCIEngine.Id;
                
                if (KibitzerManager.KibitzersList.Count == 1)
                {
                    //analysisUc.Show(ChessBoard.Pane, DockAlignment.Bottom, 0.25);
                    analysisUc.Show(dp, DockState.DockBottom);
                }
                else
                {
                    AnalysisUc parent = KibitzerManager.KibitzersList[0];
                    analysisUc.Show(parent.Pane, null);
                }
            }
        }

        protected void RemoveKibitzer()
        {
            AnalysisUc analysisUc = KibitzerManager.RemoveEngine();
            if (analysisUc != null)
            {
                analysisUc.Close();
            }
        }

        protected void RemoveAllKibitzers()
        {
            try
            {
                while (KibitzerManager.KibitzersList.Count > 0)
                {
                    RemoveKibitzer();
                }
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
            }
        }

        #endregion

        #region UserControls

        private void NotationMainUc_Load()
        {
            RefreshGameInfo();
        }

        public void LoadBook()
        {
            bookUc.LoadBook();
        }

        void DisplayECO(string discription)
        {
            gameInfoUc.EcoDiscription = discription;
        }

        internal void RefreshGameInfo()
        {
            if (gameInfoUc != null)
            {
                gameInfoUc.RefreshGameInfo();
            }

            RefreshTitle();
        }

        #endregion
    }
}
