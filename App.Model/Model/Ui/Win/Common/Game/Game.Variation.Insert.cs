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
        #region Insert
        public void AddInsert()
        {
            //this.Game.CurrentMove.C = this.Game.CurrentMove.C + 1;
            //if (this.Game.CurrentMove.R == -1)
            //{
            //    this.Game.CurrentMove.R++;
            //    //this.CurrentColumnIndex = this.Game.CurrentMove.C;                
            //}

            //Move m = Game.CurrentMove;

            ////Game.CurrentMove.SNo = this.Game.Notations.Scoring.Game.CurrentMove.SNo =  m.SNo;            
         
            //if(!this.Game.Flags.IsMainline)
            //{
            //    this.Game.Flags.IsVariationInProgress = true;
            //}

            //SetDisplayNotation(this.Game.CurrentMove.Notation, this.Game.CurrentMove.R, this.Game.CurrentMove.C, true);            

            //if (Ap.Game.GameMode == GameMode.HumanVsHuman)   // for same move in manual game after retrac
            //{
            //    if (!this.Game.Flags.IsMainline)
            //    {
            //        this.Game.Flags.IsVariationInProgress = true;                    
            //    }
            //    else
            //    {
            //        this.Game.Flags.IsVariationInProgress = false;                    
            //    }
            //}
            //else
            //{
            //    this.Game.CurrentMove.Flags.IsBlackVariation = true;
            //    this.Game.Flags.IsBlackVariation = true;
            //    this.Game.Flags.IsVariationInProgress = true;
            //    this.Game.Flags.IsMainline = false;
            //}

            // m.PieceStr = this.Game.CurrentMove.PieceStr;      
            // m.Fen = this.Game.CurrentMove.Fen;           
            // m.From = this.Game.CurrentMove.From;          
            // m.To = this.Game.CurrentMove.To;            
            // m.MoveTime = this.Game.CurrentMove.MoveTime;      
            // m.MoveTimeWhite = this.Game.CurrentMove.MoveTimeWhite;
            // m.MoveTimeBlack = this.Game.CurrentMove.MoveTimeBlack;
            // m.Flags.IsBlackVariation = this.Game.CurrentMove.Flags.IsBlackVariation;
            // m.CapturedPceStr = this.Game.CurrentMove.CapturedPceStr;                      

            //VariationTypeE = VariationTypeE.None;            
        }

        #endregion

    }
}
