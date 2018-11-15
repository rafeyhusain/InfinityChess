namespace App.Model.Fen
{
    enum FileE : byte
    {
        File_A,
        File_B,
        File_C,
        File_D,
        File_E,
        File_F,
        File_G,
        File_H,
        NoFile,
    };

    static class File
    {
        internal const byte Files = 0x08;
        internal static readonly char[] mapFile = default(char[]);

        static File()
        {
            mapFile = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
        }

        internal static bool IsValid( FileE file )
        {
            return ((byte) file & 0xF8) == 0;   //~0x07
        }

        internal static char FileNotation( FileE file )
        {
            return (char) ('a' + (byte) file);
        }
    };
}