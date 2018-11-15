using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model
{
    public enum PlayerType
    {
        Engine = 1,
        Human = 2
    }

    public enum GameType
    {
        None = 0,
        Bullet =1,
        Blitz = 2,
        Rapid =3,
        Long = 4,
        NoClock = 5
    }

    public enum GameTeam
    {
        Black = 0,
        White = 1
    }

    public enum Pieces
    {
        NONE, WKING, WQUEEN, WROOK, WBISHOP, WKNIGHT, WPAWN,
        BKING, BQUEEN, BROOK, BBISHOP, BKNIGHT, BPAWN
    };

    public class Files
    {
        public const string OpeningBookExtension = ".icb";
        public const string TablebasesExtension = ".ict";
        public const string DatabaseExtension = ".icd";
        public const string PortableGameNotationExtension = ".pgn";
        public const string ParametersExtension = ".param";        
    }
}
