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

namespace App.Model.Db 
{
    public class RegisteredUsers : BaseItems<RegisteredUser, RegisteredUsers>
    {
        #region Constructors

        public RegisteredUsers()
        {
        }

        public RegisteredUsers(Cxt cxt)
        {
            Cxt = cxt;
        }

        public RegisteredUsers(Cxt cxt, BaseCollection items)
        {
            Cxt = cxt;

            DataTable = items.DataTable;
        }

        public RegisteredUsers(Cxt cxt, DataTable table)
        {
            Cxt = cxt;

            DataTable = table;
        }

        #endregion

        #region Properties

        #region Core
        public override InfiChess TableName
        {
            get { return InfiChess.RegisteredUser; }
            set { base.TableName = value; }
        }
        #endregion

        #region Enum

        #endregion

        #endregion 
              
        #region Methods
        #endregion
    }
}
