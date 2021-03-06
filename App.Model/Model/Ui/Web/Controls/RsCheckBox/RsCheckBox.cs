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
    [ToolboxData("<{0}:RsCheckBox runat=server />")]
    public class RsCheckBox : CheckBox
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

        
    }
}
