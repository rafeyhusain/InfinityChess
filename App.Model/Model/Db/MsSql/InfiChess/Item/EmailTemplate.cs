using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Diagnostics;
/// <summary>
/// Summary description for Room
/// </summary>
namespace App.Model.Db
{
    #region EmailTemplateE

    public enum EmailTemplateE
    {
        NewAccount = 1,
        ForgotPassword = 2,
        ChangePassword = 3,
        Contact = 4,
        FiniVoucher = 5
    }

    #endregion
    
    public class EmailTemplate : BaseItem
    {
        #region Constructor
        public EmailTemplate()
            : base(0)
        {
        }

        public EmailTemplate(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public EmailTemplate(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public EmailTemplate(Cxt cxt, DataRow row)
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
            get { return InfiChess.EmailTemplate; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion

        #region Enum
        public EmailTemplateE EmailTemplateIDE { [DebuggerStepThrough]get { return (EmailTemplateE)this.EmailTemplateID; } [DebuggerStepThrough] set { this.EmailTemplateID = (int)value; } }
        #endregion

        #region Generated
        public int EmailTemplateID { [DebuggerStepThrough] get { return GetColInt32("EmailTemplateID"); } [DebuggerStepThrough] set { SetColumn("EmailTemplateID", value); } }
        public int StatusID { [DebuggerStepThrough] get { return GetColInt32("StatusID"); } [DebuggerStepThrough] set { SetColumn("StatusID", value); } }
        public string Subject { [DebuggerStepThrough] get { return GetCol("Subject"); } [DebuggerStepThrough] set { SetColumn("Subject", value); } }
        public string Body { [DebuggerStepThrough] get { return GetCol("Body"); } [DebuggerStepThrough] set { SetColumn("Body", value); } }
        #endregion

        #region Contained Classes
        
        #endregion

        #region Calculated

        #endregion
        #endregion

        #region Methods
       
        #region SendMail

        public static MailVerifyResult Send(Cxt cxt, EmailTemplateE templateID, int userID)
        {
            User user = new User(cxt, userID);
            return Send(cxt,templateID, user);
        }

        public static MailVerifyResult Send(Cxt cxt, EmailTemplateE templateID, string email)
        {
            User user = User.GetUserByEmail(cxt, email);
            return Send(cxt,templateID, user);
        }

        public static MailVerifyResult Send(Cxt cxt, EmailTemplateE templateID, User user)
        {
            EmailTemplate t = new EmailTemplate(cxt, (int)templateID);

            string subject = ReplaceTokens(cxt, t.Subject, user);
            string body = ReplaceTokens(cxt, t.Body, user);
            return UMail.Send(cxt, user.Email, "", "", subject, body);
        }

        public static MailVerifyResult Send(Cxt cxt, EmailTemplateE templateID, Order Order)
        {
            EmailTemplate t = new EmailTemplate(cxt, (int)templateID);
            string subject = ReplaceTokens(cxt, t.Subject, Order);
            string body = ReplaceTokens(cxt, t.Body, Order);
            return UMail.Send(cxt, Order.Email, "", "", subject, body);
        }

        public static MailVerifyResult Send(Cxt cxt, EmailTemplateE templateID, Contact Contact)
        {
            EmailTemplate t = new EmailTemplate(cxt, (int)templateID);
            string subject = ReplaceTokens(cxt, t.Subject, Contact);
            string body = ReplaceTokens(cxt, t.Body, Contact);
            KeyValue keyValue = new KeyValue(cxt, (int)KeyValueE.ContactEmails);
            return UMail.Send(cxt, keyValue.Value, "", "", subject, body);
        } 


        #endregion

        #region Helpers

        private static string ReplaceTokens(Cxt cxt, string s, Contact Contact)
        {
            s = s.Replace("%Name%", Contact.Name);
            s = s.Replace("%Email%", Contact.Email);
            s = s.Replace("%Phone%", Contact.Phone);
            s = s.Replace("%Subject%", Contact.Subject);
            s = s.Replace("%Message%", Contact.Message);            
            KeyValue keyValue = new KeyValue(cxt, (int)KeyValueE.UrlInfiChess);
            s = s.Replace("%signinlink%", keyValue.Value);
            return s;
        }

        private static string ReplaceTokens(Cxt cxt, string s, Order Order)
        {
            s = s.Replace("%OrderID%", Order.OrderID.ToString());
            s = s.Replace("%OrderDate%", Order.OrderDate.ToString("dddd 'the' d 'day of' MMMM 'in the year' yyyy"));
            s = s.Replace("%VoucherNo%", Order.UserVoucher.VoucherNo);
            s = s.Replace("%UserName%", Order.UserName.ToString());
            s = s.Replace("%Address%", Order.Address);
            s = s.Replace("%City%", Order.City);
            s = s.Replace("%Country%", Order.Country);
            s = s.Replace("%Zip%", Order.PostalCode.ToString());
            s = s.Replace("%Qty%", Order.OrderDetail.Quantity.ToString());
            s = s.Replace("%Description%", "Fini purchased");
            s = s.Replace("%Price%", "$ " + Math.Round(Order.OrderDetail.UnitPrice, 2).ToString());
            s = s.Replace("%Amount%", "$ " + Convert.ToString(Math.Round(Order.OrderDetail.Quantity * Order.OrderDetail.UnitPrice, 2)));
            s = s.Replace("%Total%", "$ " + Convert.ToString(Math.Round(Order.OrderDetail.Quantity * Order.OrderDetail.UnitPrice, 2)));            
            KeyValue keyValue = new KeyValue(cxt, (int)KeyValueE.UrlInfiChess);
            s = s.Replace("%signinlink%", keyValue.Value);
            return s;
        }

        private static string ReplaceTokens(Cxt cxt, string s, User user)
        {
            s = s.Replace("%username%", user.UserName);
            s = s.Replace("%password%", UCrypto.Decrypt(user.Password));
            s = s.Replace("%name%", user.FirstName + " " + user.LastName);
            //s = s.Replace("%signinlink%", KeyValues.Instance.GetKeyValue(KeyValueE.UrlInfiChess).Value);
            KeyValue keyValue = new KeyValue(cxt, (int)KeyValueE.UrlInfiChess);
            s = s.Replace("%signinlink%", keyValue.Value);
            return s;
        }

        #endregion
       
        #endregion
    }
}