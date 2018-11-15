using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using App.Model;
using WeifenLuo.WinFormsUI.Docking;

namespace App.Win
{
    public partial class ChessBoard : DockContent, IGameUc
    {
        #region DataMembers 
        
        public const string Guid = "76ee1c55-a061-428c-b751-1f8dfbf4db51";
        public Game Game = null;

        #endregion

        #region Properties 
        private ChessBoardUc chessBoardUc1;
        public ChessBoardUc ChessBoardUc
        {
            get
            {
                return this.chessBoardUc1;
            }
        }
        #endregion

        #region Ctor & Load 

        public ChessBoard(Game game)
        {
            this.Game = game;
            InitializeComponent();
            InitChessBoardUc();
        }

        private void ChessBoard_Load(object sender, EventArgs e)
        {
            bool isFlipped = chessBoardUc1.Flipped;
            flipToolStripMenuItem.Checked = isFlipped;
        }

        #endregion

        #region Context Menu Events 
                
        private void flipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isFlipped = chessBoardUc1.Flipped;
            chessBoardUc1.Flipped = !isFlipped;
            flipToolStripMenuItem.Checked = !isFlipped;
        }

        private void boardDesignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowBoardDesignPopup(this);
        }

        public void ShowBoardDesignPopup(IWin32Window owner)
        {
            BoardDesignPopup boardDesignPopup = new BoardDesignPopup();
            boardDesignPopup.ApplyDesign += new EventHandler(BoardDesignPopup_ApplyDesign);
            boardDesignPopup.ShowDialog(owner);
        }

        public static void ShowBoardDesignPopupOnline(IWin32Window owner)
        {
            BoardDesignPopup boardDesignPopup = new BoardDesignPopup();
            boardDesignPopup.ShowDialog(owner);
        }

        #endregion

        #region Helper Methods 

        private void InitChessBoardUc()
        {
            Dock = DockStyle.Fill;
            pnlBackground.Controls.Clear();
            System.Windows.Forms.Integration.ElementHost elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            chessBoardUc1 = new ChessBoardUc(this.Game);
            elementHost1.Child = chessBoardUc1;
            elementHost1.Dock = DockStyle.Fill;
            pnlBackground.Controls.Add(elementHost1);

            SetBackground();
        }

        public void BoardDesignPopup_ApplyDesign(object sender, EventArgs e)
        {
            chessBoardUc1.SetCurrentTheme();
            SetBackground();
        }
        
        private void SetBackground()
        {
            pnlBackground.BackColor = Color.Transparent;

            if (Ap.BoardTheme.IsBoardBackgroundImageAvailable)
            {
                pnlBackground.BackgroundImage = Image.FromFile(Ap.BoardTheme.BoardBackgroundImagePath);
            }
            else
            {
                pnlBackground.BackColor = ColorTranslator.FromHtml(Ap.BoardTheme.BoardBackgroundColor);
            }
        }

        public void SaveAsBitmap(string fileName)
        {
            //getthe instance of the graphics from the control
            Graphics g = pnlBackground.CreateGraphics();

            //new bitmap object to save the image
            Bitmap bmp = new Bitmap(pnlBackground.Width, pnlBackground.Height);

            //Drawing control to the bitmap            
            pnlBackground.DrawToBitmap(bmp, new Rectangle(pnlBackground.Location.X, pnlBackground.Location.Y, pnlBackground.Width, pnlBackground.Height));
            bmp.Save(fileName);
            bmp.Dispose();
        }

        #endregion               

        #region IGameUc Members

        public void NewGame()
        {
            chessBoardUc1.NewGame();
        }

        public void Init()
        {
            chessBoardUc1.Init();
        }

        public void UnInit()
        {
            chessBoardUc1.UnInit();
        }

        #endregion

        #region Overrrides

        protected override string GetPersistString()
        {
            return Guid;
        }

        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {   
                case Keys.Left:
                    return true;
                case Keys.Right:
                    return true;
                case Keys.Up:
                    return true;
                case Keys.Down:
                    return true;
                default:
                    break;
            }
            return false;            
        }

        #endregion
    }
}
