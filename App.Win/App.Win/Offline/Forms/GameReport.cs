using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;
using InfinityChess.WinForms;

namespace App.Win
{
    public partial class GameReport : Form
    {
        #region DataMember 
   
        public Game Game = null;
        public MainForm MainForm;
        bool IsDiagram = false;

        #endregion

        #region Ctor 
        
        public GameReport(bool isDiagram,Game game,MainForm mainForm)
        {
            InitializeComponent();
            this.Game = game;
            this.MainForm = mainForm;
            this.IsDiagram = isDiagram;
            editor1.Tick += new Design.Editor.TickDelegate(editor1_Tick);
            editor1.toolStrip1.Visible = false;
            editor1.Enabled = false;
        }

        bool isEditorLoaded = false;
        void editor1_Tick()
        {
            if (editor1.ReadyState == Design.ReadyState.Complete && !isEditorLoaded)
            {
                isEditorLoaded = true;
                LoadReport();
            }
        }

        #endregion

        #region Form Events

        private void GameReport_Load(object sender, EventArgs e)
        {
            
        }

        private void GameReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.MainForm != null && !this.MainForm.IsDisposed)
            {
                this.MainForm.Visible = true;
            }
        }

        #endregion
        
        #region Controls Events

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            editor1.Print();
        }

        #endregion

        #region Helper Methods 

        private void LoadReport()
        {
            string html = "";

            if (IsDiagram)
            {   
                html = this.Game.ToGameDiagram();
            }
            else
            {
                html = this.Game.ToGameHtml();
            }

            editor1.BodyHtml = html;
            this.Text = "Infinity Chess - Print Game";
        }

        #endregion

        
    }
}
