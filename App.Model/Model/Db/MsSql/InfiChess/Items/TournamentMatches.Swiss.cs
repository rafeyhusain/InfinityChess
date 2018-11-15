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
        #region Create Swiss Tournament

        public static Kv CreateSwissTournament(Cxt cxt, Tournament Tournament)
        {
            //Kv kv = new Kv();
            //int result = GetRoundInProgress(cxt, Tournament);

            //if (result > 0)
            //{
            //    kv.Set("Result", result);
            //    return kv;
            //}

            //CreateSwissTournamentMatches(cxt, Tournament);

            //kv.Set("Result", 0);

            //return kv;

            SqlTransaction trans = null;
            try
            {
                trans = SqlHelper.BeginTransaction(Config.ConnectionString);
                TournamentMatches t = new TournamentMatches();
                t.CreateSwissRound1(cxt, trans, Tournament, 0, 0);
                SqlHelper.CommitTransaction(trans);
            }
            catch (Exception ex)
            {
                SqlHelper.RollbackTransaction(trans);
                Log.Write(cxt, ex);
            }

            return new Kv();
        }
            
         
        

        public static void CreateSwissTournamentMatches(Cxt cxt, Tournament Tournament)
        {
            SqlTransaction trans = null;
            try
            {
                trans = SqlHelper.BeginTransaction(Config.ConnectionString);

                CreateSwissTournamentMatches(cxt, trans, Tournament);

                SqlHelper.CommitTransaction(trans);
            }
            catch (Exception ex)
            {
                SqlHelper.RollbackTransaction(trans);
                Log.Write(cxt, ex);
            }

        }

        public static void CreateSwissTournamentMatches(Cxt cxt, SqlTransaction trans, Tournament Tournament)
        {
            DataTable dtTournamentUsers = TournamentUsers.GetTournamentUsersByTournamentID(StatusE.Active, Tournament.TournamentID);
            TournamentUsers tournamentUsers = new TournamentUsers(cxt, dtTournamentUsers);
            TournamentMatches tournamentMatchRounds = new TournamentMatches(cxt, GetTournamntMatchByTournamentID(Tournament.TournamentID));

            if (tournamentMatchRounds.DataTable.Rows.Count > 0)
            {
                TournamentMatch tournamentMatch = new TournamentMatch(cxt, tournamentMatchRounds.DataTable.Rows[tournamentMatchRounds.DataTable.Rows.Count - 1]);
                if (tournamentMatch.Round >= 1)
                {
                    CreateSwissRound(cxt, trans, Tournament, tournamentMatch.Round);
                    return;
                }
            }
            else
            {
                //CreateRound(trans, tournamentUsers, 1);
            }
        }

        #endregion

        #region Create Swiss Tournament
        public static void CreateRound(Cxt cxt, SqlTransaction trans, TournamentUsers tournamentUsers, int round, Tournament Tournament)
        {
            TournamentMatches tournamentMatches = new TournamentMatches(cxt, GetTournamntMatch());

            if (tournamentUsers.DataTable.Rows.Count == 0)
            {
                return;
            }
         
            DataView dv = tournamentUsers.DataTable.DefaultView;
            dv.Sort = "EloBefore desc";
           
            int playerCount = dv.Table.Rows.Count;
            short flag = 0;
            tournamentUsers = null;
            tournamentUsers = new TournamentUsers(cxt, dv.ToTable());

            if (tournamentUsers.DataTable.Rows.Count % 2 == 1)
            {
                TournamentUser tournamentUser = tournamentUsers[tournamentUsers.DataTable.Rows.Count - 1];
            }

            for (int i = 0; i < tournamentUsers.DataTable.Rows.Count / 2; i++)
            {
                TournamentMatch TournamentMatch = tournamentMatches.NewItem();
                int white, black;
                if (flag == 0) // flag ==0 --> White, flag ==1 --> black
                {
                    white = i;
                    black = playerCount / 2 + i;
                    flag = 1;
                }
                else
                {
                    black = i;
                    white = playerCount / 2 + i;
                    flag = 0;
                }

                TournamentUser TournamentUserWhite = tournamentUsers[white];
                TournamentUser TournamentUserBlack = tournamentUsers[black];

                TournamentMatch.WhiteUserID = TournamentUserWhite.UserID;
                TournamentMatch.BlackUserID = TournamentUserBlack.UserID;

                TournamentMatch.EloWhiteBefore = TournamentUserWhite.EloBefore;
                TournamentMatch.EloBlackBefore = TournamentUserBlack.EloBefore;

                TournamentMatch.Round = round;
                TournamentMatch.TournamentID = Tournament.TournamentID;
                TournamentMatch.MatchStartDate = DateTime.Now;
                TournamentMatch.MatchStartTime = DateTime.Now;
                TournamentMatch.TimeMin = Tournament.TimeControlMin;
                TournamentMatch.TimeSec = Tournament.TimeControlSec;
                TournamentMatch.TournamentMatchStatusE = TournamentMatchStatusE.Scheduled;
                TournamentMatch.CreatedBy = Ap.CurrentUserID;
                TournamentMatch.DateCreated = DateTime.Now;
                TournamentMatch.TournamentMatchTypeE = TournamentMatchTypeE.Normal;
                TournamentMatch.StatusID = (int)StatusE.Active;
                tournamentMatches.Add(TournamentMatch);
            }
            tournamentMatches.Save(trans);
        }

        static bool IsMatchPlayed(Cxt cxt, TournamentUsers tournamentUsers, int wUserID, int bUserID)
        {
            int tournamentID = 0;

            DataTable dtTournamentMatches = GetTournamntMatchByTournamentID(tournamentID);

            DataRow[] drWhite = dtTournamentMatches.Select("WhiteUserID = " + wUserID + " and BlackUserID = " + bUserID);
            DataRow[] drBlack = dtTournamentMatches.Select("BlackUserID = " + wUserID + " and WhiteUserID = " + bUserID);
            if (drWhite.Length > 0 || drBlack.Length > 0)
            {
                return true;
            }
            else if (tournamentUsers.DataTable.Rows.Count > 0)
            {
                foreach (DataRow item in tournamentUsers.DataTable.Rows)
                {
                    TournamentUser tournamentUser = new TournamentUser(cxt, item);
                    if (tournamentUser.UserID == wUserID || tournamentUser.UserID == bUserID)
                    {
                        return true;
                    }
                    //working here on saturday
                }
            }
            return false;
        }

        public static void CreateSwissRound(Cxt cxt, SqlTransaction trans, Tournament Tournament, int Round)
        {
            DataTable dtTournamentUsers = TournamentUsers.GetTournamentUsersByTournamentID(StatusE.Active, Tournament.TournamentID);
            TournamentMatches tournamentMatches = new TournamentMatches(cxt, GetTournamntMatch());
            TournamentMatches tournamentMatchRounds = new TournamentMatches(cxt, GetTournamntMatchByTournamentID(Tournament.TournamentID));
            TournamentUsers tournamentUsers = new TournamentUsers(cxt, dtTournamentUsers);
            int round = 0;
            int team = 0;
            if (dtTournamentUsers.Rows.Count == 0)
            {
                return;
            }

            DataTable dtGroup = TournamentUsers.GetTournamentUsersGroupByTournamentPoint(Tournament.TournamentID);

            if (dtGroup.Rows.Count > 0)
            {
                round = Round;
                //team = round * 2 + 1;
                //Round = round + 1; 
                team = dtGroup.Rows.Count;
            }

            DataRow[][] Teams = new DataRow[team][];
            DataRow[][] TeamsBackup = new DataRow[team][];
            DataRow[] TeamsHalfResult = null;

            int j = 0;
            Decimal[] arr = new decimal[team];

            foreach (DataRow item in dtGroup.Rows)
            {
                int count = Convert.ToInt32(item["MatchCount"]);
                Teams[j] = new DataRow[count];
                arr[j] = Convert.ToDecimal(item["TournamentPoints"]);
                TeamsBackup[j] = new DataRow[count];
                j++;
            }
            short IsMode = 0;

            DataView dv = tournamentUsers.DataTable.DefaultView;
            for (int i = 0; i <= arr.Length - 1; i++)
            {
                dv.Sort = "TournamentPoints DESC, EloBefore DESC";
                dv.RowFilter = "TournamentPoints = " + Decimal.ToSingle(arr[i]).ToString();

                if (arr[i].ToString() == "0.5")
                {
                    IsMode = 1;
                    TeamsHalfResult = new DataRow[dv.ToTable().Rows.Count];
                    for (int k = 0; k < dv.ToTable().Rows.Count; k++)
                    {
                        DataRow item = dv.ToTable().Rows[k];
                        TeamsHalfResult[k] = item;
                    }
                    continue;
                }
                for (int k = 0; k < dv.ToTable().Rows.Count; k++)
                {
                    DataRow item = dv.ToTable().Rows[k];
                    Teams[i][k] = item;
                }
            }
            if (IsMode == 1)
                FillHalfResult(Teams, TeamsHalfResult);
            SetList(Teams, TeamsBackup, null, 0, 0);

            //int j = 0;
            for (int i = 0; i <= Teams.GetUpperBound(0); i++)
            {
                TournamentUsers tournamentUsers2 = new TournamentUsers();
                for (int k = 0; k <= Teams[i].GetUpperBound(0); k++)
                {
                    DataRow dr = Teams[i][k];
                    if (dr == null)
                        continue;
                    TournamentUser tournamentUser = new TournamentUser(cxt, dr);
                    tournamentUsers2.Add(tournamentUser);
                }
                if (tournamentUsers2.DataTable != null)
                    CreateRound(cxt, trans, tournamentUsers2, Round + 1, Tournament);
            }
        }

        static DataTable GetNewTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("Id"));
            dt.Columns.Add(new DataColumn("Round"));
            dt.Columns.Add(new DataColumn("TournamentID"));
            dt.Columns.Add(new DataColumn("TournamentMatchID"));
            dt.Columns.Add(new DataColumn("WhiteUserID"));
            dt.Columns.Add(new DataColumn("BlackUserID"));
            dt.Columns.Add(new DataColumn("TournamentPoints"));

            return dt;
        }
        
        #endregion

        #region Swiss Tournament - New 
        /*
        DataTable TournamentUsersData = null;
        DataTable TournamentMatchesData = null;
        DataTable GroupData = null;

        DataTable PlayersData = null;
        DataSet ScoreGroupsDataSet = null;
        DataTable PairingsData = null;
        
        public void CreateSwissRound1(Cxt cxt, SqlTransaction trans, Tournament Tournament, int Round, int i)
        {
            DataTable dt = GetNewTable();

            TournamentUsersData = TournamentUsers.GetTournamentUsersByTournamentID(StatusE.Active, Tournament.TournamentID);
            TournamentMatchesData = GetTournamntMatchByTournamentID(Tournament.TournamentID);

            DataView dv = TournamentUsersData.DefaultView;

            dv.Sort = "TournamentPoints, EloAfter desc";

            DataView dvMatches = TournamentMatchesData.DefaultView;
            dvMatches.Sort = "Round desc";

            if (dvMatches.Count > 0)
            {
                Round = Convert.ToInt32(dvMatches[0]["Round"]) + 1;
            }

            GroupData = TournamentUsers.GetTournamentUsersGroupByTournamentPoint(Tournament.TournamentID);
            try
            {
                // swiss matches paired according to the article :
                // http://www.fide.com/fide/handbook.html?id=84&view=article

                PlayersData = LoadPlayersDetails(cxt, dv.ToTable().Select(), "");
                ScoreGroupsDataSet = LoadScoreGroups(cxt);
                PairingsData = CreatePairings(cxt);

                CreateSwissMatches(cxt, trans, Tournament, Round);
                
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }

        private void CreateSwissMatches(Cxt cxt, SqlTransaction trans, Tournament Tournament, int Round)
        {
            TournamentMatches tournamentMatches = new TournamentMatches();

            foreach (DataRow drPair in PairingsData.Rows)
            {
                int whiteId = Convert.ToInt32(drPair[PlayerWhite]);
                int blackId = Convert.ToInt32(drPair[PlayerBlack]);

                TournamentMatch m = new TournamentMatch(cxt, 0);

                TournamentUser TournamentUserWhite =  TournamentUser.GetTournamentUserById(cxt, Tournament.TournamentID, whiteId);
                TournamentUser TournamentUserBlack = TournamentUser.GetTournamentUserById(cxt, Tournament.TournamentID, blackId);

                m.WhiteUserID = TournamentUserWhite.UserID;
                m.BlackUserID = TournamentUserBlack.UserID;

                m.EloWhiteBefore = TournamentUserWhite.EloBefore;
                m.EloBlackBefore = TournamentUserBlack.EloBefore;

                m.Round = Round;
                m.TournamentID = Tournament.TournamentID;
                m.MatchStartDate = DateTime.Now;
                m.MatchStartTime = DateTime.Now;
                m.TimeMin = Tournament.TimeControlMin;
                m.TimeSec = Tournament.TimeControlSec;
                m.TournamentMatchStatusE = TournamentMatchStatusE.Scheduled;
                m.CreatedBy = Ap.CurrentUserID;
                m.DateCreated = DateTime.Now;
                m.TournamentMatchTypeE = TournamentMatchTypeE.Normal;

                tournamentMatches.Add(m);

            }
            tournamentMatches.Save(trans);

        }
        
        #region PlayersTable Columns

        const string UserId = "UserId";
        const string No = "No";
        const string PreferenceColor = "PreferenceColor";
        const string Name = "Name";
        const string Rating = "Rating";
        const string Score = "Score";
        const string IsDf = "IsDf";
        const string IsUf = "IsUf";
        const string ExchangePlayerIds = "ExchangePlayerIds";
        const string IsBye = "IsBye";

        #endregion

        #region PairingsTable Columns

        const string GameNo = "GameNo";
        const string PlayerWhite = "PlayerWhite";
        const string PlayerBlack = "PlayerBlack";

        #endregion

        #region InitTables

        private DataTable InitPlayersTable(string tableName)
        {
            DataTable dt = new DataTable(tableName);

            dt.Columns.Add(UserId, typeof(int));
            dt.Columns.Add(No, typeof(int));
            dt.Columns.Add(Name, typeof(string));
            dt.Columns.Add(Rating, typeof(int));
            dt.Columns.Add(Score, typeof(float));
            dt.Columns.Add(IsDf, typeof(bool));
            dt.Columns.Add(IsUf, typeof(bool));
            dt.Columns.Add(ExchangePlayerIds, typeof(string));
            dt.Columns.Add(IsBye, typeof(bool));

            return dt;
        }

        private DataTable InitPairingsTable()
        {
            DataTable dt = new DataTable("Pairings");

            dt.Columns.Add(GameNo, typeof(int));
            dt.Columns.Add(PlayerWhite, typeof(int));
            dt.Columns.Add(PlayerBlack, typeof(int));

            return dt;
        }

        #endregion

        #region LoadTables

        private DataTable LoadPlayersDetails(Cxt cxt, DataRow[] drTourUsers, string tableName)
        {
            DataTable dtPlayers = InitPlayersTable(tableName);
            TournamentUser tu;
            int no = 1;

            foreach (DataRow drUser in drTourUsers)
            {
                tu = new TournamentUser(cxt, drUser);
                DataRow drPlayer = dtPlayers.NewRow();

                drPlayer[UserId] = tu.UserID;
                drPlayer[No] = no++;
                drPlayer[Name] = tu.Name;
                drPlayer[Rating] = tu.EloAfter;
                drPlayer[Score] = tu.TournamentPoints;
                drPlayer[IsDf] = false;
                drPlayer[IsUf] = false;
                drPlayer[ExchangePlayerIds] = "";
                drPlayer[IsBye] = false;

                dtPlayers.Rows.Add(drPlayer);
            }

            return dtPlayers;
        }

        private DataSet LoadScoreGroups(Cxt cxt)
        {
            DataSet dsScoreGroups = new DataSet("ScoreGroups");
            DataTable dtPlayers = null;
            DataRow[] drTourPlayers = null;
            string points = "";

            foreach (DataRow dr in GroupData.Rows)
            {
                points = dr["TournamentPoints"].ToString();
                drTourPlayers = TournamentUsersData.Select("TournamentPoints = " + points);
                dtPlayers = LoadPlayersDetails(cxt, drTourPlayers, (dsScoreGroups.Tables.Count + 1).ToString());

                dsScoreGroups.Tables.Add(dtPlayers);
            }

            return dsScoreGroups;
        }

        #endregion

        #region CreatePairings

        private DataTable CreatePairings(Cxt cxt)
        {
            List<int> t = new List<int>();

            
            
            
            // 9.2	The players with the same score form a score-group. The Median Score-group is the score-group with players having 
            //      the score equal to half the number of rounds that have been played. Pairing begins with the highest score-group and proceeds 
            //      downward until just before the Median Score-group, then continues with the lowest score-group and proceeds upwards to the 
            //      Median Score-Group which is paired last. The Median-Score-group is paired downward.

            if (GroupData.Rows.Count == 0)
            {
                return null;
            }

            DataTable dtPairings = InitPairingsTable();
            string points = "";
            DataTable dtScoreGroup = null;

            int median = GroupData.Rows.Count / 2;
            if (GroupData.Rows.Count % 2 > 0)
            {
                median++;
            }

            int tableIndex = -1;
            DataTable dtMedianSG = null;
            List<int> lowerGroupsTables = new List<int>();

            foreach (DataRow dr in GroupData.Rows)
            {
                points = dr["TournamentPoints"].ToString();
                dtScoreGroup = GetPointsTable(points);

                tableIndex = Convert.ToInt32(dtScoreGroup.TableName);
                if (tableIndex == median)
                {
                    dtMedianSG = dtScoreGroup;
                }
                else if (tableIndex < median)
                {
                    CreatePairing(dtPairings, dtScoreGroup, median);
                }
                else if (tableIndex > median)
                {
                    lowerGroupsTables.Add(tableIndex);
                }
            }
            
            for (int i = lowerGroupsTables.Count -1; i >= 0; i--)
            {
                tableIndex = lowerGroupsTables[i];
                dtScoreGroup = ScoreGroupsDataSet.Tables[tableIndex - 1];
                CreatePairing(dtPairings, dtScoreGroup, median);
            }

            if (dtMedianSG != null)
            {
                CreatePairing(dtPairings, dtMedianSG, median);
            }

            return dtPairings;
        }

        private DataTable GetPointsTable(string points)
        {
            int index = 0;
            DataTable dt = null;

            foreach (DataRow dr in GroupData.Rows)
            {
                if (points == dr["TournamentPoints"].ToString())
                {
                    dt = ScoreGroupsDataSet.Tables[index];
                    break;
                }
                index++;
            }

            return dt;
        }

        private void CreatePairing(DataTable dtPairings, DataTable dtScoreGroup, int median)
        {
            if (dtScoreGroup.Rows.Count == 0)
            {
                return;
            }

            DataRow drPair = null;
            int tableIndex = Convert.ToInt32(dtScoreGroup.TableName);
            int s1Index = -1;
            int s2Index = -1;
            bool isDown = tableIndex <= median;
            bool isS1White = true;

            dtScoreGroup = SortTable(dtScoreGroup, "Score  desc");
            
            if (dtScoreGroup.Rows.Count % 2 > 0)
            {
                // 9.3 (d) it is necessary to make even the number of players in the score-group.
                FloatPlayer(dtScoreGroup, isDown);
            }

            s2Index = dtScoreGroup.Rows.Count / 2;
            bool isColorCompatible = false;
            bool isPairFound = false;
            int player1Id = -1;
            int player2Id = -1;

            // 9.4	The players in a score-group, after transfer of players where necessary, are arranged in the order of 
            //  their pairing numbers and the players in the top half are tentatively paired with the players in the bottom half. 
            //  These pairings are said to be proposed pairings, to be confirmed after scrutiny for compatibility and proper colour. 
            //  If the players in a score-group are numbered : 1, 2, 3 ... n, then the proposed pairings are (ignoring colours): 
            //  1 v (n/2 + 1), 2 v (n/2 + 2), 3 v (n/2 + 3) ... n/2 v n.

            #region Downward Pairing 
            
            if (isDown)
            {
                for (s1Index = 0; s1Index < dtScoreGroup.Rows.Count / 2; s1Index++)
                {
                    isPairFound = false;
                    drPair = dtPairings.NewRow();
                    drPair[GameNo] = dtPairings.Rows.Count + 1;

                    player1Id = Convert.ToInt32(dtScoreGroup.Rows[s1Index][UserId]);
                    player2Id = Convert.ToInt32(dtScoreGroup.Rows[s2Index][UserId]);

                    #region Chgeck Players Compatiblity and Search Compatible Opponent

                    isColorCompatible = IsColorCompatible(player1Id, isS1White);
                    if (isColorCompatible)
                    {
                        drPair[PlayerWhite] = player1Id;
                        player2Id = GetCompatibleOpponent(player1Id, !isS1White, s1Index, s2Index, dtScoreGroup.Rows.Count / 2, isDown, dtScoreGroup);
                        if (player2Id != -1)
                        {
                            drPair[PlayerBlack] = player2Id;
                            isPairFound = true;
                        }
                    }
                    else
                    {
                        isColorCompatible = IsColorCompatible(player1Id, !isS1White);
                        if (isColorCompatible)
                        {
                            drPair[PlayerWhite] = player1Id;
                            player2Id = GetCompatibleOpponent(player1Id, isS1White, s1Index, s2Index, dtScoreGroup.Rows.Count / 2, isDown, dtScoreGroup);
                            if (player2Id != -1)
                            {
                                drPair[PlayerBlack] = player2Id;
                                isPairFound = true;
                            }
                        }
                    }

                    #endregion

                    if (isPairFound) // if Pair founded, then add it to pairings data.
                    {
                        dtScoreGroup.Rows[s1Index][IsDf] = false;
                        dtScoreGroup.Rows[s1Index][IsUf] = false;
                        dtPairings.Rows.Add(drPair);
                    }
                    else // else set its flags to DownFloat or UpFloat.
                    {
                        dtScoreGroup.Rows[s1Index][IsDf] = isDown;
                        dtScoreGroup.Rows[s1Index][IsUf] = !isDown;
                    }

                    RemoveExchanges(dtScoreGroup);

                    isS1White = !isS1White;
                    s2Index++;
                }
            }

            #endregion

            #region Upward Pairing

            else 
            {
                s2Index = dtScoreGroup.Rows.Count - 1;
                s1Index = (dtScoreGroup.Rows.Count / 2);
                if (dtScoreGroup.Rows.Count % 2 == 0)
                {
                    s1Index = s1Index - 1;
                }

                for (s2Index = dtScoreGroup.Rows.Count - 1; s2Index >= dtScoreGroup.Rows.Count / 2; s2Index--)
                {
                    isPairFound = false;
                    drPair = dtPairings.NewRow();
                    drPair[GameNo] = dtPairings.Rows.Count + 1;

                    player1Id = Convert.ToInt32(dtScoreGroup.Rows[s1Index][UserId]);
                    player2Id = Convert.ToInt32(dtScoreGroup.Rows[s2Index][UserId]);

                    #region Chgeck Players Compatiblity and Search Compatible Opponent

                    isColorCompatible = IsColorCompatible(player1Id, isS1White);
                    if (isColorCompatible)
                    {
                        drPair[PlayerWhite] = player1Id;
                        player2Id = GetCompatibleOpponent(player1Id, !isS1White, s1Index, s2Index, dtScoreGroup.Rows.Count / 2, isDown, dtScoreGroup);
                        if (player2Id != -1)
                        {
                            drPair[PlayerBlack] = player2Id;
                            isPairFound = true;
                        }
                    }
                    else
                    {
                        isColorCompatible = IsColorCompatible(player1Id, !isS1White);
                        if (isColorCompatible)
                        {
                            drPair[PlayerBlack] = player1Id;
                            player2Id = GetCompatibleOpponent(player1Id, isS1White, s1Index, s2Index, dtScoreGroup.Rows.Count / 2, isDown, dtScoreGroup);
                            if (player2Id != -1)
                            {
                                drPair[PlayerWhite] = player2Id;
                                isPairFound = true;
                            }
                        }
                    }

                    #endregion

                    if (isPairFound) // if Pair founded, then add it to pairings data.
                    {
                        dtScoreGroup.Rows[s1Index][IsDf] = false;
                        dtScoreGroup.Rows[s1Index][IsUf] = false;
                        dtPairings.Rows.Add(drPair);
                    }
                    else // else set its flags to DownFloat or UpFloat.
                    {
                        dtScoreGroup.Rows[s1Index][IsDf] = isDown;
                        dtScoreGroup.Rows[s1Index][IsUf] = !isDown;
                    }

                    RemoveExchanges(dtScoreGroup);

                    isS1White = !isS1White;
                    s1Index--;
                }
            }

            #endregion

            #region Check & Set DownFloat/UpFloat Flags 
            
            // If any player remains Unpaired, then set for DownFloat or UpFloat accordingly.

            foreach (DataRow dr in dtScoreGroup.Rows)
            {
                if (!Convert.ToBoolean(dr[IsDf]) && !Convert.ToBoolean(dr[IsUf]))
                {
                    int userId = Convert.ToInt32(dr[UserId]);
                    bool isUnpaired = !IsAlreadyPaired(dtPairings, userId);
                    if (isUnpaired)
                    {
                        dr[IsDf] = isDown;
                        dr[IsUf] = !isDown;
                    }               
                }
            }

            #endregion

            #region Float Players, If flags set to DownFloat or UpFloat 

            // If flags set to DownFloat or UpFloat, then Float Players.

            List<int> playersToFolat = new List<int>();

            foreach (DataRow dr in dtScoreGroup.Rows)
            {
                if (Convert.ToBoolean(dr[IsDf]) || Convert.ToBoolean(dr[IsUf]))
                {
                    playersToFolat.Add(Convert.ToInt32(dr[UserId]));
                }
            }

            int rowIndex = -1;
            foreach (int playerId in playersToFolat)
            {
                rowIndex = GetRowIndex(dtScoreGroup, playerId);
                FloatPlayer(dtScoreGroup, rowIndex, isDown);
            }

            #endregion

        }

        private DataTable SortTable(DataTable table, string sort)
        {
            table.DefaultView.Sort = sort;
            table = table.DefaultView.ToTable();

            return table;
        }

        #region FloatPlayer 
        
        private void FloatPlayer(DataTable dtScoreGroup, bool isDown)
        {
            int rowIndex = 0;
            if (isDown)
            {
                rowIndex = dtScoreGroup.Rows.Count - 1;
            }

            FloatPlayer(dtScoreGroup, rowIndex, isDown);
        }

        private void FloatPlayer(DataTable dtScoreGroup, int rowIndex, bool isDown)
        {
            // 10.2 When pairing proceeds downward, the floater is transferred to the next lower score-group. 
            // When pairing proceeds upwards, the floater is transferred to the next higher score-group.

            DataTable dtAdjacentTable = null;

            dtAdjacentTable = GetAdjacentTable(dtScoreGroup, isDown);
            DataRow dr = dtScoreGroup.Rows[rowIndex];

            if (dtAdjacentTable == null)
            {
                if (isDown)
                {
                    // 8.1	If in any round the number of participants is uneven, the Bye is awarded to the player with the lowest rank in the lowest score-group.

                    // set player to bye.
                    dr[IsBye] = true;
                }
            }
            else // float player.
            {
                if (isDown)
                {
                    dr[IsDf] = true;
                    dr[IsUf] = false;

                    DataRow drNew = dtAdjacentTable.NewRow();
                    drNew.ItemArray = GetRowItems(dr);
                    drNew[ExchangePlayerIds] = "";

                    dtScoreGroup.Rows.Remove(dr);

                    dtAdjacentTable.Rows.InsertAt(drNew, 0);

                    dtScoreGroup.AcceptChanges();
                    dtAdjacentTable.AcceptChanges();
                }
                else
                {
                    dr[IsDf] = false;
                    dr[IsUf] = true;
                    DataRow drNew = dtAdjacentTable.NewRow();
                    drNew.ItemArray = GetRowItems(dr);
                    drNew[ExchangePlayerIds] = "";

                    dtScoreGroup.Rows.Remove(dr);
                    dtAdjacentTable.Rows.Add(drNew);

                    dtScoreGroup.AcceptChanges();
                    dtAdjacentTable.AcceptChanges();
                }
            }
        }
        
        #endregion

        #region ExchangePlayer 
                
        private bool ExchangePlayer(DataTable dtScoreGroup, int s1Index, int s2Index, int s2StartIndex, bool isDown)
        {
            // 11.1 The proposed pairings of players obtained according to Rule 9.4 are scrutinised in turn for compliance with Rule 2 
            // which stipulates that the two players have not played each other in an earlier round. And, when pairing downward, 
            // scrutiny of proposed pairings begins with the highest numbered player; if the pairing is found not to comply with Rule 2, 
            // the lower numbered player is exchanged until a compatible pairing is found; or, when pairing upwards, scrutiny of proposed pairings 
            // begins with the lowest numbered player; if the pairing is found not to comply with Rule 2, the higher numbered player is exchanged 
            // until a compatible pairing is found.

            bool isExchanged = false;
            int newPlayerIndex = -1;
            DataRow drPlayer = dtScoreGroup.Rows[s2Index];
            int maxIndex = dtScoreGroup.Rows.Count - 1;

            if (isDown && (s2Index + 1) <= maxIndex) // isDown and index not greater than the last player's index.
            {
                newPlayerIndex = s2Index + 1;
            }
            // else if ((s2StartIndex - 1) > s1Index) // ifUp and next item is not yet traversed by s1Index.
            else if (!isDown && (s2StartIndex < s2Index)) // ifUp and next item is not yet traversed by s1Index.
            {
                newPlayerIndex = s2StartIndex - 1;
                isDown = false;
            }

            if (newPlayerIndex == -1)
            {
                return false;
            }

            // if these two players already exchanged, then move forward to exchange next available player.
            if (IsIndexedPlayersAlreadyExchanged(dtScoreGroup, s2Index, newPlayerIndex)) 
            {
                // 9.5 Where a proposed pairing would result in the pairing of players who have already played each other,
                // the lower numbered player of the two is exchanged for another within the same score-group. 
                // Further exchanges of opponents may be made to allow alternation or equalisation of colours where possible. 
                return ExchangePlayer(dtScoreGroup, s1Index, newPlayerIndex, s2StartIndex, isDown);
            }

            // else then exchange these players.
            if (newPlayerIndex > -1)
            {
                DataRow drNewPlayer = dtScoreGroup.Rows[newPlayerIndex];
                object[] playerItems = drPlayer.ItemArray;
                object[] newPlayerItems = drNewPlayer.ItemArray;

                drPlayer.ItemArray = newPlayerItems;
                drNewPlayer.ItemArray = playerItems;

                drPlayer[ExchangePlayerIds] = drPlayer[ExchangePlayerIds].ToString() + "," + drNewPlayer[UserId].ToString();
                drNewPlayer[ExchangePlayerIds] = drNewPlayer[ExchangePlayerIds].ToString() + "," + drPlayer[UserId].ToString();

                isExchanged = true;
            }

            return isExchanged;
        }

        #endregion

        private object[] GetRowItems(DataRow dr)
        {
            object[] items = new object[dr.ItemArray.Length];

            for (int i = 0; i < dr.ItemArray.Length; i++)
            {
                items[i] = dr.ItemArray[i];
            }

            return items;
        }

        private int GetRowIndex(DataTable dtScoreGroup, int playerId)
        {
            int rowIndex = -1;

            for (int i = 0; i < dtScoreGroup.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtScoreGroup.Rows[i][UserId]) == playerId)
                {
                    rowIndex = i;
                    break;
                }
            }

            return rowIndex;
        }
                
        private bool IsIndexedPlayersAlreadyExchanged(DataTable dtScoreGroup, int p1Index, int p2Index)
        {
            bool isExchanged = false;

            DataRow drP1 = dtScoreGroup.Rows[p1Index];
            DataRow drP2 = dtScoreGroup.Rows[p2Index];

            string p1Ids = drP1[ExchangePlayerIds].ToString();
            string p2Ids = drP2[ExchangePlayerIds].ToString();

            if (string.IsNullOrEmpty(p1Ids) || string.IsNullOrEmpty(p2Ids))
            {
                return isExchanged;
            }

            string[] p1Exchanges = p1Ids.Split(',');
            string[] p2Exchanges = p2Ids.Split(',');

            foreach (string p1Item in p1Exchanges)
            {
                if (string.IsNullOrEmpty(p1Item))
                {
                    continue;
                }

                if (p1Item == drP2[UserId].ToString())
                {
                    isExchanged = true;
                    break;
                }                
            }

            if (!isExchanged)
            {
                foreach (string p2Item in p2Exchanges)
                {
                    if (string.IsNullOrEmpty(p2Item))
                    {
                        continue;
                    }

                    if (p2Item == drP1[UserId].ToString())
                    {
                        isExchanged = true;
                        break;
                    }
                }
            }

            return isExchanged;
        }

        private DataTable GetAdjacentTable(DataTable dtScoreGroup, bool isDown)
        {
            DataTable dt = null;
            int tableIndex = Convert.ToInt32(dtScoreGroup.TableName);

            if (isDown)
            {
                tableIndex++;
            }
            else
            {
                tableIndex--;
            }

            if (tableIndex >= 0 && ScoreGroupsDataSet.Tables.Count >= tableIndex)
            {
                dt = ScoreGroupsDataSet.Tables[tableIndex - 1];
            }

            return dt;
        }

        private void RemoveExchanges(DataTable dtScoreGroup)
        {
            foreach (DataRow dr in dtScoreGroup.Rows)
            {
                dr[ExchangePlayerIds] = "";
            }
        }

        #endregion

        #region CheckCompatibility

        private bool IsOpponentCompatible(int userId, int opponentId)
        {
            //2. Two players may play each other only once.

            bool isCompatible = true;

            TournamentMatchesData.DefaultView.Sort = "Round desc";            
            int whiteUserId = -1;
            int blackUserId = -1;

            foreach (DataRow dr in TournamentMatchesData.Rows)
            {
                whiteUserId = Convert.ToInt32(dr["WhiteUserID"]);
                blackUserId = Convert.ToInt32(dr["BlackUserID"]);

                // if already paired with this player, then its not compatible.
                if (userId == whiteUserId && opponentId == blackUserId)
                {
                    isCompatible = false; 
                    break;
                }
                else if (userId == blackUserId && opponentId == whiteUserId)
                {
                    isCompatible = false; 
                    break;
                }
            }

            return isCompatible;
        }

        private bool IsColorCompatible(int userId, bool isWhite)
        {
            
            bool isCompatible = true;

            int whiteCount = TournamentMatchesData.Select("WhiteUserId = " + userId).Length;
            int blackCount = TournamentMatchesData.Select("BlackUserId = " + userId).Length;

            // 12.1 (b) no player shall be given three more of one colour than the other.
            if (isWhite)
            {
                if (whiteCount >= blackCount + 2)
                {
                    isCompatible = false;
                }
            }
            else
            {
                if (blackCount >= whiteCount + 2)
                {
                    isCompatible = false;
                }
            }

            if (isCompatible)
            {
                isCompatible = IsSuccessiveCompatible(userId, isWhite);
            }

            return isCompatible;
        }

        private bool IsSuccessiveCompatible(int userId, bool isWhite)
        {
            // 12.1 (a) no player shall be given the same colour in three successive rounds

            bool isCompatible = true;
            DataRow[] userMatches = TournamentMatchesData.Select("WhiteUserId = " + userId + " or BlackUserId = " + userId, "Round desc");                        
            int whiteCount = 0;
            int blackCount = 0;
            int whiteUserId = -1;
            int blackUserId = -1;

            foreach (DataRow dr in userMatches)
            {
                if (isWhite)
                {
                    whiteUserId = Convert.ToInt32(dr["WhiteUserId"]);
                    if (whiteUserId == userId)
                    {
                        whiteCount++;
                        blackCount = 0;

                        if (whiteCount >= 2)
                        {
                            isCompatible = false;
                            break;
                        }
                    }
                }
                else
                {
                    blackUserId = Convert.ToInt32(dr["BlackUserId"]);
                    if (blackUserId == userId)
                    {
                        whiteCount = 0;
                        blackCount++;

                        if (blackCount >= 2)
                        {
                            isCompatible = false;
                            break;
                        }
                    }
                }
            }

            return isCompatible; 
        }

        private bool IsAlreadyPaired(DataTable dtPairing, int userId)
        {
            if (dtPairing == null)
            {
                return false;
            }

            int pairedItem = dtPairing.Select(PlayerWhite + " = " + userId + " or " + PlayerBlack + " = " + userId).Length;            
            return pairedItem > 0;
        }

        private int GetCompatibleOpponent(int userId, bool oppIsWhite, int s1Index,int s2Index, int s2StartIndex, bool isDown, DataTable dtScoreGroup)
        {
            // 9.1	Two players who have not yet played each other are said to be compatible provided that 
            //      the pairing will not require either player to have the same colour in three successive rounds, 
            //      or to have three more of one colour than the other.

            int oppId = -1;            
            bool isColorCompatible = false;
            bool isPlayerCompatible = false;

            oppId = Convert.ToInt32(dtScoreGroup.Rows[s2Index][UserId]);
            isPlayerCompatible = IsOpponentCompatible(userId,oppId);

            if (isPlayerCompatible)
            {
                isColorCompatible = IsColorCompatible(oppId, oppIsWhite);
                if (!isColorCompatible)
                {
                    // 9.5 Where a proposed pairing would result in the pairing of players who have already played each other,
                    // the lower numbered player of the two is exchanged for another within the same score-group. 
                    // Further exchanges of opponents may be made to allow alternation or equalisation of colours where possible. 
                    bool isExchanged = ExchangePlayer(dtScoreGroup, s1Index, s2Index, s2StartIndex, isDown);
                    if (isExchanged)
                    {
                        return GetCompatibleOpponent(userId, oppIsWhite, s1Index, s2Index, s2StartIndex, isDown, dtScoreGroup);
                    }
                    else
                    {
                        // 9.3 
                        // (a) the player has already played all the players of his score-group; or
                        // (b) the player has already received two more of one colour over an equal allocation and there 
                        //      is no compatible opponent available in the score-group to enable him to have a permissible colour; or
                        // (c) the player has already received the same colour in the previous two rounds and there is no 
                        //      compatible player in the score-group to enable the player to have the alternate colour;

                        //12.3 If one of the players in a pairing had the same colour in the previous two rounds, he must be given the alternating colour. 
                        // If both players had the same colour in the previous two rounds and compatible opponents in the score-group are not available, 
                        // then one or both players must be floated.

                        dtScoreGroup.Rows[s2Index][IsDf] = isDown;
                        dtScoreGroup.Rows[s2Index][IsUf] = !isDown;
                    }
                }
            }
            else
            {
                // 9.5 Where a proposed pairing would result in the pairing of players who have already played each other,
                // the lower numbered player of the two is exchanged for another within the same score-group. 
                // Further exchanges of opponents may be made to allow alternation or equalisation of colours where possible. 
                bool isExchanged = ExchangePlayer(dtScoreGroup, s1Index, s2Index, s2StartIndex, isDown);
                if (isExchanged)
                {
                    return GetCompatibleOpponent(userId, oppIsWhite, s1Index, s2Index, s2StartIndex, isDown, dtScoreGroup);
                }
                else
                {
                    // 9.3 
                    // (a) the player has already played all the players of his score-group; or
                    // (b) the player has already received two more of one colour over an equal allocation and there 
                    //      is no compatible opponent available in the score-group to enable him to have a permissible colour; or
                    // (c) the player has already received the same colour in the previous two rounds and there is no 
                    //      compatible player in the score-group to enable the player to have the alternate colour;

                    //12.3 If one of the players in a pairing had the same colour in the previous two rounds, he must be given the alternating colour. 
                    // If both players had the same colour in the previous two rounds and compatible opponents in the score-group are not available, 
                    // then one or both players must be floated.

                    dtScoreGroup.Rows[s2Index][IsDf] = isDown;
                    dtScoreGroup.Rows[s2Index][IsUf] = !isDown;
                }
            }

            if (isPlayerCompatible && isColorCompatible)
            {
                dtScoreGroup.Rows[s2Index][IsDf] = false;
                dtScoreGroup.Rows[s2Index][IsUf] = false;
            }
            else
            {
                oppId = -1;                
            }
            return oppId;
        }

        #endregion

        */
        #endregion

        #region Swiss Tournament - New 20100929

        DataTable TournamentUsersData = null;
        DataTable TournamentMatchesData = null;
        DataTable GroupData = null;

        DataTable PlayersData = null;
        DataSet ScoreGroupsDataSet = null;
        DataTable PairingsData = null;

        public void CreateSwissRound1(Cxt cxt, SqlTransaction trans, Tournament Tournament, int Round, int i)
        {
            DataTable dt = GetNewTable();

            TournamentUsersData = TournamentUsers.GetTournamentUsersByTournamentID(StatusE.Active, Tournament.TournamentID);
            TournamentMatchesData = GetTournamntMatchByTournamentID(Tournament.TournamentID);

            DataView dv = TournamentUsersData.DefaultView;

            dv.Sort = "TournamentPoints, EloAfter desc";

            DataView dvMatches = TournamentMatchesData.DefaultView;
            dvMatches.Sort = "Round desc";

            if (dvMatches.Count > 0)
            {
                Round = Convert.ToInt32(dvMatches[0]["Round"]) + 1;
            }

            GroupData = TournamentUsers.GetTournamentUsersGroupByTournamentPoint(Tournament.TournamentID);
            try
            {
                // swiss matches paired according to the article :
                // http://www.fide.com/fide/handbook.html?id=83&view=article

                PlayersData = LoadPlayersDetails(cxt, dv.ToTable().Select(), "");
                ScoreGroupsDataSet = LoadScoreGroups(cxt);
                PairingsData = CreatePairings(cxt);

                CreateSwissMatches(cxt, trans, Tournament, Round);

            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }

        private void CreateSwissMatches(Cxt cxt, SqlTransaction trans, Tournament Tournament, int Round)
        {
            TournamentMatches tournamentMatches = new TournamentMatches();

            foreach (DataRow drPair in PairingsData.Rows)
            {
                int whiteId = Convert.ToInt32(drPair[PlayerWhite]);
                int blackId = Convert.ToInt32(drPair[PlayerBlack]);

                TournamentMatch m = new TournamentMatch(cxt, 0);

                TournamentUser TournamentUserWhite = TournamentUser.GetTournamentUserById(cxt, Tournament.TournamentID, whiteId);
                TournamentUser TournamentUserBlack = TournamentUser.GetTournamentUserById(cxt, Tournament.TournamentID, blackId);

                m.WhiteUserID = TournamentUserWhite.UserID;
                m.BlackUserID = TournamentUserBlack.UserID;

                m.EloWhiteBefore = TournamentUserWhite.EloBefore;
                m.EloBlackBefore = TournamentUserBlack.EloBefore;

                m.Round = Round;
                m.TournamentID = Tournament.TournamentID;
                m.MatchStartDate = DateTime.Now;
                m.MatchStartTime = DateTime.Now;
                m.TimeMin = Tournament.TimeControlMin;
                m.TimeSec = Tournament.TimeControlSec;
                m.TournamentMatchStatusE = TournamentMatchStatusE.Scheduled;
                m.CreatedBy = Ap.CurrentUserID;
                m.DateCreated = DateTime.Now;
                m.TournamentMatchTypeE = TournamentMatchTypeE.Normal;

                tournamentMatches.Add(m);

            }
            tournamentMatches.Save(trans);

        }

        #region PlayersTable Columns

        const string UserId = "UserId";
        const string No = "No";
        const string PreferenceColor = "PreferenceColor";
        const string Name = "Name";
        const string Rating = "Rating";
        const string Score = "Score";
        const string IsDf = "IsDf";
        const string IsUf = "IsUf";
        const string ExchangePlayerIds = "ExchangePlayerIds";
        const string IsBye = "IsBye";

        #endregion

        #region PairingsTable Columns

        const string GameNo = "GameNo";
        const string PlayerWhite = "PlayerWhite";
        const string PlayerBlack = "PlayerBlack";

        #endregion

        #region InitTables

        private DataTable InitPlayersTable(string tableName)
        {
            DataTable dt = new DataTable(tableName);

            dt.Columns.Add(UserId, typeof(int));
            dt.Columns.Add(No, typeof(int));
            dt.Columns.Add(Name, typeof(string));
            dt.Columns.Add(Rating, typeof(int));
            dt.Columns.Add(Score, typeof(float));
            dt.Columns.Add(IsDf, typeof(bool));
            dt.Columns.Add(IsUf, typeof(bool));
            dt.Columns.Add(ExchangePlayerIds, typeof(string));
            dt.Columns.Add(IsBye, typeof(bool));

            return dt;
        }

        private DataTable InitPairingsTable()
        {
            DataTable dt = new DataTable("Pairings");

            dt.Columns.Add(GameNo, typeof(int));
            dt.Columns.Add(PlayerWhite, typeof(int));
            dt.Columns.Add(PlayerBlack, typeof(int));

            return dt;
        }

        #endregion

        #region LoadTables

        private DataTable LoadPlayersDetails(Cxt cxt, DataRow[] drTourUsers, string tableName)
        {
            DataTable dtPlayers = InitPlayersTable(tableName);
            TournamentUser tu;
            int no = 1;

            foreach (DataRow drUser in drTourUsers)
            {
                tu = new TournamentUser(cxt, drUser);
                DataRow drPlayer = dtPlayers.NewRow();

                drPlayer[UserId] = tu.UserID;
                drPlayer[No] = no++;
                drPlayer[Name] = tu.Name;
                drPlayer[Rating] = tu.EloAfter;
                drPlayer[Score] = tu.TournamentPoints;
                drPlayer[IsDf] = false;
                drPlayer[IsUf] = false;
                drPlayer[ExchangePlayerIds] = "";
                drPlayer[IsBye] = false;

                dtPlayers.Rows.Add(drPlayer);
            }

            return dtPlayers;
        }

        private DataTable LoadBrackets(Cxt cxt, DataRow[] drTourUsers, int bracketNo)
        {
            if (drTourUsers.Length == 0)
            {
                return new DataTable();
            }

            DataTable dtPlayers = InitPlayersTable("");
            TournamentUser tu;
            int no = 1;

            for (int i = 0; i < dtPlayers.Rows.Count; i++)
            {
                
            }
            foreach (DataRow drUser in drTourUsers)
            {
                tu = new TournamentUser(cxt, drUser);
                DataRow drPlayer = dtPlayers.NewRow();

                drPlayer[UserId] = tu.UserID;
                drPlayer[No] = no++;
                drPlayer[Name] = tu.Name;
                drPlayer[Rating] = tu.EloAfter;
                drPlayer[Score] = tu.TournamentPoints;
                drPlayer[IsDf] = false;
                drPlayer[IsUf] = false;
                drPlayer[ExchangePlayerIds] = "";
                drPlayer[IsBye] = false;

                dtPlayers.Rows.Add(drPlayer);
            }

            return dtPlayers;
        }

        private DataSet LoadScoreGroups(Cxt cxt)
        {
            DataSet dsScoreGroups = new DataSet("ScoreGroups");
            DataTable dtPlayers = null;
            DataRow[] drTourPlayers = null;
            string points = "";

            foreach (DataRow dr in GroupData.Rows)
            {
                points = dr["TournamentPoints"].ToString();                

                dtPlayers = LoadPlayersDetails(cxt, drTourPlayers, (dsScoreGroups.Tables.Count + 1).ToString());

                dsScoreGroups.Tables.Add(dtPlayers);
            }

            return dsScoreGroups;
        }

        #endregion

        #region CreatePairings

        private DataTable CreatePairings(Cxt cxt)
        {
            List<int> t = new List<int>();




            // 9.2	The players with the same score form a score-group. The Median Score-group is the score-group with players having 
            //      the score equal to half the number of rounds that have been played. Pairing begins with the highest score-group and proceeds 
            //      downward until just before the Median Score-group, then continues with the lowest score-group and proceeds upwards to the 
            //      Median Score-Group which is paired last. The Median-Score-group is paired downward.

            if (GroupData.Rows.Count == 0)
            {
                return null;
            }

            DataTable dtPairings = InitPairingsTable();
            string points = "";
            DataTable dtScoreGroup = null;

            int median = GroupData.Rows.Count / 2;
            if (GroupData.Rows.Count % 2 > 0)
            {
                median++;
            }

            int tableIndex = -1;
            DataTable dtMedianSG = null;
            List<int> lowerGroupsTables = new List<int>();

            foreach (DataRow dr in GroupData.Rows)
            {
                points = dr["TournamentPoints"].ToString();
                dtScoreGroup = GetPointsTable(points);

                tableIndex = Convert.ToInt32(dtScoreGroup.TableName);
                if (tableIndex == median)
                {
                    dtMedianSG = dtScoreGroup;
                }
                else if (tableIndex < median)
                {
                    CreatePairing(dtPairings, dtScoreGroup, median);
                }
                else if (tableIndex > median)
                {
                    lowerGroupsTables.Add(tableIndex);
                }
            }

            for (int i = lowerGroupsTables.Count - 1; i >= 0; i--)
            {
                tableIndex = lowerGroupsTables[i];
                dtScoreGroup = ScoreGroupsDataSet.Tables[tableIndex - 1];
                CreatePairing(dtPairings, dtScoreGroup, median);
            }

            if (dtMedianSG != null)
            {
                CreatePairing(dtPairings, dtMedianSG, median);
            }

            return dtPairings;
        }

        private DataTable GetPointsTable(string points)
        {
            int index = 0;
            DataTable dt = null;

            foreach (DataRow dr in GroupData.Rows)
            {
                if (points == dr["TournamentPoints"].ToString())
                {
                    dt = ScoreGroupsDataSet.Tables[index];
                    break;
                }
                index++;
            }

            return dt;
        }

        private void CreatePairing(DataTable dtPairings, DataTable dtScoreGroup, int median)
        {
            if (dtScoreGroup.Rows.Count == 0)
            {
                return;
            }

            DataRow drPair = null;
            int tableIndex = Convert.ToInt32(dtScoreGroup.TableName);
            int s1Index = -1;
            int s2Index = -1;
            bool isDown = tableIndex <= median;
            bool isS1White = true;

            dtScoreGroup = SortTable(dtScoreGroup, "Score  desc");

            if (dtScoreGroup.Rows.Count % 2 > 0)
            {
                // 9.3 (d) it is necessary to make even the number of players in the score-group.
                FloatPlayer(dtScoreGroup, isDown);
            }

            s2Index = dtScoreGroup.Rows.Count / 2;
            bool isColorCompatible = false;
            bool isPairFound = false;
            int player1Id = -1;
            int player2Id = -1;

            // 9.4	The players in a score-group, after transfer of players where necessary, are arranged in the order of 
            //  their pairing numbers and the players in the top half are tentatively paired with the players in the bottom half. 
            //  These pairings are said to be proposed pairings, to be confirmed after scrutiny for compatibility and proper colour. 
            //  If the players in a score-group are numbered : 1, 2, 3 ... n, then the proposed pairings are (ignoring colours): 
            //  1 v (n/2 + 1), 2 v (n/2 + 2), 3 v (n/2 + 3) ... n/2 v n.

            #region Downward Pairing

            if (isDown)
            {
                for (s1Index = 0; s1Index < dtScoreGroup.Rows.Count / 2; s1Index++)
                {
                    isPairFound = false;
                    drPair = dtPairings.NewRow();
                    drPair[GameNo] = dtPairings.Rows.Count + 1;

                    player1Id = Convert.ToInt32(dtScoreGroup.Rows[s1Index][UserId]);
                    player2Id = Convert.ToInt32(dtScoreGroup.Rows[s2Index][UserId]);

                    #region Chgeck Players Compatiblity and Search Compatible Opponent

                    isColorCompatible = IsColorCompatible(player1Id, isS1White);
                    if (isColorCompatible)
                    {
                        drPair[PlayerWhite] = player1Id;
                        player2Id = GetCompatibleOpponent(player1Id, !isS1White, s1Index, s2Index, dtScoreGroup.Rows.Count / 2, isDown, dtScoreGroup);
                        if (player2Id != -1)
                        {
                            drPair[PlayerBlack] = player2Id;
                            isPairFound = true;
                        }
                    }
                    else
                    {
                        isColorCompatible = IsColorCompatible(player1Id, !isS1White);
                        if (isColorCompatible)
                        {
                            drPair[PlayerWhite] = player1Id;
                            player2Id = GetCompatibleOpponent(player1Id, isS1White, s1Index, s2Index, dtScoreGroup.Rows.Count / 2, isDown, dtScoreGroup);
                            if (player2Id != -1)
                            {
                                drPair[PlayerBlack] = player2Id;
                                isPairFound = true;
                            }
                        }
                    }

                    #endregion

                    if (isPairFound) // if Pair founded, then add it to pairings data.
                    {
                        dtScoreGroup.Rows[s1Index][IsDf] = false;
                        dtScoreGroup.Rows[s1Index][IsUf] = false;
                        dtPairings.Rows.Add(drPair);
                    }
                    else // else set its flags to DownFloat or UpFloat.
                    {
                        dtScoreGroup.Rows[s1Index][IsDf] = isDown;
                        dtScoreGroup.Rows[s1Index][IsUf] = !isDown;
                    }

                    RemoveExchanges(dtScoreGroup);

                    isS1White = !isS1White;
                    s2Index++;
                }
            }

            #endregion

            #region Upward Pairing

            else
            {
                s2Index = dtScoreGroup.Rows.Count - 1;
                s1Index = (dtScoreGroup.Rows.Count / 2);
                if (dtScoreGroup.Rows.Count % 2 == 0)
                {
                    s1Index = s1Index - 1;
                }

                for (s2Index = dtScoreGroup.Rows.Count - 1; s2Index >= dtScoreGroup.Rows.Count / 2; s2Index--)
                {
                    isPairFound = false;
                    drPair = dtPairings.NewRow();
                    drPair[GameNo] = dtPairings.Rows.Count + 1;

                    player1Id = Convert.ToInt32(dtScoreGroup.Rows[s1Index][UserId]);
                    player2Id = Convert.ToInt32(dtScoreGroup.Rows[s2Index][UserId]);

                    #region Chgeck Players Compatiblity and Search Compatible Opponent

                    isColorCompatible = IsColorCompatible(player1Id, isS1White);
                    if (isColorCompatible)
                    {
                        drPair[PlayerWhite] = player1Id;
                        player2Id = GetCompatibleOpponent(player1Id, !isS1White, s1Index, s2Index, dtScoreGroup.Rows.Count / 2, isDown, dtScoreGroup);
                        if (player2Id != -1)
                        {
                            drPair[PlayerBlack] = player2Id;
                            isPairFound = true;
                        }
                    }
                    else
                    {
                        isColorCompatible = IsColorCompatible(player1Id, !isS1White);
                        if (isColorCompatible)
                        {
                            drPair[PlayerBlack] = player1Id;
                            player2Id = GetCompatibleOpponent(player1Id, isS1White, s1Index, s2Index, dtScoreGroup.Rows.Count / 2, isDown, dtScoreGroup);
                            if (player2Id != -1)
                            {
                                drPair[PlayerWhite] = player2Id;
                                isPairFound = true;
                            }
                        }
                    }

                    #endregion

                    if (isPairFound) // if Pair founded, then add it to pairings data.
                    {
                        dtScoreGroup.Rows[s1Index][IsDf] = false;
                        dtScoreGroup.Rows[s1Index][IsUf] = false;
                        dtPairings.Rows.Add(drPair);
                    }
                    else // else set its flags to DownFloat or UpFloat.
                    {
                        dtScoreGroup.Rows[s1Index][IsDf] = isDown;
                        dtScoreGroup.Rows[s1Index][IsUf] = !isDown;
                    }

                    RemoveExchanges(dtScoreGroup);

                    isS1White = !isS1White;
                    s1Index--;
                }
            }

            #endregion

            #region Check & Set DownFloat/UpFloat Flags

            // If any player remains Unpaired, then set for DownFloat or UpFloat accordingly.

            foreach (DataRow dr in dtScoreGroup.Rows)
            {
                if (!Convert.ToBoolean(dr[IsDf]) && !Convert.ToBoolean(dr[IsUf]))
                {
                    int userId = Convert.ToInt32(dr[UserId]);
                    bool isUnpaired = !IsAlreadyPaired(dtPairings, userId);
                    if (isUnpaired)
                    {
                        dr[IsDf] = isDown;
                        dr[IsUf] = !isDown;
                    }
                }
            }

            #endregion

            #region Float Players, If flags set to DownFloat or UpFloat

            // If flags set to DownFloat or UpFloat, then Float Players.

            List<int> playersToFolat = new List<int>();

            foreach (DataRow dr in dtScoreGroup.Rows)
            {
                if (Convert.ToBoolean(dr[IsDf]) || Convert.ToBoolean(dr[IsUf]))
                {
                    playersToFolat.Add(Convert.ToInt32(dr[UserId]));
                }
            }

            int rowIndex = -1;
            foreach (int playerId in playersToFolat)
            {
                rowIndex = GetRowIndex(dtScoreGroup, playerId);
                FloatPlayer(dtScoreGroup, rowIndex, isDown);
            }

            #endregion

        }

        private DataTable SortTable(DataTable table, string sort)
        {
            table.DefaultView.Sort = sort;
            table = table.DefaultView.ToTable();

            return table;
        }

        #region FloatPlayer

        private void FloatPlayer(DataTable dtScoreGroup, bool isDown)
        {
            int rowIndex = 0;
            if (isDown)
            {
                rowIndex = dtScoreGroup.Rows.Count - 1;
            }

            FloatPlayer(dtScoreGroup, rowIndex, isDown);
        }

        private void FloatPlayer(DataTable dtScoreGroup, int rowIndex, bool isDown)
        {
            // 10.2 When pairing proceeds downward, the floater is transferred to the next lower score-group. 
            // When pairing proceeds upwards, the floater is transferred to the next higher score-group.

            DataTable dtAdjacentTable = null;

            dtAdjacentTable = GetAdjacentTable(dtScoreGroup, isDown);
            DataRow dr = dtScoreGroup.Rows[rowIndex];

            if (dtAdjacentTable == null)
            {
                if (isDown)
                {
                    // 8.1	If in any round the number of participants is uneven, the Bye is awarded to the player with the lowest rank in the lowest score-group.

                    // set player to bye.
                    dr[IsBye] = true;
                }
            }
            else // float player.
            {
                if (isDown)
                {
                    dr[IsDf] = true;
                    dr[IsUf] = false;

                    DataRow drNew = dtAdjacentTable.NewRow();
                    drNew.ItemArray = GetRowItems(dr);
                    drNew[ExchangePlayerIds] = "";

                    dtScoreGroup.Rows.Remove(dr);

                    dtAdjacentTable.Rows.InsertAt(drNew, 0);

                    dtScoreGroup.AcceptChanges();
                    dtAdjacentTable.AcceptChanges();
                }
                else
                {
                    dr[IsDf] = false;
                    dr[IsUf] = true;
                    DataRow drNew = dtAdjacentTable.NewRow();
                    drNew.ItemArray = GetRowItems(dr);
                    drNew[ExchangePlayerIds] = "";

                    dtScoreGroup.Rows.Remove(dr);
                    dtAdjacentTable.Rows.Add(drNew);

                    dtScoreGroup.AcceptChanges();
                    dtAdjacentTable.AcceptChanges();
                }
            }
        }

        #endregion

        #region ExchangePlayer

        private bool ExchangePlayer(DataTable dtScoreGroup, int s1Index, int s2Index, int s2StartIndex, bool isDown)
        {
            // 11.1 The proposed pairings of players obtained according to Rule 9.4 are scrutinised in turn for compliance with Rule 2 
            // which stipulates that the two players have not played each other in an earlier round. And, when pairing downward, 
            // scrutiny of proposed pairings begins with the highest numbered player; if the pairing is found not to comply with Rule 2, 
            // the lower numbered player is exchanged until a compatible pairing is found; or, when pairing upwards, scrutiny of proposed pairings 
            // begins with the lowest numbered player; if the pairing is found not to comply with Rule 2, the higher numbered player is exchanged 
            // until a compatible pairing is found.

            bool isExchanged = false;
            int newPlayerIndex = -1;
            DataRow drPlayer = dtScoreGroup.Rows[s2Index];
            int maxIndex = dtScoreGroup.Rows.Count - 1;

            if (isDown && (s2Index + 1) <= maxIndex) // isDown and index not greater than the last player's index.
            {
                newPlayerIndex = s2Index + 1;
            }
            // else if ((s2StartIndex - 1) > s1Index) // ifUp and next item is not yet traversed by s1Index.
            else if (!isDown && (s2StartIndex < s2Index)) // ifUp and next item is not yet traversed by s1Index.
            {
                newPlayerIndex = s2StartIndex - 1;
                isDown = false;
            }

            if (newPlayerIndex == -1)
            {
                return false;
            }

            // if these two players already exchanged, then move forward to exchange next available player.
            if (IsIndexedPlayersAlreadyExchanged(dtScoreGroup, s2Index, newPlayerIndex))
            {
                // 9.5 Where a proposed pairing would result in the pairing of players who have already played each other,
                // the lower numbered player of the two is exchanged for another within the same score-group. 
                // Further exchanges of opponents may be made to allow alternation or equalisation of colours where possible. 
                return ExchangePlayer(dtScoreGroup, s1Index, newPlayerIndex, s2StartIndex, isDown);
            }

            // else then exchange these players.
            if (newPlayerIndex > -1)
            {
                DataRow drNewPlayer = dtScoreGroup.Rows[newPlayerIndex];
                object[] playerItems = drPlayer.ItemArray;
                object[] newPlayerItems = drNewPlayer.ItemArray;

                drPlayer.ItemArray = newPlayerItems;
                drNewPlayer.ItemArray = playerItems;

                drPlayer[ExchangePlayerIds] = drPlayer[ExchangePlayerIds].ToString() + "," + drNewPlayer[UserId].ToString();
                drNewPlayer[ExchangePlayerIds] = drNewPlayer[ExchangePlayerIds].ToString() + "," + drPlayer[UserId].ToString();

                isExchanged = true;
            }

            return isExchanged;
        }

        #endregion

        private object[] GetRowItems(DataRow dr)
        {
            object[] items = new object[dr.ItemArray.Length];

            for (int i = 0; i < dr.ItemArray.Length; i++)
            {
                items[i] = dr.ItemArray[i];
            }

            return items;
        }

        private int GetRowIndex(DataTable dtScoreGroup, int playerId)
        {
            int rowIndex = -1;

            for (int i = 0; i < dtScoreGroup.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtScoreGroup.Rows[i][UserId]) == playerId)
                {
                    rowIndex = i;
                    break;
                }
            }

            return rowIndex;
        }

        private bool IsIndexedPlayersAlreadyExchanged(DataTable dtScoreGroup, int p1Index, int p2Index)
        {
            bool isExchanged = false;

            DataRow drP1 = dtScoreGroup.Rows[p1Index];
            DataRow drP2 = dtScoreGroup.Rows[p2Index];

            string p1Ids = drP1[ExchangePlayerIds].ToString();
            string p2Ids = drP2[ExchangePlayerIds].ToString();

            if (string.IsNullOrEmpty(p1Ids) || string.IsNullOrEmpty(p2Ids))
            {
                return isExchanged;
            }

            string[] p1Exchanges = p1Ids.Split(',');
            string[] p2Exchanges = p2Ids.Split(',');

            foreach (string p1Item in p1Exchanges)
            {
                if (string.IsNullOrEmpty(p1Item))
                {
                    continue;
                }

                if (p1Item == drP2[UserId].ToString())
                {
                    isExchanged = true;
                    break;
                }
            }

            if (!isExchanged)
            {
                foreach (string p2Item in p2Exchanges)
                {
                    if (string.IsNullOrEmpty(p2Item))
                    {
                        continue;
                    }

                    if (p2Item == drP1[UserId].ToString())
                    {
                        isExchanged = true;
                        break;
                    }
                }
            }

            return isExchanged;
        }

        private DataTable GetAdjacentTable(DataTable dtScoreGroup, bool isDown)
        {
            DataTable dt = null;
            int tableIndex = Convert.ToInt32(dtScoreGroup.TableName);

            if (isDown)
            {
                tableIndex++;
            }
            else
            {
                tableIndex--;
            }

            if (tableIndex >= 0 && ScoreGroupsDataSet.Tables.Count >= tableIndex)
            {
                dt = ScoreGroupsDataSet.Tables[tableIndex - 1];
            }

            return dt;
        }

        private void RemoveExchanges(DataTable dtScoreGroup)
        {
            foreach (DataRow dr in dtScoreGroup.Rows)
            {
                dr[ExchangePlayerIds] = "";
            }
        }

        #endregion

        #region CheckCompatibility

        private bool IsOpponentCompatible(int userId, int opponentId)
        {
            //2. Two players may play each other only once.

            bool isCompatible = true;

            TournamentMatchesData.DefaultView.Sort = "Round desc";
            int whiteUserId = -1;
            int blackUserId = -1;

            foreach (DataRow dr in TournamentMatchesData.Rows)
            {
                whiteUserId = Convert.ToInt32(dr["WhiteUserID"]);
                blackUserId = Convert.ToInt32(dr["BlackUserID"]);

                // if already paired with this player, then its not compatible.
                if (userId == whiteUserId && opponentId == blackUserId)
                {
                    isCompatible = false;
                    break;
                }
                else if (userId == blackUserId && opponentId == whiteUserId)
                {
                    isCompatible = false;
                    break;
                }
            }

            return isCompatible;
        }

        private bool IsColorCompatible(int userId, bool isWhite)
        {

            bool isCompatible = true;

            int whiteCount = TournamentMatchesData.Select("WhiteUserId = " + userId).Length;
            int blackCount = TournamentMatchesData.Select("BlackUserId = " + userId).Length;

            // 12.1 (b) no player shall be given three more of one colour than the other.
            if (isWhite)
            {
                if (whiteCount >= blackCount + 2)
                {
                    isCompatible = false;
                }
            }
            else
            {
                if (blackCount >= whiteCount + 2)
                {
                    isCompatible = false;
                }
            }

            if (isCompatible)
            {
                isCompatible = IsSuccessiveCompatible(userId, isWhite);
            }

            return isCompatible;
        }

        private bool IsSuccessiveCompatible(int userId, bool isWhite)
        {
            // 12.1 (a) no player shall be given the same colour in three successive rounds

            bool isCompatible = true;
            DataRow[] userMatches = TournamentMatchesData.Select("WhiteUserId = " + userId + " or BlackUserId = " + userId, "Round desc");
            int whiteCount = 0;
            int blackCount = 0;
            int whiteUserId = -1;
            int blackUserId = -1;

            foreach (DataRow dr in userMatches)
            {
                if (isWhite)
                {
                    whiteUserId = Convert.ToInt32(dr["WhiteUserId"]);
                    if (whiteUserId == userId)
                    {
                        whiteCount++;
                        blackCount = 0;

                        if (whiteCount >= 2)
                        {
                            isCompatible = false;
                            break;
                        }
                    }
                }
                else
                {
                    blackUserId = Convert.ToInt32(dr["BlackUserId"]);
                    if (blackUserId == userId)
                    {
                        whiteCount = 0;
                        blackCount++;

                        if (blackCount >= 2)
                        {
                            isCompatible = false;
                            break;
                        }
                    }
                }
            }

            return isCompatible;
        }

        private bool IsAlreadyPaired(DataTable dtPairing, int userId)
        {
            if (dtPairing == null)
            {
                return false;
            }

            int pairedItem = dtPairing.Select(PlayerWhite + " = " + userId + " or " + PlayerBlack + " = " + userId).Length;
            return pairedItem > 0;
        }

        private int GetCompatibleOpponent(int userId, bool oppIsWhite, int s1Index, int s2Index, int s2StartIndex, bool isDown, DataTable dtScoreGroup)
        {
            // 9.1	Two players who have not yet played each other are said to be compatible provided that 
            //      the pairing will not require either player to have the same colour in three successive rounds, 
            //      or to have three more of one colour than the other.

            int oppId = -1;
            bool isColorCompatible = false;
            bool isPlayerCompatible = false;

            oppId = Convert.ToInt32(dtScoreGroup.Rows[s2Index][UserId]);
            isPlayerCompatible = IsOpponentCompatible(userId, oppId);

            if (isPlayerCompatible)
            {
                isColorCompatible = IsColorCompatible(oppId, oppIsWhite);
                if (!isColorCompatible)
                {
                    // 9.5 Where a proposed pairing would result in the pairing of players who have already played each other,
                    // the lower numbered player of the two is exchanged for another within the same score-group. 
                    // Further exchanges of opponents may be made to allow alternation or equalisation of colours where possible. 
                    bool isExchanged = ExchangePlayer(dtScoreGroup, s1Index, s2Index, s2StartIndex, isDown);
                    if (isExchanged)
                    {
                        return GetCompatibleOpponent(userId, oppIsWhite, s1Index, s2Index, s2StartIndex, isDown, dtScoreGroup);
                    }
                    else
                    {
                        // 9.3 
                        // (a) the player has already played all the players of his score-group; or
                        // (b) the player has already received two more of one colour over an equal allocation and there 
                        //      is no compatible opponent available in the score-group to enable him to have a permissible colour; or
                        // (c) the player has already received the same colour in the previous two rounds and there is no 
                        //      compatible player in the score-group to enable the player to have the alternate colour;

                        //12.3 If one of the players in a pairing had the same colour in the previous two rounds, he must be given the alternating colour. 
                        // If both players had the same colour in the previous two rounds and compatible opponents in the score-group are not available, 
                        // then one or both players must be floated.

                        dtScoreGroup.Rows[s2Index][IsDf] = isDown;
                        dtScoreGroup.Rows[s2Index][IsUf] = !isDown;
                    }
                }
            }
            else
            {
                // 9.5 Where a proposed pairing would result in the pairing of players who have already played each other,
                // the lower numbered player of the two is exchanged for another within the same score-group. 
                // Further exchanges of opponents may be made to allow alternation or equalisation of colours where possible. 
                bool isExchanged = ExchangePlayer(dtScoreGroup, s1Index, s2Index, s2StartIndex, isDown);
                if (isExchanged)
                {
                    return GetCompatibleOpponent(userId, oppIsWhite, s1Index, s2Index, s2StartIndex, isDown, dtScoreGroup);
                }
                else
                {
                    // 9.3 
                    // (a) the player has already played all the players of his score-group; or
                    // (b) the player has already received two more of one colour over an equal allocation and there 
                    //      is no compatible opponent available in the score-group to enable him to have a permissible colour; or
                    // (c) the player has already received the same colour in the previous two rounds and there is no 
                    //      compatible player in the score-group to enable the player to have the alternate colour;

                    //12.3 If one of the players in a pairing had the same colour in the previous two rounds, he must be given the alternating colour. 
                    // If both players had the same colour in the previous two rounds and compatible opponents in the score-group are not available, 
                    // then one or both players must be floated.

                    dtScoreGroup.Rows[s2Index][IsDf] = isDown;
                    dtScoreGroup.Rows[s2Index][IsUf] = !isDown;
                }
            }

            if (isPlayerCompatible && isColorCompatible)
            {
                dtScoreGroup.Rows[s2Index][IsDf] = false;
                dtScoreGroup.Rows[s2Index][IsUf] = false;
            }
            else
            {
                oppId = -1;
            }
            return oppId;
        }

        #endregion

        #endregion

        int GetLastUserID(Cxt cxt, DataView dv, TournamentMatch tm, int userIDW, int userIDB)
        {

            if (tm.WhiteUserID == userIDW && tm.BlackUserID == userIDB || tm.WhiteUserID == userIDB && tm.BlackUserID == userIDW)
            {
                TournamentUsers tus = new TournamentUsers(cxt, dv.Table);

                for (int i = 0; i < tus.Count; i++)
                {
                    TournamentUser tu1 = tus[i];
                    TournamentUser tu2 = tus[i];

                    if (tu1.UserID == userIDW)
                    {
                        return userIDW;
                    }
                    else if (tu2.UserID == userIDB)
                    {
                        return userIDB;
                    }

                }
            }
            return 0;
        }

        #region Fill  Half Result List
        /// <summary>
        /// below function is used for filling 0.5 result in all win and loose group
        /// </summary>
        /// <param name="teams"></param>
        /// <param name="halfResult"></param>
        /// <param name="dv"></param>
        static void FillHalfResult(DataRow[][] teams, DataRow[] halfResult)
        {
            DataRow[][] BackupTeams = new DataRow[2][];

            int count = 0;
            bool isMode = false;
            if (halfResult.Length % 2 == 1)
            {
                count = halfResult.Length;
                DataRow dr = halfResult[count - 1];
                //teams[0]
                //teams[0].SetValue(dr, 0);
                Array.Resize(ref teams[0], teams[0].Length + 1);
                //BackupTeams[0].SetValue(dr, count + 1);
                isMode = true;
            }

            count = halfResult.Length / 2;
            int team2Len = teams[2].Length;
            Array.Resize(ref teams[2], team2Len + count);
            for (int i = 0; i < count; i++)
            {
                DataRow dr = halfResult[i];
                teams[2].SetValue(dr, team2Len + i);
            }

            int team1Len = teams[0].Length;
            Array.Resize(ref teams[0], team1Len + count);
            if (isMode)
            {
                for (int i = 0; i < halfResult.Length - 1; i++)
                {
                    DataRow dr = halfResult[i];
                    teams[0].SetValue(dr, team1Len + i);
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    DataRow dr = halfResult[count + i];
                    teams[0].SetValue(dr, team1Len + i);
                }
            }
        }
        #endregion

        #region Resize List
        static DataRow[] ResizeArray(DataRow[] TeamsBackup, int size)
        {
            DataRow[] Teams = new DataRow[size];
            Teams = new DataRow[size];
            int i = 0;
            foreach (DataRow item in TeamsBackup)
            {
                if (i < TeamsBackup.Length - 1)
                {
                    Teams[i] = item;
                    i++;
                }
            }
            return Teams;

        }
        
        static void SetList(DataRow[][] Teams, DataRow[][] TeamsBackup, DataRow dr, int index, int count)
        {

            if (dr != null)
            {
                if (index == Teams.Length)
                {
                    return;
                }
                int resize = Teams[index].Length;
                if (index < resize)
                {
                    TeamsBackup[index] = new DataRow[resize + 1];
                    TeamsBackup[index].SetValue(dr, 0);
                    for (int i = 0; i < Teams[index].Length; i++)
                    {
                        TeamsBackup[index][i + 1] = Teams[index][i];
                    }
                    if (TeamsBackup[index].Length % 2 == 1)
                    {
                        DataRow drItem = TeamsBackup[index][Teams[index].Length];

                        //TeamsBackup[index][Teams[index].Length].Delete();

                        TeamsBackup[index] = ResizeArray(TeamsBackup[index], Teams[index].Length);
                        int resize2 = Teams[++index].Length;
                        if (index < resize2)
                        {
                            SetList(Teams, TeamsBackup, drItem, index, 0);
                            //return;
                        }
                    }
                    return;
                }
            }
            else if (count == 1)
            {
                for (int i = 0; i < Teams[index].Length - 1; i++)
                {
                    TeamsBackup[index][i] = Teams[index][i];
                }
                count = 0;
                return;
            }

            for (index = 0; index < Teams.GetUpperBound(0); index++)
            {
                if (Teams[index].Length % 2 == 1)
                {
                    DataRow drItem = Teams[index].ElementAt(Teams.Length);
                    TeamsBackup[index] = new DataRow[Teams[index].Length - 1];
                    SetList(Teams, TeamsBackup, null, index, 1);
                    index += 1;
                    SetList(Teams, TeamsBackup, drItem, index, 0);
                }
                else
                {
                    SetList(Teams, TeamsBackup, null, index, 1);
                }
            }
        }
        #endregion

        #region Floating a number
        static DataRow GetFloatRow(DataView dv)
        {
            DataRow drFloat = null;
            if (dv.ToTable().Rows.Count % 2 == 1)
            {
                drFloat = dv.ToTable().Rows[dv.ToTable().Rows.Count - 1];
            }
            return drFloat;
        }
        #endregion
    }
}
