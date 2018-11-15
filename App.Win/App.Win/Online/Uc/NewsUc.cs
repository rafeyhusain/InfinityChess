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
    public partial class NewsUc : DockContent
    {
        public const string Guid = "053e4a26-e1a9-4a77-b31e-e28c8e7f2f40";

        public NewsUc()
        {
            InitializeComponent();
        }

        private void NewsUc_Load(object sender, EventArgs e)
        {
            GetNews();
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void GetNews()
        {
            DataSet ds = SocketClient.GetNews();
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Refresh();
                    dataGridView1.Rows[0].Selected = true;
                    int newsID = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value.ToString());
                    if (!String.IsNullOrEmpty(KeyValues.Instance.GetKeyValue("NewsUrl").Value))
                        webBrowser1.Navigate(KeyValues.Instance.GetKeyValue("NewsUrl").Value + newsID);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int newsID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            if (!String.IsNullOrEmpty(KeyValues.Instance.GetKeyValue("NewsUrl").Value))
                webBrowser1.Navigate(KeyValues.Instance.GetKeyValue("NewsUrl").Value + newsID);
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            GetNews();
        }

        #region Overrrides

        protected override string GetPersistString()
        {
            return Guid;
        }

        #endregion
    }
}
