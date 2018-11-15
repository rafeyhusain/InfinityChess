using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace App.Model.Db
{
    public class TournamentUsers : BaseItems<TournamentUser, TournamentUsers>
    {
        #region Constructors
        public TournamentUsers()
        {
        }

        public TournamentUsers(Cxt cxt)
        {
            Cxt = cxt;
        }

        public TournamentUsers(Cxt cxt, BaseCollection items)
        {
            Cxt = cxt;

            DataTable = items.DataTable;
        }

        public TournamentUsers(Cxt cxt, DataTable table)
        {
            Cxt = cxt;

            DataTable = table;
        }

        #endregion

        #region Properties

        #region Core
        public override InfiChess TableName
        {
            get
            {
                return InfiChess.TournamentUser;
            }
            set
            {
                base.TableName = value;
            }
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
        public static DataTable GetTournamentRegisteredUsers()
        {
            return BaseCollection.ExecuteSql("GetTournamentRegisteredUsers");
        }

        public static DataTable GetTournamentUsers(int TournamentID, UserStatusE UserStatusID, TournamentEntityTypeE TournamentEntityTypeE)
        {
            if (TournamentEntityTypeE == TournamentEntityTypeE.RegisteredUser)
            {
                return BaseCollection.Execute("GetTournamentRegisteredUsers", TournamentID, 0);
                    //ExecuteSql("GetTournamentRegisteredUsers @p", );
            }
            else
            {
                return BaseCollection.Execute("GetTournamentUsers", TournamentID, 0, UserStatusID.ToString("d"));
            }
        }

        public static DataTable GetTournamentUsers(int TournamentID, int TeamID, UserStatusE UserStatusID, TournamentEntityTypeE TournamentEntityTypeID)
        {
            if (TournamentEntityTypeID == TournamentEntityTypeE.RegisteredUser)
            {
                return BaseCollection.Execute("GetTournamentRegisteredUsers", TournamentID, TeamID);
                //ExecuteSql("GetTournamentRegisteredUsers @p", );
            }
            else
            {
                return BaseCollection.Execute("GetTournamentUsers", TournamentID, TeamID, UserStatusID.ToString("d"));
            }
        }

        /// <summary>
        /// Online Client
        /// </summary>
        /// <param name="TournamentID"></param>
        /// <param name="TeamID"></param>
        /// <param name="UserStatusID"></param>
        /// <param name="TournamentEntityTypeID"></param>
        /// <returns></returns>
        public static DataTable GetTournamentUsers(int TournamentID, int TeamID, int userStatusID, TournamentEntityTypeE TournamentEntityTypeID)
        {
            if (TournamentEntityTypeID == TournamentEntityTypeE.RegisteredUser)
            {
                return BaseCollection.Execute("GetTournamentRegisteredUsers", TournamentID, TeamID);
                //ExecuteSql("GetTournamentRegisteredUsers @p", );
            }
            else
            {
                return BaseCollection.Execute("GetTournamentUsers", TournamentID, TeamID, userStatusID);
            }
        }

        public static DataTable UpdateStatus(int statusID, string tournamentUserID)
        {          
            return BaseCollection.ExecuteSql(InfiChess.Tournament, "update TournamentUser set statusid = @p1 WHERE TournamentUserID in (@p2)", statusID, tournamentUserID);
        }

        public static DataTable GetTournamentUsersByTournamentID(int statusID, int tournamentID)
        {
            return BaseCollection.Select(InfiChess.TournamentUser, "TournamentID = " + tournamentID + " and StatusID = " + statusID.ToString());
        }

        public static DataTable GetTournamentUsersByRound(int tournamentID, int round)
        {
            return BaseCollection.Execute("GetTournamentUsersByRound", tournamentID, round);
        }
   
        /// <summary>
        /// for online client
        /// </summary>
        /// <param name="statusID"></param>
        /// <param name="tournamentID"></param>
        /// <returns></returns>
        public static DataTable GetTournamentUsersByTournamentID(StatusE statusID, int tournamentID)
        {
            return BaseCollection.Select(InfiChess.TournamentUser, "TournamentID = " + tournamentID + " and StatusID = " + statusID.ToString("d") + " ORDER BY EloBefore DESC");
        }

        public static DataTable GetTournamentUsersWithCreatedDate(StatusE statusID, int tournamentID)
        {
            return BaseCollection.Select(InfiChess.TournamentUser, "TournamentID = " + tournamentID + " and StatusID = " + statusID.ToString("d") + " ORDER BY DateCreated ASC");
        }


        public static DataTable GetTournamentUsersByTournamentID(int TeamA, int TeamB, int tournamentID)
        {
            return BaseCollection.Select(InfiChess.TournamentUser, "TournamentID = " + tournamentID + " and (TeamID = " + TeamA +" or TeamID = "+ TeamB +")");
        }

        //public static DataTable GetTournamentUsers()
        //{
        //    return BaseCollection.ExecuteSql("GetTournamentUsers");
        //}

        public static DataTable GetTournamentUsersGroupByTournamentPoint(int TournamentID)
        {
            return BaseCollection.ExecuteSql("select MatchCount = count(*), tournamentpoints from TournamentUser where statusid <> 4 and tournamentpoints is not null and tournamentid = " + TournamentID.ToString() + " group by tournamentpoints order by tournamentpoints desc");
        }


        #region Update Status
        public static DataTable UpdateStatus(int StatusID, int TournamentUserStatusID, string TournamentUserIDs)
        {
            // status id is deleted
            StringBuilder sb = new StringBuilder();
            sb.Append("update TournamentUser set StatusID = ").Append(StatusID).Append(" ");
            sb.Append(" WHERE TournamentUserID in (").Append(TournamentUserIDs).Append(")");
            return BaseCollection.ExecuteSql(sb.ToString());
        } 
        #endregion

        #region Create Register Users
        public static void CreateRegisterUsers(Cxt cxt, SqlTransaction sqlTrans, DataTable dt)
        {            
            foreach (DataRow dr in dt.Rows)
            {
                TournamentUser tournamentUser = new TournamentUser(cxt, dr);
                
                BaseCollection.Execute(sqlTrans, "CreateTournamentRegisterUser",
                        tournamentUser.TournamentID, tournamentUser.UserID,
                        tournamentUser.StatusID, tournamentUser.TeamID, 
                        tournamentUser.EloBefore, cxt.CurrentUser.UserID, 
                        DateTime.Now);
            }
        }
        
        #endregion
        #endregion

        public static void SaveTournamentRegisteredUsers(Cxt cxt,
                                                    int statusID,
                                                    int tournamentUserStatusID,
                                                    int tournamentID,
                                                    string userIDs,
                                                    string tournamentWantinUserIDs,
                                                    int teamID, int eloBefore)        
        {
            TournamentWantinUsers.SaveWantinUsers(cxt, statusID, tournamentUserStatusID, tournamentID, userIDs, "", teamID, eloBefore);
            
        }

        public static void DeleteTournamentUser(Cxt cxt, SqlTransaction trans, int tournamentID)
        {

            BaseCollection.Execute(trans, "UpdateTournamentUserStatusByTeamID",
                                        "0", tournamentID,                                        
                                        cxt.CurrentUserID, DateTime.Now, (int)StatusE.Deleted);
        }

    }

}
