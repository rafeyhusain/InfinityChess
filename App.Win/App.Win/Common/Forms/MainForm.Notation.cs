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
using App.Model;

using InfinityChess.Offline.Forms;

namespace InfinityChess.WinForms
{
    public partial class MainForm
    {
        public static char PieceToNotation(Pieces piece)
        {
            char aPiece = ' ';
            switch (piece)
            {
                case Pieces.WKING:
                case Pieces.BKING:
                    aPiece = 'K';
                    break;
                case Pieces.WQUEEN:
                case Pieces.BQUEEN:
                    aPiece = 'Q';
                    break;
                case Pieces.WROOK:
                case Pieces.BROOK:
                    aPiece = 'R';
                    break;
                case Pieces.WBISHOP:
                case Pieces.BBISHOP:
                    aPiece = 'B';
                    break;
                case Pieces.WKNIGHT:
                case Pieces.BKNIGHT:
                    aPiece = 'N';
                    break;
                case Pieces.WPAWN:
                case Pieces.BPAWN:
                    aPiece = ' ';
                    break;
            }
            return aPiece;
        }
    }
}
