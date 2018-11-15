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
    public class EngineOptions
    {
        #region Data Members
        
        public Kv Kv = new Kv();
        
        #endregion

        #region Ctor

        public EngineOptions()
        {
            Load();
        }

        public EngineOptions(string xml)
        {
            if (!String.IsNullOrEmpty(xml))
            {
                LoadXml(xml);
            }
        }

        #endregion

        #region Instance

        private static EngineOptions instance = null;
        public static EngineOptions Instance
        {
            [DebuggerStepThrough]
            get
            {
                if (instance == null)
                {
                    instance = new EngineOptions();
                }
                return instance;
            }
            [DebuggerStepThrough]
            set { instance = value; }
        }

        #endregion

        #region Properties

        #region E2E Popup

        public string DatabaseFile
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "DatabaseFile");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "DatabaseFile", value);
            }
        }

        public string WhiteEngine
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "WhiteEngine");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "WhiteEngine", value);
            }
        }

        public string WhiteBook
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "WhiteBook");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "WhiteBook", value);
            }
        }

        public bool WhiteUseTablebases
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "WhiteUseTablebases");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "WhiteUseTablebases", value);
            }
        }

        public int WhiteHashTableSize
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetInt32(Kv.DataTable, "WhiteHashTableSize");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "WhiteHashTableSize", value);
            }
        }

        public string BlackEngine
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "BlackEngine");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "BlackEngine", value);
            }
        }

        public string BlackBook
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "BlackBook");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "BlackBook", value);
            }
        }

        public bool BlackUseTablebases
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "BlackUseTablebases");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "BlackUseTablebases", value);
            }
        }

        public int BlackHashTableSize
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetInt32(Kv.DataTable, "BlackHashTableSize");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "BlackHashTableSize", value);
            }
        }

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

        public int NoOfGames
        {
            [DebuggerStepThrough]
            get
            {
                return Convert.ToInt32(Kv.Get(Kv.DataTable, "NoOfGames"));
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "NoOfGames", value);
            }
        }

        public int MoveLimit
        {
            [DebuggerStepThrough]
            get
            {
                return Convert.ToInt32(Kv.Get(Kv.DataTable, "MoveLimit"));
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "MoveLimit", value);
            }
        }

        public bool NoGameLimit
        {
            [DebuggerStepThrough]
            get
            {
                return Convert.ToBoolean(Kv.Get(Kv.DataTable, "NoGameLimit"));
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "NoGameLimit", value);
            }
        }

        public bool NoMoveLimit
        {
            [DebuggerStepThrough]
            get
            {
                return Convert.ToBoolean(Kv.Get(Kv.DataTable, "NoMoveLimit"));
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "NoMoveLimit", value);
            }
        }
       
        public bool AlternateColor
        {
            [DebuggerStepThrough]
            get
            {
                return Convert.ToBoolean(Kv.Get(Kv.DataTable, "AlternateColor"));
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "AlternateColor", value);
            }
        }

        public bool FlipBoard
        {
            [DebuggerStepThrough]
            get
            {
                return Convert.ToBoolean(Kv.Get(Kv.DataTable, "FlipBoard"));
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "FlipBoard", value);
            }
        }

        #endregion

        #region LoadEngine Popup
                
        public bool UseTablebases
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "UseTablebases");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "UseTablebases", value);
            }
        }

        public int HashTableSize
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetInt32(Kv.DataTable, "HashTableSize");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "HashTableSize", value);
            }
        }

        #endregion

        #endregion

        #region Load/Save

        private void Init()
        {
            if (string.IsNullOrEmpty(Kv.Get(Kv.DataTable, "WhiteUseTablebases")))
            {
                WhiteUseTablebases = false;
            }
            if (string.IsNullOrEmpty(Kv.Get(Kv.DataTable, "WhiteHashTableSize")))
            {
                WhiteHashTableSize = 311;
            }
            if (string.IsNullOrEmpty(Kv.Get(Kv.DataTable, "BlackUseTablebases")))
            {
                BlackUseTablebases = false;
            }
            if (string.IsNullOrEmpty(Kv.Get(Kv.DataTable, "BlackHashTableSize")))
            {
                BlackHashTableSize = 311;
            }
            Save();
        }

        public void Load()
        {
            Load(Ap.FileEngineOptionsXml);
        }

        public void Load(string filePath)
        {
            this.Kv.ReadXml(filePath);
            //Init();
        }

        public void LoadXml(string xml)
        {
            MemoryStream memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(xml));
            this.Kv.ReadXml(memoryStream);
            memoryStream.Close();
        }

        public void Save()
        {
            Save(Ap.FileEngineOptionsXml);
        }

        public void Save(string filePath)
        {
            this.Kv.WriteXml(filePath);
        }

        #endregion
    }
}
