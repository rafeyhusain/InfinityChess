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
        public static DataSet GetAllTeam()
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetAllTeam);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);

            return SocketClient.Instance.Invoke(kv.DataTable);
        }

        public static void UpdateTeamStatus(StatusE statusID, string teamIds)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.UpdateTeamStatus);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("TeamIds", teamIds);
            kv.Set("StatusID", statusID.ToString("d"));
            SocketClient.Instance.InvokeAsync(kv.DataTable.Copy());
        }
        public static void UpdateTeamDetail(string txtTeamNaem, string txtDescription)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.ChangePassword);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("UserId", Ap.CurrentUserID);
            kv.Set("TeamName", txtTeamNaem);
            kv.Set("Description", txtDescription);
            SocketClient.Instance.InvokeAsync(kv.DataTable);
        }
        public static void SaveTeam(string txtTeamNaem, string txtDescription,int teamID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.SaveTeam);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            //kv.Set("TeamDetail", UData.ToString(dt));
            kv.Set("TeamName", txtTeamNaem);
            kv.Set("TeamDescription", txtDescription);
            kv.Set("TeamID", teamID);
            SocketClient.Instance.Invoke(kv.DataTable);
        }
        public static Team GetTeamByID(int teamID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetTeamByID);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("TeamID", teamID);

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

            Team t = new Team(Ap.Cxt, ds.Tables[0].Rows[0]);

            if (teamID > 0)
            {
                ds.Tables[0].Rows[0].AcceptChanges();
                ds.Tables[1].Rows[0].AcceptChanges();

                User u = new User(Ap.Cxt, ds.Tables[1].Rows[0]);

                t.CreatedUser = u;
            }

            return t;
        } 
        
    }
}
