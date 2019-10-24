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
using System.Windows.Shapes;

namespace RegistroAspirantes
{
    /// <summary>
    /// Interaction logic for Moedificacion.xaml
    /// </summary>
    public partial class Moedificacion : Window
    {
        public Moedificacion()
        {
            InitializeComponent();
            Conexion.llenarComboProgramas(cbProgramas);
            Conexion.llenarComboProgramas2(cbAspirantes);
        }

        private void bAceptar_Click(object sender, RoutedEventArgs e)
        {
            Aspirante a = new Aspirante();
            MessageBox.Show(/*modifica*/);
        }
    }
}
