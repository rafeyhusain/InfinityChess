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
    public class MoveFlags : BaseFlags
    {
        #region Data Members

        public Move Move = null;
        public BookMove BookMove = null;       

        #endregion

        #region Ctor

        public MoveFlags(string moveFlags)
        {
            this.Flags = moveFlags;
        }

        public MoveFlags(Move m)
        {
            this.Move = m;
            base.flags = m.MoveFlags;
        }

        public MoveFlags(BookMove m)
        {
            this.BookMove = m;
            base.flags = m.BookMoveFlags;
        }

        #endregion

        #region Properties

        #region Core
        public override string Flags
        {
            get { return flags; }
            set
            {
                flags = value;

                if (Move != null)
                {
                    Move.MoveFlags = value;
                }

                if (BookMove != null)
                {
                    BookMove.BookMoveFlags = value;
                }
            }
        }

        public bool IsMated { [DebuggerStepThrough] get { return Flags.Contains(Moves.Mated); } [DebuggerStepThrough] set { SetMoveFlag(Moves.Mated, value); } }
        public bool IsStaleMated { [DebuggerStepThrough] get { return Flags.Contains(Moves.StaleMated); } [DebuggerStepThrough] set { SetMoveFlag(Moves.StaleMated, value); } }        
        public bool IsInCheck { [DebuggerStepThrough] get { return Flags.Contains(Moves.InCheck); } [DebuggerStepThrough] set { SetMoveFlag(Moves.InCheck, value); } }
        public bool IsCapture { [DebuggerStepThrough] get { return Flags.Contains(Moves.Capture); } [DebuggerStepThrough] set { SetMoveFlag(Moves.Capture, value); } }
        public bool IsEnpassantCapture { [DebuggerStepThrough] get { return Flags.Contains(Moves.EnpassantCapture); } [DebuggerStepThrough] set { SetMoveFlag(Moves.EnpassantCapture, value); } }
        public bool IsAmbigousMove { [DebuggerStepThrough] get { return Flags.Contains(Moves.AmbigousMove); } [DebuggerStepThrough] set { SetMoveFlag(Moves.AmbigousMove, value); } }
        public bool IsAmbigousMoveColumn { [DebuggerStepThrough] get { return Flags.Contains(Moves.AmbigousMoveColumn); } [DebuggerStepThrough] set { SetMoveFlag(Moves.AmbigousMoveColumn, value); } }
        public bool IsAmbigousMoveRow { [DebuggerStepThrough] get { return Flags.Contains(Moves.AmbigousMoveRow); } [DebuggerStepThrough] set { SetMoveFlag(Moves.AmbigousMoveRow, value); } }        
        public bool IsAmbigousMoveRowToCol { [DebuggerStepThrough] get { return Flags.Contains(Moves.AmbigousMoveRowToCol); } [DebuggerStepThrough] set { SetMoveFlag(Moves.AmbigousMoveRowToCol, value); } }
        public bool IsVariation { [DebuggerStepThrough] get { return Flags.Contains(Moves.Variation); } [DebuggerStepThrough] set { SetMoveFlag(Moves.Variation, value); } }
        public bool IsBlackVariation { [DebuggerStepThrough] get { return Flags.Contains(Moves.BlackVariation); } [DebuggerStepThrough] set { SetMoveFlag(Moves.BlackVariation, value); } }
        public bool IsBlackMainLine { [DebuggerStepThrough] get { return Flags.Contains(Moves.BlackMainLine); } [DebuggerStepThrough] set { SetMoveFlag(Moves.BlackMainLine, value); } }
        public bool IsPromotion { [DebuggerStepThrough] get { return Flags.Contains(Moves.Promotion); } [DebuggerStepThrough] set { SetMoveFlag(Moves.Promotion, value); } }
        public bool IsLongCastling { [DebuggerStepThrough] get { return Flags.Contains(Moves.LongCastling); } [DebuggerStepThrough] set { SetMoveFlag(Moves.LongCastling, value); } }
        public bool IsShortCastling { [DebuggerStepThrough] get { return Flags.Contains(Moves.ShortCastling); } [DebuggerStepThrough] set { SetMoveFlag(Moves.ShortCastling, value); } }
        public bool IsVariationInsert { [DebuggerStepThrough] get { return Flags.Contains(Moves.VariationInsert); } [DebuggerStepThrough] set { SetMoveFlag(Moves.VariationInsert, value); } }
        public bool IsVariationOverwrite { [DebuggerStepThrough] get { return Flags.Contains(Moves.VariationOverwrite); } [DebuggerStepThrough] set { SetMoveFlag(Moves.VariationOverwrite, value); } }
        public bool IsVariationNewMainLine { [DebuggerStepThrough] get { return Flags.Contains(Moves.VariationNewMainLine); } [DebuggerStepThrough] set { SetMoveFlag(Moves.VariationNewMainLine, value); } }

        public bool IsHuman { [DebuggerStepThrough] get { return Flags.Contains(Moves.Human); } [DebuggerStepThrough] set { SetMoveFlag(Moves.Human, value); } }
        public bool IsEngine { [DebuggerStepThrough] get { return Flags.Contains(Moves.Engine); } [DebuggerStepThrough] set { SetMoveFlag(Moves.Engine, value); } }
        public bool IsBook { [DebuggerStepThrough] get { return Flags.Contains(Moves.Book); } [DebuggerStepThrough] set { SetMoveFlag(Moves.Book, value); } }

        public bool IsTempMove { [DebuggerStepThrough] get { return Flags.Contains(Moves.TempMove); } [DebuggerStepThrough] set { SetMoveFlag(Moves.TempMove, value); } }

        // for Book - start
        public bool IsMainMove { [DebuggerStepThrough] get { return Flags.Contains(Moves.MainMove); } [DebuggerStepThrough] set { SetMoveFlag(Moves.MainMove, value); } }
        public bool NotInTournament { [DebuggerStepThrough] get { return Flags.Contains(Moves.NotInTournament); } [DebuggerStepThrough] set { SetMoveFlag(Moves.NotInTournament, value); } }
        // for Book - end

        public bool IsValidMove
        {
            [DebuggerStepThrough]
            get
            {
                return Flags.Contains(Moves.IsValidMove);
            }
            [DebuggerStepThrough]
            set
            {
                SetMoveFlag(Moves.IsValidMove, value);
            }
        }

        #endregion

        #region Calculated
        public bool IsRootMove
        {
            [DebuggerStepThrough]
            get 
            {
                if (this.Move == null)
                {
                    return true;
                }

                return this.Move.Id == -1; 
            }
        }

        public bool IsAnyKindOfVariation
        {
            [DebuggerStepThrough]
            get { return VariationType != VariationTypeE.None; }
        }

        public VariationTypeE VariationType
        {
            [DebuggerStepThrough]
            get
            {
                if (IsVariation)
                {
                    return VariationTypeE.Variation;
                }

                if (IsVariationNewMainLine)
                {
                    return VariationTypeE.MainLine;
                }

                if (IsVariationInsert)
                {
                    return VariationTypeE.Insert;
                }

                if (IsVariationOverwrite)
                {
                    return VariationTypeE.Overwrite;
                }

                return VariationTypeE.None;
            }

            set
            {
                switch (value)
                {
                    case VariationTypeE.Variation:
                        IsVariation = true;
                        break;
                    case VariationTypeE.MainLine:
                        IsVariationNewMainLine = true;
                        break;
                    case VariationTypeE.Insert:
                        IsVariationInsert = true;
                        break;
                    case VariationTypeE.Overwrite:
                        IsVariationOverwrite = true;
                        break;
                    default:
                        IsVariation = false;
                        IsVariationNewMainLine = false;
                        IsVariationInsert = false;
                        IsVariationOverwrite = false;
                        break;
                }
            }
        }

        public MoveByE MoveBy
        {
            [DebuggerStepThrough]
            get
            {
                if (IsHuman)
                {
                    return MoveByE.Human;
                }
                else if (IsEngine)
                {
                    return MoveByE.Engine;
                }
                else if (IsBook)
                {
                    return MoveByE.Book;
                }

                return MoveByE.None;
            }

            set
            {
                switch (value)
                {
                    case MoveByE.Human:
                        IsHuman = true;
                        break;
                    case MoveByE.Engine:
                        IsEngine = true;
                        break;
                    case MoveByE.Book:
                        IsBook = true;
                        break;
                }
            }
        }

        public bool IsCastling { get { return IsShortCastling || IsLongCastling; } }
        public bool IsCheckAndCastling { get { return IsInCheck && (IsShortCastling || IsLongCastling); } }
        public bool HasFlags { get { return Flags == string.Empty; } }
        #endregion

        #endregion

        #region AppendFlags
        public string AppendFlags(MoveFlags mf)
        {
            this.flags += mf.Flags;
            return this.flags;
        } 
        #endregion
    }
}
