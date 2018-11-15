using System;
using App.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfinityChess;
using System.IO;
using InfinitySettings.Streams;
using ChessBoardCtrl.New;
using InfinitySettings.UCIManager;
using System.Data;

namespace App.Model
{
    public partial class Game
    {
        #region Data Members 

        #endregion
    
        #region Properties 

        #endregion

        #region Methods 

        public void SetCurrentPlayerHuman()
        {
            if (Player1.PlayerType == PlayerType.Human)
            {
                Player1.Active = true;
                Player2.Active = false;
                CurrentPlayer = Player1;
            }
            else if (Player2.PlayerType == PlayerType.Human)
            {
                Player1.Active = false;
                Player2.Active = true;
                CurrentPlayer = Player2;
            }
        }


        #endregion

    }
}
