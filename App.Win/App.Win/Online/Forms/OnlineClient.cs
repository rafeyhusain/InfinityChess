using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;
using App.Model.Db;
using FullScreenMode;
using InfinityChess;
using InfinityChess.WinForms;
using InfinityChess.Online.Forms;

namespace App.Win
{
    public partial class OnlineClient : Form, IMsgQueueConsumer
    {
        #region Data Members
        FullScreen _FullScreen;

        public RoomUc room;
        bool isNormalClose = true;

        public event EventHandler OnDisconnect = null;
        public event EventHandler OnConnect = null;

        delegate void GetDataByRoom(Kv kv);

        #endregion

        #region Ctor
        public OnlineClient()
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(KeyValues.Instance.GetKeyValue(KeyValueE.RefreshIntervalOnlineClient).Value))
            {
                timer1.Interval = UData.ToInt32(KeyValues.Instance.GetKeyValue(KeyValueE.RefreshIntervalOnlineClient).Value);
            }

            if (!string.IsNullOrEmpty(KeyValues.Instance.GetKeyValue(KeyValueE.Heartbeat).Value))
            {
                timerHeartbeat.Interval = UData.ToInt32(KeyValues.Instance.GetKeyValue(KeyValueE.Heartbeat).Value);
            }

        }
        #endregion

        #region Properties

        public RoomUc RoomUc
        {
            get { return room; }
        }

        #endregion

        #region ConsumeMessage
        void SynchronizeConsumeMessage(Kv kv)
        {
            DoConsumeMessage(kv);
        }

        void DoConsumeMessage(Kv kv)
        {
            MethodNameE MethodName = (MethodNameE)kv.GetInt32("MethodName");

            #region Switch MethodName
            switch (MethodName)
            {
                case MethodNameE.BannedUser:
                    BanUser(kv);
                    break;
                case MethodNameE.KickedUser:
                    KickUser();
                    break;
                case MethodNameE.BlockIP:
                    BlockIP();
                    break;
                case MethodNameE.WriteChatMessage:
                    WriteChatMessage(kv);
                    break;
                case MethodNameE.SystemInformation:
                    SystemInformation(kv);
                    break;
                case MethodNameE.UpdateGameDataByGameID:
                case MethodNameE.Abort:
                    Abort(kv);
                    break;
                case MethodNameE.AvChat:
                    AvChat(kv);
                    break;
                case MethodNameE.ForceLogoff:
                    CloseAllWindows();
                    break;
                case MethodNameE.BlockMachine:
                    BlockMachine(kv);
                    break;
                case MethodNameE.StartTournamentMatch:
                    StartTournamentMatch(kv);
                    break;
                case MethodNameE.PingClient:
                    PingClient();
                    break;
                case MethodNameE.GetDataByRoomID:
                    GetDataByRoomID(kv);
                    break;
            } 
            #endregion
        }

        private void Abort(Kv kv)
        {
        }

        private void WriteChatMessage(Kv kv)
        {
            if ((ChatTypeE)kv.GetInt32("ChatType") == ChatTypeE.AllWindows)
            {
                ChatClient.Write(ChatTypeE.GameWindow, (ChatMessageTypeE)kv.GetInt32("MessageType"), ChatTypeE.GameWindow, kv.Get("Message"), 0);
                ChatClient.Write(ChatTypeE.OnlineClient, (ChatMessageTypeE)kv.GetInt32("MessageType"), ChatTypeE.OnlineClient, kv.Get("Message"), 0);
            }
            else
            {
                ChatClient.Write(ChatTypeE.OnlineClient, (ChatMessageTypeE)kv.GetInt32("MessageType"), (ChatTypeE)kv.GetInt32("ChatType"), kv.Get("Message"), 0);
            }
        }

        private void GetDataByRoomID(Kv kv)
        {
            if (RoomUc.InvokeRequired)
            {
                GetDataByRoom d = new GetDataByRoom(GetDataByRoomID);
                this.Invoke(d, new object[] { kv });
            }
            else
            {
                RoomUc.SetDataByRoomId(kv.GetDataSet("AppData"), kv.GetBool("IsFromTimer"));
                timer1.Start();
            }
        }

        private void PingClient()
        {
            SocketClient.PingReply();
        }

        private void SystemInformation(Kv kv)
        {
            ChatClient.Send(ChatAudienceTypeE.Individual, ChatMessageTypeE.Info, (ChatTypeE)kv.GetInt32("ChatType"), kv.GetInt32("FromUserID"), "\" " + Ap.CurrentUser.UserName + " \"\n" + UProcess.GetSystemInfo(), 0);
        }

        private void BlockIP()
        {
            MessageForm.Show(this, MsgE.InfoBlockedUser, MessageBoxButtons.OK, MessageBoxIcon.Information);
            CloseAllWindows();
        }

        private void KickUser()
        {
            MessageForm.Show(this, MsgE.InfoKickUser, Ap.CurrentUser.UserName);
            CloseAllWindows();
        }

        private void CloseAllWindows()
        {
            isNormalClose = false;
            this.Close();
        }

        private void BanUser(Kv kv)
        {
            kv.Get("BanStartDate");
            string banDate = kv.Get("BanEndDate").Trim();
            if (banDate != string.Empty)
            {
                DateTime dt = Convert.ToDateTime(banDate);
                if (dt == new DateTime())
                {
                    MessageForm.Show(this, MsgE.ErrorBaned, Ap.CurrentUser.UserName);
                }
                else
                {
                    MessageForm.Show(this, MsgE.InfoBaned, kv.Get("BanStartDate"), kv.Get("BanEndDate"));
                }
            }

            //Application.Exit();
            CloseAllWindows();
        }

        private void AvChat(Kv kv)
        {
            AvChatE avChat = (AvChatE)kv.GetInt32("AvChat");

            switch (avChat)
            {
                case AvChatE.Asked:
                    if (!AvPlayer.IsIdle())
                    {
                        kv.Set("AvChat", (int)AvChatE.Busy);
                        SocketClient.SendAvResponse(kv);
                        return;
                    }
                    this.Invoke(new AvPlayer.StartChatDelegate(AvPlayer.StartChat), kv.DataTable);
                    break;
                case AvChatE.Accepted:
                    this.Invoke(new AvPlayer.PlayChatDelegate(AvPlayer.PlayChat));
                    break;
                case AvChatE.Declined:
                    this.Invoke(new AvPlayer.StopChatDelegate(AvPlayer.StopChat));
                    ChatClient.Write((ChatTypeE)kv.GetInt32("ClientWindow"), ChatMessageTypeE.Error, (ChatTypeE)kv.GetInt32("ClientWindow"), Msg.GetMsg(MsgE.ErrorAvChatDenied, kv.Get("ToUserName")), 0);
                    break;
                case AvChatE.Busy:
                    this.Invoke(new AvPlayer.StopChatDelegate(AvPlayer.StopChat));
                    ChatClient.Write((ChatTypeE)kv.GetInt32("ClientWindow"), ChatMessageTypeE.Error, (ChatTypeE)kv.GetInt32("ClientWindow"), Msg.GetMsg(MsgE.ErrorAvChatBusy, kv.Get("ToUserName")), 0);
                    break;
                case AvChatE.NoService:
                    this.Invoke(new AvPlayer.StopChatDelegate(AvPlayer.StopChat));
                    ChatClient.Write((ChatTypeE)kv.GetInt32("ClientWindow"), ChatMessageTypeE.Error, (ChatTypeE)kv.GetInt32("ClientWindow"), MsgE.InfoNoAvService, 0);
                    break;
                default:
                    break;
            }
        }

        private void BlockMachine(Kv kv)
        {
            String machineKey;

            BlockMachineE blockMachineE = (BlockMachineE)kv.GetInt32("BlockMachineE");
            switch (blockMachineE)
            {
                case BlockMachineE.Initialized:
                    machineKey = WmiHelper.GetMachineKey();
                    if (!String.IsNullOrEmpty(machineKey))
                    {
                        MessageForm.Show(this, MsgE.InfoBlockMachine);
                        kv.Set("MachineKey", machineKey);
                        kv.Set("BlockMachine", (int)BlockMachineE.Done);
                    }
                    SocketClient.SendAvResponse(kv);
                    break;
                case BlockMachineE.Done:
                    machineKey = kv.Get("MachineKey");
                    if (!String.IsNullOrEmpty(machineKey))
                        MessageForm.Show(this, MsgE.ErrorBlockMachine);
                    break;
            }
        }

        private void StartTournamentMatch(Kv kv)
        {
            if (Ap.IsGameInProgress)
            {
                return;
            }

            DataSet ds = UData.LoadDataSet(kv.Get("GameData"));
            MainOnline.ShowMainOnline(ds, false);
        }

        #endregion

        #region Helper

        private void Init()
        {
            Ap.Init(ApModuleE.Online);

            GuestAuthentication();
            room = new RoomUc();

            room.LoadPlayerGrid += new RoomUc.PlayerDataGridHandler(room_LoadPlayerGrid);
            room.LoadGameGrid += new RoomUc.GameDataGridHandler(room_LoadGameGrid);
            room.LoadChallengeGrid += new RoomUc.ChallengeDataGridHandler(room_LoadChallengeGrid);
            room.LoadRoomInfoPage += new RoomUc.RommInfoPageHandler(room_LoadRoomInfoPage);
            room.LoadUserMessages += new RoomUc.UserMessagesHandler(room_LoadUserMessages);

            SocketClient.Instance.ServerDownError += new SocketClient.OnServerDownErrorEventHandler(Instance_ServerDownError);
            Ap.MsgQueue.Register(this);

            InitDockPanel();
            CreateDockWindow();
            timer1.Start();
            timerHeartbeat.Start();
            playersUc.SelectPlayer += new PlayersUc.SelectedPlayerHandler(playersUc_SelectPlayer);
            PlayersUc.RefreshData += new EventHandler(PlayersUc_RefreshData);
        }

        private void GuestAuthentication()
        {
            if (Ap.CurrentUser.HumanRankIDE == RankE.Guest)
            {
                #region Menubar Items
                newTournamentToolStripMenuItem.Enabled = false;
                PModeToolStripMenuItem.Enabled = false;
                editUserDataToolStripMenuItem.Enabled = false;
                changePasswordToolStripMenuItem.Enabled = false;
                paymentsToolStripMenuItem.Enabled = false;
                //ratingToolStripMenuItem.Enabled = false;
                userInformationToolStripMenuItem.Enabled = false;
                ratingToolStripMenuItem1.Enabled = false;
                bestGameToolStripMenuItem.Enabled = false;
                rankInformationToolStripMenuItem.Enabled = false;
                #endregion

                #region Toolbar Items
                toolStripFollowPlayer.Enabled = false;
                toolStripPersonalData.Enabled = false;
                toolStripRequestRating.Enabled = false;
                toolStripUserInfo.Enabled = false;
                #endregion
            }
        }

        internal void LoadPanes()
        {

        }

        internal void SavePanes()
        {

        }

        bool OpenBestBiltzGame()
        {
            bool isGameRunning = false;
            DataSet dsPlayer = SocketClient.HighestRankingPlayerGame();
            if (dsPlayer.Tables.Count > 0)
            {
                if (dsPlayer.Tables[0].Rows[0]["GameID"] != System.DBNull.Value)
                {
                    int GameID = UData.ToInt32(dsPlayer.Tables[0].Rows[0]["GameID"]);
                    SocketClient.AddAudience(GameID);
                    MainOnline.ShowMainOnline(GameID);
                    isGameRunning = true;
                }
            }
            return isGameRunning;
        }

        private bool CheckLastInprogressGame()
        {
            DataSet ds = SocketClient.GetLastInprogressGame(Ap.CurrentUserID);
            return MainOnline.ShowMainOnline(ds, true);
        }

        void ShowTournamentMenus(bool enable)
        {
            newTournamentToolStripMenuItem.Enabled = enable;
            myTournamentListToolStripMenuItem.Enabled = enable;
            gamesToolStripMenuItem.Enabled = enable;
            createTeamToolStripMenuItem.Enabled = enable;
            myTeamsToolStripMenuItem.Enabled = enable;
        }

        public void TogglePlayingModeItem()
        {
            if (Ap.SelectedRoomID == (int)RoomE.EngineHall)
            {
                PModeToolStripMenuItem.Enabled = true;
            }
            else
            {
                PModeToolStripMenuItem.Enabled = false;
            }
        }

        #endregion

        #region Events

        #region App Data Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            RoomUc.GetDataByRoomId(true);

            timer1.Start();
        }
        #endregion

        #region Form
        private void OnlineClient_Load(object sender, EventArgs e)
        {
            try
            {
                Init();
                ApWin.OnlineClientForm = this;
                string userTitle = " - InfinityChess Online";

                if (Ap.CurrentUser.HumanRankIDE != RankE.Guest)
                {
                    userTitle = "[" + Ap.CurrentUser.UserName + "] - " + Ap.CurrentUser.FirstName + "," + Ap.CurrentUser.LastName + userTitle;

                    if (Ap.CurrentUser.IsAdmin)
                    {
                        adminToolStripMenuItem.Visible = true;
                    }

                    ShowTournamentMenus(Ap.CurrentUser.IsTournamentDirector);
                }
                else
                {
                    userTitle = "[" + Ap.CurrentUser.UserName + "] - " + "Guest" + userTitle;
                }
                ApWin.OnlineClientForm.Text = userTitle;
                toInfichesscomToolStripMenuItem.Enabled = true;
                IdleTimer idleTimer = new IdleTimer();
                idleTimer.Interval = 300;

                CheckLastInprogressGame();
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }

        private void OnlineClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            ApWin.StartupForm.SetVisible();
            Ap.CurrentUserID = 0;
            Ap.CurrentUser = null;
            SocketClient.Instance.Disconnect();

            SocketClient.Instance.ServerDownError -= new SocketClient.OnServerDownErrorEventHandler(Instance_ServerDownError);
            Ap.MsgQueue.UnRegister(this);

            this.chatUc.UnInit();
        }

        private void OnlineClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Ap.IsGameInProgress || Ap.HasKibitzers)
            {
                ChatClient.Write(ChatTypeE.OnlineClient, ChatMessageTypeE.Warning, ChatTypeE.OnlineClient, MsgE.ErrorRoomChange, 0);
                e.Cancel = true;
                return;
            }
            else if (isNormalClose)
            {
                if (MessageForm.Confirm(this, MsgE.ConfirmLogOff) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            Ap.UnInit(ApModuleE.Online);

            if (isNormalClose)
            {
                ProgressForm frm = ProgressForm.Show(this, "Logging off...");
                Ap.CurrentUser.Logoff();
                frm.Close();
            }

            UnInitDockingEvents();
            SaveDocking();

            Ap.CanAutoChallenge = true;
            Ap.PlayingMode.ChessTypeID = 1;
            PlayingModeData.Instance.ChessType = ChessTypeE.Human;
            Ap.SelectedRoomID = 0;

            if (Ap.PlayingMode.SelectedEngine != null)
            {
                Ap.PlayingMode.SelectedEngine.Close();
                Ap.PlayingMode.SelectedEngine = null;
            }

            PlayingModeData.Instance.Save();
            UserFormulas.Instance = null;
        } 
        #endregion

        #region Toolbar & Menu
        private void toolStripSystemInformation_Click(object sender, EventArgs e)
        {
            if (playersUc.SelectedUserId != 0)
            {

                SocketClient.SystemInformation(playersUc.SelectedUserId, ChatTypeE.OnlineClient);
            }
        }

        private void gotoInfinityChessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ap.OpenHomeUrl();
        }

        private void tsOpenDataFolder_Click(object sender, EventArgs e)
        {
            Ap.OpenFolderData();
        }

        private void exitProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editUserDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserData.Show(this, Ap.CurrentUserID, Ap.CurrentUser, false);
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword frm = new ChangePassword();
            frm.Show(ApWin.OnlineClientForm);
        }

        private void menuBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menuBarToolStripMenuItem.Checked)
            {
                DialogResult result = MessageForm.Confirm(this, MsgE.ConfirmAccessMenubar);
                if (result.ToString() == "Yes")
                {
                    menuStrip1.Visible = false;
                    menuBarToolStripMenuItem.Checked = false;
                    tableLayoutPanel1.ColumnStyles[0].Width = 0;
                    tableLayoutPanel1.ColumnStyles[1].Width = 100;
                }
            }
            else
            {

                menuStrip1.Visible = true;
                menuBarToolStripMenuItem.Checked = true;
                tableLayoutPanel1.ColumnStyles[0].Width = 76;
                tableLayoutPanel1.ColumnStyles[1].Width = 24;
            }
        }

        private void statusbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statusbarToolStripMenuItem.Checked)
            {
                statusStrip1.Visible = false;
                statusbarToolStripMenuItem.Checked = false;
            }
            else
            {
                statusStrip1.Visible = true;
                statusbarToolStripMenuItem.Checked = true;
            }
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_FullScreen == null)
            {
                _FullScreen = new FullScreen(ApWin.OnlineClientForm);
            }
            if (fullScreenToolStripMenuItem.Checked == false)
            {
                // show FullScreen
                DialogResult dr = MessageForm.Confirm(this, MsgE.ConfirmStoreNormalView);
                if (dr == DialogResult.Yes)
                {
                    _FullScreen.ShowFullScreen();
                    tableLayoutPanel1.Visible = false;
                    statusStrip1.Visible = false;
                    fullScreenToolStripMenuItem.Checked = true;
                }
            }
            else
            {
                // Hide FullScreen
                _FullScreen.ShowFullScreen();
                tableLayoutPanel1.Visible = true;
                statusStrip1.Visible = true;
                fullScreenToolStripMenuItem.Checked = false;
            }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TogglePanel(infoUc, infoToolStripMenuItem.Checked);
        }

        private void playersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TogglePanel(playersUc, playersToolStripMenuItem.Checked);
        }

        private void gamesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TogglePanel(gamesUc, gamesToolStripMenuItem1.Checked);
        }

        private void newsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TogglePanel(newsUc, newsToolStripMenuItem.Checked);
        }

        private void toggleChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TogglePanel(chatUc, toggleChatToolStripMenuItem.Checked);
        }

        private void inboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TogglePanel(inboxUc, inboxToolStripMenuItem.Checked);
        }

        private void sentItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TogglePanel(sentUc, sentItemsToolStripMenuItem.Checked);
        }

        private void challengesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TogglePanel(challengesUc, challengesToolStripMenuItem.Checked);
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TogglePanel(RoomUc, roomsToolStripMenuItem.Checked);
        }

        private void loadDefaultPanesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageForm.Confirm(this, MsgE.ConfirmLoadDefaultPanes) == DialogResult.Yes)
            {
                LoadDefaultPanels();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutInfinityChess frm = new AboutInfinityChess();
            frm.ShowDialog();
        }

        private void toolStripPersonalData_Click(object sender, EventArgs e)
        {
            editUserDataToolStripMenuItem.PerformClick();
        }

        private void PModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayingMode frm = new PlayingMode(Ap.Game);
            frm.ShowDialog();
        }

        private void toolStripRequestRating_Click(object sender, EventArgs e)
        {
            RatedGameResult RatedGameResult = new RatedGameResult();
            RatedGameResult.ShowInTaskbar = false;
            RatedGameResult.UserID = Ap.CurrentUserID;
            RatedGameResult.UserName = Ap.CurrentUser.UserName;
            RatedGameResult.ShowDialog();
        }

        private void toInfichesscomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ap.OpenHomeUrl();
        }

        private void toolStripReconnect_Click(object sender, EventArgs e)
        {
            SocketClient.Reconnect(ChatTypeE.OnlineClient);
        }

        private void toolStripUserInfo_Click(object sender, EventArgs e)
        {
            PersonalInformation oPersonalInformation = new PersonalInformation(Ap.CurrentUserID);
            oPersonalInformation.UserName = Ap.CurrentUser.UserName;
            oPersonalInformation.ShowInTaskbar = false;
            oPersonalInformation.Show();
        }

        private void pingServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SocketClient.Ping();
        }

        private void reconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SocketClient.Reconnect(ChatTypeE.OnlineClient);
        }

        private void convertServerTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServerTimeForm ServerTimeForm = new ServerTimeForm();
            ServerTimeForm.ShowInTaskbar = false;
            ServerTimeForm.ShowDialog();
        }

        private void topRatingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserTopRatingForm UserTopRatingForm = new UserTopRatingForm();
            UserTopRatingForm.ShowInTaskbar = false;
            UserTopRatingForm.ShowDialog();
        }

        private void toolStripFollowPlayer_Click(object sender, EventArgs e)
        {
            if (!OpenBestBiltzGame())
            {
                MessageForm.Show(this, MsgE.InfoBestBiltzGameToKibitz, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsPingServer_Click(object sender, EventArgs e)
        {
            SocketClient.Ping();
        }

        private void tsLocalTime_Click(object sender, EventArgs e)
        {
            ServerTimeForm ServerTimeForm = new ServerTimeForm();
            ServerTimeForm.ShowInTaskbar = false;
            ServerTimeForm.ShowDialog();
        }

        private void tsmFactorySetting_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageForm.Confirm(this, MsgE.ConfirmResetSetting);
            if (dialogResult == DialogResult.Yes)
            {
                ApWin.ShowUserProfile = true;
                Ap.ResetFactorySettings();
                LoadDefaultPanels();
                this.Close();
            }
        }

        private void tsUndoSetting_Click(object sender, EventArgs e)
        {
            if (MessageForm.Confirm(this, MsgE.ConfirmLoadDefaultPanes) == DialogResult.Yes)
            {
                LoadDefaultPanels();
            }
        }

        private void createUCIEngineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetupUCIEngine objuciengine = new SetupUCIEngine(Ap.Game);
            objuciengine.ShowDialog(this);
        }

        private void userInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonalInformation oPersonalInformation = new PersonalInformation(Ap.CurrentUserID);
            oPersonalInformation.UserName = Ap.CurrentUser.UserName;
            oPersonalInformation.ShowInTaskbar = false;
            oPersonalInformation.Show();
        }

        private void ratingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RatedGameResult RatedGameResult = new RatedGameResult();
            RatedGameResult.ShowInTaskbar = false;
            RatedGameResult.UserID = Ap.CurrentUserID;
            RatedGameResult.UserName = Ap.CurrentUser.UserName;
            RatedGameResult.ShowDialog();
        }

        private void fillUpAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KeyValueE keyValueE = KeyValueE.OrderUrl;
            InfinityChess.Online.Forms.BrowserForm BrowserForm = new InfinityChess.Online.Forms.BrowserForm(keyValueE, false);
            BrowserForm.ShowDialog(this);
        }

        private void bestGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!OpenBestBiltzGame())
            {
                MessageForm.Show(this, MsgE.InfoBestBiltzGameToKibitz, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void statusStrip1_DoubleClick(object sender, EventArgs e)
        {
            MessageForm.Show(toolStripStatusLabel1.Text);
        }

        private void rankInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rankInformationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            RankInfo RankInfo = new RankInfo(Ap.CurrentUserID, Ap.CurrentUser.UserName);
            RankInfo.ShowDialog();
        }

        private void viewAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckoutAccount CheckoutAccount = new CheckoutAccount();
            CheckoutAccount.Show();

        }

        private void serverStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfinityChess.Online.Forms.ServerStatistic ServerStatistic = new InfinityChess.Online.Forms.ServerStatistic();
            ServerStatistic.ShowDialog();
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InfinityChess.InfinityChesshelp.InfinityChessHelp.OpenHelpFile();
        }

        private void queryUpgradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UpdateClient.IsIdle)
                QueryUpgrade();
            else
                ChatClient.Write(ChatTypeE.OnlineClient, ChatMessageTypeE.Error, ChatTypeE.OnlineClient, MsgE.ErrorUpgradeInProgress, 0);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsPopup frmOptions = new OptionsPopup(Ap.Game, null);
            frmOptions.OptionsApplied += new EventHandler(frmOptions_OptionsApplied);
            frmOptions.ShowDialog(this);
            frmOptions.OptionsApplied -= new EventHandler(frmOptions_OptionsApplied);
        }

        void frmOptions_OptionsApplied(object sender, EventArgs e)
        {
            playersUc.LoadPlayers();
            GamesUc.LoadGames();
        }

        private void chessMediaSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gamesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tsmTournament_Click(object sender, EventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                UserList frm = new UserList();
                frm.Show();
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }

        private void newsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NewsList frm = new NewsList();
            frm.Show();
        }

        private void roomsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RoomList frm = new RoomList();
            frm.Show();
        }

        private void logToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LogList frm = new LogList();
            frm.Show();
        }

        private void tournamentDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TournamentDetail.ShowDialog(this, 0);
        }

        private void teamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeamList frm = new TeamList();
            frm.Show();
        }

        private void blockedIPsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IPList frm = new IPList();
            frm.Show();
        }

        #region Tournament Menu
        private void newTournamentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TournamentDetail.Show(this, 0);
        }

        private void myTournamentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TournamentList.Show(this, TournamentStatusE.Unknown);
        }

        private void forthcommingTournamentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TournamentList.Show(this, TournamentStatusE.Scheduled);
        }

        private void inProgressTournamentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TournamentList.Show(this, TournamentStatusE.InProgress);
        }

        private void finishedTournamentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TournamentList.Show(this, TournamentStatusE.Finsihed);
        }

        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void createTeamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeamDetail.Show(this, 0);
        }

        private void myTeamsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeamList.Show(this, true);
        }
        #endregion
        #endregion

        #region User Control
        void PlayersUc_RefreshData(object sender, EventArgs e)
        {
            RoomUc.GetDataByRoomId(true);
        }

        void room_LoadUserMessages(DataTable table)
        {
            inboxUc.LoadMessages(table);
            sentUc.LoadMessages(table);
        }

        void playersUc_SelectPlayer(int userID, string userName, string userRank)
        {
            chatUc.SelectedPlayer(userID, userName, userRank);
        }

        void Instance_ServerDownError(string error)
        {
            if (statusStrip1 != null && statusStrip1.Items.Count > 0)
            {
                //statusStrip1.Items[0].Text = error;
            }
        }

        void room_LoadRoomInfoPage(int roomID, int tounamentID, string url)
        {
            //infoMainUc1.LoadRoomInfo(roomID, tounamentID);
            infoUc.LoadRoomInfo(roomID, tounamentID, url);
        }

        void room_LoadPlayerGrid(DataTable table)
        {
            playersUc.LoadPlayers(table);
        }

        void room_LoadGameGrid(DataTable table)
        {
            //infoMainUc1.LoadGames(table);
            gamesUc.LoadGames(table);
        }

        void room_LoadChallengeGrid(DataTable table)
        {
            //challengesMain.LoadChallenges(table);
            challengesUc.LoadChallenges(table);
        }
        
        #endregion

        #region Heartbeat Timer
        private void timerHeartbeat_Tick(object sender, EventArgs e)
        {
            timerHeartbeat.Stop();

            #region Disconnection Log
            if (SocketClient.Instance.IsNotConnected)
            {
                Ap.MoveLog.Disconnected();

                if (OnDisconnect != null)
                {
                    OnDisconnect(this, EventArgs.Empty);
                }
            }

            #endregion

            if (SocketClient.ReconnectIfRequired(ChatTypeE.OnlineClient))
            {
                if (Ap.IsGameInProgress)
                {
                    #region Game In Progress
                    Ap.MoveLog.Connected();

                    if (OnConnect != null)
                    {
                        OnConnect(this, EventArgs.Empty);
                    }

                    DataSet ds = SocketClient.GetGameDataByGameID(Ap.Game.DbGame.GameID);
                    Ap.Game.DbGame = App.Model.Db.Game.CreateGame(Ap.Cxt, ds);
                    Ap.Game.SetOnlineGameXml(Ap.Game.DbGame.GameXml, true);

                    if (Ap.PlayingMode.SelectedEngine != null)
                    {
                        SocketClient.SetUserEngine(Ap.PlayingMode.SelectedEngine.EngineName, UserStatusE.Playing);
                    }
                    else
                    {
                        SocketClient.SetUserEngine(string.Empty, UserStatusE.Playing);
                    }
                    #endregion
                }
                else
                {
                    #region Last In Progress Game
                    if (!CheckLastInprogressGame())
                    {
                        if (Ap.PlayingMode.SelectedEngine != null)
                        {
                            SocketClient.SetUserEngine(Ap.PlayingMode.SelectedEngine.EngineName, Ap.CurrentUser.UserStatusIDE);
                        }
                        else
                        {
                            SocketClient.SetUserEngine(string.Empty, Ap.CurrentUser.UserStatusIDE);
                        }
                    }
                    #endregion
                }
            }

            SocketClient.HeartbeatPing();

            timerHeartbeat.Start();
        }
        #endregion
        
        #endregion

        #region QueryUpgrade

        private void QueryUpgrade()
        {
            #region Check/Validate Version
            KeyValues.Reresh();
            String versionString = KeyValues.Instance.GetKeyValue(KeyValueE.CurrentVersionNo).Value;

            if (String.IsNullOrEmpty(versionString))
            {
                ChatClient.Write(ChatTypeE.OnlineClient, ChatMessageTypeE.Error, ChatTypeE.OnlineClient, MsgE.InfoNoAvService, 0);
                return;
            }

            Int32 major;
            Int32 minor;
            Int32 build;
            Int32 revision;

            String[] versionParts = versionString.Split('.');

            if (versionParts.Length < 4)
            {
                ChatClient.Write(ChatTypeE.OnlineClient, ChatMessageTypeE.Error, ChatTypeE.OnlineClient, MsgE.InfoNoAvService, 0);
                return;
            }

            if (!Int32.TryParse(versionParts[0], out major))
            {
                ChatClient.Write(ChatTypeE.OnlineClient, ChatMessageTypeE.Error, ChatTypeE.OnlineClient, MsgE.InfoNoAvService, 0);
                return;
            }

            if (!Int32.TryParse(versionParts[1], out minor))
            {
                ChatClient.Write(ChatTypeE.OnlineClient, ChatMessageTypeE.Error, ChatTypeE.OnlineClient, MsgE.InfoNoAvService, 0);
                return;
            }

            if (!Int32.TryParse(versionParts[2], out build))
            {
                ChatClient.Write(ChatTypeE.OnlineClient, ChatMessageTypeE.Error, ChatTypeE.OnlineClient, MsgE.InfoNoAvService, 0);
                return;
            }

            if (!Int32.TryParse(versionParts[3], out revision))
            {
                ChatClient.Write(ChatTypeE.OnlineClient, ChatMessageTypeE.Error, ChatTypeE.OnlineClient, MsgE.InfoNoAvService, 0);
                return;
            }
            #endregion

            #region Upgrade
            Version currentVersion = new Version(Config.Version);
            Version newVersion = new Version(major, minor, build, revision);
            Boolean upgradeRequired = false;
            upgradeRequired = UpdateUtility.IsUpgradeRequired(currentVersion, newVersion);

            if (upgradeRequired)
            {
                if (MessageForm.Confirm(null, MsgE.InfoUpgradeAvailable) == DialogResult.Yes)
                {
                    DownloadUpgrades();
                }
            }
            else
            {
                ChatClient.Write(ChatTypeE.OnlineClient, ChatMessageTypeE.Info, ChatTypeE.OnlineClient, MsgE.InfoUpgradeNotRequired, 0);
            }
            #endregion
        }

        private void DownloadUpgrades()
        {
            try
            {
                DataSet ds = UpdateUtility.GetAvailablePatches(Config.Version);
                if (ds != null && ds.Tables.Count > 0)
                {
                    Kv kv = new Kv(ds.Tables[0]);
                    long patchSize = kv.GetInt32("PatchSize");
                    long setupSize = kv.GetInt32("SetupSize");
                    int multiplier = 6;
                    if (patchSize >= (setupSize * multiplier))
                    {
                        if (MessageForm.Confirm(null, MsgE.ConfirmPatchSizeDownload, patchSize + " MB", setupSize + " MB") == DialogResult.No)
                        {
                            return;
                        }
                    }
                    string newVersion = kv.Get("PatchFile1").Replace(".zip", "");
                    string currentPatchUrl = KeyValues.Instance.GetKeyValue(KeyValueE.PatchUrl).Value;
                    this.Invoke(new UpdateClient.BeginUpdateDelegateKv(UpdateClient.BeginUpdate), kv, currentPatchUrl, newVersion);
                }
            }

            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }

        #endregion

        #region IMsgQueueConsumer Members

        public void ConsumeMessage(Kv kv)
        {
            ISynchronizeInvoke synchronizer = this;

            MsgQueue.SyncConsumeMessage s = new MsgQueue.SyncConsumeMessage(SynchronizeConsumeMessage);

            synchronizer.Invoke(s, new object[] { kv });
        }

        public int GameID
        {
            get
            {
                return 0;
            }
        }

        public App.Model.Game Game
        {
            get
            {
                return null;
            }
        }

        #endregion
    }
}