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
    public partial class LongClockForm : BaseWinForm
    {
        #region DataMembers 

        public Game Game = null;
        public InfinityChess.TournamentManager.Tournament TournamentInfo = null;

        #endregion

        #region Properties 

        public App.Model.OptionsLongClock OptionsLongClock
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return Ap.OptionsLongClock; }
        }

        #endregion
        
        #region Ctor 

        public LongClockForm(Game game)
        {
            this.Game = game;
            InitializeComponent();
        }

        #endregion

        #region Load 

        private void LongClockForm_Load(object sender, EventArgs e)
        {
            numHourFirst.Value = OptionsLongClock.FirstControlHour;
            numMinuteFirst.Value = OptionsLongClock.FirstControlMinute;
            numMovesFirst.Value = OptionsLongClock.FirstControlMoves;
            numGainFirst.Value = OptionsLongClock.FirstControlGainPerMoves;

            numHourSecond.Value = OptionsLongClock.SecondControlHour;
            numMinuteSecond.Value = OptionsLongClock.SecondControlMinute;
            numMovesSecond.Value = OptionsLongClock.SecondControlMoves;
            numGainSecond.Value = OptionsLongClock.SecondControlGainPerMoves;

            numHourThird.Value = OptionsLongClock.ThirdControlHour;
            numMinuteThird.Value = OptionsLongClock.ThirdControlMinute;
            numGainThird.Value = OptionsLongClock.ThirdControlGainPerMove;
        }

        #endregion

        #region Events 
                
        private void rb2hour_CheckedChanged(object sender, EventArgs e)
        {
            numHourFirst.Value = 2;
            numMinuteFirst.Value = 0;
            numMovesFirst.Value = 40;
            numGainFirst.Value = 0;

            numHourSecond.Value = 1;
            numMinuteSecond.Value = 0;
            numMovesSecond.Value = 20;
            numGainSecond.Value = 0;

            numHourThird.Value = 0;
            numMinuteThird.Value = 30;            
            numGainThird.Value = 0;
        }

        private void rb60min_CheckedChanged(object sender, EventArgs e)
        {
            numHourFirst.Value = 1;
            numMinuteFirst.Value = 0;
            numMovesFirst.Value = 40;
            numGainFirst.Value = 30;

            numHourSecond.Value = 0;
            numMinuteSecond.Value = 0;
            numMovesSecond.Value = 0;
            numGainSecond.Value = 0;

            numHourThird.Value = 0;
            numMinuteThird.Value = 15;
            numGainThird.Value = 30;
        }

        private void rb2HourAllMoves_CheckedChanged(object sender, EventArgs e)
        {
            numHourFirst.Value = 2;
            numMinuteFirst.Value = 0;
            numMovesFirst.Value = 40;
            numGainFirst.Value = 30;

            numHourSecond.Value = 1;
            numMinuteSecond.Value = 0;
            numMovesSecond.Value = 0;
            numGainSecond.Value = 0;

            numHourThird.Value = 0;
            numMinuteThird.Value = 30;
            numGainThird.Value = 30;
        }

        private void rb90min_CheckedChanged(object sender, EventArgs e)
        {
            numHourFirst.Value = 1;
            numMinuteFirst.Value = 30;
            numMovesFirst.Value = 40;
            numGainFirst.Value = 0;

            numHourSecond.Value = 0;
            numMinuteSecond.Value = 30;
            numMovesSecond.Value = 40;
            numGainSecond.Value = 0;

            numHourThird.Value = 0;
            numMinuteThird.Value = 15;
            numGainThird.Value = 0;
        }

        private void rb45min_CheckedChanged(object sender, EventArgs e)
        {
            numHourFirst.Value = 0;
            numMinuteFirst.Value = 45;
            numMovesFirst.Value = 40;
            numGainFirst.Value = 0;

            numHourSecond.Value = 0;
            numMinuteSecond.Value = 45;
            numMovesSecond.Value = 40;
            numGainSecond.Value = 0;

            numHourThird.Value = 0;
            numMinuteThird.Value = 45;
            numGainThird.Value = 0;
        }

        private void rb90minAllMoves_CheckedChanged(object sender, EventArgs e)
        {
            numHourFirst.Value = 1;
            numMinuteFirst.Value = 30;
            numMovesFirst.Value = 40;
            numGainFirst.Value = 0;

            numHourSecond.Value = 0;
            numMinuteSecond.Value = 0;
            numMovesSecond.Value = 40;
            numGainSecond.Value = 0;

            numHourThird.Value = 0;
            numMinuteThird.Value = 15;
            numGainThird.Value = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveOptions();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
        private void btnHelp_Click(object sender, EventArgs e)
        {
           Ap.Help(this, HelpTopicIdE.LongClockForm);
        }
        
        #endregion

        #region Helper Methods 
               
        // save form to tournament object
        public void Get(InfinityChess.TournamentManager.Tournament tournament)
        {
            tournament.LongFirstHour = numHourFirst.Value;
        }

        // set form using tournament object
        public void Set(InfinityChess.TournamentManager.Tournament tournament)
        {
            numHourFirst.Value = tournament.LongFirstHour;
        }

        public void SaveOptions()
        {
            OptionsLongClock.FirstControlHour = Convert.ToInt32(numHourFirst.Value);
            OptionsLongClock.FirstControlMinute = Convert.ToInt32(numMinuteFirst.Value);
            OptionsLongClock.FirstControlMoves = Convert.ToInt32(numMovesFirst.Value);
            OptionsLongClock.FirstControlGainPerMoves = Convert.ToInt32(numGainFirst.Value);

            OptionsLongClock.SecondControlHour = Convert.ToInt32(numHourSecond.Value);
            OptionsLongClock.SecondControlMinute = Convert.ToInt32(numMinuteSecond.Value);
            OptionsLongClock.SecondControlMoves = Convert.ToInt32(numMovesSecond.Value);
            OptionsLongClock.SecondControlGainPerMoves = Convert.ToInt32(numGainSecond.Value);

            OptionsLongClock.ThirdControlHour = Convert.ToInt32(numHourThird.Value);
            OptionsLongClock.ThirdControlMinute = Convert.ToInt32(numMinuteThird.Value);
            OptionsLongClock.ThirdControlGainPerMove = Convert.ToInt32(numGainThird.Value);

            this.Game.GameTime.GainPerMove = OptionsLongClock.FirstControlGainPerMoves;

            OptionsLongClock.Save();

            Ap.Options.GameType = GameType.Long;
            Ap.Options.Save();
        }

        #endregion

        #region Overrides

        public override string HelpTopicId
        {
            get { return "60"; }
        }

        #endregion

    }
}
