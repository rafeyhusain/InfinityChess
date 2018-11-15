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
    public class Options
    {
        #region Data Members

        public Kv Kv = new Kv();

        #endregion

        #region Ctor

        public Options()
        {
            Load();
        }

        public Options(string xml)
        {
            if (!String.IsNullOrEmpty(xml))
            {
                LoadXml(xml);
            }
        }

        public Options(string filePath, bool unUsed)
        {
            Load(filePath);
        }

        #endregion

        #region Instance
        private static Options instance = null;
        public static Options Instance
        {
            //[DebuggerStepThrough]
            get
            {
                if (instance == null)
                {
                    instance = new Options();
                }
                return instance;
            }
            [DebuggerStepThrough]
            set { instance = value; }
        }
        #endregion

        #region Properties

        #region Clocks + Notations

        public string ClockType
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "ClockType");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "ClockType", value);
            }
        }
        public int PlayingTime
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToInt32(Kv.Get(Kv.DataTable, "PlayingTime"));
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "PlayingTime", value);
            }
        }
        public string NotationMode
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "NotationMode");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "NotationMode", value);
            }
        }

        #endregion

        #region Tablebases

        public string TablebasesPath1
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "TablebasesPath1");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "TablebasesPath1", value);
            }
        }

        public string TablebasesPath2
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "TablebasesPath2");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "TablebasesPath2", value);
            }
        }

        public string TablebasesPath3
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "TablebasesPath3");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "TablebasesPath3", value);
            }
        }

        public string TablebasesPath4
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "TablebasesPath4");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "TablebasesPath4", value);
            }
        }

        public int TablebasesCache
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToInt32(Kv.Get(Kv.DataTable, "TablebasesCache"));
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "TablebasesCache", value);
            }
        }

        public bool DoTablebasesLoadAtProgramStart
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToBool(Kv.Get(Kv.DataTable, "DoTablebasesLoadAtProgramStart"));
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "DoTablebasesLoadAtProgramStart", value);
            }
        }

        #endregion

        #region Multimedia

        public bool DoMultimediaBoardSounds
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToBool(Kv.Get(Kv.DataTable, "DoMultimediaBoardSounds"));
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "DoMultimediaBoardSounds", value);
            }
        }

        #endregion

        #region Clocks + Notations

        public bool LockGameData
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToBool(Kv.Get(Kv.DataTable, "LockGameData"));
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "LockGameData", value);
            }
        }

        #endregion

        #region Setting

        private static int _defaultHashTableSize = 311;
        public static int DefaultHashTableSize
        {
            [DebuggerStepThrough]
            get { return _defaultHashTableSize; }
            [DebuggerStepThrough]
            set { _defaultHashTableSize = value; }
        }

        private static UCIEngine _defaultEngine;
        public static UCIEngine DefaultEngine
        {
            [DebuggerStepThrough]
            get { return _defaultEngine; }
            [DebuggerStepThrough]
            set { _defaultEngine = value; }
        }

        private static InfinitySettings.EngineManager.Engine _defaultEngineXml;
        public static InfinitySettings.EngineManager.Engine DefaultEngineXml
        {
            [DebuggerStepThrough]
            get { return _defaultEngineXml; }
            [DebuggerStepThrough]
            set { _defaultEngineXml = value; }
        }

        #endregion

        #region Calculated
        public bool IsSingleNotation
        {
            [DebuggerStepThrough]
            get
            {
                return Ap.Options.NotationMode == "1.d4";
            }
        }
        #endregion

        #region DataGridView Display 
        public bool ShowHorizontalGrid
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToBool(Kv.Get(Kv.DataTable, "ShowHorizontalGrid"));
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "ShowHorizontalGrid", value);
            }
        }
        public bool ShowVerticalGrid
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToBool(Kv.Get(Kv.DataTable, "ShowVerticalGrid"));
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "ShowVerticalGrid", value);
            }
        }
        #endregion

        public GameType GameType
        {
            [DebuggerStepThrough]
            get
            {
                return (GameType)Kv.GetInt32(Kv.DataTable, "GameType");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "GameType", value.ToString("d"));
            }
        }

        #endregion

        #region Additional Properties

        public string CurrentBookFilePath
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "CurrentBookFilePath");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "CurrentBookFilePath", value);
            }
        }

        public string ApplicationCode
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "ApplicationCode");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "ApplicationCode", value);
                Save();
            }
        }

        public string ProductCode
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "ProductCode");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "ProductCode", value);                
            }
        }

        public string CurrentDatabaseFilePath
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "CurrentDatabaseFilePath");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "CurrentDatabaseFilePath", value);
            }
        }

        public string CurrentGameGuid
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "CurrentGameGuid");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "CurrentGameGuid", value);
            }
        }

        public string CurrentGameDatabaseFilePath
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "CurrentGameDatabaseFilePath");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "CurrentGameDatabaseFilePath", value);
            }
        }

        public string DefaultGameDatabaseFilePath
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "DefaultGameDatabaseFilePath");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "DefaultGameDatabaseFilePath", value);
            }
        }

        public string LoginID
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "LoginID");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "LoginID", value);
            }
        }

        public string Password
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "Password");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "Password", value);
            }
        }

        public string Version
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "Version");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "Version", value);
            }
        }

        public bool ShowCapturedPieces
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToBool(Kv.Get(Kv.DataTable, "ShowCapturedPieces"));
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "ShowCapturedPieces", value);
            }
        }

        public bool ShowGameInfo
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToBool(Kv.Get(Kv.DataTable, "ShowGameInfo"));
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "ShowGameInfo", value);
            }
        }

        public bool ShowComments
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToBool(Kv.Get(Kv.DataTable, "ShowComments"));
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "ShowComments", value);
            }
        }

        public bool ShowDisconnectionLog
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToBool(Kv.Get(Kv.DataTable, "ShowDisconnectionLog"));
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "ShowDisconnectionLog", value);
            }
        }
        
        #endregion

        #region Load/Save

        public void Load()
        {
            Load(Ap.FileOptionsXml);
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
            Save(Ap.FileOptionsXml);
        }

        public void Save(string filePath)
        {
            this.Kv.WriteXml(filePath);
        }

        #endregion

        #region Reset
        public void ResetFactorySettings()
        {
            //// set Clocks+Notations
            ClockType = "Digital";
            NotationMode = "1.d4";

            //// set Tablebases
            TablebasesPath1 = "";
            TablebasesPath2 = "";
            TablebasesPath3 = "";
            TablebasesPath4 = "";
            TablebasesCache = 3;
            DoTablebasesLoadAtProgramStart = true;

            //// set Multimedia
            DoMultimediaBoardSounds = true;
           
            //// set GlobalOptions
            CurrentBookFilePath = "";
            ApplicationCode = "";

            ProductCode = "{573D7C52-D0D7-40CF-95E9-C6189B42957D}";
            this.Version = Config.Version;

            ShowCapturedPieces = true;
            ShowGameInfo = true;
            ShowComments = true;
            ShowDisconnectionLog = false;

            ShowHorizontalGrid = true;
            ShowVerticalGrid = false;

            LoginID = "";
            Password = "";

            this.PlayingTime = 60;

            Save();
        }
        #endregion

        #region Methods
        public void SetApplicationCode()
        {
            if (string.IsNullOrEmpty(ApplicationCode))
            {
                ApplicationCode = Guid.NewGuid().ToString();
            }
        }
        #endregion

    }
}
