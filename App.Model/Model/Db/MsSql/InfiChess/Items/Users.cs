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
    public class Users : BaseItems<User, Users>
    {
        #region Constructors
        public Users()
        {
        }

        public Users(Cxt cxt)
        {
            Cxt = cxt;
        }

        public Users(Cxt cxt, BaseCollection items)
        {
            Cxt = cxt;

            DataTable = items.DataTable;
        }

        public Users(Cxt cxt, DataTable table)
        {
            Cxt = cxt;

            DataTable = table;
        }

        #endregion

        #region Properties
        #region Core
        public override InfiChess TableName
        {
            get { return InfiChess.User; }
            set { base.TableName = value; }
        }
        #endregion
        #endregion

        #region Methods
        #region GetUsers
        public static DataTable GetAllUser()
        {
            DataTable table = BaseCollection.ExecuteSql("SELECT UserID, UserName FROM [User] WHERE UserStatusID IN (1,3,5,6) AND StatusID = 1");
            return table;
        }

        public static DataTable GetAllUser(int roomId)
        {
            return BaseCollection.Execute("GetUsersByRoomID", roomId);
        }

        public static DataTable GetUserIdsByRoomID(Cxt cxt, int roomId)
        {
            DataTable table = BaseCollection.ExecuteSql("SELECT UserID, UserName FROM [User] where RoomID = " + roomId + " AND UserStatusID IN (1,3,5,6) AND StatusID = 1");
            return table;
        }

        public static DataTable GetUsers(int userID1, int userID2)
        {
            DataTable table = BaseCollection.ExecuteSql("select UserID,UserName from [User] where UserID IN ('" + userID1 + "','" + userID2 + "')");
            return table;
        }

        public static DataTable GetLoggedInUsers()
        {
            return Users.GetAllUser(0);
        }
        
        #endregion

        #region GetAllUserByID
        public static DataTable GetAllUserByID(Cxt cxt, StatusE statusID)
        {
            DataTable table = BaseCollection.ExecuteSql(InfiChess.User, "SELECT u.*,UserRole.RoleID as RoleID,  c.Name AS Country, Rank.Name AS Rank FROM [User] AS u LEFT OUTER JOIN Rank ON u.HumanRankID = Rank.RankID LEFT OUTER JOIN Country AS c ON u.CountryID = c.CountryID LEFT OUTER JOIN UserRole ON u.UserID = UserRole.UserRoleID where u.StatusID <>" + statusID.ToString("d"));
            return table;
        }
        public static DataTable GetAllAdmin()
        {
            DataTable table = BaseCollection.ExecuteSql(InfiChess.User, "SELECT u.*,UserRole.RoleID as RoleID, c.Name AS Country, Rank.Name AS Rank FROM [User] AS u LEFT OUTER JOIN Rank ON u.HumanRankID = Rank.RankID LEFT OUTER JOIN Country AS c ON u.CountryID = c.CountryID LEFT OUTER JOIN UserRole ON u.UserID = UserRole.UserRoleID where u.userid in (select userid from userrole where roleid =1)");
            return table;
        }
        public static DataTable GetAllBanUser(Cxt cxt, StatusE statusID)
        {
            DataTable table = BaseCollection.ExecuteSql(InfiChess.User, "SELECT u.*,UserRole.RoleID as RoleID,  c.Name AS Country, Rank.Name AS Rank FROM [User] AS u LEFT OUTER JOIN Rank ON u.HumanRankID = Rank.RankID LEFT OUTER JOIN Country AS c ON u.CountryID = c.CountryID LEFT OUTER JOIN UserRole ON u.UserID = UserRole.UserRoleID where u.StatusID =" + statusID.ToString("d"));
            return table;
        }
        public static DataTable GetAllBanUserMachine()
        {
            DataTable table = BaseCollection.ExecuteSql(InfiChess.User, "SELECT u.*,UserRole.RoleID as RoleID,  c.Name AS Country, Rank.Name AS Rank FROM [User] AS u LEFT OUTER JOIN Rank ON u.HumanRankID = Rank.RankID LEFT OUTER JOIN Country AS c ON u.CountryID = c.CountryID LEFT OUTER JOIN UserRole ON u.UserID = UserRole.UserRoleID where u.BanMachineKey is not null ");
            return table;
        }
        #endregion

        #region UpdateStatus

        public static DataTable UpdateStatus(StatusE statusID, string userIDs)
        {
            // status id is deleted
            StringBuilder sb = new StringBuilder();
            sb.Append("update [User] set statusid = ").Append(statusID.ToString("d")).Append(" WHERE userID in (").Append(userIDs).Append(")");
            return BaseCollection.ExecuteSql(sb.ToString());
        }

        public static DataTable UpdateBanStatus(StatusE statusID, string userIDs)
        {
            // status id is deleted
            StringBuilder sb = new StringBuilder();
            sb.Append("update [User] set statusid = ").Append(statusID.ToString("d"));
            //sb.Append(", BanMachineKey = '").Append(machineKey).Append("'");
            sb.Append(", BanEndDate = NULL, BanEndTime = NULL, BanStartDate = NULL, BanStartTime = NULL ");
            sb.Append(" WHERE userID in (").Append(userIDs).Append(")");
            return BaseCollection.ExecuteSql(sb.ToString());
        }
        public static void  MakeAdmin(string userIDs, RankE humanRankID, RoleE roleID)
        {
            System.Data.SqlClient.SqlTransaction t = null;

            try
            {
                t = SqlHelper.BeginTransaction(Config.ConnectionString);

                //BaseCollection.ExecuteSql2(t, "update [User] set HumanRankID = " +humanRankID.ToString("d") +" WHERE userID in (" +userIDs +")");
                BaseCollection.ExecuteSql2(t, "update [UserRole] set RoleID = " + roleID.ToString("d") + " WHERE userID in (" + userIDs + ")");


                SqlHelper.CommitTransaction(t);
            }
            catch (Exception ex)
            {
                SqlHelper.RollbackTransaction(t);
                Log.Write(Ap.Cxt, ex);
            }
        }
        public static void RevokeAdmin(string userIDs, RankE humanRankID, RoleE roleID)
        {
            System.Data.SqlClient.SqlTransaction t = null;

            try
            {
                t = SqlHelper.BeginTransaction(Config.ConnectionString);

                //BaseCollection.ExecuteSql2(t, "update [User] set HumanRankID = " + humanRankID.ToString("d") + " WHERE userID in (" + userIDs + ")");
                BaseCollection.ExecuteSql2(t, "update [UserRole] set RoleID = " + roleID.ToString("d") + " WHERE userID in (" + userIDs + ")");


                SqlHelper.CommitTransaction(t);
            }
            catch (Exception ex)
            {
                SqlHelper.RollbackTransaction(t);
                Log.Write(Ap.Cxt, ex);
            }
        }

        #endregion

        #endregion

        #region Get Users By Game and Chess type

        public static DataTable GetUsersByGameType(Cxt cxt, ChessTypeE ChessTypeE, GameType GameTypeE)
        {
            return BaseCollection.Execute("GetTopRatingByGameType", ChessTypeE.ToString("d"), GameTypeE.ToString("d"));
        }

        #endregion

    }
}
