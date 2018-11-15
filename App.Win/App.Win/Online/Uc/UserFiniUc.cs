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

    public partial class UserFiniUc : UserControl
    {
       
        #region Constructors
        public UserFiniUc()
        {
            InitializeComponent();
           
        } 
        #endregion

        decimal stake = 0;
        decimal flate = 0;
        decimal oldFlat = 0;
        public decimal Stake { get { return nudStake.Value; } }
        public decimal Flate { get { return nudFlate.Value; } }

        decimal oldStake = 0;

        public bool IsFini
        {
            get
            {
                if (Stake > 0 || Flate != 0)
                {
                    return true;
                }
                return false;
            }
        }

        public bool IsFiniApplicable(int opponentUserID)
        {
            
            if (IsFini)
            {

                if (((int)Ap.CurrentUser.HumanRankIDE < (int)RankE.Knight))
                {
                    ChatClient.Write(ChatTypeE.OnlineClient, ChatMessageTypeE.Error, ChatTypeE.OnlineClient, MsgE.ErrorBeforePlayFini,0);
                    return true;
                }
                else if (!(Ap.CurrentUser.Fini > 0))
                {
                    ChatClient.Write(ChatTypeE.OnlineClient, ChatMessageTypeE.Error, ChatTypeE.OnlineClient, Msg.GetMsg(MsgE.ErrorFiniNotExist, Ap.CurrentUser.UserName),0);
                    return true;
                }

                DataSet ds = SocketClient.GetUserById(opponentUserID);
                User opponentUser = null;

                if (ds.Tables.Count > 0)
                {
                    opponentUser = User.CreateUser(ds.Tables[0]);
                }

                if (opponentUser != null)
                {
                    if (((int)opponentUser.HumanRankIDE < (int)RankE.Knight))
                    {
                        ChatClient.Write(ChatTypeE.OnlineClient, ChatMessageTypeE.Error, ChatTypeE.OnlineClient, MsgE.ErrorBeforePlayFini,0);
                        return true;
                    }
                    else if (!(opponentUser.Fini > 0))
                    {
                        ChatClient.Write(ChatTypeE.OnlineClient, ChatMessageTypeE.Error, ChatTypeE.OnlineClient, Msg.GetMsg(MsgE.ErrorFiniNotExist, opponentUser.UserName), 0);
                        return true;
                    }
                }
                else
                {
                    return true;
                }
                
            }
            return false;
        }

        string ValidateValue(string value)
        {
            if (value.Contains("+-") || value.Contains("-+"))
            {
                value = value.Remove(0, 1);

            }
            return value;
        }

        void UpdateStakeText()
        {
            if (stake > 0)
            {
                lblWinText.Text = "+" + stake.ToString();
            }
            else if (stake < 0)
            {
                lblWinText.Text = "-" + stake.ToString();
            }
            else
            {
                lblWinText.Text = "0";
            }

        }

        void UpdateFlateText()
        {
            if (flate > 0)
            {
                lblLossText.Text = "+" + flate;
            }
            else if (flate < 0)
            {
                lblLossText.Text = "-" + flate;
            }
            else
            {
                lblLossText.Text = "0";
            }

        }

        private void nudStake_ValueChanged(object sender, EventArgs e)
        {
            //this.lblLossText.TextChanged -= new System.EventHandler(this.lblLossText_TextChanged);
            if (oldStake > nudStake.Value)
            {
                stake = -1;
            }
            else
            {
                stake = +1;
            }
            oldStake = nudStake.Value;


            decimal win = Convert.ToDecimal(lblWinText.Text);
            decimal lose = Convert.ToDecimal(lblLossText.Text);

            //lblDrawText.Text = nudFlate.Value.ToString();

            win = win + stake;
            lose = lose + (-stake);

            lblWinText.Text = win.ToString();
            lblLossText.Text = lose.ToString();

            
        }
        
        
        private void nudFlate_ValueChanged(object sender, EventArgs e)
        {
            //flate = 0;
            //stake = 0;
            //this.nudStake.ValueChanged -= new System.EventHandler(this.nudStake_ValueChanged);
            this.lblLossText.TextChanged -= new System.EventHandler(this.lblLossText_TextChanged);

            if (oldFlat > nudFlate.Value)
            {
                flate = -1;
            }
            else
            {
                flate = 1;
            }              

            oldFlat = nudFlate.Value;

            decimal win = Convert.ToDecimal(lblWinText.Text);
            decimal lose = Convert.ToDecimal(lblLossText.Text);

            lblDrawText.Text = nudFlate.Value.ToString();

            win = win + flate;
            lose = lose + flate;

            lblWinText.Text = win.ToString();
            lblLossText.Text = lose.ToString();

            this.lblLossText.TextChanged += new System.EventHandler(this.lblLossText_TextChanged);
        }        

        private void lblLossText_TextChanged(object sender, EventArgs e)
        {
            this.lblLossText.TextChanged -= new System.EventHandler(this.lblLossText_TextChanged);
            decimal dec = Convert.ToDecimal(lblLossText.Text);
            //dec = -dec;
            
            lblLossText.Text = dec.ToString();
            this.lblLossText.TextChanged += new System.EventHandler(this.lblLossText_TextChanged);
        }
       
    }
}
