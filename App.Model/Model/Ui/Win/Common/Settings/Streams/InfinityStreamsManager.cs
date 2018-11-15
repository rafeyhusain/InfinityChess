using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;
using System.IO;
using App.Model;
using System.Data;

namespace InfinitySettings.Streams
{    
    public class InfinityStreamsManager
    {
        #region Ctor
        public InfinityStreamsManager()
        {

        } 
        #endregion

        #region Write
        public static void WriteFile(string filePath, string fileContent)
        {
            try
            {
                UFile.RemoveReadOnly(filePath);
                UZip.WriteZip(filePath, fileContent);
            }
            catch (Exception ex)
            {
                MessageForm.Show(ex, fileContent);
                TestDebugger.Instance.WriteLog(ex);
                TestDebugger.Instance.WriteLog(fileContent);
                throw ex;
            }
        }

        public static void WriteStreamToFile(string filePath, MemoryStream memoryStream)
        {
            try
            {
                string fileContent = GetStreamsContent(memoryStream);
                UFile.RemoveReadOnly(filePath);
                WriteFile(filePath, fileContent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void WriteRegularFile(string filePath, string fileContent)
        {
            try
            {
                UFile.RemoveReadOnly(filePath);
                StreamWriter writer = new StreamWriter(filePath, false);
                writer.Write(fileContent);
                writer.Close();
                writer = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        #endregion

        #region Read
        public static string ReadFromFile(string filePath)
        {
            string fileContent = "";
            try
            {
                UFile.RemoveReadOnly(filePath);
                //InfinityReader reader = new InfinityReader(filePath);
                //fileContent = reader.ReadToEnd();
                //reader.Close();
                //reader = null;

                fileContent = InfinityReader.ReadToEnd(filePath);                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return fileContent;
        }

        public static MemoryStream ReadStreamFromFile(string filePath)
        {
            MemoryStream memoryStream = null;
            try
            {
                string fileContent = InfinityStreamsManager.ReadFromFile(filePath);
                memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(fileContent));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return memoryStream;
        }

        private static string GetStreamsContent(MemoryStream memoryStream)
        {
            string content = string.Empty;
            memoryStream.Position = 0;

            StreamReader streamReader = new StreamReader(memoryStream);
            content = streamReader.ReadToEnd();
            streamReader.Close();

            return content;
        }

        public static string ReadFromRegularFile(string filePath)
        {
            string fileContent = "";
            try
            {
                UFile.RemoveReadOnly(filePath);
                StreamReader reader = new StreamReader(filePath);
                fileContent = reader.ReadToEnd();
                reader.Close();
                reader = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return fileContent;
        } 
        #endregion
    }
}

