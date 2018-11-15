using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FullScreenMode;
using App.Model;
using InfinityChess.Offline.Forms;
using InfinitySettings.EngineManager;
using System.Diagnostics;
using Crom.Controls.Docking;

namespace InfinityChess.WinForms
{
    public partial class MainOffline : MainForm
    {

        #region Navigation Click Events

        private void MoveToFirst_Click(object sender, EventArgs e)
        {
            base.Game.MoveTo(MoveToE.First);
           // NotationUc.SetSelection(); 
        }

        private void PrevMove_Click(object sender, EventArgs e)
        {
            base.Game.MoveTo(MoveToE.Previous);
        }

        private void tsbRetractLastMoveOverwrite_Click(object sender, EventArgs e)
        {            
            base.Game.RetracMove();
        }

        private void NextMove_Click(object sender, EventArgs e)
        {
            base.Game.MoveTo(MoveToE.Next);
        }

        private void MoveToLast_Click(object sender, EventArgs e)
        {
            base.Game.MoveTo(MoveToE.Last);
        }

        #endregion

        #region PositionSetup
        private void positionSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!App.Win.frmGameResult.AdjudicateGame(base.Game))
            {
                return;
            }

            App.Win.PositionSetup frm = new App.Win.PositionSetup(base.Game, this);

            if (frm.ShowDialog() == DialogResult.OK)
            {                
                base.Game.NewGame(frm.Fen, base.Game.GameMode, base.Game.GameType);                
            }
        }
        #endregion
    }

}
