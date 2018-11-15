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
using App.Model.Db;
using System.Net.Sockets;
using System.Net;
using System.Collections;
using System.Threading;

namespace App.Model
{
    public partial class SocketClient
    {
        public static DataSet AddChallengeData
            (
              int WhiteUserID
            , int blackUserID
            , ChallengeTypeE challengeTypeE
            , GameType gameTypeIDE
            , ColorE colorIDE
            , int roomID
            , int timeMin
            , int gainPerMove
            , int chessTypeID
            , bool isRated
            , bool withClock
            , bool challengerSendsGame
            , string description
            , int statke
            , int flate
            )
        {
            ChallengeDataKv kv = new ChallengeDataKv();
            kv.Kv.Set("MethodName", (int)MethodNameE.AddChallengeData);
            kv.Kv.Set(StdKv.CurrentUserID, WhiteUserID);
            kv.ChallengerUserID = WhiteUserID;
            kv.ChallengeTypeIDE = challengeTypeE;
            kv.ChessTypeID = chessTypeID;
            kv.ColorIDE = colorIDE;
            kv.IsRated = isRated;
            kv.WithClock = withClock;
            kv.IsChallengerSendsGame = challengerSendsGame;
            kv.Description = description;
            kv.OpponentUserID = blackUserID;
            kv.RoomID = roomID;
            kv.StatusIDE = StatusE.Active;
            kv.GameTypeIDE = gameTypeIDE;
            kv.TimeMin = timeMin;
            kv.GainPerMoveMin = gainPerMove;
            kv.Stake = statke;
            kv.Flate = flate;
            DataSet ds = SocketClient.Instance.Invoke(kv.Kv.DataTable.Copy());           
            
            return ds;
        }

        public static DataSet DeleteChallenge(int challengeID, int challengerID, ChallengeTypeE challengeType)
        {
                Kv kv = new Kv();
                if (challengerID == Ap.CurrentUserID)
                {
                    kv.Set("MethodName", (int)MethodNameE.DeleteChallenge);
                }
                else
                {
                    if (challengeType != ChallengeTypeE.Seek)
                    {
                        kv.Set("MethodName", (int)MethodNameE.DeclineChallenge);
                    }
                    else
                    {
                        return null;
                    }
                }
                kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
                kv.Set("ChallengeID", challengeID);
                DataSet ds = SocketClient.Instance.Invoke(kv.DataTable.Copy());
                return ds;
        }

        public static DataSet GetChallengeByID(int challengeID)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.GetChallengeByID);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("ChallengeID", challengeID);
            DataSet ds = SocketClient.Instance.Invoke(kv.DataTable.Copy());
            return ds;
        }

        public static DataSet ModifyChallenge(ColorE colorIDE, GameType gameTypeIDE, int challengeID, int roomID, int chessTypeID, bool IsRated, bool WithClock, bool ChallengerSendsGame, int opponentUserID, int timeMin, int gainPerMove)
        {
            ChallengeDataKv kv = new ChallengeDataKv();
            kv.Kv.Set("MethodName", (int)MethodNameE.ModifyChallenge);
            kv.Kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.ChallengeID = challengeID;
            kv.ChallengerUserID = Ap.CurrentUserID;
            kv.ChallengeTypeIDE = ChallengeTypeE.Modify;
            kv.ChessTypeID = chessTypeID;
            kv.ColorIDE = colorIDE;
            kv.IsRated = IsRated;
            kv.WithClock = WithClock;
            kv.IsChallengerSendsGame = ChallengerSendsGame;
            kv.Description = "";
            kv.OpponentUserID = opponentUserID;
            kv.GameTypeIDE = gameTypeIDE;
            kv.StatusIDE = StatusE.Active;
            kv.TimeMin = timeMin;
            kv.GainPerMoveMin = gainPerMove;
            kv.RoomID = roomID;
            //kv.ChessTypeID = PlayingMode.ChessTypeID;
            DataSet ds = SocketClient.Instance.Invoke(kv.Kv.DataTable.Copy());
            return ds;
            
        }

        public static void DeclineChallenges(DataTable dt)
        {
            Kv kv = new Kv();
            kv.Set("MethodName", (int)MethodNameE.DeclineChallenges);
            kv.Set(StdKv.CurrentUserID, Ap.CurrentUserID);
            kv.Set("ChallengesData", UData.ToString(dt));
            SocketClient.Instance.InvokeAsync(kv.DataTable.Copy());
        }
    }
}
            
               
                
               
               
         
    

