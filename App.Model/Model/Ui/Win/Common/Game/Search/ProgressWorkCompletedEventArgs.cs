using System;
using App.Model;
using System.Collections.Generic;
using System.Text;
using InfinitySettings.Streams;
using System.IO;
using System.Xml;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;

namespace App.Model
{
    public class ProgressWorkCompletedEventArgs : EventArgs
    {
        public DataTable SearchedGames;
        public RunWorkerCompletedEventArgs arguments;
        public string data;
        public ProgressWorkCompletedEventArgs(RunWorkerCompletedEventArgs e, DataTable searchedGames)
        {
            SearchedGames = searchedGames;
            arguments = e;
        }

    }
}
