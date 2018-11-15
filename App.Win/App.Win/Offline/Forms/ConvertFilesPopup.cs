using System;
using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using InfinitySettings.GameManager;
using System.IO;

namespace App.Win
{
    public partial class ConvertFilesPopup : BaseWinForm
    {
        #region DataMember
        public Game Game = null;
        GameSearchProgress progressForm;
        public int totalGamesCount = 0;
        PgnManager pgn;
        IcdManager Icd;
        public BackgroundWorker backgroundWorker;
        public bool isPgnToIcbConversion = false;
        private bool isTotalGameCountSet = false;
        string fileName;
        #endregion

        public ConvertFilesPopup(Game game)
        {
            this.Game = game;
            InitializeComponent();
        }

        private void ConvertFilesPopup_Load(object sender, EventArgs e)
        {
            //txtFile.Text = @"E:\Idrees\PgnTest\1.pgn";            
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Database Files(*.pgn;*.icd)|*.pgn;*.icd";
            openFileDialog1.FileName = "filename";
            openFileDialog1.InitialDirectory = Ap.FolderBooks;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = openFileDialog1.FileName;
            }
        }

        public override string HelpTopicId
        {
            get { return "30"; }
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            Ap.Help(this, HelpTopicIdE.ConvertFilesPopup);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region File Conversion
        private void convertPGNToInfinityChessDatabaseicdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pgn = new PgnManager(this.Game);
            pgn.OnProgressBarInitialized += new PgnManager.ProgressBarInitHandler(pgn_OnProgressBarInitialized);
            pgn.OnProgressChanged += new PgnManager.ProgressChangedEventHandler(pgn_OnProgressChanged);
            pgn.OnProgressWorkCompleted += new PgnManager.ProgressWorkCompletedHandler(pgn_OnProgressWorkCompleted);
            fileName = txtFile.Text;
            if (isPgnToIcbConversion)
            {
                pgn.isPgnToIcbConversion = true;
                UFile.Delete(fileName.Replace(".pgn", ".icb"));
            }
            else
            {
                UFile.Delete(fileName.Replace(".pgn", ".icd"));
            }
            pgn.ConvertPgnToIcd(fileName);
            isPgnToIcbConversion = false;
        }

        private void convertPGNToInfinityChessBookicbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isPgnToIcbConversion = true;
            convertPGNToInfinityChessDatabaseicdToolStripMenuItem_Click(sender, e);
        }

        private void convertInfinityChessDatabaseicdToPGNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileName = txtFile.Text;
            if (fileName.EndsWith(Files.DatabaseExtension))
            {
                Icd = new IcdManager(this.Game);
                Icd.OnProgressBarInitialized += new IcdManager.ProgressBarInitHandler(Icd_OnProgressBarInitialized);
                Icd.OnProgressChanged += new IcdManager.ProgressChangedEventHandler(Icd_OnProgressChanged);
                Icd.OnProgressWorkCompleted += new IcdManager.ProgressWorkCompletedHandler(Icd_OnProgressWorkCompleted);
                UFile.Delete(fileName.Replace(".icd", ".pgn"));
                Icd.ConvertIcdToPgn(fileName);
            }
            else
            {
                MessageForm.Error(Msg.GetMsg(MsgE.ErrorInvalidFileFormat));
                return;
            }
        }
        #endregion

        #region IcdManagerProgressBar
        void Icd_OnProgressBarInitialized(object sender, ProgressBarEventArgs e)
        {
            totalGamesCount = e.TotalGames;
        }
        void Icd_OnProgressWorkCompleted(object sender, ProgressWorkCompletedEventArgs e)
        {
            if (progressForm != null)
            {
                progressForm.Timer.Stop();
                if (e.arguments.Cancelled)
                {
                    MessageForm.Show(this,MsgE.ConversionCancelled);
                }
                if (!e.arguments.Cancelled)
                {
                    MessageForm.Show(this, MsgE.ConversionCompleted);
                    progressForm.OnWorkCancelled -= new GameSearchProgress.WorkCancelledHandler(IcdProgressForm_OnWorkCancelled);
                }
                using (StreamWriter outfile =
             new StreamWriter(fileName.Replace(".icd", ".pgn")))
                {
                    outfile.Write(e.data);
                }
                progressForm.Close();
                progressForm = null;
            }
        }
        void Icd_OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (progressForm != null)
            {
                progressForm.ProgressBar.Show();
                progressForm.ProgressBar.Refresh();
                progressForm.ProgressBar.Value = e.ProgressPercentage;
                progressForm.GameNo.Text = "Game " + e.ProgressPercentage.ToString() + " of " + totalGamesCount.ToString();
                string percentage = Math.Round((((double)e.ProgressPercentage / totalGamesCount) * 100)).ToString();
                progressForm.Percentage.Text = percentage + "%";
            }
            else
            {
                progressForm = new GameSearchProgress();
                progressForm.Text = "File Conversion";
                progressForm.OnWorkCancelled += new GameSearchProgress.WorkCancelledHandler(IcdProgressForm_OnWorkCancelled);
                progressForm.ProgressBar.Maximum = totalGamesCount;
                progressForm.Show();

            }
        }
        void IcdProgressForm_OnWorkCancelled(object sender, EventArgs args)
        {
            if (Icd != null)
            {
                DialogResult dr = MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, "cancel", "conversion");
                if (dr == DialogResult.Yes)
                {
                    progressForm.OnWorkCancelled -= new GameSearchProgress.WorkCancelledHandler(IcdProgressForm_OnWorkCancelled);
                    Icd.CancelIcdToPgnConversion();
                }
                else
                {
                    return;
                }
            }
        }
        #endregion

        #region PGNManagerProgressBar
        void pgn_OnProgressWorkCompleted(object sender, ProgressWorkCompletedEventArgs e)
        {

            if (progressForm != null)
            {
                progressForm.Timer.Stop();
                if (e.arguments.Cancelled)
                {
                    MessageForm.Show(this,MsgE.ConversionCancelled);
                }
                if (!e.arguments.Cancelled)
                {
                    MessageForm.Show(this,MsgE.ConversionCompleted);
                    progressForm.OnWorkCancelled -= new GameSearchProgress.WorkCancelledHandler(pgnProgressForm_OnWorkCancelled);
                }
                progressForm.Close();
                progressForm = null;
            }

        }
        void pgn_OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            if (progressForm != null)
            {
                if (!isTotalGameCountSet)
                {
                    progressForm.ProgressBar.Maximum = totalGamesCount;
                    isTotalGameCountSet = true;
                }
                progressForm.ProgressBar.Show();
                progressForm.ProgressBar.Refresh();
                progressForm.ProgressBar.Value = e.ProgressPercentage;
                progressForm.GameNo.Text = "Game " + e.ProgressPercentage.ToString() + " of " + totalGamesCount.ToString();
                string percentage = Math.Round((((double)e.ProgressPercentage / totalGamesCount) * 100)).ToString();
                progressForm.Percentage.Text = percentage + "%";

            }
            else
            {
                progressForm = new GameSearchProgress();
                progressForm.Text = "File Conversion";
                progressForm.OnWorkCancelled += new GameSearchProgress.WorkCancelledHandler(pgnProgressForm_OnWorkCancelled);
                progressForm.TimeConsumed.Text = "Estimating Game Count....";
                progressForm.Show();
            }
        }
        void pgn_OnProgressBarInitialized(object sender, ProgressBarEventArgs e)
        {
            totalGamesCount = e.TotalGames;
        }
        void pgnProgressForm_OnWorkCancelled(object sender, EventArgs args)
        {
            if (pgn != null)
            {
                DialogResult dr = MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, "cancel", "conversion");
                if (dr == DialogResult.Yes)
                {

                    progressForm.OnWorkCancelled -= new GameSearchProgress.WorkCancelledHandler(pgnProgressForm_OnWorkCancelled);
                    pgn.CancelPgnToIcdConversion();
                }
                else
                {
                    return;
                }
            }
        }
        #endregion
       
    }
}