using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using App.Model.Db;
using System.Timers;
using System.Data;


namespace App.Model
{
    public class UserSession
    {
        #region Data Members
        public int UserID;

        /// <summary>
        /// True is User is ready to receive 
        /// message for new game or restarted game
        /// </summary>
        public bool IsReady = true;

        int TimeOut = 15;
        public int ElapsedTime;
        int Heartbeat = 5000;//ms
        DateTime start;

        public Socket AsynSocket;
        public Socket SynSocket;

        public const int BufferSize = 8192;
        public byte[] AsyncBuffer = new byte[BufferSize];
        public byte[] SyncBuffer = new byte[BufferSize];

        public StringBuilder AsyncData;
        public StringBuilder SyncData;

        Timer t = new Timer();

        public event EventHandler OnTimeOut;

        #endregion

        #region Properties

        #endregion

        #region Constructor
        public UserSession(int id)
        {
            Init(id);
        }

        #endregion

        #region Methods

        protected virtual void Init(int id)
        {
            UserID = id;

            AsyncBuffer = new byte[BufferSize];
            SyncBuffer = new byte[BufferSize];

            AsyncData = new StringBuilder();
            SyncData = new StringBuilder();

            if (id != 0)
            {
                KeyValues.IsRequestFromServer = true;
                if (!string.IsNullOrEmpty(KeyValues.Instance.GetKeyValue(KeyValueE.TimeOut).Value))
                {
                    TimeOut = BaseItem.ToInt32(KeyValues.Instance.GetKeyValue(KeyValueE.TimeOut).Value);
                }

                if (!string.IsNullOrEmpty(KeyValues.Instance.GetKeyValue(KeyValueE.Heartbeat).Value))
                {
                    Heartbeat = BaseItem.ToInt32(KeyValues.Instance.GetKeyValue(KeyValueE.Heartbeat).Value);
                }

                t.Elapsed += new ElapsedEventHandler(t_Elapsed);
                t.Interval = 1000;
                t.Start();
            }
        }

        public virtual void CloseSocket(Cxt cxt)
        {
            try
            {
                if (AsynSocket == null && SynSocket == null)
                {
                    return;
                }

                if (AsynSocket != null)
                {
                    AsynSocket.Shutdown(SocketShutdown.Both);
                    AsynSocket.Close();
                    AsynSocket = null;
                }
                if (SynSocket != null)
                {
                    SynSocket.Shutdown(SocketShutdown.Both);
                    SynSocket.Close();
                    SynSocket = null;
                }
            }
            catch (Exception ex)
            {
                Log.Write(cxt, ex);
            }
        }

        public void SendAsync(string data)
        {
            try
            {
                if (AsynSocket != null)
                {
                    if (AsynSocket.Connected)
                    {
                        AsynSocket.Send(System.Text.ASCIIEncoding.ASCII.GetBytes(data + "\0"));
                    }
                }
            }
            catch
            {
                // If someone is disconnected (i.e. PC down or internet dc), I can not do anything!
            }
        }

        //public DataSet SendSync(string data)
        public DataSet SendSync(string data)
        {
            try
            {
                if (SynSocket != null)
                {
                    if (SynSocket.Connected)
                    {
                        SyncData = new StringBuilder();
                        int i = SynSocket.Receive(SyncBuffer);

                        while (true)
                        {
                            SyncData.Append(System.Text.ASCIIEncoding.ASCII.GetString(SyncBuffer, 0, i));

                            if (!SyncData.ToString().Contains("\0"))
                            {
                                i = SynSocket.Receive(SyncBuffer);
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (UData.IsValidXml(SyncData.ToString()))
                        {
                            return UData.LoadDataSet(SyncData.ToString());
                        }
                        else
                        {
                            DataSet ds = new DataSet();
                            return ds;
                        }
                    }
                    else
                    {
                        return new DataSet();
                    }
                }
                else
                {
                    return new DataSet();
                }
            }
            catch (Exception ex)
            {
                return new DataSet();
            }
        }

        private void PingClient()
        {
            start = DateTime.Now;

            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.PingClient);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);

            SendAsync(kv.ToDataTableString);
        }

        public void PingReply()
        {
            DateTime end = DateTime.Now;
            TimeSpan ts = end.Subtract(start);

            User.UpdateInternet(ts.TotalSeconds, UserID);

            ElapsedTime = 0;
        }

        public void Stop()
        {
            t.Stop();
        }

        #endregion

        #region Timer tick

        void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            t.Stop();
            ElapsedTime++;

            if (ElapsedTime > (Heartbeat / 1000) + 1)
            {
                PingClient();
            }

            if (ElapsedTime > TimeOut)
            {
                if (OnTimeOut != null)
                {
                    OnTimeOut(this, EventArgs.Empty);
                    return;
                }
            }

            t.Start();
        }
        #endregion
    }
}

