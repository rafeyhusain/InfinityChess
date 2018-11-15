using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;
using App.Win;

namespace InfinityChess.Online
{
    public partial class ServerTimeUc : UserControl
    {
        #region Constructor
        public ServerTimeUc()
        {
            InitializeComponent();
        }
        #endregion

        TimeSpan tsLocal = DateTime.Now.TimeOfDay;
        TimeSpan tsServer = DateTime.Now.TimeOfDay;

        #region Load Event
        private void ServerTimeUc_Load(object sender, EventArgs e)
        {
            FillServerTime();
            FillLocalTime();
        }
        #endregion

        #region Fill Local and server time
        void FillLocalTime()
        {
            this.dtpLocalTimeB.ValueChanged -= new System.EventHandler(this.dtpLocalTimeB_ValueChanged);
            this.dtpServerTimeB.ValueChanged -= new System.EventHandler(this.dtpServerTimeB_ValueChanged);
            this.dtpLocalTimeB.KeyDown -= new KeyEventHandler(dtpLocalTimeB_KeyDown);
            this.dtpServerTimeB.KeyDown -= new KeyEventHandler(this.dtpServerTimeB_KeyDown);

            dtpLocalTimeA.Text = DateTime.Now.ToString();
            dtpLocalTimeB.Text = DateTime.Now.ToString();

            tsLocal = dtpLocalTimeA.Value.TimeOfDay;            
            
            this.dtpLocalTimeB.KeyDown += new KeyEventHandler(dtpLocalTimeB_KeyDown);
            this.dtpLocalTimeB.ValueChanged += new System.EventHandler(this.dtpLocalTimeB_ValueChanged);
            this.dtpServerTimeB.ValueChanged += new System.EventHandler(this.dtpServerTimeB_ValueChanged);
            this.dtpServerTimeB.KeyDown += new KeyEventHandler(this.dtpServerTimeB_KeyDown);
        }

        void FillServerTime()
        {
            this.dtpLocalTimeB.ValueChanged -= new System.EventHandler(this.dtpLocalTimeB_ValueChanged);
            this.dtpServerTimeB.ValueChanged -= new System.EventHandler(this.dtpServerTimeB_ValueChanged);
            this.dtpLocalTimeB.KeyDown -= new KeyEventHandler(dtpLocalTimeB_KeyDown);
            this.dtpServerTimeB.KeyDown -= new KeyEventHandler(this.dtpServerTimeB_KeyDown);

            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetServerTime);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            DataSet ds = SocketClient.GetServerTime();

            if (ds.Tables.Count > 0)
            {
                Kv kvServerTime = new Kv(ds.Tables[0]);
                string serverTime = kvServerTime.Get("ServerTime");
                if (serverTime.Trim().Length > 0)
                {
                    dtpServerTimeA.Text = serverTime;
                    dtpServerTimeB.Text = serverTime;
                    tsServer = dtpServerTimeA.Value.TimeOfDay;
                }
            }
            this.dtpLocalTimeB.KeyDown += new KeyEventHandler(dtpLocalTimeB_KeyDown);
            this.dtpLocalTimeB.ValueChanged += new System.EventHandler(this.dtpLocalTimeB_ValueChanged);
            this.dtpServerTimeB.ValueChanged += new System.EventHandler(this.dtpServerTimeB_ValueChanged);
            this.dtpServerTimeB.KeyDown += new KeyEventHandler(this.dtpServerTimeB_KeyDown);
        }


        #endregion
        
        #region Local and server time value change event
        private void dtpLocalTimeB_ValueChanged(object sender, EventArgs e)
        {
            LocalTimeBChange();
        }

        private void dtpServerTimeB_ValueChanged(object sender, EventArgs e)
        {
            ServerTimeBChange();
            //LocalTimeBChange();
        }


        #endregion

        #region Local Time and server time change
        void ServerTimeBChange()
        {
            this.dtpLocalTimeB.ValueChanged -= new System.EventHandler(this.dtpLocalTimeB_ValueChanged);
            this.dtpServerTimeB.ValueChanged -= new System.EventHandler(this.dtpServerTimeB_ValueChanged);
            this.dtpLocalTimeB.KeyDown -= new KeyEventHandler(dtpLocalTimeB_KeyDown);
            this.dtpServerTimeB.KeyDown -= new KeyEventHandler(this.dtpServerTimeB_KeyDown);

            //TimeSpan ts = dtpServerTimeB.Value.Subtract(dtpLocalTimeB.Value);
            //dtpLocalTimeB.Value = dtpLocalTimeB.Value.Add(ts);
            DateTime dt = dtpServerTimeB.Value.Subtract(tsServer);
            dtpLocalTimeB.Value = dtpLocalTimeB.Value.Add(dt.TimeOfDay);
            tsServer = dtpServerTimeB.Value.TimeOfDay;
            tsLocal = dtpLocalTimeB.Value.TimeOfDay;

            this.dtpLocalTimeB.KeyDown += new KeyEventHandler(dtpLocalTimeB_KeyDown);
            this.dtpLocalTimeB.ValueChanged += new System.EventHandler(this.dtpLocalTimeB_ValueChanged);
            this.dtpServerTimeB.ValueChanged += new System.EventHandler(this.dtpServerTimeB_ValueChanged);
            this.dtpServerTimeB.KeyDown += new KeyEventHandler(this.dtpServerTimeB_KeyDown);
        }

        void LocalTimeBChange()
        {
            this.dtpLocalTimeB.ValueChanged -= new System.EventHandler(this.dtpLocalTimeB_ValueChanged);
            this.dtpServerTimeB.ValueChanged -= new System.EventHandler(this.dtpServerTimeB_ValueChanged);
            this.dtpLocalTimeB.KeyDown -= new KeyEventHandler(dtpLocalTimeB_KeyDown);
            this.dtpServerTimeB.KeyDown -= new KeyEventHandler(this.dtpServerTimeB_KeyDown);

            DateTime dt = dtpLocalTimeB.Value.Subtract(tsLocal);
            dtpServerTimeB.Value = dtpServerTimeB.Value.Add(dt.TimeOfDay);
            tsLocal = dtpLocalTimeB.Value.TimeOfDay;
            tsServer = dtpServerTimeB.Value.TimeOfDay;
            //TimeSpan ts = dtpLocalTimeB.Value.Subtract(dtpServerTimeB.Value);
            //dtpServerTimeB.Value = dtpServerTimeB.Value.Add(ts);

            this.dtpLocalTimeB.KeyDown += new KeyEventHandler(dtpLocalTimeB_KeyDown);
            this.dtpLocalTimeB.ValueChanged += new System.EventHandler(this.dtpLocalTimeB_ValueChanged);
            this.dtpServerTimeB.ValueChanged += new System.EventHandler(this.dtpServerTimeB_ValueChanged);
            this.dtpServerTimeB.KeyDown += new KeyEventHandler(this.dtpServerTimeB_KeyDown);
        } 
        #endregion

        private void dtpServerTimeB_KeyDown(object sender, KeyEventArgs e)
        {
            ServerTimeBChange();
        }

        private void dtpLocalTimeB_KeyDown(object sender, KeyEventArgs e)
        {
            LocalTimeBChange();
        }

        //private void dtpServerTimeB_KeyUp(object sender, KeyEventArgs e)
        //{

        //}

        //private void dtpLocalTimeB_KeyUp(object sender, KeyEventArgs e)
        //{

        //}

        #region event for time change
        //private void dtpLocalTimeB_KeyUp(object sender, KeyEventArgs e)
        //{
        //    LocalTimeBChange(); //dtpLocalTimeB_ValueChanged(sender, e);
        //}

        //private void dtpLocalTimeB_KeyDown(object sender, KeyEventArgs e)
        //{
        //    ServerTimeBChange(); //dtpServerTimeB_ValueChanged(sender, e);
        //}
        #endregion

    }
}
