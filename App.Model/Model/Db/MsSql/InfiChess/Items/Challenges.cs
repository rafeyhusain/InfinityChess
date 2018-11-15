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
    public class Challenges : BaseItems<Challenge, Challenges>
    {
        #region Constructors
        public Challenges()
        {
        }

        public Challenges(Cxt cxt)
        {
            Cxt = cxt;
        }

        public Challenges(Cxt cxt, BaseCollection items)
        {
            Cxt = cxt;

            DataTable = items.DataTable;
        }

        public Challenges(Cxt cxt, DataTable table)
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
        public static DataTable GetChallengesByRoomID(Cxt cxt, int roomID, int userID)
        {
            return BaseCollection.Execute("GetChallengesByRoomID", roomID, userID);
        }

        public static void UpdateAllChallenges(SqlTransaction t, int challengeID, int currentUserID, int ChallengerUserID)
        {
            BaseCollection.Execute(t, "UpdateAllChallengesByID", challengeID, currentUserID, ChallengerUserID);
        }

        public static void UpdateChallengesStatus(SqlTransaction t, int userID)
        {
            BaseCollection.ExecuteSql(t, InfiChess.Challenge, "UPDATE Challenge SET StatusID = 4 WHERE StatusID = 1 AND ChallengerUserID = @p1 AND TournamentMatchID IS NULL", userID);
        }

        static int GetRoomIDByTournament(int tournamentID)
        {
            Room RoomItem = Room.GetRoomByTournamentID(Cxt.Instance, tournamentID);
            return RoomItem.RoomID;
        }

        #endregion
    }
}
