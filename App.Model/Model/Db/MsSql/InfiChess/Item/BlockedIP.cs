using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;
namespace App.Model.Db
{
    public class BlockedIP : BaseItem
    {
        #region Constructor
        public BlockedIP()
            : base(0)
        {
        }

        public BlockedIP(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public BlockedIP(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public BlockedIP(Cxt cxt, DataRow row)
        {
            Cxt = cxt;

            DataRow = row;
        }

       
        #endregion

        #region Properties

        #region Core
        public override InfiChess TableName { [DebuggerStepThrough] get { return InfiChess.BlockedIP; } [DebuggerStepThrough] set { base.TableName = value; } }
        #endregion

        #region Enum
        #endregion

        #region Generated
        public int BlockedIPID { [DebuggerStepThrough] get { return GetColInt32("BlockedIPID"); } [DebuggerStepThrough] set { SetColumn("BlockedIPID", value); } }
        public int MidifiedBy { [DebuggerStepThrough] get { return GetColInt32("MidifiedBy"); } [DebuggerStepThrough] set { SetColumn("MidifiedBy", value); } }
        public string IPAddress { [DebuggerStepThrough] get { return GetCol("IPAddress"); } [DebuggerStepThrough] set { SetColumn("IPAddress", value); } }
        #endregion

        #region Contained Classes
        #endregion

        #region Calculated
        #endregion

        #endregion

        #region Methods
        public static BlockedIP GetBlockedIPsById(Cxt cxt, int BlockedIPsId)
        {
            return new BlockedIP(cxt, BaseCollection.SelectItem(InfiChess.BlockedIP, BlockedIPsId));
        }
        #endregion
    }
}
