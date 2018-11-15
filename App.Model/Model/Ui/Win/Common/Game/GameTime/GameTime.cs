using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Win;
using System.Diagnostics;

namespace App.Model
{
    //Bullet: up to 2 minutes
    //Blitz: more than 2 min., up to 10 min.
    //Rapid: more than 10 min., up to  60 min.
    //Note:
    //Users playing with an increment like e.g. 2min+12sec can make it difficult to determine to which category a game belongs.  
    //In such a case user would effectively have 12 minutes for his first 50 moves and another 10 minutes for his next 50 moves. 
    //So this would rather be a rapid game instead of a blitz game, as each of the players would have 22 min. for 100 moves. 
    //Yet, the character of the game would be blitz in the beginning: 
    //if you spend more than 3 min for your first 5 moves, you have definitely lost, while (theoretically speaking) 
    //in an ordinary rapid game you would not have lost. To keep things clear and simple, we should neglect the factor increment;  
    //i.e. the category will be determined by the basic time without considering any increment. 

    public class GameTime
    {
        #region Data Members
        public Game Game = null;
        public GameType GameType = GameType.None;

        //Bullet: up to 2 minutes
        //Blitz: more than 2 min., up to 10 min.
        //Rapid: more than 10 min., up to  60 min.
        public long TimeMin = 0;
        public long GainPerMove = 0;
        public long HumanBonus = 0;
        public long HumanBonusPerMove = 0;
        public int LongGamePhase = 1;

        // : tournament games with over 15 minutes for all the moves”
        public long FirstHour = 0;
        public long FirstMin = 0;
        public long FirstMoves = 0;
        public long FirstGainPerMoves = 0;

        public long SecondHour = 0;
        public long SecondMin = 0;
        public long SecondMoves = 0;
        public long SecondGainPerMoves = 0;

        public long ThirdHour = 0;
        public long ThirdMin = 0;        
        public long ThirdGainPerMoves = 0;        

        public const int SecondsPerMove = 1;
        #endregion

        #region Properties

        public long TotalTime
        {
            [DebuggerStepThrough]
            get
            {
                long gameTime = 0;
                long gameMinutes = 0;
                long gameSeconds = 0;
                
                switch (GameType)
                {
                    case GameType.Bullet:
                    case GameType.Blitz:
                    case GameType.Rapid:
                    case GameType.NoClock:
                        gameMinutes = TimeMin;
                        gameSeconds = GainPerMove;
                        gameTime = (gameMinutes * 60) + gameSeconds;
                        break;
                    case GameType.Long:                        
                        gameTime = GetSeconds(FirstHour, FirstMin, FirstGainPerMoves);
                        break;
                    default:
                        gameTime = Options.Instance.PlayingTime;
                        break;
                }

                return gameTime;
            }
        }

        #endregion

        public long GetSeconds(long hours, long minutes, long gainSeconds)
        {
            long seconds = 0;
            seconds = (hours * 60 * 60) + (minutes * 60) + gainSeconds;
            return seconds;
        }

        public GameTime(Game game)
        {
            this.Game = game;
        }

        #region Methods
     
        public void Init()
        {
            switch (this.GameType)
            {
                case GameType.Bullet:
                case GameType.Blitz:
                case GameType.Rapid:
                case GameType.NoClock:
                    Init(Ap.OptionsBlitzClock, true);
                    break;
                case GameType.Long:
                    Init(Ap.OptionsLongClock, true);
                    break;
                default:
                    break;
            }
        }

        public void Init(OptionsBlitzClock c, bool initDefault)
        {
            if (c == null)
            {
                if (initDefault)
                {
                    c = Ap.OptionsBlitzClock;
                }
                else
                {
                    return;
                }
            }

            TimeMin = c.Time;
            GainPerMove = c.GainPerMove;
        }

        public void Init(OptionsLongClock c, bool initDefault)
        {
            if (c == null)
            {
                if (initDefault)
                {
                    c = Ap.OptionsLongClock;
                }
                else
                {
                    return;
                }
            }

            FirstHour = c.FirstControlHour;
            FirstMin = c.FirstControlMinute;
            FirstMoves = c.FirstControlMoves;
            FirstGainPerMoves = c.FirstControlGainPerMoves;

            SecondHour = c.SecondControlHour;
            SecondMin = c.SecondControlMinute;
            SecondMoves = c.SecondControlMoves;
            SecondGainPerMoves = c.SecondControlGainPerMoves;

            ThirdHour = c.ThirdControlHour;
            ThirdMin = c.ThirdControlMinute;            
            ThirdGainPerMoves = c.ThirdControlGainPerMove;

            LongGamePhase = 1;

            GainPerMove = FirstGainPerMoves;
        }

        public void Set(App.Model.Db.Game game)
        {
            switch (this.GameType)
            {
                case GameType.Bullet:
                case GameType.Blitz:
                case GameType.Rapid:
                case GameType.NoClock:
                    TimeMin = game.TimeMin;
                    GainPerMove = game.GainPerMoveMin;
                    break;
                case GameType.Long:
                    FirstHour = 0;
                    TimeMin = game.TimeMin;
                    GainPerMove = game.GainPerMoveMin;
                    FirstMin = game.TimeMin;
                    FirstMoves = 0;
                    FirstGainPerMoves = game.GainPerMoveMin;
                    break;
                default:
                    break;
            }
        }

        public static GameType GetGameType(int min, int sec)
        {
            float gameTime = min + ((float)sec / 60);

            if (gameTime <= 2)
            {
                //Bullet Game
                return GameType.Bullet;
            }
            else if (gameTime <= 10)
            {
                //Blitz Game
                return GameType.Blitz;
            }
            else if (gameTime <= 60)
            {
                //Rapid Game
                return GameType.Rapid;
            }
            else
            {
                //Long Game
                return GameType.Long;
            }
        }

        public static long GetGameTime(GameType gameType, Game game)
        {
            long gameTime = -1;

            switch (gameType)
            {
                case GameType.Blitz:
                    {

                        long gameMinutes = Ap.OptionsBlitzClock.Time;
                        long gameSeconds = Ap.OptionsBlitzClock.GainPerMove;
                        gameTime = InfinitySettings.Settings.GetTimeInSeconds(0, gameMinutes, gameSeconds);

                        game.GainPerMove = (int)gameSeconds;

                        break;
                    }
                case GameType.Long:
                    {
                        long gameHours = Ap.OptionsLongClock.FirstControlHour;
                        long gameMinutes = Ap.OptionsLongClock.FirstControlMinute;
                        long gameSeconds = Ap.OptionsLongClock.FirstControlGainPerMoves;        // add by DA
                        gameTime = InfinitySettings.Settings.GetTimeInSeconds(gameHours, gameMinutes, gameSeconds);

                        game.GainPerMove = (int)gameSeconds;

                        break;
                    }
                default:
                    break;
            }
            return gameTime;
        }

        public static long GetGameMinutes(GameType gameType)
        {
            long gameTime = -1;
            long minutes = -1;

            switch (gameType)
            {
                case GameType.Blitz:
                    {

                        long gameMinutes = Ap.OptionsBlitzClock.Time;
                        long gameSeconds = Ap.OptionsBlitzClock.GainPerMove;
                        gameTime = (gameMinutes * 60) + gameSeconds;

                        minutes = gameMinutes;
                        break;
                    }
                case GameType.Long:
                    {
                        long gameHours = Ap.OptionsLongClock.FirstControlHour;
                        long gameMinutes = Ap.OptionsLongClock.FirstControlMinute;
                        gameTime = (gameHours * 60 * 60) + (gameMinutes * 60);

                        minutes = gameTime;
                        break;
                    }
                default:
                    break;
            }
            return minutes;
        }

        public static long GetGameSeconds(GameType gameType)
        {
            long gameTime = -1;
            long seconds = -1;

            switch (gameType)
            {
                case GameType.Blitz:
                    {

                        long gameMinutes = Ap.OptionsBlitzClock.Time;
                        long gameSeconds = Ap.OptionsBlitzClock.GainPerMove;
                        gameTime = (gameMinutes * 60) + gameSeconds;

                        seconds = gameSeconds;
                        break;
                    }
                case GameType.Long:
                    {
                        long gameHours = Ap.OptionsLongClock.FirstControlHour;
                        long gameMinutes = Ap.OptionsLongClock.FirstControlMinute;
                        gameTime = (gameHours * 60 * 60) + (gameMinutes * 60);

                        seconds = 0;
                        break;
                    }
                default:
                    break;
            }
            return seconds;
        }
        #endregion
    }
}
