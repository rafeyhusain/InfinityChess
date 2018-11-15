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
    public partial class Clock
    {
        #region Events

        public delegate void MoveToEventHandler(MoveToE moveTo);
        public event MoveToEventHandler MoveToEventE;

        public event EventHandler MoveToEvent;

        #endregion

        #region MoveTo Methods
    
        public void MoveTo(MoveToE moveTo)
        {
            SetToCurrentMove(this.Game.CurrentMove);

            if (MoveToEventE != null)
            {
                MoveToEventE(moveTo);
            }
        }

        public void MoveTo(Move m)
        {
            SetToCurrentMove(m);

            if (MoveToEvent != null)
            {
                MoveToEvent(this, EventArgs.Empty);
            }
        }

        private void SetToCurrentMove(Move m)
        {
            Stop();
            SetClock(m);
        }

        #endregion
    }
}
