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
    public partial class RankInfo : Form
    {
        public RankInfo(int userId,string userName)
        {
            InitializeComponent();
            rankInfoUc1.UserID = userId;
            rankInfoUc1.UserName = userName;
           
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RankInfo_Load(object sender, EventArgs e)
        {
            this.Text = "'" + rankInfoUc1.UserName + "'" + " - Rank Information";
          
        }

       

        
    }
}
