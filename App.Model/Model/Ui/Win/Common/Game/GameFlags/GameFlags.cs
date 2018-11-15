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
        public const string Aborted = "A";

        public const string InfiniteAnalysisStarted = "B";
        public const string InfiniteAnalysisStopped = "b";

        public const string InfiniteAnalysisGoButtonPressed = "C";
        public const string EngineResponseReceived = "c";

        public const string ChallengerSendsGame = "D";
        public const string DatabaseGame = "d";

        public const string EngineBlack = "E";
        public const string EngineOn = "e";

        public const string BoardSetByFen = "F";
        public const string FiftyMoves = "f";

        public const string NewGameStartClock = "G";
        public const string PastGame = "g";

        public const string PositionPasted = "h";

        public const string ForceEngineToMove = "I";
        public const string BoradInitialized = "i";

        public const string ProcessOutputInInfiniteAnalysis = "J";
        public const string GameResult = "j";

        public const string WhiteShortCastling = "K";
        public const string BlackShortCastling = "k";

        public const string InsufficientMaterial = "M";
        public const string ForceEngineToMoveInInfiniteAnalysis = "m";

        public const string Navigation = "N";
        public const string NewGame = "n";

        public const string ThreeFoldRepetition = "O";

        public const string BoardSetByPositionSetup = "p";

        public const string WhiteLongCastling = "Q";
        public const string BlackLongCastling = "q";

        public const string Resigned = "R";
        public const string RetracMove = "r";

        public const string PieceMovedSuccessfully = "S";
        public const string SuddenDeath = "s";
        
        public const string TimeExpired = "T";

        public const string MoveInProgress = "V";

        public const string ExamineMode = "x";

        public const string InfiniteAnalysisOn = "Y";

        public const string Ready = "Z"; 
        public const string Pause = "z"; // paused by some dialog
        
        #endregion

        #region Ctor

        public GameFlags(Game game)
        {
            Game = game;
        }

        public GameFlags(Game game, string gameFlags)
        {
            Game = game;
            this.flags = gameFlags;
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

        public bool IsBoardSetByFen { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.BoardSetByFen); } [DebuggerStepThrough]set { SetMoveFlag(GameFlags.BoardSetByFen, value); } }

        public bool IsEngineBlack { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.EngineBlack); } [DebuggerStepThrough]set { SetMoveFlag(GameFlags.EngineBlack, value); } }

        public bool IsResigned { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.Resigned); } set { SetMoveFlag(GameFlags.Resigned, value); } }
        public bool IsTimeExpired { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.TimeExpired); } [DebuggerStepThrough]set { SetMoveFlag(GameFlags.TimeExpired, value); } }

        public bool IsPieceMovedSuccessfully { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.PieceMovedSuccessfully); } [DebuggerStepThrough]set { SetMoveFlag(GameFlags.PieceMovedSuccessfully, value); } }

        public bool IsExamineMode { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.ExamineMode); } [DebuggerStepThrough]set { SetMoveFlag(GameFlags.ExamineMode, value); } }
        public bool IsForceEngineToMove { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.ForceEngineToMove); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.ForceEngineToMove, value); } }

        public bool IsMoveInProgress { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.MoveInProgress); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.MoveInProgress, value); } }
        public bool IsInfiniteAnalysisOn { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.InfiniteAnalysisOn); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.InfiniteAnalysisOn, value); } }

        public bool IsRetracMove { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.RetracMove); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.RetracMove, value); } }

        public bool IsEngineOn { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.EngineOn); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.EngineOn, value); } }

        public bool IsThreeFoldRepetition { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.ThreeFoldRepetition); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.ThreeFoldRepetition, value); } }
        public bool IsInsufficientMaterial { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.InsufficientMaterial); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.InsufficientMaterial, value); } }

        public bool IsFiftyMoves { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.FiftyMoves); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.FiftyMoves, value); } }
        public bool IsSuddenDeathResult { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.SuddenDeath); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.SuddenDeath, value); } }

        public bool IsInfiniteAnalysisStarted { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.InfiniteAnalysisStarted); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.InfiniteAnalysisStarted, value); } }

        public bool IsInfiniteAnalysisStopped { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.InfiniteAnalysisStopped); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.InfiniteAnalysisStopped, value); } }

        public bool IsProcessOutputInInfiniteAnalysis { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.ProcessOutputInInfiniteAnalysis); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.ProcessOutputInInfiniteAnalysis, value); } }


        public bool IsForceEngineToMoveInInfiniteAnalysis { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.ForceEngineToMoveInInfiniteAnalysis); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.ForceEngineToMoveInInfiniteAnalysis, value); } }

        public bool IsInfiniteAnalysisGoButtonPressed { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.InfiniteAnalysisGoButtonPressed); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.InfiniteAnalysisGoButtonPressed, value); } }

        public bool IsEngineResponseReceived { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.EngineResponseReceived); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.EngineResponseReceived, value); } }

        public bool IsNewGame { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.NewGame); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.NewGame, value); } }

        public bool IsDatabaseGame { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.DatabaseGame); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.DatabaseGame, value); } }

        public bool IsPaused { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.Pause); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.Pause, value); } }

        public bool IsReady { [DebuggerStepThrough] get { return Flags.Contains(GameFlags.Ready); } [DebuggerStepThrough] set { SetMoveFlag(GameFlags.Ready, value); } }

        #endregion

        #region Calculated
        public void ResetResultFlags()
        {
            IsMated = false;
            IsStaleMated = false;
            IsThreeFoldRepetition = false;
            IsFiftyMoves = false;
            IsInsufficientMaterial = false;
            IsTimeExpired = false;
            IsResigned = false;
        }

        public bool IsNotPaused { [DebuggerStepThrough] get { return !IsPaused; } }

        public bool IsNotReady { [DebuggerStepThrough] get { return !IsReady; } }

        public bool IsKibitzer
        {
            [DebuggerStepThrough]
            get
            {
                return Game.GameMode == GameMode.Kibitzer;
            }
        }

        public bool IsEvalRequired
        {
            [DebuggerStepThrough]
            get
            {
                return Game.CurrentPlayer.IsEngine && (Game.GameMode == GameMode.EngineVsEngine || (PlayingModeData.Instance.SendEvaluations && IsOnline));
            }
        }

        public bool IsExpectedMoveRequired
        {
            [DebuggerStepThrough]
            get
            {
                return Game.CurrentPlayer.IsEngine && PlayingModeData.Instance.SendExpectedMoves && IsOnline;
            }
        }

        public bool IsRootMove { [DebuggerStepThrough] get { return Game.CurrentMove.Id == -1; } }

        public bool IsBookLoadRequired
        {
            [DebuggerStepThrough]
            get
            {
                return Game.GameMode != GameMode.None && Game.GameMode != GameMode.OnlineHumanVsHuman;
            }
        }

        public bool IsVariationPossible
        {
            [DebuggerStepThrough]
            get
            {
                return Game.GameMode == GameMode.HumanVsHuman || Game.GameMode == GameMode.HumanVsEngine;
            }
        }

        public bool HasVariations
        {
            [DebuggerStepThrough]
            get
            {

                if (!IsVariationPossible)
                {
                    return false;
                }

                string filter = "";

                filter += Moves.MoveFlags + " like '%" + Moves.Variation + "%'";
                filter += " OR " + Moves.MoveFlags + " like '%" + Moves.VariationInsert + "%'";
                filter += " OR " + Moves.MoveFlags + " like '%" + Moves.VariationOverwrite + "%'";
                filter += " OR " + Moves.MoveFlags + " like '%" + Moves.VariationNewMainLine + "%'";

                return Game.Moves.Filter(filter).Count > 0;
            }
        }

        public bool IsFirstEngineMove
        {
            [DebuggerStepThrough]
            get
            {
                if ((Game.GameMode == GameMode.EngineVsEngine || Game.GameMode == GameMode.OnlineEngineVsEngine || Game.GameMode == GameMode.OnlineHumanVsEngine) && IsFirtMove)
                {
                    return true;
                }
                return false;
            }
        }

        public bool IsFirstMoveSelected
        {
            [DebuggerStepThrough]
            get
            {
                if (IsFirtMove)
                {
                    return true;
                }

                if (Game.CurrentMove.HasNoParent)
                {
                    return true;
                }

                return false;
            }
        }

        public bool IsRootMoveSelected
        {
            [DebuggerStepThrough]
            get
            {
                if (IsFirtMove)
                {
                    return true;
                }

                if (Game.Flags.IsRootMove)
                {
                    return true;
                }

                return false;
            }
        }

        public bool IsVariation
        {
            [DebuggerStepThrough]
            get
            {
                if (IsFirtMove)
                {
                    return false;
                }

                if (IsCurrentLineLastMove)
                {
                    return false;
                }

                return true;
            }
        }

        public bool IsCurrentLineLastMove
        {
            [DebuggerStepThrough]
            get
            {
                if (IsFirtMove)
                {
                    return true;
                }

                if (Game.Moves.GetChildren(Game.CurrentMove).Count == 0)
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

        public bool IsLastMove
        {
            [DebuggerStepThrough]
            get
            {
                if (Game.Moves == null)
                {
                    return true;
                }

                if (IsFirtMove)
                {
                    return true;
                }

                if (Game.CurrentMove.Id == Game.Moves.Last.Id)
                {
                    return true;
                }

                return false;
            }
        }

        public bool IsPositionSetupAllowed
        {
            [DebuggerStepThrough]
            get
            {
                if (Game.DbGame == null)
                {
                    return false;
                }

                return AmIChallenger && Game.DbGame.IsChallengerSendsGame;
            }
        }

        public bool IsPositionSetupEnabled { [DebuggerStepThrough] get { return AmIChallenger && IsChallengerSendsGame; } }

        public bool AmIChallenger
        {
            [DebuggerStepThrough]
            get
            {
                if (Game.DbGame == null)
                {
                    return false;
                }

                if (Game.DbGame.Challenge == null)
                {
                    return false;
                }

                return Game.DbGame.Challenge.AmIChallenger;
            }
        }

        public bool AmIOpponent 
        { 
            [DebuggerStepThrough] 
            get 
            {
                if (Game.DbGame == null)
                {
                    return false;
                }

                return Game.DbGame.Challenge.AmIOpponent; 
            } 
        }

        public bool IsWhiteCastling { [DebuggerStepThrough] get { return IsWhiteShortCastling || IsWhiteLongCastling; } [DebuggerStepThrough] set { IsWhiteShortCastling = IsWhiteLongCastling = value; } }

        public bool IsBlackCastling { [DebuggerStepThrough]get { return IsBlackShortCastling || IsBlackLongCastling; } [DebuggerStepThrough] set { IsBlackShortCastling = IsBlackLongCastling = value; } }

        public bool IsMoveEnable
        {
            [DebuggerStepThrough]
            get
            {
                if (IsOffline)
                {
                    return true;
                }

                if (IsPaused)
                {
                    return true;
                }

                if (IsExamineMode)
                {
                    return true;
                }

                if (IsChallengerSendsGame)
                {
                    return false;
                }

                if (Game.Flags.IsGameFinished)
                {
                    return false;
                }

                if (Game.Clock.IsCurrentPlayerTimeExpired)
                {
                    return false;
                }

                if (Game.DbGame == null)
                {
                    return false;
                }

                if (Game.DbGame.IsKibitzer)
                {
                    return false;
                }

                return IsMyTurn;
            }
        }

        public bool IsWhiteTurn
        {
            [DebuggerStepThrough]
            get
            {
                if (IsFirtMove)
                {
                    return this.Game.CurrentMove.IsWhite; // return 'w' or 'b' from Fen set by Position setup, paste fen or new game!
                }

                return !this.Game.CurrentMove.IsWhite; // if white move is placed on the board then it is black's turn
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
                switch (Game.GameMode)
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
                return Game.CurrentPlayer.Engine != null && !Game.CurrentPlayer.Engine.IsClosed && Game.GameMode != GameMode.HumanVsHuman;
            }
        }

        public bool IsChangeNamesAllowed
        {
            [DebuggerStepThrough]
            get
            {
                if (Ap.Options.LockGameData && Game.GameMode == GameMode.HumanVsHuman)
                    return false;

                return true;
            }
        }

        public bool IsUpdateGameRequired
        {
            [DebuggerStepThrough]
            get
            {
                if (Game.DbGame == null)
                {
                    return false;
                }

                return !(IsMyTurn || IsExamineMode || Game.DbGame.IsKibitzer);
            }
        }

        public bool IsGameWindowAutoCloseOnResult
        {
            [DebuggerStepThrough]
            get
            {

                return IsAborted || IsResigned || IsTimeExpired;
            }
        }

        public bool IsGameWindowAutoCloseRequired
        {
            [DebuggerStepThrough]
            get
            {

                return (IsAutoChallengeTypeGame || (IsTournamentMatch && !AmIHuman)) && Game.GameMode != GameMode.Kibitzer;
            }
        }

        public bool IsTournamentMatch
        {
            [DebuggerStepThrough]
            get
            {
                if (Game.DbGame == null)
                {
                    return false;
                }

                return Game.DbGame.IsTournamentMatch;
            }
        }

        public bool IsSuddenDeathMatch
        {
            [DebuggerStepThrough]
            get
            {
                if (!IsTournamentMatch)
                {
                    return false;
                }

                return this.Game.DbGame.TournamentMatch.TournamentMatchTypeE == TournamentMatchTypeE.SuddenDeath;
            }
        }

        public bool IsTournamentMatchTimeExpired
        {
            [DebuggerStepThrough]
            get
            {
                return IsTournamentMatch && IsFirtMove && AmIOpponent;
            }
        }

        public bool IsAutoChallengeTypeGame
        {
            [DebuggerStepThrough]
            get
            {

                return (PlayingModeData.Instance.ChessType == ChessTypeE.Engine && (PlayingModeData.Instance.AutometicAccepts || PlayingModeData.Instance.AutometicChallenges));
            }
        }

        public bool IsNotMyTurn
        {
            [DebuggerStepThrough]
            get
            {
                return !IsMyTurn;
            }
        }

        public bool IsMyTurn
        {
            [DebuggerStepThrough]
            get
            {
                if (Game.DbGame == null)
                {
                    return false;
                }

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
                else if (Game.DbGame.IsCurrentUserBlack)
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
                else
                {
                    return false;
                }
            }
        }

        public bool AmIHuman
        {
            [DebuggerStepThrough]
            get
            {
                switch (Game.GameMode)
                {
                    case GameMode.HumanVsHuman:
                    case GameMode.OnlineHumanVsHuman:
                    case GameMode.Kibitzer:
                        return true;
                    case GameMode.HumanVsEngine:
                        return Game.CurrentPlayer.PlayerType == PlayerType.Human;
                    case GameMode.OnlineHumanVsEngine:
                        if (Game.DbGame == null)
                        {
                            return true;
                        }

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
                return Game.GameResult == GameResultE.WhiteLose && IsResigned;
            }
        }

        public bool IsBlackResigned
        {
            [DebuggerStepThrough]
            get
            {
                return Game.GameResult == GameResultE.WhiteWin && IsResigned;
            }
        }

        public bool IsGameFinished
        {
            [DebuggerStepThrough]
            get
            {
                return Game.GameResult != GameResultE.None && Game.GameResult != GameResultE.InProgress;
            }
        }

        public bool IsEngineGameFinished
        {
            [DebuggerStepThrough]
            get
            {
                return IsGameFinished && Game.GameMode != GameMode.HumanVsEngine;
            }
        }

        public bool IsAdjudicateRequired
        {
            get
            {
                if (IsFirtMove)
                {
                    return false;
                }
                return !Game.Flags.IsGameFinished && Game.Moves.Count >= 6 && !IsDatabaseGame;
            }
        }

        public bool IsStaleMated
        {
            [DebuggerStepThrough]
            get
            {
                if (IsFirtMove)
                {
                    return false;
                }

                return Game.Moves.Last.Flags.IsStaleMated;
            }
            [DebuggerStepThrough]
            set
            {
                Game.Moves.Last.Flags.IsStaleMated = value;
            }
        }

        public bool IsMated
        {
            [DebuggerStepThrough]
            get
            {
                if (IsFirtMove)
                {
                    return false;
                }

                return Game.Moves.Last.Flags.IsMated;
            }
            [DebuggerStepThrough]
            set
            {
                Game.Moves.Last.Flags.IsStaleMated = value;
            }
        }

        public bool IsPromotion
        {
            [DebuggerStepThrough]
            get
            {
                if (IsFirtMove)
                {
                    return false;
                }

                return Game.Moves.Last.Flags.IsPromotion;
            }
        }

        public bool IsDraw { [DebuggerStepThrough] get { return Game.GameResult == GameResultE.Draw; } }

        public bool AmIWhite { [DebuggerStepThrough] get { return Game.CurrentPlayer.IsWhite; } }

        public bool AmIBlack { [DebuggerStepThrough] get { return Game.CurrentPlayer.IsBlack; } }

        public bool IsNoClockGame
        {
            [DebuggerStepThrough]
            get
            {
                return ((IsOnline && Game.DbGame != null && Game.DbGame.GameTypeIDE == GameType.NoClock)
                            || Game.Flags.IsInfiniteAnalysisOn
                            || Game.GameMode == GameMode.HumanVsHuman);
            }
        }

        public bool IsClockedGame
        {
            [DebuggerStepThrough]
            get
            {
                return !IsNoClockGame;
            }
        }

        public bool IsInfiniteAnalysisOff { [DebuggerStepThrough] get { return !IsInfiniteAnalysisOn; } }

        public bool IsClockStartRequired
        {
            [DebuggerStepThrough]
            get
            {
                return IsInfiniteAnalysisOff && Game.Clock.IsPaused && !IsGameFinished && !IsPaused;
            }
        }

        public bool NewEngineMatchRequired
        {
            [DebuggerStepThrough]
            get
            {
                return Game.GameMode == GameMode.EngineVsEngine
                        &&
                        !this.Game.E2EMatchesStopped
                        &&
                        (Game.E2EGamesCount < Ap.EngineOptions.NoOfGames || Ap.EngineOptions.NoGameLimit);
            }
        }

        public bool IsFlipBoardRequried
        {
            [DebuggerStepThrough]
            get
            {
                if (Game.GameMode == GameMode.EngineVsEngine && Ap.EngineOptions.FlipBoard && !Game.IsFlipped)
                {
                    return true;
                }

                return false;
            }
        }

        public bool IsMoveLimitExpired
        {
            [DebuggerStepThrough]
            get
            {
                if (!Game.Flags.IsDatabaseGame
                    && Game.GameMode == GameMode.EngineVsEngine
                    && Game.Moves.Count >= Ap.EngineOptions.MoveLimit
                    && !Ap.EngineOptions.NoMoveLimit)
                {
                    return true;
                }

                return false;
            }
        }

        public bool IsResignAllowed
        {
            [DebuggerStepThrough]
            get
            {
                if (Game.GameMode == GameMode.HumanVsHuman || Game.GameMode == GameMode.HumanVsEngine )
                {
                    return true;
                }

                return false;
            }
        }

        public bool IsSwapPlayersRequired
        {
            [DebuggerStepThrough]
            get
            {
                if (IsOnline)
                {
                    return false;
                }

                if (IsFirtMove)
                {
                    // if engine is black and next move is black
                    // OR
                    // if engine is white and next move is white
                    if ((!Game.NextMoveIsWhite && IsEngineBlack) || (Game.NextMoveIsWhite && !IsEngineBlack))
                    {
                        return true;
                    }
                }
                else
                {
                    // if engine is black and variation is white(clicked on white's move's cell)
                    // OR 
                    // if engine is white and variation is black(clicked on black's move's cell)
                    if ((Game.CurrentMove.IsWhite && IsEngineBlack) || (!Game.CurrentMove.IsWhite && !IsEngineBlack))
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public bool IsCurrentBookAvailable
        {
            [DebuggerStepThrough]
            get
            {
                return Game.CurrentPlayer.Book != null && Game.CurrentPlayer.Book.IsAvailable && (IsInfiniteAnalysisOff || IsForceEngineToMove);
            }
        }

        public bool IsDefaultBookAvailable
        {
            get
            {
                return Game.DefaultBook != null && Game.DefaultBook.IsAvailable;
            }
        }

        public bool IsNewGameMode
        {
            [DebuggerStepThrough]
            get
            {
                return Game.GameMode != Game.PreviousGameMode;
            }
        }

        public bool IsCurrentEngineClosed
        {
            [DebuggerStepThrough]
            get
            {
                return Game.CurrentPlayer.Engine == null
                        || Game.CurrentPlayer.Engine.IsClosed
                        || Game.CurrentPlayer.Engine.IsSwitchedOff
                        || (IsGameFinished && Game.GameMode != GameMode.HumanVsEngine)
                        || (!IsEngineOn && IsInfiniteAnalysisOff)
                        ;
            }
        }

        public bool IsAnalysisAllowed
        {
            [DebuggerStepThrough]
            get
            {
                return Game.GameMode == GameMode.HumanVsEngine;
            }
        }

        public bool IsResultPopupAllowed
        {
            [DebuggerStepThrough]
            get
            {
                return Game.ResultReason == GameResultReasonE.Mated 
                       && Game.GameMode != GameMode.EngineVsEngine
                       && !this.Game.Flags.IsDatabaseGame;
            }
        }

        public bool IsSelectNotationBlocked
        {
            [DebuggerStepThrough]
            get
            {
                switch (this.Game.GameMode)
                {
                    case GameMode.EngineVsEngine:
                    case GameMode.OnlineHumanVsHuman:
                    case GameMode.OnlineEngineVsEngine:
                        return true;
                        
                }
                return false;
            }
        }

        public bool IsE2eResultInitRequired
        {
            [DebuggerStepThrough]
            get
            {
                return Game.GameMode == GameMode.EngineVsEngine && Game.E2EGamesCount == 0;                
            }
        }

        public bool IsEngine1White
        {
            [DebuggerStepThrough]
            get
            {
                return Game.E2eResult.Engine1Name == Game.Player1.Engine.EngineName;
            }
        }

        public bool IsTournamentMatchForcedWin
        {
            get
            {
                switch (this.Game.GameResultID)
                {
                    case GameResultE.None:
                        return false;
                    case GameResultE.ForcedWhiteWin:
                    case GameResultE.ForcedWhiteLose:
                    case GameResultE.ForcedDraw:
                        return true;
                    default:
                        return false;
                }
            }
        }

        public bool IsForceEngineMoveAllowed
        {
            [DebuggerStepThrough]
            get
            {
                if (this.Game.SpaceBarCounter > 0 && this.Game.DefaultEngine != null)
                {
                    if ((!IsMoveInProgress && !IsEngineGameFinished))
                    {
                        if (((!this.Game.DefaultEngine.IsPonderMove || IsInfiniteAnalysisStopped) && IsInfiniteAnalysisOff) 
                            || (IsInfiniteAnalysisOn && IsInfiniteAnalysisGoButtonPressed))                        
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }

        #endregion

        #endregion

        #region GetFenFlags
        public string GetFenFlags()
        {
            string s = Game.EnPassant == SquareE.NoSquare ? "-" : Game.EnPassant.ToString().ToLower();

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

            IsWhiteShortCastling = true;
            IsWhiteLongCastling = true;
            IsBlackShortCastling = true;
            IsBlackLongCastling = true;
            IsEngineBlack = true;
            IsEngineOn = true;
            IsReady = true;
        }
        #endregion
    }
}
