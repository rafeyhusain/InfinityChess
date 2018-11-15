using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
namespace App.Model
{
    public class OptionsBlitzClock
    {
        #region DataMember

        public Kv Kv = new Kv();

        #endregion

        #region Ctor

        public OptionsBlitzClock()
        {
            Load();
        }

        public OptionsBlitzClock(string xml)
        {
            if (!String.IsNullOrEmpty(xml))
            {
                LoadXml(xml);
            }
        }

        #endregion

        #region Instance
        private static OptionsBlitzClock instance = null;
        public static OptionsBlitzClock Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OptionsBlitzClock();
                }

                return instance;
            }
            set { instance = value; }
        }

        #endregion

        #region Properties

        public int Time
        {
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "Time", value);
            }
            get
            {
                return BaseItem.ToInt32(Kv.Get(Kv.DataTable, "Time"),5);
            }

           
        }

        public int GainPerMove
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToInt32(Kv.Get(Kv.DataTable, "GainPerMove"),0);
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "GainPerMove", value);
            }
        }

        public int HumanBonus
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToInt32(Kv.Get(Kv.DataTable, "HumanBonus"),0);
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "HumanBonus", value);
            }
        }

        public int HumanBonusPerMove
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToInt32(Kv.Get(Kv.DataTable, "HumanBonusPerMove"),0);
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "HumanBonusPerMove", value);
            }
        }

        #endregion

        #region Load/Save

        public void Load()
        {
            Load(Ap.FileOptionsBlitzClockXml);
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
            Save(Ap.FileOptionsBlitzClockXml);
        }

        public void Save(string filePath)
        {
            this.Kv.WriteXml(filePath);
        }

        #endregion

        #region Reset
        public void ResetFactorySettings()
        {
            // set Blitz Options
            Time = 5;
            GainPerMove = 0;
            HumanBonus = 0;
            HumanBonusPerMove = 0;

            Save();
        }
        #endregion
    }
}
