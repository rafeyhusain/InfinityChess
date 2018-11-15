using System;
using App.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfinityChess;
using System.IO;
using InfinitySettings.Streams;

using InfinitySettings.UCIManager;
using System.Data;

namespace App.Model
{
    public partial class Game
    {
        #region Properties 

        #endregion

        #region Methods 

        public void Start(GameMode gameMode, GameType gameType)
        {
            GameMode = gameMode;
            GameType = gameType;




            Options.Instance.CurrentDatabaseFilePath = null;

            offDrawToolStripMenuItem.Enabled = true;
            resignToolStripMenuItem.Enabled = true;
            tsbResignThisGame.Enabled = true;
            tsbOfferDrawToPlay.Enabled = true;
            infiniteAnalysisToolStripMenuItem.Text = "Infinite Analysis: " + InfinitySettings.Settings.DefaultEngineXml.EngineTitle;
            switchOffEngineToolStripMenuItem.Text = "Switch Off Engine";
            switchOffEngineToolStripMenuItem.Checked = false;
            InfinityChess.InfinityGlobal.MainForm = this;
            InfinityChess.InfinityGlobal.MainOffline = this;
            PrevMove.Enabled = false;
            tsbRetractLastMoveOverwrite.Enabled = false;
            NextMove.Enabled = false;

            if (t != null)
            {
                //InfinityChess.InfinityGlobal.MainForm.Start(t);
            }
            else
            {
                switch (gameMode)
                {
                    case GameMode.None:
                        break;
                    case GameMode.HumanVsHuman:

                        Ap.Game.Stop();
                        Ap.Game.GameMode = GameMode.HumanVsHuman;
                        Ap.Game.GameType = gameType;
                        Ap.Game.Start();

                        StartGame();
                        break;
                    case GameMode.HumanVsEngine:
                        InitDocking();
                        NewGameHumanVsEngine(gameType);
                        break;
                    case GameMode.EngineVsEngine:
                        EngineVsEngine frm = new EngineVsEngine();
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            for (int i = 0; i < menuStrip1.Items.Count; i++)
                            {
                                this.ToggleMenuShortcuts((ToolStripMenuItem)menuStrip1.Items[i], false);
                            }
                            tableLayoutPanel1.Visible = false;
                            menuStrip1.Visible = false;
                            toolStrip1.Visible = false;
                            toolStrip2.Visible = true;

                            InitDocking();

                            NewGameEngineVsEngine(EngineVsEngine.UCIEngineWhite.EngineFile, EngineVsEngine.UCIEngineWhite.HashTableSize,
                                    EngineVsEngine.BookWhite, EngineVsEngine.UCIEngineBlack.EngineFile,
                                    EngineVsEngine.UCIEngineBlack.HashTableSize, EngineVsEngine.BookBlack,
                                    EngineVsEngine.GameType, EngineVsEngine.MoveLimit);
                        }
                        else
                        {
                            NewGame(GameMode.HumanVsEngine);
                        }
                        break;
                    default:
                        break;
                }
            }
            SetStatusbarMessage("Ready - New Game");
            EnableDrawResignButtons(false);
            Flags.IsInfiniteAnalysisOn = false;


            switch (gameMode)
            {
                case GameMode.HumanVsHuman:
                    break;
                case GameMode.HumanVsEngine:
                    break;
                case GameMode.EngineVsEngine:
                    break;
                case GameMode.OnlineHumanVsHuman:
                    break;
                case GameMode.OnlineHumanVsEngine:
                    break;
                case GameMode.OnlineEngineVsEngine:
                    break;
                case GameMode.Kibitzer:
                    break;
            }
        }

        #endregion

    }
}
