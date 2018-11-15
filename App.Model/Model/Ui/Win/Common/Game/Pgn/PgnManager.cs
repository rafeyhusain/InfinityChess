using System; 
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using App.Model;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using PgnParser;
using System.Text.RegularExpressions;
using System.Threading;
using System.ComponentModel;

namespace App.Model
{
    public class PgnManager
    {
        #region DataMembers
        public const string EmptyMoves = "<?xml version=\"1.0\" standalone=\"yes\"?><NewDataSet></NewDataSet>";
        public const string TempMoves = "<?xml version=\"1.0\" standalone=\"yes\"?><NewDataSet><M><Id>-1</Id><Pid>0</Pid><W>0</W><No>0</No><P></P><F>e2</F><T>e4</T><Mf>Q</Mf><Mt>0</Mt><Mw>0</Mw><Mb>0</Mb><Cp/><Fen></Fen></M></NewDataSet>";
        public Game Game = null;
        public BackgroundWorker backgroundWorker;
        public DoWorkEventArgs workEventArgument = null;
        PgnWrapper pgn = null;
        public int CurrentGameNo = 0;
        public long TotalGames = 0;
        public string filepath;
        public bool isTotalGamesCalculated = false;
        public bool isPgnToIcbConversion = false;
        public bool isImportInCurrentGameBook = false;
        Book book;
        public int databaseFileNo = 0;
        public int databaseGameNo = 0;
        #endregion

        #region Ctor

        public PgnManager(Game game)
        {
            this.Game = game;
        }

        #endregion

        #region Delegates/Events
        public delegate void ProgressChangedEventHandler(object sender, ProgressChangedEventArgs e);
        public event ProgressChangedEventHandler OnProgressChanged;

        public delegate void ProgressWorkCompletedHandler(object sender, ProgressWorkCompletedEventArgs e);
        public event ProgressWorkCompletedHandler OnProgressWorkCompleted;

        public delegate void ProgressBarInitHandler(object sender, ProgressBarEventArgs e);
        public event ProgressBarInitHandler OnProgressBarInitialized;
        #endregion

        #region Properties
        #endregion

        #region Methods

        public void ConvertPgnToIcd(string fileName)
        {
            filepath = fileName;
            if (fileName.EndsWith(Files.PortableGameNotationExtension))
            {
                Thread totalGames = new Thread(GameCount);
                totalGames.Start();
                if (!isImportInCurrentGameBook && isPgnToIcbConversion)
                {
                    book = new Book(this.Game);
                    book.FilePath = fileName.Replace(".pgn", ".icb");
                }
                else if (isImportInCurrentGameBook && isPgnToIcbConversion)
                {
                    book = this.Game.Book;
                    book.NewPositionsImported = 0;
                }
                else
                {
                    Ap.Database = new Database(fileName.Replace(".pgn", ".icd"), this.Game);
                }
                backgroundWorker = new BackgroundWorker();
                backgroundWorker.WorkerReportsProgress = true;
                backgroundWorker.WorkerSupportsCancellation = true;
                backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
                backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
                backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
                backgroundWorker.RunWorkerAsync(fileName);
            }
            else
            {
                MessageForm.Error(Msg.GetMsg(MsgE.ErrorInvalidFileFormat));
                return;
            }
        }

        void pgn_OnGameLoaded(string gameXml)
        {
            //TestDebugger.Instance.WriteLog(gameXml);            
            CurrentGameNo++;
            databaseGameNo++;
            try
            {
                Kv kvGame = new Kv(gameXml, true);
                string movesXml = Kv.Get(kvGame.DataTable, "Moves");
                if (movesXml == EmptyMoves)
                {
                    movesXml = TempMoves;
                }
                Kv kvMoves = new Kv(movesXml, true);

                if (isTotalGamesCalculated)
                {
                    backgroundWorker.ReportProgress(CurrentGameNo);
                }
                AddGame(kvGame, kvMoves);
            }
            catch (OutOfMemoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw;
                //TestDebugger.Instance.ErrorConvert(ex, gameXml);
            }

            if (backgroundWorker.CancellationPending)
            {
                if (workEventArgument != null)
                {
                    workEventArgument.Cancel = true;
                    pgn.Close();
                    return;
                }
            }
        }

        static readonly object locker = new object();
        private void AddGame(Kv kvGame, Kv kvMoves)
        {
            GameData gameData = GetGameData(kvGame);
            Moves moves = GetMoves(kvMoves);

            if (isPgnToIcbConversion)
            {
                    GameItem item = new GameItem(gameData, moves);                    
                    book.ImportGame(item);
            }
            else
            {
                gameData.Guid = System.Guid.NewGuid().ToString();
                gameData.Moves = UData.ToString(moves.DataTable);
                string gameXml = this.Game.GetGameXml(gameData);
                Ap.Database.AppendGame(gameXml);
            }
        }

        private GameData GetGameData(Kv kvGame)
        {
            //Game game = new Game();
            GameData gameData = new GameData(this.Game);
            gameData.Clear();
            // load game data

            if (!string.IsNullOrEmpty(kvGame.Get("Event")))
            {
                gameData.Tournament = kvGame.Get("Event");
            }
            else
            {
                gameData.Tournament = string.Empty;
            }

            if (!string.IsNullOrEmpty(kvGame.Get("Date")))
            {
                string[] date = kvGame.Get("Date").Split('.');
                if (date[0] != "????")
                {
                    gameData.Year = Convert.ToDecimal(date[0]);
                    gameData.IsYear = true;
                }
                if (date[1] != "??")
                {
                    gameData.Month = Convert.ToDecimal(date[1]);
                    gameData.IsMonth = true;
                }
                if (date[2] != "??")
                {
                    gameData.Day = Convert.ToDecimal(date[2]);
                    gameData.IsDay = true;
                }
            }

            if (!string.IsNullOrEmpty(kvGame.Get("White")))
            {
                string[] white = kvGame.Get("White").Split(',');
                if (white.Length > 1)
                {
                    gameData.White1 = white[0];
                    gameData.White2 = white[1];
                }
                else
                {
                    gameData.White1 = white[0];
                }
            }
            else
            {
                gameData.White1 = string.Empty;
                gameData.White2 = string.Empty;
            }

            if (!string.IsNullOrEmpty(kvGame.Get("Black")))
            {
                string[] black = kvGame.Get("Black").Split(',');
                if (black.Length > 1)
                {
                    gameData.Black1 = black[0];
                    gameData.Black2 = black[1];
                }
                else
                {
                    gameData.Black1 = black[0];
                }
            }
            else
            {
                gameData.Black1 = string.Empty;
                gameData.Black2 = string.Empty;
            }

            if (!string.IsNullOrEmpty(kvGame.Get("BlackElo")))
            {
                gameData.EloBlack = Convert.ToDecimal(kvGame.Get("BlackElo"));
            }

            if (!string.IsNullOrEmpty(kvGame.Get("WhiteElo")))
            {
                gameData.EloWhite = Convert.ToDecimal(kvGame.Get("WhiteElo"));
            }

            if (!string.IsNullOrEmpty(kvGame.Get("Result")))
            {
                gameData.Result = kvGame.Get("Result");
            }
            else
            {
                gameData.Result = string.Empty;
            }
            return gameData;

        }
        private Moves GetMoves(Kv kvMoves)
        {
            Moves moves = new Moves(Moves.GetMovesTable());
            Move m;

            foreach (DataRow dr in kvMoves.DataTable.Rows)
            {
                m = Move.NewMove();
                m.Game = this.Game;
                m.Id = Convert.ToInt32(dr["Id"].ToString());
                m.Pid = Convert.ToInt32(dr["Pid"].ToString());
                m.White = Convert.ToInt32(dr["W"].ToString());
                if (Convert.ToBoolean(m.White))
                {
                    m.IsWhite = true;
                    m.IsBlack = false;
                }
                else
                {
                    m.IsWhite = false;
                    m.IsBlack = true;
                }
                m.MoveNo = Convert.ToInt32(dr["No"].ToString());
                m.PieceStr = dr["P"].ToString();
                m.From = dr["F"].ToString();
                m.To = dr["T"].ToString();
                m.MoveFlags = dr["Mf"].ToString();
                m.MoveTime = Convert.ToInt64(dr["Mt"].ToString());
                m.MoveTimeWhite = Convert.ToInt64(dr["Mw"].ToString());
                m.MoveTimeBlack = Convert.ToInt64(dr["Mb"].ToString());
                m.CapturedPceStr = dr["Cp"].ToString();
                m.Fen = dr["Fen"].ToString();
                moves.DataTable.ImportRow(m.DataRow);
            }
            return moves;
        }


        #region Helper
        private void GameCount()
        {
            string content = File.ReadAllText(filepath);
            Regex expression = new Regex(@"\[Event \""", RegexOptions.Singleline);
            int count = expression.Matches(content).Count;
            TotalGames = count;
            isTotalGamesCalculated = true;
            if (OnProgressBarInitialized != null)
            {
                ProgressBarEventArgs args = new ProgressBarEventArgs(0, count);
                OnProgressBarInitialized(null, args);
            }
        }
        #endregion

        #region BackGroundThread
        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string filename = e.Argument as string;
                filepath = filename;
                pgn = new PgnWrapper();
                workEventArgument = e;
                backgroundWorker.ReportProgress(0);
                pgn.OnGameLoaded += new PgnWrapper.GameLoaded(pgn_OnGameLoaded);
                pgn.Open(filename);
                pgn.Close();
            }
            catch (OutOfMemoryException exm)
            {
                MessageForm.Show(exm);
            }
            catch (Exception ex)
            {
                MessageForm.Show("Invalid PGN file format. Some games or moves are not in valid PGN file format.\n");
            }
        }

        void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (OnProgressChanged != null)
            {
                OnProgressChanged(this, e);
            }
        }
        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (OnProgressWorkCompleted != null)
            {
                if (isPgnToIcbConversion)
                {
                    book.Save();
                }
                ProgressWorkCompletedEventArgs args = new ProgressWorkCompletedEventArgs(e, null);
                OnProgressWorkCompleted(this, args);
            }
        }
        public void CancelPgnToIcdConversion()
        {
            if (backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
            }
        }

        #endregion

        #endregion
    }
   
}