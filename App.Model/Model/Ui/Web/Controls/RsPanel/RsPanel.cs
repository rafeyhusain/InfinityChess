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

namespace App.Model
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:RsPanel runat=server />")]
    public class RsPanel : Panel
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            InitMessage();

            //base.Controls.Add(lblMessage);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        public void ShowMessage(string message, bool isError)
        {
            lblMessage = message;
            if (message != string.Empty)
            {
                this.HorizontalAlign = HorizontalAlign.Center;
                if (isError)
                {
                    this.BackColor = System.Drawing.Color.Red;
                }
                else
                {
                    this.BackColor = System.Drawing.Color.Green;
                }
            }
        }
        
        string lblMessage = string.Empty;
        public string Message
        {
            get
            { return lblMessage; }
            set
            { lblMessage = value; }
        }

        bool isError = false;
        public bool IsError
        {
            get
            { return isError; }
            set
            { isError = value; }
        }


        public void InitMessage()
        {
            Label Label = new Label();
            Label.Text = lblMessage;
            base.Controls.Add(Label);
        }

        
    }
}
