using System;
using System.Collections.Generic;
using System.Text;
using App.Model.Db;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace App.Model
{
    #region enum
   

    #endregion

    public class ConnectionLog
    {
        #region Data Members
        public DataTable log = new DataTable();
        
        #endregion

        #region Properties
       
        #endregion

        #region Constructor

        public ConnectionLog()
        {

        }


        #endregion

        #region Instance
        private static ConnectionLog instance = null;
        public static ConnectionLog Instance
        {
            [DebuggerStepThrough]
            get
            {
                if (instance == null)
                {
                    instance = new ConnectionLog();
                }

                return instance;
            }
            [DebuggerStepThrough]
            set { instance = value; }
        }

        #endregion

        #region Methods
        public void Disconnect()
        { }

        public void Connect()
        { }
        #endregion
    }
}
