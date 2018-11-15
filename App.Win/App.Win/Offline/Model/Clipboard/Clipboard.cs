using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Model;
using InfinityChess.WinForms;

namespace App.Win
{
    class Clipboard
    {
        public static void CopyPosition(string fenNotation)
        {
            //string fenNotation = ApWin.MainForm.ChessBoardUc.GetFen();
            fenNotation = ChessLibrary.FenParser.ResetMoveCounter(fenNotation);
            System.Windows.Forms.Clipboard.SetText(fenNotation);
        }

        public static void PastePosition(Game game)
        {
            string fenNotation = System.Windows.Forms.Clipboard.GetText();

            if (game.GameValidator.IsValidFen(fenNotation))
            {
                game.NewGame(fenNotation, game.GameMode, game.GameType);
            }
        }
    }
}

namespace App.Win
{
    class ApWin
    {
        #region InfinityGlobal
        #region Properties
        private static bool _showUserProfile = false;
        public static bool ShowUserProfile
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ApWin._showUserProfile; }
            [System.Diagnostics.DebuggerStepThrough]
            set { ApWin._showUserProfile = value; }
        }
        #endregion

        #region Forms

        //static InfinityChess.WinForms.MainForm mainForm;
        //public static InfinityChess.WinForms.MainForm MainForm
        //{
        //    get { return mainForm; }
        //    set { mainForm = value; }
        //}

        static App.Win.OnlineClient _onlineClientForm;
        public static App.Win.OnlineClient OnlineClientForm
        {
            get { return _onlineClientForm; }
            set { _onlineClientForm = value; }
        }

        static InfinityChess.Winforms.Startup _startupForm;
        public static InfinityChess.Winforms.Startup StartupForm
        {
            get { return _startupForm; }
            set { _startupForm = value; }
        }
        #endregion
        #endregion
    }
}
