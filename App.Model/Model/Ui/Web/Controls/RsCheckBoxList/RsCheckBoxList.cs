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
using System.Collections;

namespace App.Model
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:RsCheckBoxList runat=server />")]
    public class RsCheckBoxList : CheckBoxList
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        #region InitControl
        private void InitControl()
        {
            Enabled = true;
            Visible = true;
            DataValueField = "AttributeID";
            DataTextField = "Name";
            DataSource = null;
            DataBind();
        }
        #endregion

        

        
    }
}
