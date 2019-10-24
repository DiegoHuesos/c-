using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RegistroAspirantes
{
    class Aspirante
    {
        public String nombre, appellidoPaterno, apellidoMaterno, sexo, correo, fechaNac;
        public int grado, programa;

        public Aspirante()
        {
        }

        public Aspirante(string nombre, string appellidoPaterno, string apellidoMaterno, string sexo, string correo, int grado, int programa, String fechaNac)
        {
            this.nombre = nombre;
            this.appellidoPaterno = appellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            this.sexo = sexo;
            this.correo = correo;
            this.fechaNac = fechaNac;
            this.grado = grado;
            this.programa = programa;
        }

        internal string generaReporte(DataGrid dGReporte, ComboBox cbProgramas)
        {
            throw new NotImplementedException();
        }

        public String alta(Aspirante a)
        {
            String res = "";
            int i;
            try {
                SqlConnection con = Conexion.agregarConexion();
                SqlCommand cmd = new SqlCommand("SELECT top(1) idAspirante FROM aspirantes order by idAspirante DESC;");
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    i = rd.GetInt32(0) + 1;
                    rd.Close();
                    SqlCommand cmd2 = new SqlCommand(String.Format("INSERT INTO aspirantes VALUES({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', {7}, {8});", i, a.nombre, a.appellidoPaterno, a.apellidoMaterno, a.sexo, a.fechaNac, a.correo, a.grado, a.programa), con);
                    cmd2.ExecuteNonQuery();
                }
                else
                {
                    i = rd.GetInt32(0) + 1;
                    rd.Close();
                    SqlCommand cmd2 = new SqlCommand(String.Format("INSERT INTO aspirantes VALUES({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', {7}, {8});", 1, a.nombre, a.appellidoPaterno, a.apellidoMaterno, a.sexo, a.fechaNac, a.correo, a.grado, a.programa), con);
                    cmd2.ExecuteNonQuery();
                }

            } catch(Exception ex) { res = "alta no exitosa " + ex.Message; }
            return res;
        }

        public String modifica(int programa, String nombre)
        {
            String res = "";
            try
            {
                SqlConnection con = Conexion.agregarConexion();
                SqlCommand cmd = new SqlCommand(String.Format("UPDATE aspirantes SET clavePrograma={0} WHERE nombre='{1}'", programa, nombre) , con);
                cmd.ExecuteNonQuery();
                res = "Alta exitosa.";
            }catch(Exception ex)
            {
                res = "Error: " + ex.Message;
            }
            return res;
        }

        public String generaReporte(DataGrid dgreporte, int pro) {
            String res = "";
            try
            {
                SqlConnection con = Conexion.agregarConexion();
                SqlCommand cmd = new SqlCommand(String.Format("SELECT * FROM aspirantes WHERE clavePrograma={0}", programa), con);
                SqlDataReader rd = cmd.ExecuteReader();
                dgreporte.ItemsSource = rd;
                res = "Reporte exitos.";
                rd.Close();
            }
            catch (Exception ex)
            {
                res = "Error: " + ex.Message;
            }
            return res;
        }
    }
}
