using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Threading;
using App.Model;

namespace App.Model
{
    public class TestDebugger
    {
        #region Data Members
        private static TestDebugger testDebugger = null;
        public bool EnableEngineLog = true;
        bool isFileInUsed = false;
        #endregion

        #region Ctor

        TestDebugger()
        {
            
        }
        
        #endregion

        #region Properties

        #region Instance
        
        public static TestDebugger Instance
        {
            [DebuggerStepThrough]
            get
            {
                if (testDebugger == null)
                {
                    testDebugger = new TestDebugger();
                }

                return testDebugger;
            }
        }
        #endregion
        #endregion

        #region Write
        public void WriteEngineInput(string engineName, string message)
        {
            if (EnableEngineLog)
            {
                Write("-------------------------------------------");
                Write("UI2E >> " + " [ " + engineName + "] " + message);
                Write("-------------------------------------------");
            }
        }

        public void WriteEngineOutput(string engineName, string message)
        {
            if (EnableEngineLog)
            {
                Write("E2UI << " + " [ " + engineName + "] " + message);
            }
        }

        public void Write(string message)
        {
            Write(message, Config.IsDev);
        }

        public void Write(string message, bool isDev)
        {
            // REMOVE following after investigation
            // START REMOVE
            if (!isDev)
            {
                System.Threading.Thread.Sleep(1); // somehow IsDev false causes problems in Engine Analysis
                return;
            }
            // END REMOVE

            if (isDev && !isFileInUsed)
            {
                WriteLog(message);
            }
        }

        public void WriteLog(string message)
        {
            isFileInUsed = true;

            StreamWriter debuggerWriter = new StreamWriter(Ap.FileLogTxt, true);

            UFile.RemoveReadOnly(Ap.FileLogTxt);

            debuggerWriter.WriteLine(message);

            debuggerWriter.Close();

            debuggerWriter = null;

            isFileInUsed = false;
        }

        public void WriteError(Exception ex)
        {
            Write("**** E R R O R ( " + DateTime.Now + " )****", true);
            Write(App.Model.AppException.GetError(ex), true);
            Write("*******************************************", true);
        }

        public void Write(Exception ex)
        {
            Write("**** E R R O R (" + DateTime.Now + ")****", true);
            Write(App.Model.AppException.GetError(ex));
            Write("*******************************************");
        }

        public void WriteInfo(string message)
        {
            if (EnableEngineLog)
            {
                Write("INFO  : " + message);
            }
        }

        public void Clear()
        {
            File.Delete(Ap.FileLogTxt);
        }

        internal void ErrorConvert(Exception ex, string gameXml)
        {
            WriteLog("**************** CONVERT ****************");
            WriteLog(App.Model.AppException.GetError(ex));
            WriteLog(gameXml);
        }

        internal void WriteLog(Exception ex)
        {
            WriteLog("**************** E R R O R ****************");
            WriteLog(App.Model.AppException.GetError(ex));
            WriteLog("*******************************************");
        }

        #endregion




    }
    
}
