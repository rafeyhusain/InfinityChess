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

namespace App.Model
{
    #region enum
    public enum ClockType
    {
        Digital = 1,
        Analog = 2,
        DoubleDigital = 3
    } 
    #endregion

    public partial class Clock
    {
        #region Data Members
        public Game Game = null;
        public bool IsPaused = false;
        public long WhiteTime = 0;
        public long BlackTime = 0;
        public long MoveTime = 0;
    
        #endregion

        #region Events
        public event EventHandler<TimeExpiredEventArgs> TimeExpired;
        public event EventHandler ClockSet;
        public event EventHandler ClockTick;
        #endregion

        #region Ctor

        public Clock(Game game)
        {
            Game = game;

            NewGame();
        }
        #endregion

        #region NewGame
        public void NewGame()
        {
            IsPaused = false;
            Reset();
        }

        #endregion

        #region Properties
    
        public DateTime WhiteDateTime
        {
            [DebuggerStepThrough]
            get
            {
                return DateTime.Now.Date.AddSeconds(-WhiteTime);
            }
        }

        public DateTime BlackDateTime
        {
            [DebuggerStepThrough]
            get
            {
                return DateTime.Now.Date.AddSeconds(-BlackTime);
            }
        }

        public string WhiteTimeString
        {
            [DebuggerStepThrough]
            get
            {
                return GetTimeString(this.WhiteTime);
            }
        }

        public string BlackTimeString
        {
            [DebuggerStepThrough]
            get
            {
                return GetTimeString(this.BlackTime);
            }
        }

        public string WhiteTimeString2
        {
            [DebuggerStepThrough]
            get
            {
                return GetTimeString(this.WhiteTime);
            }
        }

        public string BlackTimeString2
        {
            [DebuggerStepThrough]
            get
            {
                return GetTimeString(this.BlackTime);
            }
        }

        public string MoveTimeString
        {
            [DebuggerStepThrough]
            get
            {
                return GetTimeString(this.MoveTime);
            }
        }

        public long CurrentPlayerTime
        {
            [DebuggerStepThrough]
            get
            {
                return this.Game.Flags.IsWhiteTurn ? WhiteTime : BlackTime;
            }
        }

        public bool IsCurrentPlayerTimeExpired
        {
            [DebuggerStepThrough]
            get
            {
                return CurrentPlayerTime <= 0;
            }
        }

        public string ZeroTimeString
        {
            [DebuggerStepThrough]
            get
            {
                return GetTimeString(0);
            }
        }

        #endregion

        #region Toggle
        public void ResetMoveTime()
        {
            MoveTime = 0;
        }

       
        #endregion

        #region Pause

        public bool TogglePause()
        {
            IsPaused = !IsPaused;

            return IsPaused;
        }

        public void Start()
        {
            IsPaused = false;
        }

        public void Stop()
        {
            IsPaused = true;
        }
        
        #endregion

        #region Helpers

        public static string GetTimeString(long timeInterval)
        {
            string timeInString = "";

            DateTime time = new DateTime(1900, 01, 01, 1, 0, 0);

            TimeSpan ts = time.AddSeconds(timeInterval) - time;

            timeInString = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2");

            return timeInString;
        }

        #endregion

        #region Tick

        public void Tick()
        {
            if (IsPaused || (this.Game.Flags.IsOffline && this.Game.Flags.IsFirtMove))
            {
                return;
            }

            #region Check Time Expire
            if (!Game.Flags.IsNoClockGame)
            {
                if (IsCurrentPlayerTimeExpired)
                {
                    TimeIsExpired();
                    return;
                }
            } 
            #endregion

            #region Update Time

            // if Game.Flags.IsInfiniteAnalysisOn== true, then ClockCounters should continue as usual, clock is zero only for display purpose.
            if (Game.Flags.IsNoClockGame && Game.Flags.IsInfiniteAnalysisOff)
            {
                if (this.Game.Flags.IsWhiteTurn)
                {
                    WhiteTime++;
                }
                else
                {
                    BlackTime++;
                }
            }
            else
            {
                if (this.Game.Flags.IsWhiteTurn)
                {
                    WhiteTime--;
                }
                else
                {
                    BlackTime--;
                }
            } 
            #endregion

            MoveTime++;

            if (ClockTick != null)
            {
                ClockTick(this, EventArgs.Empty);
            }
        }

        #endregion

        #region SetTime
        public void ToggleClock(Move m)
        {
            SetClock(m);
        }

        public void SetClock(Move m)
        {
            WhiteTime = m.MoveTimeWhite;
            BlackTime = m.MoveTimeBlack;
            MoveTime = m.MoveTime;

            OnClockSet();
        }

        private void OnClockSet()
        {
            if (ClockSet != null)
            {
                ClockSet(this, EventArgs.Empty);
            }
        } 
        #endregion

        #region Zero
        public void Zero()
        {
            WhiteTime = 0;
            BlackTime = 0;
            MoveTime = 0;

            OnClockSet();
        }

        public void StopZero()
        {
            Stop();
            Zero();
        }
        #endregion

        #region Reset

        public void Reset(long whiteTime, long blackTime)
        {
            this.WhiteTime = whiteTime;
            this.BlackTime = blackTime;
            MoveTime = 0;
            
            OnClockSet();
        }

        public void Reset()
        {
            this.WhiteTime = this.Game.GameTime.TotalTime;
            this.BlackTime = this.Game.GameTime.TotalTime;
            MoveTime = 0;

            OnClockSet();
        }

        public void StopReset()
        {
            Stop();
            Reset();
        }
        #endregion

        public void TimeIsExpired()
        {
            if (Game.Flags.IsOnline && !this.Game.Flags.IsMyTurn)
            {
                if(!Game.Flags.IsTournamentMatchTimeExpired)
                    return;
            }

            if (IsCurrentPlayerTimeExpired)
            {
                IsPaused = true;

                if (TimeExpired != null)
                {
                    TimeExpired(this, new TimeExpiredEventArgs(this.Game.Flags.IsWhiteTurn));
                }

                this.Game.TimeExpired(GameResultE.InProgress, true);
            }
        }
    }

    #region TimeExpiredEventArgs
    public class TimeExpiredEventArgs : EventArgs
    {
        public bool IsWhiteTurn = true;

        public TimeExpiredEventArgs(bool isWhiteTurn)
        {
            IsWhiteTurn = isWhiteTurn;
        }
    } 
    #endregion
}
