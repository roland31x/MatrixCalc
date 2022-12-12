using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MatrixCalc
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static int MatrixVal { get; set; }
        public static int[,] Matrix = new int[MatrixVal + 1, MatrixVal + 1]; 
        public static void SetMatrixVal(int val)
        {
            MatrixVal = val;
        }
    }
}
