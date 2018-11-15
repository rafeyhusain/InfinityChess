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
    #region enum TaskE
    public enum TaskE
    {
        Unknown = 0,
        ViewService = 1,
        SearchItem = 2,
        NewItem = 3,
        EditItem = 4,
        DeleteItem = 5,
        ViewItem = 6,
        BrowseItem = 7,
        MyItem = 8
    } 
    #endregion

    public class Task : BaseItem
	{
        #region Constructor
        public Task()
            : base(0)
        {
        }

        public Task(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public Task(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }
        #endregion

        #region Properties

        #region Cor

        public override InfiChess TableName
        {
            [DebuggerStepThrough]
            get { return InfiChess.Task; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion
        
        #endregion

        #region Method

        #region GetTask

        public static BaseCollection GetTasks(int serviceID)
        {
            return GetTasks(serviceID, UWeb.UserName);
        }

        public static BaseCollection GetTasks(int serviceID, string userName)
        {
            string sql = "SELECT * FROM RoleTask WHERE ServiceID IN(" + serviceID + ") AND RoleID IN(SELECT RoleID FROM UserRole WHERE UserID IN(SELECT UserID FROM [User] WHERE UserName = '" + userName + "'))";

            return BaseCollection.SelectItems(InfiChess.RoleTask, sql);
        }
        
        #endregion

        #region HasTask

        public bool HasTask(TaskE taskID)
        {
            return false;
        }

        public static bool HasTask(int serviceID, TaskE taskID)
        {
            return HasTask(serviceID, UWeb.UserName, taskID);
        }

        public static bool HasTask(int serviceID, string userName, TaskE taskID)
        {
            BaseCollection items = GetTasks(serviceID, userName).Filter("TaskID=" + ((int)taskID));

            return items.Count != 0;
        }

        #endregion
        
        #endregion
    }
}
