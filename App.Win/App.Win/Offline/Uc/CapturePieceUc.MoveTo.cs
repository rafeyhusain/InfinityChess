using System; using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace InfinityChess
{
    public partial class CapturePieceUc
    {
        #region CapturePieces Events 

        void CapturedPieces_MoveToEventE(MoveToE moveTo)
        {
            UpdatePieces();
        }

        void CapturedPieces_MoveToEventN(int moveNo)
        {
            
        }

        #endregion

        #region Helper Methods

        public void RemovePreviousPieces()
        {
            List<PictureBox> whitePiecesToRemove = new List<PictureBox>();
            List<PictureBox> blackPiecesToRemove = new List<PictureBox>();

            ///// select white pieces to remove
            foreach (object obj in panelWhite.Controls)
            {
                PictureBox pic = obj as PictureBox;
                if (pic != null)
                {   
                    int moveId = (int)pic.Tag;

                    bool pieceFounded = IsMovesContainsPiece(moveId);
                    if (!pieceFounded)
                    {
                        whitePiecesToRemove.Add(pic);
                    }
                }
            }

            ///// select black pieces to remove
            foreach (object obj in panelBlack.Controls)
            {
                PictureBox pic = obj as PictureBox;
                if (pic != null)
                {
                    int moveId = (int)pic.Tag;

                    bool pieceFounded = IsMovesContainsPiece(moveId);
                    if (!pieceFounded)
                    {
                        blackPiecesToRemove.Add(pic);
                    }
                }
            }

            ///// now remove white pieces
            foreach (PictureBox pic in whitePiecesToRemove)
            {
                if (wpiclocation > 0)
                {
                    wpiclocation = wpiclocation - pieceWidth;
                }
                RemovePicture(pic, false);
            }

            ///// now remove black pieces
            foreach (PictureBox pic in blackPiecesToRemove)
            {
                if (bpiclocation > 0)
                {
                    bpiclocation = bpiclocation - pieceWidth;
                }
                RemovePicture(pic, true);
            }
        }

        public void AddNewPieces()
        {
            if (this.Game.CurrentLine == null)
            {
                return;
            }

            string filter = Moves.MoveFlags + " like '%" + Moves.Capture + "%'";
            filter += " and " + Moves.Id + " <=  " + this.Game.CurrentMove.Id;
            foreach (DataRow dr in this.Game.CurrentLine.DataTable.Select(filter))
            {
                Move m = new Move(dr);
                m.Game = this.Game;

                int moveId = m.Id;

                bool pieceAlreadyAdded = IsPieceAlreadyAdded(moveId);
                if (!pieceAlreadyAdded)
                {
                    if (m.IsWhite)
                    {
                        PictureBox pic = GetPiecePictureBox(m);
                        AddPicture(pic, false);
                    }
                    else
                    {
                        PictureBox pic = GetPiecePictureBox(m);
                        AddPicture(pic, true);
                    }
                }               
            }
        }

        private bool IsMovesContainsPiece(int moveId)
        {
            bool pieceContained = false;
            
            string filter = string.Empty;
            filter += Moves.Id  + " = " + moveId;
            filter += " and " + Moves.Id +  " <= " + this.Game.CurrentMove.Id;

            int rowsCount = this.Game.CurrentLine.DataTable.Select(filter).Length;
            pieceContained = rowsCount > 0;
            return pieceContained;
        }

        private bool IsPieceAlreadyAdded(int moveId)
        {
            bool pieceAdded = false;

            ///// check white pieces to remove
            foreach (object obj in panelWhite.Controls)
            {
                PictureBox pic = obj as PictureBox;
                if (pic != null)
                {
                    if (moveId == (int)pic.Tag)
                    {
                        pieceAdded = true;
                        return pieceAdded;
                    }
                }
            }

            ///// check black pieces to remove
            foreach (object obj in panelBlack.Controls)
            {
                PictureBox pic = obj as PictureBox;
                if (pic != null)
                {
                    if (moveId == (int)pic.Tag)
                    {
                        pieceAdded = true;
                        return pieceAdded;
                    }
                }
            }

            return pieceAdded;
        }

        #endregion
    }
}
