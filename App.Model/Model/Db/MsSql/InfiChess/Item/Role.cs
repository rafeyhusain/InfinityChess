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
    #region enum RoleE
    public enum RoleE
    {
        Unknown = 0,
        Admin = 1,
        Player = 2,
        Moderator = 3,
        Trainer = 4,
        Guest = 5
    }
    #endregion

    public class Role : BaseItem
    {
        #region Constructor
        public Role()
            : base(0)
        {
        }

        public Role(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public Role(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }
      
       
        #endregion

        #region Properties
        
        #region Cor
        public override InfiChess TableName
        {
            [DebuggerStepThrough]
            get { return InfiChess.Role; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }
        #endregion

        #region Enum
        public RoleE RoleIDE { [DebuggerStepThrough]get { return (RoleE)this.RoleID; } [DebuggerStepThrough] set { this.RoleID = (int)value; } }
        #endregion

        #region Generated
        public int RoleID { [DebuggerStepThrough] get { return GetColInt32("RoleID"); } [DebuggerStepThrough] set { SetColumn("RoleID", value); } }
        #endregion
       
        #endregion

        #region Method

        public bool IsAdmin(int userID)
        {
            bool isTrue = false;
            DataTable dt = BaseCollection.ExecuteSql(InfiChess.Role, "select role.roleID, role.Name, role.Description from [role] inner join UserRole on [role].roleid = userrole.roleid where [UserRole].userid = @p1", userID);
            if (dt.Rows.Count > 0)
            {
                ///Role role = new Role(Cxt.Instance, dt.Rows[0]);
                if (Convert.ToInt32(dt.Rows[0]["RoleID"]) == (int)RoleE.Admin)
                {
                    isTrue = true;
                }
                else
                {
                    isTrue = false;
                }
            }
            return isTrue;
        }

        #endregion
        
    }
}
