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
        public const int MaxColumnIndex = 9;

        public Game Game = null;
        public Scoring Scoring = null;
        public DataTable NotationData = null;
        public DataTable NotationView = null;

        public int ResultRowId=0;
        public bool IsFromAdd = false;

        public const string Id = "Id";
        public const string R = "R";
        public const string C = "C";
        #endregion

        #region Events
        public delegate void OnAddToNotation(object sender, Move m);
        public event OnAddToNotation EventOnAddToNotation;

        public delegate void OnCommnetsToNotation(object sender, Move m, string comments, bool isbefore, bool isdeleteAllCommentary);
        public event OnCommnetsToNotation EventCommnetsToNotation;

        public delegate void OnToClearNotation(object sender);
        public event OnToClearNotation EventToClearNotation;

        public delegate void OnResultToNotation(object sender, string result);
        public event OnResultToNotation EventOnResultToNotation;
        #endregion

        #region Ctor
        public Notations(Game game)
        {
            this.Game = game;

            NotationData = GetNotationDataTable();
            NotationView = GetNotationViewTable();

            Scoring = new Scoring(this, this.Game);
        }

        public void NewGame()
        {
            if (NotationData != null)
            {
                NotationData.Clear();
            }

            if (NotationView != null)
            {
                NotationView.Clear();
            }

            ResultRowId = 0;

            Scoring.NewGame();
        }

        #endregion

        #region Method
        public void AddMove(Move m)
        {
            this.AddToNotation(m);
        }

        private void AddToNotation(Move m)
        {
            IsFromAdd = true;

            switch (m.Flags.VariationType)
            {
                case VariationTypeE.Variation:
                    AddVariation(m);
                    break;
                case VariationTypeE.MainLine:
                    AddMainLine(m);
                    break;
                case VariationTypeE.Insert:
                    AddInsert(m);
                    break;
                case VariationTypeE.Overwrite:
                    AddOverwrite(m);
                    break;
                default:
                    AddNormalMove(m);
                    break;
            }

            if (EventOnAddToNotation != null)
            {
                EventOnAddToNotation(this, m);
            }

            IsFromAdd = false;
        }

        public void NotationTextClear()
        {
            if (EventToClearNotation != null)
            {
                EventToClearNotation(this);
            }
        }
        #endregion

        #region Variations

        private void AddNormalMove(Move m)
        {
            AddNotationData(m);
            AddNotationView(m);
            Scoring.AddNormalMove(m);
        }

        private void AddVariation(Move m)
        {
            AddNotationData(m);
            AddNotationView(m);
            Scoring.AddCurrentMoveLine(m);
        }

        private void AddMainLine(Move m)
        {
            int i,r = 0, c = 0, d = 0;
            string str = "";

            Move move = Game.Moves.GetById(m.Pid);

            Moves moves = Game.Moves.GetLineFrom(move);

            if (moves == null)
            {
                return;
            }

            for (i = 0; i < moves.Count; i++)
            {
                move = moves[i];

                NotationDataRow nv = GetNotationDataRow(move.Id);

                r = nv.R;
                d = nv.C;

                str = NotationView.Rows[r][d].ToString();
                NotationView.Rows[r][d] = "";

                c++;

                if (r >= LastNotationViewRowIndex || i == 0 || c == 10)
                {
                    DataRow dr = NotationView.NewRow();
                    NotationView.Rows.Add(dr);
                    if (c == 10)
                    {
                        c = 0;
                    }
                }

                r = LastNotationViewRowIndex;
                
                nv.R = r;
                nv.C = c;

                NotationView.Rows[r][c] = str;
            }

            NotationData.AcceptChanges();
            NotationView.AcceptChanges();

            AddNotationData(m);
            AddNotationView(m);
            Scoring.AddCurrentMoveLine(m);
        }

        private void AddOverwrite(Move m)
        {
            int j = 0,i,c=0;

            if (m.HasNoParent)
            {
                j = -1;
                c = 0;

                for (i = NotationData.Rows.Count - 1; i > j; i--)
                {
                    NotationData.Rows[i].Delete();
                }

                for (i = LastNotationViewRowIndex; i > j; i--)
                {
                    NotationView.Rows[i].Delete();
                }

                NotationData.AcceptChanges();
                NotationView.AcceptChanges();

                this.Game.Moves.DeleteAllRows();

                AddNotationData(m);
                AddNotationView(m);
                Scoring.AddCurrentMoveLine(m);

                return;
            }
            else
            {
                j = GetNotationDataRowIndex(m.Pid);
            }

            for (i = LastNotationViewRowIndex; i > j; i--)
            {
                NotationData.Rows[i].Delete();
            }
            
            NotationData.AcceptChanges();

            NotationDataRow nd = GetNotationDataRow(m.Pid);

            if (nd != null)
            {
                j = nd.R;
                c = nd.C;
            }
            else
            {
                j = 0;
            }

            for (i = LastNotationViewRowIndex; i > j; i--)
            {
                NotationView.Rows[i].Delete();
            }

            for (i = c + 1; i <= MaxColumnIndex; i++)
            {
                NotationView.Rows[j][i] = "";
            }

            NotationView.AcceptChanges();

            this.Game.Moves.DeleteRows(m);

            AddNotationData(m);
            AddNotationView(m);
            Scoring.AddCurrentMoveLine(m);
        }

        private void AddInsert(Move m)  // in progress
        {
            AddOverwrite(m);
        }

        private Move ReplaceNextMove(Move m)
        {
            Move nextM = Game.Moves.Next(Game.CurrentMove);

            m.Id = nextM.Id;
            m.Pid = nextM.Pid;

            return nextM.Replace(m);
        }

        private bool IsPrevMoveMainLine(Move m)
        {
            Move pm = this.Game.Moves.Prev(m);
            
            if (pm != null)
            {
                return pm.Flags.VariationType == VariationTypeE.MainLine;
            }

            return false;
        }

        #endregion

        #region GameFinished
        public void GameFinished()
        {
            if (this.Game.Flags.IsGameFinished)
            {
                DataRow dr = NotationView.NewRow();
                NotationView.Rows.Add(dr);
                string result = string.Empty;
                NotationView.Rows[LastNotationViewRowIndex][0] = result = this.Game.GameResultString;
                ResultRowId = LastNotationViewRowIndex;

                if (EventOnResultToNotation != null)
                {
                    EventOnResultToNotation(this, result);
                }
            }
        }
        #endregion

        #region GameResultEdited
        public void GameResultEdited()
        {
            ResultRowId = LastNotationViewRowIndex;
            Game.Notations.RefreshNotation();
            if (EventOnResultToNotation != null)
            {
                EventOnResultToNotation(this, this.Game.GameData.GameResultString);
            }
           
        }
        #endregion

    }
}
