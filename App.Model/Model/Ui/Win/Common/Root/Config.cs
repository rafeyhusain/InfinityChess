// (c) Copyright RafeySoft, Karachi Pakistan. http://rafeysoft.com
// This source is subject to following License:
// http://rafeysoft.com/Web/Page/ItemEdit.aspx?sid=29&lid=4&cid=23&iid=2143
// Please write to info@rafeysoft.com for more information
// All other rights reserved.

using System;
using App.Model;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web;
using System.Reflection;
using System.Diagnostics;
namespace App.Model
{
    [DebuggerStepThrough]
    public class Config
    {
        #region Ctor
        static Config()
        {

        }
        #endregion

        #region GetKey
        public static string GetKey(string key, object defaultValue)
        {
            string val = "";

            try
            {
                val = ConfigurationManager.AppSettings[key];

                if (val == null)
                {
                    val = defaultValue.ToString();
                }
            }
            catch
            {
                val = defaultValue.ToString();
            }

            return val;
        }

        public static int GetKeyInt32(string key, int defaultValue)
        {
            try
            {
                return Convert.ToInt32(Config.GetKey(key, defaultValue));
            }
            catch
            {
                return defaultValue;
            }
        }

        public static bool GetKeyBool(string key, bool defaultValue)
        {
            try
            {
                return Convert.ToBoolean(Config.GetKey(key, defaultValue));
            }
            catch
            {
                return defaultValue;
            }
        }
        #endregion

        #region ConnectionString

        public static string DefaultConnectionString
        {
            [DebuggerStepThrough]
            get { return GetKey("DefaultConnectionString", "ConnectionString"); }
        }

        public static string WebServiceUrl
        {
            [DebuggerStepThrough]
            get { return GetKey("WebServiceUrl", "localhost"); }
        }

        public static string ConnectionString
        {
            [DebuggerStepThrough]
            get { return ConfigurationManager.ConnectionStrings[DefaultConnectionString].ConnectionString.Replace("%AppFolder%", AppDomain.CurrentDomain.BaseDirectory); }
        }
        #endregion

        #region Crypto
        public static byte[] IV
        {
            [DebuggerStepThrough]
            get { return new byte[] { 210, 152, 152, 141, 6, 84, 161, 212, 77, 71, 46, 38, 68, 110, 128, 159 }; }
        }

        public static byte[] Key
        {
            [DebuggerStepThrough]
            get { return new byte[] { 186, 176, 251, 49, 154, 190, 169, 253, 33, 120, 181, 202, 38, 102, 8, 104, 38, 59, 243, 44, 174, 14, 63, 152, 29, 74, 225, 121, 229, 238, 11, 33 }; }
        }
        #endregion

        #region About
        public static string About
        {
            [DebuggerStepThrough]
            get { return ""; }
        }

        public static string Version
        {
            [DebuggerStepThrough]
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString(4);
            }
        }

        public static bool IsDev
        {
            [DebuggerStepThrough]
            get { return GetKeyBool("IsDev", false); }
        }

        public static string ProductName
        {
            [DebuggerStepThrough]
            get { return "Infinity Chess"; }
        }
        #endregion

        #region UserID

        public static int MaxDbSizeInMb
        {
            [DebuggerStepThrough]
            get { return GetKeyInt32("MaxDbSizeInMb", 15); }
        }

        public static int MaxDbSizeInKb
        {
            [DebuggerStepThrough]
            get { return GetKeyInt32("MaxDbSizeInKb", 60); } // 60 Kb(ziped) = 15 Mb(encrypted)
        }

        public static int UserID
        {
            [DebuggerStepThrough]
            get { return GetKeyInt32("UserID", 0); }
        }

        public static string User1Name
        {
            [DebuggerStepThrough]
            get { return GetKey("User1Name", "ubaid"); }
        }

        public static string User1Password
        {
            [DebuggerStepThrough]
            get { return GetKey("User1Password", "ubaid"); }
        }

        public static string User2Name
        {
            [DebuggerStepThrough]
            get { return GetKey("User2Name", "imran"); }
        }

        public static string User2Password
        {
            [DebuggerStepThrough]
            get { return GetKey("User2Password", "imran"); }
        }

        #endregion

        #region Game Server

        public static string ServerType
        {
            [DebuggerStepThrough]
            get { return GetKey("ServerType", "Development Server"); }
        }

        public static string GameServerIP
        {
            [DebuggerStepThrough]
            get { return GetKey("GameServerIP", "98.129.67.170"); }
        }

        public static int GameServerPort
        {
            [DebuggerStepThrough]
            get { return GetKeyInt32("GameServerPort", 7000); }
        }

        public static bool GameServerEnableIncomingLog
        {
            [DebuggerStepThrough]
            get { return GetKeyBool("GameServerEnableIncomingLog", false); }
        }

        public static bool GameServerEnableOutgoingLog
        {
            [DebuggerStepThrough]
            get { return GetKeyBool("GameServerEnableOutgoingLog", false); }
        }

        #endregion

        #region Av Server

        public static string AvServerIp
        {
            [DebuggerStepThrough]
            get { return GetKey("AvServerIp", "98.129.67.170"); }
        }

        public static int AvServerPort
        {
            [DebuggerStepThrough]
            get { return GetKeyInt32("AvServerPort", 7001); }
        }

        #endregion

    }
}
