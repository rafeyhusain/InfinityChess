using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using App.Model;
using InfinityChess;
using System.IO;
using AppEngine;
using System.Runtime.Serialization.Formatters.Binary;

namespace App.Win
{
    public partial class TestForm : Form
    {
        #region DataMembers 

        protected DockPanel dp;
        InfinityChess.AnalysisUc k1 = null;
        InfinityChess.AnalysisUc k2 = null;
        InfinityChess.AnalysisUc k3 = null;
        public Game Game = null;

        #endregion

        #region Ctor 

        public TestForm(Game game)
        {
            InitializeComponent();
            this.Game = game;
        }

        #endregion

        #region Load

        private void TestForm_Load(object sender, EventArgs e)
        {

        }

        #endregion
        
        #region Events

        private void button1_Click(object sender, EventArgs e)
        {
            LoadPvMoves();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ZipFiles();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TestSerializer();
        }

        #endregion

        #region Load Moves
        Game g;
        private GameW GameWrapper;
        string fen = ChessLibrary.FenParser.InitialBoardFen;
        private void LoadPvMoves()
        {
            g = new Game();
            GameWrapper = new GameW(fen);
            string s = "test";

            for (int i = 0; i < 10000; i++)
            {

                string pv = "b1c3 g8f6 g1f3 b8c6 e2e4 e7e6 d2d4 d7d5 e4d5 f6d5 f1d3 f8e7";
                Moves moves = LoadMoves(pv);
                s = GetMovesString(moves);
                moves = null;
                GC.Collect();
            }

            MessageForm.Show("Finished : " + s);
        }

        private Moves LoadMoves(string pv)
        {
            Moves moves = new Moves(Moves.GetMovesTable());
            try
            {
                GameWrapper.SetFen(fen);

                string[] pvMoves = pv.Split(" ".ToCharArray());
                int currentMoveNumber = 1;
                bool isWhite = true;
                int tempMoveNumber = currentMoveNumber;
                bool isWhiteMove = isWhite;
                Move m;

                foreach (string move in pvMoves)
                {
                    if (string.IsNullOrEmpty(move))
                        continue;
                    if (GameWrapper.IsLegalMove(move))
                    {
                        m = App.Model.Move.NewMove();
                        m.Game = g;
                        m.MoveNo = tempMoveNumber;
                        m.IsWhite = isWhiteMove;
                        m.From = move.Substring(0, 2);
                        m.To = move.Substring(2, 2);
                        m.Piece = Board.PieceFromString(GameWrapper.GetMovingPiece(move));
                        m.Flags.IsCapture = GameWrapper.IsCapturingMove(move);
                        m.Flags.IsPromotion = GameWrapper.IsPromotionMove(move);
                        m.Flags.IsLongCastling = GameWrapper.IsLongCastlingMove(move);
                        m.Flags.IsShortCastling = GameWrapper.IsShortCastlingMove(move);
                        m.Flags.IsInCheck = GameWrapper.IsCheckingMove(move);
                        m.Flags.IsMated = GameWrapper.IsCheckMatingMove(move);
                        m.Flags.IsStaleMated = GameWrapper.IsStaleMatingMove(move);
                        m.Flags.IsAmbigousMove = GameWrapper.IsAmbiguousMove(move);
                        m.Flags.IsAmbigousMoveColumn = GameWrapper.IsAmbiguousFile(move);
                        m.Flags.IsAmbigousMoveRow = GameWrapper.IsAmbiguousRank(move);

                        if (m.Flags.IsCapture)
                        {
                            m.CapturedPiece = Board.PieceFromString(GameWrapper.GetMovingPiece(move));
                        }
                        if (m.Flags.IsMated)
                        {
                            m.Flags.IsInCheck = false;
                        }
                        GameWrapper.AppendMove(move);

                        moves.DataTable.ImportRow(m.DataRow);

                        isWhiteMove = !isWhiteMove;

                        if (isWhiteMove)
                        {
                            tempMoveNumber++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.Write(ex);
            }
            return moves;
        }

        private string GetMovesString(Moves moves)
        {
            StringBuilder formattedPv = new StringBuilder();
            bool isFirstMove = true;
            Move m;
            for (int i = 0; i < moves.Count; i++)
            {
                m = moves[i];
                if (isFirstMove)
                {
                    formattedPv.Append(m.MoveNo + "...");
                }
                else
                {
                    formattedPv.Append(" ");
                }

                formattedPv.Append(m.Notation.Substring(m.Notation.IndexOf(".") + 1));
                formattedPv.Append(" ");

                isFirstMove = false;
            }
            return formattedPv.ToString();

        }

        #endregion

        #region NewGame 

        Game gE2e;

        private void NewGame()
        {
            for (int i = 0; i < 100; i++)
            {
                NewGameE2E();
            }
            MessageForm.Show("100 Game(s) Done");
        }

        private void NewGameE2E()
        {
            Ap.Game.Player1EngineFileName = "E:\\Projects\\Common\\Engines\\Rybka_v2.1c.demo.w32.exe";
            Ap.Game.Player2EngineFileName = "C:\\Documents and Settings\\user\\My Documents\\InfinityChess\\Data\\Engines\\TogaII.exe";

            Ap.Game.Player1EngineHashTableSize = 311;
            Ap.Game.Player2EngineHashTableSize = 311;

            Ap.Game.NewGame(GameMode.EngineVsEngine, Ap.Options.GameType);
        }

        #endregion

        #region NewZipFiles 

        private void ZipFiles()
        {
            ZipFolderFiles(@"C:\Documents and Settings\user\My Documents\InfinityChess\Data\Books", "icb");
            ZipFolderFiles(@"C:\Documents and Settings\user\My Documents\InfinityChess\Data\Database", "icd");
            ZipFolderFiles(@"C:\Documents and Settings\user\My Documents\InfinityChess\Data\EngineParameter", "param");
            ZipFolderFiles(@"C:\Documents and Settings\user\My Documents\InfinityChess\Data\Kv", "icx");
            ZipFolderFiles(@"C:\Documents and Settings\user\My Documents\InfinityChess\Data\Kv", "icp");
            ZipFolderFiles(@"C:\Documents and Settings\user\My Documents\InfinityChess\Data\Kv", "thm");
        }

        #region Test Methods

        private void ZipFolderFiles(string folderPath, string filesExtension)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(folderPath);
            System.IO.FileInfo[] files = dir.GetFiles("*." + filesExtension);
            List<string> fileNames = new List<string>();
            foreach (System.IO.FileInfo item in files)
            {
                fileNames.Add(item.FullName);
            }

            foreach (string file in fileNames)
            {
                ZipFile(file);
            }
        }

        private void ZipFile(string fileName)
        {
            string s = InfinitySettings.Streams.InfinityReader.ReadToEnd(fileName);
            UZip.WriteZip(fileName, s);
        }

        private void UnzipFolderFiles(string folderPath)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(folderPath);
            System.IO.FileInfo[] files = dir.GetFiles("*.xml");
            List<string> fileNames = new List<string>();
            foreach (System.IO.FileInfo item in files)
            {
                fileNames.Add(item.FullName);
            }

            foreach (string file in fileNames)
            {
                UnzipFile(file);
            }
        }

        private void UnzipFile(string fileName)
        {
            string fileContent = InfinitySettings.Streams.InfinityStreamsManager.ReadFromFile(fileName);

            System.IO.StreamWriter writer = new System.IO.StreamWriter(fileName, false);
            writer.WriteLine(fileContent);
            writer.Close();
            writer = null;
        }

        #endregion

        

        #endregion

        #region Test TreeNode 

        string bookFile = Ap.FolderBooks + "t.txt";

        private void TestSerializer()
        {
            ImportGames();

            string fileName = bookFile;
            MySerializer s = new MySerializer();
            s.SerializeObject(fileName, parentNode);

            TreeNode tn = new TreeNode();
            tn = (TreeNode)s.DeSerializeObject(fileName);

            DataTable dt = InitDataTable();

            GetData(dt, parentNode, "-1");
            int r = dt.Rows.Count;
            r += 1;
        }

        TreeNode parentNode = null;
        TreeNode currentParent = null;
        private void ImportGames()
        {
            parentNode = new TreeNode("-1");
            string databaseFileName = @"C:\Documents and Settings\user\Desktop\Pgn Test\sample.icd";
            Database db = new Database(databaseFileName, this.Game);
            List<GameItem> gameItems = db.GetGamesItems();

            if (gameItems != null)
            {
                foreach (GameItem item in gameItems)
                {
                    currentParent = parentNode.Nodes.Add(item.GameData.White1,item.GameData.Black1);
                    ImportGame(item.Moves);
                }
            }
        }

        private void ImportGame(Moves moves)
        {
            Move m = null;
            for (int i = 0; i < moves.Count; i++)
            {
                m = moves[i];
                currentParent = AddNode(currentParent, m);                
            }
        }

        private static DataTable InitDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("I", typeof(int));
            dt.Columns.Add("P", typeof(int));
            dt.Columns.Add("F", typeof(string));
            dt.Columns.Add("N", typeof(string));
            dt.Columns.Add("A", typeof(string));
            dt.Columns.Add("V", typeof(string));
            dt.Columns.Add("R", typeof(string));
            dt.Columns.Add("C", typeof(string));
            dt.Columns.Add("B", typeof(string));
            dt.Columns.Add("G", typeof(string));
            dt.Columns.Add("H", typeof(string));
            dt.Columns.Add("M", typeof(string));
            dt.Columns.Add("E", typeof(string));
            dt.Columns.Add("W", typeof(string));
            dt.Columns.Add("D", typeof(string));
            dt.Columns.Add("Y", typeof(string));
            dt.Columns.Add("O", typeof(string));
            dt.Columns.Add("X", typeof(string));
            dt.Columns.Add("S", typeof(string));
            return dt;
        }
        
        int bookId = 1;
        private TreeNode AddNode(TreeNode parent, Move m)
        {
            int id = bookId++;
            TreeNode move = parent.Nodes.Add("Id", id.ToString());
            move.Nodes.Add("I", id.ToString());
            move.Nodes.Add("P", parent.Text);
            move.Nodes.Add("F", m.From);
            move.Nodes.Add("N", m.To);
            move.Nodes.Add("A", "0");
            move.Nodes.Add("V", "0");
            move.Nodes.Add("R", "0");
            move.Nodes.Add("C", "0");
            move.Nodes.Add("B", "0");
            move.Nodes.Add("G", "0");
            move.Nodes.Add("H", m.White.ToString());
            move.Nodes.Add("M", "0");
            move.Nodes.Add("E", m.Fen);
            move.Nodes.Add("W", "0");
            move.Nodes.Add("D", "0.5");
            move.Nodes.Add("Y", "");
            move.Nodes.Add("O", m.PieceStr);
            move.Nodes.Add("X", m.CapturedPceStr);
            move.Nodes.Add("S", m.MoveFlags);

            return move;
        }

        private string GetTestString()
        {
            string s = @"
<B>
    <I>0</I>
    <P>-1</P>
    <F />
    <T />
    <N>0</N>
    <A>0</A>
    <V>0</V>
    <R>0</R>
    <C>0</C>
    <B>0</B>
    <G>0</G>
    <H>1</H>
    <M>0</M>
    <E>rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1</E>
    <W>0</W>
    <D>0.5</D>
    <Y />
    <O />
    <S />
  </B>";
            return s;
        }

        private void GetData(DataTable dt, TreeNode t, string parentId)
        {
            foreach (TreeNode c in t.Nodes)
            {

                if (c.Nodes.Count > 0)
                {

                    if (c.Text == "M")
                    {
                        DataRow dr = dt.NewRow();
                        dr["I"] = Convert.ToInt32(c.Nodes[0].Text);
                        dr["P"] = Convert.ToInt32(c.Nodes[1].Text);
                        dr["F"] = c.Nodes[2].Text;
                        dr["N"] = c.Nodes[3].Text;
                        dr["A"] = c.Nodes[4].Text;
                        dr["V"] = c.Nodes[5].Text;
                        dr["R"] = c.Nodes[6].Text;
                        dr["C"] = c.Nodes[7].Text;
                        dr["B"] = c.Nodes[8].Text;
                        dr["G"] = c.Nodes[9].Text;
                        dr["H"] = c.Nodes[10].Text;
                        dr["M"] = c.Nodes[11].Text;
                        dr["E"] = c.Nodes[12].Text;
                        dr["W"] = c.Nodes[13].Text;
                        dr["D"] = c.Nodes[14].Text;
                        dr["Y"] = c.Nodes[15].Text;
                        dr["O"] = c.Nodes[16].Text;
                        dr["S"] = c.Nodes[17].Text;

                        dt.Rows.Add(dr);
                    }
                }
            }
        }
        
        #endregion
    }


    #region Testclasses

    class MySerializer
    {

        public void SerializeObject(string filename, object objectToSerialize)
        {
            Stream stream = File.Open(filename, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, objectToSerialize);
            stream.Close();
        }

        public object DeSerializeObject(string filename)
        {
            object objectToSerialize;
            Stream stream = File.Open(filename, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            objectToSerialize = (object)bFormatter.Deserialize(stream);
            stream.Close();
            return objectToSerialize;
        }
    }

    #endregion


}
