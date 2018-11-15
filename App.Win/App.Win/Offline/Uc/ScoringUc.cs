using System;
using App.Model;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ChessLibrary;
using InfinityChess.Offline.Forms;
using App.Win;
using WeifenLuo.WinFormsUI.Docking;

namespace InfinityChess
{
    public partial class ScoringUc : DockContent, IGameUc
    {
        #region Data Members

        public Game Game = null;

        public const string Guid = "204f7ed7-2422-4dad-8768-aca0cc2d406b";

        #endregion

        #region ctor
        public ScoringUc(Game game)
        {
            this.Game = game;
            InitializeComponent();
        }

        #endregion

        #region Paging

        private enum NavButton
        {
            First = 1,
            Next = 2,
            Previous = 3,
            Last = 4,
        }


        private void tsbFirst_Click(object sender, EventArgs e)
        {
            this.Game.Notations.Scoring.FirstPage();
        }

        private void tsbPrevious_Click(object sender, EventArgs e)
        {
            this.Game.Notations.Scoring.PrevPage();
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            this.Game.Notations.Scoring.NextPage();
        }

        private void tsbLast_Click(object sender, EventArgs e)
        {
            this.Game.Notations.Scoring.LastPage();
        }

        #endregion

        #region IGameUc Members

        public void NewGame()
        {

        }

        public void Init()
        {
            dgvScoring.DataSource = this.Game.Notations.Scoring.ScoringView;

            this.Game.Notations.EventOnAddToNotation += new Notations.OnAddToNotation(Notations_EventOnAddToNotation);
            this.Game.Notations.Scoring.MoveToEventE += new Scoring.MoveToEventHandler(Scoring_MoveToEventE);
            this.Game.Notations.Scoring.MoveToEvent += new EventHandler(Scoring_MoveToEvent);
            this.Game.Notations.Scoring.BeforeMoveToCurrentLine += new EventHandler(Scoring_BeforeMoveToCurrentLine);
            this.Game.Notations.Scoring.AfterMoveToCurrentLine += new EventHandler(Scoring_AfterMoveToCurrentLine);
        }

        void Scoring_BeforeMoveToCurrentLine(object sender, EventArgs e)
        {
            this.Game.Notations.Scoring.IsSelectionAllowed = false;
            dgvScoring.DataSource = null;
        }

        void Scoring_AfterMoveToCurrentLine(object sender, EventArgs e)
        {
            this.Game.Notations.Scoring.IsSelectionAllowed = true;
            dgvScoring.DataSource = this.Game.Notations.Scoring.ScoringView;
        }

        void Notations_EventOnAddToNotation(object sender, Move m)
        {
            SetSelection(m);
        }

        public void UnInit()
        {
            this.Game.Notations.EventOnAddToNotation -= new Notations.OnAddToNotation(Notations_EventOnAddToNotation);
            this.Game.Notations.Scoring.MoveToEventE -= new Scoring.MoveToEventHandler(Scoring_MoveToEventE);
            this.Game.Notations.Scoring.MoveToEvent -= new EventHandler(Scoring_MoveToEvent);            
        }
        #endregion

        #region Helper
        public void SetSelection(Move m)
        {
            try
            {
                ScoringDataRow sd = this.Game.Notations.Scoring.GetScoringDataRow(m.Id);

                if (sd == null)
                {
                    return;
                }

                this.Game.Notations.IsFromAdd = true;

                if (sd.R < dgvScoring.Rows.Count && sd.C < dgvScoring.ColumnCount)
                {
                    dgvScoring.CurrentCell = dgvScoring[sd.C, sd.R];
                    dgvScoring.Refresh();
                }

                this.Game.Notations.IsFromAdd = false;
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                string s = ex.ToString();
            }
        }
        #endregion

        #region Grid Events
        private void dgvScoring_SelectionChanged(object sender, EventArgs e)
        {
            if (!this.Game.Notations.Scoring.IsSelectionAllowed)
            {
                return;
            }

            if (dgvScoring.CurrentCell == null || this.Game.Flags.IsFirtMove || this.Game.Notations.IsFromAdd)
            {
                return;
            }

            int sno = 0;
            if (dgvScoring.CurrentCell.ColumnIndex > 3)
            {
                sno = BaseItem.ToInt32(dgvScoring[3, dgvScoring.CurrentCell.RowIndex].Value);
            }
            else
            {
                sno = BaseItem.ToInt32(dgvScoring[0, dgvScoring.CurrentCell.RowIndex].Value);
            }

            ScoringDataRow sd = this.Game.Notations.Scoring.GetScoringDataRow(dgvScoring.CurrentCell.RowIndex, dgvScoring.CurrentCell.ColumnIndex, sno);

            if (sd == null)
            {
                return;
            }

            Move m = this.Game.Moves.GetById(sd.Id);

            this.Game.MoveTo(m);
        }

        private void dgvScoring_KeyDown(object sender, KeyEventArgs e)
        {
            switch ((Keys)e.KeyValue)
            {
                case Keys.Left:
                    e.Handled = true;
                    break;
                case Keys.Right:
                    e.Handled = true;
                    break;
            }
        }

        private void dgvScoring_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {




        }

        //private void dgvScoring_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{
        //    int i = e.ColumnIndex;
        //}

        #endregion

        #region Overrrides

        protected override string GetPersistString()
        {
            return Guid;
        }

        #endregion
    }
}