using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using App.Model.Db;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Drawing;

namespace App.Model
{
    public class ApCache
    {
        public Dictionary<string, Image> GameTypeImages = new Dictionary<string, Image>();
        public Dictionary<string, Image> RankImages = new Dictionary<string, Image>();

        public void Init(ApModuleE module)
        {
            if (module == ApModuleE.Online)
            {
                GameTypeImages.Add("1", Image.FromFile(App.Model.Ap.FolderImages + @"GameTypes\1.PNG"));
                GameTypeImages.Add("2", Image.FromFile(App.Model.Ap.FolderImages + @"GameTypes\2.PNG"));
                GameTypeImages.Add("3", Image.FromFile(App.Model.Ap.FolderImages + @"GameTypes\3.PNG"));
                GameTypeImages.Add("4", Image.FromFile(App.Model.Ap.FolderImages + @"GameTypes\4.PNG"));
                GameTypeImages.Add("5", Image.FromFile(App.Model.Ap.FolderImages + @"GameTypes\5.PNG"));
                
                RankImages.Add("Admin", Image.FromFile(App.Model.Ap.FolderImages + @"Ranks\Admin.PNG"));
                RankImages.Add("Pawn", Image.FromFile(App.Model.Ap.FolderImages + @"Ranks\Pawn.PNG"));
                RankImages.Add("Knight", Image.FromFile(App.Model.Ap.FolderImages + @"Ranks\Knight.PNG"));
                RankImages.Add("Bishop", Image.FromFile(App.Model.Ap.FolderImages + @"Ranks\Bishop.PNG"));
                RankImages.Add("Rook", Image.FromFile(App.Model.Ap.FolderImages + @"Ranks\Rook.PNG"));
                RankImages.Add("Queen", Image.FromFile(App.Model.Ap.FolderImages + @"Ranks\Queen.PNG"));
                RankImages.Add("King", Image.FromFile(App.Model.Ap.FolderImages + @"Ranks\King.PNG"));
                RankImages.Add("Guest", Image.FromFile(App.Model.Ap.FolderImages + @"Ranks\Guest.PNG"));
            }
        }

        public void UnInit(ApModuleE module)
        {
            if (module == ApModuleE.Online)
            {
                GameTypeImages.Clear();
                RankImages.Clear();
            }
        }
    }
}
