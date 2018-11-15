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
        #region Overwrite

        public void AddOverwrite()
        {  

            //if (this.Game.CurrentMove.R == -1)
            //{
            //    DeleteAllRows();
            //    this.Game.Flags.IsVariationInProgress = false;
            //    this.Game.Flags.IsMainline = true;
            //    AddNewRow();
            //    this.Game.CurrentMove.R = 0;
            //}            
            //else
            //{
            //    DeleteNotationsData(this.Game.CurrentMove.C);
            //}

            //if (this.Game.CurrentMove.R >= 0 && this.Game.CurrentMove.C > 0 && !this.Game.Flags.IsRetracMove)
            //{
            //    //IsWhite = !IsWhite;
            //}
            //SetMovesDisplay(this.Game.CurrentMove.R, true);
            ////this.Game.CurrentMove.C = this.CurrentColumnIndex;
            //Ap.Game.Flags.IsRetracMove = false;         
        }   

        #endregion 
    }
}
