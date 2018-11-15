using System; using App.Model;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using InfinityChess.Offline.Forms;

namespace InfinityChess
{
    public static class ThemeClass
    {
        public static void ApplyTheme(object obj)
        {
            string objName = obj.GetType().BaseType.FullName;

            switch (objName)
            {
                case "System.Windows.Forms.Form":
                    {
                        SetControlTheme((Form)obj);
                        break;
                    }
                default:
                    break;
            }
        }
        static System.Drawing.Color _backColor = new System.Drawing.Color(); 
        private static void SetControlTheme(Form form)
        {
            form.BackColor = _backColor;
            form.ForeColor = ThemeSetting.Default.ForeColorControl;
            form.Font = ThemeSetting.Default.Font;

            foreach (Control child in form.Controls)
            {
                SetControlTheme(child);
            }
        }

        private static void SetControlTheme(Control control)
        {
            string controlTypeName = control.GetType().Name;

            if (controlTypeName == "DataGridView")
            {
                DataGridView grd = (DataGridView)control;
                if (grd != null)
                {
                    grd.BackgroundColor = _backColor;
                    grd.GridColor = ThemeSetting.Default.ForeColorControl;

                    grd.DefaultCellStyle.BackColor = _backColor;
                    grd.DefaultCellStyle.ForeColor = ThemeSetting.Default.ForeColorControl;
                    grd.DefaultCellStyle.Font = ThemeSetting.Default.Font;

                    grd.ColumnHeadersDefaultCellStyle.BackColor = _backColor;
                    grd.ColumnHeadersDefaultCellStyle.ForeColor = ThemeSetting.Default.ForeColorControl;
                    grd.ColumnHeadersDefaultCellStyle.Font = ThemeSetting.Default.Font;

                    grd.RowsDefaultCellStyle.BackColor = _backColor;
                    grd.RowsDefaultCellStyle.ForeColor = ThemeSetting.Default.ForeColorControl;
                    grd.RowsDefaultCellStyle.Font = ThemeSetting.Default.Font;

                    grd.RowHeadersDefaultCellStyle.BackColor = _backColor;
                    grd.RowHeadersDefaultCellStyle.ForeColor = ThemeSetting.Default.ForeColorControl;
                    grd.RowHeadersDefaultCellStyle.Font = ThemeSetting.Default.Font;

                    foreach (DataGridViewColumn column in grd.Columns)
                    {
                        column.DefaultCellStyle.BackColor = _backColor;
                        column.DefaultCellStyle.ForeColor = ThemeSetting.Default.ForeColorControl;
                        column.DefaultCellStyle.Font = ThemeSetting.Default.Font;
                    }
                }
            }
            else
            {
                control.BackColor = _backColor;
                control.ForeColor = ThemeSetting.Default.ForeColorControl;
                control.Font = ThemeSetting.Default.Font;
                foreach (Control child in control.Controls)
                {
                    SetControlTheme(child);
                }
            }
        }
    }
}
