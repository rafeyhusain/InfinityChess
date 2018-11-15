// (c) Copyright RafeySoft, Karachi Pakistan. http://rafeysoft.com
// This source is subject to following License:
// http://rafeysoft.com/Web/Page/ItemEdit.aspx?sid=29&lid=4&cid=23&iid=2143
// Please write to info@rafeysoft.com for more information
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Web;
using System.Diagnostics;
namespace App.Model.Db 
{
    public enum KeyValueE
    { 
        UrlInfiChess =1,
        RoomUrl =2,
        TournamentUrl=3,
        NewsUrl =4,
        MinTournamentRank=5,
        TournamentEditUrl = 6,
        RefreshIntervalOnlineClient = 7,
        TournamentResultUrl = 8,
        ForthcommingTournaments = 9,
        InProgressTournaments = 10,
        FillPayment = 11,
        ContactEmails = 12,
        OrderUrl = 13,
        PaymentUrl = 14,
        CurrentVersionNo = 15,
        PatchUrl = 16,
        FinishedTournaments = 17,
        TeamEditUrl = 18,
        TeamListUrl = 19,
        UserUrl = 20,
        TimeOut = 21,
        Heartbeat = 22,
        LogUrl = 23,
        AdminNewsUrl = 24,
        AdminRoomsUrl = 25,
        ServerMaintainceDateTime = 26,
        PatchPath = 27
    }

    public class KeyValues : BaseItems<KeyValue, KeyValues>
    {
        #region DataMember

        private static KeyValues instance = null;
        public static bool IsRequestFromServer = false;

        #endregion
      
        #region Core

        public override InfiChess TableName
        {
            [DebuggerStepThrough]
            get { return InfiChess.KeyValue; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion

        #region Properties
        
        public static KeyValues Instance
        {
            [DebuggerStepThrough]
            get
            {
                if (HttpContext.Current == null && !IsRequestFromServer)
                {
                    if (instance == null)
                    {
                        DataSet ds = SocketClient.GetKeyValues();
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            instance = new KeyValues(Cxt.Instance, ds.Tables[0]);
                        }
                    }
                }
                else
                {
                    instance = new KeyValues(Cxt.Instance, KeyValues.GetKeyValues());
                }

                return instance;
            }
            [DebuggerStepThrough]
            set { instance = value; }
        }

        #endregion

        #region Constructors

        public KeyValues()
        {
        }

        public KeyValues(Cxt cxt)
        {
            Cxt = cxt;
        }

        public KeyValues(Cxt cxt, BaseCollection items)
        {
            Cxt = cxt;

            DataTable = items.DataTable;
        }

        public KeyValues(Cxt cxt, DataTable table)
        {
            Cxt = cxt;

            DataTable = table;
        }

        #endregion

        #region Methods
        
        public static void Reresh()
        {
            DataSet ds = SocketClient.GetKeyValues();
            if (ds != null && ds.Tables.Count > 0)
            {
                instance = new KeyValues(Cxt.Instance, ds.Tables[0]);
            }
        }

        public static DataTable GetKeyValues()
        {
            return BaseCollection.ExecuteSql(InfiChess.KeyValue, "SELECT * FROM [KeyValue]", "");
        }

        public KeyValue GetKeyValue(string keyName)
        {
            KeyValue item = new KeyValue(this.Cxt, GetRow(keyName));

            return item;
        }

        public KeyValue GetKeyValue(KeyValueE id)
        {
            KeyValue item = new KeyValue(this.Cxt, GetRow((int) id));

            return item;
        }

        public static string GetUrl(KeyValueE keyValueID)
        {
            string url = KeyValues.Instance.GetKeyValue(keyValueID).Value;

            if (!String.IsNullOrEmpty(url))
            {
                url = url + "&UserID=" + Ap.CurrentUserID;
            }

            return url;
        }

        public static string GetTitle(KeyValueE keyValueID)
        {
            string title = "";

            switch (keyValueID)
            {
                case KeyValueE.TournamentUrl:
                    title = "Tournament";
                    break;
                case KeyValueE.TournamentEditUrl:
                    title = "New Tournament";
                    break;
                case KeyValueE.ForthcommingTournaments:
                    title = "Forthcomming Tournaments";
                    break;
                case KeyValueE.InProgressTournaments:
                    title = "InProgress Tournaments";
                    break;
                case KeyValueE.FinishedTournaments:
                    title = "Finished Tournaments";
                    break;
                case KeyValueE.OrderUrl:
                    title = "Order";
                    break;
                case KeyValueE.TeamEditUrl:
                    title = "New Team";
                    break;
                case KeyValueE.TeamListUrl:
                    title = "Teams";
                    break;
                case KeyValueE.UserUrl:
                    title = "Users";
                    break;
                case KeyValueE.AdminNewsUrl:
                    title = "News";
                    break;
                case KeyValueE.AdminRoomsUrl:
                    title = "Rooms";
                    break;
                case KeyValueE.LogUrl:
                    title = "Log";
                    break;
               
                default:
                    break;
            }
            return title;
        }

        public KeyValue this[KeyValueE id]
        {
            get { return this.GetKeyValue(id); }
        }
        #endregion

        #region Helpers

        private DataRow GetRow(string keyName)
        {
            DataRow[] rows = DataTable.Select("KeyName='" + keyName + "'");

            if (rows.Length > 0)
            {
                return rows[0];
            }

            return null;
        }

        private DataRow GetRow(int id)
        {
            DataRow[] rows = DataTable.Select("KeyValueID='" + id.ToString("d")+"'");

            if (rows.Length > 0)
            {
                return rows[0];
            }

            return null;
        }

        #endregion

    }
}
