using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;

namespace App.Win
{
    public partial class ChangeWeightPopup : BaseWinForm
    {
        int moveWeight = 0;

        public int MoveWeight
        {
            get { return moveWeight; }
        }

        public override string HelpTopicId
        {
            get { return "10"; }
        }

        public ChangeWeightPopup(int currentMoveWeight)
        {
            InitializeComponent();
            moveWeight = currentMoveWeight;
        }

        private void ChangeWeightPopup_Load(object sender, EventArgs e)
        {
            numMoveWeight.Value = moveWeight;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            moveWeight = Convert.ToInt32(numMoveWeight.Value);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
