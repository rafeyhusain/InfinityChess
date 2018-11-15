using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model
{
    public class UCIEventArgs : EventArgs
    {
        public UCIEventArgs()
        {

        }
    }

    public class UCIMoveEventArgs : UCIEventArgs
    {
        public string MoveFrom { get; set; }
        public string MoveTo { get; set; }
        
        public UCIMoveEventArgs(string moveFrom, string moveTo)
        {
            MoveFrom = moveFrom;
            MoveTo = moveTo;            
        }
    }

    public class UCIUndoMoveEventArgs : UCIEventArgs
    {
        public string Move { get; set; }

        public UCIUndoMoveEventArgs(string move)
        {
            Move = move;
        }
    }

    public class UCIIllegalMoveEventArgs : UCIEventArgs
    {
        public string Move { get; set; }
        public string Message { get; set; }

        public UCIIllegalMoveEventArgs(string move, string message)
        {
            Move = move;
            Message = message;            
        }
    }

    public class UCIErrorEventArgs : UCIEventArgs
    {        
        public string Message { get; set; }

        public UCIErrorEventArgs(string message)
        {
            Message = message;
        }
    }

    public class UCIMessageEventArgs : UCIEventArgs
    {
        public string Message { get; set; }

        public UCIMessageEventArgs(string message)
        {
            Message = message;
        }
    }

    public class UCIInfoEventArgs : UCIEventArgs
    {
        public string CurrentMove { get; set; }
        public int CurrentMoveNumber { get; set; }
        public int Depth { get; set; }
        public long Time { get; set; }
        public long Nodes { get; set; }
        public long NPS { get; set; }
        public int ScoreCP { get; set; }
        public string PV { get; set; }
        public int MultiPV { get; set; }
        public int SelDepth { get; set; }
        public long CpuLoad { get; set; }
        public int TbHits { get; set; }
        public bool IsLowerBound { get; set; }
        public bool IsUpperBound { get; set; }
        public int Mate { get; set; }

        public UCIInfoEventArgs(
                                string currentMove,
                                int currentMoveNumber,
                                int depth,
                                long time,
                                long nodes,
                                long nps,
                                int scoreCP,
                                string pv,
                                int multipv,
                                int seldepth,
                                long cpuload,
                                int tbHits,
                                bool isLowerBound,
                                bool isUpperBound,
                                int mate
                                )
        {
            CurrentMove = currentMove;
            CurrentMoveNumber = currentMoveNumber;
            Depth = depth;
            Time = time;
            Nodes = nodes;
            NPS = nps;
            ScoreCP = scoreCP;
            PV = pv;
            MultiPV = multipv;
            SelDepth = seldepth;
            CpuLoad = cpuload;
            TbHits = tbHits;
            IsLowerBound = isLowerBound;
            IsUpperBound = isUpperBound;
            Mate = mate;
        }
    }

}
