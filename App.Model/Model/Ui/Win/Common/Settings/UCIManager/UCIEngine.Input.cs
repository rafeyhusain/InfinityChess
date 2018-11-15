using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.ComponentModel;
using App.Model;
using InfinitySettings.Streams;

namespace App.Model
{
    public partial class UCIEngine
    {
        #region UCI Input

        #region Core
        public string SendEngine(string command)
        {
            if (!IsClosed && !IsSwitchedOff)
            {
                try
                {
                    TestDebugger.Instance.WriteEngineInput(EngineName, command);
                    _uciProcess.StandardInput.WriteLine(command);
                }
                catch (Exception ex)
                {
                    TestDebugger.Instance.Write("EXCEPTION......" + ex);
                }
            }
            else
            {
                TestDebugger.Instance.WriteEngineInput("Engine is closed and cant accept input", command);
            }

            return command;
        }
        #endregion

        #region Commands

        #region Uci
        public string SendUci()
        {
            return SendEngine("uci\n");
        }
        #endregion

        #region SetOption
        public const string OptionHash = "Hash";
        public const string OptionClear = "Clear";
        public const string OptionNalimovPath = "NalimovPath";
        public const string OptionNalimovCache = "NalimovCache";
        public const string OptionPonder = "Ponder";
        public const string OptionMultiPv = "MultiPV";

        public string SendOption(string name, object value)
        {
            return SendEngine(string.Format("setoption name {0} value {1}\n", name, value.ToString()));
        }

        public string SendOption(string name)
        {
            return SendEngine(string.Format("setoption name {0} \n", name));
        }
        #endregion

        #region Position
        public string SendPosition(string moves)
        {
            return SendPosition("", moves);
        }

        public string SendPosition(string fen, string moves)
        {
            string command = "position";

            if (String.IsNullOrEmpty(fen))
            {
                command += " startpos";
            }
            else
            {
                command += string.Format(" fen {0}", fen);
            }

            if (!String.IsNullOrEmpty(moves))
            {
                command += string.Format(" moves {0}", moves);
            }

            command += "\n";

            return SendEngine(command);
        }
        #endregion

        #region Go
        public string SendGo(string searchMoves
                    , bool ponder
                    , long wTime
                    , long bTime
                    , long wInc
                    , long bInc
                    , long movesToGo
                    , long depth
                    , long nodes
                    , long mate
                    , long moveTime
                    , bool infinite
                    )
        {
            string command = "go";

            if (!String.IsNullOrEmpty(searchMoves))
            {
                command += string.Format(" searchmoves {0}", searchMoves);
            }

            if (ponder)
            {
                command += string.Format(" ponder");
            }

            if (wTime > 0)
            {
                command += string.Format(" wtime {0}", wTime);
            }

            if (bTime > 0)
            {
                command += string.Format(" btime {0}", bTime);
            }

            if (wInc > 0)
            {
                command += string.Format(" winc {0}", wInc);
            }

            if (bInc > 0)
            {
                command += string.Format(" binc {0}", bInc);
            }

            if (movesToGo > 0)
            {
                command += string.Format(" movestogo {0}", movesToGo);
            }

            if (depth > 0)
            {
                command += string.Format(" depth {0}", depth);
            }

            if (nodes > 0)
            {
                command += string.Format(" nodes {0}", nodes);
            }

            if (mate > 0)
            {
                command += string.Format(" mate {0}", mate);
            }

            if (moveTime > 0)
            {
                command += string.Format(" movetime {0}", moveTime);
            }

            if (infinite)
            {
                command += string.Format(" infinite");
            }

            command += "\n";

            return SendEngine(command);
        }

        public string SendGoInfinite()
        {
            return SendGo("", false, 0, 0, 0, 0, 0, 0, 0, 0, 0, true);
        }

        public string SendGo(bool ponder, long wTime, long bTime, long wInc, long bInc)
        {
            return SendGo("", ponder, wTime, bTime, wInc, bInc, 0, 0, 0, 0, 0, false);
        }

        public string SendGo(bool ponder, long wTime, long bTime)
        {
            return SendGo(ponder, wTime, bTime, 0, 0);
        }
        #endregion

        #region Stop
        public string SendStop()
        {
            isInfiniteCommandInProgress = false;
            return SendEngine("stop\r\n");
        }


        #endregion

        #region PonderHit
        public void SendPonderHit()
        {
            SendEngine("ponderhit\n");
        }
        #endregion

        #region Ready
        public string SendIsReady()
        {
            return SendEngine("isready\n");
        }
        #endregion



        #endregion

        #region Combination Commands
        public void SendPositionGo(bool isPonder, string fen, string moves, long whiteTimeSeconds, long blackTimeSeconds)
        {
            if (!IsHashCleared)
            {
                IsHashCleared = true;
            }
            if (IsKibitzer)
            {
                SendStop();
                SendPositionGoInfinite(fen, moves);
                return;
            }
            IsMoveInProgress = true;
            if (ProcessPonder && !IsPonderMove && CheckPonderHit(moves))
            {
                return;
            }
            else
            {
                positionCommand = SendPosition(fen, moves);

                if (isInfiniteCommandInProgress)
                {
                    SendOption(UCIEngine.OptionMultiPv, 2);
                    SendGoInfinite();
                }
                else
                {
                    if ((this.Game.Flags.IsFirtMove && isPonder) || (isPonder && isFirstPonderMove))
                    {
                        SendOption(UCIEngine.OptionPonder, "true");
                        isFirstPonderMove = false;
                    }
                    SendGo(isPonder, whiteTimeSeconds, blackTimeSeconds);
                }
            }
        }

        public void SendPositionGoInfinite(string fen, string moves)
        {
            if (!IsHashCleared)
            {
                IsHashCleared = true;
            }

            if (!string.IsNullOrEmpty(fen))
            {
                positionCommand = SendPosition(fen, moves);
            }
            else
            {
                positionCommand = SendPosition(moves);
            }

            if (this.Game.Flags.IsInfiniteAnalysisStarted)
            {
                this.Game.Flags.IsInfiniteAnalysisStarted = false;
                this.Game.Flags.IsMoveInProgress = false;
            }
            SendGoInfinite();
            isInfiniteCommandInProgress = true;
        }

        private bool CheckPonderHit(string moves)
        {
            if (!string.IsNullOrEmpty(this.Game.PreviousPonderMove) && moves.EndsWith(this.Game.PreviousPonderMove))
            {
                SendPonderHit();
                return true;
            }
            else
            {
                if (!string.IsNullOrEmpty(this.Game.PreviousPonderMove))
                {
                        isPonderMiss = true;
                        SendStop();
                        return true;
                }
            }
            return false;
        }

        public void SendPositionGoWithoutCheckingPonderHit(bool isPonder, string fen, string moves, long whiteTimeSeconds, long blackTimeSeconds)
        {
            if (IsKibitzer)
            {
                SendStop();
                SendPositionGoInfinite(fen, moves);
                return;
            }

            IsMoveInProgress = true;
            positionCommand = SendPosition(fen, moves);

            if (isInfiniteCommandInProgress)
            {
                SendOption(UCIEngine.OptionMultiPv, 2);
                SendGoInfinite();
            }
            else
            {
                if ((this.Game.Flags.IsFirtMove && isPonder) || (isPonder && isFirstPonderMove))
                {
                    SendOption(UCIEngine.OptionPonder, "true");
                    isFirstPonderMove = false;
                }
                SendGo(isPonder, whiteTimeSeconds, blackTimeSeconds);
            }
        }
       
        #endregion

        #endregion
    }
}
