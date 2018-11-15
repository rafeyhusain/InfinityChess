using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Diagnostics;

namespace App.Model.Db
{
    public class BlockedIpItem : BaseItems<BlockedIP, BlockedIpItem>
    {

        #region Constructors
        public BlockedIpItem()
        {
        }

        public BlockedIpItem(Cxt cxt)
        {
            Cxt = cxt;
        }

        public BlockedIpItem(Cxt cxt, BaseCollection items)
        {
            Cxt = cxt;

            DataTable = items.DataTable;
        }

        public BlockedIpItem(Cxt cxt, DataTable table)
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
                return InfiChess.News;
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
        
        #region Methods
        public static DataTable GetAllBlockedIPs()
        {
            return BaseCollection.ExecuteSql(InfiChess.BlockedIP, "SELECT * FROM BlockedIP");
        }
        public static DataTable UnBlockedIPs(string parm)
        {
            // status id is deleted
            StringBuilder sb = new StringBuilder();

            sb.Append("Delete FROM BlockedIP ").Append(" WHERE BlockedIPID in (").Append(parm).Append(")");

            return BaseCollection.ExecuteSql(sb.ToString());
        }
        #endregion


        

    }
}
