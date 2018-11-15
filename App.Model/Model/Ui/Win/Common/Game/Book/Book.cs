using System;
using App.Model;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.IO;
using InfinitySettings.Streams;
using InfinitySettings.UCIManager;
using System.Configuration;
using System.Diagnostics;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;

namespace App.Model
{
    public partial class Book
    {
        #region Data Members
        public Game Game = null;
        private BookOptions bookOptions;
        public BookMoves BookMoves = null;
        private Moves NotationsTree;
        private Moves NotationsLastMoveBranch;
        private Move PointToMove = null;  // move where book is currently pointing to
        public Dictionary<string, DataRow> BookMovesCollection = null;
        public Dictionary<string, string> BookMovesFen = null;
        string MoveKey = string.Empty;
        public string FilePath;
        public string FileName;
        string bookOptionsFilter = string.Empty;
        private long lastMoveIdProcessed = 0;
        private bool isImportInProgress = false;
        private int newPositionsImported = 0;
        int NoOfTranspos = 0;
        int TransposedMoveRowId = 0;

        private bool isClosed;
        private bool isExpired = false;
        public bool IsOpeningBookChanged;
        public bool AllowMoveAdding = false;

        #endregion

        #region Delegate / Events

        public event UCIEngine.MoveReceivedHandler MoveReceived;
        public event EventHandler BookLoaded;
        public event EventHandler BookClosed;
        public event EventHandler OnPointTo;
        #endregion

        #region Properties

        bool HasGame
        {
            get { return this.Game != null; }
        }

        public bool IsClosed
        {
            [DebuggerStepThrough]
            get { return isClosed; }
        }

        public bool IsExpired
        {
            [DebuggerStepThrough]
            get
            {
                return isExpired || isClosed;
            }
        }

        public bool IsAvailable
        {
            [DebuggerStepThrough]
            get
            {
                return !IsExpired && BookOptions.UseBook;
            }
        }

        public int NewPositionsImported
        {
            [DebuggerStepThrough]
            get { return newPositionsImported; }

            [DebuggerStepThrough]
            set { newPositionsImported = value; }

        }

        public BookOptions BookOptions
        {
            get { return bookOptions; }
        }

        public bool IsImportInProgress
        {
            [DebuggerStepThrough]
            get
            {
                return isImportInProgress;
            }
            [DebuggerStepThrough]
            set
            {
                isImportInProgress = value;
            }
        }

        #endregion

        #region Ctor
        public Book(Game game)
        {
            Game = game;
            BookMoves = new BookMoves();
            BookMoves.Game = this.Game;
            LoadBookMovesDictionary();
        }

        public Book(Game game, string fileName)
        {
            Game = game;
            BookMoves = new BookMoves();
            BookMoves.Game = this.Game;
            Load(fileName);
        }

        #endregion

        #region Load
        public bool Load(string fileName)
        {
            isExpired = false;

            if (string.IsNullOrEmpty(fileName))
            {
                fileName = Ap.Options.CurrentBookFilePath;
                if (string.IsNullOrEmpty(fileName))
                {
                    isClosed = true;
                    Close();

                    return true;
                }
            }
            else
            {
                SetCurrentBookInOptions(fileName);
            }

            if (FilePath == Options.Instance.CurrentBookFilePath)
            {
                return true; // book is already loaded
            }

            FilePath = fileName;
            FileName = System.IO.Path.GetFileName(fileName);
            return Load();
        }

        public void LoadBookMovesDictionary()
        {

            if (BookMovesCollection == null)
            {
                BookMovesCollection = new Dictionary<string, DataRow>();
            }
            else
            {
                BookMovesCollection.Clear();
            }

            if (BookMovesFen == null)
            {
                BookMovesFen = new Dictionary<string, string>();
            }
            else
            {
                BookMovesFen.Clear();
            }

            string key = string.Empty;
            foreach (DataRow dr in BookMoves.DataTable.Rows)
            {
                key = dr[BookMove.ColumnMoveNumber].ToString() + dr[BookMove.ColumnWhiteMove] + dr[BookMove.ColumnParentId] + dr[BookMove.ColumnFrom] + dr[BookMove.ColumnTo];
                BookMovesCollection.Add(key, dr);
                BookMovesFen.Add(key, dr[BookMove.ColumnFen].ToString());
            }
        }

        private bool Load()
        {
            BookMoves.DataTable.Clear();

            if (File.Exists(FilePath))
            {
                //// load book's table

                MemoryStream memoryStream = InfinityStreamsManager.ReadStreamFromFile(FilePath);
                BookMoves.DataTable.ReadXml(memoryStream);
                memoryStream.Close();

                if (BookMoves.DataTable.Rows.Count == 0)
                    BookMoves.AddRootRow();
            }
            else
            {
                BookMoves.AddRootRow();
            }

            SetOptions();

            isClosed = false;

            if (HasGame)
            {
                PointTo(this.Game.CurrentMove);
            }

            if (BookLoaded != null)
            {
                BookLoaded(this, EventArgs.Empty);
            }
            LoadBookMovesDictionary();
            return true;
        }

        public bool Reload()
        {
            return Load();
        }

        public void SetCurrentBookInOptions(string filePath)
        {
            Ap.Options.CurrentBookFilePath = filePath;
            Ap.Options.Save();
        }

        public void NewGame()
        {
            BookMoves.AllowMoveAdding = false;
            BookMoves.RemoveTempMoves();
            BookMovesCollection.Clear();
            LoadBookMovesDictionary();
            isExpired = false;
            PointTo(Game.CurrentMove);
        }
        #endregion

        #region Save

        public void Save()
        {
            IsOpeningBookChanged = false;
            try
            {
                if (BookMovesCollection.Count > 0)
                {
                    MemoryStream memoryStream = new MemoryStream();
                    BookMoves.DataTable = BookMovesCollection.Values.CopyToDataTable<DataRow>();
                    BookMoves.DataTable.DefaultView.RowFilter = BookMove.ColumnMoveFlags + " Not like '%T%'";
                    BookMoves.DataTable = BookMoves.DataTable.DefaultView.ToTable("B");
                    BookMoves.DataTable.WriteXml(memoryStream);
                    InfinityStreamsManager.WriteStreamToFile(FilePath, memoryStream);
                    memoryStream.Close();
                    memoryStream.Dispose();
                    memoryStream = null;
                    PointToMove = null;
                    PointTo(Game.CurrentMove);
                 }
            }
            catch (OutOfMemoryException ex)
            {
                BookMoves.DataTable.Clear();
                LoadBookMovesDictionary();
                newPositionsImported = 0;
                MessageForm.Show("An error occurred, please try import games again");
                
            }
        }

        public void SaveAsync()
        {
            System.Threading.ThreadPool.QueueUserWorkItem(SaveAsync);
        }

        private void SaveAsync(object state)
        {
            Save();
        }

        public void AppendFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                DataTable tempBookData = BookMoves.GetBookMovesTable();

                MemoryStream memoryStream = InfinityStreamsManager.ReadStreamFromFile(filePath);
                tempBookData.ReadXml(memoryStream);
                memoryStream.Close();

                BookMoves.DataTable.Merge(tempBookData);
            }
        }
        #endregion

        #region Close

        public void Close()
        {
            if (BookMoves != null)
            {
                BookMoves.DataTable.Clear();
            }
            FilePath = null;
            FileName = null;
            isClosed = true;
            SetCurrentBookInOptions(null);
            if (BookMovesCollection != null)
            {
                BookMovesCollection.Clear();
                BookMovesFen.Clear();
            }
            OnCloseBook();
        }

        private void OnCloseBook()
        {
            if (BookClosed != null)
            {
                BookClosed(this, EventArgs.Empty);
            }
        }

        #endregion

        #region Import
        /// <summary>
        /// 1. Extract MainLine for the current gameItem.
        /// 2. Sort MainLine in Ascending Order by MoveId(as we could disrtubed move's order in recusrsion process).
        /// 3. Transpose MainLine
        /// 4. Import MainLine
        /// </summary>
        /// <param name="gameItem"></param>
        public void ImportGame(GameItem gameItem)
        {
           
            if (!gameItem.HasMoves) // if have no moves, then return. nothing to import.
            {
                return;
            }

            // 1. Extract MainLine for the current gameItem.
            Moves branchMoves = GetLastMovesBranch(gameItem.Moves);
            if (branchMoves == null)
            {
                return;
            }

            lastMoveIdProcessed = 0;
            string sortExpression = string.Empty;
            bool isTransposed = false;

            //2. Sort MainLine in Ascending Order by MoveId(as we could disrtubed move's order in recusrsion process).
            branchMoves.DataTable = SetBranchTable(branchMoves.DataTable);

            // clear fields, no of transpositions and id to be transposed
            NoOfTranspos = 0;
            TransposedMoveRowId = 0;

            //3. Transpose MainLine
            isTransposed = TransposeBranch(gameItem, branchMoves);

            // 4. Import MainLine
            ImportBranch(gameItem, branchMoves);
        }

        /// <summary>
        /// Transpose MainLine
        /// 1. Get Last Move
        /// 2. Find matching Moves(from book, if any exists) for LastMove's fen(position)
        /// 3. Tranpose(Update some columns like, NoOfGame,EloAverage, Result etc ) matched items
        ///    Tranpose : Update fields for all games(or moves) of book whereever LastMove's fen is matched
        /// </summary>
        /// <param name="gameItem"></param>
        /// <param name="branchMoves"></param>
        /// <returns></returns>
        private bool TransposeBranch(GameItem gameItem, Moves branchMoves)
        {
            bool isTransposed = false;
            lastMoveIdProcessed = 0;
            string filter = string.Empty;

            DataRow movesLastRow = null;

            // 1. Get Last Move
            if (branchMoves.DataTable.Rows.Count > 0)
            {
                movesLastRow = branchMoves.DataTable.Rows[branchMoves.Count - 1];
            }

            string fen = ChessLibrary.FenParser.GetOnlyFen(movesLastRow[Moves.Fen].ToString());

            // 2. Find matching Moves(from book, if any exists) for LastMove's fen(position)
            //filter = BookMove.ColumnFen + " like '%" + fen + "%'";
            StringBuilder transposedMovesRowKey = new StringBuilder();
            if (BookMovesFen.ContainsValue(fen))
            {
                int fenMatchCount = 0;
                foreach (KeyValuePair<string, string> item in BookMovesFen)
                {
                    if (item.Value == fen)
                    {
                        if (fenMatchCount > 0)
                        {
                            transposedMovesRowKey.Append(",");
                        }
                        transposedMovesRowKey.Append(item.Key);
                        fenMatchCount++;
                    }
                }

                string[] matchedKeys = transposedMovesRowKey.ToString().Split(',');

                foreach (string item in matchedKeys)
                {
                    DataRow bookRow = BookMovesCollection[item] as DataRow;
                    UpdateBookRow(gameItem, movesLastRow, bookRow, false);
                    isTransposed = true;

                    // set NoOfTranpose and MoveId to be tranposed for temporary purpose which we will use in ImportBranch
                    switch (gameItem.GameData.Result)
                    {
                        case "1-0":
                            NoOfTranspos = Convert.ToInt32(bookRow[BookMove.ColumnWinCount]);  // no of games (transposed)
                            break;
                        case "1/2-1/2":
                            NoOfTranspos = Convert.ToInt32(bookRow[BookMove.ColumnDrawCount]); // no of games (transposed)
                            break;
                        case "0-1":
                            NoOfTranspos = Convert.ToInt32(bookRow[BookMove.ColumnLoseCount]); // no of games (transposed)
                            break;
                    }

                    //NoOfTranspos = Convert.ToInt32(bookRow[BookMove.ColumnWinCount]);
                }

            }
            return isTransposed;
        }

        /// <summary>
        /// Import MainLine
        /// 1.Iterate on each move in MainLine, check if any move is already exists in book then update otherwise add.        
        /// </summary>
        /// <param name="gameItem"></param>
        /// <param name="branchMoves"></param>
        private void ImportBranch(GameItem gameItem, Moves branchMoves)
        {
            bool currentNodeMatched = false;
            string filter = string.Empty;
            string fen = gameItem.GameData.InitialBoardFen;

            if (ChessLibrary.FenParser.IsInitialFen(fen) || string.IsNullOrEmpty(fen))
            {
                lastMoveIdProcessed = 0;// 0 is the root row(move), by default root is the "last move" being processed in import game.                
            }
            else
            {
                lastMoveIdProcessed = -1;// -1 is the root row(move), if game not started from initial board fen.
            }

            // as we have root row already in book,
            // and every new branch's first move treated as child of this root move
            // so we assume that "lastNodeMatched = true" for every new branch's first move
            bool lastNodeMatched = true; // can also be callled "ParentNode"

            foreach (DataRow moveRow in branchMoves.DataTable.Rows)
            {
                // set current node(moves) matched = false
                currentNodeMatched = false;

                // if last node(move) matched(means current move's parent is matched)
                MoveKey = moveRow[Moves.No].ToString() + moveRow[Moves.White].ToString() + lastMoveIdProcessed.ToString() + moveRow[Moves.FromSquare].ToString() + moveRow[Moves.ToSquare].ToString();
                if (lastNodeMatched)
                {
                    // current move = current row;
                    // check current move's these field to know if this move is already present in book :
                    // 1. Move Number
                    // 2. Is White Move ?
                    // 3. From (square)
                    // 4. To (square)
                    // 5. Parent (last moveId processed)

                    //filter = BookMove.ColumnMoveNumber + " = " + moveRow[Moves.No] + " and " + BookMove.ColumnWhiteMove + " = " + moveRow[Moves.White];
                    //filter += " and " + BookMove.ColumnFrom + " = '" + moveRow[Moves.FromSquare] + "' and ";
                    //if (lastMoveIdProcessed != 0)
                    //{
                    //    filter += BookMove.ColumnParentId + " = " + lastMoveIdProcessed.ToString() + " and ";
                    //}
                    //filter += BookMove.ColumnTo + " = '" + moveRow[Moves.ToSquare] + "'";

                    //DataRow[] bookRows = BookMoves.DataTable.Select(filter);

                    //filter = BookMove.ColumnMoveKey + " = '" + MoveKey + "'";
                    //DataRow[] bookRows = BookMoves.DataTable.Select(filter);

                    if (BookMovesCollection.ContainsKey(MoveKey))
                    //if(bookRows.Length > 0)
                    {
                        DataRow bookRow = BookMovesCollection[MoveKey] as DataRow;
                        //DataRow bookRow = bookRows[0] as DataRow;

                        if (bookRow != null) // if move already present in book
                        {
                            currentNodeMatched = true;
                            // now this current node(move) is now become our last move
                            lastMoveIdProcessed = Convert.ToInt64(bookRow[BookMove.ColumnId]);
                            // now update this row(move) in book
                            UpdateBookRow(gameItem, moveRow, bookRow, false);
                        }
                    }

                }

                // if current node(move) not matched
                if (!currentNodeMatched)
                {
                    // set last node(move) matched = false, 
                    // this is current node (and not matched)
                    // so it behaves as "lastNodeMatched =false" in next iteration
                    lastNodeMatched = false;
                    if (!BookMovesCollection.ContainsKey(MoveKey))
                    {
                        UpdateBookRow(gameItem, moveRow, null, true);
                    }
                }
            }
        }

        private bool IsParentMatched(DataRow moveRow, DataRow bookRow)
        {
            bool matched = false;

            // if any one table has only one row, then assume that parents are matched.
            if (moveRow.Table.Rows.Count == 1 || bookRow.Table.Rows.Count == 1) // if has only one row, then return.
            {
                return true;
            }

            // get move's parent
            DataRow[] moveRows = moveRow.Table.Select(Moves.Id + " = " + moveRow[Moves.Pid]); // get move's parent row
            if (moveRows.Length > 0)
            {
                DataRow mpRow = moveRows[0];

                // get book's move's parent
                DataRow[] bookRows = BookMoves.DataTable.Select(BookMove.ColumnId + " = " + bookRow[BookMove.ColumnParentId]); // get book's parent row
                if (bookRows.Length > 0)
                {
                    DataRow bpRow = bookRows[0];

                    // check, if parent rows(move's parent & book's move's pparent) matched.
                    if (mpRow[Moves.No].ToString() == bpRow[BookMove.ColumnMoveNumber].ToString()
                        && mpRow[Moves.White].ToString() == bpRow[BookMove.ColumnWhiteMove].ToString()
                        && mpRow[Moves.FromSquare].ToString() == bpRow[BookMove.ColumnFrom].ToString()
                        && mpRow[Moves.ToSquare].ToString() == bpRow[BookMove.ColumnTo].ToString()
                        )
                    {
                        // check further next parents
                        matched = IsParentMatched(mpRow, bpRow);
                    }
                }
            }
            else
            {
                matched = true;
            }

            return matched;
        }



        /// <summary>
        /// Import MainLine's move in Book, or update if already exsits
        /// </summary>
        /// <param name="gameItem"></param>
        /// <param name="moveRow"></param>
        /// <param name="bookRow"></param>
        /// <param name="doAdd"></param>
        private void UpdateBookRow(GameItem gameItem, DataRow moveRow, DataRow bookRow, bool doAdd)
        {
            if (doAdd)
            {
                #region Add Move
                DataRow tempBookRow = BookMoves.DataTable.NewRow();
                tempBookRow[BookMove.ColumnFrom] = moveRow[Moves.FromSquare].ToString(); // from
                tempBookRow[BookMove.ColumnTo] = moveRow[Moves.ToSquare].ToString(); // to

                if (NoOfTranspos > 0 && TransposedMoveRowId == Convert.ToInt32(moveRow[Moves.Id]))
                {
                    switch (gameItem.GameData.Result)
                    {
                        case "1-0":
                            tempBookRow[BookMove.ColumnWinCount] = NoOfTranspos; // no of games (transposed)
                            break;
                        case "1/2-1/2":
                            tempBookRow[BookMove.ColumnDrawCount] = NoOfTranspos; // no of games (transposed)
                            break;
                        case "0-1":
                            tempBookRow[BookMove.ColumnLoseCount] = NoOfTranspos; // no of games (transposed)
                            break;
                    }
                }
                else
                {
                    switch (gameItem.GameData.Result)
                    {
                        case "1-0":
                            tempBookRow[BookMove.ColumnWinCount] = 1;
                            tempBookRow[BookMove.ColumnDrawCount] = 0;
                            tempBookRow[BookMove.ColumnLoseCount] = 0;
                            break;
                        case "1/2-1/2":
                            tempBookRow[BookMove.ColumnWinCount] = 0;
                            tempBookRow[BookMove.ColumnDrawCount] = 1;
                            tempBookRow[BookMove.ColumnLoseCount] = 0;
                            break;
                        case "0-1":
                            tempBookRow[BookMove.ColumnWinCount] = 0;
                            tempBookRow[BookMove.ColumnDrawCount] = 0;
                            tempBookRow[BookMove.ColumnLoseCount] = 1;
                            break;
                    }
                }

                tempBookRow[BookMove.ColumnPercentage] = 0; // percentage                
                tempBookRow[BookMove.ColumnPref] = 0; // pref
                tempBookRow[BookMove.ColumnFact] = 0; // fact
                tempBookRow[BookMove.ColumnProb] = 0; // prob
                tempBookRow[BookMove.ColumnPercentageTotal] = 0; // percentage total
               
                tempBookRow[BookMove.ColumnWhiteMove] = moveRow[Moves.White].ToString() == "1"; // isWhite
                tempBookRow[BookMove.ColumnMoveNumber] = Convert.ToInt32(moveRow[Moves.No]); // move number

                if (Convert.ToBoolean(tempBookRow[BookMove.ColumnWhiteMove]) == true)
                {
                    tempBookRow[BookMove.ColumnAverage] = (long)gameItem.GameData.EloWhite; // average
                }
                else
                {
                    tempBookRow[BookMove.ColumnAverage] = (long)gameItem.GameData.EloBlack; // average
                }


                tempBookRow[BookMove.ColumnFen] = ChessLibrary.FenParser.GetOnlyFen(moveRow[Moves.Fen].ToString()); // fen
                tempBookRow[BookMove.ColumnMoveType] = ""; // move type

                // move processed in last iteration  => lastMoveIdProcessed
                // so that is the parent of our current move
                tempBookRow[BookMove.ColumnParentId] = lastMoveIdProcessed; // parent id
                tempBookRow[BookMove.ColumnMovePiece] = moveRow[Moves.Pce].ToString(); // piece
                tempBookRow[BookMove.ColumnMoveFlags] = moveRow[Moves.MoveFlags].ToString() + Moves.MainMove; // move flags
                tempBookRow[BookMove.ColumnCapturedPiece] = moveRow[Moves.CapturedPce].ToString(); // captured piece

                //tempBookRow[BookMove.ColumnId] = BookMoves.GetNextMoveId(); // get maximum id
                tempBookRow[BookMove.ColumnMoveKey] = MoveKey;
                tempBookRow[BookMove.ColumnId] = BookMovesCollection.Count; // get maximum id

                //BookMoves.DataTable.Rows.Add(tempBookRow);
                BookMovesFen.Add(MoveKey, ChessLibrary.FenParser.GetOnlyFen(moveRow[Moves.Fen].ToString()));
                if (!BookMovesCollection.ContainsKey(MoveKey))
                {
                    BookMovesCollection.Add(MoveKey, tempBookRow);
                }
                lastMoveIdProcessed = Convert.ToInt64(tempBookRow[BookMove.ColumnId]);

                newPositionsImported++;
                #endregion
            }
            else
            {
                #region Update Move

                // set no. of games = no. of games +1 each time new game is imported.
                int noOfGames = 0;
                switch (gameItem.GameData.Result)
                {
                    case "1-0":
                        bookRow[BookMove.ColumnWinCount] = Convert.ToInt32(bookRow[BookMove.ColumnWinCount]) + 1;
                        noOfGames = Convert.ToInt32(bookRow[BookMove.ColumnWinCount]); // no of games (transposed)
                        break;
                    case "1/2-1/2":
                        bookRow[BookMove.ColumnDrawCount] = Convert.ToInt32(bookRow[BookMove.ColumnDrawCount]) + 1; // no of games (transposed)
                        noOfGames = Convert.ToInt32(bookRow[BookMove.ColumnDrawCount]);
                        break;
                    case "0-1":
                        bookRow[BookMove.ColumnLoseCount] = Convert.ToInt32(bookRow[BookMove.ColumnLoseCount]) + 1; // no of games (transposed)
                        noOfGames = Convert.ToInt32(bookRow[BookMove.ColumnLoseCount]);
                        break;
                }

                // check if this is transposed move Id,
                // then update its no. of games with same no. as of other tranposed(matched) moves
                // which is done in method : "private bool TransposeBranch(GameItem gameItem, Moves branchMoves)"
                if (NoOfTranspos > 0 && TransposedMoveRowId == Convert.ToInt32(moveRow[Moves.Id]))
                {
                    noOfGames = NoOfTranspos; // no of games (transposed)
                }
                #endregion
            }
        }

        public void ImportGameFromDatabase(Database database, int fromGameNo, int toGameNo, bool includeVariations)
        {
            newPositionsImported = 0;
            List<GameItem> gameItems = database.GetGamesItems(fromGameNo, toGameNo);
            if (gameItems != null)
            {
                foreach (GameItem item in gameItems)
                {
                    ImportGame(item);
                }
            }
            Save();
        }

        public List<GameItem> LoadGameFromDatabase(Database database)
        {
            List<GameItem> gameItems = database.GetGamesItems();
            if (gameItems != null)
            {
                return gameItems;
            }
            else
            {
                return null;
            }
        }

        private string GetGameXml(string gameItemsXml)
        {
            string gameXml = string.Empty;

            gameXml += "<GameXml>";
            gameXml += gameItemsXml;
            gameXml += "</GameXml>";

            return gameXml;
        }

        /// <summary>
        /// Sort MainLine in Ascending Order by MoveId
        /// </summary>
        /// <param name="dt">MainLine</param>
        /// <returns>MainLine(sorted)</returns>
        private DataTable SetBranchTable(DataTable dt)
        {
            DataTable dtBranch = dt.Copy();
            string sortExpression = Moves.Id + " asc";
            dtBranch.DefaultView.Sort = sortExpression;
            dtBranch = dtBranch.DefaultView.ToTable();
            return dtBranch;
        }

        #endregion

        #region Helper

        #region SetMove
        public void PointTo(Move m)
        {
            if (IsClosed)
            {
                return;
            }

            if (PointToMove != null)
            {
                if (m != null)
                {
                    if (PointToMove.Id == m.Id && PointToMove.IsWhite == m.IsWhite && PointToMove.MoveNo == m.MoveNo)
                    {
                        return;
                    }
                }
            }

            PointToMove = m.Clone();  // move where book is currently pointing to

            BookMoves.LoadChilds(m,BookMovesCollection);

            if (OnPointTo != null)
            {
                OnPointTo(this, EventArgs.Empty);
            }
        }

        public void DoMove()
        {
            if (IsClosed)
            {
                return;
            }

            if (BookMoves.rowIndex == -1)
            {
                isExpired = true;
                return;
            }

            Move m = BookMoves.CurrentMove();

            if (m == null)
            {
                isExpired = true;
                return;
            }

            isExpired = false;
            BookMoves.rowIndex = 0;

            if (MoveReceived != null)
            {
                UCIMoveEventArgs e = new UCIMoveEventArgs(m.From, m.To);
                MoveReceived(this, e);
            }

        }

        public void SetOptions()
        {
            if (bookOptions == null)
            {
                bookOptions = new BookOptions(BookOptionsType.Global);
            }

            SetOptions(bookOptions);
        }

        public void SetOptions(BookOptions bookOptions)
        {
            if (bookOptions == null)
            {
                return;
            }

            this.bookOptions = bookOptions;
            bookOptionsFilter = string.Empty;
            bookOptionsFilter += " " + BookMove.ColumnWinCount + " >= " + bookOptions.MinGames;
            bookOptionsFilter += " and ";
            bookOptionsFilter += " " + BookMove.ColumnMoveNumber + " <= " + bookOptions.MaxMoves;

            bookOptionsFilter += " and ";
            bookOptionsFilter += " " + BookMove.ColumnMoveFlags + " like '%" + Moves.MainMove + "%'";

            if (bookOptions.TournamentBook) // not DontPlayInTournament (black) moves are used
            {
                bookOptionsFilter += " and ";
                bookOptionsFilter += " " + BookMove.ColumnMoveFlags + " not like '%" + Moves.NotInTournament + "%'";
            }

            bookOptionsFilter += " and ";
            bookOptionsFilter += " " + BookMove.ColumnMoveType + " <> '?'";
        }

        #endregion

        #region GetLastMoveBranch

        /// <summary>
        /// Extract Moves(MainLine's moves,thus excluding variations) for the provided Game(Moves)
        /// It starts from LastMove and traverse back upto first move, 
        /// assuming it as MainLine's moves or (MainLine Baranch)
        /// </summary>
        /// <param name="notationsTree"></param>
        /// <returns></returns>
        private Moves GetLastMovesBranch(Moves notationsTree)
        {
            if (notationsTree == null || notationsTree.Count == 0)
            {
                return null;
            }

            NotationsTree = notationsTree;

            // get last moves(datarow)
            DataRow dr = NotationsTree.DataTable.Rows[NotationsTree.DataTable.Rows.Count - 1];

            // now traverse back upto first move, to get MainLine
            return GetLastMovesBranch(Convert.ToInt32(dr[Moves.Id]));
        }

        private Moves GetLastMovesBranch(int pid)
        {
            NotationsLastMoveBranch = new Moves();
            return DoGetMovesBranch(pid);
        }

        private Moves DoGetMovesBranch(int pid)
        {
            NotationsTree.DataTable.DefaultView.RowFilter = Moves.Id + "=" + pid;

            if (NotationsTree.DataTable.DefaultView.Count == 0) // if we hit first move, then stop and return this MainLine
            {
                return NotationsLastMoveBranch;
            }
            else // we have further moves in MainLine, so append it to our MainLine 
            {
                DataRow dr = NotationsTree.DataTable.DefaultView[0].Row;
                NotationsTree.DataTable.DefaultView.RowFilter = "";
                NotationsLastMoveBranch.DataTable.ImportRow(dr);
                DoGetMovesBranch(Convert.ToInt32(dr[Moves.Pid]));
            }

            NotationsTree.DataTable.DefaultView.RowFilter = "";

            return NotationsLastMoveBranch;
        }

        #endregion

        #region Search Moves/Position

        public void SearchMove(string fen)
        {
            string[] movePositions = GetMovePositions(fen);

            if (!string.IsNullOrEmpty(movePositions[0]))
            {
                if (MoveReceived != null)
                {
                    string moveFrom = movePositions[0];
                    string moveTo = movePositions[1];
                    UCIMoveEventArgs e = new UCIMoveEventArgs(moveFrom, moveTo);
                    MoveReceived(this, e);
                }
            }
        }

        private string[] GetMovePositions(string currentFEN)
        {
            string[] movePositions = new string[2];
            int moveId = GetMoveId(currentFEN);
            if (moveId >= 0)
            {
                movePositions = GetMovePositionByMoveId(moveId);
            }
            return movePositions;
        }

        private int GetMoveId(string currentFEN)
        {
            int moveId = -1;
            if (BookMoves != null)
            {
                string filterExpression = string.Empty;
                string tempFEN = ChessLibrary.FenParser.GetOnlyFen(currentFEN);
                filterExpression += BookMove.ColumnFen + " like '" + tempFEN + "%'";

                DataRow[] dRows = BookMoves.DataTable.Select(filterExpression);

                if (dRows.Length > 0)
                {
                    if (currentFEN == this.Game.InitialBoardFen)
                    {
                        moveId = Convert.ToInt32(dRows[0][BookMove.ColumnId]);
                    }
                    else
                    {
                        DataRow drMove = this.Game.CurrentLine.Last.DataRow;
                        foreach (DataRow dr in dRows)
                        {
                            if (IsParentMatched(drMove, dr))
                            {
                                moveId = Convert.ToInt32(dr[BookMove.ColumnId]);
                                break;
                            }
                        }
                    }
                }

                if (moveId == -1)
                {
                    isExpired = true;
                }
            }
            return moveId;
        }

        private string[] GetMovePositionByMoveId(int moveId)
        {
            string[] movePositions = new string[2];

            string filterExpression = string.Empty;
            filterExpression += BookMove.ColumnParentId + " = " + moveId;
            if (!string.IsNullOrEmpty(bookOptionsFilter))
                filterExpression += " and " + bookOptionsFilter;
            DataRow[] dr = BookMoves.DataTable.Select(filterExpression, BookMove.ColumnWinCount + " Desc");

            if (dr.Length > 0)
            {
                movePositions[0] = dr[0][BookMove.ColumnFrom].ToString();
                movePositions[1] = dr[0][BookMove.ColumnTo].ToString();
            }
            else
            {
                isExpired = true;
            }

            return movePositions;
        }

        #endregion


       
        #endregion

    }
}
