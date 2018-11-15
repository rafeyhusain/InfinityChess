using System;
using System.Text;
using System.Diagnostics;

namespace App.Model.Fen
{
    using Bitboard = UInt64;

    /// <summary>
    /// Forsyth–Edwards Notation (FEN)
    /// Standard notation for describing a particular board position of a chess game.
    /// 
    ///  <FEN> ::=  <Piece Placement>
    ///         ' ' <Side to move>
    ///         ' ' <Castling ability>
    ///         ' ' <En passant target square>
    ///         ' ' <Halfmove clock>
    ///         ' ' <Fullmove counter>
    /// </summary>
    public static class FEN
    {
        internal const string StartFEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

        internal const char recordSep = ' ';
        internal const char rankSep   = '/';

        public static bool IsValid( string fenString )
        {
            if( string.IsNullOrEmpty(fenString) )
            {
                return false;
            }

            string[] records = fenString.Split(new char[] { recordSep }, StringSplitOptions.RemoveEmptyEntries);
            int numRecord = records.Length;
            // --- full fenString check
            //if( numRecord != 6 )
            //{
            //    return false;
            //}

            Board board = new Board();

            #region Piece placement

            string[] ranks = records[ 0 ].Split(rankSep);

            if( ranks.Length != Rank.Ranks )
            {
                return false;
            }

            byte baseSqr = (byte) SquareE.A8;
            foreach( string rank in ranks )
            {
                byte offsetFile = 0;
                foreach( char achar in rank )
                {
                    if( achar >= '1' && achar <= '8' )
                        offsetFile += (byte) (achar - '0');
                    else
                    {
                        Piece piece = Piece.Parse(achar);

                        if( piece != default(Piece) )
                        {// there is a piece
                            ColorE color = piece.Color;
                            PieceE type = piece.Type;

                            if( color != ColorE.NoColor && type != PieceE.NoPiece )
                            {
                                if( offsetFile >= File.Files )
                                {
                                    return false;
                                }

                                SquareE sqr = (SquareE) (baseSqr + offsetFile);

                                switch( type )
                                {
                                    case PieceE.Pawn:
                                        RankE pawnRank = Square._Rank(sqr);
                                        if( pawnRank == RankE.Rank_1 || pawnRank == RankE.Rank_8 )
                                        {
                                            return false;
                                        }
                                        if( board.PieceCount[ (byte) color, (byte) type ] >= 8 )
                                        {
                                            return false;
                                        }
                                        break;
                                    case PieceE.King:
                                        if( board.PieceCount[ (byte) color, (byte) type ] >= 1 )
                                        {
                                            return false;
                                        }
                                        break;
                                    case PieceE.Knight:
                                    case PieceE.Bishop:
                                    case PieceE.Rook:
                                    case PieceE.Queen:
                                        if( board.PieceCount[ (byte) color, (byte) PieceE.Pawn ] +
                                            board.PieceCount[ (byte) color, (byte) PieceE.Knight ] +
                                            board.PieceCount[ (byte) color, (byte) PieceE.Bishop ] +
                                            board.PieceCount[ (byte) color, (byte) PieceE.Rook ] +
                                            board.PieceCount[ (byte) color, (byte) PieceE.Queen ]
                                            >= 15 )
                                        {
                                            return false;
                                        }
                                        break;
                                }

                                board.PutPiece(piece, sqr);   // put the piece on board
                            }
                        }
                        else
                        {
                            return false;
                        }

                        ++offsetFile;
                    }
                }

                if( offsetFile == 0 ) // Allow null lines = /8/
                    offsetFile = File.Files;

                if( offsetFile != File.Files )
                {
                    return false;
                }
                baseSqr -= File.Files;
            }

            for( ColorE color = ColorE.White; color <= ColorE.Black; ++color )
            {
                Bitboard occupy = board.Occupies[ (byte) color ];
                // check too many total pieces
                if( BitBoard.CountSets(occupy) > 16 )
                {
                    return false;
                }
                // check if the number of Pawns plus the number of extra Queens, Rooks, Bishops, Knights
                // (which can result only by promotion) exceeds 8

                // check too many color pieces
                if( board.PieceCount[ (byte) color, (byte) PieceE.Pawn ] +
                    Math.Max(board.PieceCount[ (byte) color, (byte) PieceE.Knight ] - 2, 0) +
                    Math.Max(board.PieceCount[ (byte) color, (byte) PieceE.Bishop ] - 2, 0) +
                    Math.Max(board.PieceCount[ (byte) color, (byte) PieceE.Rook ] - 2, 0) +
                    Math.Max(board.PieceCount[ (byte) color, (byte) PieceE.Queen ] - 1, 0)
                    > 8 )
                {
                    return false;
                }

                if( board.PieceCount[ (byte) color, (byte) PieceE.Bishop ] > 1 )
                {
                    Bitboard bishops = occupy & board.Pieces[ (byte) PieceE.Bishop ];

                    byte[] oppBishopCount = new byte[ Color.Colors ];

                    //SquareE[] square = BitBoard.GetSquares(occupy & board.Pieces[ (byte) PieceE.Bishop ]);
                    //foreach( SquareE sqr in square )
                    //    ++oppBishopCount[ (byte) Square._Color(sqr) ];

                    oppBishopCount[ (byte) ColorE.White ] = BitBoard.CountSets(BitBoard.LightSquares & bishops);
                    oppBishopCount[ (byte) ColorE.Black ] = BitBoard.CountSets(BitBoard.DarkSquares & bishops);

                    if( board.PieceCount[ (byte) color, (byte) PieceE.Pawn ] +
                        Math.Max(oppBishopCount[ (byte) ColorE.White ] - 1, 0) +
                        Math.Max(oppBishopCount[ (byte) ColorE.Black ] - 1, 0)
                        > 8 )
                    {
                        return false;
                    }
                }

                // check for King
                byte king = board.PieceCount[ (byte) color, (byte) PieceE.King ];
                if( king != 1 ) //Illegal King
                {
                    return false;
                }
            }

            //Bitboard occupied = board.Occupied;
            //if( (board.Occupies[ (byte) ColorE.White ] ^ board.Occupies[ (byte) ColorE.Black ]) !=
            //     occupied )
            //{
            //    return false;
            //}

            //if( (board.Pieces[ (byte) PieceE.Pawn ] ^
            //     board.Pieces[ (byte) PieceE.Knight ] ^
            //     board.Pieces[ (byte) PieceE.Bishop ] ^
            //     board.Pieces[ (byte) PieceE.Rook ] ^
            //     board.Pieces[ (byte) PieceE.Queen ] ^
            //     board.Pieces[ (byte) PieceE.King ]) !=
            //     occupied )
            //{
            //    return false;
            //}

            #endregion

            if( numRecord > 1 )
            {
                #region Active color

                string aColor = records[ 1 ];
                if( string.IsNullOrEmpty(aColor) || aColor.Length != 1 )
                {
                    return false;
                }

                char activeColor = char.ToLower(aColor[ 0 ]);
                if( activeColor == 'w' )
                    board.OnMove = ColorE.White;
                else if( activeColor == 'b' )
                    board.OnMove = ColorE.Black;
                else
                {
                    board.OnMove = ColorE.NoColor;
                    return false;
                }
                #endregion
            }

            if( numRecord > 2 )
            {
                #region Castling privileges

                string castles = records[ 2 ];
                if( string.IsNullOrEmpty(castles) )
                {
                    return false;
                }

                if( castles == "-" )
                {
                    board.Castle[ (byte) ColorE.White ].AnyCastle = false;
                    board.Castle[ (byte) ColorE.Black ].AnyCastle = false;
                }
                else
                {
                    int length = castles.Length;
                    if( length > 4 )
                    {
                        return false;
                    }

                    for( byte i = 0; i < length - 1; ++i )
                    {
                        for( byte j = (byte) (i + 1); j < length; ++j )
                        {
                            if( castles[ i ] == castles[ j ] )
                            {
                                return false;
                            }
                        }
                    }

                    foreach( char castle in castles )
                    {
                        switch( castle )
                        {
                            case 'K':
                                {
                                    Bitboard occupy = board.Occupies[ (byte) ColorE.White ];
                                    if( BitBoard.GetSquare(occupy & board.Pieces[ (byte) PieceE.King ], SquareE.E1) &&
                                        BitBoard.GetSquare(occupy & board.Pieces[ (byte) PieceE.Rook ], SquareE.H1) )
                                        board.Castle[ (byte) ColorE.White ].ShortCastle = true;
                                    else
                                        return false;
                                } break;
                            case 'Q':
                                {
                                    Bitboard occupy = board.Occupies[ (byte) ColorE.White ];
                                    if( BitBoard.GetSquare(occupy & board.Pieces[ (byte) PieceE.King ], SquareE.E1) &&
                                        BitBoard.GetSquare(occupy & board.Pieces[ (byte) PieceE.Rook ], SquareE.A1) )
                                        board.Castle[ (byte) ColorE.White ].LongCastle = true;
                                    else
                                        return false;
                                } break;
                            case 'k':
                                {
                                    Bitboard occupy = board.Occupies[ (byte) ColorE.Black ];
                                    if( BitBoard.GetSquare(occupy & board.Pieces[ (byte) PieceE.King ], SquareE.E8) &&
                                        BitBoard.GetSquare(occupy & board.Pieces[ (byte) PieceE.Rook ], SquareE.H8) )
                                        board.Castle[ (byte) ColorE.Black ].ShortCastle = true;
                                    else
                                        return false;
                                } break;
                            case 'q':
                                {
                                    Bitboard occupy = board.Occupies[ (byte) ColorE.Black ];
                                    if( BitBoard.GetSquare(occupy & board.Pieces[ (byte) PieceE.King ], SquareE.E8) &&
                                        BitBoard.GetSquare(occupy & board.Pieces[ (byte) PieceE.Rook ], SquareE.A8) )
                                        board.Castle[ (byte) ColorE.Black ].LongCastle = true;
                                    else
                                        return false;
                                } break;
                            default:
                                return false;
                        }
                    }
                }
                #endregion
            }

            if( numRecord > 3 )
            {
                #region EnPassant Target square

                string epSqr = records[ 3 ];
                if( string.IsNullOrEmpty(epSqr) )
                {
                    return false;
                }

                if( epSqr == "-" )
                    board.EnPassant = SquareE.NoSquare;
                else
                {
                    if( epSqr.Length != 2 )
                    {
                        return false;
                    }

                    char epFile = char.ToLower(epSqr[ 0 ]);
                    if( !(epFile >= 'a' && epFile <= 'h') )
                    {
                        return false;
                    }

                    char epRank = epSqr[ 1 ];
                    if( !(epRank == '3' || epRank == '6') )
                    {
                        return false;
                    }

                    if( epRank == '3' &&
                        (
                        board.OnMove != ColorE.Black ||
                        !BitBoard.GetSquare(board.Occupies[ (byte) ColorE.White ] & board.Pieces[ (byte) PieceE.Pawn ], Square._Square(epFile, (char) (epRank + 1)))
                        )
                        ||
                        epRank == '6' &&
                        (
                        board.OnMove != ColorE.White ||
                        !BitBoard.GetSquare(board.Occupies[ (byte) ColorE.Black ] & board.Pieces[ (byte) PieceE.Pawn ], Square._Square(epFile, (char) (epRank - 1)))
                        )
                      )
                    {
                        return false;
                    }
                    board.EnPassant = Square._Square(epFile, epRank);
                }
                #endregion
            }

            if( numRecord > 4 )
            {
                #region HalfMove Clock (Ply)

                byte halfMoveClock;
                if( !byte.TryParse(records[ 4 ], out halfMoveClock) )
                {
                    return false;
                }
                if( halfMoveClock > 100 )
                {
                    return false;
                }
                board.HalfMoveClock = halfMoveClock;
                #endregion
            }

            if( numRecord > 5 )
            {
                #region FullMove Counter

                ushort fullMoveCount;
                if( !ushort.TryParse(records[ 5 ], out fullMoveCount) )
                {
                    return false;
                }
                if( fullMoveCount == 0 ) fullMoveCount = 1;
                board.FullMoveCount = fullMoveCount;
                #endregion
            }

            return true;
        }

        /// Split Method
        internal static Board ToBoard( string fenString )
        {
            const Board emptyBoard = default(Board);

            if( string.IsNullOrEmpty(fenString) )
                return emptyBoard;

            string[] records = fenString.Split(new char[] { recordSep }, StringSplitOptions.RemoveEmptyEntries);
            int numRecord = records.Length;
            // --- full fenString check
            //if( numRecord != 6 ) return emptyBoard;

            Board board = new Board();

            #region Piece placement

            string[] ranks = records[ 0 ].Split(rankSep);

            if( ranks.Length != Rank.Ranks ) return emptyBoard;

            byte baseSqr = (byte) SquareE.A8;
            foreach( string rank in ranks )
            {
                byte offsetFile = 0;
                foreach( char achar in rank )
                {
                    if( achar >= '1' && achar <= '8' )
                        offsetFile += (byte) (achar - '0');
                    else
                    {
                        Piece piece = Piece.Parse(achar);

                        if( piece != default(Piece) )
                        {// there is a piece
                            ColorE color = piece.Color;
                            PieceE type = piece.Type;

                            if( color != ColorE.NoColor && type != PieceE.NoPiece )
                            {
                                if( offsetFile >= File.Files )
                                    return emptyBoard;

                                SquareE sqr = (SquareE) (baseSqr + offsetFile);

                                switch( type )
                                {
                                    case PieceE.Pawn:
                                        RankE pawnRank = Square._Rank(sqr);
                                        if( pawnRank == RankE.Rank_1 || pawnRank == RankE.Rank_8 )
                                            return emptyBoard;
                                        if( board.PieceCount[ (byte) color, (byte) type ] >= 8 )
                                            return emptyBoard;
                                        break;
                                    case PieceE.King:
                                        if( board.PieceCount[ (byte) color, (byte) type ] >= 1 )
                                            return emptyBoard;
                                        break;
                                    case PieceE.Knight:
                                    case PieceE.Bishop:
                                    case PieceE.Rook:
                                    case PieceE.Queen:
                                        if( board.PieceCount[ (byte) color, (byte) PieceE.Pawn ] +
                                            board.PieceCount[ (byte) color, (byte) PieceE.Knight ] +
                                            board.PieceCount[ (byte) color, (byte) PieceE.Bishop ] +
                                            board.PieceCount[ (byte) color, (byte) PieceE.Rook ] +
                                            board.PieceCount[ (byte) color, (byte) PieceE.Queen ]
                                            >= 15 )
                                        {
                                            return emptyBoard;
                                        }
                                        break;
                                }

                                board.PutPiece(piece, sqr);   // put the piece on board
                            }
                        }
                        else
                            return emptyBoard;

                        ++offsetFile;
                    }
                }

                if( offsetFile == 0 ) // Allow null lines = /8/
                    offsetFile = File.Files;

                if( offsetFile != File.Files )
                    return emptyBoard;

                baseSqr -= File.Files;
            }

            for( ColorE color = ColorE.White; color <= ColorE.Black; ++color )
            {
                Bitboard occupy = board.Occupies[ (byte) color ];
                // check too many total pieces
                if( BitBoard.CountSets(occupy) > 16 )
                    return emptyBoard;

                // check if the number of Pawns plus the number of extra Queens, Rooks, Bishops, Knights
                // (which can result only by promotion) exceeds 8

                // check too many color pieces
                if( board.PieceCount[ (byte) color, (byte) PieceE.Pawn ] +
                    Math.Max(board.PieceCount[ (byte) color, (byte) PieceE.Knight ] - 2, 0) +
                    Math.Max(board.PieceCount[ (byte) color, (byte) PieceE.Bishop ] - 2, 0) +
                    Math.Max(board.PieceCount[ (byte) color, (byte) PieceE.Rook ] - 2, 0) +
                    Math.Max(board.PieceCount[ (byte) color, (byte) PieceE.Queen ] - 1, 0)
                    > 8 )
                {
                    return emptyBoard;
                }

                if( board.PieceCount[ (byte) color, (byte) PieceE.Bishop ] > 1 )
                {
                    Bitboard bishops = occupy & board.Pieces[ (byte) PieceE.Bishop ];

                    byte[] bishopCount = new byte[ Color.Colors ];

                    //SquareE[] square = BitBoard.GetSquares(occupy & board.Pieces[ (byte) PieceE.Bishop ]);
                    //foreach( SquareE sqr in square )
                    //    ++bishopCount[ (byte) Square._Color(sqr) ];

                    bishopCount[ (byte) ColorE.White ] = BitBoard.CountSets(BitBoard.LightSquares & bishops);
                    bishopCount[ (byte) ColorE.Black ] = BitBoard.CountSets(BitBoard.DarkSquares & bishops);

                    if( board.PieceCount[ (byte) color, (byte) PieceE.Pawn ] +
                        Math.Max(bishopCount[ (byte) ColorE.White ] - 1, 0) +
                        Math.Max(bishopCount[ (byte) ColorE.Black ] - 1, 0)
                        > 8 )
                    {
                        return emptyBoard;
                    }
                }

                // check for King
                byte king = board.PieceCount[ (byte) color, (byte) PieceE.King ];
                if( king != 1 ) //Illegal King
                    return emptyBoard;
            }
            #endregion

            if( numRecord > 1 )
            {
                #region Active color

                string aColor = records[ 1 ];
                if( string.IsNullOrEmpty(aColor) || aColor.Length != 1 )
                    return emptyBoard;

                char activeColor = char.ToLower(aColor[ 0 ]);
                if( activeColor == 'w' )
                    board.OnMove = ColorE.White;
                else if( activeColor == 'b' )
                    board.OnMove = ColorE.Black;
                else
                {
                    board.OnMove = ColorE.NoColor;
                    return emptyBoard;
                }
                #endregion
            }

            if( numRecord > 2 )
            {
                #region Castling privileges

                string castles = records[ 2 ];
                if( string.IsNullOrEmpty(castles) )
                    return emptyBoard;

                if( castles == "-" )
                {
                    board.Castle[ (byte) ColorE.White ].AnyCastle = false;
                    board.Castle[ (byte) ColorE.Black ].AnyCastle = false;
                }
                else
                {
                    int length = castles.Length;
                    if( length > 4 )
                        return emptyBoard;

                    for( byte i = 0; i < length - 1; ++i )
                    {
                        for( byte j = (byte) (i + 1); j < length; ++j )
                        {
                            if( castles[ i ] == castles[ j ] )
                                return emptyBoard;
                        }
                    }

                    foreach( char castle in castles )
                    {
                        switch( castle )
                        {
                            case 'K':
                                {
                                    Bitboard occupy = board.Occupies[ (byte) ColorE.White ];
                                    if( BitBoard.GetSquare(occupy & board.Pieces[ (byte) PieceE.King ], SquareE.E1) &&
                                        BitBoard.GetSquare(occupy & board.Pieces[ (byte) PieceE.Rook ], SquareE.H1) )
                                        board.Castle[ (byte) ColorE.White ].ShortCastle = true;
                                    else
                                        return emptyBoard;
                                } break;
                            case 'Q':
                                {
                                    Bitboard occupy = board.Occupies[ (byte) ColorE.White ];
                                    if( BitBoard.GetSquare(occupy & board.Pieces[ (byte) PieceE.King ], SquareE.E1) &&
                                        BitBoard.GetSquare(occupy & board.Pieces[ (byte) PieceE.Rook ], SquareE.A1) )
                                        board.Castle[ (byte) ColorE.White ].LongCastle = true;
                                    else
                                        return emptyBoard;
                                } break;
                            case 'k':
                                {
                                    Bitboard occupy = board.Occupies[ (byte) ColorE.Black ];
                                    if( BitBoard.GetSquare(occupy & board.Pieces[ (byte) PieceE.King ], SquareE.E8) &&
                                        BitBoard.GetSquare(occupy & board.Pieces[ (byte) PieceE.Rook ], SquareE.H8) )
                                        board.Castle[ (byte) ColorE.Black ].ShortCastle = true;
                                    else
                                        return emptyBoard;
                                } break;
                            case 'q':
                                {
                                    Bitboard occupy = board.Occupies[ (byte) ColorE.Black ];
                                    if( BitBoard.GetSquare(occupy & board.Pieces[ (byte) PieceE.King ], SquareE.E8) &&
                                        BitBoard.GetSquare(occupy & board.Pieces[ (byte) PieceE.Rook ], SquareE.A8) )
                                        board.Castle[ (byte) ColorE.Black ].LongCastle = true;
                                    else
                                        return emptyBoard;
                                } break;
                            default:
                                return emptyBoard;
                        }
                    }
                }
                #endregion
            }

            if( numRecord > 3 )
            {
                #region EnPassant Target square

                string epSqr = records[ 3 ];
                if( string.IsNullOrEmpty(epSqr) )
                    return emptyBoard;

                if( epSqr == "-" )
                    board.EnPassant = SquareE.NoSquare;
                else
                {
                    if( epSqr.Length != 2 )
                        return emptyBoard;

                    char epFile = char.ToLower(epSqr[ 0 ]);
                    if( !(epFile >= 'a' && epFile <= 'h') )
                        return emptyBoard;

                    char epRank = epSqr[ 1 ];
                    if( !(epRank == '3' || epRank == '6') )
                        return emptyBoard;

                    if( epRank == '3' &&
                        (
                        board.OnMove != ColorE.Black ||
                        !BitBoard.GetSquare(board.Occupies[ (byte) ColorE.White ] & board.Pieces[ (byte) PieceE.Pawn ], Square._Square(epFile, (char) (epRank + 1)))
                        )
                        ||
                        epRank == '6' &&
                        (
                        board.OnMove != ColorE.White ||
                        !BitBoard.GetSquare(board.Occupies[ (byte) ColorE.Black ] & board.Pieces[ (byte) PieceE.Pawn ], Square._Square(epFile, (char) (epRank - 1)))
                        )
                      )
                    {
                        return emptyBoard;
                    }

                    board.EnPassant = Square._Square(epFile, epRank);
                }
                #endregion
            }

            if( numRecord > 4 )
            {
                #region HalfMove Clock (Ply)

                byte halfMoveClock;
                if( !byte.TryParse(records[ 4 ], out halfMoveClock) )
                    return emptyBoard;

                if( halfMoveClock > 100 )
                    return emptyBoard;

                board.HalfMoveClock = halfMoveClock;
                #endregion
            }

            if( numRecord > 5 )
            {
                #region FullMove Counter

                ushort fullMoveCount;
                if( !ushort.TryParse(records[ 5 ], out fullMoveCount) )
                    return emptyBoard;

                if( fullMoveCount == 0 ) fullMoveCount = 1;
                board.FullMoveCount = fullMoveCount;
                #endregion
            }

            return board;
        }

        internal static string ToString( Board board )
        {
            if( board == default(Board) )
            {
                Debug.Assert(false, "Null or Empty FEN");
                return string.Empty;
            }

            StringBuilder fenString = new StringBuilder();

            #region Pieces
            for( RankE rank = RankE.Rank_8; ; --rank )
            {
                byte emptySqr = 0;
                for( FileE file = FileE.File_A; file <= FileE.File_H; ++file )
                {
                    bool isPiece = false;
                    for( ColorE color = ColorE.White; color <= ColorE.Black; ++color )
                    {
                        Bitboard occupy = board.Occupies[ (byte) color ];
                        SquareE sqr = Square._Square(file, rank);
                        if( BitBoard.GetSquare(occupy, sqr) )
                        {
                            for( PieceE type = PieceE.Pawn; type <= PieceE.King; ++type )
                            {
                                Bitboard piece = board.Pieces[ (byte) type ];
                                if( BitBoard.GetSquare(piece, sqr) ) // occupy & piece 
                                {
                                    isPiece = true;
                                    if( emptySqr > 0 )
                                    {
                                        fenString.Append(emptySqr);
                                        emptySqr = 0;
                                    }
                                    fenString.Append(Piece.mapPiece[ (byte) color, (byte) type ]);
                                    break;
                                }

                            }
                        }
                    }
                    if( !isPiece )
                        ++emptySqr;
                }
                if( emptySqr > 0 )
                {
                    fenString.Append(emptySqr);
                    emptySqr = 0;
                }

                if( rank == RankE.Rank_1 )
                    break;

                fenString.Append(rankSep);
            }
            #endregion

            fenString.Append(recordSep);

            #region OnMove
            switch( board.OnMove )
            {
                case ColorE.White: fenString.Append('w'); break;
                case ColorE.Black: fenString.Append('b'); break;
                case ColorE.NoColor:
                default: fenString.Append('-'); break;
            }
            #endregion

            fenString.Append(recordSep);

            #region Castle
            if( board.Castle[ (byte) ColorE.White ].AnyCastle ||
                board.Castle[ (byte) ColorE.Black ].AnyCastle )
            {
                if( board.Castle[ (byte) ColorE.White ].ShortCastle ) fenString.Append('K');
                if( board.Castle[ (byte) ColorE.White ].LongCastle ) fenString.Append('Q');
                if( board.Castle[ (byte) ColorE.Black ].ShortCastle ) fenString.Append('k');
                if( board.Castle[ (byte) ColorE.Black ].LongCastle ) fenString.Append('q');
            }
            else
                fenString.Append('-');
            #endregion

            fenString.Append(recordSep);

            #region EnPassant

            SquareE ep = board.EnPassant;
            if( Square.IsValid(ep) )
                fenString.Append(ep.ToString().ToLower());
            else
                fenString.Append('-');
            #endregion

            fenString.Append(recordSep);

            #region HalfMove Clock

            fenString.Append(board.HalfMoveClock);
            #endregion

            fenString.Append(recordSep);

            #region FullMove Counter

            fenString.Append(board.FullMoveCount);
            #endregion

            return fenString.ToString();
        }
    }
}
