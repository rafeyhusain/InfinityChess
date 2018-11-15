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
    public class KeyValue : BaseItem
    {
        #region Constructor
        public KeyValue()
            : base(0)
        {
        }

        public KeyValue(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public KeyValue(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public KeyValue(Cxt cxt, DataRow row)
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
            get { return InfiChess.KeyValue; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion

        #region Enum

        #endregion

        #region Generated
        public int KeyValueID { [DebuggerStepThrough]get { return GetColInt32("KeyValueID"); } [DebuggerStepThrough]set { SetColumn("KeyValueID", value); } }
        public string KeyName { [DebuggerStepThrough]get { return GetCol("KeyName"); } [DebuggerStepThrough]set { SetColumn("KeyName", value); } }
        public string Value { [DebuggerStepThrough] get { return GetCol("Value"); } [DebuggerStepThrough]set { SetColumn("Value", value); } }
        #endregion

        #region Contained Classes

        #endregion

        #region Calculated
        public int ValueInt32 { [DebuggerStepThrough] get { return GetColInt32("Value"); } [DebuggerStepThrough]set { SetColumn("Value", value); } }
        public bool ValueBool { [DebuggerStepThrough] get { return GetColBool("Value"); } [DebuggerStepThrough]set { SetColumn("Value", value); } }
        #endregion
        #endregion 
    }
}
