using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using InfinitySettings.Streams;
using System.Diagnostics;
namespace App.Model
{
    #region Xml Generation SQLs
    /*
     * Country
     select '<Kv><k>'+ convert(varchar(20), CountryID) + '</k><v>' + Name + '</v></Kv>' from Country
     * 
     * NearestCity
     * select '<Kv><k>'+ convert(varchar(20), NearestCityID) + '</k><v>' + Name + '</v></Kv>' from NearestCity
     */

    #endregion

    #region enum
    public enum KvType
    {
        None,
        Web,
        Country,
        ResultSymbols,
        TournamentType,
        Eco,
        CountryLong,
        NearestCity,
        ColorSchemes,
        PiecesThemes,
        BackgroundThemes
    }

    public enum StdKv
    {
        CurrentUserID,
        Ver
    }

    //SELECT KeyName + ' = ' + CONVERT(VARCHAR(20), Value) + ',' FROM KeyValue
    public enum SysKv
    {
        None = 0,
        UrlInfiChess = 1
    }
    #endregion

    #region KV
    public class Kv
    {
        #region Data Members
        public DataTable DataTable = null;
        public const string KeyName = "k";
        public const string ValueName = "v";
        #endregion

        #region Ctor

        public Kv(bool Empty)
        {
            CreateKv();
        }

        public Kv()
        {
            CreateKv();

            this.AddStdKeys();
        }

        public Kv(string filePath)
        {
            ReadXml(filePath);

            this.AddStdKeys();
        }

        public Kv(DataTable kv)
        {
            DataTable = kv;
        }

        public Kv(string kvXml, bool isXml)
        {
            Load(kvXml);
        }

        public void Load(string kvXml)
        {
            if (String.IsNullOrEmpty(kvXml))
            {
                CreateKv();
            }
            else
            {
                DataTable = UData.LoadDataTable(kvXml, kvXml);
            }
        }

        public Kv(KvType type)
        {
            if (type == KvType.Web)
            {
                DataTable = UData.ToTable2("Kv", "k", "v");
            }
            else
            {
                string path = GetFilePath(type);

                DataTable = UData.LoadDataTable5(path);
            }
        }

        private void CreateKv()
        {
            DataTable = UData.LoadXsdText(App.Model.Properties.Resources.Kv);
            DataTable.TableName = "Kv";
        }

        public static Kv Instance(KvType type)
        {
            return new Kv(type);
        }

        private void AddStdKeys()
        {
            Set(StdKv.Ver, Config.Version);
            Set(StdKv.CurrentUserID, Ap.CurrentUserID);
        }
        #endregion

        #region Properties

        public string ToDataTableString
        {
            [DebuggerStepThrough]
            get
            {
                return UData.ToString(DataTable);
            }
        }

        #endregion

        #region Method

        #region Set
        [DebuggerStepThrough]
        public void Set(StdKv key, object value)
        {
            Kv.Set(DataTable, key, value);
        }

        [DebuggerStepThrough]
        public void Set(string key, DateTime value)
        {
            Kv.Set(DataTable, key, value);
        }

        [DebuggerStepThrough]
        public void Set(string key, bool value)
        {
            Kv.Set(DataTable, key, value);
        }

        [DebuggerStepThrough]
        public void Set(string key, decimal value)
        {
            Kv.Set(DataTable, key, value);
        }

        [DebuggerStepThrough]
        public void Set(string key, double value)
        {
            Kv.Set(DataTable, key, value);
        }

        [DebuggerStepThrough]
        public void Set(string key, long value)
        {
            Kv.Set(DataTable, key, value);
        }

        [DebuggerStepThrough]
        public void Set(string key, int value)
        {
            Kv.Set(DataTable, key, value);
        }

        [DebuggerStepThrough]
        public void Set(string key, byte[] value)
        {
            Kv.Set(DataTable, key, value);
        }

        [DebuggerStepThrough]
        public void Set(string key, string value)
        {
            Kv.Set(DataTable, key, value);
        }
        #endregion

        #region Get

        [DebuggerStepThrough]
        public DataSet GetDataSet(string key)
        {
            return Kv.GetDataSet(DataTable, key);
        }

        [DebuggerStepThrough]
        public DataTable GetDataTable(string key)
        {
            return Kv.GetDataTable(DataTable, key);
        }

        [DebuggerStepThrough]
        public DateTime GetDateTime(string key)
        {
            return Kv.GetDateTime(DataTable, key);
        }

        [DebuggerStepThrough]
        public bool GetBool(string key)
        {
            return Kv.GetBool(DataTable, key);
        }

        [DebuggerStepThrough]
        public decimal GetDecimal(string key)
        {
            return Kv.GetDecimal(DataTable, key);
        }

        [DebuggerStepThrough]
        public double GetDouble(string key)
        {
            return Kv.GetDouble(DataTable, key);
        }

        [DebuggerStepThrough]
        public int GetInt32(string key)
        {
            return Kv.GetInt32(DataTable, key);
        }

        [DebuggerStepThrough]
        public byte[] GetBytes(string key)
        {
            return Kv.GetBytes(DataTable, key);
        }

        [DebuggerStepThrough]
        public string Get(StdKv key)
        {
            return Kv.Get(DataTable, key.ToString());
        }

        [DebuggerStepThrough]
        public int GetInt32(StdKv key)
        {
            return Kv.GetInt32(DataTable, key.ToString());
        }

        [DebuggerStepThrough]
        public string Get(string key)
        {
            return Kv.Get(DataTable, key);
        }

        [DebuggerStepThrough]
        public DataRow GetSettingRow(string key)
        {
            return Kv.GetSettingRow(DataTable, key);
        }
        #endregion

        #endregion

        #region Helpers

        #region Set
        public static void Set(DataTable table, StdKv key, object value)
        {
            Set(table, key.ToString(), value.ToString());
        }

        public static void Set(DataTable table, string key, DateTime value)
        {
            Set(table, key, value.ToString());
        }

        public static void Set(DataTable table, string key, bool value)
        {
            Set(table, key, value.ToString());
        }

        public static void Set(DataTable table, string key, decimal value)
        {
            Set(table, key, value.ToString());
        }

        public static void Set(DataTable table, string key, long value)
        {
            Set(table, key, value.ToString());
        }

        public static void Set(DataTable table, string key, double value)
        {
            Set(table, key, value.ToString());
        }

        public static void Set(DataTable table, string key, int value)
        {
            Set(table, key, value.ToString());
        }

        public static void Set(DataTable table, string key, byte[] value)
        {
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            Set(table, key, enc.GetString(value));
        }

        public static void Set(DataTable table, string key, string value)
        {
            DataRow row = GetSettingRow(table, key);

            row[KeyName] = key;
            row[ValueName] = value;
        }
        #endregion

        #region Get

        public static DataSet GetDataSet(DataTable table, string key)
        {
            try
            {
                string s = Get(table, key);

                return UData.LoadDataSet(s);
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetDataTable(DataTable table, string key)
        {
            try
            {
                string s = Get(table, key);

                return UData.LoadDataTable(s);
            }
            catch
            {
                return null;
            }
        }

        public static DateTime GetDateTime(DataTable table, string key)
        {
            try
            {
                return Convert.ToDateTime(Get(table, key));
            }
            catch
            {
                return DateTime.Now.AddYears(-1000);
            }
        }

        public static bool GetBool(DataTable table, string key)
        {
            try
            {
                return Convert.ToBoolean(Get(table, key));
            }
            catch
            {
                return false;
            }
        }

        public static decimal GetDecimal(DataTable table, string key)
        {
            try
            {
                return Convert.ToDecimal(Get(table, key));
            }
            catch
            {
                return 0;
            }
        }

        public static double GetDouble(DataTable table, string key)
        {
            try
            {
                return Convert.ToDouble(Get(table, key));
            }
            catch
            {
                return 0;
            }
        }

        public static int GetInt32(DataTable table, string key)
        {
            try
            {
                return Convert.ToInt32(Get(table, key));
            }
            catch
            {
                return 0;
            }
        }

        public static byte[] GetBytes(DataTable table, string key)
        {
            try
            {
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                return encoding.GetBytes(Get(table, key));
            }
            catch
            {
                return null;
            }
        }

        public static string Get(DataTable table, string key)
        {
            DataRow row = GetSettingRow(table, key);

            return row[ValueName].ToString();
        }

        public static DataRow GetSettingRow(DataTable table, string key)
        {
            DataRow row = null;

            DataRow[] rows = table.Select(Kv.KeyName + "=" + UStr.Quote(key));

            if (rows.Length > 0)
            {
                row = rows[0];
            }
            else
            {
                row = table.NewRow();
                row[Kv.KeyName] = key;
                table.Rows.Add(row);

                table.AcceptChanges();
            }

            return row;
        }

        public static string GetFilePath(KvType type)
        {
            return Ap.FolderDataKv + type.ToString() + ".icx";
        }

        #endregion

        #endregion

        #region Load/ReadXml
        public void ReadXml(string filePath)
        {
            CreateKv();

            UData.ReadXml(DataTable, filePath);
        }

        public void ReadXml(System.IO.MemoryStream memoryStream)
        {
            CreateKv();
            DataTable.ReadXml(memoryStream);
        }

        public void WriteXml(string filePath)
        {
            UData.WriteXml(DataTable, filePath);
        }

        public void LoadXml(string dt)
        {
            UData.LoadDataTable(this.DataTable, UZip.Unzip(dt));
        }
        #endregion

        #region To
        public override string ToString()
        {
            return UData.ToString(this.DataTable);
        }

        public string ToZip()
        {
            return UZip.Zip(this.ToString());
        }
        #endregion

        #region SysKv
        private static DataTable sysKv = null;
        public static DataTable SysKv
        {
            get
            {
                if (sysKv == null)
                {
                    sysKv = BaseCollection.ExecuteSql("select KeyName k, Value v from KeyValue");
                }

                return sysKv;
            }
        }

        public static string Get(SysKv sysKv)
        {
            return Kv.Get(SysKv, sysKv.ToString());
        }

        public static int GetInt32(SysKv sysKv)
        {
            return Kv.GetInt32(SysKv, sysKv.ToString());
        }

        public static bool GetBool(SysKv sysKv)
        {
            return Kv.GetBool(SysKv, sysKv.ToString());
        }
        #endregion

        #region Cxt
        private Cxt cxt = null;
        public Cxt Cxt
        {
            get
            {
                if (cxt == null)
                {
                    cxt = new Cxt();

                    cxt.CurrentUserID = this.GetInt32(StdKv.CurrentUserID);
                }

                return cxt;
            }
            set { cxt = value; }
        }
        #endregion

        #region Indexer

        public string this[string k]
        {
            get
            {
                return this.Get(k);
            }
            set
            {
                this.Set(k, value);
            }
        }

        #endregion
    }
    #endregion
}
