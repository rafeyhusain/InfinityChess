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
using System.Diagnostics;
namespace App.Model.Db 
{
    public class Games : BaseItems<Game, Games>
	{
        #region Constructors
        public Games()
        {
        }

        public Games(Cxt cxt)
        {
            Cxt = cxt;
        }

        public Games(Cxt cxt, BaseCollection items)
        {
            Cxt = cxt;

            DataTable = items.DataTable;
        }

        public Games(Cxt cxt, DataTable table)
        {
            Cxt = cxt;

            DataTable = table;
        }

        #endregion

        #region Properties
        #region Core
        public override InfiChess TableName
        {
            [DebuggerStepThrough]
            get { return InfiChess.Game; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }
        #endregion
        #endregion

        #region Methods
        public static DataTable GetGamesByRoomID(Cxt cxt, int roomID)
        {
            return BaseCollection.Execute("GetGamesByRoomID", roomID);
        }

        public static DataTable GetGamesByUserID(Cxt cxt, int userID)
        {
            return BaseCollection.Execute("GetGamesByUserID", userID);
        }

        public static DataTable GetGamesByUserName(Cxt cxt, string userName)
        {
            User user = User.GetUser(cxt, userName);
            return BaseCollection.Execute("GetGamesByUserID", user.UserID);
        }

        public static DataTable GetAllGamesByTournamentID(Cxt cxt, int tournamentID)
        {            
            return BaseCollection.Execute("GetAllGamesByTournamentID", tournamentID);
        }

        public static void UpdateGameStatusWithTournamentMatchID(Cxt cxt, SqlTransaction trans, string gameIDs, GameResultE gameResultID)
        {

            BaseCollection.Execute(trans, "UpdateGameStatusWithTournamentMatchID",
                                        gameIDs, gameResultID.ToString("d"),
                                        cxt.CurrentUserID, DateTime.Now);
        }
        
        
        #endregion
    }
}
