using System;
using App.Model;
using System.Collections.Generic;
using System.Text;
using InfinitySettings.Streams;
using System.IO;
using System.Xml;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Collections;
using ICSharpCode.SharpZipLib.BZip2;
using ChessLibrary;

namespace App.Model
{
    #region Summary
    /*
     * Under folder <My Documents>\InfiChess\Data\Database
     * 
     * 1) Database.icd
     * Default Database
     * 
     * 2) AutoSave.icd 
     * Auto save (replace) game in this database after every 10 sec and app close 
     * 
     * 3) MyOnlineKibitzedGame.icd (Ap.Game.GameMode == GameMode.Kibitzer)
     * When you watch a game online as audiance, auto save (replace) game in this database after every 10 sec and game window close 
     * 
     * 4) MyOnlineGame.icd (Ap.Game.GameMode == GameMode.OnlineHumanVsHuman)
     * When you play a human game online, auto save (replace) game in this database after every 10 sec and game window close 
     * 
     * 5) MyOnlineEngineGame.icd (Ap.Game.GameMode == GameMode.OnlineEngineVsEngine)
     * When you play an engine game online, auto save (replace) game in this database after every 10 sec and game window close 
     * 
     * 
    */
    
    #endregion
    public class Database
    {
        #region Data Members

        public Game Game = null;
        public const string Guid = "I";
        public const string GameXml = "X";

        public const string SerialNo = "SNo";
        public const string Players = "Players";
        public const string Tournament = "Tournament";
        public const string ECO = "Eco";
        public const string Variation = "Variation";
        public const string Result = "Result";
        public const string Year = "Year";
        public const string Moves = "Moves";
        public DataTable DatabaseData = null;
        public GameItems GameItems = null;
        public BackgroundWorker backgroundWorker;
        DataTable searchedGames;
        public DoWorkEventArgs workEventArgument = null;
        public string FilePath = null;
        
        #endregion

        #region Properties

        public int GamesCount
        {
            [DebuggerStepThrough]
            get
            {
                if (this.DatabaseData != null)
                {
                    return this.DatabaseData.Rows.Count;
                }

                return 0;
            }
        }

        public string FileName
        {
            [DebuggerStepThrough]
            get
            {
                if (!String.IsNullOrEmpty(this.FilePath))
                {
                    return System.IO.Path.GetFileName(FilePath);
                }

                return "";
            }


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

        #region Ctor
        public Database(string filePath,Game game)
        {
            this.Game = game;
            this.FilePath = filePath;
            Load();
        }

        public static DataTable GetDatabaseDataTable()
        {
            return UData.ToTable2("G", Guid, GameXml);
        }

        public static DataTable GetDatabaseViewDataTable()
        {
            return UData.ToTable2("GV", SerialNo, Guid, Players, Tournament, ECO, Year, Result, Variation, Moves);
        }
        #endregion

        #region Load
        public void Load()
        {
            DatabaseData = GetDatabaseDataTable();

            this.GameItems = new GameItems(this);
            this.GameItems.Game = this.Game;
            if (File.Exists(this.FilePath))
            {
                //UData.ReadXmlDecrypted(DatabaseData, this.FilePath);
                UData.ReadXml(DatabaseData, this.FilePath);
            }
            else
            {
                //UData.WriteXmlDecrypted(DatabaseData, this.FilePath);
                UData.WriteXml(DatabaseData, this.FilePath);
            }
        }
        #endregion

        #region Create Copy

        private void CreateCopyIfRequired(string filePath)
        {
            FileInfo fi = new FileInfo(this.FilePath);

            if (fi.Length >= 1024 * Config.MaxDbSizeInKb)
            {
                string newFilePath = GetNextFilePath(filePath);
                fi.CopyTo(newFilePath, true);
                fi.Delete();

                CreateEmptyFile();

                DatabaseData.Rows.Clear();
            }
            fi = null;
        }

     
        private string GetNextVersion(string filePath,int version)
        { 
            string ext = Path.GetExtension(filePath);
            string tempPath = filePath.Replace(ext, "");
            string nextFilePath = "";
            int no = GetCurrentFileNo(filePath);
            if (no == 0 && tempPath.Substring(tempPath.Length - 1) != "0")
            {
                tempPath = tempPath + "_" + no + ext;
            }
            else
            {
                if (version == 1)
                {
                    tempPath = tempPath.Substring(0, tempPath.LastIndexOf("_")- 1);
                    tempPath = tempPath + ext;
                }
                else
                {
                    no++;
                    tempPath = tempPath.Substring(0, tempPath.LastIndexOf("_"));
                    tempPath = tempPath + "_" + no + ext;
                }
            }
            return nextFilePath = tempPath;
        }

        private int GetFileCountOfCurrentDatabase(string filePath)
        {
            string ext = Path.GetExtension(filePath);
            string filename = Path.GetFileName(filePath).Replace(ext, "");
            string directory = Path.GetDirectoryName(filePath);
            string[] files = Directory.GetFiles(directory, filename + "*.icd");
            return files.Length - 1;
        }

        private void CreateEmptyFile()
        {
            // create new empty file
            DataTable dtEmpty = DatabaseData.Clone();            
            UData.WriteXml(dtEmpty, this.FilePath);

            if (DatabaseData.Rows.Count > 0) // clear database's datatable except last row.
            {
                DataRow dr = DatabaseData.Rows[DatabaseData.Rows.Count - 1];
                DatabaseData.Rows.Clear();
                DatabaseData.ImportRow(dr);
                DatabaseData.AcceptChanges();
            }
        }


        private ArrayList GetAllFiles(string filePath)
        {
            ArrayList files = new ArrayList();
            int no = 1;
            string ext = Path.GetExtension(filePath);
            string tempPath = filePath.Replace(ext, "");
            string nextFilePath = "";
            bool nextFileFounded = false;
            string s = tempPath.Substring(tempPath.LastIndexOf("_") + 1);
            Int32.TryParse(s, out no);

            if (no == 0)
            {
                if (File.Exists(tempPath + ext))
                    files.Add(tempPath + ext);
            }
            else
            {
                tempPath = tempPath.Substring(0, tempPath.LastIndexOf("_"));
                if (File.Exists(tempPath + ext))
                    files.Add(tempPath + ext);
            }
            no = 1;

            do
            {
                if (tempPath.EndsWith(no.ToString()))
                {
                    tempPath = tempPath.Substring(0, tempPath.LastIndexOf(no.ToString()));
                }
                if (tempPath.EndsWith("_"))
                {
                    nextFilePath = tempPath + no + ext;
                }
                else
                {
                    nextFilePath = tempPath + "_" + no + ext;
                }

                if (!File.Exists(nextFilePath))
                {
                    nextFileFounded = true;
                }
                else
                {
                    files.Add(nextFilePath);
                }

                no++;
            } while (!nextFileFounded);

            return files;
        }
        private string GetNextFilePath(string filePath)
        {
            string ext = Path.GetExtension(filePath);
            string tempPath = filePath.Replace(ext, "");
            string nextFilePath = "";
            bool nextFileFounded = false;
            int no = GetCurrentFileNo(filePath);
            int currentfileNo = no;
            no++;
            do
            {
                if (tempPath.EndsWith(currentfileNo.ToString()))
                {
                    tempPath = tempPath.Substring(0, tempPath.LastIndexOf(currentfileNo.ToString()));
                    nextFilePath = tempPath + no + ext;

                }
                else
                {
                    if (currentfileNo == 0)
                    {
                        currentfileNo++;
                    }
                    if (tempPath.EndsWith("_"))
                    {
                        nextFilePath = tempPath + currentfileNo + ext;
                    }
                    else
                    {
                        nextFilePath = tempPath + "_" + currentfileNo + ext;
                    }
                }

                if (!File.Exists(nextFilePath))
                {
                    nextFileFounded = true;
                }

                currentfileNo++;
            } while (!nextFileFounded);

            return nextFilePath;
        }
        private int GetCurrentFileNo(string filePath)
        {
            int no = 1;
            string ext = Path.GetExtension(filePath);
            string tempPath = filePath.Replace(ext, "");

            string s = tempPath.Substring(tempPath.LastIndexOf("_") + 1);
            Int32.TryParse(s, out no);

            if (no <= 0)
            {
                no = 0;
            }

            return no;
        }



        #endregion

        #region AppendGame
        
        public void AppendGame_Original(string gameXml)
        {
            GameItem gi = new GameItem(gameXml);
            StreamWriter writer = new StreamWriter(FilePath, true);
            writer.WriteLine(@"<G>");
            writer.Write(@"<I>");
            writer.Write(gi.Guid);
            writer.Write(@"</I>");
            writer.Write(@"<X>");
            StringBuilder xmlString = new StringBuilder(gameXml);
            xmlString.Replace("&lt;", "&amp;lt;");
            xmlString.Replace("&gt;", "&amp;gt;");
            xmlString.Replace("<", "&lt;");
            xmlString.Replace(">", "&gt;");
            writer.Write(xmlString);
            writer.Write(@"</X>");
            writer.Write(@"</G>");
            writer.Flush();
            writer.Close();
            writer = null;
        }
        
        public void AppendGame(string gameXml)
        {
            DataRow dr = DatabaseData.NewRow();
            dr[Guid] = System.Guid.NewGuid().ToString();
            dr[GameXml] = gameXml;
            DatabaseData.Rows.Add(dr);

            Save();
        }

        public void AppendGame(string gameXml, string filepath,int gameNo)
        {
            GameItem gi = new GameItem(gameXml);
            StreamWriter writer = null;
            if (gameNo == 1)
            {
                FileInfo xmlfile = new FileInfo(filepath);
                writer = xmlfile.CreateText();
                writer.Write(@"<?xml version=""1.0"" standalone=""yes""?>");
                writer.Write("<NewDataSet>");
            }
            else
            {
                writer = File.AppendText(filepath);
            }
            writer.Write("<G>");
            writer.Write("<I>");
            writer.Write(gi.Guid);
            writer.Write("</I>");
            writer.Write("<X>");
            StringBuilder xmlString = new StringBuilder(gameXml);
            xmlString.Replace("&lt;", "&amp;lt;");
            xmlString.Replace("&gt;", "&amp;gt;");
            xmlString.Replace("<", "&lt;");
            xmlString.Replace(">", "&gt;");
            writer.Write(xmlString);
            writer.Write("</X>");
            writer.Write("</G>");
            writer.Flush();
            writer.Close();
            writer = null;
            xmlString = null;
             
            
          }
        #endregion

        #region UpdateGame
        public void UpdateGame(string gameXml,int index)
        {
            if (index < 0 || index > DatabaseData.Rows.Count - 1)
            {
                return;
            }

            // update game(row) to the database table
            DataRow dataBaseRow = DatabaseData.Rows[index];
            dataBaseRow[GameXml] = gameXml;
        }
        #endregion

        # region SearchGames
        public void SearchGames(GameSearch gameSearchData)
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.ProgressChanged += new  System.ComponentModel.ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            backgroundWorker.RunWorkerAsync(gameSearchData);
             
        }
        #endregion

        #region BackGroundThread
        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            GameSearch gameSearchData = e.Argument as GameSearch;
            searchedGames = Database.GetDatabaseViewDataTable();
            GameItem gameItem = null;
            workEventArgument = e;
            Nullable<bool> isBoardFenMatched = null;
            ArrayList files = GetAllFiles(this.FilePath);
            if (OnProgressBarInitialized != null)
            {
                int gameCount= GetTotalGamesCount(files);
                ProgressBarEventArgs args2=new ProgressBarEventArgs(0,gameCount);
                OnProgressBarInitialized(this, args2);
                backgroundWorker.ReportProgress(-1);
            }
            int serialNo = 0;
            for (int count = 0; count < files.Count ; count++)
            {
                Database DbFileVersion = new Database(files[count].ToString(), Game);
                DataTable gamesData = DbFileVersion.GetGamesTable();
                   
                foreach (DataRow row in gamesData.Rows)
                {
                    serialNo++;
                    backgroundWorker.ReportProgress(serialNo);
                    gameItem = new GameItem(row);
                    if (backgroundWorker.CancellationPending)
                    {
                        if (workEventArgument != null)
                        {
                            workEventArgument.Cancel = true;
                            return;
                        }
                    }
                    if (gameSearchData.IsGameDataIncluded)
                    {
                        if (!string.IsNullOrEmpty(gameSearchData.Black1))
                        {
                            if (gameSearchData.Black1 != gameItem.GameData.Black1)
                                continue;
                        }

                        if (!string.IsNullOrEmpty(gameSearchData.Black2))
                        {
                            if (gameSearchData.Black2 != gameItem.GameData.Black2)
                                continue;
                        }

                        if (!string.IsNullOrEmpty(gameSearchData.White1))
                        {
                            if (gameSearchData.White1 != gameItem.GameData.White1)
                                continue;
                        }
                        if (!string.IsNullOrEmpty(gameSearchData.White2))
                        {
                            if (gameSearchData.White2 != gameItem.GameData.White2)
                                continue;
                        }
                        if (!string.IsNullOrEmpty(gameSearchData.Tournament))
                        {
                            if (gameSearchData.Tournament != gameItem.GameData.Tournament)
                                continue;
                        }
                        /* Search for Annotator field is missing*/

                        if (gameSearchData.IsYear)
                        {
                            if (gameItem.GameData.Year < gameSearchData.Year1 || gameItem.GameData.Year > gameSearchData.Year2)
                                continue;
                        }
                        if (gameSearchData.IsECO)
                        {
                            if (!string.IsNullOrEmpty(gameSearchData.EcoCode1) || !string.IsNullOrEmpty(gameSearchData.EcoCode2))
                            {
                                if (!ValidEcoRange(gameSearchData.EcoCode1, gameSearchData.EcoCode2, gameItem.GameData.EcoCode))
                                {
                                    continue;
                                }
                            }
                        }
                        if (gameSearchData.IsMoves)
                        {
                            int moveCount = gameItem.Moves.DataTable.Rows.Count;
                            if (moveCount == 0)
                            {
                                if (moveCount < gameSearchData.Moves1 || moveCount > gameSearchData.Moves2)
                                    continue;
                            }
                            int actualMoves = moveCount / 2;
                            int remainder = moveCount % 2;
                            actualMoves += remainder;

                            if (actualMoves < gameSearchData.Moves1 || actualMoves > gameSearchData.Moves2)
                                continue;
                        }
                        if (gameSearchData.IsWin)
                        {
                            if (gameItem.GameData.Result != "1-0")
                                continue;
                        }
                        if (gameSearchData.IsDraw)
                        {
                            if (gameItem.GameData.Result != "1/2-1/2")
                                continue;
                        }
                        if (gameSearchData.IsLost)
                        {
                            if (gameItem.GameData.Result != "0-1")
                                continue;
                        }
                        if (gameSearchData.IsMated)
                        {
                            if (gameItem.GameData.ResultReasonE != GameResultReasonE.Mated)
                                continue;
                        }
                        if (gameSearchData.IsStalem)
                        {
                            if (gameItem.GameData.ResultReasonE != GameResultReasonE.StaleMated)
                                continue;
                        }
                        if (gameSearchData.IsCheck)
                        {
                            bool IsInCheck = false;
                            Moves moves = gameItem.Moves;
                            foreach (DataRow dr in moves.DataTable.Rows)
                            {
                                Move m = new Move(dr);
                                m.Game = this.Game;
                                if (m.Flags.IsInCheck)
                                {
                                    IsInCheck = true;
                                }
                            }
                            if (!IsInCheck)
                                continue;
                        }


                        if (gameSearchData.IsOneElo)
                        {
                            if ((gameItem.GameData.EloBlack < gameSearchData.Elo1 || gameItem.GameData.EloBlack > gameSearchData.Elo2) && (gameItem.GameData.EloWhite < gameSearchData.Elo1 || gameItem.GameData.EloWhite > gameSearchData.Elo2))
                            { continue; }
                        }
                        if (gameSearchData.IsBothElo)
                        {
                            if ((gameItem.GameData.EloBlack < gameSearchData.Elo1 || gameItem.GameData.EloBlack > gameSearchData.Elo2) || (gameItem.GameData.EloWhite < gameSearchData.Elo1 || gameItem.GameData.EloWhite > gameSearchData.Elo2))
                            { continue; }
                        }
                        if (gameSearchData.IsAverageElo)
                        {
                            decimal averageElo = (gameItem.GameData.EloWhite + gameItem.GameData.EloBlack) / 2;
                            if ((averageElo < gameSearchData.Elo1 || averageElo > gameSearchData.Elo2))
                            { continue; }
                        }

                    }

                    if (gameSearchData.IsPositonIncluded)
                    {
                        if (!string.IsNullOrEmpty(gameSearchData.BoardFen))
                        {
                            if (gameSearchData.BoardFen != FenParser.GetOnlyFen(Game.InitialBoardFen))
                            {
                                Moves moves = gameItem.Moves;
                                foreach (DataRow dr in moves.DataTable.Rows)
                                {
                                    Move m = new Move(dr);
                                    m.Game = this.Game;
                                    if (FenParser.GetOnlyFen(m.Fen) == gameSearchData.BoardFen)
                                    {
                                        isBoardFenMatched = true;
                                        break;
                                    }
                                    else
                                    {
                                        isBoardFenMatched = false;
                                    }
                                }
                            }
                            else
                            {
                                isBoardFenMatched = true;
                            }
                        }
                    }


                    if ((gameSearchData.IsPositonIncluded && isBoardFenMatched == true) || !gameSearchData.IsPositonIncluded)
                    {
                        DataRow rowx = searchedGames.NewRow();
                        rowx[Database.SerialNo] = serialNo;
                        rowx[Database.Guid] = gameItem.GameData.Guid;
                        rowx[Database.Players] = gameItem.GameData.GamePlayers;
                        rowx[Database.Tournament] = gameItem.GameData.Tournament;
                        rowx[Database.ECO] = gameItem.GameData.EcoCode;
                        rowx[Database.Year] = gameItem.GameData.Year;
                        rowx[Database.Result] = gameItem.GameData.Result;

                        if (gameItem.Moves != null)
                        {
                            rowx[Database.Moves] = ((BaseItems<Move, Moves>)(gameItem.Moves)).Last.MoveNo;
                        }

                        if (gameItem.Moves != null)
                        {
                            rowx[Database.Variation] = App.Model.Moves.HasVariation(gameItem.Moves.DataTable) ? "V" : "";
                        }
                        searchedGames.Rows.Add(rowx);

                        
                        

                    }
                }
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
                ProgressWorkCompletedEventArgs args = new ProgressWorkCompletedEventArgs(e, searchedGames);
                OnProgressWorkCompleted(this, args);
            }
        }

        public void CancelSearching()
        {
            if (backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
            }
        }

        private int GetTotalGamesCount(ArrayList files)
        {
            int totalGames = 0;
            for (int count = 0; count < files.Count; count++)
            {
                Database DbFileVersion = new Database(files[count].ToString(), Game);
                DataTable gamesData = DbFileVersion.GetGamesTable();
                totalGames += gamesData.Rows.Count;
                DbFileVersion = null;
                gamesData = null;
                
            }
            return totalGames;
        }
        #endregion

        #region Save
        public void Save()
        {
            CreateCopyIfRequired(FilePath);            
            UData.WriteXml(DatabaseData, this.FilePath);
        }
        #endregion

        #region GetGamesTable
        public DataTable GetGamesTable(int fromGameNo, int toGameNo)
        {
            DataTable games = GetDatabaseDataTable();
            int rowCounter = 1;
            foreach (DataRow gameRow in DatabaseData.Rows)
            {
                if (rowCounter >= fromGameNo && rowCounter <= toGameNo)
                {
                    games.ImportRow(gameRow);
                }

                rowCounter++;
            }

            return games;
        }
        
        public DataTable GetGamesTable()
        {
            DataTable games = GetDatabaseDataTable();

            foreach (DataRow gameRow in DatabaseData.Rows)
            {
                games.ImportRow(gameRow);
            }

            return games;
        }
        #endregion

        #region GetGamesItems
        public List<GameItem> GetGamesItems(int fromGameNo, int toGameNo)
        {
            List<GameItem> gameItems = new List<GameItem>();
            DataTable gamesData = GetGamesTable(fromGameNo, toGameNo);
            GameItem gameItem = null;

            foreach (DataRow row in gamesData.Rows)
            {
                gameItem = new GameItem(row);
                gameItems.Add(gameItem);
            }
            return gameItems;
        }
        public List<GameItem> GetGamesItems()
        {
            List<GameItem> gameItems = new List<GameItem>();

            DataTable gamesData = GetGamesTable();

            GameItem gameItem = null;
            foreach (DataRow row in gamesData.Rows)
            {
                gameItem = new GameItem(row);
                gameItems.Add(gameItem);
            }
            return gameItems;
        }
        #endregion
        
        #region LastGame
        public DataRow GetLastGameRow()
        {
            DataRow row = null;

            row = (DataRow)DatabaseData.Rows[DatabaseData.Rows.Count - 1];

            return row;
        }

        public GameItem LoadLastGame()
        {
            GameItem gameItem = null;
            DataRow lastRow = GetLastGameRow();
            if (lastRow != null)
            {
                gameItem = new GameItem(lastRow);
            }
            return gameItem;
        }
       #endregion

        #region Helper
        
        public static string ShortPath(string databaseFilePath)
        {
            if (!String.IsNullOrEmpty(databaseFilePath))
            {
                FileInfo databaseFile = new FileInfo(databaseFilePath);
                return @"..\" + databaseFile.Directory.Name + @"\" + databaseFile.Name;
            }
            else
            {
                return string.Empty;
            }
        }

        public static void CreateE2eIfNotExists()
        {
            if (!File.Exists(Ap.FileDatabaseE2E))
            {
                Ap.LoadDatabase(Ap.FileDatabaseE2E);
                Ap.Database.Save();
            }
        }

        public static byte[] StrToByteArray(string str)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetBytes(str);
        }

        public bool ValidEcoRange(string ecoCode1,string ecoCode2, string gameEcoCode)
        {
            Regex expression = new Regex(@"^[A-E](\d{2})$");
            if (string.IsNullOrEmpty(gameEcoCode) || !expression.IsMatch(gameEcoCode))
                return false;
            
            int gameEcoCharacterCode = (int)gameEcoCode[0];
            int gameEcoNumberCode = int.Parse(gameEcoCode.Substring(1));
               
            
            if (!string.IsNullOrEmpty(ecoCode1) && !string.IsNullOrEmpty(ecoCode2))
            {
                int characterCode1 = (int)ecoCode1[0];
                int numberCode1 = int.Parse(ecoCode1.Substring(1,2));
                int characterCode2 = (int)ecoCode2[0];
                int numberCode2 = int.Parse(ecoCode2.Substring(1,2));
                if (gameEcoCharacterCode >= characterCode1 && gameEcoCharacterCode <= characterCode2)
                {
                    if (gameEcoCharacterCode == characterCode1)
                    {
                        if (gameEcoNumberCode < numberCode1)
                        {
                            return false;
                        }
                    }
                    else if (gameEcoCharacterCode == characterCode2)
                    {
                        if (gameEcoNumberCode > numberCode2)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                        return false;
                }

            }
            else if (!string.IsNullOrEmpty(ecoCode1))
            {
                int characterCode1 = (int)ecoCode1[0];
                int numberCode1 = int.Parse(ecoCode1.Substring(1));
          
                if (gameEcoCharacterCode >= characterCode1)
                {
                    if (gameEcoCharacterCode == characterCode1)
                    {
                        if (gameEcoNumberCode < numberCode1)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                int characterCode2 = (int)ecoCode2[0];
                int numberCode2 = int.Parse(ecoCode2.Substring(1));

                if (gameEcoCharacterCode >= characterCode2)
                {
                    if (gameEcoCharacterCode == characterCode2)
                    {
                        if (gameEcoNumberCode < numberCode2)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        #endregion        

        #region Temp 

        public string GetTempItem()
        {
            string s = "";
            s = @"
    <Kv xmlns=""http://tempuri.org/Kv.xsd"">
  <Kv>
    <k>White1</k>
    <v>Rybka_v2.1c.demo.w32</v>
  </Kv>
  <Kv>
    <k>White2</k>
    <v />
  </Kv>
  <Kv>
    <k>Black1</k>
    <v>Infinity Chess</v>
  </Kv>
  <Kv>
    <k>Black2</k>
    <v>.</v>
  </Kv>
  <Kv>
    <k>Tournament</k>
    <v>Blitz 1'</v>
  </Kv>
  <Kv>
    <k>IsECO</k>
    <v>True</v>
  </Kv>
  <Kv>
    <k>EcoCode</k>
    <v>A00</v>
  </Kv>
  <Kv>
    <k>IsEloWhite</k>
    <v>False</v>
  </Kv>
  <Kv>
    <k>EloWhite</k>
    <v>0</v>
  </Kv>
  <Kv>
    <k>IsEloBlack</k>
    <v>False</v>
  </Kv>
  <Kv>
    <k>EloBlack</k>
    <v>0</v>
  </Kv>
  <Kv>
    <k>IsRound</k>
    <v>False</v>
  </Kv>
  <Kv>
    <k>Round</k>
    <v>0</v>
  </Kv>
  <Kv>
    <k>IsSubround</k>
    <v>False</v>
  </Kv>
  <Kv>
    <k>Subround</k>
    <v>0</v>
  </Kv>
  <Kv>
    <k>Result</k>
    <v>1-0</v>
  </Kv>
  <Kv>
    <k>ResultSymbol</k>
    <v />
  </Kv>
  <Kv>
    <k>IsYear</k>
    <v>True</v>
  </Kv>
  <Kv>
    <k>Year</k>
    <v>2010</v>
  </Kv>
  <Kv>
    <k>IsMonth</k>
    <v>True</v>
  </Kv>
  <Kv>
    <k>Month</k>
    <v>9</v>
  </Kv>
  <Kv>
    <k>IsDay</k>
    <v>True</v>
  </Kv>
  <Kv>
    <k>Day</k>
    <v>30</v>
  </Kv>
  <Kv>
    <k>Anotators</k>
    <v />
  </Kv>
  <Kv>
    <k>WhiteTeam</k>
    <v />
  </Kv>
  <Kv>
    <k>BlackTeam</k>
    <v />
  </Kv>
  <Kv>
    <k>Source</k>
    <v />
  </Kv>
  <Kv>
    <k>Guid</k>
    <v>ed4e9796-ddb6-4b38-aa0f-82702e531345</v>
  </Kv>
  <Kv>
    <k>Moves</k>
    <v>&lt;NewDataSet&gt;
  &lt;M&gt;
    &lt;Id&gt;1&lt;/Id&gt;
    &lt;Pid&gt;-1&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;1&lt;/No&gt;
    &lt;P&gt;N&lt;/P&gt;
    &lt;F&gt;b1&lt;/F&gt;
    &lt;T&gt;c3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;60&lt;/Mw&gt;
    &lt;Mb&gt;60&lt;/Mb&gt;
    &lt;Fen&gt;rnbqkbnr/pppppppp/8/8/8/2N5/PPPPPPPP/R1BQKBNR b KQkq - 1 1&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;2&lt;/Id&gt;
    &lt;Pid&gt;1&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;1&lt;/No&gt;
    &lt;P&gt;N&lt;/P&gt;
    &lt;F&gt;b8&lt;/F&gt;
    &lt;T&gt;c6&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;60&lt;/Mw&gt;
    &lt;Mb&gt;59&lt;/Mb&gt;
    &lt;Fen&gt;r1bqkbnr/pppppppp/2n5/8/8/2N5/PPPPPPPP/R1BQKBNR w KQkq - 2 2&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;3&lt;/Id&gt;
    &lt;Pid&gt;2&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;2&lt;/No&gt;
    &lt;P /&gt;
    &lt;F&gt;d2&lt;/F&gt;
    &lt;T&gt;d4&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;59&lt;/Mw&gt;
    &lt;Mb&gt;59&lt;/Mb&gt;
    &lt;Fen&gt;r1bqkbnr/pppppppp/2n5/8/3P4/2N5/PPP1PPPP/R1BQKBNR b KQkq d3 0 2&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;4&lt;/Id&gt;
    &lt;Pid&gt;3&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;2&lt;/No&gt;
    &lt;P /&gt;
    &lt;F&gt;d7&lt;/F&gt;
    &lt;T&gt;d6&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;59&lt;/Mw&gt;
    &lt;Mb&gt;59&lt;/Mb&gt;
    &lt;Fen&gt;r1bqkbnr/ppp1pppp/2np4/8/3P4/2N5/PPP1PPPP/R1BQKBNR w KQkq - 0 3&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;5&lt;/Id&gt;
    &lt;Pid&gt;4&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;3&lt;/No&gt;
    &lt;P&gt;N&lt;/P&gt;
    &lt;F&gt;g1&lt;/F&gt;
    &lt;T&gt;f3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;1&lt;/Mw&gt;
    &lt;Mb&gt;0&lt;/Mb&gt;
    &lt;Fen&gt;r1bqkbnr/ppp1pppp/2np4/8/3P4/2N2N2/PPP1PPPP/R1BQKB1R b KQkq - 1 3&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;6&lt;/Id&gt;
    &lt;Pid&gt;5&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;3&lt;/No&gt;
    &lt;P&gt;N&lt;/P&gt;
    &lt;F&gt;g8&lt;/F&gt;
    &lt;T&gt;f6&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;1&lt;/Mw&gt;
    &lt;Mb&gt;0&lt;/Mb&gt;
    &lt;Fen&gt;r1bqkb1r/ppp1pppp/2np1n2/8/3P4/2N2N2/PPP1PPPP/R1BQKB1R w KQkq - 2 4&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;7&lt;/Id&gt;
    &lt;Pid&gt;6&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;4&lt;/No&gt;
    &lt;P /&gt;
    &lt;F&gt;d4&lt;/F&gt;
    &lt;T&gt;d5&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;2&lt;/Mw&gt;
    &lt;Mb&gt;0&lt;/Mb&gt;
    &lt;Fen&gt;r1bqkb1r/ppp1pppp/2np1n2/3P4/8/2N2N2/PPP1PPPP/R1BQKB1R b KQkq - 0 4&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;8&lt;/Id&gt;
    &lt;Pid&gt;7&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;4&lt;/No&gt;
    &lt;P&gt;N&lt;/P&gt;
    &lt;F&gt;c6&lt;/F&gt;
    &lt;T&gt;e5&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;2&lt;/Mw&gt;
    &lt;Mb&gt;0&lt;/Mb&gt;
    &lt;Fen&gt;r1bqkb1r/ppp1pppp/3p1n2/3Pn3/8/2N2N2/PPP1PPPP/R1BQKB1R w KQkq - 1 5&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;9&lt;/Id&gt;
    &lt;Pid&gt;8&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;5&lt;/No&gt;
    &lt;P&gt;N&lt;/P&gt;
    &lt;F&gt;f3&lt;/F&gt;
    &lt;T&gt;e5&lt;/T&gt;
    &lt;Mf&gt;NxQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;2&lt;/Mw&gt;
    &lt;Mb&gt;0&lt;/Mb&gt;
    &lt;Cp&gt;N&lt;/Cp&gt;
    &lt;Fen&gt;r1bqkb1r/ppp1pppp/3p1n2/3PN3/8/2N5/PPP1PPPP/R1BQKB1R b KQkq - 0 5&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;10&lt;/Id&gt;
    &lt;Pid&gt;9&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;5&lt;/No&gt;
    &lt;P /&gt;
    &lt;F&gt;d6&lt;/F&gt;
    &lt;T&gt;e5&lt;/T&gt;
    &lt;Mf&gt;NxQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;2&lt;/Mw&gt;
    &lt;Mb&gt;1&lt;/Mb&gt;
    &lt;Cp&gt;N&lt;/Cp&gt;
    &lt;Fen&gt;r1bqkb1r/ppp1pppp/5n2/3Pp3/8/2N5/PPP1PPPP/R1BQKB1R w KQkq - 0 6&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;11&lt;/Id&gt;
    &lt;Pid&gt;10&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;6&lt;/No&gt;
    &lt;P&gt;Q&lt;/P&gt;
    &lt;F&gt;d1&lt;/F&gt;
    &lt;T&gt;d3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;2&lt;/Mw&gt;
    &lt;Mb&gt;1&lt;/Mb&gt;
    &lt;Fen&gt;r1bqkb1r/ppp1pppp/5n2/3Pp3/8/2NQ4/PPP1PPPP/R1B1KB1R b KQkq - 1 6&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;12&lt;/Id&gt;
    &lt;Pid&gt;11&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;6&lt;/No&gt;
    &lt;P /&gt;
    &lt;F&gt;c7&lt;/F&gt;
    &lt;T&gt;c6&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;2&lt;/Mw&gt;
    &lt;Mb&gt;1&lt;/Mb&gt;
    &lt;Fen&gt;r1bqkb1r/pp2pppp/2p2n2/3Pp3/8/2NQ4/PPP1PPPP/R1B1KB1R w KQkq - 0 7&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;13&lt;/Id&gt;
    &lt;Pid&gt;12&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;7&lt;/No&gt;
    &lt;P /&gt;
    &lt;F&gt;d5&lt;/F&gt;
    &lt;T&gt;c6&lt;/T&gt;
    &lt;Mf&gt;NxQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;2&lt;/Mw&gt;
    &lt;Mb&gt;1&lt;/Mb&gt;
    &lt;Cp /&gt;
    &lt;Fen&gt;r1bqkb1r/pp2pppp/2P2n2/4p3/8/2NQ4/PPP1PPPP/R1B1KB1R b KQkq - 0 7&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;14&lt;/Id&gt;
    &lt;Pid&gt;13&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;7&lt;/No&gt;
    &lt;P /&gt;
    &lt;F&gt;b7&lt;/F&gt;
    &lt;T&gt;c6&lt;/T&gt;
    &lt;Mf&gt;NxQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;2&lt;/Mw&gt;
    &lt;Mb&gt;2&lt;/Mb&gt;
    &lt;Cp /&gt;
    &lt;Fen&gt;r1bqkb1r/p3pppp/2p2n2/4p3/8/2NQ4/PPP1PPPP/R1B1KB1R w KQkq - 0 8&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;15&lt;/Id&gt;
    &lt;Pid&gt;14&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;8&lt;/No&gt;
    &lt;P&gt;Q&lt;/P&gt;
    &lt;F&gt;d3&lt;/F&gt;
    &lt;T&gt;d8&lt;/T&gt;
    &lt;Mf&gt;Nx+Q&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;2&lt;/Mw&gt;
    &lt;Mb&gt;2&lt;/Mb&gt;
    &lt;Cp&gt;Q&lt;/Cp&gt;
    &lt;Fen&gt;r1bQkb1r/p3pppp/2p2n2/4p3/8/2N5/PPP1PPPP/R1B1KB1R b KQkq - 0 8&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;16&lt;/Id&gt;
    &lt;Pid&gt;15&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;8&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;e8&lt;/F&gt;
    &lt;T&gt;d8&lt;/T&gt;
    &lt;Mf&gt;NxQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;2&lt;/Mw&gt;
    &lt;Mb&gt;2&lt;/Mb&gt;
    &lt;Cp&gt;Q&lt;/Cp&gt;
    &lt;Fen&gt;r1bk1b1r/p3pppp/2p2n2/4p3/8/2N5/PPP1PPPP/R1B1KB1R w KQ - 0 9&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;17&lt;/Id&gt;
    &lt;Pid&gt;16&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;9&lt;/No&gt;
    &lt;P /&gt;
    &lt;F&gt;e2&lt;/F&gt;
    &lt;T&gt;e4&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;3&lt;/Mw&gt;
    &lt;Mb&gt;2&lt;/Mb&gt;
    &lt;Fen&gt;r1bk1b1r/p3pppp/2p2n2/4p3/4P3/2N5/PPP2PPP/R1B1KB1R b KQ e3 0 9&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;18&lt;/Id&gt;
    &lt;Pid&gt;17&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;9&lt;/No&gt;
    &lt;P /&gt;
    &lt;F&gt;e7&lt;/F&gt;
    &lt;T&gt;e6&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;3&lt;/Mw&gt;
    &lt;Mb&gt;2&lt;/Mb&gt;
    &lt;Fen&gt;r1bk1b1r/p4ppp/2p1pn2/4p3/4P3/2N5/PPP2PPP/R1B1KB1R w KQ - 0 10&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;19&lt;/Id&gt;
    &lt;Pid&gt;18&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;10&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;c1&lt;/F&gt;
    &lt;T&gt;e3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;3&lt;/Mw&gt;
    &lt;Mb&gt;2&lt;/Mb&gt;
    &lt;Fen&gt;r1bk1b1r/p4ppp/2p1pn2/4p3/4P3/2N1B3/PPP2PPP/R3KB1R b KQ - 1 10&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;20&lt;/Id&gt;
    &lt;Pid&gt;19&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;10&lt;/No&gt;
    &lt;P&gt;N&lt;/P&gt;
    &lt;F&gt;f6&lt;/F&gt;
    &lt;T&gt;g4&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;3&lt;/Mw&gt;
    &lt;Mb&gt;3&lt;/Mb&gt;
    &lt;Fen&gt;r1bk1b1r/p4ppp/2p1p3/4p3/4P1n1/2N1B3/PPP2PPP/R3KB1R w KQ - 2 11&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;21&lt;/Id&gt;
    &lt;Pid&gt;20&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;11&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;e3&lt;/F&gt;
    &lt;T&gt;g5&lt;/T&gt;
    &lt;Mf&gt;N+Q&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;3&lt;/Mw&gt;
    &lt;Mb&gt;3&lt;/Mb&gt;
    &lt;Fen&gt;r1bk1b1r/p4ppp/2p1p3/4p1B1/4P1n1/2N5/PPP2PPP/R3KB1R b KQ - 3 11&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;22&lt;/Id&gt;
    &lt;Pid&gt;21&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;11&lt;/No&gt;
    &lt;P&gt;N&lt;/P&gt;
    &lt;F&gt;g4&lt;/F&gt;
    &lt;T&gt;f6&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;3&lt;/Mw&gt;
    &lt;Mb&gt;3&lt;/Mb&gt;
    &lt;Fen&gt;r1bk1b1r/p4ppp/2p1pn2/4p1B1/4P3/2N5/PPP2PPP/R3KB1R w KQ - 4 12&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;23&lt;/Id&gt;
    &lt;Pid&gt;22&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;12&lt;/No&gt;
    &lt;P /&gt;
    &lt;F&gt;f2&lt;/F&gt;
    &lt;T&gt;f3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;4&lt;/Mw&gt;
    &lt;Mb&gt;3&lt;/Mb&gt;
    &lt;Fen&gt;r1bk1b1r/p4ppp/2p1pn2/4p1B1/4P3/2N2P2/PPP3PP/R3KB1R b KQ - 0 12&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;24&lt;/Id&gt;
    &lt;Pid&gt;23&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;12&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;f8&lt;/F&gt;
    &lt;T&gt;c5&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;4&lt;/Mw&gt;
    &lt;Mb&gt;3&lt;/Mb&gt;
    &lt;Fen&gt;r1bk3r/p4ppp/2p1pn2/2b1p1B1/4P3/2N2P2/PPP3PP/R3KB1R w KQ - 1 13&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;25&lt;/Id&gt;
    &lt;Pid&gt;24&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;13&lt;/No&gt;
    &lt;P&gt;N&lt;/P&gt;
    &lt;F&gt;c3&lt;/F&gt;
    &lt;T&gt;a4&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;4&lt;/Mw&gt;
    &lt;Mb&gt;3&lt;/Mb&gt;
    &lt;Fen&gt;r1bk3r/p4ppp/2p1pn2/2b1p1B1/N3P3/5P2/PPP3PP/R3KB1R b KQ - 2 13&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;26&lt;/Id&gt;
    &lt;Pid&gt;25&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;13&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;c5&lt;/F&gt;
    &lt;T&gt;e7&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;4&lt;/Mw&gt;
    &lt;Mb&gt;4&lt;/Mb&gt;
    &lt;Fen&gt;r1bk3r/p3bppp/2p1pn2/4p1B1/N3P3/5P2/PPP3PP/R3KB1R w KQ - 3 14&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;27&lt;/Id&gt;
    &lt;Pid&gt;26&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;14&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;g5&lt;/F&gt;
    &lt;T&gt;e3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;4&lt;/Mw&gt;
    &lt;Mb&gt;4&lt;/Mb&gt;
    &lt;Fen&gt;r1bk3r/p3bppp/2p1pn2/4p3/N3P3/4BP2/PPP3PP/R3KB1R b KQ - 4 14&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;28&lt;/Id&gt;
    &lt;Pid&gt;27&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;14&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;d8&lt;/F&gt;
    &lt;T&gt;c7&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;4&lt;/Mw&gt;
    &lt;Mb&gt;4&lt;/Mb&gt;
    &lt;Fen&gt;r1b4r/p1k1bppp/2p1pn2/4p3/N3P3/4BP2/PPP3PP/R3KB1R w KQ - 5 15&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;29&lt;/Id&gt;
    &lt;Pid&gt;28&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;15&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;e1&lt;/F&gt;
    &lt;T&gt;c1&lt;/T&gt;
    &lt;Mf&gt;NCQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;5&lt;/Mw&gt;
    &lt;Mb&gt;4&lt;/Mb&gt;
    &lt;Fen&gt;r1b4r/p1k1bppp/2p1pn2/4p3/N3P3/4BP2/PPP3PP/2KR1B1R b - - 6 15&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;30&lt;/Id&gt;
    &lt;Pid&gt;29&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;15&lt;/No&gt;
    &lt;P&gt;N&lt;/P&gt;
    &lt;F&gt;f6&lt;/F&gt;
    &lt;T&gt;d7&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;5&lt;/Mw&gt;
    &lt;Mb&gt;4&lt;/Mb&gt;
    &lt;Fen&gt;r1b4r/p1knbppp/2p1p3/4p3/N3P3/4BP2/PPP3PP/2KR1B1R w - - 7 16&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;31&lt;/Id&gt;
    &lt;Pid&gt;30&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;16&lt;/No&gt;
    &lt;P /&gt;
    &lt;F&gt;b2&lt;/F&gt;
    &lt;T&gt;b3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;5&lt;/Mw&gt;
    &lt;Mb&gt;4&lt;/Mb&gt;
    &lt;Fen&gt;r1b4r/p1knbppp/2p1p3/4p3/N3P3/1P2BP2/P1P3PP/2KR1B1R b - - 0 16&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;32&lt;/Id&gt;
    &lt;Pid&gt;31&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;16&lt;/No&gt;
    &lt;P&gt;R&lt;/P&gt;
    &lt;F&gt;h8&lt;/F&gt;
    &lt;T&gt;d8&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;5&lt;/Mw&gt;
    &lt;Mb&gt;4&lt;/Mb&gt;
    &lt;Fen&gt;r1br4/p1knbppp/2p1p3/4p3/N3P3/1P2BP2/P1P3PP/2KR1B1R w - - 1 17&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;33&lt;/Id&gt;
    &lt;Pid&gt;32&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;17&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;f1&lt;/F&gt;
    &lt;T&gt;e2&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;6&lt;/Mw&gt;
    &lt;Mb&gt;4&lt;/Mb&gt;
    &lt;Fen&gt;r1br4/p1knbppp/2p1p3/4p3/N3P3/1P2BP2/P1P1B1PP/2KR3R b - - 2 17&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;34&lt;/Id&gt;
    &lt;Pid&gt;33&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;17&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;e7&lt;/F&gt;
    &lt;T&gt;a3&lt;/T&gt;
    &lt;Mf&gt;N+Q&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;6&lt;/Mw&gt;
    &lt;Mb&gt;4&lt;/Mb&gt;
    &lt;Fen&gt;r1br4/p1kn1ppp/2p1p3/4p3/N3P3/bP2BP2/P1P1B1PP/2KR3R w - - 3 18&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;35&lt;/Id&gt;
    &lt;Pid&gt;34&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;18&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;c1&lt;/F&gt;
    &lt;T&gt;b1&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;6&lt;/Mw&gt;
    &lt;Mb&gt;4&lt;/Mb&gt;
    &lt;Fen&gt;r1br4/p1kn1ppp/2p1p3/4p3/N3P3/bP2BP2/P1P1B1PP/1K1R3R b - - 4 18&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;36&lt;/Id&gt;
    &lt;Pid&gt;35&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;18&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;c8&lt;/F&gt;
    &lt;T&gt;b7&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;6&lt;/Mw&gt;
    &lt;Mb&gt;5&lt;/Mb&gt;
    &lt;Fen&gt;r2r4/pbkn1ppp/2p1p3/4p3/N3P3/bP2BP2/P1P1B1PP/1K1R3R w - - 5 19&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;37&lt;/Id&gt;
    &lt;Pid&gt;36&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;19&lt;/No&gt;
    &lt;P&gt;N&lt;/P&gt;
    &lt;F&gt;a4&lt;/F&gt;
    &lt;T&gt;b2&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;6&lt;/Mw&gt;
    &lt;Mb&gt;5&lt;/Mb&gt;
    &lt;Fen&gt;r2r4/pbkn1ppp/2p1p3/4p3/4P3/bP2BP2/PNP1B1PP/1K1R3R b - - 6 19&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;38&lt;/Id&gt;
    &lt;Pid&gt;37&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;19&lt;/No&gt;
    &lt;P&gt;N&lt;/P&gt;
    &lt;F&gt;d7&lt;/F&gt;
    &lt;T&gt;b6&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;6&lt;/Mw&gt;
    &lt;Mb&gt;5&lt;/Mb&gt;
    &lt;Fen&gt;r2r4/pbk2ppp/1np1p3/4p3/4P3/bP2BP2/PNP1B1PP/1K1R3R w - - 7 20&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;39&lt;/Id&gt;
    &lt;Pid&gt;38&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;20&lt;/No&gt;
    &lt;P&gt;N&lt;/P&gt;
    &lt;F&gt;b2&lt;/F&gt;
    &lt;T&gt;d3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;7&lt;/Mw&gt;
    &lt;Mb&gt;5&lt;/Mb&gt;
    &lt;Fen&gt;r2r4/pbk2ppp/1np1p3/4p3/4P3/bP1NBP2/P1P1B1PP/1K1R3R b - - 8 20&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;40&lt;/Id&gt;
    &lt;Pid&gt;39&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;20&lt;/No&gt;
    &lt;P&gt;N&lt;/P&gt;
    &lt;F&gt;b6&lt;/F&gt;
    &lt;T&gt;d7&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;7&lt;/Mw&gt;
    &lt;Mb&gt;5&lt;/Mb&gt;
    &lt;Fen&gt;r2r4/pbkn1ppp/2p1p3/4p3/4P3/bP1NBP2/P1P1B1PP/1K1R3R w - - 9 21&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;41&lt;/Id&gt;
    &lt;Pid&gt;40&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;21&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;e3&lt;/F&gt;
    &lt;T&gt;g5&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;7&lt;/Mw&gt;
    &lt;Mb&gt;5&lt;/Mb&gt;
    &lt;Fen&gt;r2r4/pbkn1ppp/2p1p3/4p1B1/4P3/bP1N1P2/P1P1B1PP/1K1R3R b - - 10 21&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;42&lt;/Id&gt;
    &lt;Pid&gt;41&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;21&lt;/No&gt;
    &lt;P /&gt;
    &lt;F&gt;f7&lt;/F&gt;
    &lt;T&gt;f6&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;7&lt;/Mw&gt;
    &lt;Mb&gt;6&lt;/Mb&gt;
    &lt;Fen&gt;r2r4/pbkn2pp/2p1pp2/4p1B1/4P3/bP1N1P2/P1P1B1PP/1K1R3R w - - 0 22&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;43&lt;/Id&gt;
    &lt;Pid&gt;42&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;22&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;g5&lt;/F&gt;
    &lt;T&gt;e3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;7&lt;/Mw&gt;
    &lt;Mb&gt;6&lt;/Mb&gt;
    &lt;Fen&gt;r2r4/pbkn2pp/2p1pp2/4p3/4P3/bP1NBP2/P1P1B1PP/1K1R3R b - - 1 22&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;44&lt;/Id&gt;
    &lt;Pid&gt;43&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;22&lt;/No&gt;
    &lt;P /&gt;
    &lt;F&gt;c6&lt;/F&gt;
    &lt;T&gt;c5&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;7&lt;/Mw&gt;
    &lt;Mb&gt;6&lt;/Mb&gt;
    &lt;Fen&gt;r2r4/pbkn2pp/4pp2/2p1p3/4P3/bP1NBP2/P1P1B1PP/1K1R3R w - - 0 23&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;45&lt;/Id&gt;
    &lt;Pid&gt;44&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;23&lt;/No&gt;
    &lt;P /&gt;
    &lt;F&gt;c2&lt;/F&gt;
    &lt;T&gt;c3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;8&lt;/Mw&gt;
    &lt;Mb&gt;6&lt;/Mb&gt;
    &lt;Fen&gt;r2r4/pbkn2pp/4pp2/2p1p3/4P3/bPPNBP2/P3B1PP/1K1R3R b - - 0 23&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;46&lt;/Id&gt;
    &lt;Pid&gt;45&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;23&lt;/No&gt;
    &lt;P /&gt;
    &lt;F&gt;f6&lt;/F&gt;
    &lt;T&gt;f5&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;8&lt;/Mw&gt;
    &lt;Mb&gt;6&lt;/Mb&gt;
    &lt;Fen&gt;r2r4/pbkn2pp/4p3/2p1pp2/4P3/bPPNBP2/P3B1PP/1K1R3R w - - 0 24&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;47&lt;/Id&gt;
    &lt;Pid&gt;46&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;24&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;e3&lt;/F&gt;
    &lt;T&gt;g5&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;8&lt;/Mw&gt;
    &lt;Mb&gt;6&lt;/Mb&gt;
    &lt;Fen&gt;r2r4/pbkn2pp/4p3/2p1ppB1/4P3/bPPN1P2/P3B1PP/1K1R3R b - - 1 24&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;48&lt;/Id&gt;
    &lt;Pid&gt;47&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;24&lt;/No&gt;
    &lt;P&gt;R&lt;/P&gt;
    &lt;F&gt;d8&lt;/F&gt;
    &lt;T&gt;e8&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;8&lt;/Mw&gt;
    &lt;Mb&gt;6&lt;/Mb&gt;
    &lt;Fen&gt;r3r3/pbkn2pp/4p3/2p1ppB1/4P3/bPPN1P2/P3B1PP/1K1R3R w - - 2 25&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;49&lt;/Id&gt;
    &lt;Pid&gt;48&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;25&lt;/No&gt;
    &lt;P&gt;N&lt;/P&gt;
    &lt;F&gt;d3&lt;/F&gt;
    &lt;T&gt;e5&lt;/T&gt;
    &lt;Mf&gt;NxQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;9&lt;/Mw&gt;
    &lt;Mb&gt;6&lt;/Mb&gt;
    &lt;Cp /&gt;
    &lt;Fen&gt;r3r3/pbkn2pp/4p3/2p1NpB1/4P3/bPP2P2/P3B1PP/1K1R3R b - - 0 25&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;50&lt;/Id&gt;
    &lt;Pid&gt;49&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;25&lt;/No&gt;
    &lt;P&gt;N&lt;/P&gt;
    &lt;F&gt;d7&lt;/F&gt;
    &lt;T&gt;e5&lt;/T&gt;
    &lt;Mf&gt;NxQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;9&lt;/Mw&gt;
    &lt;Mb&gt;7&lt;/Mb&gt;
    &lt;Cp&gt;N&lt;/Cp&gt;
    &lt;Fen&gt;r3r3/pbk3pp/4p3/2p1npB1/4P3/bPP2P2/P3B1PP/1K1R3R w - - 0 26&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;51&lt;/Id&gt;
    &lt;Pid&gt;50&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;26&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;g5&lt;/F&gt;
    &lt;T&gt;f4&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;9&lt;/Mw&gt;
    &lt;Mb&gt;7&lt;/Mb&gt;
    &lt;Fen&gt;r3r3/pbk3pp/4p3/2p1np2/4PB2/bPP2P2/P3B1PP/1K1R3R b - - 1 26&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;52&lt;/Id&gt;
    &lt;Pid&gt;51&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;26&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;b7&lt;/F&gt;
    &lt;T&gt;c6&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;9&lt;/Mw&gt;
    &lt;Mb&gt;7&lt;/Mb&gt;
    &lt;Fen&gt;r3r3/p1k3pp/2b1p3/2p1np2/4PB2/bPP2P2/P3B1PP/1K1R3R w - - 2 27&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;53&lt;/Id&gt;
    &lt;Pid&gt;52&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;27&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;f4&lt;/F&gt;
    &lt;T&gt;e5&lt;/T&gt;
    &lt;Mf&gt;Nx+Q&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;10&lt;/Mw&gt;
    &lt;Mb&gt;7&lt;/Mb&gt;
    &lt;Cp&gt;N&lt;/Cp&gt;
    &lt;Fen&gt;r3r3/p1k3pp/2b1p3/2p1Bp2/4P3/bPP2P2/P3B1PP/1K1R3R b - - 0 27&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;54&lt;/Id&gt;
    &lt;Pid&gt;53&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;27&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;c7&lt;/F&gt;
    &lt;T&gt;b6&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;10&lt;/Mw&gt;
    &lt;Mb&gt;7&lt;/Mb&gt;
    &lt;Fen&gt;r3r3/p5pp/1kb1p3/2p1Bp2/4P3/bPP2P2/P3B1PP/1K1R3R w - - 1 28&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;55&lt;/Id&gt;
    &lt;Pid&gt;54&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;28&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;e2&lt;/F&gt;
    &lt;T&gt;d3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;10&lt;/Mw&gt;
    &lt;Mb&gt;7&lt;/Mb&gt;
    &lt;Fen&gt;r3r3/p5pp/1kb1p3/2p1Bp2/4P3/bPPB1P2/P5PP/1K1R3R b - - 2 28&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;56&lt;/Id&gt;
    &lt;Pid&gt;55&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;28&lt;/No&gt;
    &lt;P /&gt;
    &lt;F&gt;g7&lt;/F&gt;
    &lt;T&gt;g6&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;10&lt;/Mw&gt;
    &lt;Mb&gt;8&lt;/Mb&gt;
    &lt;Fen&gt;r3r3/p6p/1kb1p1p1/2p1Bp2/4P3/bPPB1P2/P5PP/1K1R3R w - - 0 29&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;57&lt;/Id&gt;
    &lt;Pid&gt;56&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;29&lt;/No&gt;
    &lt;P&gt;R&lt;/P&gt;
    &lt;F&gt;h1&lt;/F&gt;
    &lt;T&gt;e1&lt;/T&gt;
    &lt;Mf&gt;NDFQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;11&lt;/Mw&gt;
    &lt;Mb&gt;8&lt;/Mb&gt;
    &lt;Fen&gt;r3r3/p6p/1kb1p1p1/2p1Bp2/4P3/bPPB1P2/P5PP/1K1RR3 b - - 1 29&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;58&lt;/Id&gt;
    &lt;Pid&gt;57&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;29&lt;/No&gt;
    &lt;P&gt;R&lt;/P&gt;
    &lt;F&gt;a8&lt;/F&gt;
    &lt;T&gt;d8&lt;/T&gt;
    &lt;Mf&gt;NDFQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;11&lt;/Mw&gt;
    &lt;Mb&gt;8&lt;/Mb&gt;
    &lt;Fen&gt;3rr3/p6p/1kb1p1p1/2p1Bp2/4P3/bPPB1P2/P5PP/1K1RR3 w - - 2 30&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;59&lt;/Id&gt;
    &lt;Pid&gt;58&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;30&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;e5&lt;/F&gt;
    &lt;T&gt;f6&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;11&lt;/Mw&gt;
    &lt;Mb&gt;8&lt;/Mb&gt;
    &lt;Fen&gt;3rr3/p6p/1kb1pBp1/2p2p2/4P3/bPPB1P2/P5PP/1K1RR3 b - - 3 30&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;60&lt;/Id&gt;
    &lt;Pid&gt;59&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;30&lt;/No&gt;
    &lt;P&gt;R&lt;/P&gt;
    &lt;F&gt;d8&lt;/F&gt;
    &lt;T&gt;d7&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;11&lt;/Mw&gt;
    &lt;Mb&gt;9&lt;/Mb&gt;
    &lt;Fen&gt;4r3/p2r3p/1kb1pBp1/2p2p2/4P3/bPPB1P2/P5PP/1K1RR3 w - - 4 31&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;61&lt;/Id&gt;
    &lt;Pid&gt;60&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;31&lt;/No&gt;
    &lt;P /&gt;
    &lt;F&gt;e4&lt;/F&gt;
    &lt;T&gt;f5&lt;/T&gt;
    &lt;Mf&gt;NxQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;11&lt;/Mw&gt;
    &lt;Mb&gt;9&lt;/Mb&gt;
    &lt;Cp /&gt;
    &lt;Fen&gt;4r3/p2r3p/1kb1pBp1/2p2P2/8/bPPB1P2/P5PP/1K1RR3 b - - 0 31&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;62&lt;/Id&gt;
    &lt;Pid&gt;61&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;31&lt;/No&gt;
    &lt;P /&gt;
    &lt;F&gt;g6&lt;/F&gt;
    &lt;T&gt;f5&lt;/T&gt;
    &lt;Mf&gt;NxQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;11&lt;/Mw&gt;
    &lt;Mb&gt;9&lt;/Mb&gt;
    &lt;Cp /&gt;
    &lt;Fen&gt;4r3/p2r3p/1kb1pB2/2p2p2/8/bPPB1P2/P5PP/1K1RR3 w - - 0 32&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;63&lt;/Id&gt;
    &lt;Pid&gt;62&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;32&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;d3&lt;/F&gt;
    &lt;T&gt;c4&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;12&lt;/Mw&gt;
    &lt;Mb&gt;9&lt;/Mb&gt;
    &lt;Fen&gt;4r3/p2r3p/1kb1pB2/2p2p2/2B5/bPP2P2/P5PP/1K1RR3 b - - 1 32&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;64&lt;/Id&gt;
    &lt;Pid&gt;63&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;32&lt;/No&gt;
    &lt;P&gt;R&lt;/P&gt;
    &lt;F&gt;d7&lt;/F&gt;
    &lt;T&gt;d1&lt;/T&gt;
    &lt;Mf&gt;Nx+Q&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;12&lt;/Mw&gt;
    &lt;Mb&gt;9&lt;/Mb&gt;
    &lt;Cp&gt;R&lt;/Cp&gt;
    &lt;Fen&gt;4r3/p6p/1kb1pB2/2p2p2/2B5/bPP2P2/P5PP/1K1rR3 w - - 0 33&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;65&lt;/Id&gt;
    &lt;Pid&gt;64&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;33&lt;/No&gt;
    &lt;P&gt;R&lt;/P&gt;
    &lt;F&gt;e1&lt;/F&gt;
    &lt;T&gt;d1&lt;/T&gt;
    &lt;Mf&gt;NxQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;13&lt;/Mw&gt;
    &lt;Mb&gt;9&lt;/Mb&gt;
    &lt;Cp&gt;R&lt;/Cp&gt;
    &lt;Fen&gt;4r3/p6p/1kb1pB2/2p2p2/2B5/bPP2P2/P5PP/1K1R4 b - - 0 33&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;66&lt;/Id&gt;
    &lt;Pid&gt;65&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;33&lt;/No&gt;
    &lt;P&gt;R&lt;/P&gt;
    &lt;F&gt;e8&lt;/F&gt;
    &lt;T&gt;g8&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;13&lt;/Mw&gt;
    &lt;Mb&gt;9&lt;/Mb&gt;
    &lt;Fen&gt;6r1/p6p/1kb1pB2/2p2p2/2B5/bPP2P2/P5PP/1K1R4 w - - 1 34&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;67&lt;/Id&gt;
    &lt;Pid&gt;66&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;34&lt;/No&gt;
    &lt;P /&gt;
    &lt;F&gt;g2&lt;/F&gt;
    &lt;T&gt;g3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;14&lt;/Mw&gt;
    &lt;Mb&gt;9&lt;/Mb&gt;
    &lt;Fen&gt;6r1/p6p/1kb1pB2/2p2p2/2B5/bPP2PP1/P6P/1K1R4 b - - 0 34&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;68&lt;/Id&gt;
    &lt;Pid&gt;67&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;34&lt;/No&gt;
    &lt;P&gt;R&lt;/P&gt;
    &lt;F&gt;g8&lt;/F&gt;
    &lt;T&gt;f8&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;14&lt;/Mw&gt;
    &lt;Mb&gt;9&lt;/Mb&gt;
    &lt;Fen&gt;5r2/p6p/1kb1pB2/2p2p2/2B5/bPP2PP1/P6P/1K1R4 w - - 1 35&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;69&lt;/Id&gt;
    &lt;Pid&gt;68&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;35&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;f6&lt;/F&gt;
    &lt;T&gt;e5&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;15&lt;/Mw&gt;
    &lt;Mb&gt;9&lt;/Mb&gt;
    &lt;Fen&gt;5r2/p6p/1kb1p3/2p1Bp2/2B5/bPP2PP1/P6P/1K1R4 b - - 2 35&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;70&lt;/Id&gt;
    &lt;Pid&gt;69&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;35&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;c6&lt;/F&gt;
    &lt;T&gt;f3&lt;/T&gt;
    &lt;Mf&gt;NxQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;15&lt;/Mw&gt;
    &lt;Mb&gt;10&lt;/Mb&gt;
    &lt;Cp /&gt;
    &lt;Fen&gt;5r2/p6p/1k2p3/2p1Bp2/2B5/bPP2bP1/P6P/1K1R4 w - - 0 36&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;71&lt;/Id&gt;
    &lt;Pid&gt;70&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;36&lt;/No&gt;
    &lt;P&gt;R&lt;/P&gt;
    &lt;F&gt;d1&lt;/F&gt;
    &lt;T&gt;d6&lt;/T&gt;
    &lt;Mf&gt;N+Q&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;15&lt;/Mw&gt;
    &lt;Mb&gt;10&lt;/Mb&gt;
    &lt;Fen&gt;5r2/p6p/1k1Rp3/2p1Bp2/2B5/bPP2bP1/P6P/1K6 b - - 1 36&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;72&lt;/Id&gt;
    &lt;Pid&gt;71&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;36&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;b6&lt;/F&gt;
    &lt;T&gt;b7&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;15&lt;/Mw&gt;
    &lt;Mb&gt;11&lt;/Mb&gt;
    &lt;Fen&gt;5r2/pk5p/3Rp3/2p1Bp2/2B5/bPP2bP1/P6P/1K6 w - - 2 37&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;73&lt;/Id&gt;
    &lt;Pid&gt;72&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;37&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;b1&lt;/F&gt;
    &lt;T&gt;c2&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;15&lt;/Mw&gt;
    &lt;Mb&gt;11&lt;/Mb&gt;
    &lt;Fen&gt;5r2/pk5p/3Rp3/2p1Bp2/2B5/bPP2bP1/P1K4P/8 b - - 3 37&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;74&lt;/Id&gt;
    &lt;Pid&gt;73&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;37&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;f3&lt;/F&gt;
    &lt;T&gt;e4&lt;/T&gt;
    &lt;Mf&gt;N+Q&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;15&lt;/Mw&gt;
    &lt;Mb&gt;12&lt;/Mb&gt;
    &lt;Fen&gt;5r2/pk5p/3Rp3/2p1Bp2/2B1b3/bPP3P1/P1K4P/8 w - - 4 38&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;75&lt;/Id&gt;
    &lt;Pid&gt;74&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;38&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;c2&lt;/F&gt;
    &lt;T&gt;d2&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;16&lt;/Mw&gt;
    &lt;Mb&gt;12&lt;/Mb&gt;
    &lt;Fen&gt;5r2/pk5p/3Rp3/2p1Bp2/2B1b3/bPP3P1/P2K3P/8 b - - 5 38&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;76&lt;/Id&gt;
    &lt;Pid&gt;75&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;38&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;e4&lt;/F&gt;
    &lt;T&gt;c6&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;16&lt;/Mw&gt;
    &lt;Mb&gt;12&lt;/Mb&gt;
    &lt;Fen&gt;5r2/pk5p/2bRp3/2p1Bp2/2B5/bPP3P1/P2K3P/8 w - - 6 39&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;77&lt;/Id&gt;
    &lt;Pid&gt;76&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;39&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;c4&lt;/F&gt;
    &lt;T&gt;e6&lt;/T&gt;
    &lt;Mf&gt;NxQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;17&lt;/Mw&gt;
    &lt;Mb&gt;12&lt;/Mb&gt;
    &lt;Cp /&gt;
    &lt;Fen&gt;5r2/pk5p/2bRB3/2p1Bp2/8/bPP3P1/P2K3P/8 b - - 0 39&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;78&lt;/Id&gt;
    &lt;Pid&gt;77&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;39&lt;/No&gt;
    &lt;P /&gt;
    &lt;F&gt;c5&lt;/F&gt;
    &lt;T&gt;c4&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;17&lt;/Mw&gt;
    &lt;Mb&gt;12&lt;/Mb&gt;
    &lt;Fen&gt;5r2/pk5p/2bRB3/4Bp2/2p5/bPP3P1/P2K3P/8 w - - 0 40&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;79&lt;/Id&gt;
    &lt;Pid&gt;78&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;40&lt;/No&gt;
    &lt;P /&gt;
    &lt;F&gt;b3&lt;/F&gt;
    &lt;T&gt;b4&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;18&lt;/Mw&gt;
    &lt;Mb&gt;12&lt;/Mb&gt;
    &lt;Fen&gt;5r2/pk5p/2bRB3/4Bp2/1Pp5/b1P3P1/P2K3P/8 b - - 0 40&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;80&lt;/Id&gt;
    &lt;Pid&gt;79&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;40&lt;/No&gt;
    &lt;P /&gt;
    &lt;F&gt;a7&lt;/F&gt;
    &lt;T&gt;a5&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;18&lt;/Mw&gt;
    &lt;Mb&gt;12&lt;/Mb&gt;
    &lt;Fen&gt;5r2/1k5p/2bRB3/p3Bp2/1Pp5/b1P3P1/P2K3P/8 w - a6 0 41&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;81&lt;/Id&gt;
    &lt;Pid&gt;80&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;41&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;e6&lt;/F&gt;
    &lt;T&gt;c4&lt;/T&gt;
    &lt;Mf&gt;NxQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;19&lt;/Mw&gt;
    &lt;Mb&gt;12&lt;/Mb&gt;
    &lt;Cp /&gt;
    &lt;Fen&gt;5r2/1k5p/2bR4/p3Bp2/1PB5/b1P3P1/P2K3P/8 b - - 0 41&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;82&lt;/Id&gt;
    &lt;Pid&gt;81&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;41&lt;/No&gt;
    &lt;P /&gt;
    &lt;F&gt;a5&lt;/F&gt;
    &lt;T&gt;b4&lt;/T&gt;
    &lt;Mf&gt;NxQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;19&lt;/Mw&gt;
    &lt;Mb&gt;13&lt;/Mb&gt;
    &lt;Cp /&gt;
    &lt;Fen&gt;5r2/1k5p/2bR4/4Bp2/1pB5/b1P3P1/P2K3P/8 w - - 0 42&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;83&lt;/Id&gt;
    &lt;Pid&gt;82&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;42&lt;/No&gt;
    &lt;P&gt;R&lt;/P&gt;
    &lt;F&gt;d6&lt;/F&gt;
    &lt;T&gt;h6&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;19&lt;/Mw&gt;
    &lt;Mb&gt;13&lt;/Mb&gt;
    &lt;Fen&gt;5r2/1k5p/2b4R/4Bp2/1pB5/b1P3P1/P2K3P/8 b - - 1 42&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;84&lt;/Id&gt;
    &lt;Pid&gt;83&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;42&lt;/No&gt;
    &lt;P&gt;R&lt;/P&gt;
    &lt;F&gt;f8&lt;/F&gt;
    &lt;T&gt;d8&lt;/T&gt;
    &lt;Mf&gt;N+Q&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;19&lt;/Mw&gt;
    &lt;Mb&gt;14&lt;/Mb&gt;
    &lt;Fen&gt;3r4/1k5p/2b4R/4Bp2/1pB5/b1P3P1/P2K3P/8 w - - 2 43&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;85&lt;/Id&gt;
    &lt;Pid&gt;84&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;43&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;e5&lt;/F&gt;
    &lt;T&gt;d4&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;19&lt;/Mw&gt;
    &lt;Mb&gt;14&lt;/Mb&gt;
    &lt;Fen&gt;3r4/1k5p/2b4R/5p2/1pBB4/b1P3P1/P2K3P/8 b - - 3 43&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;86&lt;/Id&gt;
    &lt;Pid&gt;85&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;43&lt;/No&gt;
    &lt;P&gt;R&lt;/P&gt;
    &lt;F&gt;d8&lt;/F&gt;
    &lt;T&gt;d7&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;19&lt;/Mw&gt;
    &lt;Mb&gt;15&lt;/Mb&gt;
    &lt;Fen&gt;8/1k1r3p/2b4R/5p2/1pBB4/b1P3P1/P2K3P/8 w - - 4 44&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;87&lt;/Id&gt;
    &lt;Pid&gt;86&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;44&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;c4&lt;/F&gt;
    &lt;T&gt;e6&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;19&lt;/Mw&gt;
    &lt;Mb&gt;15&lt;/Mb&gt;
    &lt;Fen&gt;8/1k1r3p/2b1B2R/5p2/1p1B4/b1P3P1/P2K3P/8 b - - 5 44&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;88&lt;/Id&gt;
    &lt;Pid&gt;87&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;44&lt;/No&gt;
    &lt;P /&gt;
    &lt;F&gt;b4&lt;/F&gt;
    &lt;T&gt;c3&lt;/T&gt;
    &lt;Mf&gt;Nx+Q&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;19&lt;/Mw&gt;
    &lt;Mb&gt;16&lt;/Mb&gt;
    &lt;Cp /&gt;
    &lt;Fen&gt;8/1k1r3p/2b1B2R/5p2/3B4/b1p3P1/P2K3P/8 w - - 0 45&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;89&lt;/Id&gt;
    &lt;Pid&gt;88&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;45&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;d2&lt;/F&gt;
    &lt;T&gt;c3&lt;/T&gt;
    &lt;Mf&gt;NxQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;19&lt;/Mw&gt;
    &lt;Mb&gt;16&lt;/Mb&gt;
    &lt;Cp /&gt;
    &lt;Fen&gt;8/1k1r3p/2b1B2R/5p2/3B4/b1K3P1/P6P/8 b - - 0 45&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;90&lt;/Id&gt;
    &lt;Pid&gt;89&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;45&lt;/No&gt;
    &lt;P&gt;R&lt;/P&gt;
    &lt;F&gt;d7&lt;/F&gt;
    &lt;T&gt;c7&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;19&lt;/Mw&gt;
    &lt;Mb&gt;17&lt;/Mb&gt;
    &lt;Fen&gt;8/1kr4p/2b1B2R/5p2/3B4/b1K3P1/P6P/8 w - - 1 46&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;91&lt;/Id&gt;
    &lt;Pid&gt;90&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;46&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;d4&lt;/F&gt;
    &lt;T&gt;e5&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;20&lt;/Mw&gt;
    &lt;Mb&gt;17&lt;/Mb&gt;
    &lt;Fen&gt;8/1kr4p/2b1B2R/4Bp2/8/b1K3P1/P6P/8 b - - 2 46&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;92&lt;/Id&gt;
    &lt;Pid&gt;91&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;46&lt;/No&gt;
    &lt;P&gt;R&lt;/P&gt;
    &lt;F&gt;c7&lt;/F&gt;
    &lt;T&gt;e7&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;20&lt;/Mw&gt;
    &lt;Mb&gt;17&lt;/Mb&gt;
    &lt;Fen&gt;8/1k2r2p/2b1B2R/4Bp2/8/b1K3P1/P6P/8 w - - 3 47&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;93&lt;/Id&gt;
    &lt;Pid&gt;92&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;47&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;e5&lt;/F&gt;
    &lt;T&gt;f4&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;21&lt;/Mw&gt;
    &lt;Mb&gt;17&lt;/Mb&gt;
    &lt;Fen&gt;8/1k2r2p/2b1B2R/5p2/5B2/b1K3P1/P6P/8 b - - 4 47&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;94&lt;/Id&gt;
    &lt;Pid&gt;93&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;47&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;c6&lt;/F&gt;
    &lt;T&gt;e4&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;21&lt;/Mw&gt;
    &lt;Mb&gt;18&lt;/Mb&gt;
    &lt;Fen&gt;8/1k2r2p/4B2R/5p2/4bB2/b1K3P1/P6P/8 w - - 5 48&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;95&lt;/Id&gt;
    &lt;Pid&gt;94&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;48&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;e6&lt;/F&gt;
    &lt;T&gt;g8&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;21&lt;/Mw&gt;
    &lt;Mb&gt;18&lt;/Mb&gt;
    &lt;Fen&gt;6B1/1k2r2p/7R/5p2/4bB2/b1K3P1/P6P/8 b - - 6 48&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;96&lt;/Id&gt;
    &lt;Pid&gt;95&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;48&lt;/No&gt;
    &lt;P&gt;R&lt;/P&gt;
    &lt;F&gt;e7&lt;/F&gt;
    &lt;T&gt;d7&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;21&lt;/Mw&gt;
    &lt;Mb&gt;19&lt;/Mb&gt;
    &lt;Fen&gt;6B1/1k1r3p/7R/5p2/4bB2/b1K3P1/P6P/8 w - - 7 49&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;97&lt;/Id&gt;
    &lt;Pid&gt;96&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;49&lt;/No&gt;
    &lt;P&gt;R&lt;/P&gt;
    &lt;F&gt;h6&lt;/F&gt;
    &lt;T&gt;h7&lt;/T&gt;
    &lt;Mf&gt;NxQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;22&lt;/Mw&gt;
    &lt;Mb&gt;19&lt;/Mb&gt;
    &lt;Cp /&gt;
    &lt;Fen&gt;6B1/1k1r3R/8/5p2/4bB2/b1K3P1/P6P/8 b - - 0 49&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;98&lt;/Id&gt;
    &lt;Pid&gt;97&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;49&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;a3&lt;/F&gt;
    &lt;T&gt;e7&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;22&lt;/Mw&gt;
    &lt;Mb&gt;19&lt;/Mb&gt;
    &lt;Fen&gt;6B1/1k1rb2R/8/5p2/4bB2/2K3P1/P6P/8 w - - 1 50&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;99&lt;/Id&gt;
    &lt;Pid&gt;98&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;50&lt;/No&gt;
    &lt;P /&gt;
    &lt;F&gt;a2&lt;/F&gt;
    &lt;T&gt;a4&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;2&lt;/Mt&gt;
    &lt;Mw&gt;24&lt;/Mw&gt;
    &lt;Mb&gt;19&lt;/Mb&gt;
    &lt;Fen&gt;6B1/1k1rb2R/8/5p2/P3bB2/2K3P1/7P/8 b - a3 0 50&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;100&lt;/Id&gt;
    &lt;Pid&gt;99&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;50&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;e4&lt;/F&gt;
    &lt;T&gt;f3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;24&lt;/Mw&gt;
    &lt;Mb&gt;19&lt;/Mb&gt;
    &lt;Fen&gt;6B1/1k1rb2R/8/5p2/P4B2/2K2bP1/7P/8 w - - 1 51&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;101&lt;/Id&gt;
    &lt;Pid&gt;100&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;51&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;f4&lt;/F&gt;
    &lt;T&gt;d6&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;25&lt;/Mw&gt;
    &lt;Mb&gt;19&lt;/Mb&gt;
    &lt;Fen&gt;6B1/1k1rb2R/3B4/5p2/P7/2K2bP1/7P/8 b - - 2 51&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;102&lt;/Id&gt;
    &lt;Pid&gt;101&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;51&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;e7&lt;/F&gt;
    &lt;T&gt;f6&lt;/T&gt;
    &lt;Mf&gt;N+Q&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;25&lt;/Mw&gt;
    &lt;Mb&gt;19&lt;/Mb&gt;
    &lt;Fen&gt;6B1/1k1r3R/3B1b2/5p2/P7/2K2bP1/7P/8 w - - 3 52&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;103&lt;/Id&gt;
    &lt;Pid&gt;102&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;52&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;c3&lt;/F&gt;
    &lt;T&gt;b4&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;26&lt;/Mw&gt;
    &lt;Mb&gt;19&lt;/Mb&gt;
    &lt;Fen&gt;6B1/1k1r3R/3B1b2/5p2/PK6/5bP1/7P/8 b - - 4 52&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;104&lt;/Id&gt;
    &lt;Pid&gt;103&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;52&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;b7&lt;/F&gt;
    &lt;T&gt;c6&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;26&lt;/Mw&gt;
    &lt;Mb&gt;20&lt;/Mb&gt;
    &lt;Fen&gt;6B1/3r3R/2kB1b2/5p2/PK6/5bP1/7P/8 w - - 5 53&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;105&lt;/Id&gt;
    &lt;Pid&gt;104&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;53&lt;/No&gt;
    &lt;P&gt;R&lt;/P&gt;
    &lt;F&gt;h7&lt;/F&gt;
    &lt;T&gt;d7&lt;/T&gt;
    &lt;Mf&gt;NxQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;26&lt;/Mw&gt;
    &lt;Mb&gt;20&lt;/Mb&gt;
    &lt;Cp&gt;R&lt;/Cp&gt;
    &lt;Fen&gt;6B1/3R4/2kB1b2/5p2/PK6/5bP1/7P/8 b - - 0 53&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;106&lt;/Id&gt;
    &lt;Pid&gt;105&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;53&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;c6&lt;/F&gt;
    &lt;T&gt;d7&lt;/T&gt;
    &lt;Mf&gt;NxQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;26&lt;/Mw&gt;
    &lt;Mb&gt;21&lt;/Mb&gt;
    &lt;Cp&gt;R&lt;/Cp&gt;
    &lt;Fen&gt;6B1/3k4/3B1b2/5p2/PK6/5bP1/7P/8 w - - 0 54&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;107&lt;/Id&gt;
    &lt;Pid&gt;106&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;54&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;b4&lt;/F&gt;
    &lt;T&gt;c5&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;26&lt;/Mw&gt;
    &lt;Mb&gt;21&lt;/Mb&gt;
    &lt;Fen&gt;6B1/3k4/3B1b2/2K2p2/P7/5bP1/7P/8 b - - 1 54&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;108&lt;/Id&gt;
    &lt;Pid&gt;107&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;54&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;f6&lt;/F&gt;
    &lt;T&gt;g5&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;26&lt;/Mw&gt;
    &lt;Mb&gt;22&lt;/Mb&gt;
    &lt;Fen&gt;6B1/3k4/3B4/2K2pb1/P7/5bP1/7P/8 w - - 2 55&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;109&lt;/Id&gt;
    &lt;Pid&gt;108&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;55&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;d6&lt;/F&gt;
    &lt;T&gt;e5&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;27&lt;/Mw&gt;
    &lt;Mb&gt;22&lt;/Mb&gt;
    &lt;Fen&gt;6B1/3k4/8/2K1Bpb1/P7/5bP1/7P/8 b - - 3 55&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;110&lt;/Id&gt;
    &lt;Pid&gt;109&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;55&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;g5&lt;/F&gt;
    &lt;T&gt;e7&lt;/T&gt;
    &lt;Mf&gt;N+Q&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;27&lt;/Mw&gt;
    &lt;Mb&gt;22&lt;/Mb&gt;
    &lt;Fen&gt;6B1/3kb3/8/2K1Bp2/P7/5bP1/7P/8 w - - 4 56&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;111&lt;/Id&gt;
    &lt;Pid&gt;110&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;56&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;c5&lt;/F&gt;
    &lt;T&gt;c4&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;28&lt;/Mw&gt;
    &lt;Mb&gt;22&lt;/Mb&gt;
    &lt;Fen&gt;6B1/3kb3/8/4Bp2/P1K5/5bP1/7P/8 b - - 5 56&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;112&lt;/Id&gt;
    &lt;Pid&gt;111&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;56&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;d7&lt;/F&gt;
    &lt;T&gt;c6&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;28&lt;/Mw&gt;
    &lt;Mb&gt;23&lt;/Mb&gt;
    &lt;Fen&gt;6B1/4b3/2k5/4Bp2/P1K5/5bP1/7P/8 w - - 6 57&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;113&lt;/Id&gt;
    &lt;Pid&gt;112&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;57&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;g8&lt;/F&gt;
    &lt;T&gt;e6&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;28&lt;/Mw&gt;
    &lt;Mb&gt;23&lt;/Mb&gt;
    &lt;Fen&gt;8/4b3/2k1B3/4Bp2/P1K5/5bP1/7P/8 b - - 7 57&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;114&lt;/Id&gt;
    &lt;Pid&gt;113&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;57&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;f3&lt;/F&gt;
    &lt;T&gt;d1&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;28&lt;/Mw&gt;
    &lt;Mb&gt;24&lt;/Mb&gt;
    &lt;Fen&gt;8/4b3/2k1B3/4Bp2/P1K5/6P1/7P/3b4 w - - 8 58&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;115&lt;/Id&gt;
    &lt;Pid&gt;114&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;58&lt;/No&gt;
    &lt;P /&gt;
    &lt;F&gt;a4&lt;/F&gt;
    &lt;T&gt;a5&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;28&lt;/Mw&gt;
    &lt;Mb&gt;24&lt;/Mb&gt;
    &lt;Fen&gt;8/4b3/2k1B3/P3Bp2/2K5/6P1/7P/3b4 b - - 0 58&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;116&lt;/Id&gt;
    &lt;Pid&gt;115&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;58&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;d1&lt;/F&gt;
    &lt;T&gt;e2&lt;/T&gt;
    &lt;Mf&gt;N+Q&lt;/Mf&gt;
    &lt;Mt&gt;2&lt;/Mt&gt;
    &lt;Mw&gt;28&lt;/Mw&gt;
    &lt;Mb&gt;26&lt;/Mb&gt;
    &lt;Fen&gt;8/4b3/2k1B3/P3Bp2/2K5/6P1/4b2P/8 w - - 1 59&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;117&lt;/Id&gt;
    &lt;Pid&gt;116&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;59&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;c4&lt;/F&gt;
    &lt;T&gt;b3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;28&lt;/Mw&gt;
    &lt;Mb&gt;26&lt;/Mb&gt;
    &lt;Fen&gt;8/4b3/2k1B3/P3Bp2/8/1K4P1/4b2P/8 b - - 2 59&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;118&lt;/Id&gt;
    &lt;Pid&gt;117&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;59&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;e7&lt;/F&gt;
    &lt;T&gt;d8&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;28&lt;/Mw&gt;
    &lt;Mb&gt;27&lt;/Mb&gt;
    &lt;Fen&gt;3b4/8/2k1B3/P3Bp2/8/1K4P1/4b2P/8 w - - 3 60&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;119&lt;/Id&gt;
    &lt;Pid&gt;118&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;60&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;e5&lt;/F&gt;
    &lt;T&gt;c3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;29&lt;/Mw&gt;
    &lt;Mb&gt;27&lt;/Mb&gt;
    &lt;Fen&gt;3b4/8/2k1B3/P4p2/8/1KB3P1/4b2P/8 b - - 4 60&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;120&lt;/Id&gt;
    &lt;Pid&gt;119&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;60&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;e2&lt;/F&gt;
    &lt;T&gt;d1&lt;/T&gt;
    &lt;Mf&gt;N+Q&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;29&lt;/Mw&gt;
    &lt;Mb&gt;27&lt;/Mb&gt;
    &lt;Fen&gt;3b4/8/2k1B3/P4p2/8/1KB3P1/7P/3b4 w - - 5 61&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;121&lt;/Id&gt;
    &lt;Pid&gt;120&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;61&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;b3&lt;/F&gt;
    &lt;T&gt;b2&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;30&lt;/Mw&gt;
    &lt;Mb&gt;27&lt;/Mb&gt;
    &lt;Fen&gt;3b4/8/2k1B3/P4p2/8/2B3P1/1K5P/3b4 b - - 6 61&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;122&lt;/Id&gt;
    &lt;Pid&gt;121&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;61&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;d1&lt;/F&gt;
    &lt;T&gt;g4&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;30&lt;/Mw&gt;
    &lt;Mb&gt;28&lt;/Mb&gt;
    &lt;Fen&gt;3b4/8/2k1B3/P4p2/6b1/2B3P1/1K5P/8 w - - 7 62&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;123&lt;/Id&gt;
    &lt;Pid&gt;122&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;62&lt;/No&gt;
    &lt;P /&gt;
    &lt;F&gt;a5&lt;/F&gt;
    &lt;T&gt;a6&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;30&lt;/Mw&gt;
    &lt;Mb&gt;28&lt;/Mb&gt;
    &lt;Fen&gt;3b4/8/P1k1B3/5p2/6b1/2B3P1/1K5P/8 b - - 0 62&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;124&lt;/Id&gt;
    &lt;Pid&gt;123&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;62&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;d8&lt;/F&gt;
    &lt;T&gt;b6&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;30&lt;/Mw&gt;
    &lt;Mb&gt;29&lt;/Mb&gt;
    &lt;Fen&gt;8/8/Pbk1B3/5p2/6b1/2B3P1/1K5P/8 w - - 1 63&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;125&lt;/Id&gt;
    &lt;Pid&gt;124&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;63&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;e6&lt;/F&gt;
    &lt;T&gt;c4&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;30&lt;/Mw&gt;
    &lt;Mb&gt;29&lt;/Mb&gt;
    &lt;Fen&gt;8/8/Pbk5/5p2/2B3b1/2B3P1/1K5P/8 b - - 2 63&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;126&lt;/Id&gt;
    &lt;Pid&gt;125&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;63&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;g4&lt;/F&gt;
    &lt;T&gt;h3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;30&lt;/Mw&gt;
    &lt;Mb&gt;30&lt;/Mb&gt;
    &lt;Fen&gt;8/8/Pbk5/5p2/2B5/2B3Pb/1K5P/8 w - - 3 64&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;127&lt;/Id&gt;
    &lt;Pid&gt;126&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;64&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;b2&lt;/F&gt;
    &lt;T&gt;b3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;31&lt;/Mw&gt;
    &lt;Mb&gt;30&lt;/Mb&gt;
    &lt;Fen&gt;8/8/Pbk5/5p2/2B5/1KB3Pb/7P/8 b - - 4 64&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;128&lt;/Id&gt;
    &lt;Pid&gt;127&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;64&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;b6&lt;/F&gt;
    &lt;T&gt;g1&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;31&lt;/Mw&gt;
    &lt;Mb&gt;31&lt;/Mb&gt;
    &lt;Fen&gt;8/8/P1k5/5p2/2B5/1KB3Pb/7P/6b1 w - - 5 65&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;129&lt;/Id&gt;
    &lt;Pid&gt;128&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;65&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;c3&lt;/F&gt;
    &lt;T&gt;a5&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;31&lt;/Mw&gt;
    &lt;Mb&gt;31&lt;/Mb&gt;
    &lt;Fen&gt;8/8/P1k5/B4p2/2B5/1K4Pb/7P/6b1 b - - 6 65&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;130&lt;/Id&gt;
    &lt;Pid&gt;129&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;65&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;h3&lt;/F&gt;
    &lt;T&gt;g4&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;31&lt;/Mw&gt;
    &lt;Mb&gt;32&lt;/Mb&gt;
    &lt;Fen&gt;8/8/P1k5/B4p2/2B3b1/1K4P1/7P/6b1 w - - 7 66&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;131&lt;/Id&gt;
    &lt;Pid&gt;130&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;66&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;a5&lt;/F&gt;
    &lt;T&gt;d8&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;32&lt;/Mw&gt;
    &lt;Mb&gt;32&lt;/Mb&gt;
    &lt;Fen&gt;3B4/8/P1k5/5p2/2B3b1/1K4P1/7P/6b1 b - - 8 66&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;132&lt;/Id&gt;
    &lt;Pid&gt;131&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;66&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;c6&lt;/F&gt;
    &lt;T&gt;d7&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;32&lt;/Mw&gt;
    &lt;Mb&gt;32&lt;/Mb&gt;
    &lt;Fen&gt;3B4/3k4/P7/5p2/2B3b1/1K4P1/7P/6b1 w - - 9 67&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;133&lt;/Id&gt;
    &lt;Pid&gt;132&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;67&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;d8&lt;/F&gt;
    &lt;T&gt;f6&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;33&lt;/Mw&gt;
    &lt;Mb&gt;32&lt;/Mb&gt;
    &lt;Fen&gt;8/3k4/P4B2/5p2/2B3b1/1K4P1/7P/6b1 b - - 10 67&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;134&lt;/Id&gt;
    &lt;Pid&gt;133&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;67&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;g1&lt;/F&gt;
    &lt;T&gt;h2&lt;/T&gt;
    &lt;Mf&gt;NxQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;33&lt;/Mw&gt;
    &lt;Mb&gt;33&lt;/Mb&gt;
    &lt;Cp /&gt;
    &lt;Fen&gt;8/3k4/P4B2/5p2/2B3b1/1K4P1/7b/8 w - - 0 68&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;135&lt;/Id&gt;
    &lt;Pid&gt;134&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;68&lt;/No&gt;
    &lt;P /&gt;
    &lt;F&gt;a6&lt;/F&gt;
    &lt;T&gt;a7&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;34&lt;/Mw&gt;
    &lt;Mb&gt;33&lt;/Mb&gt;
    &lt;Fen&gt;8/P2k4/5B2/5p2/2B3b1/1K4P1/7b/8 b - - 0 68&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;136&lt;/Id&gt;
    &lt;Pid&gt;135&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;68&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;g4&lt;/F&gt;
    &lt;T&gt;f3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;34&lt;/Mw&gt;
    &lt;Mb&gt;34&lt;/Mb&gt;
    &lt;Fen&gt;8/P2k4/5B2/5p2/2B5/1K3bP1/7b/8 w - - 1 69&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;137&lt;/Id&gt;
    &lt;Pid&gt;136&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;69&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;f6&lt;/F&gt;
    &lt;T&gt;e5&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;35&lt;/Mw&gt;
    &lt;Mb&gt;34&lt;/Mb&gt;
    &lt;Fen&gt;8/P2k4/8/4Bp2/2B5/1K3bP1/7b/8 b - - 2 69&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;138&lt;/Id&gt;
    &lt;Pid&gt;137&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;69&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;h2&lt;/F&gt;
    &lt;T&gt;g1&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;35&lt;/Mw&gt;
    &lt;Mb&gt;34&lt;/Mb&gt;
    &lt;Fen&gt;8/P2k4/8/4Bp2/2B5/1K3bP1/8/6b1 w - - 3 70&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;139&lt;/Id&gt;
    &lt;Pid&gt;138&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;70&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;e5&lt;/F&gt;
    &lt;T&gt;b8&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;2&lt;/Mt&gt;
    &lt;Mw&gt;37&lt;/Mw&gt;
    &lt;Mb&gt;34&lt;/Mb&gt;
    &lt;Fen&gt;1B6/P2k4/8/5p2/2B5/1K3bP1/8/6b1 b - - 4 70&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;140&lt;/Id&gt;
    &lt;Pid&gt;139&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;70&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;d7&lt;/F&gt;
    &lt;T&gt;c8&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;37&lt;/Mw&gt;
    &lt;Mb&gt;34&lt;/Mb&gt;
    &lt;Fen&gt;1Bk5/P7/8/5p2/2B5/1K3bP1/8/6b1 w - - 5 71&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;141&lt;/Id&gt;
    &lt;Pid&gt;140&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;71&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;c4&lt;/F&gt;
    &lt;T&gt;a6&lt;/T&gt;
    &lt;Mf&gt;N+Q&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;38&lt;/Mw&gt;
    &lt;Mb&gt;34&lt;/Mb&gt;
    &lt;Fen&gt;1Bk5/P7/B7/5p2/8/1K3bP1/8/6b1 b - - 6 71&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;142&lt;/Id&gt;
    &lt;Pid&gt;141&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;71&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;c8&lt;/F&gt;
    &lt;T&gt;d8&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;38&lt;/Mw&gt;
    &lt;Mb&gt;35&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/B7/5p2/8/1K3bP1/8/6b1 w - - 7 72&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;143&lt;/Id&gt;
    &lt;Pid&gt;142&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;72&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;b3&lt;/F&gt;
    &lt;T&gt;b4&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;39&lt;/Mw&gt;
    &lt;Mb&gt;35&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/B7/5p2/1K6/5bP1/8/6b1 b - - 8 72&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;144&lt;/Id&gt;
    &lt;Pid&gt;143&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;72&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;g1&lt;/F&gt;
    &lt;T&gt;e3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;39&lt;/Mw&gt;
    &lt;Mb&gt;35&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/B7/5p2/1K6/4bbP1/8/8 w - - 9 73&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;145&lt;/Id&gt;
    &lt;Pid&gt;144&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;73&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;b4&lt;/F&gt;
    &lt;T&gt;a5&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;40&lt;/Mw&gt;
    &lt;Mb&gt;35&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/B7/K4p2/8/4bbP1/8/8 b - - 10 73&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;146&lt;/Id&gt;
    &lt;Pid&gt;145&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;73&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;f3&lt;/F&gt;
    &lt;T&gt;d5&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;2&lt;/Mt&gt;
    &lt;Mw&gt;40&lt;/Mw&gt;
    &lt;Mb&gt;37&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/B7/K2b1p2/8/4b1P1/8/8 w - - 11 74&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;147&lt;/Id&gt;
    &lt;Pid&gt;146&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;74&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;a5&lt;/F&gt;
    &lt;T&gt;b5&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;41&lt;/Mw&gt;
    &lt;Mb&gt;37&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/B7/1K1b1p2/8/4b1P1/8/8 b - - 12 74&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;148&lt;/Id&gt;
    &lt;Pid&gt;147&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;74&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;d5&lt;/F&gt;
    &lt;T&gt;g2&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;41&lt;/Mw&gt;
    &lt;Mb&gt;38&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/B7/1K3p2/8/4b1P1/6b1/8 w - - 13 75&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;149&lt;/Id&gt;
    &lt;Pid&gt;148&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;75&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;b5&lt;/F&gt;
    &lt;T&gt;a4&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;42&lt;/Mw&gt;
    &lt;Mb&gt;38&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/B7/5p2/K7/4b1P1/6b1/8 b - - 14 75&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;150&lt;/Id&gt;
    &lt;Pid&gt;149&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;75&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;g2&lt;/F&gt;
    &lt;T&gt;d5&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;42&lt;/Mw&gt;
    &lt;Mb&gt;38&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/B7/3b1p2/K7/4b1P1/8/8 w - - 15 76&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;151&lt;/Id&gt;
    &lt;Pid&gt;150&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;76&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;a4&lt;/F&gt;
    &lt;T&gt;a3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;43&lt;/Mw&gt;
    &lt;Mb&gt;38&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/B7/3b1p2/8/K3b1P1/8/8 b - - 16 76&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;152&lt;/Id&gt;
    &lt;Pid&gt;151&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;76&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;e3&lt;/F&gt;
    &lt;T&gt;c5&lt;/T&gt;
    &lt;Mf&gt;N+Q&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;43&lt;/Mw&gt;
    &lt;Mb&gt;39&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/B7/2bb1p2/8/K5P1/8/8 w - - 17 77&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;153&lt;/Id&gt;
    &lt;Pid&gt;152&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;77&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;a3&lt;/F&gt;
    &lt;T&gt;b2&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;44&lt;/Mw&gt;
    &lt;Mb&gt;39&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/B7/2bb1p2/8/6P1/1K6/8 b - - 18 77&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;154&lt;/Id&gt;
    &lt;Pid&gt;153&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;77&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;d5&lt;/F&gt;
    &lt;T&gt;f3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;44&lt;/Mw&gt;
    &lt;Mb&gt;40&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/B7/2b2p2/8/5bP1/1K6/8 w - - 19 78&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;155&lt;/Id&gt;
    &lt;Pid&gt;154&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;78&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;b2&lt;/F&gt;
    &lt;T&gt;c2&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;45&lt;/Mw&gt;
    &lt;Mb&gt;40&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/B7/2b2p2/8/5bP1/2K5/8 b - - 20 78&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;156&lt;/Id&gt;
    &lt;Pid&gt;155&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;78&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;c5&lt;/F&gt;
    &lt;T&gt;e3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;45&lt;/Mw&gt;
    &lt;Mb&gt;41&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/B7/5p2/8/4bbP1/2K5/8 w - - 21 79&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;157&lt;/Id&gt;
    &lt;Pid&gt;156&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;79&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;c2&lt;/F&gt;
    &lt;T&gt;d3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;46&lt;/Mw&gt;
    &lt;Mb&gt;41&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/B7/5p2/8/3KbbP1/8/8 b - - 22 79&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;158&lt;/Id&gt;
    &lt;Pid&gt;157&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;79&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;e3&lt;/F&gt;
    &lt;T&gt;b6&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;46&lt;/Mw&gt;
    &lt;Mb&gt;42&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/Bb6/5p2/8/3K1bP1/8/8 w - - 23 80&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;159&lt;/Id&gt;
    &lt;Pid&gt;158&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;80&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;d3&lt;/F&gt;
    &lt;T&gt;c3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;47&lt;/Mw&gt;
    &lt;Mb&gt;42&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/Bb6/5p2/8/2K2bP1/8/8 b - - 24 80&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;160&lt;/Id&gt;
    &lt;Pid&gt;159&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;80&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;b6&lt;/F&gt;
    &lt;T&gt;f2&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;0&lt;/Mt&gt;
    &lt;Mw&gt;47&lt;/Mw&gt;
    &lt;Mb&gt;42&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/B7/5p2/8/2K2bP1/5b2/8 w - - 25 81&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;161&lt;/Id&gt;
    &lt;Pid&gt;160&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;81&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;c3&lt;/F&gt;
    &lt;T&gt;d2&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;48&lt;/Mw&gt;
    &lt;Mb&gt;42&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/B7/5p2/8/5bP1/3K1b2/8 b - - 26 81&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;162&lt;/Id&gt;
    &lt;Pid&gt;161&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;81&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;f3&lt;/F&gt;
    &lt;T&gt;g2&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;48&lt;/Mw&gt;
    &lt;Mb&gt;43&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/B7/5p2/8/6P1/3K1bb1/8 w - - 27 82&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;163&lt;/Id&gt;
    &lt;Pid&gt;162&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;82&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;d2&lt;/F&gt;
    &lt;T&gt;c2&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;49&lt;/Mw&gt;
    &lt;Mb&gt;43&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/B7/5p2/8/6P1/2K2bb1/8 b - - 28 82&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;164&lt;/Id&gt;
    &lt;Pid&gt;163&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;82&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;g2&lt;/F&gt;
    &lt;T&gt;d5&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;2&lt;/Mt&gt;
    &lt;Mw&gt;49&lt;/Mw&gt;
    &lt;Mb&gt;45&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/B7/3b1p2/8/6P1/2K2b2/8 w - - 29 83&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;165&lt;/Id&gt;
    &lt;Pid&gt;164&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;83&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;c2&lt;/F&gt;
    &lt;T&gt;b1&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;50&lt;/Mw&gt;
    &lt;Mb&gt;45&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/B7/3b1p2/8/6P1/5b2/1K6 b - - 30 83&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;166&lt;/Id&gt;
    &lt;Pid&gt;165&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;83&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;d5&lt;/F&gt;
    &lt;T&gt;f3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;50&lt;/Mw&gt;
    &lt;Mb&gt;46&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/B7/5p2/8/5bP1/5b2/1K6 w - - 31 84&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;167&lt;/Id&gt;
    &lt;Pid&gt;166&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;84&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;b1&lt;/F&gt;
    &lt;T&gt;a2&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;51&lt;/Mw&gt;
    &lt;Mb&gt;46&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/B7/5p2/8/5bP1/K4b2/8 b - - 32 84&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;168&lt;/Id&gt;
    &lt;Pid&gt;167&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;84&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;f2&lt;/F&gt;
    &lt;T&gt;e3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;51&lt;/Mw&gt;
    &lt;Mb&gt;47&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/B7/5p2/8/4bbP1/K7/8 w - - 33 85&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;169&lt;/Id&gt;
    &lt;Pid&gt;168&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;85&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;a2&lt;/F&gt;
    &lt;T&gt;a3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;52&lt;/Mw&gt;
    &lt;Mb&gt;47&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/B7/5p2/8/K3bbP1/8/8 b - - 34 85&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;170&lt;/Id&gt;
    &lt;Pid&gt;169&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;85&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;e3&lt;/F&gt;
    &lt;T&gt;c5&lt;/T&gt;
    &lt;Mf&gt;N+Q&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;52&lt;/Mw&gt;
    &lt;Mb&gt;48&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/B7/2b2p2/8/K4bP1/8/8 w - - 35 86&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;171&lt;/Id&gt;
    &lt;Pid&gt;170&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;86&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;a3&lt;/F&gt;
    &lt;T&gt;a4&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;53&lt;/Mw&gt;
    &lt;Mb&gt;48&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/B7/2b2p2/K7/5bP1/8/8 b - - 36 86&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;172&lt;/Id&gt;
    &lt;Pid&gt;171&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;86&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;f3&lt;/F&gt;
    &lt;T&gt;d5&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;53&lt;/Mw&gt;
    &lt;Mb&gt;49&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/B7/2bb1p2/K7/6P1/8/8 w - - 37 87&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;173&lt;/Id&gt;
    &lt;Pid&gt;172&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;87&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;a6&lt;/F&gt;
    &lt;T&gt;d3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;2&lt;/Mt&gt;
    &lt;Mw&gt;55&lt;/Mw&gt;
    &lt;Mb&gt;49&lt;/Mb&gt;
    &lt;Fen&gt;1B1k4/P7/8/2bb1p2/K7/3B2P1/8/8 b - - 38 87&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;174&lt;/Id&gt;
    &lt;Pid&gt;173&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;87&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;d8&lt;/F&gt;
    &lt;T&gt;c8&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;55&lt;/Mw&gt;
    &lt;Mb&gt;50&lt;/Mb&gt;
    &lt;Fen&gt;1Bk5/P7/8/2bb1p2/K7/3B2P1/8/8 w - - 39 88&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;175&lt;/Id&gt;
    &lt;Pid&gt;174&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;88&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;a4&lt;/F&gt;
    &lt;T&gt;b5&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;56&lt;/Mw&gt;
    &lt;Mb&gt;50&lt;/Mb&gt;
    &lt;Fen&gt;1Bk5/P7/8/1Kbb1p2/8/3B2P1/8/8 b - - 40 88&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;176&lt;/Id&gt;
    &lt;Pid&gt;175&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;88&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;c5&lt;/F&gt;
    &lt;T&gt;e3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;56&lt;/Mw&gt;
    &lt;Mb&gt;51&lt;/Mb&gt;
    &lt;Fen&gt;1Bk5/P7/8/1K1b1p2/8/3Bb1P1/8/8 w - - 41 89&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;177&lt;/Id&gt;
    &lt;Pid&gt;176&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;89&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;d3&lt;/F&gt;
    &lt;T&gt;f5&lt;/T&gt;
    &lt;Mf&gt;Nx+Q&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;57&lt;/Mw&gt;
    &lt;Mb&gt;51&lt;/Mb&gt;
    &lt;Cp /&gt;
    &lt;Fen&gt;1Bk5/P7/8/1K1b1B2/8/4b1P1/8/8 b - - 0 89&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;178&lt;/Id&gt;
    &lt;Pid&gt;177&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;89&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;c8&lt;/F&gt;
    &lt;T&gt;b7&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;57&lt;/Mw&gt;
    &lt;Mb&gt;52&lt;/Mb&gt;
    &lt;Fen&gt;1B6/Pk6/8/1K1b1B2/8/4b1P1/8/8 w - - 1 90&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;179&lt;/Id&gt;
    &lt;Pid&gt;178&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;90&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;f5&lt;/F&gt;
    &lt;T&gt;c2&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;58&lt;/Mw&gt;
    &lt;Mb&gt;52&lt;/Mb&gt;
    &lt;Fen&gt;1B6/Pk6/8/1K1b4/8/4b1P1/2B5/8 b - - 2 90&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;180&lt;/Id&gt;
    &lt;Pid&gt;179&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;90&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;d5&lt;/F&gt;
    &lt;T&gt;c6&lt;/T&gt;
    &lt;Mf&gt;N+Q&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;58&lt;/Mw&gt;
    &lt;Mb&gt;53&lt;/Mb&gt;
    &lt;Fen&gt;1B6/Pk6/2b5/1K6/8/4b1P1/2B5/8 w - - 3 91&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;181&lt;/Id&gt;
    &lt;Pid&gt;180&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;91&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;b5&lt;/F&gt;
    &lt;T&gt;c4&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;59&lt;/Mw&gt;
    &lt;Mb&gt;53&lt;/Mb&gt;
    &lt;Fen&gt;1B6/Pk6/2b5/8/2K5/4b1P1/2B5/8 b - - 4 91&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;182&lt;/Id&gt;
    &lt;Pid&gt;181&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;91&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;c6&lt;/F&gt;
    &lt;T&gt;f3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;59&lt;/Mw&gt;
    &lt;Mb&gt;54&lt;/Mb&gt;
    &lt;Fen&gt;1B6/Pk6/8/8/2K5/4bbP1/2B5/8 w - - 5 92&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;183&lt;/Id&gt;
    &lt;Pid&gt;182&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;92&lt;/No&gt;
    &lt;P /&gt;
    &lt;F&gt;g3&lt;/F&gt;
    &lt;T&gt;g4&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;60&lt;/Mw&gt;
    &lt;Mb&gt;54&lt;/Mb&gt;
    &lt;Fen&gt;1B6/Pk6/8/8/2K3P1/4bb2/2B5/8 b - - 0 92&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;184&lt;/Id&gt;
    &lt;Pid&gt;183&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;92&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;e3&lt;/F&gt;
    &lt;T&gt;a7&lt;/T&gt;
    &lt;Mf&gt;NxQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;60&lt;/Mw&gt;
    &lt;Mb&gt;55&lt;/Mb&gt;
    &lt;Cp /&gt;
    &lt;Fen&gt;1B6/bk6/8/8/2K3P1/5b2/2B5/8 w - - 0 93&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;185&lt;/Id&gt;
    &lt;Pid&gt;184&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;93&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;b8&lt;/F&gt;
    &lt;T&gt;a7&lt;/T&gt;
    &lt;Mf&gt;NxQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;61&lt;/Mw&gt;
    &lt;Mb&gt;55&lt;/Mb&gt;
    &lt;Cp&gt;B&lt;/Cp&gt;
    &lt;Fen&gt;8/Bk6/8/8/2K3P1/5b2/2B5/8 b - - 0 93&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;186&lt;/Id&gt;
    &lt;Pid&gt;185&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;93&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;f3&lt;/F&gt;
    &lt;T&gt;g4&lt;/T&gt;
    &lt;Mf&gt;NxQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;61&lt;/Mw&gt;
    &lt;Mb&gt;56&lt;/Mb&gt;
    &lt;Cp /&gt;
    &lt;Fen&gt;8/Bk6/8/8/2K3b1/8/2B5/8 w - - 0 94&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;187&lt;/Id&gt;
    &lt;Pid&gt;186&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;94&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;a7&lt;/F&gt;
    &lt;T&gt;d4&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;62&lt;/Mw&gt;
    &lt;Mb&gt;56&lt;/Mb&gt;
    &lt;Fen&gt;8/1k6/8/8/2KB2b1/8/2B5/8 b - - 1 94&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;188&lt;/Id&gt;
    &lt;Pid&gt;187&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;94&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;g4&lt;/F&gt;
    &lt;T&gt;f3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;2&lt;/Mt&gt;
    &lt;Mw&gt;62&lt;/Mw&gt;
    &lt;Mb&gt;58&lt;/Mb&gt;
    &lt;Fen&gt;8/1k6/8/8/2KB4/5b2/2B5/8 w - - 2 95&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;189&lt;/Id&gt;
    &lt;Pid&gt;188&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;95&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;c4&lt;/F&gt;
    &lt;T&gt;b4&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;63&lt;/Mw&gt;
    &lt;Mb&gt;58&lt;/Mb&gt;
    &lt;Fen&gt;8/1k6/8/8/1K1B4/5b2/2B5/8 b - - 3 95&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;190&lt;/Id&gt;
    &lt;Pid&gt;189&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;95&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;f3&lt;/F&gt;
    &lt;T&gt;d5&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;63&lt;/Mw&gt;
    &lt;Mb&gt;59&lt;/Mb&gt;
    &lt;Fen&gt;8/1k6/8/3b4/1K1B4/8/2B5/8 w - - 4 96&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;191&lt;/Id&gt;
    &lt;Pid&gt;190&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;96&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;c2&lt;/F&gt;
    &lt;T&gt;b1&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;64&lt;/Mw&gt;
    &lt;Mb&gt;59&lt;/Mb&gt;
    &lt;Fen&gt;8/1k6/8/3b4/1K1B4/8/8/1B6 b - - 5 96&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;192&lt;/Id&gt;
    &lt;Pid&gt;191&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;96&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;d5&lt;/F&gt;
    &lt;T&gt;f3&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;64&lt;/Mw&gt;
    &lt;Mb&gt;60&lt;/Mb&gt;
    &lt;Fen&gt;8/1k6/8/8/1K1B4/5b2/8/1B6 w - - 6 97&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;193&lt;/Id&gt;
    &lt;Pid&gt;192&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;97&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;b1&lt;/F&gt;
    &lt;T&gt;f5&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;65&lt;/Mw&gt;
    &lt;Mb&gt;60&lt;/Mb&gt;
    &lt;Fen&gt;8/1k6/8/5B2/1K1B4/5b2/8/8 b - - 7 97&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;194&lt;/Id&gt;
    &lt;Pid&gt;193&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;97&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;b7&lt;/F&gt;
    &lt;T&gt;c7&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;65&lt;/Mw&gt;
    &lt;Mb&gt;61&lt;/Mb&gt;
    &lt;Fen&gt;8/2k5/8/5B2/1K1B4/5b2/8/8 w - - 8 98&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;195&lt;/Id&gt;
    &lt;Pid&gt;194&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;98&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;d4&lt;/F&gt;
    &lt;T&gt;e5&lt;/T&gt;
    &lt;Mf&gt;N+Q&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;66&lt;/Mw&gt;
    &lt;Mb&gt;61&lt;/Mb&gt;
    &lt;Fen&gt;8/2k5/8/4BB2/1K6/5b2/8/8 b - - 9 98&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;196&lt;/Id&gt;
    &lt;Pid&gt;195&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;98&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;c7&lt;/F&gt;
    &lt;T&gt;d8&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;2&lt;/Mt&gt;
    &lt;Mw&gt;66&lt;/Mw&gt;
    &lt;Mb&gt;63&lt;/Mb&gt;
    &lt;Fen&gt;3k4/8/8/4BB2/1K6/5b2/8/8 w - - 10 99&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;197&lt;/Id&gt;
    &lt;Pid&gt;196&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;99&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;e5&lt;/F&gt;
    &lt;T&gt;f6&lt;/T&gt;
    &lt;Mf&gt;N+Q&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;67&lt;/Mw&gt;
    &lt;Mb&gt;63&lt;/Mb&gt;
    &lt;Fen&gt;3k4/8/5B2/5B2/1K6/5b2/8/8 b - - 11 99&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;198&lt;/Id&gt;
    &lt;Pid&gt;197&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;99&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;d8&lt;/F&gt;
    &lt;T&gt;e8&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;67&lt;/Mw&gt;
    &lt;Mb&gt;64&lt;/Mb&gt;
    &lt;Fen&gt;4k3/8/5B2/5B2/1K6/5b2/8/8 w - - 12 100&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;199&lt;/Id&gt;
    &lt;Pid&gt;198&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;100&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;f5&lt;/F&gt;
    &lt;T&gt;g6&lt;/T&gt;
    &lt;Mf&gt;N+Q&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;68&lt;/Mw&gt;
    &lt;Mb&gt;64&lt;/Mb&gt;
    &lt;Fen&gt;4k3/8/5BB1/8/1K6/5b2/8/8 b - - 13 100&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;200&lt;/Id&gt;
    &lt;Pid&gt;199&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;100&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;e8&lt;/F&gt;
    &lt;T&gt;d7&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;68&lt;/Mw&gt;
    &lt;Mb&gt;65&lt;/Mb&gt;
    &lt;Fen&gt;8/3k4/5BB1/8/1K6/5b2/8/8 w - - 14 101&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;201&lt;/Id&gt;
    &lt;Pid&gt;200&lt;/Pid&gt;
    &lt;W&gt;1&lt;/W&gt;
    &lt;No&gt;101&lt;/No&gt;
    &lt;P&gt;B&lt;/P&gt;
    &lt;F&gt;f6&lt;/F&gt;
    &lt;T&gt;h4&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;2&lt;/Mt&gt;
    &lt;Mw&gt;70&lt;/Mw&gt;
    &lt;Mb&gt;65&lt;/Mb&gt;
    &lt;Fen&gt;8/3k4/6B1/8/1K5B/5b2/8/8 b - - 15 101&lt;/Fen&gt;
  &lt;/M&gt;
  &lt;M&gt;
    &lt;Id&gt;202&lt;/Id&gt;
    &lt;Pid&gt;201&lt;/Pid&gt;
    &lt;W&gt;0&lt;/W&gt;
    &lt;No&gt;101&lt;/No&gt;
    &lt;P&gt;K&lt;/P&gt;
    &lt;F&gt;d7&lt;/F&gt;
    &lt;T&gt;c8&lt;/T&gt;
    &lt;Mf&gt;NQ&lt;/Mf&gt;
    &lt;Mt&gt;1&lt;/Mt&gt;
    &lt;Mw&gt;70&lt;/Mw&gt;
    &lt;Mb&gt;66&lt;/Mb&gt;
    &lt;Fen&gt;2k5/8/6B1/8/1K5B/5b2/8/8 w - - 16 102&lt;/Fen&gt;
  &lt;/M&gt;
&lt;/NewDataSet&gt;</v>
  </Kv>
  <Kv>
    <k>EcoDescription</k>
    <v />
  </Kv>
  <Kv>
    <k>InitialBoardFen</k>
    <v>rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1</v>
  </Kv>
  <Kv>
    <k>OptionsBlitzClock</k>
    <v>&lt;Kv xmlns=""http://tempuri.org/Kv.xsd""&gt;
  &lt;Kv&gt;
    &lt;k&gt;Time&lt;/k&gt;
    &lt;v&gt;1&lt;/v&gt;
  &lt;/Kv&gt;
  &lt;Kv&gt;
    &lt;k&gt;GainPerMove&lt;/k&gt;
    &lt;v&gt;0&lt;/v&gt;
  &lt;/Kv&gt;
  &lt;Kv&gt;
    &lt;k&gt;HumanBonus&lt;/k&gt;
    &lt;v&gt;0&lt;/v&gt;
  &lt;/Kv&gt;
  &lt;Kv&gt;
    &lt;k&gt;HumanBonusPerMove&lt;/k&gt;
    &lt;v&gt;0&lt;/v&gt;
  &lt;/Kv&gt;
&lt;/Kv&gt;</v>
  </Kv>
  <Kv>
    <k>GameMode</k>
    <v>2</v>
  </Kv>
  <Kv>
    <k>GameType</k>
    <v>2</v>
  </Kv>
  <Kv>
    <k>Flags</k>
    <v>enCYES</v>
  </Kv>
  <Kv>
    <k>GameResult</k>
    <v>2</v>
  </Kv>
</Kv> 
";
            return s;
        }

        public void LoadTempItems1(int noOfItems)
        {
            string s = "";
            for (int i = 0; i < noOfItems; i++)
            {
                s = GetTempItem();
                AppendGame(s);
            }
            
        }

        public void LoadTempItems(Game g, int noOfItems)
        {
            string s = "";
            for (int i = 0; i < noOfItems; i++)
            {
                s = GetTempItem();
                GameData gd = new GameData(g, s);
                s = g.GetGameXml(gd);
                AppendGame(s);
                gd = null;
                
            }
            
        }

        #endregion
    }  
   
}
