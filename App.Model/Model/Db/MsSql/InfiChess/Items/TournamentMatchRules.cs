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
using System.Diagnostics;

namespace App.Model.Db 
{
    public class TournamentMatchRules : BaseItems<TournamentMatchRule, TournamentMatchRules>
    {
        #region Constructors
        public TournamentMatchRules()
        {
        }

        public TournamentMatchRules(Cxt cxt)
        {
            Cxt = cxt;
        }

        public TournamentMatchRules(Cxt cxt, BaseCollection items)
        {
            Cxt = cxt;

            DataTable = items.DataTable;
        }

        public TournamentMatchRules(Cxt cxt, DataTable table)
        {
            Cxt = cxt;

            DataTable = table;
        }

        #endregion

        #region Properties
        #region Core
        public override InfiChess TableName
        {
            [DebuggerStepThrough]
            get { return InfiChess.TournamentMatchRule; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }
        #endregion
        #endregion

        private static TournamentMatchRules instance = null;

        public static TournamentMatchRules Instance
        {
            [DebuggerStepThrough]
            get
            {
                if (instance == null)
                {
                    instance = GetTournamentMatchRules();
                }

                return instance;
            }
            [DebuggerStepThrough]
            set { instance = value; }
        }


        #region Methods

        public static TournamentMatchRules GetTournamentMatchRules()
        {
            return new TournamentMatchRules(Cxt.Instance, BaseCollection.ExecuteSql("SELECT * FROM TournamentMatchRule"));
        }

        public bool CanChangeStatus(TournamentMatchStatusE currentStatusID, TournamentMatchStatusE requiredStatusID)
        {
            TournamentMatchRule item = GetTournamentMatchRule(currentStatusID);

            return item.GetColInt32(requiredStatusID.ToString()) == 1;
        }

        public TournamentMatchRule GetTournamentMatchRule(TournamentMatchStatusE status)
        {
            TournamentMatchRule item = new TournamentMatchRule(this.Cxt, GetRow(status));

            return item;
        }
        #endregion

        #region Helpers

        private DataRow GetRow(TournamentMatchStatusE status)
        {
            DataRow[] rows = DataTable.Select("TournamentMatchRuleID = " + status.ToString("d"));

            if (rows.Length > 0)
            {
                return rows[0];
            }

            return null;
        }

        #endregion


    }
}
