using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RegistroAspirantes
{
    class Conexion
    {

        public static SqlConnection agregarConexion()
        {
            SqlConnection conexion = new SqlConnection("Data Source=CC102-09\\SA;Initial Catalog=baseAspirantes;User ID=sa; Password=adminadmin");
            conexion.Open();
            return conexion;
        }

        public static void llenarComboProgramas(ComboBox cb)
        {
            try {
                SqlConnection conexion = agregarConexion();
                if(conexion != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT nombre FROM programas", conexion);
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        cb.Items.Add(rd.GetString(0));
                    }
                    cb.SelectedIndex = 0;
                    rd.Close();
                    conexion.Close();
                }
                else
                {
                    MessageBox.Show("No se puede conectar.");
                }
            } catch(Exception ex) { MessageBox.Show("Error: " + ex); }
        }

        public static void llenarComboProgramas2(ComboBox cb)
        {
            try
            {
                SqlConnection conexion = agregarConexion();
                if (conexion != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT nombre FROM aspirantes", conexion);
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        cb.Items.Add(rd.GetString(0));
                    }
                    cb.SelectedIndex = 0;
                    rd.Close();
                    conexion.Close();
                }
                else
                {
                    MessageBox.Show("No se puede conectar.");
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex); }
        }
    }

}
