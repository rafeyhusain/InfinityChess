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
    public class UserVoucher : BaseItem
    {
        #region Constructor
        public UserVoucher()
            : base(0)
        {
        }

        public UserVoucher(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public UserVoucher(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public UserVoucher(Cxt cxt, DataRow row)
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
            get { return InfiChess.UserVoucher; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion

        #region Enum
        public enum VoucherStatusE
        {
            Unknown = 0,
            Buy = 1,
            Used = 2
        }
        #endregion

        #region Generated
        public int UserVoucherID { [DebuggerStepThrough]get { return GetColInt32("UserVoucherID"); } [DebuggerStepThrough]set { SetColumn("UserVoucherID", value); } }
        public int UserID { [DebuggerStepThrough]get { return GetColInt32("UserID"); } [DebuggerStepThrough]set { SetColumn("UserID", value); } }
        public int VoucherStatusID { [DebuggerStepThrough]get { return GetColInt32("VoucherStatusID"); } [DebuggerStepThrough]set { SetColumn("VoucherStatusID", value); } }
        public string VoucherNo { [DebuggerStepThrough]get { return GetCol("VoucherNo"); } [DebuggerStepThrough]set { SetColumn("VoucherNo", value); } }
        public DateTime BuyDate { [DebuggerStepThrough]get { return GetColDateTime("BuyDate"); } [DebuggerStepThrough]set { SetColumn("BuyDate", value); } }
        public DateTime ActivationDate { [DebuggerStepThrough]get { return GetColDateTime("ActivationDate"); } [DebuggerStepThrough]set { SetColumn("ActivationDate", value); } }
        public DateTime ExpiryDate { [DebuggerStepThrough]get { return GetColDateTime("ExpiryDate"); } [DebuggerStepThrough]set { SetColumn("ExpiryDate", value); } }
        public int OrderID { [DebuggerStepThrough]get { return GetColInt32("OrderID"); } [DebuggerStepThrough]set { SetColumn("OrderID", value); } }
        #endregion

        #region Contained Classes
        public VoucherStatusE VoucherStatusIDE { [DebuggerStepThrough]get { return (VoucherStatusE)this.VoucherStatusID; } [DebuggerStepThrough]set { this.VoucherStatusID = (int)value; } }
        bool isUsed = false;
        public bool IsUsed { [DebuggerStepThrough]get { return isUsed; } [DebuggerStepThrough]set { isUsed = value; } }
        #endregion

        #region Calculated
       
        #endregion

        public static UserVoucher GetUserVoucher(Cxt cxt, int orderID)
        {
            return new UserVoucher(cxt, BaseCollection.SelectItem(InfiChess.UserVoucher, orderID));
        }

        #endregion 
           
        #region Method

        public static UserVoucher GetUserVoucher(Cxt cxt, string voucherNo)
        {
            UserVoucher userVoucher = null;
            DataTable dt = BaseCollection.ExecuteSql(InfiChess.UserVoucher, "SELECT * FROM UserVoucher where VoucherNo = @p1", voucherNo);
            if (dt.Rows.Count > 0)
            {
                userVoucher = new UserVoucher(cxt, dt.Rows[0]);
            }
            return userVoucher;
        }

        public void Save(UserVoucher UserVoucher, SqlTransaction trans)
        {            
            UserVoucher.ExpiryDate = DateTime.Now.AddYears(+1);
            UserVoucher.BuyDate = DateTime.Now;
            UserVoucher.VoucherNo = Guid.NewGuid().ToString();
            UserVoucher.VoucherStatusIDE = UserVoucher.VoucherStatusE.Buy;
            UserVoucher.Save(trans);     
        }

        public static UserVoucher CheckoutAccount(Cxt cxt, string voucherNo)
        {
            SqlTransaction trans = null;
            UserVoucher UserVoucher = null;
            try
            {
                UserVoucher = UserVoucher.GetUserVoucher(cxt, voucherNo);

                if (UserVoucher != null)
                {

                    User User = new User(cxt, UserVoucher.UserID);

                    OrderDetail OrderDetail = new OrderDetail(cxt, UserVoucher.OrderID);
                
                    trans = SqlHelper.BeginTransaction(Config.ConnectionString);

                    if (UserVoucher.VoucherStatusIDE != VoucherStatusE.Used)
                    {
                        UserVoucher.ActivationDate = DateTime.Now;
                        UserVoucher.VoucherStatusIDE = VoucherStatusE.Used;
                        UserVoucher.Save(trans);

                        
                        User.Fini += OrderDetail.Quantity;
                        User.UpdateFini(trans, User.Fini, User.UserID);
                        

                        SqlHelper.CommitTransaction(trans);
                        UserVoucher.isUsed = false;
                    }
                    else
                    {
                        UserVoucher.isUsed = true;
                    }
                }                
            }
            catch (Exception ex)
            {
                SqlHelper.RollbackTransaction(trans);

                throw ex;
            }
            return UserVoucher;
        }

        #endregion

        public static MsgE GetMessage(DataSet ds)
        {
            MsgE msgID = MsgE.CreditCardValid;
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Kv kv = new Kv(ds.Tables[0]);
                    if (kv.Get("Message") == "0")
                    {
                        msgID = MsgE.CreditCardValid;                        
                    }
                    else if (kv.Get("Message") == "1")
                    {                        
                        msgID = MsgE.CardAlreadyCheckedout;                        
                    }
                    else if (kv.Get("Message") == "2")
                    {                        
                        msgID = MsgE.VoucherInvalid;                        
                    }
                }
            }
            return msgID;
        }
      
    }
}
