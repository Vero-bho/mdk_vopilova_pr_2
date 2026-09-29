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
    public partial class Task4Page : Page
    {






        public Task4Page()
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
            if (string.IsNullOrWhiteSpace(txtArray.Text) ||
                string.IsNullOrWhiteSpace(txtB.Text))
            {
                MessageBox.Show("Заполните массив и число b!");
                return;
            }

            string[] parts = SplitNumbers(txtArray.Text);

            int[] a = new int[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                if (!int.TryParse(parts[i], out a[i]))
                {
                    MessageBox.Show($"\"{parts[i]}\" — не целое!");
                    return;
                }
            }

            if (!int.TryParse(txtB.Text, out int b))
            {
                MessageBox.Show("b — целое число!");
                return;
            }

            int[] less = new int[a.Length];
            int[] equal = new int[a.Length];
            int[] greater = new int[a.Length];
            int nLess = 0, nEqual = 0, nGreater = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < b)
                    less[nLess++] = a[i];
                else if (a[i] == b)
                    equal[nEqual++] = a[i];
                else
                    greater[nGreater++] = a[i];
            }

            int[] result = new int[a.Length];
            int k = 0;
            for (int i = 0; i < nLess; i++) result[k++] = less[i];
            for (int i = 0; i < nEqual; i++) result[k++] = equal[i];
            for (int i = 0; i < nGreater; i++) result[k++] = greater[i];

            txtResult.Text = "Исходный:  " + ArrayToString(a) + "\n" +
                             "Результат: " + ArrayToString(result);
        }
        private string ArrayToString(int[] arr)
        {
            string s = "";
            for (int i = 0; i < arr.Length; i++)
            {
                s += arr[i];
                if (i < arr.Length - 1)
                    s += " ";
            }
            return s;
        }

        private string[] SplitNumbers(string text)
        {
            char[] separators = { ' ', ',', ';', '\n', '\r', '\t' };

            int count = 0;
            bool inToken = false;
            for (int i = 0; i < text.Length; i++)
            {
                if (!IsSeparator(text[i], separators))
                {
                    if (!inToken) { count++; inToken = true; }
                }
                else
                {
                    inToken = false;
                }
            }

            string[] result = new string[count];
            int index = 0;
            string current = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (!IsSeparator(text[i], separators))
                {
                    current += text[i];
                }
                else
                {
                    if (current.Length > 0)
                    {
                        result[index++] = current;
                        current = "";
                    }
                }
            }

            if (current.Length > 0)
                result[index] = current;

            return result;
        }

        private bool IsSeparator(char c, char[] separators)
        {
            for (int i = 0; i < separators.Length; i++)
                if (c == separators[i])
                    return true;
            return false;
        }
    }
}
