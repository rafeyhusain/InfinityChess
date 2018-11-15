using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;
using System.IO;
using App.Model;


namespace InfinitySettings.Streams
{
    public class InfinityWriter : FileStream
    {
        public string Path = string.Empty;

        public InfinityWriter(string path)
            : base(path, FileMode.Open)
        {
            Path = path;
        }

        public InfinityWriter(string path, bool append)
            : base(path, append ? FileMode.Append : FileMode.Create)
        {
            Path = path;
        }
        
        public void WriteLine(string value)
        {
            //Write(value + Environment.NewLine);
        }

        public void Write( string value)
        {
            //Write(UZip.ZipString(value), 0, value.Length);
            UZip.WriteZip(Path, value);
        }
    }
}

