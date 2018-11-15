// (c) Copyright RafeySoft, Karachi Pakistan. http://rafeysoft.com
// This source is subject to following License:
// http://rafeysoft.com/Web/Page/ItemEdit.aspx?sid=29&lid=4&cid=23&iid=2143
// Please write to info@rafeysoft.com for more information
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Diagnostics;
namespace App.Model.Db 
{
    public class TournamentRounds : BaseItems<TournamentRound, TournamentRounds>
    {
        #region Constructors
        public TournamentRounds()
        {
        }

        public TournamentRounds(Cxt cxt)
        {
            Cxt = cxt;
        }

        public TournamentRounds(Cxt cxt, BaseCollection items)
        {
            Cxt = cxt;

            DataTable = items.DataTable;
        }

        public TournamentRounds(Cxt cxt, DataTable table)
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
            get { return InfiChess.TournamentRound; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }
        #endregion

        #endregion 
              
        #region Methods
        public static DataTable GetAllTournamentRounds(int tournamentId)
        {
            return BaseCollection.ExecuteSql(InfiChess.TournamentRound, "TournamentID", tournamentId, "StatusID", (int)StatusE.Active);
        }

        public static DataTable GetTournamentRoundsByNo(int toutnamentId, int round)
        {
            DataTable table = BaseCollection.ExecuteSql(InfiChess.TournamentRound, "TournamentID", toutnamentId, "Round ", round, "StatusID", (int)StatusE.Active);
            return table;
        }

        public static DataTable GetTournamentWinnersByRound(int toutnamentId, int round)
        {
            DataTable dt = BaseCollection.Execute("GetTournamentPlayersByRound", toutnamentId, round, true);
            dt.TableName = InfiChess.TournamentRound.ToString();
            return dt;
        }

        public static DataTable GetTournamentLosersByRound(int toutnamentId, int round)
        {
            DataTable dt = BaseCollection.Execute("GetTournamentPlayersByRound", toutnamentId, round, false);
            dt.TableName = InfiChess.TournamentRound.ToString();
            return dt;
        }

        #region Delete Tournament Round By TournamentID
        public static void DeleteTournamentRoundByTournamentID(SqlTransaction trans, int tournamentID)
        {
            BaseCollection.ExecuteSql(trans, InfiChess.TournamentRound, "UPDATE TournamentRound set StatusID = @p1 where tournamentID = @p2", (int)StatusE.Deleted, tournamentID);
        }
        #endregion

        #endregion



    }
}
