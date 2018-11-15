using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using App.Model.Db;
namespace App.Model
{
    public partial class SocketClient
    {
        public static DataSet GetAllRoomsWithRelationShip()
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetAllRoomsWithRelationShip);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable.Copy());
            return ds;
        }
        public static DataSet GetAllRoomsWithNullTournament()
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetAllRoomsWithNullTournament);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable.Copy());
            return ds;
        }
        public static void SaveRoom(int roomID,int parentID, string txtName, string html, bool canTakeMove, bool isUrlBit, bool isGuestAllow)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.SaveRoom);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("RoomID", roomID);
            kv.Set("ParentID", parentID);
            kv.Set("Name", txtName);
            kv.Set("Html", html);
            kv.Set("CanTakeBackMove", canTakeMove);
            kv.Set("IsUrlBit", isUrlBit);
            kv.Set("IsGuestAllow", isGuestAllow);
            
            SocketClient.Instance.Invoke(kv.DataTable);
        }
        public static void UpdateRoomStatus(StatusE statusID, string roomIDs)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.UpdateRoomStatus);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("RoomIDs", roomIDs);
            kv.Set("StatusID", statusID.ToString("d"));
            SocketClient.Instance.InvokeAsync(kv.DataTable.Copy());
        }
        public static Room GetRoomByID(int roomID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetRoomByID);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("RoomID", roomID);

            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable);

            if (ds == null)
            {
                return null;
            }

            if (ds.Tables.Count == 0)
            {
                return null;
            }

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }

            Room r = new Room(Ap.Cxt, ds.Tables[0].Rows[0]);

            if (roomID > 0)
            {
                ds.Tables[0].Rows[0].AcceptChanges();
                ds.Tables[1].Rows[0].AcceptChanges();

                User u = new User(Ap.Cxt, ds.Tables[1].Rows[0]);

                r.CreatedUser = u;
            }

            return r;
        } 
    }
}
