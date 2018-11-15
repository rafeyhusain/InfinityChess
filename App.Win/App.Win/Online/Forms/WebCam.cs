using System;
using System.Drawing;
using App.Model; 
using System.Windows.Forms;

namespace App.Win
{
    public partial class WebCam : Form
    {
        #region Data Members
        private static WebCam webCam;
        private delegate void FrameDelegate(Bitmap bitmap);
        #endregion

        #region Constructor
        private WebCam()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        public static bool IsLoaded;

        public static WebCam Instance
        {
            //[System.Diagnostics.DebuggerStepThrough]
            //get { return webCam ?? (webCam  = new WebCam()); }
            get
            {
                if (webCam == null || webCam.IsDisposed)
                    webCam = new WebCam();
                return webCam;
            }
        }
        #endregion

        #region Event Handlers

        private void AvClient_OnLocalFrame(object sender, AvFrameEventArgs args)
        {
            if(this.pctLocalWebCam.InvokeRequired)
                this.pctLocalWebCam.Invoke(new FrameDelegate(OnLocalFrame),args.Bitmap);
            else
                this.pctLocalWebCam.Image = args.Bitmap;
        }

        private void AvClient_OnRemoteFrame(object sender, AvFrameEventArgs args)
        {
            if (this.pctRemoteWebCam.InvokeRequired)
                this.pctRemoteWebCam.Invoke(new FrameDelegate(OnRemoteFrame), args.Bitmap);
            else
                this.pctRemoteWebCam.Image = args.Bitmap;
        }

        private void OnLocalFrame(Bitmap bitmap)
        {
            this.pctLocalWebCam.Image = bitmap;
        }

        private void OnRemoteFrame(Bitmap bitmap)
        {
            this.pctRemoteWebCam.Image = bitmap;
        }

        private void WebCam_OnClose(object sender, System.EventArgs args)
        {
        } 

        #endregion

    }
}
