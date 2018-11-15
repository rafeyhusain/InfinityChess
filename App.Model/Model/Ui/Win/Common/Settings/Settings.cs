using System;
using System.Collections.Generic;
using System.Text;
using App.Model;
using System.Configuration;
using System.Diagnostics;
namespace InfinitySettings
{
    public class Settings
    {
        static Settings()
        {
            InitializeItems();
        }

        private static void InitializeItems()
        {
            try
            {
                //  user profil instances
                _engineManager = new InfinitySettings.EngineManager.EngineManager();
                _defaultEngineXml = _engineManager.LoadDefaultEngine();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Properties

        private static string _defaultOpeningBook;
        public static string DefaultOpeningBook
        {
            [DebuggerStepThrough]
            get
            {
                _defaultOpeningBook = System.Configuration.ConfigurationSettings.AppSettings["DefaultBook"];
                return _defaultOpeningBook;
            }
            [DebuggerStepThrough]
            set
            {
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.AppSettings.Settings["DefaultBook"].Value = value;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private static EngineManager.EngineManager _engineManager;
        public static EngineManager.EngineManager EngineManager
        {
            [DebuggerStepThrough]
            get { return _engineManager; }
            [DebuggerStepThrough]
            set { _engineManager = value; }
        }

        private static EngineManager.Engine _defaultEngineXml;
        public static EngineManager.Engine DefaultEngineXml
        {
            [DebuggerStepThrough]
            get { return _defaultEngineXml; }
            [DebuggerStepThrough]
            set { _defaultEngineXml = value; }
        }
        
        private static UCIEngine _engine2;
        public static UCIEngine Engine2
        {
            [DebuggerStepThrough]
            get { return _engine2; }
            [DebuggerStepThrough]
            set { _engine2 = value; }
        }

        #endregion

        #region Methods

        public static string GetFileNameOnly(string path)
        {
            string tempFileName = path;
            if (tempFileName.Contains("."))
                tempFileName = tempFileName.Substring(0, tempFileName.LastIndexOf("."));
            if (tempFileName.Contains("/"))
                tempFileName = tempFileName.Substring(tempFileName.LastIndexOf("/") + 1);
            if (tempFileName.Contains("\\"))
                tempFileName = tempFileName.Substring(tempFileName.LastIndexOf("\\") + 1);
            return tempFileName;
        }

        public static long GetTimeInSeconds(long hours, long minutes, long seconds)
        {
            long timeInSeconds = 0;

            timeInSeconds += hours * 60 * 60;
            timeInSeconds += minutes * 60;
            timeInSeconds += seconds;

            return timeInSeconds;
        }

        private static void CloseDefaultEngine()
        {
            if (Options.DefaultEngine != null)
            {
                Options.DefaultEngine.Close();
                Options.DefaultEngine = null;
            }
            GC.Collect();
        }


        #endregion

    }
}
