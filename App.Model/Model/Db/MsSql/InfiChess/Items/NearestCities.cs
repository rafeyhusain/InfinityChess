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
    public class NearestCities : BaseItems<NearestCity, NearestCities>
    {
        #region Constructors
        public NearestCities()
        {
        }

        public NearestCities(Cxt cxt)
        {
            Cxt = cxt;
        }

        public NearestCities(Cxt cxt, BaseCollection items)
        {
            Cxt = cxt;

            DataTable = items.DataTable;
        }

        public NearestCities(Cxt cxt, DataTable table)
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
        public static DataTable GetAllNearestCities()
        {
            return BaseCollection.ExecuteSql(InfiChess.Country, "SELECT * FROM NearestCity", "");
        }
        #endregion
    }
}
