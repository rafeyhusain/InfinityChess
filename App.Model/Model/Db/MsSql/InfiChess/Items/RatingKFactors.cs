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
    public class RatingKFactors : BaseItems<RatingKFactor, RatingKFactors>
    {
        #region Constructors
        public RatingKFactors()
        {
        }

        public RatingKFactors(Cxt cxt)
        {
            Cxt = cxt;
        }

        public RatingKFactors(Cxt cxt, BaseCollection items)
        {
            Cxt = cxt;

            DataTable = items.DataTable;
        }

        public RatingKFactors(Cxt cxt, DataTable table)
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
            get { return InfiChess.RatingKFactor; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }
        #endregion
        #endregion


        private static RatingKFactors instance = null;

        public static RatingKFactors Instance
        {
            [DebuggerStepThrough]
            get
            {
                if (instance == null)
                {
                    instance = new RatingKFactors(Cxt.Instance, BaseCollection.ExecuteSql("SELECT * FROM RatingKFactor"));
                }

                return instance;
            }
            [DebuggerStepThrough]
            set { instance = value; }
        }


        #region Methods

        public RatingKFactor GetRatingKFactor(int eloEloRating, int noOfGames)
        {
            RatingKFactor item = new RatingKFactor(this.Cxt, GetRow(eloEloRating, noOfGames));

            return item;
        }
        #endregion

        #region Helpers

        private DataRow GetRow(int eloRating, int noOfGames)
        {
            DataRow[] rows = DataTable.Select("RatingSystemID=2 AND MinNoOfGames <= " + noOfGames + " AND MaxNoOfGames >= " + noOfGames + " AND MinEloRating <= " + eloRating + " AND MaxEloRating >= " + eloRating);

            if (rows.Length > 0)
            {
                return rows[0];
            }

            return null;
        }

        #endregion


    }
}
