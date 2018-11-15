using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;
using App.Model.Db;
using WeifenLuo.WinFormsUI.Docking;

namespace App.Win
{
    public partial class InboxUc : DockContent
    {
        public const string Guid = "c531d548-2e6c-44a5-ad3d-e012f75917da";

        public InboxUc()
        {
            InitializeComponent();
        }

        public void LoadMessages(DataTable table)
        {
            int index = 0;
            DataGridViewColumn oldColumn = new DataGridViewColumn();
            SortOrder so = SortOrder.None;
            if (dataGridView1 != null && dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                    index = dataGridView1.SelectedRows[0].Index;
                oldColumn = dataGridView1.SortedColumn;
                so = dataGridView1.SortOrder;
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = null;
            editor1.BodyHtml = "";
            if (table == null)
                return;

            DataView dv = new DataView(table);
            dv.RowFilter = "UserIDTo=" + Ap.CurrentUserID + " AND StatusIDTo=1";

            dataGridView1.DataSource = dv.ToTable();
            if (oldColumn != null)
            {
                switch (so)
                {
                    case SortOrder.Ascending:
                        this.dataGridView1.Sort(oldColumn, ListSortDirection.Ascending);
                        break;
                    case SortOrder.Descending:
                        this.dataGridView1.Sort(oldColumn, ListSortDirection.Descending);
                        break;
                    case SortOrder.None:
                        break;
                    default:
                        break;
                }
            }
            
            if (dataGridView1.Rows.Count > index)
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = index;
                dataGridView1.Rows[index].Selected = true;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Email\recieve.PNG");
                e.Value = item;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editor1.BodyHtml = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
            }
        }

        private void InboxUc_Load(object sender, EventArgs e)
        {
            editor1.toolStrip1.Visible = false;
            editor1.doc.designMode = "Off";
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            SendMessage frm = new SendMessage();
            frm.IsReply = false;
            frm.ShowDialog();
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult dr = MessageForm.Confirm(this.ParentForm, MsgE.ConfirmEmailDelete, "");
                if (dr == DialogResult.Yes)
                {
                    int messageId = UData.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    int statusIDFrom = UData.ToInt32(dataGridView1.SelectedRows[0].Cells[9].Value.ToString());
                    
                    DataSet ds = SocketClient.DeleteEmail(messageId, statusIDFrom, (int)StatusE.Deleted);
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        this.LoadMessages(ds.Tables[0]);
                    }
                    else
                    {
                        this.LoadMessages(null);
                        editor1.BodyHtml = "";
                    }
                }
            }
        }

        private void toolStripButtonReply_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                SendMessage frm = new SendMessage();
                frm.IsReply = true;
                frm.To = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                frm.Subject = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                frm.BodyText = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                frm.ShowDialog();
            }
        }

        #region Overrrides

        protected override string GetPersistString()
        {
            return Guid;
        }

        #endregion
    }
}
