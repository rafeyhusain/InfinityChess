using System;
using System.Diagnostics;

namespace App.Model.Fen
{
    using Bitboard = UInt64;

    static partial class BitBoard
    {

        internal static Bitboard[] _MinValue;
        internal static Bitboard[] _MaxValue;

        const byte   Max08 = 0xFF;
        const ushort Max16 = 0xFFFF;
        const uint   Max32 = 0xFFFFFFFF;

        internal static byte[] _SetCount;
        internal static byte[] _RankOverlay;

        internal static byte[ , ] _BitShiftGap;

        //internal static Bitboard[ , ] _PassedPawnMask;
        //internal static Bitboard[ , ] _OutpostMask;

        internal static void InitBitboards()
        {
            #region //Constants
            //byte i;
            //for( i = 0; i < 0x08; ++i )
            //{
            //    SquaresOfFile[ i ] = SquaresOfRank[ i ] = EmptySquares;
            //}

            //for( SquareE sqr = SquareE.A1; sqr <= SquareE.H8; ++sqr )
            //{
            //    SquaresOfFile[ (byte) Square._File(sqr) ] |= _MinValue[ (byte) sqr ];
            //    SquaresOfRank[ (byte) Square._Rank(sqr) ] |= _MinValue[ (byte) sqr ];
            //}

            //SquaresOfFileRange = new Bitboard[ File.Files, Rank.Ranks ];
            //SquaresOfRankRange = new Bitboard[ File.Files, Rank.Ranks ];
            //for( i = 0; i < 0x08; ++i )
            //{
            //    SquaresOfLateralFiles[ i ] = SquaresOfLateralRanks[ i ] = EmptySquares;

            //    if( i != (byte) FileE.File_A )
            //        SquaresOfLateralFiles[ i ] |= SquaresOfFile[ i - 1 ];
            //    if( i != (byte) FileE.File_H )
            //        SquaresOfLateralFiles[ i ] |= SquaresOfFile[ i + 1 ];
            //    if( i != (byte) RankE.Rank_1 )
            //        SquaresOfLateralRanks[ i ] |= SquaresOfRank[ i - 1 ];
            //    if( i != (byte) RankE.Rank_8 )
            //        SquaresOfLateralRanks[ i ] |= SquaresOfRank[ i + 1 ];

            //    for( byte j = 0; j < 0x08; ++j )
            //    {
            //        SquaresOfFileRange[ i, j ] = SquaresOfRankRange[ i, j ] = EmptySquares;
            //        for( byte k = 0; k < 0x08; k++ )
            //        {
            //            if( (k >= i && k <= j) || (k >= j && k <= i) )
            //            {
            //                SquaresOfFileRange[ i, j ] |= SquaresOfFile[ k ];
            //                SquaresOfRankRange[ i, j ] |= SquaresOfRank[ k ];
            //            }
            //        }
            //    }
            //}

            //File_NotA = ~SquaresOfFile[ (byte) FileE.File_A ];
            //File_NotH = ~SquaresOfFile[ (byte) FileE.File_H ];

            //WhiteSideSquares = SquaresOfRank[ (byte) RankE.Rank_1 ] | SquaresOfRank[ (byte) RankE.Rank_2 ] | SquaresOfRank[ (byte) RankE.Rank_3 ] | SquaresOfRank[ (byte) RankE.Rank_4 ];
            //BlackSideSquares = SquaresOfRank[ (byte) RankE.Rank_5 ] | SquaresOfRank[ (byte) RankE.Rank_6 ] | SquaresOfRank[ (byte) RankE.Rank_7 ] | SquaresOfRank[ (byte) RankE.Rank_8 ];

            //QueenSideSquares = SquaresOfFile[ (byte) FileE.File_A ] | SquaresOfFile[ (byte) FileE.File_B ] | SquaresOfFile[ (byte) FileE.File_C ] | SquaresOfFile[ (byte) FileE.File_D ];
            //KingSideSquares = SquaresOfFile[ (byte) FileE.File_E ] | SquaresOfFile[ (byte) FileE.File_F ] | SquaresOfFile[ (byte) FileE.File_G ] | SquaresOfFile[ (byte) FileE.File_H ]; 


            //CenterSquares = MinValue[ (byte) SquareE.D4 ] | MinValue[ (byte) SquareE.D5 ] | MinValue[ (byte) SquareE.E4 ] | MinValue[ (byte) SquareE.E5 ];

            //ExpCenterSquares =
            //    (SquaresOfFile[ (byte) FileE.File_C ] | SquaresOfFile[ (byte) FileE.File_D ] |
            //     SquaresOfFile[ (byte) FileE.File_E ] | SquaresOfFile[ (byte) FileE.File_F ])
            //  & (SquaresOfRank[ (byte) RankE.Rank_3 ] | SquaresOfRank[ (byte) RankE.Rank_4 ] |
            //     SquaresOfRank[ (byte) RankE.Rank_5 ] | SquaresOfRank[ (byte) RankE.Rank_6 ]);

            //CornerSquares = (BitBoard.File_A | BitBoard.File_H) & (BitBoard.Rank_1 | BitBoard.Rank_8);
            //BorderSquares = SquaresOfFile[ (byte) FileE.File_A ] | SquaresOfFile[ (byte) FileE.File_H ] | SquaresOfRank[ (byte) RankE.Rank_1 ] | SquaresOfRank[ (byte) RankE.Rank_8 ];
            #endregion

            Bitboard min = 0x01UL;
            _MinValue = new Bitboard[ Square.Squares ];
            _MaxValue = new Bitboard[ Square.Squares ];
            for( SquareE sqr = SquareE.A1; sqr <= SquareE.H8; ++sqr, min <<= 1 )
            {
                _MinValue[ (byte) sqr ] = min;
                _MaxValue[ (byte) sqr ] = ~min;
            }


            _SetCount = new byte[ Max16 + 1 ];
            _RankOverlay = new byte[ Max16 + 1 ];
            for( ushort s = 0; ; ++s )
            {
                _SetCount[ s ] = CountSets(s);
                _RankOverlay[ s ] = RankOverlay(s);

                if( s == Max16 )
                    break;
            }

            _BitShiftGap = new byte[ Max08 + 1, File.Files ];
            for( byte occ = 0; ; ++occ )
            {
                for( byte file = 0; file < File.Files; ++file )
                {

                    //_BitShiftGap[ occ, file ] = (byte) (occ == 0 ? 0 : 8);
                    //for( byte index = 0; index < File.Files; ++index )
                    //{
                    //    if( ((byte) _MinValue[ index ] & occ) != 0 )
                    //    {
                    //        byte value = (byte) Math.Abs(file - index);
                    //        if( value < _BitShiftGap[ occ, file ] )
                    //        {
                    //            _BitShiftGap[ occ, file ] = value;
                    //            if( index > file )
                    //                break;
                    //        }
                    //    }
                    //}


                    if( occ == 0 || ((byte) _MinValue[ file ] & occ) != 0 )
                    {
                        _BitShiftGap[ occ, file ] = 0;
                        continue;
                    }
                    byte westCount = 8;
                    if( file > 0 ) // west
                    {
                        westCount = 1;
                        for( byte west = (byte) (file - 1);
                             west != 0 && ((byte) _MinValue[ west ] & occ) == 0;
                             --west )
                        {
                            //if( west == 0 || ((byte) _MinValue[ west ] & occ) != 0 ) break;
                            ++westCount;
                        }
                    }
                    byte eastCount = 8;
                    if( file < 7 ) // east
                    {
                        eastCount = 1;
                        for( byte east = (byte) (file + 1);
                             east != 7 && ((byte) _MinValue[ east ] & occ) == 0;
                             ++east )
                        {
                            //if( east == 7 || ((byte) _MinValue[ east ] & occ) != 0 ) break;
                            ++eastCount;
                        }
                    }
                    _BitShiftGap[ occ, file ] = Math.Min(westCount, eastCount);

                }


                if( occ == Max08 )
                    break;
            }


            //_PassedPawnMask = new Bitboard[ Color.Colors, Square.Squares ];
            //_OutpostMask = new Bitboard[ Color.Colors, Square.Squares ];
            //for( ColorE color = ColorE.White; color <= ColorE.Black; ++color )
            //{
            //    for( SquareE sqr = SquareE.A1; sqr <= SquareE.H8; ++sqr )
            //    {
            //        _PassedPawnMask[ (byte) color, (byte) sqr ] = FrontRank(color, sqr) & LateralThisFiles(sqr);
            //        _OutpostMask[ (byte) color, (byte) sqr ] = FrontRank(color, sqr) & LateralFiles(sqr);
            //    }
            //}


        }

        // A BitScan Forward is used to find the index of the least significant 1 bit (LS1B). [Least significant one bit]
        // Count Trailing Zero
        internal static byte BitScanForward( Bitboard bb )
        {
            //// [http://chessprogramming.wikispaces.com/BitScan]

            // De Bruijn Multiplication
            // A 64-bit De Bruijn sequence contains 64-overlapped unique 6-bit sequences (a circle of 64 bits)
            // multiply a 64-bit De Bruijn sequence with the isolated LS1B, get a unique six bit subsequence inside the most significant bits (upper 6 bits)
            Debug.Assert(bb != 0, "bitboard is empty");
            if( bb == 0 ) return 64;
            byte[] Debruijn64 = 
            {
                63,  0, 58,  1, 59, 47, 53,  2,
                60, 39, 48, 27, 54, 33, 42,  3,
                61, 51, 37, 40, 49, 18, 28, 20,
                55, 30, 34, 11, 43, 14, 22,  4,
                62, 57, 46, 52, 38, 26, 32, 41,
                50, 36, 17, 19, 29, 10, 13, 21,
                56, 45, 25, 31, 35, 16,  9, 12,
                44, 24, 15,  8, 23,  7,  6,  5
            };
            const Bitboard debruijn64 = 0x07EDD5E59A4E28C2;
            Bitboard LS1B = bb & (ulong) (-(long) bb); //bb & (~bb + 1);
            return Debruijn64[ LS1B * debruijn64 >> 0x3A ]; // LS1BHash6 [0x3A = 58 = 64-6]


            // Bitscan by Modulo
            // modulo operation of the isolated LS1B by the prime number 67. The remainder 0..66 can be used to
            //const byte prime67 = 0x43;
            //sbyte[] lookup67 = new sbyte[ prime67 + 1 ]
            //{
            //  64,  0,  1, 39,  2, 15, 40, 23,
            //   3, 12, 16, 59, 41, 19, 24, 54,
            //   4, -1, 13, 10, 17, 62, 60, 28,
            //  42, 30, 20, 51, 25, 44, 55, 47,
            //   5, 32, -1, 38, 14, 22, 11, 58,
            //  18, 53, 63,  9, 61, 27, 29, 50,
            //  43, 46, 31, 37, 21, 57, 52,  8,
            //  26, 49, 45, 36, 56,  7, 48, 35,
            //   6, 34, 33, -1 
            //};
            //Bitboard LS1B = bb & (ulong) (-(long) bb); //bb & (~bb + 1);
            //return (byte) lookup67[ LS1B % prime67 ];
        }

        // A BitScan Reverse is used to find the index of the most significant 1 bit (MS1B). [Most significant one bit]
        // Count Leading Zero
        internal static byte BitScanReverse( Bitboard bb )
        {
            Debug.Assert(bb != 0, "bitboard is empty");
            if( bb == 0 ) return 64;

            //bb |= (bb >> 1);
            //bb |= (bb >> 2);
            //bb |= (bb >> 4);
            //bb |= (bb >> 8);
            //bb |= (bb >> 16);
            //return (byte) (64 - CountSetBits(bb));


            byte countLead0 = 0;
            if( bb > 0xFFFFFFFF )
            {
                bb >>= 0x20;
                countLead0 += 0x20;
            }
            if( bb > 0xFFFF )
            {
                bb >>= 0x10;
                countLead0 += 0x10;
            }
            if( bb > 0xFF )
            {
                bb >>= 0x08;
                countLead0 += 0x08;
            }
            if( bb > 0x0F )
            {
                bb >>= 0x04;
                countLead0 += 0x04;
            }
            if( bb > 0x03 )
            {
                bb >>= 0x02;
                countLead0 += 0x02;
            }
            return (byte) (countLead0 + (byte) (bb >> 0x01));
        }

        static byte[] BitScanDatabase;

        public static void initializeFirstOne()
        {
            Bitboard bit = 1;
            BitScanDatabase = new byte[ Square.Squares ];
            byte i = 0;
            do
            {
                BitScanDatabase[ (bit * BitBoard.BitScanMagic) >> 58 ] = i;
                i++;
                bit <<= 1;
            }
            while( bit != 0 );
        }


        internal static byte CountSets( Bitboard bb )
        {
            byte countBit1 = 0;

            #region //Loops
            //for( int i = 0; i < 0x40; ++i )
            //{
            //    countBit1 += (byte) ((bb >> i) & 1);
            //} 
            ////-------------------------------
            //while( bb != EmptySquares )
            //{
            //    ++countBit1;
            //    bb &= (bb - 1); // reset LS1B
            //}
            #endregion

            #region //Shifts
            //bb -= ((bb >> S[ 0 ]) & B[ 0 ]); //put count of each 2 bits into those 2 bits // Counting Duo-Bits
            //bb = (bb & B[ 1 ]) + ((bb >> S[ 1 ]) & B[ 1 ]); //put count of each 4 bits into those 4 bits // Counting Nibble-Bits
            //bb = (bb + (bb >> S[ 2 ])) & B[ 2 ];  //put count of each 8 bits into those 8 bits // Counting 8-Bits (Byte) 

            ///// using multiplication
            //const Bitboard kF = 0x0101010101010101;
            //bb = (bb * kF) >> 0x38;       //returns 8 most significant bits of bb + (bb<<8) + (bb<<16) + (bb<<24) + ... // 0x38 = 56 = 64 - 8 S[ 3 ]

            ///// using addition
            ////bb = (bb + (bb >> S[ 3 ])) & 0x00FF00FF00FF00FF;  //put count of each 16 bits into their lowest 8 bits
            ////bb = (bb + (bb >> S[ 4 ])) & 0x000000FF000000FF;  //put count of each 32 bits into their lowest 8 bits
            ////bb = (bb + (bb >> S[ 5 ])) //& 0x00000000000000FF;  //put count of each 64 bits into their lowest 8 bits

            ////bb = (bb + (bb >> S[ 5 ])) & 0xFFFFFFFF;  //put count of each 64 bits into their lowest 32 bits
            ////bb = (bb + (bb >> S[ 4 ])) & 0xFFFF;      //put count of each 32 bits into their lowest 16 bits
            ////bb = (bb + (bb >> S[ 3 ])) //& 0xFF;        //put count of each 16 bits into their lowest 8 bits 

            //countBit1 = (byte) bb; 
            #endregion

            #region Lookup
            countBit1 = (byte)
                (_SetCount[ (bb >> 0x00) & Max16 ] +
                 _SetCount[ (bb >> 0x10) & Max16 ] +
                 _SetCount[ (bb >> 0x20) & Max16 ] +
                 _SetCount[ (bb >> 0x30) & Max16 ]);
            #endregion

            return countBit1;
        }
        internal static byte CountSets( ushort word )
        {
            byte countBit1 = 0;

            #region //Loops
            //for( byte i = 0; i < 0x10; ++i )
            //{
            //    countBit1 += (byte) ((word >> i) & 1);
            //} 

            //while( set != 0 )
            //{
            //    ++countBit1;
            //    word &= (ushort) (word - 1); // reset LS1B
            //}
            #endregion

            #region Shifts
            word = (ushort) ((word) - ((word >> S[ 0 ]) & 0x5555));
            word = (ushort) ((word & 0x3333) + ((word >> S[ 1 ]) & 0x3333));
            word = (ushort) ((word + (word >> S[ 2 ])) & 0x0F0F);
            ///// using multiplication
            word = (ushort) ((word * 0x0101) >> S[ 3 ]);
            ///// using addition
            //word += (ushort) (word >> S[ 3 ]);
            countBit1 = (byte) word;
            #endregion

            return countBit1;
        }

        // collapsedFilesIndex
        internal static byte RankOverlay( Bitboard bb )
        {
            return (byte)
                (_RankOverlay[ (bb >> 0x00) & Max16 ] |
                 _RankOverlay[ (bb >> 0x10) & Max16 ] |
                 _RankOverlay[ (bb >> 0x20) & Max16 ] |
                 _RankOverlay[ (bb >> 0x30) & Max16 ]);

            //bb |= bb >> 0x20;
            //bb |= bb >> 0x10;
            //bb |= bb >> 0x08;
            //return (byte) bb;
        }
        internal static byte RankOverlay( ushort word )
        {
            return (byte) (word | word >> 0x08); // [word = 16 bit]
        }


        internal static bool IsSquareOn( Bitboard bb, SquareE sqr )
        {
            //return (bb & _MinValue[ (byte) sqr ]) != EmptySquares;

            return (bb & 0x01UL << (byte) sqr) != EmptySquares;
        }

    
    };
}