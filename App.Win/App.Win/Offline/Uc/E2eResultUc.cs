using System;
using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace InfinityChess
{
    public partial class E2EResultUc : UserControl
    {
        #region DataMembers 

        public Game Game = null;

        #endregion

        #region Ctor 
        public E2EResultUc()
        {
            InitializeComponent();
        }
        #endregion

        #region Control Load 

        private void E2EResultUc_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Events

        bool isEditorLoaded = false;
        void editor1_Tick()
        {
            if (editor1.ReadyState == Design.ReadyState.Complete && !isEditorLoaded)
            {
                isEditorLoaded = true;
                LoadResults();
            }
        }

        #endregion
      
        #region Helper Methods

        bool isInitiated = false;
        public void Init()
        {
            if (!isInitiated) // if not already init.
            {
                if (editor1 == null || editor1.IsDisposed)
                {
                    editor1 = new Design.Editor();
                }

                editor1.Tick += new Design.Editor.TickDelegate(editor1_Tick);
                editor1.toolStrip1.Visible = false;
                //editor1.Enabled = false;

                this.Game.AfterFinish += new EventHandler(Game_AfterFinish);
                isInitiated = true;
            }
        }

        void Game_AfterFinish(object sender, EventArgs e)
        {
            LoadResults();
        }

        private void LoadResults()
        {
            string html = "";
            html = this.Game.E2eResult.GetResultString();
            
            editor1.BodyHtml = html;
        }

        #endregion
    }

}
