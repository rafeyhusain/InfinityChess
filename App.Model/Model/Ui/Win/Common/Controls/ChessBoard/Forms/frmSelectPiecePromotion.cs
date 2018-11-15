using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using App.Model;

namespace App.Win
{
    public partial class frmSelectPiecePromotion : Form
    {
        #region DataMember
        public Game Game = null;       
        Pieces piece;        
        #endregion

        #region Property

        public Pieces PrmotedPiece
        {
            get
            {
                return piece;
            }
            set
            {
                piece = value;
            }
        }       

        #endregion

        bool color = false;
       
        public frmSelectPiecePromotion(Game game, bool isColor)
        {
            color = isColor;
            InitializeComponent();
            this.Game = game;
        }

        private void btnQueen_Click(object sender, EventArgs e)
        {
            if (color)
            {
                piece = Pieces.BQUEEN;               
            }
            else
            {
                piece = Pieces.WQUEEN;                
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnRook_Click(object sender, EventArgs e)
        {
            if (color)
            {
                piece = Pieces.BROOK;                
            }
            else
            {
                piece = Pieces.WROOK;                
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnBishop_Click(object sender, EventArgs e)
        {
            if (color)
            {
                piece = Pieces.BBISHOP;                
            }
            else
            {
                piece = Pieces.WBISHOP;                
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnKnight_Click(object sender, EventArgs e)
        {
            if (color)
            {
                piece = Pieces.BKNIGHT;                
            }
            else
            {
                piece = Pieces.WKNIGHT;                
            }
            
            this.DialogResult = DialogResult.OK;
        }

        private void frmSelectPiecePromotion_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void frmSelectPiecePromotion_Load(object sender, EventArgs e)
        {
            if (color)
            {
                btnQueen.Image = Image.FromFile(Ap.FolderPiecesImages + PiecesImagesFiles.black_queen);
                btnRook.Image = Image.FromFile(Ap.FolderPiecesImages + PiecesImagesFiles.black_rook);
                btnBishop.Image = Image.FromFile(Ap.FolderPiecesImages + PiecesImagesFiles.black_bishop);
                btnKnight.Image = Image.FromFile(Ap.FolderPiecesImages + PiecesImagesFiles.black_knight);
            }
            else
            {
                btnQueen.Image = Image.FromFile(Ap.FolderPiecesImages + PiecesImagesFiles.white_queen);
                btnRook.Image = Image.FromFile(Ap.FolderPiecesImages + PiecesImagesFiles.white_rook);
                btnBishop.Image = Image.FromFile(Ap.FolderPiecesImages + PiecesImagesFiles.white_bishop);
                btnKnight.Image = Image.FromFile(Ap.FolderPiecesImages + PiecesImagesFiles.white_knight);
            }
        }

        

        public static Pieces GetPromotedPiece(Control parent, Game game, Move m, bool isColor)
        {
            Pieces promotePiece = Pieces.NONE;

            if (game.Flags.IsEngineMove)
            {
                if (isColor)
                {
                    promotePiece = Pieces.BQUEEN;
                }
                else
                {
                    promotePiece = Pieces.WQUEEN;
                }
            }
            else
            {
                frmSelectPiecePromotion frm = new frmSelectPiecePromotion(game, isColor);

                if (frm.ShowDialog(parent) == DialogResult.OK)
                {
                    promotePiece = (Pieces)frm.PrmotedPiece;
                }

                if (promotePiece == Pieces.NONE)
                {
                    if (isColor)
                    {
                        promotePiece = Pieces.BQUEEN;
                    }
                    else
                    {
                        promotePiece = Pieces.WQUEEN;
                    }
                }     
            }

            m.Piece = promotePiece;

            return promotePiece;
        }
    }
}
