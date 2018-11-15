namespace App.Model.Fen
{
    //[Flags]
    // Piece colors:
    enum ColorE : byte
    {
        White,
        Black,
        NoColor,
    };
    
  

    static class Color
    {
        internal const byte Colors = 2;


        internal static ColorE Switch( ref ColorE color )
        {
            switch( color )
            {
                case ColorE.White: return color = ColorE.Black;
                case ColorE.Black: return color = ColorE.White;

                case ColorE.NoColor:
                default: return color = ColorE.NoColor;
            }
        }
    };
}