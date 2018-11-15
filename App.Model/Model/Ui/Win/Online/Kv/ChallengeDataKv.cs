using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using App.Model.Db;
using System.Drawing;
using System.IO;
using System.Data.SqlClient;
using System.Diagnostics;
namespace App.Model
{
    public class ChallengeDataKv : BaseDataKv
    {
        #region Data Member
        
        #endregion

        #region Properties

        
        #region Core

        #endregion

        #region Enum
        public StatusE StatusIDE { [DebuggerStepThrough]get { return (StatusE)this.StatusID; } [DebuggerStepThrough]set { this.StatusID = (int)value; } }
        public ColorE ColorIDE { [DebuggerStepThrough]get { return (ColorE)this.ColorID; } [DebuggerStepThrough]set { this.ColorID = (int)value; } }
        public GameType GameTypeIDE { [DebuggerStepThrough]get { return (GameType)this.GameTypeID; } [DebuggerStepThrough] set { this.GameTypeID = (int)value; } }
        public ChallengeTypeE ChallengeTypeIDE { [DebuggerStepThrough]get { return (ChallengeTypeE)this.ChallengeTypeID; } [DebuggerStepThrough]set { this.ChallengeTypeID = (int)value; } }
        #endregion

        #region Generated
        public int ChallengeID { [DebuggerStepThrough]get { return Kv.GetInt32("ChallengeID"); } [DebuggerStepThrough]set { Kv.Set("ChallengeID", value); } }
        public int ChallengerUserID { [DebuggerStepThrough] get { return Kv.GetInt32("ChallengerUserID"); } [DebuggerStepThrough]set { Kv.Set("ChallengerUserID", value); } }
        public int OpponentUserID { [DebuggerStepThrough] get { return Kv.GetInt32("OpponentUserID"); } [DebuggerStepThrough] set { Kv.Set("OpponentUserID", value); } }
        public int RoomID { [DebuggerStepThrough]get { return Kv.GetInt32("RoomID"); } [DebuggerStepThrough] set { Kv.Set("RoomID", value); } }
        public int GameTypeID { [DebuggerStepThrough]get { return Kv.GetInt32("GameTypeID"); } [DebuggerStepThrough]set { Kv.Set("GameTypeID", value); } }
        public int ChessTypeID { [DebuggerStepThrough] get { return Kv.GetInt32("ChessTypeID"); } [DebuggerStepThrough] set { Kv.Set("ChessTypeID", value); } }
        public int ChallengeStatusID { [DebuggerStepThrough] get { return Kv.GetInt32("ChallengeStatusID"); } [DebuggerStepThrough]set { Kv.Set("ChallengeStatusID", value); } }
        public int ColorID { [DebuggerStepThrough]get { return Kv.GetInt32("ColorID"); } [DebuggerStepThrough] set { Kv.Set("ColorID", value); } }
        public int ChallengeTypeID { [DebuggerStepThrough]get { return Kv.GetInt32("ChallengeTypeID"); } [DebuggerStepThrough] set { Kv.Set("ChallengeTypeID", value); } }
        public int StatusID { [DebuggerStepThrough]get { return Kv.GetInt32("StatusID"); } [DebuggerStepThrough]set { Kv.Set("StatusID", value); } }
        public int TimeMin { [DebuggerStepThrough] get { return Kv.GetInt32("TimeMin"); } [DebuggerStepThrough] set { Kv.Set("TimeMin", value); } }
        public int GainPerMoveMin { [DebuggerStepThrough]get { return Kv.GetInt32("GainPerMoveMin"); } [DebuggerStepThrough]set { Kv.Set("GainPerMoveMin", value); } }
        public int TimeMax { [DebuggerStepThrough] get { return Kv.GetInt32("TimeMax"); } [DebuggerStepThrough] set { Kv.Set("TimeMax", value); } }
        public int GainPerMoveMax { [DebuggerStepThrough]get { return Kv.GetInt32("GainPerMoveMax"); } [DebuggerStepThrough]set { Kv.Set("GainPerMoveMax", value); } }
        public string Description { [DebuggerStepThrough]get { return Kv.Get("Description"); } [DebuggerStepThrough]set { Kv.Set("Description", value); } }
        public bool IsRated { [DebuggerStepThrough]get { return Kv.GetBool("IsRated"); } [DebuggerStepThrough]set { Kv.Set("IsRated", value); } }
        public bool WithClock { [DebuggerStepThrough]get { return Kv.GetBool("WithClock"); } [DebuggerStepThrough]set { Kv.Set("WithClock", value); } }
        public bool IsChallengerSendsGame { [DebuggerStepThrough]get { return Kv.GetBool("IsChallengerSendsGame"); } [DebuggerStepThrough]set { Kv.Set("IsChallengerSendsGame", value); } }
        public int Stake { [DebuggerStepThrough] get { return Kv.GetInt32("Stake"); } [DebuggerStepThrough] set { Kv.Set("Stake", value); } }
        public int Flate { [DebuggerStepThrough]get { return Kv.GetInt32("Flate"); } [DebuggerStepThrough]set { Kv.Set("Flate", value); } }
        #endregion

        #region Calculated

        #endregion

        #endregion

        #region Constructor
        public ChallengeDataKv()
        {
            Kv = new Kv(KvType.Web);
        }

        public ChallengeDataKv(Kv kv)
        {
            base.Kv = kv;
        }

        #endregion

        #region Methods

        public DataTable AddChallenge()
        {
            Challenge item;
            
            try
            {
                string selectQuery;
                DataTable table;
                if (OpponentUserID != 0)
                {
                    selectQuery = "SELECT TOP 1 * FROM Challenge WHERE ChallengerUserID = @p1 AND OpponentUserID = @p2 AND ChallengeStatusID = 1 AND StatusID = 1";
                    table = BaseCollection.ExecuteSql(InfiChess.Challenge, selectQuery, ChallengerUserID, OpponentUserID);
                }
                else
                {
                    selectQuery = "SELECT TOP 1 * FROM Challenge WHERE ChallengerUserID = @p1 AND OpponentUserID IS NULL AND ChallengeStatusID = 1 AND StatusID = 1";
                    table = BaseCollection.ExecuteSql(InfiChess.Challenge, selectQuery, ChallengerUserID, null);
                }

                if (table != null && table.Rows.Count > 0)
                {
                    item = new Challenge(base.Kv.Cxt, table.Rows[0]);
                }
                else
                {
                    item = new Challenge();
                }

                item.Cxt = base.Kv.Cxt;
                item.ChallengerUserID = ChallengerUserID;
                item.ChallengeTypeID = ChallengeTypeID;
                item.ChessTypeID = ChessTypeID;
                item.ColorID = ColorID;
                item.IsRated = IsRated;
                item.WithClock = WithClock;
                item.IsChallengerSendsGame = IsChallengerSendsGame;
                item.Description = Description;
                item.GameTypeID = GameTypeID;

                if (OpponentUserID > 0)
                {
                    item.OpponentUserID = OpponentUserID;
                }

                item.RoomID = RoomID;
                item.StatusID = StatusID;
                item.TimeMin = TimeMin;
                item.GainPerMoveMin = GainPerMoveMin;
                item.ChallengeStatusIDE = ChallengeStatusE.Seeking;
                item.Stake = Stake;
                item.Flate = Flate;
                item.Cxt.CurrentUserID = Kv.Cxt.CurrentUserID;

                item.Save();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Challenges.GetChallengesByRoomID(item.Cxt, RoomID, item.Cxt.CurrentUserID);
        }

        public DataTable ModifyChallenge()
        {
            Challenge item;

            try
            {
                item = new Challenge(Kv.Cxt, ChallengeID);
                item.Cxt = base.Kv.Cxt;
                item.ChallengerUserID = ChallengerUserID;
                item.ChallengeTypeID = ChallengeTypeID;
                item.ChessTypeID = ChessTypeID;
                item.ColorID = ColorID;
                item.IsRated = IsRated;
                item.WithClock = WithClock;
                item.IsChallengerSendsGame = IsChallengerSendsGame;
                item.Description = Description;
                item.GameTypeID = GameTypeID;
                item.OpponentUserID = OpponentUserID;
                item.RoomID = RoomID;
                item.StatusID = StatusID;
                item.TimeMin = TimeMin;
                item.GainPerMoveMin = GainPerMoveMin;
                item.ChallengeStatusIDE = ChallengeStatusE.Seeking;
                item.Cxt.CurrentUserID = Kv.Cxt.CurrentUserID;

                item.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Challenges.GetChallengesByRoomID(item.Cxt, RoomID, item.Cxt.CurrentUserID);
        }

        #endregion

    }
}
