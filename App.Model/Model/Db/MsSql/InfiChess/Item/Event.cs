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
using System.Diagnostics;
namespace App.Model.Db
{
    #region EventTypeE
    
    public enum EventTypeE
    {
        Unknown = 0,
        Tournament = 1,
        Broadcast = 2,
        Relay = 3,
        Simul = 4,
        Media = 5
    }

    #endregion
   
    public class Event : BaseItem
    {
        #region Constructor
        public Event()
            : base(0)
        {
        }

        public Event(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public Event(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public Event(Cxt cxt, DataRow row)
        {
            Cxt = cxt;
            DataRow = row;
        }

        #endregion

        #region Properties

        #region Core
        public override InfiChess TableName
        {
            [DebuggerStepThrough]
            get { return InfiChess.Event; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion

        #region Enum

        public EventTypeE EventTypeIDE { get { return (EventTypeE)this.EventTypeID; } set { this.EventTypeID = (int)value; } }
        public StatusE StatusIDE { get { return (StatusE)this.StatusID; } set { this.StatusID = (int)value; } }

        #endregion
                
        #region Generated
        public int EventID { [DebuggerStepThrough] get { return GetColInt32("EventID"); } [DebuggerStepThrough] set { SetColumn("EventID", value); } }
        public int RoomID { [DebuggerStepThrough]get { return GetColInt32("RoomID"); } [DebuggerStepThrough]set { SetColumn("RoomID", value); } }
        public int EventTypeID { [DebuggerStepThrough] get { return GetColInt32("EventTypeID"); } [DebuggerStepThrough] set { SetColumn("EventTypeID", value); } }
        public int EventObjectID { [DebuggerStepThrough] get { return GetColInt32("EventObjectID"); } [DebuggerStepThrough]set { SetColumn("EventObjectID", value); } }
        public int StatusID { [DebuggerStepThrough] get { return GetColInt32("StatusID"); } [DebuggerStepThrough] set { SetColumn("StatusID", value); } }
        public DateTime EventDate { [DebuggerStepThrough] get { return GetColDateTime("EventDate"); } [DebuggerStepThrough] set { SetColumn("EventDate", value); } }
        public DateTime EventTime { [DebuggerStepThrough] get { return GetColDateTime("EventTime"); } [DebuggerStepThrough]set { SetColumn("EventTime", value); } }        
        #endregion

        #region Contained Classes

        #endregion

        #region Calculated

        #endregion
        #endregion 
        
        #region Methods
        public static Event GetEventID(Cxt cxt, int eventID)
        {
            return new Event(cxt, BaseCollection.SelectItem(InfiChess.Event, eventID));
        }
        public static Event GetEventByTournamentID(Cxt cxt, int tournamentID)
        {
            return new Event(cxt, BaseCollection.SelectItem(InfiChess.Event, " EventObjectID= "+ tournamentID));
        }
        #endregion
    }
}
