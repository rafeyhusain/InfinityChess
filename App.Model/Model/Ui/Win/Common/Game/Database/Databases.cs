using System;
using App.Model;
using System.Collections.Generic;
using System.Data;
using System.Text;
using InfinityChess;
using System.Windows.Forms;
using ChessLibrary;
using System.Diagnostics;

namespace App.Model
{
    public partial class Databases
    {
        #region Data Members
        public DataTable DatabaseFilesData = null;
        public const string Path = "Path";
        public const string ShortPath = "ShortPath";
        public const string DBFilesData = "DatabaseFilesData";
        #endregion

        #region Ctor

        public Databases()
        {
            DatabaseFilesData = GetDatabaseFilesDataTable();
            Load();
        }

        public static DataTable GetDatabaseFilesDataTable()
        {
            return UData.ToTable2(DBFilesData, Path, ShortPath);
        }  
        #endregion

        #region Properties
        public int Count { get { return DatabaseFilesData.Rows.Count; } }
        
        #endregion

        #region AddDatabaseFilePath
 
        public bool Add(string filePath)
        {
            if (Exists(filePath))
            {
                return false;
            }

            DataRow row = DatabaseFilesData.NewRow();
            row[Path] = filePath;
            row[ShortPath] = Database.ShortPath(filePath);
            DatabaseFilesData.Rows.Add(row);

            Save();

            return true;
        } 
        #endregion

        #region Remove DatabaseFilePath
        public void Remove(string filePath)
        {
            DataRow row = GetDatabaseFilesDataRow(filePath);
            row.Delete();
            row.Table.AcceptChanges();
        } 
        #endregion

        #region GetDatabaseFilePath
        public bool Exists(string filePath)
        {
            return GetDatabaseFilesDataRow(filePath) != null;
        }

        private DataRow GetDatabaseFilesDataRow(string filePath)
        {
            DataRow[] rows = DatabaseFilesData.Select("Path='" + filePath + "'");
            if (rows.Length > 0)
                return rows[0];
            return null;
        } 
        #endregion

        #region Load/Save
        
        public void Load()
        {
            Load(Ap.FileDatabaseFilesIcp);
        }

        public void Load(string filePath)
        {
            UData.ReadXml(this.DatabaseFilesData, filePath);
        }

        public void Save()
        {
            Save(Ap.FileDatabaseFilesIcp);
        }

        public void Save(string filePath)
        {
            UData.WriteXml(this.DatabaseFilesData, filePath);
        }

        #endregion

        #region FirstAvailableDataBaseFilePath
        public string GetFirstAvailableDataBaseFilePath()
        {
            string databasePath = string.Empty;
            foreach (DataRow row in DatabaseFilesData.Rows)
            {
                if (System.IO.File.Exists(row[Databases.Path].ToString()))
                {
                    databasePath = row[Databases.Path].ToString();
                    goto final;
                }
                else 
                {
                    row.Delete();
                }
            }
        final:
            this.DatabaseFilesData.AcceptChanges();
            return databasePath;
        } 
        #endregion

        #region Helper

        #endregion
    }

    
}
