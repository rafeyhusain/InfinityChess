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
using System.Data;

namespace App.Model.Model.Ui.Win.Common.Controls.Notation
{
    /// <summary>
    /// Interaction logic for NotationTextView.xaml
    /// </summary>
    public partial class NotationTextView : UserControl
    {

        public event EventHandler OnMoveSelect;

        public int SelectedIndex = 0;
        public Move SelectedMove;
        public TextBlock SelectedTextBlock;
        public FontWeight fw = FontWeights.Bold;
        public double fs = 13;
        public Moves Moves = null;
        int moveID = 0;

        public NotationTextView()
        {
            InitializeComponent();
        }
        
        public int SelectedMoveID
        {
            get
            {
                return moveID;
            }
        }

        #region Comments
        public void AddComments(bool isBefore, string comments)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.Foreground = Brushes.DarkBlue;
            textBlock.FontSize = fs;
            textBlock.FontWeight = FontWeights.Thin;
            textBlock.Text = comments;

            if (wrapPanel.Children.Count <= 0)
            {
                textBlock.Name = "textBlockSC" + SelectedIndex;
                wrapPanel.Children.Insert(SelectedIndex, textBlock);
                return;
            }

            if (isBefore)
            {
                int index = SelectedIndex - 1;
                if (index > 0)
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
                int index = SelectedIndex + 2;
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
                    if (tb.Name.Contains("AC") || tb.Name.Contains("BC"))
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
            //SelectedMove = this.Game.Moves.GetById(Convert.ToInt32(target.Tag));
            SelectedTextBlock = target;
            return target;          
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

        #region AddMoves
        private TextBlock SelectLastNotationView(TextBlock target)
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

            SelectedTextBlock = target;
            return target;
        }

        public void AddMoves(Moves moves)
        {
            this.Moves = moves;

            for (int i = 0; i < moves.Count; i++)
            {
                AddMove(moves[i], 1);
            }
        }

        private void AddMove(Move move, int idx)
        {
            if (wrapPanel.Children.Count < 4)
            {
                idx = SelectedIndex;
            }
            else
            {
                idx = wrapPanel.Children.Count - 4;
            }

            TextBlock textBlock = new TextBlock();
            textBlock.Name = "textBlock" + move.MoveNo;
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.FontSize = fs;
            textBlock.Text = move.Notation + "  ";
            textBlock.Tag = move.Id;
            textBlock.FontWeight = fw;
            if (wrapPanel.Children.Count == 0) // if notation window is empty
            {
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
                wrapPanel.Children.Insert(idx + 4, textBlock); //simple move means after first move
            }

            SelectLastNotationView(textBlock);

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
            textBlock.Text = move.MoveTime + "  ";
            wrapPanel.Children.Insert(SelectedIndex + 2, textBlock);

            if (!string.IsNullOrEmpty(move.ExpectedMove))
            {
                AddComments(false, "(" + move.ExpectedMove + ") ");
            }
            else
            {
                AddComments(false, " ");
            }

            SelectedMove = move;
        }


        #endregion
        
        private void wrapPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!(e.OriginalSource.GetType() == typeof(TextBlock)))
            {
                return;
            }

            Move move = null;

            TextBlock target = (TextBlock)e.OriginalSource;
            target = CheckComments(target);
            
            if (target != null && target.Tag != null && !string.IsNullOrEmpty(target.Tag.ToString()))
            {
                if (Moves.Count > 0)
                {
                    DataView dv = Moves.DataTable.DefaultView;

                    dv.RowFilter = Moves.Id + "=" + target.Tag.ToString();

                    if (dv.ToTable().Rows.Count > 0)
                    {
                        move = new Move(dv.ToTable().Rows[0]);
                        moveID = move.Id;
                        if (OnMoveSelect != null)
                        {
                            OnMoveSelect(this, EventArgs.Empty);
                        }
                    }
                }
            }

            e.Handled = true;
            wrapPanel.Focus();
        }
    }
}
