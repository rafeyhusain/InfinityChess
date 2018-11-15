using System;
using System.Runtime.InteropServices;
using BackgroundCopyManager;

namespace App.Model
{
    public class UpdateJobProgress
    {
        #region Data members
        private readonly _BG_JOB_PROGRESS jobProgress; 
        #endregion

        #region Constructors
        public UpdateJobProgress(_BG_JOB_PROGRESS jobProgress)
        {
            this.jobProgress = jobProgress;
        } 
        #endregion

        #region Properties
        public Double BytesTotal
        {
            get
            {
                return Convert.ToDouble(jobProgress.BytesTotal);
            }
        }

        public Double BytesTransferred
        {
            get
            {
                return Convert.ToDouble(jobProgress.BytesTransferred);
            }
        }

        public int FilesTotal
        {
            get
            {
                return Convert.ToInt32(jobProgress.FilesTotal);
            }
        }

        public int FilesTransferred
        {
            get
            {
                return Convert.ToInt32(jobProgress.FilesTransferred);
            }
        } 
        #endregion

    }

    class BitsFileProgress
    {
        #region Data members
        private _BG_FILE_PROGRESS fileProgress; 
        #endregion

        #region Constructor
        public BitsFileProgress(_BG_FILE_PROGRESS fileProgress)
        {
            this.fileProgress = fileProgress;
        } 
        #endregion

        #region Properties
        public decimal BytesTotal
        {
            get { return Convert.ToDecimal(fileProgress.BytesTotal); }
        }

        public decimal BytesTransferred
        {
            get { return Convert.ToDecimal(fileProgress.BytesTransferred); }
        }

        public bool Completed
        {
            get { return Convert.ToBoolean(fileProgress.Completed); }
        } 
        #endregion

    }
}
