using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;
namespace App.Model.Db 
{
    public class Events : BaseItems<Event, Events>
    {
        #region Constructors
        public Events()
        {
        }

        public Events(Cxt cxt)
        {
            Cxt = cxt;
        }

        public Events(Cxt cxt, BaseCollection items)
        {
            Cxt = cxt;

            DataTable = items.DataTable;
        }

        public Events(Cxt cxt, DataTable table)
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
            get
            {
                return InfiChess.Event;
            }
            [DebuggerStepThrough]
            set
            {
                base.TableName = value;
            }
        }

        #endregion

        #region Enum

        #endregion

        #region Generated
        #endregion

        #region Contained Classes

        #endregion

        #region Calculated

        #endregion
        #endregion 

        #region Properties
        

        #endregion

        #region Methods
        public static DataTable GetAllEvent()
        {
            return BaseCollection.ExecuteSql(InfiChess.Event, "SELECT * FROM Event where statusID <> 4", "");
        }

        public static DataTable UpdateStatus(StatusE statusID, string eventIDs)
        {
            // status id is deleted
            StringBuilder sb = new StringBuilder();
            sb.Append("update Event set statusid = ").Append(statusID.ToString("d")).Append(" WHERE EventID in (").Append(eventIDs).Append(")");
            return BaseCollection.ExecuteSql(sb.ToString());
        }

        #endregion
    }
}
