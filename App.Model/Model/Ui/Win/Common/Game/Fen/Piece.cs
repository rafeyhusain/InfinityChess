namespace App.Model.Fen
{
    // Piece shapes:
    enum PieceE : byte
    {
        Pawn,   // Promotable
        
        // Non-Promotable,

        // Reproducible
        Knight, // Jumping

        Bishop, // Sliding
        Rook,
        Queen,


        King,   // Immortal, Inimitable, Unrepeatable

        NoPiece,
    };

    class Piece
    {
        internal const byte PiecesType = 6;
        internal static readonly char[ , ] mapPiece = default(char[ , ]);

        static Piece()
        {
            mapPiece = new char[ , ]
            {
                { 'P', 'N', 'B', 'R', 'Q', 'K' },
                { 'p', 'n', 'b', 'r', 'q', 'k' }
            };
        }

        internal static Piece Parse( char ch )
        {
            switch( ch )
            {
                // white Piece
                case 'P': return new Piece(ColorE.White, PieceE.Pawn);
                case 'N': return new Piece(ColorE.White, PieceE.Knight);
                case 'B': return new Piece(ColorE.White, PieceE.Bishop);
                case 'R': return new Piece(ColorE.White, PieceE.Rook);
                case 'Q': return new Piece(ColorE.White, PieceE.Queen);
                case 'K': return new Piece(ColorE.White, PieceE.King);

                // black Piece
                case 'p': return new Piece(ColorE.Black, PieceE.Pawn);
                case 'n': return new Piece(ColorE.Black, PieceE.Knight);
                case 'b': return new Piece(ColorE.Black, PieceE.Bishop);
                case 'r': return new Piece(ColorE.Black, PieceE.Rook);
                case 'q': return new Piece(ColorE.Black, PieceE.Queen);
                case 'k': return new Piece(ColorE.Black, PieceE.King);

                default: return default(Piece);
            }
        }



        internal readonly ColorE Color;
        internal readonly PieceE Type;

        //internal virtual ColorE Color { get { return ColorE.NoColor;} }

        internal Piece( ColorE color, PieceE type )
        {
            Color = color;
            Type = type;
        }

        internal Piece()
            : this(ColorE.NoColor, PieceE.NoPiece)
        {
        }
    };

    //sealed class WhitePiece : Piece
    //{
    //    internal override ColorE Color
    //    {
    //        [DebuggerStepThrough]
              //get { return ColorE.White; }
    //    }
    //};

    //sealed class BlackPiece : Piece
    //{
    //    internal override ColorE Color
    //    {
    //        [DebuggerStepThrough]
               //get { return ColorE.Black; }
    //    }
    //};
}