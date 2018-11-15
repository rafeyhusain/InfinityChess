// (c) Copyright RafeySoft, Karachi Pakistan. http://rafeysoft.com
// This source is subject to following License:
// http://rafeysoft.com/Web/Page/ItemEdit.aspx?sid=29&lid=4&cid=23&iid=2143
// Please write to info@rafeysoft.com for more information
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Diagnostics;
namespace App.Model.Db 
{
    public class TournamentPrizes : BaseItems<TournamentPrize, TournamentPrizes>
    {
        #region Constructors
        public TournamentPrizes()
        {
        }

        public TournamentPrizes(Cxt cxt)
        {
            Cxt = cxt;
        }

        public TournamentPrizes(Cxt cxt, BaseCollection items)
        {
            Cxt = cxt;

            DataTable = items.DataTable;
        }

        public TournamentPrizes(Cxt cxt, DataTable table)
        {
            Cxt = cxt;

            DataTable = table;
        }

        #endregion

        #region Properties

        #region Core
        public override InfiChess TableName
        {
            [DebuggerStepThrough]
            get { return InfiChess.TournamentPrize; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }
        #endregion

        #region Enum

        #endregion

        #region Generated
        #endregion

        #region Contained Classes

        #endregion

        #region Calculated
        int tournamentID;
        public int TournamentID { get { return tournamentID; } set { tournamentID = value; } }
        #endregion
        #endregion 

        #region Methods
        public static DataTable GetAllTournamentPrize(StatusE statusE)
        {
            return BaseCollection.ExecuteSql(InfiChess.TournamentPrize, "SELECT * FROM TournamentPrize WHERE statusID = @p1 ORDER BY DateCreated DESC", (int)statusE);
        }

        public static DataTable GetTournamentPrizeByTournamentID(Cxt cxt, int TournamentID)
        {
            string sql = @"SELECT tp.*,tpc.Name as CategoryName FROM TournamentPrize tp
                               inner join TournamentPrizeCategory tpc on tp.TournamentPrizeCategoryId = tpc.TournamentPrizeCategoryID
                               WHERE TournamentID = @p1 ORDER BY PrizePosition";

            return BaseCollection.ExecuteSql(InfiChess.TournamentPrize, sql, TournamentID);
        }

        public static DataTable GetTournamentPrizeCategories(Cxt cxt)
        {
            return BaseCollection.ExecuteSql(InfiChess.TournamentPrize, "SELECT * FROM TournamentPrizeCategory ORDER BY TournamentPrizeCategoryID");
        }

        public static DataTable GetAllTournamentPrizes()
        {
            return BaseCollection.ExecuteSql(InfiChess.Team, "SELECT * FROM TournamentPrize WHERE statusID <> 4 ORDER BY DateCreated DESC", "");
        }

        public static DataTable UpdateStatus(StatusE statusID, string parm)
        {
            // status id is deleted
            StringBuilder sb = new StringBuilder();

            sb.Append("update TournamentPrize set statusid = ").Append(statusID.ToString("d")).Append(" WHERE TeamID in (").Append(parm).Append(")");

            return BaseCollection.ExecuteSql(sb.ToString());
        }
        
        void DeletePrizeByTournamentID(SqlTransaction trans)
        {
            TournamentPrizes.Delete(InfiChess.TournamentPrize, "TournamentID", tournamentID);
        }

        public static void DeleteTournamentPrizes(string tournamentPrizeIDs)
        {
            string[] tournamentPrizeIDsArr = tournamentPrizeIDs.Split(',');

            foreach (string itemID in tournamentPrizeIDsArr)
            {
                if (string.IsNullOrEmpty(itemID))
                {
                    continue;
                }
                TournamentPrizes.Delete(InfiChess.TournamentPrize, Convert.ToInt32(itemID));
            }
        }        
        public override void Save()
        {            
            SqlTransaction trans = null;
            try 
	        {	        
                trans = SqlHelper.BeginTransaction(Config.ConnectionString);

                DeletePrizeByTournamentID(trans);
                base.Save(trans);

                SqlHelper.CommitTransaction(trans);
	        }
	        catch (Exception ex)
	        {
                SqlHelper.RollbackTransaction(trans);
                Log.Write(this.Cxt, ex);
	        }
            
        }
        
        #endregion



    }
}
