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
    public partial class Notations
    {
        #region Events

        public delegate void MoveToEventHandler(MoveToE moveTo);
        public event MoveToEventHandler MoveToEventE;

        //public delegate void MoveToEventHandler1(int id);
        public event EventHandler MoveToEvent;

        #endregion

        #region MoveTo Methods
    
        public void MoveTo(MoveToE moveTo)
        {
            if (MoveToEventE != null)
            {
                MoveToEventE(moveTo);
            }

            Scoring.MoveTo(moveTo);
        }

        public void MoveTo(Move m)
        {
            if (MoveToEvent != null)
            {
                MoveToEvent(this, EventArgs.Empty);
            }

            Scoring.MoveTo();
        }

        #endregion
    }
}
