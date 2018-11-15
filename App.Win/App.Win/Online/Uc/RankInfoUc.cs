using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;

namespace App.Win
{
    public partial class RankInfoUc : UserControl
    {
        private int userID;
        private string userName;
        public RankInfoUc()
        {
            InitializeComponent();
            
        }
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private void RankInfoUc_Load(object sender, EventArgs e)
        {
            DataSet ds = SocketClient.GetRankInfo(userID);
            
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null)
                { 
                    this.lbRank.Text = ds.Tables[0].Rows[0]["rank"].ToString();
                    this.lblNextRank.Text = ds.Tables[0].Rows[0]["nextRank"].ToString();
                    this.lblLoginDays.Text = ds.Tables[0].Rows[0]["loginDays"].ToString();
                    this.lblBullet.Text = "Required Game = " + ds.Tables[0].Rows[0]["requiredGame"].ToString();
                    
                }
            }

        }
    }
}
