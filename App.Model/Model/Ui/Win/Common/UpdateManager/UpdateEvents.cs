using System;
using System.Runtime.InteropServices;
using BackgroundCopyManager;

namespace App.Model
{
    class UpdateEvents : IBackgroundCopyCallback
    {
        #region Constructor
        public UpdateJobEventer JobEvents;
        #endregion

        #region Methods
        void IBackgroundCopyCallback.JobError(IBackgroundCopyJob job, IBackgroundCopyError error)
        {
            JobEvents.ErrorEvent(new UpdateJob(job), error);
        }

        void IBackgroundCopyCallback.JobModification(IBackgroundCopyJob job, System.UInt32 dwReserved)
        {
            JobEvents.ModificationEvent(new UpdateJob(job));
        }

        void IBackgroundCopyCallback.JobTransferred(IBackgroundCopyJob job)
        {
            JobEvents.TransferredEvent(new UpdateJob(job));
        }
        #endregion
    }

    public class UpdateJobEventer
    {
        #region Data members
        private UpdateEvents callback; 
        #endregion

        #region Events
        public event EventHandler<UpdateJobErrorEventArgs> OnJobError;
        public event EventHandler<UpdateJobEventArgs> OnJobModification;
        public event EventHandler<UpdateJobEventArgs> OnJobTransferred; 
        #endregion

        #region constructor
        public UpdateJobEventer()
        {
            callback = new UpdateEvents();
            callback.JobEvents = this;
        }
        #endregion

        #region Methods
        public void ErrorEvent(UpdateJob errorJob, IBackgroundCopyError errorInfo)
        {
            if (OnJobError != null)
                OnJobError.Invoke(this, new UpdateJobErrorEventArgs(errorJob, errorInfo));
        }

        public void ModificationEvent(UpdateJob modifiedJob)
        {
            if (OnJobModification != null)
                OnJobModification.Invoke(this, new UpdateJobEventArgs(modifiedJob));
        }

        public void TransferredEvent(UpdateJob transferredJob)
        {
            if (OnJobTransferred != null)
                OnJobTransferred.Invoke(this, new UpdateJobEventArgs(transferredJob));
        }

        public void AddJob(UpdateJob jobToMonitor, JobNotificationType notifyType)
        {
            jobToMonitor.NotifyInterface = callback;
            jobToMonitor.NotifyFlags = notifyType;
        }

        public void AddJob(UpdateJob jobToMonitor)
        {
            AddJob(jobToMonitor, JobNotificationType.JobError | JobNotificationType.JobTransferred);
        } 
        #endregion
    }

    public class UpdateJobEventArgs:EventArgs 
    {
        public readonly UpdateJob CopyJob;
        public readonly String DisplayName;

        public UpdateJobEventArgs(UpdateJob job)
        {
            CopyJob = job;
            DisplayName = job.DisplayName;
        }
    }

    public class UpdateJobErrorEventArgs : UpdateJobEventArgs
    {
        IBackgroundCopyError errorInfo;
        public readonly BackgroundCopyManager.BG_ERROR_CONTEXT ErrorContext;
        public readonly Int32 ErrorCode;

        private int GetCurrentLCID()
        {
            return System.Threading.Thread.CurrentThread.CurrentUICulture.LCID;
        }
            
        public String GetErrorDescription()
        {
            return GetErrorDescription(GetCurrentLCID());
        }
            
        public String GetErrorDescription(int LcId)
        {
            String errorDesc;
            errorInfo.GetErrorDescription(Convert.ToUInt32(LcId), out errorDesc);
            return errorDesc;
        }
           
        public String GetErrorContextDescription()
        {
            return GetErrorContextDescription(GetCurrentLCID());
        }

        public String GetErrorContextDescription(int LcId)
        {
            String  errorContextDesc;
            errorInfo.GetErrorContextDescription(Convert.ToUInt32(LcId), out errorContextDesc);
            return errorContextDesc;
        }
  
        public UpdateJobErrorEventArgs(UpdateJob eventJob, IBackgroundCopyError errorInfo):base(eventJob)
        {
            this.errorInfo = errorInfo;
         }
    }
}
