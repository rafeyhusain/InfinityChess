using System;
using App.Model;
using System.Collections.Generic;

using System.Text;
using InfinityChess;
using System.IO;
using InfinitySettings.Streams;
using System.Diagnostics;
namespace App.Model
{
    #region Enum

    public enum BookOptionsType
    {
        Global = 0,
        WhiteEngine = 1,
        BlackEngine = 2,
        Optimize = 3,
        Normal = 4,
        Handicap = 5
    }

    #endregion

    public class BookOptions
    {
        #region Data Members

        public BookOptionsType OptionsType;
        public Kv Kv = new Kv();

        #endregion

        #region Ctor

        public BookOptions()
        {
            this.OptionsType = BookOptionsType.Global;
            Load();
        }


        public BookOptions(BookOptionsType type)
        {
            this.OptionsType = type;
            Load();
        }

        public BookOptions(BookOptionsType type, string xml)
        {
            this.OptionsType = type;

            if (!String.IsNullOrEmpty(xml))
            {
                LoadXml(xml);
            }
        }

        #endregion

        #region Instance
        private static BookOptions instance = null;
        public static BookOptions Instance
        {
            [DebuggerStepThrough]
            get
            {
                if (instance == null)
                {
                    instance = new BookOptions();
                }
                return instance;
            }
            [DebuggerStepThrough]
            set { instance = value; }
        }


        #endregion

        #region Properties

        #region Core

        #region Global

        public bool GlobalUseBook
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "GlobalUseBook");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "GlobalUseBook", value);
            }
        }

        public bool GlobalTournamentBook
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "GlobalTournamentBook");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "GlobalTournamentBook", value);
            }
        }

        public int GlobalMinGames
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetInt32(Kv.DataTable, "GlobalMinGames");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "GlobalMinGames", value);
            }
        }

        public int GlobalMaxMoves
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetInt32(Kv.DataTable, "GlobalMaxMoves");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "GlobalMaxMoves", value);
            }
        }

        #endregion

        #region White Engine

        public bool WhiteUseBook
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "WhiteUseBook");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "WhiteUseBook", value);
            }
        }

        public bool WhiteTournamentBook
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "WhiteTournamentBook");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "WhiteTournamentBook", value);
            }
        }

        public int WhiteMinGames
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetInt32(Kv.DataTable, "WhiteMinGames");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "WhiteMinGames", value);
            }
        }

        public int WhiteMaxMoves
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetInt32(Kv.DataTable, "WhiteMaxMoves");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "WhiteMaxMoves", value);
            }
        }

        #endregion

        #region Black Engine

        public bool BlackUseBook
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "BlackUseBook");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "BlackUseBook", value);
            }
        }

        public bool BlackTournamentBook
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "BlackTournamentBook");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "BlackTournamentBook", value);
            }
        }

        public int BlackMinGames
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetInt32(Kv.DataTable, "BlackMinGames");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "BlackMinGames", value);
            }
        }

        public int BlackMaxMoves
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetInt32(Kv.DataTable, "BlackMaxMoves");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "BlackMaxMoves", value);
            }
        }

        #endregion

        #region Optimize

        public bool OptimizeUseBook
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "OptimizeUseBook");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "OptimizeUseBook", value);
            }
        }

        public bool OptimizeTournamentBook
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "OptimizeTournamentBook");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "OptimizeTournamentBook", value);
            }
        }

        public int OptimizeMinGames
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetInt32(Kv.DataTable, "OptimizeMinGames");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "OptimizeMinGames", value);
            }
        }

        public int OptimizeMaxMoves
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetInt32(Kv.DataTable, "OptimizeMaxMoves");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "OptimizeMaxMoves", value);
            }
        }

        #endregion

        #region Normal

        public bool NormalUseBook
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "NormalUseBook");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "NormalUseBook", value);
            }
        }

        public bool NormalTournamentBook
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "NormalTournamentBook");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "NormalTournamentBook", value);
            }
        }

        public int NormalMinGames
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetInt32(Kv.DataTable, "NormalMinGames");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "NormalMinGames", value);
            }
        }

        public int NormalMaxMoves
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetInt32(Kv.DataTable, "NormalMaxMoves");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "NormalMaxMoves", value);
            }
        }

        #endregion

        #region Handicap

        public bool HandicapUseBook
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "HandicapUseBook");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "HandicapUseBook", value);
            }
        }

        public bool HandicapTournamentBook
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "HandicapTournamentBook");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "HandicapTournamentBook", value);
            }
        }

        public int HandicapMinGames
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetInt32(Kv.DataTable, "HandicapMinGames");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "HandicapMinGames", value);
            }
        }

        public int HandicapMaxMoves
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetInt32(Kv.DataTable, "HandicapMaxMoves");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "HandicapMaxMoves", value);
            }
        }

        #endregion

        #endregion

        #region Calculated

        public bool UseBook
        {
            [DebuggerStepThrough]
            get
            {
                switch (OptionsType)
                {
                    case BookOptionsType.Global:
                        return GlobalUseBook;
                    case BookOptionsType.WhiteEngine:
                        return WhiteUseBook;
                    case BookOptionsType.BlackEngine:
                        return BlackUseBook;
                    case BookOptionsType.Optimize:
                        return OptimizeUseBook;
                    case BookOptionsType.Normal:
                        return NormalUseBook;
                    case BookOptionsType.Handicap:
                        return HandicapUseBook;
                    default:
                        throw new Exception("Undefined BookOptions Type...");
                }
            }
            [DebuggerStepThrough]
            set
            {
                switch (OptionsType)
                {
                    case BookOptionsType.Global:
                        GlobalUseBook = value;
                        break;
                    case BookOptionsType.WhiteEngine:
                        WhiteUseBook = value;
                        break;
                    case BookOptionsType.BlackEngine:
                        BlackUseBook = value;
                        break;
                    case BookOptionsType.Optimize:
                        OptimizeUseBook = value;
                        break;
                    case BookOptionsType.Normal:
                        NormalUseBook = value;
                        break;
                    case BookOptionsType.Handicap:
                        HandicapUseBook = value;
                        break;
                    default:
                        throw new Exception("Undefined BookOptions Type...");
                }
            }
        }

        public bool TournamentBook
        {
            [DebuggerStepThrough]
            get
            {
                switch (OptionsType)
                {
                    case BookOptionsType.Global:
                        return GlobalTournamentBook;
                    case BookOptionsType.WhiteEngine:
                        return WhiteTournamentBook;
                    case BookOptionsType.BlackEngine:
                        return BlackTournamentBook;
                    case BookOptionsType.Optimize:
                        return OptimizeTournamentBook;
                    case BookOptionsType.Normal:
                        return NormalTournamentBook;
                    case BookOptionsType.Handicap:
                        return HandicapTournamentBook;
                    default:
                        throw new Exception("Undefined BookOptions Type..."); ;
                }
            }
            [DebuggerStepThrough]
            set
            {
                switch (OptionsType)
                {
                    case BookOptionsType.Global:
                        GlobalTournamentBook = value;
                        break;
                    case BookOptionsType.WhiteEngine:
                        WhiteTournamentBook = value;
                        break;
                    case BookOptionsType.BlackEngine:
                        BlackTournamentBook = value;
                        break;
                    case BookOptionsType.Optimize:
                        OptimizeTournamentBook = value;
                        break;
                    case BookOptionsType.Normal:
                        NormalTournamentBook = value;
                        break;
                    case BookOptionsType.Handicap:
                        HandicapTournamentBook = value;
                        break;
                    default:
                        throw new Exception("Undefined BookOptions Type..."); ;
                }
            }
        }

        public int MinGames
        {
            [DebuggerStepThrough]
            get
            {
                switch (OptionsType)
                {
                    case BookOptionsType.Global:
                        return GlobalMinGames;
                    case BookOptionsType.WhiteEngine:
                        return WhiteMinGames;
                    case BookOptionsType.BlackEngine:
                        return BlackMinGames;
                    case BookOptionsType.Optimize:
                        return OptimizeMinGames;
                    case BookOptionsType.Normal:
                        return NormalMinGames;
                    case BookOptionsType.Handicap:
                        return HandicapMinGames;
                    default:
                        throw new Exception("Undefined BookOptions Type..."); ;
                }
            }
            [DebuggerStepThrough]
            set
            {
                switch (OptionsType)
                {
                    case BookOptionsType.Global:
                        GlobalMinGames = value;
                        break;
                    case BookOptionsType.WhiteEngine:
                        WhiteMinGames = value;
                        break;
                    case BookOptionsType.BlackEngine:
                        BlackMinGames = value;
                        break;
                    case BookOptionsType.Optimize:
                        OptimizeMinGames = value;
                        break;
                    case BookOptionsType.Normal:
                        NormalMinGames = value;
                        break;
                    case BookOptionsType.Handicap:
                        HandicapMinGames = value;
                        break;
                    default:
                        throw new Exception("Undefined BookOptions Type..."); ;
                }
            }
        }

        public int MaxMoves
        {
            [DebuggerStepThrough]
            get
            {
                switch (OptionsType)
                {
                    case BookOptionsType.Global:
                        return GlobalMaxMoves;
                    case BookOptionsType.WhiteEngine:
                        return WhiteMaxMoves;
                    case BookOptionsType.BlackEngine:
                        return BlackMaxMoves;
                    case BookOptionsType.Optimize:
                        return OptimizeMaxMoves;
                    case BookOptionsType.Normal:
                        return NormalMaxMoves;
                    case BookOptionsType.Handicap:
                        return HandicapMaxMoves;
                    default:
                        throw new Exception("Undefined BookOptions Type..."); ;
                }
            }
            [DebuggerStepThrough]
            set
            {
                switch (OptionsType)
                {
                    case BookOptionsType.Global:
                        GlobalMaxMoves = value;
                        break;
                    case BookOptionsType.WhiteEngine:
                        WhiteMaxMoves = value;
                        break;
                    case BookOptionsType.BlackEngine:
                        BlackMaxMoves = value;
                        break;
                    case BookOptionsType.Optimize:
                        OptimizeMaxMoves = value;
                        break;
                    case BookOptionsType.Normal:
                        NormalMaxMoves = value;
                        break;
                    case BookOptionsType.Handicap:
                        HandicapMaxMoves = value;
                        break;
                    default:
                        throw new Exception("Undefined BookOptions Type..."); ;
                }
            }
        }

        #endregion

        #endregion

        #region Load/Save

        public void Load()
        {
            Load(Ap.FileBookOptions);
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
        }

        public void Save()
        {
            Save(Ap.FileBookOptions);
        }

        public void Save(string filePath)
        {
            this.Kv.WriteXml(filePath);
        }

        #endregion


        public void CreateKv()
        {
            // Current
            this.GlobalUseBook = true;
            this.GlobalTournamentBook = false;
            this.GlobalMinGames = 2;
            this.GlobalMaxMoves = 30;

            // White
            this.WhiteUseBook = true;
            this.WhiteTournamentBook = false;
            this.WhiteMinGames = 2;
            this.WhiteMaxMoves = 30;

            // Black
            this.BlackUseBook = true;
            this.BlackTournamentBook = false;
            this.BlackMinGames = 2;
            this.BlackMaxMoves = 30;

            // Optimize
            this.OptimizeUseBook = true;
            this.OptimizeTournamentBook = true;
            this.OptimizeMinGames = 3;
            this.OptimizeMaxMoves = 35;

            // Normal
            this.NormalUseBook = true;
            this.NormalTournamentBook = false;
            this.NormalMinGames = 2;
            this.NormalMaxMoves = 30;

            // Handicap
            this.HandicapUseBook = true;
            this.HandicapTournamentBook = false;
            this.HandicapMinGames = 50;
            this.HandicapMaxMoves = 20;

            Save();
        }
    }
}
