using System;
using System.Text;
using App.Model;

namespace ChessLibrary
{
    /// <summary>
    /// Represents a standard Algebraic notation chess move.
    /// </summary>
    public class ChessMove
    {
        public Game Game = null;

        public const bool WHITE = true;
        public const bool BLACK = false;

        public bool Color;
        public int Number;
        public int Question;
        public int Exclamation;
        public string Move;
        public char Promotion;
        public char Piece;
        public char Qualify;

        public ChessMove(Game game)
        {
            this.Game = game;
            clear();
        }
        public void switchColor()
        {
            Color = !Color;
        }
        /// <summary>
        /// Set the move object to it's initial stabel state.
        /// </summary>
        public void clear()
        {
            Color = WHITE;
            Question = 0;
            Exclamation = 0;
            Move = "";
            Promotion = ' ';
            Piece = ' ';
            Qualify = ' ';
            Number = 0;
        }
        /// <summary>
        /// Breaks appart the chess move into our object
        /// for easier manipulation.
        /// </summary>
        /// <param name="chessmove"></param>
        public void parseMove(string chessmove)
        {
            char achar;
            StringBuilder build = new StringBuilder();
            chessmove = chessmove.ToUpper();
            clear();
            Piece = 'P';
            for (int ndx = chessmove.Length - 1; ndx >= 0; ndx--)
            {
                achar = chessmove[ndx];
                switch (achar)
                {
                    case '+':
                        this.Game.CurrentMove.Flags.IsInCheck = true;
                        break;
                    case '!':
                        Exclamation++;
                        break;
                    case '#':
                        this.Game.CurrentMove.Flags.IsMated = true;
                        break;
                    case '?':
                        Question++;
                        break;
                    case '=':
                        Promotion = build.ToString()[0];
                        build.Length = 0;
                        break;
                    case 'X':
                        this.Game.CurrentMove.Flags.IsCapture = true;
                        break;
                    case 'K':
                        if (ndx == 0)
                        {
                            Piece = achar;
                        }
                        else
                        {
                            build.Append(achar);
                        }
                        break;
                    case 'Q':
                        if (ndx == 0)
                        {
                            Piece = achar;
                        }
                        else
                        {
                            build.Append(achar);
                        }
                        break;
                    case 'B':
                        if (ndx == 0)
                        {
                            Piece = achar;
                        }
                        else
                        {
                            build.Append(achar);
                        }
                        break;
                    case 'N':
                        if (ndx == 0)
                        {
                            Piece = achar;
                        }
                        else
                        {
                            build.Append(achar);
                        }
                        break;
                    case 'R':
                        if (ndx == 0)
                        {
                            Piece = achar;
                        }
                        else
                        {
                            build.Append(achar);
                        }
                        break;
                    default:
                        build.Append(achar);
                        break;
                }
            }
            // Get remaining command and reverse it.
            chessmove = build.ToString();
            build.Length = 0;
            for (int ndx = chessmove.Length - 1; ndx >= 0; ndx--)
            {
                achar = chessmove[ndx];
                build.Append(achar);
            }
            chessmove = build.ToString().ToLower();
            if (chessmove.Length == 3)
            {
                Qualify = chessmove[0];
                chessmove = chessmove.Substring(1, 2);
            }

            Move = chessmove;
        }
        /// <summary>
        /// Converts our chess object into standard algebraic notation.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder build = new StringBuilder();
            if (Piece != 'P')
                build.Append(Piece);
            if (Qualify != ' ')
                build.Append(Qualify);
            if (this.Game.CurrentMove.Flags.IsCapture)
                build.Append("x");
            build.Append(Move);

            if (Promotion != ' ')
            {
                build.Append('=');
                build.Append(Promotion);
            }
            if (this.Game.CurrentMove.Flags.IsInCheck)
                build.Append('+');

            if (this.Game.CurrentMove.Flags.IsMated)
                build.Append('#');
            return build.ToString();
        }
    }
}
