using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
namespace App.Model.Db
{
    public class Tournaments : BaseItems<Tournament, Tournaments>
    {
        #region Constructors
        public Tournaments()
        {
        }

        public Tournaments(Cxt cxt)
        {
            Cxt = cxt;
        }

        public Tournaments(Cxt cxt, BaseCollection items)
        {
            Cxt = cxt;

            DataTable = items.DataTable;
        }

        public Tournaments(Cxt cxt, DataTable table)
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
                return InfiChess.Tournament;
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

        public static DataTable GetAllTournaments()
        {
            return BaseCollection.ExecuteSql(InfiChess.Tournament, "SELECT * FROM Tournament where statusID <> 4 Order by DateCreated ", "");
        }

        public static DataTable GetAllTournaments(TournamentStatusE TournamentStatusID)
        {
            return BaseCollection.Execute("GetAllTournament", TournamentStatusID.ToString("d"));
        }

        public static DataTable GetAllActiveTournaments()
        {
            return BaseCollection.ExecuteSql(InfiChess.Tournament, "SELECT *, TD = u.UserName, ts.Name as TournamentStatus FROM Tournament t inner join [User] u on u.userid = t.createdby inner join TournamentStatus ts on t.TournamentStatusID = ts.TournamentStatusID  where t.statusID <> 4 AND t.TournamentStatusID <> 3 Order by t.DateCreated DESC", "");
        }

        public static DataTable GetAllOngoingTournaments(DateTime createdDate)
        {
            return BaseCollection.ExecuteSql(InfiChess.Tournament, "SELECT * FROM Tournament where statusID <> 4 and TournamentStartDate is NULL Order by DateCreated ", createdDate );
        }

        public static DataTable GetAllTournaments(int userID)
        {
            return BaseCollection.ExecuteSql(InfiChess.Tournament, "SELECT * FROM Tournament where CreatedBy = " + userID + " and statusID <> 4 Order by DateCreated DESC", "");            
        }

        public static DataTable GetAllActiveTournaments(int userID)
        {
            return BaseCollection.ExecuteSql(InfiChess.Tournament, "SELECT * , TD = u.UserName, ts.Name as TournamentStatus FROM Tournament t inner join [User] u on u.userid = t.createdby inner join TournamentStatus ts on t.TournamentStatusID = ts.TournamentStatusID where t.CreatedBy = " + userID + " and t.statusID <> 4 AND t.TournamentStatusID <> 3 Order by t.DateCreated DESC", "");
        }

        public static void UpdateStatus(Cxt cxt, StatusE statusID, string tournamentIDs)
        {

            SqlTransaction trans = null;
            Rooms Rooms = new Rooms();

            try
            {
                trans = SqlHelper.BeginTransaction(Config.ConnectionString);

                //BaseCollection.ExecuteSql2(trans, "update Tournament set statusid = @p1 WHERE TournamentID in (@p2)", statusID.ToString("d"), tournamentIDs);

                Tournaments Tournaments = new Tournaments();

                string[] tournamentIDArr = tournamentIDs.Split(',');
                
                for (int i = 0; i < tournamentIDArr.Length; i++)
                {
                    Tournament Tournament = new Tournament(cxt, Convert.ToInt32(tournamentIDArr[i]));

                    Tournament.StatusIDE = statusID;
                    Tournaments.Add(Tournament);
                    Room Room = Room.GetRoomByTournamentID(cxt, Convert.ToInt32(tournamentIDArr[i]));

                    if (Room.RoomID != 0)
                    {
                        if (statusID == StatusE.Deleted)
                        {
                            Room.TournamentID = 0;
                            Room.StatusIDE = StatusE.Inactive;
                            Rooms.Add(Room);
                        }
                    }
                }
                Tournaments.Save(trans);
                if (Rooms.Count > 0)
                    Rooms.Save(trans);
                
                SqlHelper.CommitTransaction(trans);
            }
            catch (Exception ex)
            {
                SqlHelper.RollbackTransaction(trans);
                Log.Write(cxt, ex);
            }

            
        }

        #endregion
    }
}
