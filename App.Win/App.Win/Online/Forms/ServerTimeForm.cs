using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InfinityChess.Online.Forms
{
    public partial class ServerTimeForm : Form
    {
        public ServerTimeForm()
        {
            InitializeComponent();
        }

        #region Close Event
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion      

    }
}
