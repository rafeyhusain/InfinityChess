// (c) Copyright RafeySoft, Karachi Pakistan. http://rafeysoft.com
// This source is subject to following License:
// http://rafeysoft.com/Web/Page/ItemEdit.aspx?sid=29&lid=4&cid=23&iid=2143
// Please write to info@rafeysoft.com for more information
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace App.Model
{
    public class AppException
    {
        #region Method
        
        #region Throw
        
        public static string Throw(Exception ex)
        {
            throw ex;
        }
        public static void Throw(string message)
        {
            throw new Exception(message);
        }
        public static void Throw(Exception ex, SqlCommand cmd)
        {
            Throw(new Exception(ex.Message + " - " + UStr.ToString(cmd) + " - " + GetError(ex), ex));
        }
        
        #endregion

        #region GetError

        public static string GetError(Exception ex)
        {
            return GetError(ex, "");
        }

        public static string GetError(Exception ex, string message)
        {
            StringBuilder s = new StringBuilder();

            if (!String.IsNullOrEmpty(message))
            {
                s.AppendLine(message);
                s.AppendLine();
            }

            if (ex != null)
            {
                s.AppendLine(ex.Message);
                s.AppendLine(ex.StackTrace);

                if (ex.InnerException != null)
                {
                    s.AppendLine();
                    s.AppendLine("**** Inner Exception ****");

                    s.AppendLine(GetError(ex.InnerException));
                }
            }

            return s.ToString();
        }
        
        #endregion
       
        #endregion
    }
}
