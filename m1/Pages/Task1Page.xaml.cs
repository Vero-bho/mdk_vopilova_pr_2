using System;
using System.Collections.Generic;
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
using System.Numerics;

namespace m1.Pages
{
    public partial class Task1Page : Page
    {
        public Task1Page()
        {
            InitializeComponent();
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mw)
            {
                mw.FrmMain.Content = null;
                mw.SetMenuVisibility(Visibility.Visible);
            }
        }
        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtN.Text))
            {
                MessageBox.Show("Введите n!"); return;
            }

            if (!int.TryParse(txtN.Text, out int n) || n < 1 || n > 100)
            {
                MessageBox.Show("n — целое от 1 до 100!"); return;
            }

            BigInteger fact = BigInteger.One;
            for (int i = 2; i <= n; i++)
                fact *= i;

            txtResult.Text = $"2 * {n}! = {2 * fact}";
        }
    }
}
