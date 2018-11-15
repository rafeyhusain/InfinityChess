// (c) Copyright RafeySoft, Karachi Pakistan. http://rafeysoft.com
// This source is subject to following License:
// http://rafeysoft.com/Web/Page/ItemEdit.aspx?sid=29&lid=4&cid=23&iid=2143
// Please write to info@rafeysoft.com for more information
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Collections;
using RKLib.ExportData;
using InfinitySettings.Streams;
using System.Xml;

namespace App.Model
{
    #region SqlTypeE
    
    public enum SqlTypeE
    {
        Insert,
        Update,
        Delete,
        Select
    }

    #endregion
   
    public class UData
    {
        #region Method
        
        #region ToSql
        public static string ToSelectAll(InfiChess tableName)
        {
            return ToSelectAll(tableName.ToString());
        }

        public static string ToSelectAll(string tableName)
        {
            return "SELECT * FROM [" + tableName + "]";
        }

        public static string ToSelect(InfiChess tableName, params object[] whereColVals)
        {
            return ToSelect(tableName.ToString(), whereColVals);
        }

        public static string ToSelect(string tableName, params object[] whereColVals)
        {
            return ToSql(ToSelectAll(tableName), ToAnd(whereColVals));
        }

        public static string ToSelectCount(int selectCount)
        {
            return " TOP " + (selectCount <= 0 ? " 100 PERCENT " : selectCount.ToString()) + " ";
        }

        public static string ToDelete(string tableName, params object[] whereColVals)
        {
            return ToSql("DELETE FROM [" + tableName + "]", ToAnd(whereColVals));
        }

        private static string ToAnd(params object[] whereColVals)
        {
            return UStr.Join(" = ", " AND ", whereColVals);
        }

        public static string ToSql(InfiChess tableName, string filter)
        {
            return ToSql(ToSelectAll(tableName), filter);
        }

        public static string ToSql(string sql, string filter)
        {
            if (String.IsNullOrEmpty(sql))
            {
                return "";
            }

            if (!String.IsNullOrEmpty(filter))
            {
                return sql + " WHERE " + filter;
            }

            return sql;
        }


        #endregion

        #region ToInt32

        public static int ToInt32(object value)
        {
            return ToInt32(value, 0);
        }

        public static int ToInt32(object value, object defaultValue)
        {
            return Convert.ToInt32(ToDecimal(value, defaultValue));
        }

        public static decimal ToDecimal(object value, object defaultValue)
        {
            try
            {
                return Convert.ToDecimal(value);
            }
            catch
            {
            }

            return ToDecimal(defaultValue, 0);
        }

        public static decimal ToDecimal(object value, decimal defaultValue)
        {
            try
            {
                return Convert.ToDecimal(value);
            }
            catch
            {
            }

            return defaultValue;
        }

        public static string ToString(object value, object defaultValue)
        {
            if (value == null)
            {
                return defaultValue.ToString() == null ? "" : defaultValue.ToString();
            }

            return value.ToString();
        }

        #endregion

        #region ToTable
        public static DataTable ToTable(DataRow row)
        {
            DataSet ds = new DataSet();

            DataTable table = row.Table.Clone();

            table.TableName = row.Table.TableName;

            ds.Tables.Add(table);

            table.ImportRow(row);

            return table;
        }

        public static DataTable ToTable(string tableName, params object[] columnNameType)
        {
            DataSet ds = new DataSet();

            DataTable table = ds.Tables.Add(tableName);

            for (int i = 0; i < columnNameType.Length; i += 2)
            {
                string name = columnNameType.GetValue(i) as string;

                Type type = columnNameType.GetValue(i + 1) as Type;

                table.Columns.Add(new DataColumn(name, type));
            }

            return table;
        }

        public static DataTable ToTable2(string tableName, params string[] columnNames)
        {
            DataSet ds = new DataSet();

            DataTable table = ds.Tables.Add(tableName);           

            return ToTable2(table, columnNames);
        }


        public static DataTable ToTable2(DataTable table, params string[] columnNames)
        {
            for (int i = 0; i < columnNames.Length; i++)
            {
                string name = columnNames.GetValue(i) as string;
                Type type = System.Type.GetType("System.String");
                table.Columns.Add(new DataColumn(name, type));
            }

            return table;
        }
        public static DataTable AddColumns(DataTable table, string[] columnNames)
        {
            if (columnNames == null)
            {
                return table;
            }

            for (int i = 0; i < columnNames.Length; i++)
            {
                string name = columnNames.GetValue(i) as string;

                Type type = System.Type.GetType("System.String");

                table.Columns.Add(new DataColumn(name, type));
            }

            return table;
        }

        public static DataTable DummyTable(int rowCount, params string[] columns)
        {
            DataTable table = ToTable2("Dummy", columns);

            return AddRows(table, rowCount);
        }

        public static DataTable AddRows(DataTable table, int rowCount)
        {
            for (int i = 0; i < rowCount; i++)
            {
                DataRow row = table.NewRow();

                foreach (DataColumn col in table.Columns)
                {
                    row[col] = "xyz" + (i + 1);
                }

                table.Rows.Add(row);
            }

            return table;
        }

        public static void SetRow(DataRow source, DataRow target)
        {
            foreach (DataColumn col in source.Table.Columns)
            {
                target[col.ColumnName] = source[col.ColumnName];
            }
        }
        #endregion

        #region Util
        
        public static string TableName(string sql)
        {
            int i = sql.IndexOf("from");

            if (i < 0)
            {
                return "";
            }

            i = i + 5;

            int j = sql.IndexOf(" ", i);

            if (j < 0)
            {
                j = sql.Length;
            }

            string tableName = sql.Substring(i, j - i);

            tableName = tableName.TrimStart('[');
            tableName = tableName.TrimEnd(']');

            return tableName.Trim();
        }

        public static String ToText(DataTable table)
        {
            StringBuilder s = new StringBuilder();

            foreach (DataRow row in table.Rows)
            {
                s.Append(row[0].ToString());    
            }

            return s.ToString();
        }

        
        #endregion

        #region Export
        public static string Export(DataTable table)
        {
            return ExportXml(Ap.FolderAppBin, table, true, true);
        }

        public static string ExportXml(DataTable table)
        {
            return ExportXml(Ap.FolderAppBin, table, true, false);
        }

        public static string ExportXsd(DataTable table)
        {
            return ExportXml(Ap.FolderAppBin, table, false, true);
        }

        private static string ExportXml(string folder, DataTable table, bool writeXml, bool writeXsd)
        {
            string path = folder;
            string xml = "";
            string xsd = "";

            if (table == null)
            {
                return "";
            }

            if (table.TableName == "")
            {
                table.TableName = "Table";
            }

            if (!path.EndsWith(@"\"))
            {
                path += @"\";
            }

            if (writeXsd)
            {
                xsd = path + table.TableName + ".xsd";
                table.WriteXmlSchema(xsd);
            }

            if (writeXml)
            {
                xml = path + table.TableName + ".xml";
                table.WriteXml(xml);
                path = xml;
            }
            else
            {
                path = xsd;
            }

            return path;
        }

        public static string ExportCsv(DataTable table)
        {
            if (table == null)
            {
                return "";
            }

            if (table.TableName == "")
            {
                table.TableName = "ExportedData";
            }

            string fileName = table.TableName.Replace(" ", "") + ".csv";

            RKLib.ExportData.Export x = new RKLib.ExportData.Export("Win");

            x.ExportDetails(table, RKLib.ExportData.Export.ExportFormat.CSV, fileName);

            return Ap.FolderAppBin + fileName;
        }

        public static string ExportSql(DataTable table, SqlTypeE type)
        {
            StringBuilder s = new StringBuilder();

            DataTable t = table.Copy();

            t.TableName = table.TableName;

            foreach (DataRow row in t.Rows)
            {
                switch (type)
                {
                    case SqlTypeE.Insert:
                        row.SetAdded();
                        break;
                    case SqlTypeE.Update:
                        row.SetModified();
                        break;
                    case SqlTypeE.Delete:
                        row.Delete();
                        break;
                    default:
                        break;
                }

                s.AppendLine(SqlHelper.ToSql(row));
            }

            string filePath = Ap.FolderAppBin + t.TableName + ".sql";

            UFile.Write(filePath, s.ToString());

            return filePath;
        }
       
        #endregion

        #region ToArray
        public static Array ToArray(DataTable table, string columnName)
        {
            return ToArray(table, columnName, System.Type.GetType("System.String"));
        }

        public static Array ToArray(DataTable table, string columnName, System.Type type)
        {
            ArrayList list = new ArrayList();

            foreach (DataRow row in table.Rows)
            {
                list.Add(row[columnName].ToString());
            }

            return list.ToArray(type);
        }

        #endregion

        #region ImportTable

        public static DataTable ImportTable(DataTable destination, DataTable source)
        {
            destination.Merge(source);

            return destination;
        } 
        
        #endregion

        #region Load
        #region DataTable
        public static DataTable LoadXsd(string xsdPath)
        {
            DataTable table = null;

            try
            {
                table = new DataTable(UFile.GetFileNameNoExtension(xsdPath));

                MemoryStream memoryStream = InfinityStreamsManager.ReadStreamFromFile(xsdPath);
                
                table.ReadXmlSchema(memoryStream);
                memoryStream.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return table;
        }

        public static DataTable LoadXsdText(string xsd)
        {
            DataTable table = null;

            try
            {
                table = new DataTable();

                if (!String.IsNullOrEmpty(xsd))
                {
                    MemoryStream s = new MemoryStream(UStr.ToBytes(xsd));

                    s.Position = 0;

                    DataSet ds = new DataSet();

                    ds.ReadXmlSchema(s);

                    table = ds.Tables[0];

                    s.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return table;
        }

        public static DataTable LoadDataTable(string xml)
        {
            return LoadDataTable(LoadXsdText(xml), xml);
        }

        public static DataTable LoadDataTable(string xsd, string xml)
        {
            DataTable table = LoadXsdText(xsd);

            return LoadDataTable(table, xml);
        }

        public static DataTable LoadDataTable2(string xsdPath, string xml)
        {
            DataTable table = LoadXsd(xsdPath);

            return LoadDataTable(table, xml);
        }

        public static DataTable LoadDataTable(DataTable table, string xml)
        {
            try
            {
                if (IsValidXml(xml))
                {
                    MemoryStream s = new MemoryStream(UStr.ToBytes(xml));

                    s.Position = 0;

                    table.ReadXml(s);

                    s.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return table;
        }

        public static DataTable LoadDataTable3(string xsdPath, string xmlPath)
        {
            DataTable table = null;

            try
            {
                table = LoadXsd(xsdPath);

                if (UFile.Exists(xmlPath))
                {
                    MemoryStream memoryStream = InfinityStreamsManager.ReadStreamFromFile(xmlPath);
                    table.ReadXml(memoryStream);
                    memoryStream.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return table;
        }

        public static DataTable LoadDataTable4(DataTable table, string xmlPath)
        {
            try
            {
                if (UFile.Exists(xmlPath))
                {
                    MemoryStream memoryStream = InfinityStreamsManager.ReadStreamFromFile(xmlPath);
                    
                    table.ReadXml(memoryStream);
                    
                    memoryStream.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return table;
        }

        public static DataTable LoadDataTable5(string xmlPath)
        {
            DataTable table = null;

            try
            {
                if (UFile.Exists(xmlPath))
                {
                    string content = InfinityStreamsManager.ReadFromFile(xmlPath);

                    table = UData.LoadDataTable(content, content);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return table;
        }

        public static string ToString(DataTable table)
        {
            string xml = string.Empty;
            try
            {
                if (table != null)
                {
                    MemoryStream s = new MemoryStream();

                    s.Position = 0;

                    table.WriteXml(s);

                    s.Position = 0;
                    StreamReader reader = new StreamReader(s);
                    xml = reader.ReadToEnd();
                    reader.Close();
                    s.Close();
                    reader = null;
                    s = null;
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return xml;
        }

        public static string ToString(DataRow row)
        {
            string xml = string.Empty;

            try
            {
                if (row != null)
                {
                    DataTable table = row.Table.Clone();

                    table.ImportRow(row);

                    return ToString(table);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return xml;
        }
        #endregion

        #region DataSet
        public static DataSet LoadXsd2(string xsdPath)
        {
            DataSet dataset = null;

            try
            {
                dataset = new DataSet(UFile.GetFileNameNoExtension(xsdPath));

                dataset.ReadXmlSchema(xsdPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dataset;
        }

        public static DataSet LoadXsdText2(string xsd)
        {
            DataSet dataset = null;

            try
            {
                if (!String.IsNullOrEmpty(xsd))
                {
                    MemoryStream s = new MemoryStream(UStr.ToBytes(xsd));

                    s.Position = 0;

                    dataset = new DataSet();

                    dataset.ReadXmlSchema(s);

                    s.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dataset;
        }

        public static DataSet LoadDataSet(string xml)
        {
            return LoadDataSet(LoadXsdText2(xml), xml);
        }

        public static DataSet LoadDataSet(string xsd, string xml)
        {
            DataSet dataset = LoadXsdText2(xsd);

            return LoadDataSet(dataset, xml);
        }

        public static DataSet LoadDataSet2(string xsdPath, string xml)
        {
            DataSet dataset = LoadXsd2(xsdPath);

            return LoadDataSet(dataset, xml);
        }

        public static DataSet LoadDataSet(DataSet dataset, string xml)
        {
            try
            {
                if (IsValidXml(xml))
                {
                    MemoryStream s = new MemoryStream(UStr.ToBytes(xml));

                    s.Position = 0;

                    dataset.ReadXml(s);

                    s.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dataset;
        }

        public static DataSet LoadDataSet3(string xsdPath, string xmlPath)
        {
            DataSet dataset = null;

            try
            {
                dataset = LoadXsd2(xsdPath);

                if (UFile.Exists(xmlPath))
                {
                    dataset.ReadXml(xmlPath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dataset;
        }

        public static string ToString(DataSet dataset)
        {
            string xml = string.Empty;
            try
            {
                if (dataset != null)
                {
                    MemoryStream s = new MemoryStream();

                    s.Position = 0;

                    dataset.WriteXml(s);

                    s.Position = 0;
                    StreamReader reader = new StreamReader(s);
                    xml = reader.ReadToEnd();
                    reader.Close();
                    s.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return xml;
        }

        public static bool IsValidXml(string xml)
        {
            if (String.IsNullOrEmpty(xml))
            {
                return false;
            }

            try
            {
                XmlDocument doc = new XmlDocument();

                doc.LoadXml(xml);
            }
            catch
            {
                return false;
            }

            return true;
        }
        #endregion
        #endregion

        #region Internationalization of date
        /// <summary>
        /// Created by arsalan ata on 12 January 2010
        /// used for sink all date format.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime GetChessDate(string value)
        {
            System.Globalization.CultureInfo cinfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            string strvalue = value; // mm/dd/yyyy hh:mm:ss am

            string[] ch = strvalue.Split(' ');
            string[] str1 = ch[0].Split('/');
            string[] str2 = ch[1].Split(':');

            DateTime dtSourceDate = new DateTime(Convert.ToInt32(str1[2]), Convert.ToInt32(str1[0]), Convert.ToInt32(str1[1]), Convert.ToInt32(str2[0]), Convert.ToInt32(str2[1]), Convert.ToInt32(str2[2]));
            DateTime date = Convert.ToDateTime(dtSourceDate, cinfo);
            return date;
        }

#endregion

        #region Write/Read...Xml

        public static void WriteXml(DataTable table, string filePath)
        {
            UFile.RemoveReadOnly(filePath);
            MemoryStream memoryStream = new MemoryStream();
            table.WriteXml(memoryStream);
            InfinityStreamsManager.WriteStreamToFile(filePath, memoryStream);
            memoryStream.Close();
        }

        public static DataTable ReadXml(DataTable table, string filePath)
        {
            if (UFile.Exists(filePath))
            {
                MemoryStream memoryStream = InfinityStreamsManager.ReadStreamFromFile(filePath);
                table.ReadXml(memoryStream);
                memoryStream.Close();
            }

            return table;
        }

        public static void WriteXmlDecrypted(DataTable table, string filePath)
        {
            UFile.RemoveReadOnly(filePath);

            table.WriteXml(filePath);
        }

        public static DataTable ReadXmlDecrypted(DataTable table, string filePath)
        {
            if (UFile.Exists(filePath))
            {
                table.ReadXml(filePath);
            }

            return table;
        }
        #endregion

        #region Contains

        public static bool Contains(DataTable table, string columnName, string value)
        {
            table.DefaultView.RowFilter = UStr.FilterExact(columnName, value);

            bool contains = table.DefaultView.Count != 0;

            table.DefaultView.RowFilter = "";

            return contains;
        }

        #endregion
        
        #endregion
    }
}
