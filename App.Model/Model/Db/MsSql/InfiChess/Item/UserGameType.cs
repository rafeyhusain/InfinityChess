// (c) Copyright RafeySoft, Karachi Pakistan. http://rafeysoft.com
// This source is subject to following License:
// http://rafeysoft.com/Web/Page/ItemEdit.aspx?sid=29&lid=4&cid=23&iid=2143
// Please write to info@rafeysoft.com for more information
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using System.Diagnostics;
namespace App.Model.Db
{
    public class UserGameType : BaseItem
    {
        #region Constructor
        public UserGameType()
            : base(0)
        {
        }

        public UserGameType(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public UserGameType(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public UserGameType(Cxt cxt, DataRow row)
        {
            Cxt = cxt;
            DataRow = row;
        }
        #endregion

        #region Properties

        #region Core
        public override InfiChess TableName
        {
            [DebuggerStepThrough]
            get { return InfiChess.UserGameType; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion

        #region Enum
        public ChessTypeE ChessTypeIDE { [DebuggerStepThrough]get { return (ChessTypeE)this.ChessTypeID; } [DebuggerStepThrough]set { this.ChessTypeID = (int)value; } }
        #endregion

        #region Generated
        public int UserGameTypeID { [DebuggerStepThrough] get { return GetColInt32("UserGameTypeID"); } [DebuggerStepThrough] set { SetColumn("UserGameTypeID", value); } }
        public int UserID { [DebuggerStepThrough]get { return GetColInt32("UserID"); } [DebuggerStepThrough] set { SetColumn("UserID", value); } }
        public int GameTypeID { [DebuggerStepThrough] get { return GetColInt32("GameTypeID"); } [DebuggerStepThrough] set { SetColumn("GameTypeID", value); } }
        public int ChessTypeID { [DebuggerStepThrough] get { return GetColInt32("ChessTypeID"); } [DebuggerStepThrough] set { SetColumn("ChessTypeID", value); } }
        public int NoOfGames { [DebuggerStepThrough] get { return GetColInt32("NoOfGames"); } [DebuggerStepThrough] set { SetColumn("NoOfGames", value); } }
        public int EloRating { [DebuggerStepThrough] get { return GetColInt32("EloRating"); } [DebuggerStepThrough] set { SetColumn("EloRating", value); } }
        public int StoredMatches { [DebuggerStepThrough] get { return GetColInt32("StoredMatches"); } [DebuggerStepThrough] set { SetColumn("StoredMatches", value); } }
        #endregion        

        #region Contained Classes
        
        #endregion

        #endregion
        
        #region Methods

        #region GetUserGameRating
        
        public static UserGameType GetUserGameRating(Cxt cxt, int chessTypeID, int gameTypeID, int userID)
        {
            DataTable table = BaseCollection.ExecuteSql(InfiChess.UserGameType, "SELECT TOP 1 * FROM [UserGameType] WHERE ChessTypeID = @p1 AND GameTypeID = @p2 AND UserID = @p3", chessTypeID, gameTypeID, userID);
            UserGameType userGameType = null;

            if (table.Rows.Count > 0)
            {
                userGameType = new UserGameType(cxt, table.Rows[0]);
            }
            else
            {
                //userGameType = null;
                userGameType = new UserGameType();
                userGameType.UserID = userID;
                userGameType.GameTypeID = gameTypeID;
                userGameType.ChessTypeID = chessTypeID;
                userGameType.NoOfGames = 0;
                userGameType.StoredMatches = 0;
                if (chessTypeID == (int)ChessTypeE.Human)
                {
                    userGameType.EloRating = 1500;
                }
                else
                {
                    userGameType.EloRating = 2200;
                }
            }

            return userGameType;
        }

        public static UserGameType GetUserCentaurGameRating(Cxt cxt, int chessTypeID, int gameTypeID, int userID)
        {
            DataTable table = BaseCollection.ExecuteSql(InfiChess.UserGameType, "select * from [UserGameType] where ChessTypeID = @p1 AND UserID = @p2", chessTypeID, userID);
            UserGameType userGameType = null;

            if (table.Rows.Count > 0)
            {
                userGameType = new UserGameType(cxt, table.Rows[0]);
            }
            else
            {
                //userGameType = null;
                userGameType = new UserGameType();
                userGameType.UserID = userID;
                userGameType.ChessTypeID = chessTypeID;
                userGameType.GameTypeID = gameTypeID;
                userGameType.NoOfGames = 0;
                userGameType.StoredMatches = 0;
                if (chessTypeID == (int)ChessTypeE.Human)
                {
                    userGameType.EloRating = 1500;
                }
                else
                {
                    userGameType.EloRating = 2200;
                }
            }

            return userGameType;
        }

        #endregion

        #endregion

    }
}
