using System;
using App.Model;
using System.Collections.Generic;

using System.Text;
using InfinityChess;
using System.IO;
using InfinitySettings.Streams;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
namespace App.Model
{
    public class Eco
    {
        #region Data Members
        private BackgroundWorker bw;
        public Kv Kv = new Kv();
        #endregion

        #region Events

        public event EventHandler<EcoMoveEventArgs> EcoReceived;

        #endregion

        #region Ctor

        public Eco()
        {
            Load();
        }

        public Eco(string xml)
        {
            if (!String.IsNullOrEmpty(xml))
            {
                LoadXml(xml);
            }
        }

        #endregion

        #region Instance
        private static Eco instance = null;
        public static Eco Instance
        {
            [DebuggerStepThrough]
            get
            {
                if (instance == null)
                {
                    instance = new Eco();
                }
                return instance;
            }
            [DebuggerStepThrough]
            set { instance = value; }
        }


        #endregion

        #region Properties

        public string White1
        {
            [DebuggerStepThrough]
            get
            {
                return Kv.Get(Kv.DataTable, "White1");
            }
            [DebuggerStepThrough]
            set
            {
                Kv.Set(Kv.DataTable, "White1", value);
            }
        }

        #endregion

        #region Load/Save

        public void Load()
        {
            Load(Ap.FileEcoMoveXml);
        }

        public void Load(string filePath)
        {
            this.Kv.ReadXml(filePath);
        }

        public void LoadXml(string xml)
        {
            MemoryStream memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(xml));
            this.Kv.ReadXml(memoryStream);
            memoryStream.Close();
        }

        public void Save()
        {
            Save(Ap.FileEcoMoveXml);
        }

        public void Save(string filePath)
        {
            this.Kv.WriteXml(filePath);
        }

        #endregion

        #region Search

        public void SearchMoves(string moves)
        {
            StartSearch(moves);
        }

        private void InitBW()
        {
            // create new worker
            this.bw = new BackgroundWorker();
            // set that it can be cancelled
            this.bw.WorkerSupportsCancellation = true;
            // install do work event
            this.bw.DoWork += new DoWorkEventHandler(bw_DoWork);
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            string moves = e.Argument.ToString();
            SearchMovesBW(moves);
        }

        public void StartSearch(string moves)
        {
            if (bw == null)
            {
                InitBW();
            }
            if (bw.IsBusy)
            {
                bw.CancelAsync();
            }

            if (!bw.IsBusy)
            {
                try
                {
                    bw.RunWorkerAsync(moves);
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                }
            }
        }

        private void SearchMovesBW(string moves)
        {
            DataView dv = Kv.DataTable.DefaultView;
            dv.RowFilter = "k = '" + moves + "'";

            if (dv.Count > 0)
            {
                string eco = dv[0]["v"].ToString();
                OnEcoReceived(moves, eco);
            }
        }

        private void OnEcoReceived(string moves, string eco)
        {
            if (EcoReceived != null)
            {
                EcoReceived(this, new EcoMoveEventArgs(moves, eco));
            }
        }

        #endregion
    }

    #region EcoMoveEventArgs

    public class EcoMoveEventArgs : EventArgs
    {
        public string Moves { get; private set; }
        public string EcoCode { get; private set; }

        public EcoMoveEventArgs(string moves, string eco)
        {
            this.Moves = moves;
            this.EcoCode = eco;
        }
    }

    #endregion
}

