using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatrixCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int val;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!int.TryParse((sender as TextBox).Text,out val))
            {
                StarterButton.IsEnabled = false;
                return;
            }
            if(val > 11 || val < 1)
            {
                StarterButton.IsEnabled = false;
                return;
            }
            StarterButton.IsEnabled = true;
        }

        private void StarterButton_Click(object sender, RoutedEventArgs e)
        {
            StarterButton.IsEnabled = false;
            App.SetMatrixVal(val);
            Window1 window1 = new Window1();
            window1.ShowDialog();
            StarterButton.IsEnabled = true;
        }
    }
}
