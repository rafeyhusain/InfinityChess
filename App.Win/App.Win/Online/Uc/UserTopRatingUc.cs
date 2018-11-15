using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;
using App.Win;

namespace InfinityChess.Online.Uc
{
    public partial class UserTopRatingUc : UserControl
    {
        #region Variables
        GameType gameType;
        ChessTypeE chessType;
        int userID = 0;
        string userName = string.Empty;
        const string HumanBullet = "Top List Bullet";
        const string HumanBiltz = "Top List Biltz";
        const string HumanLong = "Top List Long";
        const string HumanRapid = "Top List Rapid";
        const string EngineBullet = "Top List Bullet Computer Chess";
        const string EngineComputer = "Top List Computer Chess";
        const string EngineSlow = "Top List Slow Computer Chess";
        const string Centrues = "Top List Centures";
        const string Chess960 = "Top List Chess 960";
        const string TwinChess = "Top List Twin Chess";
        const string OutChatrang = "Top List Out Chatrang";

        //public int UserID { get { return userID; } set { userID = value; } }
        //public string UserName { get { return userName; } set { userName = value; } }

        #endregion

        #region Constructor
        public UserTopRatingUc()
        {
            InitializeComponent();
        }

        
        #endregion               

        

        #region Load Event
        private void UserTopRatingUc_Load(object sender, EventArgs e)
        {
            gvUserRating.AutoGenerateColumns = false;
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }
        
        #endregion

        #region Method        
        
        #region Get User Rating function
        void GetUserRating()
        {
            DataSet ds = SocketClient.GetUsersByGameType(chessType, gameType); 
            gvUserRating.DataSource = null;
            if (ds.Tables.Count > 0)
            {
                this.btnPicture.Enabled = true;
                gvUserRating.DataSource = ds.Tables[0];
            }
            else
                this.btnPicture.Enabled = false;
        } 
        #endregion
        
        #region Game and Chess Type
        void GetGameType(string strGameType)
        {
            switch (strGameType)
            {
                case HumanBullet:
                    chessType = ChessTypeE.Human;
                    gameType = GameType.Bullet;
                    break;
                case HumanBiltz:
                    chessType = ChessTypeE.Human;
                    gameType = GameType.Blitz;
                    break;
                case HumanLong:
                    chessType = ChessTypeE.Human;
                    gameType = GameType.Long;
                    break;
                case HumanRapid:
                    chessType = ChessTypeE.Human;
                    gameType = GameType.Rapid;
                    break;
                case EngineBullet:
                    chessType = ChessTypeE.Engine;
                    gameType = GameType.Bullet;
                    break;
                case EngineComputer:
                    chessType = ChessTypeE.Engine;
                    gameType = GameType.Blitz;
                    break;
                case EngineSlow:
                    chessType = ChessTypeE.Engine;
                    gameType = GameType.Long;
                    break;
                case Centrues:
                    break;

                default:
                    break;
            }
        } 
        #endregion

        void ShowUser(int userID)
        {
            PersonalInformation frm = new PersonalInformation();
            frm.UserID = userID;
            frm.ShowDialog();
        }

        void ViewRatingUser(int userID)
        {
            if (!Ap.CurrentUser.IsGuest)
            {
                RatedGameResult frm = new RatedGameResult();
                frm.UserID = userID;
                frm.ShowDialog();
            }
        }

        #endregion

        #region List box click Event
        private void lbGameType_Click(object sender, EventArgs e)
        {
            GetGameType(lbGameType.SelectedItem.ToString());
            GetUserRating();

        }
        
        #endregion

        #region Grid Events      

        private void gvUserRating_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (gvUserRating.Rows[e.RowIndex].Cells[1].Value != null)
            {
                userID = Convert.ToInt32(gvUserRating.Rows[e.RowIndex].Cells[1].Value);
            }
            ShowUser(userID);
        }
        
        #endregion

        private void btnPicture_Click(object sender, EventArgs e)
        {
            ShowUser(userID);
        }      

        private void btnViewRating_Click(object sender, EventArgs e)
        {
            ViewRatingUser(userID);
        }        

        private void gvUserRating_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             if (gvUserRating.Rows[e.RowIndex].Cells[1].Value != null)
             {
                 userID = Convert.ToInt32(gvUserRating.Rows[e.RowIndex].Cells[1].Value);
             }
        }

    }
}
