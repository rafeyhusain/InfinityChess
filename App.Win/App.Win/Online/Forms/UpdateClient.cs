using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;

namespace App.Win
{
    public partial class UpdateClient : Form
    {
        #region Data members

        private UpdateManager manager;
        private UpdateJob job;
        private UpdateJobEventer jobEvents;
        private int totalItems = 0;
        private int currentPatchNo = 0;
        private string patchPath = "";
        private readonly Kv kv;
        private readonly String patchUrl;
        private readonly String currentVersionNo;

        private const String JOB_NAME = "Infinity Chess";
        private const String JOB_DESC = "Update download";
        
        private static UpdateClient updateClient;
        public static bool IsIdle = true;

        #endregion

        #region Ctor
        public UpdateClient(String patchUrl, String currentVersionNo)
        {
            InitializeComponent();
            this.patchUrl = patchUrl;
            this.currentVersionNo = currentVersionNo;
        }

        public UpdateClient(Kv kv, String patchUrl, String currentVersionNo)
        {
            InitializeComponent();
            this.kv = kv;
            this.patchUrl = patchUrl;
            this.currentVersionNo = currentVersionNo;
            patchPath = patchUrl.Substring(0, patchUrl.LastIndexOf("/"));
        } 

        #endregion

        #region Delegates 

        public delegate void BeginUpdateDelegate(String patchUrl, String currentVersionNo);
        public delegate void BeginUpdateDelegateKv(Kv kv, String patchUrl, String currentVersionNo);

        #endregion

        #region Events 

        private void Form_Load(object sender, EventArgs e)
        {
            StartDownloading();
        }

        private void Form_Closing(object sender, FormClosingEventArgs args)
        {
            args.Cancel = !UpdateClient.IsIdle;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckStatus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (job != null)
            {
                job.Cancel();
                UpdateClient.IsIdle = true;
                this.Close();
            }
        }

        #endregion

        #region UpdateJobEvents 

        private void UpdateJobEvents_JobError(object sender, UpdateJobErrorEventArgs e)
        {
            MessageForm.Show(this, e.GetErrorDescription(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void UpdateJobEvents_JobModification(object sender, UpdateJobEventArgs e)
        {

        }

        private void UpdateJobEvents_JobTransferred(object sender, UpdateJobEventArgs e)
        {
            if (job.State == UpdateJobState.Transferred)
            {
                job.Complete();
                UpdateClient.IsIdle = true;                
                DownloadItem();
            }
        }
        
        #endregion

        #region Helper Methods

        private void StartDownloading()
        {
            this.txtCurrentVersionNo.Text = this.currentVersionNo;
            totalItems = kv.DataTable.Select(Kv.KeyName + " like 'PatchFile%'").Length;
            lblTotalItems.Text = "of " + totalItems;
            pbItems.Maximum = totalItems;

            DownloadItem();
        }

        private void DownloadItem()
        {
            currentPatchNo++;
            string fileUrl = kv.Get("PatchFile" + currentPatchNo);
            if (string.IsNullOrEmpty(fileUrl))
            {
                SetProgressBar(pbItems, totalItems, currentPatchNo - 1);
                DownloadingCompleted();
            }
            else
            {
                SetLabelText(lblCurrentItem, currentPatchNo.ToString());
                SetProgressBar(pbItems, totalItems, currentPatchNo - 1);

                fileUrl = patchPath + "/" + fileUrl;
                DownloadItem(fileUrl);
            }
        }

        private void DownloadItem(string fileUrl)
        {
            SetProgressBar(pbDownloadItem, 100, 0); // reset progress bar to initial value.

            updateClient.InitializeJob();
            updateClient.StartJob(fileUrl);
        }

        private void InitializeJob()
        {
            manager = new UpdateManager();
            UpdateJobs jobs = manager.GetJobs();

            foreach (UpdateJob job in jobs)
            {
                if (job.DisplayName == JOB_NAME)
                {
                    job.Cancel();
                }
            }

            jobEvents = new UpdateJobEventer();
            jobEvents.OnJobError += new EventHandler<UpdateJobErrorEventArgs>(this.UpdateJobEvents_JobError);
            //jobEvents.OnJobModification += new EventHandler<UpdateJobEventArgs>(this.UpdateJobEvents_JobModification);
            jobEvents.OnJobTransferred += new EventHandler<UpdateJobEventArgs>(this.UpdateJobEvents_JobTransferred);
        }

        private void StartJob(string fileUrl)
        {
            this.txtCurrentVersionNo.Text = this.currentVersionNo;
            job = manager.CreateJob(JOB_NAME, JOB_DESC, 0, 0);
            //job.AddFile(Ap.FilePatch, this.patchUrl);
            string localPath = Ap.FolderPatches + System.IO.Path.GetFileName(fileUrl);
            job.AddFile(localPath, fileUrl);
            job.Priority = UpdateJobPriority.Foreground;
            job.Resume();
            jobEvents.AddJob(job);
            timer1.Interval = 3000;
            timer1.Start(); 
        }

        private void CheckStatus()
        {
            UpdateJobProgress progress = job.Progress;
            int maximum = (int) progress.BytesTotal;
            int transferred = (int)progress.BytesTransferred;
            if (maximum < 0)
                return;
            //if (pbDownloadItem.Maximum == 100)
            //    pbDownloadItem.Maximum = maximum;
            //if (transferred < pbDownloadItem.Maximum)
            //    pbDownloadItem.Value = transferred;
            SetProgressBar(pbDownloadItem, maximum, transferred);
        }

        private void DownloadingCompleted()
        {
            Application.ApplicationExit += UpdateClient.ApplicationExit;
            MessageForm.Show(this, MsgE.InfoUpgradeDownloaded);
            CloseForm(this);
        }

        #region Thread-safe Methods 

        private void SetLabelText(Label lbl, string text)
        {
            if (lbl.InvokeRequired)
            {
                lbl.BeginInvoke(new MethodInvoker(delegate() { SetLabelText(lbl, text); }));
            }
            else
            {
                lbl.Text = text;
            }
        }

        private void SetProgressBar(ProgressBar pb, int max, int value)
        {
            if (pb.InvokeRequired)
            {
                pb.BeginInvoke(new MethodInvoker(delegate() { SetProgressBar(pb, max, value); }));
            }
            else
            {
                if (pb.Maximum == 100)
                    pb.Maximum = max;
                if (value <= pb.Maximum)
                    pb.Value = value;
            }
        }

        private void CloseForm(Form frm)
        {
            if (frm.InvokeRequired)
            {
                frm.BeginInvoke(new MethodInvoker(delegate() { CloseForm(frm); }));
            }
            else
            {
                frm.Close();
            }
        }

        #endregion

        #endregion

        #region Static Methods 

        public static void BeginUpdate(Kv kv, String patchUrl, String currentVersionNo)
        {
            if (updateClient != null)
                updateClient.Dispose();

            IsIdle = false;
            updateClient = new UpdateClient(kv, patchUrl, currentVersionNo);
            updateClient.Show();
        }

        public static void BeginUpdate(String patchUrl, String currentVersionNo)
        {
            IsIdle = false;

            if (updateClient != null)
                updateClient.Dispose();

            IsIdle = false;
            updateClient = new UpdateClient(patchUrl, currentVersionNo);
            updateClient.Show();
            updateClient.InitializeJob();
            updateClient.StartJob(patchUrl);
        }

        public static void ApplicationExit(object sender, EventArgs args)
        {
            StartProcess();
        }

        private static void StartProcess()
        {
            var startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = Ap.FileUpdateManager;
            startInfo.WorkingDirectory = Ap.FolderUpdaterBin;
            startInfo.UseShellExecute = true;
            System.Diagnostics.Process.Start(startInfo);
        } 

        #endregion

    }
}
