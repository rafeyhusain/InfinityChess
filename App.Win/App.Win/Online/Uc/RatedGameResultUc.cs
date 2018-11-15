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

namespace App.Win
{
    public partial class RatedGameResultUc : UserControl
    {
        #region Properties
        private UserElo userElo;
        public UserElo UserElo
        {
            [System.Diagnostics.DebuggerStepThrough]
            set { userElo = value; }
            [System.Diagnostics.DebuggerStepThrough]
            get { return userElo; }
        }

        private int userID;
        private string userName;

        public int UserID
        {
            [System.Diagnostics.DebuggerStepThrough]
            set { userID = value; }
            [System.Diagnostics.DebuggerStepThrough]
            get { return userID; }
        }
        public string UserName
        {
            [System.Diagnostics.DebuggerStepThrough]
            set { userName = value; }
            [System.Diagnostics.DebuggerStepThrough]
            get { return userName; }
        }

        public int chessTypeID;
        public int gameTypeID;
        
        #endregion
        
        public RatedGameResultUc()
        {
            InitializeComponent();
        }

        private void RatedGameResultUc_Load(object sender, EventArgs e)
        {
            //SetRating();
        }

        public void SetRating()
        {
            dataGridView1.AutoGenerateColumns = false;
            if (userElo != null)
            {
                UserElo ue = new UserElo();
                //ue = userElo;
                //userElo.UserGamesRating = gameRatedTable;
                ue.UserID = userID;
                dataGridView1.DataSource = null;
                dataGridView1.DataSource= ue.GetUserGamesRating(chessTypeID, gameTypeID);
                lblTotalGames.Text = ue.TotalGames.ToString();
                lblStoredGame.Text = ue.TotalGames.ToString();
                lblWhite.Text = ue.WhiteGames.ToString();
                lblWins.Text = ue.WinGames.ToString();
                lblDraws.Text = ue.DrawGames.ToString();
                lblLosses.Text = ue.LossesGames.ToString();
                lblResult.Text = ue.Result.ToString() + " %";
                lblOpponentElo.Text = ue.OpponentsRating.ToString();
                lblNOpponents.Text = ue.NOpponent.ToString();
                lblRating.Text = ue.Rating.ToString();
                if (chessTypeID == 3)
                {
                    label11.Visible = false;
                    lblRanking.Visible = false;
                }
                else
                {
                    lblRanking.Text = ue.Ranking;
                }
                lblDate.Text = ue.Date.ToString();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5 || e.ColumnIndex == 8 || e.ColumnIndex == 9 || e.ColumnIndex == 10 || e.ColumnIndex == 13)
            {
                if (dataGridView1["WhiteUserID", e.RowIndex].Value.ToString() != userID.ToString())
                {
                    switch (e.ColumnIndex)
                    {
                        case 5:
                            e.Value = dataGridView1["WhiteUserName", e.RowIndex].Value;
                            break;
                        case 8:
                            e.Value = dataGridView1["EloWhite", e.RowIndex].Value;
                            break;
                        case 9:
                            if (dataGridView1["GameResultID", e.RowIndex].Value != null)
                            {
                                string result = string.Empty;
                                GameResultE gameResult = (GameResultE)UData.ToInt32(dataGridView1["GameResultID", e.RowIndex].Value.ToString());
                                switch (gameResult)
                                {
                                    case GameResultE.None:
                                        break;
                                    case GameResultE.InProgress:
                                        break;
                                    case GameResultE.WhiteWin:
                                        result = "0";
                                        break;
                                    case GameResultE.WhiteLose:
                                        result = "1";
                                        break;
                                    case GameResultE.Draw:
                                        result = "1/2";
                                        break;
                                    case GameResultE.Absent:
                                        break;
                                    case GameResultE.NoResult:
                                        break;
                                    case GameResultE.WhiteBye:
                                        result = "1";
                                        break;
                                    case GameResultE.BlackBye:
                                        result = "0";
                                        break;
                                    case GameResultE.ForcedWhiteWin:
                                        result = "0";
                                        break;
                                    case GameResultE.ForcedWhiteLose:
                                        result = "1";
                                        break;
                                    case GameResultE.ForcedDraw:
                                        result = "1/2";
                                        break;
                                    default:
                                        break;
                                }
                                e.Value = result;
                            }
                            break;
                        case 10:
                            e.Value = "White";
                            break;
                        case 13:
                            if (dataGridView1["WhiteUserCountry", e.RowIndex].Value != null && dataGridView1["WhiteUserCountry", e.RowIndex].Value.ToString() != "" && dataGridView1["WhiteUserCountry", e.RowIndex].Value.ToString() != "0")
                            {
                                Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Flags\" + dataGridView1["WhiteUserCountry", e.RowIndex].Value + ".PNG");
                                e.Value = item;
                            }
                            else
                            {
                                Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Flags\244.PNG");
                                e.Value = item;
                            }
                            break;
                    }
                }
                else
                {
                    switch (e.ColumnIndex)
                    {
                        case 5:
                            e.Value = dataGridView1["BlackUserName", e.RowIndex].Value;
                            break;
                        case 8:
                            e.Value = dataGridView1["EloBlack", e.RowIndex].Value;
                            break;
                        case 9:
                            if (dataGridView1["GameResultID", e.RowIndex].Value != null)
                            {
                                string result = string.Empty;
                                GameResultE gameResult = (GameResultE)UData.ToInt32(dataGridView1["GameResultID", e.RowIndex].Value.ToString());
                                switch (gameResult)
                                {
                                    case GameResultE.None:
                                        break;
                                    case GameResultE.InProgress:
                                        break;
                                    case GameResultE.WhiteWin:
                                        result = "1";
                                        break;
                                    case GameResultE.WhiteLose:
                                        result = "0";
                                        break;
                                    case GameResultE.Draw:
                                        result = "1/2";
                                        break;
                                    case GameResultE.Absent:
                                        break;
                                    case GameResultE.NoResult:
                                        break;
                                    case GameResultE.WhiteBye:
                                        result = "0";
                                        break;
                                    case GameResultE.BlackBye:
                                        result = "1";
                                        break;
                                    case GameResultE.ForcedWhiteWin:
                                        result = "1";
                                        break;
                                    case GameResultE.ForcedWhiteLose:
                                        result = "0";
                                        break;
                                    case GameResultE.ForcedDraw:
                                        result = "1/2";
                                        break;
                                    default:
                                        break;
                                }
                                e.Value = result;
                            }
                            break;
                        case 10:
                            e.Value = "Black";
                            break;
                        case 13:
                            if (dataGridView1["BlackUserCountry", e.RowIndex].Value != null && dataGridView1["BlackUserCountry", e.RowIndex].Value.ToString() != "" && dataGridView1["BlackUserCountry", e.RowIndex].Value.ToString() != "0")
                            {
                                Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Flags\" + dataGridView1["BlackUserCountry", e.RowIndex].Value + ".PNG");
                                e.Value = item;
                            }
                            else
                            {
                                Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Flags\244.PNG");
                                e.Value = item;
                            }
                            break;
                    }
                }
            }
        }

       
    }
}
