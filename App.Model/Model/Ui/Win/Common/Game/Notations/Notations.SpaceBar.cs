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
        #region Data Members       
        #endregion      

        public void InsertNewDataRow()
        {
           // //int Game.CurrentMove.R = 0;
           // //this.Game.CurrentMove.C = 0;
           // //this.Game.CurrentColumnIndex = -1; //this.Game.CurrentMove.C;

           // if (this.Game.Flags.IsGameFinished)
           // {
           //   int rowIndex =   NotationView.Rows.Count - 1;
           //   NotationView.Rows[rowIndex][0] = "";
           //   Game.CurrentMove.R = rowIndex;              
           // }
           // if (this.Game.CurrentColumnIndex <= (MaxColumnIndex - 1) && !this.Game.Flags.IsGameFinished)
           //{                            
           //     AddNewRow();               
           //     Game.CurrentMove.R = NotationView.Rows.Count - 1;                
           //}
           // this.Game.Flags.IsVariationInProgress = true;
           // SetMovesDisplay(Game.CurrentMove.R, true); 
           // //this.Game.CurrentColumnIndex = this.Game.CurrentMove.C;
           // //this.Game.CurrentMove.R = CurrentRowIndex;
           // OnMoveAdded();
        }
        
        public void RemoveRowsDisplayTable()
        {
            //for (int i = NotationView.Rows.Count - 1; i > this.Game.CurrentMove.R; i--)
            //{
            //    this.NotationView.Rows.RemoveAt(i);
            //}        
        }
        public void AddResultinDisplayGrid(string result)
        {
             int count = NotationView.Rows.Count - 1;
             AddResult(result, count);            
        }
        
    }

   
}
