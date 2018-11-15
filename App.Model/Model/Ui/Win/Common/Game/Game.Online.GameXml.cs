using System;
using App.Model;
using System.Collections.Generic;
using System.Data;
using System.Text;
using InfinityChess;
using System.IO;
using InfinitySettings.Streams;
using InfinitySettings.EngineManager;

namespace App.Model
{
    #region enums
    public enum GameXmlKvE
    {
        None = 0,
        Resign = 1,
        Draw = 2,
        NewGame = 3

    }

    public enum ResignE
    {
        None = 0,
        Resigned = 1
    }



    #endregion

    public partial class Game
    {
        #region Data Members

        public DataSet GameXmlDataSet = null;
        private Kv gameXmlKv = null;

        #endregion

        #region Get/Set GameXml
        public string GetOnlineGameXml()
        {
            DataRow dr = Notations.GetLastRow();
     
            if (dr != null)
            {
                return UData.ToString(dr);
            }
            else
            {
                return "";
            }
        }

        public bool SetOnlineGameXml(string gameXml, bool isPaste)
        {
            if (String.IsNullOrEmpty(gameXml))
                return false;

            if (Flags.IsExamineMode)
                return false;

            Ap.Game.Flags.IsClickedByUser = true;

            if (isPaste)
            {
               Paste(gameXml);
            }
            else
            {
                Union(gameXml);
            }

            return true;
        }

        #endregion

    }
}
