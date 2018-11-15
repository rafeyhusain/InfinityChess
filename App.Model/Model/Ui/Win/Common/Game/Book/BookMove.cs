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
    public class BookMove : BaseItem
    {
        #region Data Members

        MoveFlags flags;

        public const string ColumnId = "I";//Id
        public const string ColumnParentId = "P";//ParentId
        public const string ColumnMoveKey = "K"; // IsWhite + F + MNo + T + Pid

        public const string ColumnFrom = "F";//From
        public const string ColumnTo = "T";//To

        public const string ColumnWinCount = "W";//WinCount
        public const string ColumnLoseCount = "L";//WhiteWin
        public const string ColumnDrawCount = "D";     //WhiteDraw   

        public const string ColumnMoveFlags = "S";// MoveFlags
        public const string ColumnFen = "E";//Fen

        public const string ColumnWhiteMove = "H";// WhiteMove
        public const string ColumnMoveNumber = "M";// MoveNumber
        public const string ColumnMoveType = "Y"; // MoveType
        public const string ColumnMovePiece = "O"; // MovePiece
        public const string ColumnPercentage = "A";//Percentage

        public const string ColumnAverage = "V";//Average
        public const string ColumnPref = "R";//Pref
        public const string ColumnFact = "C";//Fact
        public const string ColumnProb = "B";//Prob
        public const string ColumnPercentageTotal = "G";//Percentage Total
        public const string ColumnCapturedPiece = "X";// CapturedPiece
        #endregion

        #region Ctor

        public BookMove()
        {
            this.DataRow = BookMove.NewRow();
        }

        public BookMove(DataRow row)
        {
            this.DataRow = row;
        }

        #endregion

        #region Properties
        #region Core
        public int Id { [DebuggerStepThrough]  get { return GetColInt32(BookMove.ColumnId); } [DebuggerStepThrough]set { SetColumn(BookMove.ColumnId, value); } }
        public int ParentId { [DebuggerStepThrough]  get { return GetColInt32(BookMove.ColumnParentId); } [DebuggerStepThrough]set { SetColumn(BookMove.ColumnParentId, value); } }
        public string FromSquare { [DebuggerStepThrough]  get { return GetCol(BookMove.ColumnFrom); } [DebuggerStepThrough]set { SetColumn(BookMove.ColumnFrom, value); } }
        public string ToSquare { [DebuggerStepThrough]  get { return GetCol(BookMove.ColumnTo); } [DebuggerStepThrough]set { SetColumn(BookMove.ColumnTo, value); } }
        public int WinCount { [DebuggerStepThrough]  get { return GetColInt32(BookMove.ColumnWinCount); } [DebuggerStepThrough]set { SetColumn(BookMove.ColumnWinCount, value); } }
        public double LostCount { [DebuggerStepThrough]  get { return GetColDouble(BookMove.ColumnLoseCount); } [DebuggerStepThrough] set { SetColumn(BookMove.ColumnLoseCount, value); } }
        public double DrawCount { [DebuggerStepThrough]  get { return GetColDouble(BookMove.ColumnDrawCount); } [DebuggerStepThrough]set { SetColumn(BookMove.ColumnDrawCount, value); } }
        public double Percentage { [DebuggerStepThrough]  get { return GetColInt32(BookMove.ColumnPercentage); } [DebuggerStepThrough]set { SetColumn(BookMove.ColumnPercentage, value); } }
        public double Average { [DebuggerStepThrough]  get { return GetColDouble(BookMove.ColumnAverage); } [DebuggerStepThrough]set { SetColumn(BookMove.ColumnAverage, value); } }
        public double Pref { [DebuggerStepThrough]  get { return GetColDouble(BookMove.ColumnPref); } [DebuggerStepThrough]set { SetColumn(BookMove.ColumnPref, value); } }
        public double Fact { [DebuggerStepThrough]  get { return GetColDouble(BookMove.ColumnFact); } [DebuggerStepThrough] set { SetColumn(BookMove.ColumnFact, value); } }
        public double Prob { [DebuggerStepThrough]  get { return GetColDouble(BookMove.ColumnProb); } [DebuggerStepThrough]set { SetColumn(BookMove.ColumnProb, value); } }
        public double PercentageTotal { [DebuggerStepThrough]  get { return GetColDouble(BookMove.ColumnPercentageTotal); } [DebuggerStepThrough]set { SetColumn(BookMove.ColumnPercentageTotal, value); } }
        public int White { [DebuggerStepThrough]  get { return GetColInt32(BookMove.ColumnWhiteMove); } [DebuggerStepThrough] set { SetColumn(BookMove.ColumnWhiteMove, value); } }
        public int MoveNumber { [DebuggerStepThrough]  get { return GetColInt32(BookMove.ColumnMoveNumber); } [DebuggerStepThrough] set { SetColumn(BookMove.ColumnMoveNumber, value); } }
        public string FenNotation { [DebuggerStepThrough]  get { return GetCol(BookMove.ColumnFen); } [DebuggerStepThrough]set { SetColumn(BookMove.ColumnFen, value); } }
        public string MoveType { [DebuggerStepThrough]  get { return GetCol(BookMove.ColumnMoveType); } [DebuggerStepThrough] set { SetColumn(BookMove.ColumnMoveType, value); } }        
        public string MovePiece { [DebuggerStepThrough]  get { return GetCol(BookMove.ColumnMovePiece); } [DebuggerStepThrough] set { SetColumn(BookMove.ColumnMovePiece, value); } }
        public string CapturedPiece { [DebuggerStepThrough]  get { return GetCol(BookMove.ColumnCapturedPiece); } [DebuggerStepThrough] set { SetColumn(BookMove.ColumnCapturedPiece, value); } }
        public string BookMoveFlags
        {
            [DebuggerStepThrough]
            get
            {
                return GetCol(BookMove.ColumnMoveFlags);
            }
            [DebuggerStepThrough]
            set
            {
                SetColumn(BookMove.ColumnMoveFlags, value);
                this.Flags.SetFlags(value);
            }
        }
        #endregion

        #region Calculated

        public bool IsWhite { [DebuggerStepThrough]get { return White == 1; } [DebuggerStepThrough]set { White = value ? 1 : 0; } }
        public bool IsPawn { [DebuggerStepThrough]get { return MovePiece == ""; } }

        public Pieces PieceType
        {
            [DebuggerStepThrough]
            get
            {
                // Use IsWhite property to find out if piece is white or black
                switch (MovePiece)
                {
                    case "":
                        return Pieces.WPAWN;
                    case "N":
                        return Pieces.WKING;
                    case "R":
                        return Pieces.WROOK;
                    case "B":
                        return Pieces.WBISHOP;
                    case "Q":
                        return Pieces.WQUEEN;
                    case "K":
                        return Pieces.WKING;
                    default:
                        return Pieces.NONE;
                }
            }
        }

        #endregion

        #region Contained Classes

        public MoveFlags Flags
        {
            [DebuggerStepThrough]
            get
            {
                if (flags == null)
                {
                    flags = new MoveFlags(this);
                }

                return flags;
            }
        }

        #endregion

        #endregion

        #region Methods

        public static DataRow NewRow()
        {
            DataTable table = BookMoves.GetBookMovesTable();

            DataRow row = table.NewRow();

            table.Rows.Add(row);

            table.AcceptChanges();

            return row;
        }

        public static BookMove NewMove()
        {
            return new BookMove(NewRow());
        }

      
        #endregion
    }
}
