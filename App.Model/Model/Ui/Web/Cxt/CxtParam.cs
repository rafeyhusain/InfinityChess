// (c) Copyright RafeySoft, Karachi Pakistan. http://rafeysoft.com
// This source is subject to following License:
// http://rafeysoft.com/Web/Page/ItemEdit.aspx?sid=29&lid=4&cid=23&iid=2143
// Please write to info@rafeysoft.com for more information
// All other rights reserved.

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using App.Model;
using System.Diagnostics;
namespace App.Model
{
    [DebuggerStepThrough]
    public class CxtParam
    {
        #region Data Members
        public StateBag ViewState = null;
        public bool ViewStateOnly = false;
        public Cxt Cxt = null;
        #endregion

        #region Constructor
        public CxtParam(Cxt cxt, bool viewStateOnly)
        {
            Cxt = cxt;
            ViewStateOnly = viewStateOnly;
        }
        #endregion

    }
}