using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Xml;
using System.Windows.Markup;
using ChessLibrary;
using App.Model;

namespace ChessBoardCtrl.New
{
    public class BoardSquare
    {
        public string Name;
        public Pieces Piece;
        public int Column;
        public int Row;
        public Viewbox Viewbox;
        public Border Background;
        public BoardSquare()
        {
            Piece = Pieces.NONE;
            Viewbox = new Viewbox();
        }
    }
}
