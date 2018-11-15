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
using EO.Web;

#region Assembly Resource Attribute
[assembly: System.Web.UI.WebResource("App.Model.Model.Ui.Web.Controls.RsDateTimePicker.Res.Script.js", "text/javascript")]
#endregion

namespace App.Model
{

    
    #region RsToolbar
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:RsDateTimePicker runat=server />")]
    public class RsDateTimePicker : DatePicker
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        public override void RenderControl(HtmlTextWriter writer)
        {
            base.RenderControl(writer);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
                
                
    } 
    #endregion
        
}
