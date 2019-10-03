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

namespace SmartCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextBox tb;
        int num;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void entrada_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            tb = sender as TextBox;
        }

        private void btFibo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                num = int.Parse(tb.Text);
                String res = "";

                if (num < 0)
                    res = "No existe. Debe ser mayor o igual a cero.";
                else if (num == 0)
                    res = "0";
                else if (num == 1)
                    res = "0 1";
                else if (num > 1)
                {
                    int n1 = 0, n2 = 1, n3, i;
                    res = "0 1";
                    for (i = 2; i < num; ++i) //loop starts from 2 because 0 and 1 are already printed    
                    {
                        n3 = n1 + n2;
                        res += " " + n3;
                        n1 = n2;
                        n2 = n3;
                    }
                }

                tb.Text = res;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }

        }

        private void btBinario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                num = int.Parse(tb.Text);
                String res = "";
                int remainder;

                string result = string.Empty;
                while (num > 0)
                {
                    remainder = num % 2;
                    num /= 2;
                    res = remainder.ToString() + res;
                }
                tb.Text = res;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void btSerieGeo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int n = int.Parse(tb.Text);
                String res = "";
                int t = 0;
                for (int i = 1; i <= n; i++)
                {
                    t += i;
                    res += " " + t;
                }
                tb.Text = res;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }

        }

        private void btCuadratic_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String[] variables = tb.Text.Split(' ');
                double a = int.Parse(variables[0]);
                double b = int.Parse(variables[1]);
                double c = int.Parse(variables[2]);

                double insideSquareRoot = (b * b) - 4 * a * c;
                double x1, x2;
                if (insideSquareRoot < 0)
                {
                    //There is no solution
                    x1 = double.NaN;
                    x2 = double.NaN;
                }
                else
                {
                    //Compute the value of each x
                    //if there is only one solution, both x's will be the same
                    double sqrt = Math.Sqrt(insideSquareRoot);
                    x1 = (-b + sqrt) / (2 * a);
                    x2 = (-b - sqrt) / (2 * a);
                }

                tb.Text = "x1: " + x1 + "   x2: " + x2;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void btMaxComDiv_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String[] nums = tb.Text.Split(' ');
                int numero1 = int.Parse(nums[0]);
                int numero2 = int.Parse(nums[1]);
                int a = Math.Max(numero1, numero2);
                int b = Math.Min(numero1, numero2);
                int res = 0;
                do //ciclo para las iteraciones
                {
                    res = b;  // Guardamos el divisor en el resultado
                    b = a % b;      //Guardamos el resto en el divisor
                    a = res;  //El divisor para al dividendo
                }
                while (b != 0);

                tb.Text = res.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }

            
        }

        private void BtClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tb.Text = "";
            }
            catch (Exception ex)
            {

            }
        }
    }
}