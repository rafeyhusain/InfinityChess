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
    public class RatingWinProbablities : BaseItems<RatingWinProbablity, RatingWinProbablities>
    {
        #region Constructors
        public RatingWinProbablities()
        {
        }

        public RatingWinProbablities(Cxt cxt)
        {
            Cxt = cxt;
        }

        public RatingWinProbablities(Cxt cxt, BaseCollection items)
        {
            Cxt = cxt;

            DataTable = items.DataTable;
        }

        public RatingWinProbablities(Cxt cxt, DataTable table)
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
            get { return InfiChess.RatingWinProbablity; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }
        #endregion
        #endregion


        private static RatingWinProbablities instance = null;

        public static RatingWinProbablities Instance
        {
            [DebuggerStepThrough]
            get
            {
                if (instance == null)
                {
                    instance = new RatingWinProbablities(Cxt.Instance, BaseCollection.ExecuteSql("SELECT * FROM RatingWinProbablity"));
                }

                return instance;
            }
            [DebuggerStepThrough]
            set { instance = value; }
        }


        #region Methods

        public RatingWinProbablity GetRatingWinProbablity(int whiteEloRating, int blackEloRating)
        {
            int diff = whiteEloRating - blackEloRating;
            if (diff < 0)
                diff = diff * -1;
            RatingWinProbablity item = new RatingWinProbablity(this.Cxt, GetRow(diff));
            return item;
        }
        #endregion

        #region Helpers

        private DataRow GetRow(int diff)
        {
            DataRow[] rows = DataTable.Select("RatingSystemID=2 AND MinDifference <= " + diff + " AND MaxDifference >= " + diff + "");

            if (rows.Length > 0)
            {
                return rows[0];
            }

            return null;
        }

        #endregion


    }
}
