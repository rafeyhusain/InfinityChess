using System;
using App.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfinityChess;
using System.IO;
using InfinitySettings.Streams;
using InfinitySettings.UCIManager;
using System.Data;
using System.Diagnostics;
using ChessLibrary;
using AppEngine;
using ChessBoardCtrl.New;
using App.Model.Fen;
using System.Windows.Forms;

namespace App.Model
{
    public class NewGameEventArgs : EventArgs
    {
        public bool Cancel { get; set; }

        public NewGameEventArgs()
        {
            Cancel = false;
        }
    }

    public class EngineMoveEventArgs : EventArgs
    {
        public string BestMove { get; set; }
        public string PonderMove { get; set; }

        public EngineMoveEventArgs()
        {

        }
    }

    public class MoveToEventArgs : EventArgs
    {
        public Move Move { get; set; }

        public MoveToEventArgs(Move move)
        {
            this.Move = move;
        }
    }
}
