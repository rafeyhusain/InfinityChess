using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.ComponentModel;
using App.Model;

namespace App.Model
{
    public class UCIEngineValidator
    {
        #region Data Members

        public Game Game = null;                
        UCIEngine uciEngine;
        System.Windows.Forms.Timer tmr;

        string filePath;
        int ticks = 0;
        bool isUciOk = false;

        #endregion

        #region Delegates and Events

        public event UCIEngine.NameReceivedHandler NameReceived;
        public event UCIEngine.AuthorReceivedHandler AuthorReceived;
        
        public event EventHandler UciValidated;
        public event EventHandler UciInvalidated;

        #endregion

        #region Ctor
        
        public UCIEngineValidator(string engineFile,Game game)
        {
            this.Game = game;
            this.filePath = engineFile;
        }

        #endregion
        
        #region Helpers Methods 
        
        public void Validate()
        {
            uciEngine = new UCIEngine(filePath, Options.DefaultHashTableSize, this.Game);
            uciEngine.UciOkReceived += new EventHandler(uciEngine_UciOkReceived);
            uciEngine.NameReceived += new UCIEngine.NameReceivedHandler(uciEngine_NameReceived);
            uciEngine.AuthorReceived += new UCIEngine.AuthorReceivedHandler(uciEngine_AuthorReceived);
            uciEngine.Load();

            isUciOk = false;
            InitTimer();
        }

        protected void InitTimer()
        {
            tmr = new System.Windows.Forms.Timer();
            tmr.Interval = 1000;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Start();
            ticks = 0;
        }

        private void OnUciValidated()
        {
            if (UciValidated != null)
            {
                UciValidated(this, EventArgs.Empty);
            }
        }

        private void OnUciInvalidated()
        {
            if (UciInvalidated != null)
            {
                UciInvalidated(this, EventArgs.Empty);
            }
        }

        #endregion

        #region Events 
                
        void tmr_Tick(object sender, EventArgs e)
        {
            tmr.Stop();

            if (isUciOk && ticks == 3) // if engine is valid, wait for 1,2 seconds.. then close engine
            {
                uciEngine.Close();
                OnUciValidated();
                return;
            }

            ticks++;

            if (ticks == 1) // wait for one second... let the engine loaded, then send uci
            {
                uciEngine.SendUci();
            }

            if (ticks >= 3 && !isUciOk) // if uci ok not received in next 2 seconds, then engine is not valid.
            {
                uciEngine.Close();
                OnUciInvalidated();
                return;
            }

            tmr.Start();
        }

        void uciEngine_UciOkReceived(object sender, EventArgs e)
        {
            isUciOk = true;
        }

        void uciEngine_NameReceived(object sender, UCIMessageEventArgs e)
        {
            if (NameReceived != null)
            {
                NameReceived(this, e);
            }
            isUciOk = true;
        }

        void uciEngine_AuthorReceived(object sender, UCIMessageEventArgs e)
        {
            if (AuthorReceived != null)
            {
                AuthorReceived(this, e);
            }
            isUciOk = true;
        }

        #endregion

    }
}
