using System; using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using InfinitySettings.GameManager;

namespace App.Win
{
    public partial class UserInfo : BaseWinForm
    {
        public UserInfo()
        {
            InitializeComponent();
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            LoadProfile();
        }

        private void LoadProfile()
        {
            UserProfile userProfile = Ap.UserProfile;
            if (userProfile != null)
            {
                
                txtLastName.Text = userProfile.LastName;
                txtFirstName.Text = userProfile.FirstName;
                txtTown.Text = userProfile.Town;
                txtComputer.Text = userProfile.Computer;

                this.picProfile.Image = global::InfinityChess.Properties.Resources.userProfile;

                switch (userProfile.PlayerStatus)
                {
                    case UserProfile.PlayerStatusValues.Beginner:
                        {
                            rdbBeginner.Checked = true;
                            break;
                        }
                    case UserProfile.PlayerStatusValues.HobbyPlayer:
                        {
                            rdbHobbyPlayer.Checked = true;
                            break;
                        }
                    case UserProfile.PlayerStatusValues.ClubPlayer:
                        {
                            rdbClubPlayer.Checked = true;
                            break;
                        }
                    default:
                        break;
                }

                switch (userProfile.Title)
                {
                    case UserProfile.PlayerTitle.Mr:
                        {
                            rdbMr.Checked = true;
                            break;
                        }
                    case UserProfile.PlayerTitle.Ms:
                        {
                            rdbMs.Checked = true;
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveProfile();
        }

        private void SaveProfile()
        {
            UserProfile userProfile = new UserProfile();

         
            userProfile.LastName = txtLastName.Text ;
            userProfile.FirstName = txtFirstName.Text ;
            userProfile.Town = txtTown.Text ;
            userProfile.Computer = txtComputer.Text ;

            if (rdbBeginner.Checked)
                userProfile.PlayerStatus = UserProfile.PlayerStatusValues.Beginner;
            else if (rdbHobbyPlayer.Checked)
                userProfile.PlayerStatus = UserProfile.PlayerStatusValues.HobbyPlayer;
            else if (rdbClubPlayer.Checked)
                userProfile.PlayerStatus = UserProfile.PlayerStatusValues.ClubPlayer;

            if (rdbMr.Checked)
                userProfile.Title = UserProfile.PlayerTitle.Mr;
            else if (rdbMs.Checked)
                userProfile.Title = UserProfile.PlayerTitle.Ms;            
            
            userProfile.SaveProfile();
            Ap.UserProfile = userProfile;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCredits_Click(object sender, EventArgs e)
        {
            AboutInfinityChess frm = new AboutInfinityChess();
            frm.ShowDialog();
        }

        public override string HelpTopicId
        {
            get { return "150"; }
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            Ap.Help(this, HelpTopicIdE.UserInfo);
        }
    }
}