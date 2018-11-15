/*
                 \\|//
                 (o o)
--------------ooO-(_)-Ooo--------------
 Copyright 2004 By Gregory A. Prentice
                      Ooo.
--------------.ooO----(  )-------------
              (  )    (_/
               \_)
If you wish to use this code in any part
I request that you simply let me know where
and give the author credit for his work.
gregoryprentice@comcast.net
www.cafechess.org
*/
using System;
using System.Diagnostics;
namespace ChessLibrary
{
  using Bitboard = System.UInt64;

  /// <summary>
  /// Sets the bitboards for all of the pieces that may be checking a king.
  /// Also keeps track of how many pieces are checking the king.  This is used
  /// for mate detection.
  /// </summary>
  public class AttackingPieces
  {
    public int Count
    {
        [DebuggerStepThrough]
        get { return coCount; }
    }
    private int coCount;

    public Bitboard DiagonalLR;
    public Bitboard DiagonalRL;
    public Bitboard Ranks;
    public Bitboard Files;

    public Bitboard Queen
    {
        [DebuggerStepThrough]
        get { return coQueen; }
        [DebuggerStepThrough]
        set { coQueen = value; if (coQueen != 0)coCount++; }
    }
    private Bitboard coQueen;
    public Bitboard Rook
    {
        [DebuggerStepThrough]
        get { return coRook; }
        [DebuggerStepThrough]
        set { coRook = value; if (coRook != 0)coCount++; }
    }
    private Bitboard coRook;
    public Bitboard Bishop
    {
        [DebuggerStepThrough]
        get { return coBishop; }
        [DebuggerStepThrough]
        set { coBishop = value; if (coBishop != 0)coCount++; }
    }
    private Bitboard coBishop;
    public Bitboard Knight
    {
        [DebuggerStepThrough]
        get { return coKnight; }
        [DebuggerStepThrough]
        set { coKnight = value; if (coKnight != 0)coCount++; }
    }
    private Bitboard coKnight;
    public Bitboard Pawn
    {
        [DebuggerStepThrough]
        get { return coPawn; }
        [DebuggerStepThrough]
        set { coPawn = value; if (coPawn != 0)coCount++; }
    }
    private Bitboard coPawn;

    public AttackingPieces()
    {
      clear();
    }
    public void clear()
    {
      coQueen=0;
      coRook=0;
      coBishop=0;
      coKnight=0;
      coPawn=0;
      coCount=0;
      DiagonalLR=0;
      DiagonalRL=0;
      Ranks=0;
      Files=0;
    }
  }

}
