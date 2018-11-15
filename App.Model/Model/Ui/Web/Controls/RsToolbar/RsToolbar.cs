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
using System.Diagnostics;
#region Assembly Resource Attribute
[assembly: System.Web.UI.WebResource("App.Model.Model.Ui.Web.Controls.RsToolbar.Res.Script.js", "text/javascript")]
#endregion

namespace App.Model
{

    #region enum
    public enum RsToolbarButton
    {
        None = 0,
        Separator = 1,
        New = 2,
        Save = 3,
        Delete = 4,
        Cancel = 5,
        Active = 6,
        Inactive = 7,
        Disable = 8,
        Accept = 9,
        Decline = 10,
        Select = 11,
        Wantin = 12,
        Remove = 13,
        Login = 14,
        Scheduled = 15,
        InProgress = 16,
        Finsihed = 17,
        Postpond = 18,
        StartMatch = 19,
        WhiteBye = 20,
        BlackBye = 21,
        Absent = 22,
        Back = 23,
        WindowClose = 24,
        Refresh = 25,
        CreateRound = 26,
        RemoveBan = 27,
        SendPassword = 28,
        Submit = 29,
        ProceedOrder = 30,
        StartTournament = 31,
        FinishTournament = 32,
        DropDownMenu = 33,
        StartRound = 34
    }
    #endregion

    #region RsToolbar
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:RsToolbar runat=server />")]
    public class RsToolbar : ToolBar
    {
        public delegate void ToolbarItemClickEvenHandler(object sender, RsToolbarButtonClickEventArg e);
        public event ToolbarItemClickEvenHandler OnToolbarItemClick;

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
            base.ItemClick += new ToolBarEventHandler(RsToolbar_ItemClick);
            
            base.AutoPostBack = true;
        }

        void RsToolbar_ItemClick(object sender, ToolBarEventArgs e)
        {
            if (OnToolbarItemClick != null)
            {
                RsToolbarButtonClickEventArg e1 = new RsToolbarButtonClickEventArg();

                e1.Item = e.Item;

                OnToolbarItemClick(this, e1);
            }
        }

        public void AddButton(params RsToolbarButton[] buttons)
        {
            foreach (RsToolbarButton b in buttons)
            {
                ToolBarItem item = new ToolBarItem();

                if (b == RsToolbarButton.Separator)
                {
                    item.Type = ToolBarItemType.Separator;
                }
                else if (b == RsToolbarButton.DropDownMenu)
                {
                    ToolBarItemCollection coll = base.ItemTemplates;
                    ToolBarItem item11 = new ToolBarItem();
                    item11.Type = ToolBarItemType.Custom;
                    coll.Add(item11);

                    ToolBarItemCollection col2 = base.Items;
                    ToolBarItem item1 = new ToolBarItem();
                    item1.Type = ToolBarItemType.Custom;
                    col2.Add(item1);
                    
                }
                else
                { 
                    item.Type = ToolBarItemType.Button;                    
                    item.CommandName = b.ToString("d");
                    item.ImageUrl = "~/Web/Img/Toolbar/" + b.ToString("d") + ".png";                    
                }
                
                
                base.Items.Add(item);
            }
        }

        public void DeleteButtons()
        {
            base.Items.Clear();                         
        }

        public void DeleteButton(RsToolbarButton button)
        {
            ToolBarItem item = Items[button.ToString("d")];
            base.Items.Remove(item);
        }

        public void DisableToolbar(params RsToolbarButton[] buttons)
        {
            foreach (RsToolbarButton b in buttons)
            {
                base.Items[b.ToString("d")].Disabled = true;
            }            
        }

        EO.Web.Menu Menu()
        {
            EO.Web.Menu Menu = new EO.Web.Menu();
            Menu.ID = "menu12";
            
            EO.Web.MenuGroup group = Menu.TopGroup;

            EO.Web.MenuItem MenuItem1 = new EO.Web.MenuItem("Home");
            MenuItem1.ItemID = "Home";
            EO.Web.MenuGroup gr1 = MenuItem1.SubMenu;
            gr1.Style.BackColor = System.Drawing.Color.Yellow;
            EO.Web.MenuItem  menu12 = new EO.Web.MenuItem("Home child");
            gr1.Items.Add(menu12);
            group.Style.BackColor = System.Drawing.Color.White;
            group.Items.Add(MenuItem1);
            return Menu;
        }
  

    } 
    #endregion

    #region RsToolbarButtonClickEventArg
    public class RsToolbarButtonClickEventArg : EventArgs
    {
        public EO.Web.ToolBarItem Item = null;

        public RsToolbarButton Button
        {
            [DebuggerStepThrough]
            get 
            {
                if (Item == null)
                {
                    return RsToolbarButton.None;
                }
                else
                {
                    return (RsToolbarButton)BaseItem.ToInt32(Item.CommandName);
                }
            }
        }

    } 
    #endregion

    }
