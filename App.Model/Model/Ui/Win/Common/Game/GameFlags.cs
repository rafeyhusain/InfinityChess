using System;
using App.Model;
using System.Collections.Generic;
using System.Data;
using System.Text;
using InfinityChess;
using System.Windows.Forms;
using ChessLibrary;
using System.Diagnostics;
using App.Model.Fen;

namespace App.Model
{
    public class GameFlags : BaseFlags
    {
        #region Data Members
        public Game Game = null;

        /*
         * WARNING: Sort Flags alphabatically to avoid duplicates
         */
        public const string ThreefoldRepetition = "3";

        public const string Aborted = "A";

        public const string VariationInProgress = "C";
        public const string InitializeClick = "c";

        public const string ChallengerSendsGame = "D";

        public const string EngineBlack = "E";
        public const string EngineOn = "e";

        public const string BoardSetByFen = "F";

        public const string NewGameStartClock = "G";
        public const string PastGame = "g";

        public const string PositionPasted = "h";

        public const string ForceEngineToMove = "I";
        public const string BoradInitialized = "i";

        public const string GameResult = "j";

        public const string WhiteShortCastling = "K";
        public const string BlackShortCastling = "k";

        public const string NewMainline = "l";

        public const string StaleMated = "M";
        public const string Mainline = "m";

        public const string Navigation = "N";
        public const string GameStart = "n";

        public const string ThreeFoldRepetition = "O";
        public const string ScoringVariation = "o";

        public const string Promotion = "P";
        public const string BoardSetByPositionSetup = "p";

        public const string WhiteLongCastling = "Q";
        public const string BlackLongCastling = "q";

        public const string Resigned = "R";
        public const string RetracMove = "r";

        public const string PieceMovedSuccessfully = "S";
        public const string SpacebarClick = "s";

        public const string TimeExpired = "T";
        public const string BlackVariation = "t";

        public const string ManualMove = "U";
        public const string ClickedByUser = "u";

        public const string MoveInProgress = "V";

        public const string ExamineMode = "x";

        public const string InfiniteAnalysisOn = "Y";

        public SquareE EnPassant = SquareE.NoSquare;              
        
        #endregion

        #region Ctor

        public GameFlags(Game game)
        {
            this.Game = game;
        }

        #endregion

        #region Properties

        #region Core
        public bool IsChallengerSendsGame { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.ChallengerSendsGame); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.ChallengerSendsGame, value); } }
        public bool IsAborted { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.Aborted); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.Aborted, value); } }

        public bool IsWhiteShortCastling { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.WhiteShortCastling); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.WhiteShortCastling, value); } }
        public bool IsWhiteLongCastling { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.WhiteLongCastling); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.WhiteLongCastling, value); } }
        public bool IsBlackLongCastling { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.BlackLongCastling); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.BlackLongCastling, value); } }
        public bool IsBlackShortCastling { [DebuggerStepThrough]get { return Flags.Contains(GameFlags.BlackShortCastling); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.BlackShortCastling, value); } }

        public bool IsEngineBlack { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.EngineBlack); } [DebuggerStepThrough]set { SetMoveFlag(GameFlags.EngineBlack, value); } }        

        public bool IsResigned { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.Resigned); } set { SetMoveFlag(GameFlags.Resigned, value); } }
        public bool IsTimeExpired { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.TimeExpired); } [DebuggerStepThrough]set { SetMoveFlag(GameFlags.TimeExpired, value); } }

        public bool IsPieceMovedSuccessfully { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.PieceMovedSuccessfully); } [DebuggerStepThrough]set { SetMoveFlag(GameFlags.PieceMovedSuccessfully, value); } }

        public bool IsExamineMode { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.ExamineMode); } [DebuggerStepThrough]set { SetMoveFlag(GameFlags.ExamineMode, value); } }
        public bool IsForceEngineToMove { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.ForceEngineToMove); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.ForceEngineToMove, value); } }
        
        public bool IsManualMove { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.ManualMove); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.ManualMove, value); } }
        public bool IsPromotion { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.Promotion); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.Promotion, value); } }
        
        public bool IsMoveInProgress { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.MoveInProgress); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.MoveInProgress, value); } }
        public bool IsInfiniteAnalysisOn { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.InfiniteAnalysisOn); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.InfiniteAnalysisOn, value); } }        
        
        public bool IsInitializeClick { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.InitializeClick); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.InitializeClick, value); } }
        public bool IsSpacebarClick { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.SpacebarClick); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.SpacebarClick, value); } }
        
        public bool IsRetracMove { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.RetracMove); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.RetracMove, value); } }
        public bool IsClickedByUser { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.ClickedByUser); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.ClickedByUser, value); } }
        
        public bool IsNewMainline { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.NewMainline); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.NewMainline, value); } }
        public bool IsVariationInProgress { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.VariationInProgress); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.VariationInProgress, value); } }
        
        public bool IsEngineOn { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.EngineOn); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.EngineOn, value); } }                
        public bool IsScoringVariation { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.ScoringVariation); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.ScoringVariation, value); } }
        
        public bool IsMainline { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.Mainline); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.Mainline, value); } }
        public bool IsGameStart { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.GameStart); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.GameStart, value); } }
        
        public bool IsBlackVariation { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.BlackVariation); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.BlackVariation, value); } }                

        #endregion

        #region Calculated
        public bool IsVariation
        {
            [DebuggerStepThrough]
            get
            {
                if (IsFirtMove)
                {
                    return false;
                }

                if (Game.Moves.Last.Id != Game.CurrentMove.Id)
                {
                    return true;
                }

                return false;
            }
        }

        public bool IsFirtMove
        {
            [DebuggerStepThrough]
            get
            {
                if (Game.Moves == null)
                {
                    return true;
                }

                return Game.Moves.Count == 0;
            }
        }
       
        public bool IsPositionSetupAllowed { [DebuggerStepThrough] get { return AmIChallenger && Game.DbGame.IsChallengerSendsGame; } }
        public bool IsPositionSetupEnabled { [DebuggerStepThrough] get { return AmIChallenger && IsChallengerSendsGame; } }
        public bool AmIChallenger { [DebuggerStepThrough] get { return Game.DbGame.Challenge.AmIChallenger; } }
        public bool AmIOpponent { [DebuggerStepThrough] get { return Game.DbGame.Challenge.AmIOpponent; } }

        public bool IsWhiteCastling { [DebuggerStepThrough] get { return IsWhiteShortCastling && IsWhiteLongCastling; } [DebuggerStepThrough] set { IsWhiteShortCastling = IsWhiteLongCastling = value; } }
        public bool IsBlackCastling { [DebuggerStepThrough]get { return IsBlackShortCastling && IsBlackLongCastling; } [DebuggerStepThrough] set { IsBlackShortCastling = IsBlackLongCastling = value; } }

        public bool IsMoveEnable
        {
            [DebuggerStepThrough]
            get
            {
                if (IsOffline)
                    return true;

                if (IsExamineMode)
                    return true;

                if (IsChallengerSendsGame)
                    return false;

                if (Game.Flags.IsGameFinished)
                    return false;

                return IsMyTurn;
            }
        }

        public bool IsOnline
        {
            [DebuggerStepThrough]
            get
            {
                return !IsOffline;
            }
        }

        public bool IsOffline
        {
            [DebuggerStepThrough]
            get
            {
                switch (this.Game.GameMode)
                {
                    case GameMode.HumanVsHuman:
                    case GameMode.HumanVsEngine:
                    case GameMode.EngineVsEngine:
                        return true;
                    default:
                        return false;
                }
            }
        }

        public bool IsEngineMove
        {
            [DebuggerStepThrough]
            get
            {
                return this.Game.CurrentPlayer.Engine != null && !this.Game.CurrentPlayer.Engine.IsClosed && this.Game.GameMode != GameMode.HumanVsHuman;
            }
        }

        public bool IsChangeNamesAllowed
        {
            [DebuggerStepThrough]
            get
            {
                if (Ap.Options.LockGameData && this.Game.GameMode == GameMode.HumanVsHuman)
                    return false;

                return true;
            }
        }

        public bool IsMyTurn
        {
            [DebuggerStepThrough]
            get
            {
                if (Game.DbGame.IsCurrentUserWhite)
                {
                    if (Game.Flags.IsFirtMove)
                    {
                        return true;
                    }
                    else
                    {
                        if (Game.CurrentMove.IsWhite)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    if (Game.Flags.IsFirtMove)
                    {
                        return false;
                    }
                    else
                    {
                        if (Game.CurrentMove.IsWhite)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }

        public bool AmIHuman
        {
            [DebuggerStepThrough]
            get
            {
                switch (this.Game.GameMode)
                {
                    case GameMode.HumanVsHuman:
                    case GameMode.OnlineHumanVsHuman:
                    case GameMode.Kibitzer:
                        return true;
                    case GameMode.HumanVsEngine:
                        return Ap.Game.CurrentPlayer.PlayerType == PlayerType.Human;
                    case GameMode.OnlineHumanVsEngine:
                        if (Game.DbGame.IsCurrentUserWhite && Game.Player1.PlayerType == PlayerType.Human)
                        {
                            return true;
                        }
                        else if (Game.DbGame.IsCurrentUserBlack && Game.Player2.PlayerType == PlayerType.Human)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    case GameMode.EngineVsEngine:
                    case GameMode.OnlineEngineVsEngine:
                        return false;
                }

                return false;
            }
        }

        public bool IsWhiteResigned
        {
            [DebuggerStepThrough]
            get
            {
                return this.Game.GameResult == GameResultE.WhiteLose && IsResigned;
            }
        }

        public bool IsBlackResigned
        {
            [DebuggerStepThrough]
            get
            {
                return this.Game.GameResult == GameResultE.WhiteWin && IsResigned;
            }
        }

        public bool IsGameFinished
        {
            [DebuggerStepThrough]
            get
            {
                return this.Game.GameResult != GameResultE.None && this.Game.GameResult != GameResultE.InProgress;
            }
        }

        public bool IsAdjudicateRequired
        {
            [DebuggerStepThrough]
            get
            {
                if (IsFirtMove)
                {
                    return false;
                }

                return !Game.Flags.IsFirtMove && !Game.Flags.IsGameFinished && Game.CurrentMove.MoveNo > 3;
            }
        }



        public bool IsStaleMated
        {
            [DebuggerStepThrough]

            get
            {
                return this.Game.Moves.Last.Flags.IsStaleMated;
            }
        }

        public bool IsThreeFoldRepetition { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.ThreeFoldRepetition); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.ThreeFoldRepetition, value); } }

        public bool IsMated
        {
            [DebuggerStepThrough]
            get
            {
                return this.Game.Moves.Last.Flags.IsMated;
            }
        }

        public bool IsDraw
        {
            [DebuggerStepThrough]
            get
            {
                return this.Game.GameResult == GameResultE.Draw;
            }
        }

        public bool AmIWhite
        {
            [DebuggerStepThrough]
            get
            {
                return this.Game.CurrentPlayer.IsWhite;
            }
        }

        public bool AmIBlack
        {
            [DebuggerStepThrough]
            get
            {
                return this.Game.CurrentPlayer.IsBlack;
            }
        }

        public bool IsNoClockGame
        {
            [DebuggerStepThrough]
            get
            {
                return IsOnline && this.Game.DbGame.GameTypeIDE == GameType.NoClock;
            }
        }
        #endregion

        #endregion

        #region GetFenFlags
        public string GetFenFlags()
        {
            string s = EnPassant == SquareE.NoSquare ? "-" : EnPassant.ToString().ToLower();

            return s + " " + GetFenCastlingFlags();
        }

        public string GetFenCastlingFlags()
        {
            string castling = "";

            castling += IsWhiteShortCastling ? "K" : "";
            castling += IsWhiteLongCastling ? "Q" : "";
            castling += IsBlackShortCastling ? "k" : "";
            castling += IsBlackLongCastling ? "q" : "";

            if (castling == "")
            {
                castling = "-";
            }

            return castling;
        }

        public override void Reset()
        {
            base.Reset();

            EnPassant = SquareE.NoSquare;

            IsWhiteShortCastling = true;
            IsWhiteLongCastling = true;
            IsBlackShortCastling = true;
            IsBlackLongCastling = true;
            IsEngineBlack = true;
            IsEngineOn = true;
            IsGameStart = true;
            IsMainline = true;
        }
        #endregion
    }
}
