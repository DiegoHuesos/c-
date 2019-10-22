using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace videojuegos
{
    public partial class Pagina4 : System.Web.UI.Page
    {
        public OdbcConnection conectarBD()
        {
            String stringConexion = "Driver={SQL Server Native Client 11.0};Server=CC102-09\\SA;Uid=sa;Pwd=adminadmin;Database=gameSpot";
            try
            {
                OdbcConnection conexion = new OdbcConnection(stringConexion);
                conexion.Open();
                lbError.Text = "conexion exitosa";
                return conexion;
            }
            catch (Exception ex)
            {
                lbError.Text = ex.StackTrace.ToString();
                return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OdbcConnection miConexion = conectarBD();
                if (miConexion != null)
                {
                    String query = String.Format("SELECT juegos.nombre from juegos, escriben WHERE escriben.claveU={0} AND escriben.claveJ=juegos.claveJ", Session["claveUnica"].ToString());
                    OdbcCommand cmd = new OdbcCommand(query, miConexion);
                    OdbcDataReader rd = cmd.ExecuteReader();
                    ddJuegos.Items.Clear();
                    while (rd.Read())
                    {
                        ddJuegos.Items.Add(rd.GetString(0));
                    }
                    rd.Close();
                }
            }
        }

        protected void ddJuegos_SelectedIndexChanged(object sender, EventArgs e)
        {
            OdbcConnection miConexion = conectarBD();
            if (miConexion != null)
            {
                String query = String.Format("SELECT juegos.claveJ FROM juegos WHERE nombre='{0}'", ddJuegos.SelectedValue);
                OdbcCommand cmd = new OdbcCommand(query, miConexion);
                OdbcDataReader rd = cmd.ExecuteReader();
                rd.Read();

                int claveJuego = rd.GetInt32(0);
                rd.Close();
                String query2 = String.Format("SELECT nombre, resumen, consola, fechaLanzamiento FROM juegos WHERE claveJ={0}",  claveJuego);
                OdbcCommand cmd2 = new OdbcCommand(query2, miConexion);
                OdbcDataReader rd2 = cmd2.ExecuteReader();
                //rd2.Read(); no se ejecuta este porque no le estamos pasando el resultado, sino el apuntador para que quede bindeado:
                gvJuegos.DataSource = rd2;
                gvJuegos.DataBind();
                rd2.Close();
            }
            else
                Console.WriteLine("Hola");

        }

        protected void gvJuegos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}