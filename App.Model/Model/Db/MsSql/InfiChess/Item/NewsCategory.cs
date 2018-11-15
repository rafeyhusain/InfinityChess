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
    public enum NewsCategoryE
    {
        Unknown = 0,
        GeneralNews = 1,
        GeneralAnnouncement = 2,
        TournamentAnnouncement = 3,
        Survey = 4
    }

    public class NewsCategory : BaseItem
    {
        #region Constructor
        public NewsCategory()
            : base(0)
        {
        }

        public NewsCategory(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public NewsCategory(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }


        #endregion

        #region Properties

        #region Core
        public override InfiChess TableName { [DebuggerStepThrough] get { return InfiChess.NewsCategory; } [DebuggerStepThrough] set { base.TableName = value; } }
        #endregion

        #region Enum
        public NewsCategoryE NewsCategoryIDE { [DebuggerStepThrough]get { return (NewsCategoryE)this.NewsCategoryID; } [DebuggerStepThrough]set { this.NewsCategoryID = (int)value; } }
        #endregion

        #region Generated
        public int NewsCategoryID { [DebuggerStepThrough] get { return GetColInt32("NewsCategoryID"); } [DebuggerStepThrough] set { SetColumn("NewsCategoryID", value); } }
        public int StatusID { [DebuggerStepThrough] get { return GetColInt32("StatusID"); } [DebuggerStepThrough] set { SetColumn("StatusID", value); } }
        #endregion

        #region Contained Classes
        #endregion

        #region Calculated
        
        #endregion

        #endregion

        #region Method

       public static DataTable GetNewsCategorysByStatusID()
       {
           DataTable dt = BaseCollection.ExecuteSql(InfiChess.UserVoucher, "SELECT * FROM NewsCategory" );
           return dt;

       }
        #endregion
    }
}
