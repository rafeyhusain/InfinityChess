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
    #region enum
    public enum RankEnum
    {
        Rank1,
        Rank2,
        Rank3,
        Rank4,
        Rank5,
        Rank6,
        Rank7,
        Rank8,
        NoRank
    }

    public enum FileEnum
    {
	    FileA,
	    FileB,
	    FileC,
	    FileD,
	    FileE,
	    FileF,
	    FileG,
	    FileH,
	    NoFile
    }
    #endregion

    public partial class Board
    {
        #region Data Members
        public Game Game = null;
        public const string Rank = "r";
        public const string File = "f";
        public const string Piece = "p";

        public DataTable BoardData = null;
        string currentFen = string.Empty;

        static char[] mapcol = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
        static char[] maprow = { '1', '2', '3', '4', '5', '6', '7', '8' };

        #endregion

        #region Ctor

        public Board(Game game)
        {
            this.Game = game;
            SetupNewGame();
        }

        public void SetupNewGame()
        {
            BoardData = GetBoardDataTable();
            
            Init();
        }


        /*
         * r = RankEnum. 
         * f = FileEnum. 
         * p = piece in square. i.e. Pieces
         */
        public static DataTable GetBoardDataTable()
        {
            return UData.ToTable2("BoardData", Board.Rank, Board.File, Board.Piece);
        }  
        #endregion

        #region InitBoard
        public void Init()
        {
            if (this.Game != null)
            {
                currentFen = this.Game.InitialBoardFen;
            }
            else
            {
                currentFen = ChessLibrary.FenParser.InitialBoardFen;
            }

            Init(currentFen);            
        }


        public void Init(string fen)
        {
            currentFen = fen;
            LoadBoardDataTable(currentFen);
        } 
        #endregion

        #region MovePiece

        public void MovePiece(string from, string to)
        {
            MovePiece(GetRank(from), GetFile(from), GetRank(to), GetFile(to));
        }

        public void MovePiece(RankEnum rankFrom, FileEnum fileFrom, RankEnum rankTo, FileEnum fileTo)
        {
            Pieces piece = GetPiece(rankFrom, fileFrom);

            SetPiece(rankFrom, fileFrom, Pieces.NONE);
            SetPiece(rankTo, fileTo, piece);
        } 

        #endregion

        #region GetPiece

        public Pieces GetPiece(string singleNotation)
        {
            return GetPiece(GetRank(singleNotation), GetFile(singleNotation)); 
        }
        
        public Pieces GetPiece(RankEnum rank, FileEnum file)
        {
            DataRow row = GetBoardDataRow(rank, file);

            return (Pieces) BaseItem.GetColInt32(row, Board.Piece);
        }

        #endregion
        
        #region GetPiece

        public void SetPiece(string singleNotation, Pieces piece)
        {
            SetPiece(GetRank(singleNotation), GetFile(singleNotation), piece);
        }

        public void SetPiece(RankEnum rank, FileEnum file, Pieces piece)
        {
            DataRow row = GetBoardDataRow(rank, file);

            if (row != null)
            {
                row[Board.Piece] = piece.ToString("d");
            }
        }

        #endregion

        #region Helper

        public FileEnum GetFile(string singleNotation)
        {
            FileEnum fileEnum = FileEnum.NoFile;
            string file = singleNotation.Substring(0, 1);
            switch (file)
            {
                case "a":
                    fileEnum = FileEnum.FileA;
                    break;
                case "b":
                    fileEnum = FileEnum.FileB;
                    break;
                case "c":
                    fileEnum = FileEnum.FileC;
                    break;
                case "d":
                    fileEnum = FileEnum.FileD;
                    break;
                case "e":   
                    fileEnum = FileEnum.FileE;
                    break;
                case "f":
                    fileEnum = FileEnum.FileF;
                    break;
                case "g":
                    fileEnum = FileEnum.FileG;
                    break;
                case "h":
                    fileEnum = FileEnum.FileH;
                    break;
                default:
                    fileEnum = FileEnum.NoFile;
                    break;
            }
            return fileEnum;
        }

        public RankEnum GetRank(string singleNotation)
        {
            RankEnum rankEnum = RankEnum.NoRank;
            string rank = singleNotation.Substring(1, 1);
            switch (rank)
            {
                case "1":
                    rankEnum = RankEnum.Rank1;
                    break;
                case "2":
                    rankEnum = RankEnum.Rank2;
                    break;
                case "3":
                    rankEnum = RankEnum.Rank3;
                    break;
                case "4":
                    rankEnum = RankEnum.Rank4;
                    break;
                case "5":
                    rankEnum = RankEnum.Rank5;
                    break;
                case "6":
                    rankEnum = RankEnum.Rank6;
                    break;
                case "7":
                    rankEnum = RankEnum.Rank7;
                    break;
                case "8":
                    rankEnum = RankEnum.Rank8;
                    break;
                default:
                    rankEnum = RankEnum.NoRank;
                    break;
            }
            return rankEnum;
        }

        public string GetFileString(FileEnum file)
        {
            string fileString = string.Empty;

            switch (file)
            {
                case FileEnum.FileA:
                    fileString = "a";
                    break;
                case FileEnum.FileB:
                    fileString = "b";
                    break;
                case FileEnum.FileC:
                    fileString = "c";
                    break;
                case FileEnum.FileD:
                    fileString = "d";
                    break;
                case FileEnum.FileE:
                    fileString = "e";
                    break;
                case FileEnum.FileF:
                    fileString = "f";
                    break;
                case FileEnum.FileG:
                    fileString = "g";
                    break;
                case FileEnum.FileH:
                    fileString = "h";
                    break;
                default:
                    break;
            }
           
            return fileString;
        }

        public string GetRankString(RankEnum rank)
        {
            string rankString = string.Empty;
            
            switch (rank)
            {
                case RankEnum.Rank1:
                    rankString = "1";
                    break;
                case RankEnum.Rank2:
                    rankString = "2";
                    break;
                case RankEnum.Rank3:
                    rankString = "3";
                    break;
                case RankEnum.Rank4:
                    rankString = "4";
                    break;
                case RankEnum.Rank5:
                    rankString = "5";
                    break;
                case RankEnum.Rank6:
                    rankString = "6";
                    break;
                case RankEnum.Rank7:
                    rankString = "7";
                    break;
                case RankEnum.Rank8:
                    rankString = "8";
                    break;
                default:
                    break;
            }

            return rankString;
        }
        
        private DataRow GetBoardDataRow(RankEnum rank, FileEnum file)
        {
            DataRow[] rows = BoardData.Select("r=" + rank.ToString("d") + " AND f=" + file.ToString("d"));

            if (rows.Length > 0)
                return rows[0];

            return null;
        }

        private void LoadBoardDataTable(string fen)
        {
            BoardData.Clear();
            int ndx = 56;
            int cnt = 0;
            string[] note = fen.Split(' ');

            // 16.1.3.1: Parse piece placement data
            string[] row = note[0].Split('/');
            if (row.Length != 8)
                throw new ArgumentException("Invalid board specification, " + row.Length + " ranks are defined, there should be 8.");

            string notation = string.Empty;
            int emptyItems = 0;
            foreach (string line in row)
            {
                cnt = 0;
                foreach (char achar in line)
                {
                    if (achar >= '0' && achar <= '9')
                    {
                        emptyItems = (int)(achar - '0');
                        //cnt += (int)(achar - '0');
                        for (int i = 1; i <= emptyItems; cnt++, i++)
                        {
                            if (cnt > 7)  //This check needed here to avoid overrunning index below under some error conditions.
                                throw new ArgumentException("Invalid board specification, rank " + (ndx / 8 + 1) + " has more than 8 items specified.");
                            notation = GetNotation(ndx + cnt);
                            AddBoardRow(notation, Pieces.NONE);
                        }
                    }
                    else
                    {
                        if (PieceFromChar(achar) != Pieces.NONE)
                        {
                            if (cnt > 7)  //This check needed here to avoid overrunning index below under some error conditions.
                                throw new ArgumentException("Invalid board specification, rank " + (ndx / 8 + 1) + " has more than 8 items specified.");
                            notation = GetNotation(ndx + cnt);
                            AddBoardRow(notation, PieceFromChar(achar));
                        }
                        cnt++;
                    }
                }

                if (cnt == 0) // Allow null lines = /8/
                    cnt += 8;

                if (cnt != 8)
                    throw new ArgumentException("Invalid board specification, rank " + (ndx / 8 + 1) + " has " + cnt + " items specified, there should be 8.");

                ndx -= 8;
            }
        }

        private void AddBoardRow(string singleNotation, Pieces piece)
        {
            DataRow dr = BoardData.NewRow();
            RankEnum rank = GetRank(singleNotation);
            FileEnum file = GetFile(singleNotation);

            dr["r"] = rank.ToString("d");
            dr["f"] = file.ToString("d");
            dr["p"] = piece.ToString("d");

            BoardData.Rows.Add(dr);
        }

        private string GetNotation(int square)
        {
            int col = square % 8;
            int row = square / 8;
            string notation = mapcol[col].ToString() + maprow[row].ToString();
            return notation;
        }

        public static string CharFromPiece2(Pieces piece)
        {
            string aPiece = "";
            switch (piece)
            {
                case Pieces.WKING:
                case Pieces.BKING:
                    aPiece = "K";
                    break;
                case Pieces.WQUEEN:
                case Pieces.BQUEEN:
                    aPiece = "Q";
                    break;
                case Pieces.WROOK:
                case Pieces.BROOK:
                    aPiece = "R";
                    break;
                case Pieces.WBISHOP:
                case Pieces.BBISHOP:
                    aPiece = "B";
                    break;
                case Pieces.WKNIGHT:
                case Pieces.BKNIGHT:
                    aPiece = "N";
                    break;
                case Pieces.WPAWN:
                case Pieces.BPAWN:
                    aPiece = ""; // NOTE PAWN is EMPTY
                    break;
            }
            return aPiece;
        }  

        public static Pieces PieceFromChar(char piece)
        {
            Pieces aPiece = Pieces.NONE;

            switch (piece)
            {
                case 'K':
                    aPiece = Pieces.WKING;
                    break;
                case 'Q':
                    aPiece = Pieces.WQUEEN;
                    break;
                case 'R':
                    aPiece = Pieces.WROOK;
                    break;
                case 'B':
                    aPiece = Pieces.WBISHOP;
                    break;
                case 'N':
                    aPiece = Pieces.WKNIGHT;
                    break;
                case 'P':
                    aPiece = Pieces.WPAWN;
                    break;
                case 'k':
                    aPiece = Pieces.BKING;
                    break;
                case 'q':
                    aPiece = Pieces.BQUEEN;
                    break;
                case 'r':
                    aPiece = Pieces.BROOK;
                    break;
                case 'b':
                    aPiece = Pieces.BBISHOP;
                    break;
                case 'n':
                    aPiece = Pieces.BKNIGHT;
                    break;
                case 'p':
                    aPiece = Pieces.BPAWN;
                    break;
            }
            return aPiece;
        }

        public static Pieces PieceFromString(string piece)
        {
            Pieces aPiece = Pieces.NONE;            

            aPiece = PieceFromChar(Convert.ToChar(piece));

            return aPiece;
        }

        public static char GetPieceChar(Pieces piece)
        {
            char aPiece = ' ';
            switch (piece)
            {
                case Pieces.WKING:
                    aPiece = 'K';
                    break;
                case Pieces.WQUEEN:
                    aPiece = 'Q';
                    break;
                case Pieces.WROOK:
                    aPiece = 'R';
                    break;
                case Pieces.WBISHOP:
                    aPiece = 'B';
                    break;
                case Pieces.WKNIGHT:
                    aPiece = 'N';
                    break;
                case Pieces.WPAWN:
                    aPiece = 'P';
                    break;

                case Pieces.BKING:
                    aPiece = 'k';
                    break;                
                case Pieces.BQUEEN:
                    aPiece = 'q';
                    break;
                case Pieces.BROOK:
                    aPiece = 'r';
                    break;
                case Pieces.BBISHOP:
                    aPiece = 'b';
                    break;
                case Pieces.BKNIGHT:
                    aPiece = 'n';
                    break;
                case Pieces.BPAWN:
                    aPiece = 'p';
                    break;
            }
            return aPiece;
        }

        public static char CharFromPiece(Pieces piece)
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
                    aPiece = 'P';
                    break;
            }
            return aPiece;
        }  

        #endregion

        #region Get Ascii - Notation 

        public string GetAsciiNotation()
        {
            string asciiNotation = string.Empty;
            string white = "w";
            string black = "b";
            char separator = ',';

            if (!string.IsNullOrEmpty(GetPieceAscii(Pieces.WKING)))
            {
                white += GetPieceAscii(Pieces.WKING) + separator;
            }
            else
            {
                white += GetPieceAscii(Pieces.WKING);
            }
            
            if (!string.IsNullOrEmpty(GetPieceAscii(Pieces.WQUEEN)))
            {
                white += GetPieceAscii(Pieces.WQUEEN) + separator;
            }
            else
            {
                white += GetPieceAscii(Pieces.WQUEEN);
            }
            
            if (!string.IsNullOrEmpty(GetPieceAscii(Pieces.WKNIGHT)))
            {
                white += GetPieceAscii(Pieces.WKNIGHT) + separator;
            }
            else
            {
                white += GetPieceAscii(Pieces.WKNIGHT);
            }

            if (!string.IsNullOrEmpty(GetPieceAscii(Pieces.WBISHOP)))
            {
                white += GetPieceAscii(Pieces.WBISHOP) + separator;
            }
            else
            {
                white += GetPieceAscii(Pieces.WBISHOP);
            }

            if (!string.IsNullOrEmpty(GetPieceAscii(Pieces.WROOK)))
            {
                white += GetPieceAscii(Pieces.WROOK) + separator;
            }
            else
            {
                white += GetPieceAscii(Pieces.WROOK);
            }


            if (!string.IsNullOrEmpty(GetPieceAscii(Pieces.WPAWN)))
            {
                white += GetPieceAscii(Pieces.WPAWN) + separator;
            }
            else
            {
                white += GetPieceAscii(Pieces.WPAWN);
            }
            
            
            white = RemoveEndingChar(white, separator);

            if (!string.IsNullOrEmpty(GetPieceAscii(Pieces.BKING)))
            {
                black += GetPieceAscii(Pieces.BKING) + separator;
            }
            else
            {
                black += GetPieceAscii(Pieces.BKING);
            }

            if (!string.IsNullOrEmpty(GetPieceAscii(Pieces.BQUEEN)))
            {
                black += GetPieceAscii(Pieces.BQUEEN) + separator;
            }
            else
            {
                black += GetPieceAscii(Pieces.BQUEEN);
            }

            if (!string.IsNullOrEmpty(GetPieceAscii(Pieces.BKNIGHT)))
            {
                black += GetPieceAscii(Pieces.BKNIGHT) + separator;
            }
            else
            {
                black += GetPieceAscii(Pieces.BKNIGHT);
            }

            if (!string.IsNullOrEmpty(GetPieceAscii(Pieces.BBISHOP)))
            {
                black += GetPieceAscii(Pieces.BBISHOP) + separator;
            }
            else
            {
                black += GetPieceAscii(Pieces.BBISHOP);
            }

            if (!string.IsNullOrEmpty(GetPieceAscii(Pieces.BROOK)))
            {
                black += GetPieceAscii(Pieces.BROOK) + separator;
            }
            else
            {
                black += GetPieceAscii(Pieces.BROOK);
            }

            if (!string.IsNullOrEmpty(GetPieceAscii(Pieces.BPAWN)))
            {
                black += GetPieceAscii(Pieces.BPAWN) + separator;
            }
            else
            {
                black += GetPieceAscii(Pieces.BPAWN);
            }
            
            black = RemoveEndingChar(black, separator);

            asciiNotation = white + "/" + black;
            return asciiNotation;
        }

        private string GetPieceAscii(Pieces piece)
        {
            string ascii = string.Empty;
            string filter = "p = '" + (int)piece + "'";
            char separator = ',';

            DataRow[] rows = BoardData.Select(filter);
            if (rows.Length > 0)
            {
                ascii += CharFromPiece(piece);

                RankEnum r;
                FileEnum f;
                foreach (DataRow dr in rows)
                {
                    r = (RankEnum)BaseItem.GetColInt32(dr, Board.Rank);
                    f = (FileEnum)BaseItem.GetColInt32(dr, Board.File);
                    ascii += GetFileString(f) + GetRankString(r) + separator;
                }
                ascii = RemoveEndingChar(ascii, separator);
            }
            
            return ascii;
        }

        private string RemoveEndingChar(string s, char charToRemove)
        {
            if (s.EndsWith(charToRemove.ToString()))
            {
                s = s.Substring(0, s.LastIndexOf(charToRemove));
            }
            return s;
        }

        private string RemoveStartingChar(string s, char charToRemove)
        {
            if (s.StartsWith(charToRemove.ToString()))
            {
                s = s.Substring(1);
            }
            return s;
        }

        #endregion

        #region Set Ascii - Notation

        public string GetFenFromAscii(string ascii)
        {
            string fen = string.Empty;
            if (IsValidAscii(ascii))
            {
                string[] asciiItems = ascii.Split("/".ToCharArray());
                string whiteAscii = asciiItems[0];
                string blackAscii = asciiItems[1];

                ///// set board rows to empty 
                SetBoardEmpty();

                ///// set white pieces on board table
                SetAsciiPieces(whiteAscii, true);
                ///// set black pieces on board table
                SetAsciiPieces(blackAscii, false);

                //// get fen from board table
                fen = GetFen();
            }
            return fen;
        }

        private bool IsValidAscii(string ascii)
        {
            bool isValid = false;
            if (ascii.StartsWith("w") && ascii.Contains("/b"))
            {
                isValid = true;
            }
            return isValid;
        }

        private void SetAsciiPieces(string piecesAscii,bool isWhite)
        {
            string[] piecesItems = piecesAscii.Split(",".ToCharArray());            

            Pieces currentPiece = Pieces.NONE;
            string pieceSymbol = string.Empty;
            string singleNotation = string.Empty;

            foreach (string item in piecesItems)
            {
                switch (item.Length)
                {
                    case 2:
                        SetPiece(item, currentPiece);
                        break;
                    case 3:
                        pieceSymbol = item.Substring(0, 1);
                        singleNotation = item.Substring(1, 2);
                        currentPiece = GetPiece(pieceSymbol, isWhite);
                        SetPiece(singleNotation, currentPiece);
                        break;
                    case 4:
                        pieceSymbol = item.Substring(1, 1);
                        singleNotation = item.Substring(2, 2);
                        currentPiece = GetPiece(pieceSymbol, isWhite);
                        SetPiece(singleNotation, currentPiece);
                        break;
                    default:
                        break;
                }
            }
        }

        private Pieces GetPiece(string pieceSymbol, bool isWhite)
        {
            Pieces piece = Pieces.NONE;
            if (isWhite)
            {
                switch (pieceSymbol)
                {
                    case "K":
                        piece = Pieces.WKING;
                        break;
                    case "Q":
                        piece = Pieces.WQUEEN;
                        break;
                    case "N":
                        piece = Pieces.WKNIGHT;
                        break;
                    case "B":
                        piece = Pieces.WBISHOP;
                        break;
                    case "R":
                        piece = Pieces.WROOK;
                        break;
                    case "P":
                        piece = Pieces.WPAWN;
                        break;
                    default:
                        piece = Pieces.NONE;
                        break;
                }
            }
            else
            {
                switch (pieceSymbol)
                {
                    case "K":
                        piece = Pieces.BKING;
                        break;
                    case "Q":
                        piece = Pieces.BQUEEN;
                        break;
                    case "N":
                        piece = Pieces.BKNIGHT;
                        break;
                    case "B":
                        piece = Pieces.BBISHOP;
                        break;
                    case "R":
                        piece = Pieces.BROOK;
                        break;
                    case "P":
                        piece = Pieces.BPAWN;
                        break;
                    default:
                        piece = Pieces.NONE;
                        break;
                }
            }
            return piece;
        }

        private void SetBoardEmpty()
        {
            BoardData = GetBoardDataTable();
            DataRow dr;
            for (int rank = 7; rank >= 0; rank--)
            {
                for (int file = 0; file < 8; file++)
                {
                    dr = BoardData.NewRow();
                    dr["r"] = rank;
                    dr["f"] = file;
                    dr["p"] = 0; // set piece to None

                    BoardData.Rows.Add(dr);
                }
            }
        }

        private string GetFen()
        {
            string fen = string.Empty;
            int emptySquares = 0;            
            Pieces piece = Pieces.NONE;
            RankEnum previousRank = RankEnum.NoRank;
            RankEnum rank = RankEnum.NoRank;

            foreach (DataRow dr in BoardData.Rows)
            {
                piece = (Pieces)BaseItem.GetColInt32(dr, Board.Piece);
                rank = (RankEnum)BaseItem.GetColInt32(dr, Board.Rank);

                if (rank != previousRank)
                {
                    if (emptySquares > 0)
                    {
                        fen += emptySquares;
                        emptySquares = 0;
                    }
                    fen += "/";
                    previousRank = rank;
                }

                if (piece == Pieces.NONE)
                {
                    emptySquares++;
                }
                else
                {
                    if (emptySquares > 0)
                    {
                        fen += emptySquares;
                        emptySquares = 0;
                    }                    
                    fen += GetPieceChar(piece);
                }
            }
            if (emptySquares > 0)
            {
                fen += emptySquares;
                emptySquares = 0;
            }  
            fen = RemoveStartingChar(fen, '/');
            return fen;
        }
       
        #endregion

    }

    
}
