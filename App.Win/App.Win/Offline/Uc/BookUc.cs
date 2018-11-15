using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ChessLibrary;
using App.Model;
using InfinityChess.Offline.Forms;
using App.Win;
using WeifenLuo.WinFormsUI.Docking;
using InfinityChess.WinForms;

namespace InfinityChess
{
    public partial class BookUc : DockContent, IGameUc
    {
        #region Data Members

        public Game Game = null;
        public MainForm MainForm;

        public const string Guid = "4d61a896-3c82-4d13-886b-96998990d63d";

        bool updateNoOfGamesHeaderRequired = true;
        bool updatePercentageHeaderRequired = true;

        #endregion

        #region Ctor

        public BookUc(Game game,MainForm mainForm)
        {
            this.Game = game;
            this.MainForm = mainForm;
            InitializeComponent();
        }

        #endregion

        #region Events

        #region Load BookUc
        private void BookUc_Load(object sender, EventArgs e)
        {
        }
        #endregion

        #region btnLoadOpeningBook
        private void btnLoadOpeningBook_Click(object sender, EventArgs e)
        {
            LoadOpeningBookFromFile();
        }
        #endregion

        #region ts

        private void tsMainMove_Click(object sender, EventArgs e)
        {
            // Mark Green
            int rowIndex = dgvOpeningBook.SelectedCells[0].RowIndex;
            if (IsValidOpeningBookCellSelected(rowIndex, 0))
            {
                this.Game.Book.IsOpeningBookChanged = true;
                DataRow dr = this.Game.Book.BookMoves.DataTable.DefaultView[rowIndex].Row;
                BookMove m = new BookMove(dr);

                if (m.Flags.IsMainMove)
                {
                    m.Flags.IsMainMove = false;
                }
                else
                {
                    m.Flags.IsMainMove = true;
                    m.Flags.NotInTournament = false;
                }
            }
        }

        private void tsDontPlayTournamentMove_Click(object sender, EventArgs e)
        {
            // Mark Red
            int rowIndex = dgvOpeningBook.SelectedCells[0].RowIndex;
            if (IsValidOpeningBookCellSelected(rowIndex, 0))
            {
                this.Game.Book.IsOpeningBookChanged = true;
                DataRow dr = this.Game.Book.BookMoves.DataTable.DefaultView[rowIndex].Row;
                BookMove m = new BookMove(dr);

                if (m.Flags.NotInTournament)
                {
                    m.Flags.NotInTournament = false;
                }
                else
                {
                    m.Flags.NotInTournament = true;
                    m.Flags.IsMainMove = false;
                }
            }
        }

        private void tsMoveTypeNone_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvOpeningBook.SelectedCells[0].RowIndex;
            int columnIndex = dgvOpeningBook.SelectedCells[0].ColumnIndex;
            if (IsValidOpeningBookCellSelected(rowIndex, columnIndex))
            {
                this.Game.Book.IsOpeningBookChanged = true;
                DataRow dr = this.Game.Book.BookMoves.DataTable.DefaultView[rowIndex].Row;
                dr[BookMove.ColumnMoveType] = string.Empty;
            }
            dgvOpeningBook.Refresh();
        }

        private void tsMoveTypeFreeze_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvOpeningBook.SelectedCells[0].RowIndex;
            int columnIndex = dgvOpeningBook.SelectedCells[0].ColumnIndex;
            if (IsValidOpeningBookCellSelected(rowIndex, columnIndex))
            {
                this.Game.Book.IsOpeningBookChanged = true;
                DataRow dr = this.Game.Book.BookMoves.DataTable.DefaultView[rowIndex].Row;
                dr[BookMove.ColumnMoveType] = "?";
            }
            dgvOpeningBook.Refresh();
        }

        private void tsChangeWeight_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvOpeningBook.SelectedCells[0].RowIndex;
            if (IsValidOpeningBookCellSelected(rowIndex, 0))
            {
                this.Game.Book.IsOpeningBookChanged = true;
                DataRow dr = this.Game.Book.BookMoves.DataTable.DefaultView[rowIndex].Row;
                int currentMoveWeight = Convert.ToInt32(dr[BookMove.ColumnFact]);
                ChangeWeightPopup frm = new ChangeWeightPopup(currentMoveWeight);
                DialogResult dialogResult = frm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    dr[BookMove.ColumnFact] = frm.MoveWeight;
                }
            }
        }

        private void tsLoadBook_Click(object sender, EventArgs e)
        {
            LoadOpeningBookFromFile();
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            bool isBookChanged = this.Game.Book.IsOpeningBookChanged;
            this.Game.Book.Save();

            if (isBookChanged)
            {
                UpdateBook();
            }
        }

        private void tsAllowMoveAdding_Click(object sender, EventArgs e)
        {
            tsAllowMoveAdding.Checked = !tsAllowMoveAdding.Checked;
            this.Game.Book.BookMoves.AllowMoveAdding = tsAllowMoveAdding.Checked;
        }

        private void tsCloseBook_Click(object sender, EventArgs e)
        {
            if (this.Game.Book.IsOpeningBookChanged)
            {
                DialogResult dialogResult = MessageForm.Confirm(this.ParentForm, MsgE.ConfirmSaveChanges);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Game.Book.Save();
                    UpdateBook();
                }
            }
            SetCloseBookLayout();
            this.Game.Book.Close();
            Options.Instance.CurrentBookFilePath = null;
        }

          private void importPGNGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MainForm.ImportPgnGame();
        }

        private void importGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MainForm.ImportGame();
        }

        void bookOptionsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            BookOptionsPopup frm = new BookOptionsPopup(this.Game);
            frm.ShowDialog();
        }

        void newOpeningBookToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.MainForm.NewOpeningBook();
        }

        #endregion

        #region dgvOpeningBook

        private void dgvOpeningBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Game.Book.BookMoves.rowIndex = e.RowIndex;
            this.Game.MoveTo(MoveToE.Next, true);
        }

        private void dgvOpeningBook_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dgvOpeningBook.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            }
        }

        private void dgvOpeningBook_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            UpdateCurrentCell(e);
        }

        private void dgvOpeningBook_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOpeningBook.CurrentCell == null)
            {
                return;
            }

            int r = dgvOpeningBook.CurrentCell.RowIndex;
            int c = dgvOpeningBook.CurrentCell.ColumnIndex;

            this.Game.Book.SetCurrentRowIndex(r);
        }

        #endregion

        #region Book
        void Book_OnPointTo(object sender, EventArgs e)
        {
            SelectCell(this.Game.Book.GetCurrentRowIndex());
        }

        void Book_BookClosed(object sender, EventArgs e)
        {
            SetCloseBookLayout();
        }

        void Book_BookLoaded(object sender, EventArgs e)
        {
            BookLoaded();
        } 
        #endregion

        #endregion

        #region Helpers

        private void LoadOpeningBookFromFile()
        {
            ofdLoadOpeningBook.Filter = "InfinityChess Opening Book icb(*" + Files.OpeningBookExtension + ")|*" + Files.OpeningBookExtension;
            ofdLoadOpeningBook.FileName = "*" + Files.OpeningBookExtension;
            //ofdLoadOpeningBook.InitialDirectory = Ap.FolderBooks;

            if (ofdLoadOpeningBook.ShowDialog() == DialogResult.OK)
            {
                Options.Instance.CurrentBookFilePath = ofdLoadOpeningBook.FileName;
                LoadBook();
            }
        }

        private void InitializeGridHeaders()
        {
            dgvOpeningBook.Columns["To"].HeaderText = this.Game.Book.FileName;
        }

        private void SetCloseBookLayout()
        {
            this.Game.Book.IsOpeningBookChanged = false;
            dgvOpeningBook.Visible = false;
            btnLoadOpeningBook.Visible = true;
            dgvOpeningBook.Columns[1].HeaderText = string.Empty;
        }

        private void BookLoaded()
        {
            //// setup layout
            dgvOpeningBook.Visible = true;
            btnLoadOpeningBook.Visible = false;
            InitializeGridHeaders();

            //// initialize variables
            this.Game.Book.IsOpeningBookChanged = false;

            updateNoOfGamesHeaderRequired = false;
            updatePercentageHeaderRequired = true;
            this.Game.Book.IsOpeningBookChanged = false;
            this.Game.Book.BookMoves.AllowMoveAdding = false;
            tsAllowMoveAdding.Checked = false;
            FocusToGrid();
        }

        private void UpdateCurrentCell(DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                //// set columns other than first column, to be seems like un-selectable
                if (dgvOpeningBook.Columns[e.ColumnIndex].DataPropertyName != BookMove.ColumnTo)
                {
                    e.CellStyle.BackColor = SystemColors.Control;
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.SelectionBackColor = SystemColors.Control;
                    e.CellStyle.SelectionForeColor = Color.Black;
                }

                if (this.Game.Book == null || this.Game.Book.BookMoves == null)
                    return;

                if (e.RowIndex >= this.Game.Book.BookMoves.DataTable.DefaultView.Count)
                {
                    return;
                }

                BookMove bm = new BookMove(this.Game.Book.BookMoves.DataTable.DefaultView[e.RowIndex].Row);

                if (bm == null)
                {
                    return;
                }

                bool isItalic = bm.BookMoveFlags.Contains("T");

                if (isItalic)
                {
                    if (e.RowIndex >= 0 && dgvOpeningBook.Columns[e.ColumnIndex].DataPropertyName == BookMove.ColumnTo)
                    {
                        e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Italic);
                        if (bm.IsWhite)
                        {
                            e.Value = bm.MoveNumber + "." + GetMoveDisplay(bm);
                        }
                        else
                        {
                            e.Value = bm.MoveNumber + "..." + GetMoveDisplay(bm);
                        }
                    }
                    else
                    {
                        e.Value = "";
                    }
                    return;
                }

                if (e.RowIndex >= 0 && dgvOpeningBook.Columns[e.ColumnIndex].DataPropertyName == BookMove.ColumnTo) // for Notations(move) column
                {
                    if (bm.IsWhite)
                    {
                        e.Value = bm.MoveNumber + "." + GetMoveDisplay(bm);
                    }
                    else
                    {
                        e.Value = bm.MoveNumber + "..." + GetMoveDisplay(bm);
                    }

                    bool isMainMove = bm.Flags.IsMainMove;
                    bool dontPlayInTournament = bm.Flags.NotInTournament;

                    if (isMainMove)
                    {
                        e.CellStyle.ForeColor = Color.Green;
                    }
                    else if (dontPlayInTournament)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                    }

                    switch (bm.MoveType)
                    {
                        case "":
                            if (!isMainMove && !dontPlayInTournament)
                                e.CellStyle.ForeColor = Color.Black;
                            break;
                        case "?":
                            if (!isMainMove && !dontPlayInTournament)
                                e.CellStyle.ForeColor = Color.Blue;
                            e.Value = e.Value + " ?";
                            break;
                        default:
                            break;
                    }

                }
                else if (e.RowIndex >= 0 && dgvOpeningBook.Columns[e.ColumnIndex].DataPropertyName == BookMove.ColumnWinCount) // for "N" column
                {
                    if (updateNoOfGamesHeaderRequired)
                    {
                        int totalGames=bm.WinCount +Convert.ToInt32(bm.DrawCount) +Convert.ToInt32(bm.LostCount);
                        string noOfGames = totalGames.ToString();
                        updateNoOfGamesHeaderRequired = false;
                    }
                }
                else if (e.RowIndex >= 0 && dgvOpeningBook.Columns[e.ColumnIndex].DataPropertyName == BookMove.ColumnPercentage)// for first "%" column
                {
                    int whiteWin = 0;
                    double whiteDraw = 0;
                    if(bm.DrawCount.ToString() == "0.5")
                    {
                        bm.DrawCount=1;
                    }
                    int noOfGames = bm.WinCount + Convert.ToInt32(bm.DrawCount) +Convert.ToInt32(bm.LostCount);
                    string strWhiteWin = bm.WinCount.ToString();
                    string strWhiteDraw = bm.DrawCount.ToString();
                    double whitePercentage = 0;
                    double blackPercentage;

                    if (!string.IsNullOrEmpty(strWhiteWin))
                    {
                        whiteWin = Convert.ToInt32(strWhiteWin);
                    }

                    if (!string.IsNullOrEmpty(strWhiteDraw))
                    {
                        whiteDraw = Convert.ToDouble(strWhiteDraw);
                    }

                    bool isWhite;
                    if (this.Game.Flags.IsFirtMove)
                    {
                        isWhite = this.Game.InitialIsWhite;
                    }
                    else
                    {
                        isWhite = this.Game.InitialIsWhite;
                    }
                    if (isWhite)
                    {
                        if ((whiteWin + whiteDraw) < 1)
                            whitePercentage = 0;
                        else
                            whitePercentage = Math.Round(((whiteWin + whiteDraw) / noOfGames) * 100, 0);

                        e.Value = whitePercentage;

                        if (updatePercentageHeaderRequired)
                        {
                            updatePercentageHeaderRequired = false;
                        }
                    }
                    else
                    {
                        if ((noOfGames - (whiteWin + whiteDraw)) == 0)
                            blackPercentage = 0;
                        else
                            blackPercentage = Math.Round(((noOfGames - (whiteWin + whiteDraw)) / noOfGames) * 100, 0);

                        e.Value = blackPercentage;

                        if (updatePercentageHeaderRequired)
                        {
                            dgvOpeningBook.Columns[e.ColumnIndex].HeaderText = "%" + "(" + blackPercentage + ")";
                            updatePercentageHeaderRequired = false;
                        }
                    }

                }
                else if (e.RowIndex >= 0 && dgvOpeningBook.Columns[e.ColumnIndex].DataPropertyName == BookMove.ColumnFact) // for "Fact" column
                {
                    int fact = Convert.ToInt32(e.Value);

                    if (fact < 0)
                        e.CellStyle.ForeColor = Color.Red;
                    else if (fact == 0)
                        e.CellStyle.ForeColor = Color.Black;
                    else if (fact > 0)
                        e.CellStyle.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                throw ex;
            }
        }

        private string GetMoveDisplay(BookMove bm)
        {
            string moveDisplay = string.Empty;

            App.Model.Move m = App.Model.Move.NewMove();
            m.Game = this.Game;

            m.From = bm.FromSquare;
            m.To = bm.ToSquare;
            m.PieceStr = bm.MovePiece;
            m.MoveFlags = bm.BookMoveFlags;
            moveDisplay = m.Notation;
            moveDisplay = moveDisplay.Substring(moveDisplay.IndexOf(".") + 1);

            return moveDisplay;
        }

        public void FocusToGrid()
        {
            dgvOpeningBook.Focus();
        }

        private bool IsValidOpeningBookCellSelected(int rowIndex, int columnIndex)
        {
            bool isValid = false;

            if (rowIndex >= 0 && rowIndex < dgvOpeningBook.Rows.Count && columnIndex == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public void SelectCell(int rowIndex)
        {
            if (rowIndex == -1)
            {
                return;
            }

            dgvOpeningBook.DataSource = this.Game.Book.BookMoves.DataTable;

            if (dgvOpeningBook.ColumnCount >= 5 && rowIndex < dgvOpeningBook.RowCount)
            {
                dgvOpeningBook.CurrentCell = dgvOpeningBook[5, rowIndex];
            }
        }

        private void UpdateBook()
        {
            if (EngineVsEngine.BookWhite != null && EngineVsEngine.BookWhite.FilePath == this.Game.Book.FilePath)
            {
                EngineVsEngine.BookWhite.Reload();
            }
            if (EngineVsEngine.BookBlack != null && EngineVsEngine.BookBlack.FilePath == this.Game.Book.FilePath)
            {
                EngineVsEngine.BookBlack.Reload();
            }
        }


        public void DeAttachBook()
        {
            DataTable dt = this.Game.Book.BookMoves.DataTable.Clone();
            dgvOpeningBook.DataSource = dt;
            InitializeGridHeaders();
        }

        public void AttachBook()
        {
            dgvOpeningBook.DataSource = this.Game.Book.BookMoves.DataTable;
            InitializeGridHeaders();
        }

        public void LoadBookGridHeaders()
        {
            InitializeGridHeaders();
        }


        #endregion

        #region Load

        public void LoadBook()
        {
            try
            {
                ProgressForm frm = ProgressForm.Show(this, "Loading Book....");
                if (!this.Game.Book.Load(Options.Instance.CurrentBookFilePath))
                {
                    MessageForm.Error(this.ParentForm, MsgE.ErrorInvalidFileFormat);
                }           
                frm.Close();
            }
            catch (FormatException ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Error(this.ParentForm, MsgE.ErrorInvalidFileFormat);
                return;
            }
        }
        
        #endregion

        #region IGameUc Members

        public void NewGame()
        {
            tsAllowMoveAdding.Checked = false;

            if (!this.Game.Book.IsClosed)
            {
                BookLoaded();
            }
            dgvOpeningBook.DataSource = this.Game.Book.BookMoves.DataTable;
            InitializeGridHeaders();
        }

        public void Init()
        {
            dgvOpeningBook.DataSource = this.Game.Book.BookMoves.DataTable;

            dgvOpeningBook.Dock = DockStyle.Fill;

            this.Game.Book.OnPointTo += new EventHandler(Book_OnPointTo);
            this.Game.Book.BookLoaded += new EventHandler(Book_BookLoaded);
            this.Game.Book.BookClosed += new EventHandler(Book_BookClosed);
            this.Game.Book.MoveToEventE += new Book.MoveToEventHandler(Book_MoveToEvent);
            this.Game.Book.MoveToEvent += new EventHandler(Book_MoveToEvent);

        }

        public void UnInit()
        {
            this.Game.Book.OnPointTo -= new EventHandler(Book_OnPointTo);
            this.Game.Book.BookLoaded -= new EventHandler(Book_BookLoaded);
            this.Game.Book.BookClosed -= new EventHandler(Book_BookClosed);
            this.Game.Book.MoveToEventE -= new Book.MoveToEventHandler(Book_MoveToEvent);
            this.Game.Book.MoveToEvent -= new EventHandler(Book_MoveToEvent);
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