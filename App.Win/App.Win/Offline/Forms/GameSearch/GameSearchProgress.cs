using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace App.Win
{
    public partial class GameSearchProgress : Form
    {
        private DateTime StartTime = DateTime.Now;
        #region Properties

        public ProgressBar ProgressBar
        {
            get
            {
                return progressBar1;
            }
        }
        public Label GameNo
        {
            get
            {
                return lblGameNo;
            }
        }
        public Label TimeConsumed
        {
            get
            {
                return lblTimeConsumed;
            }

        }
        public Label Percentage
        {
            get
            {
                return lblPercentage;
            }
        }
        public Timer Timer
        {
            get
            {
                return timer1;
            }
        }

        #endregion

        #region Delegates/Events
        public delegate void WorkCancelledHandler(object sender, EventArgs args);
        public event WorkCancelledHandler OnWorkCancelled;

        #endregion

        public GameSearchProgress()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (OnWorkCancelled != null)
            {
                OnWorkCancelled(null, new EventArgs());
            }
        }

        private void GameSearchProgress_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (OnWorkCancelled != null)
            {
                OnWorkCancelled(null, new EventArgs());
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void GameSearchProgress_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = DateTime.Now - StartTime;
            string time = string.Empty;
            if (!string.IsNullOrEmpty(Percentage.Text))
            {
                if (ts.Duration() == TimeSpan.Zero)
                {
                    time+=" for a few milliseconds. ";
                }
                else
                {
                    if (ts.Hours > 0)
                    {
                        time+=" " + ts.Hours.ToString() + "h";
                    }
                    if (ts.Minutes > 0)
                    {
                        time+=" " + ts.Minutes.ToString() + "m";
                    }
                    if (ts.Seconds > 0)
                    {
                        time+=" " + ts.Seconds.ToString() + "s";
                    }
                }
                this.TimeConsumed.Text = time;
            }
        }
    }
}
