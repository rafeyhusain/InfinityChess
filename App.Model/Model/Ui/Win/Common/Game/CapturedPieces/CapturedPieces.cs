using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace App.Model
{
    public partial class CapturedPieces
    {
        #region Data Members
        public Game Game = null;
        #endregion

        #region Delegate / Events

        public event EventHandler ClearEvent;
        public event EventHandler PieceAddedEvent;
        public event EventHandler UpdatePieces;

        #endregion

        #region Ctor

        public CapturedPieces(Game game)
        {
            this.Game = game;
            NewGame();
        }

        public void Update(Move m)
        {
            if (UpdatePieces != null)
            {
                UpdatePieces(this, EventArgs.Empty);
            }
        }

        public void AddPiece()
        {
            if (PieceAddedEvent != null)
            {
                PieceAddedEvent(this, EventArgs.Empty);
            }
        }

        public void Clear()
        {   
            if (ClearEvent != null)
            {
                ClearEvent(this, EventArgs.Empty);
            }
        }

        public void NewGame()
        {
            this.Clear();
        }

        #endregion
                
    }
}
