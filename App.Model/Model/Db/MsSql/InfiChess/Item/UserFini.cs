using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Room
/// </summary>
namespace App.Model.Db
{
    public class UserFini : BaseItem
    {
        #region Constructor
        public UserFini()
            : base(0)
        {
        }

        public UserFini(Cxt cxt, int id)
            : base(cxt, id)
        {
        }

        public UserFini(Cxt cxt, BaseItem item)
            : base(cxt, item)
        {
        }

        public UserFini(Cxt cxt, DataRow row)
        {
            Cxt = cxt;

            DataRow = row;
        }


        #endregion

        #region Properties

        #region Core
        public override InfiChess TableName { [DebuggerStepThrough] get { return InfiChess.UserFini; } [DebuggerStepThrough] set { base.TableName = value; } }
        #endregion

        #region Enum
        #endregion

        #region Generated
        public int UserFiniID { [DebuggerStepThrough] get { return GetColInt32("UserFiniID"); } [DebuggerStepThrough] set { SetColumn("UserFiniID", value); } }
        public int WhiteUserID { [DebuggerStepThrough] get { return GetColInt32("WhiteUserID"); } [DebuggerStepThrough] set { SetColumn("WhiteUserID", value); } }
        public int BlackUserID { [DebuggerStepThrough] get { return GetColInt32("BlackUserID"); } [DebuggerStepThrough] set { SetColumn("BlackUserID", value); } }
        public int WhiteFini { [DebuggerStepThrough] get { return GetColInt32("WhiteFini"); } [DebuggerStepThrough] set { SetColumn("WhiteFini", value); } }
        public int BlackFini { [DebuggerStepThrough] get { return GetColInt32("BlackFini"); } [DebuggerStepThrough] set { SetColumn("BlackFini", value); } }
        public int StackFee { [DebuggerStepThrough] get { return GetColInt32("StackFee"); } [DebuggerStepThrough] set { SetColumn("StackFee", value); } }
        public int FlateFee { [DebuggerStepThrough] get { return GetColInt32("FlateFee"); } [DebuggerStepThrough] set { SetColumn("FlateFee", value); } }
        public int GameResultID { [DebuggerStepThrough] get { return GetColInt32("GameResultID"); } [DebuggerStepThrough] set { SetColumn("GameResultID", value); } }
        public int GameID { [DebuggerStepThrough] get { return GetColInt32("GameID"); } [DebuggerStepThrough] set { SetColumn("GameID", value); } }
        #endregion

        #region Contained Classes
        #endregion

        #region Calculated
        #endregion

        #endregion

        #region Methods

        #region Public Methods

        static bool IsOpponentWhite(Game game)
        {
            bool isTrue = false;
            if (game.WhiteUserID == game.Challenge.OpponentUserID)
            {
                isTrue = true;
            }
            else
            {
                isTrue = false;
            }
            return isTrue;
        }

        public static void UpdateFiniTransfer(SqlTransaction trans, Cxt cxt, Game game, int stake, int flate)
        {
            int wFini = 0, bFini = 0;            
            bool isOpponentWhite = IsOpponentWhite(game);
            
            /// below check will be for stake fee
            if (game.GameResultIDE == GameResultE.WhiteWin) // if white wins then stake will be gain by white user
            { 
                User WhiteUser = new User(cxt, game.WhiteUserID);
                wFini = WhiteUser.Fini + stake;   
                User BlackUser = new User(cxt, game.BlackUserID);
                bFini = BlackUser.Fini - stake;
            }
            else if (game.GameResultIDE == GameResultE.WhiteLose)
            {
                User WhiteUser = new User(cxt, game.WhiteUserID);
                wFini = WhiteUser.Fini - stake;
                User BlackUser = new User(cxt, game.BlackUserID);
                bFini = BlackUser.Fini + stake;
            }

            // below check will be for flate fee
            UserFini UserFini = null;
            if (flate > 0) // +ve flate fee mean opponent will pay to challenger
            {
                if (isOpponentWhite)
                {
                    User ChallengerUser = new User(cxt, game.Challenge.ChallengerUserID);
                    bFini = bFini + flate;   // +ve flate fee for paid by opponent
                    User OpponentUser = new User(cxt, game.Challenge.OpponentUserID);
                    wFini = wFini - flate;
                                       
                }
                else
                {
                    User ChallengerUser = new User(cxt, game.Challenge.ChallengerUserID);
                    wFini = wFini + flate;   // +ve flate fee for paid by opponent
                    User OpponentUser = new User(cxt, game.Challenge.OpponentUserID);
                    bFini = bFini - flate;                    
                }
               
            }
            else // flate fee with -ve, challenger pay the opponent no matter what the result is.
            {
                if (isOpponentWhite)
                {
                    User ChallengerUser = new User(cxt, game.Challenge.ChallengerUserID);
                    bFini = bFini + flate;   // -ve flate fee for paid by challenger
                    User OpponentUser = new User(cxt, game.Challenge.OpponentUserID);
                    wFini = wFini - flate;
                                       
                }
                else
                {
                    User ChallengerUser = new User(cxt, game.Challenge.ChallengerUserID);
                    wFini = wFini + flate;   // -ve flate fee for paid by challenger
                    User OpponentUser = new User(cxt, game.Challenge.OpponentUserID);
                    bFini = bFini - flate;
                    
                }                
            }

            UserFini = GetUpdatedUserFini(cxt, game, wFini, bFini, stake, flate);
            UserFini.Save(trans);            

            User.UpdateFini(trans, wFini, game.WhiteUser.UserID);
            User.UpdateFini(trans, bFini, game.BlackUser.UserID);

        }

        private static UserFini GetUpdatedUserFini(Cxt cxt, Game game, int whiteFini, int blackFini, int stake, int flate)
        {
            UserFini UserFini = new UserFini(cxt, 0);
            UserFini.StackFee = stake;
            UserFini.FlateFee = flate;
            UserFini.WhiteFini = whiteFini;
            UserFini.BlackFini = blackFini;
            UserFini.WhiteUserID = game.WhiteUserID;
            UserFini.BlackUserID = game.BlackUserID;
            UserFini.GameResultID = game.GameResultID;
            UserFini.GameID = Convert.ToInt32(game.GameID);
            return UserFini;
        }

        private static int GetMasterID(User whiteUser, User blackUser, ref bool isWhite)
        {
            int userID = 0;

            if (whiteUser.HumanRankIDE == RankE.King || whiteUser.HumanRankIDE == RankE.Queen)
            {
                userID = whiteUser.UserID;
                isWhite = true;
            }
            else if (blackUser.HumanRankIDE == RankE.King || blackUser.HumanRankIDE == RankE.Queen)
            {
                userID = blackUser.UserID;
            }
            else
            {
                userID = 0;
            }
            return userID;
        }


        #endregion


        #endregion
    }
}

//private static void CheckUpdateFini(Cxt cxt, Game game, int finiW, int finiB, int stake, int flate)
//        {
//            User WhiteUser = User.GetUserByID(Cxt.Instance, game.WhiteUserID);
//            User BlackUser = User.GetUserByID(Cxt.Instance, game.BlackUserID);

//            bool isWhite = false;
//            if (GetMasterID(WhiteUser, BlackUser, ref isWhite) > 0) // king or queen exist
//            {
//                if (isWhite) // king or queen white userid
//                {
//                    if (game.GameResultIDE == GameResultE.WhiteLose)
//                    {
//                        finiB = game.BlackUser.Fini - (stake - (-flate)); // flate fee will be -ve, king or queen loose the match
//                        finiW = game.WhiteUser.Fini + (stake - (-flate)); // flate - stake fee and add in master account
//                        stake = 0;
//                        flate = stake - flate;
//                    }
//                    else if (game.GameResultIDE == GameResultE.WhiteWin)
//                    {
//                        finiB = (game.BlackUser.Fini - (stake - flate)); // flate - stake fee and add in master account
//                        finiW = (game.WhiteUser.Fini + (stake - flate)); // master win the match
//                        flate = -(flate);
//                    }
//                    if (game.GameResultIDE == GameResultE.Draw)
//                    {
//                        finiB = (game.BlackUser.Fini - (-flate)); // flate fee will be applicable.
//                        finiW = (game.WhiteUser.Fini + (-flate));
//                        stake = 0;
//                        flate = -flate;
//                    }
//                }
//                else
//                {
//                    if (game.GameResultIDE == GameResultE.WhiteLose)
//                    {
//                        finiB = (game.BlackUser.Fini + (stake - flate)); // flate fee will be -ve
//                        finiW = (game.WhiteUser.Fini - (stake - flate));
//                        flate = -flate;

//                    }
//                    else if (game.GameResultIDE == GameResultE.WhiteWin)
//                    {
//                        finiB = (game.BlackUser.Fini - (stake - (-flate)));
//                        finiW = (game.WhiteUser.Fini + (stake - (-flate)));
//                        stake = 0;
//                        flate = stake - (-flate);

//                    }
//                    if (game.GameResultIDE == GameResultE.Draw)
//                    {
//                        finiB = (game.BlackUser.Fini + (-flate)); // flate fee will be applicable.
//                        finiW = (game.WhiteUser.Fini - (-flate));
//                        stake = 0;
//                        flate = -(flate);

//                    }
//                }
//            }
//            else
//            {
//                if (game.GameResultIDE == GameResultE.WhiteLose)
//                {
//                    finiB = game.BlackUser.Fini + stake; // flate fee will be -ve
//                    finiW = game.WhiteUser.Fini - stake;
//                    stake = 0;
//                    flate = 0;
//                }
//                else if (game.GameResultIDE == GameResultE.WhiteWin)
//                {
//                    finiB = game.BlackUser.Fini - stake;
//                    finiW = game.WhiteUser.Fini + stake;
//                    flate = 0;
//                }
//                if (game.GameResultIDE == GameResultE.Draw)
//                {
//                    finiB = 0;
//                    finiW = 0;
//                    stake = 0;
//                    flate = 0;

//                }
//            }

//        }


 //if (game.WhiteUserID == game.Challenge.OpponentUserID && game.GameResultIDE == GameResultE.WhiteLose)
 //               {
 //                   wFlate = OpponentUser.Fini - flate;
 //               }
 //               else if (game.WhiteUserID == game.Challenge.OpponentUserID && game.GameResultIDE == GameResultE.WhiteWin)
 //               {
 //                   wFlate = OpponentUser.Fini;
 //               }
 //               else if (game.BlackUserID == game.Challenge.OpponentUserID && game.GameResultIDE == GameResultE.WhiteLose)
 //               {
 //                   bFlate = OpponentUser.Fini;
 //               }
 //               else if (game.BlackUserID == game.Challenge.OpponentUserID && game.GameResultIDE == GameResultE.WhiteWin)
 //               {
 //                   bFlate = OpponentUser.Fini - flate;
 //               }



 //if (game.WhiteUserID == game.Challenge.ChallengerUserID && game.GameResultIDE == GameResultE.WhiteLose)
 //               {
 //                   wFlate = ChallengerUser.Fini - flate;
 //               }
 //               else if (game.WhiteUserID == game.Challenge.ChallengerUserID && game.GameResultIDE == GameResultE.WhiteWin)
 //               {
 //                   wFlate = ChallengerUser.Fini;
 //               }
 //               else if (game.BlackUserID == game.Challenge.ChallengerUserID && game.GameResultIDE == GameResultE.WhiteLose)
 //               {
 //                   bFlate = ChallengerUser.Fini;
 //               }
 //               else if (game.BlackUserID == game.Challenge.ChallengerUserID && game.GameResultIDE == GameResultE.WhiteWin)
 //               {
 //                   bFlate = ChallengerUser.Fini - flate;
 //               }