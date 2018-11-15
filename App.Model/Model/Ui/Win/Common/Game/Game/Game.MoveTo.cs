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
    public partial class Game
    {
      
        #region MoveTo
        public void MoveTo(MoveToE moveTo)
        {
            MoveTo(moveTo, false);
        }

        public void MoveTo(MoveToE moveTo, bool moveFromBook)
        {
            Move m = null;

            if ((Flags.IsFirstMoveSelected || Flags.IsRootMoveSelected) && (moveTo == MoveToE.Previous || moveTo == MoveToE.First))
            {
                if (Flags.IsRootMoveSelected)
                {
                    return;
                }

                SetInitialPosition();
                return;
            }

            if (moveFromBook && moveTo == MoveToE.Next)
            {
                Book.MoveTo(moveTo, true);
                return;
            }

            if (Flags.IsFirtMove && moveTo == MoveToE.Next)
            {
                return;
            }

            switch (moveTo)
            {
                case MoveToE.First:
                    m = Moves.First;
                    break;
                case MoveToE.Last:
                    m = Moves.Last;
                    break;
                case MoveToE.Next:
                    m = GetNextMove(CurrentMove);
                    break;
                case MoveToE.Previous:
                    m = Moves.Prev(CurrentMove);
                    break;
                case MoveToE.Up:
                    break;
                case MoveToE.Down:
                    break;
                default:
                    break;
            }

           
            Flags.IsRetracMove = false;

            CurrentMove = m.Clone();

            Clock.MoveTo(moveTo);
            Notations.MoveTo(moveTo);
            Book.MoveTo(moveTo, false);
            CapturedPieces.MoveTo(moveTo);

            SetFen(CurrentMove.Fen);
            SwapPlayersIfNeeded();
        }

        public void MoveTo(Move m)
        {
            if (m == null)
            {
                return;
            }

            if (m.Id == CurrentMove.Id)
            {
                return;
            }

            if (BeforeMoveTo != null)
            {
                BeforeMoveTo(this, new MoveToEventArgs(m));
            }

            Flags.IsRetracMove = false;

            CurrentMove = m.Clone();

            Clock.MoveTo(CurrentMove);
            Notations.MoveTo(CurrentMove);
            Book.MoveTo(CurrentMove);
            CapturedPieces.MoveTo(CurrentMove);

            SetFen(CurrentMove.Fen);
            SwapPlayersIfNeeded();

            if (AfterMoveTo != null)
            {
                AfterMoveTo(this, new MoveToEventArgs(CurrentMove));
            }
        }

        private Move GetNextMove(Move m)
        {
            Moves children = Moves.GetChildren(m);

            if (children.Count == 0)
            {
                m = CurrentMove;
            }
            else if (children.Count == 1)
            {
                m = children[0];
            }
            else if (children.Count > 1)
            {
                if (SelectCurrentMoveChildren != null)
                {
                    SelectCurrentMoveChildrenEventArgs e = new SelectCurrentMoveChildrenEventArgs();
                    e.Move = m;
                    SelectCurrentMoveChildren(this, e);
                    m = e.Move;
                }
            }

            if (m == null)
            {
                m = CurrentMove;
            }

            return m;
        }

        private void SetInitialPosition()
        {
            CurrentMove = RootMove.Clone();
            SetFen(InitialBoardFen);
            Book.MoveTo(CurrentMove);
        }

        #endregion

        #region RetracMove
        public void RetracMove()
        {
            MoveTo(MoveToE.Previous);
            Flags.IsRetracMove = true;
        }
        
        #endregion

    }
}
