using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace videojuegos
{
    public partial class Pagina3 : System.Web.UI.Page
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
            OdbcConnection miConexion = conectarBD();
            if (miConexion != null)
            {
                String query = String.Format("SELECT juegos.nombre from juegos, escriben WHERE escriben.claveU={0} AND escriben.claveJ=juegos.claveJ",Session["claveUnica"].ToString());
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Pagina4.aspx");
        }

        protected void ddJuegos_SelectedIndexChanged(object sender, EventArgs e)
        {
            OdbcConnection miConexion = conectarBD();
            if (miConexion != null)
            {
                String query = String.Format("SELECT claveJ FROM juegos WHERE nombre='{0}'",ddJuegos.SelectedValue);
                OdbcCommand cmd = new OdbcCommand(query, miConexion);
                OdbcDataReader rd = cmd.ExecuteReader();
                rd.Read();
                int claveJuego = rd.GetInt32(0);

                String query2 = String.Format("SELECT critica.contenido FROM critica WHERE critica.claveC= (SELECT claveC FROM escriben WHERE escriben.claveU={0} and escriben.claveJ={1})",  Session["claveUnica"].ToString(), claveJuego);
                OdbcCommand cmd2 = new OdbcCommand(query2, miConexion);
                OdbcDataReader rd2 = cmd.ExecuteReader();
                rd2.Read();
                lbCritica.Text= rd.GetString(0);
                rd.Close();
                rd2.Close();
            }
            else
                Console.WriteLine("Hola");
        }
    }
}