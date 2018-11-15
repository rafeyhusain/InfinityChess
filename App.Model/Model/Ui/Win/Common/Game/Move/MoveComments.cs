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
    public enum MoveCommentTypeE
    {
        Before = 1,
        After = 2,
        MoveLog = 3
    }

    public class MoveComments : Kv
    {
        #region Data Members

        public Move Move = null;

        public MoveLog MoveLog = null;
        #endregion

        #region Ctor

        public MoveComments(Move m)
        {
            this.Move = m;

            base.Load(m.Comments);
            MoveLog = new MoveLog(this);
        }

        #endregion

        #region Indexer

        public string this[MoveCommentTypeE type]
        {
            get
            {
                return Get(type);
            }
            set
            {
                Set(type, value);

                if (this.Move != null)
                {
                    this.Move.Comments = base.ToDataTableString;
                }
            }
        }

        public string Get(MoveCommentTypeE type)
        {
            return base[type.ToString("d")];
        }

        public void Set(MoveCommentTypeE type, string value)
        {
            base[type.ToString("d")] = value;
        }

        public void AppendMoveLog()
        {
            if (Ap.MoveLog.IsEmpty)
            {
                return;
            }

            MoveLog.Set(Ap.MoveLog);
            this[MoveCommentTypeE.MoveLog] = Ap.MoveLog.ToString();
            Ap.MoveLog.Clear();
        }

        #endregion

        #region Properties
        public bool HasCommentsBefore
        {
            get { return !String.IsNullOrEmpty(this[MoveCommentTypeE.Before]); }
        }

        public bool HasCommentsAfter
        {
            get { return !String.IsNullOrEmpty(this[MoveCommentTypeE.After]); }
        }

        public bool HasLog
        {
            get { return !String.IsNullOrEmpty(this[MoveCommentTypeE.MoveLog]); }
        }
        #endregion

        public void Set(MoveComments mc)
        {
            base.DataTable = mc.DataTable.Copy();

            MoveLog.Set(mc.MoveLog);
        }

        public void DeleteComments()
        {
            Load("");
        }
    }
}
