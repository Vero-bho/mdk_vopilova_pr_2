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

namespace m1.Pages
{
    public partial class Task2Page : Page
    {
        public Task2Page()
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
            if (string.IsNullOrWhiteSpace(txtInput.Text))
            {
                MessageBox.Show("Введите строку!");
                return;
            }

            string[] words = SplitWords(txtInput.Text);

            string[] reversed = new string[words.Length];
            for (int i = 0; i < words.Length; i++)
                reversed[i] = words[words.Length - 1 - i];

            string result = "";
            for (int i = 0; i < reversed.Length; i++)
            {
                result += reversed[i];
                if (i < reversed.Length - 1)
                    result += " ";
            }

            txtResult.Text = result;
        }

        private string[] SplitWords(string text)
        {
            int count = 0;
            bool inWord = false;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != ' ')
                {
                    if (!inWord) { count++; inWord = true; }
                }
                else
                {
                    inWord = false;
                }
            }

            string[] words = new string[count];
            int index = 0;
            string current = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != ' ')
                {
                    current += text[i];
                }
                else
                {
                    if (current.Length > 0)
                    {
                        words[index++] = current;
                        current = "";
                    }
                }
            }

            if (current.Length > 0)
                words[index] = current;

            return words;
        }
    }
}
