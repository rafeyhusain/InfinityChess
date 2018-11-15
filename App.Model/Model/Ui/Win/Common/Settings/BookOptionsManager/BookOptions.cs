using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;
using System.Diagnostics;
namespace InfinitySettings.BookOptionsManager
{
    public class BookOptions
    {
        #region Properties

        string _nodePath;

        private bool _useBook;
        public bool UseBook
        {
            [DebuggerStepThrough]
            get { return _useBook; }
            [DebuggerStepThrough]
            set { _useBook = value; }
        }

        private bool _tournamentBook;
        public bool TournamentBook
        {
            [DebuggerStepThrough]
            get { return _tournamentBook; }
            [DebuggerStepThrough]
            set { _tournamentBook = value; }
        }

        private int _varietyOfPlay;
        public int VarietyOfPlay
        {
            [DebuggerStepThrough]
            get { return _varietyOfPlay; }
            [DebuggerStepThrough]
            set { _varietyOfPlay = value; }
        }

        private int _influence;
        public int Influence
        {
            [DebuggerStepThrough]
            get { return _influence; }
            [DebuggerStepThrough]
            set { _influence = value; }
        }

        private int _learningStrength;
        public int LearningStrength
        {
            [DebuggerStepThrough]
            get { return _learningStrength; }
            [DebuggerStepThrough]
            set { _learningStrength = value; }
        }

        private int _minimumGames;
        public int MinimumGames
        {
            [DebuggerStepThrough]
            get { return _minimumGames; }
            [DebuggerStepThrough]
            set { _minimumGames = value; }
        }

        private int _upToMove;
        public int UpToMove
        {
            [DebuggerStepThrough]
            get { return _upToMove; }
            [DebuggerStepThrough]
            set { _upToMove = value; }
        }

        #endregion

        #region Methods

        public void Load(XmlDocument xmldoc)
        {
            _nodePath = "/BookOptionsData/BookOptions";
            XmlElement root = xmldoc.DocumentElement;
            XmlNode itemNode = root.SelectNodes(_nodePath).Item(0);

            _useBook = Convert.ToBoolean(itemNode.ChildNodes[0].InnerText);
            _tournamentBook = Convert.ToBoolean(itemNode.ChildNodes[1].InnerText);
            _varietyOfPlay = Convert.ToInt32(itemNode.ChildNodes[2].InnerText);
            _influence = Convert.ToInt32(itemNode.ChildNodes[3].InnerText);
            _learningStrength = Convert.ToInt32(itemNode.ChildNodes[4].InnerText);
            _minimumGames = Convert.ToInt32(itemNode.ChildNodes[5].InnerText);
            _upToMove = Convert.ToInt32(itemNode.ChildNodes[6].InnerText);
        }

        public void Save(ref XmlDocument xmldoc)
        {
            _nodePath = "/BookOptionsData/BookOptions";
            XmlElement root = xmldoc.DocumentElement;
            XmlNode itemNode = root.SelectNodes(_nodePath).Item(0);
            
            itemNode.ChildNodes[0].InnerText = _useBook.ToString();
            itemNode.ChildNodes[1].InnerText = _tournamentBook.ToString();
            itemNode.ChildNodes[2].InnerText = _varietyOfPlay.ToString();
            itemNode.ChildNodes[3].InnerText = _influence.ToString();
            itemNode.ChildNodes[4].InnerText = _learningStrength.ToString();
            itemNode.ChildNodes[5].InnerText = _minimumGames.ToString();
            itemNode.ChildNodes[6].InnerText = _upToMove.ToString();
        }

        public void LoadOptimize(XmlDocument xmldoc)
        {
            _nodePath = "/BookOptionsData/BookOptionsOptimize";
            XmlElement root = xmldoc.DocumentElement;
            XmlNode itemNode = root.SelectNodes(_nodePath).Item(0);

            _useBook = Convert.ToBoolean(itemNode.ChildNodes[0].InnerText);
            _tournamentBook = Convert.ToBoolean(itemNode.ChildNodes[1].InnerText);
            _varietyOfPlay = Convert.ToInt32(itemNode.ChildNodes[2].InnerText);
            _influence = Convert.ToInt32(itemNode.ChildNodes[3].InnerText);
            _learningStrength = Convert.ToInt32(itemNode.ChildNodes[4].InnerText);
            _minimumGames = Convert.ToInt32(itemNode.ChildNodes[5].InnerText);
            _upToMove = Convert.ToInt32(itemNode.ChildNodes[6].InnerText);
        }

        public void LoadNormal(XmlDocument xmldoc)
        {
            _nodePath = "/BookOptionsData/BookOptionsNormal";
            XmlElement root = xmldoc.DocumentElement;
            XmlNode itemNode = root.SelectNodes(_nodePath).Item(0);

            _useBook = Convert.ToBoolean(itemNode.ChildNodes[0].InnerText);
            _tournamentBook = Convert.ToBoolean(itemNode.ChildNodes[1].InnerText);
            _varietyOfPlay = Convert.ToInt32(itemNode.ChildNodes[2].InnerText);
            _influence = Convert.ToInt32(itemNode.ChildNodes[3].InnerText);
            _learningStrength = Convert.ToInt32(itemNode.ChildNodes[4].InnerText);
            _minimumGames = Convert.ToInt32(itemNode.ChildNodes[5].InnerText);
            _upToMove = Convert.ToInt32(itemNode.ChildNodes[6].InnerText);
        }

        public void LoadHandicap(XmlDocument xmldoc)
        {
            _nodePath = "/BookOptionsData/BookOptionsHandicap";
            XmlElement root = xmldoc.DocumentElement;
            XmlNode itemNode = root.SelectNodes(_nodePath).Item(0);

            _useBook = Convert.ToBoolean(itemNode.ChildNodes[0].InnerText);
            _tournamentBook = Convert.ToBoolean(itemNode.ChildNodes[1].InnerText);
            _varietyOfPlay = Convert.ToInt32(itemNode.ChildNodes[2].InnerText);
            _influence = Convert.ToInt32(itemNode.ChildNodes[3].InnerText);
            _learningStrength = Convert.ToInt32(itemNode.ChildNodes[4].InnerText);
            _minimumGames = Convert.ToInt32(itemNode.ChildNodes[5].InnerText);
            _upToMove = Convert.ToInt32(itemNode.ChildNodes[6].InnerText);
        }

        #endregion
    }
}
