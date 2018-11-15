using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ChessLibrary;
using InfinitySettings.UCIManager;
using InfinitySettings.EngineManager;
using InfinityChess.Offline.Forms;
using App.Model;
using App.Model.Win.Controls;
using App.Win;

namespace InfinityChess.WinForms
{
    public partial class MainForm
    {
        #region ChessBoardCtrl

        public ChessBoardUc ChessBoardUc
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return this.ChessBoard.ChessBoardUc;
            }
        }

        #endregion
    }
}
