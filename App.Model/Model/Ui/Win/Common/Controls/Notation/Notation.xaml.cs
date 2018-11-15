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

namespace WindowsFormsApplication1
{
    public partial class Notation : UserControl
    {
        public int SelectedIndex = 0;
        public string SelectedMove = "";
        public FontWeight fw = FontWeights.Bold;

        public Notation()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
           
        }

        private void rootPreviewMouseDown(object sender, RoutedEventArgs e)
        {
            if (!(e.OriginalSource.GetType() == typeof(TextBlock)))
                return;

            TextBlock target = (TextBlock)e.OriginalSource;

            CheckComments(target);
            
            e.Handled = true;
            wrapPanel.Focus();
        }

        private void CheckComments(TextBlock target)
        {
            int index = wrapPanel.Children.IndexOf(target);
            if (target.Name.Contains("AC") || target.Name.Contains("BR"))
            {
                SelectLastNotation((TextBlock)wrapPanel.Children[index - 1]);
            }
            else if (target.Name.Contains("BC") || target.Name.Contains("BL"))
            {
                SelectLastNotation((TextBlock)wrapPanel.Children[index + 1]);
            }
            else
            {
                SelectLastNotation(target);
            }
        }

        private void SelectLastNotation(TextBlock target)
        {
            if (SelectedIndex >= 0 && SelectedIndex < wrapPanel.Children.Count)
            {
                TextBlock source = (TextBlock)wrapPanel.Children[SelectedIndex];
                source.Background = Brushes.Transparent;
                source.Foreground = Brushes.Black;
            }

            string name = target.Name;
            target.Background = Brushes.Black;
            target.Foreground = Brushes.White;
            
            SelectedMove = target.Text;
            fw = target.FontWeight;
            SelectedIndex = wrapPanel.Children.IndexOf(target);
        }

        //private void rootPreviewKeyDown(object sender, KeyEventArgs e)
        //{
        //    MessageBox.Show(e.Source.ToString());
        //    MessageBox.Show(e.OriginalSource.ToString());

        //    switch (e.Key)
        //    {
        //        case Key.Left:
        //            if (e.OriginalSource is TextBlock)
        //            {
        //                TextBlock source = e.Source as TextBlock;
        //                source.Text = source.Text + "dynamic content";
        //            }
        //            else
        //                MessageBox.Show("Hello");
        //            break;
        //        case Key.Right:

        //            break;
        //    }
        //    e.Handled = true;
        //}

        public void HandleKey(int key)
        {
            MessageBox.Show(key.ToString());
        }

        public void AddMove(int moveNo, string move, bool isVariation)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Name = "textBlock" + moveNo;
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.FontSize = 12;
            

            if ((moveNo % 2) != 0)
            {
                textBlock.Text = moveNo + "." + move + "  ";
            }
            else
            {
                textBlock.Text = move + "  ";
            }

            if (isVariation)
            {
                TextBlock source = (TextBlock)wrapPanel.Children[SelectedIndex];
                source.Background = Brushes.Transparent;
                source.Foreground = Brushes.Black;

                TextBlock textBlockNewLine = new TextBlock();
                textBlockNewLine.Name = "textBlockNLL" + moveNo;
                textBlockNewLine.TextWrapping = TextWrapping.Wrap;
                textBlockNewLine.TextAlignment = TextAlignment.Center;
                textBlockNewLine.Width = 1000;
                textBlockNewLine.Height = 0;
                wrapPanel.Children.Insert(SelectedIndex, textBlockNewLine);

                TextBlock textBlockBraket = new TextBlock();
                textBlockBraket.Name = "textBlockBL" + moveNo;
                textBlockBraket.TextWrapping = TextWrapping.Wrap;
                textBlockBraket.TextAlignment = TextAlignment.Center;
                textBlockBraket.Text = " [ ";
                wrapPanel.Children.Insert(SelectedIndex + 1, textBlockBraket);
                fw = FontWeights.Light;
                textBlock.FontWeight = fw;
                wrapPanel.Children.Insert(SelectedIndex + 2, textBlock);

                textBlockBraket = new TextBlock();
                textBlockBraket.Name = "textBlockBR" + moveNo;
                textBlockBraket.TextWrapping = TextWrapping.Wrap;
                textBlockBraket.TextAlignment = TextAlignment.Center;
                textBlockBraket.Text = " ] ";
                wrapPanel.Children.Insert(SelectedIndex + 3, textBlockBraket);

                textBlockNewLine = new TextBlock();
                textBlockNewLine.Name = "textBlockNLR" + moveNo;
                textBlockNewLine.TextWrapping = TextWrapping.Wrap;
                textBlockNewLine.TextAlignment = TextAlignment.Center;
                textBlockNewLine.Width = 1000;
                textBlockNewLine.Height = 0;
                wrapPanel.Children.Insert(SelectedIndex + 4, textBlockNewLine);
            }
            else
            {
                textBlock.FontWeight = fw;
                if (wrapPanel.Children.Count == 0)
                {
                    wrapPanel.Children.Add(textBlock);
                }
                else
                {
                    wrapPanel.Children.Insert(SelectedIndex + 1, textBlock);
                }
            }
            
            SelectLastNotation(textBlock);
        }

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

        public void MoveNext()
        {
            if (SelectedIndex >= 0 && SelectedIndex < wrapPanel.Children.Count)
            {
                if ((SelectedIndex + 1) == wrapPanel.Children.Count)
                {
                    return;
                }
                TextBlock target = (TextBlock)wrapPanel.Children[SelectedIndex + 1];
                CheckComments(target);
            }
        }

        public void MovePrevious()
        {
            if (SelectedIndex > 0)
            {
                TextBlock target = (TextBlock)wrapPanel.Children[SelectedIndex - 1];
                CheckComments(target);
            }
        }

        public void AddComments(bool isBefore, string comments)
        {
            if (wrapPanel.Children.Count <= 0)
            {
                return;
            }

            TextBlock textBlock = new TextBlock();
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.Foreground = Brushes.Blue;
            textBlock.FontSize = 12;
            
            textBlock.Text = comments + "  ";

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
                int index = SelectedIndex + 1;
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
            if (SelectedIndex >= 0)
            {
                TextBlock[] TbComments = new TextBlock[wrapPanel.Children.Count];
                int Counrer = 0;
                for (int i = 0; i < wrapPanel.Children.Count; i++)
                {
                    TextBlock tb = (TextBlock)wrapPanel.Children[i];
                    if (tb.Name.Contains("AC") || tb.Name.Contains("BC"))
                    {
                        TbComments[Counrer] = tb;
                        Counrer++;
                    }
                    else
                    {
                        tb.Background = Brushes.Transparent;
                        tb.Foreground = Brushes.Black;
                    }
                }

                foreach (TextBlock item in TbComments)
                {
                    wrapPanel.Children.Remove(item);
                }

                SelectedIndex = wrapPanel.Children.Count - 1;
                SelectLastNotation((TextBlock)wrapPanel.Children[SelectedIndex]);
            }
        }
    }
}
