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
    [ToolboxData("<{0}:RsRichTextBox runat=server />")]
    public class RsRichTextBox : FredCK.FCKeditorV2.FCKeditor
    {
        public string Text
        {
            [DebuggerStepThrough]
            get { return base.Value; }
            [DebuggerStepThrough]
            set { base.Value = Text; }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.BasePath = "~/Web/Js/fckeditor/";
            base.OnPreRender(e);
        }

        
    }
}
