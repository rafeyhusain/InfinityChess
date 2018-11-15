using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace App.Model
{
    public class GameSearch
    {
        #region Data Members
        public Kv Kv = new Kv();
        #endregion

         #region Ctor

        public GameSearch()
        {
            Load();
        }


        #region BoardPosition
        public string BoardFen
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "BoardFen");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "BoardFen", value);
            }
        }       
        #endregion
        #region GameData Players and Result
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
        public string Annotator
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "Annotator");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "Annotator", value);
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
        public decimal Year1
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(Kv.DataTable, "Year1");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "Year1", value);
            }
        }
        public decimal Year2
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(Kv.DataTable, "Year2");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "Year2", value);
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
        public string EcoCode1
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "EcoCode1");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "EcoCode1", value);
            }
        }
        public string EcoCode2
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "EcoCode2");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "EcoCode2", value);
            }
        }

        public bool IsMoves
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "IsMoves");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "IsMoves", value);
            }
        }
        public decimal Moves1
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(Kv.DataTable, "Moves1");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "Moves1", value);
            }
        }
        public decimal Moves2
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(Kv.DataTable, "Moves2");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "Moves2", value);
            }
        }

        public decimal Elo1
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(Kv.DataTable, "Elo1");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "Elo1", value);
            }
        }
        public decimal Elo2
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(Kv.DataTable, "Elo2");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "Elo2", value);
            }
        }
        public bool IsNoneElo
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "IsNoneElo");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "IsNoneElo", value);
            }
        }
        public bool IsOneElo
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "IsOneElo");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "IsOneElo", value);
            }
        }
        public bool IsBothElo
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "IsBothElo");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "IsBothElo", value);
            }
        }
        public bool IsAverageElo
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "IsAverageElo");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "IsAverageElo", value);
            }
        }


        public bool IsWin
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "IsWin");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "IsWin", value);
            }
        }
        public bool IsLost
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "IsLost");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "IsLost", value);
            }
        }
        public bool IsDraw
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "IsDraw");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "IsDraw", value);
            }
        }
        public bool IsMated
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "IsMated");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "IsMated", value);
            }
        }
        public bool IsStalem
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "IsStalem");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "IsStalem", value);
            }
        }
        public bool IsCheck
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "IsCheck");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "IsCheck", value);
            }
        }

        #endregion
        #region Include/Exclude Option
        public bool IsPositonIncluded
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "IsPositonIncluded");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "IsPositonIncluded", value);
            }
        }
        public bool IsGameDataIncluded
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.GetBool(Kv.DataTable, "IsGameDataIncluded");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "IsGameDataIncluded", value);
            }
        }
        #endregion

        #region Load/Save

        public void Load()
        {
            Load(Ap.FileSearchGameDataXml);
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
            Save(Ap.FileSearchGameDataXml);
        }

        public void Save(string filePath)
        {
            this.Kv.WriteXml(filePath);
        }


        #endregion

         #endregion

    }
}
