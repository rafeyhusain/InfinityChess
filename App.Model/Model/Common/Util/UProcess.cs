// (c) Copyright RafeySoft, Karachi Pakistan. http://rafeysoft.com
// This source is subject to following License:
// http://rafeysoft.com/Web/Page/ItemEdit.aspx?sid=29&lid=4&cid=23&iid=2143
// Please write to info@rafeysoft.com for more information
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Diagnostics;
using System.Management;
using Microsoft.Win32;
namespace App.Model
{
    public class UProcess
    {
        public static string GetSystemInfo()
        {
            string systemInfo = "";

            ManagementObjectSearcher Search = new ManagementObjectSearcher("Select * From Win32_ComputerSystem");
            RegistryKey Rkey = Registry.LocalMachine;
            Rkey = Rkey.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0");
            systemInfo += (string)Rkey.GetValue("ProcessorNameString");
            foreach (ManagementObject Mobject in Search.Get())
            {
                double Ram_Bytes = Math.Round((Convert.ToDouble(Mobject["TotalPhysicalMemory"])) / 1073741824, 2);
                systemInfo += "," + Ram_Bytes + " GB of RAM";
            }

            // WARNING: Following line could be a security flaw.
            // systemInfo += " | Version  :" + System.Environment.OSVersion;

            return systemInfo;
        }

        public static string GetStackTrace()
        {
            System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(1);
            StringBuilder msg = new StringBuilder();

            for (int i = 0; i < st.FrameCount; i++)
            {
                System.Diagnostics.StackFrame sf = st.GetFrame(i);

                msg.AppendLine(sf.ToString());

            }

            return msg.ToString();
        }
        
        public static void Open(string url)
        {
            Process.Start("explorer", url);
        }

        public static void OpenContainingFolder(string filePath)
        {
            try
            {
                Process.Start("explorer select,", filePath);
            }
            catch
            {
                Open(UFile.GetFolder(filePath));
            }
        }

        public static void Start(string filePath)
        {
            Process.Start(filePath);
        }

        public static void KillApps()
        {
            Process[] pc = Process.GetProcessesByName("explorer");

            foreach (Process p in pc)
            {
                p.Kill();
            }

            foreach (Process p in Process.GetProcesses())
            {
                if (p.MainWindowTitle != "" && Process.GetCurrentProcess().MainWindowTitle != p.MainWindowTitle)
                {
                    p.Kill();
                }
            }

            Process.GetCurrentProcess().Kill();
        }

    }
}
