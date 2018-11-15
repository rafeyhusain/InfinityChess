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
using App.Model.Db;
using System.Diagnostics;
namespace App.Model
{
    [DebuggerStepThrough]
    public class Cxt : CxtParam
    {
        #region Data Members
        private int currentUserID = 0;
        private User user = null;

        #endregion

        #region Constructor
        public Cxt()
            : base(null, false)
        {
            base.Cxt = this;
        }

        public Cxt(StateBag viewState)
            : base(null, false)
        {
            base.Cxt = this;
            ViewState = viewState;
        }

        #endregion

        #region User

        public int CurrentUserID
        {
            [DebuggerStepThrough]
            get
            {
                if (currentUserID == 0)
                {
                    currentUserID = Config.UserID;

                    if (HttpContext.Current != null)
                    {
                        currentUserID = UWeb.UserID;
                    }
                }

                return currentUserID;
            }
            [DebuggerStepThrough]
            set { currentUserID = value; }
        }

        public User CurrentUser
        {
            [DebuggerStepThrough]
            get
            {
                if (user == null)
                {
                    user = new User(Cxt.Instance, CurrentUserID);
                }

                return user;
            }
            [DebuggerStepThrough]
            set
            {
                user = value;

                if (user != null)
                {
                    CurrentUserID = user.ID; // just to make sure user and userid stay in sync
                }
            }
        }
        #endregion

        #region Instance
        public static Cxt Instance
        {
            [DebuggerStepThrough]
            get
            {
                return new Cxt();
            }
        }
        #endregion

        #region Util

        #region CanDo
        public void CanDo(TaskE task)
        {
            switch (task)
            {
                case TaskE.Unknown:
                    break;
                case TaskE.ViewService:
                    break;
                case TaskE.SearchItem:
                    break;
                case TaskE.NewItem:
                    break;
                case TaskE.EditItem:
                    break;
                case TaskE.DeleteItem:
                    break;
                case TaskE.ViewItem:
                    break;
                default:
                    break;
            }

        }
        #endregion

        #endregion
    }
}