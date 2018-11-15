using System; using App.Model;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace App.Model
{
    public class Clipboard
    {
        DataTable Moves = null;
        public Game Game = null;

        #region Ctor

        public Clipboard(Game game)
        {
            this.Game = game;
        }
        #endregion

        public void Reset()
        {
            
        }

        #region Copy/Paste
        public void CopyGame()
        {
            InfinityChess.PGNManager.PGNReader pgnReader = new InfinityChess.PGNManager.PGNReader();
            pgnReader.CopyGame();

            Moves = Ap.Game.Notations.Game.Moves.DataTable.DefaultView.ToTable();
        }

        public void PasteGame()
        {
            if (Moves == null)
            {
                return;
            }

            Ap.Game.Paste(Moves);
        }
        
        //public void CopyPosition()
        //{
        //    ResetPositionClipboard();

        //    string fenNotation = InfinityChess.Abstract.InfinityGlobal.MainForm.ChessBoard.GetCompleteFENNotation();

        //    System.Windows.Forms.Clipboard.SetText(fenNotation);
        //}

        public void CopyPosition(string fenNotation)
        {
            System.Windows.Forms.Clipboard.Clear();
            System.Windows.Forms.Clipboard.SetText(fenNotation);
        }

        //public void PastePosition()
        //{
        //    IsPositionPasted = true;

        //    string fenNotation = System.Windows.Forms.Clipboard.GetText();

        //    InfinityChess.Abstract.InfinityGlobal.MainForm.ChessBoard.SetBoardPositionByFEN(fenNotation, false);
            
        //    //Ap.Game.Notations.NdRow.IsWhite = fenNotation.Contains(" w ");
        //    //InfinityChess.Abstract.InfinityGlobal.MainForm.SwapPlayersIfNeeded();
        //}
        #endregion
    }
}
