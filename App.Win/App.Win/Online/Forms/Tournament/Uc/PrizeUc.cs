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
    public partial class PrizeUc : UserControl
    {
        public PrizeUc()
        {
            InitializeComponent();
        }

        private void toolStripBtnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TournamentPrize tp = new TournamentPrize();

            tp.PrizePosition = (int)cmbPrize.SelectedValue;
            tp.TournamentPrizeCategoryID = (int)cmbCategory.SelectedValue;
            tp.PrizeAmount = BaseItem.ToDecimal(txtAmount.Text);

            tp.TournamentID = 1;

            SocketClient.AddPrize(tp.DataRow.Table);
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {

        }

        private void PrizeUc_Load(object sender, EventArgs e)
        {

        }
    }
}
