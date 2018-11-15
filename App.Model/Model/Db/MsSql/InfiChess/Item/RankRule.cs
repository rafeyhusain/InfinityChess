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
    #region enum

    #region RankRuleNameE
    public enum RankRuleE
    {
        Unknown = 0,
        Pawn = 1,
        Knight = 2,
        Bishop = 3,
        Rook = 4,
        Queen = 5,
        King = 6,
        Guest = 7
    }
    #endregion 
    #endregion
    
    public class RankRule : BaseItem
    {
        #region Constructor
        public RankRule()
            : base(0)
        {
        }

        public RankRule(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public RankRule(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public RankRule(Cxt cxt, DataRow row)
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
            get { return InfiChess.RankRule; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion

        #region Enum
        public RankE RankIDE { [DebuggerStepThrough]get { return (RankE)this.RankID; } [DebuggerStepThrough] set { this.RankID = (int)value; } }
        #endregion

        #region Generated
        public int RankRuleID { [DebuggerStepThrough] get { return GetColInt32("RankRuleID"); } [DebuggerStepThrough] set { SetColumn("RankRuleID", value); } }
        public int ChessTypeID { [DebuggerStepThrough]get { return GetColInt32("ChessTypeID"); } [DebuggerStepThrough]set { SetColumn("ChessTypeID", value); } }
        public int RankID { [DebuggerStepThrough] get { return GetColInt32("RankID"); } [DebuggerStepThrough]set { SetColumn("RankID", value); } }
        public int LoginDays { [DebuggerStepThrough] get { return GetColInt32("LoginDays"); } [DebuggerStepThrough] set { SetColumn("LoginDays", value); } }
        public int NoOfGames { [DebuggerStepThrough] get { return GetColInt32("NoOfGames"); } [DebuggerStepThrough]set { SetColumn("NoOfGames", value); } }
        public int EloRating { [DebuggerStepThrough] get { return GetColInt32("EloRating"); } [DebuggerStepThrough] set { SetColumn("EloRating", value); } }
        #endregion

        #endregion
    }
}
