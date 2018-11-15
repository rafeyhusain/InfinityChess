using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;
using App.Model.Db;

namespace App.Win
{

    public partial class BanUserUc : UserControl
    {
       
        #region Constructors
        public BanUserUc()
        {
            InitializeComponent();
            FillDays();
            FillHours();
        } 
        #endregion

        #region Delegates
        public delegate void SubmitClickedHandler(DialogResult dr);
        public event SubmitClickedHandler SubmitClicked; 
        #endregion

        #region Variables
        int userID = 0;
        string userName = string.Empty;
        DateTime dtServerTime = DateTime.Now;
        #endregion

        #region Properties
        public int UserID { get { return userID; } set { userID = value; } }
        public string UserName { get { return userName; } set { userName = value; } }

        private UserDataKv kv = null; 
        public UserDataKv KvUserData
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                if (kv == null)
                {
                    kv = new UserDataKv();
                }

                return kv;
            }
        } 
        #endregion      
        
        #region Events

        #region Forever radio button error
        private void rbForever_CheckedChanged(object sender, EventArgs e)
        {
            if (rbForever.Checked)
            {
                EnableFields(false, 0);
            }
            else
            {
                EnableFields(true, 0);
            }
        } 
        #endregion



        #region Ok button Event
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtBanReason.Text != string.Empty)
            {
                KvUserData.UserID = this.userID;
                KvUserData.BanStartDate = dtpStartDate.Text;
                KvUserData.BanStartTime = dtpStartTime.Text;
                KvUserData.BanReason = txtBanReason.Text;
                KvUserData.BanMachineKey = WmiHelper.GetMachineKey();
                if (rbDate.Checked)
                {
                    KvUserData.BanEndDate = dtpEndDate.Text;
                    KvUserData.BanEndTime = dtpEndTime.Text;
                }
                else if (rbForever.Checked)
                {
                    KvUserData.BanEndDate = "";
                    KvUserData.BanEndTime = "";
                }
                else if (rbDuration.Checked)
                {
                    KvUserData.BanEndDate = dtServerTime.ToString();
                    if (cbDays.Text.Trim().Length > 0)
                    {
                        dtServerTime = dtServerTime.AddDays(Convert.ToInt32(cbDays.Text));
                        KvUserData.BanEndTime = dtServerTime.ToString();
                    }
                    if (cbHours.Text.Trim().Length > 0)
                    {
                        dtServerTime = dtServerTime.AddHours(Convert.ToInt32(cbHours.Text));
                        KvUserData.BanEndTime = dtServerTime.ToString();
                    }
                }

                DialogResult dr = MessageForm.Confirm(this.ParentForm, MsgE.ConfirmBanUser, userName);
                if (dr == DialogResult.Yes)
                {
                    DataSet ds = SocketClient.BanUser(KvUserData);
                }
                SubmitClicked(dr);

            }
            else
            {
                MessageForm.Error(this.ParentForm, MsgE.ErrorBanReason);
            }

        }
        
        #endregion

        #region Load Event
        private void BanUserUc_Load(object sender, EventArgs e)
        {            
            rbDate.Checked = true;
            DataSet ds = SocketClient.GetServerTime();           
            if (ds.Tables.Count > 0)
            {
                Kv kvServerTime = new Kv(ds.Tables[0]);
                string serverTime = kvServerTime.Get("ServerTime");
                if (serverTime.Trim().Length > 0)
                {
                    lblServerTime.Text = serverTime;
                    dtServerTime = Convert.ToDateTime(lblServerTime.Text);

                    dtpStartDate.Text = Convert.ToDateTime(lblServerTime.Text).ToShortDateString();
                    dtpStartTime.Text = Convert.ToDateTime(lblServerTime.Text).ToLongTimeString();
                    dtpEndDate.Text = Convert.ToDateTime(lblServerTime.Text).ToShortDateString();
                    dtpEndTime.Text = Convert.ToDateTime(lblServerTime.Text).ToShortTimeString();
                }
            }

        }
        #endregion

        #endregion

        #region Method

        void EnableFields(bool isEnable, int index)
        {
            if (index == 0)
            {
                dtpStartDate.Enabled = isEnable;
                dtpEndDate.Enabled = isEnable;
                dtpStartTime.Enabled = isEnable;
                dtpEndTime.Enabled = isEnable;
                cbDays.Enabled = isEnable;
                cbHours.Enabled = isEnable;
            }
            else if (index == 1)
            {
                dtpStartDate.Enabled = isEnable;
                dtpEndDate.Enabled = isEnable;
                dtpStartTime.Enabled = isEnable;
                dtpEndTime.Enabled = isEnable;
                cbDays.Enabled = false;
                cbHours.Enabled = false;
            }
            else            
            {
                dtpStartDate.Enabled = isEnable;
                dtpEndDate.Enabled = isEnable;
                dtpStartTime.Enabled = isEnable;
                dtpEndTime.Enabled = isEnable;
                cbDays.Enabled = true;
                cbHours.Enabled = true;
            }
        }

        void FillDays()
        {
            for (int i = 1; i < 31; i++)
            {
                cbDays.Items.Add(i.ToString());
            }
        }

        void FillHours()
        {
            for (int i = 1; i < 25; i++)
            {
                cbHours.Items.Add(i.ToString());
            }
        }

        #endregion

        private void rbDate_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDate.Checked)
            {
                EnableFields(true, 1);
            }
            else
            {
                EnableFields(false, 2);
            }
        }

        private void rbDuration_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDuration.Checked)
            {
                EnableFields(false, 2);
            }
            else
            {
                EnableFields(true, 1);
            }
        }

        

        
    }
}
