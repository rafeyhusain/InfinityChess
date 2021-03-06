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
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
namespace App.Model
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:RsRadioButton runat=server />")]
    public class RsRadioButton : RadioButton
    {
        public string Value
        {
            [DebuggerStepThrough]
            get { return Checked ? "1" : "0"; }
            [DebuggerStepThrough]
            set { Checked = (value == "1" ? true : false); }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        #region Properties

        [Category("RafeySoft")]
        public virtual bool ShowDefaultItem
        {
            [DebuggerStepThrough]
            get { return UWeb.VsBool(ViewState, "ShowDefaultItem", false); }
            [DebuggerStepThrough]
            set { ViewState["ShowDefaultItem"] = value; }
        }

        [Category("RafeySoft")]
        public virtual bool SelectDefaultItem
        {
            [DebuggerStepThrough]
            get { return UWeb.VsBool(ViewState, "SelectDefaultItem", false); }
            [DebuggerStepThrough]
            set { ViewState["SelectDefaultItem"] = value; }
        }

        [Category("RafeySoft")]
        public virtual string DefaultItemText
        {
            [DebuggerStepThrough]
            get { return UWeb.Vs(ViewState, "DefaultItemText", ""); }
            [DebuggerStepThrough]
            set { ViewState["DefaultItemText"] = value; }
        }

        [Category("RafeySoft")]
        public virtual string DefaultItemValue
        {
            [DebuggerStepThrough]
            get { return UWeb.Vs(ViewState, "DefaultItemValue", ""); }
            [DebuggerStepThrough]
            set { ViewState["DefaultItemValue"] = value; }
        } 
        #endregion

        #region InitControl
        private void InitControl()
        {
            Enabled = true;
            Visible = true;

            
        }
        #endregion

        
    }
}
