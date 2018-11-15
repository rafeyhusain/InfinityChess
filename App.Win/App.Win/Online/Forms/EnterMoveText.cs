using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InfinityChess.InfinityChesshelp;
using App.Model;

namespace App.Win
{
    public partial class EnterMoveText : BaseWinForm
    {
        #region DataMembers 

        public Game Game = null;
        public bool IsTextBeforeMove = false;

        #endregion

        #region Ctor

        public EnterMoveText(Game game)
        {
            this.Game = game;
            InitializeComponent();
        }

        #endregion
        
        #region Properties 
        
        public string Comments
        {
            get { return richTextBox1.Text; }
            set { richTextBox1.Text = value; }
        }

        #endregion

        #region Load 
                
        private void EnterMoveText_Load(object sender, EventArgs e)
        {
            if (IsTextBeforeMove)
            {
                this.Text = "Enter text before move";
            }
            else
            {
                this.Text = "Enter text after move";
            }
        }

        #endregion

        #region Overrides 

        public override string HelpTopicId
        {
            get { return "170"; }
        }

        #endregion


        #region Events 

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Ap.Help(this, HelpTopicIdE.EnterMoveText);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            this.Close();
        }

        #endregion

        #region Static
                
        internal static void Open(bool isTextBeforeMove, Game game)
        {
            try
            {
                EnterMoveText frm = new EnterMoveText(game);
                frm.IsTextBeforeMove = isTextBeforeMove;

                if (isTextBeforeMove)
                {
                    frm.Comments = game.CurrentMove.MoveComments[MoveCommentTypeE.Before];
                }
                else
                {
                    frm.Comments = game.CurrentMove.MoveComments[MoveCommentTypeE.After] + " " + game.CurrentMove.ExpectedMove;
                }
                
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    game.SetComments(frm.Comments, isTextBeforeMove);
                }

                game.Notations.SetNotationView(game.CurrentMove);
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }

        #endregion

    }
}
