using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Diagnostics;
/// <summary>
/// Summary description for UserMessage
/// </summary>
namespace App.Model.Db
{
    public class UserMessage : BaseItem
    {
        #region Constructor
        public UserMessage()
            : base(0)
        {
        }

        public UserMessage(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public UserMessage(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public UserMessage(Cxt cxt, DataRow row)
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
            get { return InfiChess.UserMessage; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion

        #region Enum

        #endregion

        #region Generated
        public int UserMessageID {[DebuggerStepThrough]  get { return GetColInt32("UserMessageID"); } [DebuggerStepThrough]  set { SetColumn("UserMessageID", value); } }
        public int UserIDFrom    {[DebuggerStepThrough]  get { return GetColInt32("UserIDFrom"); }    [DebuggerStepThrough]  set { SetColumn("UserIDFrom", value); } }
        public int UserIDTo     { [DebuggerStepThrough]  get { return GetColInt32("UserIDTo"); }      [DebuggerStepThrough]  set { SetColumn("UserIDTo", value); } }
        public int Size         { [DebuggerStepThrough]  get { return GetColInt32("Size"); }          [DebuggerStepThrough]  set { SetColumn("Size", value); } }
        public int StatusIDFrom { [DebuggerStepThrough]  get { return GetColInt32("StatusIDFrom"); } [DebuggerStepThrough]  set { SetColumn("StatusIDFrom", value); } }
        public int StatusIDTo { [DebuggerStepThrough]  get { return GetColInt32("StatusIDTo"); } [DebuggerStepThrough]  set { SetColumn("StatusIDTo", value); } }
        public string Subject   { [DebuggerStepThrough]  get { return GetCol("Subject"); }            [DebuggerStepThrough]  set { SetColumn("Subject", value); } }
        public string Text      { [DebuggerStepThrough]  get { return GetCol("Text"); }               [DebuggerStepThrough]  set { SetColumn("Text", value); } }
        public DateTime EmailTime{[DebuggerStepThrough]  get { return GetColDateTime("EmailTime"); }  [DebuggerStepThrough]  set { SetColumn("EmailTime", value); } }
        #endregion

        #endregion

        #region Methods

        #region GetUserMessageId

        public static UserMessage GetMessageById(Cxt cxt, int userMessageId)
        {
            return new UserMessage(cxt, BaseCollection.SelectItem(InfiChess.UserMessage, userMessageId));
        }

        public static UserMessage GetMessagesByUserID(Cxt cxt, int userID)
        {
            return new UserMessage(cxt, BaseCollection.SelectItem(InfiChess.UserMessage, "UserIDFrom=" + userID + " OR UserIDTo=" + userID));
        }

        #endregion

        #endregion
    }
}