using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ChessLibrary;
using App.Model;
using InfinityChess.WinForms;

namespace App.Win
{
    public partial class GameSearch : Form
    {
        #region Data Member
        public Game Game = null;
        public MainForm MainForm;
        App.Model.GameSearch gameSearch;
        TabPage tabPageControl;
        private const string positionControl = "PositionSetupUc";
        PositionSetupUc positionSetup;
        #endregion

        #region Properties
        public App.Model.GameSearch GameSearchData
        {
            get
            {
                if (gameSearch == null)
                {
                    gameSearch = new App.Model.GameSearch();
                }
                return gameSearch;
            }

            private set { gameSearch = value; }
        } 
        #endregion

        #region Ctor
        public GameSearch(Game game, MainForm mainForm)
        {
            InitializeComponent();
            this.Game = game;
            this.MainForm = mainForm;
            positionSetup = new PositionSetupUc(this.Game, this.MainForm);
            positionSetup.OnBoardFenSet += new PositionSetupUc.BoardFenSetHandler(positionSetup_OnBoardFenSet);
            tabPageControl = tabControl1.TabPages["position"];
            tabPageControl.Controls.Add(positionSetup);
            LoadGameSearch();
        }

        #endregion

        #region EventHandlers
        private void chkYear_CheckedChanged(object sender, EventArgs e)
        {
            if (chkYear.Checked)
                chkGameData.Checked = true;
            else if (!GameDataIncludedInSearch())
            {
                chkGameData.Checked = false;
            }

        }
        private void chkEco_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEco.Checked)
                chkGameData.Checked = true;
            else if (!GameDataIncludedInSearch())
            {
                chkGameData.Checked = false;
            }
        }
        private void chkMoves_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMoves.Checked)
                chkGameData.Checked = true;
            else if (!GameDataIncludedInSearch())
            {
                chkGameData.Checked = false;
            }
        }
        private void chkWin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWin.Checked)
                chkGameData.Checked = true;
            else if (!GameDataIncludedInSearch())
            {
                chkGameData.Checked = false;
            }
        }
        private void chkDraw_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDraw.Checked)
                chkGameData.Checked = true;
            else if (!GameDataIncludedInSearch())
            {
                chkGameData.Checked = false;
            }
        }
        private void chkLost_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLost.Checked)
                chkGameData.Checked = true;
            else if (!GameDataIncludedInSearch())
            {
                chkGameData.Checked = false;
            }
        }
        private void chkMate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMate.Checked)
                chkGameData.Checked = true;
            else if (!GameDataIncludedInSearch())
            {
                chkGameData.Checked = false;
            }
        }
        private void chkStalem_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStalem.Checked)
                chkGameData.Checked = true;
            else if (!GameDataIncludedInSearch())
            {
                chkGameData.Checked = false;
            }
        }
        private void chkCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCheck.Checked)
                chkGameData.Checked = true;
            else if (!GameDataIncludedInSearch())
            {
                chkGameData.Checked = false;
            }
        }
        private void txtWhite1_TextChanged(object sender, EventArgs e)
        {
            if (txtWhite1.Text != string.Empty)
            {
                chkGameData.Checked = true;
            }
             else if (!GameDataIncludedInSearch())
            {
                chkGameData.Checked = false;
            }
       
        }
        private void txtWhite2_TextChanged(object sender, EventArgs e)
        {
            if (txtWhite2.Text != string.Empty)
            {
                chkGameData.Checked = true;
            }
            else if (!GameDataIncludedInSearch())
            {
                chkGameData.Checked = false;
            }
        }
        private void txtBlack1_TextChanged(object sender, EventArgs e)
        {
            if (txtBlack1.Text != string.Empty)
            {
                chkGameData.Checked = true;
            }
            else if (!GameDataIncludedInSearch())
            {
                chkGameData.Checked = false;
            }
        }
        private void txtBlack2_TextChanged(object sender, EventArgs e)
        {
            if (txtBlack2.Text != string.Empty)
            {
                chkGameData.Checked = true;
            }
            else if (!GameDataIncludedInSearch())
            {
                chkGameData.Checked = false;
            }
        }
        private void txtTournament_TextChanged(object sender, EventArgs e)
        {
            if (txtTournament.Text != string.Empty)
            {
                chkGameData.Checked = true;
            }
            else if (!GameDataIncludedInSearch())
            {
                chkGameData.Checked = false;
            }
        }
        private void rdbtnOne_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnOne.Checked)
            {
                chkGameData.Checked = true;
            }
            else if (!GameDataIncludedInSearch())
            {
                chkGameData.Checked = false;
            }
        }

        private void rdbtnBoth_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnBoth.Checked)
            {
                chkGameData.Checked = true;
            }
            else if (!GameDataIncludedInSearch())
            {
                chkGameData.Checked = false;
            }
        }

        private void rdbtnAverage_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnAverage.Checked)
            {
                chkGameData.Checked = true;
            }
            else if (!GameDataIncludedInSearch())
            {
                chkGameData.Checked = false;
            }
        }
    
        private void numYear1_ValueChanged(object sender, EventArgs e)
        {
            chkYear.Checked = true;
        }
        private void numYear2_ValueChanged(object sender, EventArgs e)
        {
            chkYear.Checked = true;
        }
        private void txtEco1_TextChanged(object sender, EventArgs e)
        {
            chkEco.Checked = true;
        }
        private void txtEco2_TextChanged(object sender, EventArgs e)
        {
            chkEco.Checked = true;
        }
        private void numMoves1_ValueChanged(object sender, EventArgs e)
        {
            chkMoves.Checked = true;
        }
        private void numMoves2_ValueChanged(object sender, EventArgs e)
        {
            chkMoves.Checked = true;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (chkPosition.Checked || chkGameData.Checked)
            {
                SaveGame();
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetGameData();
        }
        private void chkPosition_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPosition.Checked)
            {
                bool isValid = this.Game.GameValidator.IsValidFen(positionSetup.GetCompleteFEN());
                if (isValid)
                {
                    btnOK.Enabled = chkPosition.Checked = isValid;
                }
                else
                {
                    chkPosition.Checked = isValid;
                }
            }
            else
            {
                if (!chkGameData.Checked)
                {
                    btnOK.Enabled = chkPosition.Checked;
                }
            }
        }
        private void chkGameData_CheckedChanged(object sender, EventArgs e)
        {
            IsValidSearchCriterea();
        }
        void positionSetup_OnBoardFenSet(object sender, EventArgs args)
        {
            bool isValid = this.Game.GameValidator.IsValidFen(positionSetup.GetCompleteFEN());
            if (isValid)
            {
                btnOK.Enabled = chkPosition.Checked = isValid;
            }
            else
            {
                chkPosition.Checked = isValid;
            }
        }
     
        #endregion

        #region Load/Save/Reset GameSearch
        private void LoadGameSearch()
        {
            txtWhite1.Text = GameSearchData.White1;
            txtWhite2.Text = GameSearchData.White2;
            txtBlack1.Text = GameSearchData.Black1;
            txtBlack2.Text = GameSearchData.Black2;
            txtTournament.Text = GameSearchData.Tournament;
            try
            {
                numYear1.Value = GameSearchData.Year1;
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                numYear1.Value = 1600;
            }
            try
            {
                numYear2.Value = GameSearchData.Year2;
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                numYear2.Value = 2010;
            }
            chkYear.Checked = GameSearchData.IsYear;
            txtEco1.Text = GameSearchData.EcoCode1;
            txtEco2.Text = GameSearchData.EcoCode2;
            chkEco.Checked = GameSearchData.IsECO;
            try
            {
                numMoves1.Value = GameSearchData.Moves1;
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                numMoves1.Value = 1;
            }
            try
            {
               numMoves2.Value = GameSearchData.Moves2;
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                numMoves2.Value = 22;
            }
            chkMoves.Checked = GameSearchData.IsMoves;
            try
            {
                numElo1.Value = GameSearchData.Elo1;
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                numElo1.Value = 600;
            }
            try
            {
                numElo2.Value = GameSearchData.Elo2;
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                numElo2.Value = 4000;
            }
            rdbtnNone.Checked = GameSearchData.IsNoneElo;
            rdbtnOne.Checked = GameSearchData.IsOneElo;
            rdbtnBoth.Checked = GameSearchData.IsBothElo;
            rdbtnAverage.Checked = GameSearchData.IsAverageElo;
            chkWin.Checked = GameSearchData.IsWin;
            chkLost.Checked = GameSearchData.IsLost;
            chkDraw.Checked = GameSearchData.IsDraw;
            chkMate.Checked = GameSearchData.IsMated;
            chkStalem.Checked = GameSearchData.IsStalem;
            chkCheck.Checked = GameSearchData.IsCheck;
            chkGameData.Checked = GameSearchData.IsGameDataIncluded;
            chkPosition.Checked = GameSearchData.IsPositonIncluded;
        }
        private void SaveGame()
        {
            bool isEco = chkEco.Checked;
            bool isMoves = chkMoves.Checked;
            bool isYear = chkYear.Checked; 
            GameSearchData.White1 = txtWhite1.Text;
            GameSearchData.White2 = txtWhite2.Text;
            GameSearchData.Black1 = txtBlack1.Text;
            GameSearchData.Black2 = txtBlack2.Text;
            GameSearchData.Tournament = txtTournament.Text;
            GameSearchData.Year1 = numYear1.Value;
            GameSearchData.Year2 = numYear2.Value;
            GameSearchData.IsYear = isYear;
            GameSearchData.EcoCode1 = FormattedEco(txtEco1.Text);
            GameSearchData.EcoCode2 = FormattedEco(txtEco2.Text);
            GameSearchData.IsECO = isEco;
            GameSearchData.Moves1 = numMoves1.Value;
            GameSearchData.Moves2 = numMoves2.Value;
            GameSearchData.IsMoves = isMoves;
            GameSearchData.Elo1 = FormattedElo(numElo1.Value);
            GameSearchData.Elo2 = FormattedElo(numElo2.Value);
            GameSearchData.IsNoneElo = rdbtnNone.Checked;
            GameSearchData.IsOneElo = rdbtnOne.Checked;
            GameSearchData.IsBothElo = rdbtnBoth.Checked;
            GameSearchData.IsAverageElo = rdbtnAverage.Checked;
            GameSearchData.IsWin = chkWin.Checked;
            GameSearchData.IsLost = chkLost.Checked;
            GameSearchData.IsDraw = chkDraw.Checked;
            GameSearchData.IsMated = chkMate.Checked;
            GameSearchData.IsStalem = chkStalem.Checked;
            GameSearchData.IsCheck = chkCheck.Checked;
            PositionSetupUc positionSetupUC = tabPageControl.Controls[positionControl] as PositionSetupUc;
            GameSearchData.BoardFen = positionSetupUC.GetBoardFEN();
            GameSearchData.IsGameDataIncluded = chkGameData.Checked;
            GameSearchData.IsPositonIncluded = chkPosition.Checked;
            GameSearchData.Save();
       }
        private void ResetGameData()
        {
            txtWhite1.Text = string.Empty;
            txtWhite2.Text = string.Empty;
            txtBlack1.Text = string.Empty;
            txtBlack2.Text = string.Empty;
            txtTournament.Text = string.Empty;
            numYear1.Value = Convert.ToDecimal(System.DateTime.Now.Year);
            numYear2.Value = Convert.ToDecimal(System.DateTime.Now.Year);
            chkYear.Checked = false;
            txtEco1.Text = "A00";
            txtEco2.Text = "E99/99";
            chkEco.Checked = false;
            numMoves1.Value = 1;
            numMoves2.Value = 22;
            chkMoves.Checked = false;
            chkWin.Checked = false;
            chkLost.Checked = false;
            chkMate.Checked = false;
            chkDraw.Checked = false;
            chkStalem.Checked = false;
            chkCheck.Checked = false;
            chkGameData.Checked = false;
            rdbtnBoth.Checked = false;
            rdbtnOne.Checked = false;
            rdbtnAverage.Checked = false;
            rdbtnNone.Checked = true;
        }
        #endregion 

        #region Helper Methods
        private string FormattedEco(string eco)
        {
            string formattedEco = string.Empty;
            if (!string.IsNullOrEmpty(eco))
            {
                if (eco.Length > 6)
                {
                    eco = eco.Remove(6);
                }

                for (int counter = 0; counter < eco.Length; counter++)
                {
                    if (counter == 0)
                    {
                        char letter = eco[counter];
                        int characterCode = (int)letter;
                        if ((characterCode >= 65 && characterCode <= 69) || (characterCode >= 97 && characterCode <=101))
                        {
                            formattedEco = letter.ToString().ToUpper();
                        }
                        else
                        {
                            return string.Empty;
                        }
                    }

                    if (counter > 0 && counter < 3)
                    {
                        if (!char.IsDigit(eco, counter))
                        {
                            formattedEco = formattedEco[0].ToString() + "00";
                            return formattedEco;
                        }
                        else
                        {
                            formattedEco += eco[counter].ToString();
                        }
                    }

                    if (counter == 3 && counter < eco.Length-1)
                    { 
                            formattedEco += "/"; 
                    }
                    if (counter == 4)
                    {
                        if (counter < eco.Length - 1)
                        {
                            if (!char.IsDigit(eco, counter))
                            {
                                formattedEco = formattedEco.Remove(3);
                                return formattedEco;
                            }
                            else
                            {
                                formattedEco += eco[counter].ToString();
                            }
                        }
                        else
                        {
                            if (!char.IsDigit(eco, counter))
                            {
                                formattedEco = formattedEco.Remove(3);
                                return formattedEco;
                            }
                            else
                            {
                                formattedEco += eco[counter].ToString() + "0";
                                return formattedEco;
                            }
                        }
                    }
                    if (counter == 5)
                    {
                        if (!char.IsDigit(eco, counter))
                        {
                            formattedEco += "0" ;
                            return formattedEco;
                        }
                        else
                        {
                            formattedEco += eco[counter].ToString(); 
                            return formattedEco;
                        }
                    }
                  }
            
            }
            return formattedEco;
        }
        private decimal FormattedElo(decimal elo)
        {
            return elo;
        }
        private bool GameDataIncludedInSearch()
        {
            List<bool> items = new List<bool>();

            items.Add(txtWhite1.Text != string.Empty);
            items.Add(txtWhite2.Text != string.Empty);
            items.Add(txtBlack1.Text != string.Empty);
            items.Add(txtBlack2.Text != string.Empty);
            items.Add(txtTournament.Text != string.Empty);
            items.Add(chkYear.Checked);
            items.Add(chkEco.Checked);
            items.Add(chkMoves.Checked);
            items.Add(chkWin.Checked);
            items.Add(chkLost.Checked);
            items.Add(chkDraw.Checked);
            items.Add(chkMate.Checked);
            items.Add(chkStalem.Checked);
            items.Add(chkCheck.Checked);
            items.Add(rdbtnOne.Checked);
            items.Add(rdbtnBoth.Checked);
            items.Add(rdbtnAverage.Checked);
            return items.Contains(true);
        }
        private void IsValidSearchCriterea()
        {
            if (!chkPosition.Checked && !chkGameData.Checked)
            {
                btnOK.Enabled = false;
            }
            else
            {
                btnOK.Enabled = true;
            }
        }

        #endregion

     
    }
}
