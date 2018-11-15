using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Collections;
using App.Model;
using System.Drawing.Drawing2D;
using InfinitySettings.Streams;
using System.Windows.Markup;
using System.Xml;
using System.Windows.Media.Effects;
using App.Win;

namespace App.Model
{
    #region struct PiecesImagesFiles
    public struct PiecesImagesFiles
    {
        // white pieces
        public const string white_rook = "white_rook.png";
        public const string white_knight = "white_knight.png";
        public const string white_bishop = "white_bishop.png";
        public const string white_queen = "white_queen.png";
        public const string white_king = "white_king.png";
        public const string white_pawn = "white_pawn.png";

        // black pieces
        public const string black_rook = "black_rook.png";
        public const string black_knight = "black_knight.png";
        public const string black_bishop = "black_bishop.png";
        public const string black_queen = "black_queen.png";
        public const string black_king = "black_king.png";
        public const string black_pawn = "black_pawn.png";
    } 
    #endregion

    public class PiecesTheme
    {
        #region DataMemebers 

        public DataTable PiecesThemeData = null;
        public DataTable ColorSchemeData = null;
        public PieceThemeE Theme = PieceThemeE.Infinity;

        public Kv KvBackground;
        public Kv KvColors;
        public Kv KvPieces;        

        #endregion

        #region Properties

        public string BorderColor
        {
            get
            {
                string color = System.Drawing.ColorTranslator.ToHtml(System.Drawing.Color.Brown);
                if (Ap.Options.BoardColorScheme == "Custom")
                {
                    color = GetBorderColor(DarkSquaresColor);
                }
                else
                {
                    color = GetColorSchemeValue("BorderColor");
                }
                return color;
            }
            set
            {
                SetColorSchemeValue("BorderColor", value);
            }
        }

        public string WhitePiecesColor
        {
            get
            {
                string color = System.Drawing.ColorTranslator.ToHtml(System.Drawing.Color.White);
                color = GetColorSchemeValue("WhitePiecesColor");
                return color;
            }
            set
            {
                SetColorSchemeValue("WhitePiecesColor", value);
            }
        }

        public string BlackPiecesColor
        {
            get
            {
                string color = System.Drawing.ColorTranslator.ToHtml(System.Drawing.Color.Black);
                color = GetColorSchemeValue("BlackPiecesColor");
                return color;
            }
            set
            {
                SetColorSchemeValue("BlackPiecesColor", value);
            }
        }

        public string LightSquaresColor
        {
            get
            {
                string color = System.Drawing.ColorTranslator.ToHtml(System.Drawing.Color.WhiteSmoke);
                color = GetColorSchemeValue("LightSquaresColor");
                return color;
            }
            set
            {
                SetColorSchemeValue("LightSquaresColor", value);
            }
        }

        public string DarkSquaresColor
        {
            get
            {
                string color = System.Drawing.ColorTranslator.ToHtml(System.Drawing.Color.Brown);
                color = GetColorSchemeValue("DarkSquaresColor");
                return color;
            }
            set
            {
                SetColorSchemeValue("DarkSquaresColor", value);
            }
        }

        #endregion

        #region Instance
        private static PiecesTheme instance = null;
        public static PiecesTheme Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PiecesTheme();
                }

                return instance;
            }
            set { instance = value; }
        }

        #endregion

        #region Ctor 

        public PiecesTheme()
        {
            PiecesThemeData = UData.ToTable2("PiecesThemeData", "ThemeID", "PieceID", "PieceXaml");
            ColorSchemeData = UData.ToTable2("ColorSchemeData", "ColorScheme", "BorderColor", "WhitePiecesColor", "BlackPiecesColor", "LightSquaresColor", "DarkSquaresColor");

            KvBackground = new Kv(KvType.BackgroundThemes);
            KvColors = new Kv(KvType.ColorSchemes);
            KvPieces = new Kv(KvType.PiecesThemes);

            Load();
        }

        #endregion
        
        #region Load Methods 

        public void Load()
        {
            if (UFile.Exists(Ap.FilePiecesTheme))
            {
                PiecesThemeData.Rows.Clear();
                System.IO.MemoryStream memoryStream = InfinityStreamsManager.ReadStreamFromFile(Ap.FilePiecesTheme);
                PiecesThemeData.ReadXml(memoryStream);
                memoryStream.Close();
            }

            if (UFile.Exists(Ap.FileColorScheme))
            {
                ColorSchemeData.Rows.Clear();
                System.IO.MemoryStream memoryStream = InfinityStreamsManager.ReadStreamFromFile(Ap.FileColorScheme);
                ColorSchemeData.ReadXml(memoryStream);
                memoryStream.Close();
            }
        }

        public string GetPieceXaml(int themeID, int pieceID)
        {
            DataRow row = GetThemeRow(themeID, pieceID);

            return BaseItem.GetCol(row, "PieceXaml");            
        }

        private DataRow GetThemeRow(int themeID, int pieceID)
        {
            DataRow[] rows = PiecesThemeData.Select("ThemeID=" + themeID.ToString() + " AND PieceID=" + pieceID.ToString());
            
            if (rows.Length > 0)
                return rows[0];

            return null;
        }

        private DataRow GetColorSchemeRow(string colorScheme)
        {
            DataRow[] rows = ColorSchemeData.Select("ColorScheme='" + colorScheme + "'");

            if (rows.Length > 0)
                return rows[0];

            return null;
        }

        private string GetBorderColor(string darkSquareColor)
        {
            string borderColor = string.Empty;
            int colorDifference = 70;
            System.Drawing.Color dColor = System.Drawing.ColorTranslator.FromHtml(Ap.PiecesTheme.DarkSquaresColor);
            int r = dColor.R;
            int g = dColor.G;
            int b = dColor.B;
            if ((r - colorDifference > 0 || r == 0) && (g - colorDifference > 0 || g == 0) && (b - colorDifference > 0 || b == 0))
            {
                if (r > 0)
                    r = r - colorDifference;
                if (g > 0)
                    g = g - colorDifference;
                if (b > 0)
                    b = b - colorDifference;
            }

            System.Drawing.Color dDarkColor = System.Drawing.Color.FromArgb(r, g, b);
            borderColor = System.Drawing.ColorTranslator.ToHtml(dDarkColor);
            return borderColor;
        }

        private string GetColorSchemeValue(string columnName)
        {
            string value = string.Empty;
            DataRow dr = GetColorSchemeRow(Ap.Options.BoardColorScheme);
                if (dr != null)
                {
                    value = dr[columnName].ToString();
                }
            return value;
        }

        private void SetColorSchemeValue(string columnName, string value)
        {
            DataRow dr = GetColorSchemeRow(Ap.Options.BoardColorScheme);
            if (dr != null)
            {
                dr[columnName] = value;
            }
        }

        #endregion

        #region Get Viewbox (Pieces Images) 

        public void SetColor(object parentControl, Color fillColor)
        {
            if (parentControl.GetType() == typeof(Panel) || parentControl.GetType().BaseType == typeof(Panel))
            {
                Panel panel = parentControl as Panel;
                foreach (object obj in panel.Children)
                {
                    if (obj.GetType() == typeof(Path))
                    {
                        Path path = obj as Path;
                        path.Fill = new SolidColorBrush(fillColor);
                        if (fillColor == GetMediaColor(WhitePiecesColor))
                        {
                            path.Stroke = GetColorBrush(Colors.Black);
                            //path.Stroke = GetColorBrush(Ap.Options.BoardBlackPiecesColor);
                        }
                        else
                        {
                            //path.Stroke = GetColorBrush(Colors.Black);
                            path.Stroke = GetColorBrush(Colors.DarkGray);
                        }                        
                    }
                    if (obj.GetType() == typeof(Ellipse))
                    {
                        Ellipse ellipse = obj as Ellipse;
                        ellipse.Fill = new SolidColorBrush(fillColor);
                        if (fillColor == GetMediaColor(WhitePiecesColor))
                        {
                            ellipse.Stroke = GetColorBrush(Colors.Black);
                            //ellipse.Stroke = GetColorBrush(Ap.Options.BoardBlackPiecesColor);
                        }
                        else
                        {
                            ellipse.Stroke = GetColorBrush(Colors.DarkGray);
                        }
                    }
                    if (obj.GetType() == typeof(Rectangle))
                    {
                        Rectangle rectangle = obj as Rectangle;
                        rectangle.Fill = new SolidColorBrush(fillColor);
                        if (fillColor == GetMediaColor(WhitePiecesColor))
                        {
                            rectangle.Stroke = GetColorBrush(Colors.Black);
                            //ellipse.Stroke = GetColorBrush(Ap.Options.BoardBlackPiecesColor);
                        }
                        else
                        {
                            rectangle.Stroke = GetColorBrush(Colors.DarkGray);
                        }
                    }
                    else if (obj.GetType() == typeof(Panel) || obj.GetType().BaseType == typeof(Panel))
                    {
                        SetColor(obj, fillColor);
                    }
                    else if (obj.GetType() == typeof(Viewbox))
                    {
                        Viewbox vb = obj as Viewbox;
                        SetColor(vb.Child, fillColor);
                    }
                }
            }
            else if (parentControl.GetType() == typeof(Viewbox))
            {
                Viewbox vb = parentControl as Viewbox;
                SetColor(vb.Child, fillColor);
            }
        }

        private Viewbox GetViewbox(int pieceID)
        {
            string pieceXaml = string.Empty;

            // if black piece, then set it to white piece,
            // as we have only maintained white pieces xaml,
            // then we color it then display with black color
            if (pieceID > 6)
                pieceID = pieceID - 6;

            pieceXaml = GetPieceXaml((int)Theme, pieceID);
            Viewbox vb = GetViewbox(pieceXaml);
            
            return vb;
        }

        private Viewbox GetViewbox(string pieceXaml)
        {
            Viewbox vb = null;            
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(pieceXaml);
            XmlElement root = xmldoc.DocumentElement;
            string viewboxXaml = root.InnerXml;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(Encoding.ASCII.GetBytes(viewboxXaml));
            ParserContext pc = null;
            pc = new ParserContext();
            pc.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            pc.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");

            vb = XamlReader.Load(ms, pc) as Viewbox;
            vb.Margin = new Thickness(3, 3, 3, 3);
            ms.Close();

            return vb;
        }

        public Viewbox GetViewbox(Pieces piece)
        {
            Viewbox vb = null;
            vb = GetViewbox((int)piece);
            if (vb != null)
            {
                Color fillColor = GetPieceColor(piece);
                SetColor(vb, fillColor);
            }

            return vb;
        }

        private Color GetPieceColor(Pieces piece)
        {
            Color color = Colors.White;
            if (piece.ToString().StartsWith("W"))
            {
                color = GetMediaColor(WhitePiecesColor);
            }
            else if (piece.ToString().StartsWith("B"))
            {
                color = GetMediaColor(BlackPiecesColor);
            }
            return color;
        }
       
        #endregion

        #region Static Methods 

        public static ImageBrush GetImageBrush(string imagePath)
        {
            ImageBrush brush = new ImageBrush();
            BitmapImage image = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
            brush.ImageSource = image;

            return brush;
        }

        public static SolidColorBrush GetColorBrush(Color color)
        {
            SolidColorBrush brush = new SolidColorBrush(color);
            return brush;
        }

        public static SolidColorBrush GetColorBrush(string colorName)
        {
            //Color color = Color.FromArgb(GetByte(colorName, 1), GetByte(colorName, 3), GetByte(colorName, 5), GetByte(colorName, 7));
            Color color = (Color)ColorConverter.ConvertFromString(colorName);
            SolidColorBrush brush = new SolidColorBrush(color);
            return brush;
        }

        public static System.Windows.Media.RadialGradientBrush GetGradientColorBrush(Color color)
        {
            System.Windows.Media.RadialGradientBrush brush = new System.Windows.Media.RadialGradientBrush();
            brush.GradientStops.Add(new GradientStop(color, 1.0));
            brush.GradientStops.Add(new GradientStop(Colors.White, 0.005));
            return brush;
        }

        public static System.Windows.Media.RadialGradientBrush GetGradientColorBrush(string colorName)
        {
            Color color = (Color)ColorConverter.ConvertFromString(colorName);
            System.Windows.Media.RadialGradientBrush brush = new System.Windows.Media.RadialGradientBrush();
            brush.GradientStops.Add(new GradientStop(color, 1.0));            
            brush.GradientStops.Add(new GradientStop(Colors.White, 0.05));            
            return brush;
        }

        public static Color GetMediaColor(System.Drawing.Color color)
        {
            string colorName = System.Drawing.ColorTranslator.ToHtml(color);
            return (Color)ColorConverter.ConvertFromString(colorName);
        }

        public static Color GetMediaColor(string colorName)
        {
            return (Color)ColorConverter.ConvertFromString(colorName);
        }

        private static byte GetByte(string s, int start)
        {
            if (!s.StartsWith("#"))
                s = "#" + s;
            return Convert.ToByte(s.Substring(start, 2), 16);
        }

        #endregion

        #region Save 

        public void Save()
        {
            Save(Ap.FilePiecesTheme);
            SaveColorScheme(Ap.FileColorScheme);
        }

        public void Save(string filePath)
        {
            UFile.RemoveReadOnly(filePath);
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            PiecesThemeData.WriteXml(memoryStream);
            InfinityStreamsManager.WriteStreamToFile(filePath, memoryStream);
            memoryStream.Close();
        }

        public void SaveColorScheme(string filePath)
        {
            UFile.RemoveReadOnly(filePath);
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            ColorSchemeData.WriteXml(memoryStream);
            InfinityStreamsManager.WriteStreamToFile(filePath, memoryStream);
            memoryStream.Close();
        }

        #endregion

        #region ResetFactorySettings

        public void ResetFactorySettings()
        {
            Ap.PiecesTheme.Theme = PieceThemeE.Infinity;
        }

        #endregion
    }

    public enum PieceThemeE
    {
        Crystals=1,
        Infinity=2,
        Habsburg=3,
        Oldstyle=4,
        USCF=5
    }

}
