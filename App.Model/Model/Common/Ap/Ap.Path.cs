using System;
using System.Collections.Generic;

using System.Text;
using System.Diagnostics;

namespace App.Model
{
    public partial class Ap
    {
        #region Win

        #region AppFolder
        public static string FolderAppBin
        {
            [DebuggerStepThrough]
            get { return AppDomain.CurrentDomain.BaseDirectory; }
        }

        public static string FolderAppRoot
        {
            [DebuggerStepThrough]
            get
            {
                return System.IO.Path.GetFullPath(FolderAppBin + @".\..\..\");
            }
        }

        #endregion

        #region Folders
        public static string DesktopData
        {
            [DebuggerStepThrough]
            get { return Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); }
        }

        public static string FolderData
        {
            [DebuggerStepThrough]
            get { return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\InfinityChess\Data\"; }
        }

        public static string FolderDataBackup
        {
            [DebuggerStepThrough]
            get { return FolderData + @"Backup\"; }
        }

        public static string FolderUpdaterBin
        {
            [DebuggerStepThrough]
            get { return FolderAppBin + @"UpdateManager\"; }
        }

        public static string FolderBinData
        {
            [DebuggerStepThrough]
            get { return Environment.CurrentDirectory + @"\InfinityChess\Data"; }
        }

        public static string FolderDataKv
        {
            [DebuggerStepThrough]
            get { return FolderData + @"Kv\"; }
        }

        public static string FolderHelp
        {
            [DebuggerStepThrough]
            get { return FolderData + @"Help\"; }
        }

        public static string FolderThemes
        {
            [DebuggerStepThrough]
            get { return FolderData + @"Themes\"; }
        }

        public static string FolderImages
        {
            [DebuggerStepThrough]
            get { return FolderData + @"Images\"; }
        }

        public static string FolderFlags
        {
            [DebuggerStepThrough]
            get { return FolderImages + @"Flags\"; }
        }

        public static string FolderRanks
        {
            [DebuggerStepThrough]
            get { return FolderImages + @"Ranks\"; }
        }

        public static string FolderImagesBackground
        {
            [DebuggerStepThrough]
            get { return FolderImages + @"Background\"; }
        }

        public static string FolderRooms
        {
            [DebuggerStepThrough]
            get { return FolderImages + @"Rooms\"; }
        }

        public static string FolderDatabase
        {
            [DebuggerStepThrough]
            get { return FolderData + @"Database\"; }
        }

        public static string FolderBooks
        {
            [DebuggerStepThrough]
            get { return FolderData + @"Books\"; }
        }

        public static string FolderTablebases
        {
            [DebuggerStepThrough]
            get { return FolderData + @"Tablebases\"; }
        }

        public static string FolderEngines
        {
            [DebuggerStepThrough]
            get { return FolderData + @"Engines\"; }
        }

        public static string FolderEngineParameter
        {
            [DebuggerStepThrough]
            get { return FolderData + @"EngineParameter\"; }
        }

        public static string FolderMedia
        {
            [DebuggerStepThrough]
            get { return FolderData + @"Media\"; }
        }

        //public static string FolderSquaresImages
        //{
        //    [DebuggerStepThrough]
        //    get { return FolderImages + @"SquaresImages\"; }
        //}

        public static string FolderLightSquares
        {
            [DebuggerStepThrough]
            get { return FolderImages + @"LightSquares\"; }
        }

        public static string FolderDarkSquares
        {
            [DebuggerStepThrough]
            get { return FolderImages + @"DarkSquares\"; }
        }

        public static string FolderPiecesImages
        {
            [DebuggerStepThrough]
            get { return FolderImages + @"PiecesImages\Position Setup\"; }
        }

        public static string FolderPiecesImagesSmall
        {
            [DebuggerStepThrough]
            get { return FolderImages + @"PiecesImages\Position Setup Small\"; }
        }

        public static string FolderPatches
        {
            [DebuggerStepThrough]
            get { return FolderData + @"Patches\"; }
        }

        public static string FolderTemp
        {
            [DebuggerStepThrough]
            get { return System.IO.Path.GetTempPath() + @"\"; }
        }

        public static string FolderTempInfinityChess
        {
            [DebuggerStepThrough]
            get { return FolderTemp + @"TempInfinityChess\"; }
        }

        public static string FolderTempBin
        {
            [DebuggerStepThrough]
            get { return FolderTemp + @"InfinityChess\"; }
        }

        public static string FolderTempData
        {
            [DebuggerStepThrough]
            get { return FolderTemp + @"InfinityChess\Data\"; }
        }

        public static string FolderTempUpdater
        {
            [DebuggerStepThrough]
            get { return FolderTemp + @"InfinityChess\_UpdateManager"; }
        }

        public static string FolderAppforUpdater
        {
            [DebuggerStepThrough]
            get
            {
                return System.IO.Path.GetFullPath(FolderAppBin + @".\..\");
            }
        }

        #endregion

        #region Files

        public static string FileBoardTheme
        {
            [DebuggerStepThrough]
            get { return FolderDataKv + "BoardTheme.thm"; }
        }

        public static string FilePrintDiagram
        {
            [DebuggerStepThrough]
            get { return FolderDataKv + "PrintDiagram.png"; }
        }

        public static string FileWhiteBox
        {
            [DebuggerStepThrough]
            get { return FolderImages + "WhiteBox.png"; }
        }

        public static string FileBlackBox
        {
            [DebuggerStepThrough]
            get { return FolderImages + "BlackBox.png"; }
        }

        public static string FilePlayingModeDataXml
        {
            [DebuggerStepThrough]
            get { return FolderDataKv + "PlayingModeData.icx"; }
        }

        public static string FileOptionsXml
        {
            [DebuggerStepThrough]
            get { return FolderDataKv + "Options.icx"; }
        }

        public static string FileOptionsBlitzClockXml
        {
            [DebuggerStepThrough]
            get { return FolderDataKv + "OptionsBlitzClock.icx"; }
        }

        public static string FileOptionsLongClockXml
        {
            [DebuggerStepThrough]
            get { return FolderDataKv + "OptionsLongClock.icx"; }
        }

        public static string FileBookOptions
        {
            [DebuggerStepThrough]
            get { return FolderDataKv + "BookOptions.icx"; }
        }

        public static string FileGameDataXml
        {
            [DebuggerStepThrough]
            get { return FolderDataKv + "GameData.icx"; }
        }

        public static string FileEcoMoveXml
        {
            [DebuggerStepThrough]
            get { return FolderDataKv + "Eco.icx"; }
        }

        public static string FileSearchGameDataXml
        {
            [DebuggerStepThrough]
            get { return FolderDataKv + "SearchGameData.icx"; }
        }

        public static string FileParametersFilesXml
        {
            [DebuggerStepThrough]
            get { return FolderDataKv + "ParametersFiles.icx"; }
        }
        
        public static string FileOptionsSetups
        {
            [DebuggerStepThrough]
            get { return FolderDataKv + "OptionsSetups.icx"; }
        }

        public static string FileEngineOptionsXml
        {
            [DebuggerStepThrough]
            get { return FolderDataKv + "EngineOptions.icx"; }
        }

        public static string FileEngineData
        {
            [DebuggerStepThrough]
            get { return FolderDataKv + "EngineManagerData.Settings.icx"; }
        }

        public static string FileDataKvXml
        {
            [DebuggerStepThrough]
            get { return FolderDataKv + "Kv.icx"; }
        }

        public static string FileDatabaseFilesIcp
        {
            [DebuggerStepThrough]
            get { return FolderDataKv + "DatabaseFiles.Icp"; }
        }
        
        public static string DefaultDatabaseFilePath
        {
            [DebuggerStepThrough]
            get { return FolderDatabase + "Database.icd"; }
        }

        public static string FileDatabaseE2E
        {
            [DebuggerStepThrough]
            get { return FolderDatabase + "E2E.icd"; }
        }

        public static string AutoSaveFilePath
        {
            [DebuggerStepThrough]
            get { return FolderDatabase + "AutoSave.icd"; }
        }

        public static string OnlineKibitzedGameFilePath
        {
            [DebuggerStepThrough]
            get { return FolderDatabase + "MyOnlineKibitzedGame.icd"; }
        }

        public static string MyOnlineGameFilePath
        {
            [DebuggerStepThrough]
            get { return FolderDatabase + "MyOnlineGame.icd"; }
        }

        public static string MyOnlineHumanTournamentFilePath
        {
            [DebuggerStepThrough]
            get { return FolderDatabase + "MyOnlineHumanTournament.icd"; }
        }

        public static string MyOnlineEngineTournamentFilePath
        {
            [DebuggerStepThrough]
            get { return FolderDatabase + "MyOnlineEngineTournament.icd"; }
        }

        public static string MyOnlineEngineGameFilePath
        {
            [DebuggerStepThrough]
            get { return FolderDatabase + "MyOnlineEngineGame.icd"; }
        }

        public static string FileHelpChm
        {
            [DebuggerStepThrough]
            get { return FolderHelp + "InfinityChessHelp.chm"; }
        }

        public static string FileUserProfile
        {
            //[DebuggerStepThrough]
            get { return FolderDataKv + "UserProfile.icx"; }
        }
        
        public static string FileOnlineDocking
        {
            [DebuggerStepThrough]
            get { return FolderDataKv + "DockOnline.xml"; }
        }

        public static string FileOnlineDockingDefault
        {
            [DebuggerStepThrough]
            get { return FolderDataKv + "DockDefaultOnline.xml"; }
        }

        public static string FileDock(GameMode mode)
        {
            return Ap.FolderDataKv + "Dock" + mode.ToString() + ".xml";
        }

        public static string FileDockDefault(GameMode mode)
        {
            return Ap.FolderDataKv + "DockDefault" + mode.ToString() + ".xml";
        }

        public static string FileRingWav
        {
            [DebuggerStepThrough]
            get { return FolderMedia + "Ring.wav"; }
        }
        public static string FileIllegalWav
        {
            [DebuggerStepThrough]
            get { return FolderMedia + "illegal.wav"; }
        }
        public static string FileCaptureWav
        {
            [DebuggerStepThrough]
            get { return FolderMedia + "Capture.wav"; }
        }

        public static string FileMoveWav
        {
            [DebuggerStepThrough]
            get { return FolderMedia + "Move.wav"; }
        }
        public static string FileSetPiecesWav
        {
            [DebuggerStepThrough]
            get { return FolderMedia + "SetPieces.wav"; }
        }
        public static string FileAvSwf
        {
            [DebuggerStepThrough]
            get { return FolderMedia + "Av.swf"; }
        }

        public static string FileLogTxt
        {
            [DebuggerStepThrough]
            get { return FolderDataKv + "Log.txt"; }
        }

        public static string FilePatch
        {
            [DebuggerStepThrough]
            get { return FolderPatches + "InfiChess.zip"; }
        }

        public static string FileUpdateManager
        {
            [DebuggerStepThrough]
            get { return FolderUpdaterBin + "UpdateManager.exe"; }
        }

        public static string FileInfiChess
        {
            [DebuggerStepThrough]
            get { return System.IO.Path.GetFullPath(FolderAppBin + @".\..\") + "InfinityChess.exe"; }
        }

        #endregion

        #endregion

        #region Web
        #region WebAppFolder
        public static string WebFolderAppRoot
        {
            [DebuggerStepThrough]
            get { return AppDomain.CurrentDomain.BaseDirectory; }
        }

        #endregion

        #region WebFolders
        public static string WebFolderWeb
        {
            [DebuggerStepThrough]
            get { return WebFolderAppRoot + @"Web\"; }
        }

        public static string WebFolderWebService
        {
            [DebuggerStepThrough]
            get { return WebFolderAppRoot + @"WebService\"; }
        }

        public static string WebFolderData
        {
            [DebuggerStepThrough]
            get { return WebFolderAppRoot + @"Data\"; }
        }

        public static string WebFolderDataUser
        {
            [DebuggerStepThrough]
            get { return WebFolderData + @"User\"; }
        }

        public static string WebFolderUserImages
        {
            [DebuggerStepThrough]
            get { return WebFolderDataUser + @"Images\"; }
        }

        #endregion

        #region Files

        #endregion
        #endregion
    }
}
