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
    public class SelectCurrentMoveChildrenEventArgs : System.ComponentModel.CancelEventArgs
    {
        public Move Move = null;
        public SelectCurrentMoveChildrenEventArgs()
        {
        }
    }
}
