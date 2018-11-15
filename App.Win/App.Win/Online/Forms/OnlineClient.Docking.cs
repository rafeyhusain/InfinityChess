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
//using Crom.Controls.Docking;
using InfinityChess.WinForms;
using WeifenLuo.WinFormsUI.Docking;

namespace App.Win
{
    public partial class OnlineClient : Form
    {
        #region Data Members
        protected DockPanel dp;
        #endregion

        #region Docking Windows 

        private void CreateDockWindow()
        {
            InitControls();
            InitDockingEvents();
            InitDockPanel();

            SetPanels();
            LoadPanels();

            SetSelectedPanels();
        }

        private void InitDockPanel()
        {
            dp = new DockPanel();
            dp.ActiveAutoHideContent = null;
            dp.Dock = DockStyle.Fill;
            dp.DocumentStyle = DocumentStyle.DockingSdi;
            Controls.Add(dp);
            dp.BringToFront();
        }

        protected void SetPanels()
        {
            ChatUc.TabText = "Chat";
            ChatUc.HideOnClose = true;
            this.chatUc.ChatType = ChatTypeE.OnlineClient;

            InboxUc.TabText = "Inbox";
            InboxUc.HideOnClose = true;

            SentUc.TabText = "Sent";
            SentUc.HideOnClose = true;

            RoomUc.TabText = "Rooms";
            RoomUc.HideOnClose = true;

            challengesUc.TabText = "Challenges";
            challengesUc.HideOnClose = true;

            infoUc.TabText = "Info";
            infoUc.HideOnClose = true;

            playersUc.TabText = "Players";
            playersUc.HideOnClose = true;

            gamesUc.TabText = "Games";
            gamesUc.HideOnClose = true;

            newsUc.TabText = "News";
            newsUc.HideOnClose = true;
        }

        protected void LoadPanels()
        {
            #region Load from xml

            string fileName = Ap.FileOnlineDocking;
            if (LoadFromFile(fileName))
            {
                return;
            }

            string defaultFileName = Ap.FileOnlineDockingDefault;
            LoadFromFile(defaultFileName);

            #endregion

            #region Load Manually

            infoUc.Show(dp, DockState.Document);
            playersUc.Show(infoUc.Pane, null);
            gamesUc.Show(infoUc.Pane, null);
            newsUc.Show(infoUc.Pane, null);

            ChatUc.Show(dp, DockState.DockRight);
            InboxUc.Show(ChatUc.Pane, null);
            SentUc.Show(ChatUc.Pane, null);

            RoomUc.Show(ChatUc.Pane, DockAlignment.Bottom, 0.45);

            challengesUc.Show(infoUc.Pane, DockAlignment.Bottom, 0.30);

            #endregion
        }

        protected bool LoadFromFile(string fileName)
        {
            try
            {
                if (System.IO.File.Exists(fileName) && !Config.IsDev)
                {
                    InitDockPanel();
                    DeserializeDockContent ddc = new DeserializeDockContent(GetContentFromPersistString);
                    dp.LoadFromXml(fileName, ddc);

                    return true;
                }
            }
            catch(Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                InitDockPanel();
            }

            return false;
        }

        protected IDockContent GetContentFromPersistString(string persistString)
        {
            switch (persistString)
            {
                case InfoUc.Guid:
                    return infoUc;
                case PlayersUc.Guid:
                    return playersUc;
                case GamesUc.Guid:
                    return gamesUc;
                case NewsUc.Guid:
                    return newsUc;
                case ChatUc.Guid:
                    return chatUc;
                case InboxUc.Guid:
                    return inboxUc;
                case SentUc.Guid:
                    return sentUc;
                case RoomUc.Guid:
                    return RoomUc;
                case ChallengesUc.Guid:
                    return challengesUc;
                default:
                    return null;
            }            
        }

        private void SetSelectedPanels()
        {
            infoUc.Activate();
            chatUc.Activate();
        }

        private void InitControls()
        {
            //// InfoMainUc
            infoUc = new InfoUc();
            playersUc = new PlayersUc();
            gamesUc = new GamesUc();
            newsUc = new NewsUc();

            //// ChatMainUc
            chatUc = new ChatUc(null);
            chatUc.Init();

            inboxUc = new InboxUc();
            sentUc = new SentUc();

            //// ChallengesMainUc
            challengesUc = new ChallengesUc();
        }

        private void SaveDocking()
        {
            if (dp != null)
            {
                string fileName = Ap.FileOnlineDocking;
                dp.SaveAsXml(fileName);
            }
        }

        protected void TogglePanel(DockContent dContent, bool show)
        {
            if (show)
            {
                dContent.Show();
            }
            else
            {
                dContent.Hide();
            }
        }

        protected void LoadDefaultDocking()
        {
            InitDockPanel();

            dp.SuspendLayout();

            LoadPanels();            
            SetSelectedPanels();

            dp.ResumeLayout(true);
        }

        private void LoadDefaultPanels()
        {
            System.IO.File.Delete(Ap.FileOnlineDocking);
            LoadDefaultDocking();
        }

        private void RemoveAllPanels()
        {
            //while (dc.DockedItems.Values.Count > 0)
            //{
            //    DockedItem item = dc.DockedItems.Values.FirstOrDefault();
            //    RemoveForm(item.Guid);
            //}
        }

        #endregion

        #region Controls Events

        private void InitDockingEvents()
        {
            ChatUc.VisibleChanged += new EventHandler(ChatUc_VisibleChanged);
            InboxUc.VisibleChanged += new EventHandler(InboxUc_VisibleChanged);
            SentUc.VisibleChanged += new EventHandler(SentUc_VisibleChanged);
            RoomUc.VisibleChanged += new EventHandler(RoomUc_VisibleChanged);
            ChallengesUc.VisibleChanged += new EventHandler(ChallengesUc_VisibleChanged);
            InfoUc.VisibleChanged += new EventHandler(InfoUc_VisibleChanged);
            PlayersUc.VisibleChanged += new EventHandler(PlayersUc_VisibleChanged);
            GamesUc.VisibleChanged += new EventHandler(GamesUc_VisibleChanged);
            NewsUc.VisibleChanged += new EventHandler(NewsUc_VisibleChanged);
        }

        private void UnInitDockingEvents()
        {
            ChatUc.VisibleChanged -= new EventHandler(ChatUc_VisibleChanged);
            InboxUc.VisibleChanged -= new EventHandler(InboxUc_VisibleChanged);
            SentUc.VisibleChanged -= new EventHandler(SentUc_VisibleChanged);
            RoomUc.VisibleChanged -= new EventHandler(RoomUc_VisibleChanged);
            ChallengesUc.VisibleChanged -= new EventHandler(ChallengesUc_VisibleChanged);
            InfoUc.VisibleChanged -= new EventHandler(InfoUc_VisibleChanged);
            PlayersUc.VisibleChanged -= new EventHandler(PlayersUc_VisibleChanged);
            GamesUc.VisibleChanged -= new EventHandler(GamesUc_VisibleChanged);
            NewsUc.VisibleChanged -= new EventHandler(NewsUc_VisibleChanged);
        }

        void ChatUc_VisibleChanged(object sender, EventArgs e)
        {
            toggleChatToolStripMenuItem.Checked = !ChatUc.IsHidden;
        }

        void InboxUc_VisibleChanged(object sender, EventArgs e)
        {
            inboxToolStripMenuItem.Checked = !InboxUc.IsHidden;
        }

        void SentUc_VisibleChanged(object sender, EventArgs e)
        {
            sentItemsToolStripMenuItem.Checked = !SentUc.IsHidden;
        }

        void RoomUc_VisibleChanged(object sender, EventArgs e)
        {
            roomsToolStripMenuItem.Checked = !RoomUc.IsHidden;
        }

        void ChallengesUc_VisibleChanged(object sender, EventArgs e)
        {
            challengesToolStripMenuItem.Checked = !ChallengesUc.IsHidden;
        }

        void InfoUc_VisibleChanged(object sender, EventArgs e)
        {
            infoToolStripMenuItem.Checked = !InfoUc.IsHidden;
        }

        void PlayersUc_VisibleChanged(object sender, EventArgs e)
        {
            playersToolStripMenuItem.Checked = !PlayersUc.IsHidden;
        }

        void GamesUc_VisibleChanged(object sender, EventArgs e)
        {
            gamesToolStripMenuItem1.Checked = !GamesUc.IsHidden;                        
        }

        void NewsUc_VisibleChanged(object sender, EventArgs e)
        {
            newsToolStripMenuItem.Checked = !NewsUc.IsHidden;
        }

        #endregion

        #region InfoMainUc 

        InfoUc infoUc;
        public InfoUc InfoUc
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return infoUc; }
            [System.Diagnostics.DebuggerStepThrough]
            set { infoUc = value; }
        }

        PlayersUc playersUc;
        public PlayersUc PlayersUc
        {
            get { return playersUc; }
            set { playersUc = value; }
        }

        GamesUc gamesUc;
        public GamesUc GamesUc
        {
            get { return gamesUc; }
            set { gamesUc = value; }
        }

        NewsUc newsUc;
        public NewsUc NewsUc
        {
            get { return newsUc; }
            set { newsUc = value; }
        }

        public void LoadRoomInfo(int roomID, int roomtournamentID,string url)
        {
            
            infoUc.LoadRoomInfo(roomID, roomtournamentID,url);
        }

        #endregion

        #region ChatMainUc 

        ChatUc chatUc;
        public ChatUc ChatUc
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return chatUc; }
            [System.Diagnostics.DebuggerStepThrough]
            set { chatUc = value; }
        }

        InboxUc inboxUc;
        public InboxUc InboxUc
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return inboxUc; }
            [System.Diagnostics.DebuggerStepThrough]
            set { inboxUc = value; }
        }

        SentUc sentUc;
        public SentUc SentUc
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return sentUc; }
            [System.Diagnostics.DebuggerStepThrough]
            set { sentUc = value; }
        }

        public void SelectedPlayer(int userID, string userName, string userRank)
        {
            chatUc.SelectedPlayer(userID, userName, userRank);
        }

        public void UnInit()
        {
            this.chatUc.UnInit();
        }

        #endregion

        #region ChallengesMainUc 

        ChallengesUc challengesUc;
        public ChallengesUc ChallengesUc
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return challengesUc; }
            [System.Diagnostics.DebuggerStepThrough]
            set { challengesUc = value; }
        }

        #endregion

        #region Resolution/Propotion

        public static Size GetDefaultSize(string guid)
        {
            // width x height = 1440 x 900;
            Size DefaultSize = new Size(1440, 900);
            Size ms = System.Windows.Forms.SystemInformation.PrimaryMonitorSize;

            Size s = new Size();
            double panelWidth = 0;
            double panelHeight = 0;

            switch (guid)
            {
                case InboxUc.Guid:
                case SentUc.Guid:
                case ChatUc.Guid:
                case RoomUc.Guid:
                    panelWidth = 400;
                    panelHeight = 100;
                    break;                    
                case ChallengesUc.Guid:
                    panelWidth = 700;
                    panelHeight = 150;
                    break;
                case PlayersUc.Guid:
                case GamesUc.Guid:
                case NewsUc.Guid:
                case InfoUc.Guid:
                    panelWidth = 700;
                    panelHeight = 100;
                    break;
                default:
                    throw new InvalidOperationException();
            }

            s.Width = (int)(ms.Width * (panelWidth / DefaultSize.Width));
            s.Height = (int)(ms.Height * (panelHeight / DefaultSize.Height));

            return s;
        }

        public static int GetDefaultWidth(string guid)
        {
            Size s = GetDefaultSize(guid);
            return s.Width;
        }

        public static int GetDefaultHeight(string guid)
        {
            Size s = GetDefaultSize(guid);
            return s.Height;
        }

        #endregion
    }
}