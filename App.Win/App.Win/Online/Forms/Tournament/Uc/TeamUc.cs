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
    public partial class TeamUc : UserControl
    {
        public TeamUc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Team t = new Team();
            t.Name  = txtName .Text ;
            t.Description = txtDescription .Text ;

            SocketClient.AddTeam(t.DataRow.Table); 
        }

        private void FIllGrid()
        {
            DataSet ds =  SocketClient.GetAllTeams();

            if (ds.Tables.Count > 0)
            {
                dgvTeam.DataSource = ds.Tables[0];
            }
        }

        private void TeamUc_Load(object sender, EventArgs e)
        {
            FIllGrid();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtDescription.Text = "";
        }
    }
}
