using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Diagnostics;

namespace App.Model.Db
{
    public class NewsItems : BaseItems<News, NewsItems>
    {

        #region Constructors
        public NewsItems()
        {
        }

        public NewsItems(Cxt cxt)
        {
            Cxt = cxt;
        }

        public NewsItems(Cxt cxt, BaseCollection items)
        {
            Cxt = cxt;

            DataTable = items.DataTable;
        }

        public NewsItems(Cxt cxt, DataTable table)
        {
            Cxt = cxt;

            DataTable = table;
        }

        #endregion

        #region Properties

        #region Core
        public override InfiChess TableName
        {
            [DebuggerStepThrough]
            get
            {
                return InfiChess.News;
            }
            [DebuggerStepThrough]
            set
            {
                base.TableName = value;
            }
        }

        #endregion

        #region Enum

        #endregion

        #region Generated
        #endregion

        #region Contained Classes

        #endregion

        #region Calculated

        #endregion
        #endregion 
        
        #region Methods
        public static DataTable GetAllNews()
        {
            return BaseCollection.ExecuteSql(InfiChess.News, "SELECT * FROM News WHERE statusID = @p1 ORDER BY DateCreated DESC ", (int)StatusE.Active);
        }

        public static DataTable GetAllNews(StatusE statusE)
        {
            return BaseCollection.ExecuteSql(InfiChess.News, "SELECT u.*, Status.Name AS Status FROM news AS u LEFT OUTER JOIN Status ON u.StatusID = Status.StatusID where u.StatusID <> @p1 ORDER BY DateCreated DESC", (int)statusE);
        }

        public static DataTable GetAllNews(NewsCategoryE newsCategoryID, StatusE statusE)
        {
            return BaseCollection.ExecuteSql(InfiChess.News, "SELECT * FROM News WHERE statusID <> @p1 and NewsCategoryID = @p2  ORDER BY DateCreated DESC ", (int)statusE, newsCategoryID.ToString("d"));
        }

        public static DataTable GetAllActiveNews(NewsCategoryE newsCategoryID, StatusE statusE)
        {
            return BaseCollection.ExecuteSql(InfiChess.News, "SELECT * FROM News WHERE statusID = @p1 and NewsCategoryID = @p2  ORDER BY DateCreated DESC ", (int)statusE, newsCategoryID.ToString("d"));
        }

        public static DataTable UpdateStatus(StatusE statusID, string parm)
        {
            // status id is deleted
            StringBuilder sb = new StringBuilder();

            sb.Append("update News set statusid = ").Append(statusID.ToString("d")).Append(" WHERE NewsID in (").Append(parm).Append(")");

            return BaseCollection.ExecuteSql(sb.ToString());
        }
        #endregion


        

    }
}
