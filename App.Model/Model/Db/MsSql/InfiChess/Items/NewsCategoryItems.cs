using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Diagnostics;

namespace App.Model.Db
{
    public class NewsCategoryItems : BaseItems<News, NewsItems>
    {

        #region Constructors
        public NewsCategoryItems()
        {
        }

        public NewsCategoryItems(Cxt cxt)
        {
            Cxt = cxt;
        }

        public NewsCategoryItems(Cxt cxt, BaseCollection items)
        {
            Cxt = cxt;

            DataTable = items.DataTable;
        }

        public NewsCategoryItems(Cxt cxt, DataTable table)
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
                return InfiChess.NewsCategory;
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
       
        #region Method

        #endregion

    }
}
