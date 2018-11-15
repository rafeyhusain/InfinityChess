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

namespace App.Model
{
    public class PlayingMode
    {
        #region Data Members
        public Game Game = null;
        public UCIEngine SelectedEngine;
        public Book SelectedBook;
        public int ChessTypeID;
        #endregion

        #region Ctor

        public PlayingMode(Game game)
        {
            this.Game = game;
        }
        #endregion
    }
}
