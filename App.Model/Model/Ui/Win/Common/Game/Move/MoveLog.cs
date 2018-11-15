using System;
using System.Collections.Generic;
using System.Text;
using App.Model.Db;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace App.Model
{
    public class MoveLog
    {
        #region Data Members
        public DataTable DataTable = null;
        public MoveComments MoveComments = null;
        public Game Game = null;

        #region Columns
        public const string DisconnectStartTime = "S";
        public const string DisconnectEndTime = "E";
        #endregion

        #endregion

        #region Properties
        public bool IsEmpty
        {
            get
            {
                if (DataTable == null)
                {
                    return true;
                }

                if (DataTable.Rows.Count == 0)
                {
                    return true;
                }

                return false;
            }
        }

        #region Instance
        private static MoveLog instance = null;


        public static MoveLog Instance
        {
            [DebuggerStepThrough]
            get
            {
                if (instance == null)
                {
                    instance = new MoveLog(Ap.Game);
                }

                return instance;
            }
            [DebuggerStepThrough]
            set { instance = value; }
        }

        #endregion

        #endregion

        #region Constructor
        public MoveLog(Game game)
        {
            Game = game;

            DataTable = GetMoveLogTable();
        }

        public MoveLog(MoveComments moveComments)
        {
            Game = moveComments.Move.Game;

            DataTable = GetMoveLogTable();

            this.MoveComments = moveComments;

            UData.LoadDataTable(DataTable, this.MoveComments[MoveCommentTypeE.MoveLog]);
        }

        public DataRow NewRow()
        {
            DataRow row = this.DataTable.NewRow();

            this.DataTable.Rows.Add(row);

            this.DataTable.AcceptChanges();

            return row;
        }

        #endregion

        #region Methods
        public void Disconnected()
        {
            if (Game == null)
            {
                return;
            }

            if (!IsAlreadyDisconnected())
            {
                DataRow row = NewRow();
                DateTime serverDisconnectStartTime = DateTime.Now.Add(ServerClientTimeDifference());
                row[MoveLog.DisconnectStartTime] = serverDisconnectStartTime;
                this.DataTable.AcceptChanges();
            }
        }

        public void Connected()
        {
            if (Game == null)
            {
                return;
            }

            DataRow row = GetLastRow();
            if (row != null)
            {
                DateTime serverDisconnectEndTime = DateTime.Now.Add(ServerClientTimeDifference());
                row[MoveLog.DisconnectEndTime] = serverDisconnectEndTime;
                this.DataTable.AcceptChanges();
            }
        }

        private DataRow GetLastRow()
        {
            if (IsEmpty)
            {
                return null;
            }
            else
            {
                return DataTable.Rows[DataTable.Rows.Count - 1];
            }
        }

        private bool IsAlreadyDisconnected()
        {
            DataRow lastRow = GetLastRow();
            if (lastRow != null)
            {
                if (!string.IsNullOrEmpty(lastRow[MoveLog.DisconnectEndTime].ToString()))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public TimeSpan ServerClientTimeDifference()
        {
            return Game.GameStartTimeServer.Subtract(Game.GameStartTimeLocal);
        }

        public string ToStringDataTable()
        {
            return UData.ToString(this.DataTable);
        }

        public override string ToString()
        {
            if (Game.Flags.IsOffline)
            {
                return ""; // no disconnection log
            }

            if (!IsEmpty)
            {
                StringBuilder logInfo = new StringBuilder();
                bool isFirstLog = true;
                if (!string.IsNullOrEmpty(DataTable.Rows[0][MoveLog.DisconnectEndTime].ToString()))
                {
                    logInfo.Append("'" + Game.CurrentPlayer.PlayerTitle.Trim() + "'");
                    logInfo.Append(" disconnected");
                }
                foreach (DataRow row in DataTable.Rows)
                {
                    if (!string.IsNullOrEmpty(row[MoveLog.DisconnectEndTime].ToString()))
                    {
                        if (!isFirstLog)
                        {
                            logInfo.Append(", ");
                        }

                        if (!string.IsNullOrEmpty(row[MoveLog.DisconnectStartTime].ToString()) && !string.IsNullOrEmpty(row[MoveLog.DisconnectEndTime].ToString()))
                        {
                            DateTime serverGameStartTime = Convert.ToDateTime(row[MoveLog.DisconnectStartTime].ToString());
                            DateTime serverGameEndTime = Convert.ToDateTime(row[MoveLog.DisconnectEndTime].ToString());
                            TimeSpan ts = serverGameEndTime.Subtract(serverGameStartTime);
                            if (ts.Duration() == TimeSpan.Zero)
                            {
                                logInfo.Append(" for a few milliseconds. ");
                            }
                            else
                            {
                                if (ts.Hours > 0)
                                {
                                    logInfo.Append(" " + ts.Hours.ToString() + "h");
                                }
                                if (ts.Minutes > 0)
                                {
                                    logInfo.Append(" " + ts.Minutes.ToString() + "m");
                                }
                                if (ts.Seconds > 0)
                                {
                                    logInfo.Append(" " + ts.Seconds.ToString() + "s");
                                }
                            }
                            logInfo.Append(" " + "[" + serverGameStartTime.ToString("d/M/yyyy") + " b/w " + serverGameStartTime.ToString("h:mm:sst").ToLower() + " to " + serverGameEndTime.ToString("h:mm:sst").ToLower() + " ST] ");
                        }
                    }
                    isFirstLog = false;
                }
                return logInfo.ToString();
            }
            else
            {
                return "";
            }
        }

        public void Clear()
        {
            DataTable.Clear();
        }
        #endregion

        #region Helpers

        public static DataTable GetMoveLogTable()
        {
            DataSet ds = new DataSet();

            DataTable table = ds.Tables.Add("L");

            table.Columns.Add(new DataColumn(MoveLog.DisconnectStartTime, typeof(string)));
            table.Columns.Add(new DataColumn(MoveLog.DisconnectEndTime, typeof(string)));

            return table;

        }
        #endregion

        public void Set(MoveLog moveLog)
        {
            this.DataTable = moveLog.DataTable.Copy();
        }
    }
}
