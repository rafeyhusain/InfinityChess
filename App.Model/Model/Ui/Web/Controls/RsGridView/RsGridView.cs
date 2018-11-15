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
using System.Collections;
using System.Data;
using System.Diagnostics;
#region Res

[assembly: WebResource("App.Model.Model.Ui.Web.Controls.RsGridView.Res.JScript.js", "text/javascript", PerformSubstitution=true)]

#endregion

namespace App.Model
{
    [ToolboxData("<{0}:RsGridView runat=server />")]
    public class RsGridView : GridView
    {
        #region Properties
        /// <summary>
        /// Add checkbox column to the gridview.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [Category("Behavior")]
        [Description("Add checkbox column to the gridview.")]
        [DefaultValue(false)]
        public bool ShowCheckBox
        {
            get
            {
                return UWeb.VsBool(ViewState, "ShowCheckBox");
            }
            set { ViewState["ShowCheckBox"] = value; }
        }

        [Category("Behavior")]
        [Description("Add radio button column to the gridview.")]
        [DefaultValue(false)]
        public bool ShowRadioButton
        {
            get
            {
                return UWeb.VsBool(ViewState, "ShowRadioButton");
            }
            set { ViewState["ShowRadioButton"] = value; }
        }

        /// <summary>
        /// Get list of selected rows
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [Browsable(false)]
        public RsListItems SelectedItems
        {
            get
            {
                RsListItems items = new RsListItems(this.DataKeyNames);

                #region ShowRadioButton
                if (ShowRadioButton)
                {
                    int selectedIndex = RsRadioButtonListTemplate.SelectedIndex(this);

                    if (selectedIndex >= 0 && selectedIndex < Rows.Count)
                    {
                        RsListItem item = items.NewItem();

                        item.RowIndex = selectedIndex;

                        item.SetDataKeys(this.DataKeys[selectedIndex]);

                        items.Add(item);
                    }
                }
                #endregion

                #region ShowCheckBox
                if (ShowCheckBox)
                {
                    for (int i = 0; i < Rows.Count; i++)
                    {
                        if (Rows[i].RowType == DataControlRowType.DataRow)
                        {
                            if (((CheckBox)Rows[i].FindControl("chk")).Checked)
                            {
                                RsListItem item = items.NewItem();

                                item.RowIndex = i;

                                item.SetDataKeys(this.DataKeys[i]);

                                items.Add(item);                                
                            }
                        }
                    }
                }
                #endregion

                return items;
            }
        }


        /// <summary>
        /// Get first selected row
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [Browsable(false)]
        public RsListItem SelectedItem
        {
            get
            {
                return SelectedItems.First;
            }
        }        
        
        /// <summary>
        /// Sets items that should be selected. 
        /// Make sure to call base.OnRowDataBound if overriding OnRowDataBound.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        private object dataSourceSelected = null;
        [Browsable(false)]
        public object DataSourceSelected
        {
            [DebuggerStepThrough]
            set
            {
                dataSourceSelected = value;
            }
        }
        #endregion

        #region Render
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        public override void RenderControl(HtmlTextWriter writer)
        {
            base.RenderControl(writer);

            if (ShowCheckBox)
            {
                string scriptLocation =
                Page.ClientScript.GetWebResourceUrl(this.GetType(), "App.Model.Model.Ui.Web.Controls.RsGridView.Res.JScript.js");
                Page.ClientScript.RegisterClientScriptInclude("App.Model.Model.Ui.Web.Controls.RsGridView.Res.JScript.js", scriptLocation);
                // WARNING: UNCOMMENT THIS
                //Page.ClientScript.RegisterStartupScript(this.GetType(), this.ID + "JSBlock", "var ObjJs_" + this.ID + " = new GridClass('" + this.ClientID + "');", true);
                //ScriptManager.RegisterStartupScript(Page, this.GetType(), this.ID + "JSBlock", "var ObjJs_" + this.ID + " = new GridClass('" + this.ClientID + "');", true);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), this.ID + "JSBlock", "alert('"+ this.ClientID + "');", true);

                StringBuilder sb = new StringBuilder();
                sb.Append("if (this.GridviewObj != undefined)").Append("{ var chkBoxes = this.GridviewObj.getElementsByTagName('input'");
        //sb.Append(" var chkBoxId = new String();").Append(" for(var i=0;i<chkBoxes.length;i++) ").Append(" {   chkBoxId = ''; "
         //   if(chkBoxes[i].type == 'checkbox')
          //  {
           //     chkBoxId = chkBoxes[i].getAttribute("id")
            //    if(chkBoxId.indexOf('chk')>0)
             //   {
              //      chkBoxes[i].checked = chkVal;
               // }
            //}
        // }
     //}");
            }
        }

        #endregion

        #region Overrides

        protected override void OnLoad(EventArgs e)
        {
            if (ShowCheckBox)
            {
                UWeb.ResJs(this, "JScript.js");
            }

            base.OnLoad(e);
        }

        protected override void OnRowCreated(GridViewRowEventArgs e)
        {
            base.OnRowCreated(e);

            if (ShowCheckBox)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    string scriptLocation =
               Page.ClientScript.GetWebResourceUrl(this.GetType(), "App.Model.Model.Ui.Web.Controls.RsGridView.Res.JScript.js");
                    Page.ClientScript.RegisterClientScriptInclude("App.Model.Model.Ui.Web.Controls.RsGridView.Res.JScript.js", scriptLocation);
                    ((CheckBox)e.Row.FindControl("chkh")).Attributes.Add("onclick", "return SetCheckBox(this);");
                    //((CheckBox)e.Row.FindControl("chkh")).Attributes.Add("onclick", "ObjJs_" + this.ID + ".CheckUnCheckRows(this.checked)");
                }
            }
        }

        protected override void OnRowDataBound(GridViewRowEventArgs e)
        {
            base.OnRowDataBound(e);

            if (e.Row.RowType != DataControlRowType.DataRow)
            {
                return;
            }

            if (!ShowCheckBox || dataSourceSelected == null)
            {
                return;
            }

            if (UData.Contains((DataTable)dataSourceSelected, DataKeyNames.GetValue(0).ToString(), UWeb.ToString(e, DataKeyNames.GetValue(0).ToString())))
            {
                CheckBox chk = e.Row.FindControl("chk") as CheckBox;

                chk.Checked = true;
            }
        }

        protected override ICollection CreateColumns(PagedDataSource dataSource, bool useDataSource)
        {
            ICollection columns = base.CreateColumns(dataSource, useDataSource);

            if (ShowCheckBox)
            {
                ArrayList list = new ArrayList(columns);
                RsCheckBoxTemplateField column = new RsCheckBoxTemplateField();
                list.Insert(0, column);

                columns = list;
            }

            if (ShowRadioButton)
            {
                ArrayList list = new ArrayList(columns);
                RsRadioButtonTemplateField column = new RsRadioButtonTemplateField(this);
                list.Insert(0, column);

                columns = list;
            }


            return columns;
        } 
        #endregion
    }

    #region Templates

    #region TemplateOwner
    [ToolboxItem(false)]
    public class TemplateOwner : WebControl
    {
    }

    #endregion

    #region RadioButton
    #region Template
    public class RsRadioButtonListTemplate : ITemplate
    {
        #region Data Members
        public static int rowIndex = -1;
        private ListItemType type;
        private Control parent = null;
        #endregion

        #region Ctor
        public RsRadioButtonListTemplate(Control parent, ListItemType type)
        {
            rowIndex = -1;
            this.type = type;
            this.parent = parent;
        }
        #endregion

        #region ITemplate Members
        public void InstantiateIn(Control container)
        {
            switch (type)
            {
                case ListItemType.AlternatingItem:
                    break;
                case ListItemType.EditItem:
                    break;
                case ListItemType.Footer:
                    break;
                case ListItemType.Header:
                    break;
                case ListItemType.Item:
                    AddControl("rdo", container);
                    break;
                case ListItemType.Pager:
                    break;
                case ListItemType.SelectedItem:
                    break;
                case ListItemType.Separator:
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Helpers
        private void AddControl(string id, Control container)
        {
            Literal c = new Literal();

            string groupName = GroupName(parent);
            id = UWeb.GetUniqueName(parent, "ctl" + rowIndex + id);

            c.Text = "<input type='radio' id='" + id + "' name='" + groupName + "' value='" + rowIndex + "'";

            if (RsRadioButtonListTemplate.SelectedIndex(parent) == rowIndex)
            {
                c.Text += " checked='checked'";
            }

            c.Text += "/>";

            container.Controls.Add(c);

            rowIndex++;
        }

        public static string GroupName(Control parent)
        {
            return parent.ID + "rdo";
        }

        public static int SelectedIndex(Control parent)
        {
            return UWeb.RfInt32(GroupName(parent), -1);
        }
        #endregion
    }
    #endregion

    #region TemplateField

    class RsRadioButtonTemplateField : TemplateField
    {
        private TemplateOwner container;
        private RsRadioButtonListTemplate header;
        private RsRadioButtonListTemplate item;

        public RsRadioButtonTemplateField(Control parent)
        {
            container = new TemplateOwner();

            header = new RsRadioButtonListTemplate(parent, ListItemType.Header);
            header.InstantiateIn(container);
            this.HeaderTemplate = header;
            this.HeaderStyle.VerticalAlign = VerticalAlign.Middle;
            this.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

            item = new RsRadioButtonListTemplate(parent, ListItemType.Item);
            item.InstantiateIn(container);
            this.ItemTemplate = item;
        }
    }
    #endregion
    #endregion

    #region CheckBox

    #region Template
    public class RsCheckBoxListTemplate : ITemplate
    {
        private ListItemType type;
        public RsCheckBoxListTemplate(ListItemType type)
        {
            this.type = type;
        }

        #region ITemplate Members
        public void InstantiateIn(Control container)
        {
            switch (type)
            {
                case ListItemType.AlternatingItem:
                    break;
                case ListItemType.EditItem:
                    break;
                case ListItemType.Footer:
                    break;
                case ListItemType.Header:
                    AddControl("chkh", container);
                    break;
                case ListItemType.Item:
                    AddControl("chk", container);
                    break;
                case ListItemType.Pager:
                    break;
                case ListItemType.SelectedItem:
                    break;
                case ListItemType.Separator:
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Helpers
        private void AddControl(string id, Control container)
        {
            RsCheckBox c = new RsCheckBox();
            c.ID = id;
            //c.BackColor = System.Drawing.Color.Blue;
            //c.BorderColor = System.Drawing.Color.Green;
            container.Controls.Add(c);
            
        }

        #endregion
    }
    #endregion

    #region TemplateField

    class RsCheckBoxTemplateField : TemplateField
    {
        private TemplateOwner container;
        private RsCheckBoxListTemplate header;
        private RsCheckBoxListTemplate item;

        public RsCheckBoxTemplateField()
        {
            container = new TemplateOwner();

            header = new RsCheckBoxListTemplate(ListItemType.Header);
            header.InstantiateIn(container);
            this.HeaderTemplate = header;
            this.HeaderStyle.VerticalAlign = VerticalAlign.Middle;
            this.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

            item = new RsCheckBoxListTemplate(ListItemType.Item);
            item.InstantiateIn(container);
            this.ItemTemplate = item;
        }
    }
    #endregion
    #endregion

    #endregion
}
