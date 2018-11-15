using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;
namespace App.Model.Db
{
    public class Contact : BaseItem
    {
        #region Constructor
        public Contact()
            : base(0)
        {
        }

        public Contact(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public Contact(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public Contact(Cxt cxt, DataRow row)
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
            get { return InfiChess.Contact; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion
        #region Enum
        #endregion

        #region Generated
        public int ContactID { [DebuggerStepThrough]get { return GetColInt32("ContactID"); } [DebuggerStepThrough] set { SetColumn("ContactID", value); } }
        public string Email { [DebuggerStepThrough] get { return GetCol("Email"); } [DebuggerStepThrough] set { SetColumn("Email", value); } }
        public string Phone { [DebuggerStepThrough] get { return GetCol("Phone"); } [DebuggerStepThrough] set { SetColumn("Phone", value); } }
        public string Subject { [DebuggerStepThrough] get { return GetCol("Subject"); } [DebuggerStepThrough] set { SetColumn("Subject", value); } }
        public string Message { [DebuggerStepThrough]get { return GetCol("Message"); } [DebuggerStepThrough]set { SetColumn("Message", value); } }        
        
        #endregion

        #region Contained Classes

        #endregion

        #region Calculated

        #endregion


        #endregion

        #region Methods
        public static Contact GetContactById(Cxt cxt, int contactID)
        {
            return new Contact(cxt, BaseCollection.SelectItem(InfiChess.Contact, contactID));
        }

        public override void Save()
        {
            KeyValue keyvalue = new KeyValue(base.Cxt, (int)KeyValueE.ContactEmails);

            base.Save();
            MailVerifyResult mvr = EmailTemplate.Send(this.Cxt, EmailTemplateE.Contact, this);
            if (mvr == MailVerifyResult.Ok)
            {
 
            }

        }
        #endregion
    }
}
