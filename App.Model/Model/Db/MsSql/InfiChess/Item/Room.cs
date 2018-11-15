using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Room
/// </summary>
namespace App.Model.Db
{
    public enum RoomE : int
    {
        ClassicalChess = 1,
        MainPlayingHall = 2,
        Cafe = 3,
        Training = 4,
        Beginners = 5,
        Broadcasts = 6,
        HumanTournaments = 7,
        ComputerChess = 8,
        EngineHall = 9,
        FreestyleChess = 10,
        TestRoom = 11,
        EngineTournaments = 12,
        CorrespondenceChess = 13,
        Clubs = 14,
        ServerNews = 15
    }

    public class Room : BaseItem
    {
        #region Constructor
        public Room()
            : base(0)
        {
        }

        public Room(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public Room(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public Room(Cxt cxt, DataRow row)
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
            get { return InfiChess.Room; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion

        #region Enum
        public StatusE StatusIDE { [DebuggerStepThrough] get { return (StatusE)this.StatusID; } [DebuggerStepThrough] set { this.StatusID = (int)value; } }
        #endregion

        #region Generated
        public int RoomID { [DebuggerStepThrough]get { return GetColInt32("RoomID"); } [DebuggerStepThrough] set { SetColumn("RoomID", value); } }
        public int ParentID { [DebuggerStepThrough] get { return GetColInt32("ParentID"); } [DebuggerStepThrough] set { SetColumn("ParentID", value); } }
        public int StatusID { [DebuggerStepThrough] get { return GetColInt32("StatusID"); } [DebuggerStepThrough]set { SetColumn("StatusID", value); } }
        public string Html { [DebuggerStepThrough] get { return GetCol("Html"); } [DebuggerStepThrough] set { SetColumn("Html", value); } }
        public bool IsGuestAllow { [DebuggerStepThrough] get { return GetColBool("IsGuestAllow"); } [DebuggerStepThrough]set { SetColumn("IsGuestAllow", value); } }
        public bool CanTakeBackMove { [DebuggerStepThrough]get { return GetColBool("CanTakeBackMove"); } [DebuggerStepThrough]set { SetColumn("CanTakeBackMove", value); } }
        public int TournamentID { [DebuggerStepThrough]get { return GetColInt32("TournamentID"); } [DebuggerStepThrough]set { SetColumn("TournamentID", value); } }
        public bool IsUrlBit { [DebuggerStepThrough]get { return GetColBool("IsUrlBit"); } [DebuggerStepThrough]set { SetColumn("IsUrlBit", value); } }
        #endregion

        #region Contained Classes

        #endregion

        #region Calculated

        #endregion

        #endregion 
       
        #region Methods

        #region GetRoom/Tournament..Id

        public static Room GetRoomById(Cxt cxt, int roomId)
        {
            return new Room(cxt, BaseCollection.SelectItem(InfiChess.Room, roomId));
        }

        public static Room GetRoomByName(Cxt cxt, int roomName)
        {
            return new Room(cxt, BaseCollection.SelectItem(InfiChess.Room, "Name = "+ roomName));
        }

        public static Room GetRoomByTournamentID(Cxt cxt, int tournamentID)
        {
            return new Room(cxt, BaseCollection.SelectItem(InfiChess.Room, "TournamentID =" + tournamentID));
        }

        public static Room GetRoomByTournamentID(Cxt cxt, ChessTypeE chessTypeE)
        {
            Room Room = null;
            if (chessTypeE == ChessTypeE.Human)
            {
                Room = new Room(cxt, BaseCollection.SelectItem(InfiChess.Room, "ParentID = 7 and (TournamentID is NULL or TournamentID = 0) "));
            }
            else if (chessTypeE == ChessTypeE.Engine)
            {
                Room = new Room(cxt, BaseCollection.SelectItem(InfiChess.Room, "ParentID = 12 and (TournamentID is NULL or TournamentID = 0) "));
            }
            return Room;
        }

        #endregion


        public static Room GetTournamentRoom(Cxt cxt, Tournament tournament)
        {
            Room Room = GetRoomByTournamentID(cxt, tournament.ChessTypeIDE);

            if (Room.RoomID == 0)
            {
                Room = GetRoomById(cxt, 0);
                Room.Name = tournament.Name;
                Room.TournamentID = tournament.TournamentID;
                Room.IsGuestAllow = false;
                Room.IsUrlBit = false;
                Room.StatusIDE = StatusE.Active;             
            }
            else 
            {                
                Room.TournamentID = tournament.TournamentID;
                Room.Name = tournament.Name;
                Room.StatusIDE = StatusE.Active;
            }
            if (tournament.ChessTypeIDE == ChessTypeE.Human)
            {
                Room.ParentID = 7;
            }
            else if (tournament.ChessTypeIDE == ChessTypeE.Engine)
            {
                Room.ParentID = 12;
            }
            return Room;            
        }

        #endregion
    }
}