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

namespace App.Model.Db 
{
    public class UserRoles : BaseItems<UserRole, UserRoles>
    {
        #region Constructors
        public UserRoles()
        {
        }

        public UserRoles(Cxt cxt)
        {
            Cxt = cxt;
        }

        public UserRoles(Cxt cxt, BaseCollection items)
        {
            Cxt = cxt;

            DataTable = items.DataTable;
        }

        public UserRoles(Cxt cxt, DataTable table)
        {
            Cxt = cxt;

            DataTable = table;
        }

        #endregion

        #region Properties

        #region Core
        public override InfiChess TableName
        {
            get { return InfiChess.UserRole; }
            set { base.TableName = value; }
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
              
        #region Methods
        public static DataTable GetAllRolesByUserID(int userID)
        {
            return BaseCollection.ExecuteSql(InfiChess.UserRole, "SELECT * FROM [UserRole] WHERE userID= " + userID,"");
        }

        public static void DeleteAllUserRoleByUserID(SqlTransaction trans, int userID)
        {
            BaseCollection.ExecuteSql(trans, InfiChess.UserRole, "Delete UserRole where userid = " + userID);
            
        }


        public void Save(UserRoles userRoles)
        {
            SqlTransaction trans = null;
            try 
	        {	        
        		trans = SqlHelper.BeginTransaction(Config.ConnectionString);
                foreach (DataRow item in userRoles.DataTable.Rows)
                {                    
                    //UserRole UserRole = new UserRole(Cxt.Instance, item);
                    DeleteAllUserRoleByUserID(trans, Convert.ToInt32(item["UserID"]));
                }
                base.Save(trans);
	         SqlHelper.CommitTransaction(trans);
            }
            catch (Exception ex)
            {
                SqlHelper.RollbackTransaction(trans);
                Log.Write(base.Cxt, ex);
            }

            
            
        }
        
        
        #endregion



    }
}
