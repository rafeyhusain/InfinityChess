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
    public class Teams : BaseItems<Team, Teams>
    {
        #region Constructors
        public Teams()
        {
        }

        public Teams(Cxt cxt)
        {
            Cxt = cxt;
        }

        public Teams(Cxt cxt, BaseCollection items)
        {
            Cxt = cxt;

            DataTable = items.DataTable;
        }

        public Teams(Cxt cxt, DataTable table)
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
            get { return InfiChess.Team; }
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
        public static DataTable GetAllTeam(StatusE statusE)
        {
            return BaseCollection.ExecuteSql(InfiChess.Team, "SELECT * FROM Team WHERE statusID = @p1 ORDER BY DateCreated DESC", (int)statusE);
        }

        public static DataTable GetAllTeam()
        {
            return BaseCollection.ExecuteSql(InfiChess.Team, "SELECT u.*, Status.Name AS Status FROM Team AS u LEFT OUTER JOIN Status ON u.StatusID = Status.StatusID where u.StatusID <> @p1 ORDER BY DateCreated DESC", (int)StatusE.Deleted);
        }

        public static DataTable GetAllTeam(int userID)
        {
            return BaseCollection.ExecuteSql(InfiChess.Team, "SELECT * FROM Team WHERE statusID <> 4 and CreatedBy = @p1 ORDER BY DateCreated DESC", userID);
        }

        public static DataTable UpdateStatus(StatusE statusID, string parm)
        {
            // status id is deleted
            StringBuilder sb = new StringBuilder();

            sb.Append("update Team set statusid = ").Append(statusID.ToString("d")).Append(" WHERE TeamID in (").Append(parm).Append(")");

            return BaseCollection.ExecuteSql(sb.ToString());
        }

        public static DataTable GetTeamsByTournamentID(int tournamentID)
        {
            return BaseCollection.ExecuteSql("select * from TournamentTeam tt inner join team t on tt.Teamid = t.TeamID where tt.TournamentID = " + tournamentID + " and tt.StatusID <> "+ (int)StatusE.Deleted);
        }

        #endregion



    }
}
