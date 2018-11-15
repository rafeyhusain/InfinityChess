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
    public class Countries : BaseItems<Country, Countries>
    {
        #region Constructors
        public Countries()
        {
        }

        public Countries(Cxt cxt)
        {
            Cxt = cxt;
        }

        public Countries(Cxt cxt, BaseCollection items)
        {
            Cxt = cxt;

            DataTable = items.DataTable;
        }

        public Countries(Cxt cxt, DataTable table)
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
            get { return InfiChess.Room; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }
        #endregion
        #endregion

        #region Methods
        public static DataTable GetAllCountries()
        {
            return BaseCollection.ExecuteSql(InfiChess.Country, "SELECT * FROM Country", "");
        }
        #endregion
    }
}
