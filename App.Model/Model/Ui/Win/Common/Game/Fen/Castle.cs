using System;
using System.Diagnostics;
namespace App.Model.Fen
{
    class Castle
    {
        internal bool ShortCastle;  //KingSide
        internal bool LongCastle;   //QueenSide

        internal bool AnyCastle
        {
            [DebuggerStepThrough]
            get { return LongCastle | ShortCastle; }
            [DebuggerStepThrough]
            set { ShortCastle = LongCastle = value; }
        }

        //public override string ToString() { return base.ToString(); }
    };

    //enum Castle : byte
    //{
    //    NoCastle,
    //    ShortCastle,
    //    LongCastle,
    //    BothCastle,
    //};

    // Castle sides:
    [Flags]
    enum CastleSide : byte
    {
        KingSide,
        QueenSide,
        NoCastleSide,
    };

    [Flags]
    enum CastleState : byte
    {
        CanCastle,
        CantCastle,
        Castled,
        NoCastleState,
    };
}