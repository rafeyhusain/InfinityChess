// (c) Copyright RafeySoft, Karachi Pakistan. http://rafeysoft.com
// This source is subject to following License:
// http://rafeysoft.com/Web/Page/ItemEdit.aspx?sid=29&lid=4&cid=23&iid=2143
// Please write to info@rafeysoft.com for more information
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;
namespace App.Model
{
    #region ListStyleE
    public enum ListStyleE
    {
        CheckBoxList,
        RadioList,
        List
    }
    
    #endregion

    #region RsList
    [ToolboxData("<{0}:RsList runat=server />")]
    public class RsList : CompositeControl
    {
        #region Data Members
        RsGridView gv = null;
        RsListFields dataTextFields = null;
        #endregion

        #region Properties

        #region Settings
        public string Tag
        {
            [DebuggerStepThrough]
            get
            {
                return UWeb.Vs(ViewState, "Tag");
            }
            [DebuggerStepThrough]
            set
            {
                ViewState["Tag"] = value;
            }
        }

        public string DataValueField
        {
            [DebuggerStepThrough]
            get
            {
                return UWeb.Vs(ViewState, "DataValueField");
            }
            [DebuggerStepThrough]
            set
            {
                ViewState["DataValueField"] = value;
            }
        }

        public RsListFields DataTextFields
        {
            [DebuggerStepThrough]
            get
            {
                DataTable table = UWeb.VsTable(ViewState, "DataTextFields");

                if (table == null)
                {
                    dataTextFields = new RsListFields();

                    ViewState["DataTextFields"] = dataTextFields.DataTable;
                }
                else
                {
                    dataTextFields.DataTable = table;
                }

                return dataTextFields;
            }
            [DebuggerStepThrough]
            set
            {
                ViewState["DataTextFields"] = value;
            }
        }

        [DefaultValue(ListStyleE.CheckBoxList)]
        public ListStyleE ListStyle
        {
            [DebuggerStepThrough]
            get
            {
                return UWeb.Vs<ListStyleE>(ViewState, "ListStyle", ListStyleE.CheckBoxList);
            }
            [DebuggerStepThrough]
            set
            {
                ViewState["ListStyle"] = value;
            }
        }

        #endregion

        #region Controls
        public RsGridView GridView { [DebuggerStepThrough]get { return gv; } }

        #endregion

        #region Calculated
        public object DataSource
        {
            [DebuggerStepThrough]
            get
            {
                EnsureChildControls();
                return gv.DataSource;
            }
            [DebuggerStepThrough]
            set
            {
                EnsureChildControls();
                gv.DataSource = value;
            }
        }

        public RsListItem SelectedItem
        {
            [DebuggerStepThrough]
            get
            {
                return SelectedItems.First;
            }
            [DebuggerStepThrough]
            set
            {
            }
        }

        public RsListItems SelectedItems
        {
            [DebuggerStepThrough]
            get
            {
                return gv.SelectedItems;
            }
            [DebuggerStepThrough]
            set
            {
            }
        }

        #endregion

        #endregion

        #region Render

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        protected override void Render(HtmlTextWriter w)
        {
            try
            {
                EnsureChildControls();

                Table t = new Table();
                t.BorderWidth = 0;
                t.CellPadding = 0;
                t.CellSpacing = 0;

                TableRow r = null;
                TableCell c = null;

                r = new TableRow();
                c = new TableCell();
                c.Controls.Add(gv);
                r.Cells.Add(c);
                t.Rows.Add(r);

                t.RenderControl(w);
            }
            catch (Exception ex)
            {
                UWeb.Error(w, ex);
            }
        }
       
        protected override void CreateChildControls()
        {
            gv = new RsGridView();
            Controls.Add(gv);
            gv.ID = "gv";

            switch (this.ListStyle)
            {
                case ListStyleE.CheckBoxList:
                    gv.ShowCheckBox = true;
                    break;
                case ListStyleE.RadioList:
                    gv.ShowRadioButton = true;
                    break;
                case ListStyleE.List:
                    break;
                default:
                    break;
            }
        }

        #endregion

        

        #region Methods

        public override void DataBind()
        {
            gv.DataBind();           
        }

        public virtual void SetValue(string url)
        {
            SetValue(url, UWeb.GetFileName(url));
        }

        public virtual void SetValue(string url, string toolTip)
        {
            EnsureChildControls();

            ShowToolBar();
        }

        #endregion

        #region Helpers

        #region ToolBar
        private void ShowToolBar()
        {

        }

        #endregion



        #endregion
    } 
    #endregion
}
