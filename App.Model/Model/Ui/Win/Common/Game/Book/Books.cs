using System; using App.Model;
using System.Collections.Generic;

using System.Text;

using System.Data;
using System.IO;
using InfinitySettings.Streams;
using InfinitySettings.UCIManager;
using System.Configuration;

namespace App.Model
{
    // http://chessprogramming.wikispaces.com/Opening+Book
    // http://chessprogramming.wikispaces.com/Zobrist+Hashing
    public partial class Books 
    {
        #region Data Members

         public Dictionary<string, Book> BookItems ;
        
        #endregion

        #region Ctor

        public Books()
        {
            BookItems = new Dictionary<string,Book>();
        }
        
        #endregion

        #region Helpers

        public void Add(string path, Book book)
        {
            if (!BookItems.ContainsKey(path))
            {
                BookItems.Add(path, book);
            }
        }

        public void Remove(string path)
        {
            if (!BookItems.ContainsKey(path))
            {
                BookItems.Remove(path);
            }
        }

        #endregion

    }
}
