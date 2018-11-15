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
    public partial class Scoring
    {
        #region Data Members

       
        #endregion

        #region Methods

        public DataTable GetScoringViewTable()
        {
            DataTable table = new DataTable("SV");

            table.Columns.Add(SNo1, typeof(int));
            table.Columns.Add(White1, typeof(string));
            table.Columns.Add(Black1, typeof(string));
            table.Columns.Add(SNo2, typeof(int));
            table.Columns.Add(White2, typeof(string));
            table.Columns.Add(Black2, typeof(string));

            return table;
        }

        private void AddScoringView(Move m)
        {
            ScoringDataRow sd = GetScoringDataRow(m.Id);

            if (Ap.Options.IsSingleNotation)
            {
                ScoringView.DefaultView[sd.R][sd.C] = m.PieceStr + m.To;
            }
            else
            {
                ScoringView.DefaultView[sd.R][sd.C] = m.PieceStr + m.FromDashTo;
            }
        }

        private void AddPage(int s1,int s2)
        {
            for (int i = 1; i <= SheetSize; i++)
            {
                ScoringView.Rows.Add(s1, "", "", s2, "", "");
                s2++;
                s1++;
            }
        }

        #endregion
    }
}
