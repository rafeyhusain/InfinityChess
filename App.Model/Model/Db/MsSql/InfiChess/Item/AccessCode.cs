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
    public class AccessCode : BaseItem
    {
        #region Constructor
        public AccessCode()
            : base(0)
        {
        }

        public AccessCode(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public AccessCode(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public AccessCode(Cxt cxt, DataRow row)
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
            get { return InfiChess.AccessCode; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }
        #endregion

        #region Enum

        #endregion

        #region Generated
        public int AccessCodeID { [DebuggerStepThrough]get { return GetColInt32("AccessCodeID"); } [DebuggerStepThrough]set { SetColumn("AccessCodeID", value); } }
        public string Code { [DebuggerStepThrough]get { return GetCol("Code"); } [DebuggerStepThrough]set { SetColumn("Code", value); } }
        public bool IsBlock { [DebuggerStepThrough] get { return GetColBool("IsBlock"); } [DebuggerStepThrough]set { SetColumn("IsBlock", value); } }
        #endregion

        #region Contained Classes

        #endregion

        #region Calculated

        #endregion
        #endregion

        #region Method

        #region Add

        public static void Add(int userid, string accesscode)
        {
            BaseCollection.ExecuteDataset("AddAccessCode", userid, accesscode);
        }
        #endregion

        #region Contained Methods

        #endregion

        #endregion
    }
}
