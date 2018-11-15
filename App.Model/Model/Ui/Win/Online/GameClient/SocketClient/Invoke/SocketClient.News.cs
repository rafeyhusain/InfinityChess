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
        public static DataSet GetAllNews()
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetAllNews);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable.Copy());
            return ds;
        }
        public static DataSet GetAllNewsCategory()
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetAllNewsCategory);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable.Copy());
            return ds;
        }
        public static void SaveNews(string txtName, string txtDescription,int cmbNewsCategoryID,int newsID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.SaveNews);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            //kv.Set("TeamDetail", UData.ToString(dt));
            kv.Set("NewsName", txtName);
            kv.Set("NewsDescription", txtDescription);
            kv.Set("NewsCategoryID", cmbNewsCategoryID);
            kv.Set("NewsID", newsID);
            SocketClient.Instance.Invoke(kv.DataTable);
        }
        public static void UpdateNewsStatus(StatusE statusID, string newsIds)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.UpdateNewsStatus);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("NewsIDs", newsIds);
            kv.Set("StatusID", statusID.ToString("d"));
            SocketClient.Instance.InvokeAsync(kv.DataTable.Copy());
        }
        public static News GetNewsByID(int newsID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetNewsByID);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("NewsID", newsID);

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

            News n = new News(Ap.Cxt, ds.Tables[0].Rows[0]);

            if (newsID > 0)
            {
                ds.Tables[0].Rows[0].AcceptChanges();
                ds.Tables[1].Rows[0].AcceptChanges();

                User u = new User(Ap.Cxt, ds.Tables[1].Rows[0]);

                n.CreatedUser = u;
            }

            return n;
        } 
    }
}
