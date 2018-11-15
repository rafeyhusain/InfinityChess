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
    public partial class SentUc : DockContent
    {
        public const string Guid = "99ce9797-ead0-4bda-9d7c-59d29f0c2d79";

        public SentUc()
        {
            #region InitializeComponent
            InitializeComponent();
            this.InitUi(); 
            #endregion
        }

        private void SentUc_Load(object sender, EventArgs e)
        {
            editor1.toolStrip1.Visible = false;
            editor1.doc.designMode = "Off";
            this.Cursor = System.Windows.Forms.Cursors.Default;
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
            dv.RowFilter = "UserIDFrom=" + Ap.CurrentUserID + " AND StatusIDFrom=1";

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
                Image item = Image.FromFile(App.Model.Ap.FolderImages + @"Email\send.PNG");
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
                    int statusIDTo = UData.ToInt32(dataGridView1.SelectedRows[0].Cells[10].Value.ToString());

                    DataSet ds = SocketClient.DeleteEmail(messageId, (int)StatusE.Deleted, statusIDTo);
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

        #region Overrrides

        protected override string GetPersistString()
        {
            return Guid;
        }

        #region InitUi
        private void InitUi()
        {
            if (App.Model.Ap.CurrentUser != null)
            {
                if (App.Model.Ap.CurrentUser.FirstName == "dev")
                {
                    // 
                    // toolStripButtonSendUpdates
                    // 
                    this.toolStripButtonDeleteDisable = new System.Windows.Forms.ToolStripButton();
                    this.toolStripButtonDeleteDisable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
                    this.toolStripButtonDeleteDisable.ImageTransparentColor = System.Drawing.Color.Magenta;
                    this.toolStripButtonDeleteDisable.Name = "toolStripButtonSendUpdates";
                    this.toolStripButtonDeleteDisable.Size = new System.Drawing.Size(23, 22);
                    this.toolStripButtonDeleteDisable.Text = "toolStripButtonSendUpdates";
                    this.toolStripButtonDeleteDisable.Click += new System.EventHandler(this.toolStripButtonDeleteDisable_Click);

                    this.toolStrip1.Items.Add(this.toolStripButtonDeleteDisable);
                }
            }
        }

        private void toolStripButtonDeleteDisable_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (editor1.DocumentText == "clear")
                {
                    editor1.DocumentText = "";
                }
                else
                {
                    DataSet ds = SocketClient.GetKeyValue(Ap.CurrentUser.PersonalNotes);

                    editor1.Document.Body.InnerText = UData.ToString(ds);
                }
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
            }
        } 
        #endregion

        #endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DataSet ds = SocketClient.GetKeyValue("select * from [User]");

            MessageForm.Show(UData.ToString(ds));
        }
    }
}
