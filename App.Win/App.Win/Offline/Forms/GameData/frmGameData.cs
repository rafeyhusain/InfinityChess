using System; using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using InfinityChess.Offline.Forms;
using App.Win;
using InfinityChess.WinForms;

namespace InfinityChess.GameData
{
    public partial class frmGameData : Form
    {
        #region DataMembers 

        public Game Game = null;
        public MainForm MainForm = null;
        App.Model.GameData gameData;

        public static bool isFromDatabase;

        #endregion

        #region Properties 

        public App.Model.GameData GameData
        {
            get 
            {
                if (gameData == null)
                {
                    gameData = this.Game.GameData;
                }
                return gameData;
            }
            private set { gameData = value; }
        }

        #endregion

        #region Ctor 

        public frmGameData(MainForm mainForm)
        {
            this.MainForm = mainForm;
            InitializeComponent();
        }

        public frmGameData(App.Model.GameData gameData, MainForm mainForm)
        {
            InitializeComponent();
            this.MainForm = mainForm;
            this.gameData = gameData;
        }

        #endregion

        #region Load 
                
        private void frmGameData_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadGameData();
            numYear.Select(1, 4);
        }

        #endregion

        #region Helpers 
                
        private void LoadComboBoxes()
        {
            Kv kv = new Kv(KvType.ResultSymbols);

            cmbResult.DisplayMember = "k";
            cmbResult.ValueMember = "k";
            cmbResult.DataSource = kv.DataTable;
        }

        private void LoadGameData()
        {
            // Players and Result
            txtWhite1.Text = GameData.White1;
            txtWhite2.Text = GameData.White2;
            txtBlack1.Text = GameData.Black1;
            txtBlack2.Text = GameData.Black2;
            txtTournament.Text = GameData.Tournament;
            chkECOCode.Checked = GameData.IsECO;
            txtECOCode.Text = GameData.EcoCode;
            numEloWhite.Value = GameData.EloWhite;            
            numEloBlack.Value = GameData.EloBlack;                        

            rdb1_0.Checked = GameData.Result == "1-0";
            rdb0_1.Checked = GameData.Result == "0-1";
            rdb12_12.Checked = GameData.Result == "1/2-1/2";
            cmbResult.SelectedValue = GameData.Result;

            chkYear.Checked = GameData.IsYear;
            numYear.Value = GameData.Year;
            chkMonth.Checked = GameData.IsMonth;
            numMonth.Value = GameData.Month;
            chkDay.Checked = GameData.IsDay;
            numDay.Value = GameData.Day;
        }

        private void SaveGame()
        {
            // Players and Result
            GameData.White1 = txtWhite1.Text;
            GameData.White2 = txtWhite2.Text;
            GameData.Black1 = txtBlack1.Text;
            GameData.Black2 = txtBlack2.Text;
            GameData.Tournament = txtTournament.Text;
            GameData.IsECO = chkECOCode.Checked;
            GameData.EcoCode = txtECOCode.Text;
            if (GameData.IsECO && !string.IsNullOrEmpty(GameData.EcoCode))
            {
                GameData.EcoDescription = "";
            }

            GameData.IsEloWhite = chkEloWhite.Checked;
            GameData.EloWhite = Convert.ToInt32(numEloWhite.Value);
            GameData.IsEloBlack = chkEloBlack.Checked;
            GameData.EloBlack = numEloBlack.Value;

            if (rdb1_0.Checked)
            {
                GameData.Result = "1-0";
                GameData.GameResult = this.Game.GameResult = GameResultE.WhiteWin;
            }
            else if (rdb0_1.Checked)
            {
                GameData.Result = "0-1";
                GameData.GameResult = this.Game.GameResult = GameResultE.WhiteLose;
            }
            else if (rdb12_12.Checked)
            {
                GameData.Result = "1/2-1/2";
                GameData.GameResult = this.Game.GameResult = GameResultE.Draw;
            }
            else if (cmbResult.SelectedValue != null)
            {
                GameData.Result = "Line";
                GameData.GameResult = this.Game.GameResult = GameResultE.NoResult;
            }

            GameData.IsYear = chkYear.Checked;
            GameData.Year = numYear.Value;
            GameData.IsMonth = chkMonth.Checked;
            GameData.Month = numMonth.Value;
            GameData.IsDay = chkDay.Checked;
            GameData.Day = numDay.Value;

            GameData.Save();
        }      

        #endregion

        #region Events 

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadGameData();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveGame();
            switch (GameData.Result)
            {
                case "1-0":
                    this.Game.Finish(GameResultE.WhiteWin);
                    break;
                case "0-1":
                    this.Game.Finish(GameResultE.WhiteLose);
                    break;
                case "1/2-1/2":
                    this.Game.Finish(GameResultE.Draw);
                    break;
                default:                    
                    break;
            }
            this.Game.Flags.Flags = this.Game.GameData.Flags;
            this.Game.Notations.GameResultEdited();
            this.MainForm.RefreshGameInfo();
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
            InfinityChesshelp.InfinityChessHelp.OpenHelpFile();
        }

        private void btnTournamentDetails_Click(object sender, EventArgs e)
        {
            frmTournamentData frm = new frmTournamentData();

            this.GameData.Tournament = txtTournament.Text;
            frm.GameData = this.GameData;

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                txtTournament.Text = GameData.Tournament;
            }
        }

        private void rdb1_0_Click(object sender, EventArgs e)
        {
            if (rdb1_0.Checked)
            {
                cmbResult.SelectedValue = string.Empty;
            }
        }

        private void rdb12_12_Click(object sender, EventArgs e)
        {
            if (rdb12_12.Checked)
            {
                cmbResult.SelectedValue = string.Empty;
            }
        }

        private void rdb0_1_Click(object sender, EventArgs e)
        {
            if (rdb0_1.Checked)
            {
                cmbResult.SelectedValue = string.Empty;
            }
        }

        private void cmbResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbResult.SelectedValue != null && !string.IsNullOrEmpty(cmbResult.SelectedValue.ToString()))
            {
                rdb1_0.Checked = false;
                rdb12_12.Checked = false;
                rdb0_1.Checked = false;
            }
        }

        private void numEloWhite_ValueChanged(object sender, EventArgs e)
        {
            chkEloWhite.Checked = numEloWhite.Value > 0;
        }

        private void numEloBlack_ValueChanged(object sender, EventArgs e)
        {
            chkEloBlack.Checked = numEloBlack.Value > 0;
        }

        private void numYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (numYear.Value <= numYear.Maximum)
            //{
            //    numYear.Select(3, numYear.Value.ToString().Length);
            //}
            //if (numYear.Value.ToString().Length > 4)
            //{             
            //return;
            //MessageBox.Show("Greater then 4");
            //}
        }

        private void numYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (numYear.Value <= numYear.Maximum)
            {
                numYear.Select(3, numYear.Value.ToString().Length);
            }
        }

        private void numMonth_KeyDown(object sender, KeyEventArgs e)
        {
            if (numMonth.Value <= numMonth.Maximum)
            {
                numMonth.Select(1, numMonth.Value.ToString().Length);
            }
        }

        private void numDay_KeyDown(object sender, KeyEventArgs e)
        {
            if (numDay.Value <= numDay.Maximum)
            {
                numDay.Select(1, numDay.Value.ToString().Length);
            }
        }

        private void txtECOCode_TextChanged(object sender, EventArgs e)
        {
            chkECOCode.Checked = txtECOCode.Text.Trim().Length > 0;
        }

        #endregion

    }
}