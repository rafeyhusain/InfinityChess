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
    public class RatingWinProbablity : BaseItem
    {
        #region Constructor
        public RatingWinProbablity()
            : base(0)
        {
        }

        public RatingWinProbablity(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public RatingWinProbablity(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public RatingWinProbablity(Cxt cxt, DataRow row)
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
            get { return InfiChess.RatingWinProbablity; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion

        #region Enum
        #endregion

        #region Generated
        public int RatingWinProbablityID { [DebuggerStepThrough]get { return GetColInt32("RatingWinProbablityID"); } [DebuggerStepThrough]set { SetColumn("RatingWinProbablityID", value); } }
        public int RatingSystemID { [DebuggerStepThrough] get { return GetColInt32("RatingSystemID"); } [DebuggerStepThrough] set { SetColumn("RatingSystemID", value); } }
        public int MinDifference { [DebuggerStepThrough] get { return GetColInt32("MinDifference"); } [DebuggerStepThrough] set { SetColumn("MinDifference", value); } }
        public int MaxDifference { [DebuggerStepThrough] get { return GetColInt32("MaxDifference"); } [DebuggerStepThrough] set { SetColumn("MaxDifference", value); } }
        public double StrongerPlayer { [DebuggerStepThrough] get { return GetColDouble("StrongerPlayer"); } [DebuggerStepThrough] set { SetColumn("StrongerPlayer", value); } }
        public double WeakerPlayer { [DebuggerStepThrough] get { return GetColDouble("WeakerPlayer"); } [DebuggerStepThrough] set { SetColumn("WeakerPlayer", value); } }
        
        #endregion
        
        #endregion
       
    }
}
