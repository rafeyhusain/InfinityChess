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
    public partial class NotationUc
    {
        void Notations_MoveToEventE(MoveToE moveTo)
        {
            SetSelection(this.Game.CurrentMove);
        }

        void Notations_MoveToEvent(object sender, EventArgs e)
        {
            SetSelection(this.Game.CurrentMove);
        }

        void Game_SelectCurrentMoveChildren(object sender, App.Model.Game.SelectCurrentMoveChildrenEventArgs e)
        {
            frmInsertNewVariation frm = new frmInsertNewVariation(this.Game);            
            frm.IsVariation = false;

            frm.ParentMove = e.Move;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                e.Move = frm.SelectedMove;
            }
        }

        private void MoveToNext()
        {
            Moves children = this.Game.Moves.GetChildren(this.Game.CurrentMove);

            Move m = null;

            if (children.Count > 1)
            {
                frmInsertNewVariation frm = new frmInsertNewVariation(this.Game);                
                frm.IsVariation = false;

                frm.ParentMove = this.Game.CurrentMove;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    m = frm.SelectedMove;
                }
            }
            else
            {
                m = children[0];
            }
        }

    }
}