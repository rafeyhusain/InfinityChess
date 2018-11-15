using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using App.Model.Db;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace App.Model
{
    #region ApModuleE
    public enum ApModuleE
    {
        None,
        Offline,
        Online,
        Both
    } 
    #endregion

    #region HelpTopicIdE
    public enum HelpTopicIdE
    { 
        BlitzClockForm =   10,
        BookOptionsPopup  =   20,
        ConvertFilesPopup =  30,
        frmGameData =  40,
        frmTournamentData =  50,
        LongClockForm =  60,
        OptionsPopup =  70,
        DatabaseForm  =  80,
        EngineVsEngine  = 90,
        ImportGameEditor = 100,
        LoadEngine = 110,
        PositionSetup = 120,
        SetupUCIEngine = 130,
        Tournament = 140,
        UserInfo = 150,
        ChallangeWindow = 160,
        EnterMoveText = 170,
        ForgetPasswordForm = 180,
        PlayingMode = 190,
        RatedGameResult = 200,
        Seek = 210,
        UserData = 220,
        Formula = 230,
        LoginForm = 240,
        BoardDesign = 250,
        NewsDetail = 260,
        RoomDetail = 270,
        TeamDetail = 280
    }
   

    #endregion

    public partial class Ap
    {
        #region DataMembers
        public static Cxt Cxt = Cxt.Instance;        
        public static Database Database = null;
        public static Databases databases = null;
        public static ApCache apCache = null;
        public static int KibitzersCount = 0;
        public static bool CanAutoChallenge = true;

        public static int SelectedRoomID = 0;
        public static int SelectedRoomParentID = 0;
        public static int RoomTournamentID = 0;
        #endregion
        
        #region Properties

        #region CurrentUser
        
        public static Databases Databases
        {
            [DebuggerStepThrough]
            get 
            {
                if (databases == null)
                {
                    databases = new Databases();
                }

                return databases;
            }
            [DebuggerStepThrough]
            set { databases = value; }
        }

        public static ApCache ApCache
        {
            [DebuggerStepThrough]
            get 
            {
                if (apCache == null)
                {
                    apCache = new ApCache();
                }

                return apCache;
            }
            [DebuggerStepThrough]
            set { apCache = value; }
        }

        public static int CurrentUserID
        {
            [DebuggerStepThrough]
            get { return Cxt.CurrentUserID; }
            [DebuggerStepThrough]
            set { Cxt.CurrentUserID = value; }
        }

        public static User CurrentUser
        {
            [DebuggerStepThrough]
            get { return Cxt.CurrentUser; }
            [DebuggerStepThrough]
            set { Cxt.CurrentUser = value; }
        }

        #endregion

        #region Options

        public static Options Options
        {   
            get { return Options.Instance; }
        }

        public static EngineOptions EngineOptions
        {
            get { return EngineOptions.Instance; }
        }

        public static ParametersFiles ParametersFiles
        {
            get { return ParametersFiles.Instance; }
        }

        public static InfinitySettings.GameManager.UserProfile UserProfile
        {
            [DebuggerStepThrough]
            get { return InfinitySettings.GameManager.UserProfile.Instance; }
            [DebuggerStepThrough]
            set { InfinitySettings.GameManager.UserProfile.Instance = value; }

        }

        public static BoardTheme BoardTheme
        {
            [DebuggerStepThrough]
            get { return BoardTheme.Instance; }
        }
               
        public static OptionsBlitzClock OptionsBlitzClock
        {
            [DebuggerStepThrough]
            get { return OptionsBlitzClock.Instance; }
        }

        public static OptionsLongClock OptionsLongClock
        {
            [DebuggerStepThrough]
            get { return OptionsLongClock.Instance; }
        }

        public static KeyValues SysOptions
        {
            [DebuggerStepThrough]
            get { return KeyValues.Instance; }
        }

        public static MoveLog MoveLog
        {
            [DebuggerStepThrough]
            get { return MoveLog.Instance;}
        }

        public static MsgQueue MsgQueue
        {
            [DebuggerStepThrough]
            get { return MsgQueue.Instance; }
        }
        #endregion

        #region Game
        
        public static Game Game
        {
            [DebuggerStepThrough]
            get { return Game.Instance; }
            [DebuggerStepThrough]
            set { Game.Instance = value; }
        }

        public static bool IsGameInProgress
        {
            [DebuggerStepThrough]
            get { return Game != null; }
        }

        public static bool HasKibitzers
        {
            [DebuggerStepThrough]
            get { return KibitzersCount > 0; }
        }

        public static PlayingMode PlayingMode
        {
            [DebuggerStepThrough]
            get { return PlayingMode.Instance; }
        }

        #endregion

        #region New Game / Close Game

        public static void NewGame()
        {
            Game = new Game();
        }

        public static void FinishGame()
        {
            Game = null;
        }

        #endregion

        #region Reset
        public static void ResetFactorySettings()
        {
            Options.ResetFactorySettings();
            OptionsBlitzClock.ResetFactorySettings();
            OptionsLongClock.ResetFactorySettings();
            BoardTheme.ResetFactorySettings();
        }
        #endregion

        #region Eco

        public static Eco Eco
        {
            get { return Eco.Instance; }
        }

        #endregion

        #endregion

        #region Init

        public static void Init(ApModuleE module)
        {
            switch (module)
            {
                case ApModuleE.None:
                    break;
                case ApModuleE.Offline:
                    break;
                case ApModuleE.Online:
                    Ap.MsgQueue.Init();
                    Ap.ApCache.Init(module);
                    break;
                case ApModuleE.Both:
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                    Ap.Options.SetApplicationCode();
                    CheckUpdateManager();
                    break;
            }
        }

        public static void UnInit(ApModuleE module)
        {
            switch (module)
            {
                case ApModuleE.None:
                    break;
                case ApModuleE.Offline:
                    break;
                case ApModuleE.Online:
                    Ap.MsgQueue.UnInit();
                    Ap.ApCache.UnInit(module);
                    break;
                case ApModuleE.Both:
                    break;
            }
        }

        #endregion

        #region Url

        public static void OpenHomeUrl()
        {
            UProcess.Open("http://www.infichess.com");
        }

        public static void OpenRegistrationUrl()
        {
            UProcess.Open("http://infichess.com/Web/Page/Public/Viewer/RegisteredUser.aspx");
        }

        public static void OpenFolderData()
        {
            OpenFolder(Ap.FolderData);
        }

        public static void OpenFolder(string path)
        {
            if (Directory.Exists(path))
            {
                UProcess.Open(path);
            }
        }

        #endregion

        #region Move Data Folder 

        public static void MoveDataFolder()
        {
            if (!System.IO.Directory.Exists(Ap.FolderData))
            {
                UFile.CopyFolder(Ap.FolderBinData, Ap.FolderData);
            }
        }

        #endregion

        #region GetGameTypeTitle
        public static string GetGameTypeTitle(GameType gameType)
        {
            string gameTypeTitle = string.Empty;

            switch (gameType)
            {
                case GameType.None:
                    long gameMinutesNone = Options.Instance.PlayingTime;
                    long gameSecondsNone = gameMinutesNone % 60;

                    gameTypeTitle += "Infinity Chess " + gameMinutesNone + "'";

                    if (gameSecondsNone > 0)
                    {
                        gameTypeTitle += gameSecondsNone + "''";
                    }
                    break;

                case GameType.Bullet:
                    long gameMinutesBullet = Options.Instance.PlayingTime;
                    long gameSecondsBullet = gameMinutesBullet % 60;

                    gameTypeTitle += "Bullet " + gameMinutesBullet + "'";

                    if (gameSecondsBullet > 0)
                    {
                        gameTypeTitle += gameSecondsBullet + "''";
                    }
                    break;

                case GameType.Blitz:
                    long gameMinutesBlitz = Ap.OptionsBlitzClock.Time;
                    long gameSecondsBlitz = Ap.OptionsBlitzClock.GainPerMove;
                    gameTypeTitle += "Blitz " + gameMinutesBlitz + "'";
                    if (gameSecondsBlitz > 0)
                    {
                        gameTypeTitle += gameSecondsBlitz + "''";
                    }
                    break;

                case GameType.Long:
                    long gameMinutes1 = 0;
                    gameMinutes1 += Ap.OptionsLongClock.FirstControlHour * 60;
                    gameMinutes1 += Ap.OptionsLongClock.FirstControlMinute;
                    long gameMoves1 = Ap.OptionsLongClock.FirstControlMoves;
                    gameTypeTitle += gameMinutes1 + "'" + "/" + gameMoves1;
                    gameTypeTitle += "+";

                    long gameMinutes2 = 0;
                    gameMinutes2 += Ap.OptionsLongClock.SecondControlHour * 60;
                    gameMinutes2 += Ap.OptionsLongClock.SecondControlMinute;
                    long gameMoves2 = Ap.OptionsLongClock.SecondControlMoves;
                    gameTypeTitle += gameMinutes2 + "'" + "/" + gameMoves2;
                    gameTypeTitle += "+";

                    long gameMinutes3 = 0;
                    gameMinutes3 += Ap.OptionsLongClock.ThirdControlHour * 60;
                    gameMinutes3 += Ap.OptionsLongClock.ThirdControlMinute;
                    gameTypeTitle += gameMinutes3 + "'";
                    break;

                default:
                    break;
            }
            return gameTypeTitle;
        } 
        #endregion

        #region LoadLastGame
        public static bool LoadLastGame(Game game, GameType gameType)
        {
            if (!string.IsNullOrEmpty(Ap.Options.CurrentGameGuid) && UFile.Exists(Ap.Options.CurrentGameDatabaseFilePath))
            {
                if (game.LoadGame(Ap.Options.CurrentGameGuid))
                {
                    return true;
                }
            }

            game.ResetCurrentGame();
            //game.NewGame(GameMode.HumanVsEngine, GameType.Blitz);            
            game.NewGame(GameMode.HumanVsEngine, gameType);
            
            return true;
        }


        #endregion

        #region Help
        public static void Help(Form frm, HelpTopicIdE topicID)
        {
            try
            {
                System.Windows.Forms.Help.ShowHelp(frm, Ap.FileHelpChm, HelpNavigator.TopicId,topicID.ToString("d"));
            }
            catch (Exception ex)
            {
                Log.Write(Ap.Cxt, ex);
            }
        } 
        #endregion

        #region LoadDatabase
        public static bool LoadDatabase(string filePath)
        {
            try
            {
                if (Ap.Database != null)
                {
                    if (filePath == Ap.Database.FilePath)
                    {
                        return true;
                    }
                }

                Databases.Add(filePath);
                Ap.Database = new Database(filePath, Game);
                return true;
            }
            catch (Exception ex)
            {
                Log.Write(Ap.Cxt, ex);

                return false;
            }
        }
        #endregion


        #region GetUserRankImage
        public static Image GetUserRankImage(string imageName)
        {
            if (Ap.ApCache.RankImages.ContainsKey(imageName))
            {
                return Ap.ApCache.RankImages[imageName];
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region GetGameTypeImage
        public static Image GetGameTypeImage(string imageName)
        {
            if (Ap.ApCache.GameTypeImages.ContainsKey(imageName))
            {
                return Ap.ApCache.GameTypeImages[imageName];
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region UpdateManager 

        private static void CheckUpdateManager()
        {
            if (!Directory.Exists(Ap.FolderTempUpdater) || !Directory.Exists(Ap.FolderUpdaterBin))
            {
                return;
            }

            string[] elements = Directory.GetFileSystemEntries(Ap.FolderTempUpdater);

            foreach (string element in elements)
            {
                String filePath = Ap.FolderUpdaterBin + Path.GetFileName(element);
                if (File.Exists(filePath))
                {
                    UFile.RemoveReadOnly(filePath);
                    File.Delete(filePath);
                }
                File.Copy(element, filePath, true);
            }

            if (Directory.Exists(Ap.FolderTempBin))
            {
                Directory.Delete(Ap.FolderTempBin, true);
            }
        }

        #endregion

    }
}
