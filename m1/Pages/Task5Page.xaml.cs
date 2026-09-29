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
    public partial class Task5Page : Page
    {
        public Task5Page()
        {
            InitializeComponent();
        }
        private readonly Random _rnd = new Random();
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mw)
            {
                mw.FrmMain.Content = null;
                mw.SetMenuVisibility(Visibility.Visible);
            }
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtRows.Text, out int n) || n < 1 || n > 20)
            {
                MessageBox.Show("N — целое от 1 до 20!");
                return;
            }
            if (!int.TryParse(txtCols.Text, out int m) || m < 1 || m > 20)
            {
                MessageBox.Show("M — целое от 1 до 20!");
                return;
            }

            int[,] a = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    a[i, j] = _rnd.Next(-10, 11);

            txtOriginal.Text = MatrixToString(a);

            int[] flat = new int[n * m];
            int k = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    flat[k++] = a[i, j];

            int[] asc = CopyArray(flat);
            int[] desc = CopyArray(flat);

            SortAsc(asc);

            SortDesc(desc);

            int[,] ascM = ToMatrix(asc, n, m);
            int[,] descM = ToMatrix(desc, n, m);

            txtAsc.Text = MatrixToString(ascM);
            txtDesc.Text = MatrixToString(descM);

            int min = flat[0], max = flat[0];
            for (int i = 1; i < flat.Length; i++)
            {
                if (flat[i] < min) min = flat[i];
                if (flat[i] > max) max = flat[i];
            }

            txtMinMax.Text = $"Минимум: {min}    Максимум: {max}";
        }

        private int[] CopyArray(int[] src)
        {
            int[] dst = new int[src.Length];
            for (int i = 0; i < src.Length; i++)
                dst[i] = src[i];
            return dst;
        }

        private void SortAsc(int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = 0; j < a.Length - 1 - i; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        int t = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = t;
                    }
                }
            }
        }

        private void SortDesc(int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = 0; j < a.Length - 1 - i; j++)
                {
                    if (a[j] < a[j + 1])
                    {
                        int t = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = t;
                    }
                }
            }
        }

        private int[,] ToMatrix(int[] src, int n, int m)
        {
            int[,] r = new int[n, m];
            int k = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    r[i, j] = src[k++];
            return r;
        }

        private string MatrixToString(int[,] a)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    sb.Append(a[i, j].ToString().PadLeft(5));
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}

