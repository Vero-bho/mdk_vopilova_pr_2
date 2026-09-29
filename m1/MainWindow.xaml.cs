using m1.Pages;
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

namespace m1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OpenPage(Page page)
        {
            SetMenuVisibility(Visibility.Collapsed);
            FrmMain.Navigate(page);
        }
        public void SetMenuVisibility(Visibility v)
        {
            pnlMenu.Visibility = v;
        }

        private void btnTask1_Click(object sender, RoutedEventArgs e) => OpenPage(new Task1Page());
        private void btnTask2_Click(object sender, RoutedEventArgs e) => OpenPage(new Task2Page());
        private void btnTask3_Click(object sender, RoutedEventArgs e) => OpenPage(new Task3Page());
        private void btnTask4_Click(object sender, RoutedEventArgs e) => OpenPage(new Task4Page());
        private void btnTask5_Click(object sender, RoutedEventArgs e) => OpenPage(new Task5Page());
    }
}
