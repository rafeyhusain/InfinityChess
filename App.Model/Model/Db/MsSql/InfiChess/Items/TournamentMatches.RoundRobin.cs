using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Model.Db;
using System.Data.SqlClient;
using System.Data;


namespace App.Model.Db
{
    public partial class TournamentMatches
    {
        #region Create RoundRobin Match
        private static DataTable BergerTable()
        {
            DataTable T = new DataTable();
            T.Columns.Add("Round");
            T.Columns.Add("Player1");
            T.Columns.Add("Player2");
            return T;
        }


        private static DataTable CalculateParing(int noOfPlayer)
        {
            DataTable T = BergerTable();
            if (noOfPlayer % 2 != 0)
            {
                noOfPlayer = noOfPlayer + 1;
            }
            int[,] pair = new int[(noOfPlayer - 1) * noOfPlayer / 2, 2];

            for (int round = 1, row = 0; round <= noOfPlayer - 1; round++)
            {
                for (int i = 1, j = round - 1, player1 = round, player2 = noOfPlayer; i <= noOfPlayer / 2; i++, player1++)
                {
                    if (player1 == noOfPlayer)
                    {
                        player1 = 1;
                    }
                    if (i > 1 && round > 1 && j >= 1)
                    {
                        pair[row, 1] = j;
                        j = j - 1;
                    }
                    else
                    {
                        pair[row, 1] = player2;
                        player2 = player2 - 1;
                    }
                    pair[row, 0] = player1;
                    row = row + 1;
                }
            }
            for (int round = 1, row = 0, v1 = 0, v2 = (noOfPlayer / 2); round <= (noOfPlayer - 1); round++)
            {
                if (round % 2 != 0)
                {
                    v1 = v1 + 1;
                    row = (v1 - 1) * noOfPlayer / 2;
                }
                else
                {
                    v2 = v2 + 1;
                    row = (v2 - 1) * noOfPlayer / 2;
                }

                for (int i = 0; i < noOfPlayer / 2; i++)
                {
                    if (i == 0 && round % 2 == 0)
                    {
                        T.Rows.Add(round, pair[row + i, 1], pair[row + i, 0]);
                    }
                    else
                    {
                        T.Rows.Add(round, pair[row + i, 0], pair[row + i, 1]);
                    }
                }
            }
            return T;
        }


        static void CalculateRoundRobinMatch(Cxt cxt, int tournamentID, Tournament tournament, List<DataRow> listTournamentUsers)
        {
            TournamentUser userW = null;
            TournamentUser userB = null;

            int dblRound = (tournament.DoubleRound) ? 2 : 1;
            int moderound = (listTournamentUsers.Count % 2 == 1) ? listTournamentUsers.Count : listTournamentUsers.Count - 1;

            for (int counter = 0; counter < dblRound; counter++)
            {
                DataTable dtCalculatePair = CalculateParing(listTournamentUsers.Count);

                for (int i = 0; i < dtCalculatePair.Rows.Count; i++)
                {
                    DataRow drCal = dtCalculatePair.Rows[i];

                    if (counter == 1)
                    {
                        userW = new TournamentUser(cxt, listTournamentUsers[Convert.ToInt32(drCal["Player2"]) - 1]);
                        userB = new TournamentUser(cxt, listTournamentUsers[Convert.ToInt32(drCal["Player1"]) - 1]);
                    }
                    else
                    {
                        userW = new TournamentUser(cxt, listTournamentUsers[Convert.ToInt32(drCal["Player1"]) - 1]);
                        userB = new TournamentUser(cxt, listTournamentUsers[Convert.ToInt32(drCal["Player2"]) - 1]);
                    }
                    int round = Convert.ToInt32(drCal["Round"]);

                    if (counter > 0)
                    {
                        round = round + moderound;
                    }
                    TournamentMatch tournamentMatch = new TournamentMatch(cxt, 0);
                    tournamentMatch.Round = round;
                    tournamentMatch.WhiteUserID = userW.UserID;
                    tournamentMatch.BlackUserID = userB.UserID;
                    tournamentMatch.TournamentID = tournamentID;
                    tournamentMatch.TournamentMatchTypeE = TournamentMatchTypeE.Normal;

                    if (tournament.TournamentStartDate > DateTime.Now)
                    {
                        tournamentMatch.MatchStartDate = tournament.TournamentStartDate;
                    }
                    else
                    {
                        tournamentMatch.MatchStartDate = DateTime.Now;
                    }

                    if (tournament.TournamentStartTime > DateTime.Now)
                    {
                        tournamentMatch.MatchStartTime = tournament.TournamentStartTime;
                    }
                    else
                    {
                        tournamentMatch.MatchStartTime = DateTime.Now;
                    }                   
                    
                    tournamentMatch.TimeMin = tournament.TimeControlMin;
                    tournamentMatch.TimeSec = tournament.TimeControlSec;

                    tournamentMatch.TournamentMatchStatusE = TournamentMatchStatusE.Scheduled;
                    if (userW.UserID == 2 || userB.UserID == 2)
                    {
                        tournamentMatch.TournamentMatchStatusE = TournamentMatchStatusE.Absent;
                    }
                    
                    tournamentMatch.EloWhiteBefore = userW.EloBefore;
                    tournamentMatch.EloBlackBefore = userB.EloBefore;
                    tournamentMatch.CreatedBy = Ap.CurrentUserID;
                    tournamentMatch.DateCreated = DateTime.Now;
                    tournamentMatch.StatusID = (int)StatusE.Active;
                    tournament.TournamentMatches.Add(tournamentMatch);
                }
            }
        }

        #endregion

        #region Create Tournament Match
        public static void CreateTournamentMatch(Cxt cxt, SqlTransaction trans, Tournament tournament, DataTable dtTournamentUsers)
        {
            //DataTable dtTournamentUsers = TournamentUsers.GetTournamentUsersByTournamentID(StatusE.Active, tournament.TournamentID);
            List<DataRow> listUser = new List<DataRow>();
            
            foreach (DataRow item in dtTournamentUsers.Rows)
            {
                listUser.Add(item);
            }

            if (dtTournamentUsers.Rows.Count % 2 != 0)
            {
                User user = User.GetUserByID(cxt, 2); // fill user list with dummy user
                listUser.Add(user.DataRow);
            }
            
            if (listUser.Count > 0)
            {
                //TournamentMatches.DeleteTournamentMatchByTournamentID(trans, tournament.TournamentID);
                CalculateRoundRobinMatch(cxt, tournament.TournamentID, tournament, listUser);
                tournament.TournamentMatches.Save(trans);
            }
        }
        #endregion
    }
}
