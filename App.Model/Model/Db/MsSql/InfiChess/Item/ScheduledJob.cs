using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;
namespace App.Model.Db
{
    public class ScheduledJob : BaseItem
    {
        #region Constructor
        public ScheduledJob()
            : base(0)
        {
        }

        public ScheduledJob(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public ScheduledJob(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public ScheduledJob(Cxt cxt, DataRow row)
        {
            Cxt = cxt;

            DataRow = row;
        }
        #endregion

        #region Properties

        #region Core
        public override InfiChess TableName { [DebuggerStepThrough] get { return InfiChess.ScheduledJob; } [DebuggerStepThrough] set { base.TableName = value; } }
        #endregion

        #region Enum
        #endregion

        #region Generated
        public int ScheduledJobID { [DebuggerStepThrough] get { return GetColInt32("ScheduledJobID"); } [DebuggerStepThrough] set { SetColumn("ScheduledJobID", value); } }
        public string Cron { [DebuggerStepThrough] get { return GetCol("Cron"); } [DebuggerStepThrough] set { SetColumn("Cron", value); } }
        public string JobClassName { [DebuggerStepThrough] get { return GetCol("JobClassName"); } [DebuggerStepThrough] set { SetColumn("JobClassName", value); } }
        public DateTime LastRunAt { [DebuggerStepThrough] get { return GetColDateTime("LastRunAt"); } [DebuggerStepThrough] set { SetColumn("LastRunAt", value); } }
        public DateTime DataModified { [DebuggerStepThrough] get { return GetColDateTime("DataModified"); } [DebuggerStepThrough] set { SetColumn("DataModified", value); } }
        #endregion

        #region Contained Classes
        #endregion

        #region Calculated
        public string Group { [DebuggerStepThrough] get { return "Group1"; } }
        public string Trigger { [DebuggerStepThrough] get { return "Trigger" + Name; } }
        public string TriggerGroup { [DebuggerStepThrough] get { return "Group1" + Trigger; } }

        #endregion

        #endregion

        #region Methods

        public static ScheduledJob GetScheduledJobById(Cxt cxt, int ScheduledJobID)
        {
            return new ScheduledJob(cxt, BaseCollection.SelectItem(InfiChess.ScheduledJob, ScheduledJobID));
        }

        public static ScheduledJob GetTopScheduledJob(Cxt cxt)
        {
            ScheduledJobs ScheduledJob = new ScheduledJobs(cxt,
                            BaseCollection.ExecuteSql(InfiChess.ScheduledJob,
                            "select top 1 * from ScheduledJob order by ScheduledJobID desc"));

            return ScheduledJob[0];
        }
        #endregion
    }
}
