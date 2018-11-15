using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model.Db;
using App.Model;

namespace App.Win
{
    public partial class MatchesUc : UserControl
    {
        public MatchesUc()
        {
            InitializeComponent();
        }

        private void MatchesUc_Load(object sender, EventArgs e)
        {
          
        }

        public void LoadDataGrid(int tournamentId)
        {
            DataSet ds= SocketClient.GetTournamentMatchs(tournamentId);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgvMatches.DataSource = ds.Tables[0];
                }
                else
                {
                    dgvMatches.DataSource = null;
                }
            }
        }
    }
}
