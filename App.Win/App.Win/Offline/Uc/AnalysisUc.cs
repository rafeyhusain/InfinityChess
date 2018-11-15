using System;
using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using InfinitySettings.EngineManager;
using InfinitySettings.UCIManager;
using System.Linq;
using App.Win;
using WeifenLuo.WinFormsUI.Docking;
using InfinityChess.WinForms;
using System.Diagnostics;

namespace InfinityChess
{
    public partial class AnalysisUc : DockContent, IGameUc
    {
        #region DataMemebers
        
        public Game Game = null;
        public MainForm MainForm = null;

        public const string Guid1 = "ecddcc05-b371-4b88-b760-c87f4dcf701e";
        public const string Guid2 = "24b28757-aba5-4ef1-9a70-3a4d8862a984";
        public string kibitzerGuid = string.Empty;       

        EngineAnalysis EngineAnalysis;

        string _emptyString = "               ";
        
        System.Windows.Forms.Timer analysisTimer;

        const string GO = "Go";
        const string Stop = "Stop";

        private string eDepth;
        private string expectedMove;
        bool isWhite = true;
        
        #endregion

        #region Delegates/Events 
        public event EventHandler StartAnalysis;
        public event EventHandler StopAnalysis;
        #endregion

        #region Properties

        public string KibitzerGuid
        {
            get { return kibitzerGuid; }
            set { kibitzerGuid = value; }
        }

        public UCIEngine UCIEngine
        {
            get
            {
                if (EngineAnalysis == null)
                {
                    return null;
                }

                return EngineAnalysis.UciEngine;
            }
        }

        public string EngineTitle
        {
            get { return lblEngine.Text; }
            set { lblEngine.Text = value; }
        }

        private bool HasEngine
        {
            get 
            {
                return EngineAnalysis != null && EngineAnalysis.UciEngine != null;
            }
        }

        private bool IsKibitzer
        {
            get
            {
                return EngineAnalysis != null && EngineAnalysis.IsKibitzer;
            }
        }

        #region Bitmaps 

        static Bitmap bitmapRed;
        public static Bitmap BitmapRed
        {
            [DebuggerStepThrough]
            get
            {
                if (bitmapRed == null)
                {
                    bitmapRed = global::InfinityChess.Properties.Resources.Red;
                }
                return bitmapRed;
            }
        }

        static Bitmap bitmapGreen;
        public static Bitmap BitmapGreen
        {
            [DebuggerStepThrough]
            get
            {
                if (bitmapGreen == null)
                {
                    bitmapGreen = global::InfinityChess.Properties.Resources.Green;
                }
                return bitmapGreen;
            }
        }

        static Bitmap bitmapOrange;
        public static Bitmap BitmapOrange
        {
            [DebuggerStepThrough]
            get
            {
                if (bitmapOrange == null)
                {
                    bitmapOrange = global::InfinityChess.Properties.Resources.orange;
                }
                return bitmapOrange;
            }
        }
        #endregion

        #endregion

        #region Ctor

        public AnalysisUc(bool isWhite, Game game, MainForm mainForm)
        {
            InitializeComponent();
            this.Game = game;
            this.MainForm = mainForm;
            this.isWhite = isWhite;
            InitGoButtonTimer();            
            this.FormClosing += new FormClosingEventHandler(AnalysisUc_FormClosing);
        }
                
        #endregion

        #region Uc Events 

        private void AnalysisUc_Load(object sender, EventArgs e)
        {

        }

        void AnalysisUc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (HasEngine)
            {
                EngineAnalysis.UciEngine.Close();
            }
        }

        #endregion

        #region Intialize/Load Method
        public void SetEngine(UCIEngine uciEngine)
        {
            if (EngineAnalysis != null)
            {
                EngineAnalysis.UnInit();
            }
            EngineAnalysis = new EngineAnalysis(this.Game, uciEngine);
        }

        private void InitAnalysisTimer()
        {
            if (analysisTimer != null)
            {
                analysisTimer.Stop();
                analysisTimer = null;
            }
            analysisTimer = new Timer();
            analysisTimer.Interval = 1000;
            analysisTimer.Tick += new EventHandler(analysisTimer_Tick);
            analysisTimer.Start();
        }

        private void InitEngine()
        {
            if (EngineAnalysis == null)
            {
                return;
            }

            string title = EngineAnalysis.UciEngine.Id;
            if (string.IsNullOrEmpty(title))
            {
                title = EngineAnalysis.UciEngine.EngineName;
            }
            lblEngine.Text = title;
            UnInit();
            Init();
        }

        public void ChangeEngine(UCIEngine uciEngine)
        {
            if (EngineAnalysis == null)
            {
                return;
            }

            this.EngineAnalysis.UciEngine = uciEngine;
            InitEngine();
        }

        private void ClearLabels()
        {
            try
            {
                lblPoints.Text = _emptyString;
                lblDepth.Text = _emptyString;
                lblRate.Text = _emptyString;
                lblExpectedMove.Text = _emptyString;
                lblMoveDepth.Text = _emptyString;
                eDepth = string.Empty;
                expectedMove = string.Empty;
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
            }            
        }

        #endregion

        #region Helper Methods

        public void CloseEngine()
        {
            if (EngineAnalysis == null)
            {
                return;
            }

            this.EngineAnalysis.CloseEngine();

            lblEngine.Text = _emptyString;
            lvNotations.Items.Clear();
            ClearLabels();
        }

        public void SwitchOnEngine()
        {
            if (EngineAnalysis == null)
            {
                return;
            }

            lblEngine.Text = this.EngineAnalysis.UciEngine.EngineName;
        }

        public void SwitchOffEngine()
        {
            lblEngine.Text = "Stopped";
            lvNotations.Items.Clear();
            ClearLabels();
            btnGo.Text = GO;

            if (EngineAnalysis == null)
            {
                return;
            }
            this.EngineAnalysis.UciEngine.SwitchOff();
        }

        private void OnStopAnalysis()
        {
            toolTipController.SetToolTip(btnGo, "Start Infinite Analysis");
            if (this.StopAnalysis != null)
            {
                lblEngine.Text = "Stopped";
                btnGo.Text = GO;
                this.StopAnalysis(this, new AnalysisUCEventArgs());
            }
        }

        private void OnStartAnalysis()
        {
            toolTipController.SetToolTip(btnGo, "Stop Infinite Analysis");
            if (this.StartAnalysis != null)
            {
                lblEngine.Text = this.UCIEngine.EngineName;
                btnGo.Text = Stop;
                this.StartAnalysis(this, new AnalysisUCEventArgs());
            }

        }

        public void ClearAnalysisItems()
        {
            if (IsKibitzer)
            {
                ClearLabels();
            }
            
            UpdateEvaluations(lvNotations, null, true);
            
            if (EngineAnalysis != null)
            {
                EngineAnalysis.AnalysisItems.Clear();
            }
        }

        private void SetExpectedMove(EngineMoveEventArgs e)
        {
            if (this.Game.Flags.IsOnline && EngineAnalysis!= null)
            {
                lblExpectedMove.Text = EngineAnalysis.FormatMove(e.BestMove, e.PonderMove);
            }
        }

        #endregion
        
        #region Events 

        #region GameEvents 
                
        void Game_StartAnalysis(object sender, EventArgs e)
        {
            SwitchOnEngine();
            btnGo.Text = Stop;
            ClearAnalysisItems();            
        }

        void Game_StopAnalysis(object sender, EventArgs e)
        {
            btnGo.Text = GO;
        }

        void Game_AfterAddMove(object sender, EventArgs e)
        {
            if (this.EngineAnalysis.ClearAnalysisNotAllowed)
            {
                return;
            }
        }

        void Game_BeforeAddMove(object sender, EngineMoveEventArgs e)
        {
            if (EngineAnalysis.IsClearRequired)
            {
                ClearAnalysisItems();
            }
            SetExpectedMove(e);
        }

        void Game_ForceEngineToMove(object sender, EventArgs e)
        {


        }

        #endregion

        #region GoButtonTimerEvent

        System.Windows.Forms.Timer tmrGoButtonTimer;

        protected void InitGoButtonTimer()
        {
            tmrGoButtonTimer = new System.Windows.Forms.Timer();
            tmrGoButtonTimer.Interval =800;
            tmrGoButtonTimer.Tick += new EventHandler(tmrGoButtonTimer_Tick);
            tmrGoButtonTimer.Start();
        }

        void tmrGoButtonTimer_Tick(object sender, EventArgs e)
        {
            btnGo.Enabled = true;
        }

        protected override bool ProcessKeyPreview(ref System.Windows.Forms.Message m)
        {
            if (this.Game.GameMode != GameMode.HumanVsEngine && this.Game.GameMode != GameMode.HumanVsHuman)
            {
                return false;
            }

            switch ((Keys)m.WParam.ToInt32())
            {
                case Keys.Space:

                    if (m.Msg == 256)
                    {
                        this.Game.SpaceBarCounter++;
                    }
                    else
                    {
                        this.Game.SpaceBarCounter = 1;
                    }
                    break;
            }

            return false;
        }

        #endregion

        #region ControlsEvents 

        private void lblRate_Click(object sender, EventArgs e)
        {

        }

        private void lblEngine_Click(object sender, EventArgs e)
        {
            if (IsKibitzer)
            {
                return;
            }

            if (this.EngineAnalysis.Game.GameMode != GameMode.EngineVsEngine)
            {
                LoadEngine objLoadEngine = new LoadEngine(this.Game, this.MainForm);                
                if (objLoadEngine.ShowDialog() == DialogResult.OK)
                {
                    this.MainForm.ChangeMainEngine(objLoadEngine.SelectedEngine);
                }
            }
        }
       
        private void btnGo_Click(object sender, EventArgs e)
        {
                if (this.Game.Flags.IsOnline)
                {
                    return;
                }
                btnGo.Enabled = false;
                lblPoints.Focus();
                if (EngineAnalysis == null)
                {
                    return;
                }

                if (!this.EngineAnalysis.IsInfiniteAnalysisAllowed && this.Game.Flags.IsInfiniteAnalysisOff)
                {
                   this.MainForm.ForceEngineToPlay();
                    return;
                }

                if (this.EngineAnalysis.UciEngine != null)
                {
                     switch (btnGo.Text)
                    {
                        case GO:
                            OnStartAnalysis();
                            this.Game.Flags.IsInfiniteAnalysisGoButtonPressed = true; 
                             break;
                        case Stop:
                            OnStopAnalysis();
                            this.Game.Flags.IsInfiniteAnalysisGoButtonPressed = false;
                            break;
                    }
             }
               
        }

        private void lvNotations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvNotations.SelectedItems != null && lvNotations.SelectedItems.Count > 0)
                lvNotations.SelectedItems[0].Selected = false;
        }

        void analysisTimer_Tick(object sender, EventArgs e)
        {
            if (EngineAnalysis == null)
            {
                return;
            }


            if (this.Game.Flags.IsFirtMove && this.Game.Flags.IsInfiniteAnalysisOff)
            {
                return;
            }

            if (this.Game.Flags.IsInfiniteAnalysisOn)
            {
                lblExpectedMove.Text = this.Game.Clock.MoveTimeString;
            }
            else
            {
                if (this.Game.CurrentPlayer.IsEngine)
                {
                    lblExpectedMove.Text = this.Game.Clock.MoveTimeString;
                }
            }
        }

        #endregion

        #endregion

        #region IGameUc Members

        public void NewGame()
        {
            lvNotations.Items.Clear();
            ClearLabels();
            InitEngine();
            InitAnalysisTimer();
        }

        public void Init()
        {
            if (EngineAnalysis != null)
            {
                EngineAnalysis.EvaluationsReceived += new EventHandler<AnalysisEventArgs>(EngineAnalysis_EvaluationsReceived);
                EngineAnalysis.ClearAnalysis += new EventHandler(EngineAnalysis_ClearAnalysis);
                this.Game.AfterAddMove += new EventHandler(Game_AfterAddMove);
                this.Game.BeforeAddMove+=new EventHandler<EngineMoveEventArgs>(Game_BeforeAddMove);
                
                this.Game.AfterNewGame += new EventHandler(Game_AfterNewGame);
                this.UCIEngine.ClearAnalysis += new EventHandler(EngineAnalysis_ClearAnalysis);
                EngineAnalysis.Init();

            }
            this.Game.StartAnalysis += new EventHandler(Game_StartAnalysis);
            this.Game.StopAnalysis += new EventHandler(Game_StopAnalysis);
            btnGo.Text = "Go";
        }

       

        public void UnInit()
        {
            if (EngineAnalysis != null)
            {
                EngineAnalysis.EvaluationsReceived -= new EventHandler<AnalysisEventArgs>(EngineAnalysis_EvaluationsReceived);
                EngineAnalysis.ClearAnalysis -= new EventHandler(EngineAnalysis_ClearAnalysis);
                this.UCIEngine.ClearAnalysis -= new EventHandler(EngineAnalysis_ClearAnalysis);
                this.Game.BeforeAddMove -= new EventHandler<EngineMoveEventArgs>(Game_BeforeAddMove);
                this.Game.AfterAddMove -= new EventHandler(Game_AfterAddMove);
                this.Game.AfterNewGame -= new EventHandler(Game_AfterNewGame);
                this.UCIEngine.ClearAnalysis -= new EventHandler(EngineAnalysis_ClearAnalysis);
                EngineAnalysis.UnInit();
             }
            this.Game.StartAnalysis -= new EventHandler(Game_StartAnalysis);
            this.Game.StopAnalysis -= new EventHandler(Game_StopAnalysis);
        }

        #endregion
        
        #region AnalysisUCEventArgs
        public class AnalysisUCEventArgs : EventArgs
        {
            public AnalysisUCEventArgs()
            {
            }
        }
        #endregion

        #region Overrrides

        protected override string GetPersistString()
        {
            if (!string.IsNullOrEmpty(KibitzerGuid))
            {
                return KibitzerGuid;
            }

            if (isWhite)
            {
                return Guid1;
            }
            else
            {
                return Guid2;
            }
        }

        #endregion
    }
}
