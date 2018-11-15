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
using App.Win;
using WeifenLuo.WinFormsUI.Docking;
using InfinityChess.WinForms;

namespace InfinityChess
{
    public partial class NotationViewerUc : UserControl
    {
        #region Data Members

        public App.Model.Db.Game DbGame = null;
        public int MoveID = 0;
        

        #endregion
        
        #region Ctor
        public NotationViewerUc()
        {                     
            InitializeComponent();
        }
        #endregion

        #region Events

        #region Load
        private void NotationUc_Load(object sender, EventArgs e)
        {            
            this.Focus();
        }

        #endregion
        
        #endregion

        #region Properties

        public int SelectedMoveID
        {
            get
            {
                return notationTextView1.SelectedMoveID;
            }
        }
        
        #endregion

        #region Helper
                
        #endregion

        #region Init

        public void Init()
        {
            Moves moves = new Moves(this.DbGame.GameXml);

            if (this.MoveID > 0)
            {
                moves.TruncateAfter(this.MoveID);
            }

            notationTextView1.AddMoves(moves);

            notationTextView1.OnMoveSelect += new EventHandler(notationTextView1_OnMoveSelect);
        }
        
        void notationTextView1_OnMoveSelect(object sender, EventArgs e)
        {
            
        }
        
        #endregion

    }
}