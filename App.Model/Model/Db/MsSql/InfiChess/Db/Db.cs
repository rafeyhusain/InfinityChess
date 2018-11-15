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
using System.Data.SqlClient;

namespace App.Model.Db
{
    public class Db
    {
        public static DataSet GetDataByRoomID(Cxt cxt, int roomID, int userID, int userStatus, int engineID, bool isFromTimer)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            if (userID != 0 && !isFromTimer)
            {
                SqlTransaction t = null;
                try
                {
                    t = SqlHelper.BeginTransaction(Config.ConnectionString);
                    Challenges.UpdateChallengesStatus(t,userID);
                    User.UpdatedUserRoom(cxt, t, roomID, userStatus, engineID, userID); //Transaction also commited in this method
                }
                catch (Exception ex)
                {
                    SqlHelper.RollbackTransaction(t);

                    throw ex;
                }
            }

            ds = BaseCollection.ExecuteDataset("ApData", userID, roomID);
            ds.Tables[0].TableName = "Room";
            ds.Tables[1].TableName = "Users";
            ds.Tables[2].TableName = "Games";
            ds.Tables[3].TableName = "Challenges";
            ds.Tables[4].TableName = "RoomUsersCount";
            ds.Tables[5].TableName = "LoggedinUsers";
            ds.Tables[6].TableName = "UserMessages";
            ds.Tables[7].TableName = "Table7";
          
            dt = new DataTable();
            dt = Challenge.GetAcceptedChallenge(cxt, roomID, userID);
            dt.TableName = "AcceptedChallenge";
            ds.Tables.Add(dt.Copy());

            return ds;
        }
    }
}
