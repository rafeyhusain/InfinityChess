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
[DebuggerStepThrough]
public class BasePage : System.Web.UI.Page
{
    #region Constructor
    public BasePage()
    {
        base.Page.Load += new EventHandler(Page_Load);
    }

    void Page_Load(object sender, EventArgs e)
    {
        if (IsDialog)
        {
            this.ShowDialogUi();
        }
    }

    #endregion

    #region Cxt

    public BaseMasterPage BaseMasterPage
    {
        [DebuggerStepThrough]
        get { return (BaseMasterPage)Master; }
    } 

    public Cxt Cxt
    {
        [DebuggerStepThrough]
        get { return BaseMasterPage.Cxt; }
    }

    #endregion

    #region Util
    #region Redirect
    public string UrlReferrer
    {
        [DebuggerStepThrough]
        get { return BaseMasterPage.UrlReferrer; }
        [DebuggerStepThrough]
        set { BaseMasterPage.UrlReferrer = value; }
    }

    public void CheckIfAuthenticated()
    {
        BaseMasterPage.CheckIfAuthenticated();
    }

    public void CheckIfAuthorized()
    {
        BaseMasterPage.CheckIfAuthorized();
    }

    public void CheckIfAuthorized(params RoleE[] roles)
    {
        BaseMasterPage.CheckIfAuthorized(roles);
    }

    public void Redirect(string url)
    {
        BaseMasterPage.Redirect(url);
    }

    public void Redirect(string url, params object[] pv)
    {
        BaseMasterPage.Redirect(url, pv);
    }

    public void GoBack()
    {
        BaseMasterPage.GoBack();
    }
    
    public void ReloadPage()
    {
        BaseMasterPage.ReloadPage();
    }
    #endregion

    #region CanDo

    public void CanDo(TaskE task)
    {
        Cxt.CanDo(task);

    }

    #endregion

    #endregion

    #region BaseUrl
    public string BaseUrl
    {
        [DebuggerStepThrough]
        get
        {
            return BaseMasterPage.BaseUrl;
        }
    } 
    #endregion

    #region ShowDialogUi
    public bool IsDialog
    {
        get { return UWeb.QsBool("IsDialog"); }
    }

    public void ShowDialogUi()
    {
        BaseMasterPage.ShowDialogUi();
    }

    #endregion
    
    #region SetMessageColor
    public System.Drawing.Color SetMessageColor(bool IsError)
    {
        return BaseMasterPage.SetMessageColor(IsError);
    }
    #endregion
    
        
   

}
