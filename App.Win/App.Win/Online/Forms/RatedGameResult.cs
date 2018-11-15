using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;
using InfinityChess.WinForms;
using InfinityChess.InfinityChesshelp;

namespace App.Win
{
    public partial class RatedGameResult : BaseWinForm
    {
        #region Properties
        private int userID;
        public int UserID
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return userID; }
            [System.Diagnostics.DebuggerStepThrough]
            set { userID = value; }
        }
        bool isRated = false;
        private string userName;
        public string UserName
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return userName; }
            [System.Diagnostics.DebuggerStepThrough]
            set { userName = value; }
        } 
        #endregion

        public RatedGameResult()
        {
            InitializeComponent();
        }

        private void RatedGameResult_Load(object sender, EventArgs e)
        {
            txtUserName.Text = this.userName;
            LoadRating(this.userName);
            this.Text = "'" + txtUserName.Text + "'" + " - Rated Game Result";
        }

        #region Helper
        private void LoadRating(string userName)
        {
            ProgressForm frmProgress = ProgressForm.Show(this, "Loading Rating...");

            UserElo ue = null;
            
            if (userName == "")
            {
                ue = new UserElo(userID);
            }
            else
            {
                ue = new UserElo(userName);
            }

            DataTable dt = UserElo.UserGamesRating;
            
            int tabs = tabControl1.TabCount;
            
            tabs--;

            if (dt != null && dt.Rows.Count > 0)
            {
                isRated = true;
                this.userID = Convert.ToInt32(dt.Rows[0]["UserID"]);
                this.userName = dt.Rows[0]["UserName"].ToString();

                tabControl1.TabPages.RemoveAt(tabs);

                var gameTypes = (from DataRow dr in dt.Rows
                                 select new { ChessTypeID = dr["ChessTypeID"], GameTypeID = dr["GameTypeID"] }).Distinct();

                var centaurGameType = (from DataRow dr in dt.Rows
                                       select new { ChessTypeID = 3 }).Distinct();

                int ChessTypeID = 0;
                int GameTypeID = 0;
                bool isCentaurTabOpened = false;

                foreach (var item in gameTypes)
                {
                    ChessTypeID = Convert.ToInt32(item.ChessTypeID);
                    GameTypeID = Convert.ToInt32(item.GameTypeID);
                    ChessTypeE chessType = (ChessTypeE)ChessTypeID;
                    GameType gameType = (GameType)GameTypeID;

                    #region ChessType
                    switch (chessType)
                    {
                        case ChessTypeE.Human:
                            switch (gameType)
                            {
                                case GameType.Bullet:
                                    tabControl1.TabPages.Add("Bullet");
                                    RatedGameResultUc ratedGameResultUc1 = new RatedGameResultUc();
                                    ratedGameResultUc1.UserID = UserID;
                                    ratedGameResultUc1.chessTypeID = ChessTypeID;
                                    ratedGameResultUc1.gameTypeID = GameTypeID;
                                    ratedGameResultUc1.UserElo = ue;
                                    ratedGameResultUc1.SetRating();
                                    tabControl1.TabPages[tabs].Controls.Add(ratedGameResultUc1);
                                    tabs++;
                                    break;
                                case GameType.Blitz:
                                    tabControl1.TabPages.Add("Blitz");
                                    RatedGameResultUc ratedGameResultUc2 = new RatedGameResultUc();
                                    ratedGameResultUc2.UserID = UserID;
                                    ratedGameResultUc2.chessTypeID = ChessTypeID;
                                    ratedGameResultUc2.gameTypeID = GameTypeID;
                                    ratedGameResultUc2.UserElo = ue;
                                    ratedGameResultUc2.SetRating();
                                    tabControl1.TabPages[tabs].Controls.Add(ratedGameResultUc2);
                                    tabs++;
                                    break;
                                case GameType.Rapid:
                                    tabControl1.TabPages.Add("Rapid");
                                    RatedGameResultUc ratedGameResultUc3 = new RatedGameResultUc();
                                    ratedGameResultUc3.UserID = UserID;
                                    ratedGameResultUc3.chessTypeID = ChessTypeID;
                                    ratedGameResultUc3.gameTypeID = GameTypeID;
                                    ratedGameResultUc3.UserElo = ue;
                                    ratedGameResultUc3.SetRating();
                                    tabControl1.TabPages[tabs].Controls.Add(ratedGameResultUc3);
                                    tabs++;
                                    break;
                                case GameType.Long:
                                    tabControl1.TabPages.Add("Long");
                                    RatedGameResultUc ratedGameResultUc4 = new RatedGameResultUc();
                                    ratedGameResultUc4.UserID = UserID;
                                    ratedGameResultUc4.chessTypeID = ChessTypeID;
                                    ratedGameResultUc4.gameTypeID = GameTypeID;
                                    ratedGameResultUc4.UserElo = ue;
                                    ratedGameResultUc4.SetRating();
                                    tabControl1.TabPages[tabs].Controls.Add(ratedGameResultUc4);
                                    tabs++;
                                    break;
                            }
                            break;
                        case ChessTypeE.Engine:
                            switch (gameType)
                            {
                                case GameType.Bullet:
                                    tabControl1.TabPages.Add("Computer/Bullet");
                                    RatedGameResultUc ratedGameResultUc5 = new RatedGameResultUc();
                                    ratedGameResultUc5.UserID = UserID;
                                    ratedGameResultUc5.chessTypeID = ChessTypeID;
                                    ratedGameResultUc5.gameTypeID = GameTypeID;
                                    ratedGameResultUc5.UserElo = ue;
                                    ratedGameResultUc5.SetRating();
                                    tabControl1.TabPages[tabs].Controls.Add(ratedGameResultUc5);
                                    tabs++;
                                    break;
                                case GameType.Blitz:
                                    tabControl1.TabPages.Add("Computer/Blitz");
                                    RatedGameResultUc ratedGameResultUc6 = new RatedGameResultUc();
                                    ratedGameResultUc6.UserID = UserID;
                                    ratedGameResultUc6.chessTypeID = ChessTypeID;
                                    ratedGameResultUc6.gameTypeID = GameTypeID;
                                    ratedGameResultUc6.UserElo = ue;
                                    ratedGameResultUc6.SetRating();
                                    tabControl1.TabPages[tabs].Controls.Add(ratedGameResultUc6);
                                    tabs++;
                                    break;
                                case GameType.Rapid:
                                    tabControl1.TabPages.Add("Computer/Rapid");
                                    RatedGameResultUc ratedGameResultUc7 = new RatedGameResultUc();
                                    ratedGameResultUc7.UserID = UserID;
                                    ratedGameResultUc7.chessTypeID = ChessTypeID;
                                    ratedGameResultUc7.gameTypeID = GameTypeID;
                                    ratedGameResultUc7.UserElo = ue;
                                    ratedGameResultUc7.SetRating();
                                    tabControl1.TabPages[tabs].Controls.Add(ratedGameResultUc7);
                                    tabs++;
                                    break;
                                case GameType.Long:
                                    tabControl1.TabPages.Add("Computer/Long");
                                    RatedGameResultUc ratedGameResultUc8 = new RatedGameResultUc();
                                    ratedGameResultUc8.UserID = UserID;
                                    ratedGameResultUc8.chessTypeID = ChessTypeID;
                                    ratedGameResultUc8.gameTypeID = GameTypeID;
                                    ratedGameResultUc8.UserElo = ue;
                                    ratedGameResultUc8.SetRating();
                                    tabControl1.TabPages[tabs].Controls.Add(ratedGameResultUc8);
                                    tabs++;
                                    break;
                            }
                            break;
                        case ChessTypeE.Centaur:
                            if (!isCentaurTabOpened)
                            {
                                tabControl1.TabPages.Add("Centaur");
                                RatedGameResultUc ratedGameResultUc9 = new RatedGameResultUc();
                                ratedGameResultUc9.UserID = UserID;
                                ratedGameResultUc9.chessTypeID = 3;
                                ratedGameResultUc9.gameTypeID = 0;
                                ratedGameResultUc9.UserElo = ue;
                                ratedGameResultUc9.SetRating();
                                tabControl1.TabPages[tabs].Controls.Add(ratedGameResultUc9);
                                tabs++;
                                isCentaurTabOpened = true;
                            }
                            break;
                        case ChessTypeE.Correspondence:
                            tabControl1.TabPages.Add("Correspondence");
                            RatedGameResultUc ratedGameResultUc10 = new RatedGameResultUc();
                            ratedGameResultUc10.UserID = UserID;
                            ratedGameResultUc10.chessTypeID = ChessTypeID;
                            ratedGameResultUc10.gameTypeID = GameTypeID;
                            ratedGameResultUc10.UserElo = ue;
                            ratedGameResultUc10.SetRating();
                            tabControl1.TabPages[tabs].Controls.Add(ratedGameResultUc10);
                            tabs++;
                            break;
                        default:
                            break;
                    }
                } 
                    #endregion
            }
            else
            {
                RatedGameResultUc ratedGameResultUc = new RatedGameResultUc();
                tabControl1.TabPages[tabs].Controls.Add(ratedGameResultUc);
                isRated = false;
            }

            frmProgress.Close();
        } 
        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        ProgressForm frmProgress;
        private void btnRating_Click(object sender, EventArgs e)
        {
            frmProgress = ProgressForm.Show(this, "Searching...");

            int count = tabControl1.TabPages.Count;
            for (int i = count-1; i >= 0; i--)
			{
                tabControl1.TabPages.RemoveAt(i);
			}
            TabPage tp = new TabPage();
            tp.Text = "Blitz";
            tp.UseVisualStyleBackColor = false;
            tabControl1.TabPages.Add(tp);
            LoadRating(txtUserName.Text);
            this.Text = "'" + txtUserName.Text + "'" + " - Rated Game Result.";
            frmProgress.Close();
            if (!isRated)
                MessageForm.Show(this,MsgE.InfoRating, txtUserName.Text);
            
        }
        private void btnPicture_Click(object sender, EventArgs e)
        {
            //this.ParentForm.DialogResult = DialogResult.OK;
            //this.ParentForm.Close();
            PersonalInformation frm = new PersonalInformation();
            frm.UserID = this.userID;
            frm.UserName = this.txtUserName.Text;
            frm.ShowDialog();
        }
        public override string HelpTopicId
        {
            get { return "200"; }
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            Ap.Help(this, HelpTopicIdE.RatedGameResult);
        }
    }
}
