// (c) Copyright RafeySoft, Karachi Pakistan. http://rafeysoft.com
// This source is subject to following License:
// http://rafeysoft.com/Web/Page/ItemEdit.aspx?sid=29&lid=4&cid=23&iid=2143
// Please write to info@rafeysoft.com for more information
// All other rights reserved.

using System;
using System.Text;
using System.Collections;
using System.IO;
using System.Data;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.BZip2;
using System.IO.Compression;

namespace App.Model
{
    public static class UZip
    {
        #region static Method
        
        #region Zip/UnZip

        public static void WriteZip(string filePath, string s)
        {
            byte[] b = UZip.ZipString(s);

            FileStream fs = new FileStream(filePath, FileMode.Create);

            fs.Write(b, 0, b.Length);

            fs.Close();
        }

        #region GZipStream 
        public static byte[] CompressNew(byte[] buffer)
        {
            MemoryStream ms = new MemoryStream();
            GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true);
            zip.Write(buffer, 0, buffer.Length);
            zip.Close();
            ms.Position = 0;

            MemoryStream outStream = new MemoryStream();

            byte[] compressed = new byte[ms.Length];
            ms.Read(compressed, 0, compressed.Length);

            byte[] gzBuffer = new byte[compressed.Length + 4];
            Buffer.BlockCopy(compressed, 0, gzBuffer, 4, compressed.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gzBuffer, 0, 4);
            return gzBuffer;
        }

        public static byte[] DecompressNew(byte[] gzBuffer)
        {
            MemoryStream ms = new MemoryStream();
            int msgLength = BitConverter.ToInt32(gzBuffer, 0);
            ms.Write(gzBuffer, 4, gzBuffer.Length - 4);

            byte[] buffer = new byte[msgLength];

            ms.Position = 0;
            GZipStream zip = new GZipStream(ms, CompressionMode.Decompress);
            zip.Read(buffer, 0, buffer.Length);

            return buffer;
        }

        public static byte[] ZipStringNew(string sBuffer)
        {
            byte[] bytesUnCompressed = Encoding.ASCII.GetBytes(sBuffer);
            byte[] bytesCompressed = CompressNew(bytesUnCompressed);
            return bytesCompressed;
        }

        public static string UnzipStringNew(byte[] compbytes)
        {
            byte[] bytesUnCompressed = DecompressNew(compbytes);
            string sUnCompressed = Encoding.ASCII.GetString(bytesUnCompressed);

            return sUnCompressed;
        } 
        #endregion

        #region ICSharpZipLib 
        public static byte[] ZipString(string sBuffer)
        {
            MemoryStream msCompressed = new MemoryStream();
            byte[] bytesBuffer = Encoding.ASCII.GetBytes(sBuffer);
            Int32 size = bytesBuffer.Length;

            // Prepend the compressed data with the length of the uncompressed data (firs 4 bytes)
            BinaryWriter writer = new BinaryWriter(msCompressed, System.Text.Encoding.ASCII);
            writer.Write(size);

            // compress the data
            BZip2OutputStream zosCompressed = new BZip2OutputStream(msCompressed);

            zosCompressed.Write(bytesBuffer, 0, size);
            //zosCompressed.Finalize();
            zosCompressed.Close();

            bytesBuffer = msCompressed.ToArray();
            return bytesBuffer;
        }

        public static string UnzipString(byte[] compbytes)
        {
            MemoryStream msUncompressed = new MemoryStream(compbytes);

            // read final uncompressed string size stored in first 4 bytes
            BinaryReader reader = new BinaryReader(msUncompressed, System.Text.Encoding.ASCII);
            Int32 size = reader.ReadInt32();

            // decompress string
            BZip2InputStream zisUncompressed = new BZip2InputStream(msUncompressed);

            byte[] bytesBuffer = new byte[size];
            zisUncompressed.Read(bytesBuffer, 0, bytesBuffer.Length);
            zisUncompressed.Close();
            msUncompressed.Close();
            string sUncompressed = Encoding.ASCII.GetString(bytesBuffer);

            return sUncompressed;
        } 
        #endregion

        public static void Zip(string inputFolderPath, string outputPathAndFile, string password)
        {
            ArrayList ar = GenerateFileList(inputFolderPath); // generate file list
            int TrimLength = (Directory.GetParent(inputFolderPath)).ToString().Length;
            // find number of chars to remove     // from orginal file path
            TrimLength += 1; //remove '\'
            FileStream ostream;
            byte[] obuffer;
            string outPath = inputFolderPath + @"\" + outputPathAndFile;
            ZipOutputStream oZipStream = new ZipOutputStream(File.Create(outPath)); // create zip stream
            if (password != null && password != String.Empty)
                oZipStream.Password = password;
            oZipStream.SetLevel(9); // maximum compression
            ZipEntry oZipEntry;
            foreach (string Fil in ar) // for each file, generate a zipentry
            {
                oZipEntry = new ZipEntry(Fil.Remove(0, TrimLength));
                oZipStream.PutNextEntry(oZipEntry);

                if (!Fil.EndsWith(@"/")) // if a file ends with '/' its a directory
                {
                    ostream = File.OpenRead(Fil);
                    obuffer = new byte[ostream.Length];
                    ostream.Read(obuffer, 0, obuffer.Length);
                    oZipStream.Write(obuffer, 0, obuffer.Length);
                }
            }
            oZipStream.Finish();
            oZipStream.Close();
        }
        public static string Zip(string s)
        {
            return s;
        } 
        public static void Unzip(string zipPathAndFile, string outputFolder, string password, bool deleteZipFile)
        {
            ZipInputStream s = new ZipInputStream(File.OpenRead(zipPathAndFile));
            if (password != null && password != String.Empty)
                s.Password = password;
            ZipEntry theEntry;
            string tmpEntry = String.Empty;
            while ((theEntry = s.GetNextEntry()) != null)
            {
                string directoryName = outputFolder;
                string fileName = Path.GetFileName(theEntry.Name);
                // create directory 
                if (directoryName != "")
                {
                    Directory.CreateDirectory(directoryName);
                }
                if (fileName != String.Empty)
                {
                    if (theEntry.Name.IndexOf(".ini") < 0)
                    {
                        string fullPath = directoryName + "\\" + theEntry.Name;
                        fullPath = fullPath.Replace("\\ ", "\\");
                        string fullDirPath = Path.GetDirectoryName(fullPath);
                        if (!Directory.Exists(fullDirPath))
                            Directory.CreateDirectory(fullDirPath);

                        UFile.Delete(fullPath);

                        FileStream streamWriter = File.Create(fullPath);

                        int size = 2048;
                        byte[] data = new byte[2048];
                        while (true)
                        {
                            size = s.Read(data, 0, data.Length);
                            if (size > 0)
                            {
                                streamWriter.Write(data, 0, size);
                            }
                            else
                            {
                                break;
                            }
                        }
                        streamWriter.Close();
                    }
                }
            }
            s.Close();
            if (deleteZipFile)
                File.Delete(zipPathAndFile);
        }
        public static void Unzip(string zipFilePath, bool deleteZipFile)
        {
            Unzip(zipFilePath, UFile.GetFolder(zipFilePath), "", deleteZipFile);
        }
        public static string Unzip(string s)
        {
            return s;
        }
        
        #endregion
        
        #region DataTable
        
        public static string ZipDataTable(DataTable dt)
        {
            return UZip.Zip(UData.ToString(dt));
        }
        public static DataTable UnzipDataTable(string xsd, string dt)
        {
            return UData.LoadDataTable(xsd, UZip.Unzip(dt));
        }
        
        #endregion

        #region DataSet
        
        public static string ZipDataSet(DataSet ds)
        {
            return UZip.Zip(UData.ToString(ds));
        }
        public static DataSet UnzipDataSet(string xsd, string ds)
        {
            return UData.LoadDataSet(xsd, UZip.Unzip(ds));
        }
        
        #endregion

        #region Helpers

        private static ArrayList GenerateFileList(string Dir)
        {
            ArrayList fils = new ArrayList();
            bool Empty = true;
            foreach (string file in Directory.GetFiles(Dir)) // add each file in directory
            {
                fils.Add(file);
                Empty = false;
            }

            if (Empty)
            {
                if (Directory.GetDirectories(Dir).Length == 0)
                // if directory is completely empty, add it
                {
                    fils.Add(Dir + @"/");
                }
            }

            foreach (string dirs in Directory.GetDirectories(Dir)) // recursive
            {
                foreach (object obj in GenerateFileList(dirs))
                {
                    fils.Add(obj);
                }
            }
            return fils; // return file list
        }

        #endregion

        #endregion
    }
}