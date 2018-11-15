using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;
namespace App.Model.Db
{
    public class News : BaseItem
    {
        #region Constructor
        public News()
            : base(0)
        {
        }

        public News(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public News(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public News(Cxt cxt, DataRow row)
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
            get { return InfiChess.News; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion

        #region Enum

        public StatusE StatusIDE { [DebuggerStepThrough]get { return (StatusE)this.StatusID; } [DebuggerStepThrough] set { this.StatusID = (int)value; } }

        #endregion

        #region Generated
        public int NewsID { [DebuggerStepThrough] get { return GetColInt32("NewsID"); } [DebuggerStepThrough] set { SetColumn("NewsID", value); } }
        public int StatusID { [DebuggerStepThrough]get { return GetColInt32("StatusID"); } [DebuggerStepThrough]set { SetColumn("StatusID", value); } }
        public int NewsCategoryID { [DebuggerStepThrough]get { return GetColInt32("NewsCategoryID"); } [DebuggerStepThrough]set { SetColumn("NewsCategoryID", value); } }

        #endregion

        #region Contained Classes

        #endregion

        #region Calculated

        #endregion
        #endregion

        #region Methods
        public static News GetNewsById(Cxt cxt, int newsId)
        {
            return new News(cxt, BaseCollection.SelectItem(InfiChess.News, newsId));
        }
        #endregion
    }
}
