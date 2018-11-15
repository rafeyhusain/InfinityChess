using System;
using App.Model;
using System.Collections.Generic;
using System.Data;
using System.Text;
using InfinityChess;
using System.Windows.Forms;
using ChessLibrary;
using System.Diagnostics;
using System.ComponentModel;

namespace App.Model
{
    public partial class Scoring
    {
        
        #region Events

        public delegate void MoveToEventHandler(MoveToE moveTo);
        public event MoveToEventHandler MoveToEventE;

        public event EventHandler MoveToEvent;

        #endregion

        #region MoveTo Methods

        public void MoveTo(MoveToE moveTo)
        {
            SetPage(Notations.Game.CurrentMove);

            if (MoveToEventE != null)
            {
                MoveToEventE(moveTo);
            }
        }

        public void MoveTo()
        {
            MoveToBW(Notations.Game.CurrentMove);
        }

        private BackgroundWorker moveToWorker;
        private void InitMoveToWorker()
        {
            // create new worker
            this.moveToWorker = new BackgroundWorker();
            // set that it can be cancelled
            this.moveToWorker.WorkerSupportsCancellation = true;
            // install do work event
            this.moveToWorker.DoWork += new DoWorkEventHandler(moveToWorker_DoWork);
            this.moveToWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(moveToWorker_RunWorkerCompleted);   
        }

        void moveToWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (AfterMoveToCurrentLine != null)
            {
                AfterMoveToCurrentLine(this, EventArgs.Empty);
            }
            if (MoveToEvent != null)
            {
                MoveToEvent(this, EventArgs.Empty);
            }
        }

        void moveToWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Move m = e.Argument as Move;
            ThMoveTo(m);
        }

        public void MoveToBW(Move m)
        {
            if (moveToWorker == null)
            {
                InitMoveToWorker();
            }
            if (moveToWorker.IsBusy)
            {
                moveToWorker.CancelAsync();
            }

            if (!moveToWorker.IsBusy)
            {
                if (BeforeMoveToCurrentLine != null)
                {
                    BeforeMoveToCurrentLine(this, EventArgs.Empty);
                }
                try
                {
                    moveToWorker.RunWorkerAsync(m);
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                }
            }
        }

        private void ThMoveTo(Move m)
        {
            AddCurrentMoveLine(m);

            //if (MoveToEvent != null)
            //{
            //    MoveToEvent(this, EventArgs.Empty);
            //}
        }

        #endregion
    }
}
