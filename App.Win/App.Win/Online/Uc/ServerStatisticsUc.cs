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
using System.Diagnostics;

namespace InfinityChess.Online.Uc
{
    public partial class ServerStatisticsUc : UserControl
    {
        public ServerStatisticsUc()
        {
            InitializeComponent();
        }

        ServerStatistic ServerStatistic = null;
        #region Properties
      
        #endregion

        #region Method

        void GetServerStatistics()
        {           
            ServerStatistic = App.Model.SocketClient.GetServerStatistic();
            if (ServerStatistic != null)
            {
                this.lblUptime.Text = ServerStatistic.ServerUpTime.ToString();
                this.lblRegisteredUsers.Text = ServerStatistic.RegisterUsers.ToString();
                this.lblTotalGames.Text = ServerStatistic.TotalGames.ToString();
                this.lblTournaments.Text = ServerStatistic.Tournaments.ToString();
                this.lblVisitors.Text = ServerStatistic.Visitors.ToString();
                this.lblGamePlayed.Text = ServerStatistic.GamePlayed.ToString();
                this.lblPeakUsers.Text = ServerStatistic.PeakUsers.ToString();
                this.groupBox1.Text += string.Format("{0:F}", ServerStatistic.PriviousDay);
            }
        }

        #endregion


        private void ServerStatisticsUc_Load(object sender, EventArgs e)
        {
            GetServerStatistics();            
        }

       
    }
}
