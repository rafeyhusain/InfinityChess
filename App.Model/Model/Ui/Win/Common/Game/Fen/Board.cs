using System;
using System.Text;
using System.Diagnostics;

namespace App.Model.Fen
{
    using Bitboard = UInt64;
    using BitMove = UInt16;

    sealed class Board
    {
        //#region Constants

        //internal const byte ForeverKing = 1;
        //internal const byte InitialQueens = 1;
        //internal const byte InitialRooks = 2;
        //internal const byte InitialBishops = 2;
        //internal const byte Initialknights = 2;

        //#endregion

        #region Fields

        internal Bitboard[] Occupies;
        internal Bitboard[] Pieces;
        internal byte[ , ] PieceCount;

        internal Castle[] Castle;

        internal ColorE OnMove;

        internal SquareE EnPassant;

        internal byte HalfMoveClock; //FiftyMove;
        
        internal ushort FullMoveCount;


        internal Bitboard Occupied
        {
            [DebuggerStepThrough]
            get { return Occupies[(byte)ColorE.White] | Occupies[(byte)ColorE.Black]; }
        }

        internal Bitboard Empty { get { return ~Occupied; } }
        

        /*
        internal bool WhiteCheck;
        internal bool BlackCheck;
        
        internal bool WhiteMate;
        internal bool BlackMate;
        internal bool StaleMate;

        
        internal byte RepeatedMove;

        internal bool BlackCastled;
        internal bool WhiteCastled;

        internal bool EndGamePhase;

        

        //internal MoveContent LastMove;
        */

        #endregion

        internal Board()
        {
            InitBoard();
        }

        private void InitBoard()
        {
            InitBitboards();
            InitCastles();
        }

        private void InitBitboards()
        {
            Occupies = new Bitboard[ Color.Colors ];
            Pieces = new Bitboard[ Piece.PiecesType ];
            PieceCount = new byte[ Color.Colors, Piece.PiecesType ];
            ClearBitboards();
        }

        private void InitCastles()
        {
            Castle = new Castle[ Color.Colors ];
            for( ColorE color = ColorE.White; color <= ColorE.Black; ++color )
                Castle[ (byte) color ] = new Castle();
            ClearCastles();
        }


        //internal void SetupFen( string fenString )
        //{
        //    if( string.IsNullOrEmpty(fenString) )
        //    {
        //        Debug.Assert(false, "Null or Empty FEN");
        //        return;
        //    }

        //    ClearBoard();

        //    Piece piece;
        //    ushort index = 0;
        //    char ch = fenString[ index ];

        //    while( ch == ' ' ) ch = fenString[ ++index ];
        //    //Piece placement. put pieces
        //    SquareE sqr = SquareE.A8;
        //    while( ch != ' ' )
        //    {
        //        // get the piece from its char representation
        //        piece = Piece.Parse(ch);
        //        if( piece != default(Piece) )
        //        {// there is a piece
        //            byte color = (byte) piece.Color;
        //            byte type = (byte) piece.Type;

        //            if( color != (byte) ColorE.NoColor && type != (byte) PieceE.NoPiece )
        //            {
        //                #region Checking
        //                if( type == (byte) PieceE.King && PieceCount[ color, type ] >= 1 )
        //                    Debug.Assert(false, "Illegal FEN format", (ColorE) color + " King already there");

        //                if( (PieceCount[ color, (byte) PieceE.Pawn ] +
        //                    Math.Max(PieceCount[ color, (byte) PieceE.Queen ] - 1, 0) +
        //                    Math.Max(PieceCount[ color, (byte) PieceE.Rook ] - 2, 0) +
        //                    Math.Max(PieceCount[ color, (byte) PieceE.Bishop ] - 2, 0) +
        //                    Math.Max(PieceCount[ color, (byte) PieceE.Knight ] - 2, 0)) > 8 )
        //                {
        //                    Debug.Assert(false, "Illegal FEN format", "Too many Pieces of " + (ColorE) color);
        //                }

        //                if( type == (byte) PieceE.Pawn )
        //                {
        //                    RankE rank = Square._Rank(sqr);
        //                    if( rank == RankE.Rank_1 || rank == RankE.Rank_8 )
        //                        Debug.Assert(false, "Illegal FEN format", "Pawn Rank");
        //                }
        //                #endregion

        //                PutPiece(piece, sqr);   // put the piece on board
        //                Square.BackwardInc(ref sqr);
        //            }
        //        }
        //        else if( ch == '8' )
        //        {
        //            Debug.Assert((byte) sqr % File.Files == 0, "Illegal FEN format", "Wrong character");
        //            sqr -= File.Files;
        //            if( sqr != SquareE.A1 )
        //            {
        //                ch = fenString[ ++index ];
        //                if( ch != '/' )
        //                {// there another char than '/' throw exception
        //                    Debug.Assert(false, "Illegal FEN format", "Wrong character");
        //                }
        //            }
        //        }
        //        else if( ch >= '1' && ch <= '7' )
        //        {// there is a number
        //            byte emptySqr = (byte) (ch - '0');
        //            while( emptySqr != 0 )    // skip empty squares
        //            {
        //                Square.BackwardInc(ref sqr);
        //                --emptySqr;
        //                if( (byte) sqr % File.Files == 0 )
        //                    break;
        //            }
        //            Debug.Assert(emptySqr == 0, "Illegal FEN format", "Wrong character");
        //        }
        //        else if( ch != '/' )
        //        {// there another char than '/' throw exception
        //            Debug.Assert(false, "Illegal FEN format", "Wrong character");
        //        }
        //        ch = fenString[ ++index ];
        //    }

        //    if( sqr != SquareE.NoSquare )
        //    {
        //        Debug.Assert(false, "Illegal FEN format", "InComplete Position");
        //    }

        //    while( ch == ' ' ) ch = fenString[ ++index ];

        //    //Active color. set side to move
        //    if( ch == 'w' )
        //    {
        //        OnMove = ColorE.White;
        //    }
        //    else if( ch == 'b' )
        //    {
        //        OnMove = ColorE.Black;
        //    }
        //    else
        //    {
        //        OnMove = ColorE.NoColor;
        //        Debug.Assert(false, "Illegal FEN format", "Active Color");
        //    }

        //    ch = fenString[ ++index ];
        //    while( ch == ' ' ) ch = fenString[ ++index ];
            
        //    //Castle availability. set castle availability
        //    if( ch == '-' )
        //    {
        //        ch = fenString[ ++index ];
        //    }
        //    else
        //    {
        //        while( ch != ' ' )
        //        {
        //            switch( ch )
        //            {
        //                case 'K':
        //                    {
        //                        Bitboard occupy = Occupies[ (byte) ColorE.White ];
        //                        if( BitBoard.GetSquare(occupy & Pieces[ (byte) PieceE.King ], SquareE.E1) ||
        //                            BitBoard.GetSquare(occupy & Pieces[ (byte) PieceE.Rook ], SquareE.H1) )
        //                        {
        //                            Castle[ (byte) ColorE.White ].ShortCastle = true;
        //                        }
        //                        else
        //                            Debug.Assert(false, "Illegal FEN format", "Castle [White.ShortCastle]");
        //                    }
        //                    break;
        //                case 'Q':
        //                    {
        //                        Bitboard occupy = Occupies[ (byte) ColorE.White ];
        //                        if( BitBoard.GetSquare(occupy & Pieces[ (byte) PieceE.King ], SquareE.E1) ||
        //                            BitBoard.GetSquare(occupy & Pieces[ (byte) PieceE.Rook ], SquareE.A1) )
        //                        {
        //                            Castle[ (byte) ColorE.White ].LongCastle = true;
        //                        }
        //                        else
        //                            Debug.Assert(false, "Illegal FEN format", "Castle [White.LongCastle]");
        //                    }
        //                    break;
        //                case 'k':
        //                    {
        //                        Bitboard occupy = Occupies[ (byte) ColorE.Black ];
        //                        if( BitBoard.GetSquare(occupy & Pieces[ (byte) PieceE.King ], SquareE.E8) ||
        //                            BitBoard.GetSquare(occupy & Pieces[ (byte) PieceE.Rook ], SquareE.H8) )
        //                        {
        //                            Castle[ (byte) ColorE.Black ].ShortCastle = true;
        //                        }
        //                        else
        //                            Debug.Assert(false, "Illegal FEN format", "Castle [Black.ShortCastle]");
        //                    }
        //                    break;
        //                case 'q':
        //                    {
        //                        Bitboard occupy = Occupies[ (byte) ColorE.Black ];
        //                        if( BitBoard.GetSquare(occupy & Pieces[ (byte) PieceE.King ], SquareE.E8) ||
        //                            BitBoard.GetSquare(occupy & Pieces[ (byte) PieceE.Rook ], SquareE.A8) )
        //                        {
        //                            Castle[ (byte) ColorE.Black ].LongCastle = true;
        //                        }
        //                        else
        //                            Debug.Assert(false, "Illegal FEN format", "Castle [Black.LongCastle]");
        //                    }
        //                    break;
        //                default: Debug.Assert(false, "Illegal FEN format", "Castle"); break;
        //            }
        //            ch = fenString[ ++index ];
        //        }
        //    }

        //    while( ch == ' ' ) ch = fenString[ ++index ];

        //    //En passant target square. set en passant target
        //    if( ch == '-' )
        //    {
        //        EnPassant = SquareE.NoSquare;
        //        ch = fenString[ ++index ];
        //    }
        //    else
        //    {   // checks if the square notation is correct
        //        char fileEP = ch;
        //        if( fileEP >= 'a' && fileEP <= 'h' )
        //        {
        //            char rankEP = fenString[ ++index ];
        //            if( rankEP == '3' || rankEP == '6' )
        //            {
        //                ++index;
        //                if( rankEP == '3' && !BitBoard.GetSquare(Occupies[ (byte) ColorE.White ] & Pieces[ (byte) PieceE.Pawn ], Square._Square(fileEP, (char) (rankEP + 1))) ||
        //                    rankEP == '6' && !BitBoard.GetSquare(Occupies[ (byte) ColorE.Black ] & Pieces[ (byte) PieceE.Pawn ], Square._Square(fileEP, (char) (rankEP - 1))) )
        //                {
        //                    Debug.Assert(false, "Illegal FEN format", "Pawn missing");
        //                }
        //                EnPassant = Square._Square(fileEP, rankEP);
        //            }
        //            else
        //                Debug.Assert(false, "Illegal FEN format", "En passant (rank)");
        //            ch = fenString[ index ];
        //        }
        //        else
        //            Debug.Assert(false, "Illegal FEN format", "En passant (file)");
        //    }

        //    while( ch == ' ' ) ch = fenString[ ++index ];
        //    //Halfmove clock. set ply
        //    try
        //    {
        //        int length = fenString.IndexOf(' ', index) - index;
        //        HalfMoveClock = byte.Parse(fenString.Substring(index, length));
        //        if( HalfMoveClock >= 100 )
        //            Debug.Assert(false, "Fifty Move Draw");

        //        index += (ushort) length;
        //        ch = fenString[ index ];
        //    }
        //    catch
        //    {
        //        Debug.Assert(false, "Illegal FEN format", "HalfMove (Ply)");
        //    }

        //    while( ch == ' ' ) ch = fenString[ ++index ];

        //    //Fullmove counter. set move number
        //    try
        //    {
        //        int length = fenString.IndexOf(' ', index);
        //        length = length != -1 ? length : fenString.Length - index;
        //        FullMoveCount = byte.Parse(fenString.Substring(index, length));
        //    }
        //    catch
        //    {
        //        Debug.Assert(false, "Illegal FEN format", "Moves");
        //    }

        //    Console.Write(FEN.ToString(this));

        //    if( IsLegal() )
        //    {
        //        Console.WriteLine(ToString());
        //    }
        //}

        internal void PutPiece( Piece piece, SquareE square )
        {
            byte color = (byte) piece.Color;
            byte type = (byte) piece.Type;
            BitBoard.SetSquare(ref Occupies[ color ], square);
            BitBoard.SetSquare(ref Pieces[ type ], square);
            ++PieceCount[ color, type ];
        }

        internal void RemovePiece( Piece piece, SquareE square )
        {
            byte color = (byte) piece.Color;
            byte type = (byte) piece.Type;
            BitBoard.RstSquare(ref Occupies[ color ], square);
            BitBoard.RstSquare(ref Pieces[ type ], square);
            --PieceCount[ color, type ];
        }

        private void ClearSquare( SquareE square )
        {
            //bool isPiece = false;
            for( ColorE color = ColorE.White; color <= ColorE.Black; ++color )
            {
                Bitboard occupy = Occupies[ (byte) color ];
                if( BitBoard.GetSquare(occupy, square) )
                {
                    for( PieceE type = PieceE.Pawn; type <= PieceE.King; ++type )
                    {
                        Bitboard piece = Pieces[ (byte) type ];
                        if( BitBoard.GetSquare(piece, square) ) // occupy & piece 
                        {
                            BitBoard.RstSquare(ref Occupies[ (byte) color ], square);
                            BitBoard.RstSquare(ref Pieces[ (byte) type ], square);
                            break;

                            //Debug.Assert(!isPiece, "Piece Overlaps");
                            //isPiece = true;
                        }
                    }
                }
            }
        }

        private bool IsLegal()
        {
            ColorE color;
            Bitboard occupy;

            #region Pieces Count

            for( color = ColorE.White; color <= ColorE.Black; ++color )
            {
                occupy = Occupies[ (byte) color ];
                // check too many total pieces
                if( BitBoard.CountSets(occupy) > 16 )
                    return false;

                // check if the number of Pawns plus the number of extra Queens, Rooks, Bishops, Knights
                // (which can result only by promotion) exceeds 8

                // check too many color pieces
                if( PieceCount[ (byte) color, (byte) PieceE.Pawn ]
                  + Math.Max(PieceCount[ (byte) color, (byte) PieceE.Queen ] - 1, 0)
                  + Math.Max(PieceCount[ (byte) color, (byte) PieceE.Rook ] - 2, 0)
                  + Math.Max(PieceCount[ (byte) color, (byte) PieceE.Bishop ] - 2, 0)
                  + Math.Max(PieceCount[ (byte) color, (byte) PieceE.Knight ] - 2, 0)
                  > 8
                  )
                {
                    return false;
                }

                if( PieceCount[ (byte) color, (byte) PieceE.Bishop ] > 1 )
                {
                    Bitboard bishops = occupy & Pieces[ (byte) PieceE.Bishop ];

                    byte[] bishopCount = new byte[ Color.Colors ];

                    //SquareE[] square = BitBoard.GetSquares(occupy & board.Pieces[ (byte) PieceE.Bishop ]);
                    //foreach( SquareE sqr in square )
                    //    ++bishopCount[ (byte) Square._Color(sqr) ];

                    bishopCount[ (byte) ColorE.White ] = BitBoard.CountSets(BitBoard.LightSquares & bishops);
                    bishopCount[ (byte) ColorE.Black ] = BitBoard.CountSets(BitBoard.DarkSquares & bishops);

                    if( PieceCount[ (byte) color, (byte) PieceE.Pawn ]
                      + Math.Max(bishopCount[ (byte) ColorE.White ] - 1, 0)
                      + Math.Max(bishopCount[ (byte) ColorE.Black ] - 1, 0)
                      > 8 )
                    {
                        Debug.Assert(false, "Illegal FEN format", "Too many Promotion Bishop of same color of " + color);
                        return false;
                    }
                }

                // check for King
                byte king = PieceCount[ (byte) color, (byte) PieceE.King ];
                if( king != 1 ) //Illegal King
                    return false;
            }
            //

            if( (Pieces[ (byte) PieceE.Pawn ] & (BitBoard.Rank_1 | BitBoard.Rank_8)) != 0 )
            {//Pawn rank one or eight
                return false;
            }
            #endregion

            #region Overlapping

            Bitboard occupied = Occupied;
            if( (Occupies[ (byte) ColorE.White ] ^
                 Occupies[ (byte) ColorE.Black ]) !=
                 occupied )
            {
                return false;
            }

            if( (Pieces[ (byte) PieceE.Pawn ] ^
                 Pieces[ (byte) PieceE.Knight ] ^
                 Pieces[ (byte) PieceE.Bishop ] ^
                 Pieces[ (byte) PieceE.Rook ] ^
                 Pieces[ (byte) PieceE.Queen ] ^
                 Pieces[ (byte) PieceE.King ]) !=
                 occupied )
            {
                return false;
            }
            #endregion

            #region Castling

            color = ColorE.White;
            occupy = Occupies[ (byte) color ];
            // check the white King is in place for castle
            if( Castle[ (byte) color ].AnyCastle )
            {
                if( BitBoard.GetSquare(occupy & Pieces[ (byte) PieceE.King ], SquareE.E1) )
                {
                    Bitboard rooks = occupy & Pieces[ (byte) PieceE.Rook ];
                    // check the white Rook is in place for castle
                    if( Castle[ (byte) color ].ShortCastle &&
                        !BitBoard.GetSquare(rooks, SquareE.H1) )
                        //Illegal WhiteShortCastle
                        return false;
                    if( Castle[ (byte) color ].LongCastle &&
                        !BitBoard.GetSquare(rooks, SquareE.A1) )
                        //Illegal WhiteLongCastle
                        return false;
                }
                else    //Illegal WhiteCastle
                    return false;
            }

            color = ColorE.Black;
            occupy = Occupies[ (byte) color ];
            // check the black King is in place for castle
            if( Castle[ (byte) color ].AnyCastle )
            {
                if( BitBoard.GetSquare(occupy & Pieces[ (byte) PieceE.King ], SquareE.E8) )
                {
                    Bitboard rooks = occupy & Pieces[ (byte) PieceE.Rook ];
                    // check the black Rook is in place for castle
                    if( Castle[ (byte) color ].ShortCastle &&
                        !BitBoard.GetSquare(rooks, SquareE.H8) )
                        //Illegal BlackShortCastle
                        return false;
                    if( Castle[ (byte) color ].LongCastle &&
                        !BitBoard.GetSquare(rooks, SquareE.A8) )
                        //Illegal BlackLongCastle
                        return false;
                }
                else    //Illegal BlackCastle
                    return false;
            }
            #endregion

            #region EnPassant

            if( EnPassant != SquareE.NoSquare )
            {
                if( !Square.IsValid(EnPassant) )
                    return false;

                if( OnMove == ColorE.White &&
                    (Square._Rank(EnPassant) != RankE.Rank_6 || !BitBoard.GetSquare(Occupies[ (byte) ColorE.Black ] & Pieces[ (byte) PieceE.Pawn ], (SquareE) (EnPassant - 8)))
                    ||
                    OnMove == ColorE.Black &&
                    (Square._Rank(EnPassant) != RankE.Rank_3 || !BitBoard.GetSquare(Occupies[ (byte) ColorE.White ] & Pieces[ (byte) PieceE.Pawn ], (SquareE) (EnPassant + 8))) )
                    return false;
            }
            #endregion

            #region Move

            if( //0 < HalfMove ||
                HalfMoveClock > 100 ) return false;
            //if( MoveCount < 0 ) return false; 
            #endregion

            #region KingCheck And Move
            /*
            // check if the side which is not to move is in check
            if(
                (board.Status.WhiteTurn && board.IsBlackKingInCheck)
             || (board.Status.BlackTurn && board.IsWhiteKingInCheck)
              )
            {
                throw new ArgumentException(Resources.NoSideNotToMoveCheckMsg, "Board");
            }
            */
            
            #endregion

            return true;
        }

        private void CountPieces()
        {
            for( ColorE color = ColorE.White; color <= ColorE.Black; ++color )
            {
                Bitboard occupy = Occupies[ (byte) color ];
                for( PieceE type = PieceE.Pawn; type <= PieceE.King; ++type )
                {
                    Bitboard piece = Pieces[ (byte) type ];
                    PieceCount[ (byte) color, (byte) type ] = BitBoard.CountSets(occupy & piece);
                }
            }
        }

        public void SwitchSideOnMove()
        {
            switch( OnMove )
            {
                case ColorE.White: OnMove = ColorE.Black; break;
                case ColorE.Black: OnMove = ColorE.White; break;
                case ColorE.NoColor:
                default: Debug.Assert(false, "No Side to Move"); break;
            }
        }

        public Piece PickPiece( SquareE sqr )
        {
            Piece p = new Piece();
            //bool isPiece = false;
            for( ColorE color = ColorE.White; color <= ColorE.Black; ++color )
            {
                Bitboard occupy = Occupies[ (byte) color ];
                if( BitBoard.GetSquare(occupy, sqr) )
                {
                    for( PieceE type = PieceE.Pawn; type <= PieceE.King; ++type )
                    {
                        Bitboard piece = Pieces[ (byte) type ];
                        if( BitBoard.GetSquare(piece, sqr) ) // occupy & piece 
                        {
                            //Debug.Assert(!isPiece, "Piece Overlaps");
                            //isPiece = true;
                            return new Piece(color, type);
                        }
                    }
                }
            }
            return p;
        }

        public void MovePiece( SquareE origin, SquareE destiny, PieceE promote )
        {
            Debug.Assert(IsLegal());

            Piece movePiece = PickPiece(origin);
            if( movePiece.Color == OnMove )
            {
                RemovePiece(movePiece, origin);

                Piece capturePiece = PickPiece(destiny);
                if( capturePiece.Type != PieceE.NoPiece )
                {
                    RemovePiece(capturePiece, destiny);
                }

                PutPiece(movePiece, destiny);
            }
        }


        #region Clears

        private void ClearBoard()
        {
            ClearBitboards();
            ClearCastles();
            //_sideMove = Colors.White;
            //_epSquare = Squares.NoSquare;
            //_50move = 0;
        }

        private void ClearBitboards()
        {
            for( ColorE color = ColorE.White; color <= ColorE.Black; ++color )
                Occupies[ (byte) color ] = BitBoard.EmptySquares;

            for( PieceE type = PieceE.Pawn; type <= PieceE.King; ++type )
                Pieces[ (byte) type ] = BitBoard.EmptySquares;

            for( ColorE color = ColorE.White; color <= ColorE.Black; ++color )
            {
                for( PieceE type = PieceE.Pawn; type <= PieceE.King; ++type )
                    PieceCount[ (byte) color, (byte) type ] = 0;
            }
        }

        private void ClearCastles()
        {
            for( ColorE color = ColorE.White; color <= ColorE.Black; ++color )
                Castle[ (byte) color ].AnyCastle = false;
        }
        #endregion


        // TODO::
        //internal Bitboard AttacksTo( Bitboard occupied, SquareE sqr, ColorE side )
        //{
        //    //Bitboard knights, kings, bishopsQueens, rooksQueens;
        //    //knights = pieceBB[ nWhiteKnight ] | pieceBB[ nBlackKnight ];
        //    //kings = pieceBB[ nWhiteKing ] | pieceBB[ nBlackKing ];
        //    //rooksQueens =
        //    //bishopsQueens = pieceBB[ nWhiteQueen ] | pieceBB[ nBlackQueen ];
        //    //rooksQueens |= pieceBB[ nWhiteRook ] | pieceBB[ nBlackRook ];
        //    //bishopsQueens |= pieceBB[ nWhiteBishop ] | pieceBB[ nBlackBishop ];

        //    //return (arrPawnAttacks[ nWhite ][ sqr ] & pieceBB[ nBlackPawn ])
        //    //     | (arrPawnAttacks[ nBlack ][ sqr ] & pieceBB[ nWhitePawn ])
        //    //     | (arrKnightAttacks[ sqr ] & knights)
        //    //     | (arrKingAttacks[ sqr ] & kings)
        //    //     | (bishopAttacks(occupied, sqr) & bishopsQueens)
        //    //     | (rookAttacks(occupied, sqr) & rooksQueens)
        //    //     ;

        //    ColorE oppside = ColorE.NoColor;
        //    if( side == ColorE.White )
        //    {
        //        oppside = ColorE.Black;
        //    }
        //    else if( side == ColorE.Black )
        //    {
        //        oppside = ColorE.White;
        //    }

        //    Bitboard sideOccupied = Occupies[ (byte) side ];

        //    Bitboard rooksQueens = Pieces[ (byte) PieceE.Rook ] | Pieces[ (byte) PieceE.Queen ];
        //    Bitboard bishopsQueens = Pieces[ (byte) PieceE.Bishop ] | Pieces[ (byte) PieceE.Queen ];

        //    return (MoveAttack._PawnAttacks[ (byte) sqr, (byte) side ] & (Pieces[ (byte) PieceE.Pawn ] & Occupies[ (byte) oppside ]))
        //        | (MoveAttack._PawnAttacks[ (byte) sqr, (byte) oppside ] & (Pieces[ (byte) PieceE.Pawn ] & Occupies[ (byte) side ]))
        //        | (MoveAttack._KnightMoves[ (byte) sqr ] & Pieces[ (byte) PieceE.Knight ])
        //        | (MoveAttack._KingMoves[ (byte) sqr ] & Pieces[ (byte) PieceE.King ])
        //        | (MoveAttack._RookMoves[ (byte) sqr ] & rooksQueens)
        //        | (MoveAttack._BishopMoves[ (byte) sqr ] & bishopsQueens);
        //}


        public override string ToString()
        {
            StringBuilder sboard = new StringBuilder();
            sboard.AppendLine(" +-+-+-+-+-+-+-+-+");


            //SquareE begSqr = SquareE.A8;
            //SquareE endSqr = SquareE.H1;
            //for( SquareE sqr = begSqr; ; Square.BackwardInc(ref sqr) )
            //{
            //    if( (byte) sqr % File.Files == 0 )
            //    {
            //        if( sqr != begSqr ) sboard.AppendLine();
            //        sboard.Append(Rank.mapRank[ (byte) sqr / File.Files ]);
            //    }
            //    bool isPiece = false;
            //    sboard.Append(" ");
            //    for( ColorE color = ColorE.White; color <= ColorE.Black; ++color )
            //    {
            //        Bitboard occupy = Occupies[ (byte) color ];
            //        for( PieceE type = PieceE.Pawn; type <= PieceE.King; ++type )
            //        {
            //            Bitboard piece = Pieces[ (byte) type ];
            //            if( BitBoard.GetSquare(occupy & piece, sqr) )
            //            {
            //                //if( isPiece ) sboard.Append('x'); // '*'
            //                isPiece = true;
            //                sboard.Append(Piece.mapPiece[ (byte) color, (byte) type ]);
            //                break;
            //            }
            //        }
            //    }
            //    if( !isPiece )
            //        sboard.Append(".");
            //    if( sqr == endSqr )
            //        break;
            //}


            for( RankE rank = RankE.Rank_8; ; --rank )
            {
                sboard.Append(Rank.mapRank[ (byte) rank ]);
                for( FileE file = FileE.File_A; file <= FileE.File_H; ++file )
                {
                    bool isPiece = false;
                    sboard.Append(" ");
                    for( ColorE color = ColorE.White; color <= ColorE.Black; ++color )
                    {
                        Bitboard occupy = Occupies[ (byte) color ];
                        SquareE sqr = Square._Square(file, rank);
                        if( BitBoard.GetSquare(occupy, sqr) )
                        {
                            for( PieceE type = PieceE.Pawn; type <= PieceE.King; ++type )
                            {
                                Bitboard piece = Pieces[ (byte) type ];
                                if( BitBoard.GetSquare(piece, sqr) ) // occupy & piece 
                                {
                                    //if( isPiece ) sboard.Append('x'); // '*'
                                    isPiece = true;
                                    sboard.Append(Piece.mapPiece[ (byte) color, (byte) type ]);
                                    break;
                                }
                            }
                        }
                    }
                    if( !isPiece )
                        sboard.Append(".");
                }
                if( rank == RankE.Rank_1 )
                    break;
                sboard.AppendLine();
            }


            sboard.AppendLine().Append(" +-+-+-+-+-+-+-+-+").AppendLine();
            sboard.Append(" ");
            foreach( char file in File.mapFile )
                sboard.Append(" " + file);
            return sboard.ToString();
        }


        private bool IsMoverInCheck()
        {

            return false;
        }
    };
}