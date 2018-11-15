using System;
using App.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfinityChess;
using System.IO;
using InfinitySettings.Streams;

using InfinitySettings.UCIManager;
using System.Data;
using System.Diagnostics;

namespace App.Model
{
    public class PlayingMode
    {
        #region Data Members        
        public UCIEngine SelectedEngine;
        public Book SelectedBook;
        public int ChessTypeID;
        #endregion

        #region Ctor

        public PlayingMode()
        {

        }
        #endregion

        #region Instance
        private static PlayingMode instance = null;
        public static PlayingMode Instance
        {
            [DebuggerStepThrough]
            get
            {
                if (instance == null)
                {
                    instance = new PlayingMode();
                }
                return instance;
            }
            [DebuggerStepThrough]
            set { instance = value; }
        }
        #endregion  
    }
}
