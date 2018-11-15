using System;
using App.Model;
using System.Collections.Generic;

using System.Text;
using InfinitySettings.Streams;
using System.IO;
using System.Xml;
using System.Data;

namespace App.Model
{
    public class GameItems : BaseItems<GameItem, GameItems>
    {
        #region Data Members
        public Game Game = null;
        public Database Database = null;
        #endregion

        #region Ctor
        public GameItems()
        {
        }

        public GameItems(Database database)
        {
            this.Database = database;
            Load();
        }

        #endregion

        #region Load
        public void Load()
        {
            DataTable = Database.GetDatabaseDataTable();
        }
        #endregion

        #region Populate Games Records
        public DataTable GetGamesData()
        {
            DataTable dt = Database.GetDatabaseViewDataTable();

            int serialNo = 0;

            foreach (DataRow row in this.Database.DatabaseData.Rows)
            {
                serialNo++;

                GameItem gi = new GameItem(row);
                DataRow rowx = dt.NewRow();

                rowx[Database.SerialNo] = serialNo;   
                rowx[Database.Guid] = gi.GameData.Guid;
                rowx[Database.Players] = gi.GameData.GamePlayers;
                rowx[Database.Tournament] = gi.GameData.Tournament;
                rowx[Database.ECO] = gi.GameData.EcoCode;
                rowx[Database.Year] = gi.GameData.Year;
                rowx[Database.Result] = gi.GameData.Result;

                if (gi.Moves != null)
                {
                    rowx[Database.Moves] = ((BaseItems<Move, Moves>)(gi.Moves)).Last.MoveNo;
                }

                if (gi.Moves!= null)
                {
                    rowx[Database.Variation] = Moves.HasVariation(gi.Moves.DataTable) ? "V" : "";
                }

                dt.Rows.Add(rowx);
            }

            return dt;
        }
        #endregion

        #region GetGameByGuid
        public GameItem GetGameByGuid(string guid)
        {
            GameItem gameItem = null;
            foreach (DataRow row in this.Database.DatabaseData.Rows)
            {
                GameItem gItem = new GameItem(row);
                
                if (gItem.GameData.Guid == guid)
                {
                    gameItem = gItem;
                    break;
                }
            }
            return gameItem;
        }  
        #endregion

        #region GetGameItem
        public GameItem GetNextGameByGuid(string guid)
        {
            return GetGameItem(guid, true);
        }
        
        public GameItem GetPreviousGameByGuid(string guid)
        {
            return GetGameItem(guid, false);
        }

        public GameItem GetGameItem(string guid)
        {
            DataRow[] rows = this.Database.DatabaseData.Select(Database.Guid + "='" + guid + "'");
            if (rows.Length > 0)
                return new GameItem(rows[0]);
            return null;
        }

        public GameItem GetGameItem(string guid, bool next)
        {
            GameItem gi = GetGameByGuid(guid);

            int index = this.IndexOf(gi);

            if (next)
            {
                index = index + 1;
            }
            else
            {
                index = index - 1;
            }

            if (index >= this.Database.GamesCount)
            {
                index = 0;
            }
            else if(index < 0)
            {
                index = this.Database.GamesCount - 1;
            }

            return new GameItem(this.Database.DatabaseData.Rows[index]);
        }

        private int IndexOf(GameItem gi)
        {
            try
            {
                return this.Database.DatabaseData.Rows.IndexOf(gi.DataRow);
            }
            catch
            {
                return -1;
            }
        } 
        #endregion


        #region GetCurrentGameIndex
        public int GetCurrentGameIndex()
        {
            for(int index=this.Database.DatabaseData.Rows.Count-1;index>=0;index--)
            {
                DataRow row = this.Database.DatabaseData.Rows[index];
                GameItem gItem = new GameItem(row);
                if (gItem.GameData.Guid == Ap.Options.CurrentGameGuid)
                {
                    return index;
                }
            }
            return -1;

        } 
        #endregion

        #region GetGameIndexByGuid
        public int GetGameIndexByGuid(string guid)
        {
            for (int index = this.Database.DatabaseData.Rows.Count - 1; index >= 0; index--)
            {
                DataRow row = this.Database.DatabaseData.Rows[index];
                GameItem gItem = new GameItem(row);
                if (gItem.GameData.Guid == guid)
                {
                    return index;
                }
            }
            return -1;

        }
        #endregion

        #region FirstGame
        public GameItem FirstGame()
        {
            DataRow row = this.Database.DatabaseData.Rows[0];
            GameItem gameItem = null;
            if (row != null)
            {
                gameItem = new GameItem(row);
                Ap.Options.CurrentGameGuid = gameItem.GameData.Guid;
                Ap.Options.Save();
            }
            return gameItem;
        } 
        #endregion

        #region LastGame
        public GameItem LastGame()
        {
            DataRow row = this.Database.DatabaseData.Rows[this.Database.DatabaseData.Rows.Count-1];
            GameItem gameItem = null;
            if (row != null)
            {
                gameItem = new GameItem(row);
                Ap.Options.CurrentGameGuid = gameItem.GameData.Guid;
                Ap.Options.Save();
            }
            return gameItem;
        }
        #endregion

        #region GetGamesByNotation
        public DataTable GetGamesByNotation(Notations notation, int rowIndex, int colIndex)
        {
            List<GameItem> gameItems = new List<GameItem>();
            foreach (DataRow row in this.Database.DatabaseData.Rows)
            {
                Move m = new Move(row);
                m.Game = this.Game;
                //string moves =  m.DoubleNotation;

                GameItem gameItem = new GameItem(row);
                DataTable dbGameMoves = gameItem.Moves.Notation.NotationView;
                DataTable currentGameMoves = this.Game.Notations.NotationView;
                Notations n = new Notations(gameItem.GameData.Game);
                DataTable myMoves=n.NotationView; 
                 // string currentGameMoves = notation.Moves.GetMovesString(rowIndex,colIndex);
                 // string databaseGameMoves = gameItem.Moves.GetMovesString(rowIndex, colIndex);
              /*
                 
                  if (currentGameMoves == databaseGameMoves)
                  {
                      serialNo++;
                      DataRow gameDataRow = GamesData.NewRow();
                      gameDataRow[SerialNo] = serialNo;
                      gameDataRow[Guid] = gameItem.GameData.Guid;
                      gameDataRow[Players] = gameItem.GameData.GamePlayers;
                      gameDataRow[Tournament] = gameItem.GameData.Tournament;
                      gameDataRow[ECO] = gameItem.GameData.EcoCode;
                      gameDataRow[Year] = gameItem.GameData.Year;
                      gameDataRow[Result] = gameItem.GameData.Result;
                    
                      if (Ap.Options.IsSingleNotation)
                      {
                          // single
                          //this.Game.Notations.GetSingleNotation();
                          //this.Game.Notations.MovesDisplay.Rows;
                         DataTable dbGameMoves= gameItem.Moves.Notation.MovesDisplay();
                         DataTable currentGameMoves = this.Game.Notations.MovesDisplay(); 
                    
                      }
                      else
                      {
                          //double
                      }
                      if (gameItem.Moves != null)
                      {
                          gameDataRow[Variation] = Notations.HasVariation(gameItem.Moves.DataTable) ? "V" : "";
                      }

                
                      GamesData.Rows.Add(gameDataRow);
                  }
                 */
            }
            return DataTable;

        }
        #endregion

        #region GameCount
        public int GameCount()
        {
            return this.DataTable.Rows.Count;
        }
        #endregion
    }
}
