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
        #region Data Members
        int prRowIndex = 0;
        int prColIndex = 0;
       
        #endregion

        #region Variation
        public void AddVariation()
        {
            //this.Game.Flags.IsMainline = false;
            //AddMove(Game.CurrentRowIndex + 1);

            //this.Game.CurrentMove.C = 0;
            //if (!this.Game.Flags.IsGameFinished)
            //{
            //    this.Game.CurrentMove.R = this.Game.CurrentRowIndex;
            //}
        }

        private void AddMove(int rowIndex)
        {
            //if (rowIndex == -1)
            //{
            //    // New row is added when
            //    // 1. Game is just started and no row is available
            //    // 2. Current Column exceed Max Column e.g. 9
            //    if (Game.CurrentRowIndex == -1 || this.Game.CurrentColumnIndex >= (MaxColumnIndex - 1) || this.Game.Flags.IsBlackVariation)
            //    {
            //        NewMovesDisplayRow();
            //    }
            //}
            //else
            //{
            //    NewMovesDisplayRow(rowIndex);
            //}

            //if (this.Game.Flags.IsGameFinished)
            //{
            //    Game.CurrentMove.R = Game.CurrentRowIndex - 1;
            //    SetMovesDisplay(Game.CurrentMove.R);
            //}
            //else
            //{
            //    SetMovesDisplay(Game.CurrentRowIndex);
            //}
           
        }

        public void CheckVariation(int SelectedColumnIndex, Move m)
        {           

            //if (m == null)
            //    return;

            //if ((Game.CurrentMove.C != this.Game.CurrentColumnIndex)) //|| SelectedRowIndex != Game.CurrentRowIndex)// && SelectedRowIndex == Game.CurrentRowIndex) 
            //{  
            //    prRowIndex = this.Game.CurrentMove.R;           // add for after game result
            //    prColIndex = this.Game.CurrentMove.C;        // add for after game result                  
            //    this.Game.CurrentMove.Flags.IsVariation = true;                
            //}
            //else
            //{                
            //    this.Game.CurrentMove.Flags.IsVariation = false;
            //    this.Game.Flags.IsVariation = false;
            //    this.Game.Flags.IsScoringVariation = false;
            //    Scoring.IsVariation = false;
            //}
            //this.Game.Flags.IsNewMainline = false;
            //this.Game.Flags.IsInitializeClick = false;            
        }

        #endregion
 
    }
}
