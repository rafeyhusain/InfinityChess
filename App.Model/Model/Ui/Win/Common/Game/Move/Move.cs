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
    public enum NotationContent
    { 
        CommentBefore = 1, // 1
        CommentAfter = 2, // 10
        MoveLog = 4, // 100
        MoveTime = 8, // 1000
        ExpectedMove = 16, // 10000
        Eval = 32, // 100000
        All = 63, // 111111
    }

    public class Move : BaseItem
    {
        #region Data Members

        public Game Game = null;
        public Pieces PromotedPiece = Pieces.NONE;
        public Pieces TargetPiece = Pieces.NONE;

        MoveFlags flags = null;
        public MoveComments MoveComments = null;
        #endregion

        #region Ctor

        public Move()
        {
            this.DataRow = Move.NewRow();
            MoveComments = new MoveComments(this);
        }

        public Move(DataRow row)
        {
            this.DataRow = row;
            MoveComments = new MoveComments(this);
        }

        #endregion

        #region Properties
        #region Core
        public override string PrimaryKey
        {
            [DebuggerStepThrough]
            get { return Moves.Id; }
        }

        public int Id { [DebuggerStepThrough] get { return GetColInt32(Moves.Id); } [DebuggerStepThrough] set { SetColumn(Moves.Id, value); } }
        public int Pid { [DebuggerStepThrough] get { return GetColInt32(Moves.Pid); } [DebuggerStepThrough] set { SetColumn(Moves.Pid, value); } }
        public int White { [DebuggerStepThrough] get { return GetColInt32(Moves.White); } [DebuggerStepThrough]set { SetColumn(Moves.White, value); } }
        public int MoveNo { [DebuggerStepThrough]get { return GetColInt32(Moves.No); } [DebuggerStepThrough] set { SetColumn(Moves.No, value); } }
        public string PieceStr { [DebuggerStepThrough] get { return GetCol(Moves.Pce); } [DebuggerStepThrough] set { SetColumn(Moves.Pce, value); } }
        public string From { [DebuggerStepThrough] get { return GetCol(Moves.FromSquare); } [DebuggerStepThrough] set { SetColumn(Moves.FromSquare, value); } }
        public string To { [DebuggerStepThrough]get { return GetCol(Moves.ToSquare); } [DebuggerStepThrough] set { SetColumn(Moves.ToSquare, value); } }
        public string Eval { [DebuggerStepThrough]get { return GetCol(Moves.Eval); } [DebuggerStepThrough] set { SetColumn(Moves.Eval, value); } }
        public string ExpectedMove { [DebuggerStepThrough]get { return GetCol(Moves.ExpectedMove); } [DebuggerStepThrough] set { SetColumn(Moves.ExpectedMove, value); } }
        public string Comments { [DebuggerStepThrough]get { return GetCol(Moves.Comments); } [DebuggerStepThrough] set { SetColumn(Moves.Comments, value); } }

        public string MoveFlags
        {
            [DebuggerStepThrough]
            get
            {
                return GetCol(Moves.MoveFlags);
            }
            [DebuggerStepThrough]
            set
            {
                SetColumn(Moves.MoveFlags, value);
                this.Flags.SetFlags(value);
            }
        }

        public long MoveTime { [DebuggerStepThrough]get { return GetColInt32(Moves.MoveTime); } [DebuggerStepThrough]set { SetColumn(Moves.MoveTime, value); } }
        public long MoveTimeWhite { get { return GetColInt32(Moves.MoveTimeWhite); } set { SetColumn(Moves.MoveTimeWhite, value); } }
        public long MoveTimeBlack { get { return GetColInt32(Moves.MoveTimeBlack); } set { SetColumn(Moves.MoveTimeBlack, value); } }
        public string CapturedPceStr { [DebuggerStepThrough]get { return GetCol(Moves.CapturedPce); } [DebuggerStepThrough] set { SetColumn(Moves.CapturedPce, value); } }
        public string Fen { [DebuggerStepThrough]get { return GetCol(Moves.Fen); } [DebuggerStepThrough] set { SetColumn(Moves.Fen, value); } }
        #endregion

        #region Calculated


        public bool HasEval
        {
            [DebuggerStepThrough]
            get { return !String.IsNullOrEmpty(Eval); }
        }

        public bool HasExpectedMove
        {
            [DebuggerStepThrough]
            get { return !String.IsNullOrEmpty(ExpectedMove); }
        }

        public bool IsBlackVariation { [DebuggerStepThrough]get { return IsBlack && Flags.IsVariation; } }

        public bool IsBlack { [DebuggerStepThrough]get { return !IsWhite; } [DebuggerStepThrough]set { IsWhite = !value; } }

        public bool IsWhite { [DebuggerStepThrough] get { return White == 1; } [DebuggerStepThrough]set { White = value ? 1 : 0; } }
        
        public bool IsPawn { [DebuggerStepThrough]get { return PieceStr == ""; } }

        public Pieces Piece
        {
            [DebuggerStepThrough]
            get
            {
                if (IsWhite)
                {
                    switch (PieceStr)
                    {
                        case "":
                            return Pieces.WPAWN;
                        case "N":
                            return Pieces.WKNIGHT;
                        case "R":
                            return Pieces.WROOK;
                        case "B":
                            return Pieces.WBISHOP;
                        case "Q":
                            return Pieces.WQUEEN;
                        case "K":
                            return Pieces.WKING;
                    }
                }
                else
                {
                    switch (PieceStr)
                    {
                        case "":
                            return Pieces.BPAWN;
                        case "N":
                            return Pieces.BKNIGHT;
                        case "R":
                            return Pieces.BROOK;
                        case "B":
                            return Pieces.BBISHOP;
                        case "Q":
                            return Pieces.BQUEEN;
                        case "K":
                            return Pieces.BKING;
                    }
                }

                return Pieces.NONE;
            }
            
            set
            {
                switch (value)
                {
                    case Pieces.WKING:
                        PieceStr = "K";
                        IsWhite = true;
                        break;
                    case Pieces.WQUEEN:
                        PieceStr = "Q";
                        IsWhite = true;
                        break;
                    case Pieces.WROOK:
                        PieceStr = "R";
                        IsWhite = true;
                        break;
                    case Pieces.WBISHOP:
                        PieceStr = "B";
                        IsWhite = true;
                        break;
                    case Pieces.WKNIGHT:
                        PieceStr = "N";
                        IsWhite = true;
                        break;
                    case Pieces.WPAWN:
                        PieceStr = "";
                        IsWhite = true;
                        break;
                    case Pieces.BKING:
                        PieceStr = "K";
                        IsWhite = false;
                        break;
                    case Pieces.BQUEEN:
                        PieceStr = "Q";
                        IsWhite = false;
                        break;
                    case Pieces.BROOK:
                        PieceStr = "R";
                        IsWhite = false;
                        break;
                    case Pieces.BBISHOP:
                        PieceStr = "B";
                        IsWhite = false;
                        break;
                    case Pieces.BKNIGHT:
                        PieceStr = "N";
                        IsWhite = false;
                        break;
                    case Pieces.BPAWN:
                        PieceStr = "";
                        IsWhite = false;
                        break;
                }
            }

        }

        public Pieces Piece2
        {
            
            get
            {
                // Use Piece to get correct piece 
                // OR
                // Use IsWhite property to find out if piece is white or black
                switch (PieceStr)
                {
                    case "":
                        return Pieces.WPAWN;
                    case "N":
                        return Pieces.WKNIGHT;
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

        public Pieces CapturedPiece
        {
            [DebuggerStepThrough]
            get
            {
                if (IsWhite)
                {
                    switch (CapturedPceStr)
                    {
                        case "":
                            return Pieces.BPAWN;
                        case "N":
                            return Pieces.BKNIGHT;
                        case "R":
                            return Pieces.BROOK;
                        case "B":
                            return Pieces.BBISHOP;
                        case "Q":
                            return Pieces.BQUEEN;
                        case "K":
                            return Pieces.BKING;
                    }
                }
                else
                {
                    switch (CapturedPceStr)
                    {
                        case "":
                            return Pieces.WPAWN;
                        case "N":
                            return Pieces.WKNIGHT;
                        case "R":
                            return Pieces.WROOK;
                        case "B":
                            return Pieces.WBISHOP;
                        case "Q":
                            return Pieces.WQUEEN;
                        case "K":
                            return Pieces.WKING;
                    }
                }

                return Pieces.NONE;
            }
            
            set
            {
                CapturedPceStr = GetPieceStr(value);

                if (value != Pieces.NONE)
                {
                    Flags.IsCapture = true;
                }
            }
        }


        public string NotationForView
        {
            [DebuggerStepThrough]
            get
            {
                return GetNotationForView(Notation);
            }
        }

        public string DoubleNotationForView
        {
            [DebuggerStepThrough]
            get
            {
                return GetNotationForView(DoubleNotation);
            }
        }

        public string SingleNotationForView
        {
            [DebuggerStepThrough]
            get
            {
                return GetNotationForView(SingleNotation);
            }
        }

        public string GetNotationForView(string notation)
        {
            return GetNotationForView(notation, NotationContent.All);
        }

        public string GetNotationForView(string notation, NotationContent nc)
        {
            if (MoveComments.HasCommentsBefore && ((nc & NotationContent.CommentBefore) == NotationContent.CommentBefore))
            {
                notation = "[" + MoveComments[MoveCommentTypeE.Before] + "] " + notation;
            }

            if (MoveComments.HasCommentsAfter && ((nc & NotationContent.CommentAfter) == NotationContent.CommentAfter))
            {
                notation = notation + " (" + MoveComments[MoveCommentTypeE.After] + ")";
            }

            if (MoveComments.HasLog && ((nc & NotationContent.MoveLog) == NotationContent.MoveLog))
            {
                notation = notation + " (" + MoveComments[MoveCommentTypeE.MoveLog] + ")";
            }

            if (HasEval && ((nc & NotationContent.Eval) == NotationContent.Eval))
            {
                notation += " " + Eval;
            }

            if (this.Game.Flags.IsClockedGame && ((nc & NotationContent.MoveTime) == NotationContent.MoveTime))
            {
                notation += " " + MoveTime;
            }

            if (HasExpectedMove && ((nc & NotationContent.ExpectedMove) == NotationContent.ExpectedMove))
            {
                notation += " (" + ExpectedMove + ")";
            }

            notation += ":" + MoveFlags;

            return notation;
        }

        public string Notation
        {
            [DebuggerStepThrough]
            get
            {
                string notation = null;

                if (Ap.Options.IsSingleNotation)
                {
                    notation = SingleNotation;
                }
                else
                {
                    notation = DoubleNotation;
                }

                return notation;
            }
        }

        public string SingleNotation
        {
            [DebuggerStepThrough]
            get
            {
                return GetSingleNotation();
            }
        }

        public string DoubleNotation
        {
            [DebuggerStepThrough]
            get
            {
                return GetDoubleNotation();
            }
        }

        public string SingleNotationPgn
        {
            [DebuggerStepThrough]
            get
            {
                return SingleNotation.Replace("0-0-0", "O-O-O").Replace("0-0", "O-O");
            }
        }
        public string FromTo
        {
            [DebuggerStepThrough]
            get
            {
                return From + To;
            }
        }

        public string MoveString
        {
            [DebuggerStepThrough]
            get
            {
                if (Flags.IsPromotion)
                {
                    return FromTo + PieceStr.ToLower();
                }

                return FromTo;
            }
        }

        public string FromDashTo
        {
            [DebuggerStepThrough]
            get
            {
                return From + "-" + To;
            }
        }

        public bool HasParent
        {
            [DebuggerStepThrough]
            get
            {
                return Pid != -1;
            }
        }

        public bool HasNoParent
        {
            [DebuggerStepThrough]
            get
            {
                return !HasParent;
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

        #region SingleNotation

        public string GetSingleNotation()
        {
            string notation = "";
            PieceStr = PieceStr.Trim(); // use bcz space comes in PieceStr 

            if (IsWhite)
            {
                notation = MoveNo + ".";
            }
            else 
            {
                if (HasNoParent)
                {
                    notation = MoveNo + "..." + notation;
                }
            }
    
            if (Flags.IsPromotion)
            {
                if (Flags.IsCapture)
                {
                    notation += Trim(From) + Moves.Capture + To + PieceStr;
                }
                else
                {
                    notation += To + PieceStr;
                }
            }
            else
            {
                if (Flags.IsCapture)
                {
                    if (Flags.IsAmbigousMove)
                    {
                        if (Flags.IsAmbigousMoveRow && Flags.IsAmbigousMoveColumn)
                        {
                            switch (this.Piece2)
                            {
                                case Pieces.WROOK:
                                case Pieces.BROOK:
                                    notation += PieceStr + TrimAlpha(From) + Moves.Capture + To;
                                    break;
                                case Pieces.WQUEEN:
                                case Pieces.BQUEEN:
                                case Pieces.WBISHOP:
                                case Pieces.BBISHOP:
                                case Pieces.WKNIGHT:
                                case Pieces.BKNIGHT:
                                    notation += PieceStr + From + Moves.Capture + To;
                                    break;
                            }
                        }
                        else if (Flags.IsAmbigousMoveRow)
                        {
                            notation += PieceStr + Trim(From) + Moves.Capture + To;
                        }
                        else if (Flags.IsAmbigousMoveColumn)
                        {
                            switch (this.Piece2)
                            {
                                case Pieces.WROOK:
                                case Pieces.BROOK:
                                    if (Flags.IsAmbigousMoveRowToCol)
                                    {
                                        notation += PieceStr + Trim(From) + Moves.Capture + To;
                                    }
                                    else
                                    {
                                        notation += PieceStr + TrimAlpha(From) + Moves.Capture + To;
                                    }
                                    break;
                                case Pieces.WQUEEN:
                                case Pieces.BQUEEN:
                                case Pieces.WBISHOP:
                                case Pieces.BBISHOP:
                                case Pieces.WKNIGHT:
                                case Pieces.BKNIGHT:
                                    notation += PieceStr + TrimAlpha(From) + Moves.Capture + To;
                                    break;
                            }
                        }
                        else
                        {
                            notation += PieceStr + Trim(From) + Moves.Capture + To;
                        }
                    }
                    else
                    {
                        if (Flags.IsAmbigousMove || string.IsNullOrEmpty(PieceStr))
                        {
                            notation += PieceStr + Trim(From) + Moves.Capture + To;
                        }
                        else
                        {
                            notation += PieceStr + Moves.Capture + To;
                        }
                    }
                }
                else
                {
                    if (Flags.IsAmbigousMove)
                    {
                        if (Flags.IsAmbigousMoveRow && Flags.IsAmbigousMoveColumn)
                        {
                            switch (this.Piece2)
                            {
                                case Pieces.WROOK:
                                case Pieces.BROOK:
                                    notation += PieceStr + TrimAlpha(From) + To;
                                    break;
                                case Pieces.WQUEEN:
                                case Pieces.BQUEEN:
                                case Pieces.WBISHOP:
                                case Pieces.BBISHOP:
                                case Pieces.WKNIGHT:
                                case Pieces.BKNIGHT:
                                    notation += PieceStr + From + To;
                                    break;
                            }
                        }
                        else if (Flags.IsAmbigousMoveRow)
                        {
                            notation += PieceStr + Trim(From) + To;
                        }
                        else if (Flags.IsAmbigousMoveColumn)
                        {
                            switch (this.Piece2)
                            {
                                case Pieces.WROOK:
                                case Pieces.BROOK:
                                    if (Flags.IsAmbigousMoveRowToCol)
                                    {
                                        notation += PieceStr + Trim(From) + To;
                                    }
                                    else
                                    {
                                        notation += PieceStr + TrimAlpha(From) + To;
                                    }
                                    break;
                                case Pieces.WQUEEN:
                                case Pieces.BQUEEN:
                                case Pieces.WBISHOP:
                                case Pieces.BBISHOP:
                                case Pieces.WKNIGHT:
                                case Pieces.BKNIGHT:
                                    notation += PieceStr + TrimAlpha(From) + To;
                                    break;
                            }
                        }
                        else
                        {
                            notation += PieceStr + Trim(From) + To;
                        }
                    }
                    else
                    {
                        if (Flags.IsShortCastling)
                        {
                            notation += "0-0";
                        }
                        else if (Flags.IsLongCastling)
                        {
                            notation += "0-0-0";
                        }
                        else
                        {
                            notation += PieceStr + To;
                        }
                    }
                }              
            }
            if (Flags.IsInCheck)
            {
                notation += Moves.InCheck;
            }
            if (Flags.IsMated)
            {
                notation += Moves.Mated;
            }

            
            if ((Flags.IsVariationNewMainLine || Flags.IsVariation) && IsBlack)
            {
                notation = MoveNo + "..." + notation;
            }

            return notation;
        }

        #endregion

        #region DoubleNotation
        public string GetDoubleNotation()
        {
            string notation = "";

            if (IsWhite)
            {
                notation = MoveNo + ".";
            }

            if (Flags.IsPromotion)
            {
                if (Flags.IsCapture)
                {
                    notation += From + Moves.Capture + To + PieceStr;
                }
                else
                {
                    notation += From + "-" + To + PieceStr;
                }
            }
            else if (Flags.IsShortCastling)
            {
                notation += "0-0";
            }
            else if (Flags.IsLongCastling)
            {
                notation += "0-0-0";
            }
            else
            {
                if (Flags.IsCapture)
                {
                    notation += PieceStr + From + Moves.Capture + To;
                }
                else
                {
                    notation += PieceStr + From + "-" + To;
                }
            }
            if (Flags.IsInCheck)
            {
                notation += Moves.InCheck;
            }
            if (Flags.IsMated)
            {
                notation += Moves.Mated;
            }

            return notation;
        }

        #endregion

        #region Trim
        private string Trim(string notation)
        {

            notation = notation.Replace("1", " ");
            notation = notation.Replace("2", " ");
            notation = notation.Replace("3", " ");
            notation = notation.Replace("4", " ");
            notation = notation.Replace("5", " ");
            notation = notation.Replace("6", " ");
            notation = notation.Replace("7", " ");
            notation = notation.Replace("8", " ");

            notation = notation.Replace(" ", "");

            return notation;
        }

        private string TrimAlpha(string notation)
        {

            notation = notation.Replace("a", " ");
            notation = notation.Replace("b", " ");
            notation = notation.Replace("c", " ");
            notation = notation.Replace("d", " ");
            notation = notation.Replace("e", " ");
            notation = notation.Replace("f", " ");
            notation = notation.Replace("g", " ");
            notation = notation.Replace("h", " ");

            notation = notation.Replace(" ", "");

            return notation;
        }
        #endregion

        #region Methods

        public static DataRow NewRow()
        {
            DataTable table = Moves.GetMovesTable();

            DataRow row = table.NewRow();

            table.Rows.Add(row);

            table.AcceptChanges();

            return row;
        }

        public static Move NewMove()
        {
            return new Move(NewRow());
        }

        public static string GetPieceStr(Pieces piece)
        {
            switch (piece)
            {
                case Pieces.WPAWN:
                case Pieces.BPAWN:
                    return "";
                case Pieces.WKNIGHT:
                case Pieces.BKNIGHT:
                    return "N";
                case Pieces.WROOK:
                case Pieces.BROOK:
                    return "R";
                case Pieces.WBISHOP:
                case Pieces.BBISHOP:
                    return "B";
                case Pieces.WQUEEN:
                case Pieces.BQUEEN:
                    return "Q";
                case Pieces.WKING:
                case Pieces.BKING:
                    return "K";
                default:
                    return "NONE";
            }
        }

        public void Set(Move m)
        {
            MoveComments.Set(m.MoveComments);
            Set(m.DataRow);
            
        }

        public void Set(DataRow moveRow)
        {
            UData.SetRow(moveRow, this.DataRow);
        }

        public void SetEval(string score, string depth)
        {
            Eval = score + "/" + depth;
        }

        #endregion

        #region Clone
        public Move Clone()
        {
            Move m = new Move();
            m.Game = this.Game;
            m.Set(this);
           
            return m;
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            return this.DoubleNotation + " | " + MoveFlags + " | IsWhite=" + IsWhite.ToString() + " | " + MoveNo;
        }
        #endregion

        public Move Replace(Move m)
        {
            Move tMove = new Move(base.Replace(m.DataRow));
            tMove.Game = this.Game;
            return tMove;
        }

        public void SetFen(string fen)
        {
            Fen = fen;
            IsWhite = fen.Contains(" w ");
            MoveNo = ChessLibrary.FenParser.GetMoveNo(fen);
        }

        public void DeleteComments()
        {
            Comments = "";

            MoveComments.DeleteComments();
        }
    }
}
