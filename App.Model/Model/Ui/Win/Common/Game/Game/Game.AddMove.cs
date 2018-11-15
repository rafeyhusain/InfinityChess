using System;
using App.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfinityChess;
using System.IO;
using InfinitySettings.Streams;
using InfinitySettings.UCIManager;
using System.Data;
using System.Diagnostics;
using ChessLibrary;
using AppEngine;
using ChessBoardCtrl.New;
using App.Model.Fen;
using System.Windows.Forms;
using System.ComponentModel;

namespace App.Model
{
    public partial class Game
    {
        #region Add Move

        public Move AddBoardMove(string from, string to, Pieces fromPiece, string fen, Move m)
        {
            m.MoveComments.AppendMoveLog();

            Move move = AddMove(from, to, fromPiece, fen, m, false);

            DoEngineMoveIfNeeded();

            return move;
        }

        public Move AddMove(string from, string to, Pieces fromPiece, string fen, Move m, bool isSetFen)
        {
            #region On Before
            if (m == null)
            {
                return null;
            }

            if (BeforeAddMove != null)
            {
                EngineMoveEventArgs em = new EngineMoveEventArgs();
                em.BestMove = from + to;
                em.PonderMove= PonderMove;
                BeforeAddMove(this, em);
            }
            #endregion

            #region Before CurrentMove Import
            if (Flags.IsOnline && Flags.IsGameFinished) // due to time expire etc.
            {
                return null;
            }

            if (Flags.IsOnline && (Flags.IsNotMyTurn || Flags.IsGameFinished))
            {
                Clock.ToggleClock(m);
            }
            else
            {
                #region Prepare Move
                if (!m.Flags.IsPromotion) // promoted piece is already assigned in promotion dialog
                {
                    m.Piece = fromPiece;
                }

                m.Id = NextMoveId;
                m.Pid = NextMovePid;
                m.MoveNo = NextMoveNo;
                m.IsWhite = NextMoveIsWhite;
                m.From = from;
                m.To = to;
                m.Fen = fen;

                if (Flags.IsEvalRequired)
                {
                    if (!String.IsNullOrEmpty(CurrentPlayer.Engine.Points) && !String.IsNullOrEmpty(CurrentPlayer.Engine.Depth))
                    {
                        m.SetEval(CurrentPlayer.Engine.Points, CurrentPlayer.Engine.Depth);
                    }
                }

                if (Flags.IsExpectedMoveRequired)
                {
                    if (!String.IsNullOrEmpty(CurrentPlayer.Engine.ExpectedMove))
                    {
                        m.ExpectedMove = CurrentPlayer.Engine.ExpectedMove;
                    }
                }
                #endregion

                #region IsVariation
                if (AddVariationMove(m))
                {
                    PlaySounds(m);
                    return null;
                }
                else
                {
                    m.Flags.VariationType = this.VariationType;
                }
                #endregion

                #region Set Clock
                if (Flags.IsOnline)
                {
                    if (!m.IsWhite)
                    {
                        Clock.WhiteTime += DbGame.GainPerMoveMin;
                    }
                    else
                    {
                        Clock.BlackTime += DbGame.GainPerMoveMin;
                    }
                }
                else
                {
                    if (m.IsWhite)
                    {
                        Clock.BlackTime += GameTime.GainPerMove;
                    }
                    else
                    {
                        Clock.WhiteTime += GameTime.GainPerMove;
                    }
                }

                m.MoveTimeWhite = Clock.WhiteTime;
                m.MoveTimeBlack = Clock.BlackTime;

                m.MoveTime = Clock.MoveTime;

                if (this.Flags.IsFirtMove && this.Flags.IsInfiniteAnalysisOff)
                {
                    Clock.Start();
                }

                #endregion
            }

            #endregion

            Notations.AddMove(m);
            CurrentMove = m.Clone();
            Moves.Import(CurrentMove);

            #region After CurrentMove Import

            SetCurrentLine(CurrentMove);
            CheckNextLongGamePhase(CurrentMove);            
            CheckThreefoldRepetition();
            SetCastlingFlags(CurrentMove.Piece, CurrentMove.From, CurrentMove.To);

            Flags.IsPieceMovedSuccessfully = true;

            #region Point Book
            if (GameMode != GameMode.EngineVsEngine && GameMode != GameMode.OnlineEngineVsEngine)
            {
                Book.PointTo(CurrentMove);
            }
            
            #endregion

            #region Update Captured Pieces

            if (CurrentMove.Flags.IsCapture)
            {
                CapturedPieces.Update(CurrentMove);
            }
            
            #endregion

            Flags.IsMoveInProgress = false;
            Flags.IsForceEngineToMove = false;

            #region Check Game Finish
            if (!Flags.IsDatabaseGame)
            {
                #region Mated
                if (Flags.IsMated)
                {
                    Mated();
                    Flags.IsMoveInProgress = true;
                }

                #endregion

                #region StaleMated
                if (Flags.IsStaleMated)
                {
                    StaleMated();
                }

                #endregion

                #region ThreefoldRepetition
                if (Flags.IsThreeFoldRepetition)
                {
                    ThreefoldRepetition(false);
                }
                #endregion

                #region InsufficientMaterial
                if (Flags.IsInsufficientMaterial)
                {
                    InsufficientMaterial();
                }
                #endregion
            } 
            #endregion

            #region SetFen
            if (isSetFen)
            {
                SetFen(CurrentMove.Fen);
            }
            
            #endregion

            #region FifityMoves
            if (this.HalfMovesCounter >= 100)
            {
                FifityMoves();
            } 
            #endregion

            #region Set ECO, Play Sound etc.
            SearchEco();
            CheckMoveLimit();
            PlaySounds(m);
            Clock.ResetMoveTime();
            VariationType = VariationTypeE.None;

            if (Flags.IsClockStartRequired)
            {
                Clock.Start();
            }
            
            #endregion

            #region Send Move To Opponent
            if (Flags.IsUpdateGameRequired)
            {
                SocketClient.UpdateGameDataByGameID(DbGame.GameID, GetLastMoveXml(), GameResult, Flags.Flags, DbGame.OpponentUserID);
            } 
            #endregion

            #endregion

            #region On After

            if (AfterAddMove != null)
            {
                AfterAddMove(this, EventArgs.Empty);
            }            

            #endregion

            return CurrentMove;
        }

        private void CheckNextLongGamePhase(Move m)
        {
            if (Flags.IsOnline || GameType != GameType.Long || CurrentLine.Count < 1)
            {
                return;
            }

            switch (GameTime.LongGamePhase)
            {
                case 1:
                    if (CurrentLine.Count / 2 == GameTime.FirstMoves)
                    {
                        if (!StartNewPhase(2))
                        {
                            StartNewPhase(3);
                        }
                    }
                    break;
                case 2:
                    StartNewPhase(3);                    
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }

        private bool StartNewPhase(int phase)
        {
            long gameTime = 0;

            switch (phase)
            {
                case 2:
                    if (GameTime.SecondHour > 0 || GameTime.SecondMin > 0)
                    {
                        gameTime = GameTime.GetSeconds(GameTime.SecondHour, GameTime.SecondMin, GameTime.SecondGainPerMoves);
                        Clock.Reset(gameTime + Clock.WhiteTime, gameTime + Clock.BlackTime);
                        GameTime.LongGamePhase = phase;
                        GameTime.GainPerMove = GameTime.SecondGainPerMoves;
                        return true;
                    }
                    break;
                case 3:
                    if (((CurrentLine.Count / 2) - GameTime.FirstMoves) == GameTime.SecondMoves)
                    {
                        if (GameTime.ThirdHour > 0 || GameTime.ThirdMin > 0)
                        {
                            gameTime = GameTime.GetSeconds(GameTime.ThirdHour, GameTime.ThirdMin, GameTime.ThirdGainPerMoves);
                            Clock.Reset(gameTime + Clock.WhiteTime, gameTime + Clock.BlackTime);
                            GameTime.LongGamePhase = phase;
                            GameTime.GainPerMove = GameTime.ThirdGainPerMoves;
                            return true;
                        }
                    }
                    break;
                default:
                    break;
            }

            return false;
        }

        private void PlaySounds(Move m)
        {   
            if (m.Flags.IsMated)
            {
                App.Model.MediaPlayer.PlaySound(SoundFileNameE.Illegal);
            }
            else if(m.Flags.IsCapture)
            {
                App.Model.MediaPlayer.PlaySound(SoundFileNameE.Capture);
            }
            else 
            {
                App.Model.MediaPlayer.PlaySound(SoundFileNameE.Move);
            }
        }


        #region Helpers
        private bool AddVariationMove(Move m)
        {
            if (GameMode == GameMode.Kibitzer)
            {
                CurrentMove = Moves.Last;
                return false;
            }

            if (Flags.IsRetracMove)
            {
                this.VariationType = VariationTypeE.Overwrite;
                return false;
            }

            if (!Flags.IsFirtMove)
            {
                Moves children = Moves.GetChildren(CurrentMove);
        
                if (children.Count > 0)
                {
                    if (m.Flags.MoveBy == MoveByE.Human)
                    {
                        if (m.From == children[0].From && m.To == children[0].To)
                        {
                            MoveTo(children[0]);
                            return true;
                        }

                    }
                    else if (m.Flags.MoveBy == MoveByE.Book)
                    {
                        for (int i = 0; i < children.Count; i++)
                        {
                            if (m.From == children[i].From && m.To == children[i].To)
                            {
                                MoveTo(children[i]);
                                return true;
                            }
                        }
                    }

                }
            }
          
            FormClosingEventArgs e = new FormClosingEventArgs(CloseReason.None, false);

            if (Flags.IsVariation)
            {
                if (m.Flags.MoveBy != MoveByE.Human)
                {
                    this.VariationType = VariationTypeE.Variation;
                    return false;
                }

                if (AddNewVariation != null)
                {
                    AddNewVariation(this, e);
                }
            }

            if (e.Cancel)
            {
                SetFen(CurrentMove.Fen);
            }

            return e.Cancel;
        }

        private void SetCastlingFlags(Pieces piece, string from, string to)
        {
            switch (piece)
            {
                case Pieces.WKING:
                    Flags.IsWhiteCastling = false;
                    break;
                case Pieces.WROOK:
                    switch (from)
                    {
                        case "a1":
                            Flags.IsWhiteLongCastling = false;
                            break;
                        case "h1":
                            Flags.IsWhiteShortCastling = false;
                            break;
                    }
                    break;
                case Pieces.BKING:
                    Flags.IsBlackCastling = false;
                    break;
                case Pieces.BROOK:
                    switch (from)
                    {
                        case "a8":
                            Flags.IsBlackLongCastling = false;
                            break;
                        case "h8":
                            Flags.IsBlackShortCastling = false;
                            break;
                    }
                    break;
            }
        }
        #endregion

        #endregion

        #region Union
        public void Union(string moves)
        {
            if (moves == "")
            {
                return;
            }

            DataTable dt = UData.LoadDataTable(Notations.Game.Moves.DataTable.Clone(), moves);

            if (dt.Rows.Count != 1)
            {
                return;
            }

            Move m = new Move(dt.Rows[0]);
            m.Game = this;

            AddMove(m.From, m.To, m.Piece, m.Fen, m, true);

            //MoveTo(MoveToE.Last);

            DoEngineMoveIfNeeded();
        }

        #endregion

        #region Paste
        public void Paste(string moves)
        {
            Flags.IsExamineMode = true;
            DataTable dt = UData.LoadDataTable(Notations.Game.Moves.DataTable.Clone(), moves);
            Paste(dt);
            Flags.IsExamineMode = false;
        }

        public void Paste(Moves moves)
        {
            Paste(moves.DataTable);
        }

        public void Paste(DataTable moves)
        {
            if (BeforePaste != null)
            {
                BeforePaste(this, EventArgs.Empty);
            }

            Moves.DataTable.Clear();
            Notations.NotationView.Clear();

            AddMoves(moves);

            if (Flags.IsOffline)
            {
                // as now on paste, we set last move selected, 
                // so currentMove points to that last move 
                // and also clock is set by that move.
                //CurrentMove = RootMove.Clone();
                //Clock.Reset();

                Clock.Stop();
                GameResult = GameResultE.InProgress;
            }
            else
            {
                Notations.GameFinished();

                if (GameResult != GameResultE.InProgress)
                {
                    Clock.Stop();
                }
            }

            if (AfterPaste != null)
            {
                AfterPaste(this, EventArgs.Empty);
            }
        }

        private BackgroundWorker bw;
        private void InitBW()
        {
            // create new worker
            this.bw = new BackgroundWorker();
            // set that it can be cancelled
            this.bw.WorkerSupportsCancellation = true;
            // install do work event
            this.bw.DoWork += new DoWorkEventHandler(moveToWorker_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (AfterPaste != null)
            {
                AfterPaste(this, EventArgs.Empty);
            }

            if (Flags.IsOnline)
            {
                MoveTo(MoveToE.Last);
            }
        }

        void moveToWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (BeforePaste != null)
            {
                BeforePaste(this, EventArgs.Empty);
            }

            DataTable moves = e.Argument as DataTable;
            Moves.DataTable.Clear();
            Notations.NotationView.Clear();

            bool b = Flags.IsEngineOn;

            Flags.IsEngineOn = false;

            AddMoves(moves);

            Flags.IsEngineOn = b;

            if (Flags.IsOffline)
            {
                CurrentMove = RootMove.Clone();
                Clock.Reset();
                Clock.Stop();
                GameResult = GameResultE.InProgress;
            }
        }

        public void PasteBW(DataTable moves)
        {
            if (bw == null)
            {
                InitBW();
            }
            if (bw.IsBusy)
            {
                bw.CancelAsync();
            }

            if (!bw.IsBusy)
            {
                try
                {
                    bw.RunWorkerAsync(move);
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                }
            }
        }

        #endregion

        #region AddMoves
        public void AddMoves(DataTable moves)
        {
            moves.DefaultView.Sort = "Id Asc";
            moves = moves.DefaultView.ToTable(moves.TableName);

            Move m = null;

            for (int i = 0; i < moves.Rows.Count; i++)
            {
                m = new Move(moves.Rows[i]);
                m.Game = this;

                if (Flags.IsOnline && i == moves.Rows.Count - 1 && !Flags.IsGameFinished)
                {
                    AddMove(m.From, m.To, m.Piece, m.Fen, m, false);

                    MoveTo(MoveToE.Last);

                    DoEngineMoveIfNeeded();
                }
                else
                {
                    CurrentMove = m;
                    Notations.AddMove(m);
                    Moves.Import(m);
                    SetCurrentLine(m);
                }
            }

            if (Flags.IsOffline || (Flags.IsOnline && Flags.IsGameFinished))
            {
                MoveTo(MoveToE.Last);
            }
        }

        #endregion

        #region do engine move
        public void DoEngineMoveIfNeeded()
        {
            string gameMoves = Moves.GetParentsStr(CurrentMove);
            long turnCounterWhite = Clock.WhiteTime * 1000;
            long turnCounterBlack = Clock.BlackTime * 1000;

            if (Flags.IsCurrentEngineClosed)
            {
                OnSendMovesToEngine(gameMoves, turnCounterWhite, turnCounterBlack);
                return;
            }

            if (CurrentPlayer.HasEngine)
            {
                UCIEngine engine = CurrentPlayer.Engine;
                Book book = CurrentPlayer.Book;

                // send moves to book
                if (Flags.IsCurrentBookAvailable)
                {
                    book.SearchMove(BoardFen);
                }

                if (book == null || !book.IsAvailable) // now send moves to engine
                {
                    if (Flags.IsInfiniteAnalysisStopped)
                    {
                        Flags.IsInfiniteAnalysisStopped = false;
                        engine.SendOption(UCIEngine.OptionMultiPv, "1");
                        engine.IsPonderMove = false;
                        if (Flags.IsBoardSetByFen)
                        {
                            engine.SendPositionGoWithoutCheckingPonderHit(false, InitialBoardFen, gameMoves, turnCounterWhite, turnCounterBlack);
                        }
                        else
                        {
                            engine.SendPositionGoWithoutCheckingPonderHit(false, string.Empty, gameMoves, turnCounterWhite, turnCounterBlack);
                        }
                    }
                    else if (Flags.IsInfiniteAnalysisOff)
                    {
                        if (Flags.IsBoardSetByFen)
                        {
                            engine.SendPositionGo(false, InitialBoardFen, gameMoves, turnCounterWhite, turnCounterBlack);
                        }
                        else
                        {
                            engine.SendPositionGo(false, string.Empty, gameMoves, turnCounterWhite, turnCounterBlack);
                        }
                    }
                }
            }
            OnSendMovesToEngine(gameMoves, turnCounterWhite, turnCounterBlack);
        }
        #endregion

        #region CheckThreefoldRepetition 

        private void CheckThreefoldRepetition()
        {
            int c = Moves.Count - 1;

            if (c < 7)
            {
                return;
            }

            if (CurrentLine == null || string.IsNullOrEmpty(CurrentMove.Fen))
            {
                return;
            }

            int tCounter = 3; //check for "3" moves with same fen
            string fen = CurrentMove.Fen;
            fen = ChessLibrary.FenParser.GetOnlyFen(fen);

            // if move's fen is same as initial fen --- check for "2" moves with same fen
            if (fen == ChessLibrary.FenParser.GetOnlyFen(ChessLibrary.FenParser.InitialBoardFen))
            {
                tCounter = 2;
            }

            DataRow[] rows = CurrentLine.DataTable.Select(Moves.Fen + " like '" + fen + "%'");

            if (rows.Length >= tCounter)
            {
                Flags.IsThreeFoldRepetition = true;
            }
        }

        #endregion

        #region SearchEco

        private void SearchEco()
        {
            string moves = GetCurrentLineMoves();
            Ap.Eco.SearchMoves(moves);
        }

        private string GetCurrentLineMoves()
        {
            string moves = "";
            if (CurrentLine == null)
            {
                return moves;
            }

            Move m;
            
            foreach (DataRow dr in CurrentLine.DataTable.Rows)
            {
                m = new Move(dr);
                m.Game = this;
                moves += m.SingleNotation + " ";
            }

            return moves.Trim();
        }

        #endregion

        #region CheckMoveLimit

        private void CheckMoveLimit()
        {
            if (Flags.IsMoveLimitExpired)
            {
                this.Finish(GameResultE.NoResult);
            }
        }
        #endregion

        #region CurrentLine
        public void SetCurrentLine(Move m)
        {
            if (this.Flags.HasVariations)
            {
                CurrentLine = Moves.GetParents(m);
                if (CurrentLine == null)
                {
                    CurrentLine = new Moves();
                    CurrentLine.Add(m);
                }
                else
                {
                    CurrentLine.Add(m);
                }
            }
            else
            {
                CurrentLine = Moves;
            }
        } 
        #endregion

        #region SetComments
        public void SetComments(string comments, bool isTextBeforeMove)
        {
            if (this.Flags.IsFirtMove)
            {
                this.Notations.SetNotation(null, comments, isTextBeforeMove,true);
                return;
            }

            if (isTextBeforeMove)
            {
                this.CurrentMove.MoveComments[MoveCommentTypeE.Before] = comments;
                this.Moves.GetById(this.CurrentMove.Id).MoveComments[MoveCommentTypeE.Before] = comments;
            }
            else
            {
                this.CurrentMove.MoveComments[MoveCommentTypeE.After] = comments;
                this.Moves.GetById(this.CurrentMove.Id).MoveComments[MoveCommentTypeE.After] = comments;
            }

            this.Notations.SetNotation(this.CurrentMove, comments, isTextBeforeMove,true);
        } 
        #endregion

        #region Heartbeat Events
        public void Connected()
        {
            if (Flags.IsKibitzer)
            {
                return;
            }

            Resume();
        }

        public void Disconnected()
        {
            if (Flags.IsKibitzer)
            {
                return;
            }

            Pause();
        } 
        #endregion

        #region Pause/Resume
        public void Pause()
        {
            if (Flags.IsPaused)
            {
                return;
            }

            Clock.Stop();

            CurrentPlayer.PauseEngine();

            Flags.IsPaused = true;
        }

        public void Resume()
        {
            if (Flags.IsNotPaused)
            {
                return;
            }

            Flags.IsPaused = false;

            CurrentPlayer.ResumeEngine();

            Clock.Start();
        }

        #endregion
    }
}
