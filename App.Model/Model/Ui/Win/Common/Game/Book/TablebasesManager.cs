
using System; using App.Model;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.IO;
using InfinitySettings.Streams;
using InfinitySettings.UCIManager;
using System.Configuration;
using System.Threading;

namespace App.Model
{
    // http://www.aarontay.per.sg/Winboard/egtb.html
    public partial class TablebasesManager 
    {
        #region Delegate / Events

        public event UCIEngine.MoveReceivedHandler EventMoveReceived;
        
        #endregion

        #region Data Members
        Books Books;
        bool moveFounded = false;
        public Game Game = null;
        #endregion
                
        #region Properties

        bool isClosed;
        public bool IsClosed { get { return isClosed; } }

        #endregion

        #region Ctor

        public TablebasesManager(Game game)
        {
            Game = game;
        }
        
        #endregion

        #region Load 

        public void Init()
        {
            ThreadStart s = new ThreadStart(DoInit);
            Thread t = new Thread(s);
            t.Start();
        }

        public void DoInit()
        {
            Books = new Books();
            LoadPaths();
        }

        private void LoadPaths()
        {
            LoadFiles(Ap.Options.TablebasesPath1);
            LoadFiles(Ap.Options.TablebasesPath2);
            LoadFiles(Ap.Options.TablebasesPath3);
            LoadFiles(Ap.Options.TablebasesPath4);
        }

        private void LoadFiles(string folderPath)
        {
            Book book;
            if (!string.IsNullOrEmpty(folderPath) && (Directory.Exists(folderPath)))
            {
                RemovePath(folderPath);
                string[] files = Directory.GetFiles(folderPath, "*" + Files.TablebasesExtension, SearchOption.TopDirectoryOnly);
                foreach (string filePath in files)
                {
                    if (File.Exists(filePath))
                    {
                        book = new Book(this.Game, filePath);
                        book.MoveReceived += new UCIEngine.MoveReceivedHandler(book_MoveReceived);
                        Books.Add(filePath, book);
                    }
                }
            }
        }

        #endregion

        #region Search Move 

        public void SearchMove(string fen)
        {
            moveFounded = false;
            foreach (Book book in Books.BookItems.Values)
            {
                book.SearchMove(fen);
                if (moveFounded)
                {
                    break;
                }
            }
            if (!moveFounded)
            {
                isClosed = true;
            }
        }
        
        #endregion

        #region Update BooksCollection

        public void Update()
        {
            ThreadStart s = new ThreadStart(LoadPaths);
            Thread t = new Thread(s);
            t.Start();
        }

        public void RemovePath(string folderPath)
        {
            string tempPath = string.Empty;
            foreach (string path in Books.BookItems.Keys)
            {
                tempPath = Path.GetDirectoryName(path);
                if (tempPath == folderPath)
                {
                    Books.Remove(path);
                }
            }
        }

        #endregion

        #region Events

        void book_MoveReceived(object sender, UCIMoveEventArgs e)
        {
            moveFounded = true;
            if (EventMoveReceived != null)
            {
                EventMoveReceived(this, e);
            }
        }
        
        #endregion

    }
}
