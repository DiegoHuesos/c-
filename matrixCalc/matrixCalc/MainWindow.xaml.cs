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
using System.Windows.Resources;
using System.Windows.Shapes;

namespace matrixCalc
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<String> carrito = new List<String>();

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


       

        public int click(Button bt)
        {
            return Convert.ToInt32(bt.Tag);
        }
        private void TbNum_KeyDown(object sender, KeyEventArgs e)
        {
            
            //Si presiona enter:
            if (e.Key == Key.Return)
            {

                grid.Columns = 2;
                grid.Rows = 2;


                for(int i = 0; i<4; i++)
                {
                    //Create button:
                    Button bt = new Button();

                    //Add image to button:
                    Uri resourceUri = new Uri("./pencil.jpg", UriKind.Relative);
                    StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);
                    BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                    var brush = new ImageBrush();
                    brush.ImageSource = temp;
                    bt.Background = brush;
                    grid.Children.Add(bt);
                    bt.Tag = i;
                    //AddEvent:
                    bt.Click += delegate
                    {
                        carrito.Add(""+this.click(bt));
                    };

                }
                
            }
        }
    }
}
