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
    public class TournamentMatchRule : BaseItem
    {
        #region Constructor
        public TournamentMatchRule()
            : base(0)
        {
        }

        public TournamentMatchRule(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public TournamentMatchRule(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public TournamentMatchRule(Cxt cxt, DataRow row)
        {
            Cxt = cxt;

            DataRow = row;
        }

       
        #endregion

        #region Properties

        #region Core
        public override InfiChess TableName { [DebuggerStepThrough] get { return InfiChess.TournamentMatchRule; } [DebuggerStepThrough] set { base.TableName = value; } }
        #endregion

        #region Enum
        #endregion

        #region Generated
        public int TournamentMatchRuleID { [DebuggerStepThrough] get { return GetColInt32("TournamentMatchRuleID"); } [DebuggerStepThrough] set { SetColumn("TournamentMatchRuleID", value); } }
        public int Scheduled { [DebuggerStepThrough] get { return GetColInt32("Scheduled"); } [DebuggerStepThrough] set { SetColumn("Scheduled", value); } }
        public int InProgress { [DebuggerStepThrough] get { return GetColInt32("InProgress"); } [DebuggerStepThrough] set { SetColumn("InProgress", value); } }
        public int Finsihed { [DebuggerStepThrough] get { return GetColInt32("Finsihed"); } [DebuggerStepThrough] set { SetColumn("Finsihed", value); } }
        public int Postpond { [DebuggerStepThrough] get { return GetColInt32("Postpond"); } [DebuggerStepThrough] set { SetColumn("Postpond", value); } }
        public int Absent { [DebuggerStepThrough] get { return GetColInt32("Absent"); } [DebuggerStepThrough] set { SetColumn("Absent", value); } }
        public int Draw { [DebuggerStepThrough] get { return GetColInt32("Draw"); } [DebuggerStepThrough] set { SetColumn("Draw", value); } }
        public int WhiteBye { [DebuggerStepThrough] get { return GetColInt32("WhiteBye"); } [DebuggerStepThrough] set { SetColumn("WhiteBye", value); } }
        public int BlackBye { [DebuggerStepThrough] get { return GetColInt32("BlackBye"); } [DebuggerStepThrough] set { SetColumn("BlackBye", value); } }
        public int ForcedWhiteWin { [DebuggerStepThrough] get { return GetColInt32("ForcedWhiteWin"); } [DebuggerStepThrough] set { SetColumn("ForcedWhiteWin", value); } }
        public int ForcedWhiteLose { [DebuggerStepThrough] get { return GetColInt32("ForcedWhiteLose"); } [DebuggerStepThrough] set { SetColumn("ForcedWhiteLose", value); } }
        public int ForcedDraw { [DebuggerStepThrough] get { return GetColInt32("ForcedDraw"); } [DebuggerStepThrough] set { SetColumn("ForcedDraw", value); } }
        #endregion

        #region Contained Classes
        #endregion

        #region Calculated
        #endregion

        #endregion
    }
}
