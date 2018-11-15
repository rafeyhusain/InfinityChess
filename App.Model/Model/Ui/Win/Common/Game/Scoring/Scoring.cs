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
        public Game Game = null;
        public Notations Notations = null;

        public DataTable ScoringData = null;
        public DataTable ScoringView = null;
        public bool IsSelectionAllowed = true;
        int pageSize = 0;

        #region Constants
        public const string Id = "Id";
        public const string SNo = "SNo";
        public const string R = "R";
        public const string C = "C";


        public const string SNo1 = "SNo1";
        public const string White1 = "W1";
        public const string Black1 = "B1";
        public const string SNo2 = "SNo2";
        public const string White2 = "W2";
        public const string Black2 = "B2";

        #endregion

        #endregion

        #region Events 

        public event EventHandler BeforeMoveToCurrentLine;
        public event EventHandler AfterMoveToCurrentLine;

        #endregion

        #region Ctor

        public Scoring(Notations notations,Game game)
        {
            this.Game = game;
            Notations = notations;

            ScoringData = GetScoringDataTable();
            ScoringView = GetScoringViewTable();
        }

        #endregion

        #region Properties

        #region Calculated
        public int PageSize
        {
            [DebuggerStepThrough]
            get
            {
                return pageSize;
            }
            [DebuggerStepThrough]
            set
            {
                pageSize = value;
            }
        }

        public int SheetSize
        {
            [DebuggerStepThrough]
            get
            {
                return PageSize / 2;
            }
            [DebuggerStepThrough]
            set
            {
                PageSize = value * 2;
            }
        }

        public int Sheet1LastSno
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToInt32(ScoringView.DefaultView[SheetSize - 1][SNo1]);
            }
        }

        public Move PageLastMove // Incomplete
        {
            [DebuggerStepThrough]
            get
            {
                int sno = BaseItem.ToInt32(ScoringView.DefaultView[ScoringView.DefaultView.Count - 1][SNo2]);
                ScoringDataRow sd = GetScoringDataRow(ScoringView.DefaultView.Count - 1, 5, sno);
                return GetMove(sd.Id);
            }
        }

        public Move PageFirstMove
        {
            [DebuggerStepThrough]
            get
            {
                if (Notations.Game.Flags.IsFirtMove)
                {
                    return null;
                }

                int sno = BaseItem.ToInt32(ScoringView.DefaultView[0][SNo1]);
                ScoringDataRow sd = GetScoringDataRow(0, 1, sno);
                return GetMove(sd.Id);
            }
        }
        #endregion

        #endregion

        #region Helper

        public void AddNormalMove(Move m)
        {
            AddNewPageIfRequried(m);
            AddScoringData(m);
            AddScoringView(m);
        }

        public void AddCurrentMoveLine(Move m)
        {
            Notations.IsFromAdd = true;
            Clear();

            Moves moves = Notations.Game.Moves.GetLine(m);
            
            if (moves == null)
            {
                return;
            }

            moves.Sort("Id Asc");

            for (int i = 0; i < moves.Count; i++)
            {
                Move move = moves[i];

                AddNormalMove(move);
            }

            int p = GetPageNo(m);

            int j = p * PageSize;

            ScoringView.DefaultView.RowFilter = SNo1 + ">" + (j - PageSize) + " and " + SNo1 + "<=" + j;

            Notations.IsFromAdd = false;
        }

        private int GetPageNo(Move m)
        {
            int sno = GetSno(m);

            return GetPageNo(sno);
        }

        private int GetPageNo(int sno)
        {
            int p = 1, j = PageSize;

            while (sno > j)
            {
                j = j + j;
                p++;
            }

            return p;
        }

        private int GetTotalPages()
        {
            object objId = ScoringData.Compute("max(" + SNo + ")", "");
            if (objId == DBNull.Value)
            {
                return 1;
            }
            
            int sno = Convert.ToInt32(objId);

            return GetPageNo(sno);
        }

        private void AddNewPageIfRequried(Move m)
        {
            int sno = GetNextSno(m);
            if (sno > ScoringView.Rows.Count * 2)
            {
                int s2 = sno + SheetSize;
                AddPage(sno, s2);

                ScoringView.DefaultView.RowFilter = SNo1 + ">=" + sno + " and " + SNo1 + "<=" + sno + PageSize;
            }
        }

        private Move GetMove(int id)
        {
            return Notations.Game.Moves.GetById(id);
        }

        private void SetPage(Move m)
        {
            Notations.IsFromAdd = true;

            int p = GetPageNo(m);

            int j = p * PageSize;

            ScoringView.DefaultView.RowFilter = SNo1 + ">" + (j - PageSize) + " and " + SNo1 + "<=" + j;

            Notations.IsFromAdd = false;
        }


        #endregion

        #region New Game
        public void NewGame()
        {
            switch (this.Game.GameType)
            {
                case GameType.Long:
                    PageSize = 100;
                    break;
                default:
                    PageSize = 20;
                    break;
            }

            Clear();
        }

        private void Clear()
        {
            if (ScoringData != null)
            {
                ScoringData.Clear();
            }

            if (ScoringView != null)
            {
                ScoringView.Clear();
            }

            ScoringView.DefaultView.RowFilter = "";

            int s2 = SheetSize + 1;

            for (int s1 = 1; s1 <= SheetSize; s1++)
            {
                ScoringView.Rows.Add(s1, "", "", s2, "", "");
                s2++;
            }
        }
        #endregion

        #region Nevigation
        public void FirstPage()
        {
            Notations.IsFromAdd = true;

            int p = 1;

            FilterTable(p);

            Notations.IsFromAdd = false;
        }

        public void NextPage()
        {
            Notations.IsFromAdd = true;

            int p = GetPageNo(Notations.Game.CurrentMove) + 1;

            if (p > GetTotalPages())
            {
                return;
            }

            FilterTable(p);

            Notations.IsFromAdd = false;
        }

        public void PrevPage()
        {
            Notations.IsFromAdd = true;

            int p = GetPageNo(Notations.Game.CurrentMove) - 1;

            if (p == 0)
            {
                return;
            }

            FilterTable(p);

            Notations.IsFromAdd = false;
        }

        public void LastPage()
        {
            Notations.IsFromAdd = true;

            int p = GetTotalPages();

            FilterTable(p);

            Notations.IsFromAdd = false;
        }

        private void FilterTable(int p)
        {
            int j = p * PageSize;

            ScoringView.DefaultView.RowFilter = SNo1 + ">" + (j - PageSize) + " and " + SNo1 + "<=" + j;

            Notations.Game.MoveTo(PageFirstMove);

        }

        #endregion
    }
}
