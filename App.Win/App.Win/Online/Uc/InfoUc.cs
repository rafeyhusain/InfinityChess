using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;
using System.Configuration;
using App.Model.Db;
using WeifenLuo.WinFormsUI.Docking;

namespace App.Win
{
    public partial class InfoUc : DockContent
    {
        public const string Guid = "969aa9ce-602b-477a-95e4-632af9af0569";

        public InfoUc()
        {
            InitializeComponent();
        }

        private void InfoUc_Load(object sender, EventArgs e)
        {

        }

        public void LoadRoomInfo(int roomID, int tournamentID, string url)
        {
            //  string url = string.Empty;

            if (tournamentID == 0 && url == "")
            {
                panel1.Visible = true;
                panel1.Dock = DockStyle.Fill;
                tournamentDetailUc1.Visible = false;
                tournamentDetailUc1.Dock = DockStyle.None;

                url = KeyValues.Instance.GetKeyValue(KeyValueE.RoomUrl).Value;
                
                if (!String.IsNullOrEmpty(url))
                {
                    webBrowser1.Navigate(url + roomID);
                }
            }
            else if (tournamentID > 0)
            {
                panel1.Visible = false;
                panel1.Dock = DockStyle.None;
                tournamentDetailUc1.Visible = true;
                tournamentDetailUc1.Dock = DockStyle.Fill;

                tournamentDetailUc1.Show(tournamentID);
            }
            else
            {
                url = url.Replace("&amp;", "&");
                webBrowser1.Navigate(url);
            }
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        #region Overrrides

        protected override string GetPersistString()
        {
            return Guid;
        }

        #endregion
    }
}
