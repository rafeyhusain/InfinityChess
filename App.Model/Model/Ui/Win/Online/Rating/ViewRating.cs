using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using App.Model;

namespace App.Model
{
    public class ViewRating
    {
        #region Data Members
        private DataTable userGamesRating;
        #endregion

        #region Properties
        public DataTable UserGamesRating
        {
            get { return userGamesRating; }
            set { userGamesRating = value; }
        }
        #endregion

        #region Constructor

        public ViewRating()
        {

        }

        #endregion

        #region Methods

        #region Public Methods

        public void GetUserGamesRating()
        {
            int totalGames = userGamesRating.Select().Count();
            int whiteGames = userGamesRating.Select("WhiteUserID=" + Ap.CurrentUserID).Count();
            int winGames = userGamesRating.Select("WhiteUserID=" + Ap.CurrentUserID + " AND GameResultID=1").Count();
            winGames = winGames + userGamesRating.Select("BlackUserID=" + Ap.CurrentUserID + " AND GameResultID=2").Count();
            int drawGames = userGamesRating.Select("WhiteUserID=" + Ap.CurrentUserID + " AND BlackUserID=" + Ap.CurrentUserID + " AND GameResultID=4").Count();
            int lossesGames = totalGames - (winGames + drawGames);
            float res = ((float)(((float)drawGames / 2) + winGames) / totalGames) * 100;
            int nOpponent = (from DataRow dr in userGamesRating.Rows
                             where (string)dr["WhiteUserID"] != Ap.CurrentUserID.ToString()
                             select (string)dr["WhiteUserID"]).Distinct().Union((from DataRow dr in userGamesRating.Rows
                                                                                 where (string)dr["WhiteUserID"] != Ap.CurrentUserID.ToString()
                                                                                 select (string)dr["WhiteUserID"]).Distinct()).Count();
            int rating = UData.ToInt32(userGamesRating.Select().FirstOrDefault()["EloRating"].ToString());
            string str = (from DataRow dr in userGamesRating.Rows
                           orderby dr["StartDate"] descending
                       select (string)dr["StartDate"]).FirstOrDefault();
        }

        #endregion

        #region Private Methods

        #endregion

        #endregion
    }
}
