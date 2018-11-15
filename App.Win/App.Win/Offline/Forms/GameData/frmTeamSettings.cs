using System; using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using App.Model;

namespace InfinityChess.GameData
{
    public partial class frmTeamSettings : Form
    {
        public App.Model.GameData GameData = null;
        public GameTeam GameTeam;

        public frmTeamSettings()
        {
            InitializeComponent();
        }

        private void frmTeamSettings_Load(object sender, EventArgs e)
        {
            LoadCombos();
            LoadSettings();
        }

        private void LoadCombos()
        {
            Kv kv = new Kv(KvType.Country);

            cmbNotation.DataSource = kv.DataTable;
            cmbNotation.DisplayMember = "k";
            cmbNotation.ValueMember = "k";
        }

        private void LoadSettings()
        {
            switch (GameTeam)
            {
                case GameTeam.Black:
                    txtName.Text = GameData.BlackTeam;
                    numTeamNumber.Value = GameData.BlackDetailTeamNumber;
                    numYear.Value = GameData.BlackDetailYear;
                    chkSeason.Checked = GameData.BlackDetailSeason;
                    chkNotation.Checked = GameData.BlackDetailIsNotation;
                    cmbNotation.SelectedValue = GameData.BlackDetailNotation;
                    break;

                case GameTeam.White:
                    txtName.Text = GameData.WhiteTeam;
                    numTeamNumber.Value = GameData.WhiteDetailTeamNumber;
                    numYear.Value = GameData.WhiteDetailYear;
                    chkSeason.Checked = GameData.WhiteDetailSeason;
                    chkNotation.Checked = GameData.WhiteDetailIsNotation;
                    cmbNotation.SelectedValue = GameData.WhiteDetailNotation;
                    break;
            }
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

            switch (GameTeam)
            {
                case GameTeam.Black:                    
                    GameData.BlackDetailTeamNumber = numTeamNumber.Value;
                    GameData.BlackDetailYear = numYear.Value;
                    GameData.BlackDetailSeason = chkSeason.Checked;
                    GameData.BlackDetailIsNotation = chkNotation.Checked;
                    GameData.BlackDetailNotation = cmbNotation.SelectedValue.ToString();
                    GameData.BlackTeam = txtName.Text;
                    break;

                case GameTeam.White:                    
                    GameData.WhiteDetailTeamNumber = numTeamNumber.Value;
                    GameData.WhiteDetailYear = numYear.Value;
                    GameData.WhiteDetailSeason = chkSeason.Checked;
                    GameData.WhiteDetailIsNotation = chkNotation.Checked;
                    GameData.WhiteDetailNotation = cmbNotation.SelectedValue.ToString();
                    GameData.WhiteTeam = txtName.Text;
                    break;
            }

            return true;
        }     

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}