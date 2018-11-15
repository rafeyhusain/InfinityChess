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
    public class ProgressBarEventArgs : EventArgs
    {
        public int CurrentGameNo;
        public int TotalGames;

        public ProgressBarEventArgs(int currentgameNo, int totalGames)
        {
            CurrentGameNo = currentgameNo;
            TotalGames = totalGames;
        }

    }
}
