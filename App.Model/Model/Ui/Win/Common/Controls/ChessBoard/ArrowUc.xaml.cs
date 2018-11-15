using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using App.Model;
using ChessBoardCtrl.New;
using InfinitySettings.GameManager;
using InfinitySettings.UCIManager;
using System.Collections;
using ChessLibrary;
using System.Diagnostics;
using System.Windows.Threading;
using System.Threading;
using System.Windows.Media.Effects;
using System.ComponentModel;

namespace App.Win
{
    /// <summary>
    /// Interaction logic for ChessBoardUc.xaml
    /// </summary>
    public partial class ArrowUc : UserControl
    {
        #region DataMembers 

        Color arrowColor = Colors.Black;
        double opacity = 0.5;

        #endregion

        #region Properties

        private Point startPoint;
        public Point StartPoint
        {
            get { return startPoint; }
            set
            {
                startPoint = value;
                Update(arrowColor);
            }
        }

        private Point endPoint;
        public Point EndPoint
        {
            get { return endPoint; }
            set
            {
                endPoint = value;
                Update(arrowColor);
            }
        }

        #endregion

        #region Ctor & Load

        public ArrowUc(Game game)
        {
            InitializeComponent();
        }

        public ArrowUc(Point StartPoint, Point EndPoint)
        {
            InitializeComponent();
            startPoint = StartPoint;
            endPoint = EndPoint;
            Update(arrowColor);
        }

        #endregion

        #region Helper Methods

        public void Draw(Point startPoint, Point endPoint)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;

            Update(arrowColor);
        }

        public void Draw(Point startPoint, Point endPoint, Color color)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;

            arrowColor = color;
            Update(arrowColor);
        }

        private void Update(Color color)
        {
            double angleOfLine = Math.Atan2((endPoint.Y - startPoint.Y), (endPoint.X - startPoint.X)) * 180 / Math.PI;

            Connector.X1 = startPoint.X;
            Connector.Y1 = startPoint.Y;
            Connector.X2 = endPoint.X;
            Connector.Y2 = endPoint.Y;
            Connector.StrokeThickness = 7;
            Connector.Stroke = new SolidColorBrush(color);
            Connector.Opacity = opacity;

            Cap.X1 = startPoint.X;
            Cap.Y1 = startPoint.Y;
            Cap.X2 = startPoint.X;
            Cap.Y2 = startPoint.Y;
            Cap.StrokeStartLineCap = PenLineCap.Triangle;
            Cap.StrokeThickness = 20;
            Cap.Stroke = new SolidColorBrush(color);
            Cap.Opacity = opacity;

            CapRotateTransform.Angle = angleOfLine;
            CapRotateTransform.CenterX = startPoint.X;
            CapRotateTransform.CenterY = startPoint.Y;

            Foot.X1 = endPoint.X;
            Foot.Y1 = endPoint.Y;
            Foot.X2 = endPoint.X;
            Foot.Y2 = endPoint.Y;
            Foot.StrokeThickness = 20;
            Foot.Stroke = new SolidColorBrush(color);
            Foot.Opacity = opacity;
        }

        #endregion
    }
}
