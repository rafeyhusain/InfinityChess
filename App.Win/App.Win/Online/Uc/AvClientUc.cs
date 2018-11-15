using System;
using System.Drawing;
using System.Windows.Forms;
using App.Model;

namespace App.Win
{
    public partial class AvClientUc : UserControl
    {

        #region Data Members
        private delegate void CboChatEndedDelegate();
        private delegate void BtnChatEndedDelegate(); 
        #endregion

        #region Constructor

        public AvClientUc()
        {
            InitializeComponent();
            cboChatType.SelectedIndex = 0;
            //AvPlayer.OnAvChatInitialize += new EventHandler<AvChatEventArgs>(this.ChatInitialize);
            //AvPlayer.OnAvChatBegan += new EventHandler<AvChatEventArgs>(this.ChatBegan);
            //AvPlayer.OnAvChatEnded += new EventHandler<AvChatEventArgs>(this.ChatEnded);
        }

        private void RemoveEvents() 
        {
            //AvPlayer.OnAvChatInitialize -= new EventHandler<AvChatEventArgs>(this.ChatInitialize);
            //AvPlayer.OnAvChatBegan -= new EventHandler<AvChatEventArgs>(this.ChatBegan);
            //AvPlayer.OnAvChatEnded -= new EventHandler<AvChatEventArgs>(this.ChatEnded);
        }

        private void DrawItem(object sender, DrawItemEventArgs args)
        {
            string[] items = { "Audio Chat", "Video Chat" };
            Image image = args.Index == 0 ? InfinityChess.Properties.Resources.AudioChat : InfinityChess.Properties.Resources.VideoChat;

            args.Graphics.FillRectangle(Brushes.Bisque, args.Bounds);
            args.Graphics.DrawString(items[args.Index], this.Font, new SolidBrush(this.ForeColor),
                                  new Point(26, args.Bounds.Y));
            args.Graphics.DrawImage(image, new Point(args.Bounds.X, args.Bounds.Y));

            if ((args.State & DrawItemState.Focus) != 0) return;
            args.Graphics.FillRectangle(Brushes.White, args.Bounds);
            args.Graphics.DrawString(items[args.Index], this.Font, new SolidBrush(this.ForeColor),
                                     new Point(26, args.Bounds.Y));
            args.Graphics.DrawImage(image, new Point(args.Bounds.X, args.Bounds.Y));
        }

        #endregion

        #region Events

        public event EventHandler<AvChatEventArgs> OnDial;
        public event EventHandler OnHangup;

        #endregion

        #region Methods

        public void ChatInitialize(object sender, AvChatEventArgs args)
        {
            btnDial.Image = InfinityChess.Properties.Resources.HangupCall;
            cboChatType.SelectedIndex = (int)args.ChatType;
            cboChatType.Enabled = false;   
        }

        public void ChatBegan(object sender, AvChatEventArgs args)
        {
            btnDial.Image = InfinityChess.Properties.Resources.HangupCall;
            cboChatType.SelectedIndex = (int)args.ChatType;
            cboChatType.Enabled = false;
            //if(args.ChatType == AvChatTypeE.Video)
            //{
            //    lock(typeof(WebCam))
            //    {
            //        if(!WebCam.IsLoaded)
            //        {
            //            //WebCam.Instance.Left = Screen.PrimaryScreen.Bounds.Width - WebCam.Instance.Width;
            //            //WebCam.Instance.Top = (Screen.PrimaryScreen.Bounds.Height - WebCam.Instance.Height) / 2;
            //            //WebCam.Instance.Left = this.Parent.Left + 20;
            //            //WebCam.Instance.Top = this.Parent.Top + this.Parent.Height - WebCam.Instance.Height - 20;
            //            //WebCam.Instance.Show();
            //            //WebCam.IsLoaded = true; 
            //        }
            //    }  
            //}  
        }

        public void ChatEnded(object sender, AvChatEventArgs args)
        {
            cboChatType.Invoke(new CboChatEndedDelegate(cboChatEnded));
            btnDial.Invoke(new BtnChatEndedDelegate(btnChatEnded));
            //if (args.ChatType == AvChatTypeE.Video)
            //{
            //    lock (typeof(WebCam))
            //    {
            //        if (WebCam.IsLoaded)
            //        {
            //            WebCam.Instance.Dispose();   
            //            WebCam.IsLoaded = false;
            //        }
            //    }
            //}  
            if (OnHangup != null)
                OnHangup.Invoke(this, new EventArgs());
        }

        private void cboChatEnded()
        {
            cboChatType.Enabled = true;
        }

        private void btnChatEnded()
        {
            btnDial.Image = InfinityChess.Properties.Resources.PickupCall;
        }

        private void btnDial_Click(object sender, EventArgs e)
        {
            if (!AvPlayer.IsIdle())
                AvPlayer.StopChat();
            else
                if (OnDial != null)
                    OnDial.Invoke(this, new AvChatEventArgs((AvChatTypeE)(cboChatType.SelectedIndex)));
        }

        #endregion
    }
}


  