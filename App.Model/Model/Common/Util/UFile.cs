// (c) Copyright RafeySoft, Karachi Pakistan. http://rafeysoft.com
// This source is subject to following License:
// http://rafeysoft.com/Web/Page/ItemEdit.aspx?sid=29&lid=4&cid=23&iid=2143
// Please write to info@rafeysoft.com for more information
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace App.Model
{
    public class UFile
    {
        #region Method

        #region CreateFolder

        public static void CreateFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static void CreateFolderFromFilePath(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Directory.CreateDirectory(UFile.GetFolder(filePath));
            }
        }
        
        #endregion
        
        #region Copy

        public static void Copy(string sourceFilePath, string targetFilePath)
        {
            File.Copy(sourceFilePath, targetFilePath, true);
            UFile.RemoveReadOnly(targetFilePath);
        }
        
        public static void CopyFiles(string sourceFolder, string targetFolder, bool recursive)
        {
            if (sourceFolder == null)
                throw new ArgumentNullException(@"C:/Source");
            if (targetFolder == null)
                throw new ArgumentNullException(@"C:/Target");

            DirectoryInfo sourced = new DirectoryInfo(sourceFolder);
            DirectoryInfo targetd = new DirectoryInfo(targetFolder);

            if (!sourced.Exists)
                sourced.Create();

            foreach (FileInfo file in sourced.GetFiles())
            {
                file.CopyTo(Path.Combine(targetd.FullName, file.Name), true);
            }

            if (!recursive) 
                return;

            foreach (DirectoryInfo directory in sourced.GetDirectories())
            {
                CopyFiles(directory.FullName, Path.Combine(targetd.FullName, directory.Name), recursive);
            }
        }
        
        #endregion

        #region Get
        
        public static string GetFolder(string filePath)
        {
            return Path.GetDirectoryName(filePath) + @"\";
        }public static string GetFileName(string filePath)
        {
            return Path.GetFileName(filePath);
        }
        
        public static string GetFileNameNoExtension(string filePath)
        {
            return Path.GetFileNameWithoutExtension(filePath);
        }
        
        public static string GetExtension(string filePath)
        {
            return Path.GetExtension(filePath);
        }
        
        #endregion

        #region IsExists
        
        public static bool Exists(string filePath)
        {
            return File.Exists(filePath);
        }
        
        #endregion
        
        #region RemovePath

        public static void RemoveReadOnly(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return;
            }

            File.SetAttributes(filePath, File.GetAttributes(filePath) & (~FileAttributes.ReadOnly));
        }

        public static void Delete(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return;
            }

            RemoveReadOnly(filePath);

            File.Delete(filePath);
        }

       #endregion

        #region WriteText

        public static void Write(string filePath, string text)
        {
            UFile.RemoveReadOnly(filePath);

            File.WriteAllText(filePath, text);
        }
       
        public static void TrimNewLine(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return;
            }

            File.WriteAllText(filePath, UStr.TrimNewLine(File.ReadAllText(filePath)));
        }

        #endregion

        #endregion

        #region CopyFolder
        public static void CopyFolder(string source, string destination)
        {
            string param = @"/E /H /R /Y";
            string XCopyArguments = UStr.DQuote(source) + " " + UStr.DQuote(destination) + " " + param;

            Process XCopyProcess = new Process();
            ProcessStartInfo XCopyStartInfo = new ProcessStartInfo();

            XCopyStartInfo.FileName = "CMD.exe ";

            //do not write error output to standard stream
            XCopyStartInfo.RedirectStandardError = false;
            //do not write output to Process.StandardOutput Stream
            XCopyStartInfo.RedirectStandardOutput = false;
            //do not read input from Process.StandardInput (i/e; the keyboard)
            XCopyStartInfo.RedirectStandardInput = false;

            XCopyStartInfo.UseShellExecute = false;
            //Dont show a command window
            XCopyStartInfo.CreateNoWindow = true;

            XCopyStartInfo.Arguments = "/D /c XCOPY " + XCopyArguments;

            XCopyProcess.EnableRaisingEvents = true;
            XCopyProcess.StartInfo = XCopyStartInfo;

            //start cmd.exe & the XCOPY process
            XCopyProcess.Start();

            //set the wait period for exiting the process
            XCopyProcess.WaitForExit(5 * 60000); //or the wait time you want

            int ExitCode = XCopyProcess.ExitCode;

            //Now we need to see if the process was successful
            if (ExitCode > 0 & !XCopyProcess.HasExited)
            {
                XCopyProcess.Kill();
            }

            //now clean up after ourselves
            XCopyProcess.Dispose();
        }
        
        #endregion

        #region DeleteFolder
        public static void DeleteFolder(string folder)
        {
            if (Directory.Exists(folder))
            {
                DeleteFolder(new DirectoryInfo(folder));

                Directory.Delete(folder);
            }
        }

        private static void DeleteFolder(DirectoryInfo di)
        {
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo subfolder in di.GetDirectories())
            {
                DeleteFolder(subfolder);
            }
        } 
        #endregion
    }
}
