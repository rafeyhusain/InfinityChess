// (c) Copyright RafeySoft, Karachi Pakistan. http://rafeysoft.com
// This source is subject to following License:
// http://rafeysoft.com/Web/Page/ItemEdit.aspx?sid=29&lid=4&cid=23&iid=2143
// Please write to info@rafeysoft.com for more information
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using App.Model.Db;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;

namespace App.Model
{
    public partial class SocketClient
    {
        #region Data Members
        private static SocketClient sc = null;
        private UserSession userSession = null;
        public int Retries;

        #endregion

        #region Events
        public delegate void OnClientDataReceived(object sender, Kv kv);
        public event OnClientDataReceived ClientDataReceived;

        public delegate void OnServerDownErrorEventHandler(String error);
        public event OnServerDownErrorEventHandler ServerDownError;
        #endregion

        #region Instance
        public static SocketClient Instance
        {
            [DebuggerStepThrough]
            get
            {
                if (sc == null)
                {
                    sc = new SocketClient();

                }

                return sc;
            }
        }
        #endregion

        #region Calc Properties
        public bool IsNotConnected
        {
            [DebuggerStepThrough]
            get
            {
                return !IsConnected;
            }
        }
        public bool IsConnected
        {
            [DebuggerStepThrough]
            get
            {
                if (userSession == null || userSession.SynSocket == null || userSession.AsynSocket == null)
                {
                    return false;
                }
                else
                {
                    return userSession.SynSocket.Connected && userSession.AsynSocket.Connected;
                }
            }
        }
        #endregion

        #region Connect/Disconnect
        public bool Connect()
        {
            try
            {
                Retries = 0;
                userSession = new UserSession(0);

                userSession.SynSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                userSession.SynSocket.Connect(Config.GameServerIP, Config.GameServerPort);

                userSession.AsynSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                userSession.AsynSocket.Connect(Config.GameServerIP, Config.GameServerPort);

                userSession.AsynSocket.BeginReceive(userSession.AsyncBuffer, 0, UserSession.BufferSize, SocketFlags.None, new AsyncCallback(ASyncDataRecive), userSession);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Disconnect()
        {
            if (userSession.AsynSocket != null)
            {
                if (userSession.AsynSocket.Connected)
                {
                    userSession.AsynSocket.Shutdown(SocketShutdown.Both);
                    userSession.AsynSocket.Close();
                    userSession.AsynSocket = null;
                }
                if (userSession.SynSocket.Connected)
                {
                    userSession.SynSocket.Shutdown(SocketShutdown.Both);
                    userSession.SynSocket.Close();
                    userSession.SynSocket = null;
                }
            }
            userSession = null;
        }
        #endregion

        #region Invoke
        public DataSet Invoke(DataTable dt)
        {        
          
            DataSet ds = new DataSet();

            if (SendSync(dt))
            {
                ds = SyncDataRecive();
            } 
            return ds;          
            
        }

        public void InvokeAsync(DataTable dt)
        {
            SendAsync(dt);
        }
       

        #endregion

        #region SendData
        private bool SendSync(DataTable dt)
        {
            try
            {
                if (userSession.SynSocket != null)
                {
                    byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(UData.ToString(dt) + "\0");
                    userSession.SynSocket.Send(data);
                }
            }
            catch (Exception ex)
            {
                OnServerDownError(ex);
                return false;
            }

            return true;
        }

        public void SendAsync(DataTable dt)
        {
            try
            {
                if (userSession.AsynSocket != null)
                {
                    byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(UData.ToString(dt) + "\0");
                    userSession.AsynSocket.Send(data);
                }
            }
            catch (Exception ex)
            {
                OnServerDownError(ex);
            }
        }
        #endregion

        #region ClientDataRecive
        private DataSet SyncDataRecive()
        {
            try
            {
                userSession.SyncData = new StringBuilder();

                int i = userSession.SynSocket.Receive(userSession.SyncBuffer);

                while (true)
                {
                    string Unzipdata = UZip.Unzip(System.Text.ASCIIEncoding.ASCII.GetString(userSession.SyncBuffer, 0, i));
                    userSession.SyncData.Append(Unzipdata);

                    if (!userSession.SyncData.ToString().Contains("\0"))
                    {
                        i = userSession.SynSocket.Receive(userSession.SyncBuffer);
                    }
                    else
                    {
                        break;
                    }
                }

                if (UData.IsValidXml(userSession.SyncData.ToString()))
                {
                    return UData.LoadDataSet(userSession.SyncData.ToString());
                }
                else
                {
                    DataSet ds = new DataSet();
                    return ds;
                }
            }
            catch (Exception ex)
            {
                OnServerDownError(ex);

                return new DataSet();
            }
        }

        private void ASyncDataRecive(IAsyncResult asynResult)
        {
            try
            {
                UserSession css = (UserSession)asynResult.AsyncState;

                if (css.AsynSocket == null)
                {
                    return;
                }
                int i = css.AsynSocket.EndReceive(asynResult);

                if (i == 0)
                {
                    return;
                }

                string Unzipdata = UZip.Unzip(System.Text.ASCIIEncoding.ASCII.GetString(css.AsyncBuffer, 0, i));
                css.AsyncData.Append(Unzipdata);

                if (!css.AsyncData.ToString().Contains("\0"))
                {
                    css.AsynSocket.BeginReceive(css.AsyncBuffer, 0, UserSession.BufferSize, SocketFlags.None, new AsyncCallback(ASyncDataRecive), css);
                }
                else
                {
                    css.AsyncData = FilterData(css);
                    css.AsynSocket.BeginReceive(css.AsyncBuffer, 0, UserSession.BufferSize, SocketFlags.None, new AsyncCallback(ASyncDataRecive), css);
                }
            }
            catch (Exception ex)
            {
                OnServerDownError(ex);
            }
        }
        #endregion

        #region Helpers

        private void OnServerDownError(Exception ex)
        {
            if (ServerDownError != null)
            {
                TestDebugger.Instance.WriteError(ex);
                ServerDownError(AppException.GetError(ex));
                SocketClient.ServerMessage();
            }            
        }

        private StringBuilder FilterData(UserSession us)
        {
            string[] strs = UStr.Split(us.AsyncData.ToString(), "\0", StringSplitOptions.RemoveEmptyEntries);

            string str = "";
            int i = 0;
            us.AsyncData = new StringBuilder();
            bool isValid = true;

            if (strs.Length > 0)
            {
                str = strs[strs.Length - 1];
                if (!UData.IsValidXml(str))
                {
                    us.AsyncData.Append(str);
                    isValid = false;
                }

                if (isValid)
                {
                    for (i = 0; i < strs.Length; i++)
                    {
                        str = strs[i];
                        ProcessData(str, us);
                    }
                }
                else
                {
                    for (i = 0; i < strs.Length - 1; i++)
                    {
                        str = strs[i];
                        ProcessData(str, us);
                    }
                }
            }

            return us.AsyncData;
        }

        private void ProcessData(string str, UserSession us)
        {
            if (UData.IsValidXml(str))
            {
                DataTable dt = UData.LoadDataTable(UData.LoadXsdText(str), str);

                Kv kv = new Kv(dt);

                Ap.MsgQueue.Enqueue(kv);
            }
        }
        #endregion
    }
}
