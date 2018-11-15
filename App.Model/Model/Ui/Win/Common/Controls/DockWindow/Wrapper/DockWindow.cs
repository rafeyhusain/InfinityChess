using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

#region Sample Form
/*
 * 
 * using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Crom.Controls.Docking;

namespace Crom.Controls.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreatePanels();
        }

        #region Docking Window
        DockManager dm = null;

        const string g1 = "bd678d79-0626-4e02-a5b8-cfe44c819ad0";
        const string g2 = "0ec2b6fa-dabf-4579-acc7-71a209408b12";
        const string g3 = "ecddcc05-b371-4b88-b760-c87f4dcf701e";
        const string g4 = "80e5c0d8-1e8d-44e8-ade0-391690df89c3";
        const string g5 = "76ee1c55-a061-428c-b751-1f8dfbf4db51";

        private void CreatePanels()
        {
            dm = new DockManager();
            dm.Dock = DockStyle.Fill;
            panel1.Controls.Add(dm);

            dm.SavePath = @"C:\Text.txt";

            DockPanel p = null;

            p = new DockPanel(new ClockUc(), null, DockStyle.Right, zDockMode.Outer, g1, true, 50, 400);
            dm.Add(p);

            p = new DockPanel(new NotationUc(), p, DockStyle.Bottom, zDockMode.Inner, g2, true, 200, 400);
            dm.Add(p);

            p = new DockPanel(new AnalysisUc(), p, DockStyle.Bottom, zDockMode.Inner, g3, true, 200, 400);
            dm.Add(p);

            p = new DockPanel(new CapturedPieceUc(), p, DockStyle.Bottom, zDockMode.Inner, g4, true, 50, 400);
            dm.Add(p);

            p = new DockPanel(new ChessBoardUc(), null, DockStyle.Fill, zDockMode.Outer, g5, true, 0, 0);
            dm.Add(p);

            dm.LoadPanels();
        } 
        

        private void clockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dm.TogglePanel(clockToolStripMenuItem.Checked, g1);
        }

        private void notationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dm.TogglePanel(notationToolStripMenuItem.Checked, g2);
        }

        private void loadDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dm.LoadDefaultPanels();
        }
  
 #endregion

    }
}
 */

        #endregion

namespace Crom.Controls.Docking
{
    public class DockWindow : DockContainer
    {
        #region Data Members
        private DockStateSerializer serializer = null;
        public new DockStateSerializer Serializer
        {
            get { return serializer; }
        }

        public Dictionary<string, DockPanel> Panels = new Dictionary<string, DockPanel>();
        #endregion

        #region Ctor
        public DockWindow()
        {
            this.PreviewRenderer = null;

            serializer = new DockStateSerializer(this);

            serializer.PanelAdded += new DockStateSerializer.PanelAddedEventHandler(serializer_PanelAdded);
        }

        #endregion

        #region Properties
        public string SavePath
        {
            get { return serializer.SavePath; }
            set { serializer.SavePath = value; }
        } 
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //if (serializer.SavePath != "")
            //{
            //    serializer.Save();
            //}
        }
        
        #endregion

        #region Events
        void OnDockerShowContextMenu(object sender, FormContextMenuEventArgs e)
        {
           
        }

        void OnDockerFormClosed(object sender, FormEventArgs e)
        {
            e.Form.Close();
        }

        void OnDockerFormClosing(object sender, DockableFormClosingEventArgs e)
        {
            //DockableFormInfo info = _docker.GetFormInfo(e.Form);
            //if (info.Id == new Guid("0a3f4468-080b-404e-b012-997b93ed2005"))
            //{
            //    e.Cancel = true;
            //}
        } 
        #endregion

        #region Add Panel
        public void Add(DockPanel panel)
        {
            Panels[panel.Guid] = panel;
        }

        private void Create(DockPanel panel)
        {
            panel.DockInfo = Add(panel.Control, panel.DockInfoOver, panel.DockStyle, panel.DockMode, panel.Guid);
            
            SetPanel(panel);
        }

        private void SetPanel(DockPanel panel)
        {
            panel.DockInfo.ShowCloseButton = panel.ShowCloseButton;
            panel.DockInfo.Dock = panel.DockStyle;
            panel.DockInfo.DockMode = panel.DockMode;
            panel.DockInfo.HostContainerDock = panel.DockStyle;

            if (panel.Width != 0)
            {
                SetWidth(panel.DockInfo, panel.Width);
            }

            if (panel.Height != 0)
            {
                SetHeight(panel.DockInfo, panel.Height);
            }
        }

        private DockableFormInfo Add(Control c, DockStyle dock, zDockMode mode, string guid)
        {
            return Add(c, null, dock, mode, guid);
        }

        private DockableFormInfo Add(Control c, DockableFormInfo infoOver, DockStyle dock, zDockMode mode, string guid)
        {
            DockableFormInfo info = Add(c, guid);
            //DockForm(info, infoOver, dock, mode);
            if (infoOver == null)
            {
                DockForm(info, dock, mode);
            }
            else
            {
                DockForm(info, infoOver, dock, mode);
            }
            return info;
        }

        private DockableFormInfo Add(Control c, string guid)
        {
            return Add(c, zAllowedDock.All, guid);
        }

        private DockableFormInfo Add(Form form, string guid)
        {
            return base.Add(form, zAllowedDock.All, new Guid(guid));
        }

        private DockableFormInfo Add(Control c, zAllowedDock allowedDock, string guid)
        {
            return base.Add(CreateForm(c), allowedDock, new Guid(guid));            
        }

        private Form CreateForm(Control c)
        {
            return CreateForm(c, 100, 100, 100, 100, "");
        }

        private Form CreateForm(Control c, int left, int top, int width, int height, string caption)
        {
            Form form = new Form();

            if (height != 0 && width != 0)
            {
                form.Bounds = new Rectangle(left, top, width, height);
            }

            form.FormBorderStyle = FormBorderStyle.None;
            form.Text = caption;
            form.TopLevel = false;

            c.Parent = form;
            c.Dock = DockStyle.Fill;

            return form;
        } 
        #endregion

        #region Load
        public new void LoadPanels()
        {
            if (File.Exists(serializer.SavePath))
            {
                serializer.Load(true, DoLoadPanel);
            }
            else
            {
                LoadDefaultPanels();
            }
        }

        public new void LoadDefaultPanels()
        {
            Clear();

            foreach (DockPanel p in Panels.Values)
            {
                Create(p);
            }
        }

        public new void Clear()
        {
            foreach (DockPanel p in Panels.Values)
            {
                Remove(p.DockInfo);
            }
        }

        private Form DoLoadPanel(Guid guid)
        {
            if (Panels.ContainsKey(guid.ToString()))
            {
                DockPanel p = Panels[guid.ToString()];

                return CreateForm(p.Control);
            }

            return null;
        }

        void serializer_PanelAdded(object sender, PanelAddedEventArgs e)
        {
            UpdatePanelDockInfo(e.DockInfo);
        }

        private void UpdatePanelDockInfo(DockableFormInfo info)
        {
            if (Panels.ContainsKey(info.Id.ToString()))
            {
                DockPanel p = Panels[info.Id.ToString()];

                p.DockInfo = info;

                SetPanel(p);
            }
        }

        #endregion

        #region TogglePanel
        public void TogglePanel(bool show, string guid)
        {
            if (show)
            {
                Create(Panels[guid]);
            }
            else
            {
                DockableFormInfo i = this.GetFormInfo(new Guid(guid));

                Remove(i);

                Panels[guid].DockStyle = DockStyle.Bottom;
                Panels[guid].DockMode = zDockMode.Inner;
            }
        } 
        #endregion

        #region AddPanel
        public void RemovePanel(string guid)
        {
            DockableFormInfo i = this.GetFormInfo(new Guid(guid));
            Remove(i);
            Panels.Remove(guid);
        }
        #endregion
    }
}
