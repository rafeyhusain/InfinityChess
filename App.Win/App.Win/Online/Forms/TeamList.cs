using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace App.Win
{
    public partial class TeamList : Form
    {
        public TeamList()
        {
            InitializeComponent();
        }

        private void TeamList_Load(object sender, EventArgs e)
        {

        }

        internal static void Show(Form owner, bool dummy)
        {
            TeamList frm = new TeamList();

            frm.Show(owner);
        }

    }
}
