using System;
using App.Model;
using System.Collections.Generic;
using System.Data;
using System.Text;
using InfinityChess;
using System.Windows.Forms;
using ChessLibrary;
using System.Diagnostics;

namespace App.Model
{
    public class BookMoves : BaseItems<BookMove, BookMoves>
    {
        #region Data Members

        public Game Game = null;
        public int rowIndex = 0;
        public Book Book = null;
        public int CurrentParentMoveId;
        public bool AllowMoveAdding = false;
        
        #endregion

        #region Ctor

        public BookMoves()
        {
            DataTable = GetBookMovesTable();
        }

        public BookMoves(DataTable table)
        {
            this.DataTable = table;
        }

        #endregion

        #region Properties

        #endregion

        #region Methods

        public Move GetBySNo(int sNo)
        {
            try
            {
                DataRow[] rows = base.DataTable.Select("sno=" + UStr.Quote(sNo));
                if (rows.Length > 0)
                {
                    Move m = new Move(rows[0]);
                    m.Game = this.Game;
                    return m;
                }
            }
            catch
            {

            }
            return null;
        }


        #endregion

        #region Helpers
        /**********************************************
        *   Description Column name in BookMoves
        *   pce = piece
        *   mvx = move action = "x","0-0","0-0-0","PR-Q(promote to Queen)","PR-xQ(promote to Queen and capture)"
        *   mvchk = move check = "+" , "#"
        *   mvdr = move duration
        *   wmt = white move time
        *   bmt = black move time
        *   cp = captured piece
        /**********************************************/

        public static DataTable GetBookMovesTable()
        {
            DataSet ds = new DataSet();

            DataTable table = ds.Tables.Add("B");

            table.Columns.Add(new DataColumn(BookMove.ColumnId, typeof(int)));
            table.Columns.Add(new DataColumn(BookMove.ColumnParentId, typeof(int)));
            table.Columns.Add(new DataColumn(BookMove.ColumnFrom, typeof(string)));
            table.Columns.Add(new DataColumn(BookMove.ColumnTo, typeof(string)));
            table.Columns.Add(new DataColumn(BookMove.ColumnWinCount, typeof(int)));
            table.Columns.Add(new DataColumn(BookMove.ColumnPercentage, typeof(double)));
            table.Columns.Add(new DataColumn(BookMove.ColumnAverage, typeof(double)));
            table.Columns.Add(new DataColumn(BookMove.ColumnPref, typeof(int)));
            table.Columns.Add(new DataColumn(BookMove.ColumnFact, typeof(int)));
            table.Columns.Add(new DataColumn(BookMove.ColumnProb, typeof(int)));
            table.Columns.Add(new DataColumn(BookMove.ColumnPercentageTotal, typeof(int)));
            table.Columns.Add(new DataColumn(BookMove.ColumnWhiteMove, typeof(int)));
            table.Columns.Add(new DataColumn(BookMove.ColumnMoveNumber, typeof(int)));
            table.Columns.Add(new DataColumn(BookMove.ColumnFen, typeof(string)));
            table.Columns.Add(new DataColumn(BookMove.ColumnLoseCount, typeof(double)));
            table.Columns.Add(new DataColumn(BookMove.ColumnDrawCount, typeof(double)));            
            table.Columns.Add(new DataColumn(BookMove.ColumnMoveType, typeof(string)));            
            table.Columns.Add(new DataColumn(BookMove.ColumnMovePiece, typeof(string)));
            table.Columns.Add(new DataColumn(BookMove.ColumnCapturedPiece, typeof(string)));
            table.Columns.Add(new DataColumn(BookMove.ColumnMoveFlags, typeof(string)));
            table.Columns.Add(new DataColumn(BookMove.ColumnMoveKey, typeof(string)));
            return table;

        }

        public void AddRootRow()
        {
            DataRow bookRow = this.DataTable.NewRow();
            bookRow[BookMove.ColumnFrom] = string.Empty; // from
            bookRow[BookMove.ColumnTo] = string.Empty; // to
            bookRow[BookMove.ColumnWinCount] = 0; // no of games
            bookRow[BookMove.ColumnPercentage] = 0; // percentage
            bookRow[BookMove.ColumnAverage] = 0; // average
            bookRow[BookMove.ColumnPref] = 0; // pref
            bookRow[BookMove.ColumnFact] = 0; // fact
            bookRow[BookMove.ColumnProb] = 0; // prob
            bookRow[BookMove.ColumnPercentageTotal] = 0; // percentage total
            bookRow[BookMove.ColumnWhiteMove] = true; // isWhite
            bookRow[BookMove.ColumnMoveNumber] = 0; // move number
            bookRow[BookMove.ColumnFen] = ChessLibrary.FenParser.InitialBoardFen; // fen (for starting position)
            bookRow[BookMove.ColumnLoseCount] = 0; // white win
            bookRow[BookMove.ColumnDrawCount] = 0.5; // white draw            

            bookRow[BookMove.ColumnMoveType] = ""; // move type            
            bookRow[BookMove.ColumnParentId] = -1; // parent id (root's parent  = -1)

            bookRow[BookMove.ColumnMovePiece] = ""; // piece
            bookRow[BookMove.ColumnMoveFlags] = ""; // move flags            

            bookRow[BookMove.ColumnId] = 0; // root id = 0
            this.DataTable.Rows.Add(bookRow);
        }

        private string GetCurrent(string column)
        {
            return DataTable.DefaultView[rowIndex].Row[column].ToString();
        }

        public Move CurrentMove()
        {
            if (rowIndex == -1)
            {
                return null;
            }

            if (DataTable.DefaultView.Count < 0)
            {
                return null;
            }

            Move m = new Move();
            m.Game = this.Game;

            m.Flags.IsValidMove = true;
            m.PieceStr = GetCurrent(BookMove.ColumnMovePiece);
            m.IsWhite = GetCurrent(BookMove.ColumnWhiteMove) == "1";
            m.Fen = GetCurrent(BookMove.ColumnFen);
            m.From = GetCurrent(BookMove.ColumnFrom);
            m.To = GetCurrent(BookMove.ColumnTo);

            return m;
        }

        public void LoadChilds(Move m,Dictionary<string,DataRow> bookMovesCollection)
        {
            CheckAndAddMove(m,bookMovesCollection,false);

            string tempParentId = "";
            bool isInitialFen = FenParser.IsInitialFen(m.Fen, true);

            if (m.Flags.IsRootMove && isInitialFen)
            {
                // if rootMove and initial fen, then CurrentMove's parent is "0"
                tempParentId = "0";
            }
            else
            {
                #region Find Book's CurrentMove's Parent 
                StringBuilder filter = new StringBuilder();
                if (!m.Flags.IsRootMove)
                {
                    filter.Append(BookMove.ColumnMoveNumber + " = " + m.MoveNo);
                    filter.Append(" and " + BookMove.ColumnWhiteMove + " = " + m.White);
                    filter.Append(" and " + BookMove.ColumnFrom + " = '" + m.From + "'");
                    filter.Append(" and " + BookMove.ColumnTo + " = '" + m.To + "'");
                    filter.Append(" and ");
                }
                filter.Append(BookMove.ColumnFen + " like '" + ChessLibrary.FenParser.GetOnlyFen(m.Fen) + "%'");

                DataRow[] rows = this.DataTable.Select(filter.ToString());

                if (rows.Length > 0)
                {
                    tempParentId = rows[0][BookMove.ColumnId].ToString();
                } 
                #endregion
            }

            if (string.IsNullOrEmpty(tempParentId))
            {
                #region if "tempParentId" not found, set defaultView to not display moves. 
                DataTable.DefaultView.RowFilter = BookMove.ColumnParentId + " = " + -2;

                if (!AllowMoveAdding)
                {
                    CheckAndAddMove(m, bookMovesCollection,true);
                }

                rowIndex = -1; 
                #endregion
            }
            else
            {
                if (m.Flags.IsRootMove && isInitialFen)
                {
                    #region If RootMove and initial fen, then set move to display according to white or black turn 
                    string filter = "";

                    if (m.White == 1)
                    {
                        filter += BookMove.ColumnParentId + " = " + tempParentId;
                    }
                    else
                    {
                        filter += BookMove.ColumnMoveNumber + " = 1";
                    }

                    filter += " and " + BookMove.ColumnWhiteMove + " = " + m.White;

                    DataTable.DefaultView.RowFilter = filter; 
                    #endregion
                }
                else
                {
                    // if parent found(and not rootMove), then load its childs
                    DataTable.DefaultView.RowFilter = BookMove.ColumnParentId + " = " + tempParentId;
                }

                // set CurrentParentMoveId to current parent founded. 
                CurrentParentMoveId = BaseItem.ToInt32(tempParentId);

                #region Set rowIndex 
                if (DataTable.DefaultView.Count > 0)
                {
                    rowIndex = 0;

                    if (m != null)
                    {
                        for (int i = 0; i < DataTable.DefaultView.Count; i++)
                        {
                            if (m.To == DataTable.DefaultView[i][BookMove.ColumnTo].ToString())
                            {
                                rowIndex = i;
                            }
                        }
                    }
                }
                else
                {
                    rowIndex = -1;
                } 
                #endregion
            }

            this.DataTable.DefaultView.Sort = BookMove.ColumnWinCount + " Desc";
        }

        public int GetNextMoveId()
        {
            int maxId = -1;

            if (DataTable.Rows.Count == 0)
            {
                maxId = 0;
            }
            else
            {
                object objId = DataTable.Compute("max(" + BookMove.ColumnId + ")", "");
                maxId = Convert.ToInt32(objId);
            }

            return maxId + 1;
        }

        private bool IsMoveAlreadyExists(Move m)
        {
            bool alreadyExists = false;
            string filter = string.Empty;
            filter += BookMove.ColumnMovePiece + " = '" + m.PieceStr + "'";
            filter += " and ";
            filter += BookMove.ColumnFrom + " = '" + m.From + "'";
            filter += " and ";
            filter += BookMove.ColumnTo + " = '" + m.To + "'";
            filter += " and ";
            filter += BookMove.ColumnFen + "  like '" + m.Fen.Substring(0, m.Fen.IndexOf(" ")) + "%'";

            DataTable.DefaultView.RowFilter = filter;
            if (DataTable.DefaultView.Count > 0 && DataTable.DefaultView[0].Row.RowState != DataRowState.Detached)
            {
                alreadyExists = true;
            }

            return alreadyExists;
        }

        public void CheckAndAddMove(Move m,Dictionary<string,DataRow> bookMovesCollection, bool isTempMove)
        {
            if (m == null)
            {
                return;
            }

            if ((!AllowMoveAdding || IsMoveAlreadyExists(m)) && !isTempMove)
            {
                return;
            }

            BookMove bm = BookMove.NewMove(); 

            bm.FromSquare = m.From;
            bm.ToSquare = m.To;
            bm.MoveNumber = m.MoveNo;
            bm.White = m.IsWhite ? 1 : 0;
            bm.WinCount = 1;
            bm.Percentage = 0;
            bm.Average = 0;
            bm.Pref = 0;
            bm.Fact = 0;
            bm.Prob = 0;
            bm.PercentageTotal = 0;
            bm.FenNotation = ChessLibrary.FenParser.GetOnlyFen(m.Fen);
            bm.LostCount = 0;
            bm.DrawCount = 0;            
            bm.MoveType = "";            
            bm.ParentId = CurrentParentMoveId;
            bm.MovePiece = m.PieceStr;
            bm.BookMoveFlags = m.MoveFlags;
            bm.Flags.IsTempMove = isTempMove;
            bm.Flags.IsMainMove = true;
            bm.Flags.NotInTournament = false;
            bm.Id = GetNextMoveId();

            Add(bm);

            string moveKey = bm.MoveNumber.ToString() + Convert.ToInt32(bm.IsWhite).ToString() + bm.ParentId.ToString() + bm.FromSquare + bm.ToSquare;
            if (!bookMovesCollection.ContainsKey(moveKey))
            {
                bookMovesCollection.Add(moveKey,bm.DataRow);
            }
            CurrentParentMoveId = bm.Id;
        }

        public void RemoveTempMoves()
        {
            DataRow[] dr = DataTable.Select(BookMove.ColumnMoveFlags + " like '%T%'");

            for (int i = 0; i < dr.Length; i++)
            {
                DataTable.Rows.Remove(dr[i]);
            }
        }

        #endregion
    }
}
