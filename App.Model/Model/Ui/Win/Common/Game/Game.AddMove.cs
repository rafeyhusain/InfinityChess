using System;
using App.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfinityChess;
using System.IO;
using InfinitySettings.Streams;
using InfinitySettings.UCIManager;
using System.Data;
using System.Diagnostics;
using ChessLibrary;
using AppEngine;
using ChessBoardCtrl.New;
using App.Model.Fen;
using System.Windows.Forms;

namespace App.Model
{
    public partial class Game
    {
        #region Add Move

        public Move AddMove(string from, string to, Pieces fromPiece, string fen, Move m, bool isPastGame, bool isSetFen)
        {
            #region On Before
            if (m == null)
            {
                return null;
            }

            if (BeforeAddMove != null)
            {
                BeforeAddMove(this, EventArgs.Empty);
            }
            #endregion

            if (isPastGame)
            {
                Clock.SetClock(m);
            }
            else
            {
                #region IsVariation
                if (Flags.IsVariation)
                {
                    if (AddVariationMove())
                    {
                        return null;
                    }
                    else
                    {
                        m.Flags.VariationType = this.VariationType;
                    }
                } 
                #endregion

                #region Prepare Move
                if (!m.Flags.IsPromotion) // promoted piece is already assigned in promotion dialog
                {
                    m.Piece = fromPiece;
                }

                m.Id = NextMoveId;
                m.Pid = NextMovePid;
                m.MoveNo = NextMoveNo;
                m.IsWhite = NextMoveIsWhite;
                m.From = from;
                m.To = to;
                m.Fen = fen;
                #endregion

                #region Set Clock
                if (Flags.IsOnline)
                {
                    if (!m.IsWhite)
                    {
                        Clock.WhiteTime += DbGame.GainPerMoveMin;
                    }
                    else
                    {
                        Clock.BlackTime += DbGame.GainPerMoveMin;
                    }
                }

                m.MoveTimeWhite = Clock.WhiteTime;
                m.MoveTimeBlack = Clock.BlackTime;

                m.MoveTime = Clock.MoveTime;

                Clock.Start();  
                #endregion
            }

            CurrentMove = m.Clone();

            SetFenCastlingNotation(m.Piece, m.From, m.To);

            Flags.IsPieceMovedSuccessfully = true;

            CompareFlags(CurrentMove);
            Notations.SetMove(CurrentMove);
            Book.SetMove(CurrentMove);

            //if (CurrentMove.CapturedPiece != Pieces.NONE)
            //{
            //    SetCapturedPiecesParameters();
            //    CapturedPieces.AddPiece();
            //}

            Flags.IsMoveInProgress = false;
            Flags.IsForceEngineToMove = false;
            Flags.IsManualMove = false;
            Flags.IsSpacebarClick = false;

            if (Flags.IsMated)
            {
                Mated();
                Flags.IsMoveInProgress = true;
            }

            if (Flags.IsStaleMated)
            {
                StaleMated();
            }

            if (Flags.IsThreeFoldRepetition)
            {
                ThreefoldRepetition(false);
            }

            if (this.HalfMovesCounter >= 100)
            {
                FifityMoves();
            }

            TogglePlayers();

            if (isSetFen)
            {
                SetFen(m.Fen);
            }

            Moves.Import(CurrentMove);

            VariationType = VariationTypeE.None;

            #region On After
            if (AfterAddMove != null)
            {
                AfterAddMove(this, EventArgs.Empty);
            }

            #endregion

            return m;
        }

        #region Helpers
        private bool AddVariationMove()
        {
            FormClosingEventArgs e = new FormClosingEventArgs(CloseReason.None, false);

            if (AddNewVariation != null)
            {
                AddNewVariation(this, e);
            }

            return e.Cancel;
        }

        private void CompareFlags(Move m)
        {
            if (!GameValidator.IsLegalMove(m.MoveString))
            {
                MoveFlags = "";
                return;
            }

            string validatorFlags = GameValidator.GetMoveFlags(m.MoveString);

            GameValidator.AppendMove(m.MoveString);

            bool equal = true;

            foreach (char c in m.MoveFlags)
            {
                if (!validatorFlags.Contains(c) && c.ToString() != Moves.EnpassantCapture)
                {
                    equal = false;
                    break;
                }
            }

            if (equal)
            {
                foreach (char c in validatorFlags)
                {
                    if (!m.MoveFlags.Contains(c))
                    {
                        equal = false;
                        break;
                    }
                }
            }

            this.MoveFlags = "MV : '" + m.MoveFlags + "'" + Environment.NewLine + "GV : '" + validatorFlags + "'" + Environment.NewLine;
            this.MoveFlags += "Fen : '" + m.Fen + "'" + Environment.NewLine + "Move : '" + m.MoveString + "'";

            if (equal)
                return;

            if (MoveFlagsError != null)
            {
                MoveFlagsError(this, EventArgs.Empty);
            }
        }

        private void SetFenCastlingNotation(Pieces piece, string from, string to)
        {
            switch (piece)
            {
                case Pieces.WKING:
                    Flags.IsWhiteCastling = false;
                    break;
                case Pieces.WROOK:
                    switch (from)
                    {
                        case "a1":
                            Flags.IsWhiteLongCastling = false;
                            break;
                        case "h1":
                            Flags.IsWhiteShortCastling = false;
                            break;
                    }
                    break;
                case Pieces.BKING:
                    Flags.IsBlackCastling = false;
                    break;
                case Pieces.BROOK:
                    switch (from)
                    {
                        case "a8":
                            Flags.IsBlackLongCastling = false;
                            break;
                        case "h8":
                            Flags.IsBlackShortCastling = false;
                            break;
                    }
                    break;
            }
        } 
        #endregion

        #endregion

        #region Union
        public void Union(string moves)
        {
            if (moves == "")
            {
                return;
            }

            DataTable dt = UData.LoadDataTable(Notations.Game.Moves.DataTable.Clone(), moves);

            AddMoves(dt);
        }
        
        #endregion

        #region Paste
        public void Paste(string moves)
        {
            DataTable dt = UData.LoadDataTable(Notations.Game.Moves.DataTable.Clone(), moves);
            Paste(dt);
        }

        public void Paste(Moves moves)
        {
            Paste(moves.DataTable);
        }

        public void Paste(DataTable moves)
        {
            if (BeforePaste != null)
            {
                BeforePaste(this, EventArgs.Empty);
            }

            Notations.Game.Moves.DataTable.Clear();
            Notations.NotationView.Clear();

            bool b = Flags.IsEngineOn;

            Flags.IsEngineOn = false;

            AddMoves(moves);

            Flags.IsEngineOn = b;

            if (Flags.IsOffline)
            {
                MoveTo(MoveToE.First);

                CurrentMove = null;
                Clock.Reset();
                Clock.Stop();
                GameResult = GameResultE.InProgress;
            }

            if (AfterPaste != null)
            {
                AfterPaste(this, EventArgs.Empty);
            }
        }
        
        #endregion

        #region AddMoves

        public void AddMoves(DataTable moves)
        {
            Move m = null;

            for (int i = 0; i < moves.Rows.Count; i++)
            {
                m = new Move(moves.Rows[i]);

                if (i == moves.Rows.Count - 1)
                {
                    AddMove(null, null, Pieces.NONE, "", m, true, Flags.IsOnline);
                }
                else
                {
                    AddMove(null, null, Pieces.NONE, "", m, true, false);
                }
            }
        } 
        #endregion

        #region TogglePlayers
        public void TogglePlayers()
        {
            if (Player1.Active)
            {
                Player1.Active = false;
                Player2.Active = true;

                CurrentPlayer = Player2;
            }
            else if (Player2.Active)
            {
                Player2.Active = false;
                Player1.Active = true;

                CurrentPlayer = Player1;
            }
        } 
        #endregion
    }
}
