using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace App.Model
{
    public class Ringer
    {

        #region Data members

        private bool wavFileExists;
        private Timer timer;
        private SoundPlayer player;
 
        #endregion

        #region Methods
        public void Initialize()
        {
            try
            {
                timer = new Timer(Ring);
                player = new SoundPlayer(Ap.FileRingWav);
                player.Load();
                wavFileExists = true;   
            }
            catch
            {
                wavFileExists = false;
            }
        }

        public void StartRinging()
        {
            if(wavFileExists)
                timer.Change(0, 2500);
        }

        public void StopRinging()
        {
            if (wavFileExists)
                timer.Change(-1, -1);
        }

        private void Ring(object state)
        {
            player.PlaySync();
        } 
        #endregion
    }


    #region Class AvChatEventArgs
    public class AvChatEventArgs : EventArgs
    {
        public AvChatTypeE ChatType;
        public AvChatEventArgs(AvChatTypeE chatType)
        {
            ChatType = chatType;
        }
    }
    #endregion

    #region Class AvFrameEventArgs
    public class AvFrameEventArgs : EventArgs
    {
        public Bitmap Bitmap;
        public AvFrameEventArgs(Bitmap bitmap)
        {
            this.Bitmap = bitmap;
        }
    }
    #endregion

    #region Class ErrorEventArgs

    public class ErrorEventArgs : EventArgs
    {
        public readonly string ErrorMessage;

        public ErrorEventArgs(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }

    #endregion

}
