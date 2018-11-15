using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
namespace App.Model.Db
{
    #region enumTournamentUserStatusIDE
    
    public enum TournamentUserStatusIDE
    {
        Requested = 1,
        Approved = 2,
        Declined = 3,
        Wantin = 4
    }
    
    #endregion

    public class TournamentUser : BaseItem
    {
        #region Constructor
        public TournamentUser()
            : base(0)
        {
        }

        public TournamentUser(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public TournamentUser(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public TournamentUser(Cxt cxt, DataRow row)
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
            get { return InfiChess.TournamentUser; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion

        #region Enum
        public StatusE StatusIDE { [DebuggerStepThrough]get { return (StatusE)this.StatusID; } [DebuggerStepThrough]set { this.StatusID = (int)value; } }
        #endregion

        #region Generated
        public int TournamentUserID { [DebuggerStepThrough]get { return GetColInt32("TournamentUserID"); } [DebuggerStepThrough] set { SetColumn("TournamentUserID", value); } }
        public int TournamentID { [DebuggerStepThrough] get { return GetColInt32("TournamentID"); } [DebuggerStepThrough] set { SetColumn("TournamentID", value); } }
        public int UserID { [DebuggerStepThrough] get { return GetColInt32("UserID"); } [DebuggerStepThrough] set { SetColumn("UserID", value); } }
        public int UserID2 { [DebuggerStepThrough] get { return GetColInt32("UserID2"); } [DebuggerStepThrough] set { SetColumn("UserID2", value); } }
        public int StatusID { [DebuggerStepThrough]get { return GetColInt32("StatusID"); } [DebuggerStepThrough]set { SetColumn("StatusID", value); } }
        public int TournamentUserStatusID { [DebuggerStepThrough] get { return GetColInt32("TournamentUserStatusID"); } [DebuggerStepThrough] set { SetColumn("TournamentUserStatusID", value); } }
        public int EloBefore { [DebuggerStepThrough] get { return GetColInt32("EloBefore"); } [DebuggerStepThrough] set { SetColumn("EloBefore", value); } }
        public int EloAfter { [DebuggerStepThrough] get { return GetColInt32("EloAfter"); } [DebuggerStepThrough] set { SetColumn("EloAfter", value); } }
        public decimal TournamentPoints { [DebuggerStepThrough] get { return GetColDecimal("TournamentPoints"); } [DebuggerStepThrough]set { SetColumn("TournamentPoints", value); } }        
        public int TeamID { [DebuggerStepThrough] get { return GetColInt32("TeamID"); } [DebuggerStepThrough] set { SetColumn("TeamID", value); } }
        #endregion

        #region Contained Classes

        private Tournament tournament = null;
        public Tournament Tournament
        {
            [DebuggerStepThrough]
            get
            {
                if (tournament == null)
                {
                    tournament = new Tournament(Cxt, this.TournamentID);
                }

                return tournament;
            }
            [DebuggerStepThrough]
            set { tournament = value; }
        }

        private User user = null;
        public User User
        {
            [DebuggerStepThrough]
            get
            {
                if (user == null)
                {
                    user = new User(base.Cxt, this.UserID);
                }
                return user;
            }
            [DebuggerStepThrough]
            set { user = value; }
        }


        private User user2 = null;
        public User User2
        {
            [DebuggerStepThrough]
            get
            {
                if (user2 == null)
                {
                    user2 = new User(base.Cxt, this.UserID2);
                }
                return user2;
            }
            [DebuggerStepThrough]
            set { user2 = value; }
        }
        #endregion

        #region Calculated
        public int ActualUserID
        {
            [DebuggerStepThrough]
            get
            {
                if (UserID2 == 0)
                {
                    return UserID;
                }

                return UserID2;
            }
        }

        public string UserName
        {
            [DebuggerStepThrough]
            get
            {
                if (UserID2 == 0)
                {
                    return User.UserName;
                }

                return User2.UserName + "(" + User.UserName + ")";
            }
        }

        public TournamentUserStatusE TournamentUserStatusE { get { return (TournamentUserStatusE)TournamentUserStatusID; } set { this.TournamentUserStatusID = (int)value; } }
        #endregion
        #endregion 
      
        #region Methods

        #region GetTournamentUserId

        public static TournamentUser GetTournamentUserById(Cxt cxt, int tournamentUserId)
        {
            return new TournamentUser(cxt, BaseCollection.SelectItem(InfiChess.TournamentUser, tournamentUserId));
        }
        public static TournamentUser GetTournamentUserById(Cxt cxt, int TournamentID, int UserID)
        {
            return new TournamentUser(cxt, BaseCollection.SelectItem(InfiChess.TournamentUser, "TournamentID = " + TournamentID + " and UserID = " + UserID));
        }

        #endregion

        #region UpdateUsersEloAfter

        public static void UpdateUsersEloAfter(SqlTransaction t, int wu, int bu, int elow, int elob, int tid)
        {
            BaseCollection.Execute(t, "UpdateTournamentUsersEloAfterByTournamentID", wu, bu, elow, elob, tid);
        }

        public static void UpdateTournamentUserEloBefore(Cxt cxt, SqlTransaction t, int userID, int tournamentID)
        {
            BaseCollection.Execute(t, "UpdateTournamentUserEloBefore", tournamentID, userID, cxt.CurrentUserID);
        }

        #endregion

        #region Replace Updated Player
        public static Kv UpdateReplacePlayer(Cxt cxt, int tournamentID, int userID, int userID2)
        {
            Kv kv = new Kv();
            SqlTransaction trans = null;
            
            try
            {                
                trans = SqlHelper.BeginTransaction(Config.ConnectionString);

                bool result = TournamentMatch.GetTournamentMatchByTournamentUserID(cxt, tournamentID, userID);

                if (result)
                {
                    kv.Set("Result", (int)MsgE.ErrorTournamentPlayerReplaceUser);
                    return kv;
                }

                TournamentUser tu = GetTournamentUserById(cxt, tournamentID, userID);
                
                BaseCollection.Execute(trans, "UpdateTournamentMatchWithUser", tournamentID, userID, userID2, cxt.CurrentUserID, 3);

                if (tu.UserID2 > 0)
                {
                    userID = tu.UserID2;
                }


                BaseCollection.Execute(trans, "UpdateTournamentMatchWithUser", tournamentID, userID, userID2, cxt.CurrentUserID, 0);

                BaseCollection.Execute(trans, "UpdateTournamentMatchWithUser", tournamentID, userID, userID2, cxt.CurrentUserID, 1);

                SqlHelper.CommitTransaction(trans);
                kv.Set("Result", 0);
            }
            catch (Exception ex)
            {
                SqlHelper.RollbackTransaction(trans);
                Log.Write(cxt, ex);
            }
            return kv;
        } 
        #endregion
        
        #endregion
    }
}
