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
using System.IO;
using WeifenLuo.WinFormsUI.Docking;

namespace App.Win
{
    public partial class GamesUc : DockContent
    {
        #region DataMember
        public const string Guid = "9028ef91-96d1-470e-a9f3-c74cc5fc263c";
        public const string GridBorderColor = "#f4f4f4";
        public FilterItems Filter = new FilterItems();
        public event EventHandler RefreshData; 
        #endregion

        #region Ctor
        public GamesUc()
        {
            InitializeComponent();
        } 
        #endregion

        #region Helper

        public void LoadGames(DataTable table)
        {
            int Index = 0;
            int ScrollIndex = 0;
            DataGridViewColumn oldColumn = new DataGridViewColumn();
            SortOrder so = SortOrder.None;
            if (dataGridView1 != null && dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    Index = dataGridView1.SelectedRows[0].Index;
                    ScrollIndex = dataGridView1.FirstDisplayedScrollingRowIndex;
                }
                oldColumn = dataGridView1.SortedColumn;
                so = dataGridView1.SortOrder;
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = null;

            if (Ap.CurrentUser.HumanRankIDE == RankE.Guest && Ap.SelectedRoomID != (int)RoomE.Cafe && Ap.SelectedRoomID != (int)RoomE.Broadcasts && Ap.SelectedRoomID != (int)RoomE.EngineHall)
            {
                return;
            }

           
            RefreshGrid(table);
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
            //dataGridView1.Refresh();
            if (dataGridView1.Rows.Count > Index)
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = ScrollIndex;
                dataGridView1.Rows[Index].Selected = true;
            }
            InitFilter();
        }

        private void InitFilter()
        {
            if (toolStripComboBox1.Items.Count > 0)
            {
                return;
            }
            
            Filter.Add("WhiteUserName", "White");
            Filter.Add("BlackUserName", "Black");
            Filter.Add("EloWhiteBefore", "EloWhite");
            Filter.Add("EloBlackBefore", "EloBlack");
            Filter.Add("Result", "Result");
            Filter.Add("TimeControl", "TimeControl");
            Filter.Add("StartTime", "StartTime");
            Filter.Add("Rated", "Type");
            
            toolStripComboBox1.ComboBox.DataSource = Filter.DataTable;
            toolStripComboBox1.ComboBox.DisplayMember = "Value";
            toolStripComboBox1.ComboBox.ValueMember = "Key";
            toolStripComboBox1.ComboBox.SelectedIndex = 0;
        }

        private void ViewGame(DataGridViewRow row)
        {
            if (row.Cells[9].Value.ToString() == "In progress")
            {
                if (Convert.ToInt32(row.Cells[3].Value) == Ap.CurrentUserID || Convert.ToInt32(row.Cells[6].Value) == Ap.CurrentUserID)
                {
                    return;
                }
            }
            if (row.Cells[0].Value != null && !String.IsNullOrEmpty(row.Cells[0].Value.ToString()) && (Ap.CurrentUser.UserStatusIDE == UserStatusE.Blank || Ap.CurrentUser.UserStatusIDE == UserStatusE.Engine || Ap.CurrentUser.UserStatusIDE == UserStatusE.Centaur))
            {
                int GameID = UData.ToInt32(row.Cells[0].Value);
                SocketClient.AddAudience(GameID);
                InfinityChess.WinForms.MainOnline.ShowMainOnline(GameID);
            }

        }

        private void RefreshGrid()
        {
            RefreshGrid((DataTable)dataGridView1.DataSource);
        }

        private void RefreshGrid(DataTable table)
        {
            dataGridView1.DataSource = Filter.SearchByValue(table, toolStripComboBox1, toolStripTextBox1);
        }

        public void LoadGames()
        {
            this.Cursor = System.Windows.Forms.Cursors.Default;
            if (!Ap.Options.ShowHorizontalGrid && !Ap.Options.ShowVerticalGrid)
            {
                dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            }
            else if (Ap.Options.ShowHorizontalGrid && !Ap.Options.ShowVerticalGrid)
            {
                dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            }
            else if (Ap.Options.ShowVerticalGrid && !Ap.Options.ShowHorizontalGrid)
            {
                dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            }
            else
            {
                dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            }
            dataGridView1.GridColor = ColorTranslator.FromHtml(GridBorderColor);
        }

        #endregion

        #region Events

        private void GamesUc_Load(object sender, EventArgs e)
        {
            LoadGames();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                SetGameType(e);
            }
        }

        private void SetGameType(DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1["GameTypeID", e.RowIndex].Value != null && dataGridView1["GameTypeID", e.RowIndex].Value.ToString() != "" && dataGridView1["GameTypeID", e.RowIndex].Value.ToString() != "0")
            {
                e.Value = Ap.GetGameTypeImage(dataGridView1[1, e.RowIndex].Value.ToString());
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            ViewGame(dataGridView1.Rows[e.RowIndex]);
        }

        private void toolStripButtonWatch_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount <= 0 || dataGridView1.SelectedRows == null || dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            foreach (DataGridViewRow dgvRow in dataGridView1.SelectedRows)
            {
                ViewGame(dgvRow);
                break;
            }
        }

        private void tsRefresh_Click(object sender, EventArgs e)
        {
            if (RefreshData != null)
            {
                RefreshData(this, EventArgs.Empty);
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrid();
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
