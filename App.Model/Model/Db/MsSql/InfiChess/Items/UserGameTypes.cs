// (c) Copyright RafeySoft, Karachi Pakistan. http://rafeysoft.com
// This source is subject to following License:
// http://rafeysoft.com/Web/Page/ItemEdit.aspx?sid=29&lid=4&cid=23&iid=2143
// Please write to info@rafeysoft.com for more information
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace App.Model.Db 
{
    public class UserGameTypes : BaseItems<UserGameType, UserGameTypes>
	{
        #region Constructors
        public UserGameTypes()
        {
        }

        public UserGameTypes(Cxt cxt)
        {
            Cxt = cxt;
        }

        public UserGameTypes(Cxt cxt, BaseCollection items)
        {
            Cxt = cxt;

            DataTable = items.DataTable;
        }

        public UserGameTypes(Cxt cxt, DataTable table)
        {
            Cxt = cxt;

            DataTable = table;
        }

        #endregion

        #region Properties
      
        #endregion

        #region Methods
        public static DataTable GetUsersGameRating(Cxt cxt, int GameTypeID, int UserId1, int UserId2)
        {
            DataTable table = BaseCollection.ExecuteSql("select * from [UserGameType] where GameTypeID = '" + GameTypeID + "' and UserID IN ( '" + UserId1 + "','" + UserId2 + "')");
            return table;
        }

        public static DataTable GetUsersGameRating(Cxt cxt, int chessTypeID, int gameTypeID, int whiteUserID, int blackUserID)
        {
            DataTable table = BaseCollection.ExecuteSql("select * from [UserGameType] where ChessTypeID = '" + chessTypeID + "' AND GameTypeID = '" + gameTypeID + "' and UserID IN ( '" + whiteUserID + "','" + blackUserID + "')");
            return table;
        }

        public static UserGameTypes GetUsersGameRating(Cxt cxt, int chessTypeID, int gameTypeID, string userIDs)
        {
            return new UserGameTypes(cxt, BaseCollection.Execute("GetUsersGameRating", chessTypeID, gameTypeID, userIDs));
            
            
        }

        #endregion
    }
}
