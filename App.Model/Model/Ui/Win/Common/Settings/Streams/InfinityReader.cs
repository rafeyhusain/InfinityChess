using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;
using System.IO;
using App.Model;


namespace InfinitySettings.Streams
{    
    public class InfinityReader : FileStream
    {
        public string Path = string.Empty;

        public InfinityReader(string path)
            : base(path, FileMode.Open)
        {
            Path = path;
        }


        public static string ReadToEnd(string path)
        {
            byte[] b = File.ReadAllBytes(path);

            return UZip.UnzipString(b);
        }

        public static string ReadToEnd2(string path)
        {
            string encryptedValue = string.Empty;
            encryptedValue = File.ReadAllText(path);

            string decryptedValue = string.Empty;
            decryptedValue = UCrypto.Decrypt(encryptedValue);

            return decryptedValue;
        }

        public static string ReadToEnd3(string path)
        {
            byte[] b = File.ReadAllBytes(path);

            return UZip.UnzipStringNew(b);
        }
    }
}

