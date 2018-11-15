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

        #region Ctor

        public DataTable GetNotationViewTable()
        {
            DataTable table = new DataTable("NV");

            table.Columns.Add("C0", typeof(string));
            table.Columns.Add("C1", typeof(string));
            table.Columns.Add("C2", typeof(string));
            table.Columns.Add("C3", typeof(string));
            table.Columns.Add("C4", typeof(string));
            table.Columns.Add("C5", typeof(string));
            table.Columns.Add("C6", typeof(string));
            table.Columns.Add("C7", typeof(string));
            table.Columns.Add("C8", typeof(string));
            table.Columns.Add("C9", typeof(string));

            return table;
        }

        #endregion

        #region Properties
        public int LastNotationViewRowIndex
        {
            get
            {
                if (ResultRowId > 0)
                {
                    return ResultRowId - 1;
                }

                return NotationView.Rows.Count - 1;
            }
        } 
        #endregion

        #region Helpers
        private bool AddNewNotationViewRow(Move m)
        {
            int c = GetC(m.Pid);

            if (c == MaxColumnIndex || NotationView.Rows.Count == 0 || IsPrevMoveMainLine(m) || m.Flags.VariationType == VariationTypeE.Variation)
            {
                
                DataRow dr = NotationView.NewRow();
                NotationView.Rows.Add(dr);

                if (ResultRowId > 0)
                {
                    NotationView.Rows[NotationView.Rows.Count - 1][0] = NotationView.Rows[ResultRowId][0];
                    NotationView.Rows[ResultRowId][0] = "";
                    ResultRowId = NotationView.Rows.Count - 1;  
                }

                return true;
            }

            return false;
        }

        private void AddNotationView(Move m)
        {
            NotationDataRow nd = GetNotationDataRow(m.Id);

            if (nd == null)
            {
                return;
            }

            NotationView.Rows[nd.R][nd.C] = m.NotationForView;
        }

        public void RefreshNotation()
        {
            DisplayNotation(Ap.Options.IsSingleNotation);
        }

        public void DisplayNotation(bool isSingle)
        {
            if (EventToClearNotation != null)
            {
                EventToClearNotation(this);
            }

            Move m = null;

            foreach (DataRow dr in this.Game.Moves.DataTable.Rows)
            {
                m = new Move(dr);
                m.Game = this.Game;
                SetNotationView(isSingle, m);

                if (EventOnAddToNotation != null)
                {
                    EventOnAddToNotation(this, m);
                }
            }
        }

        public void SetNotationView(Move m)
        {
            SetNotationView(Ap.Options.IsSingleNotation, m);
        }
        
        public void SetNotationView(bool isSingle, Move m)
        {
            NotationDataRow nd = GetNotationDataRow(m.Id);

            if (nd == null)
            {
                return;
            }

            NotationView.Rows[nd.R][nd.C] = isSingle ? m.SingleNotationForView : m.DoubleNotationForView;
        }

        public void SetNotation(Move m, string comments, bool isBefore, bool isdeleteAllCommentary)
        {
            if (EventCommnetsToNotation != null)
            {
                EventCommnetsToNotation(this, m, comments, isBefore, isdeleteAllCommentary);
            }
        }

        #endregion

    }
}

