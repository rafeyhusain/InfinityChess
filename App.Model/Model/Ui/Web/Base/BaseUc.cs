using System;
using System.Data;
using System.Configuration;
using System.Collections;
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
public class BaseUc : System.Web.UI.UserControl
{
    private CxtParam param = null;

    #region Constructor
    public BaseUc()
    {
        param = new CxtParam(null, true);
        param.ViewState = ViewState;
    }
    #endregion

    #region Cxt

    public BasePage BasePage
    {
        [DebuggerStepThrough]
        get { return (BasePage)Page; }
    }

    public BaseMasterPage BaseMasterPage
    {
        [DebuggerStepThrough]
        get { return (BaseMasterPage)BasePage.BaseMasterPage; }
    }

    public Cxt Cxt
    {
        [DebuggerStepThrough]
        get { return BasePage.Cxt; }
    }

    public CxtParam Uc
    {
        [DebuggerStepThrough]
        get { param.Cxt = Cxt; return param; }
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
        BaseMasterPage.Redirect(url, null);
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
