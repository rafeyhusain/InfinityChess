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
    public partial class TournamentUc : UserControl
    {
        public TournamentUc()
        {
            InitializeComponent();
        }

        
        private void TournamentUc_Load(object sender, EventArgs e)
        {


            FillCmbs();

        }

        private void FillCmbs()
        {
            DataSet ds= SocketClient.GetTournamentCmbData();

            if (ds.Tables.Count > 0)
            {
                cmbType.DataSource = ds.Tables[0];
                cmbType.DisplayMember = "Name";
                cmbType.ValueMember = "TournamentTypeId";

                cmbChessType.DataSource = ds.Tables[1];
                cmbChessType.DisplayMember = "Name";
                cmbChessType.ValueMember = "ChessTypeId";
            }

            FillNumbers();
            FillMin();
        }

        private void SaveTournament()
        {
           App.Model.Db.Tournament t = new App.Model.Db.Tournament();

           t.TournamentTypeID  =(int) cmbType.SelectedValue;
           t.ChessTypeID =(int) cmbChessType.SelectedValue;
           t.Round = (int)cmbRound.SelectedValue;

           t.Rated = chkRated.Checked;
           t.DoubleRound = chkDoubleRound.Checked;
           t.IsTieBreak = chkAllowTieBreak.Checked;
           t.TimeControlMin = (int)cmbMin.SelectedValue;
           t.TimeControlSec = (int)cmbSec.SelectedValue;

           //t.RegistrationStartDate = dtpRegistrationStart.Value;
            //t.RegistrationStartTime 
             //t.RegistrationEndDate    
           //t.RegistrationEndTime 

           t.Name = txtTitle.Text;
           t.Description = txtInvitation.Text;

           SocketClient.SaveTournament(t.DataRow.Table);
        }

        void FillNumbers()
        {
            for (int i = 1; i < 20; i++)
            {
                cmbRound.Items.Add(i.ToString());
            }
            cmbRound.SelectedIndex = 0;
        }

        void FillMin()
        {
            for (int i = 1; i < 181; i++)
            {
                cmbMin.Items.Add(i.ToString());
                cmbSec.Items.Add(i.ToString());

            }
            cmbMin.SelectedIndex = 0;
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveTournament();
        }
    }
}
