using System; using App.Model;
using System.Collections.Generic;

using System.Text;
using System.Xml;
using System.IO;
using InfinityChess;
using System.ComponentModel;
using System.Diagnostics;

namespace InfinitySettings.EngineManager
{
    public class KibitzerManager
    {
        #region DataMembers 

        public Game Game = null;
        BackgroundWorker bw;

        private List<AnalysisUc> kibitzersList;
        public List<AnalysisUc> KibitzersList
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return kibitzersList; }
            set { kibitzersList = value; }
        }

        #endregion

        #region Ctor 

        public KibitzerManager(Game game)
        {
            this.Game = game;
            kibitzersList = new List<AnalysisUc>();
            InitBW();
        }

        #endregion

        #region Instance
        //private static KibitzerManager instance = null;
        //public static KibitzerManager Instance
        //{
        //    [DebuggerStepThrough]
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new KibitzerManager();
        //        }
        //        return instance;
        //    }
        //    [DebuggerStepThrough]
        //    set { instance = value; }
        //}
        #endregion

        #region Helper Methods 

        private void InitBW()
        {
            // create new worker
            bw = new BackgroundWorker();
            // set that it can be cancelled
            bw.WorkerSupportsCancellation = true;
            // install do work event
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            UciEngineArgs args = e.Argument as UciEngineArgs;
            if (args != null)
            {
                StartSendMoveToKibitzer(args);
            }
        }

        public void SendMoveToKibitzer(Move m)
        {
            if (kibitzersList == null)
            {
                return;
            }

            string gameMoves = this.Game.Moves.GetParentsStr(m);
            SendMoveToKibitzer(gameMoves, m.MoveTimeWhite * 1000, m.MoveTimeBlack * 1000);
        }

        public void SendMoveToKibitzer(string moves, long whiteTurnSeconds, long blackTurnSeconds)
        {
            if (kibitzersList == null)
            {
                return;
            }

            //SendMoveToKibitzerBW(moves, whiteTurnSeconds, blackTurnSeconds);

            foreach (AnalysisUc kibitzer in kibitzersList)
            {
                if (this.Game.Flags.IsBoardSetByFen)
                {
                    kibitzer.UCIEngine.SendPositionGo(false, this.Game.InitialBoardFen, moves, whiteTurnSeconds, blackTurnSeconds);
                }
                else
                {
                    kibitzer.UCIEngine.SendPositionGo(false, string.Empty, moves, whiteTurnSeconds, blackTurnSeconds);
                }
            }
        }

        public void SendMoveToKibitzerBW(string moves,long whiteTurnSeconds, long blackTurnSeconds)
        {
            if (bw.IsBusy)
            {
                bw.CancelAsync();
            }

            if (!bw.IsBusy)
            {
                //try
                {
                    UciEngineArgs args = new UciEngineArgs(moves, whiteTurnSeconds, blackTurnSeconds);
                    bw.RunWorkerAsync(args);
                }
                //catch (Exception ex)
                //{
                //    string s = ex.Message;
                //}
            }
        }

        public void StartSendMoveToKibitzer(UciEngineArgs args)
        {
            if (kibitzersList == null)
            {
                return;
            }
            foreach (AnalysisUc kibitzer in kibitzersList)
            {
                if (this.Game.Flags.IsBoardSetByFen)
                {
                    kibitzer.UCIEngine.SendPositionGo(false, this.Game.InitialBoardFen, args.Moves, args.WhiteTime, args.BlackTime);
                }
                else
                {
                    kibitzer.UCIEngine.SendPositionGo(false, string.Empty, args.Moves, args.WhiteTime, args.BlackTime);
                }
            }
        }

        public AnalysisUc RemoveEngine()
        {
            AnalysisUc tempKibitzer = null;
            if (kibitzersList != null)
            {
                foreach (AnalysisUc kibitzer in kibitzersList)
                {
                    tempKibitzer = kibitzer;
                }

                if (tempKibitzer != null)
                {
                    RemoveItem(tempKibitzer);
                }
            }
            return tempKibitzer;
        }

        public AnalysisUc RemoveEngine(string guid)
        {
            AnalysisUc tempKibitzer = null;
            if (kibitzersList != null)
            {
                foreach (AnalysisUc kibitzer in kibitzersList)
                {
                    if (kibitzer.KibitzerGuid == guid)
                    {
                        tempKibitzer = kibitzer;
                        break;
                    }
                }

                if (tempKibitzer != null)
                {
                    RemoveItem(tempKibitzer);
                }
            }
            return tempKibitzer;
        }

        public bool RemoveEngineByName(string engineName)
        {
            if (kibitzersList != null)
            {
                AnalysisUc tempKibitzer = null;
                foreach (AnalysisUc kibitzer in kibitzersList)
                {
                    if (kibitzer.UCIEngine.EngineName == engineName)
                    {
                        tempKibitzer = kibitzer;
                    }
                }

                if (tempKibitzer != null)
                {
                    RemoveItem(tempKibitzer);
                }
            }
            return true;
        }

        private void RemoveItem(AnalysisUc kibitzer)
        {
            kibitzer.UCIEngine.Close();
            kibitzersList.Remove(kibitzer);
        }

        #endregion

    }

    public class UciEngineArgs
    {
        public string Moves = "";
        public long WhiteTime = 100;
        public long BlackTime = 100;        

        public UciEngineArgs(string moves,long whiteTime,long blackTime)
        {
            this.Moves = moves;
            this.WhiteTime = whiteTime;
            this.BlackTime = blackTime;
        }
    }
}
