using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using App.Model.Db;
using System.Drawing;
using System.IO;
using System.Data.SqlClient;
using System.Diagnostics;
namespace App.Model
{
    public class UserFormulaDataKv : BaseDataKv
    {
        #region Properties

        #region Core

        #endregion

        #region Enum
        #endregion

        #region Generated
        public int UserFormulaID { [DebuggerStepThrough]get { return base.Kv.GetInt32("UserFormulaID"); } [DebuggerStepThrough]set { base.Kv.Set("UserFormulaID", value); } }
        public int UserID { [DebuggerStepThrough]get { return base.Kv.GetInt32("UserID"); } [DebuggerStepThrough]set { base.Kv.Set("UserID", value); } }
        public int MinElo { [DebuggerStepThrough]get { return base.Kv.GetInt32("MinElo"); } [DebuggerStepThrough]set { base.Kv.Set("MinElo", value); } }
        public int MaxElo { [DebuggerStepThrough]get { return base.Kv.GetInt32("MaxElo"); } [DebuggerStepThrough]set { base.Kv.Set("MaxElo", value); } }
        public int MinTime { [DebuggerStepThrough]get { return base.Kv.GetInt32("MinTime"); } [DebuggerStepThrough]set { base.Kv.Set("MinTime", value); } }
        public int MaxTime { [DebuggerStepThrough]get { return base.Kv.GetInt32("MaxTime"); } [DebuggerStepThrough]set { base.Kv.Set("MaxTime", value); } }
        public int MinGainPerMove { [DebuggerStepThrough]get { return base.Kv.GetInt32("MinGainPerMove"); } [DebuggerStepThrough]set { base.Kv.Set("MinGainPerMove", value); } }
        public int MaxGainPerMove { [DebuggerStepThrough]get { return base.Kv.GetInt32("MaxGainPerMove"); } [DebuggerStepThrough]set { base.Kv.Set("MaxGainPerMove", value); } }
        public int RankID { [DebuggerStepThrough]get { return base.Kv.GetInt32("RankID"); } [DebuggerStepThrough] set { base.Kv.Set("RankID", value); } }
        public int DucatesToOverride { [DebuggerStepThrough]get { return base.Kv.GetInt32("DucatesToOverride"); } [DebuggerStepThrough] set { base.Kv.Set("DucatesToOverride", value); } }
        public bool IsUnrated { [DebuggerStepThrough]get { return base.Kv.GetBool("IsUnrated"); } [DebuggerStepThrough] set { base.Kv.Set("IsUnrated", value); } }
        public bool IsRated { [DebuggerStepThrough]get { return base.Kv.GetBool("IsRated"); } [DebuggerStepThrough] set { base.Kv.Set("IsRated", value); } }
        public bool IsDucate { [DebuggerStepThrough]get { return base.Kv.GetBool("IsDucate"); } [DebuggerStepThrough]set { base.Kv.Set("IsDucate", value); } }
        public bool IsNoComputer { [DebuggerStepThrough]get { return base.Kv.GetBool("IsNoComputer"); } [DebuggerStepThrough] set { base.Kv.Set("IsNoComputer", value); } }
        public bool IsNoCentaur { [DebuggerStepThrough]get { return base.Kv.GetBool("IsNoCentaur"); } [DebuggerStepThrough] set { base.Kv.Set("IsNoCentaur", value); } }
        public bool IsFastInternetOnly { [DebuggerStepThrough]get { return base.Kv.GetBool("IsFastInternetOnly"); } [DebuggerStepThrough]set { base.Kv.Set("IsFastInternetOnly", value); } }
        public bool IsActive { [DebuggerStepThrough]get { return base.Kv.GetBool("IsActive"); } [DebuggerStepThrough]set { base.Kv.Set("IsActive", value); } } 
        #endregion

        #region Contained Classes
        
        #endregion

        #region Calculated

        #endregion
        #endregion

        #region Constructor
        public UserFormulaDataKv()
        {
            Kv = new Kv(KvType.Web);
        }

        public UserFormulaDataKv(Kv kv)
        {
            base.Kv = kv;
        }

        #endregion

        #region Methods
        public DataTable UpdateFormula()
        {
            UserFormula item;

            try
            {
                string selectQuery;
                DataTable table;
                selectQuery = "SELECT TOP 1 * FROM UserFormula WHERE UserID = @p1";
                table = BaseCollection.ExecuteSql(InfiChess.UserFormula, selectQuery, UserID);
                
                if (table != null && table.Rows.Count > 0)
                {
                    item = new UserFormula(base.Kv.Cxt, table.Rows[0]);
                }
                else
                {
                    item = new UserFormula();
                }

                item.Cxt = base.Kv.Cxt;
                item.UserID = UserID;

                item.IsUnrated = IsUnrated;
                item.IsRated = IsRated;
                item.IsDucate = IsDucate;

                item.IsNoComputer = IsNoComputer;
                item.IsNoCentaur = IsNoCentaur;
                item.IsFastInternetOnly = IsFastInternetOnly;

                item.MinElo = MinElo;
                item.MaxElo = MaxElo;

                item.MinTime = MinTime;
                item.MaxTime = MaxTime;

                item.MinGainPerMove = MinGainPerMove;
                item.MaxGainPerMove = MaxGainPerMove;

                item.RankID = RankID;
                item.DucatesToOverride = DucatesToOverride;
                item.IsActive = IsActive;

                item.Cxt.CurrentUserID = base.Kv.Cxt.CurrentUserID;

                item.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Challenges.GetChallengesByRoomID(item.Cxt, base.Kv.GetInt32("RoomID"), item.Cxt.CurrentUserID);
        }
        #endregion

    }
}
