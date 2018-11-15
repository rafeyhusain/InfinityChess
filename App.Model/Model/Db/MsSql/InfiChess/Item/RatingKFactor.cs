// (c) Copyright RafeySoft, Karachi Pakistan. http://rafeysoft.com
// This source is subject to following License:
// http://rafeysoft.com/Web/Page/ItemEdit.aspx?sid=29&lid=4&cid=23&iid=2143
// Please write to info@rafeysoft.com for more information
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using System.Diagnostics;
namespace App.Model.Db
{
    public class RatingKFactor : BaseItem
    {
        #region Constructor
        public RatingKFactor()
            : base(0)
        {
        }

        public RatingKFactor(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public RatingKFactor(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public RatingKFactor(Cxt cxt, DataRow row)
        {
            Cxt = cxt;

            DataRow = row;
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

        #region Enum
        #endregion

        #region Generated
        public int RatingKFactorID { [DebuggerStepThrough] get { return GetColInt32("RatingKFactorID"); } [DebuggerStepThrough]set { SetColumn("RatingKFactorID", value); } }
        public int RatingSystemID { [DebuggerStepThrough]get { return GetColInt32("RatingSystemID"); } [DebuggerStepThrough] set { SetColumn("RatingSystemID", value); } }
        public int KFactor { [DebuggerStepThrough] get { return GetColInt32("KFactor"); } [DebuggerStepThrough]set { SetColumn("KFactor", value); } }
        public int MinEloRating { [DebuggerStepThrough] get { return GetColInt32("MinEloRating"); } [DebuggerStepThrough] set { SetColumn("MinEloRating", value); } }
        public int MaxEloRating { [DebuggerStepThrough]get { return GetColInt32("MaxEloRating"); } [DebuggerStepThrough] set { SetColumn("MaxEloRating", value); } }
        public int MinNoOfGames { [DebuggerStepThrough] get { return GetColInt32("MinNoOfGames"); } [DebuggerStepThrough] set { SetColumn("MinNoOfGames", value); } }
        public int MaxNoOfGames { [DebuggerStepThrough] get { return GetColInt32("MaxNoOfGames"); } [DebuggerStepThrough] set { SetColumn("MaxNoOfGames", value); } }
        #endregion
        
        #endregion
    }
}
