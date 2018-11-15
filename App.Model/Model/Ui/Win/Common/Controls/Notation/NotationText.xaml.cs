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

namespace App.Win
{
    public partial class NotationText : UserControl
    {
        #region DataMember

        public Game Game = null;
        public int SelectedIndex = 0;
        public Move SelectedMove;
        public TextBlock SelectedTextBlock;
        public FontWeight fw = FontWeights.Bold;
        public double fs = 13;
        #endregion

        #region Ctor
        public NotationText()
        {
            InitializeComponent();
            SV.ScrollToBottom();
        }
        #endregion

        #region Events
        private void rootPreviewMouseDown(object sender, RoutedEventArgs e)
        {
            if (!(e.OriginalSource.GetType() == typeof(TextBlock)))
            {
                return;
            }

            TextBlock target = (TextBlock)e.OriginalSource;
            target = CheckComments(target);

            if (target != null && target.Tag != null && !string.IsNullOrEmpty(target.Tag.ToString()))
            {
                Move m = this.Game.Moves.GetById(UData.ToInt32(target.Tag));
                if (m != null)
                {
                    this.Game.MoveTo(m);
                }
            }

            e.Handled = true;
            wrapPanel.Focus();
        }

        private void rootPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (this.Game.Flags.IsOnline || this.Game.GameMode == GameMode.EngineVsEngine)
            {
                return;
            }

            switch (e.Key)
            {
                case Key.Left:
                    MovePrevious();
                    break;
                case Key.Right:
                    MoveNext();
                    break;
                case Key.Space:
                    this.Game.SpaceBarCounter++;
                    break;
                case Key.M:
                    if (Keyboard.Modifiers == ModifierKeys.Control)
                    {
                        this.Game.NewGame(GameMode.HumanVsHuman, GameType.NoClock);
                    }
                    break;
                //case Key.N:
                //    if (Keyboard.Modifiers == ModifierKeys.Control)
                //    {
                //        this.Game.NewGame(GameMode.HumanVsHuman, GameType.NoClock);
                //    }
                //    break;
            }
            e.Handled = true;
            wrapPanel.Focus();
        }

        public void HandleKey(int key)
        {
            MessageBox.Show(key.ToString());
        }
        #endregion

        #region Helper

        #region Comments
        public void AddComments(Nullable<bool> isBefore, string comments)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.Foreground = Brushes.DarkBlue;
            textBlock.FontSize = fs;
            textBlock.FontWeight = FontWeights.Thin;
            textBlock.Text = comments;
            textBlock.Padding = new Thickness(0, 0, 5, 0);

            if (wrapPanel.Children.Count <= 0)
            {
                textBlock.Name = "textBlockSC" + SelectedIndex;
                wrapPanel.Children.Insert(SelectedIndex, textBlock);
                return;
            }
            else if (wrapPanel.Children.Count == 1)
            {
                TextBlock target = (TextBlock)wrapPanel.Children[0];
                target.Text = comments;
                return;
            }

            if (isBefore == null)
            {
                int index = SelectedIndex + 4;
                if (index < wrapPanel.Children.Count)
                {
                    TextBlock target = (TextBlock)wrapPanel.Children[index];

                    if (target.Name.Contains("AC"))
                    {
                        target.Text = textBlock.Text;
                    }
                    else
                    {
                        textBlock.Name = "textBlockAC" + SelectedIndex;
                        wrapPanel.Children.Insert(index, textBlock);
                    }
                }
                else
                {
                    textBlock.Name = "textBlockAC" + SelectedIndex;
                    wrapPanel.Children.Insert(index, textBlock);
                }
            }
            

            else if ((bool)isBefore)
            {
                int index = SelectedIndex - 1;
                if (index >= 0)
                {
                    TextBlock target = (TextBlock)wrapPanel.Children[index];

                    if (target.Name.Contains("BC"))
                    {
                        target.Text = textBlock.Text;
                    }
                    else
                    {
                        textBlock.Name = "textBlockBC" + SelectedIndex;
                        wrapPanel.Children.Insert(SelectedIndex, textBlock);
                        SelectedIndex++;
                    }
                }
                else
                {
                    textBlock.Name = "textBlockBC" + SelectedIndex;
                    wrapPanel.Children.Insert(SelectedIndex, textBlock);
                    SelectedIndex++;
                }
            }
            else
            {
                int index = SelectedIndex + 3;
                if (index < wrapPanel.Children.Count)
                {
                    TextBlock target = (TextBlock)wrapPanel.Children[index];

                    if (target.Name.Contains("AC"))
                    {
                            target.Text = textBlock.Text;
                    }
                    else
                    {
                        textBlock.Name = "textBlockAC" + SelectedIndex;
                        wrapPanel.Children.Insert(index, textBlock);
                    }
                }
                else
                {
                    textBlock.Name = "textBlockAC" + SelectedIndex;
                    wrapPanel.Children.Insert(index, textBlock);
                }
            }
        }

        public void RemoveComments()
        {
            if (wrapPanel.Children.Count <= 0)
            {
                return;
            }
            TextBlock tb = (TextBlock)wrapPanel.Children[SelectedIndex];
            //tb.Background = Brushes.Transparent;
            //tb.Foreground = Brushes.Black;

            if (SelectedIndex >= 0)
            {
                //TextBlock[] TbComments = new TextBlock[wrapPanel.Children.Count];
                //int Counter = 0;
                for (int i = 0; i < wrapPanel.Children.Count; i++)
                {
                    tb = (TextBlock)wrapPanel.Children[i];
                    if (tb.Name.Contains("AC") || tb.Name.Contains("BC") || tb.Name.Contains("SC"))
                    {
                        //TbComments[Counter] = tb;
                        tb.Text = " ";
                        //Counter++;
                    }
                }
                //SelectedIndex = wrapPanel.Children.Count - 2;
                //SelectLastNotation((TextBlock)wrapPanel.Children[SelectedIndex]);
            }
        }

        public void RemoveMoveComments()
        {
            if (wrapPanel.Children.Count <= 1)
            {
                return;
            }
            TextBlock tb = (TextBlock)wrapPanel.Children[SelectedIndex];
            TextBlock tbBefore = (TextBlock)wrapPanel.Children[SelectedIndex-1];
            TextBlock tbAfter = (TextBlock)wrapPanel.Children[SelectedIndex+3];
            tbBefore.Text = " ";
            tbAfter.Text = " ";            
        }
        #endregion

        #region Move Selection
        private TextBlock CheckComments(TextBlock target)
        {
            int index = wrapPanel.Children.IndexOf(target);

            if (target.Name.Contains("SC"))
            {
                return null;
            }
            else if (target.Name.Contains("Time") || target.Name.Contains("Eval") || target.Name.Contains("NLR"))
            {
                TextBlock tb = (TextBlock)wrapPanel.Children[index - 1];
                return SelectLastNotation(tb);
            }
            else if (target.Name.Contains("AC") || target.Name.Contains("BR"))
            {
                TextBlock tb = (TextBlock)wrapPanel.Children[index - 2];
                return SelectLastNotation(tb);
            }
            else if (target.Name.Contains("BC") || target.Name.Contains("BL") || target.Name.Contains("NLL"))
            {
                TextBlock tb = (TextBlock)wrapPanel.Children[index + 1];
                return SelectLastNotation(tb);
            }
            else
            {
                return SelectLastNotation(target);
            }
        }

        public void MoveNext()
        {
            if (wrapPanel.Children.Count > 0)
            {
                TextBlock target = (TextBlock)wrapPanel.Children[SelectedIndex];
                if (!string.IsNullOrEmpty(target.Tag.ToString()))
                {
                    Move m = this.Game.Moves.GetById(UData.ToInt32(target.Tag));
                    if (m != null)
                    {
                        this.Game.MoveTo(MoveToE.Next);
                    }
                }
            }
        }

        public void MovePrevious()
        {
            if (wrapPanel.Children.Count > 0)
            {
                TextBlock target = (TextBlock)wrapPanel.Children[SelectedIndex];
                if (!string.IsNullOrEmpty(target.Tag.ToString()))
                {
                    Move m = this.Game.Moves.GetById(UData.ToInt32(target.Tag));
                    if (m != null)
                    {
                        this.Game.MoveTo(MoveToE.Previous);
                    }
                }
            }
        }

        private TextBlock SelectLastNotation(TextBlock target)
        {
            if (target.Name.Contains("Result"))
            {
                return null;
            }

            if (target.Name.Contains("Eval"))
            {
                int index = wrapPanel.Children.IndexOf(target);
                TextBlock tb = (TextBlock)wrapPanel.Children[index - 1];
                return SelectLastNotation(tb);
            }

            if (SelectedIndex >= 0 && SelectedIndex < wrapPanel.Children.Count)
            {
                TextBlock source = (TextBlock)wrapPanel.Children[SelectedIndex];
                if (!source.Name.Contains("SC") && !source.Name.Contains("Time"))
                {
                    source.Foreground = Brushes.Black;
                }
                source.Background = Brushes.Transparent;
            }

            if (!target.Name.Contains("Time"))
            {
                target.Foreground = Brushes.White;
                target.Background = Brushes.Black;
            }

            
            fw = target.FontWeight;
            fs = target.FontSize;
            SelectedIndex = wrapPanel.Children.IndexOf(target);

            if (target.Tag == null)
            {
                target = CheckComments(target);
            }
            SelectedMove = this.Game.Moves.GetById(Convert.ToInt32(target.Tag));
            SelectedTextBlock = target;
            return target;

            //else
            //{
            //if (!string.IsNullOrEmpty(target.Tag.ToString()))
            //{
            //    Move m = this.Game.Moves.GetById(UData.ToInt32(target.Tag));
            //    if (m != null)
            //    {
            //        this.Game.MoveTo(m);
            //    }
            //}
            //}
        }

        public void SetSelection(Move move)
        {
            if (wrapPanel != null && wrapPanel.Children.Count > 0)
            {
                //TextBlock[] TbComments = new TextBlock[wrapPanel.Children.Count];
                TextBlock tb;// = (TextBlock)wrapPanel.Children[0];
                int idx = SelectedIndex;
                for (int i = 0; i < wrapPanel.Children.Count; i++)
                {
                    tb = (TextBlock)wrapPanel.Children[i];
                    if (tb.Tag != null && (int)tb.Tag == move.Id)
                    {
                        idx = i;
                        SelectLastNotation(tb);
                        break;
                    }
                }
            }
            //if (idx != SelectedIndex)
            //{
            //    SelectLastNotation(tb);
            //}
        } 
        #endregion

        #region Move Addition
        public void AddMove(Move move, int idx)
        {
            if (this.Game.GameMode == GameMode.Kibitzer)
            {
                //if (this.Game.Flags.IsGameFinished || this.Game.Flags.IsAnalysisAllowed)
                if (this.Game.Flags.IsGameFinished || this.Game.Flags.IsAnalysisAllowed || wrapPanel.Children.Count < 4)
                {
                    idx = SelectedIndex;
                }
                else
                {
                    idx = wrapPanel.Children.Count - 4;
                }
            }
            
            TextBlock textBlock = new TextBlock();
            textBlock.Name = "textBlock" + move.MoveNo;
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.FontSize = fs;
            textBlock.Text = move.Notation + "  ";
            textBlock.Tag = move.Id;
            textBlock.FontWeight = fw;
            if (move.Flags.IsBook)
            {
                textBlock.Foreground = Brushes.Green;
            }
         
            if (wrapPanel.Children.Count == 0) // if notation window is empty
            {
                //wrapPanel.Children.Add(textBlock);
                wrapPanel.Children.Insert(idx, textBlock);
            }
            else if (wrapPanel.Children.Count == 1) // if comments added on initial board position
            {
                wrapPanel.Children.Insert(idx + 1, textBlock);
            }
            else if (wrapPanel.Children.Count == 2) // if move adding on overwrite after game finish
            {
                wrapPanel.Children.Insert(idx, textBlock);
            }
            else
            {
                if (wrapPanel.Children.Count == idx + 5)
                {
                    wrapPanel.Children.Insert(idx + 5, textBlock); //simple move means after first move
                }
                else
                {
                    wrapPanel.Children.Insert(idx + 4, textBlock);
                }
            }

            SelectLastNotation(textBlock);
                        
            textBlock = new TextBlock();
            textBlock.Name = "textBlockEval" + move.MoveNo;
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.FontSize = fs;
            textBlock.Foreground = Brushes.MediumBlue;
            if (!string.IsNullOrEmpty(move.Eval))
            {
                textBlock.Text = move.Eval + "  ";
            }
            else
            {
                textBlock.Text = " ";
            }
            wrapPanel.Children.Insert(SelectedIndex + 1, textBlock);

            textBlock = new TextBlock();
            textBlock.Name = "textBlockTime" + move.MoveNo;
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.FontSize = fs;
            textBlock.Foreground = Brushes.DeepPink;
            if (this.Game.Flags.IsClockedGame)
            {
                textBlock.Text = move.MoveTime + "  ";
            }
            else
            {
                textBlock.Text = " ";
            }

              
            wrapPanel.Children.Insert(SelectedIndex + 2, textBlock);

            if (!string.IsNullOrEmpty(move.ExpectedMove))
            {
                AddComments(false, "(" + move.ExpectedMove + ") ");
            }
            else
            {
                AddComments(false, " ");
            }

            if (Ap.Options.ShowComments)
            {
                if (move.MoveComments.HasCommentsBefore)
                {
                    AddComments(true, move.MoveComments[MoveCommentTypeE.Before].ToString());
                }
                else
                {
                    AddComments(true, " ");
                }
                if (move.MoveComments.HasCommentsAfter)
                {
                    AddComments(false, move.MoveComments[MoveCommentTypeE.After].ToString());
                }
                else
                {
                    AddComments(false, " ");
                }
            }

            if (Ap.Options.ShowDisconnectionLog)
            {
                AddComments(null, move.MoveComments[MoveCommentTypeE.MoveLog].ToString());
            }
            else
            {
                AddComments(null, string.Empty);
            }
             SelectedMove = move;
        }

        public void AddVariation(Move move)
        {
            Move mv = this.Game.Moves.GetById(move.Pid);

            if (mv != null)
            {
                SetSelection(mv);
            }

            TextBlock source = (TextBlock)wrapPanel.Children[SelectedIndex];
            source.Background = Brushes.Transparent;
            source.Foreground = Brushes.Black;

            fs = 13;
            fw = FontWeights.Thin;
            int i = 4;

            TextBlock textBlockNewLine = new TextBlock();
            textBlockNewLine.Name = "textBlockNLL" + move.MoveNo;
            textBlockNewLine.TextWrapping = TextWrapping.Wrap;
            textBlockNewLine.TextAlignment = TextAlignment.Center;
            textBlockNewLine.Width = 1000;
            textBlockNewLine.Height = 0;
            wrapPanel.Children.Insert(SelectedIndex + i, textBlockNewLine);
            i++;

            TextBlock textBlockBraket = new TextBlock();
            textBlockBraket.Name = "textBlockBL" + move.MoveNo;
            textBlockBraket.TextWrapping = TextWrapping.Wrap;
            textBlockBraket.TextAlignment = TextAlignment.Center;
            textBlockBraket.FontSize = fs;
            textBlockBraket.FontWeight = fw;
            textBlockBraket.Text = "[ ";
            wrapPanel.Children.Insert(SelectedIndex + i, textBlockBraket);
            i++;

            TextBlock textBlock = new TextBlock();
            textBlock.Name = "textBlock" + move.MoveNo;
            textBlock.Tag = move.Id;
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.FontSize = fs;
            textBlock.FontWeight = fw;
            textBlock.Text = move.Notation + "  ";
            wrapPanel.Children.Insert(SelectedIndex + i, textBlock);
            i++;

            TextBlock textBlockEval = new TextBlock();
            textBlockEval.Name = "textBlockEval" + move.MoveNo;
            textBlockEval.TextWrapping = TextWrapping.Wrap;
            textBlockEval.TextAlignment = TextAlignment.Center;
            textBlockEval.FontSize = fs;
            textBlockEval.FontWeight = fw;
            textBlockEval.Foreground = Brushes.MediumBlue;
            if (!string.IsNullOrEmpty(move.Eval))
            {
                textBlockEval.Text = move.Eval + "  ";
            }
            else
            {
                textBlockEval.Text = "  ";
            }
            wrapPanel.Children.Insert(SelectedIndex + i, textBlockEval);
            i++;

            TextBlock textBlockTime = new TextBlock();
            textBlockTime.Name = "textBlockTime" + move.MoveNo;
            textBlockTime.TextWrapping = TextWrapping.Wrap;
            textBlockTime.TextAlignment = TextAlignment.Center;
            textBlockTime.FontSize = fs;
            textBlockTime.FontWeight = fw;
            textBlockTime.Foreground = Brushes.DeepPink;
            if (this.Game.Flags.IsClockedGame)
            {
                textBlockTime.Text = move.MoveTime + "  ";
            }
            else
            {
                textBlockTime.Text = "  ";
            }
            wrapPanel.Children.Insert(SelectedIndex + i, textBlockTime);
            i++;

            SelectLastNotation(textBlock);

            if (!string.IsNullOrEmpty(move.ExpectedMove))
            {
                AddComments(false, "(" + move.ExpectedMove + ")");
            }
            else
            {
                AddComments(false, " ");
            }

            textBlockBraket = new TextBlock();
            textBlockBraket.Name = "textBlockBR" + move.MoveNo;
            textBlockBraket.TextWrapping = TextWrapping.Wrap;
            textBlockBraket.TextAlignment = TextAlignment.Center;
            textBlockBraket.FontSize = fs;
            textBlockBraket.FontWeight = fw;
            textBlockBraket.Text = " ]";
            wrapPanel.Children.Insert(SelectedIndex + 4, textBlockBraket);

            textBlockNewLine = new TextBlock();
            textBlockNewLine.Name = "textBlockNLR" + move.MoveNo;
            textBlockNewLine.TextWrapping = TextWrapping.Wrap;
            textBlockNewLine.TextAlignment = TextAlignment.Center;
            textBlockNewLine.Width = 1000;
            textBlockNewLine.Height = 0;
            wrapPanel.Children.Insert(SelectedIndex + 5, textBlockNewLine);

            SelectedMove = move;

        }

        public void AddNewMainLine(Move move)
        {
            Move mv;
            TextBlock textBlockNewLine;
            TextBlock textBlockBraket;
            if (move.Pid != -1)
            {
                mv = this.Game.Moves.GetById(move.Pid);

                SetSelection(mv);

                textBlockNewLine = new TextBlock();
                textBlockNewLine.Name = "textBlockNLL" + move.MoveNo;
                textBlockNewLine.TextWrapping = TextWrapping.Wrap;
                textBlockNewLine.TextAlignment = TextAlignment.Center;
                textBlockNewLine.Width = 1000;
                textBlockNewLine.Height = 0;
                wrapPanel.Children.Insert(SelectedIndex + 4, textBlockNewLine);

                textBlockBraket = new TextBlock();
                textBlockBraket.Name = "textBlockBL" + move.MoveNo;
                textBlockBraket.TextWrapping = TextWrapping.Wrap;
                textBlockBraket.TextAlignment = TextAlignment.Center;
                textBlockBraket.FontSize = fs;
                textBlockBraket.FontWeight = FontWeights.Thin;
                textBlockBraket.Text = "[ ";
                wrapPanel.Children.Insert(SelectedIndex + 5, textBlockBraket);
            }
            else
            {
                AddMove(move, 0 - 4);
                
                textBlockNewLine = new TextBlock();
                textBlockNewLine.Name = "textBlockNLL" + move.MoveNo;
                textBlockNewLine.TextWrapping = TextWrapping.Wrap;
                textBlockNewLine.TextAlignment = TextAlignment.Center;
                textBlockNewLine.Width = 1000;
                textBlockNewLine.Height = 0;
                wrapPanel.Children.Insert(SelectedIndex + 4, textBlockNewLine);

                textBlockBraket = new TextBlock();
                textBlockBraket.Name = "textBlockBL" + move.MoveNo;
                textBlockBraket.TextWrapping = TextWrapping.Wrap;
                textBlockBraket.TextAlignment = TextAlignment.Center;
                textBlockBraket.FontSize = fs;
                textBlockBraket.FontWeight = FontWeights.Thin;
                textBlockBraket.Text = "[ ";
                wrapPanel.Children.Insert(SelectedIndex + 5, textBlockBraket);

                int index = wrapPanel.Children.IndexOf(SelectedTextBlock);
                TextBlock tb = (TextBlock)wrapPanel.Children[index + 7];
                SelectLastNotation(tb);

                //SetSelection(mv);
                SelectedTextBlock.FontWeight = FontWeights.Thin;
                mv = SelectedMove;
            }

            OldMainLine(mv);

            textBlockBraket = new TextBlock();
            textBlockBraket.Name = "textBlockBR" + move.MoveNo;
            textBlockBraket.TextWrapping = TextWrapping.Wrap;
            textBlockBraket.TextAlignment = TextAlignment.Center;
            textBlockBraket.FontSize = fs;
            textBlockBraket.FontWeight = FontWeights.Thin;
            textBlockBraket.Text = " ]";
            wrapPanel.Children.Insert(SelectedIndex + 4, textBlockBraket);

            textBlockNewLine = new TextBlock();
            textBlockNewLine.Name = "textBlockNLR" + move.MoveNo;
            textBlockNewLine.TextWrapping = TextWrapping.Wrap;
            textBlockNewLine.TextAlignment = TextAlignment.Center;
            textBlockNewLine.Width = 1000;
            textBlockNewLine.Height = 0;
            wrapPanel.Children.Insert(SelectedIndex + 5, textBlockNewLine);

            if (move.Pid != -1)
            {
                AddMove(move, SelectedIndex + 2);
            }
            else
            {
                SetSelection(move);
            }
        }

        private void OldMainLine(Move mv)
        {
            Moves movs = this.Game.Moves.GetChildren(mv);

            for (int i = 0; i < movs.Count; i++)
            {
                Move m = movs[i];
                SetSelection(m);
                SelectedTextBlock.FontWeight = FontWeights.Thin;
                OldMainLine(movs[i]);
            }
        }
        #endregion

        #region Refresh Notation
        public void ClearNotationText(int idx, bool isOverwrite)
        {
            if (isOverwrite && this.Game.Flags.IsGameFinished)
            {
                wrapPanel.Children.RemoveRange(idx, wrapPanel.Children.Count - 2);
            }
            else
            {
                wrapPanel.Children.RemoveRange(idx, wrapPanel.Children.Count);
            }
            SelectedIndex = idx;
            SelectedMove = null;
            fw = FontWeights.Bold;
            fs = 13;
        }

        public void ToggleEnableDisable(bool status)
        {
            wrapPanel.IsEnabled = status;
        }
        #endregion

        #region Result
        public void Result(string result)
        {
            TextBlock textBlockNewLine = new TextBlock();
            textBlockNewLine.Name = "textBlockNLR";
            textBlockNewLine.TextWrapping = TextWrapping.Wrap;
            textBlockNewLine.TextAlignment = TextAlignment.Center;
            textBlockNewLine.Width = 1000;
            textBlockNewLine.Height = 0;
            wrapPanel.Children.Insert(wrapPanel.Children.Count, textBlockNewLine);

            TextBlock textBlock = new TextBlock();
            textBlock.Name = "textBlockResult";
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.FontSize = 13;
            textBlock.FontWeight = FontWeights.Medium;
            textBlock.Text = result;
            wrapPanel.Children.Insert(wrapPanel.Children.Count, textBlock);
        }  
        #endregion

        #region Delete Move

        public void RemoveMove()
        {
            if (SelectedIndex >= 0)
            {
                wrapPanel.Children.RemoveAt(SelectedIndex);
                if (wrapPanel.Children.Count == 0)
                {
                    SelectedIndex = -1;
                }
                else
                {
                    if (SelectedIndex > 0)
                    {
                        SelectedIndex--;
                        SelectLastNotation((TextBlock)wrapPanel.Children[SelectedIndex]);
                    }
                }
            }
        }
        #endregion

        #endregion
    }
}
