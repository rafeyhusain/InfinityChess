using System; using App.Model;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace App.Win
{
    public partial class Tournament : BaseWinForm
    {
        #region DataMembers 

        public Game Game = null;
        public InfinityChess.TournamentManager.Tournament TournamentInfo;
        public static string _result;        

        #endregion

        #region Ctor
                
        public Tournament(Game game)
        {
            this.Game = game;
            InitializeComponent();
            TournamentInfo = new InfinityChess.TournamentManager.Tournament(this.Game);
        }

        #endregion

        #region Helpers
        private void LoadTournament()
        {
            TournamentInfo.Load();

            if (TournamentInfo.Title == "")
            {
                TournamentInfo.Title = TournamentInfo.FileName;
            }

            if (TournamentInfo.TournamentGuid == "")
            {
                TournamentInfo.TournamentGuid = Guid.NewGuid().ToString ();  
            }
            
            this.txtTitle.Text = TournamentInfo.Title;
            this.SetTimeControl(TournamentInfo.TimeControl);
            this.SetTournamentType(TournamentInfo.TournamentType);
            if (TournamentInfo.Cycles == 0)
            {
                this.txtCycles.Value = 1;
            }
            else
            {
                this.txtCycles.Value = TournamentInfo.Cycles;
            }

            if (TournamentInfo.MoveLimit == 0)
            {
                this.txtMoveLimit.Value  = 600;
            }
            else
            {
                this.txtMoveLimit.Value = TournamentInfo.MoveLimit;  
            }
            


            int count = TournamentInfo.DataSet.TournamentParticipants.Rows.Count;
            if (count  > 1)
            {
                btnRunContinue.Enabled = true;
                lblNoOfMatches.Text = (TournamentInfo.GetNoOfMatches(count)*txtCycles.Value).ToString() + " " + "Games";
            }
            foreach (DataRow row in TournamentInfo.DataSet.TournamentParticipants.Rows)
            {
                lstParticipent.Items.Add(row["Name"]);
                TournamentInfo.ParticipitantList.Add(row["Name"]);

                if (row["IsEngine"].ToString() == "False" && count > 1)
                {
                    btnNextHumanGame.Enabled = true;
                }
            }

           

        }

        private void SaveTournament()
        {
            
            TournamentInfo.Title = this.txtTitle.Text;
            TournamentInfo.TimeControl = this.GetTimeControl();
            TournamentInfo.TournamentType = this.GetTournamentType();
            TournamentInfo.Cycles = this.txtCycles.Value;
            TournamentInfo.MoveLimit = this.txtMoveLimit.Value;
             
            TournamentInfo.SaveTournomrntMatches(lstParticipent);
            TournamentInfo.Save();


        }

        private int GetTournamentType()
        {
            if (chkRoundRobin.Checked)
                return 0;
            else if (chkRunGauntLet.Checked)
                return 1;
            else if (chkKnockout.Checked)
                return 2;
            else if (chkSwiss.Checked)
                return 3;
            else
                return -1;
        }

        private void SetTournamentType(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    chkRoundRobin.Checked = true;
                    break;

                case 1:
                    chkRunGauntLet.Checked = true;
                    break;

                case 2:
                    chkKnockout.Checked = true;
                    break;

                case 3:
                    chkSwiss.Checked = true;
                    break;

            }
        }

        private int GetTimeControl()
        {
            if (chkBlitzGame.Checked)
                return 0;
            else if (chkLongGame.Checked)
                return 1;
            else
                return -1;
        }

        private void SetTimeControl(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    chkBlitzGame.Checked = true;
                    break;

                case 1:
                    chkLongGame.Checked = true;
                    break;
            }
        }

        private void InviteHuman()
        {

            if (lstParticipent.Items.IndexOf("Human") == -1)
            {
                TournamentInfo.AddParticipitant("Human", false);
                lstParticipent.Items.Add("Human");

                if (lstParticipent.Items.Count > 1)
                {
                    btnRunContinue.Enabled = true;
                    btnNextHumanGame.Enabled = true;
                }

            }

           
            lblNoOfMatches.Text = (TournamentInfo.GetNoOfMatches(lstParticipent.Items.Count)* txtCycles .Value  ).ToString() + " " + "Games";

        }

        private void DeleteParticipant()
        {
            if (lstParticipent.SelectedItem == null)
            {
                return;
            }
            bool isEngine = true;
            if ("Human" == lstParticipent.SelectedItem.ToString())
            {
                btnNextHumanGame.Enabled = false;
            }

            TournamentInfo.DeleteParticipitant(lstParticipent.SelectedItem.ToString(), isEngine);
            TournamentInfo.ParticipitantList.Remove(lstParticipent.SelectedItem);
            lstParticipent.Items.Remove(lstParticipent.SelectedItem);

            if (lstParticipent.Items.Count < 2)
            {

                btnRunContinue.Enabled = false;
                btnNextHumanGame.Enabled = false; 
            }

        }
        #endregion       





        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // Numeric dropdown cycles
            decimal count = TournamentInfo.GetNoOfMatches(lstParticipent.Items.Count);

            lblNoOfMatches.Text = (txtCycles.Value * count).ToString() + " " + "Games";

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInviteEngine_Click(object sender, EventArgs e)
        {
            InviteEngine frm = new InviteEngine(true, this.Game);

            frm.TournamentInfo = this.TournamentInfo;

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                string p = frm.SelectedEngine.EngineName.Replace(".exe", "");

                TournamentInfo.AddParticipitant(p, true);
                lstParticipent.Items.Add(p);
                lblNoOfMatches.Text = (TournamentInfo.GetNoOfMatches(lstParticipent.Items.Count) * txtCycles.Value).ToString() + " " + "Games";
                TournamentInfo.ParticipitantList.Add(p);

                if (lstParticipent.Items.Contains("Human"))
                {
                    btnNextHumanGame.Enabled = true;
                }
                
                if (lstParticipent.Items.Count > 1)
                {
                    btnRunContinue.Enabled = true;
                }

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void Tournament_Load(object sender, EventArgs e)
        {
            LoadTournament();
        }

        private void btnInviteHuman_Click(object sender, EventArgs e)
        {
            InviteHuman();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteParticipant();
            lblNoOfMatches.Text = (TournamentInfo.GetNoOfMatches(lstParticipent.Items.Count) * txtCycles.Value).ToString() + " " + "Games";

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstParticipent.SelectedItem != null && lstParticipent.SelectedItem.ToString ()  != "Human")
            {
                InviteEngine frm = new InviteEngine(true, this.Game);
                frm.TournamentInfo = this.TournamentInfo;

                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    string strSelected = lstParticipent.SelectedItem.ToString ();
                    int Index = lstParticipent.SelectedIndex;
 
                    string p = frm.SelectedEngine.EngineName.Replace(".exe", "");

                    TournamentInfo.UpdateParticipitant(strSelected,p);
                    TournamentInfo.ParticipitantList.Remove(strSelected);
                    lstParticipent.Items.Remove(strSelected);  

                    lstParticipent.Items.Insert(Index, p);
                    TournamentInfo.ParticipitantList.Insert(Index, p);  

                }
            }
        }

        private void checkBlitzGame_Click(object sender, EventArgs e)
        {
            App.Win.BlitzClockForm frm = new App.Win.BlitzClockForm(this.Game);

            frm.TournamentInfo = this.TournamentInfo;

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                frm.Get(this.TournamentInfo);
            }
        }

        private void chkLongGame_Click(object sender, EventArgs e)
        {
            App.Win.LongClockForm frm = new App.Win.LongClockForm(this.Game);

            frm.TournamentInfo = this.TournamentInfo;

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                frm.Get(this.TournamentInfo);
            }
        }
        
        //Code by Ubaid
        private void btnRunContinue_Click(object sender, EventArgs e)
        {
            SaveTournament();
            TournamentInfo.RunNextMatch();
            this.Close();
        }

        private void btnNextHumanGame_Click(object sender, EventArgs e)
        {
            SaveTournament();
            TournamentInfo.RunNextHumanMatch(); 
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            SaveTournament();
            this.Close();
        }
        public override string HelpTopicId
        {
            get { return "140"; }
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            Ap.Help(this, HelpTopicIdE.Tournament);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            TournamentInfo.GetNoOfMatches(lstParticipent);

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }
    }
}
