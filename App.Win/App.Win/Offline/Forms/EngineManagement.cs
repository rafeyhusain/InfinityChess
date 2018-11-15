using System; using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using InfinitySettings.EngineManager;
using System.Linq;

namespace InfinityChess
{
    public partial class EngineManagement : Form
    {
        #region DataMembers 

        public Game Game = null;
        List<InfinitySettings.EngineManager.Engine> lstEngine;
        List<InfinitySettings.EngineManager.Engine> lstActiveEngine;
        List<InfinitySettings.EngineManager.Engine> lstDeActiveEngine;
        
        #endregion

        #region Ctor 

        public EngineManagement(Game game)
        {
            this.Game = game;
            InitializeComponent();
        }

        #endregion

        #region Load 
                
        private void EngineManagement_Load(object sender, EventArgs e)
        {
            LoadEnginesLists();
        }

        #endregion

        #region Helpers 

        private void LoadEnginesLists()
        {
            EngineManager objEngineManager = new EngineManager();
            lstEngine = objEngineManager.LoadEngines();

            lstActiveEngine = new List<InfinitySettings.EngineManager.Engine>();
            lstActiveEngine = lstEngine.Where(x => x.IsActive == true).ToList();

            lstDeActiveEngine = new List<InfinitySettings.EngineManager.Engine>();
            lstDeActiveEngine = lstEngine.Where(x => x.IsActive == false).ToList();
            
            if (lstActiveEngine.Count > 0)
            {
                lstActivateEngine.DisplayMember = "Name";
                lstActivateEngine.ValueMember = "EngineTitle";
                lstActivateEngine.DataSource = lstActiveEngine;
                lstActivateEngine.SelectedIndex = lstActivateEngine.Items.Count - 1;
            }
            if (lstDeActiveEngine.Count > 0)
            {
                lstDeActivateEngine.DisplayMember = "Name";
                lstDeActivateEngine.ValueMember = "EngineTitle";
                lstDeActivateEngine.DataSource = lstDeActiveEngine;
                lstDeActivateEngine.SelectedIndex = lstDeActivateEngine.Items.Count - 1;
            }
        }

        private void RefreshLists()
        {
            lstActivateEngine.DataSource = null;
            lstActivateEngine.DisplayMember = null;
            lstActivateEngine.ValueMember = null;

            lstActivateEngine.DisplayMember = "Name";
            lstActivateEngine.ValueMember = "EngineTitle";
            lstActivateEngine.DataSource = lstActiveEngine.ToList<InfinitySettings.EngineManager.Engine>();
            lstActivateEngine.SelectedIndex = lstActivateEngine.Items.Count - 1;
            lstActivateEngine.Refresh();

            lstDeActivateEngine.DataSource = null;
            lstDeActivateEngine.DisplayMember = null;
            lstDeActivateEngine.ValueMember = null;

            lstDeActivateEngine.DisplayMember = "Name";
            lstDeActivateEngine.ValueMember = "EngineTitle";
            lstDeActivateEngine.DataSource = lstDeActiveEngine.ToList<InfinitySettings.EngineManager.Engine>();
            lstDeActivateEngine.SelectedIndex = lstDeActivateEngine.Items.Count - 1;
            lstDeActivateEngine.Refresh();
        }

        #endregion

        #region Events 

        private void btnDeActive_Click(object sender, EventArgs e)
        {
            if (lstActiveEngine.Count > 0 && lstActivateEngine.SelectedItem != null)
            {
                InfinitySettings.EngineManager.Engine selectedItem = (InfinitySettings.EngineManager.Engine)lstActivateEngine.SelectedItem;
                string _defaultEngine = this.Game.DefaultEngine.EngineName + ".exe";
                if (_defaultEngine != selectedItem.EngineTitle)
                {
                    lstActiveEngine.Remove(selectedItem);
                    lstDeActiveEngine.Add(selectedItem);
                    RefreshLists();
                }
                else
                {
                  MessageForm.Error(this,MsgE.ErrorEngineActive,selectedItem.Name);
                }
            }
        }
        
        private void btnActive_Click(object sender, EventArgs e)
        {
            if (lstDeActiveEngine.Count > 0 && lstDeActivateEngine.SelectedItem != null)
            {
                InfinitySettings.EngineManager.Engine selectedItem = (InfinitySettings.EngineManager.Engine)lstDeActivateEngine.SelectedItem;
                lstDeActiveEngine.Remove(selectedItem);
                lstActiveEngine.Add(selectedItem);
                RefreshLists();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EngineManager objEngineManager = new EngineManager();
            foreach (var item in lstActiveEngine)
            {
                objEngineManager.ActivateEngine(item.EngineTitle);
            }
            foreach (var item in lstDeActiveEngine)
            {
                objEngineManager.DeActivateEngine(item.EngineTitle);
            }
            this.Close();
        }

        #endregion

    }
}