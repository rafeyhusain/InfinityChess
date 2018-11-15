using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.ComponentModel;
using App.Model;
using System.Timers;
using InfinitySettings.Streams;

namespace App.Model
{
    public partial class UCIEngine
    {
        #region Process Output

        private void ProcessUCIData(string uciData)
        {
            if (uciData == null)
            {
                return;
            }

            if (uciData.StartsWith("bestmove"))
            {
                //if (this.Game.Flags.IsProcessOutputInInfiniteAnalysis)
                //{
                //    this.Game.Flags.IsProcessOutputInInfiniteAnalysis = false;
                //}
                ProcessBestMove(uciData);
            }
            //else if (this.Game.Flags.IsProcessOutputInInfiniteAnalysis)
            //{
            //    return;
            //}
            else if (uciData.StartsWith("uciok"))
            {
                ProcessUciOk();
            }
            else if (uciData.StartsWith("Illegal move\n"))
            {
                if (IllegalMove != null)
                {
                    UCIIllegalMoveEventArgs e = new UCIIllegalMoveEventArgs(uciData, uciData);
                    IllegalMove(this, e);
                }
            }
            else if (uciData.StartsWith("Error\n"))
            {
                if (Error != null)
                {
                    UCIErrorEventArgs e = new UCIErrorEventArgs(uciData);
                    Error(this, e);
                }
            }
            else if (uciData.StartsWith("id name"))
            {
                string uciName = uciData.Substring("id name".Length);
                this.id = uciName;
                if (NameReceived != null)
                {
                    UCIMessageEventArgs e = new UCIMessageEventArgs(uciName);
                    NameReceived(this, e);
                }
            }
            else if (uciData.StartsWith("id author"))
            {
                string uciAuthor = uciData.Substring("id author".Length);
                this.author = uciAuthor;
                if (AuthorReceived != null)
                {
                    UCIMessageEventArgs e = new UCIMessageEventArgs(uciAuthor);
                    AuthorReceived(this, e);
                }
            }
            else if (uciData.StartsWith("option name"))
            {
                ProcessOptionName(uciData);
            }
            else if (uciData.StartsWith("readyok") && !IsKibitzer)
            {
                if (!IsHashCleared)
                {
                    SendOption(OptionClear + " " + OptionHash);
                }
            }
            else if (uciData.StartsWith("info "))
            {
                ProcessInfo(uciData);
            }
        }

        private void ProcessOptionName(string uciData)
        {
            if (uciData.Contains(OptionNalimovPath))
            {
                IsNalimovPathSupported = true;
            }

            if (OptionReceived != null)
            {
                UCIMessageEventArgs e = new UCIMessageEventArgs(uciData);
                OptionReceived(this, e);
            }
            if (IsLoadParametersRequired)
            {
                Parameters.AddParameter(uciData);
            }
        }

        private void ProcessInfo(string uciData)
        {
            if (positionCommand == "position fen rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 0 moves \n")
                return;
            ProcessUCIInfo(uciData);
        }

        private void ProcessUciOk()
        {
            if (UciOkReceived != null)
            {
                UciOkReceived(this, EventArgs.Empty);
            }
            if (IsLoadParametersRequired)
            {
                Parameters.OnParametersLoaded();
            }

            SendOption(OptionHash, Ap.EngineOptions.HashTableSize);
            if (!IsKibitzer)
            {
                SendOption(OptionPonder, "false");

                if (HasParametersLoaded)
                {
                    Parameters.SetEngineParameters(this);
                }

                SendOption(OptionNalimovCache, "1");
            }            

            SendIsReady();
        }

        private void ProcessBestMove(string uciData)
        {
            if (!HasGame || IsPaused)
            {
                return;
            }

            TestDebugger.Instance.Write("UI2E >>  " + EngineName + " : Best Moves : " + uciData);
            if (!uciData.Contains("bestmove ponder") && !uciData.Contains("bestmove  ponder"))
            {
                bestMoves = uciData.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string ParentMoves = this.Game.Moves.GetParentsStr(this.Game.CurrentMove);

                if (bestMoves.Length >= 2)
                {
                    IsMoveInProgress = false;
                    string moveFrom = bestMoves[1].Substring(0, 2);
                    string moveTo = bestMoves[1].Substring(2, 2);
                    this.Game.BestMove = bestMoves[1];
                    if (IsBestMoveWithPonder)
                    {
                        this.Game.PonderMove = bestMoves[3];
                    }
                    else
                    {
                        this.Game.PonderMove = subPonderMove;
                    }
                    if (isPonderMiss)
                    {
                        isPonderMiss = false;
                        IsPonderMoveResponse = false;
                        OnClearAnalysis();
                        if (this.Game.Flags.IsBoardSetByFen)
                        {
                            SendPositionGoWithoutCheckingPonderHit(false, this.Game.InitialBoardFen, ParentMoves, this.Game.Clock.WhiteTime * 1000, this.Game.Clock.BlackTime * 1000);
                        }
                        else
                        {
                            SendPositionGoWithoutCheckingPonderHit(false, string.Empty, ParentMoves, this.Game.Clock.WhiteTime * 1000, this.Game.Clock.BlackTime * 1000);
                        }
                        SendStop();
                        return;
                    }
                    if (this.Game.Flags.IsInfiniteAnalysisStopped)
                    {
                        return;
                    }

                    if (((!IsPonderMove || this.Game.Flags.IsInfiniteAnalysisStopped) && this.Game.Flags.IsInfiniteAnalysisOff) || (this.Game.Flags.IsInfiniteAnalysisOn && this.Game.Flags.IsForceEngineToMoveInInfiniteAnalysis))
                    {
                        isSendStop = false;

                        if (this.Game.Flags.IsInfiniteAnalysisStopped)
                        {
                            this.Game.Flags.IsInfiniteAnalysisStopped = false;
                        }

                        if (this.Game.Flags.IsFirtMove && this.Game.Flags.IsForceEngineToMove && !this.Game.Flags.IsInfiniteAnalysisOn)
                        {
                            IsPonderMove = !IsPonderMove;
                        }

                        if (this.Game.CurrentPlayer.Book == null || !this.Game.CurrentPlayer.Book.IsAvailable)
                        {
                            if (MoveReceived != null)
                            {
                                UCIMoveEventArgs e = new UCIMoveEventArgs(moveFrom, moveTo);
                                MoveReceived(this, e);
                            }
                        }
                    }

                    if (!ProcessPonder)
                    {
                        return;
                    }
                    
                    IsPonderMove = !IsPonderMove;

                    if ((IsPonderMove && this.Game.Flags.IsInfiniteAnalysisOff) || (this.Game.Flags.IsInfiniteAnalysisOn && this.Game.Flags.IsForceEngineToMoveInInfiniteAnalysis))
                    {
                        if (bestMoves.Length == 4)
                        {
                            this.Game.PreviousPonderMove = bestMoves[3];
                        }
                        else
                        {
                            this.Game.PreviousPonderMove = subPonderMove;
                        }    
                        
                        if (IsKibitzer)
                        {
                            return;
                        }

                        if (this.Game.Flags.IsInfiniteAnalysisOff)
                        {
                            if (!string.IsNullOrEmpty(this.Game.PonderMove))
                            {
                                if (ParentMoves.EndsWith(this.Game.BestMove))
                                {
                                    if (this.Game.Flags.IsBoardSetByFen)
                                    {
                                        SendPositionGo(true, this.Game.InitialBoardFen, ParentMoves + " " + this.Game.PonderMove, this.Game.Clock.WhiteTime * 1000, this.Game.Clock.BlackTime * 1000);
                                    }
                                    else
                                    {
                                        SendPositionGo(true, string.Empty, ParentMoves + " " + this.Game.PonderMove, this.Game.Clock.WhiteTime * 1000, this.Game.Clock.BlackTime * 1000);
                                    }
                                }
                                else
                                {
                                    if (this.Game.Flags.IsBoardSetByFen)
                                    {
                                        SendPositionGo(true, this.Game.InitialBoardFen, ParentMoves + " " + this.Game.BestMove + " " + this.Game.PonderMove, this.Game.Clock.WhiteTime * 1000, this.Game.Clock.BlackTime * 1000);
                                    }
                                    else
                                    {
                                        SendPositionGo(true, string.Empty, ParentMoves + " " + this.Game.BestMove + " " + this.Game.PonderMove, this.Game.Clock.WhiteTime * 1000, this.Game.Clock.BlackTime * 1000);
                                    }
                                }
                            }
                            IsPonderMove = !IsPonderMove;
                            IsPonderMoveResponse = true;
                        }
                    }

                }
            }
            else
            {
                this.Game.PonderMove = "";
                IsPonderMove = false;
            }
            isInfiniteCommandInProgress = false;
        }

        private void GoInfiniteIfRequired()
        {
            if (!this.IsClosed)
            {
                string parentMoves = this.Game.Moves.GetParentsStr(this.Game.CurrentMove);
                if (this.Game.Flags.IsForceEngineToMoveInInfiniteAnalysis && this.Game.Flags.IsInfiniteAnalysisOn)
                {
                    if (this.Game.Flags.IsBoardSetByFen)
                    {
                        SendPositionGoInfinite(this.Game.InitialBoardFen, parentMoves);
                    }
                    else
                    {
                        SendPositionGoInfinite(string.Empty, parentMoves);
                    }

                    this.Game.Flags.IsForceEngineToMoveInInfiniteAnalysis = false;
                    this.Game.Flags.IsMoveInProgress = false;
                }
                else if (this.Game.Flags.IsInfiniteAnalysisOn && !this.Game.Flags.IsForceEngineToMoveInInfiniteAnalysis)
                {
                    this.SendStop();
                    if (this.Game.Flags.IsBoardSetByFen)
                    {
                        this.SendPositionGoInfinite(this.Game.InitialBoardFen, parentMoves);
                    }
                    else
                    {
                        this.SendPositionGoInfinite(string.Empty, parentMoves);
                    }
                }
            }
        }

        #endregion

        #region Timer
        private void InitTimer()
        {
            t.Elapsed += new ElapsedEventHandler(t_Elapsed);
            t.Interval = 100;
        }

        private void ResetTimer()
        {
            ElapsedTime = 0;
        }

        private void StartTimer()
        {
            this.Game.Flags.IsEngineResponseReceived = true;
            ElapsedTime = 0;
            this.Game.Clock.IsPaused = true;
            t.Start();
        }

        private void StopTimer()
        {
            t.Stop();
        }

        void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            t.Stop();

            ElapsedTime++;

            if (ElapsedTime > TimeOut)
            {
                //SendStop();
                this.Game.Flags.IsEngineResponseReceived = false;
                this.Game.Clock.IsPaused = false;
            }
            else
            {
                this.Game.Flags.IsEngineResponseReceived = true;
                this.Game.Clock.IsPaused = true;
                t.Start();
            }
        }

        #endregion

    }
}
