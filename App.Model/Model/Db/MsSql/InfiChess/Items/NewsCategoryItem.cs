using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Diagnostics;

namespace App.Model.Db
{
    public class NewsCategoryItem : BaseItems<News, NewsCategoryItem>
    {

        #region Constructors
        public NewsCategoryItem()
        {
        }

        public NewsCategoryItem(Cxt cxt)
        {
            Cxt = cxt;
        }

        public NewsCategoryItem(Cxt cxt, BaseCollection items)
        {
            Cxt = cxt;

            DataTable = items.DataTable;
        }

        public NewsCategoryItem(Cxt cxt, DataTable table)
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
