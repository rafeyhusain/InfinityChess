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
using System.Security.Principal;
using System.Web.Security;
using System.Data.SqlClient;
using System.Diagnostics;
namespace App.Model.Db
{
    public class OrderDetail : BaseItem
    {
        #region Constructor
        public OrderDetail()
            : base(0)
        {
        }

        public OrderDetail(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public OrderDetail(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public OrderDetail(Cxt cxt, DataRow row)
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
            get { return InfiChess.OrderDetail; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion

        #region Enum

        #endregion

        #region Generated
        public int OrderDetailID { [DebuggerStepThrough]get { return GetColInt32("OrderDetailID"); } [DebuggerStepThrough]set { SetColumn("OrderDetailID", value); } }
        public int OrderID { [DebuggerStepThrough]get { return GetColInt32("OrderID"); } [DebuggerStepThrough]set { SetColumn("OrderID", value); } }
        public int ProductID { [DebuggerStepThrough]get { return GetColInt32("ProductID"); } [DebuggerStepThrough]set { SetColumn("ProductID", value); } }
        public int Quantity { [DebuggerStepThrough]get { return GetColInt32("Quantity"); } [DebuggerStepThrough]set { SetColumn("Quantity", value); } }
        public decimal UnitPrice { [DebuggerStepThrough]get { return GetColDecimal("UnitPrice"); } [DebuggerStepThrough]set { SetColumn("UnitPrice", value); } }
        #endregion

        #region Contained Classes

        #endregion

        #region Calculated

        #endregion
        #endregion 

        #region Methods

        public static OrderDetail GetOrderDetail(Cxt cxt, int orderID)
        {
            return new OrderDetail(cxt, BaseCollection.SelectItem(InfiChess.OrderDetail, "OrderID = " + orderID));
        }

        public void Save(OrderDetail OrderDetail, SqlTransaction trans)
        {
            //OrderDetail OrderDetail = new OrderDetail(this.Cxt, orderID);            
            OrderDetail.Save(trans);            
        }

        #endregion

    }
}
