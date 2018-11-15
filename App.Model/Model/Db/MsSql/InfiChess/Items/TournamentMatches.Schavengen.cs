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
        #region Schavengen Table
        private static DataTable SchavengenTempTable()
        {
            DataTable T = new DataTable();
            T.Columns.Add("Round");
            T.Columns.Add("Player1");
            T.Columns.Add("Player2");
            return T;
        }

        private static DataTable SchavengenTeamTable()
        {
            DataTable T = new DataTable();
            T.Columns.Add("Round");
            T.Columns.Add("TeamA");
            T.Columns.Add("TeamB");
            return T;
        }

        private static DataTable SchSystems(int userCounter)
        {
            int round = userCounter;
            int halfcounter = 0;
            DataTable T = BergerTable();
            bool c1 = false, c2 = false;
            for (int i = 0; i < round; i++)
            {
                int SecPlayer = 0;
                bool isHalf = false;
                int halfround = 0;

                for (int j = 0, k = 0; j < round; j++, k++)
                {
                    if (i > 0 && i + 1 <= round / 2)
                    {
                        if (SecPlayer == (round * 2)) // value will be greater then the half of round then true
                        {

                            halfround = j + 1 + (2 * i);
                            isHalf = true;
                        }
                        else
                        {
                            SecPlayer = round + (i * 2) + k + 1;
                            isHalf = false;
                        }
                    }
                    else if (i + 1 > round / 2)
                    {
                        if (SecPlayer == (round * 2)) // value will be greater then the half of round then true
                        {
                            halfround = j + 1 + (halfcounter * 2) + 1;
                            isHalf = true;
                        }
                        else
                        {
                            SecPlayer = (j + 1) + (round + (halfcounter * 2) + 1);
                            isHalf = false;
                        }
                    }
                    else
                    {
                        SecPlayer = round + k + 1;
                    }

                    int playerA = 0, playerB = 0;
                    if (isHalf)
                    {
                        if (c1 == false)
                        {
                            playerA = j + 1;
                            playerB = halfround;
                            c1 = true;
                        }
                        else
                        {
                            playerA = halfround;
                            playerB = j + 1;
                            c1 = false;
                        }
                    }
                    else
                    {
                        if (c1 == false)
                        {
                            playerA = j + 1; ;
                            playerB = SecPlayer;
                            c1 = true;
                        }
                        else
                        {
                            playerA = SecPlayer;
                            playerB = j + 1;
                            c1 = false;
                        }
                    }
                    DataRow dr = T.NewRow();
                    dr["Round"] = i + 1;
                    dr["Player1"] = playerA;
                    dr["Player2"] = playerB;
                    T.Rows.Add(dr);
                }
                if (i + 1 > round / 2)
                {
                    halfcounter += 1;
                }

                if (c2 == false)
                {
                    c2 = true;
                    c1 = true;
                }
                else
                {
                    c2 = false;
                    c1 = false;
                }
            }
            return T;
        }

        public static DataTable SchSystemsOdd(int userCounter)
        {
            decimal round = Convert.ToDecimal(userCounter);
            decimal halfcounter = 0;
            DataTable T = BergerTable();
            bool c1 = false, c2 = false;
            for (decimal i = 0; i < round; i++)
            {
                decimal SecPlayer = 0;
                bool isHalf = false;
                decimal halfround = 0;

                for (decimal j = 0, k = 0; j < round; j++, k++)
                {
                    if (i > 0 && i + 1 <= Math.Ceiling(round / 2))
                    {
                        if (SecPlayer == (round * 2)) // value will be greater then the half of round then true
                        {

                            halfround = j + 1 + (2 * i);
                            isHalf = true;
                        }
                        else
                        {
                            SecPlayer = round + (i * 2) + k + 1;
                            isHalf = false;
                        }
                    }
                    else if (i + 1 > Math.Ceiling(round / 2))
                    {
                        if (SecPlayer == (round * 2)) // value will be greater then the half of round then true
                        {

                            halfround = j + 1 + (halfcounter * 2) + 1;
                            isHalf = true;
                        }
                        else
                        {
                            SecPlayer = (j + 1) + (round + (halfcounter * 2) + 1);
                            isHalf = false;
                        }
                    }
                    else
                    {
                        SecPlayer = round + k + 1;
                    }
                    decimal playerA = 0, playerB = 0;

                    if (isHalf)
                    {
                        if (c1 == false)
                        {
                            playerA = j + 1;
                            playerB = halfround;
                            c1 = true;
                        }
                        else
                        {
                            playerA = halfround;
                            playerB = j + 1; ;
                            c1 = false;
                        }
                    }
                    else
                    {
                        if (c1 == false)
                        {
                            playerA = j + 1;
                            playerB = SecPlayer;
                            c1 = true;
                        }
                        else
                        {
                            playerA = SecPlayer;
                            playerB = j + 1;
                            c1 = false;
                        }
                    }
                    DataRow dr = T.NewRow();
                    dr["Round"] = i + 1;
                    dr["Player1"] = playerA;
                    dr["Player2"] = playerB;
                    T.Rows.Add(dr);
                }

                if (i + 1 > Math.Ceiling(round / 2))
                {
                    halfcounter += 1;
                }

                if (c2 == false)
                {
                    c2 = true;
                    c1 = true;
                }
                else
                {
                    c2 = false;
                    c1 = false;
                }
            }
            return T;
        }

        public static DataTable SchTeamPairing(int teamCounter)
        {
            DataTable T = SchavengenTeamTable();
            int n = teamCounter;
            int count = 0;
            int teamA = 0, teamB = 0;
            bool isRandom = true;
            for (int i = 0; i < n - 1; i++)
            {
                int counter = 0;
                for (int j = i; j < n - 1; j++)
                {
                    if (isRandom)
                    {
                        teamA = i + 1;
                        teamB = j + 1 + 1;
                        isRandom = false;
                    }
                    else
                    {
                        teamA = j + 1 + 1;
                        teamB = i + 1;
                        isRandom = true;
                    }

                    DataRow dr = T.NewRow();
                    dr["Round"] = i + 1;
                    dr["TeamA"] = teamA;
                    dr["TeamB"] = teamB;
                    T.Rows.Add(dr);

                    counter++;
                }                
                count += counter;
            }
            return T;
        }
        #endregion

        
        public static void CreateSchavengenSystem(Cxt cxt, SqlTransaction trans, Tournament tournament, DataTable dtTournamentUsers)
        {            
            int roundValue = 1; 
            int val = 0;

            TournamentMatches.DeleteTournamentMatchByTournamentID(trans, tournament.TournamentID);

            Teams Teams = new Teams(cxt, Teams.GetTeamsByTournamentID(tournament.TournamentID));
            roundValue = 1;
            int round = dtTournamentUsers.Rows.Count / Teams.Count;

            int doubleRoundNo = tournament.DoubleRoundNo * 2;

            if (doubleRoundNo == 0)
            {
                doubleRoundNo = 1;
            }

            bool isWhite = false;
            for (int k = 0; k <= doubleRoundNo-1; k++)
            {
                if (isWhite)
                {
                    isWhite = false;
                }
                else
                {
                    isWhite = true;
                }

                //Teams Teams = new Teams(cxt, Teams.GetTeamsByTournamentID(tournament.TournamentID));

                if (Teams.Count > 0)
                {
                    DataTable dtCalculatePair = SchTeamPairing(Teams.Count);
                    Team teamW = null;
                    Team teamB = null;
                    
                    for (int i = 0; i < dtCalculatePair.Rows.Count; i++)
                    {                        
                        DataRow drCal = dtCalculatePair.Rows[i];

                        teamW = Teams[Convert.ToInt32(drCal["TeamA"]) - 1];
                        teamB = Teams[Convert.ToInt32(drCal["TeamB"]) - 1];       

                        dtTournamentUsers.DefaultView.RowFilter = "TeamID = " + teamW.TeamID.ToString() + " or TeamID = " + teamB.TeamID.ToString();
                        dtTournamentUsers.DefaultView.Sort = "TeamID";
                        TournamentUsers tu = new TournamentUsers(cxt, dtTournamentUsers.DefaultView.ToTable());


                        
                        if (tu.Count > 0)
                        {
                            CreateSchavengenMatches(cxt, tournament, tu, isWhite, k, round, ref val, ref roundValue);
                            tournament.TournamentMatches.Save(trans);
                        }
                    }
                }
            }
        }

        private static void CreateSchavengenMatches(Cxt cxt, Tournament tournament, TournamentUsers TournamentUsers, bool isWhite, int counter, 
            int round, ref int val, ref int roundValue)
        {
            
            TournamentUser userW = null;
            TournamentUser userB = null;
            
            if (TournamentUsers.Count > 0)
            {
                DataTable dt = null;
                if ((TournamentUsers.Count / 2) % 2 == 1)
                {
                    dt = SchSystemsOdd(TournamentUsers.Count / 2);
                }
                else
                {
                    dt = SchSystems(TournamentUsers.Count / 2);
                }

                //DataRow[] dr = dt.Select("1=1", "Round desc");

                //int round = i + counter * Convert.ToInt32(dr[0]["Round"]);
                
                foreach (DataRow item in dt.Rows)
                {

                    if (val == round)
                    {
                        roundValue++;
                        val = 0;
                    }

                    if (isWhite)
                    {
                        userW = new TournamentUser(Cxt.Instance, TournamentUsers[Convert.ToInt32(item["Player1"]) - 1]);
                        userB = new TournamentUser(Cxt.Instance, TournamentUsers[Convert.ToInt32(item["Player2"]) - 1]);
                    }
                    else
                    {
                        userW = new TournamentUser(Cxt.Instance, TournamentUsers[Convert.ToInt32(item["Player2"]) - 1]);
                        userB = new TournamentUser(Cxt.Instance, TournamentUsers[Convert.ToInt32(item["Player1"]) - 1]);
                    }
                    TournamentMatch tournamentMatch = new TournamentMatch(cxt, 0);
                    tournamentMatch.Round = roundValue;
                    tournamentMatch.WhiteUserID = userW.UserID;
                    tournamentMatch.BlackUserID = userB.UserID;
                    tournamentMatch.TournamentID = tournament.TournamentID;
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
                    tournamentMatch.EloWhiteBefore = userW.EloBefore;
                    tournamentMatch.EloBlackBefore = userB.EloBefore;
                    tournamentMatch.CreatedBy = cxt.CurrentUserID;
                    tournamentMatch.DateCreated = DateTime.Now;
                    tournamentMatch.StatusID = (int)StatusE.Active;
                    tournament.TournamentMatches.Add(tournamentMatch);
                    val++;
                }
            }
        }

        private static void CreateSchavengenMatches(Cxt cxt, Tournament tournament, TournamentUsers TournamentUsers)
        {

            TournamentUser userW = null;
            TournamentUser userB = null;

            if (TournamentUsers.Count > 0)
            {
                DataTable dt = null;
                if ((TournamentUsers.Count / 2) % 2 == 1)
                {
                    dt = SchSystemsOdd(TournamentUsers.Count / 2);
                }
                else
                {
                    dt = SchSystems(TournamentUsers.Count / 2);
                }


                foreach (DataRow item in dt.Rows)
                {

                    userW = new TournamentUser(Cxt.Instance, TournamentUsers[Convert.ToInt32(item["Player1"]) - 1]);
                    userB = new TournamentUser(Cxt.Instance, TournamentUsers[Convert.ToInt32(item["Player2"]) - 1]);

                    TournamentMatch tournamentMatch = new TournamentMatch(cxt, 0);
                    tournamentMatch.Round = Convert.ToInt32(item["Round"]);
                    tournamentMatch.WhiteUserID = userW.UserID;
                    tournamentMatch.BlackUserID = userB.UserID;
                    tournamentMatch.TournamentID = tournament.TournamentID;
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
                    tournamentMatch.EloWhiteBefore = userW.EloBefore;
                    tournamentMatch.EloBlackBefore = userB.EloBefore;
                    tournamentMatch.CreatedBy = cxt.CurrentUserID;
                    tournamentMatch.DateCreated = DateTime.Now;

                    tournament.TournamentMatches.Add(tournamentMatch);

                }
            }
        }

    }
}
