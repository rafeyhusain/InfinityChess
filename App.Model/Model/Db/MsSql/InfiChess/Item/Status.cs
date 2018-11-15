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
    #region enum StatusE
    public enum StatusE
    {
        Unknown = 0,
        Active = 1,
        Disabled = 2,
        Inactive = 3,
        Deleted = 4,
        Ban = 5
    }
    #endregion

    public class Status : BaseItem
	{
        #region Constructor
        public Status()
            : base(0)
        {
        }

        public Status(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public Status(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }
        #endregion

        #region Properties

        #region Cor

        public override InfiChess TableName
        {
            [DebuggerStepThrough]
            get { return InfiChess.Status; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion

        #endregion
        
        #region Method

        #region Tostring
        
        public static string ToString(int status)
        {
            return ToString((StatusE)status);
        }
        public static string ToString(StatusE status)
        {
            switch (status)
            {
                case StatusE.Active:
                    return "Active";
                case StatusE.Disabled:
                    return "Disabled";
                case StatusE.Inactive:
                    return "Inactive";
                case StatusE.Deleted:
                    return "Deleted";
                case StatusE.Ban:
                    return "Ban";
                default:
                    return "";
            }
        }
        #endregion

        #endregion
    }
}
