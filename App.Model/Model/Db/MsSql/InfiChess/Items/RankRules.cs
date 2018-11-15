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
    public class RankRules : BaseItems<RankRule, RankRules>
    {
        #region Constructors
        public RankRules()
        {
        }

        public RankRules(Cxt cxt)
        {
            Cxt = cxt;
        }

        public RankRules(Cxt cxt, BaseCollection items)
        {
            Cxt = cxt;

            DataTable = items.DataTable;
        }

        public RankRules(Cxt cxt, DataTable table)
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
            get { return InfiChess.RankRule; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }
        #endregion
        #endregion


        private static RankRules instance = null;

        public static RankRules Instance
        {
            [DebuggerStepThrough]
            get
            {
                if (instance == null)
                {
                    instance = new RankRules(Cxt.Instance, BaseCollection.ExecuteSql("SELECT * FROM RankRule"));
                }

                return instance;
            }
            [DebuggerStepThrough]
            set { instance = value; }
        }


        #region Methods

        public RankRule GetRankRule(int eloRating, int noOfGames, int loginDays, int chessTypeID)
        {
            RankRule item = new RankRule(this.Cxt, GetRow(eloRating, noOfGames, loginDays, chessTypeID));

            return item;
        }
        #endregion

        #region Helpers

        private DataRow GetRow(int eloRating, int noOfGames, int loginDays, int chessTypeID)
        {
            DataRow[] rows = DataTable.Select("ChessTypeID=" + chessTypeID + " AND RankId <> 7 AND EloRating<=" + eloRating + " AND NoOfGames<=" + noOfGames + " AND LoginDays<=" + loginDays);
            
            int len = rows.Length;
            if (len > 0)
            {
                return rows[len-1];
            }

            return null;
        }

        #endregion


    }
}
