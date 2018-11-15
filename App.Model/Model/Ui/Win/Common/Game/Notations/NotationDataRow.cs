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
    public class NotationDataRow : BaseItem
    {
        public const string CId = "Id";
        public const string CR = "R";
        public const string CC = "C";

        public NotationDataRow(DataRow row)
        {
            this.DataRow = row;
        }

        public override string PrimaryKey
        {
            [DebuggerStepThrough]
            get { return Moves.Id; }
        }

        public int Id { [DebuggerStepThrough] get { return GetColInt32(NotationDataRow.CId); } [DebuggerStepThrough]set { SetColumn(NotationDataRow.CId, value); } }
        public int R { [DebuggerStepThrough]get { return GetColInt32(NotationDataRow.CR); } [DebuggerStepThrough]set { SetColumn(NotationDataRow.CR, value); } }
        public int C { [DebuggerStepThrough]get { return GetColInt32(NotationDataRow.CC); } [DebuggerStepThrough]set { SetColumn(NotationDataRow.CC, value); } }
    }
    
}

