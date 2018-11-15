using System; 
using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace App.Win
{
    public partial class BookOptionsPopup : BaseWinForm
    {
        #region DataMembers 

        public Game Game = null;
        BookOptions bookOptions;               

        #endregion
        
        #region Ctor + Load 
        
       public BookOptionsPopup(Game game)
       {
           this.Game = game;
           InitializeComponent();
           LoadBookOptions();
       }

       public BookOptionsPopup(BookOptions bookOptions, Game game)
        {
            this.Game = game;
            InitializeComponent();
            this.bookOptions = bookOptions;
        }

        private void BookOptionsPopup_Load(object sender, EventArgs e)
        {
            FillBookData(bookOptions.OptionsType);
        }
        
        #endregion

        #region Properties 

        bool HasGame
        {
            get { return this.Game != null; }
        }

        #endregion

        #region Helper Methods

        private void LoadBookOptions()
        {
            if (bookOptions == null)
            {
                bookOptions = new BookOptions(BookOptionsType.Global);
            }
        }

        private void FillBookData(BookOptionsType type)
        {
            switch (type)
            {
                case BookOptionsType.Global:
                    chkUseBook.Checked = bookOptions.UseBook;
                    chkTournamentBook.Checked = bookOptions.TournamentBook;
                    numericMinimumGame.Value = bookOptions.MinGames;
                    numericUpToMove.Value = bookOptions.MaxMoves;
                    break;
                case BookOptionsType.WhiteEngine:
                    chkUseBook.Checked = bookOptions.WhiteUseBook;
                    chkTournamentBook.Checked = bookOptions.WhiteTournamentBook;
                    numericMinimumGame.Value = bookOptions.WhiteMinGames;
                    numericUpToMove.Value = bookOptions.WhiteMaxMoves;
                    break;
                case BookOptionsType.BlackEngine:
                    chkUseBook.Checked = bookOptions.BlackUseBook;
                    chkTournamentBook.Checked = bookOptions.BlackTournamentBook;
                    numericMinimumGame.Value = bookOptions.BlackMinGames;
                    numericUpToMove.Value = bookOptions.BlackMaxMoves;
                    break;
                case BookOptionsType.Optimize:
                    chkUseBook.Checked = bookOptions.OptimizeUseBook;
                    chkTournamentBook.Checked = bookOptions.OptimizeTournamentBook;
                    numericMinimumGame.Value = bookOptions.OptimizeMinGames;
                    numericUpToMove.Value = bookOptions.OptimizeMaxMoves;
                    break;
                case BookOptionsType.Normal:
                    chkUseBook.Checked = bookOptions.NormalUseBook;
                    chkTournamentBook.Checked = bookOptions.NormalTournamentBook;
                    numericMinimumGame.Value = bookOptions.NormalMinGames;
                    numericUpToMove.Value = bookOptions.NormalMaxMoves;
                    break;
                case BookOptionsType.Handicap:
                    chkUseBook.Checked = bookOptions.HandicapUseBook;
                    chkTournamentBook.Checked = bookOptions.HandicapTournamentBook;
                    numericMinimumGame.Value = bookOptions.HandicapMinGames;
                    numericUpToMove.Value = bookOptions.HandicapMaxMoves;
                    break;
                default:
                    break;
            }
        }

        private void SaveBookOptionInfo()
        {
            bookOptions.UseBook = chkUseBook.Checked;
            bookOptions.TournamentBook = chkTournamentBook.Checked;

            bookOptions.MinGames = Convert.ToInt32(numericMinimumGame.Value);
            bookOptions.MaxMoves = Convert.ToInt32(numericUpToMove.Value);
            bookOptions.Save();
        }

        #endregion

        #region Events

        private void btnOptimize_Click(object sender, EventArgs e)
        {
            FillBookData(BookOptionsType.Optimize);
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            FillBookData(BookOptionsType.Normal);
        }

        private void btnHandicap_Click(object sender, EventArgs e)
        {
            FillBookData(BookOptionsType.Handicap);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveBookOptionInfo();
            if (HasGame)
            {
                this.Game.Book.SetOptions(bookOptions);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        public override string HelpTopicId
        {
            get { return "20"; }
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            Ap.Help(this, HelpTopicIdE.BookOptionsPopup);
        }

        #endregion

    }
}
