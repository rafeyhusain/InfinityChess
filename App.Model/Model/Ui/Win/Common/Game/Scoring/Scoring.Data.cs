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
    
        #region Methods

        public static DataTable GetScoringDataTable()
        {
            DataTable table = new DataTable("SD");

            table.Columns.Add(new DataColumn(Scoring.Id, typeof(int)));
            table.Columns.Add(new DataColumn(Scoring.SNo, typeof(int)));
            table.Columns.Add(new DataColumn(Scoring.R, typeof(int)));
            table.Columns.Add(new DataColumn(Scoring.C, typeof(int)));
            
            return table;
        }

        public void AddScoringData(Move m)
        {
            int sno = GetNextSno(m);
            int r = GetNextR(m);
            int c = GetNextC(m, sno);

            ScoringData.Rows.Add(m.Id, sno, r, c);
        }

        public int GetNextSno(Move m)
        {
            if (Notations.Game.Flags.IsFirtMove)
            {
                return 1;
            }

            ScoringDataRow sd = GetScoringDataRow(m.Pid);

            if (sd == null)
            {
                return 1;
            }

            if (m.IsWhite)
            {
                return sd.SNo + 1;
            }

            return sd.SNo;
        }

        public int GetNextR(Move m)
        {
            if (Notations.Game.Flags.IsFirtMove)
            {
                return 0;
            }

            ScoringDataRow sd = GetScoringDataRow(m.Pid);

            if (sd == null)
            {
                return 0;
            }

            if (m.IsWhite)
            {
                if (sd.R == SheetSize - 1)
                {
                    return 0;

                }
                return sd.R + 1;
            }

            return sd.R;
        }

        public int GetNextC(Move m,int sno)
        {
            if (Notations.Game.Flags.IsFirtMove)
            {
                return 1;
            }

            if (sno <= Sheet1LastSno)
            {
                if (m.IsWhite)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            else
            {
                if (m.IsWhite)
                {
                    return 4;
                }
                else
                {
                    return 5;
                }
            }
        }

        public int GetSno(Move m)
        {
            if (Notations.Game.Flags.IsFirtMove)
            {
                return 1;
            }

            ScoringDataRow sd = GetScoringDataRow(m.Id);

            if (sd == null)
            {
                return 1;
            }

            return sd.SNo;
        }

        public ScoringDataRow GetScoringDataRow(int id)
        {
            try
            {
                DataRow[] rows = ScoringData.Select(Id + "=" + id);

                if (rows.Length > 0)
                {
                    return new ScoringDataRow(rows[0]);
                }
            }
            catch
            {
            }
            return null;
        }

        public ScoringDataRow GetScoringDataRow(int r, int c,int sno)
        {
            try
            {
                DataRow[] rows = this.ScoringData.Select("R=" + r + " AND " + "C=" + c + " AND " + SNo + "=" + sno);
                if (rows.Length > 0)
                {
                    return new ScoringDataRow(rows[0]);
                }
            }
            catch
            {
            }

            return null;
        }

        #endregion
    }
}
