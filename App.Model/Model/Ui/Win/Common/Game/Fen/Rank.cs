namespace App.Model.Fen
{
    enum RankE : byte
    {
        Rank_1,
        Rank_2,
        Rank_3,
        Rank_4,
        Rank_5,
        Rank_6,
        Rank_7,
        Rank_8,
        NoRank,
    };

    static class Rank
    {
        internal const byte Ranks = 0x08;
        internal static readonly char[] mapRank = default(char[]);

        static Rank()
        {
            mapRank = new char[] { '1', '2', '3', '4', '5', '6', '7', '8' };
        }

        internal static bool IsValid( RankE rank )
        {
            return ((byte) rank & 0xF8) == 0;   //~0x07
        }

        internal static char RankNotation( RankE rank )
        {
            return (char) ('1' + (byte) rank);
        }
    };
}