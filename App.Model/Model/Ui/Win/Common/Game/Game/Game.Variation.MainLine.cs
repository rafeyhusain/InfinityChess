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
        
        DataTable tempNotatioData = null;

        #endregion

        #region MainLine
        
        public void AddMainLine()
        {
           // // ToDo: Reminder code required refectoring but working fine .. !

           // Move m = null;

           // string filter = null;
           // string setMove = null;

           // int columnIndex = 0;
           // int selectedColIndex = 0;
           // int pr = 0;
           // int pc = 0;            
           // int rowCount = 0;

           // bool IsWhite = false;
           // this.Game.Flags.IsNewMainline = true;

           //// CurrentColumnIndex++;          

           // tempNotatioData = this.Game.Moves.DataTable.Copy();
           // tempNotatioData.TableName = "tempNotatioData";

           // m = this.Game.CurrentMove;
           // IsWhite = m.IsWhite;
           // this.Game.CurrentMove.SNo = m.SNo + 1;

           // filter += "(r =" + Game.CurrentMove.R + " AND c >" + (Game.CurrentMove.C).ToString() + ") OR ";
           // filter += "(r >" + Game.CurrentMove.R + ")";

           // if (Game.CurrentMove.R == -1 && Game.CurrentMove.C == -1)
           // {
           //     Game.CurrentMove.R = 0;
           //     Game.CurrentMove.C = 0;
           //     this.Game.Flags.IsMainline = true;
           //     this.Game.Flags.IsVariationInProgress = false;                

           //     DeleteNotationData(filter);
                
           //     this.Game.CurrentMove.R = Game.CurrentMove.R;
           //     this.Game.CurrentMove.C = Game.CurrentMove.C;
           //     this.Game.CurrentMove.White = m.White;
           //     this.Game.CurrentMove.MoveNo = m.MoveNo;
           //     this.Game.CurrentMove.PieceStr = m.PieceStr;
           //     this.Game.CurrentMove.From = m.From;
           //     this.Game.CurrentMove.To = m.To;
           //     this.Game.CurrentMove.MoveTime = m.MoveTime;
           //     this.Game.CurrentMove.MoveTimeWhite = this.Game.Clock.WhiteTime;
           //     this.Game.CurrentMove.MoveTimeBlack = this.Game.Clock.BlackTime;
           //     this.Game.CurrentMove.Fen = m.Fen;
           //     this.Game.CurrentMove.CapturedPceStr = m.CapturedPceStr;               

           // }
           // else
           // {                

           //     DeleteNotationData(filter);            
               
           //     selectedColIndex = Game.CurrentMove.C;
           //     selectedColIndex = selectedColIndex + 1;     // new change                           

           //     this.Game.CurrentMove.R = Game.CurrentMove.R;
           //     this.Game.CurrentMove.C = selectedColIndex;
           //     this.Game.CurrentMove.Pr = SelectedCellRowIndex;
           //     this.Game.CurrentMove.Pc = SelectedCellColumnIndex;
                
           //     this.Game.Moves.Import(this.Game.CurrentMove);   

           //     Game.CurrentMove.C = Game.CurrentMove.C + 1;
                
           // }

           // if (MovesDisplay.Rows.Count - 1 <= 0)
           // {
           //     if (Game.CurrentMove.R == -1 && Game.CurrentMove.C == -1)
           //     {
           //         Game.CurrentMove.R = 0;
           //         Game.CurrentMove.C = 0;
           //     }
           //     AddNewRow();
           // }         
                

           // if (!this.Game.Flags.IsMainline)
           // {
           //     this.Game.Flags.IsVariationInProgress = true;
           // }

           // SetDisplayNotation(setMove =  this.Game.CurrentMove.Notation, rowCount = Game.CurrentMove.R, Game.CurrentMove.C, this.Game.Flags.IsVariationInProgress);                
            

           // if (Ap.Game.Flags.IsInitializeClick || Game.CurrentMove.R == 0 && Game.CurrentMove.C == 0)
           // {
           //     pr = Convert.ToInt32(tempNotatioData.Rows[0][Moves.R]);
           //     pc = Convert.ToInt32(tempNotatioData.Rows[0][Moves.C]);
           // }
           // else
           // {   
           //     pr = Convert.ToInt32(tempNotatioData.Rows[0][Moves.Pr]);
           //     pc = Convert.ToInt32(tempNotatioData.Rows[0][Moves.Pc]);
           // }

           // foreach (DataRow rv in tempNotatioData.Rows)
           // {

           //     Move m1 = new Move(rv);
                
           //     int row = m1.R;
           //     int col = m1.C;

           //     if (col == 0 || columnIndex >= 10)
           //     {
           //         columnIndex = 0;
           //     }

           //     row = row + 1;

           //     if (MovesDisplay.Rows.Count == 0 || row > MovesDisplay.Rows.Count - 1)
           //     {
           //         AddNewRow();
           //         columnIndex = 0;
           //     }

           //     if (this.Game.Flags.IsGameFinished)
           //     {
           //         MovesDisplay.Rows[row][0] = "";
           //     }

           //     if (IsWhite)
           //     {
           //         this.Game.Flags.IsBlackVariation = true;
           //         IsWhite = false;
           //     }

           //     this.Game.Flags.IsVariationInProgress = true;
           //     SetDisplayNotation(m1.Notation, row, columnIndex, this.Game.Flags.IsVariationInProgress);

           //     m1.SNo = m1.SNo + 1;
           //     m1.R = row;
           //     m1.C = columnIndex;
           //     m1.Pr = pr;
           //     m1.Pc = pc;

           //     this.Game.Moves.Import(m1);

           //     pr = this.Game.CurrentMove.R;
           //     pc = this.Game.CurrentMove.C;
           //     columnIndex++;
           // }

           // PrRow = SelectedCellRowIndex;     //pr;
           // PrCol = SelectedCellColumnIndex;  //pc;

           // if (!m.IsWhite)
           // {
           //     this.Game.CurrentMove.IsWhite = true;
           // }
           // else
           // {
           //     this.Game.CurrentMove.IsWhite = false;
           //     this.Game.CurrentMove.MoveNo = m.MoveNo;           
           // }     

           // this.Game.Flags.IsVariationInProgress = false;            
           // this.Game.Flags.IsBlackVariation = true;
           // this.Game.Flags.IsMainline = true;                        
            
           // if (MoveAdded != null)
           // {
           //     MoveAdded(this, new MoveToNotationEventArgs(Game.CurrentMove.R, CurrentColumnIndex));
           // }
           
           // // For Scoring Window 
           // OnMovesAdded(this.Game.CurrentMove.SNo, setMove , rowCount, true);
            
        }

        private void DeleteNotationData(string filter)
        {           

            //this.Game.Moves.DataTable.DefaultView.RowFilter = filter;

            //foreach (DataRowView rv in this.Game.Moves.DataTable.DefaultView)
            //{
            //    int r = Convert.ToInt32(rv.Row[Moves.R]);
            //    int c = Convert.ToInt32(rv.Row[Moves.C]);
            //    NotationView.Rows[r][c] = "";
            //    rv.Row.Delete();
            //    this.Game.Moves.DataTable.Rows.Remove(rv.Row);
            //}
            
            //for (int i = this.Game.Moves.DataTable.Rows.Count - 1; i >= 0; i--)
            //{
            //    tempNotatioData.Rows.RemoveAt(i);
            //}
                
        }
          
        #endregion
    }
}
