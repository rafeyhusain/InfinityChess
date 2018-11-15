/***************************************************************************
 *   CopyRight (C) 2009 by Cristinel Mazarine                              *
 *   Author:   Cristinel Mazarine                                          *
 *   Contact:  cristinel@osec.ro                                           *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the Crom Free License as published by           *
 *   the SC Crom-Osec SRL; version 1 of the License                        *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   Crom Free License for more details.                                   *
 *                                                                         *
 *   You should have received a copy of the Crom Free License along with   *
 *   this program; if not, write to the contact@osec.ro                    *
 ***************************************************************************/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

namespace Crom.Controls.Docking
{
    /// <summary>
    /// Container for dockable tool windows. Place this control on your form to enable window guided docking.
    /// </summary>

    public partial class DockContainer : UserControl
    {

        #region DataMemers

        public Dictionary<string, DockedItem> DockedItems = new Dictionary<string, DockedItem>();

        #endregion

        #region Public section

        public DockableFormInfo AddForm(Control c, zAllowedDock allowDock, string guid, Size size, string caption)
        {
            Form frm = CreateForm(size, c, caption);
            DockableFormInfo dfi = this.Add(frm, allowDock, new Guid(guid));
            return dfi;
        }

        public void LoadPanels()
        {
            LoadDefaultPanels();
        }

        public void LoadDefaultPanels()
        {
            foreach (DockedItem item in DockedItems.Values)
            {
                if (item.ParentDfi == null)
                {
                    this.DockForm(item.ControlDfi, item.Style, item.Mode);
                }
                else
                {
                    this.DockForm(item.ControlDfi, item.ParentDfi, item.Style, item.Mode);
                }
            }
        }

        public void SelectPanel(string guid)
        {
            DockableFormInfo dfi = GetFormInfo(new Guid(guid));
            _docker.SelectedForm = dfi.DockableForm;
        }

        #endregion Public section

        #region Private section

        private Form DoLoadPanel(Guid guid)
        {
            if (DockedItems.ContainsKey(guid.ToString()))
            {
                DockedItem item = DockedItems[guid.ToString()];
                //return item.ControlDfi.DockableForm;
                return CreateForm(item.Size, item.Control, item.Caption);
            }

            return null;
        }

        public Form CreateForm(Size size, Control control, string caption)
        {
            Form form = new Form();
            form.Bounds = new Rectangle(100, 100, size.Width, size.Height);
            form.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            control.Parent = form;
            control.Dock = DockStyle.Fill;
            form.TopLevel = false;
            form.Text = caption;

            return form;
        }

        void Serializer_PanelAdded(object sender, PanelAddedEventArgs e)
        {
            UpdatePanelDockInfo(e.DockInfo);
        }

        private void UpdatePanelDockInfo(DockableFormInfo info)
        {
            if (DockedItems.ContainsKey(info.Id.ToString()))
            {
                DockedItem item = DockedItems[info.Id.ToString()];
                info.ShowCloseButton = item.ControlDfi.ShowCloseButton;
            }
        }

        #endregion Private section
    }

    #region DockedItem - MI
    public struct DockedItem
    {
        public int No;
        public Control Control;
        public string Guid;
        public DockableFormInfo ControlDfi;
        public DockableFormInfo ParentDfi;
        public DockStyle Style;
        public zDockMode Mode;
        public Size Size;
        public string Caption;

        public static DockedItem GetItem(int no, Control control, string guid)
        {
            DockedItem dockedItem = new DockedItem();
            dockedItem.No = no;
            dockedItem.Control = control;
            dockedItem.Guid = guid;
            return dockedItem;
        }
    }
    #endregion
}
