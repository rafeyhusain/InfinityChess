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

        public void SetCapturedPiecesParameters()
        {

            if (Flags.IsFirtMove)
            {
                CapturedPieces.IsWhiteMove = InitialIsWhite;
                CapturedPieces.MoveNo = InitialMoveNo;
            }
            else
            {
                CapturedPieces.IsWhiteMove = CurrentMove.IsWhite;
                CapturedPieces.MoveNo = CurrentMove.MoveNo;
            }

            //CapturedPieces.Game.CurrentMove.R = Notations.Game.CurrentMove.R;
            //CapturedPieces.Game.CurrentMove.C = Notations.Game.CurrentMove.C;
            CapturedPieces.NotationsDataTable = Moves.DataTable.Copy();         
        }

        public void RetracMove()
        {
            //Flags.IsClickedByUser = true;
            //Flags.IsRetracMove = true;

            //if (Notations.Game.CurrentMove.R != -1 && Notations.Game.CurrentMove.C != -1)
            //{
            //    Clock.SetClock(CurrentMove);
            //}
        }

        public void SetMove(int r, int c)
        {
            NotationDataRow nd = Notations.GetNotationDataRow(r, c);

            Move m = Moves.GetByID(nd.Id);

            SetMove(m);
        }

        public void SetMove(Move m)
        {
            if (m.Id == CurrentMove.Id)
            {
                return;
            }

            CurrentMove = m;

            Flags.IsMoveInProgress = true;
            Flags.IsClickedByUser = true;

            Clock.Stop();
            Clock.SetClock(CurrentMove);

            Flags.IsRetracMove = false;
            Flags.IsMoveInProgress = false;

            Notations.Set();
            Book.MoveTo();

            SetFen(CurrentMove.Fen); 
            //SetCapturedPiecesParameters();
            //CapturedPieces.MoveTo(moveTo);
        }

        public void MoveTo(MoveToE moveTo)
        {
            Move m = null;
            switch (moveTo)
            {
                case MoveToE.First:
                    m = Moves.First;
                    //Notations.MoveTo(moveTo);
                    break;
                case MoveToE.Last:
                    m = Moves.Last;
                    break;
                case MoveToE.Next:
                    m = Moves.Next(CurrentMove);
                    //Notations.MoveTo(moveTo);
                    break;
                case MoveToE.Previous:
                    m = Moves.Prev(CurrentMove);
                    //Notations.MoveTo(moveTo);
                    break;
                case MoveToE.Up:                
                    break;
                case MoveToE.Down:               
                    break;
                default:
                    break;
            }


            if (m == null && moveTo == MoveToE.Previous)
            {
                return;
            }

            if (m == null)
            {
                Book.MoveTo(moveTo, true);
                return;
            }

            if (CurrentMove.Id == m.Id)
            {
                Book.MoveTo(moveTo, true);
            }
            else
            {
                CurrentMove = m.Clone();

                Flags.IsMoveInProgress = true;
                Flags.IsClickedByUser = true;

                Clock.Stop();
                Clock.SetClock(CurrentMove); 

                Flags.IsRetracMove = false;
                Flags.IsMoveInProgress = false;

                Notations.Set();
                Book.MoveTo(moveTo, false);
                SetCapturedPiecesParameters();
                CapturedPieces.MoveTo(moveTo);

                SetFen(CurrentMove.Fen); 
            }
        }

        public void MoveTo(int moveNo)
        {
            Notations.MoveTo(moveNo);
            Book.MoveTo(moveNo);
            SetCapturedPiecesParameters();
            CapturedPieces.MoveTo(moveNo);
        }

        #endregion




        public Move GetMove(int rowIndex, int columnIndex)
        {
            //DataRow[] rows = Moves.DataTable.Select(Moves.R + "=" + rowIndex + " AND " + Moves.C + "=" + columnIndex);
            //if (rows.Length > 0)
            //{
            //    return new Move(rows[0]);
            //}
            //else
            //{
                return null;
            //}
        }

    }
}
