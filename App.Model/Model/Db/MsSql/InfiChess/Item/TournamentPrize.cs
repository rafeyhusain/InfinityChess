using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using App.Model.Db;
using System.Diagnostics;
namespace App.Model
{

    public enum TournamentPrizeCategoryE
    {
        Unknown = 0,
        Fini = 1,        
        Euro = 2,
        Dollar = 3        
    }

    public class TournamentPrize  : BaseItem
    {
        #region Constructor
        public TournamentPrize()
             : base(0)
        {
        }

        public TournamentPrize(Cxt cxt, int id)
             : base(cxt, id)
        {
        }

        public TournamentPrize(Cxt cxt, BaseItem item)
             : base(cxt, item)
        {
        }

        public TournamentPrize(Cxt cxt, DataRow row)
        {
            Cxt = cxt;

            DataRow = row;
        }

        #region Cor
        public override InfiChess TableName
        {
            [DebuggerStepThrough]
            get { return InfiChess.TournamentPrize; }
            [DebuggerStepThrough]
            set { base.TableName = value; }
        }
        #endregion
       
        #endregion

        #region Properties

        #region GetPrize
        public static string GetPrize(string prizePosition)
        {
            switch (prizePosition)
            {
                case "1":
                    return "1st";                    
                case "2":
                    return "2nd";                    
                case "3":
                    return "3rd";                    
                case "4":
                    return "4rth";                    
                case "5":
                    return "5th";                    
                case "6":
                    return "6th";                    
                case "7":
                    return "7th";                    
                case "8":
                    return "8th";                    
                case "9":
                    return "9th";
                case "10":
                    return "10th";

            }
            return "10th";
        }
        #endregion

        #region GetPrizeCategory
        public static string GetPrizeCategory(string TournamentPrizeCategoryID)
        {
            TournamentPrizeCategoryE TournamentPrizeCategoryIDE = (TournamentPrizeCategoryE)
                Enum.ToObject(typeof(TournamentPrizeCategoryE), Convert.ToInt32(TournamentPrizeCategoryID));

            switch (TournamentPrizeCategoryIDE)
            {
                case TournamentPrizeCategoryE.Unknown:
                    return TournamentPrizeCategoryE.Unknown.ToString();                    
                case TournamentPrizeCategoryE.Fini:
                    return TournamentPrizeCategoryE.Fini.ToString();                    
                case TournamentPrizeCategoryE.Euro:
                    return TournamentPrizeCategoryE.Euro.ToString();                    
                case TournamentPrizeCategoryE.Dollar:
                    return TournamentPrizeCategoryE.Dollar.ToString();                    
                default:
                    break;
            }
            return TournamentPrizeCategoryID.ToString();
        }
        #endregion

        #region Generated
        public int TournamentPrizeID { get { return GetColInt32("TournamentPrizeID"); } set { SetColumn("TournamentPrizeID", value); } }
        public int TournamentID { get { return GetColInt32("TournamentID"); } set { SetColumn("TournamentID", value); } }
        public int TournamentPrizeCategoryID { get { return GetColInt32("TournamentPrizeCategoryID"); } set { SetColumn("TournamentPrizeCategoryID", value); } }
        public decimal PrizeAmount { get { return GetColDecimal("PrizeAmount"); } set { SetColumn("PrizeAmount", value); } }
        public int PrizePosition { get { return GetColInt32("PrizePosition"); } set { SetColumn("PrizePosition", value); } }
        #endregion

        #region Containted
        public TournamentPrizeCategoryE TournamentPrizeCategoryIDE { [DebuggerStepThrough]get { return (TournamentPrizeCategoryE)TournamentPrizeCategoryID; } [DebuggerStepThrough] set { this.TournamentPrizeCategoryID = (int)value; } }
        #endregion

        #endregion

        #region Methods
        public static TournamentPrize GetTournamentPrizeID(Cxt cxt, int TournamentPrizeID)
        {
            return new TournamentPrize(cxt, BaseCollection.SelectItem(InfiChess.TournamentPrize, TournamentPrizeID));                
        }
        
        #endregion
        
    }
}
