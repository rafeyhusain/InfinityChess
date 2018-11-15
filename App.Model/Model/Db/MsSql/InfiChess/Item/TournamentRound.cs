using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
/// <summary>
/// Summary description for TournamentRound
/// </summary>
namespace App.Model.Db
{
    public class TournamentRound : BaseItem
    {
        #region Constructor
        public TournamentRound()
            : base(0)
        {
        }

        public TournamentRound(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public TournamentRound(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public TournamentRound(Cxt cxt, DataRow row)
        {
            Cxt = cxt;

            DataRow = row;
        }

       
        #endregion
        
        #region Properties

        #region Core
        public override InfiChess TableName
        {
            [DebuggerStepThrough]
            get { return InfiChess.TournamentRound; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion

        #region Enum
        public StatusE StatusIDE { [DebuggerStepThrough] get { return (StatusE)this.StatusID; } [DebuggerStepThrough] set { this.StatusID = (int)value; } }
        public GameResultE GameResultIDE { [DebuggerStepThrough] get { return (GameResultE)this.GameResultID; } [DebuggerStepThrough] set { this.GameResultID = (int)value; } }
        #endregion

        #region Generated
        public int TournamentRoundID { [DebuggerStepThrough]get { return GetColInt32("TournamentRoundID"); } [DebuggerStepThrough] set { SetColumn("TournamentRoundID", value); } }
        public int TournamentID { [DebuggerStepThrough] get { return GetColInt32("TournamentID"); } [DebuggerStepThrough] set { SetColumn("TournamentID", value); } }
        public int Round { [DebuggerStepThrough] get { return GetColInt32("Round"); } [DebuggerStepThrough]set { SetColumn("Round", value); } }
        public int WhiteUserID { [DebuggerStepThrough] get { return GetColInt32("WhiteUserID"); } [DebuggerStepThrough]set { SetColumn("WhiteUserID", value); } }
        public int BlackUserID { [DebuggerStepThrough] get { return GetColInt32("BlackUserID"); } [DebuggerStepThrough]set { SetColumn("BlackUserID", value); } }
        public int StatusID { [DebuggerStepThrough]get { return GetColInt32("StatusID"); } [DebuggerStepThrough]set { SetColumn("StatusID", value); } }
        public decimal WhitePoints { [DebuggerStepThrough] get { return GetColDecimal("WhitePoints"); } [DebuggerStepThrough]set { SetColumn("WhitePoints", value); } }
        public decimal BlackPoints { [DebuggerStepThrough] get { return GetColDecimal("BlackPoints"); } [DebuggerStepThrough]set { SetColumn("BlackPoints", value); } }
        public int GameResultID { [DebuggerStepThrough] get { return GetColInt32("GameResultID"); } [DebuggerStepThrough]set { SetColumn("GameResultID", value); } }
        #endregion

        #endregion 
       
        #region Methods

        #region GetTournamentRound

        public static TournamentRound GetTournamentRoundById(Cxt cxt, int TournamentRoundId)
        {
            return new TournamentRound(cxt, BaseCollection.SelectItem(InfiChess.TournamentRound, TournamentRoundId));
        }

        public static DataTable GetTournamentRoundByPlayers(int toutnamentId, int round, int whiteUserId, int blackUserId)
        {
            DataTable dt = BaseCollection.Execute("GetTournamentRoundByPlayers", toutnamentId, round, whiteUserId, blackUserId);
            dt.TableName = InfiChess.TournamentRound.ToString();
            return dt;
        }
        
        #endregion

        #endregion
    }
}