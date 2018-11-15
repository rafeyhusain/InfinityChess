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
        public Game GameCopy = null;        

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

        #region Old 

        public void CopyGame1()
        {
            InfinityChess.PGNManager.PGNReader pgnReader = new InfinityChess.PGNManager.PGNReader(this.Game);
            pgnReader.CopyGame();

            Moves = this.Game.Notations.Game.Moves.DataTable.DefaultView.ToTable();            
        }

        public void PasteGame1()
        {
            if (Moves == null)
            {
                return;
            }

            this.Game.Paste(Moves);
        }

        #endregion

        public void CopyGame()
        {
            InfinityChess.PGNManager.PGNReader pgnReader = new InfinityChess.PGNManager.PGNReader(this.Game);
            pgnReader.CopyGame();

            GameCopy = this.Game.Copy();
        }

        public void PasteGame()
        {
            if (GameCopy == null)
            {
                return;
            }

            this.Game.Flags.Flags = GameCopy.Flags.Flags;
            this.Game.Flags.IsInfiniteAnalysisOn = false;
            this.Game.Paste(GameCopy.Moves.DataTable);
            this.Game.Finish(GameCopy.GameResult);
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
            
        //    //this.Game.Notations.NdRow.IsWhite = fenNotation.Contains(" w ");
        //    //InfinityChess.Abstract.InfinityGlobal.MainForm.SwapPlayersIfNeeded();
        //}
        #endregion
    }
}
