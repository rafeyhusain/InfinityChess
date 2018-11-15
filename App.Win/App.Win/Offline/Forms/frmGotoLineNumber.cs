using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Win;

namespace InfinityChess.WinForms
{
    public partial class frmGotoLineNumber : Form
    {
        #region Data Member
        public DatabaseForm DatabaseForm = null;
        int maxLineNumbersInGamesGrid = 0;
        #endregion

        #region Ctor
        public frmGotoLineNumber(DatabaseForm databaseForm)
        {
            DatabaseForm = databaseForm;
            InitializeComponent();
        } 
        #endregion

        #region Load
        private void frmGotoLine_Load(object sender, EventArgs e)
        {
            if (this.DatabaseForm != null)
            {
                maxLineNumbersInGamesGrid = this.DatabaseForm.GameGridView.Rows.Count;
                BoundComboWithGamesGridLineNumbers();
            }
        }

        #endregion

        #region Bound Games Grid Line Numbers To ComboBox
        public void BoundComboWithGamesGridLineNumbers()
        {
             
            for (int num = 1; num <= maxLineNumbersInGamesGrid; num++)
            {
                domainUpDown.Items.Add(num.ToString());
            }
            domainUpDown.SelectedIndex = 0;

        } 
        #endregion
               
        #region Called Once the OK Button get pressed
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.DatabaseForm.GameGridView.Rows[int.Parse(domainUpDown.Text) - 1].Selected = true;
                this.DatabaseForm.GameGridView.FirstDisplayedScrollingRowIndex = int.Parse(domainUpDown.Text) - 1;
                this.Close();
            }
            catch (Exception ex)
            {
                App.Model.TestDebugger.Instance.WriteError(ex);
                //maxLineNumbersInGamesGrid--;
                MessageBox.Show("Please select Line Numbers from 1 - " +  maxLineNumbersInGamesGrid);
            }
        }
        #endregion
    }
}
