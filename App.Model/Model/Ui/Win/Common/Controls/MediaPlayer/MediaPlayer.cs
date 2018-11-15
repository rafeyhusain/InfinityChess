using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading;
using App.Model.Db;

namespace App.Model
{
    public enum SoundFileNameE
    {
        Capture = 1,
        Illegal = 3,
        Move = 4,
        Ring = 6,
        SetPieces = 7,
    }
    public class MediaPlayer
    {
        #region DateMember

        public static SoundPlayer player = new SoundPlayer();

        #endregion

        #region Method

        public static void PlaySound(SoundFileNameE soundFileID)
        {
            if (Ap.Options.DoMultimediaBoardSounds)
            {
                player.SoundLocation = GetSounfFilePath(soundFileID);

                if (UFile.Exists(player.SoundLocation))
                {
                    Thread th = new Thread(Play);
                    th.Start();
                }
            }
        }

        private static void Play()
        {
            try
            {
                player.Play();
            }
            catch (Exception ex)
            {
                Log.Write(Ap.Cxt, ex);
            }
        }

        private static string GetSounfFilePath(SoundFileNameE soundFileID)
        {
            switch (soundFileID)
            {
                case SoundFileNameE.Capture:
                    return Ap.FileCaptureWav;
                case SoundFileNameE.Illegal:
                    return Ap.FileIllegalWav;
                case SoundFileNameE.Move:
                    return Ap.FileMoveWav;
                case SoundFileNameE.Ring:
                    return Ap.FileRingWav;
                case SoundFileNameE.SetPieces:
                    return Ap.FileSetPiecesWav;
                default: break;
            }
            return "";
        }
        #endregion
    }
}
