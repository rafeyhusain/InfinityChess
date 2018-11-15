using System; using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace InfinityChess.GameData
{
    public partial class frmTournamentData : Form
    {
        public App.Model.GameData GameData = null;

        public frmTournamentData()
        {          
            InitializeComponent();
        }

        private void frmTournamentData_Load(object sender, EventArgs e)
        {
            LoadCombos();
            LoadTournament();
        }

        private void LoadCombos()
        {
            Kv kv1 = new Kv(KvType.Country);

            cmbNotation.DataSource = kv1.DataTable;
            cmbNotation.DisplayMember = "k";
            cmbNotation.ValueMember = "k";

            Kv kv2 = new Kv(KvType.TournamentType);

            cmbType.DataSource = kv2.DataTable;
            cmbType.DisplayMember = "k";
            cmbType.ValueMember = "k";
        }

        private void LoadTournament()
        {            
            txtPlace.Text = GameData.PlayerDetailPlace;
            chkYear.Checked = GameData.PlayerDetailIsYear;
            numYear.Value = GameData.PlayerDetailYear;
            chkMonth.Checked = GameData.PlayerDetailIsMonth;
            numMonth.Value = GameData.PlayerDetailMonth;
            chkDay.Checked = GameData.PlayerDetailIsDay;
            numDay.Value = GameData.PlayerDetailDay;
            chkNotation.Checked = GameData.PlayerDetailIsNotation;
            cmbNotation.SelectedValue = GameData.PlayerDetailNotation;
            chkRounds.Checked = GameData.PlayerDetailIsRound;
            numRounds.Value = GameData.PlayerDetailRound;
            chkCategory.Checked = GameData.PlayerDetailIsCategory;
            numCategory.Value = GameData.PlayerDetailCategory;
            chkType.Checked = GameData.PlayerDetailIsType;
            cmbType.SelectedValue = GameData.PlayerDetailType;
            chkComplete.Checked = GameData.PlayerDetailIsCompleted;
            chkBoardPoints.Checked = GameData.PlayerDetailIsBoardPoint;

            rdbBlitz.Checked = GameData.PlayerDetailTime == "Blitz";
            rdbRapid.Checked = GameData.PlayerDetailTime == "Rapid";
            rdbNormal.Checked = GameData.PlayerDetailTime == "Normal";
            rdbCorrespChe.Checked = GameData.PlayerDetailTime == "Corresp. Che:";

            // update title text as supplied from parent form.
            txtTitle.Text = GameData.Tournament;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool Save()
        {
            if (cmbNotation.SelectedValue == null)
            {
                MessageForm.Show(this,MsgE.InfoSelectNotation);
                return false;
            }

            GameData.PlayerDetailPlace = txtPlace.Text;
            GameData.PlayerDetailIsYear = chkYear.Checked;
            GameData.PlayerDetailYear = numYear.Value;
            GameData.PlayerDetailIsMonth = chkMonth.Checked;
            GameData.PlayerDetailMonth = numMonth.Value;
            GameData.PlayerDetailIsDay = chkDay.Checked;
            GameData.PlayerDetailDay = numDay.Value;
            GameData.PlayerDetailIsNotation = chkNotation.Checked;
            GameData.PlayerDetailNotation = cmbNotation.SelectedValue.ToString();
            GameData.PlayerDetailIsRound = chkRounds.Checked;
            GameData.PlayerDetailRound = numRounds.Value;
            GameData.PlayerDetailIsCategory = chkCategory.Checked;
            GameData.PlayerDetailCategory = numCategory.Value;
            GameData.PlayerDetailIsType = chkType.Checked;
            GameData.PlayerDetailType = cmbType.SelectedValue.ToString();
            GameData.PlayerDetailIsCompleted = chkComplete.Checked;
            GameData.PlayerDetailIsBoardPoint = chkBoardPoints.Checked;

            if (rdbBlitz.Checked)
                GameData.PlayerDetailTime = "Blitz";
            if (rdbRapid.Checked)
                GameData.PlayerDetailTime = "Rapid";
            if (rdbNormal.Checked)
                GameData.PlayerDetailTime = "Normal";
            if (rdbCorrespChe.Checked)
                GameData.PlayerDetailTime = "Corresp. Che:";

            GameData.Tournament = txtTitle.Text;

            return true;
        }
               
        private void btnHelp_Click(object sender, EventArgs e)
        {
            InfinityChesshelp.InfinityChessHelp.OpenHelpFile();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}