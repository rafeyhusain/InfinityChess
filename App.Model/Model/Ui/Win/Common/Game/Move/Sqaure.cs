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
    public class Sqaure
    {
        #region Data Members
        public static string[] File = { "a", "b", "c", "d", "e", "f", "g", "h" };
        public static string[] Rank = { "1", "2", "3", "4", "5", "6", "7", "8" };

        public const int FileCount = 8;
        public const int RankCount = 8;

        #endregion

        #region Ctor

        public Sqaure()
        {
        
        }

        #endregion

        #region Properties
      
        #endregion

        #region Methods
        public static string GetNotation(int column, int row)
        {
            return File[column] + Rank[row];
        }
        #endregion
    }
}
