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
    public partial class frmSource : Form
    {
        public App.Model.GameData GameData = null;

        public frmSource()
        {
            InitializeComponent();
        }

        private void frmSource_Load(object sender, EventArgs e)
        {
            LoadSource();
        }

        private void LoadSource()
        {
            txtTitle.Text = GameData.Source;
            txtPublisher.Text = GameData.SourceDetailPublisher;

            if (!string.IsNullOrEmpty(GameData.SourceDetailPublication))
                dtpPublication.Value = App.Model.UData.GetChessDate(GameData.SourceDetailPublication);

            if (!string.IsNullOrEmpty(GameData.SourceDetailDate))
                dtpDate.Value = App.Model.UData.GetChessDate(GameData.SourceDetailDate);
            
            numVersion.Value = GameData.SourceDetailVersion;

            rdbHigh.Checked = GameData.SourceDetailQuality == "High";
            rdbNormal.Checked = GameData.SourceDetailQuality == "Normal";
            rdbLow.Checked = GameData.SourceDetailQuality == "Low";
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
            GameData.Source = txtTitle.Text;
            GameData.SourceDetailPublisher = txtPublisher.Text;
            GameData.SourceDetailPublication = dtpPublication.Value.ToShortDateString();
            GameData.SourceDetailDate = dtpDate.Value.ToShortDateString();
            GameData.SourceDetailVersion = numVersion.Value;

            if (rdbHigh.Checked)
                GameData.SourceDetailQuality = "High";
            if (rdbNormal.Checked)
                GameData.SourceDetailQuality = "Normal";
            if (rdbLow.Checked)
                GameData.SourceDetailQuality = "Low";

            return true;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            InfinityChesshelp.InfinityChessHelp.OpenWordDocument();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}