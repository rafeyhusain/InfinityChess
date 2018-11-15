using System;
using System.Collections.Generic;
using System.Text;
using App.Model.Db;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Linq;

namespace App.Model
{
    #region enum
   

    #endregion

    #region MsgQueue
    public class MsgQueue
    {
        #region Data Members
        public delegate void SyncConsumeMessage(Kv kv);

        private Timer t1 = new Timer();
        private Dictionary<int, Queue<Kv>> queues = new Dictionary<int, Queue<Kv>>();
        private Dictionary<int, IMsgQueueConsumer> consumers = new Dictionary<int, IMsgQueueConsumer>();

        public delegate void ConsumeMessageEventHandler(object sender, Kv kv);
        public event ConsumeMessageEventHandler ConsumeMessage;
        #endregion

        #region Constructor

        public MsgQueue()
        {
        }

        #endregion

        #region Instance
        private static MsgQueue instance = null;
        public static MsgQueue Instance
        {
            [DebuggerStepThrough]
            get
            {
                if (instance == null)
                {
                    instance = new MsgQueue();
                }

                return instance;
            }
            [DebuggerStepThrough]
            set { instance = value; }
        }

        #endregion

        #region Properties
        public bool IsEmpty
        {
            get
            {
                return queues.Count == 0;
            }
        }

        public bool IsNotEmpty
        {
            get
            {
                return !IsEmpty;
            }
        }

        public int Count
        {
            get
            {
                return queues.Count;
            }
        }

        #endregion

        #region Queue Methods

        public void Enqueue(Kv kv)
        {
            int gameID = kv.GetInt32("GameID");

            if (consumers.ContainsKey(gameID))
            {
                if (gameID > 0 && consumers[gameID].Game != null)
                {
                    MethodNameE mn = (MethodNameE)kv.GetInt32("MethodName");

                    if (consumers[gameID].Game.Flags.IsNotReady && mn != MethodNameE.RestartGame && mn != MethodNameE.RestartGameWithSetup 
                        && mn != MethodNameE.WriteChatMessage && mn != MethodNameE.ForceLogoff)
                    {
                        return;
                    }
                }
                consumers[gameID].ConsumeMessage(kv);
            }
            else
            {
                if (!queues.ContainsKey(gameID))
                {
                    queues.Add(gameID, new Queue<Kv>());
                }

                queues[gameID].Enqueue(kv);
            }
        }

        private void OnConsumeMessage(Kv kv)
        {
            if (ConsumeMessage != null)
            {
                ConsumeMessage(this, kv);
            }
        }

        public Kv Dequeue(int gameID)
        {
            if (!queues.ContainsKey(gameID))
            {
                return null;
            }

            return queues[gameID].Dequeue();
        }

        public Kv Peek(int gameID)
        {
            if (!queues.ContainsKey(gameID))
            {
                return null;
            }

            return queues[gameID].Peek();
        }

        public void Clear()
        {
            foreach (int gameID in queues.Keys)
            {
                Clear(gameID);
            }
        }

        public void Clear(int gameID)
        {
            if (!queues.ContainsKey(gameID))
            {
                return;
            }

            queues[gameID].Clear();
        }
        #endregion

        #region Timer
        public void Init()
        {
            t1.Interval = 100;
            t1.Start();
            t1.Elapsed += new ElapsedEventHandler(t1_Elapsed);
        }

        public void UnInit()
        {
            t1.Stop();
            t1.Elapsed -= new ElapsedEventHandler(t1_Elapsed);
            this.Clear();
        }

        void t1_Elapsed(object sender, ElapsedEventArgs e)
        {
            t1.Stop();

            if (queues.Keys.Count > 0)
            {
                List<int> queKeys = queues.Keys.ToList();

                foreach (int gameID in queKeys)
                {
                    ConsumeQueue(gameID);
                }
            }

            t1.Start();
        }

        private void ConsumeQueue(int gameID)
        {
            if (!consumers.ContainsKey(gameID))
            {
                return;
            }

            while(queues[gameID].Count > 0)
            {
                consumers[gameID].ConsumeMessage(queues[gameID].Dequeue());
            }

            queues.Remove(gameID);
        }
        #endregion

        #region MsgQueueConsumer
        public void Register(IMsgQueueConsumer consumer)
        {
            // GameID > 0 is a valid GameID
            // GameID = 0 is for OnlineClient
            // GameID < 0 is Invalid
            if (consumer.GameID < 0)
            {
                return;
            }

            if (!consumers.ContainsKey(consumer.GameID))
            {
                consumers.Add(consumer.GameID, consumer);
            }
        }

        public void UnRegister(IMsgQueueConsumer consumer)
        {
            if (consumers.ContainsKey(consumer.GameID))
            {
                consumers.Remove(consumer.GameID);
            }
        }
        #endregion
    } 
    #endregion

    #region IMsgQueueConsumer
    public interface IMsgQueueConsumer
    {
        void ConsumeMessage(Kv kv);
        int GameID { get; }
        Game Game { get; }
    }
    #endregion
}
