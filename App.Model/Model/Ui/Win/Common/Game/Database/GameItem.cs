using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using InfinitySettings.Streams;
using System.Diagnostics;

namespace App.Model
{
    public class GameItem : BaseItem
    {
        #region Data Members
        public GameData GameData;
        public Moves Moves; 
        #endregion

        #region Ctor
        public GameItem()
        {
        }

        public GameItem(string gameXml)
        {
            base.DataRow = NewRow();

            this.GameXml = gameXml;

            LoadGameItems();

            this.Guid = GameData.Guid;
        }
        
        public GameItem(DataRow row)
        {
            base.DataRow = row;

            LoadGameItems();
        }

        public GameItem(GameData gameData,Moves moves)
        {
            this.GameData = gameData;
            this.Moves = moves;
        }

        static Game TempGame = null;
        private void LoadGameItems()
        {
            // this line is changed with line below, as we don't need current game to load GameData, 
            // as GameData will load from gameXml, so we only need a new game object.

            //GameData = new GameData(Ap.Game, GameXml); 

            if (TempGame == null)
            {
                TempGame= new Game();
            }

            GameData = new GameData(TempGame, GameXml);
            if (!string.IsNullOrEmpty(GameData.Moves))
            {
                Moves = new Moves();
                string notationsXml = GameData.Moves;

                MemoryStream memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(notationsXml));
                Moves.DataTable.ReadXml(memoryStream);
                int lastRowIndex = Moves.DataTable.Rows.Count - 1;

                if (lastRowIndex >= 0)
                {
                    //if (string.IsNullOrEmpty(moves.DataTable.Rows[lastRowIndex][Moves.R].ToString()))
                    //{
                    //    moves.DataTable.Rows.Remove(moves.DataTable.Rows[lastRowIndex]);
                    //}
                }
                memoryStream.Close();
            }

        }
        #endregion

        #region Properties

        #region Core
        public string Guid { [DebuggerStepThrough]get { return GetCol(Database.Guid); } [DebuggerStepThrough] set { SetColumn(Database.Guid, value); } }
        public string GameXml { [DebuggerStepThrough]get { return GetCol(Database.GameXml); } [DebuggerStepThrough] set { SetColumn(Database.GameXml, value); } }
        #endregion

        #region Calculated

        public bool HasMoves
        {
            get
            {
                return Moves.Count > 0 && Moves.First.Id > -1;
            }
        }

        #endregion
        #endregion

        #region Helpers
        public static DataRow NewRow()
        {
            DataTable table = Database.GetDatabaseDataTable();

            DataRow row = table.NewRow();

            table.Rows.Add(row);

            table.AcceptChanges();

            return row;
        }

        public static GameItem NewGameItem()
        {
            return new GameItem(NewRow());
        }
        
        #endregion
    }
}
