using System; using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using App.Win;
using InfinityChess.WinForms;

namespace App.Win
{
    public partial class OptionsPopup : BaseWinForm
    {
        #region DataMembers 

        public Game Game = null;
        public MainForm MainForm = null;
                
        #endregion

        #region Delegates/Events 

        public event EventHandler OptionsApplied;

        #endregion

        #region Ctor

        public OptionsPopup(Game game, MainForm mainForm)
        {
            this.Game = game;
            this.MainForm = mainForm;
            InitializeComponent();
        }

        #endregion

        #region Properties 

        public App.Model.Options Options
        {
            get { return Ap.Options; }
        }

        #endregion

        #region Events

        private void OptionsPopup_Load(object sender, EventArgs e)
        {
            LoadOptions();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveAndApplyOptions();
            this.Close();
        }               

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            SaveAndApplyOptions();
        }
        public override string HelpTopicId
        {
            get { return "70"; }
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            Ap.Help(this, HelpTopicIdE.OptionsPopup);
        }             
        
        #endregion

        #region Helper Methods 

        private void OnOptionsApplied()
        {
            if (OptionsApplied != null)
            {
                OptionsApplied(this, EventArgs.Empty);
            }
        }

        private void LoadOptions()
        {
            ////// Load Clocks+Notations
            rdbClocks_C_Digital.Checked = Options.ClockType == "Digital";
            rdbClocks_C_Analog.Checked = Options.ClockType == "Analog";
            rdbClocks_C_DoubleDigital.Checked = Options.ClockType == "DoubleDigital";

            rdbClocks_N_1d4.Checked = Options.NotationMode == "1.d4";
            rdbClocks_N_1d2_d4.Checked = Options.NotationMode == "1.d2-d4";
            
            //// Load Multimedia
            chkMM_Audio_BoardSounds.Checked = Options.DoMultimediaBoardSounds;
            chkShowHorizontalGrid.Checked = Options.ShowHorizontalGrid;
            chkShowVerticalGrid.Checked = Options.ShowVerticalGrid;
        }

        private void SaveOptions()
        {
            ///// Update Clocks+Notations
            if (rdbClocks_C_Digital.Checked)
            {
                Options.ClockType = "Digital";                
            }
            if (rdbClocks_C_Analog.Checked)
            {
                Options.ClockType = "Analog";            
            }
            if (rdbClocks_C_DoubleDigital.Checked)
            {
                Options.ClockType = "DoubleDigital";                
            }

            if (rdbClocks_N_1d4.Checked)
                Options.NotationMode = "1.d4";
            if (rdbClocks_N_1d2_d4.Checked)
                Options.NotationMode = "1.d2-d4";

            //// Update Multimedia
            Options.DoMultimediaBoardSounds = chkMM_Audio_BoardSounds.Checked;
            
            /// DataGridViewRow Display Option
            Options.ShowHorizontalGrid = chkShowHorizontalGrid.Checked;
            Options.ShowVerticalGrid = chkShowVerticalGrid.Checked;
            Options.Save();
        }

        private void SaveAndApplyOptions()
        {
            SaveOptions();
            ClockType clockType = ClockType.Digital;

            // Apply on MainForm(s)
            switch (Options.ClockType)
            {
                case "Digital":
                    clockType = ClockType.Digital;
                    break;
                case "Analog":
                    clockType = ClockType.Analog;
                    break;
                case "DoubleDigital":
                    clockType = ClockType.DoubleDigital;
                    break;
                default:
                    break;
            }

            ApplyOnGame(rdbClocks_N_1d4.Checked, clockType);

            OnOptionsApplied();
        }

        private void ApplyOnGame(bool isSingleNotation, ClockType clockType)
        {
            MainForm mainForm = null;
            
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType().BaseType == typeof(MainForm))
                {
                    mainForm = frm as MainForm;
                    mainForm.Game.Notations.DisplayNotation(isSingleNotation);
                    mainForm.ClockUc.ClockType = clockType;
                    mainForm.ClockUc.RefreshClock();
                }
            }
        }             

        #endregion
        
        #region Design Tab Methods/Events 

        private void btnDesign_BoardDesign_Click(object sender, EventArgs e)
        {
            //BoardDesignPopup frm = new BoardDesignPopup();
            //frm.ShowDialog();
            if (this.MainForm == null) // online
            {
                ChessBoard.ShowBoardDesignPopupOnline(this);
            }
            else // offline
            {
                this.MainForm.ChessBoard.ShowBoardDesignPopup(this);
            }
        }

        #endregion

                
    }
}