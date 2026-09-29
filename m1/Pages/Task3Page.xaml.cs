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
    public partial class Task3Page : Page
    {
        public Task3Page()
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
                MessageBox.Show("Введите числа!");
                return;
            }

            string[] parts = SplitNumbers(txtInput.Text);

            if (parts.Length == 0)
            {
                MessageBox.Show("Не найдено ни одного числа!");
                return;
            }

            if (parts.Length > 30)
            {
                MessageBox.Show("Не более 30 чисел!");
                return;
            }

            int[] a = new int[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                if (!int.TryParse(parts[i], out a[i]))
                {
                    MessageBox.Show($"\"{parts[i]}\" — не целое число!");
                    return;
                }
            }

            int bestStart = 0, bestLen = 0;
            int curStart = 0, curLen = 1;

            for (int i = 1; i < a.Length; i++)
            {
                int prev = a[i - 1];
                if (prev != 0 && a[i] != 0 && a[i] % prev == 0)
                {
                    curLen++;
                }
                else
                {
                    if (curLen > bestLen)
                    {
                        bestLen = curLen;
                        bestStart = curStart;
                    }
                    curStart = i;
                    curLen = 1;
                }
            }
            if (curLen > bestLen)
            {
                bestLen = curLen;
                bestStart = curStart;
            }

            if (bestLen == 0)
            {
                txtResult.Text = "Подпоследовательность не найдена.";
                return;
            }

            string output = $"Длина: {bestLen}\nЭлементы: ";
            for (int i = 0; i < bestLen; i++)
            {
                output += a[bestStart + i];
                if (i < bestLen - 1)
                    output += " → ";
            }


            txtResult.Text = output;
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
