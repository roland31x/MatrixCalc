using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MatrixCalc
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        int ElementsOK = 0;
        int boxplacetop;
        public Window1()
        {
            InitializeComponent();
            for (int i = 0; i < App.MatrixVal; i++)
            {
                ColumnDefinition f = new ColumnDefinition();
                f.Width = new GridLength((MainGrid.Width - 15) / App.MatrixVal);
                MainGrid.ColumnDefinitions.Add(f);
                RowDefinition r = new RowDefinition();
                r.Height = new GridLength((MainGrid.Height - 15) / App.MatrixVal);
                MainGrid.RowDefinitions.Add(r);
            }
            for (int i = 0; i < App.MatrixVal; i++)
            {
                for (int j = 0; j < App.MatrixVal; j++)
                {
                    TextBox t = new TextBox
                    {
                        Text = $"a({i + 1},{j + 1})",
                        Width = MainGrid.Width / App.MatrixVal - (100 / App.MatrixVal),
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontSize = 144 / App.MatrixVal,
                        TextAlignment = TextAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        Height = (MainGrid.Height) / App.MatrixVal - (100 / App.MatrixVal),
                        BorderBrush = new SolidColorBrush(Colors.Black),
                        Background = new SolidColorBrush(Colors.LightGray),
                        Tag = (i + 1) * 10 + j + 1 ,
                    };
                    t.GotFocus += TextBox_PreviewMouseDown;
                    MainGrid.Children.Add(t);
                    Grid.SetRow(t, i);
                    Grid.SetColumn(t, j);
                }
            }

        }
        private void TextBox_PreviewMouseDown(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null)
            {
                if(!int.TryParse(tb.Text, out int i))
                {
                    tb.Text = "";
                }              
            }
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.Matrix = new int[App.MatrixVal + 1, App.MatrixVal + 1];
                foreach (TextBox t in MainGrid.Children)
                    {
                        int i = Convert.ToInt16(t.Tag);
                        App.Matrix[i / 10, i % 10] = int.Parse(t.Text);
                    
                    }
                DeltaBox_Copy.Text = DetCalc(App.Matrix).ToString();
                DeltaBox.Visibility = Visibility.Visible;
                DeltaBox_Copy.Visibility = Visibility.Visible;
                if(DeltaBox_Copy.Text.Length > 54)
                {
                    DeltaBox_Copy.FontSize = 36;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bad inputs!");
            }
}
        public static int DetCalc(int[,] matrix)
        {
            int determinant = 0;
            PermutationSet lol = new PermutationSet(matrix.GetLength(0) - 1);
            foreach (Permutation p in lol.Totals)
            {
                determinant += (int)Math.Pow(-1, p.Sign) * Element(p, matrix);
            }
            return determinant;
        }
        public static int Element(Permutation p, int[,] m)
        {
            int element = 1;
            for (int i = 1; i < p.Permuted.Length; i++)
            {
                element *= m[i, p.Permuted[i]];
            }
            return element;
        }
    }
    
}


