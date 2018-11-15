using System; using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using App.Win;
using InfinityChess.Offline.Forms;
using InfinityChess.WinForms;

namespace InfinityChess.Winforms
{
    public partial class Startup : Form
    {
        #region DataMembers 

        ProgressForm frmProgress;
        MainForm mainForm;

        #endregion

        #region Ctor 

        public Startup()
        {
            InitializeComponent();
        }

        #endregion

        #region Form Events 
                
        private void Startup_Load(object sender, EventArgs e)
        {
            ApWin.StartupForm = this;
            lblVersion.Text = Config.Version;
        }

        private void Startup_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        #endregion

        #region Events 

        private void button3_Click(object sender, EventArgs e)
        {
            MessageForm.Show(this,MsgE.InfoCommingShortly);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string processName = "slow296.exe";
            Process[] processes = Process.GetProcessesByName(processName);

            foreach (Process process in processes)
            {
                process.Kill();
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {   
            LoginForm objLoginForm = new LoginForm();
            objLoginForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetInvisible();            

            InfinityChess.WinForms.MainOffline frm = new InfinityChess.WinForms.MainOffline();

            frm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadMainForm();            
        }

        private void pbQuit_Click(object sender, EventArgs e)
        {
            string processName = "InfinityChess.exe";
            Process[] processes = Process.GetProcessesByName(processName);

            foreach (Process process in processes)
            {
                process.Kill();
            }

            this.Close();
        }

        private void pbInfinityChess_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog(this);
        }

        private void pbHelp_Click(object sender, EventArgs e)
        {
            InfinityChesshelp.InfinityChessHelp.OpenHelpFile();
        }

        #endregion

        #region Helper Methods 
        
        private void SetInvisible()
        {
            this.Visible = false;
        }

        public void SetVisible()
        {
            this.Visible = true;
        }

        private void LoadMainForm()
        {
            SetInvisible();

            frmProgress = ProgressForm.Show(this, "Loading...", 2000);
            frmProgress.FormClosed += new FormClosedEventHandler(frmProgress_FormClosed);
            Application.DoEvents();

            Ap.NewGame();
            mainForm = new InfinityChess.WinForms.MainOffline();
            mainForm.Show();
        }

        public void checkUserProfile()
        {
            if (ApWin.ShowUserProfile == true)
            {
                InfinitySettings.GameManager.UserProfile _userProfile = new InfinitySettings.GameManager.UserProfile();
                _userProfile.LoadUserProfile();
                if (_userProfile.SkipOnProgramStart == false)
                {
                    UserInfo objUserInfo = new UserInfo();
                    objUserInfo.ShowDialog();
                }
                ApWin.ShowUserProfile = false;
            }
        }

        #endregion

        #region ProgressForm Events 

        void frmProgress_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mainForm == null)
            {
                return;
            }

            if (mainForm.IsDisposed)
            {
                return;
            }

            mainForm.WindowState = FormWindowState.Maximized;
            mainForm.ShowInTaskbar = true;
            frmProgress = null;
        }


        #endregion
        
    }
}