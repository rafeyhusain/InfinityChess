using System;
using App.Model;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Collections;
using System.IO;
using InfinitySettings.Streams;

namespace InfinityChess.TournamentManager
{
    public class Tournament
    {
        #region DataMembers 

        public Game Game = null;
        public InfinityChess.Data.Kv.Tournament.TournamentParticipantsRow Participant1 = null;
        public InfinityChess.Data.Kv.Tournament.TournamentParticipantsRow Participant2 = null;
        public WinForms.MainForm frmMainForm;
        public string FilePath = "";
        public InfinityChess.Data.Kv.Tournament DataSet = new InfinityChess.Data.Kv.Tournament();

        public ArrayList ParticipitantList = new ArrayList();
        public int CurrentMatchID = 0;
        public bool IsDataChange = false;

        #endregion

        #region Events
        
        #endregion

        #region Ctor 

        public Tournament(Game game)
        {
            this.Game = game;
        }

        #endregion

        #region Load & Save
        public void Load()
        {
            Load(this.FilePath);
        }

        public void Load(string filePath)
        {
            //if (File.Exists(filePath))
            //{
            //    DataSet.ReadXml(filePath);
            //}
            //else
            //{
            //    DataSet.WriteXml(filePath);
            //}

            if (File.Exists(filePath))
            {
                MemoryStream memoryStream = InfinityStreamsManager.ReadStreamFromFile(filePath);
                DataSet.ReadXml(memoryStream);
                memoryStream.Close();
            }
            else
            {
                Save(filePath);
            }
        }

        public void Save()
        {
            Save(this.FilePath);
        }

        public void Save(string filePath)
        {
            //UFile.RemoveReadOnly(filePath);
            //DataSet.WriteXml(filePath);

            MemoryStream memoryStream = new MemoryStream();
            DataSet.WriteXml(memoryStream);
            InfinityStreamsManager.WriteStreamToFile(filePath, memoryStream);
            memoryStream.Close();
        }


        #endregion




        public string FileName
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return System.IO.Path.GetFileNameWithoutExtension(FilePath); }
        }

        public ArrayList EngineParticipitant
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                ArrayList list = new ArrayList();

                foreach (InfinityChess.Data.Kv.Tournament.TournamentParticipantsRow row in DataSet.TournamentParticipants.Rows)
                {
                    if (row.IsEngine)
                    {
                        list.Add(row.Name);
                    }
                }

                return list;
            }
        }

        #region Settings
        #region Main
        public string TournamentGuid
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return Kv.Get(DataSet.Kv, "TournamentGuid");
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                Kv.Set(DataSet.Kv, "TournamentGuid", value);
            }
        }
        public string Title
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return Kv.Get(DataSet.Kv, "Title");
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                Kv.Set(DataSet.Kv, "Title", value);
            }
        }

        public int TimeControl
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return Kv.GetInt32(DataSet.Kv, "TimeControl");
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                Kv.Set(DataSet.Kv, "TimeControl", value);
            }
        }


        public GameType GameType
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                switch (TimeControl)
                {
                    case 0:
                        return GameType.Blitz;

                    case 1:
                        return GameType.Long;

                    default:
                        return GameType.None;
                }
            }
        }

        public int TournamentType
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return Kv.GetInt32(DataSet.Kv, "TournamentType");
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                Kv.Set(DataSet.Kv, "TournamentType", value);
            }
        }

        public decimal Cycles
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(DataSet.Kv, "Cycles");
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                Kv.Set(DataSet.Kv, "Cycles", value);
            }
        }

        public decimal MoveLimit
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(DataSet.Kv, "MoveLimit");
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                Kv.Set(DataSet.Kv, "MoveLimit", value);
            }
        }

        public bool PermenantBrain
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return Kv.GetBool(DataSet.Kv, "PermenantBrain");
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                Kv.Set(DataSet.Kv, "PermenantBrain", value);
            }
        }

        public bool BookLearning
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return Kv.GetBool(DataSet.Kv, "BookLearning");
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                Kv.Set(DataSet.Kv, "BookLearning", value);
            }
        }

        public bool OpeningDb
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return Kv.GetBool(DataSet.Kv, "OpeningDb");
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                Kv.Set(DataSet.Kv, "OpeningDb", value);
            }
        }

        public int FirstGame
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return Kv.GetInt32(DataSet.Kv, "FirstGame");
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                Kv.Set(DataSet.Kv, "FirstGame", value);
            }
        }

        public bool AlternarteColors
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return Kv.GetBool(DataSet.Kv, "AlternarteColors");
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                Kv.Set(DataSet.Kv, "AlternarteColors", value);
            }
        }
        #endregion

        #region Blitz

        public decimal BlitzTimeMin
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(DataSet.Kv, "BlitzTimeMin");
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                Kv.Set(DataSet.Kv, "BlitzTimeMin", value);
            }
        }
        public decimal BlitzGain
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(DataSet.Kv, "BlitzGain");
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                Kv.Set(DataSet.Kv, "BlitzGain", value);
            }
        }
        public decimal BlitzHumanGain
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(DataSet.Kv, "BlitzHumanGain");
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                Kv.Set(DataSet.Kv, "BlitzHumanGain", value);
            }
        }
        public decimal BlitzHumanGainPerMove
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(DataSet.Kv, "BlitzHumanGainPerMove");
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                Kv.Set(DataSet.Kv, "BlitzHumanGainPerMove", value);
            }
        }
        public int BlitzDefaults
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return Kv.GetInt32(DataSet.Kv, "BlitzDefaults");
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                Kv.Set(DataSet.Kv, "BlitzDefaults", value);
            }
        }
        #endregion

        #region Long
        public int LongDefaults
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return Kv.GetInt32(DataSet.Kv, "LongDefaults");
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                Kv.Set(DataSet.Kv, "LongDefaults", value);
            }
        }

        #region First
        public decimal LongFirstHour
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(DataSet.Kv, "LongFirstHour");
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                Kv.Set(DataSet.Kv, "LongFirstHour", value);
            }
        }
        public decimal LongFirstMin
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(DataSet.Kv, "LongFirstMin");
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                Kv.Set(DataSet.Kv, "LongFirstMin", value);
            }
        }
        public decimal LongFirstMoves
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(DataSet.Kv, "LongFirstMoves");
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                Kv.Set(DataSet.Kv, "LongFirstMoves", value);
            }
        }
        public decimal LongFirstGain
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(DataSet.Kv, "LongFirstGain");
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                Kv.Set(DataSet.Kv, "LongFirstGain", value);
            }
        }
        #endregion

        #region Second
        public decimal LongSecondHour
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(DataSet.Kv, "LongSecondHour");
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                Kv.Set(DataSet.Kv, "LongSecondHour", value);
            }
        }
        public decimal LongSecondMin
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(DataSet.Kv, "LongSecondMin");
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                Kv.Set(DataSet.Kv, "LongSecondMin", value);
            }
        }
        public decimal LongSecondMoves
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(DataSet.Kv, "LongSecondMoves");
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                Kv.Set(DataSet.Kv, "LongSecondMoves", value);
            }
        }
        public decimal LongSecondGain
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(DataSet.Kv, "LongSecondGain");
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                Kv.Set(DataSet.Kv, "LongSecondGain", value);
            }
        }
        #endregion

        #region Third
        public decimal LongThirdHour
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(DataSet.Kv, "LongThirdHour");
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                Kv.Set(DataSet.Kv, "LongThirdHour", value);
            }
        }
        public decimal LongThirdMin
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(DataSet.Kv, "LongThirdMin");
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                Kv.Set(DataSet.Kv, "LongThirdMin", value);
            }
        }

        public decimal LongThirdGain
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return Kv.GetDecimal(DataSet.Kv, "LongThirdGain");
            }
            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                Kv.Set(DataSet.Kv, "LongThirdGain", value);
            }
        }
        #endregion
        #endregion

        #endregion

        #region Participitant

        public void UpdateParticipitant(string name, string newName)
        {
            DataSet.TournamentParticipants.DefaultView.RowFilter = "Name='" + name + "'";

            if (DataSet.TournamentParticipants.DefaultView.Count > 0)
            {
                DataSet.TournamentParticipants.DefaultView[0]["name"] = newName;
                DataSet.AcceptChanges();
                IsDataChange = true;
            }
            DataSet.TournamentParticipants.DefaultView.RowFilter = "";
        }

        public void AddParticipitant(string name, bool isEngine)
        {
            DataSet.TournamentParticipants.DefaultView.RowFilter = "Name='" + name + "' AND IsEngine=" + isEngine;

            if (DataSet.TournamentParticipants.DefaultView.Count == 0)
            {
                InfinityChess.Data.Kv.Tournament.TournamentParticipantsRow row = DataSet.TournamentParticipants.NewTournamentParticipantsRow();

                row.Name = name.Replace(".exe", "");
                row.IsEngine = isEngine;
                DataSet.TournamentParticipants.Rows.Add(row);
                DataSet.AcceptChanges();
                IsDataChange = true;
            }

            DataSet.TournamentParticipants.DefaultView.RowFilter = "";
        }

        public void DeleteParticipitant(string name, bool isEngine)
        {
            DataSet.TournamentParticipants.DefaultView.RowFilter = "Name='" + name + "' AND IsEngine=" + isEngine;

            if (DataSet.TournamentParticipants.DefaultView.Count != 0)
            {
                DataSet.TournamentParticipants.DefaultView[0].Delete();
                DataSet.TournamentParticipants.AcceptChanges();
                IsDataChange = true;
            }

            DataSet.TournamentParticipants.DefaultView.RowFilter = "";
        }
        #endregion

        #region Match DataSet table matchs Add Update functions

        //*************************************************

        public string GetNextHumanMatch()
        {
            Participant1 = null;
            Participant2 = null;
            DataSet.TournamentMatchs.DefaultView.RowFilter = "IsFinished='" + false + "'";

            foreach (DataRowView Row in DataSet.TournamentMatchs.DefaultView)
            {
                DataSet.TournamentParticipants.DefaultView.RowFilter = "Name in ('" + Row["Participant1"].ToString() + "','" + Row["Participant2"].ToString() + "')";

                if (DataSet.TournamentParticipants.DefaultView[0]["IsEngine"].ToString() == "False")
                {
                    CurrentMatchID = (int)Row["TournamentMatchID"];
                    Participant1 = (InfinityChess.Data.Kv.Tournament.TournamentParticipantsRow)DataSet.TournamentParticipants.DefaultView[0].Row;
                    Participant2 = (InfinityChess.Data.Kv.Tournament.TournamentParticipantsRow)DataSet.TournamentParticipants.DefaultView[1].Row;
                }
                else if (DataSet.TournamentParticipants.DefaultView[1]["IsEngine"].ToString() == "False")
                {
                    CurrentMatchID = (int)Row["TournamentMatchID"];
                    Participant1 = (InfinityChess.Data.Kv.Tournament.TournamentParticipantsRow)DataSet.TournamentParticipants.DefaultView[1].Row;
                    Participant2 = (InfinityChess.Data.Kv.Tournament.TournamentParticipantsRow)DataSet.TournamentParticipants.DefaultView[0].Row;
                }
            }

            if (Participant1 == null || Participant2 == null)
            {
                DataSet.TournamentParticipants.DefaultView.RowFilter = "";
                DataSet.TournamentMatchs.DefaultView.RowFilter = "";
                return "Finished";
            }

            DataSet.TournamentParticipants.DefaultView.RowFilter = "";
            DataSet.TournamentMatchs.DefaultView.RowFilter = "";
            return "";
        }



        public string GetNextMatch()
        {
            DataSet.TournamentMatchs.DefaultView.RowFilter = "IsFinished='" + false + "'";

            if (DataSet.TournamentMatchs.DefaultView.Count > 0)
            {
                CurrentMatchID = (int)DataSet.TournamentMatchs.DefaultView[0]["TournamentMatchID"];
                string P1 = DataSet.TournamentMatchs.DefaultView[0]["Participant1"].ToString();
                string P2 = DataSet.TournamentMatchs.DefaultView[0]["Participant2"].ToString();

                DataSet.TournamentParticipants.DefaultView.RowFilter = "Name in ('" + P1 + "','" + P2 + "')";

                if (DataSet.TournamentParticipants.DefaultView[0]["IsEngine"].ToString() == "False")
                {
                    Participant1 = (InfinityChess.Data.Kv.Tournament.TournamentParticipantsRow)DataSet.TournamentParticipants.DefaultView[0].Row;
                    Participant2 = (InfinityChess.Data.Kv.Tournament.TournamentParticipantsRow)DataSet.TournamentParticipants.DefaultView[1].Row;
                }
                else
                {
                    Participant1 = (InfinityChess.Data.Kv.Tournament.TournamentParticipantsRow)DataSet.TournamentParticipants.DefaultView[1].Row;
                    Participant2 = (InfinityChess.Data.Kv.Tournament.TournamentParticipantsRow)DataSet.TournamentParticipants.DefaultView[0].Row;
                }
                // string strP1AndP2 = P1 + "," + P2 + "," + GameMode.ToString();

                DataSet.TournamentParticipants.DefaultView.RowFilter = "";

                return "";
            }
            else
            {
                return "Finished";
            }

        }


        public void RunNextHumanMatch()
        {

            string strNextMatch = GetNextHumanMatch();

            if (strNextMatch != "Finished")
            {
                RecreateMainForm();
                this.Game.AfterFinish += new EventHandler(Instance_AfterFinish);
                //InfinityChess.InfinityGlobal.MainForm.Start(this);

            }
            else
            {
                MessageBox.Show(strNextMatch);
            }
        }


        public void RunNextMatch()
        {

            string strNextMatch = GetNextMatch();

            if (strNextMatch != "Finished")
            {
                RecreateMainForm();
                this.Game.AfterFinish += new EventHandler(Instance_AfterFinish);
                //InfinityChess.InfinityGlobal.MainForm.Start(this);

            }
            else
            {
                MessageBox.Show(strNextMatch);
            }
        }

        private void RecreateMainForm()
        {
            if (frmMainForm != null)
            {
                frmMainForm.Close();
                frmMainForm = null;
            }

            //frmMainForm = new InfinityChess.WinForms.MainForm();
            //InfinityChess.Abstract.InfinityGlobal.MainForm = frmMainForm;
            //frmMainForm.MdiParent = InfinityChess.Abstract.InfinityGlobal.OfflineClientForm;   
            //frmMainForm.Show();
        }

        public void AddMatch(string Player1, string Player2)
        {
            InfinityChess.Data.Kv.Tournament.TournamentMatchsRow Row = DataSet.TournamentMatchs.NewTournamentMatchsRow();
            Row.Participant1 = Player1;
            Row.Participant2 = Player2;
            Row.Result = "";
            DataSet.TournamentMatchs.Rows.Add(Row);
            DataSet.AcceptChanges();

        }

        public void UpdateMatch(int MatchID, string Result)
        {

            DataSet.TournamentMatchs.Rows.Find(MatchID)["Result"] = Result;
            DataSet.TournamentMatchs.Rows.Find(CurrentMatchID)["IsFinished"] = true;
            DataSet.TournamentMatchs.AcceptChanges();
        }

        public void DeleteAllMatchs()
        {
            DataSet.TournamentMatchs.Columns[0].AutoIncrement = false;

            DataSet.TournamentMatchs.Rows.Clear();
            DataSet.TournamentMatchs.AcceptChanges();
            DataSet.TournamentMatchs.Columns[0].AutoIncrement = true;
            DataSet.TournamentMatchs.Columns[0].AutoIncrementSeed = 1;

        }

        #endregion

        public void Start()
        {
            //this.Game.AfterFinish += new EventHandler(Instance_AfterFinish);

            //PlayNextMatch();
        }

        void Instance_AfterFinish(object sender, EventArgs e)
        {

            //this.Game .GameResult 

            UpdateMatch(CurrentMatchID, this.Game.GameResult.ToString());
            Save();
            //if (AfterTournamentMatchFinish != null)
            //{
            //    AfterTournamentMatchFinish(this, EventArgs.Empty);
            //}

            //PlayNextMatch();
        }

        public void PlayNextMatch()
        {
            for (int i = 0; i < DataSet.TournamentParticipants.Rows.Count; i++)
            {
                if (i + 1 >= DataSet.TournamentParticipants.Rows.Count)
                {
                    break;
                }

                for (int j = i + 1; j < DataSet.TournamentParticipants.Rows.Count; j++)
                {
                    InfinityChess.Data.Kv.Tournament.TournamentParticipantsRow px = null;

                    px = DataSet.TournamentParticipants[i];
                    if (!px.IsEngine)
                    {
                        Participant1 = px;
                        Participant2 = DataSet.TournamentParticipants[j];
                    }

                    px = DataSet.TournamentParticipants[j];
                    if (!px.IsEngine)
                    {
                        Participant1 = px;
                        Participant2 = DataSet.TournamentParticipants[i];
                    }
                    else
                    {
                        Participant1 = DataSet.TournamentParticipants[i];
                        Participant2 = DataSet.TournamentParticipants[j];
                    }

                    if (!HasPlayed(Participant1, Participant2))
                    {
                        this.Game.Stop();
                    }
                }
            }
        }

        private bool HasPlayed(InfinityChess.Data.Kv.Tournament.TournamentParticipantsRow Participant1, InfinityChess.Data.Kv.Tournament.TournamentParticipantsRow Participant2)
        {
            DataSet.TournamentMatchs.DefaultView.RowFilter = "Player1='" + Participant1.Name + "' AND Player2='" + Participant2.Name + "'";

            bool played = DataSet.TournamentMatchs.DefaultView.Count != 0;

            DataSet.TournamentMatchs.DefaultView.RowFilter = "";

            return played;
        }

        public GameMode GameMode
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return GetGameMode(Participant1, Participant2); }
        }

        public App.Model.PlayerType Participant1PlayerType
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return GetPlayerType(Participant1); }
        }

        public App.Model.PlayerType Participant2PlayerType
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return GetPlayerType(Participant2); }
        }

        private App.Model.PlayerType GetPlayerType(InfinityChess.Data.Kv.Tournament.TournamentParticipantsRow p1)
        {
            if (p1.IsEngine)
                return App.Model.PlayerType.Engine;
            else
                return App.Model.PlayerType.Human;
        }

        private GameMode GetGameMode(InfinityChess.Data.Kv.Tournament.TournamentParticipantsRow p1, InfinityChess.Data.Kv.Tournament.TournamentParticipantsRow p2)
        {
            if (p1.IsEngine && p2.IsEngine)
                return GameMode.EngineVsEngine;

            else if (!p1.IsEngine && p2.IsEngine)
                return GameMode.HumanVsEngine;

            else if (p1.IsEngine && !p2.IsEngine)
                return GameMode.HumanVsEngine;

            else
                return GameMode.None;
        }

        public int GetNoOfMatches(int Games)
        {
            int i, j, t = 1, NM = 0;
            for (i = 1; i < Games; i++)
            {

                for (j = Games; j > t; j--)
                {

                    NM++;
                }
                t++;

            }

            return NM;
        }

        public void GetNoOfMatches(ListBox Lb)
        {

            string str = "";
            int Games = Lb.Items.Count;


            int i, j, t = 1, NM = 0;
            for (i = 1; i < Games; i++)
            {

                for (j = Games; j > t; j--)
                {

                    str = str + Lb.Items[i - 1].ToString() + " vs " + Lb.Items[j - 1].ToString() + ", ";


                    NM++;
                }
                t++;

            }

            MessageBox.Show(str);

        }

        public void SaveTournomrntMatches(ListBox Lb)
        {
            if (IsDataChange == true)
            {
                TournamentGuid = Guid.NewGuid().ToString();
                int Games = Lb.Items.Count;
                
                int i, j, t = 1;

                DeleteAllMatchs();
                for (i = 1; i < Games; i++)
                {

                    for (j = Games; j > t; j--)
                    {
                        string P1 = Lb.Items[i - 1].ToString();
                        string P2 = Lb.Items[j - 1].ToString();

                        AddMatch(P1, P2);
                        int RowID = DataSet.TournamentMatchs.Rows.Count - 1;
                        int MatchID = (int)DataSet.TournamentMatchs.Rows[RowID]["TournamentMatchID"];
                        SaveGame(P1, P2, MatchID);
                    }
                    t++;

                }

            }


        }



        private void SaveGame(string P1, string P2, int MatchID)
        {

            App.Model.GameData _GameData = new App.Model.GameData(this.Game);

            // Players and Result
            _GameData.White1 = P1;
            _GameData.White2 = P1;
            _GameData.Black1 = P2;
            _GameData.Black2 = P2;
            _GameData.Tournament = Title;
            _GameData.TournamentGuid = TournamentGuid;
            _GameData.IsECO = false;
            _GameData.EcoCode = "344";
            _GameData.IsEloWhite = false;
            _GameData.EloWhite = 0;
            _GameData.IsEloBlack = false;
            _GameData.EloBlack = 0;

            _GameData.Result = "";

            _GameData.ResultSymbol = "";

            _GameData.IsYear = false;
            _GameData.Year = 0;
            _GameData.IsMonth = false;
            _GameData.Month = 0;
            _GameData.IsDay = false;
            _GameData.Day = 0;

            _GameData.TournamentMatchID = MatchID;

            string gameXml = UData.ToString(_GameData.Kv.DataTable);
            string fileName = "uba.icd";// InfinityChess.Offline.Forms.GlobalSet.Default.CurrentGameFile;
            if (gameXml != "")
            {
                Ap.LoadDatabase(fileName);
                Ap.Database.AppendGame(gameXml);
                Ap.Database.Save();
            }
        }

        private void SaveGame1()
        {
            App.Model.GameData GD = new App.Model.GameData(this.Game);
            this.Game.GetGameXml();

            string fileName = "Tournaments.icd";// InfinityChess.Offline.Forms.GlobalSet.Default.CurrentGameFile;
            this.Game.SaveGame(fileName);
        }

    }
}
