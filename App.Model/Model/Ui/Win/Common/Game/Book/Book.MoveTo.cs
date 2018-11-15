using System; using App.Model;
using System.Collections.Generic;

using System.Text;

using System.Data;
using System.IO;
using InfinitySettings.Streams;
using InfinitySettings.UCIManager;
using System.Configuration;

namespace App.Model
{
    public partial class Book
    {
        #region Events 

        public delegate void MoveToEventHandler(MoveToE moveTo);
        public event MoveToEventHandler MoveToEventE;

        public event EventHandler MoveToEvent;

        #endregion

        #region MoveTo Methods 

        public void MoveTo(MoveToE moveTo)
        {
            PointTo(this.Game.CurrentMove);

            if (MoveToEventE != null)
            {
                MoveToEventE(moveTo);
            }
        }

        public void MoveTo(Move m)
        {
            PointTo(m);

            if (MoveToEvent != null)
            {
                MoveToEvent(this, EventArgs.Empty);
            }
        }

        #region Helpers
        public void MoveTo()
        {
            PointTo(this.Game.CurrentMove);
        }

        public void MoveTo(MoveToE moveTo, bool isNew)
        {
            if (isNew)
            {
                DoMove();
            }
            else
            {
                PointTo(this.Game.CurrentMove);
            }

            if (MoveToEventE != null)
            {
                MoveToEventE(moveTo);
            }
        }
        #endregion

        #endregion

        public void SetCurrentRowIndex(int ri)
        {
            BookMoves.rowIndex = ri; 
        }

        public int GetCurrentRowIndex()
        {
            return BookMoves.rowIndex;
        }

        public bool IsDifferentMove(Move m)
        {
            Move bm = BookMoves.CurrentMove();

            if (m.To == bm.To && m.From == bm.From)
            {
                return false;
            }
            return true;
        }
    }
}
