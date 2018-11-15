using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;

using System.ComponentModel;
using App.Model;
using System.Timers;
using InfinitySettings.Streams;

namespace App.Model
{
    public partial class UCIEngine
    {
        #region Data Members

        public Game Game = null;

        private string author = string.Empty;
        private string id = string.Empty;
        public string EngineName = "";
        public string EngineFile = "";
        public int HashTableSize = 512;
        public bool IsSwitchedOff = false;
        public InfinitySettings.UCIManager.EngineParameters Parameters;
        Process _uciProcess = null;
        string positionCommand = string.Empty;
        bool isInfiniteCommandInProgress = false;
        bool IsNalimovPathSupported = false;
        public bool IsMoveInProgress = false;
        public bool IsPonderMove = false;
        public bool IsPonderMoveResponse = false;
        private bool isFirstPonderMove = true;
        public bool isSendStop = false;
        public bool IsKibitzer = false;
        public bool IsHashCleared = false;
        public bool isPonderMiss = false;
        public bool IsPaused = false;
        public string ponderMove = "";
        public string subPonderMove = "";
        private string[] bestMoves;
        int TimeOut = 1;
        public int ElapsedTime;
        public string Points;
        public string Depth;
        public string ExpectedMove;

        Timer t = new Timer();

        #endregion

        #region Delegates and Events

        public event EventHandler UciOkReceived;

        public delegate void OptionReceivedHandler(object sender, UCIMessageEventArgs e);
        public event OptionReceivedHandler OptionReceived;

        public delegate void NameReceivedHandler(object sender, UCIMessageEventArgs e);
        public event NameReceivedHandler NameReceived;

        public delegate void AuthorReceivedHandler(object sender, UCIMessageEventArgs e);
        public event AuthorReceivedHandler AuthorReceived;

        public delegate void MoveReceivedHandler(object sender, UCIMoveEventArgs e);
        public event MoveReceivedHandler MoveReceived;

        public delegate void IllegalMoveHandler(object sender, UCIIllegalMoveEventArgs e);
        public event IllegalMoveHandler IllegalMove;

        public delegate void ErrorHandler(object sender, UCIErrorEventArgs e);
        public event ErrorHandler Error;

        public delegate void InfoReceivedHandler(object sender, UCIInfoEventArgs e);
        public event InfoReceivedHandler InfoReceived;

        public event EventHandler ClearAnalysis;
        #endregion

        #region Ctor
        public UCIEngine(string engineFile, int hashTableSize, Game game)
        {
            EngineFile = engineFile;
            HashTableSize = hashTableSize;
            this.Game = game;
            if (HasGame)
            {
                this.Game.AfterAddMove += new EventHandler(Game_AfterAddMove);
            }
            InitTimer();
        }

        #endregion

        #region Properties

        #region Core
        public bool IsClosed
        {
            get { return _uciProcess == null; }
        }

        bool useTablebases = true;
        public bool UseTablebases
        {
            get { return useTablebases; }
            set { useTablebases = value; }
        }

        public bool IsInfiniteCommandInProgress
        {
            get { return isInfiniteCommandInProgress; }
            set { isInfiniteCommandInProgress = value; }
        }

        public string Author
        {
            get { return author; }
        }

        public string Id
        {
            get { return id; }
        }
        #endregion

        #region Calculated

        bool ProcessPonder
        {
            get { return this.Game.GameMode == GameMode.HumanVsEngine || this.Game.GameMode == GameMode.HumanVsHuman; }
        }

        bool HasGame
        {
            get { return this.Game != null; }
        }

        public bool HasParametersLoaded
        {
            get { return Parameters != null && Parameters.IsLoaded; }
        }

        public bool IsLoadParametersRequired
        {
            get { return !HasParametersLoaded && Parameters != null; }
        }

        public string EngineTitle
        {
            get
            {
                string title = Id;
                if (string.IsNullOrEmpty(title))
                {
                    title = EngineName;
                }

                return title;
            }
        }

        bool IsBestMoveAvailable
        {
            get { return bestMoves != null && bestMoves.Length >= 2; }
        }

        bool IsBestMoveWithPonder
        {
            get { return bestMoves != null && bestMoves.Length == 4; }
        }

        #endregion

        #endregion

        #region Close/SwitchOff 
        
        public void Pause()
        {
            //this.SendStop();
            IsPaused = true;
        }

        public void Resume()
        {
            IsPaused = false;
        }

        public void Close()
        {
            this.Kill();
        }

        public void Kill()
        {
            if (_uciProcess != null)
            {
                if (!_uciProcess.HasExited)
                    _uciProcess.Kill();
                _uciProcess = null;
            }
        }

        public void SwitchOn()
        {
            IsSwitchedOff = false;
        }

        public void SwitchOff()
        {
            IsSwitchedOff = true;
        }

        #endregion

        #region UCI

        #region Init
        private void InitUciProcess()
        {
            if (_uciProcess != null)
            {
                _uciProcess.Close();
                _uciProcess = null;
            }

            _uciProcess = new Process();
            _uciProcess.StartInfo.FileName = EngineFile;
            _uciProcess.StartInfo.CreateNoWindow = true;
            _uciProcess.StartInfo.UseShellExecute = false;
            _uciProcess.StartInfo.RedirectStandardError = true;
            _uciProcess.StartInfo.RedirectStandardInput = true;
            _uciProcess.StartInfo.RedirectStandardOutput = true;
            _uciProcess.OutputDataReceived += new DataReceivedEventHandler(_uciProcess_OutputDataReceived);

            _uciProcess.Start();

            _uciProcess.BeginOutputReadLine();

        }
        #endregion

        #region Receive
        void _uciProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            ProcessUCIData(e.Data);
        }
        #endregion

        #endregion

        #region Load
        public static UCIEngine Load(string engineFile, int hashTableSize, Game game)
        {
            UCIEngine engine = new UCIEngine(engineFile, hashTableSize, game);

            engine.Load();

            return engine;
        }

        public bool Load()
        {
            if (String.IsNullOrEmpty(EngineFile))
            {
                return false;
            }
            EngineName = Path.GetFileNameWithoutExtension(EngineFile);
            InitUciProcess();
            if (HasGame)
            {
                Parameters = new InfinitySettings.UCIManager.EngineParameters(this.Game);
                Parameters.LoadEngineParameters(this.EngineName);
            }
            SendUci();
            return true;
        }

        public bool LoadParameters(InfinitySettings.UCIManager.EngineParameters parameters)
        {
            Close();
            if (String.IsNullOrEmpty(EngineFile))
            {
                return false;
            }
            EngineName = Path.GetFileNameWithoutExtension(EngineFile);
            InitUciProcess();
            this.Parameters = parameters;
            SendUci();
            return true;
        }
        #endregion

        #region Game Events

        void Game_AfterAddMove(object sender, EventArgs e)
        {
            GoInfiniteIfRequired();
        }
        private void OnClearAnalysis()
        {
            if (ClearAnalysis != null)
            {
                ClearAnalysis(this, EventArgs.Empty);
            }
        }
        #endregion

        #region Helpers 

        //private void SendNalimovPath()
        //{
        //    string path = "";
            
        //    path = AppendPath(path, Ap.Options.TablebasesPath1);
        //    path = AppendPath(path, Ap.Options.TablebasesPath2);
        //    path = AppendPath(path, Ap.Options.TablebasesPath3);
        //    path = AppendPath(path, Ap.Options.TablebasesPath4);

        //    if (!string.IsNullOrEmpty(path))
        //    {
        //        //SendOption(OptionNalimovPath, path);
        //    }
        //}

        //private string AppendPath(string path, string pathToAppend)
        //{
        //    if (string.IsNullOrEmpty(pathToAppend))
        //    {
        //        return path;
        //    }

        //    if (!string.IsNullOrEmpty(path))
        //    {
        //        path += ";";
        //    }

        //    path += pathToAppend;
        //    return path;
        //}

        #endregion
    }
}
