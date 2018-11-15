using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;
using WeifenLuo.WinFormsUI.Docking;

namespace App.Win
{
    public partial class AudienceUc : DockContent, IGameUc
    {
        public const string Guid = "6af4d2ec-6101-4462-a14b-cc123cedc26b";

        public AudienceUc()
        {
            InitializeComponent();
        }

        private void AudienceUc_Load(object sender, EventArgs e)
        {

        }

        public void FillAudienceGrid(DataTable dt)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        public void AddAudience(DataRow dr)
        {
            DataTable dt = new DataTable();
            if (dataGridView1.Rows.Count > 0)
            {
                dt = (DataTable)dataGridView1.DataSource;
                dt.ImportRow(dr);
            }
            else
            {
                dataGridView1.AutoGenerateColumns = false;
                dt = dr.Table;
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        public void RemoveAudience(int userID)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                DataTable dt = (DataTable)dataGridView1.DataSource;
                DataRow dr = dt.Select("UserID=" + userID).FirstOrDefault();
                if (dr != null && dt.Rows.Count > 0)
                {
                    dt.Rows.Remove(dr);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (dataGridView1["Rank", e.RowIndex].Value != null && dataGridView1["Rank", e.RowIndex].Value.ToString() != "" && dataGridView1["Rank", e.RowIndex].Value.ToString() != "0")
                {
                    Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Ranks\" + dataGridView1["Rank", e.RowIndex].Value + ".PNG");
                    e.Value = item;
                }
            }
            if (e.ColumnIndex == 4)
            {
                if (dataGridView1["CountryID", e.RowIndex].Value != null && dataGridView1["CountryID", e.RowIndex].Value.ToString() != "" && dataGridView1["CountryID", e.RowIndex].Value.ToString() != "0")
                {
                    Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Flags\" + dataGridView1["CountryID", e.RowIndex].Value + ".PNG");
                    e.Value = item;
                    dataGridView1["Nation", e.RowIndex].ToolTipText = dataGridView1["CountryName", e.RowIndex].Value.ToString();
                }
                else
                {
                    Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Flags\244.PNG");
                    e.Value = item;
                }
            }
        }

        #region IGameUc Members

        public void Init()
        {
            
        }

        public void UnInit()
        {
            
        }

        public void NewGame()
        {
           
        }

        #endregion

        #region Overrrides

        protected override string GetPersistString()
        {
            return Guid;
        }

        #endregion
    }
}
