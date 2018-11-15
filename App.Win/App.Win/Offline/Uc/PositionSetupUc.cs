using System;
using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ChessLibrary;
using App.Win;
using InfinityChess.WinForms;

namespace App.Win
{
    public partial class PositionSetupUc : UserControl
    {
        #region DataMembers

        public Game Game = null;
        public MainForm MainForm;

        public string Fen = "";

        string squaresImagesFilesPath;
        string piecesImagesFilesPath;
        string piecesImagesFilesPathSmall;

        Dictionary<string, Image> piecesImages;
        Dictionary<string, Image> piecesImagesSmall;
        Image squareLightImage;
        Image squareDarkImage;
        Image selectedPieceImage;
        Pieces selectedPiece;
        string[] files;
        string[] ranks;
        Dictionary<string, SquareItem> BoardSquares;

        bool mirrorVertical = false;
        bool mirrorHorizontal = false;

        #endregion

        #region Ctor
        public PositionSetupUc(Game game, MainForm mainForm)
        {
            InitializeComponent();
            this.Game = game;
            this.MainForm = mainForm;
            squaresImagesFilesPath = Ap.FolderSquaresImages;
            piecesImagesFilesPath = Ap.FolderPiecesImages;
            piecesImagesFilesPathSmall = Ap.FolderPiecesImagesSmall;

            files = new string[] { "a", "b", "c", "d", "e", "f", "g", "h" };
            ranks = new string[] { "1", "2", "3", "4", "5", "6", "7", "8" };

            LoadPositionSetup();
            LoadBoardFromFEN(FenParser.InitialBoardFen);
        }

        #endregion

        #region Delegates/Events
        public delegate void BoardFenSetHandler(object sender, EventArgs args);
        public event BoardFenSetHandler OnBoardFenSet;
        #endregion

        #region EventHandlers

        private void btnOK_Click(object sender, EventArgs e)
        {
            Fen = GetBoardFEN();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadFEN(FenParser.InitialBoardFen);
            ValidateFen();
            Fen = FenParser.InitialBoardFen;
            if (OnBoardFenSet != null)
            {
                OnBoardFenSet(this, null);
            }
        }
             
        private void btnCopyBoard_Click(object sender, EventArgs e)
        {
            string fenNotation = this.MainForm.ChessBoardUc.GetFen();
            LoadBoardFromFEN(fenNotation);
            Fen = fenNotation;
            if (OnBoardFenSet != null)
            {
                OnBoardFenSet(this, null);
            }
        }

        void pieceImage_Click(object sender, EventArgs e)
        {
            UpdateThisPicture(sender, e);
        }

        #endregion

        #region Load/Position/Heplers Methods

        private void LoadBoardFromFEN(string fenNotation)
        {
            BoardSquares = new Dictionary<string, SquareItem>();
            LoadBoardSquares();
            LoadFEN(fenNotation);
        }

        private void LoadPositionSetup()
        {
            BoardSquares = new Dictionary<string, SquareItem>();
            LoadPiecesImages();
            LoadSidePieces();
        }

        private void LoadPiecesImages()
        {
            if (piecesImages == null)
            {
                piecesImages = new Dictionary<string, Image>();

                // white pieces
                piecesImages.Add(PiecesImagesFiles.white_rook, Image.FromFile(piecesImagesFilesPath + PiecesImagesFiles.white_rook));
                piecesImages.Add(PiecesImagesFiles.white_knight, Image.FromFile(piecesImagesFilesPath + PiecesImagesFiles.white_knight));
                piecesImages.Add(PiecesImagesFiles.white_bishop, Image.FromFile(piecesImagesFilesPath + PiecesImagesFiles.white_bishop));
                piecesImages.Add(PiecesImagesFiles.white_queen, Image.FromFile(piecesImagesFilesPath + PiecesImagesFiles.white_queen));
                piecesImages.Add(PiecesImagesFiles.white_king, Image.FromFile(piecesImagesFilesPath + PiecesImagesFiles.white_king));
                piecesImages.Add(PiecesImagesFiles.white_pawn, Image.FromFile(piecesImagesFilesPath + PiecesImagesFiles.white_pawn));

                // black pieces
                piecesImages.Add(PiecesImagesFiles.black_rook, Image.FromFile(piecesImagesFilesPath + PiecesImagesFiles.black_rook));
                piecesImages.Add(PiecesImagesFiles.black_knight, Image.FromFile(piecesImagesFilesPath + PiecesImagesFiles.black_knight));
                piecesImages.Add(PiecesImagesFiles.black_bishop, Image.FromFile(piecesImagesFilesPath + PiecesImagesFiles.black_bishop));
                piecesImages.Add(PiecesImagesFiles.black_queen, Image.FromFile(piecesImagesFilesPath + PiecesImagesFiles.black_queen));
                piecesImages.Add(PiecesImagesFiles.black_king, Image.FromFile(piecesImagesFilesPath + PiecesImagesFiles.black_king));
                piecesImages.Add(PiecesImagesFiles.black_pawn, Image.FromFile(piecesImagesFilesPath + PiecesImagesFiles.black_pawn));
            }
            if (piecesImagesSmall == null)
            {
                piecesImagesSmall = new Dictionary<string, Image>();

                // white pieces
                piecesImagesSmall.Add(PiecesImagesFiles.white_rook, Image.FromFile(piecesImagesFilesPathSmall + PiecesImagesFiles.white_rook));
                piecesImagesSmall.Add(PiecesImagesFiles.white_knight, Image.FromFile(piecesImagesFilesPathSmall + PiecesImagesFiles.white_knight));
                piecesImagesSmall.Add(PiecesImagesFiles.white_bishop, Image.FromFile(piecesImagesFilesPathSmall + PiecesImagesFiles.white_bishop));
                piecesImagesSmall.Add(PiecesImagesFiles.white_queen, Image.FromFile(piecesImagesFilesPathSmall + PiecesImagesFiles.white_queen));
                piecesImagesSmall.Add(PiecesImagesFiles.white_king, Image.FromFile(piecesImagesFilesPathSmall + PiecesImagesFiles.white_king));
                piecesImagesSmall.Add(PiecesImagesFiles.white_pawn, Image.FromFile(piecesImagesFilesPathSmall + PiecesImagesFiles.white_pawn));

                // black pieces
                piecesImagesSmall.Add(PiecesImagesFiles.black_rook, Image.FromFile(piecesImagesFilesPathSmall + PiecesImagesFiles.black_rook));
                piecesImagesSmall.Add(PiecesImagesFiles.black_knight, Image.FromFile(piecesImagesFilesPathSmall + PiecesImagesFiles.black_knight));
                piecesImagesSmall.Add(PiecesImagesFiles.black_bishop, Image.FromFile(piecesImagesFilesPathSmall + PiecesImagesFiles.black_bishop));
                piecesImagesSmall.Add(PiecesImagesFiles.black_queen, Image.FromFile(piecesImagesFilesPathSmall + PiecesImagesFiles.black_queen));
                piecesImagesSmall.Add(PiecesImagesFiles.black_king, Image.FromFile(piecesImagesFilesPathSmall + PiecesImagesFiles.black_king));
                piecesImagesSmall.Add(PiecesImagesFiles.black_pawn, Image.FromFile(piecesImagesFilesPathSmall + PiecesImagesFiles.black_pawn));
            }

            // also load squares images
            squareLightImage = Image.FromFile(squaresImagesFilesPath + "brown_light.jpg");
            squareDarkImage = Image.FromFile(squaresImagesFilesPath + "brown_dark.jpg");
        }

        private void LoadBoardSquares()
        {
            pnlBoard.Controls.Clear();

            int squareHeight = 60;
            int squareWidth = 60;

            Rectangle squareRectangle;
            SquareItem boardSquare;
            string notation;
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    notation = mapcol[col].ToString() + maprow[7 - row].ToString();
                    if (BoardSquares.ContainsKey(notation))
                    {
                        boardSquare = BoardSquares[notation];
                        boardSquare.Row = row + 1;
                        boardSquare.Column = col + 1;

                        PictureBox pieceImage = boardSquare.PictureBox;
                        pieceImage.Name = notation;
                        pieceImage.BackgroundImage = GetSquareImage(row, col);
                        pieceImage.Height = squareHeight;
                        pieceImage.Width = squareWidth;
                        pieceImage.Top = row * squareHeight;
                        pieceImage.Left = col * squareWidth;

                        squareRectangle = new Rectangle(pieceImage.Left, pieceImage.Top, pieceImage.Width, pieceImage.Height);
                        boardSquare.Rectangle = squareRectangle;

                        if (pnlBoard.Controls.Contains(pieceImage))
                        {
                            pnlBoard.Controls.Remove(pieceImage);
                        }
                    }
                    else
                    {
                        boardSquare = new SquareItem();
                        boardSquare.Name = notation;
                        boardSquare.Row = row + 1;
                        boardSquare.Column = col + 1;
                        boardSquare.BackgroundImage = GetSquareImage(row, col);
                        BoardSquares.Add(notation, boardSquare);

                        PictureBox pieceImage = new PictureBox();
                        pieceImage.Name = notation;
                        pieceImage.BackgroundImage = GetSquareImage(row, col);
                        pieceImage.Height = squareHeight;
                        pieceImage.Width = squareWidth;
                        pieceImage.Top = row * squareHeight;
                        pieceImage.Left = col * squareWidth;
                        pieceImage.Click += new EventHandler(pieceImage_Click);
                        pieceImage.Tag = boardSquare;

                        boardSquare.PictureBox = pieceImage;

                        pnlBoard.Controls.Add(pieceImage);
                    }
                }
            }
        }

        private void RemovePieces()
        {
            foreach (SquareItem s in BoardSquares.Values)
            {
                if (s.Piece != Pieces.NONE)
                {
                    s.PictureBox.Image = null;
                    s.Piece = Pieces.NONE;
                }
            }
        }

        private void UpdateThisPicture(object sender, EventArgs e)
        {
            if (selectedPiece != Pieces.NONE)
            {
                PictureBox squarePicture = (PictureBox)sender;
                if (squarePicture != null)
                {
                    SquareItem squareItem = squarePicture.Tag as SquareItem;
                    if (squareItem != null)
                    {
                        if (squareItem.Piece == selectedPiece)
                        {
                            squareItem.Piece = Pieces.NONE;
                            squarePicture.Image = null;
                        }
                        else
                        {
                            squareItem.Piece = selectedPiece;
                            squarePicture.Image = GetImageByPiece(squareItem.Piece);
                        }
                        SetupCastlingControls();
                        Fen = GetBoardFEN();
                        if (OnBoardFenSet != null)
                        {
                            OnBoardFenSet(this, null);
                        }
                        //ValidateFen();
                        
                    }
                }
            }
        }

        private Image GetImageByPiece(Pieces piece)
        {
            Image squareImage = null;
            switch (piece)
            {
                case Pieces.NONE:
                    {
                        squareImage = null;
                        break;
                    }
                case Pieces.WKING:
                    {
                        squareImage = piecesImages[PiecesImagesFiles.white_king];
                        break;
                    }
                case Pieces.WQUEEN:
                    {
                        squareImage = piecesImages[PiecesImagesFiles.white_queen];
                        break;
                    }
                case Pieces.WROOK:
                    {
                        squareImage = piecesImages[PiecesImagesFiles.white_rook];
                        break;
                    }
                case Pieces.WBISHOP:
                    {
                        squareImage = piecesImages[PiecesImagesFiles.white_bishop];
                        break;
                    }
                case Pieces.WKNIGHT:
                    {
                        squareImage = piecesImages[PiecesImagesFiles.white_knight];
                        break;
                    }
                case Pieces.WPAWN:
                    {
                        squareImage = piecesImages[PiecesImagesFiles.white_pawn];
                        break;
                    }
                case Pieces.BKING:
                    {
                        squareImage = piecesImages[PiecesImagesFiles.black_king];
                        break;
                    }
                case Pieces.BQUEEN:
                    {
                        squareImage = piecesImages[PiecesImagesFiles.black_queen];
                        break;
                    }
                case Pieces.BROOK:
                    {
                        squareImage = piecesImages[PiecesImagesFiles.black_rook];
                        break;
                    }
                case Pieces.BBISHOP:
                    {
                        squareImage = piecesImages[PiecesImagesFiles.black_bishop];
                        break;
                    }
                case Pieces.BKNIGHT:
                    {
                        squareImage = piecesImages[PiecesImagesFiles.black_knight];
                        break;
                    }
                case Pieces.BPAWN:
                    {
                        squareImage = piecesImages[PiecesImagesFiles.black_pawn];
                        break;
                    }
                default:
                    {
                        squareImage = null;
                        break;
                    }
            }
            return squareImage;
        }

        private void LoadSidePieces()
        {
            if (piecesImages != null)
            {
                // white pieces
                pbWhiteRook.BackgroundImage = squareLightImage;
                pbWhiteRook.Image = piecesImages[PiecesImagesFiles.white_rook];

                pbWhiteKnight.BackgroundImage = squareLightImage;
                pbWhiteKnight.Image = piecesImages[PiecesImagesFiles.white_knight];

                pbWhiteBishop.BackgroundImage = squareLightImage;
                pbWhiteBishop.Image = piecesImages[PiecesImagesFiles.white_bishop];

                pbWhiteQueen.BackgroundImage = squareLightImage;
                pbWhiteQueen.Image = piecesImages[PiecesImagesFiles.white_queen];

                pbWhiteKing.BackgroundImage = squareLightImage;
                pbWhiteKing.Image = piecesImages[PiecesImagesFiles.white_king];

                pbWhitePawn.BackgroundImage = squareLightImage;
                pbWhitePawn.Image = piecesImages[PiecesImagesFiles.white_pawn];

                // black pieces
                pbBlackRook.BackgroundImage = squareLightImage;
                pbBlackRook.Image = piecesImages[PiecesImagesFiles.black_rook];

                pbBlackKnight.BackgroundImage = squareLightImage;
                pbBlackKnight.Image = piecesImages[PiecesImagesFiles.black_knight];

                pbBlackBishop.BackgroundImage = squareLightImage;
                pbBlackBishop.Image = piecesImages[PiecesImagesFiles.black_bishop];

                pbBlackQueen.BackgroundImage = squareLightImage;
                pbBlackQueen.Image = piecesImages[PiecesImagesFiles.black_queen];

                pbBlackKing.BackgroundImage = squareLightImage;
                pbBlackKing.Image = piecesImages[PiecesImagesFiles.black_king];

                pbBlackPawn.BackgroundImage = squareLightImage;
                pbBlackPawn.Image = piecesImages[PiecesImagesFiles.black_pawn];
            }
        }

        private Image GetSquareImage(int row, int column)
        {
            Image squareImage = null;
            if (row % 2 == 0 && column % 2 == 0)
            {
                squareImage = squareLightImage;
            }
            else if (row % 2 == 0 && column % 2 != 0)
            {
                squareImage = squareDarkImage;
            }
            else if (row % 2 != 0 && column % 2 != 0)
            {
                squareImage = squareLightImage;
            }
            else if (row % 2 != 0 && column % 2 == 0)
            {
                squareImage = squareDarkImage;
            }
            return squareImage;
        }

        private void SetMouseCursorToSelectedPieceImage()
        {
            Bitmap b = new Bitmap(selectedPieceImage);
            Cursor c = new Cursor(b.GetHicon());
            pnlBoard.Cursor = c;
        }

        private void SetupCastlingControls()
        {

            SquareItem whiteKing = BoardSquares["e1"];
            SquareItem whiteKingRook = BoardSquares["h1"];
            SquareItem whiteQueenRook = BoardSquares["a1"];

            SquareItem blackKing = BoardSquares["e8"];
            SquareItem blackKingRook = BoardSquares["h8"];
            SquareItem blackQueenRook = BoardSquares["a8"];


        }

        private int MapBoardRow(int row)
        {
            int boardRow = -1;
            if (mirrorVertical)
            {
                boardRow = 9 - row;
            }
            else
            {
                boardRow = row;
            }
            return boardRow;
        }

        private int MapBoardColumn(int column)
        {
            int boardColumn = -1;
            if (mirrorHorizontal)
            {
                boardColumn = 9 - column;
            }
            else
            {
                boardColumn = column;
            }
            return boardColumn;
        }

        private void MirroHorizontal()
        {
            foreach (SquareItem s in BoardSquares.Values)
            {
                if (s.Column <= 4)
                {
                    SquareItem thisSquare = s.Copy();
                    int newRow = thisSquare.Row; //MapBoardRow(thisSquare.Row);
                    int newColumn = MapBoardColumn(thisSquare.Column);
                    SquareItem mirroredSquare = GetSquareItem(newRow, newColumn);

                    thisSquare.Piece = mirroredSquare.Piece;
                    thisSquare.PictureBox.Image = mirroredSquare.PictureBox.Image;

                    mirroredSquare.Piece = s.Piece;
                    mirroredSquare.PictureBox.Image = GetImageByPiece(s.Piece);


                    s.Piece = thisSquare.Piece;
                    s.PictureBox.Image = thisSquare.PictureBox.Image;
                }
            }
        }

        private SquareItem GetSquareItem(int row, int col)
        {
            SquareItem item = null;
            foreach (SquareItem s in BoardSquares.Values)
            {
                if (s.Row == row && s.Column == col)
                {
                    item = s;
                    break;
                }
            }
            return item;
        }

        private void MirroVertical()
        {
            foreach (SquareItem s in BoardSquares.Values)
            {
                if (s.Row <= 4)
                {
                    SquareItem thisSquare = s.Copy();
                    int newRow = MapBoardRow(thisSquare.Row);
                    int newColumn = thisSquare.Column; //MapBoardColumn(thisSquare.Column);
                    SquareItem mirroredSquare = GetSquareItem(newRow, newColumn);

                    thisSquare.Piece = GetOppositeSidePiece(mirroredSquare.Piece);
                    thisSquare.PictureBox.Image = GetImageByPiece(thisSquare.Piece);

                    mirroredSquare.Piece = GetOppositeSidePiece(s.Piece);
                    mirroredSquare.PictureBox.Image = GetImageByPiece(mirroredSquare.Piece);

                    s.Piece = thisSquare.Piece;
                    s.PictureBox.Image = thisSquare.PictureBox.Image;
                }
            }
        }

        private Pieces GetOppositeSidePiece(Pieces piece)
        {
            Pieces oppositePiece = Pieces.NONE;
            switch (piece)
            {
                case Pieces.WKING:
                    oppositePiece = Pieces.BKING;
                    break;
                case Pieces.WQUEEN:
                    oppositePiece = Pieces.BQUEEN;
                    break;
                case Pieces.WROOK:
                    oppositePiece = Pieces.BROOK;
                    break;
                case Pieces.WBISHOP:
                    oppositePiece = Pieces.BBISHOP;
                    break;
                case Pieces.WKNIGHT:
                    oppositePiece = Pieces.BKNIGHT;
                    break;
                case Pieces.WPAWN:
                    oppositePiece = Pieces.BPAWN;
                    break;
                case Pieces.BKING:
                    oppositePiece = Pieces.WKING;
                    break;
                case Pieces.BQUEEN:
                    oppositePiece = Pieces.WQUEEN;
                    break;
                case Pieces.BROOK:
                    oppositePiece = Pieces.WROOK;
                    break;
                case Pieces.BBISHOP:
                    oppositePiece = Pieces.WBISHOP;
                    break;
                case Pieces.BKNIGHT:
                    oppositePiece = Pieces.WKNIGHT;
                    break;
                case Pieces.BPAWN:
                    oppositePiece = Pieces.WPAWN;
                    break;
                default:
                    break;
            }
            return oppositePiece;
        }


        #endregion

        #region Side Pieces Images Events

        private void pbWhiteKing_Click(object sender, EventArgs e)
        {
            selectedPieceImage = piecesImagesSmall[PiecesImagesFiles.white_king];
            selectedPiece = Pieces.WKING;

            SetMouseCursorToSelectedPieceImage();
        }

        private void pbWhiteQueen_Click(object sender, EventArgs e)
        {
            selectedPieceImage = piecesImagesSmall[PiecesImagesFiles.white_queen];
            selectedPiece = Pieces.WQUEEN;

            SetMouseCursorToSelectedPieceImage();
        }

        private void pbWhiteKnight_Click(object sender, EventArgs e)
        {
            selectedPieceImage = piecesImagesSmall[PiecesImagesFiles.white_knight];
            selectedPiece = Pieces.WKNIGHT;

            SetMouseCursorToSelectedPieceImage();
        }

        private void pbWhiteBishop_Click(object sender, EventArgs e)
        {
            selectedPieceImage = piecesImagesSmall[PiecesImagesFiles.white_bishop];
            selectedPiece = Pieces.WBISHOP;

            SetMouseCursorToSelectedPieceImage();
        }

        private void pbWhiteRook_Click(object sender, EventArgs e)
        {
            selectedPieceImage = piecesImagesSmall[PiecesImagesFiles.white_rook];
            selectedPiece = Pieces.WROOK;

            SetMouseCursorToSelectedPieceImage();
        }

        private void pbWhitePawn_Click(object sender, EventArgs e)
        {
            selectedPieceImage = piecesImagesSmall[PiecesImagesFiles.white_pawn];
            selectedPiece = Pieces.WPAWN;

            SetMouseCursorToSelectedPieceImage();
        }

        private void pbBlackKing_Click(object sender, EventArgs e)
        {
            selectedPieceImage = piecesImagesSmall[PiecesImagesFiles.black_king];
            selectedPiece = Pieces.BKING;

            SetMouseCursorToSelectedPieceImage();
        }

        private void pbBlackQueen_Click(object sender, EventArgs e)
        {
            selectedPieceImage = piecesImagesSmall[PiecesImagesFiles.black_queen];
            selectedPiece = Pieces.BQUEEN;

            SetMouseCursorToSelectedPieceImage();
        }

        private void pbBlackKnight_Click(object sender, EventArgs e)
        {
            selectedPieceImage = piecesImagesSmall[PiecesImagesFiles.black_knight];
            selectedPiece = Pieces.BKNIGHT;

            SetMouseCursorToSelectedPieceImage();
        }

        private void pbBlackBishop_Click(object sender, EventArgs e)
        {
            selectedPieceImage = piecesImagesSmall[PiecesImagesFiles.black_bishop];
            selectedPiece = Pieces.BBISHOP;

            SetMouseCursorToSelectedPieceImage();
        }

        private void pbBlackRook_Click(object sender, EventArgs e)
        {
            selectedPieceImage = piecesImagesSmall[PiecesImagesFiles.black_rook];
            selectedPiece = Pieces.BROOK;

            SetMouseCursorToSelectedPieceImage();
        }

        private void pbBlackPawn_Click(object sender, EventArgs e)
        {
            selectedPieceImage = piecesImagesSmall[PiecesImagesFiles.black_pawn];
            selectedPiece = Pieces.BPAWN;

            SetMouseCursorToSelectedPieceImage();
        }

        #endregion

        #region Fen Helpers Methods

        public string GetCompleteFEN()
        {
            string completeFEN = string.Empty;
            string space = " ";
            completeFEN += GetBoardFEN();
            completeFEN += space;

            // if (rdbWhiteToMove.Checked)
            completeFEN += "w";
            // if (rdbBlackToMove.Checked)
            //     completeFEN += "b";

            completeFEN += space;

            string castlingNotation = string.Empty;
            //castlingNotation += "K";
            //castlingNotation += "Q";
            //castlingNotation += "k";
            //castlingNotation += "q";

            if (string.IsNullOrEmpty(castlingNotation))
                completeFEN += "-";
            else
                completeFEN += castlingNotation;

            completeFEN += space;

            completeFEN += GetEnPassantSquare();

            completeFEN += space;
            completeFEN += "0";
            completeFEN += space;
            completeFEN += 1;// numMoveNumber.Value.ToString();

            return completeFEN;
        }

        char[] mapcol = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
        char[] maprow = { '1', '2', '3', '4', '5', '6', '7', '8' };

        public string GetBoardFEN()
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
                    string notation = mapcol[col].ToString() + maprow[row].ToString();
                    //SquareItem squareItem = GetSquareItem(row, col);
                    SquareItem squareItem = BoardSquares[notation];
                    switch (squareItem.Piece)
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
                            switch (squareItem.Piece)
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

        public void LoadFEN(string fenNotation)
        {
            RemovePieces();

            int ndx = 56;
            int cnt = 0;
            string[] note = fenNotation.Split(' ');

            // 16.1.3.1: Parse piece placement data
            string[] row = note[0].Split('/');
            if (row.Length != 8)
                throw new ArgumentException("Invalid board specification, " + row.Length + " ranks are defined, there should be 8.");

            coBoard = new StringBuilder(64, 64);
            int rowNumber = 0;
            int columnNumber = 0;
            foreach (string line in row)
            {
                columnNumber = 0;
                cnt = 0;
                foreach (char achar in line)
                {
                    if (achar >= '0' && achar <= '9')
                    {
                        cnt += (int)(achar - '0');
                        columnNumber += (int)(achar - '0');
                    }
                    else
                    {
                        Pieces currentPiece = Board.PieceFromChar(achar);
                        if (currentPiece != Pieces.NONE)
                        {
                            if (cnt > 7)  //This check needed here to avoid overrunning index below under some error conditions.
                                throw new ArgumentException("Invalid board specification, rank " + (ndx / 8 + 1) + " has more then 8 items specified.");
                            PlacePiece(ndx + cnt, currentPiece);
                            coBoard.Append(achar);
                        }
                        cnt++;
                        columnNumber++;
                    }
                }
                rowNumber++;
                if (cnt == 0) // Allow null lines = /8/
                    cnt += 8;

                if (cnt != 8)
                    throw new ArgumentException("Invalid board specification, rank " + (ndx / 8 + 1) + " has " + cnt + " items specified, there should be 8.");

                ndx -= 8;
            }

            if (note.Length >= 2)
            {
                // 16.1.3.2: Parse active color
                if (note[1].Length > 0)
                {
                    char colorchar = Char.ToLower(note[1][0]);
                }
            }

            // 16.1.3.3: Parse castling availability
            bool WK = false;
            bool WQ = false;
            bool BK = false;
            bool BQ = false;

            if (note.Length >= 3)
            {
                foreach (char achar in note[2])
                {
                    switch (achar)
                    {
                        case 'K':
                            WK = true;
                            break;
                        case 'Q':
                            WQ = true;
                            break;
                        case 'k':
                            BK = true;
                            break;
                        case 'q':
                            BQ = true;
                            break;
                        case '-':
                            break;
                        default:
                            throw new Exception("Invalid castle privileges designation, use: KQkq or -");
                    }
                }
            }

            try
            {
                if (note.Length >= 4)
                {
                    // 16.1.3.4: Parse en passant target square such as "e3"
                    coEnPassant = note[3];
                    if (coEnPassant.Length == 2)
                    {
                        coEnPassant = coEnPassant.Substring(0, 1);
                    }
                }

                if (note.Length >= 5)
                {
                    // 16.1.3.5: Parse halfmove clock, count of half-move since last pawn advance or unit capture
                    coHalfMove = Int16.Parse(note[4]);
                }

                if (note.Length >= 6)
                {
                    // 16.1.3.6: Parse fullmove number, increment after each black move
                    coFullMove = Int16.Parse(note[5]);
                    //numMoveNumber.Value = coFullMove;
                }

            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
            }
        }

        private void PlacePiece(int square, Pieces piece)
        {
            int col = square % 8;
            int row = square / 8;

            string notation = mapcol[col].ToString() + maprow[row].ToString();
            if (BoardSquares.ContainsKey(notation))
            {
                SquareItem boardSquare = BoardSquares[notation];
                boardSquare.PictureBox.Image = GetImageByPiece(piece);
                boardSquare.Piece = piece;
            }          
        }

        private void ValidateFen()
        {
            string fenNotation = GetCompleteFEN();
            try
            {
                bool isValid = this.Game.GameValidator.IsValidFen(fenNotation);
            }
            catch(Exception ex) 
            {
                TestDebugger.Instance.WriteError(ex);
            }
        }

        #endregion

        #region Fen Helpers DataMembers

        private StringBuilder coBoard;
        public char this[int ndx]
        {
            get { return coBoard[ndx]; }
            set
            {
                string str = "KQRBNPkqrbnp";
                if (str.IndexOf(value) >= 0)
                    coBoard[ndx] = value;
                else
                    throw new Exception("Invalid piece value (" + value + ") use one of: " + str);
            }
        }

        public string Enpassant
        {
            get { return coEnPassant; }
            set { coEnPassant = value; }
        }
        private string coEnPassant;

        public int HalfMoves
        {
            get { return coHalfMove; }
            set { coHalfMove = value; }
        }
        private int coHalfMove;

        public int FullMoves
        {
            get { return coFullMove; }
            set { coFullMove = value; }
        }
        private int coFullMove;

        #endregion

        #region Castling Checkboxes Events

        private void chkWhiteCastlingShort_Click(object sender, EventArgs e)
        {
            SetupCastlingControls();
        }

        private void chkWhiteCastlingLong_Click(object sender, EventArgs e)
        {
            SetupCastlingControls();
        }

        private void chkBlackCastlingShort_Click(object sender, EventArgs e)
        {
            SetupCastlingControls();
        }

        private void chkBlackCastlingLong_Click(object sender, EventArgs e)
        {
            SetupCastlingControls();
        }

        #endregion

        #region Enpassant Move

        private string GetEnPassantSquare()
        {
            string enpassant = "-";
            //if (string.IsNullOrEmpty(txtEnpassant.Text.Trim()))
            //{
            //    return enpassant;
            //}

            //char fileChar = Convert.ToChar(txtEnpassant.Text);

            //if ((fileChar >= 65 && fileChar <= 72) || (fileChar >= 97 && fileChar <= 104)) // check for characters ['A' to 'H']  or ['a' to 'h']
            //{
            //    int pawnRank = 0;
            //    int enpassantRank = 0;

            //    if (rdbWhiteToMove.Checked)
            //    {
            //        pawnRank = 5;           // black pawn placed
            //        enpassantRank = 6;      // black pawn enpassant
            //        enpassant = GetEnpassantSquare(fileChar, pawnRank, enpassantRank, false);
            //    }
            //    else if (rdbBlackToMove.Checked)
            //    {
            //        pawnRank = 4;           // white pawn placed
            //        enpassantRank = 3;      // white pawn enpassant
            //        enpassant = GetEnpassantSquare(fileChar, pawnRank, enpassantRank, true);
            //    }
            //}

            return enpassant;
        }

        private string GetEnpassantSquare(char file, int pawnRank, int enpassantRank, bool isWhitePawn)
        {
            string enpassant = "-";
            string pawnSquare = file + pawnRank.ToString();
            string enpassantSquare = file + enpassantRank.ToString();

            string rightSquare = GetRightFile(file.ToString());
            string leftSquare = GetLeftFile(file.ToString());

            bool isPawnPlaced = IsPawnPlaced(isWhitePawn, pawnSquare);
            bool isOpponentPawnOnRight = false;
            bool isOpponentPawnOnLeft = false;

            if (!string.IsNullOrEmpty(rightSquare))
            {
                isOpponentPawnOnRight = IsPawnPlaced(!isWhitePawn, rightSquare + pawnRank);
            }
            if (!string.IsNullOrEmpty(leftSquare))
            {
                isOpponentPawnOnLeft = IsPawnPlaced(!isWhitePawn, leftSquare + pawnRank);
            }

            if (isPawnPlaced && (isOpponentPawnOnRight || isOpponentPawnOnLeft))
            {
                enpassant = enpassantSquare;
            }
            return enpassant;
        }

        private bool IsPawnPlaced(bool isWhite, string square)
        {
            bool pawnPlaced = false;
            Pieces piece = isWhite == true ? Pieces.WPAWN : Pieces.BPAWN;
            if (!string.IsNullOrEmpty(square) && BoardSquares[square].Piece == piece)
            {
                pawnPlaced = true;
            }
            return pawnPlaced;
        }

        private string GetRightFile(string currentFile)
        {
            string file = string.Empty;
            switch (currentFile)
            {
                case "a":
                    file = "b";
                    break;
                case "b":
                    file = "c";
                    break;
                case "c":
                    file = "d";
                    break;
                case "d":
                    file = "e";
                    break;
                case "e":
                    file = "f";
                    break;
                case "f":
                    file = "g";
                    break;
                case "g":
                    file = "h";
                    break;
                case "h":
                    file = "";
                    break;
                default:
                    file = "";
                    break;
            }
            return file;
        }

        private string GetLeftFile(string currentFile)
        {
            string file = string.Empty;
            switch (currentFile)
            {
                case "a":
                    file = "";
                    break;
                case "b":
                    file = "a";
                    break;
                case "c":
                    file = "b";
                    break;
                case "d":
                    file = "c";
                    break;
                case "e":
                    file = "d";
                    break;
                case "f":
                    file = "e";
                    break;
                case "g":
                    file = "f";
                    break;
                case "h":
                    file = "g";
                    break;
                default:
                    file = "";
                    break;
            }
            return file;
        }

        #endregion
    }
}
