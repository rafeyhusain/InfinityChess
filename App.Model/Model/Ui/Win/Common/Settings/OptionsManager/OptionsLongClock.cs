using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
namespace App.Model
{
    public class OptionsLongClock
    {
        #region DataMember

        public Kv Kv = new Kv();

        #endregion

        #region Ctor

        public OptionsLongClock()
        {
            Load();
        }
        public OptionsLongClock(string xml)
        {
            if (!String.IsNullOrEmpty(xml))
            {
                LoadXml(xml);
            }
        }

        #endregion

        #region Instance
        private static OptionsLongClock instance = null;
        public static OptionsLongClock Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OptionsLongClock();
                }

                return instance;
            }
            set { instance = value; }
        }

        #endregion

        #region Properties

        #region FirstControl

        public long FirstControlHour
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToLong(Kv.Get(Kv.DataTable, "FirstControlHour"),2);
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "FirstControlHour", value);
            }
        }

        public long FirstControlMinute
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToLong(Kv.Get(Kv.DataTable, "FirstControlMinute"),2);
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "FirstControlMinute", value);
            }
        }

        public long FirstControlMoves
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToLong(Kv.Get(Kv.DataTable, "FirstControlMoves"),40);
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "FirstControlMoves", value);
            }
        }

        public long FirstControlGainPerMoves
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToLong(Kv.Get(Kv.DataTable, "FirstControlGainPerMoves"),0);
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "FirstControlGainPerMoves", value);
            }
        }

        #endregion

        #region SecondControl
        public long SecondControlHour
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToLong(Kv.Get(Kv.DataTable, "SecondControlHour"),1);
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "SecondControlHour", value);
            }
        }

        public long SecondControlMinute
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToLong(Kv.Get(Kv.DataTable, "SecondControlMinute"),0);
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "SecondControlMinute", value);
            }
        }

        public long SecondControlMoves
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToLong(Kv.Get(Kv.DataTable, "SecondControlMoves"),20);
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "SecondControlMoves", value);
            }
        }

        public long SecondControlGainPerMoves
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToLong(Kv.Get(Kv.DataTable, "SecondControlGainPerMoves"),0);
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "SecondControlGainPerMoves", value);
            }
        }
        #endregion

        #region ThirdControl

        public long ThirdControlHour
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToLong(Kv.Get(Kv.DataTable, "ThirdControlHour"),0);
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "ThirdControlHour", value);
            }
        }

        public long ThirdControlMinute
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToLong(Kv.Get(Kv.DataTable, "ThirdControlMinute"),30);
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "ThirdControlMinute", value);
            }
        }

        public long ThirdControlGainPerMove
        {
            [DebuggerStepThrough]
            get
            {
                return BaseItem.ToLong(Kv.Get(Kv.DataTable, "ThirdControlGainPerMove"),0);
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "ThirdControlGainPerMove", value);
            }
        }

        #endregion

        #endregion

        #region Load/Save

        public void Load()
        {
            Load(Ap.FileOptionsLongClockXml);
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
            Save(Ap.FileOptionsLongClockXml);
        }

        public void Save(string filePath)
        {
            this.Kv.WriteXml(filePath);
        }

        #endregion

        #region Reset
        public void ResetFactorySettings()
        {
            // set First Control
            FirstControlHour = 2;
            FirstControlMinute = 2;
            FirstControlMoves = 40;
            FirstControlGainPerMoves = 0;

            // set Second Control
            SecondControlHour = 1;
            SecondControlMinute = 0;
            SecondControlMoves = 20;
            SecondControlGainPerMoves = 0;

            // set Third Control
            ThirdControlHour = 0;
            ThirdControlMinute = 30;
            ThirdControlGainPerMove = 0;

            Save();
        }
        #endregion
    }
}
