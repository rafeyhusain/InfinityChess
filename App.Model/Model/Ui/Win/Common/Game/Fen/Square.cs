using System.Diagnostics;

namespace App.Model.Fen
{
    public enum SquareE : byte
    {
        A1, B1, C1, D1, E1, F1, G1, H1,
        A2, B2, C2, D2, E2, F2, G2, H2,
        A3, B3, C3, D3, E3, F3, G3, H3,
        A4, B4, C4, D4, E4, F4, G4, H4,
        A5, B5, C5, D5, E5, F5, G5, H5,
        A6, B6, C6, D6, E6, F6, G6, H6,
        A7, B7, C7, D7, E7, F7, G7, H7,
        A8, B8, C8, D8, E8, F8, G8, H8,
        NoSquare,
    };

    static class Square
    {
        internal const byte Squares = 0x40; //File.Files * Rank.Ranks;

        #region Old

        //internal byte Sqr;
        //internal Piece Piece = default(Piece);

        //internal FileE File { get { return GetFile(Sqr); } }

        //internal RankE Rank { get { return GetRank(Sqr); } }

        //internal Square()
        //{
        //}

        //internal Square( byte sqr )
        //{
        //    SetSquare(sqr);
        //}

        //internal Square( SquareE sqr )
        //    : this((byte) sqr)
        //{
        //}

        //internal Square( byte file, byte rank )
        //{
        //    SetFileRank(file, rank);
        //}

        //internal Square( FileE file, RankE rank )
        //    : this((byte) file, (byte) rank)
        //{
        //}

        //private void SetSquare( byte sqr )
        //{
        //    //Debug.Assert(sqr < Square.Squares);
        //    Sqr = sqr;
        //}

        //private void SetFileRank( byte file, byte rank )
        //{
        //    //Debug.Assert(file < M.File.Files);
        //    //Debug.Assert(rank < M.Rank.Ranks);
        //    //SetSquare((byte) ((rank * M.File.Files) + file));
        //    SetSquare((byte) ((rank << 0x03) + file));
        //}

        //internal bool IsEmpty
        //{
        //    get { return Piece == default(Piece); }
        //}

        //internal ColorE OccupiedBy
        //{
        //    get
        //    {
        //        if( !IsEmpty )
        //        {
        //            if( Piece.Color == ColorE.White )
        //                return ColorE.White;
        //            else if( Piece.Color == ColorE.Black )
        //                return ColorE.Black;
        //            else
        //                return ColorE.NoColor;
        //        }
        //        return ColorE.NoColor;
        //    }
        //}

        //internal bool IsOccupiedBy( ColorE color )
        //{
        //    return !IsEmpty && Piece.Color == color;
        //} 
        //public override string ToString()
        //{
        //    return string.Format("{0}{1}", FileNotation, RankNotation);
        //}

        #endregion

        internal static FileE _File( SquareE sqr )
        {
            Debug.Assert(IsValid(sqr), "Not 0-3F");
            return (FileE) ((byte) sqr & 0x07); 
        }

        internal static RankE _Rank( SquareE sqr )
        {
            Debug.Assert(IsValid(sqr), "Not 0-3F");
            return (RankE) (((byte) sqr >> 3) & 0x07);
        }

        internal static ColorE _Color( SquareE sqr )
        {
            return (ColorE) (((byte) _File(sqr) + (byte) _Rank(sqr) + 1) % 2);
        }

        internal static SquareE _Square( FileE file, RankE rank )
        {
            Debug.Assert(File.IsValid(file), "Not 0-7");
            Debug.Assert(Rank.IsValid(rank), "Not 0-7");
            return (SquareE) (((byte) rank << 3) + (byte) file);
        }

        internal static SquareE _Square( char file, char rank )
        {
            //Debug.Assert(File.IsValid((FileE) (file - 'a')), "Not a-h"); // (file >= 'a' && file <= 'h')
            //Debug.Assert(Rank.IsValid((RankE) (rank - '1')), "Not 1-8"); // (rank >= '1' && rank <= '8')
            //return (SquareE) (((rank - '1') << 3) + (file - 'a'));
            
            return _Square((FileE) (file - 'a'), (RankE) (rank - '1'));
        }

        internal static bool IsValid( SquareE sqr )
        {
            return ((byte) sqr & 0xC0) == 0; //((byte) sqr & ~0x3F) == 0; // sqr >= SquareE.A1 && sqr <= SquareE.H8;
        }


        internal static SquareE BackwardInc( ref SquareE sqr )
        {
            switch( sqr )
            {
                case SquareE.H1: return sqr = SquareE.NoSquare;
                case SquareE.H2: return sqr = SquareE.A1;
                case SquareE.H3: return sqr = SquareE.A2;
                case SquareE.H4: return sqr = SquareE.A3;
                case SquareE.H5: return sqr = SquareE.A4;
                case SquareE.H6: return sqr = SquareE.A5;
                case SquareE.H7: return sqr = SquareE.A6;
                case SquareE.H8: return sqr = SquareE.A7;
                default: return ++sqr; // sqr = (SquareE) (sqr + 1);
            }
        }

        public static string ToString( SquareE sqr )
        {
            return string.Format("{0}{1}", File.FileNotation(_File(sqr)), Rank.RankNotation(_Rank(sqr)));
        }
    };
}