using System; using App.Model;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using InfinityChess;
using System.IO;
using InfinitySettings.Streams;

namespace App.Model
{
    public class PlayingModeData
    {
        #region Data Members

        public Kv Kv = new Kv();               

        #endregion

        #region Ctor 

        public PlayingModeData()
        {
            Load();
        }

        public PlayingModeData(string xml)
        {
            if (!String.IsNullOrEmpty(xml))
            {
                LoadXml(xml);
            }
        }

        #endregion

        #region Instance
        private static PlayingModeData instance = null;
        public static PlayingModeData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlayingModeData();
                }

                return instance;
            }
            set { instance = value; }
        }

        #endregion

        #region Properties

        public bool Pause
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToBool(Kv.Get(Kv.DataTable, "Pause"));
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "Pause", value);
            }
        }

        public ChessTypeE ChessType
        {
            [DebuggerStepThrough]
            get
            {
                return (ChessTypeE) ChessTypeID;
            }
            [DebuggerStepThrough]
            set
            {
                ChessTypeID = (int)value;
            }
        }

        public int ChessTypeID
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetInt32(Kv.DataTable, "ChessType");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "ChessType", value);
            }
        }

        public int Time
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetInt32(Kv.DataTable, "Time");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "Time", value);
            }
        }

        public int GainPerMove
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetInt32(Kv.DataTable, "GainPerMove");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "GainPerMove", value);
            }
        }

        public bool AutometicChallenges
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToBool(Kv.Get(Kv.DataTable, "AutometicChallenges"));
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "AutometicChallenges", value);
            }
        }

        public bool AutometicAccepts
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToBool(Kv.Get(Kv.DataTable, "AutometicAccepts"));
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "AutometicAccepts", value);
            }
        }

        public bool SendEvaluations
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToBool(Kv.Get(Kv.DataTable, "SendEvaluations"));
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "SendEvaluations", value);
            }
        }

        public bool SendExpectedMoves
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToBool(Kv.Get(Kv.DataTable, "SendExpectedMoves"));
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "SendExpectedMoves", value);
            }
        }
        
        #endregion

        #region Load/Save

        public void Load()
        {
            Load(Ap.FilePlayingModeDataXml);
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
            Save(Ap.FilePlayingModeDataXml);
        }

        public void Save(string filePath)
        {
            this.Kv.WriteXml(filePath);
        }

        #endregion
      
    }
}
