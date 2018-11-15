using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Diagnostics;
namespace App.Model.Win.Controls
{
    public class SquareItem
    {
        public string SquareName { [DebuggerStepThrough]get; [DebuggerStepThrough]set; }
        public Rectangle SquareRectangle { [DebuggerStepThrough] get; [DebuggerStepThrough]set; }
        public Pieces SquarePiece { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        public SquareItem(string squareName, Rectangle squareRectangle, Pieces squarePiece)
        {
            SquareName = squareName;
            SquareRectangle = squareRectangle;
            SquarePiece = squarePiece;
        }
    }
}
