using System;
using System.Xml;
using System.Drawing;
using System.Text;
using App.Model;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using ShockwaveFlashObjects;
using AxShockwaveFlashObjects;

namespace App.Win
{
    public partial class AvPlayer : Form
    {

        #region Data members
        private static AvChatStateE state;
        private static AvChatTypeE ChatType;
        private static Boolean initiatedChat;
        private static Int32 FromUserId;
        private static String FromUserName;
        private static Int32 ToUserId;
        private static String ToUserName;
        private static ChatTypeE ClientWindow;
        private static Timer timer;
        private static AvPlayer avPlayer;
        private static Ringer ringer;
        private static bool IsMuted;
        #endregion

        #region Events
        public delegate void StartChatDelegate(DataTable dt);
        public delegate void PlayChatDelegate();
        public delegate void StopChatDelegate();
        public static event EventHandler<AvChatEventArgs> OnAvChatInitialize;
        public static event EventHandler<AvChatEventArgs> OnAvChatBegan;
        public static event EventHandler<AvChatEventArgs> OnAvChatEnded;
        
        #endregion

        #region Constructors
        static AvPlayer()
        {
            state = AvChatStateE.Idle;
            ChatType = AvChatTypeE.Audio;
            initiatedChat = false;
            ringer = new Ringer();
            ringer.Initialize();
        }
        #endregion

        #region Methods

        public static bool IsFlash8Installed()
        {
            RegistryKey registry = Registry.ClassesRoot;
            try
            {
                registry = registry.OpenSubKey("ShockwaveFlash.ShockwaveFlash\\CurVer");
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                return false;
            }

            if (registry != null)
            {
                if (registry.ValueCount > 0)
                {
                    String[] keyParts = registry.GetValue("").ToString().Split('.');
                    if (keyParts.Length < 3)
                        return false;
                    Int32 versionNo;
                    if (!Int32.TryParse(keyParts[2], out versionNo))
                        return false;
                    return versionNo > 7;
                }
                registry.Close();
            }
            return false;
        }

        public static bool IsIdle()
        {
            return state == AvChatStateE.Idle;
        }

        public static void InitializeChat(int toUserId, String toUserName, AvChatTypeE chatType, ChatTypeE clientWindow)
        {
            state = AvChatStateE.Handshaking;
            ChatType = chatType;
            initiatedChat = true;
            ToUserId = toUserId;
            ToUserName = toUserName;
            ClientWindow = clientWindow;

            if (avPlayer != null)
            {
                avPlayer.Dispose();
                avPlayer = null;
            }

            StringBuilder connectionString = new StringBuilder("rtmp://");
            connectionString.Append(Config.AvServerIp);
            connectionString.Append(":");
            connectionString.Append(Config.AvServerPort);
            connectionString.Append("/videochat");

            try
            {
                string chatTypeString = ((int)ChatType + 1).ToString();
                avPlayer = new AvPlayer();
                avPlayer.player.CallFunction("<invoke name=\"InitializeChat\" returntype=\"xml\"><arguments><string>" + connectionString.ToString() + "</string><string>" + Ap.CurrentUserID.ToString() + "</string><string>" + toUserId.ToString() + "</string><number>" + chatTypeString + "</number></arguments></invoke>");
                //ringer.StartRinging();
                if (OnAvChatInitialize != null)
                    OnAvChatInitialize.Invoke(typeof(AvPlayer), new AvChatEventArgs(ChatType));
            }
            catch (AccessViolationException ex)
            {
                StopChat();
                MessageForm.Show(null, MsgE.ErrorAvNoCamera, MessageBoxButtons.OK, MessageBoxIcon.Error,ex);
            }
            catch (COMException e)
            {
                if (e.Message.Substring(0, 20) == "Class not registered")
                    MessageForm.Show(null, MsgE.ErrorAvNoPlayer, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void StartChat(DataTable dt)
        {
            Kv kv = new Kv(dt);
            string chatType;
            int fromUserId = kv.GetInt32("FromUserID");
            int toUserId = kv.GetInt32("ToUserID");
            string  fromUserName = kv.Get("FromUserName");
            AvChatTypeE chatTypeE = (AvChatTypeE) kv.GetInt32("AvChatType");
            
            if (chatTypeE == AvChatTypeE.Audio)
                chatType = "audio";
            else
                chatType = "video";

            if (MessageForm.Confirm(ActiveForm, MsgE.InfoAvChatRequested, chatType, fromUserName) == DialogResult.No)
            {
                kv.Set("AvChat", (int)AvChatE.Declined);
                SocketClient.SendAvResponse(kv);
                return;
            }

            state = AvChatStateE.Talking;
            initiatedChat = false;
            ChatType = chatTypeE;
            FromUserId = fromUserId;
            FromUserName = fromUserName;
            ToUserId = toUserId;
            
            if (avPlayer != null)
            {
                avPlayer.Dispose();
                avPlayer = null;
            }

            StringBuilder connectionString = new StringBuilder("rtmp://");
            connectionString.Append(Config.AvServerIp);
            connectionString.Append(":");
            connectionString.Append(Config.AvServerPort);
            connectionString.Append("/videochat");

            try
            {
                avPlayer = new AvPlayer();
                if (ChatType == AvChatTypeE.Video)
                    ShowPlayer();

                string chatTypeString = ((int)ChatType + 1).ToString();
                avPlayer.player.CallFunction("<invoke name=\"StartChat\" returntype=\"xml\"><arguments><string>" + connectionString.ToString() + "</string><string>" + FromUserId + "</string><string>" + ToUserId + "</string><number>" + chatTypeString + "</number></arguments></invoke>");

                if (OnAvChatBegan != null)
                    OnAvChatBegan.Invoke(typeof(AvPlayer), new AvChatEventArgs(ChatType));
            }

            catch (AccessViolationException ex)
            {
                TestDebugger.Instance.WriteError(ex);
                StopChat();
                MessageForm.Show(null, MsgE.ErrorAvNoCamera, MessageBoxButtons.OK, MessageBoxIcon.Error,ex);
            }
            catch (COMException e)
            {
                TestDebugger.Instance.WriteError(e);
                if (e.Message.Substring(0, 20) == "Class not registered")
                    MessageForm.Show(null, MsgE.ErrorAvNoPlayer, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public static void PlayChat()
        {
            if (avPlayer == null)
                return;

            ringer.StopRinging();
            
            avPlayer.player.CallFunction("<invoke name=\"PlayChat\" returntype=\"xml\"></invoke>");

            state = AvChatStateE.Talking;

            if (ChatType == AvChatTypeE.Video || IsMuted)
                ShowPlayer(); 

            if (OnAvChatBegan != null)
                OnAvChatBegan.Invoke(typeof(AvPlayer), new AvChatEventArgs(ChatType));
        }

        public static void StopChat()
        {
            if (initiatedChat && state == AvChatStateE.Handshaking)
                ringer.StopRinging();

            state = AvChatStateE.Idle;

            if (avPlayer != null)
            {
                avPlayer.player.CallFunction("<invoke name=\"StopChat\" returntype=\"xml\"></invoke>");
                avPlayer.Dispose();
                avPlayer = null;
            }
            
            if (OnAvChatEnded != null)
                OnAvChatEnded.Invoke(typeof(AvPlayer), new AvChatEventArgs(ChatType));
        }

        public static void ChatInitialized(bool isMuted)
        {
            IsMuted = isMuted;
            if (initiatedChat)
            {
                ringer.StartRinging();
                SocketClient.SendAvRequest(ToUserId, ToUserName, ChatType, ClientWindow);
            }
            else
            {
                SocketClient.AcceptAvRequest(FromUserId, FromUserName, ChatType, ClientWindow);
                if (IsMuted)
                    ShowPlayer();
            }
        }

        public static void StopChat(bool isChild)
        {
            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += new System.EventHandler(TimerOnTick);
            timer.Start();
        }

        private static void TimerOnTick(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Dispose();
            timer = null;
            StopChat();
        }

        private static void ShowPlayer()
        {
            avPlayer.Left = Screen.PrimaryScreen.Bounds.Width - avPlayer.Width;
            avPlayer.Top = (Screen.PrimaryScreen.Bounds.Height - avPlayer.Height) / 2;
            avPlayer.Show();
        }

        #endregion

        #region Instace Constructors
        public AvPlayer()
        {
            InitializeComponent();
            player.LoadMovie(0, Ap.FileAvSwf);
            player.Play();
        }
        #endregion

        #region Helper

        private void FlashEvent(object sender, _IShockwaveFlashEvents_FlashCallEvent e)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(e.request);
            XmlAttributeCollection attributes = document.FirstChild.Attributes;
            String command = attributes.Item(0).InnerText;
            XmlNodeList list = document.GetElementsByTagName("arguments");

            switch (command)
            {
                case "ConnectionSuccess":
                    bool isMuted = (list[0].InnerText == "true");
                    AvPlayer.ChatInitialized(isMuted);    
                    break;
                case "ConnectionFailed":
                    //ChatClient.Write(ClientWindow, ChatMessageTypeE.Error, ClientWindow, Msg.GetMsg(MsgE.InfoNoAvService),0);
                    AvPlayer.StopChat(true);
                    break;
                case "PlayStreamFailed":
                    AvPlayer.StopChat(true);
                    break;
                case "OnUnmuted": 
                    this.Hide();
                    break;
                case "OnError":
                    switch (list[0].InnerText)
                    {
                        case "2126":
                            //MessageBox.Show("Could not connect to server.");
                            break;
                        default:
                            //MessageBox.Show("Error:" + list[0].InnerText);
                            break;
                    }
                    break;
                default:
                    //MessageBox.Show("Event" + command);
                    break;
            }
        }
        #endregion

    }
}
