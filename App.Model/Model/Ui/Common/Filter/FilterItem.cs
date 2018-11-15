using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;

namespace App.Model
{
    public class FilterItem : BaseItem
    {
        #region Data Members

        #endregion

        #region Constructor
        public FilterItem()
            : base(0)
        {
        }

        public FilterItem(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public FilterItem(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public FilterItem(Cxt cxt, DataRow row)
        {
            Cxt = cxt;
            DataRow = row;
        }

        public FilterItem(DataRow row)
        {
            DataRow = row;
        }

        #endregion

        #region Properties

        public string Key { [DebuggerStepThrough] get { return GetCol("Key"); } [DebuggerStepThrough] set { SetColumn("Key", value); } }
        public string Value { [DebuggerStepThrough] get { return GetCol("Value"); } [DebuggerStepThrough] set { SetColumn("Value", value); } }
   
        #endregion


        public static FilterItem NewMove()
        {
            return new FilterItem(NewRow());
        }

        public static DataRow NewRow()
        {
            DataTable table = FilterItems.GetFilterItemsTable();

            DataRow row = table.NewRow();

            table.Rows.Add(row);

            table.AcceptChanges();

            return row;
        }

    }
}
