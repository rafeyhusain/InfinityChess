using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using App.Model;
using System.Reflection;
using System.Diagnostics;
namespace App.Model
{
    public class UserElo
    {
        #region Data Members
        private static DataTable userGamesRating;
        private int userID;
        private int totalGames;
        private int whiteGames;
        private int winGames;
        private int drawGames;
        private int lossesGames;
        private decimal result;
        private int nOpponent;
        private int opponentsRating;
        private int rating;
        private string ranking;
        private string date;
        #endregion

        #region Properties
        public static DataTable UserGamesRating
        {
            [DebuggerStepThrough]
            get { return userGamesRating; }
            [DebuggerStepThrough]
            set { userGamesRating = value; }
        }
        public int UserID
        {
            [DebuggerStepThrough]
            get { return userID; }
            [DebuggerStepThrough]
            set { userID = value; }
        }
        public int TotalGames
        {
            [DebuggerStepThrough]
            get { return totalGames; }
        }
        public int WhiteGames
        {
            [DebuggerStepThrough]
            get { return whiteGames; }
        }
        public int WinGames
        {
            [DebuggerStepThrough]
            get { return winGames; }
        }
        public int DrawGames
        {
            [DebuggerStepThrough]
            get { return drawGames; }
        }
        public int LossesGames
        {
            [DebuggerStepThrough]
            get { return lossesGames; }
        }
        public decimal Result
        {
            [DebuggerStepThrough]
            get { return result; }
        }
        public int NOpponent
        {
            [DebuggerStepThrough]
            get { return nOpponent; }
        }
        public int OpponentsRating
        {
            [DebuggerStepThrough]
            get { return opponentsRating; }
        }
        public int Rating
        {
            [DebuggerStepThrough]
            get { return rating; }
        }
        public string Ranking
        {
            [DebuggerStepThrough]
            get { return ranking; }
        }
        public string Date
        {
            [DebuggerStepThrough]
            get { return date; }
        }
        #endregion

        #region Constructor

        public UserElo()
        {

        }

        public UserElo(int uID)
        {
            GetUserGames(uID);
        }

        public UserElo(string uName)
        {
            GetUserGames(uName);
        }

        #endregion

        #region Methods

        #region Public Methods

        public DataTable GetUserGamesRating(int chessTypeID, int gameTypeID)
        {
            if (chessTypeID == 3)
            {
                return GetUserCentaurGamesRating(chessTypeID);
            }

            DataView dv;

            dv = new DataView(userGamesRating);
            dv.RowFilter = "ChessTypeID=" + chessTypeID + " AND GameTypeID=" + gameTypeID;
            totalGames = dv.Count;
            ranking = dv.ToTable().Rows[0]["Position"].ToString() + "/" + dv.ToTable().Rows[0]["TotalPlayers"].ToString();

            dv = new DataView(userGamesRating);
            dv.RowFilter = "WhiteUserID=" + userID + " AND ChessTypeID=" + chessTypeID + " AND GameTypeID=" + gameTypeID;
            whiteGames = dv.Count;
            
            dv = new DataView(userGamesRating);
            dv.RowFilter = "WhiteUserID=" + userID + " AND ChessTypeID=" + chessTypeID + " AND GameTypeID=" + gameTypeID + " AND GameResultID=2";
            winGames = dv.Count;
            dv = new DataView(userGamesRating);
            dv.RowFilter = "BlackUserID=" + userID + " AND ChessTypeID=" + chessTypeID + " AND GameTypeID=" + gameTypeID + " AND GameResultID=3";
            winGames = winGames + dv.Count;

            dv = new DataView(userGamesRating);
            dv.RowFilter = "ChessTypeID=" + chessTypeID + " AND GameTypeID=" + gameTypeID + " AND BlackUserID=" + userID + " AND GameResultID=4";
            drawGames = dv.Count;
            
            lossesGames = totalGames - (winGames + drawGames);
            result = System.Math.Round((decimal)(((decimal)(drawGames / 2) + winGames) / totalGames) * 100, 2);

            nOpponent = (from DataRow dr in userGamesRating.Rows
                         where (string)dr["WhiteUserID"] != userID.ToString()
                         && (string)dr["ChessTypeID"] == chessTypeID.ToString()
                         && (string)dr["GameTypeID"] == gameTypeID.ToString()
                         select (string)dr["WhiteUserID"]).Distinct().Union((from DataRow dr in userGamesRating.Rows
                                                                             where (string)dr["BlackUserID"] != userID.ToString()
                                                                             && (string)dr["ChessTypeID"] == chessTypeID.ToString()
                                                                             && (string)dr["GameTypeID"] == gameTypeID.ToString()
                                                                             select (string)dr["BlackUserID"]).Distinct()).Count();
            int whiteAvgElo = 0;
            int blackAvgElo = 0;
            int oppCount = 0;
            dv = new DataView(userGamesRating);
            dv.RowFilter = "ChessTypeID=" + chessTypeID + " AND GameTypeID=" + gameTypeID;

            foreach (DataRow item in dv.ToTable().Rows)
            {
                if (item["WhiteUserID"].ToString() == userID.ToString())
                {
                    blackAvgElo += UData.ToInt32(item["EloBlackBefore"]);
                }
                else
                {
                    whiteAvgElo += UData.ToInt32(item["EloWhiteBefore"]);
                }
                oppCount++;
            }

            if (oppCount > 0)
            {
                opponentsRating = (whiteAvgElo + blackAvgElo) / oppCount;
            }
            else
            {
                opponentsRating = 0;
            }

            dv = new DataView(userGamesRating);
            dv.RowFilter = "ChessTypeID=" + chessTypeID + " AND GameTypeID=" + gameTypeID;
            rating  = UData.ToInt32(dv.ToTable().Rows[0]["EloRating"]);
            if (!string.IsNullOrEmpty(dv.ToTable().Rows[0]["StartDate"].ToString()))
                date = Convert.ToDateTime(dv.ToTable().Rows[0]["StartDate"]).ToShortDateString();
            else
                date = DateTime.Now.ToShortDateString();
            dv = new DataView(userGamesRating);
            dv.RowFilter = "ChessTypeID=" + chessTypeID + " AND GameTypeID=" + gameTypeID;

            return dv.ToTable();
        }

        private DataTable GetUserCentaurGamesRating(int chessTypeID)
        {
            DataView dv;

            dv = new DataView(userGamesRating);
            dv.RowFilter = "ChessTypeID=" + chessTypeID;
            totalGames = dv.Count;
            ranking = dv.ToTable().Rows[0]["Position"].ToString() + "/" + dv.ToTable().Rows[0]["TotalPlayers"].ToString();

            dv = new DataView(userGamesRating);
            dv.RowFilter = "WhiteUserID=" + userID + " AND ChessTypeID=" + chessTypeID;
            whiteGames = dv.Count;

            dv = new DataView(userGamesRating);
            dv.RowFilter = "WhiteUserID=" + userID + " AND ChessTypeID=" + chessTypeID + " AND GameResultID=2";
            winGames = dv.Count;
            dv = new DataView(userGamesRating);
            dv.RowFilter = "BlackUserID=" + userID + " AND ChessTypeID=" + chessTypeID + " AND GameResultID=3";
            winGames = winGames + dv.Count;

            dv = new DataView(userGamesRating);
            dv.RowFilter = "ChessTypeID=" + chessTypeID + " AND BlackUserID=" + userID + " AND GameResultID=4";
            drawGames = dv.Count;

            lossesGames = totalGames - (winGames + drawGames);
            result = System.Math.Round((decimal)(((decimal)(drawGames / 2) + winGames) / totalGames) * 100, 2);

            nOpponent = (from DataRow dr in userGamesRating.Rows
                         where (string)dr["WhiteUserID"] != userID.ToString()
                         && (string)dr["ChessTypeID"] == chessTypeID.ToString()
                         select (string)dr["WhiteUserID"]).Distinct().Union((from DataRow dr in userGamesRating.Rows
                                                                             where (string)dr["BlackUserID"] != userID.ToString()
                                                                             && (string)dr["ChessTypeID"] == chessTypeID.ToString()
                                                                             select (string)dr["BlackUserID"]).Distinct()).Count();
            int whiteAvgElo = 0;
            int blackAvgElo = 0;
            int oppCount = 0;
            dv = new DataView(userGamesRating);
            dv.RowFilter = "ChessTypeID=" + chessTypeID;

            foreach (DataRow item in dv.ToTable().Rows)
            {
                if (item["WhiteUserID"].ToString() == userID.ToString())
                {
                    blackAvgElo += UData.ToInt32(item["EloBlackBefore"]);
                }
                else
                {
                    whiteAvgElo += UData.ToInt32(item["EloWhiteBefore"]);
                }
                oppCount++;
            }

            if (oppCount > 0)
            {
                opponentsRating = (whiteAvgElo + blackAvgElo) / oppCount;
            }
            else
            {
                opponentsRating = 0;
            }

            dv = new DataView(userGamesRating);
            dv.RowFilter = "ChessTypeID=" + chessTypeID;
            rating = UData.ToInt32(dv.ToTable().Rows[0]["EloRating"]);
            if (!string.IsNullOrEmpty(dv.ToTable().Rows[0]["StartDate"].ToString()))
                date = Convert.ToDateTime(dv.ToTable().Rows[0]["StartDate"]).ToShortDateString();
            else
                date = DateTime.Now.ToShortDateString();
            dv = new DataView(userGamesRating);
            dv.RowFilter = "ChessTypeID=" + chessTypeID;

            return dv.ToTable();
        }

        public void GetUserGames(int uID)
        {
            DataSet ds = SocketClient.GetGamesByUserID(uID);
            if (ds != null && ds.Tables.Count > 0)
            {
                UserGamesRating = ds.Tables[0];
            }
        }

        public void GetUserGames(string uName)
        {
            DataSet ds = SocketClient.GamesByUserName(uName);
            UserGamesRating = null;
            
            if (ds != null && ds.Tables.Count > 0)
            {
                UserGamesRating = null;
                UserGamesRating = ds.Tables[0];
            }

        }

        #endregion

        #region Private Methods
        private DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            // column names 
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow 
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }


        #endregion

        #endregion
    }
}
