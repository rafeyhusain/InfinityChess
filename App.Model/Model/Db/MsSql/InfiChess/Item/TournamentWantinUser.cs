using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;
namespace App.Model.Db
{
    public class TournamentWantinUser : BaseItem
    {
        #region Constructor
        public TournamentWantinUser()
            : base(0)
        {
        }

        public TournamentWantinUser(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public TournamentWantinUser(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public TournamentWantinUser(Cxt cxt, DataRow row)
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
            get { return InfiChess.TournamentWantinUser; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion

        #region Enum
        public TournamentUserStatusE TournamentUserStatusE { [DebuggerStepThrough] get { return (TournamentUserStatusE)this.TournamentUserStatusID; } [DebuggerStepThrough]set { this.TournamentUserStatusID = (int)value; } }
        public StatusE StatusIDE { [DebuggerStepThrough] get { return (StatusE)this.StatusID; } [DebuggerStepThrough] set { this.StatusID = (int)value; } }

        #endregion

        #region Generated

        public int TournamentWantinUserID { [DebuggerStepThrough]get { return GetColInt32("TournamentWantinUserID"); } [DebuggerStepThrough]set { SetColumn("TournamentWantinUserID", value); } }
        public int TournamentID { [DebuggerStepThrough] get { return GetColInt32("TournamentID"); } [DebuggerStepThrough]set { SetColumn("TournamentID", value); } }
        public int UserID { [DebuggerStepThrough] get { return GetColInt32("UserID"); } [DebuggerStepThrough] set { SetColumn("UserID", value); } }
        public int TournamentUserStatusID { [DebuggerStepThrough] get { return GetColInt32("TournamentUserStatusID"); } [DebuggerStepThrough]set { SetColumn("TournamentUserStatusID", value); } }
        public int StatusID { [DebuggerStepThrough] get { return GetColInt32("StatusID"); } [DebuggerStepThrough] set { SetColumn("StatusID", value); } }
        public int TeamID { [DebuggerStepThrough] get { return GetColInt32("TeamID"); } [DebuggerStepThrough] set { SetColumn("TeamID", value); } }

        #endregion

        #region Contained Classes
        Tournament tournament = null;
        User user = null;

        public Tournament Tournament { [DebuggerStepThrough] get { return tournament; } [DebuggerStepThrough] set { tournament = value; } }
        public User User { [DebuggerStepThrough] get { return user; } [DebuggerStepThrough]set { user = value; } }
        public TournamentUserStatusIDE TournamentUserStatusIDE { [DebuggerStepThrough]get { return (TournamentUserStatusIDE)TournamentUserStatusID; } [DebuggerStepThrough] set { this.TournamentUserStatusID = (int)value; } }


        #endregion

        #region Calculated

        #endregion
        #endregion

        #region Methods

        #region GetTournamentWantinUserId

        public static TournamentWantinUser GetTournamentWantinUserById(Cxt cxt, int tournamentWantinUserId)
        {
            return new TournamentWantinUser(cxt, BaseCollection.SelectItem(InfiChess.TournamentWantinUser, tournamentWantinUserId));
        }
        public static TournamentWantinUser GetTournamentWantinUserById(Cxt cxt, int tournamentID, int userID)
        {
            return new TournamentWantinUser(cxt, BaseCollection.SelectItem(InfiChess.TournamentWantinUser, "TournamentID = " + tournamentID + " AND UserID = " + userID));
        }

        #endregion

        #endregion
    }
}
