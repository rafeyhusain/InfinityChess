using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections;

namespace App.Model
{
    public class FilterItems : BaseItems<FilterItem, FilterItems>
    {
        #region DataMember
        public const string Key = "Key";
        public const string Value = "Value";
        #endregion

        #region Constructors
        public FilterItems()
        {
            DataTable = GetFilterItemsTable();
        }

        public FilterItems(Cxt cxt)
        {
            Cxt = cxt;
            DataTable = GetFilterItemsTable();
        }

        public FilterItems(Cxt cxt, BaseCollection items)
        {
            Cxt = cxt;

            DataTable = items.DataTable;
        }

        public FilterItems(Cxt cxt, DataTable table)
        {
            Cxt = cxt;

            DataTable = table;
        }

        public static DataTable GetFilterItemsTable()
        {
            DataSet ds = new DataSet();

            DataTable table = ds.Tables.Add("FI");

            table.Columns.Add(new DataColumn(FilterItems.Key, typeof(string)));
            table.Columns.Add(new DataColumn(FilterItems.Value, typeof(string)));

            return table;
        }
        #endregion

        #region Method

        public void Add(DataTable dt)
        {
            foreach (DataColumn col in dt.Columns)
            {
                Add(col.ColumnName, col.Caption);
            }
        }
        public void Add(string key, string value)
        {
            if (String.IsNullOrEmpty(key) || String.IsNullOrEmpty(value))
            {
                return;
            }

            FilterItem fi = FilterItem.NewMove();
            fi.Key = key;
            fi.Value = value;
            DataTable.Rows.Add(fi.Key, fi.Value);
        }

        public void Add(GridView gv, params string[] hideColumnNames)
        {
            DataTable dt = (DataTable)gv.DataSource;

            for (int i = 0; i < gv.Columns.Count; i++)
            {
                DataControlField col = gv.Columns[i];
                DataColumn colx = dt.Columns[i];

                if (col.Visible)
                {
                    if (hideColumnNames != null)
                    {
                        if (hideColumnNames.Contains(colx.ColumnName))
                        {
                            continue;
                        }
                    }

                    DataTable.Rows.Add(colx.ColumnName, col.HeaderText);
                }
            }
        }

        public void Add(DataGridView gv, params string[] hideColumnNames)
        {
            DataTable dt = (DataTable)gv.DataSource;

            for (int i = 0; i < gv.ColumnCount; i++)
            {
                DataGridViewColumn col = gv.Columns[i];
                
                if (col.Visible)
                {
                    if (hideColumnNames != null)
                    {
                        if (hideColumnNames.Contains(col.DataPropertyName))
                        {
                            continue;
                        }
                    }

                    Add(col.DataPropertyName, col.Name);
                }
            }
        }

        public DataTable SearchByValue(DataTable dt, string column, string value)
        {
            try
            {
                if (dt == null || String.IsNullOrEmpty(column))
                {
                    return null;
                }

                if (String.IsNullOrEmpty(value))
                {
                    return dt;
                }

                DataView dv = new DataView(dt);

                switch (dv.Table.Columns[column].DataType.FullName)
                {
                    case "System.String":
                        if (column == "Internet")
                        {
                            column = "InternetTooltip";
                        }
                        dv.RowFilter = column + " LIKE  '%" + value.Replace("'", "''") + "%'";
                        break;
                    case "System.DateTime":
                        dv.RowFilter = "CONVERT(" + column + ",System.String) LIKE  '%" + value + "%'";
                        break;
                    default:
                        dv.RowFilter = column + " = '" + value + "'";
                        break;
                }

                return dv.ToTable();
            }
            catch
            {
                return null;
            }
        }

        #endregion

        public DataTable SearchByValue(DataTable table, ToolStripComboBox cmb, ToolStripTextBox txt)
            {
            try
            {
                object val = ((ComboBox)cmb.Control).SelectedValue;

                if (val == null)
                {
                    return table;
                }

                return SearchByValue(table, val.ToString(), txt.Text);
            }
            catch (Exception ex)
            {
                MessageForm.Show(ex);
            }

            return table;
        }
    }
}
