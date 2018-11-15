using System;
using App.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using InfinitySettings.EngineManager;
using InfinitySettings.UCIManager;
using System.Linq;
using App.Win;
using WeifenLuo.WinFormsUI.Docking;

namespace InfinityChess
{
    public partial class AnalysisUc
    {
      
        #region Helper Methods

        public void GoInfinite(string fen, string moves)
        {
            if (EngineAnalysis == null)
            {
                return;
            }

            if (EngineAnalysis.UciEngine != null)
            {
                EngineAnalysis.UciEngine.SendPositionGoInfinite(fen, moves);
            }

            btnGo.Text = Stop;
        }

        public bool IsValidAnalysisNumber(string analysisInfo)
        {
            string[] analysis = analysisInfo.Split('.');

            if (this.UCIEngine.IsKibitzer)
            {
                if (analysis.GetValue(0).ToString() == this.Game.NextMoveNo.ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (this.Game.Flags.IsInfiniteAnalysisOn)
            {
                if (this.Game.Flags.IsFirtMove)
                {
                    return true;
                }

                if ((this.Game.CurrentMove.IsWhite && analysisInfo.Contains("...")) || (!this.Game.CurrentMove.IsWhite && !analysisInfo.Contains("...")))
                {
                    if (analysis.GetValue(0).ToString() == this.Game.NextMoveNo.ToString())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }            
            else
            {
                return true;
            }
        }

        public string RestrictUptoTwoDecimalPoint(string points)
        {
            if (!string.IsNullOrEmpty(points))
            {
                if (points.Contains('.'))
                {
                    if (points.Length - points.IndexOf('.') == 3)
                    {
                        return points.Substring(0, points.Length - 1) + "0)";
                    }
                    else
                    {
                        return points;
                    }
                }
            }
            return string.Empty;
        }               

        #endregion

        #region Display Evaluations

        #region Debug Mode 
        // use only while debugging, otherwise use next method (without debug)
        // as it uses "Control.InokdeRequired" which causes performance penalty (memory leaks).
        void EngineAnalysis_EvaluationsReceived_Debug(object sender, AnalysisEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(e.Depth))
                {
                    //lblDepth.Text = "Depth=" + e.Depth;
                    SetLabelText(lblDepth, "Depth=" + e.Depth);
                }

                if (!string.IsNullOrEmpty(e.Rate))
                {
                    //lblRate.Text = e.Rate;
                    SetLabelText(lblRate, e.Rate);
                }
                #region Add Evaluation Item 
                if (!string.IsNullOrEmpty(e.EMoves))
                {
                    if (IsValidAnalysisNumber(e.EMoves))
                    {
                        if (!string.IsNullOrEmpty(this.Game.PonderMove) && this.Game.Flags.IsInfiniteAnalysisOff)
                        {
                            //lblExpectedMove.Text = e.ExpectedMove;
                            SetLabelText(lblExpectedMove, e.ExpectedMove);
                        }

                        //lblPoints.Text = e.Points;
                        SetLabelText(lblPoints, e.Points);

                        if (e.IsLowerBound)
                        {
                            //pbEngineScore.Image = global::InfinityChess.Properties.Resources.Red;
                            SetPicture(pbEngineScore, global::InfinityChess.Properties.Resources.Red);
                        }
                        else if (e.IsUpperBound)
                        {
                            //pbEngineScore.Image = global::InfinityChess.Properties.Resources.Green;
                            SetPicture(pbEngineScore, global::InfinityChess.Properties.Resources.Green);
                        }
                        else
                        {
                            //pbEngineScore.Image = global::InfinityChess.Properties.Resources.orange;
                            SetPicture(pbEngineScore, global::InfinityChess.Properties.Resources.orange);
                        }

                        AddEvaluationItem("1", e.EMoves);
                        AddEvaluationItem("2", e.EStatistics);
                    }
                }
                #endregion

                if (!string.IsNullOrEmpty(e.MoveDepth))
                {
                    //lblMoveDepth.Text = e.MoveDepth;
                    SetLabelText(lblMoveDepth, e.MoveDepth);
                }

                if (string.IsNullOrEmpty(lblEngine.Text.Trim()) && this.Game.Flags.IsPieceMovedSuccessfully)
                {
                    lblEngine.Text = this.EngineAnalysis.UciEngine.EngineName;
                }
            }
            catch(Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
            }
        }
        
        #endregion

        #region Release Mode 
        
        void EngineAnalysis_EvaluationsReceived(object sender, AnalysisEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(e.Depth))
                {
                    lblDepth.Text = "Depth=" + e.Depth;
                    //SetLabelText(lblDepth, "Depth=" + e.Depth);
                }

                if (!string.IsNullOrEmpty(e.Rate))
                {
                    lblRate.Text = e.Rate;
                    //SetLabelText(lblRate, e.Rate);
                }
                #region Add Evaluation Item
                if (!string.IsNullOrEmpty(e.EMoves))
                {
                    if (IsValidAnalysisNumber(e.EMoves))
                    {
                        if (!string.IsNullOrEmpty(this.Game.PonderMove) && this.Game.Flags.IsInfiniteAnalysisOff)
                        {
                            lblExpectedMove.Text = e.ExpectedMove;
                            //SetLabelText(lblExpectedMove, e.ExpectedMove);
                        }

                        lblPoints.Text = e.Points;
                        //SetLabelText(lblPoints, e.Points);

                        if (e.IsLowerBound)
                        {
                            pbEngineScore.Image = BitmapRed;
                            //SetPicture(pbEngineScore, global::InfinityChess.Properties.Resources.Red);
                        }
                        else if (e.IsUpperBound)
                        {
                            pbEngineScore.Image = BitmapGreen;
                            //SetPicture(pbEngineScore, global::InfinityChess.Properties.Resources.Green);
                        }
                        else
                        {
                            pbEngineScore.Image = BitmapOrange;
                            //SetPicture(pbEngineScore, global::InfinityChess.Properties.Resources.orange);
                        }

                        AddEvaluationItem("1", e.EMoves);
                        AddEvaluationItem("2", e.EStatistics);
                    }
                }
                #endregion

                if (!string.IsNullOrEmpty(e.MoveDepth))
                {
                    lblMoveDepth.Text = e.MoveDepth;
                    //SetLabelText(lblMoveDepth, e.MoveDepth);
                }

                if (string.IsNullOrEmpty(lblEngine.Text.Trim()) && this.Game.Flags.IsPieceMovedSuccessfully)
                {
                    lblEngine.Text = this.EngineAnalysis.UciEngine.EngineName;
                }
            }
            catch(Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
            }
        }

        #endregion

        private void AddEvaluationItem(string itemType, string notations)
        {
            ListViewItem item = new ListViewItem(notations);
            switch (itemType)
            {
                case "1":
                    item.ForeColor = Color.Black;
                    item.Font = new Font(item.Font, FontStyle.Bold);
                    break;
                case "2":
                    item.ForeColor = Color.Gray;
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    break;
                case "3":
                    item.ForeColor = Color.Black;
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    break;
            }
            //lvNotations.Items.Add(item);
            UpdateEvaluations(lvNotations, item, false);
        }

        void EngineAnalysis_ClearAnalysis(object sender, EventArgs e)
        {
            ClearAnalysisItems();
        }                

        #endregion

        #region Clear Evaluations
        void Game_AfterNewGame(object sender, EventArgs e)
        {
            ClearLabels();
            ClearAnalysisItems();
        }
        #endregion

        #region Thread-safe Methods 

        private void SetLabelText(Label lbl, string text)
        {
            if (lbl.InvokeRequired)
            {
                lbl.BeginInvoke(new MethodInvoker(delegate() { SetLabelText(lbl, text); }));
            }
            else
            {
                lbl.Text = text;
            }
        }

        private void SetPicture(PictureBox pic, Image img)
        {
            if (pic.InvokeRequired)
            {
                pic.BeginInvoke(new MethodInvoker(delegate() { SetPicture(pic, img); }));
            }
            else
            {
                pic.Image = img;
            }
        }

        private void UpdateEvaluations(ListView lst, ListViewItem item, bool doClear)
        {
            if (lst.InvokeRequired)
            {
                lst.BeginInvoke(new MethodInvoker(delegate() { UpdateEvaluations(lst, item, doClear); }));
            }
            else
            {
                if (doClear)
                {
                    lvNotations.Items.Clear();
                }
                else
                {
                    lst.Items.Add(item);
                    item.EnsureVisible();
                }
            }
        }
        
        #endregion
    }
}
