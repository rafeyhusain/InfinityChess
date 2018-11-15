using System;
using System.Runtime.InteropServices;
using BackgroundCopyManager;

namespace App.Model
{
    #region Enums
    internal enum BitsJobType
    {
        CurrentUser = 0,
        AllUsers = 1
    }

    public enum JobNotificationType
    {
        JobTransferred = 1,
        JobError = 2,
        JobModification = 8
    }

    public enum UpdateJobPriority
    {
        Foreground = 0,
        High = 1,
        Normal = 2,
        Low = 3
    }

    public enum UpdateJobState
    {
        Queued = 0,
        Connecting = 1,
        Transferring = 2,
        Suspended = 3,
        Errors = 4,
        TransientError = 5,
        Transferred = 6,
        Acknowledged = 7,
        Cancelled = 8
    }

    internal enum BitsProxyUsage
    {
        NoProxy = 1,
        Override = 2,
        Preconfig = 0
    } 
    #endregion

    public class UpdateManager
    {
        private int DEFAULT_RETRY_PERIOD = 1209600; //20160 minutes (1209600 seconds)
        private int DEFAULT_RETRY_DELAY = 600; // 10 minutes (600 seconds)

        #region Data members
        private IBackgroundCopyManager copyManager; 
        #endregion

        #region Constructor
        public UpdateManager()
        {
            try
            {
                copyManager = new BackgroundCopyManager.BackgroundCopyManager();
            }
            catch (COMException ex)
            {
                throw new Exception(String.Format("Error Creating Job ({0}).", ex.Message));
            }
        } 
        #endregion

        #region Methods
        public UpdateJob CreateJob(String jobName, String description, Int64 retryPeriod, Int64 retryDelay)
        {
            IBackgroundCopyJob newJob;
            GUID newJobID;

            try
            {
                copyManager.CreateJob(jobName, BG_JOB_TYPE.BG_JOB_TYPE_DOWNLOAD, out newJobID, out newJob);
                UpdateJob myJob = new UpdateJob(newJob);
                myJob.Description = description;

                //if (retryPeriod != DEFAULT_RETRY_PERIOD)
                myJob.NoProgressTimeout = DEFAULT_RETRY_PERIOD;

                //if (retryDelay != DEFAULT_RETRY_DELAY)
                myJob.MinimumRetryDelay = DEFAULT_RETRY_DELAY;

                return myJob;
            }
            catch (COMException ex)
            {
                throw new Exception(String.Format("Error Creating Job ({0}).", ex.Message));
            }
        }

        public UpdateJob FindJob(System.Guid jobId)
        {
            try
            {
                IBackgroundCopyJob foundJob;
                GUID guid = UpdateUtility.ConvertToBitsGuid(jobId);
                copyManager.GetJob(ref guid, out foundJob);
                return new UpdateJob(foundJob);
            }
            catch (COMException ex)
            {
                throw new Exception(String.Format("Error finding job ({0}).", ex.Message));
            }
        }

        public UpdateJobs GetJobs()
        {
            UpdateJobs myJobs = new UpdateJobs();

            IEnumBackgroundCopyJobs copyJobs;
            IBackgroundCopyJob retrievedJob;

            UInt32 uintFetched = Convert.ToUInt32(0);
            Int32 intFetched;

            try
            {
                copyManager.EnumJobs(Convert.ToUInt32(0), out copyJobs);
                do
                {
                    copyJobs.Next(Convert.ToUInt32(1), out retrievedJob, ref uintFetched);
                    intFetched = Convert.ToInt32(uintFetched);
                    if (intFetched == 1)
                        myJobs.Add(new UpdateJob(retrievedJob));
                }
                while (intFetched == 1);

                return myJobs;
            }

            catch (COMException ex)
            {
                throw new Exception(String.Format("Error Creating Job ({0}).", ex.Message));
            }
        } 
        #endregion
    }
}
