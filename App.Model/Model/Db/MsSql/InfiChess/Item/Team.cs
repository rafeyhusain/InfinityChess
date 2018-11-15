using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using App.Model.Db;
using System.Diagnostics;
namespace App.Model
{
    public class Team : BaseItem
    {
        #region Constructor
        public Team()
            : base(0)
        {
        }

        public Team(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public Team(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public Team(Cxt cxt, DataRow row)
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
            get { return InfiChess.Team; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion

        #region Enum
        public StatusE StatusIDE { [DebuggerStepThrough]get { return (StatusE)this.StatusID; } [DebuggerStepThrough] set { this.StatusID = (int)value; } }
        #endregion

        #region Generated
        public int TeamID { get { return GetColInt32("TeamID"); } set { SetColumn("TeamID", value); } }
        public int StatusID { get { return GetColInt32("StatusID"); } set { SetColumn("StatusID", value); } }
        public string TeamName { get { return GetCol("TeamName"); } set { SetColumn("TeamName", value); } }
        #endregion

        #region Contained Classes

        #endregion

        #region Calculated

        #endregion
        
        #endregion
        
        #region Methods
        public static Team GetTeamById(Cxt cxt, int teamID)
        {
            return new Team(cxt, BaseCollection.SelectItem(InfiChess.Team, teamID));
        }
        #endregion
        
    }
}
