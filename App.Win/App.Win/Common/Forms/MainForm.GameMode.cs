using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ChessLibrary;
using InfinitySettings.UCIManager;
using InfinitySettings.EngineManager;
using App.Model;

using InfinityChess.Offline.Forms;

namespace InfinityChess.WinForms
{
    public partial class MainForm
    {
        #region New Game

       
        public void StartGame()
        {
            if (ChessBoardUc.Flipped)
                FlipBoard();

            CreateDockWindow();

            if (Ap.Game.DefaultEngine != null)
            {
                if (Ap.Game.DefaultEngine.IsClosed)
                {
                    Ap.Game.DefaultEngine.Load();
                }
            }

            this.RefreshGameInfo();

            Ap.Game.Flags.IsEngineBlack = true;

            if (Ap.Game.GameMode == GameMode.HumanVsEngine)
            {
                InitSpaceBarTimer();
            }
        }

        #endregion
    }
}
