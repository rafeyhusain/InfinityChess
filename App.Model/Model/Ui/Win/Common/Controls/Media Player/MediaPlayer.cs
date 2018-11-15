using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading;
namespace App.Model
{
    public enum SoundFileNameE
    {
        Capture = 1,
        Capture2 = 2,
        Illegal = 3,
        Move = 4,
        Move2 = 5,
        Ring = 6,
        SetPieces = 7,
        SetPieces2 = 8,
        WrongMove = 9,
    }
    public class MediaPlayer
    {
        #region DateMember

       public static SoundPlayer player = new SoundPlayer();
        
        #endregion

        #region Method

        public static void PlaySound(SoundFileNameE soundFileID)
        {
            player.SoundLocation = GetSounfFilePath(soundFileID);
            Thread th = new Thread(Play);
            th.Start();
        }

        private static void Play()
        {
            try
            {
                player.Play();
            }
            catch (Exception ex)
            {
                App.Model.Db.Log.Write(Ap.Cxt, ex);
            }
        }

        private static string GetSounfFilePath(SoundFileNameE soundFileID)
        {
            switch (soundFileID)
            {
                case SoundFileNameE.Capture:
                    return Ap.FileCaptureWav;
                case SoundFileNameE.Capture2:
                    return Ap.FileCapture2Wav;
                case SoundFileNameE.Illegal:
                    return Ap.FileIllegalWav;
                case SoundFileNameE.Move:
                    return Ap.FileMove2Wav;
                case SoundFileNameE.Ring:
                    return Ap.FileRingWav;
                case SoundFileNameE.SetPieces:
                    return Ap.FileSetPiecesWav;
                case SoundFileNameE.SetPieces2:
                    return Ap.FileSetPieces2Wav;
                case SoundFileNameE.WrongMove:
                    return Ap.FileWrongMoveWav;
                default :break;
            }
            return "";
        }
        #endregion
    }
}
