using System;
using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InfinityChess.Offline.Forms;

namespace App.Win
{
    public partial class BlitzClockForm : BaseWinForm
    {
        #region DataMembers 

        public Game Game = null;
        public InfinityChess.TournamentManager.Tournament TournamentInfo = null;
                
        #endregion

        #region Ctor 
                
        public BlitzClockForm(Game game)
        {
            this.Game = game;
            InitializeComponent();
        }

        #endregion

        #region Properties

        public App.Model.OptionsBlitzClock OptionsBlitzClock
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return Ap.OptionsBlitzClock; }
        }
        
        #endregion

        #region Load 

        private void BlitzClockForm_Load(object sender, EventArgs e)
        {
            if (TournamentInfo == null)
            {
                numericTime.Value = OptionsBlitzClock.Time;
                numericGainPerMove.Value = OptionsBlitzClock.GainPerMove;
            }
            else
            {
                this.Set(TournamentInfo);
            }
        }

        #endregion

        #region Events 
                
        private void rb5min_CheckedChanged(object sender, EventArgs e)
        {
            numericTime.Value = 5;
            numericGainPerMove.Value = 0;
        }

        private void rb25min_CheckedChanged(object sender, EventArgs e)
        {
            numericTime.Value = 30;
            numericGainPerMove.Value = 0;
        }

        private void rb4min_CheckedChanged(object sender, EventArgs e)
        {
            numericTime.Value = 4;
            numericGainPerMove.Value = 2;
        }

        private void rb15min_CheckedChanged(object sender, EventArgs e)
        {
            numericTime.Value = 15;
            numericGainPerMove.Value = 3;
        }

        private void rb10min_CheckedChanged(object sender, EventArgs e)
        {
            numericTime.Value = 15;
            numericGainPerMove.Value = 0;
        }

        private void rb60min_CheckedChanged(object sender, EventArgs e)
        {
            numericTime.Value = 60;
            numericGainPerMove.Value = 0;
        }

        private void rb2min_CheckedChanged(object sender, EventArgs e)
        {
            numericTime.Value = 30;
            numericGainPerMove.Value = 10;
        }

        private void rb90min_CheckedChanged(object sender, EventArgs e)
        {
            numericTime.Value = 45;
            numericGainPerMove.Value = 15;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            SaveOptions();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
        private void btnHelp_Click(object sender, EventArgs e)
        {
           Ap.Help(this,HelpTopicIdE.BlitzClockForm);
        }

        private void rb3min_Click(object sender, EventArgs e)
        {
            numericTime.Value = 3;
            numericGainPerMove.Value = 0;
        }

        private void rb10min2_Click(object sender, EventArgs e)
        {
            numericTime.Value = 10;
            numericGainPerMove.Value = 0;
        }

        private void rb3min1sec_Click(object sender, EventArgs e)
        {
            numericTime.Value = 3;
            numericGainPerMove.Value = 1;
        }

        private void rb10min1sec_Click(object sender, EventArgs e)
        {
            numericTime.Value = 10;
            numericGainPerMove.Value = 1;
        }

        #endregion

        #region Helpers 

        // save form to tournament object
        public void Get(InfinityChess.TournamentManager.Tournament tournament)
        {
            tournament.BlitzTimeMin = numericTime.Value;
            tournament.BlitzHumanGainPerMove = numericGainPerMove.Value;
        }

        // set form using tournament object
        public void Set(InfinityChess.TournamentManager.Tournament tournament)
        {
            numericGainPerMove.Value = tournament.BlitzHumanGainPerMove;
            if (tournament.BlitzTimeMin != 0)
            {
                numericTime.Value = tournament.BlitzTimeMin;
            }

        }
                
        public void SaveOptions()
        {
            OptionsBlitzClock.Time = Convert.ToInt32(numericTime.Value);
            OptionsBlitzClock.GainPerMove = Convert.ToInt32(numericGainPerMove.Value);
            //this.Game.GainPerMove = Convert.ToInt32(numericGainPerMove.Value);
            this.Game.GameTime.GainPerMove = Convert.ToInt32(numericGainPerMove.Value);

            OptionsBlitzClock.Save();

            Ap.Options.GameType = GameType.Blitz;
            Ap.Options.Save();
        }

        #endregion

        #region Overries

        public override string HelpTopicId
        {
            get { return "10"; }
        }
        #endregion




    }
}
