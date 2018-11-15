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
    public class Rooms : BaseItems<Room, Rooms>
    {
        #region Constructors
        public Rooms()
        {
        }

        public Rooms(Cxt cxt)
        {
            Cxt = cxt;
        }

        public Rooms(Cxt cxt, BaseCollection items)
        {
            Cxt = cxt;

            DataTable = items.DataTable;
        }

        public Rooms(Cxt cxt, DataTable table)
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
            get { return InfiChess.Room; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }
        #endregion

        #region Enum

        #endregion

        #region Generated
        #endregion

        #region Contained Classes

        #endregion

        #region Calculated

        #endregion
        #endregion 
              
        #region Methods
        public static DataTable GetAllRooms()
        {
            return BaseCollection.ExecuteSql(InfiChess.Room, "SELECT * FROM [Room] WHERE StatusID = 1", "");
        }
        public static DataTable GetRoomByID(Cxt cxt, int roomID)
        {
            DataTable table = BaseCollection.ExecuteSql(InfiChess.Room, "select * from [Room] where RoomID=@p1", roomID);
            return table;
        }

        public static DataTable GetRoomUsersCount(Cxt cxt)
        {
            DataTable table = BaseCollection.ExecuteSql("SELECT RoomID, COUNT(*) AS UsersCount FROM [User] WHERE UserStatusID <> 4 AND StatusID = 1 GROUP BY ROOMID");
            return table;
        }

        public static DataTable GetAllRoomsWithRelationship()
        {
            DataTable table = BaseCollection.ExecuteSql("GetAllRoomsWithRelationship");
            return table;
        }
        public static DataTable GetAllRoomsWithNullTournament()
        {
            DataTable table = BaseCollection.ExecuteSql("GetAllRoomsWithNullTournament");
            return table;
        }

        public static DataTable UpdateStatus(StatusE statusID, string parm)
        {
            // status id is deleted
            StringBuilder sb = new StringBuilder();
            sb.Append("update Room set statusid = ").Append(statusID.ToString("d")).Append(" WHERE RoomID in (").Append(parm).Append(")");            
            return BaseCollection.ExecuteSql(sb.ToString());
        }


        #endregion



    }
}
