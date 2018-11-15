using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using App.Model;
using System.IO;
using InfinitySettings.Streams;
using AppEngine;

namespace InfinitySettings.UCIManager
{
    public class EngineAnalysis
    {
        #region Deletegates/Events 
        public event EventHandler<AnalysisEventArgs> EvaluationsReceived;
        public event EventHandler ClearAnalysis;
        #endregion

        #region DataMemebers

        public Game Game;        
        public UCIEngine UciEngine;
        private GameW GameWrapper;
        public Dictionary<string, string> AnalysisItems;

        int currentMoveNumber = 0;
        
        int maxCurrentMoveNumber = 0;
        bool isWhite = false;
        int defaultAdvantageValue = -1;
        int _scoreCP = -1;
        public int ScoreCP { get { return _scoreCP; } }
        public string CurrentFen
        { 
            get 
            {
                if (this.Game.Flags.IsFirtMove)
                {
                    return Game.InitialBoardFen;
                }
                else
                {
                    return this.Game.CurrentMove.Fen;
                }
            }
        }
        private string eDepth;
        private string expectedMove;

        #endregion

        #region Ctor 

        public EngineAnalysis(Game game, UCIEngine uciEngine)
        {
            this.Game = game;
            this.UciEngine = uciEngine;
            AnalysisItems = new Dictionary<string, string>();
        }

        void Game_AfterSwapPlayers(object sender, EventArgs e)
        {
            defaultAdvantageValue = defaultAdvantageValue * (-1);
        }

        #endregion

        #region Properties

        #region Core

        public bool IsKibitzer
        {
            get { return UciEngine.IsKibitzer; }
            set { UciEngine.IsKibitzer = value; }
        }

        #endregion

        #region Calculated

        public bool IsChangeEngineAllowed
        {
            get { return this.Game.GameMode == GameMode.HumanVsEngine; }
        }

        public bool IsInfiniteAnalysisAllowed
        {
            get { return this.Game.GameMode == GameMode.HumanVsHuman; }
        }

        public bool IsEvaluationsAllowed
        {
            get
            {
                if (IsKibitzer)
                {
                    return true;
                }

                int no = 0;
                return (this.Game.NextMoveNo >= no || !this.Game.NextMoveIsWhite || this.Game.Flags.IsInfiniteAnalysisOn);
            }
        }

        public bool IsNewMove
        {
            get
            {
                return (currentMoveNumber != this.Game.CurrentMove.MoveNo || isWhite != this.Game.CurrentMove.IsWhite);
            }
        }

        public bool ClearAnalysisNotAllowed
        {
            get
            {
                return this.Game.GameMode == GameMode.EngineVsEngine
                     && this.Game.CurrentPlayer.Engine != null
                     && this.Game.CurrentPlayer.Engine.EngineName != this.UciEngine.EngineName;
            }
        }

        public bool AmIPlayer1
        {
            get
            {
                return Game.Player1.HasEngine && Game.Player1.Engine.EngineName == UciEngine.EngineName;
            }
        }

        public bool IsBookAvailable
        {
            get
            {
                if (IsKibitzer)
                {
                    return false;
                }

                if ((AmIPlayer1 && Game.Player1.IsBookAvailable) || (Game.Flags.IsDefaultBookAvailable && this.Game.GameMode== GameMode.HumanVsEngine))
                {
                    return true;
                }
                else if ((!AmIPlayer1 && Game.Player2.IsBookAvailable) || (Game.Flags.IsDefaultBookAvailable && this.Game.GameMode==GameMode.HumanVsEngine))
                {
                    return true;
                }
                return false;                
            }
        }

        public bool IsClearRequired
        {
            get
            {
                if (IsBookAvailable)
                {
                    return false;
                }
                if (this.Game.GameMode != GameMode.HumanVsEngine)
                {
                    if (this.Game.CurrentPlayer.HasEngine)
                    {
                        if (this.Game.CurrentPlayer.Engine.EngineName == this.UciEngine.EngineName)
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }

        #endregion

        #endregion

        #region Helper Methods 
     
        public void CloseEngine()
        {
            if (this.UciEngine != null)
            {
                this.UciEngine.Close();
                this.UciEngine = null;
            }            
        }

        #endregion

        #region Process Evaluations 

        private Moves LoadMoves(string pv)
        {
            Moves moves = new Moves(Moves.GetMovesTable());
            try
            {
                #region Set GameWrapper 

                if (this.UciEngine.IsPonderMoveResponse)
                {
                    GameWrapper.SetFen(CurrentFen);
                    if (GameWrapper.IsLegalMove(this.Game.PonderMove) && this.Game.Flags.IsInfiniteAnalysisOff && !this.UciEngine.IsKibitzer)
                    {
                        GameWrapper.AppendMove(this.Game.PonderMove);
                    }
                }
                else
                {
                    GameWrapper.SetFen(CurrentFen);
                }

                #endregion

                #region DataMembers 
                string[] pvMoves = pv.Split(" ".ToCharArray());
                currentMoveNumber = this.Game.NextMoveNo;
                isWhite = this.Game.NextMoveIsWhite;
                int tempMoveNumber = currentMoveNumber;
                bool isWhiteMove = isWhite;
                Move m;
                #endregion

                #region LoadMoves 
                foreach (string move in pvMoves)
                {
                    if (string.IsNullOrEmpty(move))
                        continue;
                    if (GameWrapper.IsLegalMove(move))
                    {
                        m = GetMove(move, tempMoveNumber, isWhiteMove);
                        
                        GameWrapper.AppendMove(move);

                        moves.DataTable.ImportRow(m.DataRow);

                        isWhiteMove = !isWhiteMove;

                        if (isWhiteMove)
                        {
                            tempMoveNumber++;
                        }
                    }
                }
                #endregion
            }
            catch(Exception ex)
            {
                TestDebugger.Instance.Write(ex);
            }
            return moves;
        }

        private void ProcessEvaluations(UCIInfoEventArgs e)
        {
            if (!IsEvaluationsAllowed)
            {
                return;
            }

            AnalysisEventArgs args = new AnalysisEventArgs();

            #region Set Depth,Nps etc.
            if (e.Depth > 0)
            {
                eDepth = e.Depth.ToString();
                args.Depth = eDepth;
            }

            if (e.NPS > 0)
            {
                args.Rate = (e.NPS / 1000) + " kN/s";
            }
            #endregion

            #region Evaluation Item
            if (!string.IsNullOrEmpty(e.PV))
            {
                args.Points = GetScore(e);
                args.IsLowerBound = e.IsLowerBound;
                args.IsUpperBound = e.IsUpperBound;

                Moves eMoves;
                eMoves = LoadMoves(e.PV);

                args.Pv = e.PV;

                expectedMove = this.Game.PonderMove;
                args.Move_Time = expectedMove;

                string stats = string.Empty;
                string points = GetScore(e);
                stats += points + "  Depth: " + e.Depth + "  ";
                stats += Clock.GetTimeString(e.Time / 1000) + "  ";

                if (e.NPS > 0)
                {
                    stats += (e.NPS / 1000) + " kN/s";
                }

                args.EMoves = GetMovesString(eMoves);

                if (this.UciEngine.IsKibitzer)
                    TestDebugger.Instance.Write("Analysis........:" + args.EMoves);

                args.EStatistics = stats;
            }
            #endregion

            #region ExpectedMove 
            if (e.CurrentMoveNumber > 0)
            {
                if (e.CurrentMoveNumber > maxCurrentMoveNumber)
                {
                    maxCurrentMoveNumber = e.CurrentMoveNumber;
                }

                Move m = Move.NewMove();
                m.Game = this.Game;

                if (!this.UciEngine.IsKibitzer)
                {
                    m.MoveNo = currentMoveNumber;
                }
                else
                {
                    if (this.Game.CurrentMove != null)
                    {
                        m.MoveNo = this.Game.CurrentMove.MoveNo;
                    }
                    else
                    {
                        m.MoveNo = 1;
                    }
                }
                if (this.Game.CurrentMove != null)
                {
                    m.IsWhite = this.Game.CurrentMove.IsWhite;
                }
                m.From = e.CurrentMove.Substring(0, 2);
                m.To = e.CurrentMove.Substring(2, 2);

                //GameWrapper = new GameW(CurrentFen);
                GameWrapper.SetFen(CurrentFen);

                if (!string.IsNullOrEmpty(this.Game.PonderMove) && GameWrapper.IsLegalMove(this.Game.PonderMove) && !this.UciEngine.IsKibitzer)
                {
                    GameWrapper.AppendMove(this.Game.PonderMove);
                }
                m.Piece = Board.PieceFromString(GameWrapper.GetMovingPiece(e.CurrentMove));

                string dot = ".";
                int correctNextMoveNo = this.Game.NextMoveNo;
                #region Move Formatting 
                if (this.Game.CurrentMove != null)
                {
                    if (!this.UciEngine.IsKibitzer)
                    {
                        if (this.Game.Flags.IsInfiniteAnalysisOff)
                        {
                            if (!this.Game.CurrentMove.IsWhite)
                            {
                                dot = "...";
                            }
                            else
                            {
                                correctNextMoveNo++;
                            }
                        }
                        else 
                        {
                            if (!this.Game.CurrentMove.IsWhite)
                            {
                                dot = ".";
                            }
                            else
                            {
                                dot = "...";
                            }
                        }
                    }
                    else
                    {
                        if (!this.Game.NextMoveIsWhite)
                        {
                            dot = "...";
                        }
                    }
                }
                #endregion
                string moveDisplay = m.Notation.Substring(m.Notation.IndexOf(".") + 1);

                moveDisplay = correctNextMoveNo + dot + moveDisplay + "(" + e.CurrentMoveNumber + "/" + maxCurrentMoveNumber + ")";
                args.MoveDepth = moveDisplay;
            }
            #endregion

            #region Set Player's(Engine's) Eval 
            SetEvaluation(args);            
            #endregion

            #region Fire Event 
            if (EvaluationsReceived != null)
            {
                EvaluationsReceived(this, args);
            }
            #endregion
        }

        private string GetScore(UCIInfoEventArgs e)
        {
            string eval = "";

            if (e.Mate > 0)
            {
                eval = "#" + e.Mate;
            }
            else
            {
                eval = GetPointsDisplayValue(e.ScoreCP);
            }

             return GetPositionEvaluationSymbol(e) + " (" + eval + ")";
        }

        /*------------------------------------------
            = The position is about equal
             
            +/= White is slightly better
             
            +/- White is clearly better
             
            +- White is winning
             
            -+ Black is winning
             
            -/+ Black is clearly better
             
            =/+ Black is slightly better

        ------------------------------------------*/
        private string GetPositionEvaluationSymbol(UCIInfoEventArgs e)
        {
            int cp = Math.Abs(e.ScoreCP);
            bool isWhiteWinning = false;
            if (cp <= 25)
            {
                return "=";
            }

            if (this.Game.GameMode == GameMode.EngineVsEngine || this.Game.GameMode == GameMode.OnlineEngineVsEngine)
            {
                if (((e.ScoreCP) < 0 && this.Game.Flags.AmIWhite) || ((e.ScoreCP) > 0 && this.Game.Flags.AmIBlack))
                {
                    isWhiteWinning = false;
                }
                else if (((e.ScoreCP) > 0 && this.Game.Flags.AmIWhite) || ((e.ScoreCP) < 0 && this.Game.Flags.AmIBlack))
                {
                    isWhiteWinning = true;
                }
            }
            else if (this.Game.GameMode == GameMode.HumanVsEngine || this.Game.GameMode == GameMode.OnlineHumanVsEngine)
            {
                if ((e.ScoreCP * defaultAdvantageValue) > 0)
                {
                    isWhiteWinning = true;
                }
                else
                {
                    isWhiteWinning = false;
                }
            }
            if (isWhiteWinning)
            {
                if (cp > 25 && cp <= 100)
                {
                    return "+/=";
                }
                else if (cp > 100 && cp <= 200)
                {
                    return "+/-";
                }
                else if (cp > 200)
                {
                    return "+-";
                }
            }
            else
            {
                if (cp > 25 && cp <= 100)
                {
                    return "=/+";
                }
                else if (cp > 100 && cp <= 200)
                {
                    return "-/+";
                }
                else if (cp > 200)
                {
                    return "-+";
                }
            }
            return "=";
        }

        private void SetEvaluation(AnalysisEventArgs args)
        {
            if (this.Game.CurrentMove == null)
            {
                return;
            }

            //Set Evaluation value & Depth
            SetPoints(args.Points, args.Depth);

            //Set ExpectedMove value & Depth
            if (!string.IsNullOrEmpty(this.Game.PonderMove))
            {
                string expectedMove = FormatMove(this.Game.PonderMove);
                args.ExpectedMove = expectedMove;

                int index = expectedMove.IndexOf(".");
                if (index >= 0)
                {
                    expectedMove = expectedMove.Substring(index + 1);
                }

                if (this.Game.Player1.IsEngine)
                {
                    this.Game.Player1.Engine.ExpectedMove = expectedMove;
                }

                if (this.Game.Player2.IsEngine)
                {
                    this.Game.Player2.Engine.ExpectedMove = expectedMove;
                }
            }

        }

        private void SetPoints(string points, string depth)
        {
            if (!String.IsNullOrEmpty(points) && !String.IsNullOrEmpty(depth))
            {
                if (this.Game.Player1.IsEngine)
                {
                    this.Game.Player1.Engine.Points = TrimEval(points);
                    this.Game.Player1.Engine.Depth = TrimEval(depth);
                }

                if (this.Game.Player2.IsEngine)
                {
                    this.Game.Player2.Engine.Points = TrimEval(points);
                    this.Game.Player2.Engine.Depth = TrimEval(depth);
                }
            }
        }

        private string TrimEval(string eval)
        {
            int idx = eval.IndexOf("(");

            if (idx >= 0)
            {
                eval = eval.Substring(idx + 1);
            }

            idx = eval.IndexOf(")");

            if (idx >= 0)
            {
                eval = eval.Substring(0, idx);
            }

            eval = eval.Replace("=", "");
            eval = eval.Replace("/", "");

            return eval.Trim();
        }

        private string GetMovesString(Moves moves)
        {
            StringBuilder formattedPv = new StringBuilder();
            bool isFirstMove = true;
            Move m;
            for (int i = 0; i < moves.Count; i++)
            {
                m = moves[i];
                if (this.UciEngine.IsKibitzer)
                {
                    if ((this.Game.NextMoveIsWhite && isFirstMove) || (m.IsWhite && !isFirstMove))
                    {
                            formattedPv.Append(m.MoveNo + ".");
                    }
                    else
                    {
                        if (isFirstMove)
                        {
                            formattedPv.Append(m.MoveNo + "...");
                        }
                        else
                        {
                            formattedPv.Append(" ");
                        }
                    }
                }                
                else if (this.Game.Flags.IsInfiniteAnalysisOff)
                {
                    if (m.IsWhite)
                    {
                        if (this.Game.CurrentPlayer.PlayerType == PlayerType.Human && !this.Game.Flags.IsForceEngineToMove && this.Game.Flags.IsInfiniteAnalysisOff)
                            formattedPv.Append(m.MoveNo + 1 + ".");
                        else
                        {
                            formattedPv.Append(m.MoveNo + ".");
                        }
                    }
                    else
                    {
                        if (isFirstMove)
                        {
                            formattedPv.Append(m.MoveNo + "...");
                        }
                        else
                        {
                            formattedPv.Append(" ");
                        }
                    }
                }
                else
                {
                    if ((this.Game.NextMoveIsWhite && isFirstMove) ||(m.IsWhite && !isFirstMove))
                    {
                            formattedPv.Append(m.MoveNo + ".");
                    }
                    else
                    {
                        if (isFirstMove)
                        {
                            formattedPv.Append(m.MoveNo + "...");
                        }
                        else
                        {
                                formattedPv.Append(" ");
                        }
                    }
                }
                formattedPv.Append(m.Notation.Substring(m.Notation.IndexOf(".") + 1));
                formattedPv.Append(" ");

                isFirstMove = false;
            }            
            return formattedPv.ToString();
            
        }

        public string FormatMove(string move)
        {
            if (string.IsNullOrEmpty(move))
            {
                return "";
            }

            //this.Game.GameValidator
            //this.GameWrapper = this.Game.GameValidator;
            if (!GameWrapper.IsLegalMove(move))
            {
                return "";
            }

            Move m = GetMove(move, currentMoveNumber, this.Game.CurrentMove.IsWhite);

            return m.Notation;
        }

        public string FormatMove(string bestMove,string ponderMove)
        {
            string fMove = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(bestMove) || string.IsNullOrEmpty(ponderMove))
                {
                    return fMove;
                }
                 GameWrapper.SetFen(CurrentFen);

                if (GameWrapper.IsLegalMove(bestMove))
                {
                    GameWrapper.AppendMove(bestMove);
                }

                if (!GameWrapper.IsLegalMove(ponderMove))
                {
                    return "";
                }

                Move m = GetMove(ponderMove, currentMoveNumber, this.Game.CurrentMove.IsWhite);
                fMove = m.Notation;

                if (!string.IsNullOrEmpty(fMove))
                {
                    string s = fMove;

                    if (s.Contains("."))
                    {
                        s = s.Substring(s.IndexOf(".") + 1);
                    }

                    /* In OfflineEngineVsEngine ponder move need not to be displayed as done in Fritz. */
                    if (this.Game.GameMode == GameMode.OnlineEngineVsEngine)
                    {
                        if (this.Game.Player1.IsEngine)
                        {
                            this.Game.Player1.Engine.ExpectedMove = s;
                        }

                        if (this.Game.Player2.IsEngine)
                        {
                            this.Game.Player2.Engine.ExpectedMove = s;
                        }
                    }
                }
            }
            catch
            {
            }

            return fMove;
        }
     
        private Move GetMove(string move, int moveNo, bool isWhite)
        {
            Move m = Move.NewMove();
            m.Game = this.Game;
            m.MoveNo = moveNo;
            m.IsWhite = isWhite;
            m.From = move.Substring(0, 2);
            m.To = move.Substring(2, 2);
            m.Piece = Board.PieceFromString(GameWrapper.GetMovingPiece(move));
            m.Flags.IsCapture = GameWrapper.IsCapturingMove(move);
            m.Flags.IsPromotion = GameWrapper.IsPromotionMove(move);
            m.Flags.IsLongCastling = GameWrapper.IsLongCastlingMove(move);
            m.Flags.IsShortCastling = GameWrapper.IsShortCastlingMove(move);
            m.Flags.IsInCheck = GameWrapper.IsCheckingMove(move);
            m.Flags.IsMated = GameWrapper.IsCheckMatingMove(move);
            m.Flags.IsStaleMated = GameWrapper.IsStaleMatingMove(move);
            m.Flags.IsAmbigousMove = GameWrapper.IsAmbiguousMove(move);
            m.Flags.IsAmbigousMoveColumn = GameWrapper.IsAmbiguousFile(move);
            m.Flags.IsAmbigousMoveRow = GameWrapper.IsAmbiguousRank(move);

            if (m.Flags.IsMated)
            {
                m.Flags.IsInCheck = false;
            }

            return m;
        }

        private string GetPointsDisplayValue(int scoreCP)
        {
            double doubleValue = Convert.ToDouble(scoreCP);
            doubleValue = doubleValue / 100;
            doubleValue = Math.Round(doubleValue, 2);

            if (this.Game.GameMode == GameMode.EngineVsEngine || this.Game.GameMode == GameMode.OnlineEngineVsEngine)
            {
                if (((ScoreCP) < 0 && this.Game.Flags.AmIWhite) || ((ScoreCP) > 0 && this.Game.Flags.AmIBlack))
                {
                    if (ScoreCP > 0)
                    {
                        doubleValue = doubleValue * -1;
                    }
                }
                else if (((ScoreCP) > 0 && this.Game.Flags.AmIWhite) || ((ScoreCP) < 0 && this.Game.Flags.AmIBlack))
                {
                    if (ScoreCP < 0)
                    {
                        doubleValue = doubleValue * -1;
                    }
                }
            }
            else if (this.Game.GameMode == GameMode.HumanVsEngine || this.Game.GameMode == GameMode.OnlineHumanVsEngine)
            {
                 doubleValue = doubleValue * defaultAdvantageValue;
            }
            return  doubleValue.ToString();            
        }

        #endregion

        #region Events 

        void UciEngine_InfoReceived(object sender, UCIInfoEventArgs e)
        {
            ProcessEvaluations(e);
        }

        void Book_MoveReceived(object sender, UCIMoveEventArgs e)
        {
                OnClearAnalysis();
                UCIInfoEventArgs args = new UCIInfoEventArgs("", -1, 0, 0, 0, 0, 0, e.MoveFrom + e.MoveTo, 0, 0, 0, 0, false, false, -1);
                SetPoints("0.00", "0");
                ProcessEvaluations(args);
        }

        private void OnClearAnalysis()
        {
            if (ClearAnalysis != null)
            {
                ClearAnalysis(this, EventArgs.Empty);
            }
        }

        #endregion

        #region IGameUc Members

        public void Init()
        {
            currentMoveNumber = this.Game.NextMoveNo;
            isWhite = this.Game.NextMoveIsWhite;
            GameWrapper = new GameW(ChessLibrary.FenParser.InitialBoardFen);
            this.UciEngine.InfoReceived += new UCIEngine.InfoReceivedHandler(this.UciEngine_InfoReceived);
            this.Game.AfterSwapPlayers += new EventHandler(Game_AfterSwapPlayers);

            if (IsKibitzer)
            {
                return;
            }

            switch (this.Game.GameMode)
            {
                case GameMode.HumanVsEngine:
                case GameMode.OnlineHumanVsEngine:
                case GameMode.OnlineEngineVsEngine:
                    if (Game.DefaultBook != null)
                    {
                        Game.DefaultBook.MoveReceived += new UCIEngine.MoveReceivedHandler(Book_MoveReceived);
                    }
                    break;
                case GameMode.EngineVsEngine:
                    if (AmIPlayer1)
                    {
                        if (Game.Player1.Book != null)
                        {
                            Game.Player1.Book.MoveReceived += new UCIEngine.MoveReceivedHandler(Book_MoveReceived);
                        }
                    }
                    else
                    {
                        if (Game.Player2.Book != null)
                        {
                            Game.Player2.Book.MoveReceived += new UCIEngine.MoveReceivedHandler(Book_MoveReceived);
                        }
                    }
                    break;
                case GameMode.Kibitzer:
                    break;
                default:
                    break;
            }
        }
                
        public void UnInit()
        {
            this.UciEngine.InfoReceived -= new UCIEngine.InfoReceivedHandler(this.UciEngine_InfoReceived);
            this.Game.AfterSwapPlayers -= new EventHandler(Game_AfterSwapPlayers);

            if (IsKibitzer)
            {
                return;
            }

            switch (this.Game.GameMode)
            {
                case GameMode.HumanVsEngine:
                case GameMode.OnlineHumanVsEngine:
                case GameMode.OnlineEngineVsEngine:
                    if (Game.DefaultBook != null)
                    {
                        Game.DefaultBook.MoveReceived -= new UCIEngine.MoveReceivedHandler(Book_MoveReceived);
                    }
                    break;
                case GameMode.EngineVsEngine:
                    if (AmIPlayer1)
                    {
                        if (Game.Player1.Book != null)
                        {
                            Game.Player1.Book.MoveReceived -= new UCIEngine.MoveReceivedHandler(Book_MoveReceived);
                        }
                    }
                    else
                    {
                        if (Game.Player2.Book != null)
                        {
                            Game.Player2.Book.MoveReceived -= new UCIEngine.MoveReceivedHandler(Book_MoveReceived);
                        }
                    }
                    break;
                case GameMode.Kibitzer:
                    break;
                default:
                    break;
            }
        }

        #endregion
    }

    #region AnalysisEventArgs 
    
    public class AnalysisEventArgs : EventArgs
    {
        public string MoveDepth;
        public string Points;
        public string Depth;
        public string Rate;
        public string Move_Time;
        public string EMoves;
        public string EStatistics;
        public bool IsLowerBound;
        public bool IsUpperBound;
        public string Pv;
        public string ExpectedMove;

        public AnalysisEventArgs()
        {

        }
    }

    #endregion

}
