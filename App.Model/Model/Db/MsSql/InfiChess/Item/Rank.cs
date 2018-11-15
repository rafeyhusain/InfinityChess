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
    #region enumRankNameE

    public enum RankE
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

    public class Rank : BaseItem
    {
        #region Constructor
        public Rank()
            : base(0)
        {
        }

        public Rank(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public Rank(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }
      
       
        #endregion

        #region Properties
       
        #region Core
        
        public override InfiChess TableName
        {
            [DebuggerStepThrough]
            get { return InfiChess.Rank; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion
       
        #endregion
    }
}
