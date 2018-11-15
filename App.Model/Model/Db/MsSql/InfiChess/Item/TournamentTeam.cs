using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;

namespace App.Model.Db
{
    public class TournamentTeam : BaseItem
    {

        #region Constructor
        public TournamentTeam()
            : base(0)
        {
        }

        public TournamentTeam(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public TournamentTeam(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public TournamentTeam(Cxt cxt, DataRow row)
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
            get { return InfiChess.TournamentTeam; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion

        #region Enum
        public StatusE StatusIDE { [DebuggerStepThrough] get { return (StatusE)this.StatusID; } [DebuggerStepThrough] set { this.StatusID = (int)value; } }
        #endregion

        #region Generated
        public int TournamentTeamID { get { return GetColInt32("TournamentTeamID"); } set { SetColumn("TournamentTeamID", value); } }
        public int TournamentID { get { return GetColInt32("TournamentID"); } set { SetColumn("TournamentID", value); } }
        public int TeamID { get { return GetColInt32("TeamID"); } set { SetColumn("TeamID", value); } }
        public int StatusID { [DebuggerStepThrough]get { return GetColInt32("StatusID"); } [DebuggerStepThrough]set { SetColumn("StatusID", value); } }
        #endregion

        #region Contained Classess
        #endregion

        #region Calculated

        #endregion


        #endregion 


        public static int IsCorrectSchTournamentUserCount(int tournamentID)
        {
            DataTable dt = BaseCollection.ExecuteSql("select COUNT(tu.userid) Counter, tu.teamid FROM tournamentuser tu INNER JOIN tournament t ON t.tournamentid = tu.tournamentid INNER JOIN team on tu.teamid = team.teamid WHERE tu.tournamentid = " + tournamentID + " and tu.statusid <> 4 GROUP BY tu.teamid");

            int counter = 0;
            Kv kv = new Kv();

            if (dt.Rows.Count > 0)
            {
                counter = Convert.ToInt32(dt.Rows[0][0]);
            }
            else
            {
                return (int)MsgE.ErrorTournamentTeamCount;
            }

            foreach (DataRow item in dt.Rows)
            {
                if (counter != Convert.ToInt32(item[0]))
                {
                    return (int)MsgE.ErrorTournamentTeamCount;                    
                }
            }
            
            return 0;

        }

    }
}
