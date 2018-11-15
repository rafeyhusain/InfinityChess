using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace App.Model
{
    public partial class CapturedPieces
    {
        #region Delegate / Events
       
        public delegate void MoveToEventHandler(MoveToE moveTo);
        public event MoveToEventHandler MoveToEventE;

        #endregion

        #region MoveTo Methods


        public void MoveTo(MoveToE moveTo)
        {
            //Update(this.Game.CurrentMove);

            if (MoveToEventE != null)
            {
                MoveToEventE(moveTo);
            }
        }

        public void MoveTo(Move m)
        {
            Update(m);
        
            //if (MoveToEventN != null)
            //{
            //    MoveToEventN(id);
            //}
        }

        #endregion
    }
}
