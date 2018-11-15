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
    public partial class TeamDetail : Form
    {
        public int TeamID = 0;
        private Team team = null;
        public TeamDetail()
        {
            InitializeComponent();
        }
        public Team Team
        {
            //[System.Diagnostics.DebuggerStepThrough]
            get
            {
                if (team == null)
                {
                    try
                    {
                        ProgressForm frm = ProgressForm.Show(this, "Loading Team...");

                        team = SocketClient.GetTeamByID(TeamID);

                        frm.Close();
                    }
                    catch (Exception ex)
                    {
                        TestDebugger.Instance.WriteError(ex);
                        MessageForm.Show(ex);
                    }
                    //if (table.Rows.Count > 0)
                    //{
                    //    team = new Team(Ap.Cxt, table.Rows[0]);
                    //}
                }

                return team;
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                team = value;
            }
        }
        private void TeamDetail_Load(object sender, EventArgs e)
        {
            LoadTeam();
        }

        public void LoadTeam()
        {
            if (Team == null)
            {
                return ;
            }

            teamDetailUc1.TeamName = this.Team.TeamName;
            teamDetailUc1.TeamDescription = this.Team.Description;

            if (this.Team.TeamID == 0)
            {
                this.Text = "New Team";
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (teamDetailUc1.TeamName == string.Empty)
            {
                MessageForm.Show(this.ParentForm, MsgE.ErrorEmptyTeamTitle);
            }
            else
            {
                if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmItemTask, "save", "team") == DialogResult.Yes)
                {
                    SaveTeam();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

            }
        }
        public void SaveTeam()
        {
            try
            {
                SocketClient.SaveTeam(teamDetailUc1.TeamName, teamDetailUc1.TeamDescription, TeamID);
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Ap.Help(this, HelpTopicIdE.TeamDetail);
        }
        public static DialogResult Show(Form owner, int teamID)
        {
            return Show(owner, teamID, null);
        }

        public static DialogResult Show(Form owner, int teamID, Team team)
        {
            TeamDetail frm = new TeamDetail();
            frm.TeamID = teamID;
            frm.Team = team;
            DialogResult result = frm.ShowDialog(owner);

            return result;
        }

        private void teamDetailUc1_Load(object sender, EventArgs e)
        {

        }

        private void pnlBottom_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
