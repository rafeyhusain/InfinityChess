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
    public class ParametersFiles
    {
        #region Data Members 
        public Kv Kv = new Kv();
        #endregion

        #region Ctor

        public ParametersFiles()
        {
            Load();
        }

        public ParametersFiles(string xml)
        {
            if (!String.IsNullOrEmpty(xml))
            {
                LoadXml(xml);
            }
        }

        #endregion

        #region Instance
        private static ParametersFiles instance = null;
        public static ParametersFiles Instance
        {
            [DebuggerStepThrough]
            get
            {
                if (instance == null)
                {
                    instance = new ParametersFiles();
                }
                return instance;
            }
            [DebuggerStepThrough]
            set { instance = value; }
        }
        #endregion

        #region Get/Set Methods 

        public string Get(string key)
        {
            return Kv.Get(Kv.DataTable, key);
        }

        public void Set(string key,string value)
        {
            Kv.Set(Kv.DataTable, key, value);
        }

        #endregion

        #region Load/Save

        public void Load()
        {
            Load(Ap.FileParametersFilesXml);
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
            GC.Collect();
        }

        public void Save()
        {
            Save(Ap.FileParametersFilesXml);
        }

        public void Save(string filePath)
        {
            this.Kv.WriteXml(filePath);
        }

        #endregion

    }
}
