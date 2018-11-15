using System; using App.Model;
using System.Collections.Generic;

using System.Text;
using InfinityChess;
using System.IO;
using InfinitySettings.Streams;

namespace App.Model
{
    public partial class Game
    {
        #region CapturedPieces

        public CapturedPieces CapturedPieces = new CapturedPieces();

        #endregion
    }
}
