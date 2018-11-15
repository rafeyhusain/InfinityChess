using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
namespace Crom.Controls.Docking
{
    public class DockPanel
    {
        #region Data Members
        public Form Form = null;
        public Control Control = null;
        public DockStyle DockStyle = DockStyle.None;
        public zDockMode DockMode = zDockMode.None;
        public string Guid = "";
        public DockPanel PanelOver = null;
        public DockableFormInfo DockInfo = null;
        public bool ShowCloseButton = true;
        public int Height = 0;
        public int Width = 0; 
        #endregion

        #region Ctor        

        public DockPanel(DockPanel panelOver)
        {
            PanelOver = panelOver;
        }       

        #endregion

        #region Properties
        public DockableFormInfo DockInfoOver
        {
            [DebuggerStepThrough]
            get
            {
                if (PanelOver != null)
                {
                    return PanelOver.DockInfo;
                }

                return null;
            }
        } 
        #endregion
    }
}
