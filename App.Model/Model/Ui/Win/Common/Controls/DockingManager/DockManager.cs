using System; using App.Model;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using InfinitySettings.Streams;
using System.Globalization;
using System.Threading;

namespace App.Model
{
    //public class DockManager : Crownwood.Magic.Docking.DockingManager
    //{
    //    #region Data Members
    //    public delegate void ContentCloseHandler(Content c);
    //    public event ContentCloseHandler ContentClose;
    //    private bool isOnContentHiding = true; 
    //    #endregion

    //    #region Ctor
    //    public DockManager(ContainerControl container, VisualStyle vs)
    //        : base(container, vs)
    //    { }
        
    //    #endregion

    //    #region Overrides
    //    public override bool OnContentHiding(Content c)
    //    {
    //        if (!isOnContentHiding)
    //        {
    //            return false;
    //        }

    //        base.OnContentHiding(c);

    //        if (ContentClose != null)
    //        {
    //            ContentClose(c);
    //        }

    //        return false;
    //    } 
    //    #endregion

    //    #region GameMode
    //    public void LoadPanes(GameMode mode)
    //    {
    //        LoadPanes(true, mode);
    //    }

    //    public void LoadPanes(bool loadDefault, GameMode mode)
    //    {
    //        if (loadDefault)
    //        {
    //            Load(Ap.FolderDataConfig + "Default" + mode.ToString() + ".xml", mode);
    //        }
    //        else
    //        {
    //            Load(Ap.FolderDataConfig + "Working" + mode.ToString() + ".xml", mode);
    //        }
    //    }

    //    public void SavePanes(GameMode mode)
    //    {
    //        try
    //        {
    //            this.Save(Ap.FolderDataConfig + "Working" + mode.ToString() + ".xml");
    //        }
    //        catch
    //        {
    //        }
    //    } 
    //    #endregion

    //    #region Core
    //    public void Load(string filePath, GameMode mode)
    //    {
    //        try
    //        {
    //            if (System.IO.File.Exists(filePath))
    //            {
    //                UFile.RemoveReadOnly(filePath);

    //                isOnContentHiding = false;

    //                System.Globalization.CultureInfo myCI = Thread.CurrentThread.CurrentCulture;
    //                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
    //                this.LoadConfigFromFile(filePath);
    //                Thread.CurrentThread.CurrentCulture = myCI;

    //                isOnContentHiding = true;
    //            }
    //            else
    //            {
    //                LoadPanes(true, mode);
    //            }
    //        }
    //        catch(Exception ex)
    //        {
    //            //throw ex;
    //        }
    //    }

    //    public void Save(string filePath)
    //    {
    //        try
    //        {
    //            System.Globalization.CultureInfo myCI = Thread.CurrentThread.CurrentCulture;
    //            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
    //            this.SaveConfigToFile(filePath);
    //            Thread.CurrentThread.CurrentCulture = myCI;
    //        }
    //        catch(Exception ex)
    //        {
    //            throw ex;
    //        }
    //    }

    //    #endregion
    //}
}

