using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace matrixCalc
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int n = 0;

        public string PlaceholderText { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }


        private void TbNum_MouseEnter(object sender, MouseEventArgs e)
        {
            if (tbNum.Text.Equals("Ingresa la longitud de la matriz"))
                tbNum.Text = "";
        }

        private void TbNum_MouseLeave_1(object sender, MouseEventArgs e)
        {
            if (tbNum.Text.Equals(""))
                tbNum.Text = "Ingresa la longitud de la matriz";
        }


        private void TbNum_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return)
            {
                try
                {
                    n = int.Parse(tbNum.Text);
                    for(int i = 0; i<n; i++){
                        for(int j=0; j<n; j++){

                            Button b = new Button();
                            Thickness m = b.Margin;
                            m.Left = 10 + (i * 10);
                            m.Top = 10 + (i * 10);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }
        }
    }
}
