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
    public class Engine : BaseItem
    {
        #region Constructor
        public Engine()
            : base(0)
        {
        }

        public Engine(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public Engine(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public Engine(Cxt cxt, DataRow row)
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
            get { return InfiChess.Engine; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion

        #region Enum

        #endregion

        #region Generated
        public int EngineID { [DebuggerStepThrough]get { return GetColInt32("EngineID"); } [DebuggerStepThrough] set { SetColumn("EngineID", value); } }
        #endregion

        #region Contained Classes

        #endregion

        #endregion

        #region Methods
        public static DataTable GetEngineByName(Cxt cxt, string engineName)
        {
            return BaseCollection.ExecuteSql("SELECT * FROM Engine WHERE Name='" + engineName.Trim() + "'");
        }

        public static DataTable GetEngineByID(Cxt cxt, int engineID)
        {
            return BaseCollection.ExecuteSql("SELECT * FROM Engine WHERE EngineID=" + engineID);
        }
        #endregion

        #region Contained Methods

        #endregion

    }
}


        