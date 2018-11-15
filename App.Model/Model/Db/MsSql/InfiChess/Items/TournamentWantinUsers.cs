using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
namespace App.Model.Db
{
    public class TournamentWantinUsers : BaseItems<TournamentWantinUser, TournamentWantinUsers>
    {
        #region Constructors
        public TournamentWantinUsers()
        {
        }

        public TournamentWantinUsers(Cxt cxt)
        {
            Cxt = cxt;
        }

        public TournamentWantinUsers(Cxt cxt, BaseCollection items)
        {
            Cxt = cxt;

            DataTable = items.DataTable;
        }

        public TournamentWantinUsers(Cxt cxt, DataTable table)
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
            get
            {
                return InfiChess.TournamentWantinUser;
            }
            [DebuggerStepThrough]
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

        #region Tournament Wantin User List

        public static DataTable GetTournamentWantinUsers(int TournamentID)
        {
            return BaseCollection.Execute("GetTournamentWantinUsers", TournamentID);
        }

        public static DataTable GetSchTournamentWantinUsers(int TournamentID)
        {
            return BaseCollection.Execute("GetSchTournamentWantinUsers", TournamentID);
        }

        #endregion
                
        public static DataTable UpdateStatus(SqlTransaction t, StatusE statusID, string tournamentUserID)
        {
            return BaseCollection.ExecuteSql(t, InfiChess.TournamentWantinUser, "update TournamentWantinUser set TournamentWantinUserStatusID = @p1 WHERE TournamentUserID in (@p2)", statusID.ToString("d"), tournamentUserID);
        }

        public static DataTable GetTournamentWantinUsers()
        {
            return BaseCollection.ExecuteSql("GetTournamentWantinUsers");
        }

        public static DataTable UpdateTournamentWantinStatus(StatusE statusID, string TournamentWantinUserIDs)
        {
            // status id is deleted
            StringBuilder sb = new StringBuilder();
            sb.Append("update TournamentWantinUser set TournamentUserStatusID = ").Append(statusID.ToString("d")).Append(" WHERE TournamentWantinUserID in (").Append(TournamentWantinUserIDs).Append(")");
            return BaseCollection.ExecuteSql(sb.ToString());

        }

        #region Update Register Wantin User

        //public static void UpdateWantinUsers(Cxt cxt, UpdateTournamentUsersS UpdateTournamentUsersS)
        //{
        //    SqlTransaction sqltrans = null;
            
        //    try
        //    {
        //        sqltrans = SqlHelper.BeginTransaction(Config.ConnectionString);
                    
        //        BaseCollection.Execute(sqltrans, "UpdateTournamentUserStatus", 
        //                                UpdateTournamentUsersS.TournamentUserIDs,
        //                                UpdateTournamentUsersS.TournamentID, 
        //                                UpdateTournamentUsersS.UserId, 
        //                                DateTime.Now,
        //                                UpdateTournamentUsersS.statusID.ToString("d"));

        //        BaseCollection.Execute(sqltrans, "UpdateTournamentWantinUserStatus", 
        //                                "",
        //                                UpdateTournamentUsersS.TournamentWantinUserIDs,
        //                                UpdateTournamentUsersS.tournamentUserStatusID.ToString("d"), 
        //                                (int)StatusE.Active,
        //                                UpdateTournamentUsersS.UserId, DateTime.Now);

        //        //BaseCollection.Execute(sqltrans, "DeleteTournamentMatchByUserID",
        //        //                        UpdateTournamentUsersS.TournamentUserIDs,
        //        //                        UpdateTournamentUsersS.TournamentID ,
        //        //                        1);                   
                            
        //        SqlHelper.CommitTransaction(sqltrans);
        //    }
        //    catch (Exception ex)
        //    {
        //        SqlHelper.RollbackTransaction(sqltrans);
        //        Log.Write(cxt, ex);
        //    }
        //}

        /// <summary>
        /// Online client wantin user update
        /// </summary>
        /// <param name="cxt"></param>
        /// <param name="statusID"></param>
        /// <param name="tournamentUserStatusID"></param>
        /// <param name="tournamentID"></param>
        /// <param name="userIDs"></param>
        /// <param name="tournamentWantinUserIDs"></param>
        public static void SaveWantinUsers(Cxt cxt,
                                                    int statusID,
                                                    int tournamentUserStatusID,
                                                    int tournamentID,
                                                    string userIDs,
                                                    string tournamentWantinUserIDs,
                                                    int teamID, int eloBefore)
        {
            SqlTransaction sqltrans = null;            
            try
            {
                sqltrans = SqlHelper.BeginTransaction(Config.ConnectionString);

                StatusE StatusIDE = (StatusE)Enum.ToObject(typeof(StatusE), statusID);

                if (StatusIDE == StatusE.Active)
                {
                    SaveWantinUsers(sqltrans, cxt, statusID, tournamentUserStatusID, tournamentID, userIDs, tournamentWantinUserIDs, teamID, eloBefore);
                }
                else
                {
                    BaseCollection.Execute(sqltrans, "UpdateTournamentUserStatus",
                                        userIDs,
                                        tournamentID,
                                        cxt.CurrentUserID,
                                        DateTime.Now,
                                        statusID);

                    BaseCollection.Execute(sqltrans, "UpdateWantinUserStatusByUserID",
                                            userIDs,
                                            tournamentID,
                                            tournamentUserStatusID,
                                            cxt.CurrentUserID, DateTime.Now);

                }

                
                SqlHelper.CommitTransaction(sqltrans);
            }
            catch (Exception ex)
            {
                SqlHelper.RollbackTransaction(sqltrans);
                Log.Write(cxt, ex);
            }
        }
               

        #endregion

        #region Structure
        public struct UpdateTournamentUsersS
        {
            public int UserId;
            public int TournamentID;
            public TournamentUserStatusE tournamentUserStatusID;
            public string TournamentWantinUserIDs;
            public string TournamentUserIDs;
            public StatusE statusID;
        }
        
        #endregion

        #region Register Wantin User

        public static void SaveWantinUsers(Cxt cxt, DataTable items, DataTable dtTournamentWantin)
        {
            SqlTransaction sqltrans = null;
            
            try
            {
                sqltrans = SqlHelper.BeginTransaction(Config.ConnectionString);
                
                TournamentUsers.CreateRegisterUsers(cxt, sqltrans, items);

                    if (dtTournamentWantin != null)
                    {
                        foreach (DataRow dr in dtTournamentWantin.Rows)
                        {
                            TournamentWantinUser tournamentWantinUser = new TournamentWantinUser(cxt, dr);
                            //tournamentWantinUser.Save(sqltrans);
                            DateTime DateModified = DateTime.Now;
                            int ModifiedBy = 1;
                            int TournamentWantinUserID = tournamentWantinUser.TournamentWantinUserID;
                            int TournamentUserStatusID = tournamentWantinUser.TournamentUserStatusID;

                            BaseCollection.ExecuteSql(sqltrans, InfiChess.TournamentWantinUser,
                                "update TournamentWantinUser set TournamentUserStatusID = @p1, ModifiedBy = @p2, DateModified = @p3 WHERE TournamentWantinUserID = @p4",
                                TournamentUserStatusID, ModifiedBy, DateModified, TournamentWantinUserID);
                        }
                    }
                

                SqlHelper.CommitTransaction(sqltrans);                
            }
            catch (Exception ex)
            {
                SqlHelper.RollbackTransaction(sqltrans);
                Log.Write(cxt, ex);  
            }
        }

        /// <summary>
        /// online client
        /// </summary>
        /// <param name="cxt"></param>
        /// <param name="items"></param>
        /// <param name="dtTournamentWantin"></param>
        private static void SaveWantinUsers(SqlTransaction trans,
                                                    Cxt cxt,
                                                    int statusID,
                                                    int tournamentUserStatusID,
                                                    int tournamentID,
                                                    string userIDs,
                                                    string tournamentWantinUserIDs,
                                                    int teamID, int eloBefore)
        {
            
            string[] userIDArr = userIDs.Split(',');
            int uId = -1;
            foreach (string userID in userIDArr)
            {
                if (!Int32.TryParse(userID, out uId))
                {
                    continue;
                }

                BaseCollection.Execute(trans, "CreateTournamentRegisterUser",
                        tournamentID, uId,
                        statusID, teamID,
                        eloBefore, cxt.CurrentUser.UserID,
                        DateTime.Now);
            }

            string[] tournamentWantinUserIDArr = tournamentWantinUserIDs.Split(',');

            BaseCollection.Execute(trans, "UpdateWantinUserStatusByUserID",
                                             userIDs,
                                             tournamentID,
                                             tournamentUserStatusID,
                                             cxt.CurrentUserID, DateTime.Now);

        }

        #endregion


        public static void DeleteTournamentWantinUser(Cxt cxt, SqlTransaction trans, int tournamentID)
        {

            BaseCollection.Execute(trans, "UpdateTournamentWantinUserStatus",
                                        "0", tournamentID,
                                        (int)TournamentUserStatusE.Declined,
                                        (int)StatusE.Deleted,
                                        cxt.CurrentUserID, DateTime.Now);
        }


        public static void CreateTournamentWantinUser(Cxt cxt, int userID, int tournamentID, int teamID, int tournamentUserStatusID)
        {
            try
            {
                TournamentWantinUser TournamentWantinUser = TournamentWantinUser.GetTournamentWantinUserById(cxt, tournamentID, userID);

                TournamentWantinUser.TournamentID = tournamentID;
                TournamentWantinUser.UserID = userID;
                TournamentWantinUser.TeamID = teamID;
                TournamentWantinUser.TournamentUserStatusID = tournamentUserStatusID;
                TournamentWantinUser.StatusID = (int)StatusE.Active;
                TournamentWantinUser.Save();
            }
            catch (Exception ex)
            {                
                Log.Write(cxt, ex);
            }
        }

        #endregion
    }

}
