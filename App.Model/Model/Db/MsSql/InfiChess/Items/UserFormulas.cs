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
using System.Web;
using System.Diagnostics;
namespace App.Model.Db 
{
    public class UserFormulas : BaseItems<UserFormula, UserFormulas>
    {
        #region DataMember

        private static UserFormulas instance = null;

        #endregion

        #region Core

        public override InfiChess TableName
        {
            [DebuggerStepThrough]
            get { return InfiChess.UserFormula; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion

        #region Properties

        public static UserFormulas Instance
        {
            [DebuggerStepThrough]
            get
            {
                if (HttpContext.Current == null)
                {
                    if (instance == null)
                    {
                        DataSet ds = SocketClient.GetUserFormula(Ap.CurrentUserID);
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            instance = new UserFormulas(Cxt.Instance, ds.Tables[0]);
                        }
                    }
                }
                else
                {
                    instance = new UserFormulas(Cxt.Instance, UserFormulas.GetUserFormulas(Ap.CurrentUserID));
                }

                return instance;
            }
            [DebuggerStepThrough]
            set { instance = value; }
        }

        #endregion

        #region Constructors

        public UserFormulas()
        {
        }

        public UserFormulas(Cxt cxt)
        {
            Cxt = cxt;
        }

        public UserFormulas(Cxt cxt, BaseCollection items)
        {
            Cxt = cxt;

            DataTable = items.DataTable;
        }

        public UserFormulas(Cxt cxt, DataTable table)
        {
            Cxt = cxt;

            DataTable = table;
        }

        #endregion

        #region Methods

        public static DataTable GetUserFormulas(int userID)
        {
            return BaseCollection.ExecuteSql(InfiChess.UserFormula, "SELECT * FROM [UserFormula] WHERE UserID = " + userID);
        }

        public UserFormula GetUserFormula()
        {
            UserFormula item = new UserFormula(this.Cxt, GetRow());

            return item;
        }

        #endregion

        #region Helpers

        private DataRow GetRow()
        {
            DataRow[] rows = DataTable.Select();

            if (rows.Length > 0)
            {
                return rows[0];
            }

            return null;
        }

        #endregion

    }
}
