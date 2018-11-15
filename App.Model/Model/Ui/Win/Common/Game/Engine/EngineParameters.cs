using System; using App.Model;
using System.Collections.Generic;

using System.Text;
using InfinityChess;
using System.IO;
using InfinitySettings.Streams;
using System.Diagnostics;
namespace App.Model
{
    /*
    public class EngineParameters
    {
        #region Data Members
        public Game Game = null;
        public Kv Kv = new Kv();      

        #endregion

        #region Ctor

        public EngineParameters(Game game)
        {
            this.Game = game;
            Load();
        }

        public EngineParameters(string contentXml)
        {
            if (!String.IsNullOrEmpty(contentXml))
            {
                LoadXml(contentXml);
            }
        }

        #endregion

        #region Properties

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

        #region Engine Parameters Properties 
                

        #endregion

        #region Load/Save

        public void Load()
        {
            Load(Ap.FileEngineParametersXml);
        }

        public void Load(string filePath)
        {
            this.Kv.ReadXml(filePath);
        }

        public void LoadXml(string contentXml)
        {
            MemoryStream memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(contentXml));
            this.Kv.ReadXml(memoryStream);
            memoryStream.Close();              
        }

        public void Save()
        {
            Save(Ap.FileEngineParametersXml);
        }

        public void Save(string filePath)
        {
            this.Kv.WriteXml(filePath);
        }

        #endregion
        
        #region New Game 

        public void SetupNewGame()
        {
            //// setup new game parameters
        }

        #endregion        
    }
    */
}
