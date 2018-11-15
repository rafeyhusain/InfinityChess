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
        #region Knockout Tournament
        /// <summary>
        /// Get Rated player from tournamentmatches
        /// GetTournamentWinners
        /// </summary>
        /// <param name="tournamentID"></param>
        /// <param name="round"></param>
        /// <returns></returns>
        static TournamentUsers GetTournamentWinners(Cxt cxt, int tournamentID, int round)
        {
            DataTable dtWinners = TournamentRounds.GetTournamentWinnersByRound(tournamentID, round - 1);
            TournamentUsers tuWinners = new TournamentUsers(cxt, dtWinners);
            
            return tuWinners;
        }

        static TournamentUsers GetTournamentLosers(Cxt cxt, int tournamentID, int round)
        {
            DataTable dtLosers = TournamentRounds.GetTournamentLosersByRound(tournamentID, round - 1);
            TournamentUsers tuLosers = new TournamentUsers(cxt, dtLosers);

            return tuLosers;
        }

        static TournamentUsers GetTournamentPreliminaryWinners1(Cxt cxt, int tournamentID, int round, DataTable dtTournamentUsers)
        {
            TournamentUsers tuWinners = new TournamentUsers();
            TournamentMatches tournamentMatches = new TournamentMatches(cxt, GetTournamntPlayers(tournamentID));
            TournamentMatches tmW = new TournamentMatches();
            TournamentUsers tuW = new TournamentUsers();
            TournamentUsers tuL = new TournamentUsers();

            int wCounter = 0, bCounter = 0, dCounter = 0;

            foreach (DataRow item in tournamentMatches.DataTable.Rows)
            {
                TournamentMatch tournamentMatch = new TournamentMatch(cxt, item);

                TournamentUser tournamentUserB = null;
                TournamentUser tournamentUserW = null;


                switch (tournamentMatch.GameResultIDE)
                {
                    case GameResultE.None:
                        break;
                    case GameResultE.InProgress:
                        break;
                    case GameResultE.WhiteWin:
                        bCounter += 1;
                        tournamentUserW = TournamentUser.GetTournamentUserById(cxt, tournamentID, tournamentMatch.WhiteUserID);
                        tournamentUserB = TournamentUser.GetTournamentUserById(cxt, tournamentID, tournamentMatch.BlackUserID);
                        tuW.Add(tournamentUserW);
                        tuL.Add(tournamentUserB);
                        break;
                    case GameResultE.WhiteLose:
                        {
                            wCounter += 1;
                            tournamentUserB = TournamentUser.GetTournamentUserById(cxt, tournamentID, tournamentMatch.BlackUserID);
                            tournamentUserW = TournamentUser.GetTournamentUserById(cxt, tournamentID, tournamentMatch.WhiteUserID);
                            tuW.Add(tournamentUserB);
                            tuL.Add(tournamentUserW);
                        }
                        break;
                    case GameResultE.Draw:
                        dCounter += 1;
                        tmW.Add(tournamentMatch);
                        break;
                    case GameResultE.Absent:
                        break;
                    case GameResultE.NoResult:
                        break;
                    case GameResultE.WhiteBye:
                        wCounter += 1;
                        tournamentUserB = TournamentUser.GetTournamentUserById(cxt, tournamentID, tournamentMatch.BlackUserID);
                        tournamentUserW = TournamentUser.GetTournamentUserById(cxt, tournamentID, tournamentMatch.WhiteUserID);
                        tuW.Add(tournamentUserB);
                        tuL.Add(tournamentUserW);
                        break;
                    case GameResultE.BlackBye:
                        bCounter += 1;
                        tournamentUserW = TournamentUser.GetTournamentUserById(cxt, tournamentID, tournamentMatch.WhiteUserID);
                        tournamentUserB = TournamentUser.GetTournamentUserById(cxt, tournamentID, tournamentMatch.BlackUserID);
                        tuW.Add(tournamentUserW);
                        tuL.Add(tournamentUserB);
                        break;
                    case GameResultE.ForcedWhiteWin:
                        bCounter += 1;
                        tournamentUserW = TournamentUser.GetTournamentUserById(cxt, tournamentID, tournamentMatch.WhiteUserID);
                        tournamentUserB = TournamentUser.GetTournamentUserById(cxt, tournamentID, tournamentMatch.BlackUserID);
                        tuW.Add(tournamentUserW);
                        tuL.Add(tournamentUserB);
                        break;
                    case GameResultE.ForcedWhiteLose:
                        wCounter += 1;
                        tournamentUserB = TournamentUser.GetTournamentUserById(cxt, tournamentID, tournamentMatch.BlackUserID);
                        tournamentUserW = TournamentUser.GetTournamentUserById(cxt, tournamentID, tournamentMatch.WhiteUserID);
                        tuW.Add(tournamentUserB);
                        tuL.Add(tournamentUserW);
                        break;
                    case GameResultE.ForcedDraw:
                        dCounter += 1;
                        tmW.Add(tournamentMatch);
                        break;
                    default:
                        break;
                }
            }

            if (dCounter > 0)
            {
                foreach (DataRow item in tmW.DataTable.Rows)
                {
                    TournamentMatch tournamentMatch = new TournamentMatch(cxt, item);
                    if (tournamentMatch.EloWhiteAfter > tournamentMatch.EloBlackAfter)
                    {
                        TournamentUser tournamentUserW = TournamentUser.GetTournamentUserById(cxt, tournamentID, tournamentMatch.WhiteUserID);
                        TournamentUser tournamentUserB = TournamentUser.GetTournamentUserById(cxt, tournamentID, tournamentMatch.BlackUserID);
                        tuW.Add(tournamentUserW);
                        tuL.Add(tournamentUserB);
                    }
                    else if (tournamentMatch.EloBlackAfter > tournamentMatch.EloWhiteAfter)
                    {
                        TournamentUser tournamentUserB = TournamentUser.GetTournamentUserById(cxt, tournamentID, tournamentMatch.BlackUserID);
                        TournamentUser tournamentUserW = TournamentUser.GetTournamentUserById(cxt, tournamentID, tournamentMatch.WhiteUserID);
                        tuW.Add(tournamentUserB);
                        tuL.Add(tournamentUserW);
                    }
                    else
                    {
                        TournamentUser tournamentUserB = TournamentUser.GetTournamentUserById(cxt, tournamentID, tournamentMatch.BlackUserID);
                        TournamentUser tournamentUserW = TournamentUser.GetTournamentUserById(cxt, tournamentID, tournamentMatch.WhiteUserID);
                        tuW.Add(tournamentUserB);
                        tuW.Add(tournamentUserW);
                    }
                }
            }
            if (tuL.Count > 0)
            {
                foreach (DataRow item in dtTournamentUsers.Rows)
                {
                    TournamentUser tu1 = new TournamentUser(cxt, item);

                    if (!tuL.Contains("UserID = " + tu1.UserID))
                    {
                        tuWinners.Add(tu1);
                    }
                }
            }
            return tuWinners;
        }

        static TournamentUsers GetTournamentPreliminaryWinners(Cxt cxt, int tournamentID, int round, DataTable dtTournamentUsers)
        {
            TournamentUsers tuWinners = new TournamentUsers();
            TournamentUsers tuLosers = GetTournamentLosers(cxt, tournamentID, round);

            if (tuLosers.Count > 0)
            {
                foreach (DataRow item in dtTournamentUsers.Rows)
                {
                    TournamentUser tu1 = new TournamentUser(cxt, item);

                    if (!tuLosers.Contains("UserID = " + tu1.UserID))
                    {
                        tuWinners.Add(tu1);
                    }
                }
            }
            return tuWinners;
        }

        static int GetRoundInProgress(Cxt cxt, Tournament tournament)
        {
            DataTable dt = TournamentMatches.GetTournamentsMatchByTournamentID(tournament.TournamentID);
            DataTable dtTournamentUsers = TournamentUsers.GetTournamentUsersByTournamentID(StatusE.Active, tournament.TournamentID);
            
            foreach (DataRow item in dt.Rows)
            {
                TournamentMatch tm = new TournamentMatch(cxt, item);
                if (tm.TournamentMatchStatusE == TournamentMatchStatusE.InProgress || tm.TournamentMatchStatusE == TournamentMatchStatusE.Scheduled)
                {
                    return (int)MsgE.ErrorTournamentNextRoundStarted;       
                }
            }
            
            object objId = dt.Compute("max(Round)", "");            
            int round = Convert.ToInt32(objId);
            DataTable dtRounds = TournamentRounds.GetTournamentWinnersByRound(tournament.TournamentID, round);
            
            if (round == 0 && TournamentMatch.IsPreliminaryRound(round, dtTournamentUsers)) // if it is prelimiry round
            {
                if (dtRounds.Rows.Count == TournamentMatch.CountPreliminaryRoundUsers(dtTournamentUsers))
                {
                    return 0;
                }
                else
                {
                    return (int)MsgE.ErrorTournamentNextRoundStarted;
                }
            }

            DataTable dtUsers = TournamentUsers.GetTournamentUsersByRound(tournament.TournamentID, round);
            
            if (dtRounds.Rows.Count != dtUsers.Rows.Count / 2)
            {
                return (int)MsgE.ErrorTournamentNextRoundStarted;
            }

            return 0;
        }

        public static Kv CreateKnockoutTournament(Cxt cxt, Tournament tournament)
        {
            Kv kv = new Kv();
            int result = GetRoundInProgress(cxt, tournament);

            if (result > 0)
            {
                kv.Set("Result", result);
                return kv;
            }

            CreateKnockoutTournamentMatches(cxt, tournament);

            kv.Set("Result", 0);

            return kv;

        }

        public static Kv IsFinalRoundCompleted(Cxt cxt, Tournament tournament)
        {
            Kv kv = new Kv();
            
            int result = GetRoundInProgress(cxt, tournament);

            if (result == 0)
            {
                result = GetKnockoutTournamentMatchesCount(cxt, tournament);                
            }

            kv.Set("Result", result);

            return kv;
        }

        public static void CreateKnockoutTournamentMatches(Cxt cxt, Tournament tournament)
        {
            DataTable dtTournamentUsers = TournamentUsers.GetTournamentUsersByTournamentID(StatusE.Active, tournament.TournamentID);
            SqlTransaction trans = null;
            try
            {
                trans = SqlHelper.BeginTransaction(Config.ConnectionString);
                CreateKnockoutTournamentMatches(cxt, trans, tournament, dtTournamentUsers);
                SqlHelper.CommitTransaction(trans);
            }
            catch (Exception ex)
            {
                SqlHelper.RollbackTransaction(trans);
                Log.Write(cxt, ex);
            }
        }

        public static void CreateKnockoutTournamentMatches(Cxt cxt, SqlTransaction trans, Tournament tournament, DataTable dtTournamentUsers)
        {
            TournamentMatches tournamentMatches = new TournamentMatches();
            TournamentUsers tournamentUsers = null;
                        
            if (tournament.TournamentCurrentRound > 0)
            {
                TournamentUsers ratedTournamentUsers = null;
                if (TournamentMatch.IsPreliminaryRound(tournament.TournamentCurrentRound - 1, dtTournamentUsers))
                {
                    ratedTournamentUsers = GetTournamentPreliminaryWinners(cxt, tournament.TournamentID, tournament.TournamentCurrentRound, dtTournamentUsers);
                }
                else
                {
                    ratedTournamentUsers = GetTournamentWinners(cxt, tournament.TournamentID, tournament.TournamentCurrentRound);
                }

                if (ratedTournamentUsers.Count == 0)
                {
                    return;
                }

                if (tournament.TournamentCurrentRound > 2) // make sure,"tournament.TournamentCurrentRound - 1" is not preliminary round 
                {
                    TournamentUsers previousRoundUsers = GetTournamentWinners(cxt, tournament.TournamentID, tournament.TournamentCurrentRound - 1);
                    if (previousRoundUsers.Count == 2 && ratedTournamentUsers.Count == 2)
                    {
                        return;
                    }
                }

                CreateKnockoutTournamentMatches(cxt, ratedTournamentUsers, tournamentMatches, tournament.TournamentCurrentRound, tournament);

                if (tournament.MaxWinners >= 3 && ratedTournamentUsers.Count == 2) // for multiple winners
                {
                    ratedTournamentUsers = GetTournamentLosers(cxt, tournament.TournamentID, tournament.TournamentCurrentRound);                    
                    CreateKnockoutTournamentMatches(cxt, ratedTournamentUsers, tournamentMatches, tournament.TournamentCurrentRound, tournament);
                }
            }
            else
            {                

                if (dtTournamentUsers.Rows.Count == 0)
                {
                    return;
                }

                if (tournament.TournamentCurrentRound == 0)
                {
                    if (!TournamentMatch.IsPreliminaryRound(tournament.TournamentCurrentRound, dtTournamentUsers))
                    {
                        tournament.TournamentCurrentRound = 1;
                        tournamentUsers = new TournamentUsers(cxt, dtTournamentUsers);
                        //CreateKnockoutTournamentMatches(cxt, tournamentUsers, tournamentMatches, tournament.TournamentCurrentRound, tournament);
                        //break;
                    }
                    else
                    {
                        tournamentUsers = GetPreliminaryRound(cxt, tournament, dtTournamentUsers);                        
                    }
                }                

                CreateKnockoutTournamentMatches(cxt, tournamentUsers, tournamentMatches, tournament.TournamentCurrentRound, tournament);
            }

            if (tournamentMatches.Count > 0)
            {
                tournamentMatches.Save(trans);
            }
        }

        public static int GetKnockoutTournamentMatchesCount(Cxt cxt, Tournament tournament)
        {
            DataTable dtTournamentUsers = TournamentUsers.GetTournamentUsersByTournamentID(StatusE.Active, tournament.TournamentID);
            TournamentMatches tournamentMatches = new TournamentMatches();
            TournamentUsers tournamentUsers = null;
            
            if (tournament.TournamentCurrentRound > 0)
            {
                TournamentUsers ratedTournamentUsers = null;
                if (TournamentMatch.IsPreliminaryRound(tournament.TournamentCurrentRound - 1, dtTournamentUsers))
                {
                    ratedTournamentUsers = GetTournamentPreliminaryWinners(cxt, tournament.TournamentID, tournament.TournamentCurrentRound, dtTournamentUsers);
                }
                else
                {
                    ratedTournamentUsers = GetTournamentWinners(cxt, tournament.TournamentID, tournament.TournamentCurrentRound);
                }

                if (ratedTournamentUsers.Count == 0)
                {
                    return 0;
                }

                if (tournament.TournamentCurrentRound > 2) // make sure,"tournament.TournamentCurrentRound - 1" is not preliminary round 
                {
                    TournamentUsers previousRoundUsers = GetTournamentWinners(cxt, tournament.TournamentID, tournament.TournamentCurrentRound - 1);
                    if (previousRoundUsers.Count == 2 && ratedTournamentUsers.Count == 2)
                    {
                        return 0;
                    }
                }

                CreateKnockoutTournamentMatches(cxt, ratedTournamentUsers, tournamentMatches, tournament.TournamentCurrentRound, tournament);

                if (tournament.MaxWinners >= 3 && ratedTournamentUsers.Count == 2) // for multiple winners
                {
                    ratedTournamentUsers = GetTournamentLosers(cxt, tournament.TournamentID, tournament.TournamentCurrentRound);
                    CreateKnockoutTournamentMatches(cxt, ratedTournamentUsers, tournamentMatches, tournament.TournamentCurrentRound, tournament);
                }
            }
            else
            {

                if (dtTournamentUsers.Rows.Count == 0)
                {
                    return 0;
                }

                if (tournament.TournamentCurrentRound == 0)
                {
                    if (!TournamentMatch.IsPreliminaryRound(tournament.TournamentCurrentRound, dtTournamentUsers))
                    {
                        tournament.TournamentCurrentRound = 1;
                        tournamentUsers = new TournamentUsers(cxt, dtTournamentUsers);
                        //CreateKnockoutTournamentMatches(cxt, tournamentUsers, tournamentMatches, tournament.TournamentCurrentRound, tournament);
                        //break;
                    }
                    else
                    {
                        tournamentUsers = GetPreliminaryRound(cxt, tournament, dtTournamentUsers);
                    }
                }

                CreateKnockoutTournamentMatches(cxt, tournamentUsers, tournamentMatches, tournament.TournamentCurrentRound, tournament);
            }

            return tournamentMatches.Count;
        }

        static void CreateKnockoutTournamentMatches(Cxt cxt, TournamentUsers tournamentUsers, TournamentMatches tournamentMatches, int round, Tournament Tournament)
        {
            if (tournamentUsers.Count > 0)
            {
                for (int i = 0; i < tournamentUsers.Count / 2; i++)
                {
                    TournamentUser userW = new TournamentUser(cxt, tournamentUsers.DataTable.Rows[i]);
                    TournamentUser userB = new TournamentUser(cxt, tournamentUsers.DataTable.Rows[tournamentUsers.Count - i - 1]);

                    TournamentMatch tournamentMatch = new TournamentMatch(cxt, 0);
                    tournamentMatch.Round = round;
                    tournamentMatch.WhiteUserID = userW.UserID;
                    tournamentMatch.BlackUserID = userB.UserID;
                    tournamentMatch.TournamentID = Tournament.TournamentID;
                    tournamentMatch.TournamentMatchTypeE = TournamentMatchTypeE.Normal;

                    if (Tournament.TournamentStartDate > DateTime.Now)
                    {
                        tournamentMatch.MatchStartDate = Tournament.TournamentStartDate;
                    }
                    else
                    {
                        tournamentMatch.MatchStartDate = DateTime.Now;
                    }

                    if (Tournament.TournamentStartTime > DateTime.Now)
                    {
                        tournamentMatch.MatchStartTime = Tournament.TournamentStartTime;
                    }
                    else
                    {
                        tournamentMatch.MatchStartTime = DateTime.Now;
                    }

                    tournamentMatch.TimeMin = Tournament.TimeControlMin;
                    tournamentMatch.TimeSec = Tournament.TimeControlSec;

                    tournamentMatch.TournamentMatchStatusE = TournamentMatchStatusE.Scheduled;
                    tournamentMatch.EloWhiteBefore = userW.EloBefore;
                    tournamentMatch.EloBlackBefore = userB.EloBefore;
                    tournamentMatch.CreatedBy = Ap.CurrentUserID;
                    tournamentMatch.DateCreated = DateTime.Now;
                    tournamentMatch.StatusID = (int)StatusE.Active;
                    tournamentMatches.Add(tournamentMatch);
                }
            }
        }

        static TournamentUsers IsPreliminaryRound(Cxt cxt, DataTable dtTournamentUsers, ref bool isTrue)
        {
            TournamentUsers preliminaryRoundUsers = null;

            if (dtTournamentUsers.Rows.Count % 2 == 1)
            {
                DataView dv = new DataView(dtTournamentUsers);
                dv.Sort = "EloBefore DESC";
                DataTable dt = dv.ToTable();
                dt.Rows[0].Delete();
                preliminaryRoundUsers = new TournamentUsers(cxt, dt);
                isTrue = true;
            }


            return preliminaryRoundUsers;
        }

        static TournamentUsers GetPreliminaryRound(Cxt cxt, Tournament tournament, DataTable dtTournamentUsers)
        {
            double upperDiff = 0.0, lowerDiff = 0.0;

            TournamentUsers preliminaryRoundUsers = new TournamentUsers();
            bool isTrue = false;
            //preliminaryRoundUsers = IsPreliminaryRound(dtTournamentUsers, ref isTrue);

            if (!isTrue)
            {
                for (int i = 1; i < 20; i++)
                {
                    double dbl = Math.Pow(2, i);
                    if (dbl >= dtTournamentUsers.Rows.Count)
                    {
                        upperDiff = dbl - Convert.ToDouble(dtTournamentUsers.Rows.Count);
                        lowerDiff = Convert.ToDouble(dtTournamentUsers.Rows.Count) - Math.Pow(2, i - 1);

                        DataView dv = new DataView(dtTournamentUsers);
                        dv.Sort = "EloBefore DESC";
                        DataTable dt = dv.ToTable();
                        /*
                        if (lowerDiff == 1.0)
                        {
                            dt.Rows[0].Delete();
                            preliminaryRoundUsers = new TournamentUsers(cxt, dt);
                            break;
                        }
                        else */
                        if (upperDiff == 0.0)
                        {
                            preliminaryRoundUsers = new TournamentUsers(cxt, dt);
                            break;
                        }
                        
                        for (int j = 0; j < lowerDiff * 2; j++)
                        {
                            DataRow dr = dt.Rows[j];
                            TournamentUser tu = new TournamentUser(cxt, dr);
                            preliminaryRoundUsers.Add(tu);
                        }
                        break;
                    }
                }
            }
            return preliminaryRoundUsers;
        }

        #endregion
    }
}
