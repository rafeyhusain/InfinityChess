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
#region Assembly Resource Attribute
[assembly: System.Web.UI.WebResource("App.Model.Model.Ui.Web.Controls.RsTextBox.Res.Script.js", "text/javascript")]
#endregion

namespace App.Model
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:RsTextBox runat=server />")]
    public class RsTextBox : TextBox
    {
        #region Properties

        [Category("RafeySoft")]
        public virtual bool ShowWaterMarkText
        {
            [DebuggerStepThrough]
            get { return UWeb.VsBool(ViewState, "ShowWaterMarkText", false); }
            [DebuggerStepThrough]
            set { ViewState["ShowWaterMarkText"] = value; }
        }

        [Category("RafeySoft")]
        public virtual string WaterMarkText
        {
            [DebuggerStepThrough]
            get { return UWeb.Vs(ViewState, "WaterMarkText", ""); }
            [DebuggerStepThrough]
            set { ViewState["WaterMarkText"] = value; }
        }

        [Category("RafeySoft")]
        public virtual string CssClassWaterMarkTextFocus
        {
            [DebuggerStepThrough]
            get { return UWeb.Vs(ViewState, "CssClassWaterMarkTextFocus", ""); }
            [DebuggerStepThrough]
            set { ViewState["CssClassWaterMarkTextFocus"] = value; }
        }

        [Category("RafeySoft")]
        public virtual string CssClassWaterMarkTextBlur
        {
            [DebuggerStepThrough]
            get { return UWeb.Vs(ViewState, "CssClassWaterMarkTextBlur", ""); }
            [DebuggerStepThrough]
            set { ViewState["CssClassWaterMarkTextBlur"] = value; }
        }

        [Category("RafeySoft")]
        public virtual string ClickOnEnterButtonClientID
        {
            [DebuggerStepThrough]
            get { return UWeb.Vs(ViewState, "ClickOnEnterButtonClientID", ""); }
            [DebuggerStepThrough]
            set { ViewState["ClickOnEnterButtonClientID"] = value; }
        }
        #endregion

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitWaterMarkText();
            }
        }

        

        #region Helpers

        private void InitWaterMarkText()
        {
            if (!ShowWaterMarkText)
            {
                return;
            }

            Page.ClientScript.RegisterClientScriptInclude(this.GetType().ToString(), UWeb.ResUrl(this, "Script.js"));

            Text = WaterMarkText;

            CssClass = CssClassWaterMarkTextBlur;

            Attributes.Add("onfocus", "RsTextBox_onfocus(this, " + UStr.Quote(CssClassWaterMarkTextFocus) + ", " + UStr.Quote(WaterMarkText) + ");");
            Attributes.Add("onblur", "RsTextBox_onblur(this, " + UStr.Quote(CssClassWaterMarkTextBlur) + ", " + UStr.Quote(WaterMarkText) + ");");
            Attributes.Add("onkeypress", "return RsTextBox_onkeypress(event, " + UStr.Quote(ClickOnEnterButtonClientID) + ")");
        }

   
        #endregion
    }
}
