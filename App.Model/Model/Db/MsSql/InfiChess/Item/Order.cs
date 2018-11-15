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
    public class Order : BaseItem
    {

        #region Constructor
        public Order()
            : base(0)
        {
        }

        public Order(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public Order(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public Order(Cxt cxt, DataRow row)
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
            get { return InfiChess.Order; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion

        #region Enum
        public enum OrderStatusE
        {
            Unknown = 0,
            Submitted = 1,
            Processed = 2,
            ErrorInvalidCard = 3,
            ErrorInsufficentFunds = 4
        }
        #endregion

        #region Generated
        public int OrderID { [DebuggerStepThrough]get { return GetColInt32("OrderID"); } [DebuggerStepThrough]set { SetColumn("OrderID", value); } }
        public int UserID { [DebuggerStepThrough]get { return GetColInt32("UserID"); } [DebuggerStepThrough]set { SetColumn("UserID", value); } }
        public string Country { [DebuggerStepThrough]get { return GetCol("Country"); } [DebuggerStepThrough]set { SetColumn("Country", value); } }
        public string UserName { [DebuggerStepThrough]get { return GetCol("UserName"); } [DebuggerStepThrough]set { SetColumn("UserName", value); } }
        public string FirstName { [DebuggerStepThrough]get { return GetCol("FirstName"); } [DebuggerStepThrough]set { SetColumn("FirstName", value); } }
        public string LastName { [DebuggerStepThrough]get { return GetCol("LastName"); } [DebuggerStepThrough]set { SetColumn("LastName", value); } }
        public string Email { [DebuggerStepThrough]get { return GetCol("Email"); } [DebuggerStepThrough]set { SetColumn("Email", value); } }
        public string Address { [DebuggerStepThrough]get { return GetCol("Address"); } [DebuggerStepThrough]set { SetColumn("Address", value); } }
        public string PostalCode { [DebuggerStepThrough]get { return GetCol("PostalCode"); } [DebuggerStepThrough]set { SetColumn("PostalCode", value); } }
        public string City { [DebuggerStepThrough]get { return GetCol("City"); } [DebuggerStepThrough]set { SetColumn("City", value); } }
        public string Freight { [DebuggerStepThrough]get { return GetCol("Freight"); } [DebuggerStepThrough]set { SetColumn("Freight", value); } }
        public DateTime OrderDate { [DebuggerStepThrough]get { return GetColDateTime("OrderDate"); } [DebuggerStepThrough]set { SetColumn("OrderDate", value); } }
        public int OrderStatusID { [DebuggerStepThrough]get { return GetColInt32("OrderStatusID"); } [DebuggerStepThrough]set { SetColumn("OrderStatusID", value); } }
        #endregion

        #region Contained Classes
        private OrderDetail orderDetail = null;
        public OrderDetail OrderDetail 
        {
            [DebuggerStepThrough]
            get { return orderDetail; }  
            [DebuggerStepThrough]
            set { orderDetail = value; } 
        }

        private UserVoucher userVoucher = null;
        public UserVoucher UserVoucher
        {
            [DebuggerStepThrough]
            get { return userVoucher; }
            [DebuggerStepThrough]
            set { userVoucher = value; }
        }


        #endregion

        #region Calculated
        public OrderStatusE OrderStatusIDE 
        { 
            [DebuggerStepThrough]
            get { return (OrderStatusE)this.OrderStatusID; } 
            [DebuggerStepThrough]
            set { this.OrderStatusID = (int)value; } 
        } 
        #endregion

        #endregion 

        #region Method

        public static Order GetOrderByID(Cxt cxt, int orderID)
        {
            return new Order(cxt, BaseCollection.SelectItem(InfiChess.Order, orderID));
        }

        public override void Save()
        {
            SqlTransaction trans = null;
            //User User = new User(this.Cxt, this.UserID);
            try
            {
                trans = SqlHelper.BeginTransaction(Config.ConnectionString);

                this.OrderStatusIDE = OrderStatusE.Submitted;
                this.Save(trans);

                OrderDetail orderDetail = this.orderDetail;
                orderDetail.OrderID = this.OrderID;
                orderDetail.Cxt = this.Cxt;
                orderDetail.Save(orderDetail, trans);
                
                //User.Fini += orderDetail.Quantity;

                //User.Save(trans);
                SqlHelper.CommitTransaction(trans);
                
            }
            catch (Exception ex)
            {
                SqlHelper.RollbackTransaction(trans);

                throw ex;
            }
        }

        public void OrderCheckout()
        {
            SqlTransaction trans = null;
            try
            {
                trans = SqlHelper.BeginTransaction(Config.ConnectionString);                
                this.OrderStatusIDE = OrderStatusE.Submitted;
                this.Save(trans);

                UserVoucher UserVoucher = new UserVoucher(this.Cxt, 0);
                UserVoucher.UserID = this.UserID;
                UserVoucher.OrderID = this.OrderID;
                UserVoucher.Save(UserVoucher, trans);

                SqlHelper.CommitTransaction(trans);

                OrderDetail OrderDetail = OrderDetail.GetOrderDetail(this.Cxt, this.OrderID);
                this.OrderDetail = OrderDetail;
                this.UserVoucher = UserVoucher;
                MailVerifyResult mvr = EmailTemplate.Send(this.Cxt, EmailTemplateE.FiniVoucher, this);
                
                if (mvr == MailVerifyResult.Ok)
                {

                }
            }
            catch (Exception ex)
            {
                SqlHelper.RollbackTransaction(trans);

                throw ex;
            }
            
        }

        #endregion

    }
}
