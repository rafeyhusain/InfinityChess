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
    public class UserRole : BaseItem
	{
        #region Constructor
        public UserRole()
            : base(0)
        {
        }

        public UserRole(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public UserRole(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }
        #endregion

        #region Properties

        #region Core

        public override InfiChess TableName
        {
            [DebuggerStepThrough]
            get { return InfiChess.UserRole; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion

        #region Table Columns
        #region Enum
        public RoleE RoleIDE { [DebuggerStepThrough]get { return (RoleE)this.RoleID; } [DebuggerStepThrough] set { this.RoleID = (int)value; } }

        #endregion

        public int UserID { [DebuggerStepThrough]get { return GetColInt32("UserID"); } [DebuggerStepThrough] set { SetColumn("UserID", value); } }
        public int RoleID { [DebuggerStepThrough]get { return GetColInt32("RoleID"); } [DebuggerStepThrough] set { SetColumn("RoleID", value); } }

        #endregion

        #endregion

    }
}
