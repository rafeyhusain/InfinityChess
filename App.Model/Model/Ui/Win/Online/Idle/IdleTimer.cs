using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using App.Model;

namespace App.Model
{
    public class IdleTimer
    {
        #region DataMemebers
        Timer timerIdle;
        bool IsIdle = false;
        
        private int interval;
        public int Interval
        {
            get { return interval; }
            set { interval = value; }
        }

        public bool Enabled
        {
            get { return timerIdle.Enabled; }
            set { timerIdle.Enabled = value; }
        }

        #endregion

        #region Ummanaged Code

        // Unmanaged function from user32.dll
        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        // Struct we'll need to pass to the function
        internal struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }

        #endregion

        #region Ctor

        public IdleTimer()
        {
            InitTimer();
        }

        #endregion

        #region Events

        void timerIdle_Tick(object sender, EventArgs e)
        {
            ProcessIdleTime();
        }

        #endregion

        #region Helper Methods

        private void InitTimer()
        {
            timerIdle = new Timer();
            timerIdle.Interval = 1000;
            timerIdle.Tick += new EventHandler(timerIdle_Tick);
            timerIdle.Enabled = true;
        }

        private void ProcessIdleTime()
        {
            // Get the system uptime
            int systemUptime = Environment.TickCount;
            // The tick at which the last input was recorded
            int LastInputTicks = 0;
            // The number of ticks that passed since last input
            int IdleTicks = 0;

            // Set the struct
            LASTINPUTINFO LastInputInfo = new LASTINPUTINFO();
            LastInputInfo.cbSize = (uint)Marshal.SizeOf(LastInputInfo);
            LastInputInfo.dwTime = 0;

            // If we have a value from the function
            if (GetLastInputInfo(ref LastInputInfo))
            {
                // Get the number of ticks at the point when the last activity was seen
                LastInputTicks = (int)LastInputInfo.dwTime;
                // Number of idle ticks = system uptime ticks - number of ticks at last input
                IdleTicks = systemUptime - LastInputTicks;
            }
            // divide by 1000 to transform the milliseconds to seconds            
            int idleSeconds = IdleTicks / 1000;
            if (idleSeconds >= interval)
            {
                if (!IsIdle)
                {
                    IsIdle = true;
                    SocketClient.IdleUser(true);
                }
                //this.Enabled = false;
            }
            else
            {
                if (IsIdle)
                {
                    SocketClient.IdleUser(false);
                }
                IsIdle = false;
            }
        }

        #endregion
    }
}
