using System; using App.Model;
using System.Collections.Generic;

using System.Text;

namespace InfinityChess.InfinityChesshelp
{
    public class InfinityChessHelp
    {
        public static void OpenHelpFile()
        {
            UProcess.Start(App.Model.Ap.FileHelpChm);
        }
    }
}
