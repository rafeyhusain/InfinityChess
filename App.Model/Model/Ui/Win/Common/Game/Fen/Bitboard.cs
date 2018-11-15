using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace App.Model.Fen
{
    using Bitboard = UInt64;
    

    static partial class BitBoard
    {

        static BitBoard()
        {
            InitBitboards();
            //TestSquareOperations();
        }

        #region Squares

        internal static Bitboard SquareMask( SquareE sqr )
        {
            Debug.Assert(Square.IsValid(sqr), "Not 0-3F");
            return 0x01UL << (byte) sqr;
        }

        internal static bool GetSquare( Bitboard bb, SquareE sqr ) { return (bb & SquareMask(sqr)) != EmptySquares; }

        internal static Bitboard SetSquare( ref Bitboard bb, SquareE sqr ) { return bb |= SquareMask(sqr); }
        internal static Bitboard SetSquares( ref Bitboard bb, params SquareE[] squares )
        {
            foreach( SquareE sqr in squares )
                bb |= SquareMask(sqr);
            return bb;
        }

        internal static Bitboard RstSquare( ref Bitboard bb, SquareE sqr ) { return bb &= ~SquareMask(sqr); }
        internal static Bitboard RstSquares( ref Bitboard bb, params SquareE[] squares )
        {
            foreach( SquareE sqr in squares )
                bb &= ~SquareMask(sqr);
            return bb;
        }

        internal static Bitboard MoveSquare( ref Bitboard bb, SquareE sqr1, SquareE sqr2 )
        {
            return bb =
                GetSquare(bb, sqr1)
              ? bb ^ (SquareMask(sqr1) | SquareMask(sqr2)) // right
              : (bb & ~SquareMask(sqr2));
        }

        internal static Bitboard IncludeSquares( ref Bitboard bb, Bitboard include ) { return bb |= include; }
        internal static Bitboard ExcludeSquares( ref Bitboard bb, Bitboard exclude ) { return bb &= ~exclude; }
        #endregion

        #region Files

        internal static byte FileIndex( SquareE sqr )
        {
            Debug.Assert(Square.IsValid(sqr), "Not 0-3F");
            return (byte) ((byte) sqr & 0x07);
        }

        internal static Bitboard RstFile( ref Bitboard bb, SquareE sqr ) { return bb &= ~FileMask(sqr); }

        //// Translate a single bit into a File coordinate.
        //// Single bit set representing piece on board
        //internal static byte GetBitFile( Bitboard sqr )
        //{
        //    if( (File_H & sqr) != 0 ) return 7;
        //    if( (File_G & sqr) != 0 ) return 6;
        //    if( (File_F & sqr) != 0 ) return 5;
        //    if( (File_E & sqr) != 0 ) return 4;
        //    if( (File_D & sqr) != 0 ) return 3;
        //    if( (File_C & sqr) != 0 ) return 2;
        //    if( (File_B & sqr) != 0 ) return 1;
        //    if( (File_A & sqr) != 0 ) return 0;
        //    return 8;
        //}

        internal static byte FileDistance( SquareE bit1, SquareE bit2 )
        {
            return (byte) Math.Abs((byte) Square._File(bit1) - (byte) Square._File(bit2));
        }
        #endregion

        #region Ranks

        internal static byte RankIndex( SquareE sqr )
        {
            Debug.Assert(Square.IsValid(sqr), "Not 0-3F");
            return (byte) ((byte) sqr & 0x38);
        }

        internal static Bitboard RstRank( ref Bitboard bb, SquareE sqr ) { return bb &= ~RankMask(sqr); }

        //// Translate a bit into a Rank coordinate.
        //// Single bit set representing piece on board
        //internal static byte GetBitRank( Bitboard sqr )
        //{
        //    if( (Rank_8 & sqr) != 0 ) return 7;
        //    if( (Rank_7 & sqr) != 0 ) return 6;
        //    if( (Rank_6 & sqr) != 0 ) return 5;
        //    if( (Rank_5 & sqr) != 0 ) return 4;
        //    if( (Rank_4 & sqr) != 0 ) return 3;
        //    if( (Rank_3 & sqr) != 0 ) return 2;
        //    if( (Rank_2 & sqr) != 0 ) return 1;
        //    if( (Rank_1 & sqr) != 0 ) return 0;
        //    return 8;
        //}
        //internal static byte GetRank( Bitboard bb, SquareE sqr ) { return (byte) ((bb >> RankIndex(sqr)) & 0xFF); }
        //internal static Bitboard SetRank( ref Bitboard bb, SquareE sqr, byte row )
        //{
        //    RstRank(ref bb, sqr);  // clear to insert fresh rank
        //    return bb |= (Bitboard) row << RankIndex(sqr);
        //}

        internal static byte RankDistance( SquareE sqr1, SquareE sqr2 )
        {
            return (byte) Math.Abs((byte) Square._Rank(sqr1) - (byte) Square._Rank(sqr2));
        }
        #endregion

        #region Diagonals

        // DiagA1H8Index {0..15} = (rankIndex - fileIndex) & 0x0F;
        // \f  0  1  2  3  4  5  6  7
        // r_________________________
        // 7 | 7  6  5  4  3  2  1  0
        // 6 | 6  5  4  3  2  1  0 15
        // 5 | 5  4  3  2  1  0 15 14
        // 4 | 4  3  2  1  0 15 14 13
        // 3 | 3  2  1  0 15 14 13 12
        // 2 | 2  1  0 15 14 13 12 11
        // 1 | 1  0 15 14 13 12 11 10
        // 0 | 0 15 14 13 12 11 10  9

        internal static byte DiagA1H8Index( SquareE sqr )
        {
            return (byte) (((RankIndex(sqr) >> 3) - FileIndex(sqr)) & 0x0F);
        }

        // DiagA8H1Index {0..15} = (rankIndex + fileIndex) ^ 0x07;
        // \f  0  1  2  3  4  5  6  7
        // r_________________________
        // 7 | 0 15 14 13 12 11 10  9
        // 6 | 1  0 15 14 13 12 11 10
        // 5 | 2  1  0 15 14 13 12 11
        // 4 | 3  2  1  0 15 14 13 12
        // 3 | 4  3  2  1  0 15 14 13
        // 2 | 5  4  3  2  1  0 15 14
        // 1 | 6  5  4  3  2  1  0 15
        // 0 | 7  6  5  4  3  2  1  0

        internal static byte DiagA8H1Index( SquareE sqr )
        {
            return (byte) (((RankIndex(sqr) >> 3) + FileIndex(sqr)) ^ 0x07);
        }

        #endregion

        #region Masks

        internal static Bitboard RankMask( SquareE sqr )
        {
            Debug.Assert(Square.IsValid(sqr), "Not 0-3F");
            return Rank_1 << RankIndex(sqr);
        }

        internal static Bitboard RankExMask( SquareE sqr ) { return RankMask(sqr) ^ SquareMask(sqr); }

        internal static Bitboard FileMask( SquareE sqr )
        {
            Debug.Assert(Square.IsValid(sqr), "Not 0-3F");
            return File_A << FileIndex(sqr);
        }

        internal static Bitboard FileExMask( SquareE sqr ) { return FileMask(sqr) ^ SquareMask(sqr); }

        internal static Bitboard EastExMask( SquareE sqr )
        {
            const Bitboard A1 = 0x0000000000000001;//File_A & Rank_1;
            return ((A1 << ((byte) sqr | 0x07)) - (A1 << (byte) sqr)) << 1;
        }

        internal static Bitboard WestExMask( SquareE sqr )
        {
            const Bitboard A1 = 0x0000000000000001;//File_A & Rank_1;
            return (A1 << (byte) sqr) - (A1 << ((byte) sqr & 0x38));
        }

        internal static Bitboard NortExMask( SquareE sqr )
        {
            const Bitboard fileA_1 = 0x0101010101010100;//File_A & ~Rank_1;
            return fileA_1 << (byte) sqr;
        }

        internal static Bitboard SoutExMask( SquareE sqr )
        {
            const Bitboard fileH_8 = 0x0080808080808080;//File_H & ~Rank_8;
            return fileH_8 >> ((byte) sqr ^ 0xFF);
        }

        internal static Bitboard DiagA1H8Mask( SquareE sqr )
        {
            Debug.Assert(Square.IsValid(sqr), "Not 0-3F");
            sbyte diag = (sbyte) (0x00 + (FileIndex(sqr) << 3) - RankIndex(sqr));
            byte nort = (byte) (-diag & (diag >> 31));
            byte sout = (byte) (diag & (-diag >> 31));
            return (DiagA1H8Squares >> sout) << nort;
        }

        internal static Bitboard DiagA8H1Mask( SquareE sqr )
        {
            Debug.Assert(Square.IsValid(sqr), "Not 0-3F");
            sbyte diag = (sbyte) (0x38 - (FileIndex(sqr) << 3) - RankIndex(sqr));
            byte nort = (byte) (-diag & (diag >> 31));
            byte sout = (byte) (diag & (-diag >> 31));
            return (DiagA8H1Squares >> sout) << nort;
        }

        internal static Bitboard DiagA1H8ExMask( SquareE sqr ) { return DiagA1H8Mask(sqr) ^ SquareMask(sqr); }

        internal static Bitboard DiagA8H1ExMask( SquareE sqr ) { return DiagA8H1Mask(sqr) ^ SquareMask(sqr); }

        #region Extra
        //internal static Bitboard SingleLaneMask( Bitboard legalSquares, Bitboard obstacles, byte square, sbyte offset )
        //{
        //    Bitboard laneMask = EmptySquares, min = EmptySquares;
        //    // square >= (byte) SquareE.A1 && square <= (byte) SquareE.H8
        //    for( square += (byte) offset; Square.IsValid(square); square += (byte) offset )
        //    {
        //        min = _MinValue[ square ];
        //        if( (min & legalSquares) == EmptySquares ) break;
        //        laneMask |= min;
        //        if( (min & obstacles) != EmptySquares )
        //            break;
        //    }
        //    return laneMask;
        //}

        //internal static Bitboard HLaneMask( byte occ, byte square )
        //{
        //    byte rank = (byte) Square.GetRank(square);
        //    Bitboard legalSquares = HLaneVector(0xFF, rank);
        //    Bitboard obstacles = HLaneVector(occ, rank);
        //    return SingleLaneMask(legalSquares, obstacles, square, 1)
        //         | SingleLaneMask(legalSquares, obstacles, square, -1);
        //}

        //internal static Bitboard HLaneVector( byte occ, byte rank )
        //{
        //    Bitboard vector = EmptySquares;
        //    for( byte i = 0; i < File.Files; ++i )
        //    {
        //        if( (occ & _MinValue[ i ]) != 0 )
        //        {
        //            vector |= _MinValue[ File.Files - 1 - i ];
        //        }
        //    }
        //    vector <<= (rank << 3);
        //    return vector;
        //}

        //internal static Bitboard VLaneVector( byte occ, byte file )
        //{
        //    Bitboard vector = EmptySquares;
        //    for( byte i = 0; i < File.Files; ++i )
        //    {
        //        if( (occ & _MinValue[ i ]) != 0 )
        //        {
        //            vector |= _MinValue[ (File.Files - 1 - i) << 3 ];
        //        }
        //    }
        //    vector <<= file;
        //    return vector;
        //} 
        #endregion
        #endregion

        #region Direction
        //internal static Bitboard SoutX( Bitboard bb, byte x ) { return bb >> (x << 0x03); }
        //internal static Bitboard NortX( Bitboard bb, byte x ) { return bb << (x << 0x03); }

        internal static Bitboard Sout( Bitboard bb ) { return bb >> 8; } //SoutX(bb, 1);
        internal static Bitboard Nort( Bitboard bb ) { return bb << 8; } //NortX(bb, 1); 

        internal static Bitboard East( Bitboard bb ) { return (bb & File_NotH) << 1; } //(bb << 1) & File_NotA;
        internal static Bitboard West( Bitboard bb ) { return (bb & File_NotA) >> 1; } //(bb >> 1) & File_NotH;

        internal static Bitboard NoEa( Bitboard bb ) { return (bb & File_NotH) << 9; } //(bb << 9) & File_NotA;
        internal static Bitboard SoEa( Bitboard bb ) { return (bb & File_NotH) >> 7; } //(bb >> 7) & File_NotA;
        internal static Bitboard SoWe( Bitboard bb ) { return (bb & File_NotA) >> 9; } //(bb >> 9) & File_NotH
        internal static Bitboard NoWe( Bitboard bb ) { return (bb & File_NotA) << 7; } //(bb << 7) & File_NotH;
        #endregion

        #region Fills  [Empty Fill (Kogge-Stone Algorithm)]

        internal static Bitboard NortFill( Bitboard bb )
        {
            bb |= (bb << 0x08);
            bb |= (bb << 0x10);
            bb |= (bb << 0x20);
            return bb;
        }
        internal static Bitboard SoutFill( Bitboard bb )
        {
            bb |= (bb >> 0x08);
            bb |= (bb >> 0x10);
            bb |= (bb >> 0x20);
            return bb;
        }

        internal static Bitboard FilesFill( Bitboard bb ) { return NortFill(bb) | SoutFill(bb); }
        internal static Bitboard HalfOrFullOpenFiles( Bitboard bb ) { return ~FilesFill(bb); }

        internal static Bitboard EastFill( Bitboard bb )
        {
            const Bitboard A1 = File_NotA;
            const Bitboard A2 = A1 & (A1 << 1);
            const Bitboard A4 = A2 & (A2 << 2);
            bb |= A1 & (bb << 0x01);
            bb |= A2 & (bb << 0x02);
            bb |= A4 & (bb << 0x04);
            return bb;
        }
        internal static Bitboard WestFill( Bitboard bb )
        {
            const Bitboard H1 = File_NotH;
            const Bitboard H2 = H1 & (H1 >> 1);
            const Bitboard H4 = H2 & (H2 >> 2);
            bb |= H1 & (bb >> 0x01);
            bb |= H2 & (bb >> 0x02);
            bb |= H4 & (bb >> 0x04);
            return bb;
        }

        internal static Bitboard RanksFill( Bitboard bb ) { return EastFill(bb) | WestFill(bb); }
        internal static Bitboard HalfOrFullOpenRanks( Bitboard bb ) { return ~RanksFill(bb); }

        internal static Bitboard NoEaFill( Bitboard bb )
        {
            const Bitboard AL1 = File_NotA;
            const Bitboard AL2 = AL1 & (AL1 << 0x09);
            const Bitboard AL4 = AL2 & (AL2 << 0x12);
            bb |= AL1 & (bb << 0x09);
            bb |= AL2 & (bb << 0x12);
            bb |= AL4 & (bb << 0x24);
            return bb;
        }
        internal static Bitboard SoEaFill( Bitboard bb )
        {
            const Bitboard AR1 = File_NotA;
            const Bitboard AR2 = AR1 & (AR1 >> 0x07);
            const Bitboard AR4 = AR2 & (AR2 >> 0x0E);
            bb |= AR1 & (bb >> 0x07);
            bb |= AR2 & (bb >> 0x0E);
            bb |= AR4 & (bb >> 0x1C);
            return bb;
        }
        internal static Bitboard SoWeFill( Bitboard bb )
        {
            const Bitboard HR1 = File_NotH;
            const Bitboard HR2 = HR1 & (HR1 >> 0x09);
            const Bitboard HR4 = HR2 & (HR2 >> 0x12);
            bb |= HR1 & (bb >> 0x09);
            bb |= HR2 & (bb >> 0x12);
            bb |= HR4 & (bb >> 0x24);
            return bb;
        }
        internal static Bitboard NoWeFill( Bitboard bb )
        {
            const Bitboard HL1 = File_NotH;
            const Bitboard HL2 = HL1 & (HL1 << 0x07);
            const Bitboard HL4 = HL2 & (HL2 << 0x0E);
            bb |= HL1 & (bb << 0x07);
            bb |= HL2 & (bb << 0x0E);
            bb |= HL4 & (bb << 0x1C);
            return bb;
        }
        #endregion

        #region Shift & Rotate

        internal static Bitboard RotateLeft( Bitboard bb, sbyte shift )
        {
            byte dataSize = 0x40; //sizeof(Bitboard) << 3;
            return
                //GenShift(bb, (sbyte) shift) | GenShift(bb, (sbyte) (shift - dataSize));
                (bb << shift) | (bb >> (dataSize - shift));
        }

        internal static Bitboard RotateRight( Bitboard bb, sbyte shift )
        {
            byte dataSize = 0x40; //sizeof(Bitboard) << 3;
            return
                //GenShift(bb, (sbyte) (-shift)) | GenShift(bb, (sbyte) (dataSize - shift));
                (bb >> shift) | (bb << (dataSize - shift));
        }

        internal static Bitboard GenShift( Bitboard bb, sbyte shift )
        {
            //byte left = (byte) shift;
            //sbyte right = -((byte) (shift >> 8) & left);
            //return (bb >> right) << (right + left);

            return (shift > 0) ? (bb << shift) : (bb >> -shift);
        }

        #region //Shift
        //internal const byte direction = 8;
        //internal static sbyte[] Shifts = new sbyte[ direction ]
        //{
        //    9, 1, -7, -8, -9, -1, 7, 8 
        //};

        //internal static Bitboard[] AvoidWraps = new Bitboard[ direction ]
        //{                        // (Full)
        //    0xFEFEFEFEFEFEFE00,  // NoEaOne
        //    0xFEFEFEFEFEFEFEFE,  // EastOne
        //    0x00FEFEFEFEFEFEFE,  // SoEaOne
        //    0x00FFFFFFFFFFFFFF,  // SoutOne
        //    0x007F7F7F7F7F7F7F,  // SoWeOne
        //    0x7F7F7F7F7F7F7F7F,  // WestOne
        //    0x7F7F7F7F7F7F7F00,  // NoWeOne
        //    0xFFFFFFFFFFFFFF00,  // NortOne
        //};

        //internal static Bitboard Shift( Bitboard bb, int dir8 )
        //{
        //    return RotateLeft(bb, Shifts[ dir8 ]) & AvoidWraps[ dir8 ];
        //} 
        #endregion


        #endregion

        #region Flip & Mirror

        internal static Bitboard FlipVertical( Bitboard bb )
        {
            //return (bb << 0x38) //& 0xFF00000000000000   //0x38 = 56
            //     | (bb << 0x28) & 0x00FF000000000000     //0x28 = 40
            //     | (bb << 0x18) & 0x0000FF0000000000     //0x18 = 24
            //     | (bb << 0x08) & 0x000000FF00000000     //0x08 = 08
            //     | (bb >> 0x08) & 0x00000000FF000000     //0x08 = 08
            //     | (bb >> 0x18) & 0x0000000000FF0000     //0x18 = 24
            //     | (bb >> 0x28) & 0x000000000000FF00     //0x28 = 40
            //     | (bb >> 0x38) //& 0x00000000000000FF   //0x38 = 56
            //     ;

            bb = ((bb >> S[ 3 ]) & B[ 3 ]) | ((bb & B[ 3 ]) << S[ 3 ]);
            bb = ((bb >> S[ 4 ]) & B[ 4 ]) | ((bb & B[ 4 ]) << S[ 4 ]);
            bb = ((bb >> S[ 5 ]) & B[ 5 ]) | ((bb & B[ 5 ]) << S[ 5 ]);
            return bb;
        }

        internal static Bitboard MirrorHorizontal( Bitboard bb )
        {
            //bb ^= B[ 2 ] & (bb ^ RotateLeft(bb, S[ 3 ]));
            //bb ^= B[ 1 ] & (bb ^ RotateLeft(bb, S[ 2 ]));
            //bb ^= B[ 0 ] & (bb ^ RotateLeft(bb, S[ 1 ]));
            //bb = RotateRight(bb, S[ 0 ] + S[ 1 ] + S[ 2 ]); //(bb, 7 );

            bb = ((bb >> S[ 0 ]) & B[ 0 ]) | ((bb & B[ 0 ]) << S[ 0 ]);
            bb = ((bb >> S[ 1 ]) & B[ 1 ]) | ((bb & B[ 1 ]) << S[ 1 ]);
            bb = ((bb >> S[ 2 ]) & B[ 2 ]) | ((bb & B[ 2 ]) << S[ 2 ]);

            return bb;
        }

        internal static Bitboard FlipMirrorOrReverse( Bitboard bb, bool flip, bool mirror )
        {
            byte start = mirror ? (byte) 0 : (byte) 3;
            byte stop = flip ? (byte) 6 : (byte) 3;
            for( byte i = start; i < stop; ++i )
            {
                byte s = (byte) (1 << i);                       // Shift    s(i) := 1 << i
                Bitboard f = (Bitboard) 1 << s;                 // Factor   f(i) := 1 << s(i)
                Bitboard k = 0xFFFFFFFFFFFFFFFF / (f + 1);      // Mask     k(i) := -1 / (f(i) + 1)
                bb = ((bb >> s) & k) + f * (bb & k);
            }
            return bb;
        }

        internal static Bitboard FlipDiagA1H8( Bitboard bb )
        {
            const Bitboard B1 = 0x5500550055005500;
            const Bitboard B2 = 0x3333000033330000;
            const Bitboard B4 = 0x0F0F0F0F00000000;
            Bitboard tt;
            tt = B4 & (bb ^ (bb << 0x1C));
            bb ^= tt ^ (tt >> 0x1C);
            tt = B2 & (bb ^ (bb << 0x0E));
            bb ^= tt ^ (tt >> 0x0E);
            tt = B1 & (bb ^ (bb << 0x07));
            bb ^= tt ^ (tt >> 0x07);
            return bb;
        }

        internal static Bitboard FlipDiagA8H1( Bitboard bb )
        {
            const Bitboard B1 = 0xAA00AA00AA00AA00;
            const Bitboard B2 = 0xCCCC0000CCCC0000;
            const Bitboard B4 = 0xF0F0F0F00F0F0F0F;
            Bitboard tt;
            tt = bb ^ (bb << 0x24);
            bb ^= B4 & (tt ^ (bb >> 0x24));
            tt = B2 & (bb ^ (bb << 0x12));
            bb ^= tt ^ (tt >> 0x12);
            tt = B1 & (bb ^ (bb << 0x09));
            bb ^= tt ^ (tt >> 0x09);
            return bb;
        }

        #endregion

        internal static SquareE[] GetSquares( Bitboard bb )
        {
            List<SquareE> square = new List<SquareE>();
            for( SquareE sqr = SquareE.A1; sqr <= SquareE.H8; ++sqr )
            {
                if( GetSquare(bb, sqr) )
                    square.Add(sqr);
            }
            return square.ToArray();
        }

        internal static Bitboard Reverse( Bitboard bb )
        {
            bb = ((bb >> S[ 0 ]) & B[ 0 ]) | ((bb & B[ 0 ]) << S[ 0 ]);// swap odd and even bits
            bb = ((bb >> S[ 1 ]) & B[ 1 ]) | ((bb & B[ 1 ]) << S[ 1 ]);// swap consecutive pairs
            bb = ((bb >> S[ 2 ]) & B[ 2 ]) | ((bb & B[ 2 ]) << S[ 2 ]);// swap nibbles ... 
            bb = ((bb >> S[ 3 ]) & B[ 3 ]) | ((bb & B[ 3 ]) << S[ 3 ]);// swap bytes
            bb = ((bb >> S[ 4 ]) & B[ 4 ]) | ((bb & B[ 0 ]) << S[ 4 ]);// swap 2-byte long pairs
            bb = (bb >> S[ 5 ]) | (bb << S[ 5 ]);                      // swap 4-byte longlong pairs
            return bb;
        }

        internal static byte ReverseByte( byte b )
        {
            //// swap and merge
            //b = (byte) (((b >> 01) & 0x55) | ((b & 0x55) << 01)); // swap odd and even bits
            //b = (byte) (((b >> 02) & 0x33) | ((b & 0x33) << 02)); // swap consecutive pairs
            //b = (byte) (b >> 04 | b << 04);                       // swap nibles ... 
            //return b;

            //// 7 Operarions (no division, no 64-bit)
            //return (byte) (((b * 0x0802U & 0x22110U) | (b * 0x8020U & 0x88440U)) * 0x10101U >> 0x10);
            //// 4 Operarions (no division, 64-bit multiply)
            //return (byte) (((b * 0x0080200802UL) & 0x0884422110U) * 0x0101010101U >> 0x20);


            //// 3 Operarions (64-bit multiply & modulus division)
            return (byte) ((b * 0x0202020202U & 0x010884422010U) % 0x3FF); // 1023
        }


        //#region Rotated Bitboard

        //internal static byte[] DiagIndex =
        //    {
        //        00,   01,   03,   06,   10,   15,   21,   28,   36,   43,   49,   54,   58,   61,   63
        //    };

        //internal static BitRank[] DiagMask = 
        //    {
        //        0x01, 0x03, 0x07, 0x0F, 0x1F, 0x3F, 0x7F, 0xFF, 0x7F, 0x3F, 0x1F, 0x0F, 0x07, 0x03, 0x01
        //    };


        //// These functions manipulate adjacent bits in 45° rotated BitBoards,
        //// which correspond to diagonals in 0° and 90° rotated BitBoards.
        //internal static byte GetDiagIndex( int n )
        //{
        //    return DiagIndex[ n ];
        //}

        //internal static Bitboard MaskDiag( byte n )
        //{
        //    return ((Bitboard) DiagMask[ n ]) << DiagIndex[ n ];
        //}

        //internal static BitRank GetDiag( Bitboard bb, int n )
        //{
        //    return (BitRank) ((bb >> DiagIndex[ n ]) & DiagMask[ n ]);
        //}

        //internal static Bitboard RstDiag( ref Bitboard bb, byte n )
        //{
        //    return bb &= ~MaskDiag(n);
        //}

        //#endregion


        internal static Bitboard PreMaskExclusions( SquareE sqr )
        {
            if( IsSquareOn(BorderSquares, sqr) )
            {
                Bitboard exclusions = EmptySquares;

                //if( !CheckSquare(SquaresOfFile[ (byte) FileE.File_A ], sqr) ) exclusions |= SquaresOfFile[ (byte) FileE.File_A ];
                //if( !CheckSquare(SquaresOfFile[ (byte) FileE.File_H ], sqr) ) exclusions |= SquaresOfFile[ (byte) FileE.File_H ];
                //if( !CheckSquare(SquaresOfRank[ (byte) RankE.Rank_1 ], sqr) ) exclusions |= SquaresOfRank[ (byte) RankE.Rank_1 ];
                //if( !CheckSquare(SquaresOfRank[ (byte) RankE.Rank_8 ], sqr) ) exclusions |= SquaresOfRank[ (byte) RankE.Rank_8 ];

                if( !IsSquareOn(File_A, sqr) ) exclusions |= File_A;
                if( !IsSquareOn(File_H, sqr) ) exclusions |= File_H;
                if( !IsSquareOn(Rank_1, sqr) ) exclusions |= Rank_1;
                if( !IsSquareOn(Rank_8, sqr) ) exclusions |= Rank_8;

                return exclusions;
            }
            else
                return BorderSquares;
        }
    };
}