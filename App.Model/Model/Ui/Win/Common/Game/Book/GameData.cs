using System;
using App.Model;
using System.Collections.Generic;

using System.Text;
using InfinityChess;
using System.IO;
using InfinitySettings.Streams;
using System.Diagnostics;
using System.Data;
namespace App.Model
{
    public class GameData
    {
        #region Data Members
        public Game Game = null;
        public Kv Kv = new Kv();

        #endregion

        #region Ctor

        public GameData(Game game)
        {
            this.Game = game;
            Load();
        }

        public GameData(Game game, string xml)
        {
            this.Game = game;
            if (!String.IsNullOrEmpty(xml))
            {
                LoadXml(xml);
            }
        }

        #endregion

        #region Properties

        #region GameData Players and Result
        public string TournamentGuid
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "TournamentGuid");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "TournamentGuid", value);
            }
        }

        public int TournamentMatchID
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetInt32(Kv.DataTable, "TournamentMatchID");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "TournamentMatchID", value);
            }
        }

        public string White1
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "White1");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "White1", value);
            }
        }
        public string Black1
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "Black1");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "Black1", value);
            }
        }
        public string White2
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "White2");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "White2", value);
            }
        }
        public string Black2
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "Black2");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "Black2", value);
            }
        }
        public string Tournament
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "Tournament");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "Tournament", value);
            }
        }
        public bool IsECO
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "IsECO");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "IsECO", value);
            }
        }
        public string EcoCode
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "EcoCode");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "EcoCode", value);
            }
        }

        public string EcoDefaultDescription
        {
            [DebuggerStepThrough]
            get
            {
                string desc = "";

                DataView dv = Ap.Eco.Kv.DataTable.DefaultView;
                dv.RowFilter = Kv.ValueName + " like '%" + EcoCode + "%'";                
                if (dv.Count > 0)
                {
                    desc = dv[0][Kv.ValueName].ToString();
                    desc = desc.Substring(4);
                    dv.RowFilter = "";
                }

                return desc;
            }
        }

        public string EcoDescription
        {
            [DebuggerStepThrough]
            get
            {
                string desc = Kv.Get(Kv.DataTable, "EcoDescription");
                if (string.IsNullOrEmpty(desc))
                {
                    desc = EcoDefaultDescription;
                }

                return desc;
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "EcoDescription", value);
            }
        }

        public bool IsEloWhite
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "IsEloWhite");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "IsEloWhite", value);
            }
        }
        public decimal EloWhite
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(Kv.DataTable, "EloWhite");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "EloWhite", value);
            }
        }
        public bool IsEloBlack
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "IsEloBlack");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "IsEloBlack", value);
            }
        }
        public decimal EloBlack
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(Kv.DataTable, "EloBlack");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "EloBlack", value);
            }
        }        
        public string Result
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "Result");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "Result", value);
            }
        }
        public string ResultReason
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "ResultReason");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "ResultReason", value);
            }
        }

        public string Flags
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "Flags");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "Flags", value);
            }
        }

        public string ResultSymbol
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "ResultSymbol");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "ResultSymbol", value);
            }
        }
        public bool IsYear
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "IsYear");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "IsYear", value);
            }
        }
        public decimal Year
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(Kv.DataTable, "Year");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "Year", value);
            }
        }
        public bool IsMonth
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "IsMonth");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "IsMonth", value);
            }
        }
        public decimal Month
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(Kv.DataTable, "Month");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "Month", value);
            }
        }
        public bool IsDay
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "IsDay");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "IsDay", value);
            }
        }
        public decimal Day
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(Kv.DataTable, "Day");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "Day", value);
            }
        }

        #region Detail
        public string PlayerDetailPlace
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "PlayerDetailPlace");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "PlayerDetailPlace", value);
            }
        }
        public bool PlayerDetailIsYear
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "PlayerDetailIsYear");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "PlayerDetailIsYear", value);
            }
        }
        public decimal PlayerDetailYear
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(Kv.DataTable, "PlayerDetailYear");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "PlayerDetailYear", value);
            }
        }
        public bool PlayerDetailIsMonth
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "PlayerDetailIsMonth");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "PlayerDetailIsMonth", value);
            }
        }
        public decimal PlayerDetailMonth
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(Kv.DataTable, "PlayerDetailMonth");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "PlayerDetailMonth", value);
            }
        }
        public bool PlayerDetailIsDay
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "PlayerDetailIsDay");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "PlayerDetailIsDay", value);
            }
        }
        public decimal PlayerDetailDay
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(Kv.DataTable, "PlayerDetailDay");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "PlayerDetailDay", value);
            }
        }
        public bool PlayerDetailIsNotation
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "PlayerDetailIsNotation");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "PlayerDetailIsNotation", value);
            }
        }
        public string PlayerDetailNotation
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "PlayerDetailNotation");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "PlayerDetailNotation", value);
            }
        }
        public bool PlayerDetailIsRound
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "PlayerDetailIsRound");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "PlayerDetailIsRound", value);
            }
        }
        public decimal PlayerDetailRound
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(Kv.DataTable, "PlayerDetailRound");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "PlayerDetailRound", value);
            }
        }
        public bool PlayerDetailIsCategory
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "PlayerDetailIsCategory");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "PlayerDetailIsCategory", value);
            }
        }
        public decimal PlayerDetailCategory
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(Kv.DataTable, "PlayerDetailCategory");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "PlayerDetailCategory", value);
            }
        }
        public bool PlayerDetailIsType
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "PlayerDetailIsType");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "PlayerDetailIsType", value);
            }
        }
        public string PlayerDetailType
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "PlayerDetailType");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "PlayerDetailType", value);
            }
        }
        public bool PlayerDetailIsBoardPoint
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "PlayerDetailIsBoardPoint");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "PlayerDetailIsBoardPoint", value);
            }
        }
        public bool PlayerDetailIsCompleted
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "PlayerDetailIsCompleted");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "PlayerDetailIsCompleted", value);
            }
        }
        public string PlayerDetailTime
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "PlayerDetailTime");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "PlayerDetailTime", value);
            }
        }
        #endregion

        #endregion

        #region GameData Anotators & Teams


        #region Detail White Team

        public decimal WhiteDetailTeamNumber
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(Kv.DataTable, "WhiteDetailTeamNumber");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "WhiteDetailTeamNumber", value);
            }
        }
        public decimal WhiteDetailYear
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(Kv.DataTable, "WhiteDetailYear");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "WhiteDetailYear", value);
            }
        }
        public bool WhiteDetailIsNotation
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "WhiteDetailIsNotation");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "WhiteDetailIsNotation", value);
            }
        }
        public string WhiteDetailNotation
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "WhiteDetailNotation");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "WhiteDetailNotation", value);
            }
        }
        public bool WhiteDetailSeason
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "WhiteDetailSeason");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "WhiteDetailSeason", value);
            }
        }
        #endregion
        #region Detail Black Team

        public decimal BlackDetailTeamNumber
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(Kv.DataTable, "BlackDetailTeamNumber");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "BlackDetailTeamNumber", value);
            }
        }
        public decimal BlackDetailYear
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(Kv.DataTable, "BlackDetailYear");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "BlackDetailYear", value);
            }
        }
        public bool BlackDetailIsNotation
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "BlackDetailIsNotation");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "BlackDetailIsNotation", value);
            }
        }
        public string BlackDetailNotation
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "BlackDetailNotation");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "BlackDetailNotation", value);
            }
        }
        public bool BlackDetailSeason
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "BlackDetailSeason");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "BlackDetailSeason", value);
            }
        }

        #endregion
        #region Detail Source Team

        public string SourceDetailPublisher
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "SourceDetailPublisher");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "SourceDetailPublisher", value);
            }
        }
        public string SourceDetailPublication
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "SourceDetailPublication");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "SourceDetailPublication", value);
            }
        }
        public string SourceDetailDate
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "SourceDetailDate");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "SourceDetailDate", value);
            }
        }
        public decimal SourceDetailVersion
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(Kv.DataTable, "SourceDetailVersion");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "SourceDetailVersion", value);
            }
        }
        public string SourceDetailQuality
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "SourceDetailQuality");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "SourceDetailQuality", value);
            }
        }
        #endregion

        #endregion

        #region Additional Properties
        public string Guid
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "Guid");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "Guid", value);
            }
        }

        public GameMode GameMode
        {
            [DebuggerStepThrough]
            get
            {
                return (GameMode)Kv.GetInt32(Kv.DataTable, "GameMode");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "GameMode", value.ToString("d"));
            }
        }

        public GameType GameType
        {
            [DebuggerStepThrough]
            get
            {
                return (GameType) Kv.GetInt32(Kv.DataTable, "GameType");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "GameType", value.ToString("d"));
            }
        }

        public GameResultE GameResult
        {
            [DebuggerStepThrough]
            get
            {
                return (GameResultE)Kv.GetInt32(Kv.DataTable, "GameResult");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "GameResult", value.ToString("d"));
            }
        }

        public string Moves
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "Moves");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "Moves", value);
            }
        }

        public string InitialBoardFen
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "InitialBoardFen");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "InitialBoardFen", value);
            }
        }
        
        public string OptionsBlitzClock
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "OptionsBlitzClock");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "OptionsBlitzClock", value);
            }
        }

        public string OptionsLongClock
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "OptionsLongClock");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "OptionsLongClock", value);
            }
        }
        #endregion

        #endregion

        #region Calculated Properties

        public GameResultReasonE ResultReasonE
        {
            get
            {
                GameFlags flags  = GameFlags;
                if (flags.IsTimeExpired)
                {
                    return GameResultReasonE.TimeExpired;
                }
                else if (flags.IsResigned)
                {
                    return GameResultReasonE.Resigned;
                }
                else if (flags.IsMated)
                {
                    return GameResultReasonE.Mated;
                }
                else if (flags.IsThreeFoldRepetition)
                {
                    return GameResultReasonE.ThreeFoldRepetition;
                }
                else if (flags.IsInsufficientMaterial)
                {
                    return GameResultReasonE.InsufficientMaterial;
                }
                else if (flags.IsStaleMated)
                {
                    return GameResultReasonE.StaleMated;
                }
                else if (flags.IsDraw)
                {
                    if (flags.IsFiftyMoves)
                    {
                        return GameResultReasonE.FiftyMoves;
                    }
                    else
                    {
                        return GameResultReasonE.Draw;
                    }
                }
                else if (flags.IsAborted)
                {
                    return GameResultReasonE.Aborted;
                }

                return GameResultReasonE.None;
            }
        }

        public string PlayerLost
        {
            get
            {
                if (GameResult == GameResultE.WhiteWin)
                {
                    return BlackTitle + " Lost";
                }
                else if (GameResult == GameResultE.WhiteLose)
                {
                    return WhiteTitle + " Lost";
                }
                else
                {
                    return "";
                }
            }
        }

        public string ResultMessage
        {
            get
            {
                string msg = "";
                GameFlags flags = GameFlags;
                
                switch (ResultReasonE)
                {
                    case GameResultReasonE.TimeExpired:
                        return "Time ";

                    case GameResultReasonE.Resigned:
                        if (flags.IsOffline)
                        {
                            if (flags.IsWhiteResigned)
                            {
                                msg = WhiteTitle + " resigned";
                            }
                            else
                            {
                                msg = BlackTitle + " resigned";
                            }
                        }
                        break;
                    case GameResultReasonE.Mated:
                        if (flags.IsOnline && flags.IsMyTurn)
                        {
                            msg = "Mated ";
                        }
                        else
                        {
                            msg = "Mated";
                        }
                        if (flags.IsOffline)
                        {
                            msg = "Mated ";
                        }
                        break;
                    case GameResultReasonE.ThreeFoldRepetition:
                        msg = "Threefold repetition";
                        break;
                    case GameResultReasonE.StaleMated:
                        msg = "Stale mated";
                        break;
                    case GameResultReasonE.FiftyMoves:
                        msg = "Fifty moves";
                        break;
                    case GameResultReasonE.Draw:
                        msg = "Game draw by mutual agreement ";
                        break;
                    case GameResultReasonE.Aborted:
                        msg = "Aborted";
                        break;
                }

                return msg;
            }
        }

        public string GameResultString
        {
            get
            {
                string resultReason = ResultMessage;// ResultReason.ToString();
                GameFlags flags = GameFlags;

                switch (GameResult)
                {
                    case GameResultE.WhiteWin:
                        return resultReason + " 1-0";
                    case GameResultE.WhiteLose:
                        if (flags.IsSuddenDeathResult)
                        {
                            return "Sudden Death 0-1 (" + resultReason + " 1/2-1/2)";
                        }
                        else
                        {
                            return resultReason + " 0-1";
                        }                        
                    case GameResultE.Draw:
                        return resultReason + " 1/2-1/2";
                    case GameResultE.Absent:
                        return resultReason + " Absent";
                    case GameResultE.NoResult:
                        return resultReason + " NoResult";
                }

                return "";
            }
        }

        public string WhiteTitle
        {
            //[DebuggerStepThrough]
            get
            {
                string whiteTitle = string.Empty;
                whiteTitle += White1;

                if (!string.IsNullOrEmpty(White2))
                    whiteTitle += ",";

                whiteTitle += White2;

                return whiteTitle;
            }
        }

        public string BlackTitle
        {
            //[DebuggerStepThrough]
            get
            {
                string blackTitle = string.Empty;
                blackTitle += Black1;

                if (!string.IsNullOrEmpty(Black2))
                    blackTitle += ",";

                blackTitle += Black2;

                return blackTitle;
            }
        }

        public string GamePlayers
        {
            [DebuggerStepThrough]
            get
            {
                return WhiteTitle + " - " + BlackTitle;
            }
        }

        public DateTime Date
        {
            [DebuggerStepThrough]
            get
            {
                return new DateTime((int)Year, (int)Month, (int)Day);
            }
        }

        public string DateString
        {
            [DebuggerStepThrough]
            get
            {
                return Date.ToShortDateString();
            }
        }

        public string EcoTitle
        {
            [DebuggerStepThrough]
            get
            {
                if (string.IsNullOrEmpty(EcoCode))
                {
                    return "";
                }

                return EcoCode + " " + EcoDescription;
            }
        }

        public GameFlags GameFlags
        {
            [DebuggerStepThrough]
            get
            {
                return new GameFlags(this.Game, Flags);
            }
        }

        #endregion

        #region Load/Save

        public void Load()
        {
            Load(Ap.FileGameDataXml);
        }

        public void Load(string filePath)
        {
            this.Kv.ReadXml(filePath);
        }

        public void LoadXml(string xml)
        {
            MemoryStream memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(xml));
            this.Kv.ReadXml(memoryStream);
            memoryStream.Close();
            memoryStream = null;            
        }

        public void Save()
        {
            Save(Ap.FileGameDataXml);
        }

        public void Save(string filePath)
        {
            this.Kv.WriteXml(filePath);
        }

        #endregion

        public bool IsPlayersSwapped = false;
        public void NewGame()
        {
            IsECO = false;
            EcoCode = string.Empty;
            EcoDescription = string.Empty;
            EloWhite = 0;
            EloBlack = 0;
            Result = string.Empty;
            IsPlayersSwapped = false;

            Year = DateTime.Now.Year;
            Month = DateTime.Now.Month;
            Day = DateTime.Now.Day;
            IsYear = true;
            IsMonth = true;
            IsDay = true;            
        }

        public void Clear()
        {
            TournamentGuid = "-1";
            TournamentMatchID = -1;
            White1 = string.Empty;
            White2 = string.Empty;
            Black1 = string.Empty;
            Black2 = string.Empty;
            Tournament = string.Empty;
            IsECO = false;
            EcoCode = string.Empty;
            EcoDescription = string.Empty;
            EloWhite = 0;
            IsEloWhite = false;
            EloBlack = 0;
            IsEloBlack = false;
            Result = string.Empty;
            ResultReason = string.Empty;
            IsYear = true;
            Year = Convert.ToDecimal(DateTime.Now.Year);
            IsMonth = true;
            Month = Convert.ToDecimal(DateTime.Now.Month);
            IsDay = true;
            Day = Convert.ToDecimal(DateTime.Now.Day);
        
        }

        public void SetPlayers(string white1,string white2,string black1,string black2)
        {
            White1 = white1;
            White2 = white2;
            Black1 = black1;
            Black2 = black2;
        }
    }
}
