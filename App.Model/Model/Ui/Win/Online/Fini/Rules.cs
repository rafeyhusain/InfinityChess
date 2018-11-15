using System;
using System.Collections.Generic;
using System.Text;
using App.Model.Db;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace App.Model
{
    #region enum
    public enum FiniRuleE
    {
        None = 0,
        RankQueenKing = 1,
        BishopHigher = 2,
        BishopHigherEven = 3
    }

    #endregion

    public class Rules
    {
         #region Data Members
        public int GameID = 0;
        #endregion

        #region Constructor

        public Rules()
        {

        }

        public Rules(App.Model.Db.Game game)
        {
            
        }

        public Rules(int gameID)
        {
            GameID = gameID;
        }


        #endregion

        #region Contained Classes

        User user = null;
        public User User { get { return user; } set { user = value; } }
        #endregion

        #region Methods

        #region Public Methods
        
        
        #endregion

        #region Private Methods
        
        #endregion

        #endregion
    }
}
