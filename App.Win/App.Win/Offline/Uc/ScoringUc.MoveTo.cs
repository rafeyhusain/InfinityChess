using System;
using App.Model;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ChessLibrary;
using InfinityChess.Offline.Forms;

namespace InfinityChess
{
    public partial class ScoringUc 
    {
        void Scoring_MoveToEventE(MoveToE moveTo)
        {
            SetSelection(this.Game.CurrentMove);
        }

        void Scoring_MoveToEvent(object sender, EventArgs e)
        {
            SetSelection(this.Game.CurrentMove);
        }  
    }
}