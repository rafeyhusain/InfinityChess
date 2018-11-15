// (c) Copyright RafeySoft, Karachi Pakistan. http://rafeysoft.com
// This source is subject to following License:
// http://rafeysoft.com/Web/Page/ItemEdit.aspx?sid=29&lid=4&cid=23&iid=2143
// Please write to info@rafeysoft.com for more information
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using System.Diagnostics;
namespace App.Model.Db
{
    #region ChallengeStatusE

    public enum ChallengeStatusE
    {
        None = 0,
        Seeking = 1,
        Accepted = 2,
        Withdraw = 3,
        Decline = 4,
        Played = 5
    }
    
    #endregion

    #region ChallengeTypeE
    public enum ChallengeTypeE
    {
        None = 0,
        Seek = 1,
        Challenge = 2,
        Modify = 3,
        Decline = 4
    }
    #endregion
    
    public class Challenge : BaseItem
    {
        #region Constructor
        public Challenge()
            : base(0)
        {
        }

        public Challenge(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public Challenge(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public Challenge(Cxt cxt, DataRow row)
        {
            Cxt = cxt;
            DataRow = row;
        }

        #endregion

        #region Variable
        static int matchID = 0;
        #endregion

        #region Properties

        #region Core
        public override InfiChess TableName
        {
            [DebuggerStepThrough]
            get { return InfiChess.Challenge; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }
        #endregion

        #region Enum
        public StatusE StatusIDE { [DebuggerStepThrough]get { return (StatusE)this.StatusID; } [DebuggerStepThrough]set { this.StatusID = (int)value; } }
        public ColorE ColorIDE { [DebuggerStepThrough]get { return (ColorE)this.ColorID; } [DebuggerStepThrough] set { this.ColorID = (int)value; } }
        public ChallengeTypeE ChallengeTypeIDE { [DebuggerStepThrough]get { return (ChallengeTypeE)this.ChallengeTypeID; } [DebuggerStepThrough] set { this.ChallengeTypeID = (int)value; } }
        public GameType GameTypeIDE { [DebuggerStepThrough] get { return (GameType)this.GameTypeID; } [DebuggerStepThrough] set { this.GameTypeID = (int)value; } }
        public ChessTypeE ChessTypeIDE { [DebuggerStepThrough] get { return (ChessTypeE)this.ChessTypeID; } set { this.ChessTypeID = (int)value; } }
        #endregion

        #region Generated
        public int ChallengeID { [DebuggerStepThrough]get { return GetColInt32("ChallengeID"); } [DebuggerStepThrough] set { SetColumn("ChallengeID", value); } }
        public int ChallengerUserID { [DebuggerStepThrough] get { return GetColInt32("ChallengerUserID"); } [DebuggerStepThrough]set { SetColumn("ChallengerUserID", value); } }
        public int OpponentUserID { [DebuggerStepThrough] get { return GetColInt32("OpponentUserID"); } [DebuggerStepThrough] set { SetColumn("OpponentUserID", value); } }
        public int RoomID { [DebuggerStepThrough]get { return GetColInt32("RoomID"); } [DebuggerStepThrough] set { SetColumn("RoomID", value); } }
        public int GameTypeID { [DebuggerStepThrough]get { return GetColInt32("GameTypeID"); } [DebuggerStepThrough] set { SetColumn("GameTypeID", value); } }
        public int ChessTypeID { [DebuggerStepThrough]get { return GetColInt32("ChessTypeID"); } [DebuggerStepThrough] set { SetColumn("ChessTypeID", value); } }
        public int ChallengeStatusID { [DebuggerStepThrough] get { return GetColInt32("ChallengeStatusID"); } [DebuggerStepThrough] set { SetColumn("ChallengeStatusID", value); } }
        public int ColorID { [DebuggerStepThrough] get { return GetColInt32("ColorID"); } [DebuggerStepThrough]set { SetColumn("ColorID", value); } }
        public int ChallengeTypeID { [DebuggerStepThrough]get { return GetColInt32("ChallengeTypeID"); } [DebuggerStepThrough] set { SetColumn("ChallengeTypeID", value); } }
        public int StatusID { [DebuggerStepThrough]get { return GetColInt32("StatusID"); } [DebuggerStepThrough]set { SetColumn("StatusID", value); } }
        public int TimeMin { [DebuggerStepThrough]get { return GetColInt32("TimeMin"); } [DebuggerStepThrough]set { SetColumn("TimeMin", value); } }
        public int GainPerMoveMin { [DebuggerStepThrough]get { return GetColInt32("GainPerMoveMin"); } [DebuggerStepThrough]set { SetColumn("GainPerMoveMin", value); } }
        public int TimeMax { [DebuggerStepThrough]get { return GetColInt32("TimeMax"); } [DebuggerStepThrough]set { SetColumn("TimeMax", value); } }
        public int GainPerMoveMax { [DebuggerStepThrough]get { return GetColInt32("GainPerMoveMax"); } [DebuggerStepThrough]set { SetColumn("GainPerMoveMax", value); } }
        public bool IsRated { [DebuggerStepThrough] get { return GetColBool("IsRated"); } [DebuggerStepThrough]set { SetColumn("IsRated", value); } }
        public bool WithClock { [DebuggerStepThrough]get { return GetColBool("WithClock"); } [DebuggerStepThrough] set { SetColumn("WithClock", value); } }
        public bool IsChallengerSendsGame { [DebuggerStepThrough] get { return GetColBool("IsChallengerSendsGame"); } [DebuggerStepThrough]set { SetColumn("IsChallengerSendsGame", value); } }
        public int TournamentMatchID { [DebuggerStepThrough]get { return GetColInt32("TournamentMatchID"); } [DebuggerStepThrough]set { SetColumn("TournamentMatchID", value); } }
        public int Stake { [DebuggerStepThrough]get { return GetColInt32("Stake"); } [DebuggerStepThrough]set { SetColumn("Stake", value); } }
        public int Flate { [DebuggerStepThrough]get { return GetColInt32("Flate"); } [DebuggerStepThrough]set { SetColumn("Flate", value); } }
        #endregion

        #region Contained Classes
        private User challengerUser = null;
        public User ChallengerUser
        {
            [DebuggerStepThrough]
            get
            {
                if (challengerUser == null)
                {
                    challengerUser = new User(Cxt, this.ChallengerUserID);
                }

                return challengerUser;
            }
            [DebuggerStepThrough]
            set { challengerUser = value; }
        }

        private User opponentUser = null;
        public User OpponentUser
        {
            [DebuggerStepThrough]
            get
            {
                if (opponentUser == null)
                {
                    opponentUser = new User(Cxt, this.OpponentUserID);
                }

                return opponentUser;
            }
            [DebuggerStepThrough]
            set { opponentUser = value; }
        }

        #endregion

        #region Calculated
        public bool IsTournamentMatch { [DebuggerStepThrough] get { return this.TournamentMatchID == 0 ? false : true; } }
        public bool AmIChallenger { [DebuggerStepThrough] get { return ChallengerUserID == Ap.CurrentUserID; } }
        public bool AmIOpponent { [DebuggerStepThrough] get { return !AmIChallenger; } }

        public ChallengeStatusE ChallengeStatusIDE
        {
            [DebuggerStepThrough]
            get { return (ChallengeStatusE)this.ChallengeStatusID; }
            [DebuggerStepThrough]
            set { this.ChallengeStatusID = (int)value; }
        }
        #endregion

        #endregion 
        
        #region Methods 

        #region Get/Update/Decline/Delete...Challanges

        public static DataTable GetAcceptedChallenge(Cxt cxt, int roomID, int userID)
        {
            DataTable table = BaseCollection.ExecuteSql(InfiChess.Challenge, "SELECT TOP 1 * FROM Challenge WHERE RoomID=@p1 AND ChallengerUserID=@p2 AND ChallengeStatusID = 2  AND StatusID = 1", roomID, userID);

            if (table.Rows.Count > 0)
            {
                Challenge c = new Challenge(cxt, table.Rows[0]);

                c.ChallengeStatusIDE = ChallengeStatusE.Played;
                c.StatusIDE = StatusE.Inactive;
                c.Save();
            }

            return table;
        }

        public static DataTable DeleteChallenge(Cxt cxt, int challengeID)
        {
            Challenge item = new Challenge(cxt, challengeID);
            item.ChallengeStatusIDE = ChallengeStatusE.Withdraw;
            item.StatusIDE = StatusE.Deleted;
            item.Save();
            return Challenges.GetChallengesByRoomID(cxt, item.RoomID, item.ChallengerUserID);
        }

        public static DataTable DeclineChallenge(Cxt cxt, int challengeID)
        {
            Challenge item = new Challenge(cxt, challengeID);
            item.ChallengeStatusIDE = ChallengeStatusE.Decline;
            item.ChallengeTypeIDE = ChallengeTypeE.Decline;
            item.Save();
            return Challenges.GetChallengesByRoomID(cxt, item.RoomID, item.ChallengerUserID);
        }

        #endregion

        #region GetChallangeId

        public static Challenge GetChallangeById(Cxt cxt, int challengeID)
        {
            return new Challenge(cxt, BaseCollection.SelectItem(InfiChess.Challenge, challengeID));
        }

        public static Challenge GetChallangeByMatchId(Cxt cxt, int matchID)
        {
            return new Challenge(cxt, BaseCollection.SelectItem(InfiChess.Challenge, "TournamentMatchID=" + matchID));
        }
        
        #endregion

        #region Contained Methods

        #endregion

        #region Create Challenge
        /// <summary>
        /// Below function is used for single challenge created when tie break occurs
        /// </summary>
        /// <param name="tournamentMatch"></param>
        /// <returns></returns>
        public static Challenge CreateChallenge(TournamentMatch tournamentMatch)
        {
            matchID = tournamentMatch.TournamentMatchID;
            Challenge Challenge = new Challenge(tournamentMatch.Cxt, 0);
            Challenge.ChallengerUserID = tournamentMatch.WhiteUserID;
            Challenge.OpponentUserID = tournamentMatch.BlackUserID;
            Challenge.RoomID = 7;

            Challenge.ChessTypeIDE = tournamentMatch.Tournament.ChessTypeIDE;

            Challenge.ChallengeTypeIDE = ChallengeTypeE.Challenge;
            Challenge.ChallengeStatusIDE = ChallengeStatusE.Accepted;
            Challenge.StatusIDE = StatusE.Inactive;
            Challenge.ChallengeStatusIDE = ChallengeStatusE.Seeking;
            Challenge.StatusIDE = StatusE.Active;
            Challenge.IsRated = tournamentMatch.Tournament.Rated;
            Challenge.WithClock = true;
            Challenge.IsChallengerSendsGame = false;
            Challenge.GameTypeIDE = Game.GetGameType(tournamentMatch.TimeMin, tournamentMatch.TimeSec);
            Challenge.TimeMin = tournamentMatch.TimeMin;
            Challenge.GainPerMoveMin = tournamentMatch.TimeSec;
            Challenge.ColorIDE = ColorE.White;
            Challenge.TournamentMatchID = tournamentMatch.TournamentMatchID;
            Challenge.Cxt = tournamentMatch.Cxt;

            return Challenge;
        } 
        #endregion
        
        #endregion
    }
}
