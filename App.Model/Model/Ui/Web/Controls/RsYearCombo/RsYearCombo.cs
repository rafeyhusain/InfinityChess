// (c) Copyright RafeySoft, Karachi Pakistan. http://rafeysoft.com
// This source is subject to following License:
// http://rafeysoft.com/Web/Page/ItemEdit.aspx?sid=29&lid=4&cid=23&iid=2143
// Please write to info@rafeysoft.com for more information
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
namespace App.Model
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:RsYearCombo runat=server />")]
    public class RsYearCombo : RsDropDownList
    {
        #region Properties

        [Category("RafeySoft")]
        public virtual int StartYear
        {
            [DebuggerStepThrough]
            get { return UWeb.VsInt32(ViewState, "StartYear", 0); }
            [DebuggerStepThrough]
            set { ViewState["StartYear"] = value; }
        }

        [Category("RafeySoft")]
        public virtual int EndYear
        {
            [DebuggerStepThrough]
            get { return UWeb.VsInt32(ViewState, "EndYear", 0); }
            [DebuggerStepThrough]
            set { ViewState["EndYear"] = value; }
        }

        [Category("RafeySoft")]
        public virtual bool StartYearCurrent
        {
            [DebuggerStepThrough]
            get { return UWeb.VsBool(ViewState, "StartYearCurrent", false); }
            [DebuggerStepThrough]
            set { ViewState["StartYearCurrent"] = value; }
        }

        [Category("RafeySoft")]
        public virtual bool EndYearCurrent
        {
            [DebuggerStepThrough]
            get { return UWeb.VsBool(ViewState, "EndYearCurrent", false); }
            [DebuggerStepThrough]
            set { ViewState["EndYearCurrent"] = value; }
        }

        [Category("RafeySoft")]
        public virtual int StartYearFromCurrent
        {
            [DebuggerStepThrough]
            get { return UWeb.VsInt32(ViewState, "StartYearFromCurrent", -40); }
            [DebuggerStepThrough]
            set { ViewState["StartYearFromCurrent"] = value; }
        }

        [Category("RafeySoft")]
        public virtual int EndYearFromCurrent
        {
            [DebuggerStepThrough]
            get { return UWeb.VsInt32(ViewState, "EndYearFromCurrent", 0); }
            [DebuggerStepThrough]
            set { ViewState["EndYearFromCurrent"] = value; }
        }

        [Category("RafeySoft")]
        public virtual bool SelectCurrentYear
        {
            [DebuggerStepThrough]
            get { return UWeb.VsBool(ViewState, "SelectCurrent", false); }
            [DebuggerStepThrough]
            set { ViewState["SelectCurrent"] = value; }
        }
        #endregion

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        #region InitControl

        private void InitControl()
        {
            Items.Clear();

            if (StartYear == 0)
            {
                StartYear = DateTime.Now.Year + StartYearFromCurrent;

                if (StartYearCurrent)
                {
                    StartYear = DateTime.Now.Year;
                }
            }

            if (EndYear == 0)
            {
                EndYear = DateTime.Now.Year + EndYearFromCurrent;

                if (EndYearCurrent)
                {
                    EndYear = DateTime.Now.Year;
                }
            }

            if (EndYear < StartYear)
            {
                throw new Exception("EndYear [" + EndYear + "] can not be less than StartYear [" + StartYear + "]");
            }

            for (int i = StartYear; i <= EndYear; i++)
            {
                base.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            if (SelectCurrentYear)
            {
                ListItem item = new ListItem(DateTime.Now.Year.ToString(), DateTime.Now.Year.ToString());

                if (Items.Contains(item))
                {
                    SelectedIndex = Items.IndexOf(item);
                }
            }

            DefaultItemText = "Select Year";
            DefaultItemValue = "";
        }

        #endregion

        
    }
}
