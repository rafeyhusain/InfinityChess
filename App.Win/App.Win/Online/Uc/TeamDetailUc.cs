using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace App.Win
{
    public partial class TeamDetailUc : UserControl
    {
        
        public TeamDetailUc()
        {
            InitializeComponent();
        }
        public string TeamName
        {
            set { txtTeamName.Text = value; }
            get { return txtTeamName.Text; }
        }
        public string TeamDescription
        {
            set { txtDescription.Text = value; }
            get { return txtDescription.Text; }
        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
