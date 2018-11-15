using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Model;
using Khendys.Controls;
using App.Model.Db;
using WeifenLuo.WinFormsUI.Docking;

namespace App.Win
{
    public partial class ChatUc : DockContent, IGameUc
    {
        #region Delegates/Events 
                
        private delegate void AvChatDelegate(bool enable, object sender, AvChatEventArgs args);

        #endregion

        #region DataMember
        public App.Model.Game Game = null;
        public const string Guid = "cf13ea7f-dabe-44bd-883c-b23a35b8db01";
        private int UserID;
        private string UserName;
        private string UserRank;
        private bool showEmotions = false;
        private ExRichTextBox rtbChat;
        private ChatTypeE chatType;

        #endregion

        #region Properties
        public ChatTypeE ChatType
        {
            [System.Diagnostics.DebuggerStepThrough]
            set { chatType = value; }
        }

        #endregion

        #region Constructor

        public ChatUc(App.Model.Game game)
        {
            this.Game = game;
            InitializeComponent();
        }

        private void AddRichTextBox()
        {
            rtbChat = new ExRichTextBox();
            panel3.Controls.Add(rtbChat);
            rtbChat.Dock = DockStyle.Fill;
            rtbChat.BackColor = Color.DimGray;// ColorTranslator.FromHtml("#4b4a45");
            rtbChat.ReadOnly = true;
        }

        #endregion

        #region Events

        private void ChatUc_Load(object sender, EventArgs e)
        {
            FillCombo();
        }

        void Instance_ChatMessageReceived(object sender, ChatMessageEventArgs e)
        {
            if (IsChatMessageBlocked(e))
            {
                return;
            }

            if (e.ChatType == chatType)
            {
                AddLine(e);
            }
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMessage.Text))
            {
                SendMessage();
                txtMessage.Text = "";
            }
        }

        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtMessage.Text))
                {
                    e.Handled = true;
                    SendMessage();
                    txtMessage.Text = "";
                }
            }
        }

        private void btnEmotion_Click(object sender, EventArgs e)
        {
            if (showEmotions)
            {
                showEmotions = false;
                toolStrip1.Visible = false;
            }
            else
            {
                showEmotions = true;
                toolStrip1.Visible = true;
            }
        }

        private void tsbHappy_Click(object sender, EventArgs e)
        {
            txtMessage.Text = txtMessage.Text + ":)";
            txtMessage.Focus();
            txtMessage.SelectionStart = txtMessage.Text.Length;
        }

        private void tsbWink_Click(object sender, EventArgs e)
        {
            txtMessage.Text = txtMessage.Text + ";)";
            txtMessage.Focus();
            txtMessage.SelectionStart = txtMessage.Text.Length;
        }

        private void tsbSad_Click(object sender, EventArgs e)
        {
            txtMessage.Text = txtMessage.Text + ":(";
            txtMessage.Focus();
            txtMessage.SelectionStart = txtMessage.Text.Length;
        }

        private void tsbAngry_Click(object sender, EventArgs e)
        {
            txtMessage.Text = txtMessage.Text + ":@";
            txtMessage.Focus();
            txtMessage.SelectionStart = txtMessage.Text.Length;
        }

        private void tsbSurprised_Click(object sender, EventArgs e)
        {
            txtMessage.Text = txtMessage.Text + ":-O";
            txtMessage.Focus();
            txtMessage.SelectionStart = txtMessage.Text.Length;
        }

        private void tsbKiss_Click(object sender, EventArgs e)
        {
            txtMessage.Text = txtMessage.Text + "(K)";
            txtMessage.Focus();
            txtMessage.SelectionStart = txtMessage.Text.Length;
        }

        private void tsbQuestion_Click(object sender, EventArgs e)
        {
            txtMessage.Text = txtMessage.Text + ":?";
            txtMessage.Focus();
            txtMessage.SelectionStart = txtMessage.Text.Length;
        }

        private void tsbLaughing_Click(object sender, EventArgs e)
        {
            txtMessage.Text = txtMessage.Text + ":D";
            txtMessage.Focus();
            txtMessage.SelectionStart = txtMessage.Text.Length;
        }

        private void tsbSleep_Click(object sender, EventArgs e)
        {
            txtMessage.Text = txtMessage.Text + ":-)";
            txtMessage.Focus();
            txtMessage.SelectionStart = txtMessage.Text.Length;
        }

        private void tsbUnfair_Click(object sender, EventArgs e)
        {
            txtMessage.Text = txtMessage.Text + ":|";
            txtMessage.Focus();
            txtMessage.SelectionStart = txtMessage.Text.Length;
        }
        #endregion

        #region AddLine
        public void AddLine(Color color, bool bold, string text)
        {
            try
            {
                rtbChat.SelectionStart = rtbChat.Text.Length;

                rtbChat.SelectionColor = color;
                rtbChat.SelectionFont = new Font("Arial", 10, bold ? FontStyle.Bold : FontStyle.Regular);
                rtbChat.SelectedText = text; //+Environment.NewLine;
                AddEmotionsImages(text);

                rtbChat.ScrollToCaret();
                rtbChat.SelectionStart = rtbChat.Text.Length;
                rtbChat.SelectedText = Environment.NewLine;
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
            }
        }

        private void AddEmotionsImages(string text)
        {
            //For Happy Smiley
            if (text.Contains(":)"))
            {
                int _index;
                while ((_index = rtbChat.Find(":)")) > -1)
                {
                    rtbChat.Select(_index, ":)".Length);
                    rtbChat.InsertImage(Image.FromFile(App.Model.Ap.FolderImages + @"smiley\" + "Happy.png"));
                }
            }
            //For Wink Smiley
            if (text.Contains(";)"))
            {
                int _index;
                while ((_index = rtbChat.Find(";)")) > -1)
                {
                    rtbChat.Select(_index, ";)".Length);
                    rtbChat.InsertImage(Image.FromFile(App.Model.Ap.FolderImages + @"smiley\" + "Wink.png"));
                }
            }
            //For Sad Smiley
            if (text.Contains(":("))
            {
                int _index;
                while ((_index = rtbChat.Find(":(")) > -1)
                {
                    rtbChat.Select(_index, ":(".Length);
                    rtbChat.InsertImage(Image.FromFile(App.Model.Ap.FolderImages + @"smiley\" + "Sad.png"));
                }
            }
            //For Angry Smiley
            if (text.Contains(":@"))
            {
                int _index;
                while ((_index = rtbChat.Find(":@")) > -1)
                {
                    rtbChat.Select(_index, ":@".Length);
                    rtbChat.InsertImage(Image.FromFile(App.Model.Ap.FolderImages + @"smiley\" + "Angry.png"));
                }
            }
            //For Surprised Smiley
            if (text.Contains(":-O") || text.Contains(":-o"))
            {
                int _index;
                while ((_index = rtbChat.Find(":-O")) > -1)
                {
                    rtbChat.Select(_index, ":-O".Length);
                    rtbChat.InsertImage(Image.FromFile(App.Model.Ap.FolderImages + @"smiley\" + "Suprised.png"));
                }
            }
            //For Kiss Smiley
            if (text.Contains("(K)") || text.Contains("(k)"))
            {
                int _index;
                while ((_index = rtbChat.Find("(K)")) > -1)
                {
                    rtbChat.Select(_index, "(K)".Length);
                    rtbChat.InsertImage(Image.FromFile(App.Model.Ap.FolderImages + @"smiley\" + "Kiss.png"));
                }
            }
            //For Question Smiley
            if (text.Contains(":?"))
            {
                int _index;
                while ((_index = rtbChat.Find(":?")) > -1)
                {
                    rtbChat.Select(_index, ":?".Length);
                    rtbChat.InsertImage(Image.FromFile(App.Model.Ap.FolderImages + @"smiley\" + "Question.png"));
                }
            }
            //For Laughing Smiley
            if (text.Contains(":D") || text.Contains(":d"))
            {
                int _index;
                while ((_index = rtbChat.Find(":D")) > -1)
                {
                    rtbChat.Select(_index, ":D".Length);
                    rtbChat.InsertImage(Image.FromFile(App.Model.Ap.FolderImages + @"smiley\" + "Laughing.png"));
                }
            }
            //For Sleep Smiley
            if (text.Contains(":-)"))
            {
                int _index;
                while ((_index = rtbChat.Find(":-)")) > -1)
                {
                    rtbChat.Select(_index, ":-)".Length);
                    rtbChat.InsertImage(Image.FromFile(App.Model.Ap.FolderImages + @"smiley\" + "Sleep.png"));
                }
            }
            //For Unfair Smiley
            if (text.Contains(":|"))
            {
                int _index;
                while ((_index = rtbChat.Find(":|")) > -1)
                {
                    rtbChat.Select(_index, ":|".Length);
                    rtbChat.InsertImage(Image.FromFile(App.Model.Ap.FolderImages + @"smiley\" + "Unfair.png"));
                }
            }
        }

        void AddLine(ChatMessageEventArgs e)
        {
            switch (e.Type)
            {
                case ChatMessageTypeE.Text:
                    AddLine(Color.Yellow, true, e.Message);
                    break;
                case ChatMessageTypeE.Info:
                    AddLine(Color.White, true, e.Message);
                    break;
                case ChatMessageTypeE.Warning:
                    AddLine(Color.Pink, true, e.Message);
                    break;
                case ChatMessageTypeE.Error:
                    AddLine(Color.Red, true, e.Message);
                    break;
                case ChatMessageTypeE.Success:
                    AddLine(Color.Lime, true, e.Message);
                    break;
                case ChatMessageTypeE.Failed:
                    AddLine(Color.Red, true, e.Message);
                    break;
                case ChatMessageTypeE.Inprogress:
                    AddLine(Color.LightBlue, false, e.Message);
                    break;
                case ChatMessageTypeE.Private:
                    AddLine(Color.GreenYellow, true, e.Message);
                    break;
                case ChatMessageTypeE.EnteredRoom:
                    AddLine(Color.LightGreen, true, e.Message);
                    break;
                case ChatMessageTypeE.LeftRoom:
                    AddLine(Color.LightPink, true, e.Message);
                    break;
                case ChatMessageTypeE.TournametInvitation:
                    AddLine(Color.Aqua, true, e.Message);
                    break;
                case ChatMessageTypeE.AdminMessage:
                    AddLine(Color.LightCyan, true, e.Message);
                    break;
                case ChatMessageTypeE.TournamentResult:
                    AddLine(Color.Orange, true, e.Message);
                    break;
                case ChatMessageTypeE.TournamentMatchResult:
                    AddLine(Color.SkyBlue, true, e.Message);
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Helper

        private bool IsChatMessageBlocked(ChatMessageEventArgs e)
        {
            return rtbChat == null || rtbChat.IsDisposed || 
                (e.ChatType == ChatTypeE.GameWindow && this.Game != null && e.GameID > 0 && e.GameID != this.Game.DbGame.ID);
        }

        public void SelectedPlayer(int userID, string userName, string userRank)
        {
            int idx = cbAudienceType.SelectedIndex;
            UserID = userID;
            UserName = userName;
            UserRank = userRank;
            if (cbAudienceType != null && cbAudienceType.Items.Count > 2)
            {
                cbAudienceType.Items.RemoveAt(2);
            }
            cbAudienceType.Items.Add(userName);
            cbAudienceType.SelectedIndex = idx;
        }

        private void FillCombo()
        {
            try
            {
                cbAudienceType.Items.Clear();
                if (chatType == ChatTypeE.GameWindow)
                {
                    if (this.Game.GameMode != GameMode.Kibitzer)
                    {
                        if (this.Game.DbGame.IsCurrentUserWhite)
                        {
                            UserID = this.Game.DbGame.BlackUserID;
                            UserName = this.Game.DbGame.BlackUser.UserName;
                            if (this.Game.DbGame.BlackUser.IsGuest)
                            {
                                UserRank = "Guest";
                            }
                            else
                            {
                                UserRank = "Not Guest";
                            }
                            cbAudienceType.Items.Add(UserName);
                        }
                        else
                        {
                            UserID = this.Game.DbGame.WhiteUserID;
                            UserName = this.Game.DbGame.WhiteUser.UserName;
                            if (this.Game.DbGame.WhiteUser.IsGuest)
                            {
                                UserRank = "Guest";
                            }
                            else
                            {
                                UserRank = "Not Guest";
                            }
                            cbAudienceType.Items.Add(UserName);
                        }
                    }
                    cbAudienceType.Items.Add("Kibitzer");
                    cbAudienceType.Items.Add("Kibitzer & Player");

                    cbAudienceType.SelectedIndex = 0;
                }
                else
                {
                    cbAudienceType.Items.Add("[Send everyone on server]");
                    cbAudienceType.Items.Add("[Send everyone in room]");

                    ChatClient.Write(ChatTypeE.OnlineClient, ChatMessageTypeE.Success, ChatTypeE.OnlineClient, "Connected", 0);
                    ChatClient.Write(ChatTypeE.OnlineClient, ChatMessageTypeE.Info, ChatTypeE.OnlineClient, "Welcome " + Ap.CurrentUser.UserName, 0);

                    cbAudienceType.Items.Add(Ap.CurrentUser.UserName);
                    cbAudienceType.SelectedIndex = 2;
                }
            }
            catch(Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
            }
        }

        private void SendMessage()
        {
            string chatMessage;
            if (chatType == ChatTypeE.OnlineClient)
            {
                if (!Ap.CurrentUser.IsGuest)
                {
                    if (cbAudienceType.SelectedIndex == 0)
                    {
                        chatMessage = Ap.CurrentUser.UserName + " (To all) : " + txtMessage.Text;
                        if (Ap.CurrentUser.IsTournamentDirector)
                        {
                            ChatClient.Send(ChatAudienceTypeE.All, ChatMessageTypeE.AdminMessage, ChatTypeE.AllWindows, 0, chatMessage, 0);
                        }
                        else
                        {
                            ChatClient.Send(ChatAudienceTypeE.All, ChatMessageTypeE.Text, chatType, 0, chatMessage, 0);                        
                        }
                    }
                    else if (cbAudienceType.SelectedIndex == 1)
                    {
                        chatMessage = Ap.CurrentUser.UserName + " (To selected room) : " + txtMessage.Text;
                        if (Ap.CurrentUser.IsTournamentDirector)
                        {
                            ChatClient.Send(ChatAudienceTypeE.Room, ChatMessageTypeE.AdminMessage, ChatTypeE.AllWindows, Ap.SelectedRoomID, chatMessage, 0);
                        }
                        else
                        {
                            ChatClient.Send(ChatAudienceTypeE.Room, ChatMessageTypeE.Text, chatType, Ap.SelectedRoomID, chatMessage, 0);
                        }
                        
                    }
                    else
                    {
                        if (UserID != Ap.CurrentUserID)
                        {
                            chatMessage = Ap.CurrentUser.UserName + " (To " + UserName + ") : " + txtMessage.Text;
                            if (Ap.CurrentUser.IsTournamentDirector)
                            {
                                ChatClient.Send(ChatAudienceTypeE.Individual, ChatMessageTypeE.AdminMessage, ChatTypeE.AllWindows, UserID, chatMessage, 0);
                            }
                            else
                            {
                                ChatClient.Send(ChatAudienceTypeE.Individual, ChatMessageTypeE.Private, ChatTypeE.AllWindows, UserID, chatMessage, 0);
                            }

                            ChatClient.Write(ChatTypeE.OnlineClient, ChatMessageTypeE.Private, ChatTypeE.OnlineClient, chatMessage,0);
                        }
                    }
                }
                else
                {
                    if (cbAudienceType.SelectedIndex == 2 && UserID != Ap.CurrentUserID && UserRank == "Guest")
                    {
                        chatMessage = Ap.CurrentUser.UserName + " (To " + UserName + ") : " + txtMessage.Text;
                        ChatClient.Send(ChatAudienceTypeE.Individual, ChatMessageTypeE.Text, chatType, UserID, chatMessage, 0);
                        ChatClient.Write(ChatTypeE.OnlineClient, ChatMessageTypeE.Text, ChatTypeE.OnlineClient, chatMessage,0);
                    }
                }
            }
            else
            {
                if (!Ap.CurrentUser.IsGuest)
                {
                    if (this.Game.GameMode != GameMode.Kibitzer)
                    {
                        if (cbAudienceType.SelectedIndex == 0)
                        {
                            chatMessage = Ap.CurrentUser.UserName + " (To " + UserName + ") : " + txtMessage.Text;
                            ChatClient.Send(ChatAudienceTypeE.Individual, ChatMessageTypeE.Private, ChatTypeE.GameWindow, UserID, chatMessage, this.Game.DbGame.ID);
                            ChatClient.Write(ChatTypeE.GameWindow, ChatMessageTypeE.Private, ChatTypeE.GameWindow, chatMessage, this.Game.DbGame.ID);
                        }
                        else if (cbAudienceType.SelectedIndex == 1)
                        {
                            chatMessage = Ap.CurrentUser.UserName + " (To Observer) : " + txtMessage.Text;
                            ChatClient.Send(ChatAudienceTypeE.Kibitzer, ChatMessageTypeE.Text, ChatTypeE.GameWindow, this.Game.DbGame.GameID, chatMessage, this.Game.DbGame.ID);
                            ChatClient.Write(ChatTypeE.GameWindow, ChatMessageTypeE.Text, ChatTypeE.GameWindow, chatMessage, this.Game.DbGame.ID);
                        }
                        else
                        {
                            chatMessage = Ap.CurrentUser.UserName + " (To Observer & Player) : " + txtMessage.Text;
                            ChatClient.Send(ChatAudienceTypeE.KibitzerPlayer, ChatMessageTypeE.Text, ChatTypeE.GameWindow, this.Game.DbGame.GameID, chatMessage, this.Game.DbGame.ID);
                        }
                    }
                    else
                    {
                        if (cbAudienceType.SelectedIndex == 0)
                        {
                            chatMessage = Ap.CurrentUser.UserName + " (To Observer) : " + txtMessage.Text;
                            ChatClient.Send(ChatAudienceTypeE.Kibitzer, ChatMessageTypeE.Text, ChatTypeE.GameWindow, this.Game.DbGame.GameID, chatMessage, this.Game.DbGame.ID);
                        }
                        else
                        {
                            chatMessage = Ap.CurrentUser.UserName + " (To Observer & Player) : " + txtMessage.Text;
                            ChatClient.Send(ChatAudienceTypeE.KibitzerPlayer, ChatMessageTypeE.Text, ChatTypeE.GameWindow, this.Game.DbGame.GameID, chatMessage, this.Game.DbGame.ID);
                        }
                    }
                }
                else
                {
                    ChatClient.Write(ChatTypeE.GameWindow, ChatMessageTypeE.Error, ChatTypeE.GameWindow, "Not allowed for guest", this.Game.DbGame.ID);
                }
            }
        }

        private void AvChatUc_OnDial(object sender, AvChatEventArgs args)
        {
            if (chatType == ChatTypeE.OnlineClient)
            {
                if (cbAudienceType.SelectedIndex < 2 || UserID == Ap.CurrentUserID)
                {
                    return;
                }
            }
            else if (cbAudienceType.SelectedIndex != 0)
            {
                return;
            }

            if (Ap.CurrentUser.IsGuest || UserRank == "Guest")
            {
                ChatClient.Write(chatType, ChatMessageTypeE.Warning, chatType, "Not allowed for guest",0);
                return;
            }

            if (!AvPlayer.IsFlash8Installed())
            {
                if (MessageForm.Confirm(this.ParentForm, MsgE.ConfirmFlashInstall) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(Msg.GetMsg(MsgE.InfoFlashUrl));
                }
                return;
            }

            ChatMessageEventArgs chatMessage = new ChatMessageEventArgs();
            chatMessage.ChatType = chatType;
            chatMessage.Type = ChatMessageTypeE.Inprogress;
            //chatMessage.Message = "Calling " + UserName + "...";
            chatMessage.Message = "Connecting to chat server" + "...";
            AddLine(chatMessage); 
            AvPlayer.InitializeChat(UserID, UserName, args.ChatType, chatType);   
        }

        public void AvChatBegan(object sender, AvChatEventArgs args)
        {
            avClientUc1.Invoke(new AvChatDelegate(AvClientChatBegan), true, sender, args);
        }

        public void AvChatEnded(object sender, AvChatEventArgs args)
        {
            bool enable;
            if (chatType == ChatTypeE.OnlineClient)
                enable = this.cbAudienceType.SelectedIndex > 1;
            else
                enable = this.cbAudienceType.SelectedIndex == 0;

            avClientUc1.Invoke(new AvChatDelegate(AvClientChatEnded), enable, sender, args);
        }

        private void AvClientChatBegan(bool enable, object sender, AvChatEventArgs args)
        {
            avClientUc1.Enabled = enable;
            avClientUc1.ChatBegan(sender, args);
        }

        private void AvClientChatEnded(bool enable, object sender, AvChatEventArgs args)
        {
            avClientUc1.Enabled = enable;
            avClientUc1.ChatEnded(sender, args);
        }

        private void cbAudienceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!AvPlayer.IsIdle())
            {
                return;
            }

            if (chatType == ChatTypeE.OnlineClient)
                avClientUc1.Enabled = this.cbAudienceType.SelectedIndex > 1;
            else
                avClientUc1.Enabled = this.cbAudienceType.SelectedIndex == 0;
        }

        #endregion

        #region IGameUc Members

        public void NewGame()
        {

        }

        public void Init()
        {
            AddRichTextBox();

            ChatClient.Instance.ChatMessageReceived += new ChatClient.ChateMessageReceivedEventHandler(Instance_ChatMessageReceived);

            //AvClient.Instance.UserName = Ap.CurrentUserID.ToString();

            AvPlayer.OnAvChatInitialize += new EventHandler<AvChatEventArgs>(avClientUc1.ChatInitialize);
            AvPlayer.OnAvChatBegan += new EventHandler<AvChatEventArgs>(AvChatBegan);
            AvPlayer.OnAvChatEnded += new EventHandler<AvChatEventArgs>(AvChatEnded);
            avClientUc1.OnDial += new EventHandler<AvChatEventArgs>(this.AvChatUc_OnDial);
        }

        public void UnInit()
        {
            ChatClient.Instance.ChatMessageReceived -= new ChatClient.ChateMessageReceivedEventHandler(Instance_ChatMessageReceived);
            
            AvPlayer.OnAvChatInitialize -= new EventHandler<AvChatEventArgs>(avClientUc1.ChatInitialize);
            AvPlayer.OnAvChatBegan -= new EventHandler<AvChatEventArgs>(AvChatBegan);
            AvPlayer.OnAvChatEnded -= new EventHandler<AvChatEventArgs>(AvChatEnded);
            avClientUc1.OnDial -= new EventHandler<AvChatEventArgs>(this.AvChatUc_OnDial);
        }
        #endregion

        #region Overrrides

        protected override string GetPersistString()
        {
            return Guid;
        }

        #endregion

    }
}
