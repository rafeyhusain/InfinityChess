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
    public class ScoringDataRow : BaseItem
    {
        public const string SId = "Id";
        public const string SSNo = "SNo"; 
        public const string SR = "R";
        public const string SC = "C";

        public ScoringDataRow(DataRow row)
        {
            this.DataRow = row;
        }

        public override string PrimaryKey
        {
            [DebuggerStepThrough]
            get { return Moves.Id; }
        }

        public int Id { [DebuggerStepThrough] get { return GetColInt32(ScoringDataRow.SId); } [DebuggerStepThrough]set { SetColumn(ScoringDataRow.SId, value); } }
        public int SNo { [DebuggerStepThrough] get { return GetColInt32(ScoringDataRow.SSNo); } [DebuggerStepThrough]set { SetColumn(ScoringDataRow.SSNo, value); } }
        public int R { [DebuggerStepThrough]get { return GetColInt32(ScoringDataRow.SR); } [DebuggerStepThrough]set { SetColumn(ScoringDataRow.SR, value); } }
        public int C { [DebuggerStepThrough]get { return GetColInt32(ScoringDataRow.SC); } [DebuggerStepThrough]set { SetColumn(ScoringDataRow.SC, value); } }
    }
    
}

