using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Diagnostics;
/// <summary>
/// Summary description for UserFormula
/// </summary>
namespace App.Model.Db
{
    public class UserFormula : BaseItem
    {
        #region Constructor
        public UserFormula()
            : base(0)
        {
        }

        public UserFormula(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public UserFormula(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public UserFormula(Cxt cxt, DataRow row)
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
            get { return InfiChess.UserFormula; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }

        #endregion

        #region Enum
        
        #endregion

        #region Generated
        public int UserFormulaID { [DebuggerStepThrough] get { return GetColInt32("UserFormulaID"); } [DebuggerStepThrough]set { SetColumn("UserFormulaID", value); } }
        public int UserID { [DebuggerStepThrough] get { return GetColInt32("UserID"); } [DebuggerStepThrough] set { SetColumn("UserID", value); } }
        public int MinElo { [DebuggerStepThrough] get { return GetColInt32("MinElo"); } [DebuggerStepThrough] set { SetColumn("MinElo", value); } }
        public int MaxElo { [DebuggerStepThrough] get { return GetColInt32("MaxElo"); } [DebuggerStepThrough] set { SetColumn("MaxElo", value); } }
        public int MinTime { [DebuggerStepThrough] get { return GetColInt32("MinTime"); } [DebuggerStepThrough] set { SetColumn("MinTime", value); } }
        public int MaxTime { [DebuggerStepThrough] get { return GetColInt32("MaxTime"); } [DebuggerStepThrough] set { SetColumn("MaxTime", value); } }
        public int MinGainPerMove { [DebuggerStepThrough] get { return GetColInt32("MinGainPerMove"); } [DebuggerStepThrough] set { SetColumn("MinGainPerMove", value); } }
        public int MaxGainPerMove { [DebuggerStepThrough] get { return GetColInt32("MaxGainPerMove"); } [DebuggerStepThrough] set { SetColumn("MaxGainPerMove", value); } }
        public int RankID { [DebuggerStepThrough] get { return GetColInt32("RankID"); } [DebuggerStepThrough]set { SetColumn("RankID", value); } }
        public int DucatesToOverride { [DebuggerStepThrough] get { return GetColInt32("DucatesToOverride"); } [DebuggerStepThrough]set { SetColumn("DucatesToOverride", value); } }
        public bool IsUnrated { [DebuggerStepThrough] get { return GetColBool("IsUnrated"); } [DebuggerStepThrough] set { SetColumn("IsUnrated", value); } }
        public bool IsRated { [DebuggerStepThrough] get { return GetColBool("IsRated"); } [DebuggerStepThrough] set { SetColumn("IsRated", value); } }
        public bool IsDucate { [DebuggerStepThrough]get { return GetColBool("IsDucate"); } [DebuggerStepThrough] set { SetColumn("IsDucate", value); } }
        public bool IsNoComputer { [DebuggerStepThrough] get { return GetColBool("IsNoComputer"); } [DebuggerStepThrough] set { SetColumn("IsNoComputer", value); } }
        public bool IsNoCentaur { [DebuggerStepThrough] get { return GetColBool("IsNoCentaur"); } [DebuggerStepThrough] set { SetColumn("IsNoCentaur", value); } }
        public bool IsFastInternetOnly { [DebuggerStepThrough]get { return GetColBool("IsFastInternetOnly"); } [DebuggerStepThrough]set { SetColumn("IsFastInternetOnly", value); } }
        public bool IsActive { [DebuggerStepThrough] get { return GetColBool("IsActive"); } [DebuggerStepThrough] set { SetColumn("IsActive", value); } }
        #endregion

        #region Contained Classes

        #endregion

        #region Calculated

        #endregion

        #endregion 
       
        #region Methods

        #region GetUserFormulaId
        
        public static UserFormula GetUserFormulaById(Cxt cxt, int UserFormulaId)
        {
            return new UserFormula(cxt, BaseCollection.SelectItem(InfiChess.UserFormula, UserFormulaId));
        }

        public static UserFormula GetUserFormulaByUserID(Cxt cxt, int userID)
        {
            return new UserFormula(cxt, BaseCollection.SelectItem(InfiChess.UserFormula, "UserID =" + userID));
        }

        #endregion

        #endregion
    }
}