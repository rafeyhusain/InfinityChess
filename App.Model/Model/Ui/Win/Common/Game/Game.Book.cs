using System; using App.Model;
using System.Collections.Generic;
using System.Text;
using InfinityChess;
using System.IO;
using InfinitySettings.Streams;
//using InfinityChess.Offline.Forms;
using InfinitySettings.BookOptionsManager;

namespace App.Model
{
    public partial class Game
    {
        #region Data Members

        private BookData bookData;
        public BookData BookData
        {
            get { return bookData; }            
        }


        public Book Book;
        
        #endregion
        
        #region Load/Save

        //public void LoadBook(string fileName)
        //{
        //    if (BeforeLoadOpeningBook != null)
        //    {
        //        BeforeLoadOpeningBook(this, EventArgs.Empty);
        //    }

        //    Book = new Book(fileName);

        //    if (System.IO.File.Exists(Book.FilePath))
        //    {   
        //        GlobalSet.Default.CurrentOpeningBookFile = Book.FileName;
        //    }

        //    if (AfterLoadOpeningBook != null)
        //    {
        //        AfterLoadOpeningBook(this, EventArgs.Empty);
        //    }
        //}
        
        public void SaveBook()
        {
            Book.Save();
        }

        #endregion                

    }
}
