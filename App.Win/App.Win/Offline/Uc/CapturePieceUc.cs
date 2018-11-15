using System;
using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace InfinityChess
{
    public partial class CapturePieceUc : UserControl, IGameUc
    {
        #region DataMembers 

        public Game Game = null;

        public const string Guid = "80e5c0d8-1e8d-44e8-ade0-391690df89c3";
        private delegate void delAddRemovePicture(PictureBox item, bool isColor);

        private int bpiclocation = 0;
        private int wpiclocation = 0;
        int pieceWidth = 20;

        #endregion

        #region Ctor 
        public CapturePieceUc()
        {
            InitializeComponent();
        }
        #endregion

        #region Control Load 

        private void CapturePieceUc_Load(object sender, EventArgs e)
        {
        }

        #endregion

        #region Events

        void CapturePieces_PieceAddedEvent(object sender, EventArgs e)
        {
            UpdatePieces();
        }

        void CapturedPieces_UpdatePieces(object sender, EventArgs e)
        {
            UpdatePieces();
        }

        void CapturePieces_ClearEvent(object sender, EventArgs e)
        {
            Reset();
        }

        #endregion

        #region IGameUc Members

        public void NewGame()
        {
            Reset();
        }

        public void Init()
        {
            this.Game.CapturedPieces.UpdatePieces += new EventHandler(CapturedPieces_UpdatePieces);
            this.Game.CapturedPieces.PieceAddedEvent += new EventHandler(CapturePieces_PieceAddedEvent);
            this.Game.CapturedPieces.ClearEvent += new EventHandler(CapturePieces_ClearEvent);

            this.Game.CapturedPieces.MoveToEventE += new CapturedPieces.MoveToEventHandler(CapturedPieces_MoveToEventE);            
        }               

        public void UnInit()
        {
            this.Game.CapturedPieces.UpdatePieces -= new EventHandler(CapturedPieces_UpdatePieces);
            this.Game.CapturedPieces.PieceAddedEvent -= new EventHandler(CapturePieces_PieceAddedEvent);
            this.Game.CapturedPieces.ClearEvent -= new EventHandler(CapturePieces_ClearEvent);
            this.Game.CapturedPieces.MoveToEventE -= new CapturedPieces.MoveToEventHandler(CapturedPieces_MoveToEventE);            
        }
        #endregion

        #region Helper Methods

        public void UpdatePieces()
        {
            RemovePreviousPieces();
            AddNewPieces();
        }

        private PictureBox GetPiecePictureBox(Move m)
        {
            PictureBox pic = new PictureBox();
            pic.Tag = m.Id;

            switch (m.CapturedPiece)
            {
                case Pieces.WKING:
                    {
                        pic.Image = System.Drawing.Image.FromFile(Ap.FolderImages + "WhitePiecessmall\\" + "white_king.gif");
                        Point wpt = new Point(wpiclocation, 0);
                        pic.Width = pieceWidth;
                        pic.Height = pieceWidth;
                        pic.Location = wpt;
                        wpiclocation = wpiclocation + pieceWidth;
                        break;
                    }
                case Pieces.WQUEEN:
                    {
                        pic.Image = System.Drawing.Image.FromFile(Ap.FolderImages + "WhitePiecessmall\\" + "white_queen.gif");
                        Point wpt = new Point(wpiclocation, 0);
                        pic.Width = pieceWidth;
                        pic.Height = pieceWidth;
                        pic.Location = wpt;
                        wpiclocation = wpiclocation + pieceWidth;
                        break;
                    }
                case Pieces.WROOK:
                    {
                        pic.Image = System.Drawing.Image.FromFile(Ap.FolderImages + "WhitePiecessmall\\" + "white_rook.gif");
                        Point wpt = new Point(wpiclocation, 0);
                        pic.Width = pieceWidth;
                        pic.Height = pieceWidth;
                        pic.Location = wpt;
                        wpiclocation = wpiclocation + pieceWidth;
                        break;
                    }
                case Pieces.WBISHOP:
                    {
                        pic.Image = System.Drawing.Image.FromFile(Ap.FolderImages + "WhitePiecessmall\\" + "white_bishop.gif");
                        Point wpt = new Point(wpiclocation, 0);
                        pic.Width = pieceWidth;
                        pic.Height = pieceWidth;
                        pic.Location = wpt;
                        wpiclocation = wpiclocation + pieceWidth;
                        break;
                    }
                case Pieces.WKNIGHT:
                    {
                        pic.Image = System.Drawing.Image.FromFile(Ap.FolderImages + "WhitePiecessmall\\" + "white_knight.gif");
                        Point wpt = new Point(wpiclocation, 0);
                        pic.Width = pieceWidth;
                        pic.Height = pieceWidth;
                        pic.Location = wpt;
                        wpiclocation = wpiclocation + pieceWidth;

                        break;
                    }
                case Pieces.WPAWN:
                    {
                        pic.Image = System.Drawing.Image.FromFile(Ap.FolderImages + "WhitePiecessmall\\" + "white_pawn.gif");               //InfinitySettings.Settings.PiecesDesign.WhitePawn;
                        Point wpt = new Point(wpiclocation, 0);
                        pic.Width = pieceWidth;
                        pic.Height = pieceWidth;
                        pic.Location = wpt;
                        wpiclocation = wpiclocation + pieceWidth;

                        break;

                    }
                case Pieces.BKING:
                    {
                        pic.Image = System.Drawing.Image.FromFile(Ap.FolderImages + "BlackPiecessmall\\" + "black_king.gif");
                        Point bpt = new Point(bpiclocation, 0);
                        pic.Width = pieceWidth;
                        pic.Height = pieceWidth;
                        pic.Location = bpt;
                        bpiclocation = bpiclocation + pieceWidth;

                        break;
                    }
                case Pieces.BQUEEN:
                    {
                        pic.Image = System.Drawing.Image.FromFile(Ap.FolderImages + "BlackPiecessmall\\" + "black_queen.gif");
                        Point bpt = new Point(bpiclocation, 0);
                        pic.Width = pieceWidth;
                        pic.Height = pieceWidth;
                        pic.Location = bpt;
                        bpiclocation = bpiclocation + pieceWidth;

                        break;
                    }
                case Pieces.BROOK:
                    {
                        pic.Image = System.Drawing.Image.FromFile(Ap.FolderImages + "BlackPiecessmall\\" + "black_rook.gif");
                        Point bpt = new Point(bpiclocation, 0);
                        pic.Width = pieceWidth;
                        pic.Height = pieceWidth;
                        pic.Location = bpt;
                        bpiclocation = bpiclocation + pieceWidth;
                        break;
                    }
                case Pieces.BBISHOP:
                    {
                        pic.Image = System.Drawing.Image.FromFile(Ap.FolderImages + "BlackPiecessmall\\" + "black_bishop.gif");
                        Point bpt = new Point(bpiclocation, 0);
                        pic.Width = pieceWidth;
                        pic.Height = pieceWidth;
                        pic.Location = bpt;
                        bpiclocation = bpiclocation + pieceWidth;
                        break;
                    }
                case Pieces.BKNIGHT:
                    {
                        pic.Image = System.Drawing.Image.FromFile(Ap.FolderImages + "BlackPiecessmall\\" + "black_knight.gif");
                        Point bpt = new Point(bpiclocation, 0);
                        pic.Width = pieceWidth;
                        pic.Height = pieceWidth;
                        pic.Location = bpt;
                        bpiclocation = bpiclocation + pieceWidth;
                        break;
                    }
                case Pieces.BPAWN:
                    {
                        pic.Image = System.Drawing.Image.FromFile(Ap.FolderImages + "BlackPiecessmall\\" + "black_pawn.gif");
                        Point bpt = new Point(bpiclocation, 0);
                        pic.Width = pieceWidth;
                        pic.Height = pieceWidth;
                        pic.Location = bpt;
                        bpiclocation = bpiclocation + pieceWidth;
                        break;
                    }
                default:
                    break;
            }
            return pic;
        }

        private void AddPicture(PictureBox picbox, bool isWhite)
        {
            if (isWhite)
            {
                if (this.panelWhite.InvokeRequired)
                {
                    this.panelWhite.Invoke(new delAddRemovePicture(this.AddPicture), picbox, isWhite);
                }
                else
                {
                    picbox.SizeMode = PictureBoxSizeMode.StretchImage;
                    panelWhite.Controls.Add(picbox);
                }
            }
            else
            {
                if (this.panelBlack.InvokeRequired)
                {
                    this.panelBlack.Invoke(new delAddRemovePicture(this.AddPicture), picbox, isWhite);
                }
                else
                {
                    picbox.SizeMode = PictureBoxSizeMode.StretchImage;
                    panelBlack.Controls.Add(picbox);
                }                
            }
        }

        private void RemovePicture(PictureBox picbox, bool isColor)
        {
            if (isColor)
            {
                if (this.panelBlack.InvokeRequired)
                {
                    this.panelBlack.Invoke(new delAddRemovePicture(this.RemovePicture), picbox, isColor);
                }
                else
                {
                    panelBlack.Controls.Remove(picbox);
                }
            }
            else
            {
                if (this.panelWhite.InvokeRequired)
                {
                    this.panelWhite.Invoke(new delAddRemovePicture(this.RemovePicture), picbox, isColor);
                }
                else
                {
                    panelWhite.Controls.Remove(picbox);
                }
            }
        }

        private void Reset()
        {
            bpiclocation = 0;
            wpiclocation = 0;
            panelWhite.Controls.Clear();
            panelBlack.Controls.Clear();

            this.BackColor = System.Drawing.SystemColors.Control;
            panelWhite.BackColor = System.Drawing.SystemColors.Control;
            panelBlack.BackColor = System.Drawing.SystemColors.Control;
        }

        #endregion
    }


}
