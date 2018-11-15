using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace App.Model.Db
{
    public class TournamentTeams : BaseItems<BaseItem, TournamentTeams>
    {
        #region Constructors
        public TournamentTeams()
        {
        }

        public TournamentTeams(Cxt cxt)
        {
            Cxt = cxt;
        }

        public TournamentTeams(Cxt cxt, BaseCollection items)
        {
            Cxt = cxt;

            DataTable = items.DataTable;
        }

        public TournamentTeams(Cxt cxt, DataTable table)
        {
            Cxt = cxt;

            DataTable = table;
        }

        #endregion

        #region Properties

        string teamIDs = string.Empty;
        public string TeamIDs { get { return teamIDs; } set { teamIDs = value; } }

        int tournamentID = 0;
        public int TournamentID { get { return tournamentID; } set { tournamentID = value; } }

        #endregion

        #region Method
        public static DataTable GetRecentTournamentTeam(Cxt cxt, int tournamentID)
        {
            return BaseCollection.ExecuteSql("select t.TeamID, t.TeamName, t.StatusID from TournamentTeam tt right join team t on tt.Teamid = t.TeamID where t.TeamID not in (select teamid from TournamentTeam where TournamentID = " + tournamentID + " and statusid <> 4) and t.statusid <> 4 and t.StatusID <> 3 group by t.TeamID, t.TeamName, t.StatusID");
        }

        public static void DeleteTournamentTeams(Cxt cxt, string tournamentTeamIDs, int tournamentID)
        {
            string[] tournamentTeamIDsArr = tournamentTeamIDs.Split(',');

            SqlTransaction trans = null;

            try
            {
                trans = SqlHelper.BeginTransaction(Config.ConnectionString);

            foreach (string itemID in tournamentTeamIDsArr)
            {
                if (string.IsNullOrEmpty(itemID))
                {
                    continue;
                }
                BaseCollection.ExecuteSql2(trans, "update TournamentTeam set StatusID = @p1 where TeamID = @p2 and TournamentID = @p3", (int)StatusE.Deleted, Convert.ToInt32(itemID), tournamentID);
                //TournamentTeams.DeleteInfiChess.TournamentTeam, Convert.ToInt32(itemID));
            }

            BaseCollection.Execute(trans, "UpdateTournamentUserStatusByTeamID",
                                  tournamentTeamIDs,
                                  tournamentID,
                                  cxt.CurrentUserID,
                                  DateTime.Now,
                                  (int)StatusE.Deleted);
          
            BaseCollection.Execute(trans, "UpdateTournamentWantinUserStatus",
                                        tournamentTeamIDs, tournamentID, 
                                        (int)TournamentUserStatusE.Declined,
                                        (int)StatusE.Deleted,
                                        cxt.CurrentUserID, DateTime.Now);

            SqlHelper.CommitTransaction(trans);
            }
            catch (Exception ex)
            {
                SqlHelper.RollbackTransaction(trans);
                Log.Write(cxt, ex);
            }
        }

        public static void DeleteTournamentTeams(Cxt cxt, SqlTransaction trans, int tournamentID)
        {            

            BaseCollection.Execute(trans, "UpdateTournamentTeamStatus",
                                        tournamentID,                                        
                                        (int)StatusE.Deleted,
                                        cxt.CurrentUserID, DateTime.Now);
        }


        public static void DeleteTournamentTeams(Cxt cxt, TournamentTeams TournamentTeams)
        {
            SqlTransaction trans = null;

            try
            {
                trans = SqlHelper.BeginTransaction(Config.ConnectionString);

                for (int i = 0; i < TournamentTeams.Count; i++)
                {                
                    //TournamentTeams.Delete(InfiChess.TournamentTeam, Convert.ToInt32(TournamentTeams.DataTable.Rows[i]["TournamentTeamID"]));
                    BaseCollection.ExecuteSql2(trans, "update TournamentTeam statusid = @p1 where TournamentTeamID = @p2", (int)StatusE.Deleted, Convert.ToInt32(TournamentTeams.DataTable.Rows[i]["TournamentTeamID"]));
                }

                 for (int i = 0; i < TournamentTeams.Count; i++)
                {                
                     BaseCollection.Execute(trans, "UpdateTournamentUserStatusByTeamID",
                                        Convert.ToInt32(TournamentTeams.DataTable.Rows[i]["TeamID"]),
                                       TournamentTeams.TournamentID,
                                       cxt.CurrentUserID,                                       
                                       DateTime.Now,
                                       (int)StatusE.Deleted);
                }

               

                
                 SqlHelper.CommitTransaction(trans);
            }
            catch (Exception ex)
            {
                SqlHelper.RollbackTransaction(trans);
                Log.Write(cxt, ex);
            }

        }

        public void SaveTeams()
        {
            string[] teamIDsArr = TeamIDs.Split(',');
            //SqlTransaction trans = null;
            //trans = SqlHelper.BeginTransaction(Config.ConnectionString);

            foreach (string itemID in teamIDsArr)
            {
                TournamentTeam TournamentTeam = new TournamentTeam(this.Cxt, Convert.ToInt32(itemID));
                TournamentTeam.TournamentID = TournamentID;
                TournamentTeam.TeamID = Convert.ToInt32(itemID);
                TournamentTeam.StatusID = (int)StatusE.Active;
                this.Add(TournamentTeam);
            }
            
            try
            {
                this.Save();
            }
            catch (Exception ex)
            {
                //SqlHelper.RollbackTransaction(trans);
                Log.Write(this.Cxt, ex);
            }

            
        }

        #endregion
    }
}
