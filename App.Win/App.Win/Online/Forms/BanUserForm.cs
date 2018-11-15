using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;
using System.Text.RegularExpressions;

namespace App.Win
{
    public partial class BanUserForm : Form
    {


        #region Contructors
        public BanUserForm()
        {
            InitializeComponent();
        }

        #region Set Icon
        void SetIcon()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BanUserForm));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        } 
        #endregion

        public BanUserForm(int userID)
        {
            InitializeComponent();
            banUserUc1.UserID = userID;
        }

        public BanUserForm(int userID, string userName)
        {
            InitializeComponent();
            banUserUc1.UserID = userID;
            banUserUc1.UserName = userName;            
            this.Text = "Ban '" + userName + "'";
            SetIcon();
            
        } 
        #endregion
                
        #region Events
        void banUserUc1_SubmitClicked(DialogResult dr)
        {
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BanUserForm_Load(object sender, EventArgs e)
        {
            banUserUc1.SubmitClicked += new BanUserUc.SubmitClickedHandler(banUserUc1_SubmitClicked);
        } 
        #endregion

        private void banUserUc1_Load(object sender, EventArgs e)
        {

        }

       
        

        

        

        

        

        
    }
}
