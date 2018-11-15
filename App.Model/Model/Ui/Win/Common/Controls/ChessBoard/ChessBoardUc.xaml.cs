using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using App.Model;
using ChessBoardCtrl.New;
using InfinitySettings.GameManager;
using InfinitySettings.UCIManager;
using System.Collections;
using ChessLibrary;
using System.Diagnostics;
using System.Windows.Threading;
using System.Threading;
using System.Windows.Media.Effects;
using System.ComponentModel;
using Board = App.Model.Board;
using App.Model.Fen;

namespace App.Win
{
    /// <summary>
    /// Interaction logic for ChessBoardUc.xaml
    /// </summary>
    public partial class ChessBoardUc : UserControl, IPositionEvents, IValidationEvents, IGameUc
    {
        #region DataMembers

        public Game Game = null;
        Pieces promotedPiece;
        Dictionary<string, BoardSquare> BoardSquares;
        List<string> fenList;
        ArrowUc arrowUc;
        TextBlock tb;
        BoardSquare selectedSquare;
        Point clickPosition;
        List<string> fenPieces;
        MoveItem pendingMove;
        string boardSetByFEN = string.Empty;
        string fenNotation = "";

        bool isDragging = false;
        bool isFenInProgress = false;        

        #endregion

        #region Properties
        public Options Options
        {
            get { return Ap.Options; }
        }

        private bool flipped;
        public bool Flipped
        {
            get { return flipped; }
            set
            {
                RemoveArrow();
                flipped = value;
                SetPiecesOnBoard();
                SetLayout();
            }
        }

        public bool IsColor
        {
            get { return this.Game.MoveValidator.Move.Color; }
            set { this.Game.MoveValidator.Move.Color = value; }
        }

        #endregion

        #region Delegates/Events

        public delegate void Promote(bool color, string square, ref Pieces piece);
        public event Promote EventPromote;

        public delegate void IsMated();
        public event IsMated EventIsMated;

        public delegate void IsStaleMated();
        public event IsStaleMated EventIsStaleMated;

        public delegate void IsInCheck(bool isColor);
        public event IsInCheck EventIsInCheck;

        public delegate void InsufficientMaterialHandler();
        public event InsufficientMaterialHandler EventInsufficientMaterial;

        public delegate void IsFree();
        public event IsFree EventIsFree;

        public delegate void IsDone();
        public event IsDone EventIsDone;

        public delegate void movePiece(Chess.Operation op, string FromSquare, string ToSquare, Move m);
        public event movePiece EventMovePiece;

        public delegate void InitBoardHandler();
        public delegate void SetPiecesHandler();
        public delegate void RemovePiecesHandler();
        public delegate void BoardFenHandler(string fen);
        public delegate void MovePieceHandler(BoardSquare bsFrom, BoardSquare bsTo, bool doPostMoveActions, Move m);
        public delegate void RemovePieceHandler(BoardSquare bsFrom);
        public delegate void delPromotePieceEventHandler(Pieces piece, string square);
        public delegate void PlacePieceEventHandler(Pieces piece, int square);
        public delegate void DrawArrowHandler(BoardSquare bsFrom, BoardSquare bsTo);
        
        #endregion

        #region Ctor 

        public ChessBoardUc(Game game)
        {
            this.Game = game;
            arrowUc = new ArrowUc(new Point(10, 10), new Point(100, 100));
            InitializeComponent();
        }

        #endregion

        #region Load

        void ChessBoardUc_Loaded(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region Load Methods

        public void InitBoardInvoked()
        {
            LoadBoardSquares();
            SetLayout();
            //InitTextBlock();   
        }

        private void LoadBoardSquares()
        {
            grdChessBoard.Children.Clear();
            BoardSquare boardSquare;
            string notation;
            for (int row = 0; row < Sqaure.RankCount; row++)
            {
                for (int col = 0; col < Sqaure.FileCount; col++)
                {
                    notation = Sqaure.GetNotation(col, row);

                    if (BoardSquares.ContainsKey(notation))
                    {
                        boardSquare = BoardSquares[notation];
                        boardSquare.Row = row + 1;
                        boardSquare.Column = col + 1;
                        if (grdChessBoard.Children.Contains(boardSquare.Background))
                        {
                            grdChessBoard.Children.Remove(boardSquare.Background);
                        }
                        boardSquare.Background = GetSquareBorder(row, col);
                    }
                    else
                    {
                        boardSquare = new BoardSquare();
                        boardSquare.Name = notation;
                        boardSquare.Row = row + 1;
                        boardSquare.Column = col + 1;
                        boardSquare.Background = GetSquareBorder(row, col);
                        BoardSquares.Add(notation, boardSquare);
                    }

                    grdChessBoard.Children.Add(boardSquare.Background);
                    Grid.SetRow(boardSquare.Background, row);
                    Grid.SetColumn(boardSquare.Background, col);
                    Grid.SetZIndex(boardSquare.Background, 0);
                }
            }
        }

        private Border GetSquareBorder(int row, int col)
        {
            Border border = new Border();
            if ((row + col) % 2 == 0)
            {
                if (Ap.BoardTheme.IsSquareImageAvailable)
                {
                    border.Background = Ap.BoardTheme.LightImageBrush;
                }
                else
                {
                    border.Background = BoardTheme.GetColorBrush(Ap.BoardTheme.LightSquaresColor);
                }
            }
            else
            {
                if (Ap.BoardTheme.IsSquareImageAvailable)
                {
                    border.Background = Ap.BoardTheme.DarkImageBrush;
                }
                else
                {
                    border.Background = BoardTheme.GetColorBrush(Ap.BoardTheme.DarkSquaresColor);
                }
            }

            return border;
        }
        
        private void SetPiecesOnBoard()
        {
            this.grdChessBoard.Dispatcher.BeginInvoke(new SetPiecesHandler(this.SetPiecesOnBoardInvoked));
        }

        private void SetPiecesOnBoardInvoked()
        {
            if (BoardSquares == null)
                return;

            foreach (BoardSquare sq in BoardSquares.Values)
            {
                if (sq.Piece == Pieces.NONE)
                    continue;

                if (grdChessBoard.Children.Contains(sq.Viewbox))
                {
                    grdChessBoard.Children.Remove(sq.Viewbox);
                }
                grdChessBoard.Children.Add(sq.Viewbox);
                Grid.SetColumn(sq.Viewbox, MapGridColumn(sq.Column));
                Grid.SetRow(sq.Viewbox, MapGridRow(sq.Row));
                Grid.SetZIndex(sq.Viewbox, 1);
            }
        }

        #endregion

        #region Set Board Coordinates

        private void SetupBoardCoordinates()
        {
            if (Ap.BoardTheme.BoardCoordinatesVisible)
            {
                SetVerticalCoordinates();
                SetHorizontalCoordinates();

                grdHorizontalCoordinates.Visibility = Visibility.Visible;
                grdVerticalCoordinates.Visibility = Visibility.Visible;
            }
            else
            {
                grdHorizontalCoordinates.Visibility = Visibility.Hidden;
                grdVerticalCoordinates.Visibility = Visibility.Hidden;
            }
        }

        private void SetVerticalCoordinates()
        {
            grdVerticalCoordinates.Children.Clear();
            AddCoordinateItem(grdVerticalCoordinates, "1", 1, 1);
            AddCoordinateItem(grdVerticalCoordinates, "2", 2, 1);
            AddCoordinateItem(grdVerticalCoordinates, "3", 3, 1);
            AddCoordinateItem(grdVerticalCoordinates, "4", 4, 1);
            AddCoordinateItem(grdVerticalCoordinates, "5", 5, 1);
            AddCoordinateItem(grdVerticalCoordinates, "6", 6, 1);
            AddCoordinateItem(grdVerticalCoordinates, "7", 7, 1);
            AddCoordinateItem(grdVerticalCoordinates, "8", 8, 1);
        }

        private void SetHorizontalCoordinates()
        {
            grdHorizontalCoordinates.Children.Clear();
            AddCoordinateItem(grdHorizontalCoordinates, "A", 1, 1);
            AddCoordinateItem(grdHorizontalCoordinates, "B", 1, 2);
            AddCoordinateItem(grdHorizontalCoordinates, "C", 1, 3);
            AddCoordinateItem(grdHorizontalCoordinates, "D", 1, 4);
            AddCoordinateItem(grdHorizontalCoordinates, "E", 1, 5);
            AddCoordinateItem(grdHorizontalCoordinates, "F", 1, 6);
            AddCoordinateItem(grdHorizontalCoordinates, "G", 1, 7);
            AddCoordinateItem(grdHorizontalCoordinates, "H", 1, 8);
        }

        private void AddCoordinateItem(Grid grd, string text, int boardRow, int boardColumn)
        {
            TextBlock tb = new TextBlock();
            tb.Text = text;
            tb.FontWeight = FontWeights.Bold;
            tb.FontSize = 12;
            Viewbox vb = new Viewbox();
            vb.Stretch = Stretch.None;
            vb.Margin = new Thickness(2, 2, 2, 2);
            vb.Child = tb;
            grd.Children.Add(vb);
            Grid.SetColumn(vb, MapGridColumn(boardColumn));
            Grid.SetRow(vb, MapGridRow(boardRow));
            Grid.SetZIndex(vb, 1);
        }

        #endregion

        #region Set Theme

        public void SetLayout()
        {
            cnvOuterBorder.Background = BoardTheme.GetColorBrush(Ap.BoardTheme.BorderColor);
            SetupBoardCoordinates();
        }

        public void SetCurrentTheme()
        {
            LoadBoardSquares();
            SetLayout();

            // set pieces theme, and reload pieces on board
            Ap.BoardTheme.PiecesTheme = Ap.BoardTheme.BoardPieces;
            ReloadPiecesViewboxes();
            SetPiecesOnBoard();
        }

        private void ReloadPiecesViewboxes()
        {
            if (BoardSquares == null)
                return;

            RemovePiecesFromBoardInvoked();
            LoadPiecesViewboxes();
        }

        private void LoadPiecesViewboxes()
        {
            foreach (BoardSquare sq in BoardSquares.Values)
            {
                if (sq.Piece != Pieces.NONE)
                {
                    sq.Viewbox = Ap.BoardTheme.GetViewbox(sq.Piece);
                }
            }
        }

        #endregion

        #region Helper Methods

        private bool IsThreadRequired(Move m)
        {
            return m.Flags.IsCastling || m.Flags.IsEnpassantCapture || m.Flags.IsPromotion;
        }

        private BoardSquare GetBoardSquare(int boardRow, int boardColumn)
        {
            BoardSquare sq = null;

            foreach (BoardSquare item in BoardSquares.Values)
            {
                if (item.Row == boardRow && item.Column == boardColumn)
                {
                    sq = item;
                    break;
                }
            }

            return sq;
        }

        private BoardSquare GetBoardSquare(Point point)
        {
            BoardSquare sq = null;
            int boardRow = MapBoardRow(point);
            int boardColumn = MapBoardColumn(point);

            sq = GetBoardSquare(boardRow, boardColumn);
            return sq;
        }

        private int MapGridRow(int boardRow)
        {
            int gridRow = -1;
            if (Flipped)
            {
                gridRow = boardRow - 1;
            }
            else
            {
                gridRow = 8 - boardRow;
            }
            return gridRow;
        }

        private int MapGridColumn(int boardColumn)
        {
            int gridColumn = -1;
            if (Flipped)
            {
                gridColumn = 8 - boardColumn;
            }
            else
            {
                gridColumn = boardColumn - 1;
            }
            return gridColumn;
        }

        private int MapBoardColumn(Point point)
        {
            int row = -1;
            int col = -1;
            double width = (int)grdChessBoard.ActualWidth;
            double height = (int)grdChessBoard.ActualHeight;
            double squareWidth = width / 8;
            double squareHeight = height / 8;

            Point newPoint = new Point(width - point.X, height - point.Y);
            col = (int)(newPoint.X / squareWidth);
            row = (int)(newPoint.Y / squareHeight);
            int tempX = (int)(newPoint.X % squareWidth);
            int tempY = (int)(newPoint.Y % squareHeight);

            if (Flipped)
            {
                col = col + 1;
            }
            else
            {
                col = 8 - col;
            }
            return col;
        }

        private int MapBoardRow(Point point)
        {
            int row = -1;
            int col = -1;
            double width = (int)grdChessBoard.ActualWidth;
            double height = (int)grdChessBoard.ActualHeight;
            double squareWidth = width / 8;
            double squareHeight = height / 8;

            Point newPoint = new Point(width - point.X, height - point.Y);
            col = (int)(newPoint.X / squareWidth);
            row = (int)(newPoint.Y / squareHeight);
            int tempX = (int)(newPoint.X % squareWidth);
            int tempY = (int)(newPoint.Y % squareHeight);


            if (Flipped)
            {
                row = 8 - row;
            }
            else
            {
                row = row + 1;
            }
            return row;
        }

        private Point MapGridCellMidPoint(int boardRow, int boardColumn)
        {
            int gridRow = MapGridRow(boardRow) + 1;
            int gridColumn = MapGridColumn(boardColumn) + 1;

            Point point;
            double width = (int)grdChessBoard.ActualWidth;
            double height = (int)grdChessBoard.ActualHeight;
            double squareWidth = width / 8;
            double squareHeight = height / 8;
            double halfSquareWidth = squareWidth / 2;
            double halfSquareHeight = squareHeight / 2;

            //double tempX = (gridColumn * squareWidth) - halfSquareWidth;
            //double tempY = (gridRow * squareHeight) - halfSquareHeight;
            double tempX = (gridColumn * squareWidth);
            double tempY = (gridRow * squareHeight);

            point = new Point(tempX, tempY);
            return point;
        }

        public void ClearPieces()
        {
            if (BoardSquares == null)
                return;
            this.grdChessBoard.Dispatcher.BeginInvoke(new RemovePiecesHandler(this.ClearPiecesInvoked));
        }

        public void ClearPiecesInvoked()
        {
            foreach (BoardSquare item in BoardSquares.Values)
            {
                if (item.Piece == Pieces.NONE)
                    continue;
                grdChessBoard.Children.Remove(item.Viewbox);
                item.Piece = Pieces.NONE;
                item.Viewbox = new Viewbox();
            }
        }

        public void RemovePiecesFromBoard()
        {
            if (BoardSquares == null)
                return;

            this.grdChessBoard.Dispatcher.BeginInvoke(new RemovePiecesHandler(this.RemovePiecesFromBoardInvoked));
        }

        public void RemovePiecesFromBoardInvoked()
        {
            foreach (BoardSquare item in BoardSquares.Values)
            {
                if (item.Piece == Pieces.NONE)
                    continue;

                grdChessBoard.Children.Remove(item.Viewbox);
            }
        }

        private bool IsPieceMoveAllowed()
        {
            bool isPieceMoveAllowed = false;
            if (Game.GameMode != GameMode.EngineVsEngine)
            {
                isPieceMoveAllowed = Game.CurrentPlayer.IsHuman || Game.Flags.IsInfiniteAnalysisOn;
            }

            if (this.Game.Flags.IsEngineResponseReceived)
            {
                isPieceMoveAllowed = false;
            }
            return isPieceMoveAllowed;
        }

        private void RemoveEnPassant()
        {
            string enPassant = GetEnpassantSquare();
            if (!string.IsNullOrEmpty(enPassant) && enPassant != "-")
            {
                string enPassantFile = enPassant.Substring(0, 1);
                int enPassantRank = Convert.ToInt32(enPassant.Substring(1, 1));

                if (enPassantRank == 3 && this.Game.MoveValidator.Move.Color)
                {
                    this.Game.EnPassant = SquareE.NoSquare;
                }
                else if (enPassantRank == 6 && !this.Game.MoveValidator.Move.Color)
                {
                    this.Game.EnPassant = SquareE.NoSquare;
                }
            }
        }

        private void SetEnPassantSquare()
        {
            string enPassant = this.Game.FenParser.Enpassant;
            if (!string.IsNullOrEmpty(enPassant) && enPassant != "-")
            {
                string enPassantFile = enPassant.Substring(0, 1);
                int enPassantRank = Convert.ToInt32(enPassant.Substring(1, 1));
                string from = string.Empty;
                string to = string.Empty;
                Pieces piece = Pieces.NONE;
                if (enPassantRank == 3)
                {
                    from = enPassantFile + "2";
                    to = enPassantFile + "4";
                    piece = Pieces.WPAWN;
                }
                else if (enPassantRank == 6)
                {
                    from = enPassantFile + "7";
                    to = enPassantFile + "5";
                    piece = Pieces.BPAWN;
                }
                this.Game.MoveValidator.moveForEnpassant(piece, from, to);
                this.Game.EnPassant = (SquareE)Enum.Parse(typeof(SquareE), enPassant.ToUpper());
            }
        }

        private string GetEnpassantSquare()
        {
            string enPassantSquare = "-";
            if (this.Game.EnPassant == SquareE.NoSquare)
            {
                enPassantSquare = "-";
            }
            else
            {
                string enPassantFile = this.Game.EnPassant.ToString().Substring(0, 1);
                int enPassantRank = Convert.ToInt32(this.Game.EnPassant.ToString().Substring(1, 1));
                if (enPassantRank == 4)
                {
                    enPassantRank = 3;
                }
                else if (enPassantRank == 5)
                {
                    enPassantRank = 6;
                }
                enPassantSquare = enPassantFile.ToLower() + enPassantRank;
            }

            return enPassantSquare;
        }

        public void StartGame()
        {
            //SetEvents();
        }

        #endregion

        #region Move Methods/Events

        void grdChessBoard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RemoveArrow();
            grdChessBoard.CaptureMouse();
            if (!IsPieceMoveAllowed())
                return;

            clickPosition = e.GetPosition(grdChessBoard);
            BoardSquare sq = GetBoardSquare(clickPosition);
            if (sq != null && sq.Piece != Pieces.NONE)
            {
                selectedSquare = sq;
                isDragging = true;
            }
        }

        void grdChessBoard_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Game.Flags.IsPieceMovedSuccessfully = false;

            if (!isDragging)
            {
                grdChessBoard.ReleaseMouseCapture();

                return;
            }

            if (selectedSquare == null)
            {
                isDragging = false;

                grdChessBoard.ReleaseMouseCapture();

                return;
            }

            Point point = e.GetPosition(grdChessBoard);
            int boardRow = MapBoardRow(point);
            int boardColumn = MapBoardColumn(point);

            if (boardColumn < 1 || boardColumn > 8 || boardRow < 1 || boardRow > 8)
            {
                PlacePieceToOriginalPosition();
                return;
            }

            string notation = Sqaure.GetNotation(boardColumn - 1, boardRow - 1);
            if (!BoardSquares.ContainsKey(notation))
            {
                return;
            }

            BoardSquare targetSquare = BoardSquares[notation];

            Move m = new Move();
            
            m.Game = this.Game;

            m.Flags.MoveBy = MoveByE.Human;

            if (this.Game.Flags.IsMoveEnable)
            {
                m = this.Game.MoveValidator.move(selectedSquare.Piece, selectedSquare.Name, targetSquare.Name, m);
            }
            else
            {
                m.Flags.IsValidMove = false;
            }

            if (m.Flags.IsValidMove)
            {
                if (m.Flags.IsCapture && !m.Flags.IsEnpassantCapture)
                {
                    m.CapturedPiece = targetSquare.Piece;

                }

                if (IsThreadRequired(m))
                {
                    MovePieceBoxThreadSafe(selectedSquare, targetSquare, true, m);
                }
                else
                {
                    MovePieceBox(selectedSquare, targetSquare, true, m);
                }
            }
            else
            {
                PlacePieceToOriginalPosition();
            }

            grdChessBoard.ReleaseMouseCapture();
            isDragging = false;
        }

        void grdChessBoard_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && selectedSquare != null && clickPosition != null)
            {
                Point currentPoint = e.GetPosition(grdChessBoard);
                TranslateTransform transform = new TranslateTransform();
                transform.X = currentPoint.X - clickPosition.X;
                transform.Y = currentPoint.Y - clickPosition.Y;
                selectedSquare.Viewbox.RenderTransform = transform;
                Grid.SetZIndex(selectedSquare.Viewbox, 2);
            }
        }

        private void PlacePieceToOriginalPosition()
        {
            selectedSquare.Viewbox.RenderTransform = Transform.Identity;
            isDragging = false;
            App.Model.MediaPlayer.PlaySound(SoundFileNameE.Illegal);

        }

        private void MovePiece(string from, string to, MoveByE moveBy)
        {
            if (!BoardSquares.ContainsKey(from) || !BoardSquares.ContainsKey(to))
            {
                return;
            }

            BoardSquare bsFrom = BoardSquares[from];
            BoardSquare bsTo = BoardSquares[to];

            this.Game.Flags.IsPieceMovedSuccessfully = false;            
            Move m = new Move();
            m.Game = this.Game;

            m.Flags.MoveBy = moveBy;

            if (this.Game.Flags.IsMoveEnable)
            {
                m = this.Game.MoveValidator.move(bsFrom.Piece, bsFrom.Name, bsTo.Name, m);
            }
            else
            {
                m.Flags.IsValidMove = false;
            }

            if (m.Flags.IsValidMove)
            {
                if (m.Flags.IsCapture && !m.Flags.IsEnpassantCapture)
                {
                    m.CapturedPiece = bsTo.Piece;
                }                
                MovePieceBoxThreadSafe(bsFrom, bsTo, true, m);
            }
            else if (Game.GameMode == GameMode.EngineVsEngine)
            {
                Game.DoEngineMoveIfNeeded();
            }
            else
            {
                this.Game.Flags.IsMoveInProgress = false;
            }
        }

        private void MovePieceBoxThreadSafe(BoardSquare bsFrom, BoardSquare bsTo, bool doPostMoveActions, Move m)
        {
            this.grdChessBoard.Dispatcher.BeginInvoke(new MovePieceHandler(this.MovePieceBox), bsFrom, bsTo, doPostMoveActions, m);
        }

        private void MovePieceBox(BoardSquare bsFrom, BoardSquare bsTo, bool doPostMoveActions, Move m)
        {
            #region set target square
            //if (!this.Game.Flags.IsPromotion)
            if (!m.Flags.IsPromotion)
            {
                bsTo.Piece = bsFrom.Piece;
                grdChessBoard.Children.Remove(bsTo.Viewbox);

                // if pieces moved by human, then remove this viewbox and create new one,
                // as transform is attached with this viewbox
                if (this.Game.Flags.AmIHuman || Game.Flags.IsInfiniteAnalysisOn) 
                {
                    grdChessBoard.Children.Remove(bsFrom.Viewbox);
                    bsTo.Viewbox = Ap.BoardTheme.GetViewbox(bsTo.Piece);
                    grdChessBoard.Children.Add(bsTo.Viewbox);
                }
                else
                {
                    bsTo.Viewbox = bsFrom.Viewbox;
                }
                bsTo.Viewbox.RenderTransform = Transform.Identity;
                Grid.SetColumn(bsTo.Viewbox, MapGridColumn(bsTo.Column));
                Grid.SetRow(bsTo.Viewbox, MapGridRow(bsTo.Row));
                Grid.SetZIndex(bsTo.Viewbox, 1);
            }
            else
            {
                grdChessBoard.Children.Remove(bsFrom.Viewbox);
            }
            #endregion

            #region set source square

            if (!BoardSquares.ContainsKey(bsFrom.Name))
            {
                return;
            }

            BoardSquare newSquare = new BoardSquare();
            newSquare.Name = bsFrom.Name;
            newSquare.Row = bsFrom.Row;
            newSquare.Column = bsFrom.Column;
            newSquare.Piece = Pieces.NONE;
            newSquare.Viewbox = new Viewbox();
            BoardSquares[bsFrom.Name] = newSquare;

            Grid.SetColumn(newSquare.Viewbox, MapGridColumn(newSquare.Column));
            Grid.SetRow(newSquare.Viewbox, MapGridRow(newSquare.Row));
            Grid.SetZIndex(newSquare.Viewbox, 1);

            #endregion

            if (!doPostMoveActions)
            {
                return;
            }

            #region add move

            RemoveEnPassant();

            // these MoveCounters should be updated here...
            // before getting Fen, as Fen should get updated data.
            if (!this.Game.Flags.IsPromotion)
            {
                this.Game.IncFifityMove(m.Flags.IsCapture, bsFrom.Piece);
            }

            if (this.Game.MoveValidator.Move.Color)
            {
                this.Game.FullMovesCounter++;
            }

            fenNotation = GetFen();
            
            m = this.Game.AddBoardMove(bsFrom.Name, bsTo.Name, bsFrom.Piece, fenNotation, m);
            m = null;
            bsTo.Viewbox.RenderTransform = Transform.Identity;

            #endregion
        }

        private void RemovePieceBoxThreadSafe(BoardSquare bsFrom)
        {
            this.grdChessBoard.Dispatcher.BeginInvoke(new RemovePieceHandler(this.RemovePieceBox), bsFrom);
        }

        private void RemovePieceBox(BoardSquare bsFrom)
        {
            if (!BoardSquares.ContainsKey(bsFrom.Name))
            {
                return;
            }

            grdChessBoard.Children.Remove(bsFrom.Viewbox);
            bsFrom.Piece = Pieces.NONE;
            bsFrom.Viewbox = new Viewbox();
            BoardSquares[bsFrom.Name] = bsFrom;
        }

        private void DrawArrowThreadSafe(BoardSquare bsFrom, BoardSquare bsTo)
        {
            this.grdChessBoard.Dispatcher.BeginInvoke(new DrawArrowHandler(this.DrawArrow), bsFrom, bsTo);
        }

        private void DrawArrow(BoardSquare bsFrom, BoardSquare bsTo)
        {
            int fr = bsFrom.Row;
            int fc = bsFrom.Column;
            int tr = bsTo.Row;
            int tc = bsTo.Column;

            RemoveArrow();

            Point startPoint = MapGridCellMidPoint(fr, fc);
            Point endPoint = MapGridCellMidPoint(tr, tc);

            if (fr == tr)
            {
                startPoint.Y -= 10;
                endPoint.Y -= 10;
            }
            if (fc == tc)
            {
                startPoint.X -= 10;
                endPoint.X -= 10;
            }

            //SetText(startPoint, endPoint);
            cnvOuterBorder.Children.Add(arrowUc);
            arrowUc.Draw(endPoint, startPoint, Colors.Yellow);
        }

        private void RemoveArrow()
        {
            if (cnvOuterBorder.Children.Contains(arrowUc))
            {
                cnvOuterBorder.Children.Remove(arrowUc);
            }
        }

        #endregion

        #region Fen Parser

        private string getFenPosition()
        {
            System.Text.StringBuilder fen = new StringBuilder();
            int empty = 0;
            for (int row = 7; row >= 0; row--)
            {
                if (empty > 0)
                {
                    fen.Append(empty.ToString());
                    empty = 0;
                }
                if (row != 7)
                    fen.Append('/');
                for (int col = 0; col < 8; col++)
                {
                    string notation = Sqaure.GetNotation(col, row);
                    if (!BoardSquares.ContainsKey(notation))
                    {
                        continue;
                    }

                    BoardSquare sq = (BoardSquare)BoardSquares[notation];
                    switch (sq.Piece)
                    {
                        case Pieces.BKING:
                        case Pieces.BQUEEN:
                        case Pieces.BROOK:
                        case Pieces.BBISHOP:
                        case Pieces.BKNIGHT:
                        case Pieces.BPAWN:
                        case Pieces.WKING:
                        case Pieces.WQUEEN:
                        case Pieces.WROOK:
                        case Pieces.WBISHOP:
                        case Pieces.WKNIGHT:
                        case Pieces.WPAWN:
                            if (empty > 0)
                            {
                                fen.Append(empty.ToString());
                                empty = 0;
                            }
                            switch (sq.Piece)
                            {
                                case Pieces.BKING:
                                    fen.Append('k');
                                    break;
                                case Pieces.BQUEEN:
                                    fen.Append('q');
                                    break;
                                case Pieces.BROOK:
                                    fen.Append('r');
                                    break;
                                case Pieces.BBISHOP:
                                    fen.Append('b');
                                    break;
                                case Pieces.BKNIGHT:
                                    fen.Append('n');
                                    break;
                                case Pieces.BPAWN:
                                    fen.Append('p');
                                    break;
                                case Pieces.WKING:
                                    fen.Append('K');
                                    break;
                                case Pieces.WQUEEN:
                                    fen.Append('Q');
                                    break;
                                case Pieces.WROOK:
                                    fen.Append('R');
                                    break;
                                case Pieces.WBISHOP:
                                    fen.Append('B');
                                    break;
                                case Pieces.WKNIGHT:
                                    fen.Append('N');
                                    break;
                                case Pieces.WPAWN:
                                    fen.Append('P');
                                    break;
                            }
                            break;
                        case Pieces.NONE:
                            empty++;
                            break;
                    }
                }
            }
            if (empty > 0)
            {
                fen.Append(empty.ToString());
                empty = 0;
            }
            return fen.ToString();
        }

        #endregion

        #region Get/Set Castling/Fen Notations

        string GetFenCastlingNotation()
        {
            if (BoardSquares == null || BoardSquares.Count == 0)
            {
                return "";
            }
                
            string fenCastlingNotation = string.Empty;
            BoardSquare tempSquare = null;

            ///// check white castling
            tempSquare = BoardSquares["e1"];
            if (tempSquare.Piece == Pieces.WKING) // if king is on its original position
            {
                tempSquare = BoardSquares["a1"];
                if (tempSquare.Piece != Pieces.WROOK) // if queen's rook is not on its original position
                    this.Game.Flags.IsWhiteLongCastling = false;

                tempSquare = BoardSquares["h1"];
                if (tempSquare.Piece != Pieces.WROOK) // if king's rook is not on its original position
                    this.Game.Flags.IsWhiteShortCastling = false; ;
            }
            else // else king is not on its original position
            {
                this.Game.Flags.IsWhiteCastling = false;
            }

            tempSquare = BoardSquares["e8"];
            if (tempSquare.Piece == Pieces.BKING) // if king is on its original position
            {
                tempSquare = BoardSquares["a8"];
                if (tempSquare.Piece != Pieces.BROOK) // if queen's rook is not on its original position
                    this.Game.Flags.IsBlackLongCastling = false;

                tempSquare = BoardSquares["h8"];
                if (tempSquare.Piece != Pieces.BROOK) // if king's rook is not on its original position
                    this.Game.Flags.IsBlackShortCastling = false;
            }
            else // else king is not on its original position
            {
                this.Game.Flags.IsBlackCastling = false;
            }

            return this.Game.Flags.GetFenCastlingFlags();
        }

        public string GetFen()
        {
            string fenNotation = getFenPosition();
            string enpassantSquare = GetEnpassantSquare();
            if (enpassantSquare == "-")
            {
                this.Game.EnPassant = SquareE.NoSquare;
            }
            else
            {
                this.Game.EnPassant = (SquareE)Enum.Parse(typeof(SquareE), enpassantSquare.ToUpper());
            }

            string turnToMove = !IsColor ? "b" : "w";
            string fenCastlingNotation = GetFenCastlingNotation();
            string space = " ";
            fenNotation += space + turnToMove + space + fenCastlingNotation;
            fenNotation += space + enpassantSquare + space + this.Game.HalfMovesCounter.ToString() + space + this.Game.FullMovesCounter.ToString();
            return fenNotation;
        }

        public string GetFenAndCastlingOnly()
        {
            string fenNotation = getFenPosition();
            string turnToMove = !IsColor ? "b" : "w";
            string fenCastlingNotation = GetFenCastlingNotation();
            string space = " ";
            fenNotation += space + turnToMove + space + fenCastlingNotation;
            return fenNotation;
        }

        public void SetFen(string fen)
        {
            if (fenNotation == fen)
            {
                return;
            }
           
            if (this.Game.FenParser.IsBusy)
            {
                fenList.Add(fen);
                TestDebugger.Instance.Write("setfen - busy : " + fen);
            }
            else
            {
                isFenInProgress = true;
                RemoveArrow();
                fenNotation = fen;
                ClearPieces();
                this.Game.MoveValidator.clearBoard();
                this.Game.FenParser.parse(fen);
                TestDebugger.Instance.Write("setfen - parsed : " + fen);
            }
        }

        private void DoPostFenActions()
        {
            SetEnPassantSquare();
            boardSetByFEN = GetFen();
            isFenInProgress = false;
            if (this.Game.Flags.IsFirstEngineMove)
            {
                this.Game.DoEngineMoveIfNeeded();
            }

            if(pendingMove!=null)
            {
                SetupMove(pendingMove.From, pendingMove.To, pendingMove.MoveBy);
            }

            ConsumeFen();
        }

        private void ConsumeFen()
        {
            if (fenList.Count > 0)
            {
                string fen = fenList[0];
                fenList.RemoveAt(0);
                SetFen(fen);
            }
        }

        #endregion

        #region Engine + Tablebases Helper Methods

        public void SetEvents()
        {
            if (Game.Player1.Engine != null)
            {
                Game.Player1.Engine.MoveReceived -= new UCIEngine.MoveReceivedHandler(_player1_EngineMoveReceived);
                Game.Player1.Engine.MoveReceived += new UCIEngine.MoveReceivedHandler(_player1_EngineMoveReceived);
            }
            if (Game.Player1.Book != null)
            {
                Game.Player1.Book.MoveReceived -= new UCIEngine.MoveReceivedHandler(player_BookMoveReceived);
                Game.Player1.Book.MoveReceived += new UCIEngine.MoveReceivedHandler(player_BookMoveReceived);
            }
            if (Game.Player2.Engine != null)
            {
                Game.Player2.Engine.MoveReceived -= new UCIEngine.MoveReceivedHandler(_player2_EngineMoveReceived);
                Game.Player2.Engine.MoveReceived += new UCIEngine.MoveReceivedHandler(_player2_EngineMoveReceived);
            }
            if (Game.Player2.Book != null)
            {
                Game.Player2.Book.MoveReceived -= new UCIEngine.MoveReceivedHandler(player_BookMoveReceived);
                Game.Player2.Book.MoveReceived += new UCIEngine.MoveReceivedHandler(player_BookMoveReceived);
            }
            //Game.Tablebases.EventMoveReceived -= new UCIEngine.MoveReceivedHandler(Tablebases_EventMoveReceived);
            //Game.Tablebases.EventMoveReceived += new UCIEngine.MoveReceivedHandler(Tablebases_EventMoveReceived);
        }

        public void ForceEngineToPlay()
        {
            if (this.Game.DefaultEngine != null)
            {
                this.Game.Flags.IsForceEngineToMove = true;
                SendMovesToEngine(this.Game.DefaultEngine, this.Game.DefaultBook);
            }
        }

        private void SendMovesToEngine(UCIEngine engine, Book book)
        {
            if (engine == null || engine.IsClosed || engine.IsSwitchedOff || this.Game.Flags.IsEngineGameFinished)
                return;

            string gameMoves = this.Game.Moves.GetParentsStr(this.Game.CurrentMove);
            string currentFEN = GetFenAndCastlingOnly();
            long turnCounterWhite = this.Game.Clock.WhiteTime * 1000;
            long turnCounterBlack = this.Game.Clock.BlackTime * 1000;

            // send moves to book
            if (Game.Flags.IsCurrentBookAvailable)
            {
                book.SearchMove(Game.BoardFen);
            }

            if (book == null || !book.IsAvailable) // now send moves to engine
            {
                if (this.Game.Flags.IsForceEngineToMove && this.Game.Flags.IsInfiniteAnalysisOn)
                {
                    this.Game.Flags.IsProcessOutputInInfiniteAnalysis = true;
                    this.Game.Flags.IsForceEngineToMoveInInfiniteAnalysis = true;
                    this.Game.DefaultEngine.SendStop();
                }
                else
                {
                    if (this.Game.Flags.IsInfiniteAnalysisStopped)
                    {
                        this.Game.Flags.IsInfiniteAnalysisStopped = false;
                        engine.SendOption(UCIEngine.OptionMultiPv, "1");
                        engine.IsPonderMove = false;
                        if (this.Game.Flags.IsBoardSetByFen)
                        {
                            engine.SendPositionGoWithoutCheckingPonderHit(false, this.Game.InitialBoardFen, gameMoves, turnCounterWhite, turnCounterBlack);
                        }
                        else
                        {
                            engine.SendPositionGoWithoutCheckingPonderHit(false, string.Empty, gameMoves, turnCounterWhite, turnCounterBlack);
                        }
                    }
                    else if (this.Game.Flags.IsInfiniteAnalysisOn)
                    {
                        if (this.Game.Flags.IsBoardSetByFen)
                        {
                            engine.SendPositionGoInfinite(this.Game.InitialBoardFen, gameMoves);
                        }
                        else
                        {
                            engine.SendPositionGoInfinite(string.Empty, gameMoves);
                        }

                    }
                    else
                    {
                        if (this.Game.Flags.IsBoardSetByFen)
                        {
                            engine.SendPositionGo(false, this.Game.InitialBoardFen, gameMoves, turnCounterWhite, turnCounterBlack);
                        }
                        else
                        {
                            engine.SendPositionGo(false, string.Empty, gameMoves, turnCounterWhite, turnCounterBlack);
                        }
                    }

                    
                }
            }
            this.Game.OnSendMovesToEngine(gameMoves, turnCounterWhite, turnCounterBlack);
        }

        void _player1_EngineMoveReceived(object sender, UCIMoveEventArgs e)
        {
            ///// if book has not expired, then let the book to move, and stop engine moves
            if (Game.Player1.Book != null && Game.Player1.Book.IsAvailable || (Game.Clock.IsCurrentPlayerTimeExpired && !this.Game.Flags.IsInfiniteAnalysisOn))
            {
                return;
            }
            SetupMove(e.MoveFrom, e.MoveTo, MoveByE.Engine);
        }

        void _player2_EngineMoveReceived(object sender, UCIMoveEventArgs e)
        {   
            ///// if book has not expired, then let the book to move, and stop engine moves
            if (Game.Player2.Book != null && Game.Player2.Book.IsAvailable || (Game.Clock.IsCurrentPlayerTimeExpired && !this.Game.Flags.IsInfiniteAnalysisOn))
            {
                return;
            }
            SetupMove(e.MoveFrom, e.MoveTo, MoveByE.Engine);
        }

        void player_BookMoveReceived(object sender, UCIMoveEventArgs e)
        {
            if (Game.GameMode != GameMode.OnlineEngineVsEngine)
            {
                DoEvents();
            }

            if (!this.Game.Flags.IsForceEngineToMove && Game.CurrentPlayer.IsEngine)
            {
                System.Threading.Thread.Sleep(300);
            }

            try
            {
                SetupMove(e.MoveFrom, e.MoveTo, MoveByE.Book);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }

        void Tablebases_EventMoveReceived(object sender, UCIMoveEventArgs e)
        {
            //if (Game.GameMode != GameMode.OnlineEngineVsEngine)
            //{
            //    DoEvents();
            //}
            //System.Threading.Thread.Sleep(300);
            //SetupMove(e.MoveFrom, e.MoveTo);
        }

        public void DoEvents()
        {
            grdChessBoard.Refresh();
        }

        private void SetupMove(string moveFrom, string moveTo, MoveByE moveBy)
        {
            pendingMove = null;
            if (isFenInProgress) //wait for "fen" to be set
            {
                pendingMove = MoveItem.NewItem(moveFrom, moveTo, moveBy);
                return;
            };

            if (Game.CurrentPlayer.IsEngine || this.Game.Flags.IsForceEngineToMove || moveBy == MoveByE.Book)
            {
                MovePiece(moveFrom, moveTo, moveBy);
            }
        }

        #endregion

        #region Add/Remove StandardValidation Events

        public void addEvents(IValidationEvents ievents)
        {
            EventPromote += new Promote(ievents.Promotion);
            EventIsMated += new IsMated(ievents.KingIsMated);
            EventIsStaleMated += new IsStaleMated(ievents.KingIsStaleMated);
            EventIsInCheck += new IsInCheck(ievents.KingIsInCheck);
            EventIsFree += new IsFree(ievents.KingIsFree);
            EventIsDone += new IsDone(ievents.FinishedMove);
            EventMovePiece += new movePiece(ievents.UpdateBoard);
            EventInsufficientMaterial += new InsufficientMaterialHandler(ievents.InsufficientMaterial);
        }

        public void removeEvents(IValidationEvents ievents)
        {
            EventPromote -= new Promote(ievents.Promotion);
            EventIsMated -= new IsMated(ievents.KingIsMated);
            EventIsStaleMated -= new IsStaleMated(ievents.KingIsStaleMated);
            EventIsInCheck -= new IsInCheck(ievents.KingIsInCheck);
            EventIsFree -= new IsFree(ievents.KingIsFree);
            EventMovePiece -= new movePiece(ievents.UpdateBoard);
            EventInsufficientMaterial -= new InsufficientMaterialHandler(ievents.InsufficientMaterial);
        }

        #endregion

        #region IValidationEvents Members

        public void Promotion(bool color, string square, ref Pieces piece)
        {
            promotedPiece = piece;

            // See if the user of this control to do the promotion.
            if (EventPromote != null)
            {
                EventPromote(color, square, ref piece);
            }

            this.grdChessBoard.Dispatcher.BeginInvoke(new delPromotePieceEventHandler(this.PromotePiece), piece, square);
        }

        private void PromotePiece(Pieces piece, string notation)
        {
            if (!BoardSquares.ContainsKey(notation))
            {
                return;
            }

            BoardSquare sq = BoardSquares[notation];
            grdChessBoard.Children.Remove(sq.Viewbox);

            sq.Piece = piece;
            sq.Viewbox = Ap.BoardTheme.GetViewbox(piece);
            grdChessBoard.Children.Add(sq.Viewbox);
            Grid.SetColumn(sq.Viewbox, MapGridColumn(sq.Column));
            Grid.SetRow(sq.Viewbox, MapGridRow(sq.Row));
            Grid.SetZIndex(sq.Viewbox, 1);
        }

        public void KingIsMated()
        {
            //this.Game.InProgressMove.Flags.IsMated = true;

            //if (EventIsMated != null)
            //    EventIsMated();
        }

        public void KingIsStaleMated()
        {
            //this.Game.InProgressMove.Flags.IsStaleMated = true;
        }

        public void KingIsInCheck(bool isColor)
        {
            //this.Game.InProgressMove.Flags.IsInCheck = true;

            //if (EventIsInCheck != null)
            //    EventIsInCheck(IsColor);
        }

        public void KingIsFree()
        {
            if (EventIsFree != null)
                EventIsFree();
        }

        public void FinishedMove()
        {
            if (EventIsDone != null)
                EventIsDone();
        }

        /// <summary>
        /// Moves a piece simply based on a source and destination
        ///   square.  Normally when the validation engine has
        ///   updated it's internal position and now the graphics
        ///   need to be updated as well.
        /// </summary>
        /// <param name="FromSquare"></param>
        /// <param name="ToSquare"></param>
        public void UpdateBoard(Chess.Operation op, string FromSquare, string ToSquare, Move m)
        {
            BoardSquare from = null;
            BoardSquare to = null;
            if (FromSquare != null)
                from = BoardSquares[FromSquare];
            if (ToSquare != null)
                to = BoardSquares[ToSquare];

            // Draw the new background and images.
            switch (op)
            {
                case Chess.Operation.MOVE:
                    MovePieceBoxThreadSafe(from, to, false, m);
                    if (EventMovePiece != null)
                    {
                        EventMovePiece(Chess.Operation.MOVE, FromSquare, ToSquare, m);
                    }
                    break;
                case Chess.Operation.DELETE:
                    //grdChessBoard.Children.Remove(from.Viewbox);
                    //from.Piece = Pieces.NONE;
                    //from.Viewbox = new Viewbox();
                    //BoardSquares[from.Name] = from;

                    RemovePieceBoxThreadSafe(from);
                    break;
            }
        }

        public void InsufficientMaterial()
        {
            
        }

        #endregion

        #region IPositionEvents Members

        public void placePiece(Pieces piece, int square)
        {
            int col = square % 8;
            int row = square / 8;
            AddFenPiece(row, col);
            this.grdChessBoard.Dispatcher.BeginInvoke(new PlacePieceEventHandler(this.PlacePieceInvoked), piece, square);
        }

        #region Place Piece Helper Methods

        private void PlacePieceInvoked(Pieces piece, int square)
        {
            int col = square % 8;
            int row = square / 8;
            PlacePiece(row, col, piece);
        }

        private void PlacePiece(int row, int col, Pieces piece)
        {
            string notation = Sqaure.GetNotation(col, row);
            if (!BoardSquares.ContainsKey(notation))
            {
                return;
            }

            BoardSquare sq = BoardSquares[notation];
            sq.Viewbox = Ap.BoardTheme.GetViewbox(piece);
            sq.Piece = piece;
            sq.Row = row + 1;
            sq.Column = col + 1;

            grdChessBoard.Children.Add(sq.Viewbox);
            Grid.SetColumn(sq.Viewbox, MapGridColumn(sq.Column));
            Grid.SetRow(sq.Viewbox, MapGridRow(sq.Row));
            Grid.SetZIndex(sq.Viewbox, 1);

            RemoveFenPiece(row, col);
        }

        private void AddFenPiece(int row, int col)
        {
            if (fenPieces == null)
            {
                fenPieces = new List<string>();
            }
            string notation = Sqaure.GetNotation(col, row);
            fenPieces.Add(notation);
        }

        private void RemoveFenPiece(int row, int col)
        {
            string notation = Sqaure.GetNotation(col, row);
            fenPieces.Remove(notation);

            if (fenPieces.Count == 0)
            {
                DoPostFenActions();
            }
        }

        #endregion

        public void setColor(bool bColor)
        {
            // Does nothing currently, just to satisfy the compiler.
        }

        public void setCastling(bool WK, bool WQ, bool BK, bool BQ)
        {
            // Does nothing currently, just to satisfy the compiler.
        }

        public void finished()
        {
            // Does nothing currently, just to satisfy the compiler.
        }

        #endregion

        #region IGameUc Members

        public void NewGame()
        {
            fenList = new List<string>();
            promotedPiece = Pieces.NONE;
            fenNotation = "";

            this.Game.MoveValidator.NewGame();
            BitboardSquare.NewGame();
            this.grdChessBoard.Dispatcher.BeginInvoke(new InitBoardHandler(this.InitBoardInvoked));

            SetEvents();
        }

        private void InitTextBlock()
        {
            tb = new TextBlock();
            grdChessBoard.Children.Add(tb);
            Grid.SetColumn(tb, 4);
            Grid.SetRow(tb, 4);
            Grid.SetZIndex(tb, 2);
            tb.FontSize = 6;
            tb.Text = "";
        }

        private void SetText(Point start, Point end)
        {
            tb.Text = start.X.ToString("0") + "," + start.Y.ToString("0") + " : " + end.X.ToString("0") + "," + end.Y.ToString("0");
        }

        public void Init()
        {
            BoardSquares = new Dictionary<string, BoardSquare>();
            System.Windows.Forms.Control parent = null;

            //this.Game.MoveReceived += new UCIEngine.MoveReceivedHandler(Game_MoveReceived);
            this.Game.MoveValidator = new MoveValidator(parent, this.Game);    //Window.GetWindow(this)
            this.Game.MoveValidator.addEvents(this);

            this.Game.FenParser = new FenParser(this.Game);
            this.Game.FenParser.addEvents(this);
            this.Game.FenParser.addEvents(this.Game.MoveValidator);
            this.Game.AfterAddMove += new EventHandler(Game_AfterAddMove);            

            this.Loaded += new RoutedEventHandler(ChessBoardUc_Loaded);

            grdChessBoard.MouseLeftButtonDown += new MouseButtonEventHandler(grdChessBoard_MouseLeftButtonDown);
            grdChessBoard.MouseLeftButtonUp += new MouseButtonEventHandler(grdChessBoard_MouseLeftButtonUp);
            grdChessBoard.MouseMove += new MouseEventHandler(grdChessBoard_MouseMove);
        }

        public void UnInit()
        {
            //this.Game.MoveReceived -= new UCIEngine.MoveReceivedHandler(Game_MoveReceived);
            this.Game.MoveValidator.removeEvents(this);
            this.Game.FenParser.removeEvents(this);
            this.Game.FenParser.removeEvents(this.Game.MoveValidator);
            this.Game.AfterAddMove -= new EventHandler(Game_AfterAddMove);

            this.Loaded -= new RoutedEventHandler(ChessBoardUc_Loaded);

            grdChessBoard.MouseLeftButtonDown -= new MouseButtonEventHandler(grdChessBoard_MouseLeftButtonDown);
            grdChessBoard.MouseLeftButtonUp -= new MouseButtonEventHandler(grdChessBoard_MouseLeftButtonUp);
            grdChessBoard.MouseMove -= new MouseEventHandler(grdChessBoard_MouseMove);

            if (Game.Player1.Engine != null)
            {
                Game.Player1.Engine.MoveReceived -= new UCIEngine.MoveReceivedHandler(_player1_EngineMoveReceived);
            }
            if (Game.Player1.Book != null)
            {
                Game.Player1.Book.MoveReceived -= new UCIEngine.MoveReceivedHandler(player_BookMoveReceived);
            }
            if (Game.Player2.Engine != null)
            {
                Game.Player2.Engine.MoveReceived -= new UCIEngine.MoveReceivedHandler(_player2_EngineMoveReceived);
            }
            if (Game.Player2.Book != null)
            {
                Game.Player2.Book.MoveReceived -= new UCIEngine.MoveReceivedHandler(player_BookMoveReceived);
            }
            //Game.Tablebases.EventMoveReceived -= new UCIEngine.MoveReceivedHandler(Tablebases_EventMoveReceived);
        }

        #endregion

        #region Game Events 

        void Game_AfterAddMove(object sender, EventArgs e)
        {
            try
            {
                if (BoardSquares == null || BoardSquares.Count == 0 || Game.CurrentMove == null)
                {
                    return;
                }

                if (!BoardSquares.ContainsKey(Game.CurrentMove.From) || !BoardSquares.ContainsKey(Game.CurrentMove.To))
                {
                    return;
                }

                BoardSquare bsFrom = BoardSquares[Game.CurrentMove.From];
                BoardSquare bsTo = BoardSquares[Game.CurrentMove.To];

                DrawArrowThreadSafe(bsFrom, bsTo);
            }
            catch
            {

            }
        }

        #endregion
    }

    public class MoveItem
    {
        public string From;
        public string To;
        public MoveByE MoveBy;

        public MoveItem()
        {

        }

        public static MoveItem NewItem(string from, string to, MoveByE moveBy)
        {
            MoveItem mi = new MoveItem();
            mi.From = from;
            mi.To = to;
            mi.MoveBy = moveBy;

            return mi;
        }
    }
}
