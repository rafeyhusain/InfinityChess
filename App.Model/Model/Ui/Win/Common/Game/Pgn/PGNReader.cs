using System; 
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using App.Model;
using System.Data;
using System.Drawing;
using System.Diagnostics;
namespace InfinityChess.PGNManager
{
    #region PGN Reader Class

    public class PGNReader
    {
        #region DataMembers 

        public App.Model.Game Game = null;
        
        #endregion

        #region Ctor 

        public PGNReader(App.Model.Game game)
        {
            this.Game = game;
        }

        #endregion

        #region Properties

        private string _fileContent;

        public string FileContent
        {
            [DebuggerStepThrough]
            get { return _fileContent; }
            [DebuggerStepThrough]
            set { _fileContent = value; }
        }

        private List<Game> _games;

        public List<Game> Games
        {
            [DebuggerStepThrough]
            get { return _games; }
            [DebuggerStepThrough]
            set { _games = value; }
        }

        #endregion

        #region Methods

        public void LoadGames(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            string fileContent = reader.ReadToEnd();
            reader.Close();
            reader = null;

            _fileContent = fileContent;
            Parse(fileContent);
        }

        public void CopyGame()
        {
            String white = this.Game.Player1.PlayerTitle;
            String black = this.Game.Player2.PlayerTitle;

            TagPairs tp = new TagPairs();
            FileContent += tp.Event = "[Event \"" + this.Game.GameType.ToString() + "\"]" + Environment.NewLine;
            FileContent += tp.Site = "[Site \"?\"]" + Environment.NewLine;
            FileContent += tp.Date = "[Date \"" + DateTime.Now.ToString() + "\"]" + Environment.NewLine;
            FileContent += tp.Round = "[Round \"?\"]" + Environment.NewLine;
            FileContent += tp.White = "[White \"" + white + "\"]" + Environment.NewLine;
            FileContent += tp.Black = "[Black \"" + black + "\"]" + Environment.NewLine;
            
            if (!ChessLibrary.FenParser.IsInitialFen(this.Game.InitialBoardFen))
            {
                FileContent += tp.Fen = "[Fen \"" + this.Game.InitialBoardFen + "\"]" + Environment.NewLine;
            }

            FileContent += tp.Result = "[Result \"*\"]" + Environment.NewLine;

            String notations = GetNotationsFromDataTable();

            FileContent = FileContent + Environment.NewLine + notations;
            System.Windows.Forms.Clipboard.SetText(FileContent);
        }

        public string GetNotationsFromDataTable()
        {
            String notations = String.Empty;
            
            Moves moves = this.Game.Moves;

            for (int i = 0; i < moves.Count; i++)
            {
                notations += moves[i].SingleNotation + " ";
            }

            return (notations + Environment.NewLine);
        }

        public string GetNotations()
        {
            return "";
        }

        public string GetNotationsForPrint()
        {
            return "";
        }

        public void PasteGame()
        {
            StreamReader reader = new StreamReader("PgnFenFile.txt");
            string fileContent = reader.ReadToEnd();
            reader.Close();
            reader = null;

            _fileContent = fileContent;

            if (!String.IsNullOrEmpty(_fileContent))
            {
                string[] copiedString = _fileContent.Split('|');
                if (!String.IsNullOrEmpty(copiedString[1]) && !String.IsNullOrEmpty(copiedString[2]))
                {
                    SetNotations(copiedString[1], copiedString[2]);
                }
            }
        }

        private void SetNotations(String copiedStringNotation, String copiedStringFEN)
        {
            
        }

        private void Parse(string fileContent)
        {
            string[] gameSeparators = { " 1-0", " 0-1", " 1/2-1/2", " 0.5-0.5", " *" };
            string[] gamesContent = fileContent.Split(gameSeparators, StringSplitOptions.RemoveEmptyEntries);

            _games = new List<Game>();
            foreach (string gameContent in gamesContent)
            {
                if (gameContent != "\r\n\r\n")
                {
                    Game game = new Game();
                    game.Load(gameContent);
                    _games.Add(game);
                }
            }
        }

        #endregion
    }

    #endregion

    #region Helper Classes

    public class Game
    {
        #region Properties

        private TagPairs _pgnTagPairs;

        public TagPairs PGNTagPairs
        {
            get { return _pgnTagPairs; }
            set { _pgnTagPairs = value; }
        }

        private MoveText _pgnMoveText;

        public MoveText PGNMoveText
        {
            get { return _pgnMoveText; }
            set { _pgnMoveText = value; }
        }

        public void Load(string gameContent)
        {
            string[] setsSeparators = { "\r\n\r\n" };
            string[] sets = gameContent.Split(setsSeparators, StringSplitOptions.RemoveEmptyEntries);

            if (sets.Length > 0)
            {
                _pgnTagPairs = new TagPairs();
                _pgnTagPairs.Load(sets[0].Trim());

                _pgnMoveText = new MoveText();
                _pgnMoveText.Load(sets[1].Trim());
            }
        }

        #endregion
    }

    public class TagPairs
    {
        public TagPairs()
        {

        }

        #region Properties

        private string _tagsContent;

        public string TagsContent
        {
            get { return _tagsContent; }
            set { _tagsContent = value; }
        }


        private string _event;
        public string Event
        {
            get { return _event; }
            set { _event = value; }
        }

        private string _site;
        public string Site
        {
            get { return _site; }
            set { _site = value; }
        }

        private string _date;

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }

        private string _round;

        public string Round
        {
            get { return _round; }
            set { _round = value; }
        }

        private string _white;

        public string White
        {
            get { return _white; }
            set { _white = value; }
        }

        private string _black;

        public string Black
        {
            get { return _black; }
            set { _black = value; }
        }

        private string _result;

        public string Result
        {
            get { return _result; }
            set { _result = value; }
        }

        private string _fen;

        public string Fen
        {
            get { return _fen; }
            set { _fen = value; }
        }

        #endregion

        #region Methods

        public void Load(string tagsContent)
        {
            _tagsContent = tagsContent;
            Parse(tagsContent);
        }

        private void Parse(string tagsContent)
        {
            string[] tagsSeparators = { "[", "]", "\r\n" };
            string[] tags = tagsContent.Split(tagsSeparators, StringSplitOptions.RemoveEmptyEntries);

            string[] tagNameValuePair;
            string tagName = string.Empty;
            string tagValue = string.Empty;
            foreach (string tag in tags)
            {
                tagNameValuePair = tag.Split("\"".ToCharArray());
                tagName = tagNameValuePair[0].Trim();
                tagValue = tagNameValuePair[1].Trim();
                AssignToField(tagName, tagValue);
            }
        }

        private void AssignToField(string tagName, string tagValue)
        {
            switch (tagName)
            {
                case "Event":
                    {
                        _event = tagValue;
                        break;
                    }
                case "Site":
                    {
                        _site = tagValue;
                        break;
                    }
                case "Date":
                    {
                        _date = tagValue;
                        break;
                    }
                case "Round":
                    {
                        _round = tagValue;
                        break;
                    }
                case "White":
                    {
                        _white = tagValue;
                        break;
                    }
                case "Black":
                    {
                        _black = tagValue;
                        break;
                    }
                case "Result":
                    {
                        _result = tagValue;
                        break;
                    }
                default:
                    break;
            }
        }

        #endregion

    }

    public class MoveText
    {
        public MoveText()
        {

        }

        #region Properties

        private string _moveTextContent;
        public string MoveTextContent
        {
            get { return _moveTextContent; }
            set { _moveTextContent = value; }
        }

        #endregion

        #region Methods

        public void Load(string moveTextContent)
        {
            _moveTextContent = moveTextContent;            
        }

        private void Parse(string moveTextContent)
        {

        }

        #endregion

    }

    #endregion
}
