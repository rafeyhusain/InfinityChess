using System;
using System.Runtime.InteropServices;
using BackgroundCopyManager;

namespace App.Model
{
    public class UpdateJob
    {
        #region Data members
        private IBackgroundCopyJob copyJob;
        #endregion

        #region Constructor
        public UpdateJob(IBackgroundCopyJob bitsJob)
        {
            copyJob = bitsJob;
        } 
        #endregion

        #region Properties
        public Guid Id
        {
            get
            {
                try
                {
                    BackgroundCopyManager.GUID jobId;
                    copyJob.GetId(out jobId);
                    //BITS returns a GUID structure, which ConvertToGUID converts into
                    //a System.GUID for ease of use within .NET
                    return UpdateUtility.ConvertToGuid(jobId);
                }
                catch (COMException ex)
                {
                    throw new Exception(String.Format("Error getting Job id ({0}).", ex.Message));
                }

            }
        }

        public String Description
        {
            get
            {
                String jobDesc = String.Empty;
                copyJob.GetDescription(out jobDesc);
                return jobDesc;
            }
            set
            {
                copyJob.SetDescription(value);
            }
        }

        public Int64 MinimumRetryDelay
        {
            get
            {
                UInt32 delay;
                copyJob.GetMinimumRetryDelay(out delay);
                return Convert.ToInt64(delay);
            }

            set
            {
                UInt32 delay = Convert.ToUInt32(value);
                copyJob.SetMinimumRetryDelay(delay);
            }
        }

        public Int64 NoProgressTimeout
        {
            get
            {
                UInt32 timeout;
                copyJob.GetNoProgressTimeout(out timeout);
                return Convert.ToInt64(timeout);
            }
            set
            {
                UInt32 timeout = Convert.ToUInt32(value);
                copyJob.SetNoProgressTimeout(timeout);
            }
        }

        public String DisplayName
        {
            get
            {
                try
                {
                    String jobName;
                    copyJob.GetDisplayName(out jobName);
                    return jobName;
                }
                catch (COMException ex)
                {
                    throw new Exception(String.Format("Error Creating Job ({0}).", ex.Message));
                }
            }
            set
            {
                try
                {
                    copyJob.SetDisplayName(value);
                }
                catch (COMException ex)
                {
                    throw new Exception(String.Format("Error Creating Job ({0}).", ex.Message));
                }
            }
        }

        public UpdateJobState State
        {
            get
            {
                try
                {
                    BG_JOB_STATE jobState;
                    copyJob.GetState(out jobState);
                    return (UpdateJobState)jobState;
                }
                catch (COMException ex)
                {
                    throw new Exception(String.Format("Error getting job state ({0}).", ex.Message));
                }
            }
        }

        public UpdateJobProgress Progress
        {
            get
            {
                try
                {
                    _BG_JOB_PROGRESS jobProgress;
                    copyJob.GetProgress(out jobProgress);
                    return new UpdateJobProgress(jobProgress);
                }
                catch (COMException ex)
                {
                    throw new Exception(String.Format("Error getting progress ({0}).", ex.Message));
                }
            }
        }

        public UpdateJobPriority Priority
        {
            get
            {
                BG_JOB_PRIORITY priority = default(BG_JOB_PRIORITY);
                copyJob.GetPriority(out priority);
                return (UpdateJobPriority) priority;
            }
            set 
            { 
                copyJob.SetPriority((BG_JOB_PRIORITY)value);
            }
        }

        public IBackgroundCopyCallback NotifyInterface
        {
            get
            {
                IBackgroundCopyCallback Notify = default(IBackgroundCopyCallback);
                object Callback = null;
                copyJob.GetNotifyInterface(out Callback);
                Notify = (IBackgroundCopyCallback)Callback;
                return Notify;
            }
            set
            {
                object Callback = null;
                Callback = (object)value;
                copyJob.SetNotifyInterface(Callback);
            }
        }

        public JobNotificationType NotifyFlags
        {
            get
            {
                UInt32 value = default(UInt32);
                copyJob.GetNotifyFlags(out value);
                return (JobNotificationType)Convert.ToInt32(value);
            }
            set
            {
                UInt32 uintvalue = default(UInt32);
                uintvalue = Convert.ToUInt32(value);
                copyJob.SetNotifyFlags(uintvalue);
            }
        } 
        #endregion

        #region Methods
        public void AddFile(String localFileName, String remoteFileName)
        {
            //TODO Check if local file already exists?
            try
            {
                copyJob.AddFile(remoteFileName, localFileName);
            }
            catch (COMException ex)
            {
                throw new Exception(String.Format("Error adding file ({0}).", ex.Message));
            }
        }

        public void Cancel()
        {
            //Possible Errors
            //BG_S_UNABLE_TO_DELETE_FILES    Job was successfully canceled; however, the service was unable to delete the temporary files associated with the job. 
            //BG_E_INVALID_STATE             Cannot cancel a job whose state is BG_JOB_STATE_CANCELLED or BG_JOB_STATE_ACKNOWLEDGED.   
            copyJob.Cancel();
        }

        public void Complete()
        {
            copyJob.Complete();
        }

        public void Suspend()
        {
            //TODO Check if job is already suspended?
            copyJob.Suspend();
        }

        public void Resume()
        {
            copyJob.Resume();
        }

        public void TakeOwnership()
        {
            //Converts ownership to the current user
            copyJob.TakeOwnership();
        } 
        #endregion
    }
}
