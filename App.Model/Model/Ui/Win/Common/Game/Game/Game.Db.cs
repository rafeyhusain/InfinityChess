using System; 
using System.Collections.Generic;
using System.Text;
using InfinityChess;
using System.IO;
using InfinitySettings.Streams;
using App.Model;
using App.Model.Db;
using System.Data;
using System.Data.SqlClient;

namespace App.Model
{
    public partial class Game
    {
        #region Game

        #region Data Members
        public App.Model.Db.Game DbGame = null;
        #endregion

        #endregion
    }
}
