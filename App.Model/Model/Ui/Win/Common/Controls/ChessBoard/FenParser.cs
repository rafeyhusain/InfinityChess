using System;
using System.Text;
using System.Collections;
using App.Model;
using ChessBoardCtrl;
using System.ComponentModel;
using System.Diagnostics;

namespace ChessLibrary
{
    /// <summary>
    /// For reference see: "Portable Game Notation Specification 
    /// and Implementation Guide"  section 16.1: FEN.  
    /// </summary>
    public class FenParser : IPosition
    {
        public Game Game = null;

        public static string InitialBoardFen { get { return "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1"; } }
        public static string EmptyBoardFen { get { return "8/8/8/8/8/8/8/8 w - - 0 1"; } }

        private StringBuilder coBoard;

        #region Events
        public delegate void placePiece(Pieces piece, int square);
        public event placePiece EventPlacePiece;

        /// Defines the color hooks that allow call back to set who's move it is.
        public delegate void setColor(bool bColor);
        public event setColor EventSetColor;

        public delegate void setCastling(bool WK, bool WQ, bool BK, bool BQ);
        public event setCastling EventSetCastling;

        public delegate void finished();
        public event finished EventFinished;
        #endregion Events

        /// <summary>
        /// The color to move given the current position.
        /// Must be 'w' or 'b'.
        /// </summary>
        public char Color
        {
            [DebuggerStepThrough]
            get { return coActiveColor; }
            [DebuggerStepThrough]
            set
            {
                if (value == 'w' || value == 'b')
                    coActiveColor = value;
                else
                    throw new Exception("Specify: 'w' or 'b'");
            }
        }
        private char coActiveColor;

        /// <summary>
        /// If true then white can still castle king side.
        /// </summary>
        public bool WhiteCastleKing
        {
            [DebuggerStepThrough]
            get { return coWKCastle; }
            [DebuggerStepThrough]
            set { coWKCastle = value; }
        }
        private bool coWKCastle;

        /// <summary>
        /// If true then white can still castle queen side.
        /// </summary>    
        public bool WhiteCastleQueen
        {
            [DebuggerStepThrough]
            get { return coWQCastle; }
            [DebuggerStepThrough]
            set { coWQCastle = value; }
        }
        private bool coWQCastle;

        /// <summary>
        /// If true then black can still castle king side.
        /// </summary>
        public bool BlackCastleKing
        {
            [DebuggerStepThrough]
            get { return coBKCastle; }
            [DebuggerStepThrough]
            set { coBKCastle = value; }
        }
        private bool coBKCastle;

        /// <summary>
        /// If true then black can still castle queen side.
        /// </summary>
        public bool BlackCastleQueen
        {
            [DebuggerStepThrough]
            get { return coBQCastle; }
            [DebuggerStepThrough]
            set { coBQCastle = value; }
        }
        private bool coBQCastle;

        /// <summary>
        /// Algebraic square for enpassant captures or '-'.
        /// </summary>
        public string Enpassant
        {
            [DebuggerStepThrough]
            get { return coEnPassant; }
            [DebuggerStepThrough]
            set { coEnPassant = value; }
        }
        private string coEnPassant;

        /// <summary>
        /// Number of half moves to determine the 50 move rule.
        /// </summary>
        public int HalfMoves
        {
            [DebuggerStepThrough]
            get { return coHalfMove; }
            [DebuggerStepThrough]
            set { coHalfMove = value; }
        }
        private int coHalfMove;

        /// <summary>
        /// Number of completed move cycles, i.e. after black moves.
        /// </summary>
        public int FullMoves
        {
            [DebuggerStepThrough]
            get { return coFullMove; }
            [DebuggerStepThrough]
            set { coFullMove = value; }
        }
        private int coFullMove;

        /// <summary>
        /// Indexer into the board.  Returns an upper case character for white and
        /// a lower case character for black.  The index number equals the board
        /// square.  Characters are 'PKQNBR' for white and 'pkqnbr' for black.
        /// </summary>
        public char this[int ndx]
        {
            [DebuggerStepThrough]
            get { return coBoard[ndx]; }
            [DebuggerStepThrough]
            set
            {
                string str = "KQRBNPkqrbnp";
                if (str.IndexOf(value) >= 0)
                    coBoard[ndx] = value;
                else
                    throw new Exception("Invalid piece value (" + value + ") use one of: " + str);
            }
        }

        /// <summary>
        /// Constructs a class by parsing a FEN notation string.
        /// </summary>
        /// <param name="str">A valid FEN notation data string</param>
        public FenParser(Game game, string str)
        {
            this.Game = game;
            coBoard = new StringBuilder(64, 64);
            parse(str);
        }

        /// <summary>
        /// Constructs a default FEN notation object with the board cleared,
        /// all castling available, white to move.
        /// </summary>
        public FenParser(Game game)
        {
            this.Game = game;
            coBoard = new StringBuilder(64, 64);
            clear();
        }

        /// <summary>
        /// Clears the notation to an empty board, white to move, all castling available.
        /// </summary>
        public void clear()
        {
            coBoard.Length = 0;
            coBoard.Append(' ', 64);
            coEnPassant = "-";
            coActiveColor = 'w';
            coWKCastle = true;
            coWQCastle = true;
            coBKCastle = true;
            coBQCastle = true;
            coHalfMove = 0;
            coFullMove = 0;
        }


        /// <summary>
        /// Creates our FEN notation string.
        /// </summary>
        /// <returns>FEN notation</returns>
        public override string ToString()
        {
            StringBuilder note = new StringBuilder();
            int count = 0;

            for (int ndx = 56; ndx >= 0; ndx -= 8)
            {
                count = 0;
                for (int cnt = 0; cnt < 8; cnt++)
                {
                    char achar = coBoard[ndx + cnt];
                    if (achar == ' ')
                        count++;
                    else
                    {
                        if (count > 0)
                            note.Append(count.ToString());
                        count = 0;
                        note.Append(achar);
                    }
                }

                if (count > 0)
                    note.Append(count.ToString());
                if (ndx != 0)
                    note.Append('/');
            }

            note.Append(' ');
            note.Append(coActiveColor);
            note.Append(' ');

            if (coWKCastle)
                note.Append('K');
            if (coWQCastle)
                note.Append('Q');
            if (coBKCastle)
                note.Append('k');
            if (coBQCastle)
                note.Append('q');

            note.Append(' ');
            note.Append(coEnPassant);
            note.Append(' ');
            note.Append(coHalfMove.ToString());
            note.Append(' ');
            note.Append(coFullMove.ToString());

            return note.ToString();
        }
        #region IPosition Members

        private BackgroundWorker fenWorker;
        private void InitFenWorker()
        {
            // create new worker
            this.fenWorker = new BackgroundWorker();
            // set that it can be cancelled
            this.fenWorker.WorkerSupportsCancellation = true;
            // install do work event
            this.fenWorker.DoWork += new DoWorkEventHandler(fenWorker_DoWork);
        }

        void fenWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            parseFen(e.Argument.ToString());
        }

        public bool IsBusy
        {
            get 
            {
                if (fenWorker != null)
                {
                    return fenWorker.IsBusy;
                }
                return false;
            }
        }

        public void parse(string str)
        {
            if (fenWorker == null)
            {
                InitFenWorker();
            }
            if (!fenWorker.IsBusy)
            {
                fenWorker.RunWorkerAsync(str);
            }
        }

        /// <summary>
        /// Parses our FEN notation into our class.
        /// For example: rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1
        /// </summary>
        /// <param name="str"></param>
        public void parseFen(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return;
            }

            // Clear all current settings.
            clear();
            int ndx = 56;
            int cnt = 0;
            string[] note = str.Split(' ');

            // 16.1.3.1: Parse piece placement data
            string[] row = note[0].Split('/');
            if (row.Length != 8)
                throw new ArgumentException("Invalid board specification, " + row.Length + " ranks are defined, there should be 8.");

            foreach (string line in row)
            {
                cnt = 0;
                foreach (char achar in line)
                {
                    if (achar >= '0' && achar <= '9')
                        cnt += (int)(achar - '0');
                    else
                    {
                        if (Board.PieceFromChar(achar) != Pieces.NONE)
                        {
                            if (cnt > 7)  //This check needed here to avoid overrunning index below under some error conditions.
                                throw new ArgumentException("Invalid board specification, rank " + (ndx / 8 + 1) + " has more then 8 items specified.");
                            if (EventPlacePiece != null)
                                EventPlacePiece(Board.PieceFromChar(achar), ndx + cnt);
                            this[ndx + cnt] = achar;
                        }
                        cnt++;
                    }
                }

                if (cnt == 0) // Allow null lines = /8/
                    cnt += 8;

                if (cnt != 8)
                    throw new ArgumentException("Invalid board specification, rank " + (ndx / 8 + 1) + " has " + cnt + " items specified, there should be 8.");

                ndx -= 8;
            }

            if (note.Length >= 2)
            {
                // 16.1.3.2: Parse active color
                if (note[1].Length > 0)
                {
                    char colorchar = Char.ToLower(note[1][0]);
                    if (colorchar.Equals('w') || colorchar.Equals('b'))
                    {
                        Color = colorchar;
                        if (EventSetColor != null)
                            EventSetColor(colorchar.Equals('w') ? true : false);
                    }
                    else
                        throw new ArgumentException("Invalid color designation, use w or b as 2nd field separated by spaces.");

                    if (note[1].Length != 1)
                        throw new ArgumentException("Invalid color designation, 2nd field is " + note[1].Length + " chars long, only 1 allowed.");
                }
            }

            // 16.1.3.3: Parse castling availability
            bool WK = false;
            bool WQ = false;
            bool BK = false;
            bool BQ = false;

            if (note.Length >= 3)
            {
                foreach (char achar in note[2])
                {
                    switch (achar)
                    {
                        case 'K':
                            WK = true;
                            break;
                        case 'Q':
                            WQ = true;
                            break;
                        case 'k':
                            BK = true;
                            break;
                        case 'q':
                            BQ = true;
                            break;
                        case '-':
                            break;
                        default:
                            throw new Exception("Invalid castle privileges designation, use: KQkq or -");
                    }
                }
            }
            if (EventSetCastling != null)
                EventSetCastling(WK, WQ, BK, BQ);

            this.Game.FenParser.Enpassant = null;

            try
            {
                if (note.Length >= 4)
                {
                    // 16.1.3.4: Parse en passant target square such as "e3"
                    coEnPassant = note[3];
                    this.Game.FenParser.Enpassant = coEnPassant;
                }

                if (note.Length >= 5)
                {
                    // 16.1.3.5: Parse halfmove clock, count of half-move since last pawn advance or unit capture
                    coHalfMove = Int16.Parse(note[4]);
                }

                if (note.Length >= 6)
                {
                    // 16.1.3.6: Parse fullmove number, increment after each black move
                    coFullMove = Int16.Parse(note[5]);
                }
            }
            catch
            {
            }
            if (EventFinished != null)
                EventFinished();

            this.Game.HalfMovesCounter = coHalfMove;
            this.Game.FullMovesCounter = coFullMove;

            //if (!Ap.Game.IsFirtMove)
            //{
            //    Ap.Game.CurrentMove.MoveNo = this.Game.FullMovesCounter;
            //}
        }

        public void addEvents(IPositionEvents ievents)
        {
            EventPlacePiece += new placePiece(ievents.placePiece);
            EventSetColor += new setColor(ievents.setColor);
            EventSetCastling += new setCastling(ievents.setCastling);
            EventFinished += new finished(ievents.finished);

        }
        public void removeEvents(IPositionEvents ievents)
        {
            EventPlacePiece -= new placePiece(ievents.placePiece);
            EventSetColor -= new setColor(ievents.setColor);
            EventSetCastling -= new setCastling(ievents.setCastling);
            EventFinished += new finished(ievents.finished);
        }

        #endregion

        #region Helper Method
        public static int GetMoveNo(string fenNotation)
        {
            ///// Retrieve Last Move Number Present After The Last Space In Fen Notation //////////////
            if (!string.IsNullOrEmpty(fenNotation))
            {
                return BaseItem.ToInt32(fenNotation.Split(' ').GetValue(fenNotation.Split(' ').Length - 1));
            }
            else
            {
                return 0;
            }
        }

        public static string GetOnlyFen(string fenNotation)
        {
            string tempFen;
            tempFen = fenNotation;
            if (tempFen.Contains(" "))
                tempFen = fenNotation.Substring(0, fenNotation.IndexOf(" "));

            return tempFen.Trim();
        }

        public static string[] GetFenParts(string fen)
        {
            if (String.IsNullOrEmpty(fen))
            {
                return null;
            }

            string[] vals = UStr.Split(fen, " ");

            if (vals.Length != 6)
            {
                return null;
            }

            return vals;
        }

        public static App.Model.Fen.SquareE GetEnpasantSqaure(string fen)
        {
            string[] vals = GetFenParts(fen);

            if (vals == null)
            {
                return App.Model.Fen.SquareE.NoSquare;
            }

            string val = vals.GetValue(3).ToString();

            if (val == "-")
            {
                return App.Model.Fen.SquareE.NoSquare;
            }

            return (App.Model.Fen.SquareE)Enum.Parse(typeof(App.Model.Fen.SquareE), val.ToUpper());
        }

        public static int GetHalfMovesCounter(string fen)
        {
            string[] vals = GetFenParts(fen);

            if (vals == null)
            {
                return 0;
            }

            string val = vals.GetValue(4).ToString();

            return BaseItem.ToInt32(val.ToUpper());
        }

        public static int GetFullMovesCounter(string fen)
        {
            string[] vals = GetFenParts(fen);

            if (vals == null)
            {
                return 0;
            }

            string val = vals.GetValue(5).ToString();

            return BaseItem.ToInt32(val.ToUpper());
        }

        internal static bool GetIsBlackShortCastling(string fen)
        {
            string[] vals = GetFenParts(fen);

            if (vals == null)
            {
                return false;
            }

            string val = vals.GetValue(2).ToString();

            if (val == "-")
            {
                return false;
            }
            else if (val.Contains("k"))
            {
                return true;
            }

            return false;
        }

        internal static bool GetIsBlackLongCastling(string fen)
        {
            string[] vals = GetFenParts(fen);

            if (vals == null)
            {
                return false;
            }

            string val = vals.GetValue(2).ToString();

            if (val == "-")
            {
                return false;
            }
            else if (val.Contains("q"))
            {
                return true;
            }

            return false;
        }

        internal static bool GetIsWhiteShortCastling(string fen)
        {
            string[] vals = GetFenParts(fen);

            if (vals == null)
            {
                return false;
            }

            string val = vals.GetValue(2).ToString();

            if (val == "-")
            {
                return false;
            }
            else if (val.Contains("K"))
            {
                return true;
            }

            return false;
        }

        internal static bool GetIsWhiteLongCastling(string fen)
        {
            string[] vals = GetFenParts(fen);

            if (vals == null)
            {
                return false;
            }

            string val = vals.GetValue(2).ToString();

            if (val == "-")
            {
                return false;
            }
            else if (val.Contains("Q"))
            {
                return true;
            }

            return false;
        }

        internal static bool IsInsufficientMaterial(string fen)
        {
            bool insufficientMaterial = false;
            string fenPosition = GetOnlyFen(fen);
            char[] fenChars = fenPosition.ToCharArray();
            int piecesCounter = 0;

            foreach (char c in fenChars)
            {
                if ((c >= 65 && c <= 90) || (c >= 97 && c <= 122)) // check for an alphabet(piece's symbol)
                {
                    piecesCounter++;
                }
            }

            if (piecesCounter == 2 && fenPosition.Contains("k") && fenPosition.Contains("K")) // only two pieces left (both kings)
            {
                insufficientMaterial = true;
            }
            return insufficientMaterial;
        }

        public static bool IsInitialFen(string fen, bool ignoreTurn)
        {
            string tFen = InitialBoardFen;

            if (ignoreTurn)
            {
                if (fen.Contains(" b "))
                {
                    tFen = tFen.Replace(" w ", " b ");
                }
            }
            return fen == tFen;
        }

        public static bool IsInitialFen(string fen)
        {
            return fen == InitialBoardFen;
        }

        public static string ResetMoveCounter(string fen)
        {
            string[] vals = GetFenParts(fen);

            if (vals == null)
            {
                return string.Empty;
            }

            vals.SetValue("1", 5);

            return (vals.GetValue(0) + " " + vals.GetValue(1) + " " + vals.GetValue(2) + " " + vals.GetValue(3) + " " + vals.GetValue(4) + " " + vals.GetValue(5));
        } 

        #endregion

    }
}
