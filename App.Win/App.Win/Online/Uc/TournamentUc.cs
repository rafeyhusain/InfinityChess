using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model.Db;
using App.Model;
using AppTournament = App.Model.Db.Tournament;
using System.Globalization;

namespace App.Win
{
    public partial class TournamentUc : UserControl
    {
        #region Data Members
        public App.Model.Db.Tournament Tournament = null;
        public event EventHandler OnVisibleTab;
        public event EventHandler OnTournamentSave;
        #endregion

        #region Ctor
        public TournamentUc()
        {
            InitializeComponent();
        }
        
        #endregion

        #region Properties

        bool IsValidMaxWinners
        {
            get
            {
                return this.Tournament.MaxWinners >= numMaxWinners.Minimum && this.Tournament.MaxWinners <= numMaxWinners.Maximum;
            }
        }

        #endregion

        #region Load
        private void TournamentUc_Load(object sender, EventArgs e)
        {
        }

        #endregion

        #region Toolbar
        private void tsbSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void tsbFinishTournament_Click(object sender, EventArgs e)
        {
            if (TournamentFinish())
            {
                tsbFinishTournament.Visible = false;
                tbsbStartTournament.Visible = false;
            }
        }

        private void tbsbStartTournament_Click(object sender, EventArgs e)
        {
            if (StartTournament())
            {
                tsbFinishTournament.Visible = true;
                tbsbStartTournament.Visible = false;
                tsbSave.Visible = false;
                cmbType.Enabled = false;
                cmbChessType.Enabled = false;
            }            
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkDoubleRound.Visible = false;
            pnlKoItems.Visible = false;
            cmbDblRound.Visible = false;
            lblDblRound.Visible = false;
            chkAllowTieBreak.Visible = false;

            pnlCommonItems.Location = new Point(pnlCommonItems.Location.X, pnlKoItems.Location.Y);
            
            switch (cmbType.SelectedValue.ToString())
            {
                case "1":
                    chkDoubleRound.Visible = true;
                    break;
                case "3":
                    pnlKoItems.Visible = true;
                    chkAllowTieBreak.Visible = true;
                    pnlCommonItems.Location = new Point(pnlCommonItems.Location.X, 270);
                    break;
                case "4":
                    cmbDblRound.Visible = true;
                    lblDblRound.Visible = true;
                    break;

                default:
                    break;
            }
            
        }

        private void reScheduleTournamentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ReScheduleTournament())
            {
                tsbFinishTournament.Visible = false;
                tbsbStartTournament.Visible = true;
                tsbSave.Visible = true;
            }   
        }
        
        private void numTieBreaks_ValueChanged(object sender, EventArgs e)
        {
            if (numTieBreaks.Value > 0)
            {
                chkAllowTieBreak.Checked = true;
            }
        }

        #endregion

        #region Helpers
        #region Fill Tournament Fields
        public void RefreshTab()
        {
            FillCmbs();
            InitDate();

            lblTDName.Text = Ap.CurrentUser.UserName;
            ToggleBieBreakControls(chkAllowTieBreak.Checked);
            numMaxWinners.Enabled = chkAllowMultipleWinners.Checked;

            if (Tournament != null)
            {
                if (!Tournament.IsNew)
                {
                    cmbChessType.SelectedValue = this.Tournament.ChessTypeID;
                    cmbType.SelectedValue = this.Tournament.TournamentTypeID;
                    cmbMin.Text = this.Tournament.TimeControlMin.ToString();
                    cmbSec.Text = this.Tournament.TimeControlSec.ToString();
                    cmbRound.Text = this.Tournament.Round.ToString();
                    cmbDblRound.Text = this.Tournament.DoubleRoundNo.ToString();
                    chkRated.Checked = this.Tournament.Rated;
                    chkDoubleRound.Checked = this.Tournament.DoubleRound;
                    chkAllowTieBreak.Checked = this.Tournament.IsTieBreak;
                    dtpRegStartDate.Value = this.Tournament.RegistrationStartDate;
                    dtpRegStartTime.Value = this.Tournament.RegistrationStartTime;

                    dtpRegEndDate.Value = this.Tournament.RegistrationEndDate;
                    dtpRegEndTime.Value = this.Tournament.RegistrationEndTime;
                    
                    dtpTournamentStartDate.Value = this.Tournament.TournamentStartDate;
                    dtpTournamentStartTime.Value = this.Tournament.TournamentStartTime;

                    txtTitle.Text = this.Tournament.Name;
                    txtInvitation.Text = this.Tournament.Description;

                    numGames.Value = this.Tournament.NoOfGamesPerRound == 0 ? 1 : this.Tournament.NoOfGamesPerRound;
                    numTieBreaks.Value = this.Tournament.NoOfTieBreaks;
                    cmbTbMin.Text = this.Tournament.TieBreakMin.ToString();
                    cmbTbSec.Text = this.Tournament.TieBreakSec.ToString();
                    cmbWhiteMin.Text = this.Tournament.SuddenDeathWhiteMin.ToString();
                    cmbBlackMin.Text = this.Tournament.SuddenDeathBlackMin.ToString();
                    cmbSdSec.Text = this.Tournament.SuddenDeathSec.ToString();
                    if (IsValidMaxWinners)
                    {
                        numMaxWinners.Value = Convert.ToDecimal(this.Tournament.MaxWinners);
                        chkAllowMultipleWinners.Checked = true;
                    }

                    tbsbStartTournament.Visible = false;
                    tsbFinishTournament.Visible = false;
                    cmbType.Enabled = false;
                    cmbChessType.Enabled = false;

                    lblTDName.Text = this.Tournament.CreatedUser.UserName;

                }
            }
            ViewStartTournamentButton();
        }

        private void InitDate()
        {
            dtpRegStartDate.Value = DateTime.Now;
            dtpRegEndDate.Value = DateTime.Now;
            dtpTournamentStartDate.Value = DateTime.Now;
        }
        #endregion

        #region View Start Finish button
        void ViewStartTournamentButton()
        {
            tbsbStartTournament.Visible = false;
            tsbFinishTournament.Visible = false;
            tsbRescheduleTask.Visible = false;
            txtTitle.Enabled = true;
            if (this.Tournament != null)
            {
                if (this.Tournament.TournamentStatusIDE == TournamentStatusE.Scheduled)
                {                    
                    tbsbStartTournament.Visible = true;
                    tsbSave.Visible = true;
                    txtTitle.Enabled = false;
                }
                else if (this.Tournament.TournamentStatusIDE == TournamentStatusE.InProgress)
                {
                    txtTitle.Enabled = false;
                    tsbRescheduleTask.Visible = true;
                    tsbFinishTournament.Visible = true;                    
                    tsbSave.Visible = false;
                }
            }
        }
        #endregion

        #region Fill Combos
        private void FillCmbs()
        {
            if (cmbType.Items.Count > 0)
            {
                return;
            }

            DataSet ds = SocketClient.GetTournamentCmbData();

            if (ds.Tables.Count > 0)
            {
                cmbType.DataSource = ds.Tables[0];
                cmbType.DisplayMember = "Name";
                cmbType.ValueMember = "TournamentTypeId";

                chkDoubleRound.Visible = true;
               
                cmbChessType.DataSource = ds.Tables[1];
                cmbChessType.DisplayMember = "Name";
                cmbChessType.ValueMember = "ChessTypeId";
            }


            FillNumbers(cmbMin, 181, 1);
            FillNumbers(cmbSec, 60, 0);
            FillNumbers(cmbRound, 20, 1);
            FillNumbers(cmbTbMin, 181, 1);
            FillNumbers(cmbTbSec, 60, 0);
            FillNumbers(cmbWhiteMin, 181, 1);
            FillNumbers(cmbBlackMin, 181, 1);
            FillNumbers(cmbSdSec, 60, 0);
            FillNumbers(cmbDblRound, 10, 0);
        }

        void FillNumbers(ComboBox cb, int counter, int start)
        {
            for (int i = start; i < counter; i++)
            {
                cb.Items.Add(i.ToString());
            }
            cb.SelectedIndex = 0;
        }

        #endregion

        #region Save Tournament
        private void SaveTournament()
        {
            Kv kv = new Kv();

            if (Tournament != null)
            {
                kv.Set("TournamentID", this.Tournament.TournamentID);
            }

            if (cmbType.SelectedValue != null)
            {
                kv.Set("TournamentTypeID", cmbType.SelectedValue.ToString());
            }

            if (cmbChessType.SelectedValue != null)
            {
                kv.Set("ChessTypeID", cmbChessType.SelectedValue.ToString());
            }            

            if (cmbRound.SelectedItem != null)
            {
                kv.Set("Round", cmbRound.SelectedItem.ToString());
            }
            else
            {
                kv.Set("Round", 1);
            }

            if (cmbDblRound.SelectedItem != null)
            {
                kv.Set("DoubleRoundNo", Convert.ToInt32(cmbDblRound.Text));
            }
            else
            {
                kv.Set("DoubleRoundNo", 0);
            }

            if (cmbType.SelectedValue != null && cmbType.SelectedValue.ToString() == "3") // if knock-out tournament.
            {
                chkAllowTieBreak.Checked = numTieBreaks.Value > 0;
            }

            kv.Set("Rated", chkRated.Checked);
            kv.Set("DoubleRound", chkDoubleRound.Checked);
            kv.Set("IsTieBreak", chkAllowTieBreak.Checked);

            if (cmbMin.SelectedItem != null)
            {
                kv.Set("TimeControlMin", cmbMin.SelectedItem.ToString());
            }
            else
            {
                kv.Set("TimeControlMin", 1);
            }

            if (cmbSec.SelectedItem != null)
            {
                kv.Set("TimeControlSec", cmbSec.SelectedItem.ToString());
            }
            else
            {
                kv.Set("TimeControlSec", 1);
            }

            kv.Set("RegistrationStartDate", dtpRegStartDate.Value.ToString());
            kv.Set("RegistrationStartTime", dtpRegStartTime.Value.ToShortTimeString());

            kv.Set("RegistrationEndDate", dtpRegEndDate.Value.ToString());
            kv.Set("RegistrationEndTime", dtpRegEndTime.Value.ToShortTimeString());

            kv.Set("TournamentStartDate", dtpTournamentStartDate.Value.ToString());
            kv.Set("TournamentStartTime", dtpTournamentStartTime.Value.ToShortTimeString());

            kv.Set("TournamentStatusID", (int)TournamentStatusE.Scheduled);
            kv.Set("StatusID", (int)StatusE.Active);
            kv.Set("TournamentStartTime", dtpTournamentStartTime.Value.ToString());

            kv.Set("Name", txtTitle.Text);
            kv.Set("Description", txtInvitation.Text);

            if (cmbTbMin.SelectedItem != null)
            {
                kv.Set("TieBreakMin", cmbTbMin.SelectedItem.ToString());
            }
            else
            {
                kv.Set("TieBreakMin", 1);
            }
            if (cmbTbSec.SelectedItem != null)
            {
                kv.Set("TieBreakSec", cmbTbSec.SelectedItem.ToString());
            }
            else
            {
                kv.Set("TieBreakSec", 1);
            }
            kv.Set("NoOfGamesPerRound", numGames.Value);
            kv.Set("NoOfTieBreaks", numTieBreaks.Value);
            kv.Set("SuddenDeathWhiteMin", cmbWhiteMin.SelectedItem.ToString());            
            kv.Set("SuddenDeathBlackMin", cmbBlackMin.SelectedItem.ToString());
            kv.Set("SuddenDeathSec", cmbSdSec.SelectedItem.ToString());

            if (chkAllowMultipleWinners.Checked)
            {
                kv.Set("MaxWinners", numMaxWinners.Value);
            }
            else
            {
                kv.Set("MaxWinners", 0);
            }

            ProgressForm frmProgress = ProgressForm.Show(this, "Saving Tournament...");

            DataSet ds = SocketClient.SaveTournament(kv);

            frmProgress.Close();

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    kv = new Kv(ds.Tables[0]);
                    this.Tournament = new App.Model.Db.Tournament(Ap.Cxt, ds.Tables[0].Rows[0]);
                }
            }
            else
            {
                return;
            }

            if (this.Tournament == null)
            {
                return;
            }

            if (OnTournamentSave != null)
            {
                OnTournamentSave(this, EventArgs.Empty);
            }

            if (this.Tournament != null)
            {
                if (this.Tournament.TournamentID > 0)
                {
                    MessageForm.Show(this.ParentForm, MsgE.ConfirmTournamentSaved, this.Tournament.Name);
                    cmbChessType.Enabled = false;
                }
            }
            

            if (OnVisibleTab != null)
            {
                OnVisibleTab(this, EventArgs.Empty);
            }

            ViewStartTournamentButton();
        }
        #endregion

        #region Validate
        public bool Validate(out MsgE msg)
        {
            DateTime datetime;
            if (txtTitle.Text.Trim() == string.Empty)
            {
                msg = MsgE.ErrorTournamentName;
                return false;
            }

            if (!DateTime.TryParseExact(dtpRegStartTime.Text, "h:m tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out datetime))
            {
                msg = MsgE.ErrorTournamentStartTime;
                return false;
            }

            if (!DateTime.TryParseExact(dtpRegEndTime.Text, "h:m tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out datetime))
            {
                msg = MsgE.ErrorTournamentEndTime;
                return false;
            }

            if (!DateTime.TryParseExact(dtpTournamentStartTime.Text, "h:m tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out datetime))
            {
                msg = MsgE.ErrorTournamentStartTime;
                return false;
            }


            if (cmbType.SelectedValue.ToString() == "3" && chkAllowTieBreak.Checked) // for Knock-out tournament
            {
                GameType trGameType = GameTime.GetGameType(Convert.ToInt32(cmbMin.Text), Convert.ToInt32(cmbSec.Text));
                GameType tbGameType = GameTime.GetGameType(Convert.ToInt32(cmbTbMin.Text), Convert.ToInt32(cmbTbSec.Text));
                GameType sdGameType = GameTime.GetGameType(Convert.ToInt32(cmbWhiteMin.Text), Convert.ToInt32(cmbSdSec.Text));

                if (trGameType != tbGameType || trGameType != sdGameType)
                {
                    msg = MsgE.ErrorRestartGameTime;
                    return false;
                }
            }

            msg = MsgE.ErrorTournamentName;
            return true;
        }
        #endregion

        #region Tournament Player Exist
        private bool IsTournamentUser
        {
            get
            {                         

                DataSet ds = SocketClient.GetTournamentRegisteredUser(StatusE.Active, this.Tournament.TournamentID);

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 1)
                        {
                            return true;
                        }
                        else
	                    {
                            return false;
	                    }
                    }
                    else
	                {
                        return false;
	                }                    
                }                
                return false;
            }

        }
        #endregion

        #region Start Tournament
        private bool StartTournament()
        {
            bool isTrue = false;
            if (this.Tournament == null)
            {
                return false;
            }

            if (this.Tournament.TournamentID == 0)
            {
                return false;
            }

            if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, "start", "tournament " + "'" + this.Tournament.Name + "'") == DialogResult.Yes)
            {
                
                ProgressForm frmProgress = ProgressForm.Show(this, "Creating matches...");

                this.Tournament.TournamentStatusIDE = TournamentStatusE.InProgress;
                DataSet ds = SocketClient.TournamentStart(this.Tournament.TournamentID, this.Tournament.TournamentStatusIDE);

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        Kv kv = new Kv(ds.Tables[0]);
                        if (kv.GetInt32("Result") > 0)
                        {
                            frmProgress.Close();
                            if ((int)MsgE.ErrorTournamentUserExist == kv.GetInt32("Result") && this.Tournament.TournamentTypeIDE == TournamentTypeE.Knockout)
                            {
                                MessageForm.Error(this.ParentForm, (MsgE)kv.GetInt32("Result"), this.Tournament.Name, 4);
                            }
                            else
                            {
                                MessageForm.Error(this.ParentForm, (MsgE)kv.GetInt32("Result"), this.Tournament.Name, 2);
                            }
                            
                            this.Tournament.TournamentStatusIDE = TournamentStatusE.Scheduled;
                            return false;
                        }
                    }

                    tsbRescheduleTask.Visible = true;
                    frmProgress.Close();

                    MessageForm.Show(this.ParentForm, MsgE.ConfirmTournamentStarted, this.Tournament.Name);
                    isTrue = true;
                }
                else
                {
                    MessageForm.Error(this.ParentForm, MsgE.ErrorTournamentUserExist, this.Tournament.Name);

                    return false;
                }
                
            }
            return isTrue;
        }

        #endregion

        #region Finish Tournament
        bool TournamentFinish()
        {
            if (this.Tournament == null)
            {
                return false;
            }

            if (this.Tournament.TournamentID == 0)
            {
                return false;
            }

            if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, "finish", "tournament " + "'" + this.Tournament.Name + "'") == DialogResult.Yes)
            {
                ProgressForm frmProgress = ProgressForm.Show(this, "Loading matches...");
                this.Tournament.TournamentStatusIDE = TournamentStatusE.Finsihed;
                SocketClient.TournamentFinish(this.Tournament.TournamentID, this.Tournament.TournamentStatusIDE);
                frmProgress.Close();

                this.ParentForm.DialogResult = DialogResult.OK;
                this.ParentForm.Close();
                return true;
            }
            return false;
        }
        #endregion

        #region Save
        public void Save()
        {
            MsgE msgE;

            if (!Validate(out msgE))
            {
                MessageForm.Error(this.ParentForm, msgE);
                return;
            }            

            SaveTournament();
        }

        #endregion                

        #region ReScheduale Tournament
        
        private bool ReScheduleTournament()
        {
            if (this.Tournament == null)
            {
                return false;
            }

            if (this.Tournament.TournamentID == 0)
            {
                return false;
            }

            if (this.Tournament.TournamentStatusIDE == TournamentStatusE.InProgress)
            {

                if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, "reschedule", "tournament " + "'" + this.Tournament.Name + "'") == DialogResult.Yes)
                {

                    ProgressForm frmProgress = ProgressForm.Show(this, "Rescheduling matches...");

                    this.Tournament.TournamentStatusIDE = TournamentStatusE.Scheduled;
                    SocketClient.RescheduleTournament(this.Tournament.TournamentID, this.Tournament.TournamentStatusIDE);

                    frmProgress.Close();
                    tsbRescheduleTask.Visible = false;                    
                    MessageForm.Show(this.ParentForm, MsgE.ConfirmRescheduleTournament, this.Tournament.Name);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                MessageForm.Show(this.ParentForm, MsgE.ErrorRescheduleTournament);
                return false;
            }
        } 
        #endregion

        #region Toggle TieBreak Controls 
        private void ToggleBieBreakControls(bool enabled)
        {
            numTieBreaks.Enabled = enabled;
            cmbTbMin.Enabled = enabled;
            cmbTbSec.Enabled = enabled;
        }
        #endregion

        #endregion

        internal void AllowEdit(bool enable)
        {
            toolStrip1.Visible = enable;

            this.Enabled = enable;
        }

        #region Events 
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cmbMin_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblTbWhiteSec_Click(object sender, EventArgs e)
        {

        }

        private void chkAllowTieBreak_CheckedChanged(object sender, EventArgs e)
        {
            ToggleBieBreakControls(chkAllowTieBreak.Checked);
        }

        private void chkAllowMultipleWinners_CheckedChanged(object sender, EventArgs e)
        {
            numMaxWinners.Enabled = chkAllowMultipleWinners.Checked;
        } 
        #endregion
    }
}
