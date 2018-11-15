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

    public class Clock
    {
        #region Data Members
        public Game Game = null;
        public bool IsPaused = false;

        public long WhiteTime = 0;
        public long BlackTime = 0;
        public long MoveTime = 0;
        public bool IsWhite = true;

        #endregion

        #region Events
        public event EventHandler<TimeExpiredEventArgs> TimeExpired;
        public event EventHandler ClockSet;
        #endregion

        #region Ctor

        public Clock(Game game)
        {
            Game = game;
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
                return GetTimeString2(this.WhiteTime);
            }
        }

        public string BlackTimeString2
        {
            [DebuggerStepThrough]
            get
            {
                return GetTimeString2(this.BlackTime);
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
            //[DebuggerStepThrough]
            get
            {
                return IsWhite ? BlackTime : WhiteTime;
            }
        }

        public bool IsCurrentPlayerTimeExpired
        {
            //[DebuggerStepThrough]
            get
            {
                return CurrentPlayerTime <= 0;
            }
        }

        #endregion

        #region SetupNewGame
        public void SetupNewGame()
        {
            IsPaused = false;
            Reset();
        }

        #endregion

        #region Toggle
        public void TogglePlayer()
        {
            IsWhite = !IsWhite;
            MoveTime = 0;
        }

       
        #endregion

        #region Pause
        public void TogglePause()
        {
            IsPaused = !IsPaused;
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

            if (timeInterval >= 3600)
            {
                int hour = (int)timeInterval / 60 / 60;
                timeInterval = timeInterval - (hour * 60 * 60);
                int min = (int)timeInterval / 60;
                int sec = (int)timeInterval - (min * 60);
                timeInString = ((hour < 10) ? "0" + hour.ToString() : hour.ToString());
                timeInString += ":" + ((min < 10) ? "0" + min.ToString() : min.ToString());
                timeInString += ":" + ((sec < 10) ? "0" + sec.ToString() : sec.ToString());
            }
            else if (timeInterval >= 60)
            {
                int min = (int)timeInterval / 60;
                int sec = (int)timeInterval - (min * 60);
                timeInString = "00:" + ((min < 10) ? "0" + min.ToString() : min.ToString());
                timeInString += ":" + ((sec < 10) ? "0" + sec.ToString() : sec.ToString());
            }
            else if (timeInterval >= 0)
            {
                timeInString += "00:00:" + ((timeInterval < 10) ? "0" + timeInterval.ToString() : timeInterval.ToString());
            }
            else
            {
                timeInString = "Time";
            }
            return timeInString;
        }

        public static string GetTimeString2(long timeInterval)
        {
            string timeInString = "";
            if (timeInterval >= 3600)
            {
                int hour = (int)timeInterval / 60 / 60;
                timeInterval = timeInterval - (hour * 60 * 60);
                int min = (int)timeInterval / 60;
                int sec = (int)timeInterval - (min * 60);
                timeInString = ((hour < 10) ? "0" + hour.ToString() : hour.ToString());
                timeInString += ":" + ((min < 10) ? "0" + min.ToString() : min.ToString());
                timeInString += ":" + ((sec < 10) ? "0" + sec.ToString() : sec.ToString());
            }
            else if (timeInterval >= 60)
            {
                int min = (int)timeInterval / 60;
                int sec = (int)timeInterval - (min * 60);
                timeInString = "00:" + ((min < 10) ? "0" + min.ToString() : min.ToString());
                timeInString += ":" + ((sec < 10) ? "0" + sec.ToString() : sec.ToString());
            }
            else if (timeInterval >= 0)
            {
                timeInString += "00:00:" + ((timeInterval < 10) ? "0" + timeInterval.ToString() : timeInterval.ToString());
            }
            else
            {
                timeInString = "Time";
            }
            return timeInString;
        }
        #endregion

        #region Tick

        public void Tick()
        {
            if (this.Game.Flags.IsFirtMove || IsPaused)
            {
                return;
            }

            #region Check Time Expire
            if (!Game.Flags.IsNoClockGame)
            {
                TimeIsExpired();

                if (IsCurrentPlayerTimeExpired)
                {
                    return;
                }
            } 
            #endregion

            #region TogglePlayer
            if (this.Game.CurrentMove.IsWhite != IsWhite)
            {
                TogglePlayer();
            } 
            #endregion

            #region Update Time
            if (Game.Flags.IsNoClockGame)
            {
                if (IsWhite)
                {
                    BlackTime++;
                }
                else
                {
                    WhiteTime++;
                }
            }
            else
            {
                if (IsWhite)
                {
                    BlackTime--;
                }
                else
                {
                    WhiteTime--;
                }
            } 
            #endregion

            MoveTime++;
        }

        #endregion

        #region SetTime
        public void SetClock(Move m)
        {
            WhiteTime = m.MoveTimeWhite;
            BlackTime = m.MoveTimeBlack;
            IsWhite = m.IsWhite;
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
        public void Reset()
        {
            this.WhiteTime = this.Game.GameTime.TotalTime;
            this.BlackTime = this.Game.GameTime.TotalTime;
            MoveTime = 0;
            IsWhite = true;

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
            if (IsCurrentPlayerTimeExpired)
            {
                IsPaused = true;

                Ap.Game.TimeExpired();

                if (TimeExpired != null)
                {
                    TimeExpired(this, new TimeExpiredEventArgs(IsWhite));
                }
            }
        }
    }

    #region TimeExpiredEventArgs
    public class TimeExpiredEventArgs : EventArgs
    {
        public bool IsWhite = true;

        public TimeExpiredEventArgs(bool isWhite)
        {
            IsWhite = isWhite;
        }
    } 
    #endregion
}
