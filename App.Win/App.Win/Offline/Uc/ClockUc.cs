using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InfinityChess.Offline.Forms;
using App.Model;
using WeifenLuo.WinFormsUI.Docking;

namespace InfinityChess
{
    public partial class ClockUc : DockContent, IGameUc    
    //public partial class ClockUc : UserControl
    {
        #region Data Members

        public Game Game = null;

        public const string Guid = "bd678d79-0626-4e02-a5b8-cfe44c819ad0";
        public ClockType ClockType = ClockType.Digital;

        #region Analog Clock

        const float PI = 3.141592654F;
        float fRadius;
        float fCenterX;
        float fCenterY;
        float fCenterCircleRadius;

        float fHourLength;
        float fMinLength;
        float fSecLength;

        float fHourThickness;
        float fMinThickness;
        float fSecThickness;

        bool bDraw5MinuteTicks = true;
        bool bDraw1MinuteTicks = true;
        float fTicksThickness = 1;

        Color hrColor = Color.Magenta;
        Color minColor = Color.Blue;
        Color secColor = Color.Red;
        Color circleColor = Color.White;
        Color ticksColor = Color.White;


        #endregion

        #endregion 

        #region Ctor
        public ClockUc(Game game)
        {
            this.Game = game;
            InitializeComponent();
            this.Height = 800;
        }
        #endregion

        #region Properties

        #region Analog Clock
        public Color HourHandColor
        {
            get { return this.hrColor; }
            set { this.hrColor = value; }
        }

        public Color MinuteHandColor
        {
            get { return this.minColor; }
            set { this.minColor = value; }
        }

        public Color SecondHandColor
        {
            get { return this.secColor; }
            set
            {
                this.secColor = value;
                this.circleColor = value;
            }
        }

        public Color TicksColor
        {
            get { return this.ticksColor; }
            set { this.ticksColor = value; }
        }

        public bool Draw1MinuteTicks
        {
            get { return this.bDraw1MinuteTicks; }
            set { this.bDraw1MinuteTicks = value; }
        }

        public bool Draw5MinuteTicks
        {
            get { return this.bDraw5MinuteTicks; }
            set { this.bDraw5MinuteTicks = value; }
        }

        #endregion

        #endregion

        #region IGameUc Members

        public void NewGame()
        {
            ClockType = ClockType.Digital;
            lblWhiteTime.ForeColor = Color.White;
            lblBlackTime.ForeColor = Color.White;

            SetClockType();

            ResizeWhite();
            ResizeBlack();
            RefreshClock();

            SetMinSize();
        }

        public void Init()
        {
            timer1.Tick += new EventHandler(timer1_Tick);
            this.Game.Clock.TimeExpired += new EventHandler<TimeExpiredEventArgs>(Clock_TimeExpired);
            this.Game.Clock.ClockSet += new EventHandler(Clock_ClockSet);
            this.Game.Clock.ClockTick += new EventHandler(Clock_ClockTick);
            this.Game.AfterAddMove += new EventHandler(Game_AfterAddMove);
        }

        void Clock_ClockTick(object sender, EventArgs e)
        {
            RefreshClock();
        }

        void Clock_ClockSet(object sender, EventArgs e)
        {
            ResetClock();
        }

        void Game_AfterAddMove(object sender, EventArgs e)
        {
            RefreshClock();
        }

        public void UnInit()
        {
            timer1.Tick -= new EventHandler(timer1_Tick);
            this.Game.Clock.TimeExpired -= new EventHandler<TimeExpiredEventArgs>(Clock_TimeExpired);
            this.Game.Clock.ClockSet -= new EventHandler(Clock_ClockSet);
            this.Game.Clock.ClockTick -= new EventHandler(Clock_ClockTick);
            this.Game.AfterAddMove -= new EventHandler(Game_AfterAddMove);
        }

        #endregion

        #region SetClockType

        private void SetClockType()
        {
            ClockType clockType = ClockType.Digital;
            switch (Ap.Options.ClockType)
            {
                case "Digital":
                    clockType = ClockType.Digital;
                    break;
                case "Analog":
                    clockType = ClockType.Analog;
                    break;
                case "DoubleDigital":
                    clockType = ClockType.DoubleDigital;
                    break;
                default:
                    break;
            }
            this.SetClockType(clockType);
        }

        public void SetClockType(ClockType clockType)
        {
            this.ClockType = clockType;
            RefreshClock();
        }

        #endregion

        #region Display Clock

        public void ResetClock()
        {
            switch (ClockType)
            {
                case ClockType.Digital:
                    ResetTimeString();
                    DisplayDigitalClock();
                    break;
                case ClockType.Analog:
                    DisplayAnalogClock();
                    break;
                default:
                    ResetTimeString();
                    DisplayDoubleDigitalClock();
                    break;
            }
        }

        public void RefreshClock()
        {
            switch (ClockType)
            {
                case ClockType.Digital:
                    SetTimeString();
                    DisplayDigitalClock();
                    break;
                case ClockType.Analog:
                    DisplayAnalogClock();
                    break;
                default:
                    if (this.Game.Flags.IsInfiniteAnalysisOff)
                    {
                        SetTimeString();
                    }
                    else
                    {
                        SetTimeStringInInfiniteAnalysis();
                    }
                    DisplayDoubleDigitalClock();
                    break;
            }
        }

        private void DisplayDigitalClock()
        {
            lblWhiteCount.Visible = false;
            lblBlackCount.Visible = false;

            pnlDigitalClock.Visible = true;

            pnlAnalogClock.Visible = false;
        }

        private void ResetTimeString()
        {
            if (this.Game.Flags.IsInfiniteAnalysisOn)
            {
                lblWhiteTime.Text = this.Game.Clock.ZeroTimeString;
                lblBlackTime.Text = this.Game.Clock.ZeroTimeString;
                lblWhiteCount.Text = this.Game.Clock.ZeroTimeString;
                lblBlackCount.Text = this.Game.Clock.ZeroTimeString;
            }
            else
            {
                lblWhiteTime.Text = this.Game.Clock.WhiteTimeString;
                lblBlackTime.Text = this.Game.Clock.BlackTimeString;

                if (this.Game.Flags.IsFirtMove)
                {
                    lblWhiteCount.Text = this.Game.Clock.MoveTimeString;
                    lblBlackCount.Text = this.Game.Clock.MoveTimeString;
                    return;
                }

                if (this.Game.Flags.IsWhiteTurn)
                {
                    lblWhiteCount.Text = this.Game.Clock.ZeroTimeString;
                    lblBlackCount.Text = this.Game.Clock.MoveTimeString;
                }
                else
                {
                    lblWhiteCount.Text = this.Game.Clock.MoveTimeString;
                    lblBlackCount.Text = this.Game.Clock.ZeroTimeString;
                }
            }
        }

        private void SetTimeString()
        {
            if (this.Game.Flags.IsInfiniteAnalysisOn)
            {
                lblWhiteTime.Text = this.Game.Clock.ZeroTimeString;
                lblBlackTime.Text = this.Game.Clock.ZeroTimeString;
                lblWhiteCount.Text = this.Game.Clock.ZeroTimeString;
                lblBlackCount.Text = this.Game.Clock.ZeroTimeString;
            }
            else
            {
                lblWhiteTime.Text = this.Game.Clock.WhiteTimeString;
                lblBlackTime.Text = this.Game.Clock.BlackTimeString;

                if (this.Game.Flags.IsFirtMove)
                {
                    lblWhiteCount.Text = this.Game.Clock.MoveTimeString;
                    return;
                }

                if (this.Game.Flags.IsWhiteTurn)
                {
                    lblWhiteCount.Text = this.Game.Clock.MoveTimeString;
                }
                else
                {
                    lblBlackCount.Text = this.Game.Clock.MoveTimeString;
                }
            }
        }

        private void SetTimeStringInInfiniteAnalysis()
        {
            lblWhiteTime.Text = this.Game.Clock.ZeroTimeString;
            lblBlackTime.Text = this.Game.Clock.ZeroTimeString;
            lblWhiteCount.Text = this.Game.Clock.ZeroTimeString;
            lblBlackCount.Text = this.Game.Clock.ZeroTimeString;

            //if (this.Game.Flags.IsFirtMove)
            //{
            //    lblWhiteTime.Text = this.Game.Clock.MoveTimeString;
            //    return;
            //}

            //if (this.Game.Flags.IsWhiteTurn)
            //{
            //    lblWhiteTime.Text = this.Game.Clock.MoveTimeString;
            //}
            //else
            //{
            //    lblBlackTime.Text = this.Game.Clock.MoveTimeString;
            //}
        }

        private void DisplayDoubleDigitalClock()
        {
            lblWhiteCount.Visible = true;
            lblBlackCount.Visible = true;

            pnlDigitalClock.Visible = true;
            pnlAnalogClock.Visible = false;
        }

        private void DisplayAnalogClock()
        {
            pnlWhite.Refresh();
            pnlBlack.Refresh();

            pnlAnalogClock.Visible = true;
            pnlDigitalClock.Visible = false;
        }
        #endregion

        #region Timer Tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Game == null)
            {
                return;
            }

            this.Game.Clock.Tick();
        }
        #endregion

        #region Menu Events
        private void digitalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetClockType(ClockType.Digital);
            Ap.Options.ClockType = "Digital";
            Ap.Options.Save();
        }

        private void analogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetClockType(ClockType.Analog);
            Ap.Options.ClockType = "Analog";
            Ap.Options.Save();
        }

        private void doubleDigitalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetClockType(ClockType.DoubleDigital);
            Ap.Options.ClockType = "DoubleDigital";
            Ap.Options.Save();
        }
        #endregion

        #region Analog Clock
        private void pnlBlack_Paint(object sender, PaintEventArgs e)
        {
            float fRadHr = (this.Game.Clock.BlackDateTime.Hour % 12 + this.Game.Clock.BlackDateTime.Minute / 60F) * 30 * PI / 180;
            float fRadMin = (this.Game.Clock.BlackDateTime.Minute) * 6 * PI / 180;
            float fRadSec = (this.Game.Clock.BlackDateTime.Second) * 6 * PI / 180;

            DrawPolygon(this.fHourThickness, this.fHourLength, hrColor, fRadHr, e);
            DrawPolygon(this.fMinThickness, this.fMinLength, minColor, fRadMin, e);
            DrawLine(this.fSecThickness, this.fSecLength, secColor, fRadSec, e);


            for (int i = 0; i < 60; i++)
            {
                if (this.bDraw5MinuteTicks == true && i % 5 == 0) // Draw 5 minute ticks
                {
                    e.Graphics.DrawLine(new Pen(ticksColor, fTicksThickness),
                    fCenterX + (float)(this.fRadius / 1.50F * System.Math.Sin(i * 6 * PI / 180)),
                    fCenterY - (float)(this.fRadius / 1.50F * System.Math.Cos(i * 6 * PI / 180)),
                    fCenterX + (float)(this.fRadius / 1.65F * System.Math.Sin(i * 6 * PI / 180)),
                    fCenterY - (float)(this.fRadius / 1.65F * System.Math.Cos(i * 6 * PI / 180)));
                }
                else if (this.bDraw1MinuteTicks == true) // draw 1 minute ticks
                {
                    e.Graphics.DrawLine(new Pen(ticksColor, fTicksThickness),
                    fCenterX + (float)(this.fRadius / 1.50F * System.Math.Sin(i * 6 * PI / 180)),
                    fCenterY - (float)(this.fRadius / 1.50F * System.Math.Cos(i * 6 * PI / 180)),
                    fCenterX + (float)(this.fRadius / 1.55F * System.Math.Sin(i * 6 * PI / 180)),
                    fCenterY - (float)(this.fRadius / 1.55F * System.Math.Cos(i * 6 * PI / 180)));
                }
            }

            //draw circle at center
            e.Graphics.FillEllipse(new SolidBrush(circleColor), fCenterX - fCenterCircleRadius / 2, fCenterY - fCenterCircleRadius / 2, fCenterCircleRadius,
            fCenterCircleRadius);
        }

        private void pnlBlack_Resize(object sender, EventArgs e)
        {
            ResizeBlack();
        }

        private void ResizeBlack()
        {
            pnlBlack.Width = pnlBlack.Height;
            this.fRadius = pnlBlack.Height / 2;
            this.fCenterX = pnlBlack.ClientSize.Width / 2;
            this.fCenterY = pnlBlack.ClientSize.Height / 2;
            this.fHourLength = (float)pnlBlack.Height / 3 / 1.65F;
            this.fMinLength = (float)pnlBlack.Height / 3 / 1.20F;
            this.fSecLength = (float)pnlBlack.Height / 3 / 1.15F;
            this.fHourThickness = (float)pnlBlack.Height / 100;
            this.fMinThickness = (float)pnlBlack.Height / 150;
            this.fSecThickness = (float)pnlBlack.Height / 200;
            this.fCenterCircleRadius = pnlBlack.Height / 50;
            pnlBlack.Refresh();
        }

        private void pnlWhite_Paint(object sender, PaintEventArgs e)
        {
            float fRadHr = (this.Game.Clock.WhiteDateTime.Hour % 12 + this.Game.Clock.WhiteDateTime.Minute / 60F) * 30 * PI / 180;
            float fRadMin = (this.Game.Clock.WhiteDateTime.Minute) * 6 * PI / 180;
            float fRadSec = (this.Game.Clock.WhiteDateTime.Second) * 6 * PI / 180;

            DrawPolygon(this.fHourThickness, this.fHourLength, hrColor, fRadHr, e);
            DrawPolygon(this.fMinThickness, this.fMinLength, minColor, fRadMin, e);
            DrawLine(this.fSecThickness, this.fSecLength, secColor, fRadSec, e);


            for (int i = 0; i < 60; i++)
            {
                if (this.bDraw5MinuteTicks == true && i % 5 == 0) // Draw 5 minute ticks
                {
                    e.Graphics.DrawLine(new Pen(ticksColor, fTicksThickness),
                    fCenterX + (float)(this.fRadius / 1.50F * System.Math.Sin(i * 6 * PI / 180)),
                    fCenterY - (float)(this.fRadius / 1.50F * System.Math.Cos(i * 6 * PI / 180)),
                    fCenterX + (float)(this.fRadius / 1.65F * System.Math.Sin(i * 6 * PI / 180)),
                    fCenterY - (float)(this.fRadius / 1.65F * System.Math.Cos(i * 6 * PI / 180)));
                }
                else if (this.bDraw1MinuteTicks == true) // draw 1 minute ticks
                {
                    e.Graphics.DrawLine(new Pen(ticksColor, fTicksThickness),
                    fCenterX + (float)(this.fRadius / 1.50F * System.Math.Sin(i * 6 * PI / 180)),
                    fCenterY - (float)(this.fRadius / 1.50F * System.Math.Cos(i * 6 * PI / 180)),
                    fCenterX + (float)(this.fRadius / 1.55F * System.Math.Sin(i * 6 * PI / 180)),
                    fCenterY - (float)(this.fRadius / 1.55F * System.Math.Cos(i * 6 * PI / 180)));
                }
            }

            //draw circle at center
            e.Graphics.FillEllipse(new SolidBrush(circleColor), fCenterX - fCenterCircleRadius / 2, fCenterY - fCenterCircleRadius / 2, fCenterCircleRadius,
            fCenterCircleRadius);
        }

        private void pnlWhite_Resize(object sender, EventArgs e)
        {
            ResizeWhite();
        }

        private void ResizeWhite()
        {
            pnlWhite.Width = pnlWhite.Height;
            this.fRadius = pnlWhite.Height / 2;
            this.fCenterX = pnlWhite.ClientSize.Width / 2;
            this.fCenterY = pnlWhite.ClientSize.Height / 2;
            this.fHourLength = (float)pnlWhite.Height / 3 / 1.65F;
            this.fMinLength = (float)pnlWhite.Height / 3 / 1.20F;
            this.fSecLength = (float)pnlWhite.Height / 3 / 1.15F;
            this.fHourThickness = (float)pnlWhite.Height / 100;
            this.fMinThickness = (float)pnlWhite.Height / 150;
            this.fSecThickness = (float)pnlWhite.Height / 200;
            this.fCenterCircleRadius = pnlWhite.Height / 50;
            pnlWhite.Refresh();
        }

        #region Analog Clock Methods

        private void DrawLine(float fThickness, float fLength, Color color, float fRadians, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(color, fThickness),
            fCenterX - (float)(fLength / 9 * System.Math.Sin(fRadians)),
            fCenterY + (float)(fLength / 9 * System.Math.Cos(fRadians)),
            fCenterX + (float)(fLength * System.Math.Sin(fRadians)),
            fCenterY - (float)(fLength * System.Math.Cos(fRadians)));
        }

        private void DrawPolygon(float fThickness, float fLength, Color color, float fRadians, System.Windows.Forms.PaintEventArgs e)
        {

            PointF A = new PointF((float)(fCenterX + fThickness * 2 * System.Math.Sin(fRadians + PI / 2)),
                (float)(fCenterY - fThickness * 2 * System.Math.Cos(fRadians + PI / 2)));
            PointF B = new PointF((float)(fCenterX + fThickness * 2 * System.Math.Sin(fRadians - PI / 2)),
                (float)(fCenterY - fThickness * 2 * System.Math.Cos(fRadians - PI / 2)));
            PointF C = new PointF((float)(fCenterX + fLength * System.Math.Sin(fRadians)),
                (float)(fCenterY - fLength * System.Math.Cos(fRadians)));
            PointF D = new PointF((float)(fCenterX - fThickness * 4 * System.Math.Sin(fRadians)),
                (float)(fCenterY + fThickness * 4 * System.Math.Cos(fRadians)));
            PointF[] points = { A, D, B, C };
            e.Graphics.FillPolygon(new SolidBrush(color), points);
        }

        #endregion

        #endregion

        #region Clock TimeExpired
        void Clock_TimeExpired(object sender, TimeExpiredEventArgs e)
        {
            SetClockExpired(e.IsWhiteTurn);
        }

        public void TimeExpired(GameResultE result)
        {
            RefreshClock();

            bool isWhiteTurn = (result == GameResultE.WhiteLose); // it will be white's turn if white is lost due to time expire!

            SetClockExpired(isWhiteTurn);
        }

        private void SetClockExpired(bool isWhiteTurn)
        {
            if (isWhiteTurn)
            {
                lblWhiteTime.ForeColor = Color.Red;
                lblWhiteTime.Text = "Time";
            }
            else
            {
                lblBlackTime.ForeColor = Color.Red;
                lblBlackTime.Text = "Time";
            }
        }

        #endregion

        #region Overrrides

        protected override string GetPersistString()
        {
            return Guid;
        }

        #endregion

        private void ClockUc_Load(object sender, EventArgs e)
        {

        }

        int clockMinWidth = 120;
        int clockMaxWidth = 200;
        int clockMinHeight = 20;
        int clockMaxHeight = 35;

        private void SetMinSize()
        {
            lblWhiteTime.MaximumSize = new Size(140, 40);
            lblWhiteCount.MaximumSize = new Size(140, 40);
            lblBlackTime.MaximumSize = new Size(140, 40);
            lblBlackCount.MaximumSize = new Size(140, 40);

            lblWhiteTime.MinimumSize = new Size(110, 10);
            lblWhiteCount.MinimumSize = new Size(110, 10);
            lblBlackTime.MinimumSize = new Size(110, 10);
            lblBlackCount.MinimumSize = new Size(110, 10);

            tlpMain.MaximumSize = new Size(580, 90);
            tlpMain.MinimumSize = new Size(420, 60);

        }

        private void lblWhiteTime_Resize(object sender, EventArgs e)
        {
            //ResizeLabel(lblWhiteTime);
            //ResizeLabel(lblWhiteCount);

            //ResizeLabel(lblWhiteTime);

            //lblWhiteTime.Text = lblWhiteTime.Width + " : " + lblWhiteTime.Height;

            //float fontSize = lblWhiteTime.Width / 8;
            //if (fontSize < 19)
            //{
            //    lblWhiteTime.Font = new Font(lblWhiteTime.Font.FontFamily, fontSize);
            //}

            //lblWhiteTime.Font = AppropriateFont(lblWhiteTime);
        }

        private void ResizeLabel(Label lbl)
        {
            if (lbl.Width < clockMinWidth)
            {
                lbl.Width = clockMinWidth;
            }
            if (lbl.Width > clockMaxWidth)
            {
                lbl.Width = clockMaxWidth;
            }

            if (lbl.Height < clockMinHeight)
            {
                lbl.Height = clockMinHeight;
            }
            if (lbl.Height > clockMaxHeight)
            {
                lbl.Height = clockMaxHeight;
            }
        }

        public static Font AppropriateFont(Label lbl)
        {
            Graphics g = lbl.CreateGraphics();
            float minFontSize = 5;
            float maxFontSize = 20;
            Size layoutSize = lbl.ClientRectangle.Size;
            string s = lbl.Text;
            Font f = lbl.Font;
            SizeF extent;

            if (maxFontSize == minFontSize)
                f = new Font(f.FontFamily, minFontSize, f.Style);

            extent = g.MeasureString(s, f);

            if (maxFontSize <= minFontSize)
                return f;

            float hRatio = layoutSize.Height / extent.Height;
            float wRatio = layoutSize.Width / extent.Width;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            float newSize = f.Size * ratio;

            if (newSize < minFontSize)
                newSize = minFontSize;
            else if (newSize > maxFontSize)
                newSize = maxFontSize;

            f = new Font(f.FontFamily, newSize, f.Style);
            extent = g.MeasureString(s, f);

            return f;
        }

        public static Font AppropriateFont(Control ctrl)
        {
            Graphics g = ctrl.CreateGraphics();
            float minFontSize = 5;
            float maxFontSize = 20;
            Size layoutSize = ctrl.ClientRectangle.Size;
            string s = ctrl.Text;
            Font f = ctrl.Font;
            SizeF extent;

            if (maxFontSize == minFontSize)
                f = new Font(f.FontFamily, minFontSize, f.Style);

            extent = g.MeasureString(s, f);

            if (maxFontSize <= minFontSize)
                return f;

            float hRatio = layoutSize.Height / extent.Height;
            float wRatio = layoutSize.Width / extent.Width;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            float newSize = f.Size * ratio;

            if (newSize < minFontSize)
                newSize = minFontSize;
            else if (newSize > maxFontSize)
                newSize = maxFontSize;

            f = new Font(f.FontFamily, newSize, f.Style);
            extent = g.MeasureString(s, f);

            return f;
        }

        public static Font AppropriateFont(Graphics g, float minFontSize,
            float maxFontSize, Size layoutSize, string s, Font f, out SizeF extent)
        {
            if (maxFontSize == minFontSize)
                f = new Font(f.FontFamily, minFontSize, f.Style);

            extent = g.MeasureString(s, f);

            if (maxFontSize <= minFontSize)
                return f;

            float hRatio = layoutSize.Height / extent.Height;
            float wRatio = layoutSize.Width / extent.Width;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            float newSize = f.Size * ratio;

            if (newSize < minFontSize)
                newSize = minFontSize;
            else if (newSize > maxFontSize)
                newSize = maxFontSize;

            f = new Font(f.FontFamily, newSize, f.Style);
            extent = g.MeasureString(s, f);

            return f;
        }

        private void lblBlackTime_Resize(object sender, EventArgs e)
        {
            //ResizeLabel(lblBlackTime);
            //ResizeLabel(lblBlackCount);
        }

        private void tlpMain_Resize(object sender, EventArgs e)
        {
            ////if (tlpMain.Height > 300)
            ////{
            ////    tlpMain.Height = 300;
            ////}
            ////else if (tlpMain.Height < 200)
            ////{
            ////    tlpMain.Height = 200;
            ////}

            //Font f = AppropriateFont(lblWhiteTime);
            //lblWhiteTime.Font = f;
            //lblWhiteCount.Font = f;
            //lblBlackTime.Font = f;
            //lblBlackCount.Font = f;
        }
    }
}
