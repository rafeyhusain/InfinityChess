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
    public class IcdManager
    {
        #region DataMembers
        public Game Game = null;
        StringBuilder pgnFileWriter;
        public BackgroundWorker backgroundWorker;
        public DoWorkEventArgs workEventArgument = null;
        public int CurrentGameNo = 0;
        public long TotalGames = 0;
        public string filepath;
        Book book;
        public bool isTotalGamesCalculated = false;
        public bool isImportInCurrentGameBook = false;
        #endregion

        #region Ctor

        public IcdManager(Game game)
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


        public void ConvertIcdToPgn(string fileName)
        {
            filepath = fileName;
            if (isImportInCurrentGameBook)
            {
                book = this.Game.Book;
                book.NewPositionsImported = 0;
            }
            Ap.Database = new Database(fileName, this.Game);
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            backgroundWorker.RunWorkerAsync(fileName);

        }

        #region BackGroundThread
        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int count = 0;
            pgnFileWriter = new StringBuilder();
            string filename = e.Argument as string;
            workEventArgument = e;

            List<GameItem> games = Ap.Database.GetGamesItems();
            int totalGamesCount = games.Count;
            if (OnProgressBarInitialized != null)
            {
                ProgressBarEventArgs args = new ProgressBarEventArgs(0, totalGamesCount);
                OnProgressBarInitialized(null, args);
            }
            backgroundWorker.ReportProgress(0);
            foreach (GameItem item in games)
            {
                count++;
                if (isImportInCurrentGameBook)
                {
                    book.ImportGame(item);
                }
                else
                {

                    GameData gameData = item.GameData;
                    Moves moves = item.Moves;
                    ConvertGameData(pgnFileWriter, gameData);
                    ConvertMovesData(pgnFileWriter, moves);
                    ConvertResultData(pgnFileWriter, gameData.Result);
                }

                backgroundWorker.ReportProgress(count);

                if (backgroundWorker.CancellationPending)
                {
                    if (workEventArgument != null)
                    {
                        workEventArgument.Cancel = true;
                        return;
                    }
                }
            }

            book.Save();
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
                ProgressWorkCompletedEventArgs args = new ProgressWorkCompletedEventArgs(e, null);
                if (!isImportInCurrentGameBook)
                {
                    args.data = pgnFileWriter.ToString();
                }
                OnProgressWorkCompleted(this, args);
            }
        }
        public void CancelIcdToPgnConversion()
        {
            if (backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
            }
        }
        #endregion

        #region (ICD to PGN Data Conversion)
        private void ConvertGameData(StringBuilder pgnFileWriter, GameData gameData)
        {
            pgnFileWriter.Append(@"[Event """);
            pgnFileWriter.Append(gameData.Tournament);
            pgnFileWriter.Append(@"""]");
            pgnFileWriter.AppendLine();

            pgnFileWriter.Append(@"[Site """);
            pgnFileWriter.Append(string.Empty);
            pgnFileWriter.Append(@"""]");
            pgnFileWriter.AppendLine();

            pgnFileWriter.Append(@"[Date """);
            pgnFileWriter.Append(gameData.Year.ToString());
            pgnFileWriter.Append(".");
            pgnFileWriter.Append(gameData.Month.ToString());
            pgnFileWriter.Append(".");
            pgnFileWriter.Append(gameData.Day.ToString());
            pgnFileWriter.Append(@"""]");
            pgnFileWriter.AppendLine();

            pgnFileWriter.Append(@"[Round """);
            pgnFileWriter.Append(string.Empty);
            pgnFileWriter.Append(@"""]");
            pgnFileWriter.AppendLine();

            pgnFileWriter.Append(@"[White """);
            pgnFileWriter.Append(gameData.White1);
            pgnFileWriter.Append(". ");
            pgnFileWriter.Append(gameData.White2);
            pgnFileWriter.Append(@"""]");
            pgnFileWriter.AppendLine();

            pgnFileWriter.Append(@"[Black """);
            pgnFileWriter.Append(gameData.Black1);
            pgnFileWriter.Append(". ");
            pgnFileWriter.Append(gameData.Black2);
            pgnFileWriter.Append(@"""]");
            pgnFileWriter.AppendLine();

            pgnFileWriter.Append(@"[Result """);
            pgnFileWriter.Append(gameData.Result);
            pgnFileWriter.Append(@"""]");
            pgnFileWriter.AppendLine();

            pgnFileWriter.Append(@"[ECO """);
            pgnFileWriter.Append(gameData.EcoCode);
            pgnFileWriter.Append(@"""]");
            pgnFileWriter.AppendLine();

            pgnFileWriter.Append(@"[WhiteElo """);
            pgnFileWriter.Append(gameData.EloWhite);
            pgnFileWriter.Append(@"""]");
            pgnFileWriter.AppendLine();

            pgnFileWriter.Append(@"[BlackElo """);
            pgnFileWriter.Append(gameData.EloBlack);
            pgnFileWriter.Append(@"""]");
            pgnFileWriter.AppendLine();

            pgnFileWriter.Append(@"[PlyCount """);
            pgnFileWriter.Append(string.Empty);
            pgnFileWriter.Append(@"""]");
            pgnFileWriter.AppendLine();

            pgnFileWriter.Append(@"[EventDate """);
            pgnFileWriter.Append("????");
            pgnFileWriter.Append(".");
            pgnFileWriter.Append("??");
            pgnFileWriter.Append(".");
            pgnFileWriter.Append("??");
            pgnFileWriter.Append(@"""]");
            pgnFileWriter.AppendLine();

            pgnFileWriter.Append(@"[EventType """);
            pgnFileWriter.Append(string.Empty);
            pgnFileWriter.Append(@"""]");
            pgnFileWriter.AppendLine();

            pgnFileWriter.Append(@"[EventRounds """);
            pgnFileWriter.Append(string.Empty);
            pgnFileWriter.Append(@"""]");
            pgnFileWriter.AppendLine();

            pgnFileWriter.Append(@"[EventType """);
            pgnFileWriter.Append(string.Empty);
            pgnFileWriter.Append(@"""]");
            pgnFileWriter.AppendLine();

            pgnFileWriter.Append(@"[EventRounds """);
            pgnFileWriter.Append(string.Empty);
            pgnFileWriter.Append(@"""]");
            pgnFileWriter.AppendLine();

            pgnFileWriter.Append(@"[EventCountry """);
            pgnFileWriter.Append(string.Empty);
            pgnFileWriter.Append(@"""]");
            pgnFileWriter.AppendLine();

            pgnFileWriter.Append(@"[Source """);
            pgnFileWriter.Append(string.Empty);
            pgnFileWriter.Append(@"""]");
            pgnFileWriter.AppendLine();

            pgnFileWriter.Append(@"[SourceDate """);
            pgnFileWriter.Append("????");
            pgnFileWriter.Append(".");
            pgnFileWriter.Append("??");
            pgnFileWriter.Append(".");
            pgnFileWriter.Append("??");
            pgnFileWriter.Append(@"""]");
            pgnFileWriter.AppendLine();
            pgnFileWriter.AppendLine();

        }
        private void ConvertMovesData(StringBuilder pgnFileWriter, Moves moves)
        {
            Move m;
            foreach (DataRow dr in moves.DataTable.Rows)
            {
                m = new Move(dr);
                m.Game = this.Game;
                pgnFileWriter.Append(m.SingleNotationPgn);
                pgnFileWriter.Append(" ");
            }
        }

        private void ConvertMovesData1(StringBuilder pgnFileWriter, Moves moves)
        {
            string s = GetMovesString(moves.DataTable);
            pgnFileWriter.Append("m.SingleNotationPgn");
            pgnFileWriter.Append(" ");
        }

        private string GetMovesString(DataTable moves)
        {
            string s = "";

            //foreach (DataRow dr in moves.DataTable.Rows)
            //{
            //    m = new Move(dr);
            //    m.Game = this.Game;
            //    pgnFileWriter.Append(m.SingleNotationPgn);
            //    pgnFileWriter.Append(" ");
            //}
            return s;
        }

        private void ConvertResultData(StringBuilder pgnFileWriter, string result)
        {
            pgnFileWriter.Append(result);
            pgnFileWriter.AppendLine();
            pgnFileWriter.AppendLine();
        }
        #endregion
    }
}
