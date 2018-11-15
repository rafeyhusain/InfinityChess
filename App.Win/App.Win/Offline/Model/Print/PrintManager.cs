using System; using App.Model;
using System.Collections.Generic;

using System.Text;
using InfinityChess.PGNManager;
using System.Data;
using InfinityChess.Data.Xsd;
using System.IO;
using System.Drawing;

namespace InfinityChess.Print
{
    public class PrintManager
    {
        public InfinityChess.Data.Xsd.PrintGameDataSet dsPrintGame;
        public void PrintGame()
        {
            string white = App.Model.Ap.Game.Player1.PlayerTitle;
            string black = App.Model.Ap.Game.Player2.PlayerTitle;
            
            DataTable MovesDisplay = App.Model.Ap.Game.Notations.NotationView;
            string notations = string.Empty;

            for (int i = 0; i < MovesDisplay.Rows.Count; i++)
            {
                for (int j = 0; j < MovesDisplay.Columns.Count; j++)
                {
                    notations += MovesDisplay.Rows[i][j].ToString() + " ";
                }
            }

            string date = DateTime.Now.ToShortDateString();

            string gametype = Ap.Game.GameType.ToString();

            dsPrintGame = new PrintGameDataSet();
            DataRow dr = dsPrintGame.PrintGame.NewRow();
            dr[0] = white;
            dr[1] = black;
            dr[2] = notations;
            dr[3] = gametype;
            dr[4] = date;
            dsPrintGame.PrintGame.Rows.Add(dr);
        }

        public void PrintDiagram()
        {
            string FilePath = Ap.FilePrintDiagram;
            dsPrintGame = new PrintGameDataSet();
            DataRow dr = dsPrintGame.PrintDiagram.NewRow();
            dr[0] = GetImageBytes(FilePath);
            dsPrintGame.PrintDiagram.Rows.Add(dr);
        }

        private void AddImageColumn(DataTable objDataTable, string strFieldName)
        {

            DataColumn objDataColumn = new DataColumn(strFieldName,
            Type.GetType("System.Byte[]"));
            objDataTable.Columns.Add(objDataColumn);

        }

        private byte[] GetImageBytes(string FilePath)
        {
            byte[] Image = null;
            FileStream fs = new FileStream(FilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            Image = new byte[fs.Length];
            fs.Read(Image, 0, Convert.ToInt32(fs.Length));
            fs.Close();

            return Image;
        }

    }
}
