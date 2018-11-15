using System;
namespace App.Model.Fen
{
    using Bitboard = UInt64;

    static partial class BitBoard
    {
        internal const Bitboard BitScanMagic = 0x07EDD5E59A4E28C2;

        internal const Bitboard File_A = 0x0101010101010101;
        internal const Bitboard File_B = 0x0202020202020202;
        internal const Bitboard File_C = 0x0404040404040404;
        internal const Bitboard File_D = 0x0808080808080808;
        internal const Bitboard File_E = 0x1010101010101010;
        internal const Bitboard File_F = 0x2020202020202020;
        internal const Bitboard File_G = 0x4040404040404040;
        internal const Bitboard File_H = 0x8080808080808080;

        internal const Bitboard Rank_1 = 0x00000000000000FF;
        internal const Bitboard Rank_2 = 0x000000000000FF00;
        internal const Bitboard Rank_3 = 0x0000000000FF0000;
        internal const Bitboard Rank_4 = 0x00000000FF000000;
        internal const Bitboard Rank_5 = 0x000000FF00000000;
        internal const Bitboard Rank_6 = 0x0000FF0000000000;
        internal const Bitboard Rank_7 = 0x00FF000000000000;
        internal const Bitboard Rank_8 = 0xFF00000000000000;

        internal const Bitboard File_NotA       = 0xFEFEFEFEFEFEFEFE;         // 56
        internal const Bitboard File_NotH       = 0x7F7F7F7F7F7F7F7F;         // 56

        internal const Bitboard EmptySquares    = 0x0000000000000000;      // 00 No squares.
        internal const Bitboard FullSquares     = 0xFFFFFFFFFFFFFFFF;       // 64 All squares.

        internal const Bitboard LightSquares    = 0x55AA55AA55AA55AA;      // 32 Light squares.
        internal const Bitboard DarkSquares     = 0xAA55AA55AA55AA55;       // 32 Dark squares.

        internal const Bitboard WhiteSideSquares = 0x00000000FFFFFFFF;  // 32 White side squares.
        internal const Bitboard BlackSideSquares = 0xFFFFFFFF00000000;  // 32 Black side squares.

        internal const Bitboard QueenSideSquares = 0x0F0F0F0F0F0F0F0F;  // 32 Queen side squares.
        internal const Bitboard KingSideSquares  = 0xF0F0F0F0F0F0F0F0;   // 32 King side squares.

        internal const Bitboard DiagA1H8Squares      = 0x8040201008040201;   // 08 A1H8 Diagonal squares.
        internal const Bitboard DiagA8H1Squares      = 0x0102040810204080;   // 08 A8H1 Diagonal squares.
        internal const Bitboard PrincipalDiagSquares = 0x8142241818244281;  // 16 Principal Diagonal squares.

        internal const Bitboard CenterSquares    = 0x0000001818000000;     // 04 Center squares.
        internal const Bitboard ExpCenterSquares = 0x00003C3C3C3C0000;  // 16 Expanded Center squares.
        internal const Bitboard CornerSquares    = 0x8100000000000081;     // 04 Corner squares.
        internal const Bitboard BorderSquares    = 0xFF818181818181FF;     // 28 Border squares.

        internal static Bitboard[] SquaresOfFile =
        {
            File_A,
            File_B,
            File_C,
            File_D,
            File_E,
            File_F,
            File_G,
            File_H,
        };

        internal static Bitboard[] SquaresOfRank =
        {
            Rank_1,
            Rank_2,
            Rank_3,
            Rank_4,
            Rank_5,
            Rank_6,
            Rank_7,
            Rank_8,
        };

        internal static Bitboard[] SquaresOfLateralFiles = 
        {
                     File_B,
            File_A | File_C,
            File_B | File_D,
            File_C | File_E,
            File_D | File_F,
            File_E | File_G,
            File_F | File_H,
            File_G,
        };

        internal static Bitboard[] SquaresOfLateralRanks = 
        {
                     Rank_2,
            Rank_1 | Rank_3,
            Rank_2 | Rank_4,
            Rank_3 | Rank_5,
            Rank_4 | Rank_6,
            Rank_5 | Rank_7,
            Rank_6 | Rank_8,
            Rank_7,
        };

        internal static Bitboard[ , ] SquaresOfFileRange = null;
        internal static Bitboard[ , ] SquaresOfRankRange = null;

        internal static byte[] S =                     
        {
            0x01,
            0x02,
            0x04,
            0x08,
            0x10,
            0x20
        };

        internal static Bitboard[] B =
        {
            0x5555555555555555,
            0x3333333333333333,
            0x0F0F0F0F0F0F0F0F,
            0x00FF00FF00FF00FF,
            0x0000FFFF0000FFFF,
            0x00000000FFFFFFFF
        };



        internal static Bitboard[ , ] SquaresOfRelativeRank = 
        {
            { Rank_1, Rank_2, Rank_3, Rank_4, Rank_5, Rank_6, Rank_7, Rank_8 },
            { Rank_8, Rank_7, Rank_6, Rank_5, Rank_4, Rank_3, Rank_2, Rank_1 }
        };

        internal static Bitboard[ , ] SquaresOfFrontRank = 
        {
            {
                Rank_2 | Rank_3 | Rank_4 | Rank_5 | Rank_6 | Rank_7 | Rank_8,
                Rank_3 | Rank_4 | Rank_5 | Rank_6 | Rank_7 | Rank_8,
                Rank_4 | Rank_5 | Rank_6 | Rank_7 | Rank_8,
                Rank_5 | Rank_6 | Rank_7 | Rank_8,
                Rank_6 | Rank_7 | Rank_8,
                Rank_7 | Rank_8,
                Rank_8,
                EmptySquares
            },
            {
                EmptySquares,
                Rank_1,
                Rank_2 | Rank_1,
                Rank_3 | Rank_2 | Rank_1,
                Rank_4 | Rank_3 | Rank_2 | Rank_1,
                Rank_5 | Rank_4 | Rank_3 | Rank_2 | Rank_1,
                Rank_6 | Rank_5 | Rank_4 | Rank_3 | Rank_2 | Rank_1,
                Rank_7 | Rank_6 | Rank_5 | Rank_4 | Rank_3 | Rank_2 | Rank_1
            }
        };


        internal static Bitboard FrontRank( ColorE color, SquareE sqr )
        {
            return SquaresOfFrontRank[ (byte) color, (byte) Square._Rank(sqr) ];
        }

        internal static Bitboard LateralFiles( SquareE sqr )
        {
            return SquaresOfLateralFiles[ (byte) Square._File(sqr) ];
        }

        internal static Bitboard LateralThisFiles( SquareE sqr )
        {
            byte file = (byte) Square._File(sqr);
            return SquaresOfFile[ file ] | SquaresOfLateralFiles[ file ];
        }
    };
}