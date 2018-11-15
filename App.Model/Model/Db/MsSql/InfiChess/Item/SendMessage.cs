using System;
using System.Collections.Generic;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SendMessage
/// </summary>
namespace App.Model.Db
{
    public class SendMessage : BaseItem
    {
        #region Constructor
        public SendMessage()
            : base(0)
        {
        }

        public SendMessage(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public SendMessage(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public SendMessage(Cxt cxt, DataRow row)
        {
            Cxt = cxt;

            DataRow = row;
        }

       
        #endregion
        
        #region Properties

        #region Core
        public override InfiChess TableName
        {
            get { return InfiChess.SendMessage; }
            set { base.TableName = value; }
        }

        #endregion

        #region Enum
        
        #endregion

        #region Generated
        public int SendMessageID { get { return GetColInt32("SendMessageID"); } set { SetColumn("SendMessageID", value); } }
        public int UserIDFrom { get { return GetColInt32("UserIDFrom"); } set { SetColumn("UserIDFrom", value); } }
        public int UserIDTo { get { return GetColInt32("UserIDTo"); } set { SetColumn("UserIDTo", value); } }
        public int Size { get { return GetColInt32("Size"); } set { SetColumn("Size", value); } }
        public int StatusID { get { return GetColInt32("StatusID"); } set { SetColumn("StatusID", value); } }
        public string Subject { get { return GetCol("Subject"); } set { SetColumn("Subject", value); } }
        public string Text { get { return GetCol("Text"); } set { SetColumn("Text", value); } }
        public DateTime Time { get { return GetColDateTime("Time"); } set { SetColumn("Time", value); } } 
        #endregion

        #region Contained Classes

        #endregion

        #region Calculated

        #endregion

        #endregion 
       
        #region Methods

        #region GetSendMessageId
        
        public static SendMessage GetMessageById(Cxt cxt, int SendMessageId)
        {
            return new SendMessage(cxt, BaseCollection.SelectItem(InfiChess.SendMessage, SendMessageId));
        }

        public static SendMessage GetMessagesByUserID(Cxt cxt, int userID)
        {
            return new SendMessage(cxt, BaseCollection.SelectItem(InfiChess.SendMessage, "UserIDFrom=" + userID + " OR UserIDTo=" + userID));
        }

        #endregion

        #endregion
    }
}